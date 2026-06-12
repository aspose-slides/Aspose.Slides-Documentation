---
title: Integrace dat z Excelu do prezentací PowerPoint
linktitle: Integrace Excelu
type: docs
weight: 330
url: /cs/cpp/excel-integration/
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
- C++
- Aspose.Slides
description: "Čtěte data ze sešitů Excel v Aspose.Slides pomocí API ExcelDataWorkbook. Načtěte listy a buňky a použijte jejich hodnoty k vytváření PowerPoint prezentací řízených daty."
---
## **Úvod**

Prezentace PowerPoint jsou výkonný způsob, jak zobrazovat a komunikovat informace. Často se používají ve spojení s sešity Excel, kde Excel slouží jako vynikající zdroj strukturovaných dat a PowerPoint exceluje v vizualizaci těchto dat pro publikum.

Existuje mnoho praktických scénářů, kde je kombinace Excelu a PowerPointu nezbytná: hromadná korespondence, naplňování datových tabulek, generování jednoho snímku na každý záznam (dávkové generování snímků), tvorba výukových materiálů a konsolidace více Excelových reportů do jedné prezentace, jen vyjmenovat několik.

Dosud implementace takových funkcí pomocí Aspose.Slides API vyžadovala spoléhat se na řešení třetích stran, jako je Aspose.Cells. Přestože jsou tyto nástroje robustní, mohou být příliš složité a nákladné pro uživatele, kteří potřebují jen základní funkčnost integrace dat.

## **Jak to funguje**

Aby bylo práce s daty z Excelu jednodušší a přehlednější, Aspose.Slides zavedl nové třídy pro čtení dat ze sešitů Excel a importování obsahu do prezentace. Tato funkce otevírá výkonné nové možnosti pro uživatele API, kteří chtějí využít Excel jako zdroj dat ve svých pracovních postupech s prezentacemi.

Nová funkčnost je navržena pro obecný přístup k datům a není integrována do objektového modelu prezentace (DOM). To znamená, že *neumožňuje upravovat ani ukládat soubory Excel* — jejím jediným účelem je otevírat sešity a procházet jejich obsah za účelem získání dat z buněk.

V jádru této funkce je nová třída [ExcelDataWorkbook](https://reference.aspose.com/slides/cs/cpp/aspose.slides.excel/exceldataworkbook/). Tato třída vám umožňuje načíst sešit Excel z lokálního souboru nebo proudu. Po načtení poskytuje několik přetížení metody [GetCell](https://reference.aspose.com/slides/cs/cpp/aspose.slides.excel/exceldataworkbook/getcell/), kterou můžete použít k získání konkrétních buněk podle jejich pozice (např. podle indexů řádku a sloupce nebo pojmenovaných oblastí).

Každé volání [GetCell](https://reference.aspose.com/slides/cs/cpp/aspose.slides.excel/exceldataworkbook/getcell/) vrací instanci třídy [ExcelDataCell](https://reference.aspose.com/slides/cs/cpp/aspose.slides.excel/exceldatacell/). Tento objekt představuje jednu buňku v sešitu Excel a poskytuje vám přístup k její hodnotě jednoduchým a intuitivním způsobem.

#### **Import grafu z Excelu**

Dalším krokem k rozšíření funkčnosti je třída [ExcelWorkbookImporter](https://reference.aspose.com/slides/cs/cpp/aspose.slides.import/excelworkbookimporter/). Tato pomocná třída poskytuje funkce pro importování obsahu ze sešitu Excel do prezentace. Obsahuje několik přetížení metody [AddChartFromWorkbook](https://reference.aspose.com/slides/cs/cpp/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), které vám pomohou získat vybraný graf ze zadaného sešitu Excel a přidat jej na konec dané kolekce tvarů na specifikovaných souřadnicích.

Stručně řečeno, jde o odlehčené a jednoduché API pro čtení dat z Excelu — přesně to, co mnoho vývojářů potřebuje, aniž by museli používat plnohodnotnou knihovnu pro zpracování tabulek.

## **Pojďme kódit**

### **Příklad scénáře hromadné korespondence**

V následujícím příkladu implementujeme jednoduchý scénář hromadné korespondence tím, že vygenerujeme více prezentací na základě dat uložených v sešitu Excel.

Pro zahájení potřebujeme dvě věci:
1. Sešit Excel obsahující data
![Excel data example](example1_image0.png)
2. Šablona prezentace PowerPoint
![PowerPoint template example](example1_image1.png)

```cpp
// Načíst sešit Excel s údaji o zaměstnancích.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Načíst šablonu prezentace.
auto templatePresentation = MakeObject<Presentation>(u"PresentationTemplate.pptx");

    // Procházet řádky Excelu (s výjimkou hlavičky v řádku 0).
for (auto rowIndex = 1; rowIndex <= 4; rowIndex++) {

    // Vytvořit novou prezentaci pro každý záznam zaměstnance.
    auto employeePresentation = MakeObject<Presentation>();

    // Odebrat výchozí prázdný snímek.
    employeePresentation->get_Slides()->RemoveAt(0);

    // Klonovat šablonový snímek do nové prezentace.
    auto slide = employeePresentation->get_Slides()->AddClone(templatePresentation->get_Slide(0));

    // Získat odstavce z cílového tvaru (předpokládá se, že se používá index tvaru 1).
    auto paragraphs = ExplicitCast<IAutoShape>(slide->get_Shape(1))->get_TextFrame()->get_Paragraphs();

    // Nahradit zástupné symboly daty z Excelu.
    auto employeeName = workbook->GetCell(worksheetIndex, rowIndex, 0)->get_Value()->ToString();
    auto namePortion = paragraphs->idx_get(0)->get_Portion(0);
    namePortion->set_Text(namePortion->get_Text().Replace(u"{{EmployeeName}}", employeeName));

    auto department = workbook->GetCell(worksheetIndex, rowIndex, 1)->get_Value()->ToString();
    auto departmentPortion = paragraphs->idx_get(1)->get_Portion(0);
    departmentPortion->set_Text(departmentPortion->get_Text().Replace(u"{{Department}}", department));

    auto yearsOfService = workbook->GetCell(worksheetIndex, rowIndex, 2)->get_Value()->ToString();
    auto yearsPortion = paragraphs->idx_get(2)->get_Portion(0);
    yearsPortion->set_Text(yearsPortion->get_Text().Replace(u"{{YearsOfService}}", yearsOfService));

    // Uložit personalizovanou prezentaci do samostatného souboru.
    employeePresentation->Save(String::Format(u"{0} Report.pptx", employeeName), SaveFormat::Pptx);
    employeePresentation->Dispose();
}

templatePresentation->Dispose();
```

![Result](example1_image2.png)

### **Příklad tabulky Excel**

Ve druhém příkladu jednoduše zkopírujeme data z tabulky Excel a zobrazíme je na snímku PowerPoint ve vizuálně přitažlivější formě.

V tomto příkladu znovu použijeme stejný sešit Excel z prvního příkladu, který obsahuje jednoduchou tabulku zaměstnanců.

```cpp
// Načíst sešit Excel obsahující údaje o zaměstnancích.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Vytvořit novou prezentaci PowerPoint.
auto presentation = MakeObject<Presentation>();

// Přidat tvar tabulky na první snímek.
auto table = presentation->get_Slide(0)->get_Shapes()->AddTable(
    50, 200,
    MakeArray<double>({200, 200, 200}),
    MakeArray<double>({30, 30, 30, 30, 30})
);

// Vyplnit tabulku PowerPoint daty ze sešitu Excel.
for (auto rowIndex = 0; rowIndex < 5; rowIndex++) {
    for (auto columnIndex = 0; columnIndex < 3; columnIndex++) {
        auto cellValue = workbook->GetCell(worksheetIndex, rowIndex, columnIndex)->get_Value()->ToString();
        table->get_Column(columnIndex)->idx_get(rowIndex)->get_TextFrame()->set_Text(cellValue);
    }
}

// Uložit výslednou prezentaci do souboru.
presentation->Save(u"Table.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Result](example2_image0.png)

### **Příklad importu grafu z Excelu**

V tomto příkladu importujeme graf z první listu sešitu Excel použitého v předchozím příkladu. Graf bude v výsledné prezentaci odkazovat na externí sešit.

Nejprve přidáme koláčový graf do sešitu Excel na základě tabulky zaměstnanců.

![Excel Chart example](example3_image0.png)

```cpp
// Vytvořit novou prezentaci PowerPoint.
auto presentation = MakeObject<Presentation>();

// Získat kolekci tvarů z prvního snímku.
auto shapes = presentation->get_Slide(0)->get_Shapes();

// Importovat graf s názvem "Chart 1" z prvního listu sešitu a přidat jej do kolekce tvarů.
ExcelWorkbookImporter::AddChartFromWorkbook(shapes, 10.0, 10.0, u"TemplateData.xlsx", u"Sheet1", u"Chart 1", false);

// Uložit výslednou prezentaci do souboru.
presentation->Save(u"Chart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Result](example3_image1.png)

### **Příklad importu všech grafů z Excelu**

Představte si, že máte sešit Excel plný grafů a potřebujete je všechny importovat do prezentace. Každý graf by měl být umístěn na nový snímek.

Následující kód prochází všechny listy ve zdrojovém souboru Excel, extrahuje grafy z každého listu a přidá každý graf na samostatný snímek pomocí prázdného rozvržení snímku. V výsledné prezentaci bude vloženo pouze data grafu, nikoli celý sešit.

```cpp
// Načíst sešit Excel obsahující údaje o zaměstnancích.
auto workbook = MakeObject<ExcelDataWorkbook>(u"ExcelWithCharts.xlsx");

// Vytvořit novou prezentaci PowerPoint.
auto presentation = MakeObject<Presentation>();

// Získat rozvržení prázdného snímku.
auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Získat názvy všech listů obsažených v sešitu Excel.
auto worksheetNames = workbook->GetWorksheetNames();

for (auto&& name : worksheetNames)
{
    // Získat slovník, který mapuje indexy grafů na jejich názvy pro list.
    auto worksheetCharts = workbook->GetChartsFromWorksheet(name);

    for (auto&& chart : worksheetCharts)
    {
        // Přidat nový snímek pomocí prázdného rozvržení.
        auto slide = presentation->get_Slides()->AddEmptySlide(blankLayout);

        // Importovat určený graf ze sešitu Excel do kolekce tvarů snímku.
        ExcelWorkbookImporter::AddChartFromWorkbook(slide->get_Shapes(), 10.0, 10.0, workbook, name, chart.get_Key(), false);
    }
}

// Uložit výslednou prezentaci do souboru.
presentation->Save(u"Charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Shrnutí**

Tento mechanismus, dostupný přímo v Aspose.Slides, kombinuje práci s daty z Excelu a prezentacemi na jednom místě. Umožňuje vám vytvářet snímky s vizuálními grafy a data prezentovat jako tabulky Excel – bez dalších knihoven nebo složitých integrací.