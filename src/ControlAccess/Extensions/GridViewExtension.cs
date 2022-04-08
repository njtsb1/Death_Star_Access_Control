using System.Windows.Forms;

namespace ControlAcess.Extensions
{
    public static class GridViewExtension
    {

        public static int GetCountRowsChecked(this DataGridViewRowCollection lines, int indexColCheck)
        {
            int qtde = 0;

            foreach(DataGridViewRow line in lines)
            {
                var cell = line.Cells[indexColCheck] as DataGridViewCheckBoxCell;
                if (cell.Value != null && (bool)cell.Value)
                    ++qtde;
            }

            return qtde;
        }

        public static int GetFirstIndexChecked(this DataGridViewRowCollection lines, int indexColCheck)
        {
            int index = -1;

            foreach (DataGridViewRow line in lines)
            {
                var cell = line.Cells[indexColCheck] as DataGridViewCheckBoxCell;
                ++index;

                if (cell.Value != null && (bool)cell.Value)
                    return index;
            }

            return -1;
        }
    }
}
