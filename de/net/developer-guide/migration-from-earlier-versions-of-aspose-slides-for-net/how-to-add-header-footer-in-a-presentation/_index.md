---
title: So fügen Sie Kopf‑ und Fußzeilen zu Präsentationen in .NET hinzu
linktitle: Kopf‑ und Fußzeile hinzufügen
type: docs
weight: 20
url: /de/net/how-to-add-header-footer-in-a-presentation/
keywords:
- Migration
- Kopfzeile hinzufügen
- Fußzeile hinzufügen
- Legacy‑Code
- Moderner Code
- Legacy‑Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie in .NET Kopf‑ und Fußzeilen in PowerPoint‑PPT, PPTX‑ und ODP‑Präsentationen mithilfe sowohl der Legacy‑ als auch der modernen Aspose.Slides‑APIs hinzufügen."
---

{{% alert color="primary" %}} 

Eine neue [Aspose.Slides für .NET API](/slides/de/net/) wurde veröffentlicht und jetzt unterstützt dieses einzelne Produkt die Möglichkeit, PowerPoint‑Dokumente von Grund auf zu erstellen und vorhandene zu bearbeiten.

{{% /alert %}} 
## **Unterstützung für Legacy-Code**
Um den Legacy‑Code zu verwenden, der mit Aspose.Slides für .NET Versionen vor 13.x entwickelt wurde, müssen Sie einige geringfügige Änderungen an Ihrem Code vornehmen, und der Code wird wie zuvor funktionieren. Alle Klassen, die in der alten Aspose.Slides für .NET unter den Namespaces Aspose.Slide und Aspose.Slides.Pptx vorhanden waren, sind jetzt in einem einzigen Aspose.Slides‑Namespace zusammengeführt. Bitte sehen Sie sich das folgende einfache Code‑Snippet zum Hinzufügen von Kopf‑ und Fußzeilen in einer Präsentation im Legacy Aspose.Slides‑API an und befolgen Sie die Schritte, die beschreiben, wie Sie zur neuen zusammengeführten API migrieren.
## **Legacy Aspose.Slides für .NET Ansatz**
```c#
PresentationEx sourcePres = new PresentationEx();

//Festlegen der Sichtbarkeit von Kopf- und Fußzeilen
sourcePres.UpdateSlideNumberFields = true;

//Aktualisieren der Datums- und Zeitfelder
sourcePres.UpdateDateTimeFields = true;

//Datum- und Zeit-Platzhalter anzeigen
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Fußzeilen-Platzhalter anzeigen
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Foliennummer anzeigen
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Festlegen der Sichtbarkeit von Kopf- und Fußzeilen auf der Titelfolie
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Präsentation auf die Festplatte schreiben
sourcePres.Write("NewSource.pptx");
```

```c#
//Präsentation erstellen
Presentation pres = new Presentation();

//Erste Folie holen
Slide sld = pres.GetSlideByPosition(1);

//Zugriff auf Header / Footer der Folie
HeaderFooter hf = sld.HeaderFooter;

//Seitenzahl Sichtbarkeit festlegen
hf.PageNumberVisible = true;

//Footer Sichtbarkeit festlegen
hf.FooterVisible = true;

//Header Sichtbarkeit festlegen
hf.HeaderVisible = true;

//Datum Zeit Sichtbarkeit festlegen
hf.DateTimeVisible = true;

//Datum Zeit Format festlegen
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

    //Datums- und Zeitfelder aktualisieren
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Datums- und Zeit-Platzhalter anzeigen
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Fußzeilen-Platzhalter anzeigen
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Kopf- und Fußzeilen-Sichtbarkeit auf Titelfolien festlegen
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Präsentation auf die Festplatte schreiben
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
