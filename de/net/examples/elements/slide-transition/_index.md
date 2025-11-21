---
title: Folienübergang
type: docs
weight: 110
url: /de/net/examples/elements/slide-transition/
keywords:
- Beispiel für Folienübergang
- Folienübergang hinzufügen
- Zugriff auf Folienübergang
- Folienübergang entfernen
- Übergangsdauer
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Steuern Sie Folienübergänge in C# mit Aspose.Slides: wählen Sie Typen, Geschwindigkeit, Sound und Timing, um Präsentationen in PPT, PPTX und ODP zu verfeinern."
---

Demonstriert die Anwendung von Folienübergangseffekten und -zeiten mit **Aspose.Slides for .NET**.

## Folienübergang hinzufügen

Wenden Sie einen Fade-Übergangseffekt auf die erste Folie an.
```csharp
static void Add_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Fade-Übergang anwenden
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```


## Zugriff auf einen Folienübergang

Lesen Sie den aktuell einer Folie zugewiesenen Übergangstyp.
```csharp
static void Access_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Push;

    // Zugriff auf den Übergangstyp
    var type = slide.SlideShowTransition.Type;
}
```


## Folienübergang entfernen

Entfernen Sie alle Übergangseffekte, indem Sie den Typ auf `None` setzen.
```csharp
static void Remove_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Übergang entfernen, indem None gesetzt wird
    slide.SlideShowTransition.Type = TransitionType.None;
}
```


## Übergangsdauer festlegen

Geben Sie an, wie lange die Folie angezeigt wird, bevor sie automatisch weiterspringt.
```csharp
static void Set_Transition_Duration()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // in Millisekunden
}
```
