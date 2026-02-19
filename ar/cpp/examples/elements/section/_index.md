---
title: القسم
type: docs
weight: 90
url: /ar/cpp/examples/elements/section/
keywords:
- مثال على الكود
- قسم
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة أقسام الشرائح في Aspose.Slides for C++: إنشاء، إعادة تسمية، إعادة ترتيب، وتجمّع الشرائح مع أمثلة C++ لملفات PPT و PPTX و ODP."
---
أمثلة لإدارة أقسام العرض—الإضافة، الوصول، الحذف، وإعادة تسميتها برمجيًا باستخدام **Aspose.Slides for C++**.

## **إضافة قسم**

إنشاء قسم يبدأ من شريحة محددة.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // حدد الشريحة التي تمثل بداية القسم.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **الوصول إلى قسم**

قراءة معلومات القسم من العرض.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // الوصول إلى قسم حسب الفهرس.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **حذف قسم**

حذف قسم تمت إضافته مسبقًا.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // إزالة القسم الأول.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **إعادة تسمية قسم**

تغيير اسم قسم موجود.

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```