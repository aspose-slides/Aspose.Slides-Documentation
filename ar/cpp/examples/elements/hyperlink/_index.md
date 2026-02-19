---
title: الارتباط التشعبي
type: docs
weight: 130
url: /ar/cpp/examples/elements/hyperlink/
keywords:
- مثال على الكود
- ارتباط تشعبي
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إضافة وإدارة الارتباطات التشعبية في Aspose.Slides for C++: ربط النصوص، الأشكال، والصور، وتعيين الأهداف والإجراءات لملفات PPT و PPTX و ODP باستخدام أمثلة C++."
---
توضح هذه المقالة كيفية إضافة الروابط التشعبية والوصول إليها وإزالتها وتحديثها على الأشكال باستخدام **Aspose.Slides for C++**.

## **إضافة ارتباط تشعبي**

قم بإنشاء شكل مستطيل يحتوي على ارتباط تشعبي يشير إلى موقع ويب خارجي.

```cpp
static void AddHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    presentation->Dispose();
}
```

## **الوصول إلى ارتباط تشعبي**

اقرأ معلومات الارتباط التشعبي من جزء النص في الشكل.

```cpp
static void AccessHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    auto hyperlink = textPortion->get_PortionFormat()->get_HyperlinkClick();

    presentation->Dispose();
}
```

## **إزالة ارتباط تشعبي**

قم بمسح الارتباط التشعبي من نص الشكل.

```cpp
static void RemoveHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    textPortion->get_PortionFormat()->set_HyperlinkClick(nullptr);

    presentation->Dispose();
}
```

## **تحديث ارتباط تشعبي**

غيّر هدف الارتباط التشعبي الموجود. استخدم `HyperlinkManager` لتعديل النص الذي يحتوي بالفعل على ارتباط تشعبي، مما يحاكي طريقة تحديث PowerPoint للارتباطات التشعبية بأمان.

```cpp
static void UpdateHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://old.example.com"));

    // يجب تغيير الارتباط التشعبي داخل النص الموجود عبر
    // HyperlinkManager بدلاً من ضبط الخاصية مباشرةً.
    // هذا يحاكي طريقة تحديث PowerPoint للارتباطات التشعبية بأمان.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```