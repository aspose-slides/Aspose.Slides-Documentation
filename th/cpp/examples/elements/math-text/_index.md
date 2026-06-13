---
title: ข้อความคณิตศาสตร์
type: docs
weight: 160
url: /th/cpp/examples/elements/math-text/
keywords:
- ตัวอย่างโค้ด
- ข้อความคณิตศาสตร์
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "สำรวจตัวอย่าง MathematicalText ของ Aspose.Slides for C++: สร้างและจัดรูปสมการ, เศษส่วน, เมทริกซ์และสัญลักษณ์ด้วย C++ ในการนำเสนอรูปแบบ PPT, PPTX และ ODP"
---
บทความนี้แสดงวิธีทำงานกับรูปแบบข้อความคณิตศาสตร์และการจัดรูปสมการโดยใช้ **Aspose.Slides for C++**.

## **เพิ่มข้อความคณิตศาสตร์**

สร้างรูปคณิตศาสตร์ที่มีส่วนของเศษส่วนและสูตรพีธากอรัส

```cpp
static void AddMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // เพิ่มรูปคณิตศาสตร์ไปยังสไลด์.
    auto mathShape = slide->get_Shapes()->AddMathShape(0, 0, 720, 150);

    // เข้าถึงย่อหน้าคณิตศาสตร์.
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

    // เพิ่มเศษส่วนง่าย: x / y.
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // เพิ่มสมการ: c² = a² + b².
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

## **เข้าถึงข้อความคณิตศาสตร์**

ค้นหารูปที่มีย่อหน้าคณิตศาสตร์บนสไลด์

```cpp
static void AccessMathText()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    // ค้นหารูปแรกที่มีย่อหน้าคณิตศาสตร์.
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

        // ตัวอย่าง: สร้างเศษส่วน (ไม่ได้เพิ่มในที่นี้).
        auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");

        // ใช้ mathParagraph หรือ fraction ตามต้องการ...
    }

    presentation->Dispose();
}
```

## **ลบข้อความคณิตศาสตร์**

ลบรูปคณิตศาสตร์ออกจากสไลด์

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

    // ลบรูปคณิตศาสตร์.
    slide->get_Shapes()->Remove(mathShape);

    presentation->Dispose();
}
```

## **จัดรูปแบบข้อความคณิตศาสตร์**

ตั้งค่าคุณสมบัติการฟอนต์สำหรับส่วนคณิตศาสตร์

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