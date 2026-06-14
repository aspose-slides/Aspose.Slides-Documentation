---
title: Tạo một Bảng trên Slide PowerPoint trong VSTO và Aspose.Slides
type: docs
weight: 90
url: /vi/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---
Các bước sau thêm một bảng vào một slide Microsoft PowerPoint bằng VSTO:

- Tạo một bản trình bày.
- Thêm một slide trống vào bản trình bày.
- Thêm một bảng 15 x 15 vào slide.
- Thêm văn bản vào mỗi ô của bảng với kích thước phông chữ 10.
- Lưu bản trình bày vào đĩa.
## **VSTO**
``` csharp

 //Tạo một bản trình bày

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Thêm một slide trống

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Thêm một bảng 15 x 15

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//Duyệt qua tất cả các hàng

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

	//Duyệt qua tất cả các ô trong hàng

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

//Lưu bản trình bày vào đĩa

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

Các bước sau thêm một bảng vào một slide Microsoft PowerPoint bằng Aspose.Slides:

- Tạo một bản trình bày.
- Thêm một bảng 15 x 15 vào slide đầu tiên.
- Thêm văn bản vào mỗi ô của bảng với kích thước phông chữ 10.
- Ghi bản trình bày vào đĩa.
## **Aspose.Slides**
``` csharp

 //Tạo một bản trình bày
Presentation pres = new Presentation();

//Truy cập slide đầu tiên
Slide sld = pres.GetSlideByPosition(1);

//Thêm một bảng
Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

//Lặp qua các hàng

for (int i = 0; i < tbl.RowsNumber; i++)
	//Lặp qua các ô
	for (int j = 0; j < tbl.ColumnsNumber; j++)
	{
		//Lấy khung văn bản của mỗi ô
		TextFrame tf = tbl.GetCell(j, i).TextFrame;

		//Thêm một số văn bản
		tf.Text = "T" + i.ToString() + j.ToString();

		//Đặt kích thước phông chữ là 10
		tf.Paragraphs[0].Portions[0].FontHeight = 10;
		tf.Paragraphs[0].HasBullet = false;
	}

//Ghi bản trình bày vào đĩa
pres.Write("tblSLD.ppt");

``` 
## **Tải Mã Mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)