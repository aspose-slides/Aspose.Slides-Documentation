---
title: Đối tượng OLE
type: docs
weight: 210
url: /vi/net/examples/elements/ole-object/
keywords:
- đối tượng OLE
- thêm đối tượng OLE
- truy cập đối tượng OLE
- xóa đối tượng OLE
- cập nhật đối tượng OLE
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xử lý các đối tượng OLE trong Aspose.Slides cho .NET: chèn, liên kết, cập nhật và trích xuất nội dung nhúng với C# trong các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này trình bày cách nhúng tệp dưới dạng đối tượng OLE và cập nhật dữ liệu của nó bằng **Aspose.Slides for .NET**.

## **Thêm Đối Tượng OLE**

Nhúng tệp PDF vào bản trình chiếu.

```csharp
static void AddOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
}
```

## **Truy cập Đối Tượng OLE**

Lấy khung đối tượng OLE đầu tiên trên một slide.

```csharp
static void AccessOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var firstOleFrame = slide.Shapes.OfType<IOleObjectFrame>().First();
}
```

## **Xóa Đối Tượng OLE**

Xóa một đối tượng OLE đã nhúng khỏi slide.

```csharp
static void RemoveOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    slide.Shapes.Remove(oleFrame);
}
```

## **Cập Nhật Dữ Liệu Đối Tượng OLE**

Thay thế dữ liệu đã nhúng trong một đối tượng OLE hiện có.

```csharp
static void UpdateOleObjectData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var newData = File.ReadAllBytes("Picture.png");
    var newDataInfo = new OleEmbeddedDataInfo(newData, "png");
    oleFrame.SetEmbeddedData(newDataInfo);
}
```