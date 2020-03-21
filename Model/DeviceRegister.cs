using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetaPoco;

namespace PetaPocoWebApi.Model
{
    [TableName("YYSG_SBS")]
    [PrimaryKey("ID", AutoIncrement = false)]
    public class DeviceRegister
    {
        [Column("ID")]
        public string ID { get; set; }

        [Column("SB_ID")]
        public Guid SB_ID { get; set; }

        [Column("FJ_SB_ID")]
        public string FJ_SB_ID { get; set; }

        [Column("SFXN_XLH")]
        public bool SFXN_XLH { get; set; }

        [Column("DW_BM")]
        public string DW_BM { get; set; }

        [Column("SB_BH")]
        public string SB_BH { get; set; }

        [Column("SB_XLH")]
        public string SB_XLH { get; set; }

        [Column("SFZC")]
        public bool SFZC { get; set; }

        [Column("SBLX_BH")]
        public int SBLX_BH { get; set; }

        [Column("SBLX_MC")]
        public string SBLX_MC { get; set; }

        [Column("GZX")]
        public string GZX { get; set; }

        [Column("YWLX")]
        public int YWLX { get; set; }

        [Column("Segments")]
        public string Segments { get; set; }

        [Column("ND")]
        public int ND { get; set; }

        [Column("SwVersion")]
        public string SwVersion { get; set; }

        [Column("CCJB")]
        public int CCJB { get; set; }

        [Column("QID")]
        public string QID { get; set; }

        [Column("QMC")]
        public string QMC { get; set; }

        [Column("SBXH_MC")]
        public string SBXH_MC { get; set; }

        [Column("SFTB")]
        public bool SFTB { get; set; }

        [Column("SFSC")]
        public bool SFSC { get; set; }

        /*               [Column("VisionCode")]
                       public string VisionCode { get; set; }*/
    }
}
