---
title: ActiveX
type: docs
weight: 200
url: /fa/cpp/examples/elements/activex/
keywords:
- مثال کد
- ActiveX
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "نمونه‌های ActiveX در Aspose.Slides برای C++ را ببینید: افزودن، پیکربندی و کنترل اشیای ActiveX در ارائه‌های PPT و PPTX با کد واضح C++."
---
این مقاله نحوه افزودن، دسترسی، حذف و پیکربندی کنترل‌های ActiveX در یک ارائه را با استفاده از **Aspose.Slides for C++** نشان می‌دهد.

## **افزودن یک کنترل ActiveX**

یک کنترل ActiveX جدید را اضافه کنید و به‌طور اختیاری خصوصیات آن را تنظیم کنید.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // افزودن یک کنترل ActiveX جدید.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // به‌صورت اختیاری برخی ویژگی‌ها را تنظیم کنید.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **دسترسی به یک کنترل ActiveX**

اطلاعات اولین کنترل ActiveX در اسلاید را بخوانید.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // دسترسی به اولین کنترل ActiveX.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **حذف یک کنترل ActiveX**

یک کنترل ActiveX موجود را از اسلاید حذف کنید.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // حذف اولین کنترل ActiveX.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **تنظیم خصوصیات ActiveX**

یک کنترل اضافه کنید و چندین خصوصیت ActiveX را پیکربندی کنید.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // یک کنترل Windows Media Player اضافه کنید و ویژگی‌ها را پیکربندی کنید.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```