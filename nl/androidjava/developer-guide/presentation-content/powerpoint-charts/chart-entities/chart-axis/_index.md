---
title: Grafiekassen aanpassen in presentaties op Android
linktitle: Grafiekas
type: docs
url: /nl/androidjava/chart-axis/
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
- as-lijn
- datumnotatie
- as-titel
- as-positie
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor Android via Java kunt gebruiken om grafiekassen in PowerPoint-presentaties aan te passen voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u grafiekassen kunt aanpassen met Aspose.Slides voor Android via Java. Het behandelt berekende aswaarden, het wisselen van rijen en kolommen van een grafiek, aszichtbaarheid, categorie‑label‑ en tick‑mark‑intervallen, datumcategorieën en -opmaak, titelrotatie, aspositionering, weergave‑eenheden en logaritmische schaal.

## **De maximale waarden op de verticale as van grafieken ophalen**

Maak een [Presentatie](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) en voeg een gebiedsgrafiek toe met standaardgegevens. Roep [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) aan voordat u berekende aswaarden leest, zodat de grafieklayout up‑to‑date is.

Lees [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) en [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) om de aslimieten te krijgen, en [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) en [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) voor de tick‑intervallen. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) en [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) geven tijdseenheid‑schalen, die relevant zijn voor datumassen. Het voorbeeld slaat deze waarden op in lokale variabelen en slaat de grafiek op.

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

Gebruik [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) om de rollen van series en categorieën in grafiekgegevens te verwisselen. Elke voormalige categorie wordt een serie, en elke voormalige serie wordt een categorie. Dit verandert hoe de gegevens worden gegroepeerd; het wisselt niet de horizontale en verticale assen uit. Het voorbeeld gebruikt [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) om de standaardgegevens te binden aan `Sheet1!A1:D5`, inclusief de koprij en categorie‑kolom, voordat rijen en kolommen worden verwisseld. Het slaat een grafiek op met vier series en drie categorieën.

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

## **De verticale as uitschakelen voor lijngrafieken**

Roep [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) met `false` aan op de verticale as om deze te verbergen. Het voorbeeld maakt een lijngrafiek met standaardgegevens en slaat deze op met de verticale as verborgen.

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

## **De horizontale as uitschakelen voor lijngrafieken**

Roep [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) met `false` aan op de horizontale as om deze te verbergen. Het voorbeeld maakt een lijngrafiek met standaardgegevens en slaat deze op met de horizontale as verborgen.

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

## **Een categorie-as wijzigen**

Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) om een datum‑ of tekst‑categorie‑as te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een grafiek als het eerste vorm op de eerste dia en categorie‑cellen die numerieke Excel‑datumnummers bevatten. Het verandert de horizontale as in een datum‑as. Het aanroepen van [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) met `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) met `1`, en [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) met `TimeUnitType.Months` plaatst hoofd‑ticks op één‑maand‑intervallen.

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

## **Intervallen voor categorie‑as‑labels beheren**

Wanneer een grafiek veel categorieën heeft, kunt u het aantal zichtbare as‑labels verminderen zonder categorieën of gegevenspunten te verwijderen. Roep [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) met `false` aan, en geef vervolgens het gewenste categorie‑interval door aan [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Voor tekst‑categorieën in hun normale volgorde begint de telling bij de eerste categorie:

| Interval | Labels die in het voorbeeld worden weergegeven |
| --- | --- |
| `1` | Categorie 1, Categorie 2, Categorie 3, ... Categorie 24 |
| `2` | Categorie 1, Categorie 3, Categorie 5, ... Categorie 23 |
| `3` | Categorie 1, Categorie 4, Categorie 7, ... Categorie 22 |

Een interval van `3` toont elk derde label, waarbij twee labels tussen de getoonde labels verborgen blijven. Het verwijdert niet de overeenkomstige kolommen. Automatische spatiëring kiest een interval op basis van de beschikbare ruimte; het toont niet per‑se elk label.

Tick‑marks hebben afzonderlijke besturingselementen. Roep [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) met `false` aan en gebruik [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) om hun interval in te stellen. Bijvoorbeeld, `1` houdt een tick‑mark bij elk categorie‑interval terwijl labels slechts elke derde categorie verschijnen. Gebruik [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) met een zichtbare stijl zodat u het resultaat kunt zien. Het opnieuw instellen van een van de automatische‑spacing‑methodes op `true` laat de grafiek het interval opnieuw kiezen.

Het volgende zelf‑containende voorbeeld maakt 24 categorieën en één serie, vervolgens slaat het drie dia's op in `CategoryAxisIntervals.pptx`: automatische spatiëring, handmatige label‑spatiëring met onafhankelijke tick‑marks, en herstelde automatische spatiëring. De twee exemplaren behouden de oorspronkelijke grafiekgegevens. Er is geen invoer‑presentatie vereist. Horizontale labeltekst maakt het verschil in dichtheid gemakkelijk te zien.

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

    // Dia 2: toon elk derde label, maar behoud een tick mark voor elke categorie.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Dia 3: laat de grafiek beide intervallen opnieuw kiezen.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatische spatiëring (dia 1):** Bij deze weergave wordt elk tweede categorielabel weergegeven en wordt het over twee regels verdeeld. Het automatische resultaat kan variëren afhankelijk van de grafiekgrootte, lettertypen en de renderer.

![Automatische categorie‑label‑spatiëring met alle 24 kolommen zichtbaar](category-axis-automatic.png)

**Handmatige spatiëring (dia 2):** Elk derde label wordt op één regel weergegeven, terwijl de tick‑marks behouden blijven bij elk categorie‑interval. Alle 24 kolommen, inclusief die zonder labels, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt de automatische weergave zoals hierboven getoond.

![Handmatige categorie‑label‑interval van drie met alle 24 kolommen zichtbaar](category-axis-manual.png)

### **Kies de juiste as en interval**

Gebruik dit categorie‑aantal‑interval voor een tekst‑categorie‑as, zoals de categorie‑as van een kolom‑, lijn‑, gebieds‑ of staafgrafiek. In een kolomgrafiek is dit de horizontale as. In een horizontale staafgrafiek is de categorie‑as verticaal, dus pas deze instellingen toe op de as die wordt geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Tick‑mark‑spatiëring is ook van toepassing op een serie‑as in grafieken die er een hebben.

Gebruik geen categorie‑label‑spatiëring om de numerieke schaal van een waarde‑as in te stellen. Op een waarde‑as geeft [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) een verschil in waarden aan: bijvoorbeeld, een hoofd‑eenheid van `10` produceert ticks bij 0, 10, 20, enzovoort wanneer de as bij nul begint. Een categorie‑label‑interval van `3` telt daarentegen categorie‑posities, ongeacht hun gegevenswaarden. Spreidings‑ en bubbelgrafieken gebruiken waarde‑assen in plaats van een tekst‑categorie‑as. Voor een datum‑as gebruikt u tijd‑gebaseerde hoofd‑eenheden en schalen zoals beschreven in [Change a Category Axis](#change-a-category-axis).

## **Datumnotatie voor categorie‑as‑waarden instellen**

Het voorbeeld vervangt de standaardgrafiekgegevens door vier jaarlijkse waarden. Datums worden opgeslagen als OLE‑Automation‑serienummers in het eerste werkblad (index `0`), berekend als het aantal dagen sinds 30 december 1899, voor deze datums. Beide kalenders gebruiken UTC en worden gewist voordat de datums worden ingesteld zodat zomertijd en de huidige tijd van de dag de berekening niet beïnvloeden. Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) met `CategoryAxisType.Date`, roep [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) met `false` aan, en geef `yyyy` door aan [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) zodat de categorie‑labels viercijferige jaartallen tonen, onafhankelijk van de celopmaak.

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

## **Rotatie‑hoek voor een grafiek‑as‑titel instellen**

Roep [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) met `true` aan op de verticale as, geef de titeltekst op, en gebruik [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) om de titel te roteren. De hoek wordt gemeten in graden; dit voorbeeld slaat een kolomgrafiek op met de waarde‑as‑titel geroteerd met 90 graden.

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

Gebruik [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) om te bepalen of de waarde‑as de categorie‑as tussen categorieën of op categorie‑tick‑marks kruist. Deze instelling geldt voor categorie‑assen. Het voorbeeld stelt dit in op `true` op de horizontale categorie‑as van een kolomgrafiek en slaat het resultaat op.

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

## **Weergave‑eenheid op een grafiek‑waarde‑as instellen**

Gebruik [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) om de labels op een waarde‑as te schalen zonder de onderliggende gegevens te wijzigen. Met [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) ingesteld op `Millions` wordt een waarde van 60 000 000 weergegeven als 60. Het voorbeeld maakt een kolomgrafiek en past de miljoenen‑weergave‑eenheid toe op de verticale as.

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

Een logaritmische waarde‑as is nuttig wanneer positieve waarden zich over meerdere orde‑van‑grootte reiken. Bijvoorbeeld, een service kan 10, 100, 1 000, 10 000 en 100 000 verzoeken ontvangen over vijf perioden. Op een lineaire schaal staan de kleinere waarden dicht bij nul. Een logaritmische schaal maakt hun relatieve groei gemakkelijker te vergelijken: gelijke afstanden vertegenwoordigen gelijke verhoudingen in plaats van gelijke verschillen.

Roep [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) met `true` aan op de waarde‑as en gebruik [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) om de basis te kiezen. Dit verandert hoe de bestaande waarden worden weergegeven; het wijzigt niet de gegevens of voegt een logaritmische trendlijn toe. Een trendlijn vertegenwoordigt een aangepaste relatie in de gegevens en is een aparte functionaliteit.

### **Kies de waarde‑as en basis**

Voor een lijn‑ of kolomgrafiek wordt de waarde‑as geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Voor een horizontale staafgrafiek wordt deze geretourneerd door [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Spreidings‑ en bubbelgrafieken hebben twee waarde‑assen, dus kies de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas geen logaritmische schaal toe op een categorie‑as.

De standaard logaritmische basis is `10`. Voor PPTX‑grafieken kunt u een basis gebruiken van `2` tot en met `1000`, inclusief; fractionele bases zoals `2.5` worden ook ondersteund. Met basis `10` zijn opeenvolgende machten zoals 10, 100, 1 000 en 10 000 gelijkmatig verdeeld.

### **Lineaire en logaritmische schaal vergelijken**

Het volgende zelf‑containende voorbeeld maakt een lijngrafiek met de vijf verzoek‑aantallen op de eerste dia, kloont die dia vervolgens en schakelt een logaritmische waarde‑as met basis 10 in op de tweede. Beide dia's behouden dezelfde gegevens.

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

    // Houd de eerste dia lineair en wijzig alleen de schaal van de waarde‑as van de kopie.
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

**Lineaire schaal (dia 1):** Gelijke verticale afstanden vertegenwoordigen gelijke verschillen in het aantal verzoeken. De grootste waarde domineert de grafiek, waardoor de kleinere waarden moeilijk te onderscheiden zijn.

![Lijngrafiek in PowerPoint die vijf verzoek‑aantallen weergeeft op een lineaire waarde‑as](value-axis-linear.png)

**Logaritmische schaal (dia 2):** Gelijke verticale afstanden vertegenwoordigen gelijke verhoudingen. Elke periode heeft tien keer zoveel verzoeken als de vorige, waardoor de punten een rechte stijgende lijn vormen op de base‑10‑schaal. De as‑labels tonen nog steeds de oorspronkelijke aantallen verzoeken.

![Dezelfde vijf verzoek‑aantallen in PowerPoint op een base‑10 logaritmische waarde‑as](value-axis-logarithmic.png)

### **Nul‑ en negatieve waarden behandelen**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de gegevens voordat u deze inschakelt. Als nul of negatieve waarden betekenisvol zijn, houd dan een lineaire schaal aan of toon ze apart. Als het weglaten van die waarden passend is voor de analyse, leg dan de omissie uit. Vervang ze niet stilletjes door kleine positieve getallen, omdat dat de betekenis van de gegevens verandert. Elke handmatig geconfigureerde minimum‑ of maximumwaarde voor een logaritmische as moet eveneens positief zijn.

## **FAQ**

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Gebruik [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) om het kruisgedrag te selecteren. Om een numerieke kruiswaarde op te geven, gebruik [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Deze instellingen laten u de as‑kruising naar een geschikte basislijn verplaatsen.

**Hoe kan ik tick‑labels positioneren ten opzichte van de as?**

Roep [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) aan met gebruik van [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` of `None`. Om de tick‑marks zelf te regelen, gebruik [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) of [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); deze staan los van de label‑positionering.