---
title: Diagramassen aanpassen in presentaties met Java
linktitle: Diagramas
type: docs
url: /nl/java/chart-axis/
keywords:
- diagramas
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
- as positie
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor Java kunt gebruiken om diagramassen in PowerPoint-presentaties aan te passen voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u de assen van een diagram kunt aanpassen met Aspose.Slides voor Java. Het behandelt berekende aswaarden, het wisselen van rijen en kolommen in diagrammen, zichtbaarheid van assen, interval van categorie‑labels en tic‑markeringen, datumcategorieën en opmaak, rotatie van titels, positie van de as, weergave‑eenheden en logaritmische schaal.

## **Maximumwaarden op de verticale as van diagrammen ophalen**

Maak een [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) en voeg een gebiedsdiagram toe met standaardgegevens. Roep [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) aan voordat u berekende aswaarden leest, zodat de diagramindeling up-to-date is.

Lees [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) en [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) voor de aslimieten, en [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) en [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) voor de tic‑intervallen. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) en [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) geven tijdseenheidschalen, die relevant zijn voor datumassen. Het voorbeeld slaat deze waarden op in lokale variabelen en slaat het diagram op.

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
## **Gegevens tussen assen verwisselen**

Gebruik [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) om de rollen van reeksen en categorieën in diagramgegevens om te wisselen. Elke voormalige categorie wordt een reeks, en elke voormalige reeks wordt een categorie. Dit verandert hoe de gegevens worden gegroepeerd; het verwisselt niet de horizontale en verticale assen. Het voorbeeld gebruikt [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) om de standaardgegevens te koppelen aan `Sheet1!A1:D5`, inclusief de koprij en categorie‑kolom, voordat rijen en kolommen worden verwisseld. Het slaat een diagram op met vier reeksen en drie categorieën.

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
## **Plotvolgorde van een as omkeren**

Gebruik [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) om een categorie‑ of waarde‑as om te keren. Bijvoorbeeld, een horizontale staafdiagram kan projectfasen van boven naar beneden weergeven in dezelfde volgorde als het werkblad: Planning, Ontwikkeling, Testen. Het omkeren van een as wijzigt de plotrichting; het sorteert of herschikt de gegevens in de werkmap niet. Ter vergelijking, [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) verwisselt de rollen van reeksen en categorieën.

Het volgende voorbeeld maakt een horizontale staafdiagram met drie fasen en één reeks. Het slaat een presentatie op met drie dia's: normale volgorde, omgekeerde categorieën en omgekeerde waarden. Elke kopie gebruikt dezelfde dataset, en op elke kopie wordt slechts één as omgekeerd.

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
    // Behoud de horizontale waardeas onderaan.
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

Het omkeren van een as kan ook de loodrechte as naar de tegenovergestelde kant van de plot verplaatsen. [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) bepaalt waar de andere as de geconfigureerde as kruist. In dia 2, wanneer het wordt aangeroepen met `CrossesType.Maximum` op de omgekeerde categorie‑as, blijft de horizontale waarde‑as onderaan. Voor een specifiek kruispunt, gebruik [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Controleer de kruisinginstellingen bij het wijzigen van de richting, vooral als het diagram al een aangepast kruispunt heeft. Roep `setPlotOrderReversed` aan met `false` om de normale plotrichting te herstellen; kruisinginstellingen zijn afzonderlijk.

| Normale volgorde (dia 1) | Omgekeerde categorieën (dia 2) | Omgekeerde waarden (dia 3) |
| --- | --- | --- |
| ![Horizontale staafdiagram met normale categorie‑ en waardeasvolgorde](axis-order-normal.png) | ![Horizontale staafdiagram met categorieën weergegeven van boven naar beneden](axis-order-categories-reversed.png) | ![Horizontale staafdiagram met een omgekeerde waardeas en nul aan de rechterkant](axis-order-values-reversed.png) |
| Categorieën lopen van onder naar boven; waarden nemen toe van links naar rechts. | Planning, Ontwikkeling en Testen lopen van boven naar beneden. Waarden en rij‑volgorde in de werkmap blijven ongewijzigd. | Categorieën behouden hun normale volgorde; waarden nemen toe van rechts naar links. De categorie‑as kruist op nul aan de rechterkant. |

## **Verticale as voor lijndiagrammen uitschakelen**

Roep [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) aan met `false` op de verticale as om deze te verbergen. Het voorbeeld maakt een lijndiagram met standaardgegevens en slaat het op met de verticale as verborgen.

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
## **Horizontale as voor lijndiagrammen uitschakelen**

Roep [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) aan met `false` op de horizontale as om deze te verbergen. Het voorbeeld maakt een lijndiagram met standaardgegevens en slaat het op met de horizontale as verborgen.

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
## **Een categorie‑as wijzigen**

Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) om een datum‑ of tekst‑categorie‑as te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een diagram als de eerste vorm op de eerste dia en categoriecellen met numerieke Excel‑datumnummers. Het wijzigt de horizontale as naar een datum‑as. Het aanroepen van [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) met `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) met `1` en [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) met `TimeUnitType.Months` plaatst hoofdtics op één‑maandintervallen.

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
## **Interval van categorie‑as‑labels beheersen**

Wanneer een diagram veel categorieën heeft, kunt u het aantal zichtbare as‑labels verminderen zonder categorieën of datapunten te verwijderen. Roep [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) aan met `false`, en geef vervolgens het gewenste categorie‑interval door aan [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Voor tekstcategorieën in hun normale volgorde start de telling bij de eerste categorie:

| Interval | Labels die in het voorbeeld worden weergegeven |
| --- | --- |
| `1` | Categorie 1, Categorie 2, Categorie 3, ... Categorie 24 |
| `2` | Categorie 1, Categorie 3, Categorie 5, ... Categorie 23 |
| `3` | Categorie 1, Categorie 4, Categorie 7, ... Categorie 22 |

Een interval van `3` toont elk derde label, waarbij twee labels tussen de weergegeven labels verborgen blijven. Het verwijdert de bijbehorende kolommen niet. Automatische spatiëring kiest een interval op basis van de beschikbare ruimte; het toont niet per se elk label.

Tic‑markeringen hebben aparte instellingen. Roep [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) aan met `false` en gebruik [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) om hun interval in te stellen. Bijvoorbeeld, `1` behoudt een tic‑markering bij elk categorie‑interval terwijl labels slechts elke derde categorie verschijnen. Gebruik [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) met een zichtbaar type zodat u het resultaat kunt zien. Het opnieuw aanroepen van een automatische‑spatiërings‑setter met `true` laat het diagram het interval opnieuw kiezen.

Het volgende zelfstandige voorbeeld maakt 24 categorieën en één reeks, en slaat drie dia's op in `CategoryAxisIntervals.pptx`: automatische spatiëring, handmatige label‑spatiëring met onafhankelijke tic‑markeringen, en herstelde automatische spatiëring. De twee kopieën behouden de oorspronkelijke diagramgegevens. Er is geen invoerpresentatie nodig. Horizontale labeltekst maakt het dichtheidsverschil gemakkelijk zichtbaar.

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

    // Dia 2: toon elk derde label, maar behoud een tic-markering voor elke categorie.
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

**Automatische spatiëring (dia 1):** In deze weergave wordt elk tweede categorie‑label weergegeven en wordt op twee regels doorbroken. Het automatische resultaat kan variëren afhankelijk van diagramgrootte, lettertypen en de renderer.

![Automatische categorie‑labelspatiëring met alle 24 kolommen zichtbaar](category-axis-automatic.png)

**Handmatige spatiëring (dia 2):** Elk derde label wordt op één regel weergegeven, terwijl tic‑markeringen behouden blijven bij elk categorie‑interval. Alle 24 kolommen, inclusief die zonder labels, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt de automatische weergave zoals hierboven.

![Handmatig categorie‑labelinterval van drie met alle 24 kolommen zichtbaar](category-axis-manual.png)

### **Kies de juiste as en het juiste interval**

Gebruik dit categorie‑aantal interval voor een tekst‑categorie‑as, zoals de categorie‑as van een kolom‑, lijn‑, gebied- of staafdiagram. In een kolomdiagram is dit de horizontale as. In een horizontale staafdiagram is de categorie‑as verticaal, dus pas deze instellingen toe op de as die wordt geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Tic‑mark‑spatiëring geldt ook voor een reeks‑as in diagrammen die die hebben.

Gebruik de categorie‑labelspatiëring niet om de numerieke schaal van een waarde‑as in te stellen. Op een waarde‑as specificeert [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) een verschil in waarden: bijvoorbeeld, een hoofd­eenheid van `10` produceert tics op 0, 10, 20, enzovoort wanneer de as bij nul begint. Een categorie‑labelinterval van `3` telt in plaats daarvan categorie‑posities, ongeacht hun gegevenswaarden. Spreidings‑ en bubbel‑diagrammen gebruiken waarde‑assen in plaats van een tekst‑categorie‑as. Voor een datum‑as, gebruik tijd‑gebaseerde hoofd­eenheden en schalen zoals beschreven in [Change a Category Axis](#change-a-category-axis).

## **Datumopmaak voor categorie‑as‑waarden instellen**

Het voorbeeld vervangt de standaarddiagramgegevens door vier jaarlijkse waarden. Datums worden opgeslagen als OLE Automation‑serienummers in het eerste werkblad (index `0`), berekend als het aantal dagen sinds 30 december 1899 voor deze datums. Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) met `CategoryAxisType.Date`, roep [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) aan met `false`, en geef `yyyy` door aan [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) zodat de categorie‑labels viercijferige jaartallen weergeven, onafhankelijk van de celopmaak.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
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
## **Rotatiehoek voor een diagram‑as‑titel instellen**

Roep [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) aan met `true` op de verticale as, geef de titeltekst op, en gebruik [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) om de titel te roteren. De hoek wordt gemeten in graden; dit voorbeeld slaat een kolomdiagram op met de titel van de waarde‑as geroteerd met 90 graden.

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
## **Aspositie op een categorie‑ of waarde‑as instellen**

Gebruik [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) om te bepalen of de waarde‑as de categorie‑as tussen categorieën of op categorie‑tics kruist. Deze instelling geldt voor categorie‑assen. Het voorbeeld stelt dit in op `true` op de horizontale categorie‑as van een kolomdiagram en slaat het resultaat op.

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
## **Weergave‑eenheid op een diagramwaarde‑as instellen**

Gebruik [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) om de labels op een waarde‑as te schalen zonder de onderliggende gegevens te wijzigen. Met [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) ingesteld op `Millions` wordt een waarde van 60.000.000 weergegeven als 60. Het voorbeeld maakt een kolomdiagram en past de miljoenen‑weergave‑eenheid toe op de verticale as.

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
## **Logaritmische waarde‑as configureren**

Een logaritmische waarde‑as is nuttig wanneer positieve waarden over meerdere orden van grootte lopen. Bijvoorbeeld, een service kan 10, 100, 1.000, 10.000 en 100.000 verzoeken ontvangen over vijf periodes. Op een lineaire schaal staan de kleinere waarden dicht bij elkaar rond nul. Een logaritmische schaal maakt hun relatieve groei makkelijker te vergelijken: gelijke afstanden vertegenwoordigen gelijke verhoudingen in plaats van gelijke verschillen.

Roep [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) aan met `true` op de waarde‑as en gebruik [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) om de basis te kiezen. Dit wijzigt hoe de bestaande waarden worden weergegeven; het verandert de gegevens niet of voegt geen logaritmische trendlijn toe. Een trendlijn vertegenwoordigt een aangepaste relatie in de gegevens en is een afzonderlijke functie.

### **Kies de waarde‑as en de basis**

Voor een lijn‑ of kolomdiagram wordt de waarde‑as teruggegeven door [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Voor een horizontale staafdiagram wordt deze teruggegeven door [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Spreidings‑ en bubbel‑diagrammen hebben twee waarde‑assen, dus kies de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas logaritmische schaal niet toe op een categorie‑as.

De standaard logaritmische basis is `10`. Voor PPTX‑diagrammen gebruikt u een basis van `2` tot en met `1000`, inclusief; fractionele basissen zoals `2,5` worden ook ondersteund. Met basis `10` zijn opeenvolgende machten zoals 10, 100, 1.000 en 10.000 gelijkmatig verdeeld.

### **Lineaire versus logaritmische schaal vergelijken**

Het volgende zelfstandige voorbeeld maakt een lijndiagram met de vijf request‑aantallen op de eerste dia, kloont die dia vervolgens en schakelt een logaritmische waarde‑as met basis‑10 in op de tweede. Beide dia's behouden dezelfde gegevens.

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

**Lineaire schaal (dia 1):** Gelijke verticale afstanden vertegenwoordigen gelijke verschillen in request‑aantallen. De grootste waarde domineert het diagram, waardoor de kleinere waarden moeilijk te onderscheiden zijn.

![Lijndiagram in PowerPoint met vijf request‑aantallen op een lineaire waarde‑as](value-axis-linear.png)

**Logaritmische schaal (dia 2):** Gelijke verticale afstanden vertegenwoordigen gelijke verhoudingen. Elke periode heeft tien keer zoveel requests als de vorige, dus de punten vormen een rechte stijgende lijn op de basis‑10 schaal. De as‑labels tonen nog steeds de oorspronkelijke request‑aantallen.

![Dezelfde vijf request‑aantallen in PowerPoint op een logaritmische waarde‑as met basis‑10](value-axis-logarithmic.png)

### **Omgaan met nul‑ en negatieve waarden**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de gegevens voordat u deze inschakelt. Als nul‑ of negatieve waarden betekenisvol zijn, behoud dan een lineaire schaal of toon ze apart. Als het weglaten van die waarden passend is voor de analyse, leg dan de reden uit. Vervang ze niet stilletjes door kleine positieve getallen, omdat dat de betekenis van de gegevens verandert. Elke handmatig geconfigureerde minimum‑ of maximumwaarde voor een logaritmische as moet ook positief zijn.

## **FAQ**
**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**  
Gebruik [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) om het kruising‑gedrag te selecteren. Om een numerieke kruising‑waarde op te geven, gebruik [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Deze instellingen laten u de as‑kruising verplaatsen naar een geschikte basislijn.

**Hoe kan ik tic‑labels positioneren ten opzichte van de as?**  
Roep [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) aan met behulp van [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` of `None`. Om de tic‑markeringen zelf te regelen, gebruik [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) of [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); deze staan los van de label‑positionering.