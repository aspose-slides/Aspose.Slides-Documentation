---
title: پیوند ابرمتنی
type: docs
weight: 130
url: /fa/cpp/examples/elements/hyperlink/
keywords:
- مثال کد
- پیوند ابرمتنی
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "افزودن و مدیریت پیوندهای ابرمتنی در Aspose.Slides برای C++: متن پیوند، اشکال و تصاویر، تنظیم هدف‌ها و اقدامات برای PPT، PPTX و ODP با مثال‌های C++."
---
این مقاله نشان می‌دهد که چگونه می‌توانید پیوندهای ابرمتنی را بر روی اشکال اضافه، دسترسی، حذف و به‌روزرسانی کنید با استفاده از **Aspose.Slides for C++**.

## **افزودن یک پیوند**

یک شکل مستطیل ایجاد کنید که شامل پیوندی است که به یک وب‌سایت خارجی اشاره می‌کند.

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

## **دسترسی به یک پیوند**

اطلاعات پیوند ابرمتنی را از بخش متن یک شکل بخوانید.

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

## **حذف یک پیوند**

پیوند ابرمتنی را از متن شکل پاک کنید.

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

## **به‌روزرسانی یک پیوند**

هدف یک پیوند ابرمتنی موجود را تغییر دهید. از `HyperlinkManager` برای اصلاح متنی که پیشاپیش حاوی پیوند ابرمتنی است استفاده کنید، به‌طوری که مشابه نحوه به‌روزرسانی ایمن پیوندهای ابرمتنی در PowerPoint باشد.

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

    // تغییر یک پیوند ابرمتنی داخل متن موجود باید از طریق
    // HyperlinkManager انجام شود نه تنظیم مستقیم ویژگی.
    // این شبیه‌سازی می‌کند که PowerPoint چگونه پیوندهای ابرمتنی را به‌صورت ایمن به‌روزرسانی می‌کند.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```