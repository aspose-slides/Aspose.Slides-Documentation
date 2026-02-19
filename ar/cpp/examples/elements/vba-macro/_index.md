---
title: ماكرو VBA
type: docs
weight: 150
url: /ar/cpp/examples/elements/vba-macro/
keywords:
- مثال على الكود
- VBA
- ماكرو
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "قم بأتمتة العروض التقديمية باستخدام Aspose.Slides for C++: أنشئ، شغّل، استورد، واحمِ ماكروات VBA في صيغ PPT و PPTX و ODP باستخدام أمثلة C++ واضحة."
---
توفر هذه المقالة توضيحًا لكيفية إضافة، الوصول إلى، وإزالة وحدات ماكرو VBA باستخدام **Aspose.Slides for C++**.

## **إضافة ماكرو VBA**

إنشاء عرض تقديمي يحتوي على مشروع VBA ووحدة ماكرو بسيطة.

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

## **الوصول إلى ماكرو VBA**

استرجاع الوحدة الأولى من مشروع VBA.

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

## **إزالة ماكرو VBA**

حذف وحدة من مشروع VBA.

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