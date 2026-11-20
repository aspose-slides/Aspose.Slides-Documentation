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
- as‑eigenschappen
- maximale waarde
- minimale waarde
- aslijn
- datumnotatie
- as‑titel
- as‑positie
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek hoe u JavaScript met Aspose.Slides voor Node.js via Java kunt gebruiken om grafiekassen aan te passen in PowerPoint‑presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u de assen van een diagram kunt aanpassen met Aspose.Slides voor Node.js via Java. Het behandelt berekende aswaarden, het wisselen van rijen en kolommen van het diagram, aszichtbaarheid, intervallen voor categorielabels en tick‑marks, datumcategorieën en opmaak, rotatie van de titel, aspositionering, weergave‑eenheden en logaritmische schaal.

## **Maximale waarden op de verticale as van diagrammen ophalen**

Maak een [Presentatie](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) en voeg een gebiedsdiagram toe met standaardgegevens. Roep [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) aan voordat u berekende aswaarden uitleest, zodat de diagramlay-out up‑to‑date is.

Lees [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) en [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) voor de aslimieten, en [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) en [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) voor de tick‑intervallen. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) en [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) geven tijd‑eenheid schalen, die relevant zijn voor datumassen. Het voorbeeld slaat deze waarden op in lokale variabelen en slaat het diagram op.

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

## **Gegevens tussen assen uitwisselen**

Gebruik [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) om de rollen van series en categorieën in diagramgegevens om te draaien. Elke voormalige categorie wordt een serie, en elke voormalige serie wordt een categorie. Dit verandert hoe de gegevens worden gegroepeerd; het wisselt niet de horizontale en verticale assen uit. Het voorbeeld gebruikt [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) om de standaardgegevens te koppelen aan `Sheet1!A1:D5`, inclusief de koprij en categoriekolom, vóór het wisselen van rijen en kolommen. Het slaat een diagram op met vier series en drie categorieën.

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

Gebruik [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) om een categorie‑ of waardenas om te keren. Bijvoorbeeld, een horizontaal staafdiagram kan projectfasen van boven naar beneden tonen in dezelfde volgorde als het werkblad: Planning, Ontwikkeling, Testen. Het omkeren van een as verandert de plotrichting; het sorteert of herschikt de werkbladgegevens niet. Ter vergelijking wisselt [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) de rollen van series en categorieën.

Het volgende voorbeeld maakt een horizontaal staafdiagram met drie fasen en één serie. Het slaat een presentatie op met drie dia’s: normale volgorde, omgekeerde categorieën en omgekeerde waarden. Elke kopie gebruikt dezelfde dataset, en op elke kopie wordt slechts één as omgekeerd.

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
    // Houd de horizontale waardenas onderaan.
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

Het omkeren van een as kan ook de loodrechte as naar de tegenoverliggende kant van het diagram verplaatsen. [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) bepaalt waar de andere as de geconfigureerde as kruist. In dia 2 wordt dit aangeroepen met `aspose.slides.CrossesType.Maximum` op de omgekeerde categorias, waardoor de horizontale waardenas onderaan blijft. Voor een specifiek kruispunt gebruikt u [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Controleer de kruisinstellingen wanneer u de richting wijzigt, vooral als het diagram al een aangepast kruispunt heeft. Roep `setPlotOrderReversed` met `false` aan om de normale plotrichting te herstellen; kruisinstellingen zijn afzonderlijk.

| Normale volgorde (dia 1) | Omgekeerde categorieën (dia 2) | Omgekeerde waarden (dia 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| Categorieën lopen van onder naar boven; waarden stijgen van links naar rechts. | Planning, Ontwikkeling en Testen lopen van boven naar beneden. Waarden en werkblad‑rijvolgorde blijven ongewijzigd. | Categorieën behouden hun normale volgorde; waarden stijgen van rechts naar links. De categorias kruist bij nul aan de rechterkant. |

## **Verticale as uitschakelen voor lijndiagrammen**

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

## **Horizontale as uitschakelen voor lijndiagrammen**

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

## **Rasterlijnen van diagrammen weergeven of verbergen**

Roep [getShowMajorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowmajorgridlines/) en [getShowMinorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowminorgridlines/) aan om te controleren welke rasterlijnen een as weergeeft. Om kleine rasterlijnen weer te geven, gebruikt u [getMinorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getminorgridlinesformat/) en stelt u de lijnvulling in op een solide, zichtbare kleur. Om ze te verbergen, stelt u de vulling in op [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/). Gebruik [getMajorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getmajorgridlinesformat/) om de lijnvulling voor grote rasterlijnen op dezelfde manier te wijzigen. Het wijzigen van de vulling behoudt de aszichtbaarheid en tick‑marks.

De verticale as van dit gegroepeerde kolomdiagram toont aanvankelijk alleen grote rasterlijnen. Het voorbeeld toont de kleine rasterlijnen in donkeroranje, verbergt ze daarna opnieuw en slaat de presentatie op. Het drukt de rasterlijnzichtbaarheid bij elke stap af.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 30, 660, 230);
    var axis = chart.getAxes().getVerticalAxis();
    console.log("Initial: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    var minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    var darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    minorFill.getSolidFillColor().setColor(darkOrange);
    console.log("Enabled: minor=%s", axis.getShowMinorGridLines());

    minorFill.setFillType(java.newByte(aspose.slides.FillType.NoFill));
    console.log("Hidden: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Kleine rasterlijnen ingeschakeld | Kleine rasterlijnen verborgen |
| --- | --- |
| ![Orange minor gridlines between the major gridlines on the vertical axis](minor-gridlines-enabled.png) | ![The same column chart with only major gridlines visible](minor-gridlines-hidden.png) |

## **Categorie‑as wijzigen**

Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) om een datum‑ of tekstcategorie‑as te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een diagram als de eerste shape op de eerste dia en categoriecellen die numerieke Excel‑datumwaarden bevatten. Het wijzigt de horizontale as naar een datum‑as. Het aanroepen van [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) met `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) met `1`, en [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) met `TimeUnitType.Months` plaatst grote ticks op één‑maandintervallen.

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

### **Het type categorias bepalen aan de hand van gegevens**

Roep [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistypeautomatically/) aan nadat de categorieën zijn gevuld, lees vervolgens [getCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getcategoryaxistype/) om de selectie te inspecteren. Dit is nuttig wanneer hetzelfde diagram ofwel tekstlabels of numerieke datumwaarden ontvangt. De methode bepaalt het type op het moment van aanroep; hij activeert geen permanente modus die latere gegevenswijzigingen opnieuw evalueert. Roep hem opnieuw aan na het vervangen van de categorieën.

Het volgende voorbeeld maakt een diagram met tekstcategorieën en drukt `true` af wanneer het geselecteerde type `CategoryAxisType.Text` is. Vervolgens vervangt het de waarden van de categoriecellen door datums en roept de methode opnieuw aan, waarbij `true` wordt afgedrukt wanneer het geselecteerde type `CategoryAxisType.Date` is. Datums worden opgeslagen als numerieke OLE‑Automation‑waarden, berekend als het aantal dagen sinds 30 december 1899, in plaats van datum‑strings. De JavaScript‑berekening gebruikt UTC‑timestamps en deelt het verschil door 86 400 000 milliseconden per dag; maand‑indices beginnen bij nul. Gebruik `java.newDouble` om elke datumwaarde als double naar Java door te geven. [setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) bepaalt hoe die waarden worden weergegeven; het converteert geen tekst naar numerieke datums. Voor meer over categoriecellen, zie [Chart Workbook](/slides/nl/nodejs-java/chart-workbook/).

Gebruik automatische bepaling wanneer de invoer bekend is om tekstcategorieën of numerieke datums te bevatten, zoals in dit voorbeeld. Voor gewone numerieke labels, gemengde categorieën of lege gegevens, roep expliciet [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) aan om het beoogde type te matchen. Alleen numerieke waarden leggen niet vast dat de categorieën datumrepresentaties zijn.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var seriesName = workbook.getCell(0, 0, 1, "Sales");
    var series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    var labels = ["First", "Second", "Third"];

    for (var i = 0; i < labels.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Text); // true

    var baseDate = Date.UTC(1899, 11, 30);
    var dates = [Date.UTC(2026, 0, 1), Date.UTC(2026, 0, 2), Date.UTC(2026, 1, 1)];

    for (var i = 0; i < dates.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0);
        var dateValue = java.newDouble((dates[i] - baseDate) / 86400000);
        categoryCell.setValue(dateValue);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Date); // true

    presentation.save("AutomaticCategoryAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Interval van categorielabels regelen**

Wanneer een diagram veel categorieën heeft, vermindert u het aantal zichtbare aslabels zonder categorieën of gegevenspunten te verwijderen. Roep [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) met `false` aan en geef vervolgens het gewenste categorinterval door aan [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Voor tekstcategorieën in hun normale volgorde start de telling bij de eerste categorie:

| Interval | Labels weergegeven in het voorbeeld |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

Een interval van `3` toont elk derde label, waarbij twee labels verborgen blijven tussen de weergegeven labels. Het verwijdert de overeenkomstige kolommen niet. Automatische spacing kiest een interval op basis van de beschikbare ruimte; het toont niet per se elk label.

Tick‑marks hebben aparte instellingen. Roep [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) met `false` aan en gebruik [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) om hun interval in te stellen. Bijvoorbeeld, `1` houdt een tick‑mark bij elk categorinterval terwijl labels slechts elke derde categorie verschijnen. Gebruik [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) met een zichtbaar stijl zodat u het resultaat kunt zien. Het opnieuw instellen van een automatische spacing‑setter met `true` laat het diagram het interval opnieuw kiezen.

Het volgende zelf‑containende voorbeeld maakt 24 categorieën en één serie, en slaat drie dia’s op in `CategoryAxisIntervals.pptx`: automatische spacing, handmatige labelspacing met onafhankelijke tick‑marks, en herstelde automatische spacing. De twee kopieën behouden de oorspronkelijke diagramgegevens. Er is geen invoer‑presentatie vereist. De horizontale labeltekst maakt het verschil in dichtheid duidelijk zichtbaar.

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

    // Dia 2: toon elk derde label, maar behoud een tick-mark voor elke categorie.
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

**Automatische spacing (dia 1):** In deze weergave wordt elke tweede categorielabel weergegeven en wordt deze op twee regels afgebroken. Het automatische resultaat kan variëren afhankelijk van diagramgrootte, lettertypen en de renderer.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Handmatige spacing (dia 2):** Elke derde label wordt op één regel weergegeven, terwijl tick‑marks behouden blijven bij elk categorinterval. Alle 24 kolommen, inclusief die zonder label, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt de automatische weergave die hierboven wordt getoond.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **De juiste as en interval kiezen**

Gebruik dit categorie‑aantal‑interval voor een tekst‑categorias, zoals de categorias van een kolom‑, lijn‑, gebieds‑ of staafdiagram. In een kolomdiagram is dit de horizontale as. In een horizontaal staafdiagram is de categorias verticaal, dus pas deze instellingen toe op de as die wordt geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Tick‑mark spacing is ook van toepassing op een series‑as in diagrammen die er één hebben.

Gebruik geen categorielabel‑spacing om de numerieke schaal van een waardenas in te stellen. Op een waardenas specificeert [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) een waardeverschil: bijvoorbeeld, een grote eenheid van `10` produceert ticks bij 0, 10, 20, enzovoort wanneer de as bij nul start. Een categorielabel‑interval van `3` telt echter posities van categorieën, ongeacht hun gegevenswaarden. Scatter‑ en bubbel‑diagrammen gebruiken waardenas in plaats van een tekst‑categorias. Voor een datum‑as gebruikt u tijds‑gebaseerde grote eenheden en schalen zoals beschreven in [Categorie‑as wijzigen](#categorie‑as-wijzigen).

## **Datumopmaak voor categoriaswaarden instellen**

Het voorbeeld vervangt de standaard diagramgegevens door vier jaarlijkse waarden. Datums worden opgeslagen als OLE‑Automation‑serienummers in het eerste werkblad (index `0`), berekend als het aantal dagen sinds 30 december 1899 voor deze datums. De JavaScript‑berekening gebruikt UTC‑timestamps en deelt het verschil door 86 400 000 milliseconden per dag. Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) met `CategoryAxisType.Date`, roep [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) met `false` aan, en geef `yyyy` door aan [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) zodat de categorielabels viercijferige jaartallen tonen, onafhankelijk van de celopmaak.

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

## **Rotatiehoek voor een diagramas‑titel instellen**

Roep [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) met `true` aan op de verticale as, geef de titeltekst op, en gebruik [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) om de titel te draaien. De hoek wordt gemeten in graden; dit voorbeeld slaat een kolomdiagram op met de titel van de waardenas geroteerd met 90 graden.

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

## **Aspositie instellen op een categorias of waardenas**

Gebruik [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) om te bepalen of de waardenas de categorias kruist tussen categorieën of op de categorietick‑marks. Deze instelling geldt voor categorie‑assen. Het voorbeeld stelt dit in op `true` voor de horizontale categorias van een kolomdiagram en slaat het resultaat op.

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

## **Weergave‑eenheid op een waardenas instellen**

Gebruik [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) om de labels op een waardenas te schalen zonder de onderliggende gegevens te wijzigen. Met [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) ingesteld op `Millions` wordt een waarde van 60 000 000 weergegeven als 60. Het voorbeeld maakt een kolomdiagram en past de weergave‑eenheid “miljoenen” toe op de verticale as.

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

## **Logaritmische waardenas configureren**

Een logaritmische waardenas is nuttig wanneer positieve waarden meerdere groottenordes beslaan. Bijvoorbeeld, een service kan 10, 100, 1 000, 10 000 en 100 000 verzoeken ontvangen over vijf perioden. Op een lineaire schaal liggen de kleinere waarden dicht bij nul bij elkaar. Een logaritmische schaal maakt hun relatieve groei makkelijker te vergelijken: gelijke afstanden vertegenwoordigen gelijke verhoudingen in plaats van gelijke verschillen.

Roep [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) met `true` aan op de waardenas en gebruik [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) om de basis te kiezen. Dit verandert hoe de bestaande waarden worden weergegeven; het wijzigt de gegevens niet en voegt geen logaritmische trendlijn toe. Een trendlijn stelt een passende relatie in de gegevens voor en is een afzonderlijke functionaliteit.

### **De waardenas en basis kiezen**

Voor een lijn‑ of kolomdiagram wordt de waardenas geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Voor een horizontaal staafdiagram wordt deze geretourneerd door [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Scatter‑ en bubbel‑diagrammen hebben twee waardenas, dus kies de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas geen logaritmische schaal toe op een categorias.

De standaard logaritmische basis is `10`. Voor PPTX‑diagrammen mag de basis liggen tussen `2` en `1000`, inclusief; breukbasissen zoals `2.5` worden ook ondersteund. Met basis `10` zijn opeenvolgende machten zoals 10, 100, 1 000 en 10 000 gelijkmatig verdeeld.

### **Lineaire en logaritmische schaal vergelijken**

Het volgende zelf‑containende voorbeeld maakt een lijndiagram met de vijf verzoektelling op de eerste dia, kloont vervolgens die dia en schakelt een logaritmische waardenas met basis 10 in op de tweede. Beide dia’s behouden dezelfde gegevens.

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

    // Behoud de eerste dia lineair en verander alleen de schaal van de waardenas van de kopie.
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

**Logaritmische schaal (dia 2):** Gelijke verticale afstanden vertegenwoordigen gelijke verhoudingen. Elke periode heeft tien keer zoveel verzoeken als de vorige, waardoor de punten een rechte stijgende lijn vormen op de basis‑10 schaal. De as‑labels tonen nog steeds de oorspronkelijke verzoektelling.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Omgaan met nul‑ en negatieve waarden**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de gegevens voordat u deze activeert. Als nul‑ of negatieve waarden betekenis hebben, behoud dan een lineaire schaal of toon ze apart. Als het weglaten van die waarden passend is voor de analyse, leg dan de reden uit. Vervang ze niet stilletjes door kleine positieve getallen, want dat wijzigt de betekenis van de data. Elke handmatig ingestelde minimum‑ of maximumwaarde voor een logaritmische as moet eveneens positief zijn.

## **FAQ**

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Gebruik [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) om het kruisk gedrag te selecteren. Om een numerieke kruiswaarde op te geven, gebruikt u [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Deze instellingen laten u de as‑kruising naar een geschikte basislijn verplaatsen.

**Hoe kan ik tick‑labels positioneren ten opzichte van de as?**

Roep [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) aan met een van de waarden uit [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` of `None`. Om de tick‑marks zelf te regelen, gebruikt u [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) of [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); deze staan los van de labelpositionering.