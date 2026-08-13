---
title: Wie man Kopf‑ und Fußzeilen zu Präsentationen in .NET hinzufügt
linktitle: Kopf‑ und Fußzeile hinzufügen
type: docs
weight: 20
url: /de/net/how-to-add-header-footer-in-a-presentation/
keywords:
- Migration
- Kopfzeile hinzufügen
- Fußzeile hinzufügen
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
description: "Erfahren Sie, wie Sie in .NET Kopf‑ und Fußzeilen in PowerPoint‑PPT, PPTX‑ und ODP‑Präsentationen sowohl mit dem Legacy‑ als auch mit dem modernen Aspose.Slides‑API hinzufügen."
---
{{% alert color="info" %}}
Eine neue [Aspose.Slides for .NET API](/slides/de/net/) wurde veröffentlicht und unterstützt nun die Möglichkeit, PowerPoint-Dokumente von Grund auf zu erstellen und vorhandene zu bearbeiten.
{{% /alert %}}
## **Support for Legacy Code**
Um den mit früheren Aspose.Slides for .NET-Versionen (vor 13.x) entwickelten Legacy-Code zu verwenden, müssen Sie einige kleine Änderungen an Ihrem Code vornehmen, und der Code wird wie zuvor funktionieren. Alle Klassen, die in der alten Aspose.Slides for .NET unter den Namespaces Aspose.Slide und Aspose.Slides.Pptx vorhanden waren, sind jetzt in einem einzigen Aspose.Slides-Namespace zusammengeführt. Bitte schauen Sie sich das folgende einfache Code-Snippet zum Hinzufügen von Kopf- und Fußzeilen zu einer Präsentation im Legacy Aspose.Slides API an und folgen Sie den Schritten, die beschreiben, wie Sie zur neuen zusammengeführten API migrieren.
## **Legacy Aspose.Slides for .NET Ansatz**
```c#
PresentationEx sourcePres = new PresentationEx();

//Festlegen der Sichtbarkeit von Kopf- und Fußzeilen
sourcePres.UpdateSlideNumberFields = true;

//Datums- und Zeitfelder aktualisieren
sourcePres.UpdateDateTimeFields = true;

//Datums- und Zeitplatzhalter anzeigen
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Fußzeilen-Platzhalter anzeigen
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Foliennummer anzeigen
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Sichtbarkeit von Kopf- und Fußzeilen auf der Titelfolie festlegen
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Präsentation auf die Festplatte schreiben
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

//Präsentation erstellen
Presentation pres = new Presentation();

//Erste Folie abrufen
Slide sld = pres.GetSlideByPosition(1);

//Auf Header / Footer der Folie zugreifen
HeaderFooter hf = sld.HeaderFooter;

//Sichtbarkeit der Seitenzahl festlegen
hf.PageNumberVisible = true;

//Sichtbarkeit der Fußzeile festlegen
hf.FooterVisible = true;

//Sichtbarkeit der Kopfzeile festlegen
hf.HeaderVisible = true;

//Sichtbarkeit von Datum und Uhrzeit festlegen
hf.DateTimeVisible = true;

//Datums- und Zeitformat festlegen
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Kopfzeilentext festlegen
hf.HeaderText = "Header Text";

//Fußzeilentext festlegen
hf.FooterText = "Footer Text";

//Präsentation auf die Festplatte schreiben
pres.Write("HeadFoot.ppt");
```

## **New Aspose.Slides for .NET 13.x Ansatz**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //Festlegen der Sichtbarkeit von Kopf- und Fußzeilen
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Datums- und Zeitfelder aktualisieren
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Datums- und Zeitplatzhalter anzeigen
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Fußzeilen-Platzhalter anzeigen
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Setze die  Kopf- und Fußzeilen-Sichtbarkeit auf der Titelfolie
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Präsentation auf die Festplatte schreiben
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```