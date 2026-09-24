---
title: Přizpůsobení tabulek s daty grafu v prezentacích na Androidu
linktitle: Datová tabulka
type: docs
url: /cs/androidjava/chart-data-table/
keywords:
- data grafu
- datová tabulka
- vlastnosti písma
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Přizpůsobte písma, okraje a legendární klíče tabulky s daty grafu v prezentacích PowerPoint pomocí Aspose.Slides pro Android prostřednictvím Javy."
---
## **Přehled**

Aspose.Slides pro Android prostřednictvím Javy vám umožňuje zobrazit tabulku s daty grafu a přizpůsobit formátování textu, okraje a legendární klíče. Tento článek vysvětluje, jak povolit tabulku, formátovat její text, ovládat každý typ okraje a zobrazit nebo skrýt legendární klíče. Příklady ukládají nakonfigurované grafy do souborů PPTX.

## **Nastavit vlastnosti písma**

Pro zobrazení tabulky s daty grafu předáte `true` metodě [setDataTable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chart/#setDataTable-boolean-). Použijte [getChartDataTable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chart/#getChartDataTable--) , abyste získali přístup k tabulce a nakonfigurovali formátování textu.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
2. Přidejte graf typu seskupený sloupcový na první snímek.
3. Povolte tabulku s daty grafu.
4. Povolte tučný text pomocí [setFontBold](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseportionformat/#setFontBold-byte-) a předajte `20` metodě [setFontHeight](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) , aby byl text o velikosti 20 bodů.
5. Uložte upravenou prezentaci.

Následující příklad vyžaduje soubor `test.pptx` v pracovním adresáři s alespoň jedním snímkem. Přidá graf s výchozími daty na pozici (50, 50), se šířkou 600 bodů a výškou 400 bodů. Uložený soubor `output.pptx` obsahuje graf s povolenou tabulkou dat a aplikovanými specifikovanými nastaveními písma.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přizpůsobení okrajů tabulky dat**

Povolte tabulku pomocí [IChart.setDataTable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichart/#setDataTable-boolean-) a přistupte k ní přes [IChart.getChartDataTable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichart/#getChartDataTable--) . Můžete nezávisle řídit tři typy okrajů:

- [setBorderHorizontal](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) ovládá vodorovné okraje buněk.
- [setBorderVertical](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idatatable/#setBorderVertical-boolean-) ovládá svislé okraje buněk.
- [setBorderOutline](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idatatable/#setBorderOutline-boolean-) ovládá vnější okraj tabulky.

Předáte `true` každé metodě, aby se okraje zobrazily, nebo `false`, aby se skryly. Následující příklad vytvoří seskupený sloupcový graf s výchozími daty, zobrazí vodorovné okraje a vnější okraj a skryje svislé okraje. Nevyžaduje žádný vstupní soubor. Pozice a velikost grafu jsou zadány v bodech.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Níže uvedené srovnání používá stejná data grafu a nastavení legendárních klíčů ve všech čtyřech případech. Začíná se se všemi povolenými okraji, každá další varianta zakáže jen jedno nastavení okraje. Varianta v levém dolním rohu odpovídá nastavení okrajů v příkladu.

![Tabulky dat grafu se všemi povolenými okraji, bez vodorovných okrajů, bez svislých okrajů a bez vnějšího okraje](data-table-borders.png)

## **Zobrazit nebo skrýt legendární klíče**

Legendární klíče jsou malé barevné značky vedle názvů sérií v tabulce dat. Pomáhají čtenářům přiřadit každý řádek tabulky k sérii grafu. Předáte `true` metodě [setShowLegendKey](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) , aby se tyto značky zobrazily, nebo `false`, aby se skryly.

Samostatná legenda grafu je řízena metodou [IChart.setLegend](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) . Tato nastavení jsou nezávislá: skrytí samostatné legendy neskryje klíče uvnitř tabulky dat a skrytí klíčů tabulky neovlivní samostatnou legendu.

Následující příklad vytvoří graf s výchozími daty, povolí jeho tabulku dat a zobrazí legendární klíče uvnitř ní, zatímco skryje samostatnou legendu. Všechny okraje tabulky jsou explicitně povoleny. Není vyžadována žádná vstupní prezentace. Pro skrytí pouze klíčů tabulky předáte `false` metodě [setShowLegendKey](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) .

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Níže uvedené srovnání ukazuje stejnou tabulku se zapnutými a vypnutými legendárními klíči. Všechny okraje zůstávají povoleny a samostatná legenda grafu je v obou případech skrytá.

![Tabulky dat grafu s legendárními klíči zobrazenými vlevo a skrytými vpravo](data-table-legend-keys.png)

## **FAQ**

**Mohu zobrazit legendární klíče v tabulce dat grafu?**

Ano. Předáte `true` metodě [setShowLegendKey](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) , aby se legendární klíče zobrazily, nebo `false`, aby se skryly.

**Zůstane tabulka dat zachována při exportu prezentace do PDF, HTML nebo obrázků?**

Ano. Aspose.Slides vykresluje graf a jeho zobrazenou tabulku dat jako součást snímku při exportu do [PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/cs/androidjava/convert-powerpoint-to-html/) nebo [images](/slides/cs/androidjava/convert-powerpoint-to-png/) .

**Mohu pracovat s tabulkami dat v grafech načtených ze šablony?**

Ano. Pro graf načtený z existující prezentace nebo šablony použijte [hasDataTable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chart/#hasDataTable--) a [setDataTable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chart/#setDataTable-boolean-) , abyste zjistili nebo změnili, zda je jeho tabulka dat zobrazena.

**Jak mohu najít grafy, které mají povolenou tabulku dat?**

Procházejte tvary na každém snímku, identifikujte grafy a zavolejte jejich metodu [hasDataTable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chart/#hasDataTable--) . Hodnota `true` značí, že je tabulka dat povolena.