---
title: SmartArt
type: docs
weight: 140
url: /hu/cpp/examples/elements/smart-art/
keywords:
- kódpélda
- SmartArt
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Dolgozzon a SmartArt-tal az Aspose.Slides for C++-ben: hozzon létre, szerkesszen, konvertáljon és formázzon diagramokat C++-vel PowerPoint és OpenDocument prezentációkhoz."
---
Ez a cikk bemutatja, hogyan lehet hozzáadni SmartArt grafikákat, elérni azokat, eltávolítani őket, és módosítani az elrendezéseket az **Aspose.Slides for C++** használatával.

## **SmartArt hozzáadása**

Helyezzen be egy SmartArt grafikát az egyik beépített elrendezés használatával.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **SmartArt elérése**

Szerezze meg az első SmartArt objektumot egy dián.

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

## **SmartArt eltávolítása**

Törölje a SmartArt alakzatot a diáról.

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

## **SmartArt elrendezés módosítása**

Frissítse egy meglévő SmartArt grafika elrendezéstípusát.

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