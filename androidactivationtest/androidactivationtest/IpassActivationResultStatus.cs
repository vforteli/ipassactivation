using System;

namespace androidactivationtest
{
    public enum IpassActivationResultStatus
    {
        OperationSucceeded = 0,
        ProvisioningAlreadyInProgress = 1,
        InternalError = 2,
        InvalidProfileId = 10,
        InvalidAutoLoginSetting = 11,
        DomainMismatch = 20,
        PrefixMismatch = 21,
        InvalidUserData = 23,
        ServerCommunicationInterrupted = 30,
        TransientError = 31,
        NoInternetAccess = 32,
        InvalidProfileIdorPin = 33
    }
}
