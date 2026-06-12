---
title: SmartArt
type: docs
weight: 140
url: /it/cpp/examples/elements/smart-art/
keywords:
- esempio di codice
- SmartArt
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Lavora con SmartArt in Aspose.Slides for C++: crea, modifica, converte e applica stili a diagrammi in C++ per presentazioni PowerPoint e OpenDocument."
---
Questo articolo mostra come aggiungere grafici SmartArt, accedervi, rimuoverli e modificare i layout utilizzando **Aspose.Slides for C++**.

## **Add SmartArt**

Inserisci un grafico SmartArt utilizzando uno dei layout predefiniti.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **Access SmartArt**

Recupera il primo oggetto SmartArt su una diapositiva.

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

## **Remove SmartArt**

Elimina una forma SmartArt dalla diapositiva.

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

## **Change SmartArt Layout**

Aggiorna il tipo di layout di un grafico SmartArt esistente.

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