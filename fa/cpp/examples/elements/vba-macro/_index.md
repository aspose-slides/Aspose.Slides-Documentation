---
title: ماکرو VBA
type: docs
weight: 150
url: /fa/cpp/examples/elements/vba-macro/
keywords:
- مثال کد
- VBA
- ماکرو
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "با Aspose.Slides for C++ ارائه‌ها را خودکار کنید: ایجاد، اجرای، وارد کردن و ایمن‌سازی ماکروهای VBA در فرمت‌های PPT، PPTX و ODP با استفاده از مثال‌های واضح C++."
---
این مقاله نشان می‌دهد که چگونه می‌توان ماکروهای VBA را با استفاده از **Aspose.Slides for C++** اضافه، دسترسی پیدا کرد و حذف کرد.

## **اضافه کردن ماکرو VBA**

یک ارائه با پروژه VBA و یک ماژول ماکرو ساده ایجاد کنید.

```cpp
static void AddVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->Dispose();
}
```

## **دسترسی به ماکرو VBA**

ماژول اول را از پروژه VBA بازیابی کنید.

```cpp
static void AccessVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    auto firstModule = presentation->get_VbaProject()->get_Module(0);

    presentation->Dispose();
}
```

## **حذف ماکرو VBA**

یک ماژول را از پروژه VBA حذف کنید.

```cpp
static void RemoveVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->get_VbaProject()->get_Modules()->Remove(module);

    presentation->Dispose();
}
```