---
title: Pracovní řešení pro změnu velikosti grafu v PPTX
type: docs
weight: 40
url: /cs/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- změna velikosti grafu
- graf Excelu
- OLE objekt
- vložit graf
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Opravte neočekávanou změnu velikosti grafu v PPTX při používání vložených OLE objektů Excel s Aspose.Slides pro PHP via Java. Nastavte pevné rozměry grafu, aby velikosti grafu a OLE rámce zůstaly konzistentní."
---
## **Přehled**

Grafy Excelu vložené jako OLE objekty v prezentacích PowerPoint pomocí komponent Aspose se mohou po první aktivaci změnit velikost. To může způsobit znatelný rozdíl v vzhledu grafu před a po aktivaci. Tento článek vysvětluje, proč dochází ke změně velikosti, a ukazuje, jak tomu zabránit nastavením pevných rozměrů grafu tak, aby odpovídaly OLE rámci.

In [Vytvořit grafy Excelu a vložit je jako OLE objekty v prezentacích](/slides/cs/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), jsme vysvětlili, jak vytvořit graf Excelu pomocí Aspose.Cells pro PHP via Java a vložit jej do prezentace PowerPoint pomocí Aspose.Slides pro PHP via Java. Pro řešení [problému s náhledem objektu](/slides/cs/php-java/object-preview-issue-when-adding-oleobjectframe/), jsme přiřadili obrázek grafu k OLE objektovému rámci grafu. V výstupní prezentaci, když dvakrát kliknete na OLE objektový rámec zobrazující obrázek grafu, graf Excelu se aktivuje. Uživatelé mohou upravovat vložený sešit Excel a poté se vrátit na snímek kliknutím mimo aktivovaný sešit. Velikost OLE objektového rámce se změní, když se uživatel vrátí na snímek, a faktor změny velikosti se liší v závislosti na původních rozměrech jak OLE objektového rámce, tak vloženého sešitu Excel.

## **Příčina změny velikosti**

Vložený sešit Excel má své vlastní rozměry okna, které se Excel snaží zachovat při první aktivaci objektu. OLE rámec na snímku má samostatně definované rozměry. Když je sešit Excel aktivován, Excel a PowerPoint vyjednávají velikost objektu, aby zachovaly jeho proporce jako součást procesu vkládání. Rozdíly mezi oknem sešitu a OLE rámcem tak mohou způsobit změnu velikosti objektu.

## **Funkční řešení**

Zarovnejte velikost grafu s OLE rámcem na snímku a udržujte rozměry grafu nezávislé na okně sešitu. Toto řešení funguje s novou prezentací i s existující šablonou.

Příklad vyžaduje Aspose.Cells pro PHP via Java a Aspose.Slides pro PHP via Java. Nakonfigurujte oba produkty se stejnou instancí PHP/Java Bridge, načtěte oba PHP wrappery a zpřístupněte oba Java knihovny mostu. Neněkteré vstupní soubory nejsou požadovány. Vytvoří jednoduchý sloupcový graf na aktivním listu grafu a vloží sešit ve formátu XLS. Náhledový obrázek grafu není přiřazen; graf se zobrazí, když je OLE objekt aktivován v PowerPointu.

Příklad vytvoří novou prezentaci s OLE rámcem o rozměrech 9,5 × 4 palce umístěným 0,5 palce od levého okraje a 1 palec od horního. Souřadnice a rozměry snímku jsou v bodech (72 bodů na palec). Pro existující prezentaci viz [Použít šablonu](#use-a-template).

## **Nastavte pevnou velikost grafu**

Nastavte [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) na false, aby rozměry grafu byly nezávislé na okně sešitu. Nastavte rozměry [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) pomocí [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) a [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height), přičemž převádíte body na pixely při 96 pixelech na palec: rámec měřící 684 × 288 bodů odpovídá grafu měřícímu 912 × 384 pixelů. Nastavte [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) na hodnotu CUSTOM typu [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/). Příklad vloží sešit pomocí [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) a uloží prezentaci s OLE rámcem o rozměrech 9,5 × 4 palce.

Číselné výsledky v Javě jsou před použitím jako PHP indexy převedeny pomocí `java_values`. Bity sešitu zůstávají v Java pole bajtů při předání do [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/).

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Souřadnice snímku a rozměry jsou v bodech (72 bodů na palec).
        $width = 684; // 9,5 palce.
        $height = 288; // 4 palce.

        $chart->setSizeWithWindow(false);
        // Převod bodů na pixely grafu při 96 pixelech na palec.
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Použít šablonu**

Logika velikosti je stejná pro existující prezentaci. Pro úpravu příkladu:

1. Načtěte šablonu prezentace místo vytváření prázdné prezentace.  
2. Zkontrolujte, že první snímek obsahuje alespoň tři tvary, a poté použijte tvar s indexem 2 jako zástupný znak.  
3. Vezměte šířku a výšku rámce z tohoto tvaru místo použití pevných hodnot 684 a 288. Nechte výpočty velikosti beze změny.  
4. Přidejte OLE rámec na pozici zástupného znaku místo pevných souřadnic 36 a 72.  
5. Odstraňte zástupný znak před uložením prezentace.

## **Často kladené otázky**

**Proč se můj vložený graf Excel mění po aktivaci v PowerPointu?**  
Odehrává se to, protože Excel se při první aktivaci snaží obnovit původní velikost okna, zatímco OLE objektový rámec v PowerPointu má vlastní rozměry. PowerPoint a Excel vyjednávají velikost tak, aby zachovaly poměr stran, což může vést ke změně velikosti.

**Jak mohu udržet konzistentní velikosti grafu a OLE rámce?**  
Nastavte pevné rozměry grafu, které odpovídají OLE rámci, a použijte vlastní velikost tisku grafu před vložením sešitu. Výše uvedený příklad ukazuje potřebná nastavení a převody jednotek.

**Je nastavení velikosti okna sešitu dostatečné?**  
Pouze nastavení velikosti okna sešitu nedokáže spolehlivě zabránit změně velikosti OLE rámce po aktivaci. Použijte pevné rozměry grafu, jak je ukázáno v příkladu.

**Funguje toto řešení jak pro prezentace založené na šabloně, tak pro nové prezentace?**  
Ano. Pro šablonu použijte rozměry a pozici zástupného znaku. Pro novou prezentaci zadejte rozměry a pozici rámce přímo.

**Mohu použít tento příklad s grafy vytvořenými v jiných tabulkových programech?**  
Příklad používá sešit Excel vytvořený pomocí Aspose.Cells. Nepředvádí chování aktivace pro jiné tabulkové programy.

## **Související sekce**

- [Vytvořit grafy Excelu a vložit je jako OLE objekty v prezentacích](/slides/cs/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)