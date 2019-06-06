//-----------------------------------------------------------------------------
//
//    ** DO NOT EDIT THIS FILE! **
//    This file was generated by a tool
//    re-running the tool will overwrite this file.
//
//-----------------------------------------------------------------------------


#include "nanoFramework_Hardware_Esp32.h"
#include "nanoFramework_Hardware_Esp32_nanoFramework_Hardware_Esp32_HighResTimer.h"

using namespace nanoFramework::Hardware::Esp32;


HRESULT Library_nanoFramework_Hardware_Esp32_nanoFramework_Hardware_Esp32_HighResTimer::NativeEspTimerCreate___I4( CLR_RT_StackFrame& stack )
{
    NANOCLR_HEADER(); hr = S_OK;
    {
        CLR_RT_HeapBlock* pMngObj = Interop_Marshal_RetrieveManagedObject( stack );

        FAULT_ON_NULL(pMngObj);

        signed int retVal = HighResTimer::NativeEspTimerCreate( pMngObj,  hr );
        NANOCLR_CHECK_HRESULT( hr );
        SetResult_INT32( stack, retVal );

    }
    NANOCLR_NOCLEANUP();
}

HRESULT Library_nanoFramework_Hardware_Esp32_nanoFramework_Hardware_Esp32_HighResTimer::NativeEspTimerDispose___VOID( CLR_RT_StackFrame& stack )
{
    NANOCLR_HEADER(); hr = S_OK;
    {
        CLR_RT_HeapBlock* pMngObj = Interop_Marshal_RetrieveManagedObject( stack );

        FAULT_ON_NULL(pMngObj);

        HighResTimer::NativeEspTimerDispose( pMngObj,  hr );
        NANOCLR_CHECK_HRESULT( hr );
    }
    NANOCLR_NOCLEANUP();
}

HRESULT Library_nanoFramework_Hardware_Esp32_nanoFramework_Hardware_Esp32_HighResTimer::NativeStop___VOID( CLR_RT_StackFrame& stack )
{
    NANOCLR_HEADER(); hr = S_OK;
    {
        CLR_RT_HeapBlock* pMngObj = Interop_Marshal_RetrieveManagedObject( stack );

        FAULT_ON_NULL(pMngObj);

        HighResTimer::NativeStop( pMngObj,  hr );
        NANOCLR_CHECK_HRESULT( hr );
    }
    NANOCLR_NOCLEANUP();
}

HRESULT Library_nanoFramework_Hardware_Esp32_nanoFramework_Hardware_Esp32_HighResTimer::NativeStartOneShot___VOID__U8( CLR_RT_StackFrame& stack )
{
    NANOCLR_HEADER(); hr = S_OK;
    {
        CLR_RT_HeapBlock* pMngObj = Interop_Marshal_RetrieveManagedObject( stack );

        FAULT_ON_NULL(pMngObj);

        unsigned __int64 param0;
        NANOCLR_CHECK_HRESULT( Interop_Marshal_UINT64( stack, 1, param0 ) );

        HighResTimer::NativeStartOneShot( pMngObj,  param0, hr );
        NANOCLR_CHECK_HRESULT( hr );
    }
    NANOCLR_NOCLEANUP();
}

HRESULT Library_nanoFramework_Hardware_Esp32_nanoFramework_Hardware_Esp32_HighResTimer::NativeStartPeriodic___VOID__U8( CLR_RT_StackFrame& stack )
{
    NANOCLR_HEADER(); hr = S_OK;
    {
        CLR_RT_HeapBlock* pMngObj = Interop_Marshal_RetrieveManagedObject( stack );

        FAULT_ON_NULL(pMngObj);

        unsigned __int64 param0;
        NANOCLR_CHECK_HRESULT( Interop_Marshal_UINT64( stack, 1, param0 ) );

        HighResTimer::NativeStartPeriodic( pMngObj,  param0, hr );
        NANOCLR_CHECK_HRESULT( hr );
    }
    NANOCLR_NOCLEANUP();
}

HRESULT Library_nanoFramework_Hardware_Esp32_nanoFramework_Hardware_Esp32_HighResTimer::NativeGetCurrent___STATIC__U8( CLR_RT_StackFrame& stack )
{
    NANOCLR_HEADER(); hr = S_OK;
    {
        unsigned __int64 retVal = HighResTimer::NativeGetCurrent( hr );
        NANOCLR_CHECK_HRESULT( hr );
        SetResult_UINT64( stack, retVal );

    }
    NANOCLR_NOCLEANUP();
}
