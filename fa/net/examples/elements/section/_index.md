---
title: بخش
type: docs
weight: 90
url: /fa/net/examples/elements/section/
keywords:
- بخش
- بخش اسلاید
- افزودن بخش
- دسترسی به بخش
- حذف بخش
- تغییر نام بخش
- نمونه کد
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مدیریت بخش‌های اسلاید در Aspose.Slides برای .NET: ایجاد، تغییر نام، ترتیب‌گذاری مجدد و گروه‌بندی اسلایدها با نمونه‌های C# برای PPT، PPTX و ODP."
---
مثال‌هایی برای مدیریت بخش‌های ارائه—اضافه کردن، دسترسی، حذف و تغییر نام آن‌ها به صورت برنامه‌نویسی با استفاده از **Aspose.Slides for .NET**.

## **افزودن یک بخش**

یک بخش ایجاد کنید که از اسلاید مشخصی شروع می‌شود.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // اسلایدی را که شروع بخش را نشان می‌دهد، مشخص کنید.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **دسترسی به یک بخش**

اطلاعات بخش را از یک ارائه بخوانید.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // دسترسی به یک بخش بر حسب اندیس.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **حذف یک بخش**

بخشی که قبلاً اضافه شده را حذف کنید.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // حذف اولین بخش.
    presentation.Sections.RemoveSection(section);
}
```

## **تغییر نام یک بخش**

نام یک بخش موجود را تغییر دهید.

```csharp
static void RenameSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("Old Name", slide);

    var section = presentation.Slides[0];
    section.Name = "New Name";
}
```