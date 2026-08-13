---
title: API Công khai và Các Thay đổi Không tương thích Ngược trong Aspose.Slides cho .NET 14.9.0
linktitle: Aspose.Slides cho .NET 14.9.0
type: docs
weight: 110
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- phương pháp kế thừa
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xem lại các bản cập nhật API công khai và các thay đổi gây phá vỡ trong Aspose.Slides cho .NET để di chuyển suôn sẻ các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính [đã thêm](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) hoặc [đã loại bỏ](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/), và các thay đổi khác được giới thiệu trong API Aspose.Slides for .NET 14.9.0.

{{% /alert %}} 
## **Thay đổi API Công khai**
#### **Thêm kế thừa từ ICollection và Generic IEnumerable Interfaces vào ISmartArtNodeCollection**
Lớp Aspose.Slides.SmartArt.SmartArtNodeCollection (và giao diện liên quan Aspose.Slides.SmartArt.ISmartArtNodeCollection) kế thừa giao diện generic IEnumerable<ISmartArtNode> và giao diện ICollection.
#### **Thêm giá trị Enum SmartArtLayoutType.Custom**
Kiểu bố cục SmartArt Custom đại diện cho một sơ đồ có mẫu tùy chỉnh. Các sơ đồ tùy chỉnh chỉ có thể được tải từ tệp trình chiếu và không thể tạo bằng phương thức ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **Thêm lớp SmartArtShape và giao diện ISmartArtShape**
Lớp Aspose.Slides.SmartArt.SmartArtShape (và giao diện Aspose.Slides.SmartArt.ISmartArtShape) cung cấp quyền truy cập vào các hình dạng riêng lẻ trong sơ đồ SmartArt. SmartArtShape có thể được sử dụng để thay đổi FillFormat, LineFormat, thêm Hyperlinks và các tác vụ khác.

{{% alert color="info" %}} 

**Lưu ý**: SmartArtShape không hỗ trợ các thuộc tính IShape RawFrame, Frame, Rotation, X, Y, Width, Height và sẽ ném System.NotSupportedException khi cố gắng truy cập chúng.

Ví dụ sử dụng:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **Thêm lớp SmartArtShapeCollection, giao diện ISmartArtShapeCollection và thuộc tính ISmartArtNode.Shapes**
Lớp Aspose.Slides.SmartArt.SmartArtShapeCollection (và giao diện Aspose.Slides.SmartArt.ISmartArtShapeCollection) cung cấp quyền truy cập vào các hình dạng riêng lẻ trong sơ đồ SmartArt. Bộ sưu tập chứa các hình dạng liên kết với SmartArtNode. Thuộc tính SmartArtNode.Shapes trả về các bộ sưu tập của tất cả các hình dạng liên kết với nút.

{{% alert color="info" %}} 

**Lưu ý**: tùy thuộc vào SmartArtLayoutType, một SmartArtShape có thể được chia sẻ giữa nhiều nút.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **Thêm các phương thức lưu Slide với việc giữ số trang**
Các phương thức sau đã được thêm:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Các phương thức này cho phép nhà phát triển lưu các slide trình chiếu đã chỉ định thành các định dạng PDF, XPS, TIFF, HTML. Mảng 'slides' được dùng để chỉ định số trang, bắt đầu từ 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    int[] slides = new int[] { 2, 3, 5 }; //Mảng vị trí các slide

    presentation.Save("output.pdf", slides, SaveFormat.Pdf);
}
``` 
#### **Thêm các phương thức thay thế hình ảnh vào PPImage, IPPImage**
Các phương thức mới được thêm:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    //Phương pháp đầu tiên

    byte[] data = File.ReadAllBytes("image0.jpeg");

    IPPImage oldImage = presentation.Images[0];

    oldImage.ReplaceImage(data);

    //Phương pháp thứ hai

    IImage newImage = Images.FromFile("image1.png");

    oldImage = presentation.Images[1];

    oldImage.ReplaceImage(newImage);

    //Phương pháp thứ ba

    oldImage = presentation.Images[2];

    oldImage.ReplaceImage(presentation.Images[3]);

    presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```