---
title: Grafiekgegevens tabellen aanpassen in presentaties met PHP
linktitle: Gegevenstabel
type: docs
url: /nl/php-java/chart-data-table/
keywords:
- grafiekgegevens
- gegevenstabel
- lettertype-eigenschappen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Pas lettertype-eigenschappen, randen en legende-sleutels van grafiekgegevens-tabellen aan in PowerPoint-presentaties met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Aspose.Slides for PHP via Java stelt u in staat om de gegevens­tabel van een grafiek weer te geven en de tekstopmaak, randen en legende‑sleutels aan te passen. In dit artikel wordt uitgelegd hoe u de tabel inschakelt, de tekst opmaakt, elke soort rand bestuurt en legende‑sleutels laat zien of verbergt. De voorbeelden slaan de geconfigureerde grafieken op in PPTX‑bestanden.

## **Lettertype‑eigenschappen instellen**

Om een gegevens­tabel van een grafiek weer te geven, geeft u `true` door aan [setDataTable](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/setdatatable/). Gebruik [getChartDataTable](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/getchartdatatable/) om toegang te krijgen tot de tabel en de tekstopmaak te configureren.

1. Laad de presentatie met de class [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/).
1. Voeg een gegroepeerde kolomgrafiek toe aan de eerste dia.
1. Schakel de gegevens­tabel van de grafiek in.
1. Schakel vet tekst in met [setFontBold](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setFontBold) en geef `20` door aan [setFontHeight](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setFontHeight) voor tekst van 20 punten.
1. Sla de gewijzigde presentatie op.

Het volgende voorbeeld vereist `test.pptx` in de werkmap met ten minste één dia. Het voegt een grafiek met standaardgegevens toe op positie (50, 50), met een breedte van 600 punten en een hoogte van 400 punten. Het opgeslagen `output.pptx` bevat de grafiek met de gegevens­tabel ingeschakeld en de opgegeven lettertype‑instellingen toegepast.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Randen van de gegevens­tabel aanpassen**

Schakel de tabel in met [Chart::setDataTable](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/setdatatable/) en krijg er toegang tot via [Chart::getChartDataTable](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/getchartdatatable/). U kunt drie soorten randen onafhankelijk regelen:

- [setBorderHorizontal](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datatable/setborderhorizontal/) regelt de horizontale celranden.
- [setBorderVertical](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datatable/setbordervertical/) regelt de verticale celranden.
- [setBorderOutline](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datatable/setborderoutline/) regelt de buitenrand van de tabel.

Geef `true` door aan elke methode om de betreffende randen weer te geven of `false` om ze te verbergen. Het volgende voorbeeld maakt een gegroepeerde kolomgrafiek met standaardgegevens, toont de horizontale randen en de buitenrand, en verbergt de verticale randen. Er is geen invoerbestand nodig. De positie en grootte van de grafiek worden in punten opgegeven.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De onderstaande vergelijking gebruikt dezelfde grafiekgegevens en dezelfde instelling voor legende‑sleutel in alle vier de gevallen. Beginnend met alle randen ingeschakeld, schakelt elke resterende variant precies één rand uit. De variant links‑onder komt overeen met de randinstellingen in het voorbeeld.

![Chart data tables with all borders enabled, no horizontal borders, no vertical borders, and no outer border](data-table-borders.png)

## **Legende‑sleutels tonen of verbergen**

Legende‑sleutels zijn kleine gekleurde markeringen naast de serienaam in de gegevens­tabel. Ze helpen de lezer elke tabelrij te koppelen aan een grafiekserie. Geef `true` door aan [setShowLegendKey](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datatable/setshowlegendkey/) om deze markeringen weer te geven of `false` om ze te verbergen.

De afzonderlijke legende van de grafiek wordt beheerd via [Chart::setLegend](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/setlegend/). Deze instellingen zijn onafhankelijk: het verbergen van de afzonderlijke legende verbergt de sleutels in de gegevens­tabel niet, en het verbergen van de sleutels in de tabel verbergt de afzonderlijke legende niet.

Het volgende voorbeeld maakt een grafiek met standaardgegevens, schakelt de gegevens­tabel in en toont legende‑sleutels erin terwijl de afzonderlijke legende verborgen blijft. Alle tabelranden worden expliciet ingeschakeld. Er is geen invoerpresentatie vereist. Om alleen de sleutels van de tabel te verbergen, geeft u `false` door aan [setShowLegendKey](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datatable/setshowlegendkey/).

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De onderstaande vergelijking toont dezelfde tabel met legende‑sleutels ingeschakeld en uitgeschakeld. Alle randen blijven ingeschakeld en de afzonderlijke grafieklegende is in beide gevallen verborgen.

![Chart data tables with legend keys shown on the left and hidden on the right](data-table-legend-keys.png)

## **FAQ**

**Kan ik legende‑sleutels tonen in de gegevens­tabel van een grafiek?**

Ja. Geef `true` door aan [setShowLegendKey](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datatable/setshowlegendkey/) om legende‑sleutels weer te geven of `false` om ze te verbergen.

**Blijft de gegevens­tabel behouden bij het exporteren van de presentatie naar PDF, HTML of afbeeldingen?**

Ja. Aspose.Slides rendert de grafiek en de weergegeven gegevens­tabel als onderdeel van de dia bij exporteren naar [PDF](/slides/nl/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/nl/php-java/convert-powerpoint-to-html/), of [images](/slides/nl/php-java/convert-powerpoint-to-png/).

**Kan ik werken met gegevens­tabellen in grafieken die uit een sjabloon zijn geladen?**

Ja. Voor een grafiek die uit een bestaande presentatie of sjabloon is geladen, gebruikt u [hasDataTable](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/hasdatatable/) en [setDataTable](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/setdatatable/) om te controleren of de gegevens­tabel wordt weergegeven of om dit te wijzigen.

**Hoe vind ik grafieken die een ingeschakelde gegevens­tabel hebben?**

Itereer door de shapes op elke dia, identificeer de grafieken en roep hun [hasDataTable](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/hasdatatable/) methode aan. Een waarde van `true` geeft aan dat de gegevens­tabel is ingeschakeld.