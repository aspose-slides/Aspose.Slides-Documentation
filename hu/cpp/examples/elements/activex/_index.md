---
title: ActiveX
type: docs
weight: 200
url: /hu/cpp/examples/elements/activex/
keywords:
- kódpélda
- ActiveX
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Tekintse meg az Aspose.Slides for C++ ActiveX példákat: ActiveX objektumok beszúrása, konfigurálása és vezérlése PPT és PPTX prezentációkban világos C++ kóddal."
---
Ez a cikk bemutatja, hogyan lehet hozzáadni, elérni, eltávolítani és konfigurálni az ActiveX vezérlőket egy prezentációban a **Aspose.Slides for C++** használatával.

## **ActiveX vezérlő hozzáadása**

Új ActiveX vezérlő beszúrása és opcionálisan a tulajdonságainak beállítása.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Új ActiveX vezérlő hozzáadása.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // Opcionálisan beállít néhány tulajdonságot.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **ActiveX vezérlő elérése**

Információk olvasása a dián található első ActiveX vezérlőből.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Az első ActiveX vezérlő elérése.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **ActiveX vezérlő eltávolítása**

Meglévő ActiveX vezérlő törlése a diáról.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Az első ActiveX vezérlő eltávolítása.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **ActiveX tulajdonságok beállítása**

Vezérlő hozzáadása és több ActiveX tulajdonság konfigurálása.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Windows Media Player vezérlő hozzáadása és a tulajdonságok konfigurálása.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```