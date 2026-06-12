---
title: Transizione della diapositiva
type: docs
weight: 110
url: /it/net/examples/elements/slide-transition/
keywords:
- transizione della diapositiva
- aggiungi transizione della diapositiva
- accedi alla transizione della diapositiva
- rimuovi transizione della diapositiva
- durata della transizione
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci le transizioni delle diapositive in Aspose.Slides per .NET: aggiungi, personalizza e sequenzia effetti e durate con esempi C# per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra l'applicazione di effetti di transizione delle diapositive e dei tempi con **Aspose.Slides for .NET**.

## **Aggiungi una transizione della diapositiva**

Applica un effetto di transizione dissolvenza alla prima diapositiva.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Applica una transizione di dissolvenza.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **Accedi a una transizione della diapositiva**

Leggi il tipo di transizione attualmente assegnato a una diapositiva.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // Accedi al tipo di transizione.
    var type = slide.SlideShowTransition.Type;
}
```

## **Rimuovi una transizione della diapositiva**

Cancella qualsiasi effetto di transizione impostando il tipo su `None`.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Rimuovi la transizione impostando none.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **Imposta la durata della transizione**

Specificare per quanto tempo la diapositiva viene visualizzata prima di avanzare automaticamente.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // in millisecondi
}
```