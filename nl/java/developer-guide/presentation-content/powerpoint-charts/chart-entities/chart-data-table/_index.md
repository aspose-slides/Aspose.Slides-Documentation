---
title: "Grafiekgegevens‑tabel aanpassen in presentaties met Java"
linktitle: "Gegevens‑tabel"
type: docs
url: /nl/java/chart-data-table/
keywords:
- grafiekgegevens
- gegevenstabel
- lettertype‑eigenschappen
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Pas lettertype‑eigenschappen, randen en legendasleutels van een grafiekgegevens‑tabel aan in PowerPoint‑presentaties met Aspose.Slides voor Java."
---
## **Overzicht**

Aspose.Slides for Java laat u een gegevens­tabel van een diagram weergeven en de tekstopmaak, randen en legendasleutels aanpassen. Dit artikel legt uit hoe u de tabel inschakelt, de tekst opmaakt, elk type rand bestuurt en legendasleutels toont of verbergt. De voorbeelden slaan de geconfigureerde diagrammen op in PPTX‑bestanden.

## **Lettertype‑eigenschappen instellen**

Om een gegevens­tabel van een diagram weer te geven, geeft u `true` door aan [setDataTable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chart/#setDataTable-boolean-). Gebruik [getChartDataTable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chart/#getChartDataTable--) om toegang te krijgen tot de tabel en de tekstopmaak te configureren.

1. Laad de presentatie via de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
1. Voeg een gegroepeerde kolomdiagram toe aan de eerste dia.
1. Schakel de gegevens­tabel van het diagram in.
1. Schakel vetgedrukte tekst in met [setFontBold](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) en geef `20` door aan [setFontHeight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) voor 20‑punt tekst.
1. Sla de gewijzigde presentatie op.

Het volgende voorbeeld vereist `test.pptx` in de werkmap met ten minste één dia. Het voegt een diagram met standaardgegevens toe op positie (50, 50), met een breedte van 600 punten en een hoogte van 400 punten. Het opgeslagen `output.pptx` bevat het diagram met de gegevens­tabel ingeschakeld en de opgegeven lettertype‑instellingen toegepast.

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

## **Randen van gegevens­tabel aanpassen**

Schakel de tabel in met [IChart.setDataTable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichart/#setDataTable-boolean-) en krijg er toegang tot via [IChart.getChartDataTable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichart/#getChartDataTable--). U kunt drie soorten randen onafhankelijk regelen:

- [setBorderHorizontal](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) regelt de horizontale celranden.
- [setBorderVertical](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) regelt de verticale celranden.
- [setBorderOutline](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) regelt de buitenste rand van de tabel.

Geef `true` door aan elke methode om de randen weer te geven of `false` om ze te verbergen. Het onderstaande voorbeeld maakt een gegroepeerde kolomdiagram met standaardgegevens, toont horizontale randen en de buitenste rand, en verbergt de verticale randen. Er is geen invoerbestand nodig. De positie en grootte van het diagram worden opgegeven in punten.

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

De vergelijking hieronder gebruikt dezelfde diagramgegevens en legendasleutelinstelling in alle vier de gevallen. Beginnend met alle randen ingeschakeld, schakelt elke resterende variant precies één randinstelling uit. De linksonder‑variant komt overeen met de randinstellingen in het voorbeeld.

![Diagramgegevens‑tabellen met alle randen ingeschakeld, geen horizontale randen, geen verticale randen, en geen buitenste rand](data-table-borders.png)

## **Legenda‑sleutels tonen of verbergen**

Legenda‑sleutels zijn kleine gekleurde markeringen naast de serienaam in de gegevens­tabel. Ze helpen lezers elke tabelrij aan een diagramserie te koppelen. Geef `true` door aan [setShowLegendKey](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) om deze markeringen te tonen of `false` om ze te verbergen.

De afzonderlijke legenda van het diagram wordt geregeld door [IChart.setLegend](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichart/#setLegend-boolean-). Deze instellingen zijn onafhankelijk: het verbergen van de afzonderlijke legenda verbergt niet de sleutels in de gegevens­tabel, en het verbergen van de sleutels in de tabel verbergt niet de afzonderlijke legenda.

Het onderstaande voorbeeld maakt een diagram met standaardgegevens, schakelt de gegevens­tabel in en toont legendasleutels daarin terwijl de afzonderlijke legenda wordt verborgen. Alle tabelranden worden expliciet ingeschakeld. Er is geen invoerpresentatie nodig. Om alleen de sleutels in de tabel te verbergen, geef `false` door aan [setShowLegendKey](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

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

De vergelijking hieronder toont dezelfde tabel met legendasleutels ingeschakeld en uitgeschakeld. Alle randen blijven ingeschakeld, en de afzonderlijke diagramlegenda is in beide gevallen verborgen.

![Diagramgegevens‑tabellen met legendasleutels links getoond en rechts verborgen](data-table-legend-keys.png)

## **FAQ**

**Kan ik legendasleutels weergeven in de gegevens­tabel van een diagram?**

Ja. Geef `true` door aan [setShowLegendKey](https://reference.aspose.com/slides/nl/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) om legendasleutels weer te geven of `false` om ze te verbergen.

**Wordt de gegevens­tabel behouden bij het exporteren van de presentatie naar PDF, HTML of afbeeldingen?**

Ja. Aspose.Slides rendert het diagram en de weergegeven gegevens­tabel als onderdeel van de dia bij het exporteren naar [PDF](/slides/nl/java/convert-powerpoint-to-pdf/), [HTML](/slides/nl/java/convert-powerpoint-to-html/), of [afbeeldingen](/slides/nl/java/convert-powerpoint-to-png/).

**Kan ik werken met gegevens‑tabellen in diagrammen die zijn geladen uit een sjabloon?**

Ja. Voor een diagram dat is geladen uit een bestaande presentatie of sjabloon, gebruik [hasDataTable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chart/#hasDataTable--) en [setDataTable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chart/#setDataTable-boolean-) om te controleren of de gegevens‑tabel wordt weergegeven of om deze te wijzigen.

**Hoe kan ik diagrammen vinden die een ingeschakelde gegevens‑tabel hebben?**

Itereer over de vormen op elke dia, identificeer de diagrammen en roep hun [hasDataTable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chart/#hasDataTable--)‑methode aan. Een waarde van `true` geeft aan dat de gegevens‑tabel is ingeschakeld.