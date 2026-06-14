---
title: Hộp Văn Bản
type: docs
weight: 40
url: /vi/cpp/examples/elements/text-box/
keywords:
- ví dụ mã
- hộp văn bản
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Làm việc với hộp văn bản trong Aspose.Slides cho C++: thêm, định dạng, căn chỉnh, bọc, tự điều chỉnh và tạo kiểu cho văn bản bằng C++ cho các bài thuyết trình PPT, PPTX và ODP."
---
Trong Aspose.Slides, một **hộp văn bản** được biểu diễn bằng một `AutoShape`. Hầu hết các hình dạng đều có thể chứa văn bản, nhưng một hộp văn bản điển hình không có nền hay viền và chỉ hiển thị văn bản.

Hướng dẫn này giải thích cách thêm, truy cập và xóa các hộp văn bản một cách lập trình.

## **Thêm Hộp Văn Bản**

Một hộp văn bản chỉ đơn giản là một `AutoShape` không có nền hay viền và có một số văn bản được định dạng. Dưới đây là cách tạo một hộp văn bản:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Tạo một hình chữ nhật (mặc định được tô đầy với viền và không có văn bản).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // Xóa màu nền và viền để làm cho nó trông giống như một hộp văn bản điển hình.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Đặt định dạng văn bản.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // Gán nội dung văn bản thực tế.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Lưu ý:** Bất kỳ `AutoShape` nào chứa một `TextFrame` không rỗng cũng có thể hoạt động như một hộp văn bản.

## **Truy cập Hộp Văn Bản theo Nội Dung**

Để tìm tất cả các hộp văn bản chứa một từ khóa cụ thể (ví dụ: "Slide"), hãy lặp qua các hình dạng và kiểm tra văn bản của chúng:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // Chỉ có AutoShape mới có thể chứa văn bản có thể chỉnh sửa.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // Thực hiện một hành động nào đó với hộp văn bản khớp.
            }
        }
    }

    presentation->Dispose();
}
```

## **Xóa Hộp Văn Bản theo Nội Dung**

Ví dụ này tìm và xóa tất cả các hộp văn bản trên slide đầu tiên mà chứa một từ khóa cụ thể:

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **Mẹo:** Luôn tạo một bản sao của bộ sưu tập hình dạng trước khi sửa đổi nó trong quá trình lặp để tránh lỗi sửa đổi bộ sưu tập.