---
title: ActiveX
type: docs
weight: 200
url: /cs/cpp/examples/elements/activex/
keywords:
- ukázka kódu
- ActiveX
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Prohlédněte si příklady ActiveX v Aspose.Slides pro C++: vkládání, konfigurace a ovládání objektů ActiveX v prezentacích PPT a PPTX pomocí přehledného C++ kódu."
---
Tento článek ukazuje, jak v prezentaci přidávat, přistupovat, odstraňovat a konfigurovat ovládací prvky ActiveX pomocí **Aspose.Slides for C++**.

## **Add an ActiveX Control**
Vložte nový ovládací prvek ActiveX a volitelně nastavte jeho vlastnosti.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Přidejte nový ovládací prvek ActiveX.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // Volitelně nastavte některé vlastnosti.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Access an ActiveX Control**
Přečtěte informace z prvního ovládacího prvku ActiveX na snímku.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Přístup k prvnímu ovládacímu prvku ActiveX.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **Remove an ActiveX Control**
Odstraňte existující ovládací prvek ActiveX ze snímku.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Odstraňte první ovládací prvek ActiveX.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Set ActiveX Properties**
Přidejte ovládací prvek a nakonfigurujte několik vlastností ActiveX.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Přidejte ovládací prvek Windows Media Player a nastavte vlastnosti.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```