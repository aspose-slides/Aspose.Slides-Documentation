---
title: Offentligt API och bakåtinkompatibla förändringar i Aspose.Slides för Java 14.8.0
linktitle: Aspose.Slides för Java 14.8.0
type: docs
weight: 70
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- migration
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT, PPTX och ODP presentationslösningar."
---
{{% alert color="info" %}} 
Den här sidan listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) klasser, metoder, egenskaper osv., eventuella nya begränsningar och andra [ändringar](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) som introducerats med Aspose.Slides for Java 14.8.0 API.
{{% /alert %}} 
## **Offentliga API-ändringar**
### **Lade till Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() och setOverlap(byte) metoderna**
Aspose.Slides.Charts.IChartSeries.getOverlap() returnerar hur mycket staplar och kolumner ska överlappa i 2D-diagram (i intervallet -100 till 100).  
Denna metod gäller inte bara för specifika serier utan för alla serier i den överordnade serieggruppen – detta är en projektion av den lämpliga gruppens egenskap.

- Använd metoden IChartSeries.getParentSeriesGroup() för att komma åt den överordnade serieggruppen.  
- Använd metoderna IChartSeriesGroup.getOverlap() och setOverlap(byte) för att hantera värdet.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **Lade till enum‑värdet ShapeThumbnailBounds.Appearance**
Denna metod för att skapa bildminiatyrer gör det möjligt för utvecklare att generera en miniatyr av en form inom dess utseendes gränser. Den tar hänsyn till alla formeffekter. Den genererade miniatyren begränsas av bildens gränser.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Lade till VbaProject-klassen och IVbaProject‑gränssnittet, ändrade Presentation.getVbaProject() och setVbaProject(VbaProject)-metoderna**
En ny funktion gör det möjligt för utvecklare att skapa och redigera VBA‑projekt i en presentation.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// Skapa nytt VBA-projekt

pres.setVbaProject(new VbaProject());

// Lägg till en tom modul i VBA-projektet

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Ange modulens källkod

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Skapa referens till <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Skapa referens till Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Lägg till referenser i VBA-projektet

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("test.pptm", SaveFormat.Pptm);
```