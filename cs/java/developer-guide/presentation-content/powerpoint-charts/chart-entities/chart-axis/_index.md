---
title: Přizpůsobení os grafu v prezentacích pomocí Javy
linktitle: Osa grafu
type: docs
url: /cs/java/chart-axis/
keywords:
- osa grafu
- vertikální osa
- horizontální osa
- přizpůsobit osu
- manipulovat osou
- spravovat osu
- vlastnosti osy
- maximální hodnota
- minimální hodnota
- čára osy
- formát data
- název osy
- umístění osy
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Objevte, jak pomocí Aspose.Slides pro Javu přizpůsobit osy grafu v PowerPoint prezentacích pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu pomocí Aspose.Slides pro Java. Pokrývá vypočítané hodnoty os, přepínání řádků a sloupců grafu, viditelnost os, intervaly štítků kategorií a značek, datové kategorie a formátování, otáčení názvu, umístění os, zobrazovací jednotky a logaritmické škálování.

## **Získání maximálních hodnot na svislé ose grafů**

Vytvořte [Prezentaci](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) a přidejte plošný graf s výchozími daty. Zavolejte [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) před čtením vypočítaných hodnot os, aby byl rozvržení grafu aktuální.

Přečtěte [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) a [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) pro limity os a [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) a [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) pro intervaly značek. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) a [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) poskytují časové jednotky, které jsou relevantní pro datové osy. Příklad uloží tyto hodnoty do lokálních proměnných a uloží graf.

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

Použijte [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) k výměně rolí řad a kategorií v datech grafu. Každá předchozí kategorie se stane řadou a každá předchozí řada se stane kategorií. Toto mění způsob seskupení dat; neprohodí vodorovnou a svislou osu. Příklad používá [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) k navázání výchozích dat na `Sheet1!A1:D5` včetně řádku záhlaví a sloupce kategorií, před přepnutím řádků a sloupců. Uloží graf se čtyřmi řadami a třemi kategoriemi.

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

Použijte [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) k obrácení kategoriové nebo hodnotové osy. Například vodorovný sloupcový graf může zobrazovat fáze projektu shora dolů ve stejném pořadí jako list: Plánování, Vývoj, Testování. Obrácení osy mění směr vykreslování; neradí ani nepřeskupuje data sešitu. Naopak [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) vyměňuje role řad a kategorií.

Následující příklad vytvoří vodorovný sloupcový graf se třemi fázemi a jednou řadou. Uloží prezentaci se třemi snímky: normální pořadí, obrácené kategorie a obrácené hodnoty. Každá kopie používá stejný dataset a na každé kopii je obrácena jen jedna osa.

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

Obrácení osy může také přesunout kolmé osy na opačnou stranu grafu. [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) řídí, kde se druhá osa protíná s konfigurovanou osou. Ve snímku 2, volání s `CrossesType.Maximum` na obrácené kategoriové ose udržuje vodorovnou hodnotovou osu ve spodní části. Pro konkrétní protínací bod použijte [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Zkontrolujte nastavení protínání při změně směru, zejména pokud má graf již vlastní bod protínání. Zavolejte `setPlotOrderReversed` s `false` pro obnovení normálního směru vykreslování; nastavení protínání jsou samostatná.

| Normální pořadí (snímek 1) | Obrácené kategorie (snímek 2) | Obrácené hodnoty (snímek 3) |
| --- | --- | --- |
| ![Vodorovný pruhový graf s normálním pořadím kategorií a hodnotové osy](axis-order-normal.png) | ![Vodorovný pruhový graf s kategoriemi zobrazenými shora dolů](axis-order-categories-reversed.png) | ![Vodorovný pruhový graf s obrácenou hodnotovou osou a nulou vpravo](axis-order-values-reversed.png) |
| Kategorie běží od spodu k vrchu; hodnoty rostou zleva doprava. | Plánování, Vývoj a Testování běží shora dolů. Hodnoty a pořadí řádků sešitu zůstávají beze změny. | Kategorie si uchovávají své normální pořadí; hodnoty rostou zprava doleva. Osa kategorií protíná v nule vpravo. |

## **Zakázání svislé osy pro čárové grafy**

Zavolejte [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) s `false` na svislé ose, aby se skryla. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou svislou osou.

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

## **Zakázání vodorovné osy pro čárové grafy**

Zavolejte [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) s `false` na vodorovné ose, aby se skryla. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou vodorovnou osou.

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

## **Změna kategoriové osy**

Použijte [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) pro výběr datové nebo textové kategoriové osy. Tento příklad vyžaduje `ExistingChart.pptx`, s grafem jako první tvarem na první snímku a buňkami kategorií obsahujícími číselné Excel datumové hodnoty. Mění vodorovnou osu na datovou osu. Volání [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) s `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) s `1` a [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) s `TimeUnitType.Months` umístí hlavní značky na interval jednoho měsíce.

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

## **Ovládání intervalů štítků kategoriové osy**

Když má graf mnoho kategorií, snižte počet viditelných štítků os bez odebrání kategorií nebo datových bodů. Zavolejte [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) s `false` a pak předáte požadovaný interval kategorií metodě [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Pro textové kategorie v jejich normálním pořadí se číslování začíná od první kategorie:

| Interval | Štítky zobrazené v příkladu |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Category 3, … Category 24 |
| `2` | Kategorie 1, Kategorie 3, Category 5, … Category 23 |
| `3` | Kategorie 1, Category 4, Category 7, … Category 22 |

Interval `3` zobrazí každý třetí štítek, přičemž dva štítky mezi zobrazenými jsou skryté. Neodstraní to odpovídající sloupce. Automatické rozestupování volí interval na základě dostupného prostoru; nemusí zobrazit každý štítek.

Značky mají samostatné ovládání. Zavolejte [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) s `false` a použijte [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) k nastavení jejich intervalu. Například `1` ponechá značku u každého intervalu kategorie, zatímco štítky se zobrazí jen každé třetí kategorie. Použijte [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) s viditelným stylem, abyste viděli výsledek. Opětovné nastavení automatického rozestupování voláním příslušného nastavení s `true` umožní grafu zvolit tento interval znovu.

Následující samostatný příklad vytvoří 24 kategorií a jednu řadu, pak uloží tři snímky v `CategoryAxisIntervals.pptx`: automatické rozestupování, ruční rozestupování štítků s nezávislými značkami a obnovené automatické rozestupování. Obě kopie zachovávají původní data grafu. Žádná vstupní prezentace není vyžadována. Vodorovný text štítků usnadňuje rozeznání hustoty.

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

    // Snímek 2: zobrazit každý třetí štítek, ale ponechat značku pro každou kategorii.
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

**Automatické rozestupování (snímek 1):** V tomto vykreslení je zobrazen každý druhý štítek kategorie a zalomí se do dvou řádků. Automatický výsledek se může lišit podle velikosti grafu, fontů a vykreslovacího mechanismu.

![Automatické rozestupování štítků kategorií se všemi 24 sloupci viditelnými](category-axis-automatic.png)

**Manuální rozestupování (snímek 2):** Každý třetí štítek je zobrazen na jednom řádku, zatímco značky zůstávají u každého intervalu kategorie. Všechny 24 sloupce, včetně těch bez štítků, zůstávají viditelné se stejnými hodnotami. Snímek 3 obnovuje automatický vzhled uvedený výše.

![Manuální interval štítků kategorií tři se všemi 24 sloupci viditelnými](category-axis-manual.png)

### **Vyberte správnou osu a interval**

Použijte tento interval počtu kategorií pro textovou kategoriovou osu, například pro osu kategorií sloupcového, čárového, plošného nebo pruhového grafu. Ve sloupcovém grafu je to vodorovná osa. Ve vodorovném pruhovém grafu je osa kategorií vertikální, takže použijte tato nastavení na osu vrácenou metodou [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Rozestupování značek se také vztahuje na osu řady v grafech, které ji mají.

Neužívejte rozestupování štítků kategorií k nastavení číselné stupnice hodnotové osy. Na hodnotové ose [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) určuje rozdíl v hodnotách: například hlavní jednotka `10` vytvoří značky na 0, 10, 20 atd., když osa začíná nulou. Interval štítků kategorií `3` počítá pozice kategorií, nezávisle na jejich hodnotách. Rozptýlené a bublinové grafy používají hodnotové osy místo textové kategoriové osy. Pro datovou osu použijte časově založené hlavní jednotky a stupnice, jak je popsáno v [Změna kategoriové osy](#změna-kategoriové-osy).

## **Nastavení formátu data pro hodnoty kategoriové osy**

Příklad nahrazuje výchozí data grafu čtyřmi ročními hodnotami. Data jsou uložena jako sériová čísla OLE Automation v první listu (index `0`), vypočítaná jako počet dnů od 30. prosince 1899. Použijte [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) s `CategoryAxisType.Date`, zavolejte [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) s `false` a předávejte `yyyy` metodě [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-), aby se štítky kategorií zobrazovaly jako čtyřciferné roky nezávisle na formátování buňky.

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

## **Nastavení úhlu otočení názvu osy grafu**

Zavolejte [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) s `true` na svislé ose, zadejte text názvu a použijte [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) k otočení názvu. Úhel se měří ve stupních; tento příklad uloží sloupcový graf s názvem hodnotové osy otočeným o 90 stupňů.

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

## **Nastavení polohy osy na kategoriové nebo hodnotové ose**

Použijte [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) k určení, zda se hodnotová osa protíná s kategoriovou osou mezi kategoriemi nebo na značkách kategorií. Toto nastavení se vztahuje na kategoriové osy. Příklad nastaví hodnotu na `true` na vodorovné kategoriové ose sloupcového grafu a uloží výsledek.

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

Použijte [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) k měřítku štítků na hodnotové ose bez změny podkladových dat. S [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) nastaveným na `Millions` se hodnota 60 000 000 zobrazí jako 60. Příklad vytvoří sloupcový graf a použije jednotku milionů na jeho svislé ose.

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

Logaritmická hodnotová osa je užitečná, pokud kladné hodnoty pokrývají několik řádů velikosti. Například služba může během pěti období přijímat 10, 100, 1 000, 10 000 a 100 000 požadavků. Na lineárním měřítku jsou menší hodnoty těsně u nuly. Logaritmické měřítko usnadňuje srovnání relativního růstu: stejné vzdálenosti představují stejné poměry, nikoli stejné rozdíly.

Zavolejte [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) s `true` na hodnotové ose a použijte [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) k výběru základu. Toto mění způsob zobrazení existujících hodnot; nemění data ani nepřidává logaritmickou čáru trendu. Čára trendu představuje aproximaci vztahu v datech a je samostatnou funkcí.

### **Vyberte hodnotovou osu a základnu**

Pro čárový nebo sloupcový graf je hodnotová osa vrácena metodou [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Pro vodorovný pruhový graf je vrácena metodou [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Rozptýlené a bublinové grafy mají dvě hodnotové osy, takže pro X hodnoty použijte vodorovnou osu, pro Y hodnoty svislou osu, nebo obě. Logaritmické škálování nepoužívejte na kategoriové ose.

Výchozí logaritmický základ je `10`. Pro PPTX grafy použijte základ v rozmezí od `2` do `1000`, včetně; podporovány jsou i zlomkové základy jako `2.5`. S základem `10` jsou po sobě jdoucí mocniny 10, 100, 1 000 a 10 000 rovnoměrně rozmístěny.

### **Porovnání lineárního a logaritmického škálování**

Následující samostatný příklad vytvoří čárový graf s pěti počty požadavků na prvním snímku, poté klonuje tento snímek a na druhém povolí logaritmickou hodnotovou osu s bází 10. Oba snímky zachovávají stejná data.

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

    // Udržet první snímek lineární a změnit pouze měřítko hodnotové osy kopie.
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

**Lineární škála (snímek 1):** Stejné vertikální vzdálenosti představují stejné rozdíly v počtech požadavků. Největší hodnota dominuje grafu, což ztěžuje rozeznání menších hodnot.

![Čárový graf v PowerPointu zobrazující pět počtů požadavků na lineární hodnotové ose](value-axis-linear.png)

**Logaritmická škála (snímek 2):** Stejné vertikální vzdálenosti představují stejné poměry. Každé období má desetkrát více požadavků než předchozí, takže body tvoří přímou rostoucí linii na bázi 10. Popisky osy stále ukazují původní počty požadavků.

![Stejné pět požadavků v PowerPointu na logaritmické hodnotové ose s bází 10](value-axis-logarithmic.png)

### **Zpracování nulových a záporných hodnot**

Logaritmické měřítko může zobrazovat jen striktně kladné hodnoty. Zkontrolujte data před jeho zapnutím. Pokud jsou nulové nebo záporné hodnoty důležité, ponechte lineární měřítko nebo je zobrazte odděleně. Pokud je vyloučení těchto hodnot vhodné pro analýzu, vysvětlete vynechání. Není vhodné tiše je nahrazovat malými kladnými čísly, protože to mění význam dat. Jakékoli ručně nastavené minimum nebo maximum pro logaritmickou osu musí být také kladné.

## **Často kladené otázky**

**Jak nastavit hodnotu, při které se jedna osa protíná s druhou (průsečík osy)?**

Použijte [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) k výběru chování průsečíku. Pro zadání číselné hodnoty průsečíku použijte [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Tato nastavení vám umožní přesunout průsečík osy na vhodnou základní linii.

**Jak mohu umístit štítky značek relativně k ose?**

Zavolejte [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) s použitím [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` nebo `None`. Pro řízení samotných značek použijte [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) nebo [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); jsou oddělené od umístění štítků.