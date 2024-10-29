---
title: Öffentliche API und nicht rückwärtskompatible Änderungen in Aspose.Slides für Java 14.8.0
type: docs
weight: 70
url: /de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) Klassen, Methoden, Eigenschaften usw., alle neuen Einschränkungen und andere [Änderungen](/slides/de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) auf, die mit der Aspose.Slides für Java 14.8.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
### **Hinzugefügt die Methoden Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() und setOverlap(byte)**
Die Methode Aspose.Slides.Charts.IChartSeries.getOverlap() gibt an, wie viel sich Balken und Säulen in 2D-Diagrammen überlappen sollten (im Bereich von -100 bis 100).
Diese Methode ist nicht nur für bestimmte Serien, sondern für alle Serien der übergeordneten Seriengruppe - dies ist eine Projektion der entsprechenden Gruppenproperty.

- Verwenden Sie die IChartSeries.getParentSeriesGroup() Methode, um auf die übergeordnete Seriengruppe zuzugreifen.
- Verwenden Sie die Methoden IChartSeriesGroup.getOverlap() und setOverlap(byte), um den Wert zu verwalten.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **Hinzugefügt den ShapeThumbnailBounds.Appearance Enum-Wert**
Diese Methode zum Erstellen von Formthumbnails ermöglicht Entwicklern, ein Formthumbnail innerhalb der Grenzen ihres Erscheinungsbilds zu generieren. Sie berücksichtigt alle Formeffekte. Das generierte Formthumbnail ist durch die Foliengrenzen eingeschränkt.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Hinzugefügt die VbaProject-Klasse und IVbaProject-Schnittstelle, geändert die Methoden Presentation.getVbaProject() und setVbaProject(VbaProject)**
Ein neues Feature ermöglicht es Entwicklern, VBA-Projekte in einer Präsentation zu erstellen und zu bearbeiten.

``` java

 Presentation pres = new Presentation();

// Neues VBA-Projekt erstellen

pres.setVbaProject(new VbaProject());

// Leeres Modul zum VBA-Projekt hinzufügen

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Modul");

// Quellcode des Moduls festlegen

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Referenz auf <stdole> erstellen

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Referenz auf Office erstellen

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Objektbibliothek");

// Referenzen zum VBA-Projekt hinzufügen

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```