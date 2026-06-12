---
title: Integrace dat z Excelu do prezentací PowerPoint
linktitle: Integrace Excelu
type: docs
weight: 330
url: /cs/nodejs-java/excel-integration/
keywords:
- Excel
- sešit
- čtení Excelu
- integrace Excelu
- zdroj dat
- hromadný dopis
- import tabulky
- Excel do PowerPointu
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Čtěte data ze sešitů Excel v JavaScriptu pomocí Aspose.Slides. Načtěte listy a buňky a použijte hodnoty k vytváření prezentací PowerPoint založených na datech."
---
## **Úvod**

Prezentace PowerPoint jsou mocným způsobem, jak zobrazovat a komunikovat informace. Často se používají v kombinaci se sešity Excel, kde Excel slouží jako vynikající zdroj strukturovaných dat a PowerPoint vyniká při vizualizaci těchto dat pro publikum.

Existuje mnoho praktických scénářů, kde je kombinace Excelu a PowerPointu nezbytná: hromadné dopisy, naplňování datových tabulek, generování jednoho snímku na záznam (hromadné vytváření snímků), tvorba výukových materiálů a konsolidace několika Excelových zpráv do jedné prezentace, jen několik příkladů.

Dosud implementace takových funkcí pomocí Aspose.Slides API vyžadovala spoléhat se na řešení třetích stran, jako je Aspose.Cells. Ačkoli jsou tyto nástroje robustní, mohou být příliš složité a nákladné pro uživatele, kteří potřebují jen základní funkce integrace dat.

## **Jak to funguje**

Aby bylo práce s daty v Excelu jednodušší a efektivnější, Aspose.Slides představilo nové třídy pro čtení dat ze sešitů Excel a importování obsahu do prezentace. Tato funkce otevírá mocné nové možnosti pro uživatele API, kteří chtějí využít Excel jako zdroj dat ve svých pracovních postupech s prezentacemi.

Nová funkčnost je navržena pro obecný přístup k datům a není integrována do objektového modelu dokumentu prezentace (DOM). To znamená, že *neumožňuje úpravy ani ukládání souborů Excel* — jejím jediným účelem je otevírat sešity a procházet jejich obsah za účelem získání dat buněk.

Jádrem této funkce je nová třída [ExcelDataWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/exceldataworkbook/). Tato třída vám umožňuje načíst sešit Excel z místního souboru nebo proudu. Po načtení poskytuje několik přetížení metody [getCell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/exceldataworkbook/#getCell), kterou můžete použít k získání konkrétních buněk podle jejich polohy (např. indexy řádku a sloupce nebo pojmenované oblasti).

Každé volání [getCell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/exceldataworkbook/#getCell) vrací instanci třídy [ExcelDataCell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/exceldatacell/). Tento objekt představuje jedinou buňku v sešitu Excel a poskytuje vám přístup k její hodnotě jednoduchým a intuitivním způsobem.

#### **Import Excelového grafu**

Dalším krokem k rozšíření funkčnosti je třída [ExcelWorkbookImporter](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/excelworkbookimporter/). Tato pomocná třída poskytuje funkci pro importování obsahu ze sešitu Excel do prezentace. Obsahuje několik přetížení metody [addChartFromWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), která vám pomůže získat vybraný graf z urnčeného sešitu Excel a přidat jej na konec zadané kolekce tvarů na specifikovaných souřadnicích.

Zkrátka, jde o lehké a jednoduché API pro čtení dat z Excelu — přesně to, co mnoho vývojářů potřebuje, aniž by museli používat kompletní knihovnu pro zpracování tabulek.

## **Pojďme kódit**

### **Příklad scénáře hromadného dopisu**

V následujícím příkladu implementujeme jednoduchý scénář hromadného dopisu tak, že vygenerujeme několik prezentací na základě dat uložených v sešitu Excel.

Pro zahájení potřebujeme dvě věci:
1. Sešit Excel obsahující data

![Příklad dat v Excelu](example1_image0.png)

2.  Šablona prezentace PowerPoint

![Příklad šablony PowerPoint](example1_image1.png)

```js
// Načtěte Excel sešit s údaji o zaměstnancích.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Načtěte šablonu prezentace.
let templatePresentation = new aspose.slides.Presentation("PresentationTemplate.pptx");

try {
    // Procházejte řádky Excelu (vyjma záhlaví v řádku 0).
    for (let rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Vytvořte novou prezentaci pro každý záznam zaměstnance.
        let employeePresentation = new aspose.slides.Presentation();

        try {
            // Odstraňte výchozí prázdný snímek.
            employeePresentation.getSlides().removeAt(0);

            // Klonujte šablonový snímek do nové prezentace.
            let slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Získejte odstavce z cílového tvaru (předpokládá se, že se používá index tvaru 1).
            let paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs();

            // Nahraďte zástupné symboly daty z Excelu.
            let employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            let namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            let department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            let departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            let yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            let yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Uložte personalizovanou prezentaci do samostatného souboru.
            employeePresentation.save(`${employeeName} Report.pptx`, aspose.slides.SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Výsledek](example1_image2.png)

### **Příklad tabulky v Excelu**

Ve druhém příkladu jednoduše zkopírujeme data z tabulky Excel a zobrazíme je na snímku PowerPoint v vizuálně atraktivnějším formátu.

V tomto příkladu znovu použijeme stejný sešit Excel z prvního příkladu, který obsahuje jednoduchou tabulku zaměstnanců.

```js
// Načtěte Excel sešit obsahující data o zaměstnancích.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Vytvořte novou PowerPoint prezentaci.
let presentation = new aspose.slides.Presentation();

try {
    // Přidejte tvar tabulky na první snímek.
    let table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            java.newArray("double", [200, 200, 200]),
            java.newArray("double", [30, 30, 30, 30, 30])
    );

    // Vyplňte tabulku v PowerPointu daty ze sešitu Excel.
    for (let rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (let columnIndex = 0; columnIndex < 3; columnIndex++) {
            let cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Uložte výslednou prezentaci do souboru.
    presentation.save("Table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Výsledek](example2_image0.png)

### **Příklad importu Excelového grafu**

V tomto příkladu importujeme graf z prvního listu sešitu Excel použitého v předchozím příkladu. Graf bude v konečné prezentaci odkazovat na externí sešit.

Nejprve přidáme koláčový graf do sešitu Excel na základě tabulky zaměstnanců.

![Příklad Excel grafu](example3_image0.png)

```js
// Vytvořte novou PowerPoint prezentaci.
let presentation = new aspose.slides.Presentation();
try {
    // Získejte kolekci tvarů z prvního snímku.
    let shapes = presentation.getSlides().get_Item(0).getShapes();

    // Importujte graf s názvem "Chart 1" z prvního listu sešitu a přidejte jej do kolekce tvarů.
    aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Uložte výslednou prezentaci do souboru.
    presentation.save("Chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Výsledek](example3_image1.png)

### **Příklad importu všech Excelových grafů**

Představte si, že máte sešit Excel plný grafů a potřebujete je všechny importovat do prezentace. Každý graf by měl být umístěn na nový snímek.

Následující kód prochází všechny listy ve zdrojovém souboru Excel, extrahuje grafy z každého listu a přidává každý graf na samostatný snímek pomocí prázdného rozvržení snímku. V konečné prezentaci bude vložen pouze datový obsah grafu, nikoli celý sešit.

```js
// Načtěte Excel sešit obsahující data o zaměstnancích.
let workbook = new aspose.slides.ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Vytvořte novou PowerPoint prezentaci.
let presentation = new aspose.slides.Presentation();
try {
    // Získejte prázdné rozložení snímku.
    let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

    // Získejte názvy všech listů obsažených v Excel sešitu.
    let worksheetNames = workbook.getWorksheetNames().iterator();

    while (worksheetNames.hasNext()) {
        let name = worksheetNames.next();
        // Získejte mapu, která mapuje indexy grafů na názvy grafů pro list.
        let worksheetCharts = workbook.getChartsFromWorksheet(name).iterator();

        while (worksheetCharts.hasNext()) {
            let chart = worksheetCharts.next();
            // Přidejte nový snímek s použitím prázdného rozložení.
            let slide = presentation.getSlides().addEmptySlide(layoutSlide);

            // Importujte určený graf z Excel sešitu do kolekce tvarů snímku.
            aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Uložte výslednou prezentaci do souboru.
    presentation.save("Charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Shrnutí**

Tento mechanismus, dostupný přímo v Aspose.Slides, kombinuje práci s daty v Excelu a prezentacemi na jednom místě. Umožňuje vám vytvářet snímky s vizuálními grafy a data prezentovat jako tabulky Excel — bez jakýchkoli dalších knihoven nebo složitých integrací.