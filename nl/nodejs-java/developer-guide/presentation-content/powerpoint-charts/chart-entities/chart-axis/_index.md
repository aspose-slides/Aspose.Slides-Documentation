---
title: Grafiekassen aanpassen in presentaties met JavaScript
linktitle: Grafiekas
type: docs
url: /nl/nodejs-java/chart-axis/
keywords:
- grafiekas
- verticale as
- horizontale as
- as aanpassen
- as manipuleren
- as beheren
- as-eigenschappen
- maximale waarde
- minimale waarde
- aslijn
- datumformaat
- as-titel
- aspositie
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek hoe u JavaScript met Aspose.Slides voor Node.js via Java kunt gebruiken om grafiekassen aan te passen in PowerPoint-presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u assen van diagrammen kunt aanpassen met Aspose.Slides voor Node.js via Java. Het behandelt berekende aswaarden, het wisselen van diagramrijen en -kolommen, aszichtbaarheid, intervallen voor categorielabels en tik-markeringen, datumcategorieën en -opmaak, rotatie van titels, positionering van assen, weergave‑eenheden en logaritmische schaal.

## **De maximale waarden op de verticale as van diagrammen ophalen**

Maak een [Presentatie](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) en voeg een gebiedsdiagram toe met standaardgegevens. Roep [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) aan voordat u berekende aswaarden leest zodat de diagramlay‑out up‑to‑date is.

Lees [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) en [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) voor de aslimieten, en [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) en [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) voor de tik‑intervallen. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) en [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) geven tijd‑eenheidschalen, die relevant zijn voor datumassen. Het voorbeeld slaat deze waarden op in lokale variabelen en slaat het diagram op.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gegevens tussen assen wisselen**

Gebruik [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) om de rollen van reeksen en categorieën in diagramgegevens om te wisselen. Elke voormalige categorie wordt een reeks, en elke voormalige reeks wordt een categorie. Dit verandert de manier waarop de gegevens worden gegroepeerd; het wisselt niet de horizontale en verticale as. Het voorbeeld gebruikt [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) om de standaardgegevens te koppelen aan `Sheet1!A1:D5`, inclusief de koprij en categoriekolom, vóór het wisselen van rijen en kolommen. Het slaat een diagram op met vier reeksen en drie categorieën.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **De verticale as voor lijndiagrammen uitschakelen**

Roep [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) met `false` aan op de verticale as om deze te verbergen. Het voorbeeld maakt een lijndiagram met standaardgegevens en slaat het op met de verticale as verborgen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **De horizontale as voor lijndiagrammen uitschakelen**

Roep [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) met `false` aan op de horizontale as om deze te verbergen. Het voorbeeld maakt een lijndiagram met standaardgegevens en slaat het op met de horizontale as verborgen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een categorias aan passen**

Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) om een datum‑ of tekst‑categorias te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een diagram als het eerste vorm op de eerste dia en categoriecellen die numerieke Excel‑datumnummers bevatten. Het wijzigt de horizontale as naar een datumas. Het aanroepen van [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) met `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) met `1`, en [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) met `TimeUnitType.Months` plaatst hoofd‑tikken op één‑maand‑intervallen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Intervallen voor categorielabels van de as regelen**

Wanneer een diagram veel categorieën heeft, kunt u het aantal zichtbare aslabels verminderen zonder categorieën of datapunten te verwijderen. Roep [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) met `false` aan en geef vervolgens het gewenste categorie‑interval door aan [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Voor tekstcategorieën in hun normale volgorde begint tellen bij de eerste categorie:

| Interval | Labels weergegeven in het voorbeeld |
| --- | --- |
| `1` | Categorie 1, Categorie 2, Categorie 3, … Categorie 24 |
| `2` | Categorie 1, Categorie 3, Categorie 5, … Categorie 23 |
| `3` | Categorie 1, Categorie 4, Categorie 7, … Categorie 22 |

Een interval van `3` toont elke derde label en laat twee labels verborgen tussen de getoonde labels. Het verwijdert de bijbehorende kolommen niet. Automatische spacing kiest een interval op basis van de beschikbare ruimte; het toont niet noodzakelijk elke label.

Tik‑markeringen hebben afzonderlijke instellingen. Roep [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) met `false` aan en gebruik [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) om hun interval in te stellen. Bijvoorbeeld, `1` houdt een tik‑markering bij elk categorie‑interval terwijl labels alleen elke derde categorie verschijnen. Gebruik [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) met een zichtbaar stijl zodat u het resultaat kunt zien. Het opnieuw instellen van een automatische‑spacing‑setter met `true` laat het diagram dat interval weer kiezen.

Het volgende zelfstandige voorbeeld maakt 24 categorieën en één reeks, en slaat vervolgens drie dia's op in `CategoryAxisIntervals.pptx`: automatische spacing, handmatige label‑spacing met onafhankelijke tik‑markeringen, en herstelde automatische spacing. De twee kopieën behouden de oorspronkelijke diagramgegevens. Er is geen invoerpresentatie nodig. Horizontale labeltekst maakt het verschil in dichtheid gemakkelijk te zien.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Dia 2: toon elke derde label, maar behoud een tikmarkering voor elke categorie.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Dia 3: laat het diagram beide intervallen opnieuw kiezen.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatische spacing (dia 1):** In deze weergave wordt elke tweede categorielabel weergegeven en wordt op twee regels afgebroken. Het automatische resultaat kan variëren met diagramgrootte, lettertypen en de renderer.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Handmatige spacing (dia 2):** Elke derde label wordt op één regel weergegeven, terwijl tik‑markeringen behouden blijven bij elk categorie‑interval. Alle 24 kolommen, inclusief die zonder labels, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt de automatische weergave zoals hierboven.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Kies de juiste as en het juiste interval**

Gebruik dit categorie‑aantal‑interval voor een tekst‑categorias, zoals de categorias van een kolom‑, lijn‑, gebieds‑ of staafdiagram. In een kolomdiagram is het de horizontale as. In een horizontaal staafdiagram is de categorias verticaal, dus pas deze instellingen toe op de as die wordt geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Tik‑markering‑spacing geldt ook voor een reeks‑as in diagrammen die er één hebben.

Gebruik geen categorielabel‑spacing om de numerieke schaal van een waardenas in te stellen. Op een waardenas specificeert [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) een verschil in waarden: bijvoorbeeld, een hoofd‑eenheid van `10` produceert tikken op 0, 10, 20, enz. wanneer de as bij nul start. Een categorielabel‑interval van `3` telt in plaats daarvan categorie‑posities, ongeacht hun gegevenswaarden. Spreidings‑ en bubbel‑diagrammen gebruiken waardennassen in plaats van een tekst‑categorias. Voor een datumas gebruikt u tijd‑gebaseerde hoofd‑eenheden en schalen zoals beschreven in [Een categorias aanpassen](#een-categorias-aanpassen).

## **Het datumformaat voor categoriaswaarden instellen**

Het voorbeeld vervangt de standaard diagramgegevens door vier jaarlijkse waarden. Datums worden opgeslagen als OLE‑Automation‑serienummers in het eerste werkblad (index `0`), berekend als het aantal dagen sinds 30 december 1899 voor deze datums. De JavaScript‑berekening gebruikt UTC‑timestamps en deelt het verschil door 86 400 000 milliseconden per dag. Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) met `CategoryAxisType.Date`, roep [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) aan met `false`, en geef `yyyy` door aan [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) zodat de categorielabels viercijferige jaartallen tonen, onafhankelijk van de celopmaak.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een rotatie‑hoek instellen voor een diagramas‑titel**

Roep [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) met `true` aan op de verticale as, geef de titeltekst op, en gebruik [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) om de titel te roteren. De hoek wordt gemeten in graden; dit voorbeeld slaat een kolomdiagram op met zijn waardenas‑titel geroteerd met 90 graden.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **De aspositie op een categorias of waardenas instellen**

Gebruik [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) om te regelen of de waardenas de categorias kruist tussen categorieën of op categorietik‑markeringen. Deze instelling geldt voor categoriasen. Het voorbeeld stelt het in op `true` voor de horizontale categorias van een kolomdiagram en slaat het resultaat op.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **De weergave‑eenheid op een diagram‑waardenas instellen**

Gebruik [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) om de labels op een waardenas te schalen zonder de onderliggende gegevens te wijzigen. Met [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) ingesteld op `Millions` wordt een waarde van 60 000 000 weergegeven als 60. Het voorbeeld maakt een kolomdiagram en past de miljoen‑weergave‑eenheid toe op de verticale as.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een logaritmische waardenas configureren**

Een logaritmische waardenas is nuttig wanneer positieve waarden meerdere grootterechterdelerorden beslaan. Bijvoorbeeld, een dienst kan 10, 100, 1 000, 10 000 en 100 000 verzoeken ontvangen over vijf perioden. Op een lineaire schaal verschijnen de kleinere waarden dicht bij nul. Een logaritmische schaal maakt hun relatieve groei makkelijker te vergelijken: gelijke afstanden vertegenwoordigen gelijke verhoudingen in plaats van gelijke verschillen.

Roep [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) met `true` aan op de waardenas en gebruik [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) om de basis te kiezen. Dit verandert hoe de bestaande waarden worden weergegeven; het wijzigt de gegevens niet en voegt geen logaritmische trendlijn toe. Een trendlijn is een apart kenmerk dat een aangepaste relatie in de gegevens vertegenwoordigt.

### **De waardenas en de basis kiezen**

Voor een lijn‑ of kolomdiagram wordt de waardenas geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Voor een horizontaal staafdiagram wordt deze geretourneerd door [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Spreidings‑ en bubbel‑diagrammen hebben twee waardennassen, dus kies de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas geen logaritmische schaal toe op een categorias.

De standaard logaritmische basis is `10`. Voor PPTX‑diagrammen mag de basis variëren van `2` tot en met `1000`, inclusief; fractionele bases zoals `2.5` worden ook ondersteund. Met basis `10` zijn opeenvolgende machten zoals 10, 100, 1 000 en 10 000 gelijkmatig verdeeld.

### **Lineaire en logaritmische schaal vergelijken**

Het volgende zelfstandige voorbeeld maakt een lijndiagram met de vijf verzoektelling‑waarden op de eerste dia, kloont die dia vervolgens en schakelt een logaritmische waardenas met basis 10 in op de tweede. Beide dia's behouden dezelfde gegevens.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Houd de eerste dia lineair en wijzig alleen de schaal van de waardenas van de kopie.
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Lineaire schaal (dia 1):** Gelijke verticale afstanden vertegenwoordigen gelijke verschillen in verzoektelling. De grootste waarde domineert het diagram, waardoor de kleinere waarden moeilijk te onderscheiden zijn.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Logaritmische schaal (dia 2):** Gelijke verticale afstanden vertegenwoordigen gelijke verhoudingen. Elke periode heeft tien keer zoveel verzoeken als de vorige, waardoor de punten een rechte stijgende lijn vormen op de basis‑10 schaal. De aslabels tonen nog steeds de oorspronkelijke verzoektelling.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Nul‑ en negatieve waarden behandelen**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de gegevens voordat u deze inschakelt. Als nul‑ of negatieve waarden betekenis hebben, behoud dan een lineaire schaal of toon ze apart. Als het weglaten van die waarden passend is voor de analyse, verklaar dan de weglating. Vervang ze niet stilletjes door kleine positieve getallen, want dat verandert de betekenis van de gegevens. Elke handmatig geconfigureerde minimum‑ of maximumwaarde voor een logaritmische as moet eveneens positief zijn.

## **FAQ**

**Hoe stel ik de waarde in waar de ene as de andere kruist (as‑kruising)?**

Gebruik [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) om het kruisingsgedrag te selecteren. Om een numerieke kruisingwaarde op te geven, gebruik [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Deze instellingen laten u de askruising naar een geschikt basislijn verplaatsen.

**Hoe kan ik tik‑labels positioneren ten opzichte van de as?**

Roep [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) aan met een van de waarden uit [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` of `None`. Om de tik‑markeringen zelf te regelen, gebruik [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) of [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); deze staan los van de labelpositionering.