﻿using Spectre.Console.Cli;

public static class Program
{
    public static int Main(string[] args)
    {
        // grab env vars from .env
        var root = Directory.GetCurrentDirectory();
        var envFile = Path.Combine(root, ".env");
        DotEnv.Load(envFile);

		var app = new CommandApp();
        app.Configure(config =>
        {
            #if DEBUG
                config.PropagateExceptions();
                config.ValidateExamples();
            #endif
            config.SetApplicationName("toshimon");
            config.CaseSensitivity(CaseSensitivity.None);

            config.AddCommand<PlayCommand>("play");
            config.AddCommand<CreateProposalCommand>("propose");
            config.AddCommand<AcceptProposalCommand>("accept");
            config.AddCommand<StatusCommand>("status");
            config.AddCommand<ChallengeCommand>("challenge");
            config.AddCommand<CheckpointCommand>("checkpoint");

        });		

		return app.Run(args);
    }
}
