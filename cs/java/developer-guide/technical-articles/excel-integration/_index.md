---
title: Integrovat data z Excelu do prezentací PowerPoint
linktitle: Integrace Excelu
type: docs
weight: 330
url: /cs/java/excel-integration/
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
- Java
- Aspose.Slides
description: "Čtěte data ze sešitů Excel v Aspose.Slides pomocí API ExcelDataWorkbook. Načtěte listy a buňky a použijte hodnoty k vytváření datově řízených prezentací PowerPoint."
---
## **Úvod**

Prezentace PowerPoint jsou výkonným způsobem, jak zobrazovat a komunikovat informace. Často se používají ve spojení s sešity Excel, kde Excel slouží jako vynikající zdroj strukturovaných dat a PowerPoint vyniká v jejich vizualizaci pro publikum.

Existuje mnoho praktických scénářů, kde je kombinace Excelu a PowerPointu nezbytná: hromadná korespondence, vyplňování datových tabulek, generování jedné snímky na každý záznam (dávkové generování snímků), tvorba výukových materiálů a konsolidace několika Excelových reportů do jedné prezentace, jen některé z nich.

Doposud vyžadovalo implementování takových funkcí pomocí Aspose.Slides API spoléhat na třetí strany jako Aspose.Cells. Přestože jsou tyto nástroje robustní, mohou být pro uživatele, kteří potřebují jen základní funkci integrace dat, zbytečně složité a nákladné.

## **Jak to funguje**

Aby byl práci s daty v Excelu jednodušší a efektivnější, Aspose.Slides zavedl nové třídy pro čtení dat ze sešitů Excel a importování obsahu do prezentace. Tato funkce otevírá uživatelům API nové možnosti, jak využít Excel jako zdroj dat v jejich pracovních postupech s prezentacemi.

Nová funkčnost je navržena pro obecný přístup k datům a není integrována do objektového modelu dokumentu prezentace (DOM). To znamená, že *nedovoluje upravovat ani ukládat soubory Excel* – jejím jediným účelem je otevřít sešity a procházet jejich obsah za účelem získání hodnot buněk.

V jádru této funkce stojí nová třída [ExcelDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/exceldataworkbook/). Tato třída vám umožňuje načíst sešit Excel z lokálního souboru nebo proudu. Po načtení poskytuje několik přetížených verzí metody [getCell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-), kterou můžete použít k získání konkrétních buněk podle jejich pozice (např. podle indexů řádku a sloupce nebo pojmenovaných oblastí).

Každé volání [getCell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) vrací instanci třídy [ExcelDataCell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/exceldatacell/). Tento objekt představuje jednu buňku v sešitu Excel a poskytuje jednoduchý a intuitivní přístup k její hodnotě.

#### **Import grafu z Excelu**

Dalším krokem k rozšíření funkčnosti je třída [ExcelWorkbookImporter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/excelworkbookimporter/). Tato utilitní třída poskytuje funkce pro import obsahu ze sešitu Excel do prezentace. Obsahuje několik přetížených verzí metody [addChartFromWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-), která pomáhá získat vybraný graf ze zadaného sešitu Excel a přidat jej na konec dané kolekce tvarů na specifikovaných souřadnicích.

Stručně řečeno, jde o lehké a přímočaré API pro čtení dat z Excelu – přesně to, co mnoho vývojářů potřebuje, aniž by museli zatěžovat kompletní knihovnou pro zpracování tabulek.

## **Pojďme kódovat**

### **Příklad scénáře hromadné korespondence**

V následujícím příkladu implementujeme jednoduchý scénář hromadné korespondence tím, že vygenerujeme více prezentací na základě dat uložených v sešitu Excel.

Pro zahájení potřebujeme dvě věci:
1. Sešit Excel obsahující data

![Příklad Excel dat](example1_image0.png)

2. Šablonu prezentace PowerPoint

![Příklad šablony PowerPoint](example1_image1.png)

```java
// Načíst sešit Excel s daty zaměstnanců.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Načíst šablonu prezentace.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Procházet řádky Excelu (vyjma hlavičky na řádku 0).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Vytvořit novou prezentaci pro každý záznam zaměstnance.
        Presentation employeePresentation = new Presentation();

        try {
            // Odstranit výchozí prázdný snímek.
            employeePresentation.getSlides().removeAt(0);

            // Zkopírovat šablonový snímek do nové prezentace.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Získat odstavce z cílového tvaru (předpokládá se, že je používán index tvaru 1).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // Nahradit zástupné symboly daty z Excelu.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Uložit personalizovanou prezentaci do samostatného souboru.
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Výsledek](example1_image2.png)

### **Příklad tabulky Excel**

Ve druhém příkladu jednoduše zkopírujeme data z tabulky Excel a zobrazíme je na snímku PowerPoint ve vizuálně atraktivnějším formátu.

V tomto příkladu znovu použijeme stejný sešit Excel z prvního příkladu, který obsahuje jednoduchou tabulku zaměstnanců.

```java
// Načíst sešit Excel obsahující data zaměstnanců.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Vytvořit novou prezentaci PowerPoint.
Presentation presentation = new Presentation();

try {
    // Přidat tvar tabulky na první snímek.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // Vyplnit tabulku PowerPoint daty ze sešitu Excel.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Uložit výslednou prezentaci do souboru.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Výsledek](example2_image0.png)

### **Příklad importu grafu z Excelu**

V tomto příkladu importujeme graf z první listu sešitu Excel použitého v předchozím příkladu. Graf bude v výsledné prezentaci propojen s externím sešitem.

Nejprve přidáme koláčový graf do sešitu Excel na základě tabulky zaměstnanců.

![Příklad grafu v Excelu](example3_image0.png)

```java
// Vytvořit novou prezentaci PowerPoint.
Presentation presentation = new Presentation();
try {
    // Získat kolekci tvarů prvního snímku.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // Importovat graf s názvem "Chart 1" z prvního listu sešitu a přidat jej do kolekce tvarů.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Uložit výslednou prezentaci do souboru.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Výsledek](example3_image1.png)

### **Příklad importu všech grafů z Excelu**

Představte si, že máte sešit Excel plný grafů a potřebujete je všechny importovat do prezentace. Každý graf by měl být umístěn na nový snímek.

Následující kód prochází všechny listy ve zdrojovém souboru Excel, extrahuje grafy z každého listu a přidá každý graf na samostatný snímek pomocí prázdného rozvržení snímku. V výsledné prezentaci bude embedována pouze data grafu, ne celý sešit.

```java
// Načíst sešit Excel obsahující data zaměstnanců.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Vytvořit novou prezentaci PowerPoint.
Presentation presentation = new Presentation();
try {
    // Získat prázdné rozložení snímku.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Získat názvy všech listů obsažených v sešitu Excel.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // Získat mapu, která mapuje indexy grafů na názvy grafů pro list.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // Přidat nový snímek s použitím prázdného rozložení.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // Importovat zadaný graf ze sešitu Excel do kolekce tvarů snímku.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Uložit výslednou prezentaci do souboru.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Shrnutí**

Tento mechanismus, dostupný přímo v Aspose.Slides, spojuje práci s daty v Excelu a prezentacemi na jednom místě. Umožňuje vytvářet snímky s vizuálními grafy a daty prezentovanými jako tabulky Excel – bez jakýchkoli dalších knihoven nebo složitých integrací.