---
title: SmartArt
type: docs
weight: 140
url: /pl/cpp/examples/elements/smart-art/
keywords:
- przykład kodu
- SmartArt
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Pracuj ze SmartArt w Aspose.Slides for C++: twórz, edytuj, konwertuj i stylizuj diagramy w C++ dla prezentacji PowerPoint i OpenDocument."
---
Ten artykuł demonstruje, jak dodawać grafiki SmartArt, uzyskiwać do nich dostęp, usuwać je oraz zmieniać układy przy użyciu **Aspose.Slides for C++**.

## **Dodaj SmartArt**

Wstaw grafikę SmartArt, używając jednego z wbudowanych układów.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **Dostęp do SmartArt**

Pobierz pierwszy obiekt SmartArt na slajdzie.

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

## **Usuń SmartArt**

Usuń kształt SmartArt ze slajdu.

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

## **Zmień układ SmartArt**

Zaktualizuj typ układu istniejącej grafiki SmartArt.

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