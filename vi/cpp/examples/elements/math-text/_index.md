---
title: Văn Bản Toán Học
type: docs
weight: 160
url: /vi/cpp/examples/elements/math-text/
keywords:
- ví dụ mã
- văn bản toán học
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Khám phá các ví dụ MathematicalText của Aspose.Slides for C++: tạo và định dạng phương trình, phân số, ma trận và ký hiệu bằng C++ trong các bài thuyết trình PPT, PPTX và ODP."
---
Bài viết này trình bày cách làm việc với các hình dạng văn bản toán học và định dạng các phương trình bằng **Aspose.Slides for C++**.

## **Thêm Văn Bản Toán Học**
Tạo một hình dạng toán học chứa một phân số và công thức Pythagore.

```cpp
static void AddMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Thêm hình dạng Math vào slide.
    auto mathShape = slide->get_Shapes()->AddMathShape(0, 0, 720, 150);

    // Truy cập đoạn văn toán học.
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

    // Thêm một phân số đơn giản: x / y.
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // Thêm phương trình: c² = a² + b².
    auto mathBlock = MakeObject<MathematicalText>(u"c")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
    mathParagraph->Add(mathBlock);

    presentation->Dispose();
}
```

## **Truy cập Văn Bản Toán Học**
Xác định một hình dạng chứa đoạn văn toán trên slide.

```cpp
static void AccessMathText()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    // Tìm hình dạng đầu tiên chứa một đoạn văn toán học.
    auto mathShape = SharedPtr<IAutoShape>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto hasMath = false;
            for (auto&& paragraph : textFrame->get_Paragraphs())
            {
                for (auto&& textPortion : paragraph->get_Portions())
                {
                    if (ObjectExt::Is<MathPortion>(textPortion))
                    {
                        hasMath = true;
                        break;
                    }
                }
                if (hasMath) break;
            }
            if (hasMath)
            {
                mathShape = autoShape;
                break;
            }
        }
    }

    if (mathShape != nullptr)
    {
        auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
        auto textPortion = paragraph->get_Portion(0);
        auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

        // Ví dụ: tạo một phân số (không được thêm ở đây).
        auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");

        // Sử dụng mathParagraph hoặc fraction khi cần...
    }

    presentation->Dispose();
}
```

## **Xóa Văn Bản Toán Học**
Xóa một hình dạng toán học khỏi slide.

```cpp
static void RemoveMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto mathShape = slide->get_Shapes()->AddMathShape(50, 50, 100, 50);

    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // Xóa hình dạng toán học.
    slide->get_Shapes()->Remove(mathShape);

    presentation->Dispose();
}
```

## **Định dạng Văn Bản Toán Học**
Đặt các thuộc tính phông chữ cho một phần toán học.

```cpp
static void FormatMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto mathShape = slide->get_Shapes()->AddMathShape(50, 50, 100, 50);
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    textPortion->get_PortionFormat()->set_FontHeight(20);

    presentation->Dispose();
}
```