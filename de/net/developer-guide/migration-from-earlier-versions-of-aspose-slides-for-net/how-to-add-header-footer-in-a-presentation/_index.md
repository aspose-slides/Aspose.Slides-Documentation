---
title: Wie man Header & Footer zu Präsentationen in .NET hinzufügt
linktitle: Header & Footer hinzufügen
type: docs
weight: 20
url: /de/net/how-to-add-header-footer-in-a-presentation/
keywords:
- Migration
- Header hinzufügen
- Footer hinzufügen
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Header und Footer in PowerPoint PPT, PPTX und ODP Präsentationen in .NET sowohl mit den Legacy- als auch den modernen Aspose.Slides APIs hinzufügen."
---

{{% alert color="primary" %}} 

Eine neue [Aspose.Slides for .NET API](/slides/de/net/) wurde veröffentlicht und dieses einzelne Produkt unterstützt nun die Möglichkeit, PowerPoint‑Dokumente von Grund auf zu erstellen und vorhandene zu bearbeiten.

{{% /alert %}} 
## **Unterstützung für Legacy‑Code**
Um den mit Aspose.Slides for .NET vor Version 13.x entwickelten Legacy‑Code zu verwenden, müssen Sie einige geringfügige Änderungen an Ihrem Code vornehmen, und der Code funktioniert weiterhin wie zuvor. Alle Klassen, die im alten Aspose.Slides for .NET unter den Namespaces Aspose.Slide und Aspose.Slides.Pptx vorhanden waren, sind jetzt in einem einzigen Aspose.Slides‑Namespace zusammengeführt. Bitte schauen Sie sich das folgende einfache Code‑Snippet zur Hinzufügung von Kopf‑ und Fußzeilen in einer Präsentation im Legacy‑Aspose.Slides‑API an und folgen Sie den Schritten, die beschreiben, wie Sie zur neuen zusammengeführten API migrieren.
## **Legacy Aspose.Slides for .NET Ansatz**
```c#
PresentationEx sourcePres = new PresentationEx();

//Festlegen der Sichtbarkeits-Eigenschaften für Kopf- und Fußzeilen
sourcePres.UpdateSlideNumberFields = true;

//Datums- und Zeitfelder aktualisieren
sourcePres.UpdateDateTimeFields = true;

//Datums- und Zeit-Platzhalter anzeigen
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Fußzeilen-Platzhalter anzeigen
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Foliennummer anzeigen
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Sichtbarkeit von Kopf- und Fußzeilen auf Titelfolie festlegen
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Präsentation auf die Festplatte schreiben
sourcePres.Write("NewSource.pptx");
```

```c#
//Präsentation erstellen
Presentation pres = new Presentation();

//Erste Folie holen
Slide sld = pres.GetSlideByPosition(1);

//Auf Header / Footer der Folie zugreifen
HeaderFooter hf = sld.HeaderFooter;

//Seitenzahl-Sichtbarkeit festlegen
hf.PageNumberVisible = true;

//Footer-Sichtbarkeit festlegen
hf.FooterVisible = true;

//Header-Sichtbarkeit festlegen
hf.HeaderVisible = true;

//Datum-Uhrzeit-Sichtbarkeit festlegen
hf.DateTimeVisible = true;

//Datum-Uhrzeit-Format festlegen
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Header-Text festlegen
hf.HeaderText = "Header Text";

//Footer-Text festlegen
hf.FooterText = "Footer Text";

//Präsentation auf die Festplatte schreiben
pres.Write("HeadFoot.ppt");
```


## **Neuer Aspose.Slides for .NET 13.x Ansatz**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Festlegen der Sichtbarkeits-Eigenschaften für Kopf- und Fußzeilen
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Datums- und Zeitfelder aktualisieren
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Datums- und Zeit-Platzhalter anzeigen
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Fußzeilen-Platzhalter anzeigen
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Sichtbarkeit von Kopf- und Fußzeilen auf Titelfolien festlegen
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Präsentation auf die Festplatte schreiben
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
