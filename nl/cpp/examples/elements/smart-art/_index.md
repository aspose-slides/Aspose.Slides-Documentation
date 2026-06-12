---
title: SmartArt
type: docs
weight: 140
url: /nl/cpp/examples/elements/smart-art/
keywords:
- codevoorbeeld
- SmartArt
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Werk met SmartArt in Aspose.Slides for C++: maak, bewerk, converteer en style diagrammen met C++ voor PowerPoint- en OpenDocument-presentaties."
---
Dit artikel laat zien hoe u SmartArt‑afbeeldingen kunt toevoegen, ze kunt benaderen, verwijderen en de lay‑outs kunt wijzigen met **Aspose.Slides for C++**.

## **SmartArt toevoegen**

Voeg een SmartArt‑afbeelding in met een van de ingebouwde lay‑outs.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **SmartArt benaderen**

Haal het eerste SmartArt‑object op een dia op.

```cpp
static void AccessSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    auto firstSmartArt = SharedPtr<ISmartArt>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<ISmartArt>(shape))
        {
            firstSmartArt = ExplicitCast<ISmartArt>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **SmartArt verwijderen**

Verwijder een SmartArt‑vorm van de dia.

```cpp
static void RemoveSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    slide->get_Shapes()->Remove(smartArt);

    presentation->Dispose();
}
```

## **SmartArt‑lay-out wijzigen**

Werk het type lay‑out van een bestaande SmartArt‑afbeelding bij.

```cpp
static void ChangeSmartArtLayout()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicBlockList);
    smartArt->set_Layout(SmartArtLayoutType::VerticalPictureList);

    presentation->Dispose();
}
```