---
title: Thêm Văn Bản Động
type: docs
weight: 40
url: /vi/net/adding-text-dynamically/
---
Cả hai phương pháp đều tuân theo các bước sau:

- Tạo một bản trình chiếu.
- Thêm một slide trống.
- Thêm một hộp văn bản.
- Đặt một đoạn văn bản.
- Ghi lại bản trình chiếu.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Tạo một bản trình chiếu
	PowerPoint.Presentation pres = Globals.ThisAddIn.Application
		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
	//Lấy bố cục slide trống
	PowerPoint.CustomLayout layout = pres.SlideMaster.
		CustomLayouts[7];
	//Thêm một slide trống
	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);
	//Thêm văn bản
	PowerPoint.Shape shp =sld.Shapes.AddTextbox
	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);
	//Đặt văn bản
	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
	txtRange.Text = "Text added dynamically";
	txtRange.Font.Name = "Arial";
	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
	txtRange.Font.Size = 32;
	//Ghi đầu ra ra đĩa
	pres.SaveAs("outVSTOAddingText.ppt",
		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
		Microsoft.Office.Core.MsoTriState.msoFalse);
}
``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//Tạo một bản trình chiếu
	Presentation pres = new Presentation();
	//Slide trống được thêm mặc định, khi bạn tạo
	//bản trình chiếu từ hàm khởi tạo mặc định
	//Vì vậy, chúng ta không cần thêm bất kỳ slide trống nào
	Slide sld = pres.GetSlideByPosition(1);
	//Lấy chỉ số phông chữ cho Arial
	//Nó luôn luôn là 0 nếu bạn tạo bản trình chiếu từ
	//hàm khởi tạo mặc định
	int arialFontIndex = 0;
	//Thêm một hộp văn bản
	//Để thêm nó, chúng ta sẽ đầu tiên thêm một hình chữ nhật
	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);
	//Ẩn đường viền của nó
	shp.LineFormat.ShowLines = false;
	//Sau đó thêm một khung văn bản bên trong
	TextFrame tf = shp.AddTextFrame("");
	//Đặt văn bản
	tf.Text = "Text added dynamically";
	Portion port = tf.Paragraphs[0].Portions[0];
	port.FontIndex = arialFontIndex;
	port.FontBold = true;
	port.FontHeight = 32;
	//Ghi đầu ra ra đĩa
	pres.Write("outAspose.ppt");
}
``` 
## **Tải mã mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)