---
title: Grafiekdatatabellen aanpassen in presentaties met JavaScript
linktitle: Datatabel
type: docs
url: /nl/nodejs-java/chart-data-table/
keywords:
- grafiekdata
- datatabel
- lettertype-eigenschappen
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Pas lettertypen, randen en legende‑sleutels van grafiekdatatabellen aan in PowerPoint‑presentaties met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Aspose.Slides for Node.js via Java stelt u in staat om een datatabel van een grafiek weer te geven en de tekstopmaak, de randen en de legende‑sleutels aan te passen. Dit artikel legt uit hoe u de tabel inschakelt, de tekst opmaakt, elk type rand regelt en legende‑sleutels toont of verbergt. De voorbeelden slaan de geconfigureerde grafieken op in PPTX‑bestanden.

## **Lettertype‑eigenschappen instellen**

Om een datatabel van een grafiek weer te geven, geeft u `true` door aan [setDataTable](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/setdatatable/). Gebruik [getChartDataTable](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/getchartdatatable/) om toegang te krijgen tot de tabel en de tekstopmaak te configureren.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.  
1. Voeg een gegroepeerde kolomgrafiek toe aan de eerste dia.  
1. Schakel de datatabel van de grafiek in.  
1. Schakel vette tekst in met [setFontBold](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setfontbold) en geef `20` door aan [setFontHeight](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setfontheight) voor tekst van 20 punten.  
1. Sla de gewijzigde presentatie op.

Het volgende voorbeeld vereist `input.pptx` in de werkmap met ten minste één dia. Het voegt een grafiek met standaarddata toe op positie (50, 50), met een breedte van 600 punten en een hoogte van 400 punten. Het opgeslagen `output.pptx` bevat de grafiek met de ingeschakelde datatabel en de opgegeven lettertype‑instellingen toegepast.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Datatabelranden aanpassen**

Schakel de tabel in met [Chart.setDataTable](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/setdatatable/) en krijg er toegang tot via [Chart.getChartDataTable](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/getchartdatatable/). U kunt drie soorten randen onafhankelijk regelen:

- [setBorderHorizontal](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datatable/setborderhorizontal/) regelt de horizontale celranden.  
- [setBorderVertical](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datatable/setbordervertical/) regelt de verticale celranden.  
- [setBorderOutline](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datatable/setborderoutline/) regelt de buitenrand van de tabel.

Geef `true` door aan elke methode om de bijbehorende randen weer te geven of `false` om ze te verbergen. Het volgende voorbeeld maakt een gegroepeerde kolomgrafiek met standaarddata, toont horizontale randen en de buitenrand, en verbergt verticale randen. Er is geen invoerbestand nodig. De positie en afmetingen van de grafiek worden opgegeven in punten.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De vergelijking hieronder maakt gebruik van dezelfde grafiekdata en legende‑sleutelinstelling in alle vier de gevallen. Beginnend met alle randen ingeschakeld, schakelt elke resterende variant precies één rand uit. De variant linksonder komt overeen met de randinstellingen in het voorbeeld.

![Grafiektabellen met alle randen ingeschakeld, geen horizontale randen, geen verticale randen en geen buitenrand](data-table-borders.png)

## **Legende‑sleutels tonen of verbergen**

Legende‑sleutels zijn kleine gekleurde markers naast de serienaam in de datatabel. Ze helpen de lezer elke tabelrij aan een grafiekserie te koppelen. Geef `true` door aan [setShowLegendKey](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datatable/setshowlegendkey/) om deze markers weer te geven of `false` om ze te verbergen.

De aparte legende van de grafiek wordt gecontroleerd door [Chart.setLegend](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/setlegend/). Deze instellingen zijn onafhankelijk: het verbergen van de aparte legende verbergt de sleutels in de datatabel niet, en het verbergen van de tabel‑sleutels verbergt de aparte legende niet.

Het volgende voorbeeld maakt een grafiek met standaarddata, schakelt de datatabel in en toont legende‑sleutels daarin terwijl de aparte legende wordt verborgen. Alle tabelranden zijn expliciet ingeschakeld. Er is geen invoerpresentatie vereist. Om alleen de sleutels van de tabel te verbergen, geeft u `false` door aan [setShowLegendKey](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datatable/setshowlegendkey/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De vergelijking hieronder toont dezelfde tabel met legende‑sleutels ingeschakeld en uitgeschakeld. Alle randen blijven ingeschakeld en de aparte grafieklegende is in beide gevallen verborgen.

![Grafiektabellen met legende‑sleutels links getoond en rechts verborgen](data-table-legend-keys.png)

## **Veelgestelde vragen**

**Kan ik legende‑sleutels in de datatabel van een grafiek weergeven?**

Ja. Geef `true` door aan [setShowLegendKey](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datatable/setshowlegendkey/) om legende‑sleutels weer te geven of `false` om ze te verbergen.

**Blijft de datatabel behouden bij het exporteren van de presentatie naar PDF, HTML of afbeeldingen?**

Ja. Aspose.Slides rendert de grafiek en de weergegeven datatabel als onderdeel van de dia bij het exporteren naar [PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/nl/nodejs-java/convert-powerpoint-to-html/), of [images](/slides/nl/nodejs-java/convert-powerpoint-to-png/).

**Kan ik werken met datatabellen in grafieken die uit een sjabloon zijn geladen?**

Ja. Voor een grafiek die uit een bestaande presentatie of sjabloon is geladen, gebruikt u [hasDataTable](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/hasdatatable/) en [setDataTable](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/setdatatable/) om te controleren of de datatabel wordt weergegeven of om dit aan te passen.

**Hoe kan ik grafieken vinden die een ingeschakelde datatabel hebben?**

Itereer door de vormen op elke dia, identificeer de grafieken en roep hun [hasDataTable](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/hasdatatable/)‑methode aan. Een waarde van `true` geeft aan dat de datatabel is ingeschakeld.