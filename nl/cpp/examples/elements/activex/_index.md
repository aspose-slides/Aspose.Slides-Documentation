---
title: ActiveX
type: docs
weight: 200
url: /nl/cpp/examples/elements/activex/
keywords:
  - codevoorbeeld
  - ActiveX
  - PowerPoint
  - presentatie
  - C++
  - Aspose.Slides
description: "Bekijk de Aspose.Slides for C++ ActiveX-voorbeelden: voeg ActiveX-objecten in, configureer ze en beheer ze in PPT- en PPTX-presentaties met duidelijke C++-code."
---
Dit artikel laat zien hoe u ActiveX-besturingselementen kunt toevoegen, benaderen, verwijderen en configureren in een presentatie met **Aspose.Slides for C++**.

## **Voeg een ActiveX-besturingselement toe**

Voeg een nieuw ActiveX-besturingselement in en stel desgewenst de eigenschappen in.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Voeg een nieuw ActiveX-besturingselement toe.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // Stel desgewenst enkele eigenschappen in.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **ActiveX-besturingselement benaderen**

Lees informatie uit het eerste ActiveX-besturingselement op de dia.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Benader het eerste ActiveX-besturingselement.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **ActiveX-besturingselement verwijderen**

Verwijder een bestaand ActiveX-besturingselement van de dia.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Verwijder het eerste ActiveX-besturingselement.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **ActiveX-eigenschappen instellen**

Voeg een besturingselement toe en configureer verschillende ActiveX-eigenschappen.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Voeg een Windows Media Player-besturingselement toe en configureer de eigenschappen.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```