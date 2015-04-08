using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace S2MMSH
{
    public enum ASF_STATUS
    {
        NULL,               // 初期状態
        SET_HEADER          // ASFヘッダ作成済み
    };

    public enum MMSH_STATUS
    {
        NULL,               // 初期状態
        CONNECTED,          // 
        HTTP_HEADER_SEND,
        ASF_HEADER_SEND,
        ASF_DATA_SENDING
    };

    public enum FFMPEG_STATUS
    {
        NULL,               // 初期状態
        INITIALIZED,        // 初期化済
        INITIALIZING,        // 初期化中
        PROCESS              // 処理中
    };

    public enum VC1ENC_STATUS
    {
        NULL,               // 初期状態
        STARTED,            // StartEnc済み
        SET_HEADER          // ASFヘッダ書き換え済み
    };

    public sealed class AsfData
    {
        private static AsfData m_Instance = new AsfData();
        public ASF_STATUS asf_status = ASF_STATUS.NULL;
        public int asf_header_size = 0;
        public byte[] asf_header = new byte[65535];
        public Socket mms_sock = null;
        public MMSH_STATUS mmsh_status = MMSH_STATUS.NULL;

        private AsfData()
        {
            Console.WriteLine("Created instance.");
        }

        public static AsfData Instance
        {
            get
            {
                return m_Instance;
            }
        }

        public void DoSomething()
        {
            Console.WriteLine("DoSomething is called");
        }

    }

    // singleton
    public sealed class ProcessManager
    {
        private static ProcessManager m_Instance = new ProcessManager();
        public Process process =  null;
        public Thread th_server = null;
        public Thread th_ffmpeg = null;
        public Boolean serverstatus = true;
        public Socket server = null;
        public FFMPEG_STATUS ffmpegstatus = FFMPEG_STATUS.NULL;

        public CVC1EncWrapper vc1enc = null;
        public VC1ENC_STATUS vc1encstatus = VC1ENC_STATUS.NULL;

        public Thread th_ffmpeg2 = null;
        public Process process2 = null;

        private ProcessManager()
        {
            Console.WriteLine("Created instance.");
        }

        public static ProcessManager Instance
        {
            get
            {
                return m_Instance;
            }
        }

        public void DoSomething()
        {
            Console.WriteLine("DoSomething is called");
        }
    }

}
