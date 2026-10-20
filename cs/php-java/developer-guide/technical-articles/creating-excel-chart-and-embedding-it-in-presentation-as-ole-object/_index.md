---
title: Vytvořte grafy v Excelu a vložte je do prezentací jako OLE objekty
type: docs
weight: 30
url: /cs/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Graf Excelu
- vložit graf
- OLE objekt
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Vytvořte graf v Excelu pomocí Aspose.Cells pro PHP přes Java a vložte sešit do prezentace PowerPoint pomocí Aspose.Slides pro PHP přes Java, včetně náhledu grafu."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit sloupcový graf Excelu pomocí Aspose.Cells pro PHP přes Java a vložit jeho sešit do prezentace PowerPoint pomocí Aspose.Slides pro PHP přes Java. Vložený sešit obsahuje jak zdrojová data, tak graf. Samostatná náhledová PNG zobrazuje graf na snímku před aktivací objektu OLE. Výsledkem je vložený objekt Excel, nikoli nativní graf PowerPointu. Úprava sešitu přes OLE vyžaduje desktopovou aplikaci, která podporuje aktivaci OLE, a kompatibilní instalaci Excelu.

## **Požadavky**

Nastavte Aspose.Cells pro PHP přes Java a Aspose.Slides pro PHP přes Java pomocí stejné instance PHP/Java Bridge. Načtěte oba PHP wrappery a zpřístupněte Java knihovny obou produktů mostu. Microsoft Office není potřeba k vytvoření prezentace s těmito knihovnami.  
Vstupní soubory nejsou vyžadovány: příklad vytvoří data a graf v paměti a poté zapíše `OutputChart.pptx` do aktuálního pracovního adresáře. Použijte licence pro oba produkty při spuštění mimo evaluační režim.

## **Jak funguje vkládání**

1. Vytvořte sešit s datovým listem a listem grafu.  
1. Aktivujte list grafu, aby se sešit otevřel na grafu.  
1. Nastavte OLE zobrazovací rozsah sešitu a vykreslete graf do PNG.  
1. Uložte sešit jako XLSX v paměti a vložte tyto bajty do snímku.  
1. Přiřaďte PNG jako náhled OLE objektu a uložte prezentaci jako PPTX.

Zobrazovací rozsah sešitu a rámeček na snímku mají různé role. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) přijímá nulově indexované počáteční a koncové řádky a sloupce. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) naopak přijímá horní řádek, levý sloupec, dolní řádek a pravý sloupec. Příklad používá index řádku 55 a index sloupce 25 jako pravé dolní hranice; tyto hodnoty jsou volby rozvržení, nikoli počet datových řádků nebo sloupců.  
Rámeček snímku používá jednotku body. Příklad ho umístí do snímku a vystředí, přičemž zachová poměr stran PNG, místo aby náhled roztahoval na celou plochu snímku.

## **Vytvoření a vložení grafu**

Následující kompletní příklad naplní `DataSheet` čtyřmi řádky a pěti sloupci hodnot. Každý řádek se stane sérií grafu. `ChartSheet` je vybrán jako aktivní list před uložením sešitu.

Sešit je explicitně uložen jako XLSX, což odpovídá příponě `xlsx` předané do [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/). Číselné výsledky Java jsou převedeny pomocí `java_values` před provedením aritmetiky v PHP, zatímco binární data zůstávají v Java byte polích. PNG je načteno přímo z bajtů bez mezilehlé konverze bitmapy. Přiřazením přes [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) se nahradí výchozí OLE zástupce.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // Ponechte PNG a XLSX jako Java pole bajtů při předávání do Slides.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // Přizpůsobte a vystředit náhled při zachování poměru stran.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Očekávaný výsledek**

`OutputChart.pptx` obsahuje jeden snímek s vloženým sešitem Excel a náhledem grafu. Sešit obsahuje původní data a sloupcový graf se čtyřmi sériemi. Náhled je vystředěn na snímku a zachovává své proporce.

![Sloupcový graf Excelu zobrazený jako náhled vloženého sešitu](excel-chart-ole-preview.png)

V kompatibilním desktopovém prostředí PowerPoint s dostupným Excelem dvojitým kliknutím na objekt aktivujete a upravíte vložený sešit. Aktivace a úpravy závisí na podpoře OLE hostitelské aplikace a bezpečnostních nastaveních.

## **Často kladené otázky**

**Proč je potřeba obrázek náhledu?**  
Vložený sešit a jeho náhled na snímku jsou samostatný obsah. Poskytněte obrázek grafu, aby snímek zobrazoval graf místo výchozího zástupce „EMBEDDED OLE OBJECT“. Viz [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/php-java/object-preview-issue-when-adding-oleobjectframe/).

**Aktualizuje se náhled automaticky, když změníme sešit v kódu?**  
Náhled považujte za snímek. Při programatické aktualizaci dat sešitu vygenerujte znovu obrázek grafu a nahraďte náhled i data vloženého sešitu.

**Mohu použít XLS místo XLSX?**  
Ano. Uložte sešit ve formátu XLS a použijte `xls` jako příponu vložených dat. Přípona musí odpovídat skutečnému formátu sešitu; pouhá změna přípony neprovádí konverzi dat.

**Proč se objekt může po aktivaci změnit velikost?**  
Hostitelská aplikace může aktualizovat prezentaci OLE objektu při aktivaci sešitu. Záleží jak na OLE zobrazovacím rozsahu sešitu, tak na rozměrech rámečku snímku. Viz [Funkční řešení pro změnu velikosti grafu v PPTX](/slides/cs/java/working-solution-for-chart-resizing-in-pptx/).

## **Související sekce**

- [Funkční řešení pro změnu velikosti grafu v PPTX](/slides/cs/java/working-solution-for-chart-resizing-in-pptx/)
- [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [Správa OLE objektů](/slides/cs/php-java/manage-ole/)