---
title: Tạo Bảng Bằng VSTO và Aspose.Slides cho .NET
linktitle: Tạo Bảng
type: docs
weight: 50
url: /vi/net/creating-a-table-on-powerpoint-slide/
keywords:
- tạo bảng
- di chuyển
- VSTO
- tự động hoá Office
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Di chuyển từ tự động hoá Microsoft Office sang Aspose.Slides for .NET và tạo bảng trong các slide PowerPoint (PPT, PPTX) bằng C# với định dạng linh hoạt."
---
{{% alert color="primary" %}} 

Bảng thường được sử dụng để hiển thị dữ liệu trên các slide thuyết trình. Bài viết này trình bày cách tạo một bảng 15 x 15 với kích thước phông chữ 10 một cách lập trình, đầu tiên bằng [VSTO 2008](/slides/vi/net/creating-a-table-on-powerpoint-slide/) và sau đó bằng [Aspose.Slides for .NET](/slides/vi/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **Creating Tables**
#### **VSTO 2008 Example**
Các bước sau sẽ thêm một bảng vào slide Microsoft PowerPoint bằng VSTO:

1. Tạo một bản thuyết trình.
1. Thêm một slide trống vào bản thuyết trình.
1. Thêm một bảng 15 x 15 vào slide.
1. Thêm văn bản vào mỗi ô của bảng với kích thước phông chữ 10.
1. Lưu bản thuyết trình vào đĩa.

```c#
//Tạo một bản thuyết trình
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Thêm một slide trống
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Thêm một bảng 15 x 15
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//Lặp qua tất cả các hàng
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Lặp qua tất cả các ô trong hàng
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Lấy khung văn bản của mỗi ô
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Thêm một số văn bản
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Đặt kích thước phông chữ của văn bản là 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Lưu bản thuyết trình vào đĩa
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Aspose.Slides for .NET Example**
Các bước sau sẽ thêm một bảng vào slide Microsoft PowerPoint bằng Aspose.Slides:

1. Tạo một bản thuyết trình.
1. Thêm một bảng 15 x 15 vào slide đầu tiên.
1. Thêm văn bản vào mỗi ô của bảng với kích thước phông chữ 10.
1. Ghi bản thuyết trình ra đĩa.

```c#
Presentation pres = new Presentation();

//Truy cập slide đầu tiên
ISlide sld = pres.Slides[0];

//Xác định các cột với độ rộng và các hàng với chiều cao
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Thêm một bảng
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Đặt định dạng viền cho mỗi ô
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Lấy khung văn bản của mỗi ô
		ITextFrame tf = cell.TextFrame;
		//Thêm một số văn bản
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Đặt kích thước phông chữ là 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Ghi bản thuyết trình vào đĩa
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```