---
title: Přizpůsobení legend grafů v prezentacích na Androidu
linktitle: Legenda grafu
type: docs
url: /cs/androidjava/chart-legend/
keywords:
- legenda grafu
- pozice legendy
- velikost písma
- PowerPoint
- prezentace
- Android
- Aspose.Slides
description: "Přizpůsobte legendy grafů pomocí Aspose.Slides for Android via Java pro optimalizaci prezentací PowerPoint s cíleným formátováním legend."
---
## **Přehled**

Aspose.Slides for Android via Java poskytuje možnosti přizpůsobení legend grafů v prezentacích PowerPoint. Tento článek ukazuje, jak umístit a změnit velikost legendy, nastavit velikost písma pro celou legendu, formátovat jednotlivou položku legendy a skrýt nebo obnovit vybrané položky.

Často kladené otázky pokrývají související chování, včetně vyhrazení místa pro legendu, zobrazování víceliniových popisků a dědění formátování z motivu prezentace.

## **Umístění legendy**

Použijte metody legendy [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setWidth-float-), a [setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setHeight-float-) k určení její polohy a velikosti jako zlomků rozměrů grafu.

Tento příklad vytvoří prezentaci a přidá do první snímku seskupený sloupcový graf s výchozími daty. Rozdělením požadovaných posunů a rozměrů legendy šířkou a výškou grafu je převede na relativní hodnoty: legenda je posunuta o 50 bodů od levého horního rohu grafu a má rozměry 100 × 100 bodů.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Vyjádřete umístění a velikost legendy relativně k grafu.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení velikosti písma legendy**

Použijte [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getTextFormat--) legendy pro přístup k jejímu formátování textu a použijte [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) k nastavení velikosti písma v bodech.

Tento příklad vytvoří graf s výchozími daty a nastaví text legendy na 20 bodů. Také zakáže automatické ohraničení pro svislou osu a nastaví její rozsah na -5 až 10.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení velikosti písma jednotlivé položky legendy**

Použijte kolekci vrácenou metodou [getEntries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getEntries--) legendy pro přístup k formátování konkrétní položky. Indexy položek jsou nulové, takže index `1` odkazuje na druhou položku.

Tento příklad vytvoří seskupený sloupcový graf, jehož výchozí data obsahují alespoň dvě řady. Formátuje druhou položku legendy tučným, kurzívním a modrým textem o velikosti 20 bodů.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Skrytí jednotlivých položek legendy**

Chcete-li vyloučit pomocnou řadu z legendy a zároveň nechat její data viditelná, zavolejte [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) s hodnotou `true` přes [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Tím se skryje pouze vybraná položka legendy; řada ani její datové body nejsou odstraněny. Naopak volání [IChart.setLegend](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) s hodnotou `false` skryje celou legendu.

Příklad níže vytvoří seskupený sloupcový graf s více řadami pomocí výchozích dat. Skryje položku legendy druhé řady (index `1`) a uloží prezentaci. Poté položku obnoví voláním [setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) s hodnotou `false` a uloží druhou kopii. Sloupce zůstávají viditelné v obou souborech.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // Obnovte stejnou položku bez změny dat grafu.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Srovnání níže ukazuje stejný graf se všemi položkami legendy viditelnými a s druhou položkou skrytou. Sloupce druhé řady zůstávají beze změny.

![Porovnání grafu se všemi položkami legendy viditelnými a s druhou řadou skrytou v legendě; všechny sloupce zůstávají viditelné.](hide-legend-entry.png)

V sloupcových, pruhových a čárových grafech položky legendy identifikují řady. U koláčových grafů identifikují jednotlivé datové body (výseče), proto použijte [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) na vybranou výseč. API dokumentuje tuto metodu datového bodu pro typy grafů `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` a `BarOfPie`. Nepředpokládejte, že platí i pro prstencové grafy, které v tomto seznamu nejsou zahrnuty.

## **Často kladené otázky**

**Can I make the chart allocate space for the legend instead of overlaying it?**

Ano. Zavolejte [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-) s hodnotou `false`, abyste vyhradili místo pro legendu místo toho, aby překrývala oblast grafu.

**Can I make multiline legend labels?**

Ano. Dlouhé popisky se mohou zalomit, pokud není k dispozici dostatečná šířka. Také můžete v názvech řad použít znaky nového řádku pro požadování zalomení.

**How do I make the legend follow the presentation theme's color scheme?**

Nenechte nastavené barvy, výplně ani písma legendy, aby mohla zdědit formátování motivu. Explicitní formátování přepíše odpovídající nastavení motivu.