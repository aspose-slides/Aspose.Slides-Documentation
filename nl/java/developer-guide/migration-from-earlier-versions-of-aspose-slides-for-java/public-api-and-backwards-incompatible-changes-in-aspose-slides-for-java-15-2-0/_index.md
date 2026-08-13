---
title: Openbare API en terugwaarts incompatibele wijzigingen in Aspose.Slides voor Java 15.2.0
linktitle: Aspose.Slides voor Java 15.2.0
type: docs
weight: 110
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- migratie
- verouderde code
- moderne code
- verouderde aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de openbare API en brekende wijzigingen in Aspose.Slides voor Java om uw PowerPoint PPT-, PPTX- en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="info" %}} 

Deze pagina geeft een overzicht van alle [toegevoegde](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) klassen, methoden, eigenschappen enzovoort, eventuele nieuwe beperkingen en andere [wijzigingen](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) die zijn geïntroduceerd met de Aspose.Slides for Java 15.2.0 API.

{{% /alert %}} {{% alert color="info" %}} 

Er zijn bekende problemen met enkele afbeeldingbolletjes en WordArt-objecten die zullen worden opgelost in Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Wijzigingen in de openbare API**
### **addDataPointForDoughnutSeries-methoden zijn toegevoegd**
De twee overloads van de IChartDataPointCollection.addDataPointForDoughnutSeries()-methode zijn toegevoegd om gegevenspunten toe te voegen aan series van het type Doughnut.
### **De classe com.aspose.slides.SmartArtShape is geërfd van de classe com.aspose.slides.GeometryShape**
com.aspose.slides.SmartArtShape class is geërfd van com.aspose.slides.GeometryShape class. Deze wijziging verbetert het objectmodel van Aspose.Slides en voegt nieuwe functionaliteiten toe aan de SmartArtShape‑klasse.
### **IGradientStopCollection.add(...) en IGradientStopCollection.insert(...) methoden zijn gewijzigd**
De handtekening van IGradientStop add(float position, int presetColor) is vervangen door de handtekening IGradientStop addPresetColor(float position, int presetColor).

De handtekening van de IGradientStopCollection‑methode IGradientStop add(float position, SchemeColor schemeColor) is vervangen door de handtekening IGradientStop addSchemeColor(float position, int schemeColor).

De handtekening van de IGradientStopCollection‑methode void insert(int index, float position, int presetColor) is vervangen door de handtekening void insertPresetColor(int index, float position, int presetColor).

De handtekening van de IGradientStopCollection‑methode void insert(int index, float position, SchemeColor schemeColor) is vervangen door de handtekening void insertSchemeColor(int index, float position, int schemeColor).
### **java.awt.Color getAutomaticSeriesColor() methode is toegevoegd aan com.aspose.slides.IChartSeries**
De getAutomaticSeriesColor()-methode retourneert een automatische kleur voor een serie op basis van de serie‑index en het grafiek‑stijl. Deze kleur wordt standaard gebruikt als FillType gelijk is aan NotDefined.
　

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Methode om een grafiek‑gegevenspunt en een grafiek‑categorie op index te verwijderen is toegevoegd**
De IChartDataPointCollection.removeAt(int index)-methode is toegevoegd om een grafiek‑gegevenspunt te verwijderen op basis van zijn index.
De IChartCategoryCollection.removeAt(int index)-methode is toegevoegd om een grafiek‑categorie te verwijderen op basis van zijn index.
### **PptXPptY‑waarde is toegevoegd aan de com.aspose.slides.PropertyType‑enumeratie**
De PptXPptY‑waarde is toegevoegd aan de com.aspose.slides.PropertyType‑enumeratie in het kader van een correctie voor een serialisatie‑probleem.