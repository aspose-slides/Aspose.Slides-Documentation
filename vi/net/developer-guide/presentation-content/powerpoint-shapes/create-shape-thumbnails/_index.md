---
title: Tạo Hình Thu Nhỏ cho Các Hình Dạng Bài Thuyết Trình trong .NET
linktitle: Hình Thu Nhỏ Hình Dạng
type: docs
weight: 70
url: /vi/net/create-shape-thumbnails/
keywords:
- hình thu nhỏ hình dạng
- hình ảnh hình dạng
- kết xuất hình dạng
- việc kết xuất hình dạng
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tạo hình thu nhỏ hình dạng chất lượng cao từ các slide PowerPoint bằng Aspose.Slides cho .NET – dễ dàng tạo và xuất hình thu nhỏ cho bài thuyết trình."
---
## **Giới thiệu**

Aspose.Slides for .NET được sử dụng để tạo các tệp bài thuyết trình trong đó mỗi trang là một slide. Các slide này có thể xem bằng cách mở tệp bài thuyết trình bằng Microsoft PowerPoint. Tuy nhiên đôi khi các nhà phát triển cần xem hình ảnh của các hình dạng riêng biệt trong một trình xem ảnh. Trong những trường hợp đó, Aspose.Slides for .NET giúp bạn tạo các hình thu nhỏ của các hình dạng trên slide. Cách sử dụng tính năng này được mô tả trong bài viết này.  
Bài viết này giải thích cách tạo hình thu nhỏ cho slide theo các cách khác nhau:

- Tạo hình thu nhỏ cho một hình dạng bên trong slide.
- Tạo hình thu nhỏ cho một hình dạng trên slide với kích thước do người dùng xác định.
- Tạo hình thu nhỏ cho một hình dạng trong giới hạn hiển thị của nó.

## **Tạo hình thu nhỏ cho hình dạng từ một slide**
Để tạo hình thu nhỏ cho hình dạng từ bất kỳ slide nào bằng Aspose.Slides for .NET:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. Lấy hình thu nhỏ của hình dạng trên slide đã tham chiếu với tỉ lệ mặc định.
1. Lưu hình thu nhỏ sang bất kỳ định dạng ảnh nào mong muốn.

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

## **Tạo hình thu nhỏ với hệ số thu phóng do người dùng xác định**
Để tạo hình thu nhỏ cho bất kỳ hình dạng nào trên slide bằng Aspose.Slides for .NET:

1. Tạo một thể hiện của lớp `Presentation`.
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. Lấy hình thu nhỏ của slide đã tham chiếu kèm giới hạn hình dạng.
1. Lưu hình thu nhỏ sang bất kỳ định dạng ảnh nào mong muốn.

Ví dụ dưới đây tạo hình thu nhỏ với hệ số thu phóng do người dùng xác định.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Thu phóng theo trục X và Y.

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
Phương pháp này cho phép các nhà phát triển tạo hình thu nhỏ trong giới hạn hiển thị của hình dạng, tính đến tất cả các hiệu ứng của hình dạng. Hình thu nhỏ được tạo ra bị giới hạn bởi giới hạn của slide. Để tạo hình thu nhỏ cho bất kỳ hình dạng nào trên slide trong giới hạn hiển thị của nó, hãy sử dụng đoạn mã mẫu sau:

1. Tạo một thể hiện của lớp `Presentation`.
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. Lấy hình thu nhỏ của slide đã tham chiếu kèm giới hạn hình dạng dưới dạng Appearance.
1. Lưu hình thu nhỏ sang bất kỳ định dạng ảnh nào mong muốn.

Ví dụ dưới đây tạo hình thu nhỏ với hệ số thu phóng do người dùng xác định.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Thu phóng theo trục X và Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **Câu hỏi thường gặp**

**Các định dạng ảnh nào có thể được sử dụng khi lưu hình thu nhỏ của hình dạng?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/vi/net/aspose.slides/imageformat/), và các định dạng khác. Các hình dạng cũng có thể được [xuất dưới dạng SVG vector](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/writeassvg/) bằng cách lưu nội dung của hình dạng dưới dạng SVG.

**Sự khác biệt giữa giới hạn Shape và Appearance khi tạo hình thu nhỏ là gì?**

`Shape` sử dụng hình học của hình dạng; `Appearance` tính đến [các hiệu ứng trực quan](/slides/vi/net/shape-effect/) (bóng, ánh sáng phát sáng, v.v.).

**Nếu một hình dạng được đánh dấu là ẩn thì sẽ xảy ra gì? Nó vẫn được tạo thành hình thu nhỏ không?**

Một hình dạng ẩn vẫn là một phần của mô hình và có thể được tạo ra; cờ ẩn chỉ ảnh hưởng đến việc hiển thị trong trình chiếu nhưng không ngăn việc tạo ảnh của hình dạng.

**Các hình dạng nhóm, biểu đồ, SmartArt và các đối tượng phức tạp khác có được hỗ trợ không?**

Có. Bất kỳ đối tượng nào được biểu diễn dưới dạng [Shape](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/) (bao gồm [GroupShape](https://reference.aspose.com/slides/vi/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chart/), và [SmartArt](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/smartart/)) đều có thể được lưu dưới dạng hình thu nhỏ hoặc SVG.

**Phông chữ được cài đặt trên hệ thống có ảnh hưởng đến chất lượng hình thu nhỏ của các hình dạng văn bản không?**

Có. Bạn nên [cung cấp các phông chữ cần thiết](/slides/vi/net/custom-font/) (hoặc [cấu hình thay thế phông chữ](/slides/vi/net/font-substitution/)) để tránh các phông chữ dự phòng không mong muốn và việc thay đổi bố cục văn bản.