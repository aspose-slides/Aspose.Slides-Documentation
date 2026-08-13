---
title: Thêm Văn Bản Động Bằng VSTO và Aspose.Slides cho .NET
linktitle: Thêm Văn Bản Động
type: docs
weight: 20
url: /vi/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- thêm văn bản
- di chuyển
- VSTO
- tự động hoá Office
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Xem cách di chuyển từ tự động hoá Microsoft Office sang Aspose.Slides cho .NET và thêm văn bản động vào các bản trình bày PowerPoint (PPT, PPTX) trong C#."
---
{{% alert color="info" %}} 

Một nhiệm vụ phổ biến mà các nhà phát triển thường thực hiện là thêm văn bản vào các slide một cách động. Bài viết này trình bày các ví dụ mã để thêm văn bản một cách động bằng cách sử dụng [VSTO](/slides/vi/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) và [Aspose.Slides for .NET](/slides/vi/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Adding Text Dynamically**
Cả hai phương pháp đều tuân theo các bước sau:

1. Tạo một bản trình bày.
1. Thêm một slide trống.
1. Thêm một hộp văn bản.
1. Đặt một số văn bản.
1. Ghi (lưu) bản trình bày.
## **VSTO Code Example**
Các đoạn mã bên dưới tạo ra một bản trình bày với một slide trống và một chuỗi văn bản trên đó.

**The presentation as created in VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Lưu ý: PowerPoint là một không gian tên đã được định nghĩa ở trên như thế này
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Tạo một bản trình bày
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Lấy bố cục slide trống
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Thêm một slide trống
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Thêm văn bản
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Đặt văn bản
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Ghi đầu ra ra đĩa
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);

```



## **Aspose.Slides for .NET Example**
Các đoạn mã bên dưới sử dụng Aspose.Slides để tạo một bản trình bày với một slide trống và một chuỗi văn bản trên đó.

**The presentation as created using Aspose.Slides for .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//Tạo một bản trình bày
Presentation pres = new Presentation();

//Slide trống được thêm mặc định, khi bạn tạo
//bản trình bày từ hàm khởi tạo mặc định
//Vì vậy, chúng ta không cần thêm bất kỳ slide trống nào
ISlide sld = pres.Slides[1];

//Thêm một textbox
//Để thêm nó, chúng ta sẽ đầu tiên thêm một hình chữ nhật
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Ẩn đường viền của nó
shp.LineFormat.Style = LineStyle.NotDefined;

//Sau đó thêm một khung văn bản bên trong
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Đặt văn bản
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Ghi đầu ra ra đĩa
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```