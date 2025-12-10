---
title: "So fügen Sie Header & Footer zu Präsentationen in .NET hinzu"
linktitle: "Header & Footer hinzufügen"
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
description: "Erfahren Sie, wie Sie Header und Footer in PowerPoint PPT-, PPTX- und ODP-Präsentationen in .NET mit sowohl der Legacy- als auch der modernen Aspose.Slides-API hinzufügen."
---

{{% alert color="primary" %}} 

Eine neue [Aspose.Slides for .NET API](/slides/de/net/) wurde veröffentlicht und jetzt unterstützt dieses einzelne Produkt die Möglichkeit, PowerPoint‑Dokumente von Grund auf zu erstellen und vorhandene zu bearbeiten.

{{% /alert %}} 
## **Support for Legacy Code**
Um den mit älteren Aspose.Slides for .NET‑Versionen (vor 13.x) entwickelten Legacy‑Code zu verwenden, müssen Sie einige kleine Änderungen an Ihrem Code vornehmen, damit er wie zuvor funktioniert. Alle Klassen, die in der alten Aspose.Slides for .NET unter den Namespaces Aspose.Slide und Aspose.Slides.Pptx vorhanden waren, wurden jetzt in einen einzigen Aspose.Slides‑Namespace zusammengeführt. Bitte werfen Sie einen Blick auf das folgende einfache Code‑Snippet zum Hinzufügen von Kopf‑ und Fußzeilen in einer Präsentation mit der Legacy‑Aspose.Slides‑API und folgen Sie den Schritten, die beschreiben, wie Sie zur neuen zusammengeführten API migrieren.
## **Legacy Aspose.Slides for .NET Approach**
```c#
PresentationEx sourcePres = new PresentationEx();

//Einstellen der Sichtbarkeits‑Eigenschaften für Kopf‑ und Fußzeile
sourcePres.UpdateSlideNumberFields = true;

//Aktualisieren der Datums‑ und Zeitfelder
sourcePres.UpdateDateTimeFields = true;

//Datums‑ und Zeit‑Platzhalter anzeigen
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Fußzeilen‑Platzhalter anzeigen
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Foliennummer anzeigen
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Sichtbarkeit von Kopf‑ und Fußzeile auf Titelfolie festlegen
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Präsentation auf die Festplatte schreiben
sourcePres.Write("NewSource.pptx");
```

```c#
//Präsentation erstellen
Presentation pres = new Presentation();

//Erste Folie abrufen
Slide sld = pres.GetSlideByPosition(1);

//Zugriff auf Header / Footer der Folie
HeaderFooter hf = sld.HeaderFooter;

//Seitennummer-Sichtbarkeit festlegen
hf.PageNumberVisible = true;

//Footer-Sichtbarkeit festlegen
hf.FooterVisible = true;

//Header-Sichtbarkeit festlegen
hf.HeaderVisible = true;

//Datum/Uhrzeit-Sichtbarkeit festlegen
hf.DateTimeVisible = true;

//Datum/Uhrzeit-Format festlegen
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Header-Text festlegen
hf.HeaderText = "Header Text";

//Footer-Text festlegen
hf.FooterText = "Footer Text";

//Präsentation auf die Festplatte schreiben
pres.Write("HeadFoot.ppt");
```




## **New Aspose.Slides for .NET 13.x Approach**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Festlegen der Sichtbarkeits‑Eigenschaften für Kopf‑ und Fußzeile
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Datums‑ und Zeitfelder aktualisieren
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Datums‑ und Zeit‑Platzhalter anzeigen
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Fußzeilen‑Platzhalter anzeigen
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Sichtbarkeit von Kopf‑ und Fußzeile auf Titelfolien festlegen
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Präsentation auf die Festplatte schreiben
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
