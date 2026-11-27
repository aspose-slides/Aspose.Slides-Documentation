---
title: Formátování grafů v prezentaci v Javě
linktitle: Formátování grafu
type: docs
weight: 60
url: /cs/java/chart-formatting/
keywords:
- formátování grafu
- formátování grafu
- prvek grafu
- vlastnosti grafu
- nastavení grafu
- možnosti grafu
- vlastnosti písma
- zaoblený okraj
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se formátovat grafy v Aspose.Slides pro Javu a vylepšete svou prezentaci PowerPoint pomocí vlastních os, písem, číselných formátů a zaoblených okrajů grafu."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides formátovat grafy v prezentacích PowerPoint. Ukazuje, jak přizpůsobit klíčové prvky grafu, jako jsou osy, mřížkové čáry, názvy, legendy, oblast vykreslování a výplně stěn, aby se zlepšil vzhled a čitelnost dat v grafu.

Také demonstruje, jak nastavit vlastnosti písma pro text v grafu, použít předdefinované číselné formáty na data grafu a povolit zaoblené rohy oblasti grafu. Společně tyto příklady ukazují, jak ovládat jak vizuální styl, tak prezentaci dat grafu v prezentaci.

Pro samostatné výplně a obrysy při rostoucích a klesajících intervalech viz [příklad akciového grafu](/slides/cs/java/create-chart/#create-stock-charts).

## **Formátování prvků grafu**

Použijte [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) k formátování názvů grafu, os, mřížkových čar, legend a oblasti vykreslování. Tento příklad vytvoří čárový graf s značkami a výchozími daty, poté použije samostatné styly textu a čáry pro osu hodnot a osu kategorií. Velikosti písma a šířky čar jsou zadány v bodech; popisky kategorií jsou otočeny o 45 stupňů.

Osa hodnot používá [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) nezávisle na zdrojových buňkách. Její měřítko běží od -2 do 15, s hlavními intervaly 2 a podintervaly 0,5. Příklad také kombinuje formátování procent s [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setDisplayUnit-int-) nastaveným na tisíce, takže tato nastavení přizpůsobte významu a velikosti vašich dat. Legenda zůstává mimo oblast vykreslování, protože [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/ilegend/#setOverlay-boolean-) je voláno s `false`. Výplně zadní stěny a podlahy jsou konfigurovány pomocí [getBackWall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) a [getFloor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--), ale tyto plochy jsou viditelné pouze u 3D grafů.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(new Color(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení vlastností písma pro graf**

Nastavte výchozí velikost písma pro text v grafu pomocí [Chart.getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getTextFormat--). Příklad vytvoří seskupený sloupcový graf s 20bodovým písmem a povolí popisky hodnot pro první sérii pomocí [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Textové prvky s vlastními explicitními nastaveními písma mohou přepsat výchozí nastavení grafu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Opětovné použít formátování textového rámečku pro legendu grafu**

Pro sladění legendy s nadpisem snímku nastavte písmo nadpisu pomocí [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) v prvním odstavci. Zavolejte [copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) na formát vrácený metodou [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) legendy. Zkopíruje nastavení textového rámce, formátování prvního odstavce a výchozí vlastnosti písma tohoto odstavce. Formátování aplikované přímo na jednotlivé části nebo na pozdější odstavce zůstává lokální ke zdroji.

Příklad používá tučný nadpis Calibri o velikosti 26 bodů v námořnické barvě jako šablonu. Po naformátování legendy zavolá [copyTo](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) pro aplikaci stejného formátování na samostatný titulek.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    IAutoShape heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
    ITextFrame sourceTextFrame = heading.addTextFrame("Quarterly sales");
    IPortionFormat font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(NullableBool.True);
    font.getFillFormat().setFillType(FillType.Solid);
    font.getFillFormat().getSolidFillColor().setColor(new Color(32, 64, 96));

    IChart chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(StyleType.Style3);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (int quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    IChartTextFormat legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    IAutoShape caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
    ITextFrame captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

V uložené prezentaci legendy a titulek odpovídají nadpisu co do velikosti, tloušťky a barvy. Legenda stále zobrazuje názvy sérií a titulek si zachovává vlastní text. Pokud má část titulku již explicitně nastavenou velikost písma, tato velikost má přednost před zkopírovaným výchozím nastavením odstavce.

| Before copying | After copying |
| --- | --- |
| ![Čtvrtletní prodejní graf s běžnými černými popisky legendy a černým titulkem](legend-formatting-before.png) | ![Stejný graf s většími, tučnými námořnickými popisky legendy a odpovídajícím titulkem](legend-formatting.png) |

## **Nastavení číselného formátu**

Použijte [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) k aplikaci vestavěného číselného formátu na buňky sešitu grafu. Tento příklad vytvoří seskupený sloupcový graf s výchozími, buňkou podporovanými daty a použije index formátu 10 (`0.00%`) na buňku hodnoty každé série. Tím se změní způsob, jakým jsou hodnoty zobrazeny v sešitu, aniž by se změnila podkladová čísla; například 0,25 se zobrazí jako 25,00 %. Formáty os a datových popisků lze konfigurovat samostatně.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Následující tabulka uvádí vestavěné indexy číselných formátů s odpovídajícími formáty Excelu pro anglické (Spojené státy) prostředí. Přesné řetězce formátů a jejich zobrazení se mohou lišit podle aplikace a locale, zejména u měn a data. Některé formáty Excelu se také liší od výchozích ve standardu OOXML, jak je popsáno v [poznámkách k implementaci číselných formátů společnosti Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Formát |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Nastavení zaoblených okrajů oblasti grafu**

Zavolejte [IChart.setRoundedCorners](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setRoundedCorners-boolean-) s hodnotou `true`, aby se zaoblily rohy oblasti grafu. Příklad vytvoří seskupený sloupcový graf a použije [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) k nastavení jeho obrysu na plnou šedou barvu a jednopásmový styl před uložením prezentace.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Úprava existujících anotací grafu**

Graf může obsahovat vlastní tvary, například textovou anotaci vysvětlující stav zprávy. Přístup k těmto tvarům získáte přes [IChart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getUserShapes--), také uvedený pod [Chart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getUserShapes--) v dokumentaci API grafu. Kolekce vrácená metodou [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) obsahuje tvary vlastněné grafem.

Běžná textová pole umístěná nad grafem patří ke snímku, i když vypadají jako součást grafu. Procházením [Slide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) se najde graf a běžné tvary snímku, ale nevyjmenují se jednotlivé tvary uvnitř grafu. Názvy grafu a datové popisky jsou samostatné prvky grafu, nikoli vlastní anotace v této kolekci.

Stáhněte si soubor [chart-annotations.pptx](chart-annotations.pptx) a umístěte jej do pracovního adresáře aplikace. Jeho první snímek obsahuje graf s nezkupovanou anotací s textem „Preliminary results“, grafovým vlastním čárou a běžným textovým polem snímku s textem „Slide overlay“. Příklad najde první graf na tomto snímku a změní anotaci na „Final results“, když je zpráva připravena k publikaci. Kontroluje, zda je kolekce prázdná, a upravuje pouze [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) s nenulovým textovým rámcem vráceným metodou [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getTextFrame--) a očekávaným textem.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

Čára a textové pole snímku zůstávají nezměněny. Následující obrázky ukazují vstup a uložený, znovu otevřený výsledek:

| Before editing | After editing |
| --- | --- |
| ![Anotace grafu s textem Preliminary results](chart-annotations-before.png) | ![Anotace grafu s textem Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Příklad kontroluje pouze tvary na nejvyšší úrovni, které vlastní graf. Pokud je anotace uvnitř [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/), prozkoumejte také kolekci [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) této skupiny. Opakujte toto rekurzivně pro vnořené skupiny a použijte stejné kontroly textu na jejich podřízené tvary. Skupina samotná je kontejner; nepovažujte ji za textové pole.
{{% /alert %}}

## **Často kladené otázky**

**Mohu nastavit poloprůhledné výplně pro sloupce/oblasti a zachovat okraj neprůhledný?**

Ano. Průhlednost výplně a obrys jsou konfigurovány odděleně. Toto je užitečné pro zlepšení čitelnosti mřížky a dat v hustých vizualizacích.

**Jak mohu zacházet s datovými popisky, když se překrývají?**

Zmenšte velikost písma, vypněte nepodstatné součásti popisků (například kategorie), upravte pozici popisku, zobrazte popisky jen pro vybrané body, pokud je to nutné, nebo přepněte formát na "hodnota + legenda".

**Mohu použít gradientní nebo vzorové výplně na série?**

Ano. Série podporují plné, gradientní a vzorové výplně. V praxi používejte gradienty střídmě a vyhýbejte se kombinacím, které snižují kontrast vůči mřížce a textu.