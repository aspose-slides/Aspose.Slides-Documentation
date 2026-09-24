---
title: Přizpůsobení datových tabulek grafů v prezentacích pomocí Javy
linktitle: Datová tabulka
type: docs
url: /cs/java/chart-data-table/
keywords:
- data grafu
- datová tabulka
- vlastnosti písma
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Přizpůsobte písma, ohraničení a legendové klíče datové tabulky grafu v prezentacích PowerPoint pomocí Aspose.Slides pro Javu."
---
## **Přehled**

Aspose.Slides for Java vám umožňuje zobrazit datovou tabulku grafu a přizpůsobit její formátování textu, ohraničení a legendové klíče. Tento článek vysvětluje, jak povolit tabulku, formátovat její text, ovládat jednotlivé typy ohraničení a zobrazit nebo skrýt legendové klíče. Příklady ukládají nakonfigurované grafy do souborů PPTX.

## **Nastavení vlastností písma**

Pro zobrazení datové tabulky grafu předávejte `true` metodě [setDataTable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chart/#setDataTable-boolean-). Použijte [getChartDataTable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chart/#getChartDataTable--) pro přístup k tabulce a konfiguraci formátování textu.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Přidejte seskupený sloupcový graf na první snímek.
1. Povolení datové tabulky grafu.
1. Povolte tučný text metodou [setFontBold](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) a předávejte `20` metodě [setFontHeight](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) pro text o velikosti 20 bodů.
1. Uložte upravenou prezentaci.

Následující příklad vyžaduje `test.pptx` v pracovním adresáři s alespoň jedním snímkem. Přidá graf s výchozími údaji na pozici (50, 50) s šířkou 600 bodů a výškou 400 bodů. Uložený `output.pptx` obsahuje graf s povolenou datovou tabulkou a aplikovanými nastaveními písma.

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

## **Přizpůsobení ohraničení datové tabulky**

Povolit tabulku pomocí [IChart.setDataTable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichart/#setDataTable-boolean-) a získat ji přes [IChart.getChartDataTable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichart/#getChartDataTable--). Můžete nezávisle ovládat tři typy ohraničení:

- [setBorderHorizontal](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) ovládá horizontální ohraničení buněk.
- [setBorderVertical](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) ovládá vertikální ohraničení buněk.
- [setBorderOutline](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) ovládá vnější ohraničení tabulky.

Předávejte `true` každé metodě pro zobrazení ohraničení nebo `false` pro jeho skrytí. Následující příklad vytvoří seskupený sloupcový graf s výchozími daty, zobrazí horizontální a vnější ohraničení a skryje vertikální ohraničení. Nevytváří žádný vstupní soubor. Pozice a velikost grafu jsou zadány v bodech.

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

Srovnání níže používá stejná data grafu a nastavení legendových klíčů ve všech čtyřech případech. Začíná se se všemi povolenými ohraničeními, každá následující varianta zakazuje jen jedno nastavení ohraničení. Varianta v levém dolním rohu odpovídá nastavením ohraničení v příkladu.

![Grafické datové tabulky se všemi povolenými ohraničeními, bez horizontálního ohraničení, bez vertikálního ohraničení a bez vnějšího ohraničení](data-table-borders.png)

## **Zobrazit nebo skrýt legendové klíče**

Legendové klíče jsou malé barevné značky vedle názvů řad v datové tabulce. Pomáhají čtenářům přiřadit každý řádek tabulky k řadě grafu. Předávejte `true` metodě [setShowLegendKey](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) pro zobrazení těchto značek nebo `false` pro jejich skrytí.

Samostatná legenda grafu je řízena metodou [IChart.setLegend](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichart/#setLegend-boolean-). Tato nastavení jsou nezávislá: skrytí samostatné legendy neskrývá klíče v datové tabulce a skrytí klíčů v tabulce neovlivní samostatnou legendu.

Následující příklad vytvoří graf s výchozími daty, povolí jeho datovou tabulku a zobrazí legendové klíče uvnitř ní při skrytí samostatné legendy. Všechna ohraničení tabulky jsou výslovně povolena. Není vyžadována žádná vstupní prezentace. Pro skrytí pouze klíčů tabulky předávejte `false` metodě [setShowLegendKey](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

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

Srovnání níže ukazuje stejnou tabulku s legendovými klíči zobrazenými vlevo a skrytými vpravo. Všechna ohraničení zůstávají povolena a samostatná legenda grafu je skrytá v obou případech.

![Grafické datové tabulky s legendovými klíči zobrazenými vlevo a skrytými vpravo](data-table-legend-keys.png)

## **Často kladené otázky**

**Mohu zobrazit legendové klíče v datové tabulce grafu?**

Ano. Předávejte `true` metodě [setShowLegendKey](https://reference.aspose.com/slides/cs/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) pro zobrazení legendových klíčů nebo `false` pro jejich skrytí.

**Zůstane datová tabulka zachována při exportu prezentace do PDF, HTML nebo obrázků?**

Ano. Aspose.Slides vykresluje graf a jeho zobrazenou datovou tabulku jako součást snímku při exportu do [PDF](/slides/cs/java/convert-powerpoint-to-pdf/), [HTML](/slides/cs/java/convert-powerpoint-to-html/) nebo [obrázků](/slides/cs/java/convert-powerpoint-to-png/).

**Mohu pracovat s datovými tabulkami v grafech načtených ze šablony?**

Ano. Pro graf načtený z existující prezentace nebo šablony použijte [hasDataTable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chart/#hasDataTable--) a [setDataTable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chart/#setDataTable-boolean-) pro kontrolu nebo změnu, zda je jeho datová tabulka zobrazena.

**Jak mohu najít grafy, u nichž je povolena datová tabulka?**

Procházejte tvary na každém snímku, identifikujte grafy a zavolejte jejich metodu [hasDataTable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chart/#hasDataTable--). Hodnota `true` značí, že je datová tabulka povolena.