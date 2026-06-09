---
title: Slide
type: docs
weight: 10
url: /pt/cpp/examples/elements/slide/
keywords:
- exemplo de código
- slide
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Controle os slides no Aspose.Slides para C++: crie, clone, reordene, redimensione, defina fundos e aplique transições com C++ em apresentações PPT, PPTX e ODP."
---
Este artigo fornece uma série de exemplos que demonstram como trabalhar com slides usando **Aspose.Slides for C++**. Você aprenderá como adicionar, acessar, clonar, reordenar e remover slides usando a classe `Presentation`.

Cada exemplo abaixo inclui uma breve explicação seguida por um trecho de código em C++.

## **Adicionar um Slide**

Para adicionar um novo slide, você deve primeiro selecionar um layout. Neste exemplo, usamos o layout `Blank` e adicionamos um slide vazio à apresentação.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **Observação:** Cada layout de slide é derivado de um slide mestre, que define o design geral e a estrutura de placeholders. A imagem abaixo ilustra como os slides mestres e seus layouts associados são organizados no PowerPoint.

![Relação entre Mestre e Layout](master-layout-slide.png)

## **Acessar Slides por Índice**

Você pode acessar slides usando seu índice, ou encontrar o índice de um slide com base em uma referência. Isso é útil para iterar ou modificar slides específicos.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Adicionar outro slide vazio.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // Acessar slides por índice.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // Obter o índice do slide a partir de uma referência, então acessá-lo por índice.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Clonar um Slide**

Este exemplo demonstra como clonar um slide existente. O slide clonado é adicionado automaticamente ao final da coleção de slides.

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **Reordenar Slides**

Você pode alterar a ordem dos slides movendo um para um novo índice. Neste caso, movemos um slide clonado para a primeira posição.

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **Remover um Slide**

Para remover um slide, basta referenciá‑lo e chamar `Remove`. Este exemplo adiciona um segundo slide e depois remove o original, deixando apenas o novo.

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```