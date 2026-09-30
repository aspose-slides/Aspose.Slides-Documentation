---
title: Přizpůsobení legend grafů v prezentacích pomocí Java
linktitle: Legenda grafu
type: docs
url: /cs/java/chart-legend/
keywords:
- legenda grafu
- pozice legendy
- velikost písma
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Přizpůsobení legend grafů pomocí Aspose.Slides for Java pro optimalizaci prezentací PowerPoint s upraveným formátováním legend."
---
## **Přehled**

Aspose.Slides for Java poskytuje možnosti přizpůsobení legend grafů v prezentacích PowerPoint. Tento článek ukazuje, jak umístit a změnit velikost legendy, nastavit velikost písma pro celou legendu, formátovat jednotlivou položku legendy a skrýt nebo obnovit vybrané položky.

FAQ pokrývá související chování, včetně vyhrazení prostoru pro legendu, zobrazení vícero řádkových popisků a dědění formátování z motivu prezentace.

## **Umístění legendy**

Pomocí metod legendy [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-) a [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) určete její polohu a velikost jako podíly rozměrů grafu.

Tento příklad vytvoří prezentaci a přidá na první snímek seskupený sloupcový graf s výchozími daty. Vydělením požadovaných posunutí a rozměrů legendy šířkou a výškou grafu se získají relativní hodnoty: legenda je posunuta o 50 bodů od levého horního rohu grafu a má velikost 100 × 100 bodů.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Vyjádřete polohu a velikost legendy relativně k grafu.
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

Pomocí legendy [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) získáte přístup k formátování textu a metodou [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) nastavíte velikost písma v bodech.

Tento příklad vytvoří graf s výchozími daty a nastaví text legendy na 20 bodů. Také zakáže automatické mezery pro svislou osu a nastaví její rozsah od –5 do 10.

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

Pomocí kolekce vrácené metodou legendy [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) získáte formátování konkrétní položky. Indexy položek jsou nulově založené, takže index `1` odkazuje na druhou položku.

Tento příklad vytvoří seskupený sloupcový graf, jehož výchozí data obsahují alespoň dvě řady. Formátuje druhou položku legendy tučným, kurzívovým a 20‑bodovým modrým textem.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Chcete‑li vyloučit pomocnou řadu z legendy při zachování viditelnosti jejích dat, zavolejte [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) s hodnotou `true` přes [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Tím se skryje pouze vybraná položka legendy; řada ani její datové body nejsou odstraněny. Naopak voláním [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) s hodnotou `false` skryjete celou legendu.

Níže uvedený příklad vytvoří seskupený sloupcový graf s více řadami pomocí výchozích dat. Skryje položku legendy druhé řady (index `1`) a uloží prezentaci. Poté položku obnoví voláním [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) s hodnotou `false` a uloží druhou kopii. Sloupce zůstávají viditelné v obou souborech.

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

![Porovnání grafu se všemi položkami legendy viditelnými a se skrytou druhou položkou v legendě; všechny sloupce zůstávají viditelné.](hide-legend-entry.png)

Ve sloupcových, pruhových a čárových grafech položky legendy identifikují řady. U koláčových grafů identifikují jednotlivé datové body (výseče), takže místo toho použijte [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) na vybrané výseči. API dokumentuje tuto metodu datového bodu pro typy grafů `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` a `BarOfPie`. Nepředpokládejte, že platí pro prstencové grafy, které nejsou v tomto seznamu zahrnuty.

## **Často kladené otázky**

**Mohu nechat graf vyhradit místo pro legendu místo jejího překrývání?**

Ano. Zavolejte [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) s hodnotou `false`, abyste rezervovali prostor pro legendu místo jejího překrývání vykreslovací oblasti.

**Mohu vytvořit víceřádkové popisky legendy?**

Ano. Dlouhé popisky se mohou zalomit, pokud není k dispozici dostatečná šířka. Můžete také použít znaky nového řádku v názvech řad pro požadavek na přerušení řádku.

**Jak zajistit, aby legenda následovala barevné schéma motivu prezentace?**

Nechte barvy, výplně a písma legendy nenastavené, aby mohla dědit formátování motivu. Explicitní formátování přepíše odpovídající nastavení motivu.