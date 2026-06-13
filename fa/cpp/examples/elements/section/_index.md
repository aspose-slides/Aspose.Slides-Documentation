---
title: بخش
type: docs
weight: 90
url: /fa/cpp/examples/elements/section/
keywords:
- مثال کد
- بخش
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "مدیریت بخش‌های اسلاید در Aspose.Slides برای C++: ایجاد، تغییر نام، مرتب‌سازی و گروه‌بندی اسلایدها با مثال‌های C++ برای PPT، PPTX و ODP."
---
نمونه‌هایی برای مدیریت بخش‌های ارائه—افزودن، دسترسی، حذف و تغییر نام آن‌ها به صورت برنامه‌نویسی با استفاده از **Aspose.Slides for C++**.

## **افزودن بخش**

یک بخش ایجاد کنید که از اسلاید خاصی آغاز می‌شود.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // اسلایدی را که نشانگر ابتدای بخش است مشخص کنید.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **دسترسی به بخش**

اطلاعات بخش را از یک ارائه بخوانید.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // دسترسی به یک بخش بر اساس شاخص.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **حذف بخش**

بخشی که قبلاً اضافه شده است را حذف کنید.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // حذف اولین بخش.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **تغییر نام بخش**

نام یک بخش موجود را تغییر دهید.

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