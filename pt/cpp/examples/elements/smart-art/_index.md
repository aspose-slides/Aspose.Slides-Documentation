---
title: SmartArt
type: docs
weight: 140
url: /pt/cpp/examples/elements/smart-art/
keywords:
- exemplo de código
- SmartArt
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Trabalhe com SmartArt no Aspose.Slides for C++: crie, edite, converta e estilize diagramas com C++ para apresentações PowerPoint e OpenDocument."
---
Este artigo demonstra como adicionar elementos SmartArt, acessá‑los, removê‑los e alterar layouts usando **Aspose.Slides for C++**.

## **Adicionar SmartArt**

Insira um elemento SmartArt usando um dos layouts incorporados.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **Acessar SmartArt**

Recupere o primeiro objeto SmartArt em um slide.

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

## **Remover SmartArt**

Exclua uma forma SmartArt do slide.

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

## **Alterar Layout do SmartArt**

Atualize o tipo de layout de um elemento SmartArt existente.

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