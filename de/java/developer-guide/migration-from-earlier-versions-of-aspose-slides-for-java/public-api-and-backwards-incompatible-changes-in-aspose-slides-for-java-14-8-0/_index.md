---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für Java 14.8.0
linktitle: Aspose.Slides für Java 14.8.0
type: docs
weight: 70
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- Migration
- Legacy-Code
- Modernen Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Überblick über öffentliche API-Updates und kritische Änderungen in Aspose.Slides für Java, um Ihre PowerPoint PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 

Diese Seite listet alle [hinzugefügt](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) Klassen, Methoden, Eigenschaften usw., alle neuen Einschränkungen und weitere [Änderungen](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) auf, die mit der Aspose.Slides for Java 14.8.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
### **Hinzugefügte Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() und setOverlap(byte) Methoden**
Die Methode Aspose.Slides.Charts.IChartSeries.getOverlap() ermittelt, wie stark Balken und Säulen in 2D-Diagrammen überlappen sollen (in einem Bereich von -100 bis 100).  
Diese Methode gilt nicht nur für eine bestimmte Serie, sondern für alle Serien der übergeordneten Seriengruppe – sie ist eine Projektion der entsprechenden Gruppeneigenschaft.

- Verwenden Sie die Methode IChartSeries.getParentSeriesGroup() zum Zugriff auf die übergeordnete Seriengruppe.
- Verwenden Sie die Methoden IChartSeriesGroup.getOverlap() und setOverlap(byte), um den Wert zu verwalten.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **Hinzugefügter ShapeThumbnailBounds.Appearance-Enum-Wert**
Diese Methode zur Erstellung von Formvorschauen ermöglicht Entwicklern, eine Formvorschau innerhalb der Grenzen ihres Erscheinungsbildes zu erzeugen. Sie berücksichtigt alle Formeffekte. Die erzeugte Formvorschau ist durch die Folienränder begrenzt.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Hinzugefügte VbaProject-Klasse und IVbaProject-Schnittstelle, geänderte Presentation.getVbaProject()- und setVbaProject(VbaProject)-Methoden**
Eine neue Funktion ermöglicht Entwicklern, VBA-Projekte in einer Präsentation zu erstellen und zu bearbeiten.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// Neues VBA-Projekt erstellen

pres.setVbaProject(new VbaProject());

// Leeres Modul zum VBA-Projekt hinzufügen

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Modul-Quellcode festlegen

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Referenz zu <stdole> erstellen

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Referenz zu Office erstellen

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Verweise zum VBA-Projekt hinzufügen

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("test.pptm", SaveFormat.Pptm);

```