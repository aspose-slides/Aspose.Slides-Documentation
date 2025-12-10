---
title: القسم
type: docs
weight: 90
url: /ar/net/examples/elements/section/
keywords:
- مثال على القسم
- قسم الشريحة
- إضافة قسم
- الوصول إلى قسم
- إزالة قسم
- إعادة تسمية قسم
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة أقسام الشرائح في C# باستخدام Aspose.Slides: إنشاء، إعادة تسمية، إعادة ترتيب بسهولة، نقل الشرائح بين الأقسام، والتحكم في الرؤية لملفات PPT و PPTX و ODP."
---

أمثلة لإدارة أقسام العرض التقديمي — إضافة، وصول، إزالة، وإعادة تسمية برمجياً باستخدام **Aspose.Slides for .NET**.

## **إضافة قسم**

إنشاء قسم يبدأ من شريحة معينة.
```csharp
static void Add_Section()
{
    using var pres = new Presentation();

    // حدد الشريحة التي تمثل بداية القسم
    pres.Sections.AddSection("New Section", pres.Slides[0]);
}
```


## **الوصول إلى قسم**

قراءة معلومات القسم من عرض تقديمي.
```csharp
static void Access_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("My Section", pres.Slides[0]);

    // الوصول إلى القسم بواسطة الفهرس
    var section = pres.Sections[0];
    var sectionName = section.Name;
}
```


## **إزالة قسم**

حذف قسم تم إضافته مسبقًا.
```csharp
static void Remove_Section()
{
    using var pres = new Presentation();
    var section = pres.Sections.AddSection("Temporary Section", pres.Slides[0]);

    // إزالة القسم الأول
    pres.Sections.RemoveSection(section);
}
```


## **إعادة تسمية قسم**

تغيير اسم قسم موجود.
```csharp
static void Rename_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("Old Name", pres.Slides[0]);

    var section = pres.Sections[0];
    section.Name = "New Name";
}
```
