---
title: Tạo hình thu nhỏ cho các hình dạng của bài thuyết trình trong .NET
linktitle: Hình thu nhỏ của hình dạng
type: docs
weight: 70
url: /vi/net/create-shape-thumbnails/
keywords:
- hình thu nhỏ của hình dạng
- hình ảnh hình dạng
- kết xuất hình dạng
- kết xuất hình dạng
- giới hạn trực quan
- giới hạn hình dạng
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tạo các hình thu nhỏ chất lượng cao cho các hình dạng từ slide PowerPoint bằng Aspose.Slides cho .NET – dễ dàng tạo và xuất các hình thu nhỏ của bài thuyết trình."
---
## **Giới thiệu**

Aspose.Slides cho .NET được sử dụng để tạo tệp trình chiếu trong đó mỗi trang là một slide. Các slide này có thể được xem bằng cách mở tệp trình chiếu bằng Microsoft PowerPoint. Tuy nhiên, đôi khi các nhà phát triển có thể cần xem hình ảnh của các hình dạng riêng biệt trong một trình xem ảnh. Trong những trường hợp đó, Aspose.Slides cho .NET giúp bạn tạo ra các hình ảnh thu nhỏ của các hình dạng trên slide. Cách sử dụng tính năng này được mô tả trong bài viết này.

Bài viết này giải thích cách tạo hình thu nhỏ của slide theo các cách khác nhau:

- Tạo hình thu nhỏ cho một hình dạng bên trong slide.
- Tạo hình thu nhỏ cho một hình dạng trên slide với kích thước do người dùng xác định.
- Tạo hình thu nhỏ cho hình dạng trong giới hạn hiển thị của hình dạng.

## **Tạo hình thu nhỏ của hình dạng từ một slide**
Để tạo hình thu nhỏ của hình dạng từ bất kỳ slide nào bằng Aspose.Slides cho .NET:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. Lấy hình ảnh thu nhỏ của hình dạng trên slide đã tham chiếu với tỷ lệ mặc định.
1. Lưu hình ảnh thu nhỏ dưới bất kỳ định dạng ảnh mong muốn nào.

Ví dụ dưới đây tạo hình thu nhỏ cho hình dạng.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Tạo hình thu nhỏ với hệ số phóng đại do người dùng định nghĩa**
Để tạo hình thu nhỏ của một hình dạng trên slide bằng Aspose.Slides cho .NET:

1. Tạo một thể hiện của lớp `Presentation`.
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. Lấy hình ảnh thu nhỏ của slide đã tham chiếu với giới hạn hình dạng.
1. Lưu hình ảnh thu nhỏ dưới bất kỳ định dạng ảnh mong muốn nào.

Ví dụ dưới đây tạo một hình thu nhỏ với hệ số phóng đại do người dùng định nghĩa.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Tỷ lệ theo các trục X và Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Tạo hình thu nhỏ dựa trên giới hạn hiển thị của hình dạng**
Phương pháp này cho phép các nhà phát triển tạo hình thu nhỏ trong giới hạn hiển thị của hình dạng, tính đến tất cả các hiệu ứng của hình dạng. Hình thu nhỏ được tạo ra bị giới hạn bởi giới hạn của slide. Để tạo hình thu nhỏ cho bất kỳ hình dạng trên slide nào trong giới hạn hiển thị của nó, hãy sử dụng đoạn mã mẫu sau:

1. Tạo một thể hiện của lớp `Presentation`.
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. Lấy hình ảnh thu nhỏ của slide đã tham chiếu với giới hạn hình dạng như là hiển thị.
1. Lưu hình ảnh thu nhỏ dưới bất kỳ định dạng ảnh mong muốn nào.

Ví dụ dưới đây tạo một hình thu nhỏ dựa trên giới hạn hiển thị của hình dạng.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Tỷ lệ theo các trục X và Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **Lấy giới hạn trực quan thực tế của một hình dạng**

Các thuộc tính khung của [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/)—các thuộc tính `X`, `Y`, `Width` và `Height`—mô tả hình chữ nhật được lưu trong mô hình trình chiếu. Nội dung thực tế được render có thể vượt ra ngoài khung đó hoặc chiếm một hình chữ nhật còn khác được căn chỉnh theo trục. Việc xoay, viền, mũi tên, bố cục và tràn văn bản, hình học SmartArt được tạo ra và các hiệu ứng render khác đều có thể làm thay đổi khu vực chiếm dụng.

Sử dụng [GetVisualBounds](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/getvisualbounds/) để tính toán khu vực chiếm dụng mà không cần tạo ảnh. Phương thức trả về một [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) theo tọa độ slide. Hình chữ nhật trả về không bị cắt theo slide, vì vậy tọa độ của nó có thể là âm khi nội dung vượt ra ngoài gốc slide.

[GetVisualBounds](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/getvisualbounds/) hiện chưa được khai báo trong giao diện [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/). Do đó, hãy giữ hình dạng lấy từ bộ sưu tập hình dạng của slide dưới dạng giá trị giao diện và chỉ ép kiểu khi gọi phương thức.

Ví dụ sau lấy và so sánh khung và giới hạn trực quan:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

Cùng một [RectangleF] có thể được dùng để căn chỉnh các hình dạng lân cận theo cạnh `Left`, `Right`, `Top` hoặc `Bottom` của nó; dự trữ đủ không gian trong bố cục được tạo; hoặc phát hiện nội dung nằm ngoài vùng cho phép. Giới hạn trực quan đặc biệt hữu ích cho SmartArt, hộp văn bản, mũi tên, hình ảnh, hình dạng đã xoay và các hình dạng nhóm, nơi khung lưu trữ có thể không phản ánh đầy đủ kết quả render.

Sử dụng [GetVisualBounds] khi bạn cần tọa độ cho bố cục hoặc xác thực và không cần bitmap. Sử dụng [IShape.GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/getimage/) khi bạn cần render hình dạng. Với [ShapeThumbnailBounds](https://reference.aspose.com/slides/vi/net/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` xác định kích thước ảnh từ giới hạn hình dạng, bao gồm các cài đặt viền, trong khi `ShapeThumbnailBounds.Appearance` xác định kích thước từ hiển thị của hình dạng và hạn chế kết quả trong giới hạn slide. Ngược lại, [GetVisualBounds] chỉ trả về hình chữ nhật đã tính toán và không cắt nó theo slide.

## **FAQ**

**Các định dạng hình ảnh nào có thể được sử dụng khi lưu hình thu nhỏ của hình dạng?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/vi/net/aspose.slides/imageformat/), và các định dạng khác. Các hình dạng cũng có thể được [exported as vector SVG](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/writeassvg/) bằng cách lưu nội dung của hình dạng dưới dạng SVG.

**Sự khác nhau giữa giới hạn Shape và Appearance khi tạo hình thu nhỏ là gì?**

`Shape` sử dụng hình học của hình dạng; `Appearance` tính đến [visual effects](/slides/vi/net/shape-effect/) (bóng, hào quang, v.v.) khi xác định kích thước.

**Điều gì sẽ xảy ra nếu một hình dạng được đánh dấu là ẩn? Nó vẫn sẽ được tạo hình thu nhỏ không?**

Một hình dạng ẩn vẫn là một phần của mô hình và có thể được render; cờ ẩn ảnh hưởng đến việc hiển thị trong slideshow nhưng không ngăn việc tạo hình ảnh của hình dạng.

**Các hình dạng nhóm, biểu đồ, SmartArt và các đối tượng phức tạp khác có được hỗ trợ không?**

Có. Bất kỳ đối tượng nào được biểu diễn dưới dạng [Shape](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/) (bao gồm [GroupShape](https://reference.aspose.com/slides/vi/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chart/), và [SmartArt](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/smartart/)) đều có thể được lưu dưới dạng hình thu nhỏ hoặc SVG.

**Các phông chữ được cài đặt trên hệ thống có ảnh hưởng đến chất lượng hình thu nhỏ cho các hình dạng văn bản không?**

Có. Bạn nên [provide the required fonts](/slides/vi/net/custom-font/) (hoặc [configure font substitutions](/slides/vi/net/font-substitution/)) để tránh việc thay thế phông chữ không mong muốn và sắp xếp lại văn bản.