---
title: Cách tạo trình chiếu Hello World trong .NET
linktitle: Trình chiếu Hello World
type: docs
weight: 10
url: /vi/net/how-to-create-hello-world-presentation-document/
keywords:
- di chuyển
- hello world
- mã legacy
- mã hiện đại
- phương pháp legacy
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tạo một trình chiếu Hello World dạng PowerPoint PPT, PPTX và ODP trong .NET với Aspose.Slides sử dụng cả API legacy và hiện đại trong một hướng dẫn đơn giản."
---
{{% alert color="info" %}} 
Một phiên bản mới của [Aspose.Slides for .NET API](/slides/vi/net/) đã được phát hành và hiện sản phẩm này hỗ trợ khả năng tạo tài liệu PowerPoint từ đầu và chỉnh sửa các tài liệu hiện có.
{{% /alert %}} 
## **Hỗ trợ mã Legacy**
Để sử dụng mã legacy được phát triển với Aspose.Slides for .NET các phiên bản trước 13.x, bạn cần thực hiện một số thay đổi nhỏ trong mã của mình và mã sẽ hoạt động như trước. Tất cả các lớp trước đây trong Aspose.Slides for .NET dưới các không gian tên Aspose.Slide và Aspose.Slides.Pptx hiện đã được hợp nhất thành một không gian tên Aspose.Slides duy nhất. Vui lòng xem đoạn mã mẫu đơn giản sau để tạo tài liệu Trình chiếu Hello World trong API Aspose.Slides legacy và làm theo các bước mô tả cách di chuyển sang API hợp nhất mới.
## **Cách tiếp cận Aspose.Slides for .NET Legacy**
```c#
using System.Drawing;
using Aspose.Slides;

//Khởi tạo một đối tượng Presentation đại diện cho tệp PPT
Presentation pres = new Presentation();

//Tạo một đối tượng License
License license = new License();

//Đặt giấy phép của Aspose.Slides cho .NET để tránh các hạn chế phiên bản dùng thử
license.SetLicense("Aspose.Slides.lic");

//Thêm một slide trống vào bản trình chiếu và lấy tham chiếu của
//slide trống đó
Slide slide = pres.AddEmptySlide();

//Thêm một hình chữ nhật (X=2400, Y=1800, Width=1000 & Height=500) vào slide
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Ẩn các đường viền của hình chữ nhật
rect.LineFormat.ShowLines = false;

//Thêm một khung văn bản vào hình chữ nhật với "Hello World" làm văn bản mặc định
rect.AddTextFrame("Hello World");

//Xóa slide đầu tiên của bản trình chiếu, mà luôn được thêm bởi
//Aspose.Slides cho .NET mặc định khi tạo bản trình chiếu
pres.Slides.RemoveAt(0);

//Ghi bản trình chiếu thành tệp PPT
pres.Write("C:\\hello.ppt");
```

## **Cách tiếp cận Aspose.Slides for .NET 13.x Mới**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo Presentation
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```