---
title: Přizpůsobení os grafů v prezentacích na Androidu
linktitle: Osa grafu
type: docs
url: /cs/androidjava/chart-axis/
keywords:
- osa grafu
- svislá osa
- vodorovná osa
- přizpůsobit osu
- manipulovat s osou
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
- Android
- Java
- Aspose.Slides
description: "Objevte, jak pomocí Aspose.Slides pro Android přes Java přizpůsobit osy grafů v prezentacích PowerPointu pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu pomocí Aspose.Slides pro Android přes Java. Pokrývá vypočítané hodnoty os, přepínání řádků a sloupců grafu, viditelnost os, intervaly popisků kategorií a značek tik, datumové kategorie a formátování, otáčení názvu, umístění os, jednotky zobrazení a logaritmické škálování.

## **Získání maximálních hodnot na svislé ose grafů**

Vytvořte [Prezentaci](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) a přidejte plošný graf s výchozími daty. Zavolejte [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) před načtením vypočítaných hodnot os, aby byl rozvrh grafu aktuální.

Přečtěte [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) a [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) pro limity osy a [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) a [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) pro intervaly značek. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) a [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) poskytují časové jednotkové měřítka, která jsou relevantní pro datumové osy. Příklad ukládá tyto hodnoty do lokálních proměnných a ukládá graf.

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

Použijte [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) k výměně rolí řad a kategorií v datech grafu. Každá bývalá kategorie se stane řadou a každá bývalá řada se stane kategorií. Toto mění způsob seskupování dat; neprohodí vodorovnou a svislou osu. Příklad používá [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) k navázání výchozích dat na `Sheet1!A1:D5`, včetně řádku nadpisu a sloupce kategorií, před výměnou řádků a sloupců. Uloží graf se čtyřmi řadami a třemi kategoriemi.

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

## **Zakázání svislé osy pro čárové grafy**

Zavolejte [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) s hodnotou `false` na svislé ose, aby se skryla. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou svislou osou.

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

Zavolejte [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) s hodnotou `false` na vodorovné ose, aby se skryla. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou vodorovnou osou.

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

## **Změna osy kategorií**

Použijte [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) k výběru datumové nebo textové osy kategorií. Tento příklad vyžaduje `ExistingChart.pptx`, kde je graf jako první tvar na první snímku a buňky kategorií obsahují číselné hodnoty datumů v Excelu. Mění vodorovnou osu na datumovou osu. Voláním [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) s `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) s `1` a [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) s `TimeUnitType.Months` umístíte hlavní značky v měsíčních intervalech.

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

Když má graf mnoho kategorií, snižte počet viditelných popisků osy, aniž byste odstraňovali kategorie nebo datové body. Zavolejte [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) s `false`, pak předáte požadovaný interval kategorií do [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Pro textové kategorie v jejich normálním pořadí se číslování začíná od první kategorie:

| Interval | Popisky zobrazené v příkladu |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Interval `3` zobrazí každý třetí popisek a mezi zobrazenými popisky skryje dva další. Neodstraňuje odpovídající sloupce. Automatické rozestupy volí interval na základě dostupného prostoru; nemusí zobrazit každý popisek.

Značky tik mají samostatná nastavení. Zavolejte [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) s `false` a použijte [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) k nastavení jejich intervalu. Například `1` ponechá značku tik u každého intervalu kategorie, zatímco popisky se zobrazí jen každou třetí kategorii. Použijte [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) s viditelným stylem, aby bylo vidět výsledky. Nastavením automatického rozestupu zpět na `true` necháte graf znovu zvolit tento interval.

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

    // Snímek 2: zobrazit každý třetí popisek, ale zachovat značku tik pro každou kategorii.
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

**Automatické rozestupy (snímek 1):** V tomto vykreslení se zobrazuje každý druhý popisek kategorie a přeteče do dvou řádků. Automatický výsledek se může lišit podle velikosti grafu, písma a vykreslovače.

![Automatické rozestupy popisků kategorií se všemi 24 sloupci viditelnými](category-axis-automatic.png)

**Manuální rozestupy (snímek 2):** Každý třetí popisek se zobrazí na jednom řádku, zatímco značky tik zůstávají u každého intervalu kategorie. Všechny 24 sloupců, včetně těch bez popisků, zůstávají viditelné se stejnými hodnotami. Snímek 3 obnovuje automatický vzhled zobrazený výše.

![Manuální interval popisků kategorií tři se všemi 24 sloupci viditelnými](category-axis-manual.png)

### **Vyberte správnou osu a interval**

Použijte tento interval počtu kategorií pro textovou osu kategorií, například osu kategorií sloupcového, čárového, plošného nebo pruhového grafu. Ve sloupcovém grafu je to vodorovná osa. Ve vodorovném pruhovém grafu je osa kategorií svislá, takže tato nastavení použijte na osu vrácenou metodou [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Rozestup značek tik se také vztahuje na osu řad v grafech, které ji mají.

Použití rozestupu popisků kategorií k nastavení číselné stupnice hodnotové osy není vhodné. Na hodnotové ose [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) určuje rozdíl v hodnotách: např. hlavní jednotka `10` vytvoří značky na 0, 10, 20 atd., když osa začíná od nuly. Interval popisků kategorií `3` počítá pozice kategorií bez ohledu na jejich datové hodnoty. Bodové a bublinové grafy používají hodnotové osy místo textové osy kategorií. Pro datumovou osu použijte časové jednotky a měřítka popsaná v sekci [Změna osy kategorií](#change-a-category-axis).

## **Nastavení formátu data pro hodnoty osy kategorií**

Příklad nahradí výchozí data grafu čtyřmi ročními hodnotami. Data jsou uložena jako sériová čísla OLE Automation v první listu (index `0`), počítaná jako počet dní od 30. prosince 1899. Obě kalendáře používají UTC a jsou vymazány před nastavením dat, aby na výpočet neměl vliv letní čas ani aktuální čas dne. Použijte [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) s `CategoryAxisType.Date`, zavolejte [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) s `false` a předáte `yyyy` do [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-), aby se popisky kategorií zobrazovaly jako čtyřciferné roky nezávisle na formátování buněk.

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

## **Nastavení úhlu otočení pro název osy grafu**

Zavolejte [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) s `true` na svislé ose, poskytněte text názvu a použijte [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) k otočení názvu. Úhel je měřen ve stupních; tento příklad uloží sloupcový graf s otočeným názvem hodnotové osy o 90 stupňů.

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

## **Nastavení umístění osy na ose kategorií nebo hodnot**

Použijte [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) k řízení, zda hodnotová osa protíná osu kategorií mezi kategoriemi nebo na značkách kategorií. Toto nastavení se vztahuje na osy kategorií. Příklad nastaví hodnotu `true` na vodorovné ose kategorií sloupcového grafu a uloží výsledek.

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

## **Nastavení jednotky zobrazení na hodnotové ose grafu**

Použijte [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) k vynásobení popisků na hodnotové ose bez změny podkladových dat. S [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) nastaveným na `Millions` se hodnota 60 000 000 zobrazí jako 60. Příklad vytvoří sloupcový graf a použije jednotku zobrazení v milionech na jeho svislé ose.

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

Logaritmická hodnotová osa je užitečná, když kladné hodnoty pokrývají několik řádů velikosti. Například služba může během pěti období přijímat 10, 100, 1 000, 10 000 a 100 000 požadavků. Na lineární stupnici jsou menší hodnoty těsně u nuly. Logaritmická stupnice usnadňuje porovnání relativního růstu: stejné vzdálenosti představují stejné poměry, nikoli stejné rozdíly.

Zavolejte [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) s `true` na hodnotové ose a použijte [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) k výběru základu. Toto mění způsob, jakým jsou stávající hodnoty zobrazovány; nemění data ani nepřidává logaritmickou trendovou čáru. Trendová čára představuje přizpůsobený vztah v datech a je samostatnou funkcí.

### **Zvolte hodnotovou osu a základ**

Pro čárový nebo sloupcový graf je hodnotová osa vrácena metodou [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Pro vodorovný pruhový graf je vrácena metodou [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Bodové a bublinové grafy mají dvě hodnotové osy, takže vyberte vodorovnou osu pro hodnoty X, svislou osu pro hodnoty Y nebo obě. Na osu kategorií logaritmické škálování nepoužívejte.

Výchozí logaritmický základ je `10`. Pro PPTX grafy použijte základ od `2` do `1000` inkluzivně; podporovány jsou i zlomkové základy jako `2.5`. Se základem `10` jsou po sobě jdoucí mocniny jako 10, 100, 1 000 a 10 000 rovnoměrně rozdělené.

### **Porovnání lineárního a logaritmického škálování**

Následující samostatný příklad vytvoří čárový graf s pěti počty požadavků na prvním snímku, poté tento snímek zduplikuje a na druhém povolí logaritmickou hodnotovou osu s bází 10. Oba snímky zachovají stejná data.

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

**Lineární stupnice (snímek 1):** Stejné vertikální vzdálenosti představují stejné rozdíly v počtech požadavků. Největší hodnota dominuje grafu a menší hodnoty jsou těžko rozlišitelné.

![Čárový graf v PowerPointu zobrazující pět počtů požadavků na lineární hodnotové ose](value-axis-linear.png)

**Logaritmická stupnice (snímek 2):** Stejné vertikální vzdálenosti představují stejné poměry. Každé období má desetkrát více požadavků než předchozí, takže body tvoří přímou stoupající čáru na logaritmické stupnici se základem 10. Osy nadále ukazují původní počty požadavků.

![Stejné pět požadavků v PowerPointu na logaritmické hodnotové ose se základem 10](value-axis-logarithmic.png)

### **Zpracování nulových a záporných hodnot**

Logaritmická stupnice může zobrazovat pouze čistě kladné hodnoty. Před jejím povolením zkontrolujte data. Pokud mají nula nebo záporné hodnoty smysl, ponechte lineární stupnici nebo je zobrazte odděleně. Pokud je vhodné tyto hodnoty z analýzy vyloučit, vysvětlete důvod vynechání. Nedávejte je tiše nahrazené malými kladnými čísly, protože by to změnilo význam dat. Jakékoli ručně nastavené minimum nebo maximum pro logaritmickou osu musí být také kladné.

## **Často kladené otázky**

**Jak nastavit hodnotu, ve které se jedna osa protíná s druhou (průsečík os)?**

Použijte [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) k výběru chování průsečíku. Pro určení číselné hodnoty průsečíku použijte [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Tato nastavení vám umožní posunout průsečík osy na vhodnou referenční úroveň.

**Jak mohu umístit popisky značek relativně k ose?**

Zavolejte [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) pomocí [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` nebo `None`. Pro řízení samotných značek tik použijte [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) nebo [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); jsou oddělené od umístění popisků.