---
title: Slide
type: docs
weight: 10
url: /pt/net/examples/elements/slide/
keywords:
- slide
- adicionar slide
- acessar slide
- índice de slide
- clonar slide
- reordenar slides
- remover slide
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Controle slides no Aspose.Slides for .NET: crie, clone, reordene, redimensione, defina fundos e aplique transições com C# para apresentações PPT, PPTX e ODP."
---
Este artigo fornece uma série de exemplos que demonstram como trabalhar com slides usando **Aspose.Slides for .NET**. Você aprenderá como adicionar, acessar, clonar, reorganizar e remover slides usando a classe `Presentation`.

Cada exemplo abaixo inclui uma breve explicação seguida de um trecho de código em C#.

## **Adicionar um Slide**

Para adicionar um novo slide, você deve primeiro selecionar um layout. Neste exemplo, usamos o layout `Blank` e adicionamos um slide vazio à apresentação.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // Cada slide é baseado em um layout, que por sua vez é baseado em um slide mestre.
    // Use o layout Blank para criar um novo slide.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Adicione um novo slide vazio usando o layout selecionado.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Nota:** Cada layout de slide é derivado de um slide mestre, que define o design geral e a estrutura de marcadores de posição. A imagem abaixo ilustra como os slides mestres e seus layouts associados são organizados no PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## **Acessar Slides por Índice**

Você pode acessar slides usando seu índice, ou encontrar o índice de um slide com base em uma referência. Isso é útil para iterar ou modificar slides específicos.

```csharp
static void AccessSlide()
{
    // Por padrão, uma apresentação é criada com um slide vazio.
    using var presentation = new Presentation();

    // Adicione outro slide vazio.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Acesse slides por índice.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // Obtenha o índice do slide a partir de uma referência e, então, acesse-o por índice.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **Clonar um Slide**

Este exemplo demonstra como clonar um slide existente. O slide clonado é automaticamente adicionado ao final da coleção de slides.

```csharp
static void CloneSlide()
{
    // Por padrão, a apresentação contém um slide vazio.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Clone o primeiro slide; ele será adicionado ao final da apresentação.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // O índice do slide clonado é 1 (segundo slide na apresentação).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **Reordenar Slides**

Você pode mudar a ordem dos slides movendo um para um novo índice. Neste caso, movemos um slide clonado para a primeira posição.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Adicione um clone do primeiro slide (criado por padrão).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // Mova o slide clonado para a primeira posição (os demais são deslocados para baixo).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Remover um Slide**

Para remover um slide, basta referenciá‑lo e chamar `Remove`. Este exemplo adiciona um segundo slide e então remove o original, ficando apenas o novo.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // Adicione um novo slide vazio além do slide padrão inicial.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Remova o primeiro slide; apenas o slide recém-adicionado permanecerá.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```