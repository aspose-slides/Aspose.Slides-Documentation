---
title: Folienübergänge
type: docs
weight: 80
url: /de/net/slide-transitions/
---

Um das Verständnis zu erleichtern, haben wir die Verwendung von Aspose.Slides für .NET zur Verwaltung einfacher Folienübergänge demonstriert. Entwickler können nicht nur verschiedene Folienübergangseffekte auf die Folien anwenden, sondern auch das Verhalten dieser Übergangseffekte anpassen. Um einen einfachen Folienübergangseffekt zu erstellen, folgen Sie den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Presentation‑Klasse
- Wenden Sie einen Folienübergangstyp auf die Folie an, indem Sie einen der von Aspose.Slides für .NET angebotenen Übergangseffekte über das **TransitionType**‑Enum auswählen
- Schreiben Sie die geänderte Präsentationsdatei.

## **Beispiel**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Instantiate Presentation class that represents a presentation file

using (Presentation pres = new Presentation(FileName))

{

    //Apply circle type transition on slide 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Apply comb type transition on slide 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Apply zoom type transition on slide 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Write the presentation to disk

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Beispielcode herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Ausführbares Beispiel herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 

Für weitere Details besuchen Sie [Managing Slides Transitions](/slides/de/net/slide-transition/).

{{% /alert %}}