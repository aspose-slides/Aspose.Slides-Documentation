---
title: ActiveX
type: docs
weight: 200
url: /cpp/examples/elements/activex/
keywords:
- code example
- ActiveX
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "See Aspose.Slides for C++ ActiveX examples: insert, configure, and control ActiveX objects in PPT and PPTX presentations with clear C++ code."
---

This article demonstrates how to add, access, remove, and configure ActiveX controls in a presentation using **Aspose.Slides for C++**.

## **Add an ActiveX Control**

Insert a new ActiveX control and optionally set its properties.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Access an ActiveX Control**

Read information from the first ActiveX control on the slide.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Access the first ActiveX control.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **Remove an ActiveX Control**

Delete an existing ActiveX control from the slide.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Remove the first ActiveX control.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Set ActiveX Properties**

Add a control and configure several ActiveX properties.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Add a Windows Media Player control and configure properties.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```
