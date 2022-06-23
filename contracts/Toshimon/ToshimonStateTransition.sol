// SPDX-License-Identifier: MIT

/**
 * Created on 2022-06-23 12:37
 * @summary: The state transition function that captures all the rules of the Toshimon battle game
 * @author: Willem Olding (ChainSafe)
 */
pragma solidity 0.7.6;
pragma experimental ABIEncoderV2;

import "@openzeppelin/contracts/math/SafeMath.sol";
import './CommitRevealApp.sol';

contract ToshimonStateTransition is CommitRevealApp {

    function advanceState(
        bytes memory _gameState_,
        Outcome.SingleAssetExit[] memory outcome,
        uint8 _moveA,
        uint8 _moveB,
        bytes32 randomSeed
    ) override public pure returns (bytes memory, Outcome.SingleAssetExit[] memory, bool) {
        GameState memory gameState = _gameState(_gameState_);
        
    }

    // For incentive reasons it needs to ensure that each time a player makes
    // a state update they set themselves as the winning player
    // unless the game forces otherwise via a conclusion
    // 
    // The entire balance is reallocated to the winning player index by this function
    // 
    // This assumes the outcome is ordered according to the players.
    function updateOutcomeFavourPlayer(
        Outcome.SingleAssetExit[] memory outcome,
        uint8 playerIndex
    ) override public pure returns (Outcome.SingleAssetExit[] memory) {
        Outcome.SingleAssetExit memory assetExit = outcome[0];
        uint256 total = assetExit.allocations[0].amount + assetExit.allocations[1].amount;

        outcome[0].allocations[playerIndex].amount = total;
        outcome[0].allocations[~playerIndex].amount = 0;

        return (outcome);
    }

}
