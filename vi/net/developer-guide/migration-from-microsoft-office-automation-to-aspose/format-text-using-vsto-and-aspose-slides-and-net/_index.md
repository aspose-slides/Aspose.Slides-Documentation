---
title: Định dạng văn bản bằng VSTO và Aspose.Slides cho .NET
linktitle: Định dạng Văn bản
type: docs
weight: 30
url: /vi/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- định dạng văn bản
- di chuyển
- VSTO
- tự động hoá Office
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Di chuyển từ tự động hoá Microsoft Office sang Aspose.Slides cho .NET và định dạng văn bản trong các bài thuyết trình PowerPoint (PPT, PPTX) với kiểm soát chính xác."
---
{{% alert color="info" %}} 

Đôi khi, bạn cần định dạng văn bản trên các slide một cách lập trình. Bài viết này hướng dẫn cách đọc một bài thuyết trình mẫu có một số văn bản trên slide đầu tiên bằng cách sử dụng hoặc [VSTO](/slides/vi/net/format-text-using-vsto-and-aspose-slides-and-net/) và [Aspose.Slides for .NET](/slides/vi/net/format-text-using-vsto-and-aspose-slides-and-net/). Mã sẽ định dạng văn bản trong hộp văn bản thứ ba trên slide sao cho giống với văn bản trong hộp văn bản cuối cùng.

{{% /alert %}} 
## **Định dạng văn bản**
Cả hai phương pháp VSTO và Aspose.Slides thực hiện các bước sau:

1. Mở bài thuyết trình nguồn.
1. Truy cập slide đầu tiên.
1. Truy cập hộp văn bản thứ ba.
1. Thay đổi định dạng của văn bản trong hộp văn bản thứ ba.
1. Lưu bài thuyết trình xuống đĩa.

Các ảnh chụp màn hình bên dưới hiển thị slide mẫu trước và sau khi thực thi mã VSTO và Aspose.Slides cho .NET.

**Bài thuyết trình đầu vào** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **Ví dụ mã VSTO**
Mã dưới đây cho thấy cách định dạng lại văn bản trên slide bằng VSTO.

**Văn bản đã được định dạng lại bằng VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Lưu ý: PowerPoint là một không gian tên đã được định nghĩa ở trên như này
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Mở bài thuyết trình
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
    Microsoft.Office.Core.MsoTriState.msoFalse,
    Microsoft.Office.Core.MsoTriState.msoFalse,
    Microsoft.Office.Core.MsoTriState.msoTrue);

//Truy cập slide đầu tiên
PowerPoint.Slide slide = pres.Slides[1];

//Truy cập hình dạng thứ ba
PowerPoint.Shape shp = slide.Shapes[3];

//Thay đổi phông chữ của văn bản thành Verdana và kích thước lên 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Đặt chữ đậm
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Đặt chữ nghiêng
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Thay đổi màu văn bản
txtRange.Font.Color.RGB = 0x00CC3333;

//Thay đổi màu nền hình dạng
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Di chuyển nó theo chiều ngang
shp.Left -= 70;

//Ghi kết quả ra đĩa
pres.SaveAs("c:\\outVSTO.ppt",
    PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
    Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Ví dụ Aspose.Slides cho .NET**
Để định dạng văn bản bằng Aspose.Slides, hãy thêm phông chữ trước khi định dạng văn bản.

**Bài thuyết trình đầu ra được tạo bằng Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

 //Mở bài thuyết trình
Presentation pres = new Presentation("source.ppt");

//Truy cập slide đầu tiên
ISlide slide = pres.Slides[0];

//Truy cập hình dạng thứ ba
IShape shp = slide.Shapes[2];

//Thay đổi phông chữ của văn bản thành Verdana và kích thước lên 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Đặt chữ đậm
port.PortionFormat.FontBold = NullableBool.True;

//Đặt chữ nghiêng
port.PortionFormat.FontItalic = NullableBool.True;

//Thay đổi màu văn bản
//Đặt màu phông chữ
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Thay đổi màu nền hình dạng
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Ghi kết quả ra đĩa
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```