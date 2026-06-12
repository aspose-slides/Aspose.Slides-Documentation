---
title: Integrovat data z Excelu do prezentací PowerPoint
linktitle: Integrace Excelu
type: docs
weight: 330
url: /cs/php-java/excel-integration/
keywords:
- Excel
- sešit
- číst Excel
- integrovat Excel
- datový zdroj
- hromadná korespondence
- importovat tabulku
- Excel do PowerPointu
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Číst data ze sešitů Excel pomocí Aspose.Slides pro PHP přes Java. Načíst listy a buňky a použít hodnoty k vytvoření prezentací PowerPoint řízených daty."
---
## **Úvod**

Prezentace PowerPoint jsou výkonným způsobem, jak zobrazovat a komunikovat informace. Často se používají společně se sešity Excel, kde Excel slouží jako vynikající zdroj strukturovaných dat a PowerPoint vyniká při vizualizaci těchto dat pro publikum.

Existuje mnoho praktických scénářů, kde je kombinace Excelu a PowerPointu nezbytná: hromadná korespondence, naplňování datových tabulek, generování jednoho slidu na každý datový záznam (dávkové vytváření slidů), vytváření výukových materiálů a konsolidace několika Excelových zpráv do jedné prezentace, jen vyjmenovat několik.

Dosud vyžadovalo implementaci takových funkcí pomocí API Aspose.Slides spoléhat na řešení třetích stran, jako je Aspose.Cells. Přestože jsou tyto nástroje robustní, mohou být pro uživatele, kteří potřebují pouze základní funkčnost integrace dat, příliš složité a nákladné.

## **Jak to funguje**

Aby bylo práce s daty Excel jednodušší a efektivnější, Aspose.Slides představila nové třídy pro čtení dat ze sešitů Excel a importování obsahu do prezentace. Tato funkce otevírá výkonné nové možnosti pro uživatele API, kteří chtějí využívat Excel jako zdroj dat ve svých pracovních postupech s prezentacemi.

Nová funkčnost je navržena pro obecný přístup k datům a není integrována do objektového modelu dokumentu prezentace (DOM). To znamená, že *neumožňuje upravovat ani ukládat soubory Excel* — jejím jediným účelem je otevírat sešity a procházet jejich obsah za účelem získání dat buněk.

Jádrem této funkce je nová třída [ExcelDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/exceldataworkbook/). Tato třída vám umožňuje načíst sešit Excel z lokálního souboru nebo proudu. Po načtení poskytuje několik přetížení metody [getCell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/exceldataworkbook/#getCell), kterou můžete použít k získání konkrétních buněk podle jejich umístění (např. indexy řádku a sloupce nebo pojmenované oblasti).

Každé volání [getCell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/exceldataworkbook/#getCell) vrací instanci třídy [ExcelDataCell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/exceldatacell/). Tento objekt představuje jednu buňku v sešitu Excel a poskytuje vám jednoduchý a intuitivní přístup k její hodnotě.

#### **Import Excelového grafu**

Dalším krokem pro rozšíření funkčnosti je třída [ExcelWorkbookImporter](https://reference.aspose.com/slides/cs/php-java/aspose.slides/excelworkbookimporter/). Tato pomocná třída poskytuje funkci pro importování obsahu ze sešitu Excel do prezentace. Obsahuje několik přetížení metody [addChartFromWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), které vám pomohou získat vybraný graf ze zadaného sešitu Excel a přidat jej na konec dané kolekce tvarů na zadaných souřadnicích.

Stručně řečeno, jde o lehké a přímé API pro čtení dat z Excelu — přesně to, co mnoha vývojářům chybí, bez zátěže kompletní knihovny pro zpracování tabulek.

## **Pojďme kódovat**

### **Příklad scénáře hromadné korespondence**

V následujícím příkladu implementujeme jednoduchý scénář hromadné korespondence generováním více prezentací na základě dat uložených v sešitu Excel.

Pro začátek potřebujeme dvě věci:
1. Sešit Excel obsahující data

![Příklad dat v Excelu](example1_image0.png)

2. Šablona prezentace PowerPoint

![Příklad šablony PowerPoint](example1_image1.png)

```php
// Načíst sešit Excel s údaji zaměstnanců.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Načíst šablonu prezentace.
$templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Procházet řádky Excelu (s výjimkou záhlaví v řádku 0).
    for ($rowIndex = 1; $rowIndex <= 4; $rowIndex++) {

        // Vytvořit novou prezentaci pro každý záznam zaměstnance.
        $employeePresentation = new Presentation();

        try {
            // Odstranit výchozí prázdný snímek.
            $employeePresentation->getSlides()->removeAt(0);

            // Zkopírovat šablonový snímek do nové prezentace.
            $slide = $employeePresentation->getSlides()->addClone($templatePresentation->getSlides()->get_Item(0));

            // Získat odstavce z cílového tvaru (předpokládá se, že se používá index tvaru 1).
            $paragraphs = $slide->getShapes()->get_Item(1)->getTextFrame()->getParagraphs();

            // Nahradit zástupné značky daty z Excelu.
            $employeeName = $workbook->getCell($worksheetIndex, $rowIndex, 0)->getValue()->toString();
            $namePortion = $paragraphs->get_Item(0)->getPortions()->get_Item(0);
            $namePortion->setText($namePortion->getText()->replace("{{EmployeeName}}", $employeeName));

            $department = $workbook->getCell($worksheetIndex, $rowIndex, 1)->getValue()->toString();
            $departmentPortion = $paragraphs->get_Item(1)->getPortions()->get_Item(0);
            $departmentPortion->setText($departmentPortion->getText()->replace("{{Department}}", $department));

            $yearsOfService = $workbook->getCell($worksheetIndex, $rowIndex, 2)->getValue()->toString();
            $yearsPortion = $paragraphs->get_Item(2)->getPortions()->get_Item(0);
            $yearsPortion->setText($yearsPortion->getText()->replace("{{YearsOfService}}", $yearsOfService));

            // Uložit personalizovanou prezentaci do samostatného souboru.
            $employeePresentation->save(sprintf("%s Report.pptx", $employeeName), SaveFormat::Pptx);
        } finally {
            $employeePresentation->dispose();
        }
    }
} finally {
    $templatePresentation->dispose();
}
```

![Výsledek](example1_image2.png)

### **Příklad tabulky Excel**

Ve druhém příkladu jednoduše zkopírujeme data z tabulky Excel a zobrazíme je na slidu PowerPoint v vizuálně atraktivnějším formátu.

V tomto příkladu znovu použijeme stejný sešit Excel z prvního příkladu, který obsahuje jednoduchou tabulku zaměstnanců.

```php
// Načíst sešit Excel obsahující data zaměstnanců.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Vytvořit novou prezentaci PowerPoint.
$presentation = new Presentation();

try {
    // Přidat tvar tabulky na první snímek.
    $table = $presentation->getSlides()->get_Item(0)->getShapes()->addTable(
            50, 200,
            array(200, 200, 200),
            array(30, 30, 30, 30, 30)
    );

    // Vyplnit tabulku PowerPoint daty ze sešitu Excel.
    for ($rowIndex = 0; $rowIndex < 5; $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < 3; $columnIndex++) {
            $cellValue = $workbook->getCell($worksheetIndex, $rowIndex, $columnIndex)->getValue()->toString();
            $table->getColumns()->get_Item($columnIndex)->get_Item($rowIndex)->getTextFrame()->setText($cellValue);
        }
    }

    // Uložit výslednou prezentaci do souboru.
    $presentation->save("Table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Výsledek](example2_image0.png)

### **Příklad importu Excelového grafu**

V tomto příkladu importujeme graf z prvního listu sešitu Excel použitého v předchozím příkladu. Graf bude v výsledné prezentaci odkazovat na externí sešit.

Nejprve přidáme koláčový graf do sešitu Excel na základě tabulky zaměstnanců.

![Příklad grafu v Excelu](example3_image0.png)

```php
// Vytvořit novou prezentaci PowerPoint.
$presentation = new Presentation();
try {
    // Získat kolekci tvarů prvního snímku.
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    // Importovat graf s názvem "Chart 1" z prvního listu sešitu a přidat jej do kolekce tvarů.
    ExcelWorkbookImporter::addChartFromWorkbook($shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Uložit výslednou prezentaci do souboru.
    $presentation->save("Chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Výsledek](example3_image1.png)

### **Příklad importu všech grafů Excel**

Představte si, že máte sešit Excel plný grafů a potřebujete je všechny importovat do prezentace. Každý graf by měl být umístěn na nový slide.

Následující kód prochází všechny listy ve zdrojovém souboru Excel, extrahuje grafy z každého listu a přidá každý graf na samostatný slide pomocí prázdného rozvržení slidu. Ve výsledné prezentaci bude vložen pouze datový obsah grafu, nikoli celý sešit.

```php
// Načíst sešit Excel obsahující data zaměstnanců.
$workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Vytvořit novou prezentaci PowerPoint.
$presentation = new Presentation();
try {
    // Získat šablonu prázdného snímku.
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Získat názvy všech listů obsažených v sešitu Excel.
    $worksheetNames = $workbook->getWorksheetNames()->iterator();

    while (java_values($worksheetNames->hasNext())) {
        $name = $worksheetNames->next();
        // Získat mapu, která mapuje indexy grafů na názvy grafů pro list.
        $worksheetCharts = $workbook->getChartsFromWorksheet($name)->iterator();

        while (java_values($worksheetCharts->hasNext())) {
            $chart = $worksheetCharts->next();
            // Přidat nový snímek pomocí prázdné šablony.
            $slide = $presentation->getSlides()->addEmptySlide($blankLayout);

            // Importovat zadaný graf ze sešitu Excel do kolekce tvarů snímku.
            ExcelWorkbookImporter::addChartFromWorkbook(
                    $slide->getShapes(), 10, 10, $workbook, $name, $chart->getKey(), false);
        }
    }

    // Uložit výslednou prezentaci do souboru.
    $presentation->save("Charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Shrnutí**

Tento mechanismus, dostupný přímo v Aspose.Slides, spojuje práci s daty Excel a prezentacemi na jednom místě. Umožňuje vám vytvářet slidy s vizuálními grafy a daty prezentovanými jako tabulky Excel – bez jakýchkoli dalších knihoven či složitých integrací.