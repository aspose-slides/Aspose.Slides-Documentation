---
title: SmartArt
type: docs
weight: 140
url: /de/cpp/examples/elements/smart-art/
keywords:
- Codebeispiel
- SmartArt
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Arbeiten Sie mit SmartArt in Aspose.Slides für C++: Erstellen, bearbeiten, konvertieren und formatieren Sie Diagramme mit C++ für PowerPoint- und OpenDocument-Präsentationen."
---
Dieser Artikel demonstriert, wie Sie SmartArt‑Grafiken hinzufügen, darauf zugreifen, sie entfernen und Layouts ändern, indem Sie **Aspose.Slides for C++** verwenden.

## **SmartArt hinzufügen**

Fügen Sie eine SmartArt‑Grafik mithilfe eines der integrierten Layouts ein.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **SmartArt abrufen**

Rufen Sie das erste SmartArt‑Objekt auf einer Folie ab.

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

## **SmartArt entfernen**

Löschen Sie eine SmartArt‑Form von der Folie.

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

## **SmartArt‑Layout ändern**

Aktualisieren Sie den Layouttyp einer vorhandenen SmartArt‑Grafik.

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