---
title: Openbare API en terugwaartse incompatibele wijzigingen in Aspose.Slides voor Java 15.2.0
linktitle: Aspose.Slides voor Java 15.2.0
type: docs
weight: 110
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- migratie
- verouderde code
- moderne code
- verouderde benadering
- moderne benadering
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de openbare API en de brekende wijzigingen in Aspose.Slides voor Java om uw PowerPoint PPT, PPTX en ODP presentatiesoftware soepel te migreren."
---
{{% alert color="primary" %}} 

Deze pagina geeft een overzicht van alle [toegevoegde](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) klassen, methoden, eigenschappen enzovoort, eventuele nieuwe beperkingen en andere [wijzigingen](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) die geïntroduceerd zijn met de Aspose.Slides for Java 15.2.0 API.

{{% /alert %}} {{% alert color="primary" %}} 

Er zijn bekende problemen met sommige afbeeldingskogelpunten en WordArt‑objecten die zullen worden verholpen in Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Openbare API‑wijzigingen**
### **addDataPointForDoughnutSeries‑methoden zijn toegevoegd**
De twee overloads van de IChartDataPointCollection.addDataPointForDoughnutSeries()‑methode zijn toegevoegd om gegevenspunten toe te voegen aan series van het type Doughnut.
### **com.aspose.slides.SmartArtShape‑klasse is overgeërfd van com.aspose.slides.GeometryShape‑klasse**
De com.aspose.slides.SmartArtShape‑klasse is overgeërfd van de com.aspose.slides.GeometryShape‑klasse. Deze wijziging verbetert het objectmodel van Aspose.Slides en voegt nieuwe functionaliteit toe aan de SmartArtShape‑klasse.
### **IGradientStopCollection.add(...) en IGradientStopCollection.insert(...)‑methoden zijn gewijzigd**
De handtekening van IGradientStop add(float position, int presetColor) is vervangen door de handtekening IGradientStop addPresetColor(float position, int presetColor).

De handtekening van de IGradientStopCollection‑methode IGradientStop add(float position, SchemeColor schemeColor) is vervangen door de handtekening IGradientStop addSchemeColor(float position, int schemeColor).

De handtekening van de IGradientStopCollection‑methode void insert(int index, float position, int presetColor) is vervangen door de handtekening void insertPresetColor(int index, float position, int presetColor).

De handtekening van de IGradientStopCollection‑methode void insert(int index, float position, SchemeColor schemeColor) is vervangen door de handtekening void insertSchemeColor(int index, float position, int schemeColor).
### **java.awt.Color getAutomaticSeriesColor()‑methode is toegevoegd aan com.aspose.slides.IChartSeries**
De getAutomaticSeriesColor()‑methode retourneert een automatische kleur voor een serie op basis van het serienummer en de diagramstijl. Deze kleur wordt standaard gebruikt als FillType gelijk is aan NotDefined.
 
``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Methode om een diagramdatapunt en diagramcategorie te verwijderen op basis van de index is toegevoegd**
De IChartDataPointCollection.removeAt(int index)‑methode is toegevoegd om een diagramdatapunt te verwijderen op basis van de index.
De IChartCategoryCollection.removeAt(int index)‑methode is toegevoegd om een diagramcategorie te verwijderen op basis van de index.
### **De waarde PptXPptY is toegevoegd aan de enumeratie com.aspose.slides.PropertyType**
De waarde PptXPptY is toegevoegd aan de enumeratie com.aspose.slides.PropertyType in het kader van een correctie voor een serialisatie‑probleem.