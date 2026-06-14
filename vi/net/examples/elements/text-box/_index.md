---
title: Hộp văn bản
type: docs
weight: 40
url: /vi/net/examples/elements/text-box/
keywords:
- hộp văn bản
- thêm hộp văn bản
- truy cập hộp văn bản
- xóa hộp văn bản
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Làm việc với hộp văn bản trong Aspose.Slides cho .NET: thêm, định dạng, căn chỉnh, gói, tự động vừa, và tạo kiểu văn bản bằng C# cho các bản trình chiếu PPT, PPTX và ODP."
---
Trong Aspose.Slides, một **hộp văn bản** được đại diện bằng một `AutoShape`. Hầu hết mọi hình dạng đều có thể chứa văn bản, nhưng một hộp văn bản điển hình không có nền hay viền và chỉ hiển thị văn bản.

Hướng dẫn này giải thích cách thêm, truy cập và xóa các hộp văn bản một cách lập trình.

## **Thêm Hộp Văn Bản**

Một hộp văn bản chỉ là một `AutoShape` không có nền hoặc viền và chứa một số văn bản đã định dạng. Đây là cách tạo một hộp văn bản:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Tạo một hình chữ nhật (mặc định là có nền, viền và không có văn bản).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Xóa nền và viền để nó trông giống như một hộp văn bản điển hình.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Đặt định dạng văn bản.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Gán nội dung văn bản thực tế.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Lưu ý:** Bất kỳ `AutoShape` nào chứa một `TextFrame` không rỗng cũng có thể hoạt động như một hộp văn bản.

## **Truy cập Hộp Văn Bản theo Nội Dung**

Để tìm tất cả các hộp văn bản chứa một từ khóa cụ thể (ví dụ: "Slide"), lặp qua các hình dạng và kiểm tra văn bản của chúng:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // Chỉ AutoShape mới có thể chứa văn bản có thể chỉnh sửa.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Thực hiện một hành động nào đó với hộp văn bản khớp.
            }
        }
    }
}
```

## **Xóa Hộp Văn Bản theo Nội Dung**

Ví dụ này tìm và xóa tất cả các hộp văn bản trên slide đầu tiên có chứa một từ khóa cụ thể:

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **Mẹo:** Luôn tạo một bản sao của bộ sưu tập hình dạng trước khi sửa đổi nó trong quá trình lặp để tránh lỗi sửa đổi bộ sưu tập.