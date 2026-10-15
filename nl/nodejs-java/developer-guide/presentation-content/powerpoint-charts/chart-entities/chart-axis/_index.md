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
- as eigenschappen
- maximale waarde
- minimale waarde
- aslijn
- datumnotatie
- as titel
- aspositie
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek hoe u JavaScript met Aspose.Slides voor Node.js via Java kunt gebruiken om grafiekassen aan te passen in PowerPoint-presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u de assen van diagrammen kunt aanpassen met Aspose.Slides for Node.js via Java. Het behandelt berekende aswaarden, het verwisselen van rijen en kolommen in diagrammen, aszichtbaarheid, categorie‑label‑ en tick‑mark‑intervallen, datumcategorieën en opmaak, titelrotatie, aspositionering, weergave‑eenheden en logaritmische schaal.

## **De maximale waarden op de verticale as van diagrammen ophalen**

Maak een [Presentatie](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) en voeg een gebiedsdiagram toe met standaardgegevens. Roep [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) aan voordat u berekende aswaarden leest, zodat de diagramlay-out up-to-date is.

Lees [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) en [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) voor de aslimieten, en [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) en [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) voor de tick‑intervallen. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) en [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) bieden tijd‑eenheid‑schalen, die relevant zijn voor datumassen. Het voorbeeld slaat deze waarden op in lokale variabelen en slaat het diagram op.

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

## **Gegevens tussen assen verwisselen**

Gebruik [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) om de rollen van reeksen en categorieën in diagramgegevens uit te wisselen. Elke voormalige categorie wordt een reeks, en elke voormalige reeks wordt een categorie. Dit wijzigt hoe de gegevens worden gegroepeerd; het verwisselt niet de horizontale en verticale assen. Het voorbeeld gebruikt [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) om de standaardgegevens te binden aan `Sheet1!A1:D5`, inclusief de koprij en categorie‑kolom, vóór het verwisselen van rijen en kolommen. Het slaat een diagram op met vier reeksen en drie categorieën.

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

## **Plotvolgorde van een as omkeren**

Gebruik [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) om een categorie‑ of waardeas om te keren. Bijvoorbeeld kan een horizontale staafdiagram projectfasen van boven naar beneden tonen in dezelfde volgorde als het werkblad: Planning, Ontwikkeling, Testen. Het omkeren van een as verandert de plotrichting; het sorteert of herschikt de werkbladgegevens niet. Ter vergelijking verwisselt [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) de rollen van reeksen en categorieën.

Het volgende voorbeeld maakt een horizontale staafdiagram met drie fasen en één reeks. Het slaat een presentatie op met drie dia's: normale volgorde, omgekeerde categorieën en omgekeerde waarden. Elke kopie gebruikt dezelfde gegevensset, en slechts één as wordt per kopie omgekeerd.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Dia 2: toon de eerste categorie bovenaan.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Bewaar de horizontale waardeas onderaan.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // Dia 3: keer alleen de horizontale numerieke schaal om.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het omkeren van een as kan ook de loodrechte as naar de tegenoverliggende kant van de plot verplaatsen. [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) bepaalt waar de andere as de geconfigureerde as kruist. In dia 2 houdt aanroep met `aspose.slides.CrossesType.Maximum` op de omgekeerde categorie‑as de horizontale waarde‑as onderaan. Voor een specifiek kruispunt gebruikt u [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Controleer de kruissinstellingen bij het wijzigen van de richting, vooral als het diagram al een aangepast kruispunt heeft. Roep `setPlotOrderReversed` met `false` aan om de normale plotrichting te herstellen; de kruissinstellingen zijn apart.

| Normale volgorde (dia 1) | Omgekeerde categorieën (dia 2) | Omgekeerde waarden (dia 3) |
| --- | --- | --- |
| ![Horizontale staafdiagram met normale categorie‑ en waarde‑as volgorde](axis-order-normal.png) | ![Horizontale staafdiagram met categorieën weergegeven van boven naar beneden](axis-order-categories-reversed.png) | ![Horizontale staafdiagram met een omgekeerde waarde‑as en nul aan de rechterkant](axis-order-values-reversed.png) |
| Categorieën lopen van onder naar boven; waarden nemen toe van links naar rechts. | Planning, Ontwikkeling en Testen lopen van boven naar beneden. Waarden en werkbladrijvolgorde blijven ongewijzigd. | Categorieën behouden hun normale volgorde; waarden nemen toe van rechts naar links. De categorie‑as kruist op nul aan de rechterkant. |

## **Verticale as uitschakelen voor lijndiagrammen**

Roep [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) met `false` op de verticale as aan om deze te verbergen. Het voorbeeld maakt een lijndiagram met standaardgegevens en slaat het op met de verticale as verborgen.

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

## **Horizontale as uitschakelen voor lijndiagrammen**

Roep [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) met `false` op de horizontale as aan om deze te verbergen. Het voorbeeld maakt een lijndiagram met standaardgegevens en slaat het op met de horizontale as verborgen.

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

## **Een categorieas wijzigen**

Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) om een datum‑ of tekstcategorie‑as te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een diagram als eerste vorm op de eerste dia en categorie‑cellen met numerieke Excel‑datumnummers. Het wijzigt de horizontale as naar een datum‑as. Aanroep van [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) met `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) met `1` en [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) met `TimeUnitType.Months` plaatst grote ticks op één‑maand‑intervallen.

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

## **Intervallen van categorie‑as‑labels beheren**

Wanneer een diagram veel categorieën heeft, kunt u het aantal zichtbare as‑labels verminderen zonder categorieën of datapunten te verwijderen. Roep [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) met `false` aan, en geef vervolgens het gewenste categorie‑interval door aan [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Voor tekstcategorieën in hun normale volgorde begint de telling bij de eerste categorie:

| Interval | Labels die in het voorbeeld worden weergegeven |
| --- | --- |
| `1` | Categorie 1, Categorie 2, Categorie 3, ... Categorie 24 |
| `2` | Categorie 1, Categorie 3, Categorie 5, ... Categorie 23 |
| `3` | Categorie 1, Categorie 4, Categorie 7, ... Categorie 22 |

Een interval van `3` toont elk derde label, waardoor twee labels tussen de weergegeven labels verborgen blijven. Het verwijdert de overeenkomstige kolommen niet. Automatische afstand kiest een interval op basis van de beschikbare ruimte; het toont niet per se elk label.

Tick‑marks hebben aparte besturingen. Roep [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) met `false` aan en gebruik [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) om hun interval in te stellen. Bijvoorbeeld, `1` behoudt een tick‑mark bij elk categorie‑interval terwijl de labels alleen elke derde categorie verschijnen. Gebruik [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) met een zichtbaar stijl zodat u het resultaat kunt zien. Als u één van de automatische‑spacer‑setters opnieuw aanroept met `true`, laat u het diagram dat interval opnieuw kiezen.

Het volgende zelfstandige voorbeeld maakt 24 categorieën en één reeks, en slaat vervolgens drie dia's op in `CategoryAxisIntervals.pptx`: automatische afstand, handmatige labelafstand met onafhankelijke tick‑marks, en herstelde automatische afstand. De twee kopieën behouden de oorspronkelijke diagramgegevens. Er is geen invoer‑presentatie vereist. Horizontale labeltekst maakt het verschil in dichtheid makkelijk zichtbaar.

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

    // Dia 2: toon elk derde label, maar behoud een tick mark voor elke categorie.
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

**Automatische afstand (dia 1):** Bij deze weergave wordt elk tweede categoriabelabel weergegeven en wordt op twee regels afgebroken. Het automatische resultaat kan variëren afhankelijk van diagramgrootte, lettertypen en de renderer.

![Automatische categoriabelabelafstand met alle 24 kolommen zichtbaar](category-axis-automatic.png)

**Handmatige afstand (dia 2):** Elk derde label wordt op één regel weergegeven, terwijl tick‑marks bij elk categorie‑interval blijven. Alle 24 kolommen, inclusief die zonder labels, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt de automatische weergave zoals hierboven.

![Handmatig categoriabelabelinterval van drie met alle 24 kolommen zichtbaar](category-axis-manual.png)

### **Kies de juiste as en interval**

Gebruik dit categorie‑aantal‑interval voor een tekst‑categorie‑as, zoals de categorie‑as van een kolom-, lijn-, gebieds- of staafdiagram. In een kolomdiagram is dit de horizontale as. In een horizontale staafdiagram is de categorie‑as verticaal, dus pas deze instellingen toe op de as die wordt geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Tick‑mark‑afstand geldt ook voor een reeks‑as in diagrammen die er één hebben.

Gebruik geen categoriabelabel‑afstand om de numerieke schaal van een waarde‑as in te stellen. Op een waarde‑as specificeert [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) een verschil in waarden: bijvoorbeeld, een grote eenheid van `10` produceert ticks bij 0, 10, 20, enz., wanneer de as bij nul start. Een categoriabelabel‑interval van `3` telt in plaats daarvan categorie‑posities, ongeacht hun dat waarden. Spreidings‑ en bubbel‑diagrammen gebruiken waarde‑assen in plaats van een tekst‑categorie‑as. Voor een datum‑as gebruikt u tijdgebaseerde grote eenheden en schalen zoals beschreven in [Change a Category Axis](#change-a-category-axis).

## **Datumnotatie instellen voor waarden van de categorie‑as**

Het voorbeeld vervangt de standaard diagramgegevens door vier jaarlijkse waarden. Datums worden opgeslagen als OLE Automation‑serienummers in het eerste werkblad (index `0`), berekend als het aantal dagen sinds 30 december 1899 voor deze datums. De JavaScript‑berekening gebruikt UTC‑tijdstempels en deelt het verschil door 86.400.000 milliseconden per dag. Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) met `CategoryAxisType.Date`, roep [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) met `false` aan, en geef `yyyy` door aan [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) zodat de categoriabelabels viercijferige jaartallen tonen, onafhankelijk van de celopmaak.

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

## **Rotatiehoek instellen voor een diagram‑as‑titel**

Roep [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) met `true` aan op de verticale as, geef de titeltekst op, en gebruik [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) om de titel te roteren. De hoek wordt gemeten in graden; dit voorbeeld slaat een kolomdiagram op met zijn waarde‑as‑titel geroteerd met 90 graden.

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

## **Aspositie instellen op een categorie‑ of waarde‑as**

Gebruik [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) om te bepalen of de waarde‑as de categorie‑as kruist tussen categorieën of op de categorie‑tick‑marks. Deze instelling geldt voor categorie‑assen. Het voorbeeld stelt het in op `true` op de horizontale categorie‑as van een kolomdiagram en slaat het resultaat op.

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

## **Weergave‑eenheid instellen op een diagram‑waarde‑as**

Gebruik [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) om de labels op een waarde‑as te schalen zonder de onderliggende gegevens te wijzigen. Met [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) ingesteld op `Millions` wordt een waarde van 60.000.000 weergegeven als 60. Het voorbeeld maakt een kolomdiagram en past de miljoenen‑weergave‑eenheid toe op de verticale as.

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

## **Logaritmische waarde‑as configureren**

Een logaritmische waarde‑as is nuttig wanneer positieve waarden zich over meerdere orders van grootte uitstrekken. Bijvoorbeeld kan een service 10, 100, 1.000, 10.000 en 100.000 aanvragen ontvangen over vijf perioden. Op een lineaire schaal verschijnen de kleinere waarden dicht bij elkaar rond nul. Een logaritmische schaal maakt hun relatieve groei makkelijker te vergelijken: gelijke afstanden staan voor gelijke verhoudingen in plaats van gelijke verschillen.

Roep [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) met `true` aan op de waarde‑as en gebruik [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) om de basis te kiezen. Dit verandert hoe de bestaande waarden worden weergegeven; het wijzigt de gegevens niet en voegt geen logaritmische trendlijn toe. Een trendlijn vertegenwoordigt een aangepaste relatie in de gegevens en is een aparte functie.

### **Kies de waarde‑as en basis**

Voor een lijn‑ of kolomdiagram wordt de waarde‑as geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Voor een horizontale staafdiagram wordt deze geretourneerd door [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Spreidings‑ en bubbel‑diagrammen hebben twee waarde‑assen, dus kies de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas geen logaritmische schaal toe op een categorie‑as.

De standaard logaritmische basis is `10`. Voor PPTX‑diagrammen kunt u een basis gebruiken van `2` tot en met `1000`, inclusief; fractionele bases zoals `2.5` worden ook ondersteund. Met basis `10` zijn opeenvolgende machten zoals 10, 100, 1.000 en 10.000 gelijkmatig verdeeld.

### **Lineaire en logaritmische schaal vergelijken**

Het volgende zelfstandige voorbeeld maakt een lijndiagram met de vijf aanvraag‑aantallen op de eerste dia, kloont vervolgens die dia en schakelt een logaritmische waarde‑as met basis 10 in op de tweede. Beide dia's behouden dezelfde gegevens.

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

    // Houd de eerste dia lineair en wijzig alleen de schaal van de waarde-as van de kopie.
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

**Lineaire schaal (dia 1):** Gelijke verticale afstanden staan voor gelijke verschillen in aanvraag‑aantallen. De grootste waarde domineert het diagram, waardoor de kleinere waarden moeilijk te onderscheiden zijn.

![Lijndiagram in PowerPoint met vijf aanvraag‑aantallen op een lineaire waarde‑as](value-axis-linear.png)

**Logaritmische schaal (dia 2):** Gelijke verticale afstanden staan voor gelijke verhoudingen. Elke periode heeft tien keer zoveel aanvragen als de vorige, waardoor de punten een rechte stijgende lijn vormen op de schaal met basis 10. De aslabels tonen nog steeds de oorspronkelijke aanvraag‑aantallen.

![Dezelfde vijf aanvraag‑aantallen in PowerPoint op een logaritmische waarde‑as met basis 10](value-axis-logarithmic.png)

### **Omgaan met nul- en negatieve waarden**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de gegevens voordat u deze inschakelt. Als nul‑ of negatieve waarden betekenisvol zijn, behoud dan een lineaire schaal of toon ze apart. Als het weglaten van die waarden geschikt is voor de analyse, leg dan de reden uit. Vervang ze niet stilletjes door kleine positieve getallen, omdat dit de betekenis van de gegevens verandert. Elke handmatig geconfigureerde minimum‑ of maximumwaarde voor een logaritmische as moet ook positief zijn.

## **Veelgestelde vragen**

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Gebruik [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) om het kruisgedrag te selecteren. Om een numerieke kruiswaarde op te geven, gebruik [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Deze instellingen laten u de askruising naar een geschikt basisniveau verplaatsen.

**Hoe kan ik tick‑labels ten opzichte van de as positioneren?**

Roep [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) aan met [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` of `None`. Om de tick‑marks zelf te besturen, gebruik [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) of [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); deze staan los van de labelpositionering.