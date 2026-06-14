---
title: SmartArt
type: docs
weight: 140
url: /vi/net/examples/elements/smart-art/
keywords:
- SmartArt
- thêm SmartArt
- truy cập SmartArt
- xóa SmartArt
- bố cục SmartArt
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Làm việc với SmartArt trong Aspose.Slides cho .NET: tạo, chỉnh sửa, chuyển đổi và thiết kế các sơ đồ bằng C# cho bản trình chiếu PowerPoint và OpenDocument."
---
Bài viết này trình bày cách thêm đồ họa SmartArt, truy cập chúng, xóa chúng và thay đổi bố cục bằng cách sử dụng **Aspose.Slides for .NET**.

## **Thêm SmartArt**

Chèn một đồ họa SmartArt bằng cách sử dụng một trong các bố cục có sẵn.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **Truy cập SmartArt**

Lấy đối tượng SmartArt đầu tiên trên một slide.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **Xóa SmartArt**

Xóa một hình dạng SmartArt khỏi slide.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **Thay đổi Bố cục SmartArt**

Cập nhật loại bố cục của một đồ họa SmartArt hiện có.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```