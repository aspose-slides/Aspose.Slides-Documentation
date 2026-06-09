---
title: Transição de Slide
type: docs
weight: 110
url: /pt/net/examples/elements/slide-transition/
keywords:
- transição de slide
- adicionar transição de slide
- acessar transição de slide
- remover transição de slide
- duração da transição
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Domine as transições de slide no Aspose.Slides for .NET: adicione, personalize e sequencie efeitos e durações com exemplos em C# para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra a aplicação de efeitos de transição de slides e temporizações com **Aspose.Slides for .NET**.

## **Adicionar uma Transição de Slide**

Aplique um efeito de transição de desvanecimento ao primeiro slide.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Aplicar uma transição de desvanecimento.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **Acessar uma Transição de Slide**

Leia o tipo de transição atualmente atribuído a um slide.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // Acessar o tipo de transição.
    var type = slide.SlideShowTransition.Type;
}
```

## **Remover uma Transição de Slide**

Remova qualquer efeito de transição definindo o tipo como `None`.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Remover transição definindo none.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **Definir Duração da Transição**

Especifique por quanto tempo o slide é exibido antes de avançar automaticamente.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // em milissegundos
}
```