---
title: SmartArt
type: docs
weight: 140
url: /cs/cpp/examples/elements/smart-art/
keywords:
- příklad kódu
- SmartArt
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Pracujte se SmartArt v Aspose.Slides pro C++: vytvářejte, upravujte, převádějte a formátujte diagramy pomocí C++ pro prezentace PowerPoint a OpenDocument."
---
Tento článek ukazuje, jak přidat grafiku SmartArt, přistupovat k ní, odebrat ji a měnit rozvržení pomocí **Aspose.Slides for C++**.

## **Přidat SmartArt**

Vložte grafiku SmartArt pomocí jednoho ze vstavených rozložení.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **Přístup k SmartArt**

Získejte první objekt SmartArt na snímku.

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

## **Odstranit SmartArt**

Odstraňte tvar SmartArt ze snímku.

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

## **Změnit rozvržení SmartArt**

Aktualizujte typ rozvržení existující grafiky SmartArt.

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