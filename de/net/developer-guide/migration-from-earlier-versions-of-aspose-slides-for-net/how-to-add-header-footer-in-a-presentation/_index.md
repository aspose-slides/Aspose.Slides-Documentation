---
title: So fügen Sie Kopf- und Fußzeilen in einer Präsentation hinzu
type: docs
weight: 20
url: /net/how-to-add-header-footer-in-a-presentation/
---

{{% alert color="primary" %}} 

Eine neue [Aspose.Slides für .NET API](/slides/net/) wurde veröffentlicht und nun unterstützt dieses einzelne Produkt die Möglichkeit, PowerPoint-Dokumente von Grund auf neu zu erstellen und vorhandene zu bearbeiten.

{{% /alert %}} 
## **Unterstützung für Legacy-Code**
Um den Legacy-Code zu verwenden, der mit Aspose.Slides für .NET-Versionen vor 13.x entwickelt wurde, müssen Sie einige kleine Änderungen an Ihrem Code vornehmen, und der Code wird wie früher funktionieren. Alle Klassen, die in der alten Aspose.Slides für .NET unter den Namespaces Aspose.Slide und Aspose.Slides.Pptx vorhanden waren, sind jetzt in den einzelnen Aspose.Slides-Namespace zusammengeführt. Bitte werfen Sie einen Blick auf das folgende einfache Code-Snippet zum Hinzufügen von Kopf- und Fußzeilen in Präsentationen in der Legacy Aspose.Slides API und folgen Sie den Schritten, die beschreiben, wie man zur neuen zusammengeführten API migriert.
## **Legacy Aspose.Slides für .NET Ansatz**
```c#
PresentationEx sourcePres = new PresentationEx();

//Eigenschaften zur Sichtbarkeit von Kopf- und Fußzeilen einstellen
sourcePres.UpdateSlideNumberFields = true;

//Aktualisieren der Datums- und Uhrzeitfelder
sourcePres.UpdateDateTimeFields = true;

//Datums- und Uhrzeitplatzhalter anzeigen
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Fußzeilenplatzhalter anzeigen
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Foliennummer anzeigen
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Sichtbarkeit der Kopf- und Fußzeilen auf der Titelfolie einstellen
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Die Präsentation auf die Festplatte schreiben
sourcePres.Write("NewSource.pptx");
```

```c#
//Die Präsentation erstellen
Presentation pres = new Presentation();

//Erste Folie abrufen
Slide sld = pres.GetSlideByPosition(1);

//Auf die Kopf-/Fußzeile der Folie zugreifen
HeaderFooter hf = sld.HeaderFooter;

//Sichtbarkeit der Seitennummer einstellen
hf.PageNumberVisible = true;

//Sichtbarkeit der Fußzeile einstellen
hf.FooterVisible = true;

//Sichtbarkeit der Kopfzeile einstellen
hf.HeaderVisible = true;

//Sichtbarkeit von Datum und Uhrzeit einstellen
hf.DateTimeVisible = true;

//Datums- und Uhrzeitformat einstellen
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Kopfzeilentext einstellen
hf.HeaderText = "Kopfzeilentext";

//Fußzeilentext einstellen
hf.FooterText = "Fußzeilentext";

//Die Präsentation auf die Festplatte schreiben
pres.Write("HeadFoot.ppt");
```



## **Neuer Ansatz von Aspose.Slides für .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Eigenschaften zur Sichtbarkeit von Kopf- und Fußzeilen einstellen
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Aktualisieren der Datums- und Uhrzeitfelder
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Datums- und Uhrzeitplatzhalter anzeigen
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Fußzeilenplatzhalter anzeigen
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Sichtbarkeit der Kopf- und Fußzeilen auf der Titelfolie einstellen
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Die Präsentation auf die Festplatte schreiben
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```