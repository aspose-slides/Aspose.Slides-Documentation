---
title: ActiveX
type: docs
weight: 200
url: /ar/cpp/examples/elements/activex/
keywords:
- مثال على الكود
- ActiveX
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "اطلع على أمثلة ActiveX في Aspose.Slides لـ C++: الإدراج، التكوين، والتحكم في كائنات ActiveX في عروض PPT و PPTX مع شفرة C++ واضحة."
---
توضح هذه المقالة كيفية إضافة والوصول إلى وإزالة وتكوين عناصر التحكم ActiveX في عرض تقديمي باستخدام **Aspose.Slides for C++**.

## **إضافة عنصر تحكم ActiveX**

أدرج عنصر تحكم ActiveX جديدًا ويمكنك اختيارياً تعيين خصائصه.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // أضف عنصر تحكم ActiveX جديد.
    // يمكنك اختيارياً تعيين بعض الخصائص.

    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **الوصول إلى عنصر تحكم ActiveX**

اقرأ المعلومات من أول عنصر تحكم ActiveX على الشريحة.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // الوصول إلى أول عنصر تحكم ActiveX.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **إزالة عنصر تحكم ActiveX**

احذف عنصر تحكم ActiveX موجود من الشريحة.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // إزالة أول عنصر تحكم ActiveX.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **تعيين خصائص ActiveX**

أضف عنصر تحكم وقم بتكوين عدة خصائص لـ ActiveX.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // إضافة عنصر تحكم Windows Media Player وتكوين الخصائص.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```