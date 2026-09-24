---
title: Grafiekdatatabellen aanpassen in presentaties op Android
linktitle: Gegevenstabel
type: docs
url: /nl/androidjava/chart-data-table/
keywords:
- grafiekgegevens
- gegevenstabel
- lettertype-eigenschappen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Pas de lettertypen, randen en legendasleutels van grafiek-gegevenstabellen aan in PowerPoint-presentaties met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Aspose.Slides for Android via Java stelt u in staat om de gegevenstabel van een diagram weer te geven en de tekstopmaak, randen en legenda‑sleutels aan te passen. Dit artikel legt uit hoe u de tabel inschakelt, de tekst opmaakt, elk type rand beheert en legenda‑sleutels toont of verbergt. De voorbeelden slaan de geconfigureerde diagrammen op in PPTX‑bestanden.

## **Lettertype‑eigenschappen instellen**

Om de gegevenstabel van een diagram weer te geven, geeft u `true` door aan [setDataTable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chart/#setDataTable-boolean-). Gebruik [getChartDataTable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chart/#getChartDataTable--) om toegang te krijgen tot de tabel en de tekstopmaak te configureren.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.  
1. Voeg een gegroepeerde kolomdiagram toe aan de eerste dia.  
1. Schakel de gegevenstabel van het diagram in.  
1. Schakel vette tekst in met [setFontBold](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseportionformat/#setFontBold-byte-) en geef `20` door aan [setFontHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) voor tekst van 20 punten.  
1. Sla de gewijzigde presentatie op.

Het volgende voorbeeld vereist `test.pptx` in de werkmap met minstens één dia. Het voegt een diagram met standaardgegevens toe op positie (50, 50), met een breedte van 600 punten en een hoogte van 400 punten. Het opgeslagen `output.pptx` bevat het diagram met de ingeschakelde gegevenstabel en de opgegeven lettertype‑instellingen toegepast.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Randen van gegevenstabel aanpassen**

Schakel de tabel in met [IChart.setDataTable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/#setDataTable-boolean-) en krijg er toegang tot via [IChart.getChartDataTable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/#getChartDataTable--). U kunt drie soorten randen onafhankelijk regelen:

- [setBorderHorizontal](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) regelt horizontale celranden.  
- [setBorderVertical](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idatatable/#setBorderVertical-boolean-) regelt verticale celranden.  
- [setBorderOutline](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idatatable/#setBorderOutline-boolean-) regelt de buitenrand van de tabel.

Geef `true` door aan elke methode om de randen weer te geven of `false` om ze te verbergen. Het volgende voorbeeld maakt een gegroepeerde kolomdiagram met standaardgegevens, toont horizontale randen en de buitenrand, en verbergt verticale randen. Het vereist geen invoerbestand. De positie en grootte van het diagram worden opgegeven in punten.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De onderstaande vergelijking gebruikt dezelfde diagramgegevens en legenda‑sleutelinstelling in alle vier gevallen. Beginnend met alle randen ingeschakeld, schakelt elke resterende variant slechts één randinstelling uit. De variant linksonder komt overeen met de randinstellingen in het voorbeeld.

![Diagram‑gegevenstabellen met alle randen ingeschakeld, geen horizontale randen, geen verticale randen en geen buitenrand](data-table-borders.png)

## **Legenda‑sleutels weergeven of verbergen**

Legenda‑sleutels zijn kleine gekleurde tekens naast de serienaam in de gegevenstabel. Ze helpen de lezer elke tabelrij aan een diagramserie te koppelen. Geef `true` door aan [setShowLegendKey](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) om deze tekens weer te geven of `false` om ze te verbergen.

De afzonderlijke legenda van het diagram wordt geregeld door [IChart.setLegend](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/#setLegend-boolean-). Deze instellingen zijn onafhankelijk: het verbergen van de afzonderlijke legenda verbergt de sleutels in de gegevenstabel niet, en het verbergen van de sleutels in de tabel verbergt de afzonderlijke legenda niet.

Het volgende voorbeeld maakt een diagram met standaardgegevens, schakelt de gegevenstabel in en toont legenda‑sleutels erin terwijl de afzonderlijke legenda wordt verborgen. Alle tabelranden zijn expliciet ingeschakeld. Er is geen invoerpresentatie vereist. Om alleen de sleutels in de tabel te verbergen, geeft u `false` door aan [setShowLegendKey](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De onderstaande vergelijking toont dezelfde tabel met legenda‑sleutels ingeschakeld en uitgeschakeld. Alle randen blijven ingeschakeld en de afzonderlijke diagramlegenda is in beide gevallen verborgen.

![Diagram‑gegevenstabellen met legenda‑sleutels links getoond en rechts verborgen](data-table-legend-keys.png)

## **FAQ**

**Kan ik legenda‑sleutels weergeven in de gegevenstabel van een diagram?**

Ja. Geef `true` door aan [setShowLegendKey](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) om legenda‑sleutels weer te geven of `false` om ze te verbergen.

**Blijft de gegevenstabel behouden bij het exporteren van de presentatie naar PDF, HTML of afbeeldingen?**

Ja. Aspose.Slides rendert het diagram en de weergegeven gegevenstabel als onderdeel van de dia bij het exporteren naar [PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/nl/androidjava/convert-powerpoint-to-html/), of [afbeeldingen](/slides/nl/androidjava/convert-powerpoint-to-png/).

**Kan ik werken met gegevenstabellen in diagrammen die uit een sjabloon zijn geladen?**

Ja. Voor een diagram dat uit een bestaande presentatie of sjabloon is geladen, gebruikt u [hasDataTable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chart/#hasDataTable--) en [setDataTable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chart/#setDataTable-boolean--) om te controleren of de gegevenstabel wordt weergegeven of om dit te wijzigen.

**Hoe kan ik diagrammen vinden waarvan de gegevenstabel is ingeschakeld?**

Loop door de vormen op elke dia, identificeer de diagrammen en roep hun [hasDataTable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chart/#hasDataTable--) methode aan. Een waarde van `true` geeft aan dat de gegevenstabel is ingeschakeld.