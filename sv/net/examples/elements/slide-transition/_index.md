---
title: Bildövergång
type: docs
weight: 110
url: /sv/net/examples/elements/slide-transition/
keywords:
- bildövergång
- lägg till bildövergång
- åtkomst till bildövergång
- ta bort bildövergång
- övergångstid
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Behärska bildövergångar i Aspose.Slides för .NET: lägg till, anpassa och sekvensera effekter och varaktigheter med C#-exempel för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur man tillämpar bildövergångseffekter och tidinställningar med **Aspose.Slides for .NET**.

## **Lägg till en bildövergång**

Applicera en toningsövergångseffekt på den första bilden.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Applicera en toningsövergång.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **Få åtkomst till en bildövergång**

Läs den övergångstyp som för närvarande är tilldelad en bild.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // Åtkomst till övergångstypen.
    var type = slide.SlideShowTransition.Type;
}
```

## **Ta bort en bildövergång**

Rensa eventuella övergångseffekter genom att sätta typen till `None`.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Ta bort övergång genom att sätta None.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **Ange övergångstid**

Ange hur länge bilden visas innan den går vidare automatiskt.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // i millisekunder
}
```