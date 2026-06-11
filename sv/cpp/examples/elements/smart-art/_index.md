---
title: SmartArt
type: docs
weight: 140
url: /sv/cpp/examples/elements/smart-art/
keywords:
- kodexempel
- SmartArt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Arbeta med SmartArt i Aspose.Slides för C++: skapa, redigera, konvertera och formge diagram med C++ för PowerPoint- och OpenDocument-presentationer."
---
Den här artikeln visar hur du lägger till SmartArt-grafik, får åtkomst till dem, tar bort dem och ändrar layouter med **Aspose.Slides for C++**.

## **Lägg till SmartArt**

Infoga en SmartArt-grafik med hjälp av någon av de inbyggda layouterna.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **Åtkomst till SmartArt**

Hämta det första SmartArt-objektet på en bild.

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

## **Ta bort SmartArt**

Ta bort en SmartArt-form från bilden.

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

## **Ändra SmartArt-layout**

Uppdatera layouttypen för en befintlig SmartArt-grafik.

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