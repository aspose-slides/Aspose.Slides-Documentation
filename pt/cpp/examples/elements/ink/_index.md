---
title: Tinta
type: docs
weight: 180
url: /pt/cpp/examples/elements/ink/
keywords:
- exemplo de código
- tinta
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Trabalhe com Tinta no Aspose.Slides for C++: desenhe, importe e edite traços, ajuste cor e largura, e exporte para PPT, PPTX e ODP usando exemplos em C++."
---
Este artigo fornece exemplos de como acessar formas de tinta existentes e removê‑las usando **Aspose.Slides for C++**.

> ❗ **Note:** Formas de tinta representam a entrada do usuário a partir de dispositivos especializados. O Aspose.Slides não pode criar novos traços de tinta programaticamente, mas você pode ler e modificar a tinta existente.

## **Acessar Tinta**

Leia as tags da primeira forma de tinta em um slide.

```cpp
static void AccessInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shape(0);
    if (ObjectExt::Is<IInk>(shape))
    {
        auto inkShape = ExplicitCast<IInk>(shape);
        auto tags = inkShape->get_CustomData()->get_Tags();
        if (tags->get_Count() > 0)
        {
            auto tagName = tags->GetNameByIndex(0);
            // Use tagName conforme necessário.
        }
    }

    presentation->Dispose();
}
```

## **Remover Tinta**

Exclua uma forma de tinta do slide, se existir.

```cpp
static void RemoveInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto ink = SharedPtr<IInk>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IInk>(shape))
        {
            ink = ExplicitCast<IInk>(shape);
            break;
        }
    }
    if (ink != nullptr)
    {
        slide->get_Shapes()->Remove(ink);
    }

    presentation->Dispose();
}
```