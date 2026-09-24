---
title: Přizpůsobení datových tabulek grafů v prezentacích pomocí JavaScriptu
linktitle: Datová tabulka
type: docs
url: /cs/nodejs-java/chart-data-table/
keywords:
- data grafu
- datová tabulka
- vlastnosti písma
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Přizpůsobte písma, okraje a legendové klíče datových tabulek grafů v prezentacích PowerPoint pomocí Aspose.Slides pro Node.js prostřednictvím Java."
---
## **Přehled**

Aspose.Slides pro Node.js prostřednictvím Java vám umožňuje zobrazit datovou tabulku grafu a přizpůsobit její formátování textu, okraje a legendové klíče. Tento článek vysvětluje, jak povolit tabulku, formátovat text, ovládat každý typ okraje a zobrazit nebo skrýt legendové klíče. Příklady ukládají nakonfigurované grafy do souborů PPTX.

## **Nastavení vlastností písma**

Chcete-li zobrazit datovou tabulku grafu, předejte `true` metodě [setDataTable](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/setdatatable/). Použijte [getChartDataTable](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/getchartdatatable/) k přístupu k tabulce a nastavení jejího formátování textu.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Přidejte seskupený sloupcový graf na první snímek.
1. Povolení datové tabulky grafu.
1. Povolení tučného textu pomocí [setFontBold](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setfontbold) a předejte `20` metodě [setFontHeight](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setfontheight) pro 20‑bodový text.
1. Uložte upravenou prezentaci.

Následující příklad vyžaduje soubor `input.pptx` v pracovním adresáři s alespoň jedním snímkem. Přidá graf s výchozími daty na pozici (50, 50), s šířkou 600 bodů a výškou 400 bodů. Uložený soubor `output.pptx` obsahuje graf s povolenou datovou tabulkou a aplikovanými nastaveními písma.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přizpůsobení okrajů datové tabulky**

Povolte tabulku pomocí [Chart.setDataTable](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/setdatatable/) a přistupujte k ní přes [Chart.getChartDataTable](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/getchartdatatable/). Můžete nezávisle řídit tři typy okrajů:

- [setBorderHorizontal](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datatable/setborderhorizontal/) řídí vodorovné okraje buněk.
- [setBorderVertical](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datatable/setbordervertical/) řídí svislé okraje buněk.
- [setBorderOutline](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datatable/setborderoutline/) řídí vnější okraj tabulky.

Předejte `true` každé metodě, aby se okraje zobrazily, nebo `false`, aby se skryly. Následující příklad vytvoří seskupený sloupcový graf s výchozími daty, zobrazí vodorovné okraje a vnější okraj a skryje svislé okraje. Nepotřebuje žádný vstupní soubor. Pozice a velikost grafu jsou zadány v bodech.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Níže uvedené srovnání používá stejná data grafu a nastavení legendových klíčů ve všech čtyřech případech. Začíná se se všemi povolenými okraji, každá další varianta vypne pouze jedno nastavení okraje. Varianta v levém dolním rohu odpovídá nastavením okrajů v příkladu.

![Tabulky dat grafu se všemi povolenými okraji, bez vodorovných okrajů, bez svislých okrajů a bez vnějšího okraje](data-table-borders.png)

## **Zobrazení nebo skrytí legendových klíčů**

Legendové klíče jsou malé barevné značky vedle názvů řad v datové tabulce. Pomáhají čtenářům přiřadit každý řádek tabulky k řadě grafu. Předejte `true` metodě [setShowLegendKey](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datatable/setshowlegendkey/) a zobrazte tyto značky, nebo `false` a skryjte je.

Samostatná legenda grafu je řízena pomocí [Chart.setLegend](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/setlegend/). Tato nastavení jsou nezávislá: skrytí samostatné legendy neskrývá klíče v datové tabulce a skrytí klíčů v tabulce neskrývá samostatnou legendu.

Následující příklad vytvoří graf s výchozími daty, povolí jeho datovou tabulku a zobrazí legendové klíče uvnitř ní při skrytí samostatné legendy. Všechny okraje tabulky jsou výslovně povoleny. Není vyžadována žádná vstupní prezentace. Chcete-li skrýt pouze klíče tabulky, předejte `false` metodě [setShowLegendKey](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datatable/setshowlegendkey/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Níže uvedené srovnání ukazuje stejnou tabulku se zapnutými a vypnutými legendovými klíči. Všechny okraje zůstávají povoleny a samostatná legenda grafu je v obou případech skryta.

![Tabulky dat grafu s legendovými klíči zobrazenými vlevo a skrytými vpravo](data-table-legend-keys.png)

## **Často kladené otázky**

**Mohu zobrazit legendové klíče v datové tabulce grafu?**

Ano. Předejte `true` metodě [setShowLegendKey](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datatable/setshowlegendkey/), aby se legendové klíče zobrazily, nebo `false`, aby se skryly.

**Zůstane datová tabulka zachována při exportu prezentace do PDF, HTML nebo obrázků?**

Ano. Aspose.Slides vykresluje graf a jeho zobrazenou datovou tabulku jako součást snímku při exportu do [PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/cs/nodejs-java/convert-powerpoint-to-html/) nebo [obrázků](/slides/cs/nodejs-java/convert-powerpoint-to-png/).

**Mohu pracovat s datovými tabulkami v grafech načtených ze šablony?**

Ano. Pro graf načtený z existující prezentace nebo šablony použijte [hasDataTable](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/hasdatatable/) a [setDataTable](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/setdatatable/), abyste zjistili nebo změnili, zda je jeho datová tabulka zobrazena.

**Jak mohu najít grafy, u nichž je povolena datová tabulka?**

Procházejte tvary na každém snímku, identifikujte grafy a zavolejte jejich metodu [hasDataTable](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/hasdatatable/). Hodnota `true` označuje, že je datová tabulka povolena.