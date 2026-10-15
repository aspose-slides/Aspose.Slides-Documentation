---
title: Přizpůsobení os grafu v prezentacích na Androidu
linktitle: Osa grafu
type: docs
url: /cs/androidjava/chart-axis/
keywords:
- osa grafu
- svislá osa
- vodorovná osa
- přizpůsobení osy
- manipulace s osou
- správa osy
- vlastnosti osy
- maximální hodnota
- minimální hodnota
- čára osy
- formát data
- název osy
- pozice osy
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Objevte, jak pomocí Aspose.Slides pro Android a Javy přizpůsobit osy grafů v PowerPoint prezentacích pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu pomocí Aspose.Slides pro Android prostřednictvím Javy. Pokrývá vypočítané hodnoty os, výměnu řádků a sloupců grafu, viditelnost os, intervaly popisků kategorií a značek os, datumové kategorie a formátování, otáčení názvu, umístění os, zobrazovací jednotky a logaritmické škálování.

## **Získání maximálních hodnot na svislé ose grafů**

Vytvořte [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) a přidejte plošný graf s výchozími daty. Před načtením vypočítaných hodnot os zavolejte [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) , aby byl vzhled grafu aktuální.

Přečtěte [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) a [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) pro limity os a [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) a [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) pro intervaly značek. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) a [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) poskytují časové jednotky, které jsou relevantní pro datumové osy. Příklad ukládá tyto hodnoty do lokálních proměnných a ukládá graf.

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

## **Prohození dat mezi osami**

Použijte [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) k výměně rolí řad a kategorií v datech grafu. Každá dřívější kategorie se stane řadou a každá dřívější řada se stane kategorií. Tím se změní způsob seskupování dat; neprohodí to vodorovnou a svislou osu. Příklad používá [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) k navázání výchozích dat na `Sheet1!A1:D5`, včetně řádku záhlaví a sloupce kategorií, před výměnou řádků a sloupců. Uloží graf se čtyřmi řadami a třemi kategoriemi.

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

## **Obrácení pořadí vykreslování osy**

Použijte [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) k obrácení kategorie nebo hodnotové osy. Například vodorovný sloupcový graf může zobrazovat fáze projektu shora dolů ve stejném pořadí jako v listu: Plánování, Vývoj, Testování. Obrácení osy změní směr vykreslování; neseřadí to ani nepřeskupí data sešitu. Naopak [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) vymění role řad a kategorií.

Následující příklad vytvoří vodorovný sloupcový graf se třemi fázemi a jednou řadou. Uloží prezentaci se třemi snímky: normální pořadí, obrácené kategorie a obrácené hodnoty. Každá kopie používá stejné datové sady a na každé kopii je obrácena jen jedna osa.

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

    // Snímek 2: zobrazit první kategorii nahoře.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Udržet vodorovnou hodnotovou osu ve spodní části.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // Snímek 3: obrátit pouze vodorovnou číselnou stupnici.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Obrácení osy může také přesunout kolmé osy na opačnou stranu grafu. [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) určuje, kde se druhá osa protíná s konfigurovanou osou. Na snímku 2, volání s `CrossesType.Maximum` na obrácené ose kategorií udrží vodorovnou hodnotovou osu ve spodní části. Pro konkrétní průsečík použijte [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Při změně směru zkontrolujte nastavení průsečíků, zejména pokud má graf již vlastní průsečík. Zavolejte `setPlotOrderReversed` s `false` pro obnovení normálního směru vykreslování; nastavení průsečíků jsou samostatná.

| Normální pořadí (snímek 1) | Obrácené kategorie (snímek 2) | Obrácené hodnoty (snímek 3) |
| --- | --- | --- |
| ![Vodorovný sloupcový graf s normálním pořadím kategorií a hodnotových os](axis-order-normal.png) | ![Vodorovný sloupcový graf s kategoriemi zobrazenými shora dolů](axis-order-categories-reversed.png) | ![Vodorovný sloupcový graf s obrácenou hodnotovou osou a nulou vpravo](axis-order-values-reversed.png) |
| Kategorie běží odspodu nahoru; hodnoty rostou zleva doprava. | Plánování, Vývoj a Testování běží shora dolů. Hodnoty a pořadí řádků sešitu zůstávají beze změny. | Kategorie zachovávají své normální pořadí; hodnoty rostou zprava doleva. Osa kategorií se protíná v nule vpravo. |

## **Zakázání svislé osy u čarových grafů**

Zavolejte [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) s `false` na svislé ose, aby byla skryta. Příklad vytvoří čarový graf s výchozími daty a uloží jej se skrytou svislou osou.

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

## **Zakázání vodorovné osy u čarových grafů**

Zavolejte [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) s `false` na vodorovné ose, aby byla skryta. Příklad vytvoří čarový graf s výchozími daty a uloží jej se skrytou vodorovnou osou.

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

## **Změna osy kategorie**

Použijte [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) k výběru datumové nebo textové kategorie osy. Tento příklad vyžaduje `ExistingChart.pptx`, kde je graf první tvarem na prvním snímku a buňky kategorií obsahují číselné datumové hodnoty Excelu. Změní vodorovnou osu na datumovou osu. Voláním [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) s `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) s `1` a [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) s `TimeUnitType.Months` umístí hlavní značky v měsíčních intervalech.

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

## **Řízení intervalů popisků osy kategorií**

Když má graf mnoho kategorií, snižte počet viditelných popisků osy, aniž byste odstraňovali kategorie nebo datové body. Zavolejte [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) s `false` a poté předáte požadovaný interval kategorií metodě [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Pro textové kategorie v jejich normálním pořadí se počítá od první kategorie:

| Interval | Popisky zobrazené v příkladu |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Interval `3` zobrazuje každý třetí popisek a mezi zobrazenými popisky skryje dva popisky. Neodstraňuje to odpovídající sloupce. Automatické rozestupy volí interval podle dostupného prostoru; nemusí nutně zobrazit každý popisek.

Značky os mají samostatné ovládání. Zavolejte [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) s `false` a použijte [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) k nastavení jejich intervalu. Například `1` ponechá značku na každém intervalu kategorií, zatímco popisky se zobrazují jen každou třetí kategorii. Použijte [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) s viditelným stylem, abyste mohli výsledek vidět. Opětovné volání automatického nastavení s `true` umožní grafu znovu zvolit tento interval.

Následující samostatný příklad vytvoří 24 kategorií a jednu řadu, poté uloží tři snímky do `CategoryAxisIntervals.pptx`: automatické rozestupy, ruční rozestupy popisků s nezávislými značkami a obnovené automatické rozestupy. Obě kopie zachovávají původní data grafu. Vstupní prezentace není vyžadována. Vodorovný text popisků usnadňuje vidět rozdíl v hustotě.

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

    // Snímek 2: zobrazit každou třetí popisku, ale zachovat značku pro každou kategorii.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Snímek 3: nechat graf znovu zvolit oba intervaly.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatické rozestupy (snímek 1):** V tomto zobrazení je každá druhá kategorie zobrazena a zalamována do dvou řádků. Automatický výsledek se může lišit podle velikosti grafu, fontů a vykreslovacího nástroje.

![Automatické rozestupy popisků kategorií se všemi 24 sloupci viditelnými](category-axis-automatic.png)

**Ruční rozestupy (snímek 2):** Každý třetí popisek je zobrazen v jednom řádku, zatímco značky zůstávají na každém intervalu kategorií. Všechny 24 sloupce, včetně těch bez popisků, zůstávají viditelné se stejnými hodnotami. Snímek 3 obnovuje automatický vzhled uvedený výše.

![Manuální interval popisků kategorií po třech se všemi 24 sloupci viditelnými](category-axis-manual.png)

### **Zvolte správnou osu a interval**

Použijte tento interval počtu kategorií pro textovou osu kategorií, například osu kategorií sloupcového, čarového, plošného nebo pruhového grafu. V sloupcovém grafu je to vodorovná osa. Ve vodorovném pruhovém grafu je osa kategorií svislá, proto použijte tato nastavení na osu vrácenou metodou [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Rozestupy značek se také vztahují na osu řad v grafech, které ji mají.

Nepoužívejte rozestupy popisků kategorií k nastavení číselné škály hodnotové osy. Na hodnotové ose [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) určuje rozdíl mezi hodnotami: například hlavní jednotka `10` vytvoří značky na 0, 10, 20 atd., pokud osa začíná nulou. Interval popisků kategorií `3` počítá pozice kategorií bez ohledu na jejich datové hodnoty. Scatter a bublinové grafy používají hodnotové osy místo textové osy kategorií. Pro datumovou osu použijte časově založené hlavní jednotky a měřítka, jak je popsáno v [Change a Category Axis](#change-a-category-axis).

## **Nastavení formátu data pro hodnoty osy kategorií**

Příklad nahradí výchozí data grafu čtyřmi ročními hodnotami. Data jsou uložena jako sériová čísla OLE Automation v první pracovní tabulce (index `0`), vypočítaná jako počet dnů od 30. prosince 1899. Oba kalendáře používají UTC a jsou vymazány před nastavením dat, aby letní čas a aktuální čas dne neovlivnily výpočet. Použijte [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) s `CategoryAxisType.Date`, zavolejte [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) s `false` a předávejte `yyyy` metodě [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-), aby popisky kategorií zobrazovaly čtyřciferné roky nezávisle na formátování buňky.

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

## **Nastavení úhlu otočení názvu osy grafu**

Zavolejte [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) s `true` na svislé ose, zadejte text názvu a použijte [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) k otočení názvu. Úhel se měří ve stupních; tento příklad uloží sloupcový graf s názvem hodnotové osy otočeným o 90 stupňů.

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

## **Nastavení pozice osy na ose kategorie nebo hodnoty**

Použijte [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) k nastavení, zda hodnotová osa protíná osu kategorií mezi kategoriemi nebo u značek kategorií. Toto nastavení se vztahuje na osy kategorií. Příklad nastaví hodnotu na `true` na vodorovné ose kategorií sloupcového grafu a uloží výsledek.

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

## **Nastavení zobrazovací jednotky na hodnotové ose grafu**

Použijte [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) k škálování popisků na hodnotové ose bez změny podkladových dat. S nastaveným [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) na `Millions` se hodnota 60 000 000 zobrazí jako 60. Příklad vytvoří sloupcový graf a použije jednotku milionů na jeho svislé ose.

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

## **Konfigurace logaritmické hodnotové osy**

Logaritmická hodnotová osa je užitečná, když kladné hodnoty zasahují několik řádů velikosti. Například služba může během pěti období přijímat 10, 100, 1 000, 10 000 a 100 000 požadavků. Na lineární škále jsou menší hodnoty blízko u sebe u nuly. Logaritmická škála usnadňuje porovnání jejich relativního růstu: stejné vzdálenosti představují stejné poměry, nikoli stejné rozdíly.

Zavolejte [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) s `true` na hodnotové ose a použijte [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) k výběru základu. Tím se změní způsob, jakým jsou existující hodnoty zobrazovány; nemění to data ani nepřidává logaritmickou regresní čáru. Regresní čára představuje vhodnou souvislost v datech a je samostatnou funkcí.

### **Zvolte hodnotovou osu a základ**

U čarového nebo sloupcového grafu je hodnotová osa vrácena metodou [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). U vodorovného pruhového grafu je vrácena metodou [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Scatter a bublinové grafy mají dvě hodnotové osy, takže vyberte vodorovnou osu pro hodnoty X, svislou osu pro hodnoty Y nebo obě. Nepoužívejte logaritmické škálování na osu kategorií.

Výchozí logaritmický základ je `10`. Pro PPTX grafy použijte základ od `2` do `1000` včetně; podporovány jsou také zlomkové základy jako `2.5`. Se základem `10` jsou následující mocniny 10, 100, 1 000 a 10 000 rovnoměrně rozmístěny.

### **Porovnání lineárního a logaritmického škálování**

Následující samostatný příklad vytvoří čarový graf s pěti počty požadavků na prvním snímku, poté klonuje tento snímek a na druhém povolí logaritmickou hodnotovou osu s bází 10. Oba snímky zachovávají stejná data.

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

    // Udržet první snímek lineární a změnit jen měřítko hodnotové osy kopie.
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

**Lineární škála (snímek 1):** Stejné svislé vzdálenosti představují stejné rozdíly v počtech požadavků. Největší hodnota dominuje grafu, což ztěžuje rozlišování menších hodnot.

![Čarový graf v PowerPointu zobrazující pět požadavků na lineární hodnotové ose](value-axis-linear.png)

**Logaritmická škála (snímek 2):** Stejné svislé vzdálenosti představují stejné poměry. Každé období má desetkrát více požadavků než předchozí, takže body tvoří přímou rostoucí linii na škále s bází 10. Popisky os stále ukazují původní počty požadavků.

![Samo pět požadavků v PowerPointu na logaritmické hodnotové ose s bází 10](value-axis-logarithmic.png)

### **Zpracování nulových a záporných hodnot**

Logaritmická škála může zobrazovat pouze striktně kladné hodnoty. Zkontrolujte data před jejím zapnutím. Pokud jsou nuly nebo záporné hodnoty významné, zachovejte lineární škálu nebo je zobrazte zvlášť. Pokud je vyloučení těchto hodnot vhodné pro analýzu, vysvětlete vynechání. Nepřepisujte je tiše malými kladnými čísly, protože to mění význam dat. Jakýkoli ručně nastavený minimum nebo maximum pro logaritmickou osu musí být také kladné.

## **Často kladené otázky**

**Jak nastavit hodnotu, při které se jedna osa protíná s druhou (průsečík osy)?**  
Použijte [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) k výběru chování průsečíku. Pro zadání číselné hodnoty průsečíku použijte [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Tato nastavení vám umožní přesunout průsečík osy na vhodnou referenční čáru.

**Jak mohu umístit popisky značek relativně k ose?**  
Zavolejte [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) pomocí [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` nebo `None`. Pro ovládání samotných značek použijte [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) nebo [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); jsou oddělené od umístění popisků.