---
title: Diaovergang
type: docs
weight: 110
url: /nl/net/examples/elements/slide-transition/
keywords:
- diaovergang
- diaovergang toevoegen
- toegang tot diaovergang
- diaovergang verwijderen
- duur van de overgang
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheers diaovergangen in Aspose.Slides for .NET: voeg toe, pas aan en rangschik effecten en duur met C#-voorbeelden voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel demonstreert het toepassen van dia‑overgangseffecten en -tijden met **Aspose.Slides for .NET**.

## **Een diaovergang toevoegen**

Pas een vervagings‑overgangseffect toe op de eerste dia.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Pas een vervagings-overgang toe.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **Toegang tot een diaovergang**

Lees het overgangstype dat momenteel aan een dia is toegewezen.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // Toegang tot het overgangstype.
    var type = slide.SlideShowTransition.Type;
}
```

## **Een diaovergang verwijderen**

Verwijder elk overgangseffect door het type in te stellen op `None`.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Verwijder de overgang door none in te stellen.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **De duur van de overgang instellen**

Geef op hoe lang de dia wordt weergegeven voordat deze automatisch wordt voortgezet.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // in milliseconden
}
```