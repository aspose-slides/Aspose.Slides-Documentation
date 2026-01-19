---
title: Hinzufügen von Formen zur Präsentation
type: docs
weight: 30
url: /de/net/adding-shapes-to-presentation/
---

## **VSTO**
Nachfolgend finden Sie das Code-Snippet zum Hinzufügen einer Linienform:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

- Instanz der Klasse Presentation erstellen
- Referenz einer Folie über deren Index abrufen
- AutoShape vom Typ Line mit der AddAutoShape‑Methode des Shapes‑Objekts hinzufügen
- Die geänderte Präsentation als PPTX‑Datei speichern

Im nachstehenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.

``` csharp

   //Instantiate Prseetation class that represents the PPTX

  Presentation pres = new Presentation();

  //Get the first slide

  ISlide slide = pres.Slides[0];

  //Add an autoshape of type line

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Laufenden Code herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Beispielcode herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)