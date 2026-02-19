---
title: Folienübergang
type: docs
weight: 110
url: /de/net/examples/elements/slide-transition/
keywords:
- Folienübergang
- Folienübergang hinzufügen
- Folienübergang abrufen
- Folienübergang entfernen
- Übergangsdauer
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Meistern Sie Folienübergänge in Aspose.Slides für .NET: Hinzufügen, Anpassen und Sequenzieren von Effekten und Dauern mit C#-Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert die Anwendung von Folienübergangseffekten und Zeitsteuerungen mit **Aspose.Slides for .NET**.

## **Folieübergang hinzufügen**

Wenden Sie einen Überblendeffekt auf die erste Folie an.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Fade-Übergang anwenden.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **Zugriff auf einen Folienübergang**

Lesen Sie den aktuell einer Folie zugewiesenen Übergangstyp.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // Zugriff auf den Übergangstyp.
    var type = slide.SlideShowTransition.Type;
}
```

## **Folienübergang entfernen**

Entfernen Sie alle Übergangseffekte, indem Sie den Typ auf `None` setzen.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Übergang entfernen, indem er auf None gesetzt wird.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **Übergangsdauer festlegen**

Geben Sie an, wie lange die Folie angezeigt wird, bevor sie automatisch weitergeht.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // in Millisekunden
}
```