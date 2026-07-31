---
title: Integrovat data z Excelu do prezentací PowerPoint
linktitle: Integrace Excelu
type: docs
weight: 330
url: /cs/net/excel-integration/
aliases:
  - /net/developer-guide/technical-articles/excel-integration/
keywords:
- Excel
- sešit
- číst Excel
- integrovat Excel
- zdroj dat
- hromadná korespondence
- importovat tabulku
- Excel do PowerPointu
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Číst data ze sešitů Excel v Aspose.Slides pomocí API ExcelDataWorkbook. Načtěte listy a buňky a použijte hodnoty k vytváření datově řízených prezentací PowerPoint."
---
## **Úvod**

Prezentace PowerPoint jsou výkonným způsobem, jak zobrazovat a předávat informace. Často se používají ve spojení s sešity Excel, kde Excel slouží jako vynikající zdroj strukturovaných dat a PowerPoint je skvělý při vizualizaci těchto dat pro publikum.

Existuje mnoho praktických situací, kdy je kombinace Excelu a PowerPointu nezbytná: hromadná korespondence, naplňování datových tabulek, generování jedné snímky na jeden záznam (dávkové vytváření snímků), tvorba výukových materiálů a konsolidace několika Excelových zpráv do jediné prezentace, jen tak několik příkladů.

Dosud bylo nutné pro implementaci takových funkcí s API Aspose.Slides spoléhat na řešení třetích stran, jako je Aspose.Cells. Ačkoliv jsou tyto nástroje robustní, mohou být pro uživatele, kteří potřebují jen základní funkci integrace dat, zbytečně složité a nákladné.

## **Jak to funguje**

Aby bylo práce s daty z Excelu jednodušší a efektivnější, Aspose.Slides zavedl nové třídy pro čtení dat ze sešitů Excel a importování obsahu do prezentace. Tato funkce otevírá silné nové možnosti pro uživatele API, kteří chtějí využít Excel jako zdroj dat ve svých pracovních postupech s prezentacemi.

Nová funkčnost je zamýšlena pro obecný přístup k datům a není integrována do Document Object Modelu (DOM) prezentace. To znamená, že *neumožňuje editaci ani ukládání souborů Excel* — její jediným účelem je otevřít sešit a procházet jeho obsah pro získání hodnot buněk.

V jádru této funkce stojí nová třída [ExcelDataWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.excel/exceldataworkbook/). Tato třída umožňuje načíst sešit Excel z místního souboru nebo proudu. Jakmile je načten, poskytuje několik přetížených metod [GetCell](https://reference.aspose.com/slides/cs/net/aspose.slides.excel/exceldataworkbook/getcell/), které můžete použít k získání konkrétních buněk podle jejich pozice (např. indexy řádku a sloupce nebo pojmenované oblasti).

Každé volání [GetCell](https://reference.aspose.com/slides/cs/net/aspose.slides.excel/exceldataworkbook/getcell/) vrací instanci třídy [ExcelDataCell](https://reference.aspose.com/slides/cs/net/aspose.slides.excel/exceldatacell/). Tento objekt představuje jednu buňku v sešitu Excel a poskytuje vám přístup k její hodnotě jednoduchým a intuitivním způsobem.

#### **Importovat Excel graf**

Dalším krokem rozšiřujícím funkčnost je třída [ExcelWorkbookImporter](https://reference.aspose.com/slides/cs/net/aspose.slides.import/excelworkbookimporter/). Tato pomocná třída poskytuje funkci pro importování obsahu ze sešitu Excel do prezentace. Obsahuje několik přetížených metod [AddChartFromWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), které vám pomohou získat vybraný graf ze zadaného sešitu Excel a přidat jej na konec dané kolekce tvarů na zadaných souřadnicích.

#### **Importovat Excel tabulku**

Třída [ExcelWorkbookImporter](https://reference.aspose.com/slides/cs/net/aspose.slides.import/excelworkbookimporter/) obsahuje také několik přetížených metod [AddTableFromWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/). Tyto metody vám umožní importovat určený rozsah buněk z určeného listu a přidat jej jako tabulku na konec dané kolekce tvarů na zadaných souřadnicích.

Stručně řečeno, jedná se o odlehčené a přímočaré API pro čtení dat z Excelu — přesně to, co mnoho vývojářů potřebuje, aniž by museli používat kompletní knihovnu pro zpracování tabulek.

## **Pojďme programovat**

### **Příklad scénáře hromadné korespondence**

V následujícím příkladu vytvoříme jednoduchý scénář hromadné korespondence generováním více prezentací na základě dat uložených v sešitu Excel.

Pro zahájení potřebujeme dvě věci:
1. Sešit Excel obsahující data

![Příklad dat v Excelu](example1_image0.png)

2. Šablonu prezentace PowerPoint

![Příklad šablony PowerPointu](example1_image1.png)

```csharp
// Načíst sešit Excel s údaji o zaměstnancích.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Načíst šablonu prezentace.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Procházet řádky Excelu (vyjma hlavičky na řádku 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Vytvořit novou prezentaci pro každý záznam zaměstnance.
    using Presentation employeePresentation = new Presentation();

    // Odstranit výchozí prázdný snímek.
    employeePresentation.Slides.RemoveAt(0);

    // Zkopírovat šablonový snímek do nové prezentace.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Získat odstavce z cílového tvaru (předpokládá se, že se používá index tvaru 1).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Nahradit zástupné symboly daty z Excelu.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Uložit personalizovanou prezentaci do samostatného souboru.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Výsledek](example1_image2.png)

### **Příklad tabulky Excel**

Ve druhém příkladu jednoduše zkopírujeme data z tabulky Excel a zobrazíme je na snímku PowerPoint v esteticky příjemnějším formátu.

V tomto příkladu znovu použijeme stejný sešit Excel z prvního příkladu, který obsahuje jednoduchou tabulku zaměstnanců.

```csharp
// Načíst sešit Excel obsahující údaje o zaměstnancích.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Vytvořit novou prezentaci PowerPoint.
using Presentation presentation = new Presentation();

// Přidat tvar tabulky na první snímek.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Vyplnit tabulku PowerPoint daty ze sešitu Excel.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Uložit výslednou prezentaci do souboru.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Výsledek](example2_image0.png)

### **Příklad importu Excel grafu**

V tomto příkladu importujeme graf z prvního listu sešitu Excel použitého v předchozím příkladu. Graf bude v výsledné prezentaci propojen s externím sešitem.

Nejprve do sešitu Excel přidáme koláčový graf založený na tabulce zaměstnanců.

![Příklad Excel grafu](example3_image0.png)

```csharp
// Vytvořit novou prezentaci PowerPoint.
using Presentation presentation = new Presentation();

// Získat kolekci tvarů z prvního snímku.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importovat graf nazvaný "Chart 1" z prvního listu sešitu a přidat jej do kolekce tvarů.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Uložit výslednou prezentaci do souboru.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Výsledek](example3_image1.png)

### **Příklad importu všech Excel grafů**

Představte si, že máte sešit Excel plný grafů a potřebujete je všechny importovat do prezentace. Každý graf by měl být umístěn na novém snímku.

Následující kód prochází všechny listy ve zdrojovém souboru Excel, extrahuje grafy z každého listu a přidá každý graf na samostatný snímek pomocí prázdného rozvržení snímku. Ve výsledné prezentaci budou vložena pouze data grafu, nikoli celý sešit.

```csharp
// Načíst sešit Excel obsahující údaje o zaměstnancích.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Vytvořit novou prezentaci PowerPoint.
using Presentation presentation = new Presentation();

// Získat prázdné rozvržení snímku.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Získat názvy všech listů obsažených v sešitu Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Získat slovník, který mapuje indexy grafů na názvy grafů pro list.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Přidat nový snímek pomocí prázdného rozvržení.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Importovat určený graf ze sešitu Excel do kolekce tvarů snímku.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Uložit výslednou prezentaci do souboru.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Příklad importu Excel tabulky**

V tomto příkladu importujeme naformátovanou tabulku z listu Excel přímo do prezentace PowerPoint.

Zdrojový list Excel obsahuje naformátovanou tabulku s údaji o zaměstnancích:

![Příklad Excel tabulky](example4_image0.png)

```csharp
// Vytvořit novou prezentaci PowerPoint.
using Presentation presentation = new Presentation();

// Získat kolekci tvarů z prvního snímku.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importovat tabulku z prvního listu sešitu a přidat ji do kolekce tvarů.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Uložit výslednou prezentaci do souboru.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![Výsledek](example4_image1.png)


## **Shrnutí**

Tento mechanismus, dostupný přímo v Aspose.Slides, kombinuje práci s daty z Excelu a prezentacemi na jednom místě. Umožňuje vám vytvářet snímky s vizuálními grafy a daty prezentovanými jako Excel tabulky — bez jakýchkoli dalších knihoven nebo složitých integrací.