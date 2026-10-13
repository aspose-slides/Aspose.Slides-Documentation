---
title: Přizpůsobení os grafu v prezentacích pomocí Javy
linktitle: Osa grafu
type: docs
url: /cs/java/chart-axis/
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
- umístění osy
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Objevte, jak pomocí Aspose.Slides pro Javu přizpůsobit osy grafu v PowerPoint prezentacích pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu pomocí Aspose.Slides pro Java. Popisuje vypočítané hodnoty os, výměnu řádků a sloupců grafu, viditelnost os, intervaly popisků kategorií a značek, datumové kategorie a formátování, otáčení názvu, umístění os, jednotky zobrazení a logaritmické škálování.

## **Získat maximální hodnoty na svislé ose grafů**

Vytvořte [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) a přidejte plošný graf s výchozími daty. Zavolejte [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) před načtením vypočítaných hodnot os, aby byl rozvržení grafu aktuální.

Pro načtení limitů os použijte [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) a [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--). Pro intervaly značek použijte [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) a [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--). [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) a [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) poskytují časové jednotkové měřítka, která jsou relevantní pro datumové osy. Příklad uloží tyto hodnoty do lokálních proměnných a uloží graf.

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

Použijte [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) k výměně rolí řad a kategorií v datech grafu. Každá bývalá kategorie se stane řadou a každá bývalá řada se stane kategorií. Tím se změní způsob seskupení dat; neprohodí se vodorovná a svislá osa. Příklad používá [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) k navázání výchozích dat na `Sheet1!A1:D5`, včetně řádku záhlaví a sloupce kategorií, před výměnou řádků a sloupců. Uloží graf se čtyřmi řadami a třemi kategoriemi.

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

## **Zakázat svislou osu pro čárové grafy**

Zavolejte [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) s hodnotou `false` na svislé ose, aby byla skryta. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou svislou osou.

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

## **Zakázat vodorovnou osu pro čárové grafy**

Zavolejte [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) s `false` na vodorovné ose, aby byla skryta. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou vodorovnou osou.

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

Použijte [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-), abyste vybrali datumovou nebo textovou osu kategorií. Tento příklad vyžaduje `ExistingChart.pptx`, kde je graf první tvarem na první snímku a buňky kategorií obsahují číselné hodnoty datumů v Excelu. Přepne vodorovnou osu na datumovou osu. Zavoláním [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) s `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) s `1` a [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) s `TimeUnitType.Months` umístíte hlavní značky v intervalech jednoho měsíce.

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

Když má graf mnoho kategorií, můžete snížit počet viditelných popisků osy, aniž byste odstraňovali kategorie nebo datové body. Zavolejte [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) s `false`, poté předáte požadovaný interval kategorií do [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Pro textové kategorie v normálním pořadí se číslování zahajuje od první kategorie:

| Interval | Popisky zobrazené v příkladu |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Interval `3` zobrazí každý třetí popisek a mezi zobrazenými popisky skryje dva popisky. Neodstraní odpovídající sloupce. Automatické rozestupy zvolí interval podle dostupného prostoru; nezobrazí nutně každý popisek.

Značky na osách mají samostatná nastavení. Zavolejte [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) s `false` a použijte [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) k nastavení jejich intervalu. Například `1` zachová značku v každém intervalu kategorií, zatímco popisky se zobrazí jen každou třetí kategorii. Použijte [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) s viditelným stylem, abyste viděli výsledek. Opětovným zavoláním některého z automatických nastavení s `true` umožníte grafu znovu zvolit tento interval.

Následující samostatný příklad vytvoří 24 kategorií a jednu řadu, poté uloží tři snímky do `CategoryAxisIntervals.pptx`: automatické rozestupy, ruční rozestupy popisků s nezávislými značkami a obnovené automatické rozestupy. Obě kopie zachovají původní data grafu. Vstupní prezentace není vyžadována. Text vodorovných popisků usnadňuje rozpoznání rozdílu v hustotě.

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

    // Snímek 2: zobrazit každý třetí popisek, ale ponechat značku pro každou kategorii.
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

**Automatické rozestupy (snímek 1):** V tomto vykreslení je zobrazena každá druhá kategorie a text se zalamuje na dva řádky. Automatický výsledek se může lišit podle velikosti grafu, fontů a vykreslovacího engine.

![Automatické rozestupy popisků kategorií se všemi 24 sloupci viditelnými](category-axis-automatic.png)

**Manuální rozestupy (snímek 2):** Každý třetí popisek je zobrazen na jednom řádku, zatímco značky zůstávají v každém intervalu kategorií. Všechny 24 sloupců, včetně těch bez popisků, jsou viditelné se stejnými hodnotami. Snímek 3 obnoví automatický vzhled zobrazený výše.

![Manuální interval popisků kategorií tři se všemi 24 sloupci viditelnými](category-axis-manual.png)

### **Zvolte správnou osu a interval**

Použijte tento interval počtu kategorií pro textovou osu kategorií, například osu kategorií sloupcového, čárového, plošného nebo pruhového grafu. V sloupcovém grafu je to vodorovná osa. V vodorovném pruhovém grafu je osa kategorií svislá, takže použijte tato nastavení na osu vrácenou metodou [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Rozestup značek se také vztahuje na osu řad v grafech, které ji mají.

Nepoužívejte rozestup popisků kategorií k nastavení číselné stupnice hodnotové osy. Na hodnotové ose [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) určuje rozdíl v hodnotách: například hlavní jednotka `10` vytváří značky na 0, 10, 20 atd., když osa začíná od nuly. Interval popisků kategorií `3` místo toho počítá pozice kategorií bez ohledu na jejich hodnoty. Scatter a bubble grafy používají hodnotové osy místo textové osy kategorií. Pro datumovou osu použijte časové jednotky a měřítka popsaná v [Změna osy kategorií](#change-a-category-axis).

## **Nastavení formátu data pro hodnoty osy kategorií**

Příklad nahradí výchozí data grafu čtyřmi ročními hodnotami. Datum jsou uložena jako sériová čísla OLE Automation v první listu (index `0`), vypočtená jako počet dnů od 30. prosince 1899. Použijte [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) s `CategoryAxisType.Date`, zavolejte [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) s `false` a předajte `yyyy` metodě [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-), aby se popisky kategorií zobrazovaly jako čtyřciferné roky nezávisle na formátování buňky.

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

## **Nastavení úhlu otáčení názvu osy grafu**

Zavolejte [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) s `true` na svislé ose, poskytněte text názvu a použijte [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) k otočení názvu. Úhel je měřen ve stupních; tento příklad uloží sloupcový graf s názvem hodnotové osy otočeným o 90 stupňů.

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

## **Nastavení umístění osy na ose kategorií nebo hodnotové ose**

Použijte [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) k určení, zda hodnotová osa protíná osu kategorií mezi kategoriemi nebo na značkách kategorií. Toto nastavení se vztahuje na osy kategorií. Příklad nastaví hodnotu `true` na vodorovné ose kategorií sloupcového grafu a výsledek uloží.

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

Použijte [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) k škálování popisků na hodnotové ose, aniž byste měnili podkladová data. S [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) nastaveným na `Millions` se hodnota 60 000 000 zobrazí jako 60. Příklad vytvoří sloupcový graf a použije jednotku zobrazení milionů na jeho svislé ose.

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

Logaritmická hodnotová osa je užitečná, když kladné hodnoty pokrývají několik řádů velikosti. Například služba může během pěti období obdržet 10, 100, 1 000, 10 000 a 100 000 požadavků. Na lineární stupnici se menší hodnoty zobrazují těsně u nuly. Logaritmická stupnice usnadňuje porovnání jejich relativního růstu: stejné vzdálenosti reprezentují stejné poměry místo stejných rozdílů.

Zavolejte [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) s `true` na hodnotové ose a použijte [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) k výběru základu. Tím se změní způsob, jakým jsou existující hodnoty zobrazovány; data se nezmění a nepřidá se logaritmická trendová čára. Trendová čára představuje aproximovanou vztahovou křivku v datech a je samostatnou funkcí.

### **Zvolte hodnotovou osu a základ**

U čárových nebo sloupcových grafů je hodnotová osa vrácena metodou [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). U vodorovného pruhového grafu je vrácena metodou [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Scatter a bubble grafy mají dvě hodnotové osy, takže vyberte vodorovnou osu pro hodnoty X, svislou osu pro hodnoty Y nebo obě. Na osu kategorií nepoužívejte logaritmické škálování.

Výchozí logaritmický základ je `10`. Pro PPTX grafy použijte základ v rozmezí od `2` do `1000`, včetně; podporovány jsou i zlomkové základy jako `2.5`. Se základem `10` jsou po sobě jdoucí mocniny 10, 100, 1 000 a 10 000 rovnoměrně rozmístěny.

### **Porovnání lineární a logaritmické škálování**

Následující samostatný příklad vytvoří čárový graf s pěti počty požadavků na prvním snímku, poté tento snímek klonuje a na druhém povolí logaritmickou hodnotovou osu se základem 10. Oba snímky zachovávají stejná data.

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

**Lineární škála (snímek 1):** Stejné vertikální vzdálenosti představují stejné rozdíly v počtech požadavků. Největší hodnota dominuje grafu, což ztěžuje rozlišení menších hodnot.

![Čárový graf v PowerPointu zobrazující pět počtů požadavků na lineární hodnotové ose](value-axis-linear.png)

**Logaritmická škála (snímek 2):** Stejné vertikální vzdálenosti představují stejné poměry. Každé období má desetkrát více požadavků než předchozí, takže body tvoří přímou rostoucí čáru na stupnici s základem 10. Popisky osy stále ukazují původní počty požadavků.

![Stejných pět požadavků v PowerPointu na logaritmické hodnotové ose se základem 10](value-axis-logarithmic.png)

### **Zpracování nulových a záporných hodnot**

Logaritmická stupnice může zobrazovat pouze striktně kladné hodnoty. Před jejím zapnutím data zkontrolujte. Pokud jsou nulové nebo záporné hodnoty významné, zachovejte lineární stupnici nebo je zobrazte samostatně. Pokud je vyloučení těchto hodnot vhodné pro analýzu, vysvětlete vynechání. Nepřepisujte je tiše malými kladnými čísly, protože to mění význam dat. Jakékoli ručně nastavené minimum nebo maximum pro logaritmickou osu musí být také kladné.

## **Často kladené otázky**

**Jak nastavit hodnotu, ve které se jedna osa protíná s druhou (průsečík osy)?**

Použijte [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) k výběru chování průsečíku. Pro zadání číselné hodnoty průsečíku použijte [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Tato nastavení vám umožní posunout průsečík osy na vhodnou referenční čáru.

**Jak mohu umístit popisky značek vzhledem k ose?**

Zavolejte [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) s použitím [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` nebo `None`. Pro řízení samotných značek použijte [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) nebo [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); jsou oddělené od umístění popisků.