---
title: Diagramassen aanpassen in presentaties op Android
linktitle: Diagramas
type: docs
url: /nl/androidjava/chart-axis/
keywords:
- diagramas
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
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor Android via Java kunt gebruiken om diagramassen in PowerPoint‑presentaties aan te passen voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u diagramassen kunt aanpassen met Aspose.Slides for Android via Java. Het behandelt berekende aswaarden, het wisselen van diagramrijen en -kolommen, aszichtbaarheid, intervallen voor categorie‑labels en tik‑markeringen, datumcategorieën en -opmaak, rotatie van de titel, aspositionering, weergave‑eenheden en logaritmische schaal.

## **De maximale waarden op de verticale as van diagrammen ophalen**

Maak een [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) aan en voeg een vlakdiagram toe met standaardgegevens. Roep [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) aan vóór het lezen van berekende aswaarden zodat de diagramindeling up‑to‑date is.

Lees [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) en [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) voor de aslimieten, en [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) en [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) voor de tik‑intervallen. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) en [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) leveren tijdseenheidschalen, die relevant zijn voor datumassen. Het voorbeeld slaat deze waarden op in lokale variabelen en slaat het diagram op.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gegevens tussen assen wisselen**

Gebruik [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) om de rollen van reeksen en categorieën in diagramgegevens uit te wisselen. Elke voormalige categorie wordt een reeks, en elke voormalige reeks wordt een categorie. Dit verandert de groepering van de gegevens; het wisselt niet de horizontale en verticale assen uit. Het voorbeeld gebruikt [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) om de standaardgegevens te binden aan `Sheet1!A1:D5`, inclusief de koprij en categoriekolom, vóór het wisselen van rijen en kolommen. Het slaat een diagram op met vier reeksen en drie categorieën.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **De plotvolgorde van een as omkeren**

Gebruik [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) om een categorie‑ of waardenas om te keren. Bijvoorbeeld, een horizontale staafdiagram kan projectfasen van boven naar beneden tonen in dezelfde volgorde als het werkblad: Planning, Ontwikkeling, Testen. Het omkeren van een as wijzigt de plotrichting; het sorteert of herschikt de werkboekgegevens niet. Ter vergelijking wisselt [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) de rollen van reeksen en categorieën.

Het volgende voorbeeld maakt een horizontale staafdiagram met drie fasen en één reeks. Het slaat een presentatie op met drie dia's: normale volgorde, omgekeerde categorieën en omgekeerde waarden. Elke kopie gebruikt dezelfde dataset, en slechts één as wordt omgekeerd per kopie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Dia 2: toon de eerste categorie bovenaan.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Behoud de horizontale waardenas onderaan.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // Dia 3: keer alleen de horizontale numerieke schaal om.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het omkeren van een as kan ook de loodrechte as naar de tegenovergestelde kant van de plot verplaatsen. [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) bepaalt waar de andere as de geconfigureerde as kruist. In dia 2 wordt het aangeroepen met `CrossesType.Maximum` op de omgekeerde categorias die horizontale waardenas onderaan houdt. Voor een specifiek kruispunt gebruik [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Controleer de kruisininstellingen bij het wijzigen van de richting, vooral als het diagram al een aangepast kruispunt heeft. Roep `setPlotOrderReversed` aan met `false` om de normale plotrichting te herstellen; kruisininstellingen zijn afzonderlijk.

| Normale volgorde (dia 1) | Omgekeerde categorieën (dia 2) | Omgekeerde waarden (dia 3) |
| --- | --- | --- |
| ![Horizontale staafdiagram met normale categorie‑ en waardenasvolgorde](axis-order-normal.png) | ![Horizontale staafdiagram met categorieën van boven naar beneden weergegeven](axis-order-categories-reversed.png) | ![Horizontale staafdiagram met een omgekeerde waardenas en nul aan de rechterkant](axis-order-values-reversed.png) |
| Categorieën lopen van onder naar boven; waarden nemen toe van links naar rechts. | Planning, Ontwikkeling en Testen lopen van boven naar beneden. Waarden en rijvolgorde in het werkboek blijven ongewijzigd. | Categorieën behouden hun normale volgorde; waarden nemen toe van rechts naar links. De categorias kruist bij nul aan de rechterkant. |

## **De verticale as voor lijndiagrammen uitschakelen**

Roep [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) aan met `false` op de verticale as om deze te verbergen. Het voorbeeld maakt een lijndiagram met standaardgegevens en slaat het op met de verticale as verborgen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **De horizontale as voor lijndiagrammen uitschakelen**

Roep [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) aan met `false` op de horizontale as om deze te verbergen. Het voorbeeld maakt een lijndiagram met standaardgegevens en slaat het op met de horizontale as verborgen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een categorias aanpassen**

Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) om een datum‑ of tekst‑categorias te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een diagram als eerste vorm op de eerste dia en categoriecellen die numerieke Excel‑datumnummers bevatten. Het verandert de horizontale as in een datumas. Door [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) aan te roepen met `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) met `1` en [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) met `TimeUnitType.Months` worden hoofd‑ticks geplaatst met intervallen van één maand.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Intervallen voor categorielabel‑as regelen**

Wanneer een diagram veel categorieën bevat, kunt u het aantal zichtbare aslabels verminderen zonder categorieën of gegevenspunten te verwijderen. Roep [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) aan met `false` en geef vervolgens het gewenste categorisch interval door aan [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Voor tekstcategorieën in hun normale volgorde begint de telling bij de eerste categorie:

| Interval | Labels in het voorbeeld |
| --- | --- |
| `1` | Categorie 1, Categorie 2, Categorie 3, … Categorie 24 |
| `2` | Categorie 1, Categorie 3, Categorie 5, … Categorie 23 |
| `3` | Categorie 1, Categorie 4, Categorie 7, … Categorie 22 |

Een interval van `3` toont elk derde label, waarbij twee labels verborgen blijven tussen de weergegeven labels. Het verwijdert de bijbehorende kolommen niet. Automatische spacing kiest een interval op basis van de beschikbare ruimte; het toont niet per se elk label.

Tikkens hebben afzonderlijke besturingselementen. Roep [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) aan met `false` en gebruik [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) om hun interval in te stellen. Bijvoorbeeld, `1` behoudt een tikkens bij elk categorisch interval terwijl labels alleen elke derde categorie verschijnen. Gebruik [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) met een zichtbaar stijltje zodat u het resultaat kunt zien. Als u de automatische‑spacing‑setter opnieuw met `true` aanroept, laat het diagram dat interval opnieuw kiezen.

Het volgende zelf‑containende voorbeeld maakt 24 categorieën en één reeks, en slaat vervolgens drie dia's op in `CategoryAxisIntervals.pptx`: automatische spacing, handmatige labelspacing met onafhankelijke tikkens, en herstelde automatische spacing. De twee kopieën behouden de oorspronkelijke diagramgegevens. Er is geen invoer‑presentatie vereist. Horizontale labeltekst maakt het verschil in dichtheid duidelijk zichtbaar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Dia 2: toon elk derde label, maar behoud een tikmarkering voor elke categorie.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Dia 3: laat het diagram beide intervallen opnieuw kiezen.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatische spacing (dia 1):** In deze weergave wordt elk tweede categorielabel getoond en wordt het op twee regels afgebroken. Het automatische resultaat kan variëren met diagramgrootte, lettertypen en de renderer.

![Automatische categorielabelspacing met alle 24 kolommen zichtbaar](category-axis-automatic.png)

**Handmatige spacing (dia 2):** Elk derde label wordt op één regel getoond, terwijl tikkens behouden blijven bij elk categorisch interval. Alle 24 kolommen, inclusief die zonder labels, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt de automatische weergave zoals hierboven getoond.

![Handmatige categorielabelinterval van drie met alle 24 kolommen zichtbaar](category-axis-manual.png)

### **Kies de juiste as en het interval**

Gebruik dit categorie‑tellaantalinterval voor een tekst‑categorias, zoals de categorias van een kolom‑, lijn‑, gebied‑ of staafdiagram. In een kolomdiagram is het de horizontale as. In een horizontale staafdiagram is de categorias verticaal, dus pas deze instellingen toe op de as die wordt geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Spacing voor tikkens geldt ook voor een reeksenas in diagrammen die er één hebben.

Gebruik geen categorielabelspacing om de numerieke schaal van een waardenas in te stellen. Op een waardenas bepaalt [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) een verschil in waarden: bijvoorbeeld, een hoofd‑eenheid van `10` produceert ticks bij 0, 10, 20, … wanneer de as bij nul begint. Een categorielabel‑interval van `3` telt in plaats daarvan categorie‑posities, ongeacht hun gegevenswaarden. Spreidings‑ en bubbel‑diagrammen gebruiken waardassen in plaats van een tekst‑categorias. Voor een datumas gebruikt u tijdgebaseerde hoofd‑eenheden en schalen zoals beschreven in [Een categorias aanpassen](#een-categorias-aanpassen).

## **Het datumformaat voor categoriaswaarden instellen**

Het voorbeeld vervangt de standaard diagramgegevens door vier jaarlijkse waarden. Datums worden opgeslagen als OLE‑Automation‑serienummers in het eerste werkblad (index `0`), berekend als het aantal dagen sinds 30 december 1899 voor deze datums. Beide kalenders gebruiken UTC en worden leeggemaakt vóór het instellen van de datums zodat zomertijd en het huidige tijdstip de berekening niet beïnvloeden. Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) met `CategoryAxisType.Date`, roep [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) aan met `false`, en geef `yyyy` door aan [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) zodat de categorielabels viercijferige jaren tonen, onafhankelijk van de celopmaak.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een rotatie‑hoek voor een diagramas‑titel instellen**

Roep [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) aan met `true` op de verticale as, geef de titeltekst op, en gebruik [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) om de titel te roteren. De hoek wordt gemeten in graden; dit voorbeeld slaat een kolomdiagram op met zijn waardenas‑titel geroteerd met 90 graden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **De aspositie op een categorias of waardenas instellen**

Gebruik [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) om te bepalen of de waardenas de categorias kruist tussen categorieën of op categoriektik‑marks. Deze instelling geldt voor categoriasen. Het voorbeeld stelt deze in op `true` op de horizontale categorias van een kolomdiagram en slaat het resultaat op.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **De weergave‑eenheid op een diagram‑waardenas instellen**

Gebruik [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) om de labels op een waardenas te schalen zonder de onderliggende gegevens te wijzigen. Met [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) ingesteld op `Millions` wordt een waarde van 60 000 000 weergegeven als 60. Het voorbeeld maakt een kolomdiagram en past de miljoenen‑weergave‑eenheid toe op de verticale as.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een logaritmische waardenas configureren**

Een logaritmische waardenas is nuttig wanneer positieve waarden zich over meerdere orders van grootte uitstrekken. Bijvoorbeeld, een service kan 10, 100, 1 000, 10 000 en 100 000 verzoeken ontvangen over vijf perioden. Op een lineaire schaal verschijnen de kleinere waarden dicht bij nul. Een logaritmische schaal maakt hun relatieve groei makkelijker te vergelijken: gelijke afstanden vertegenwoordigen gelijke verhoudingen in plaats van gelijke verschillen.

Roep [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) aan met `true` op de waardenas en gebruik [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) om de basis te kiezen. Dit verandert hoe de bestaande waarden worden weergegeven; het wijzigt de gegevens niet en voegt geen logaritmische trendlijn toe. Een trendlijn stelt een aangepaste relatie in de gegevens voor en is een afzonderlijke functie.

### **De waardenas en de basis kiezen**

Voor een lijn‑ of kolomdiagram wordt de waardenas geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Voor een horizontale staafdiagram wordt deze geretourneerd door [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Spreidings‑ en bubbel‑diagrammen hebben twee waardassen, dus kies de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas geen logaritmische schaal toe op een categorias.

De standaard logaritmische basis is `10`. Voor PPTX‑diagrammen mag de basis tussen `2` en `1000` liggen, inclusief; fractionele basissen zoals `2.5` worden ook ondersteund. Met basis `10` zijn opeenvolgende machten zoals 10, 100, 1 000 en 10 000 gelijkmatig verdeeld.

### **Lineaire versus logaritmische schaal vergelijken**

Het volgende zelf‑containende voorbeeld maakt een lijndiagram met de vijf verzoekaantallen op de eerste dia, kloont die dia vervolgens en schakelt een base‑10 logaritmische waardenas in op de tweede. Beide dia's behouden dezelfde gegevens.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Behoud de eerste dia lineair en wijzig alleen de schaal van de waardenas van de kopie.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Lineaire schaal (dia 1):** Gelijke verticale afstanden vertegenwoordigen gelijke verschillen in verzoekaantallen. De grootste waarde domineert het diagram, waardoor de kleinere waarden moeilijk te onderscheiden zijn.

![Lijndiagram in PowerPoint dat vijf verzoekaantallen toont op een lineaire waardenas](value-axis-linear.png)

**Logaritmische schaal (dia 2):** Gelijke verticale afstanden vertegenwoordigen gelijke verhoudingen. Elke periode heeft tien keer zoveel verzoeken als de vorige, zodat de punten een rechte stijgende lijn vormen op de base‑10 schaal. De as‑labels blijven de oorspronkelijke verzoekaantallen tonen.

![Dezelfde vijf verzoekaantallen in PowerPoint op een base‑10 logaritmische waardenas](value-axis-logarithmic.png)

### **Omgaan met nul‑ en negatieve waarden**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de gegevens voordat u deze activeert. Als nul of negatieve waarden betekenis hebben, behoud dan een lineaire schaal of toon ze afzonderlijk. Als het weglaten van die waarden passend is voor de analyse, leg dan de omissie uit. Vervang ze niet stilletjes door kleine positieve getallen, want dat verandert de betekenis van de gegevens. Elke handmatig geconfigureerde minimum‑ of maximumwaarde voor een logaritmische as moet ook positief zijn.

## **FAQ**

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Gebruik [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) om het kruiskundig gedrag te selecteren. Om een numerieke kruiswaarde op te geven, gebruik [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Deze instellingen laten u de as‑kruising naar een geschikte basislijn verplaatsen.

**Hoe kan ik tik‑labels positioneren ten opzichte van de as?**

Roep [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) aan met behulp van [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` of `None`. Om de tikkens zelf te regelen, gebruik [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) of [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); deze staan los van de labelpositionering.