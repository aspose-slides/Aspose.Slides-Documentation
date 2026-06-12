---
title: Integrace dat z Excelu do prezentací PowerPoint
linktitle: Integrace Excel
type: docs
weight: 330
url: /cs/androidjava/excel-integration/
keywords:
- Excel
- sešit
- číst Excel
- integrovat Excel
- zdroj dat
- hromadná korespondence
- importovat tabulku
- Excel do PowerPoint
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Čtěte data ze sešitů Excel v Aspose.Slides pomocí API ExcelDataWorkbook. Načtěte listy a buňky a použijte hodnoty k vytvoření PowerPoint prezentací řízených daty."
---
## **Úvod**

Prezentace v PowerPoint jsou výkonným způsobem, jak zobrazit a předat informace. Často se používají spolu s sešity Excel, kde Excel slouží jako vynikající zdroj strukturovaných dat a PowerPoint vyniká v jejich vizualizaci pro publikum.

Existuje mnoho praktických scénářů, kde je kombinace Excel a PowerPoint nezbytná: hromadná korespondence, naplňování datových tabulek, generování jedné snímky na záznam (dávkové generování snímků), tvorba výukových materiálů a konsolidace několika Excelových reportů do jedné prezentace, jen vyjmenovat několik.

Dosud implementace takových funkcí pomocí Aspose.Slides API vyžadovala spoléhat se na řešení třetích stran, jako je Aspose.Cells. Ačkoli jsou tyto nástroje robustní, mohou být pro uživatele, kteří potřebují jen základní funkci integrace dat, příliš složité a nákladné.

## **Jak to funguje**

Aby práce s daty v Excelu byla jednodušší a plynulejší, Aspose.Slides zavedl nové třídy pro čtení dat ze sešitů Excel a importování obsahu do prezentace. Tato funkce otevírá výkonné nové možnosti pro uživatele API, kteří chtějí využít Excel jako zdroj dat ve svých pracovních postupech s prezentacemi.

Nová funkčnost je navržena pro obecný přístup k datům a není integrována do objektového modelu dokumentu prezentace (DOM). To znamená, že *neumožňuje upravovat ani ukládat soubory Excel* — jejím jediným účelem je otevřít sešity a procházet jejich obsah za účelem získání dat buněk.

V jádru této funkce je nová třída [ExcelDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/exceldataworkbook/). Tato třída vám umožní načíst sešit Excel z lokálního souboru nebo proudu. Po načtení poskytuje několik přetížení metody [getCell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-), kterou můžete použít k získání konkrétních buněk podle jejich pozice (např. indexy řádku a sloupce nebo pojmenované oblasti).

Každé volání [getCell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) vrací instanci třídy [ExcelDataCell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/exceldatacell/). Tento objekt představuje jednu buňku v sešitu Excel a poskytuje vám přístup k její hodnotě jednoduchým a intuitivním způsobem.

#### **Import grafu z Excelu**

Dalším krokem pro rozšíření funkčnosti je třída [ExcelWorkbookImporter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/excelworkbookimporter/). Tato pomocná třída poskytuje funkci pro importování obsahu ze sešitu Excel do prezentace. Obsahuje několik přetížení metody [addChartFromWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-), která vám pomáhá získat vybraný graf ze zadaného sešitu Excel a přidat jej na konec dané kolekce tvarů na určených souřadnicích.

Stručně řečeno, jde o lehké a jednoduché API pro čtení dat z Excelu — přesně to, co mnoho vývojářů potřebuje, aniž by museli používat kompletní knihovnu pro zpracování tabulek.

## **Pojďme kódovat**

### **Příklad scénáře hromadné korespondence**

V následujícím příkladu implementujeme jednoduchý scénář hromadné korespondence vytvořením několika prezentací na základě dat uložených v sešitu Excel.

Pro začátek potřebujeme dvě věci:
1. Sešit Excel obsahující data

![Příklad dat v Excelu](example1_image0.png)

2. Šablona prezentace PowerPoint

![Příklad šablony PowerPoint](example1_image1.png)

```java
// Načtěte sešit Excel s údaji o zaměstnancích.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Načtěte šablonu prezentace.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Procházejte řádky Excelu (vyjma záhlaví na řádku 0).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Vytvořte novou prezentaci pro každý záznam zaměstnance.
        Presentation employeePresentation = new Presentation();

        try {
            // Odeberte výchozí prázdnou snímku.
            employeePresentation.getSlides().removeAt(0);

            // Klonujte šablonový snímek do nové prezentace.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Získejte odstavce z cílového tvaru (předpokládá se, že se používá index tvaru 1).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // Nahraďte zástupné znaky daty z Excelu.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Uložte personalizovanou prezentaci do samostatného souboru.
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

Ve druhém příkladu jednoduše zkopírujeme data z tabulky Excel a zobrazíme je na snímku PowerPoint v vizuálně atraktivnější podobě.

V tomto příkladu znovu použijeme stejný sešit Excel z prvního příkladu, který obsahuje jednoduchou tabulku zaměstnanců.

```java
// Načtěte sešit Excel obsahující data o zaměstnancích.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Vytvořte novou prezentaci PowerPoint.
Presentation presentation = new Presentation();

try {
    // Přidejte tvar tabulky na první snímek.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // Vyplňte tabulku PowerPoint daty ze sešitu Excel.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Uložte výslednou prezentaci do souboru.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Výsledek](example2_image0.png)

### **Příklad importu grafu z Excelu**

V tomto příkladu importujeme graf z prvního listu sešitu Excel použitého v předchozím příkladu. Graf bude v výsledné prezentaci odkazovat na externí sešit.

Nejprve přidáme koláčový graf do sešitu Excel na základě tabulky zaměstnanců.

![Příklad grafu v Excelu](example3_image0.png)

```java
// Vytvořte novou prezentaci PowerPoint.
Presentation presentation = new Presentation();
try {
    // Získejte kolekci tvarů z prvního snímku.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // Importujte graf pojmenovaný "Chart 1" z prvního listu sešitu a přidejte jej do kolekce tvarů.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Uložte výslednou prezentaci do souboru.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Výsledek](example3_image1.png)

### **Příklad importu všech grafů z Excelu**

Představte si, že máte sešit Excel plný grafů a potřebujete je všechny importovat do prezentace. Každý graf by měl být umístěn na novém snímku.

Následující kód prochází všechny listy ve zdrojovém souboru Excel, extrahuje grafy z každého listu a přidá každý graf na samostatný snímek pomocí prázdného rozložení snímku. Ve výsledné prezentaci bude vložena pouze data grafu, nikoli celý sešit.

```java
// Načtěte sešit Excel obsahující data o zaměstnancích.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Vytvořte novou prezentaci PowerPoint.
Presentation presentation = new Presentation();
try {
    // Získejte prázdné rozložení snímku.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Získejte názvy všech listů obsažených v sešitu Excel.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // Získejte mapu, která mapuje indexy grafů na názvy grafů pro tento list.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // Přidejte nový snímek pomocí prázdného rozložení.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // Importujte specifikovaný graf ze sešitu Excel do kolekce tvarů snímku.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Uložte výslednou prezentaci do souboru.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Shrnutí**

Tento mechanismus, dostupný přímo v Aspose.Slides, spojuje práci s daty z Excelu a prezentacemi na jednom místě. Umožňuje vám vytvářet snímky s vizuálními grafy a daty prezentovanými jako tabulky Excel – bez jakýchkoli dalších knihoven či složitých integrací.