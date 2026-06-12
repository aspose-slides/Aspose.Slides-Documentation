---
title: Integrace dat z Excelu do prezentací PowerPoint
linktitle: Integrace Excelu
type: docs
weight: 330
url: /cs/net/excel-integration/
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
- .NET
- C#
- Aspose.Slides
description: "Čtěte data ze sešitů Excel v Aspose.Slides pomocí API ExcelDataWorkbook. Načtěte listy a buňky a použijte jejich hodnoty k vytvoření datově řízených prezentací PowerPoint."
---
## **Úvod**

Prezentace PowerPoint jsou výkonným způsobem, jak zobrazovat a předávat informace. Často se používají spolu se sešity Excel, kde Excel slouží jako vynikající zdroj strukturovaných dat a PowerPoint vyniká v jejich vizualizaci pro publikum.

Existuje mnoho praktických scénářů, kde je kombinace Excelu a PowerPointu nezbytná: hromadná korespondence, naplňování tabulek daty, generování jedné snímku na záznam (dávkové generování snímků), tvorba výukových materiálů a konsolidace několika Excelových reportů do jediné prezentace, abychom jen vyjmenovali některé.

Dosud implementace takových funkcí pomocí API Aspose.Slides vyžadovala spoléhat se na řešení třetích stran, jako je Aspose.Cells. I když jsou tyto nástroje robustní, mohou být pro uživatele, kteří potřebují jen základní funkci integrace dat, příliš složité a nákladné.

## **Jak to funguje**

Aby bylo práce s daty v Excelu jednodušší a efektivnější, Aspose.Slides zavedl nové třídy pro čtení dat ze sešitů Excel a importování obsahu do prezentace. Tato funkce otevírá silné nové možnosti pro uživatele API, kteří chtějí využívat Excel jako zdroj dat ve svých pracovních postupech s prezentacemi.

Nová funkčnost je navržena pro obecný přístup k datům a není integrována do Presentation Document Object Model (DOM). To znamená, že *neumožňuje upravovat ani ukládat soubory Excel* — jejím jediným účelem je otevřít sešity a procházet jejich obsah za účelem získání dat z buněk.

V jádru této funkce je nová třída [ExcelDataWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.excel/exceldataworkbook/). Tato třída vám umožňuje načíst sešit Excel z lokálního souboru nebo proudu. Po načtení poskytuje několik přetížení metody [GetCell](https://reference.aspose.com/slides/cs/net/aspose.slides.excel/exceldataworkbook/getcell/), kterou můžete použít k získání konkrétních buněk podle jejich umístění (např. indexy řádku a sloupce nebo pojmenované rozsahy).

Každé volání [GetCell](https://reference.aspose.com/slides/cs/net/aspose.slides.excel/exceldataworkbook/getcell/) vrací instanci třídy [ExcelDataCell](https://reference.aspose.com/slides/cs/net/aspose.slides.excel/exceldatacell/). Tento objekt představuje jednu buňku v sešitu Excel a poskytuje vám přístup k její hodnotě jednoduchým a intuitivním způsobem.

#### **Importovat Excel graf**

Dalším krokem rozšíření funkčnosti je třída [ExcelWorkbookImporter](https://reference.aspose.com/slides/cs/net/aspose.slides.import/excelworkbookimporter/). Tato pomocná třída poskytuje funkci pro import obsahu ze sešitu Excel do prezentace. Obsahuje několik přetížení metody [AddChartFromWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), které vám pomohou získat vybraný graf z určeného sešitu Excel a přidat jej na konec dané kolekce tvarů na uvedených souřadnicích.

Stručně řečeno, jedná se o lehké a přímé API pro čtení dat z Excelu — přesně to, co mnoho vývojářů potřebuje, aniž by museli zatěžovat kompletní knihovnou pro zpracování tabulek.

## **Pojďme kódovat**

### **Příklad scénáře hromadné korespondence**

V následujícím příkladu implementujeme jednoduchý scénář hromadné korespondence tím, že vygenerujeme několik prezentací na základě dat uložených v sešitě Excel.

Abyste mohli začít, potřebujete dvě věci:
1. Sešit Excel obsahující data

![Příklad dat v Excelu](example1_image0.png)

2. Šablona prezentace PowerPoint

![Příklad šablony PowerPointu](example1_image1.png)

```csharp
// Načtěte sešit Excel s údaji o zaměstnancích.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Načtěte šablonu prezentace.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Procházejte řádky Excelu (s výjimkou hlavičky na řádku 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Vytvořte novou prezentaci pro každý záznam zaměstnance.
    using Presentation employeePresentation = new Presentation();

    // Odstraňte výchozí prázdný snímek.
    employeePresentation.Slides.RemoveAt(0);

    // Zkopírujte šablonový snímek do nové prezentace.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Získejte odstavce z cílového tvaru (předpokládá se, že se používá index tvaru 1).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Nahraďte zástupné symboly daty z Excelu.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Uložte personalizovanou prezentaci do samostatného souboru.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Výsledek](example1_image2.png)

### **Příklad tabulky v Excelu**

Ve druhém příkladu jednoduše zkopírujeme data z tabulky v Excelu a zobrazíme je na snímku PowerPointu ve vizuálně atraktivnějším formátu.

V tomto příkladu znovu použijeme ten samý sešit Excel z prvního příkladu, který obsahuje jednoduchou tabulku zaměstnanců.

```csharp
// Načtěte sešit Excel obsahující údaje o zaměstnancích.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Vytvořte novou prezentaci PowerPoint.
using Presentation presentation = new Presentation();

// Přidejte tvar tabulky na první snímek.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Vyplňte tabulku PowerPoint daty ze sešitu Excel.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Uložte výslednou prezentaci do souboru.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Výsledek](example2_image0.png)

### **Příklad importu Excel grafu**

V tomto příkladu importujeme graf z první listu sešitu Excel použitého v předchozím příkladu. Graf bude odkazovat na externí sešit ve výsledné prezentaci.

Nejprve přidáme koláčový graf do sešitu Excel na základě tabulky zaměstnanců.

![Příklad Excel grafu](example3_image0.png)

```csharp
// Vytvořte novou prezentaci PowerPoint.
using Presentation presentation = new Presentation();

// Získejte kolekci tvarů z prvního snímku.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importujte graf s názvem "Chart 1" z prvního listu sešitu a přidejte ho do kolekce tvarů.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Uložte výslednou prezentaci do souboru.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Výsledek](example3_image1.png)

### **Příklad importu všech Excel grafů**

Představte si, že máte sešit Excel plný grafů a potřebujete je všechny importovat do prezentace. Každý graf by měl být umístěn na novém snímku.

Následující kód prochází všechny listy ve zdrojovém souboru Excel, extrahuje grafy z každého listu a přidá každý graf na samostatný snímek pomocí rozvržení prázdného snímku. Ve výsledné prezentaci bude vložen pouze datový obsah grafu, nikoli celý sešit.

```csharp
// Načtěte sešit Excel obsahující údaje o zaměstnancích.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Vytvořte novou prezentaci PowerPoint.
using Presentation presentation = new Presentation();

// Získejte rozložení prázdného snímku.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Získejte názvy všech listů obsažených v sešitu Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Získejte slovník, který mapuje indexy grafů na názvy grafů pro list.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Přidejte nový snímek pomocí prázdného rozložení.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Importujte zvolený graf ze sešitu Excel do kolekce tvarů snímku.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Uložte výslednou prezentaci do souboru.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

## **Shrnutí**

Tento mechanismus, dostupný přímo v Aspose.Slides, spojuje práci s daty v Excelu a prezentacemi na jednom místě. Umožňuje vám vytvářet snímky s vizuálními grafy a data prezentovat jako tabulky Excel — bez jakýchkoli dalších knihoven či složitých integrací.