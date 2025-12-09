---
title: Wie man Kopf- und Fußzeilen zu Präsentationen in .NET hinzufügt
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
description: "Erfahren Sie, wie Sie in .NET mithilfe sowohl der Legacy- als auch der modernen Aspose.Slides-APIs Kopf- und Fußzeilen in PowerPoint PPT-, PPTX- und ODP-Präsentationen hinzufügen."
---

{{% alert color="primary" %}} 

Eine neue [Aspose.Slides for .NET API](/slides/de/net/) wurde veröffentlicht und unterstützt nun die Möglichkeit, PowerPoint‑Dokumente von Grund auf zu erstellen und vorhandene zu bearbeiten.

{{% /alert %}} 
## **Unterstützung für Legacy-Code**
Um den mit früheren Aspose.Slides für .NET‑Versionen (vor 13.x) entwickelten Legacy‑Code zu verwenden, müssen Sie einige kleine Änderungen an Ihrem Code vornehmen, damit er wie zuvor funktioniert. Alle Klassen, die in der alten Aspose.Slides für .NET unter den Namespaces Aspose.Slide und Aspose.Slides.Pptx vorhanden waren, sind jetzt in einem einzigen Aspose.Slides‑Namespace zusammengeführt. Bitte werfen Sie einen Blick auf das folgende einfache Code‑Snippet zum Hinzufügen von Kopf‑ und Fußzeilen in einer Präsentation mit der Legacy‑Aspose.Slides‑API und folgen Sie den Schritten, die beschreiben, wie Sie zur neuen zusammengeführten API migrieren.
## **Legacy Aspose.Slides für .NET Ansatz**
```c#
PresentationEx sourcePres = new PresentationEx();

//Festlegen der Sichtbarkeit von Kopf- und Fußzeilen
sourcePres.UpdateSlideNumberFields = true;

//Aktualisieren der Datums- und Uhrzeitfelder
sourcePres.UpdateDateTimeFields = true;

//Datum-Uhrzeit-Platzhalter anzeigen
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
//Präsentation erstellen
Presentation pres = new Presentation();

//Erste Folie abrufen
Slide sld = pres.GetSlideByPosition(1);

//Header / Footer der Folie zugreifen
HeaderFooter hf = sld.HeaderFooter;

//Seitenzahl Sichtbarkeit festlegen
hf.PageNumberVisible = true;

//Footer Sichtbarkeit festlegen
hf.FooterVisible = true;

//Header Sichtbarkeit festlegen
hf.HeaderVisible = true;

//Datum/Uhrzeit Sichtbarkeit festlegen
hf.DateTimeVisible = true;

//Datum/Uhrzeit Format festlegen
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Header-Text festlegen
hf.HeaderText = "Header Text";

//Footer-Text festlegen
hf.FooterText = "Footer Text";

//Präsentation auf die Festplatte schreiben
pres.Write("HeadFoot.ppt");
```




## **Neuer Aspose.Slides für .NET 13.x Ansatz**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Festlegen der Sichtbarkeit von Kopf- und Fußzeilen
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Datums- und Uhrzeitfelder aktualisieren
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Datums- und Uhrzeit-Platzhalter anzeigen
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Fußzeilen-Platzhalter anzeigen
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Sichtbarkeit von Kopf- und Fußzeilen auf Titelfolie festlegen
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Präsentation auf die Festplatte schreiben
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
