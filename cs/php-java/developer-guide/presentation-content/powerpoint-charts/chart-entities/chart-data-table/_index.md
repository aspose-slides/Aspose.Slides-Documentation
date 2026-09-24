---
title: Přizpůsobení datových tabulek grafů v prezentacích pomocí PHP
linktitle: Datová tabulka
type: docs
url: /cs/php-java/chart-data-table/
keywords:
- data grafu
- datová tabulka
- vlastnosti písma
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Přizpůsobte písma, okraje a legendové klíče datových tabulek grafů v prezentacích PowerPoint pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Aspose.Slides for PHP přes Java vám umožňuje zobrazit datovou tabulku grafu a přizpůsobit její formátování textu, okraje a legendové klíče. Tento článek vysvětluje, jak povolit tabulku, naformátovat text, ovládat každý typ okraje a zobrazit nebo skrýt legendové klíče. Příklady ukládají nakonfigurované grafy do souborů PPTX.

## **Nastavení vlastností písma**

Chcete-li zobrazit datovou tabulku grafu, předejte `true` metodě [setDataTable](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/setdatatable/). Pro přístup k tabulce a nastavení formátování textu použijte [getChartDataTable](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/getchartdatatable/).

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Přidejte seskupený sloupcový graf na první snímek.
1. Povolte datovou tabulku grafu.
1. Povolte tučný text pomocí [setFontBold](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setFontBold) a předejte `20` metodě [setFontHeight](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setFontHeight) pro 20‑bodový text.
1. Uložte upravenou prezentaci.

Následující příklad vyžaduje soubor `test.pptx` v pracovním adresáři s alespoň jedním snímkem. Přidá graf s výchozími daty na pozici (50, 50) o šířce 600 bodů a výšce 400 bodů. Uložený soubor `output.pptx` obsahuje graf s povolenou datovou tabulkou a aplikovanými zadanými nastaveními písma.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Přizpůsobení ohraničení datové tabulky**

Povolte tabulku metodou [Chart::setDataTable](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/setdatatable/) a přistupujte k ní přes [Chart::getChartDataTable](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/getchartdatatable/). Můžete nezávisle řídit tři typy okrajů:

- [setBorderHorizontal](https://reference.aspose.com/slides/cs/php-java/aspose.slides/datatable/setborderhorizontal/) řídí vodorovné okraje buněk.
- [setBorderVertical](https://reference.aspose.com/slides/cs/php-java/aspose.slides/datatable/setbordervertical/) řídí svislé okraje buněk.
- [setBorderOutline](https://reference.aspose.com/slides/cs/php-java/aspose.slides/datatable/setborderoutline/) řídí vnější okraj tabulky.

Předejte `true` každé metodě, chcete‑li zobrazit její okraje, nebo `false`, chcete‑li je skrýt. Následující příklad vytvoří seskupený sloupcový graf s výchozími daty, zobrazí vodorovné okraje a vnější okraj a skryje svislé okraje. Nevytváří žádný vstupní soubor. Pozice a velikost grafu jsou zadány v bodech.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Porovnání níže používá stejná data grafu a nastavení legendového klíče ve všech čtyřech případech. Začíná se se všemi okraji povoleny, přičemž každá následující varianta zakáže právě jeden typ okraje. Varianta vlevo dole odpovídá nastavení okrajů v příkladu.

![Datové tabulky grafu se všemi okraji povoleny, bez vodorovných okrajů, bez svislých okrajů a bez vnějšího okraje](data-table-borders.png)

## **Zobrazení nebo skrytí legendových klíčů**

Legendové klíče jsou malé barevné značky vedle názvů řad v datové tabulce. Pomáhají čtenářům přiřadit každý řádek tabulky k odpovídající řadě grafu. Předejte `true` metodě [setShowLegendKey](https://reference.aspose.com/slides/cs/php-java/aspose.slides/datatable/setshowlegendkey/) k zobrazení těchto značek nebo `false` k jejich skrytí.

Samostatná legenda grafu je řízena metodou [Chart::setLegend](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/setlegend/). Tato nastavení jsou nezávislá: skrytí samostatné legendy neskryje klíče uvnitř datové tabulky a skrytí klíčů v tabulce neskryje samostatnou legendu.

Následující příklad vytvoří graf s výchozími daty, povolí jeho datovou tabulku a zobrazí v ní legendové klíče při skrytí samostatné legendy. Všechny okraje tabulky jsou výslovně povoleny. Vstupní prezentace není vyžadována. Chcete‑li skrýt pouze klíče tabulky, předejte `false` metodě [setShowLegendKey](https://reference.aspose.com/slides/cs/php-java/aspose.slides/datatable/setshowlegendkey/).

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Porovnání níže ukazuje stejnou tabulku s povolenými a zakázanými legendovými klíči. Všechny okraje zůstávají povoleny a samostatná legenda grafu je skryta v obou případech.

![Datové tabulky grafu s legendovými klíči zobrazenými vlevo a skrytými vpravo](data-table-legend-keys.png)

## **FAQ**

**Mohu zobrazit legendové klíče v datové tabulce grafu?**

Ano. Předejte `true` metodě [setShowLegendKey](https://reference.aspose.com/slides/cs/php-java/aspose.slides/datatable/setshowlegendkey/) k zobrazení legendových klíčů nebo `false` k jejich skrytí.

**Zůstane datová tabulka zachována při exportu prezentace do PDF, HTML nebo obrázků?**

Ano. Aspose.Slides renderuje graf a jeho zobrazenou datovou tabulku jako součást snímku při exportu do [PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/cs/php-java/convert-powerpoint-to-html/) nebo [images](/slides/cs/php-java/convert-powerpoint-to-png/).

**Mohu pracovat s datovými tabulkami v grafech načtených ze šablony?**

Ano. Pro graf načtený z existující prezentace nebo šablony použijte [hasDataTable](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/hasdatatable/) a [setDataTable](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/setdatatable/) k ověření nebo změně, zda je jeho datová tabulka zobrazena.

**Jak mohu najít grafy, u kterých je povolena datová tabulka?**

Procházejte tvary na každém snímku, identifikujte grafy a zavolejte jejich metodu [hasDataTable](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/hasdatatable/). Hodnota `true` označuje, že je datová tabulka povolena.