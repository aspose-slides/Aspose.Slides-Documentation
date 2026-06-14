---
title: Hình ảnh
type: docs
weight: 50
url: /vi/net/examples/elements/picture/
keywords:
- hình ảnh
- khung hình ảnh
- thêm hình ảnh
- truy cập hình ảnh
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Làm việc với hình ảnh trong Aspose.Slides for .NET: chèn, cắt, nén, thay đổi màu và xuất ảnh với các ví dụ C# cho các bài thuyết trình PPT, PPTX và ODP."
---
Bài viết này trình bày cách chèn và truy cập hình ảnh từ các hình ảnh trong bộ nhớ bằng **Aspose.Slides for .NET**. Các ví dụ dưới đây tạo một hình ảnh trong bộ nhớ, đặt nó lên một slide và sau đó truy xuất lại.

## **Thêm hình ảnh**

Đoạn mã này tạo một bitmap nhỏ, chuyển nó thành luồng và chèn nó dưới dạng khung hình ảnh vào slide đầu tiên.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Tạo một hình ảnh đơn giản trong bộ nhớ.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // Chuyển đổi bitmap sang MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Thêm hình ảnh vào bản trình chiếu.
    var image = presentation.Images.AddImage(imageStream);

    // Chèn khung hình ảnh hiển thị ảnh trên slide đầu tiên.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Truy cập hình ảnh**

Ví dụ này đảm bảo một slide chứa khung hình ảnh và sau đó truy cập vào khung đầu tiên mà nó tìm thấy.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Đảm bảo có ít nhất một khung hình ảnh để làm việc.
    using var bitmap = new Bitmap(40, 40);

    // Chuyển đổi bitmap sang MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Thêm hình ảnh vào bản trình chiếu.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // Truy cập khung hình ảnh đầu tiên trên slide.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```