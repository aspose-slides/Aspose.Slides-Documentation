---
title: قسم
type: docs
weight: 90
url: /ar/net/examples/elements/section/
keywords:
- قسم
- قسم الشريحة
- إضافة قسم
- الوصول إلى قسم
- إزالة قسم
- إعادة تسمية قسم
- مثال على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة أقسام الشرائح في Aspose.Slides for .NET: إنشاء، إعادة تسمية، إعادة ترتيب، وتجميع الشرائح مع أمثلة C# لـ PPT و PPTX و ODP."
---
أمثلة لإدارة أقسام العرض التقديمي — الإضافة، الوصول، الإزالة، وإعادة تسمية هذه الأقسام برمجياً باستخدام **Aspose.Slides for .NET**.

## **إضافة قسم**

إنشاء قسم يبدأ من شريحة محددة.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // حدد الشريحة التي تشير إلى بداية القسم.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **الوصول إلى قسم**

قراءة معلومات القسم من عرض تقديمي.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // الوصول إلى قسم حسب الفهرس.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **إزالة قسم**

حذف قسم تمت إضافته مسبقاً.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // إزالة القسم الأول.
    presentation.Sections.RemoveSection(section);
}
```

## **إعادة تسمية قسم**

تغيير اسم قسم موجود.

```csharp
static void RenameSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("Old Name", slide);

    var section = presentation.Sections[0];
    section.Name = "New Name";
}
```