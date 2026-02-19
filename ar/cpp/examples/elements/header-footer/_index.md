---
title: رأس وتذييل
type: docs
weight: 220
url: /ar/cpp/examples/elements/header-footer/
keywords:
- مثال على الشيفرة
- رأس
- تذييل
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تحكم في رؤوس وتذييلات الشرائح باستخدام Aspose.Slides for C++: أضف التواريخ وأرقام الشرائح والنص المخصص في ملفات PPT و PPTX و ODP مع أمثلة C++."
---
توَّضح هذه المقالة كيفية إضافة تذييلات وتحديث العناصر النائبة للتاريخ والوقت باستخدام **Aspose.Slides for C++**.

## **إضافة تذييل**

أضف نصًا إلى منطقة التذييل في الشريحة واجعلها مرئية.

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **تحديث التاريخ والوقت**

قم بتعديل العنصر النائب للتاريخ والوقت في الشريحة.

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```