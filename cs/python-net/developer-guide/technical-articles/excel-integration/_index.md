---
title: Integrace dat z Excelu do prezentací PowerPoint
linktitle: Integrace Excelu
type: docs
weight: 330
url: /cs/python-net/excel-integration/
keywords:
- Excel
- sešit
- čtení Excelu
- integrace Excelu
- zdroj dat
- hromadná korespondence
- import tabulky
- Excel do PowerPointu
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Čtěte data ze sešitů Excel v Aspose.Slides pomocí API ExcelDataWorkbook. Načtěte listy a buňky a použijte jejich hodnoty k vytvoření prezentací PowerPoint založených na datech."
---
## **Úvod**

Prezentace PowerPoint jsou silným nástrojem pro zobrazování a komunikaci informací. Často se používají ve spojení se sešity Excel, kde Excel funguje jako vynikající zdroj strukturovaných dat a PowerPoint vyniká v jejich vizualizaci pro publikum.

Existuje mnoho praktických scénářů, kde je kombinace Excelu a PowerPointu nezbytná: hromadné korespondence, naplňování datových tabulek, generování jedné snímky pro každý záznam (hromadná tvorba snímků), tvorba výukových materiálů a konsolidace několika Excelových reportů do jedné prezentace, jen některé z nich.

Dosud vyžadovalo implementaci takových funkcí pomocí API Aspose.Slides spoléhat na řešení třetích stran, jako je Aspose.Cells. Ačkoli jsou tyto nástroje robustní, mohou být pro uživatele, kteří potřebují jen základní funkci integrace dat, příliš složité a nákladné.

## **Jak to funguje**

Aby bylo práce s daty z Excelu jednodušší a plynulejší, Aspose.Slides představila nové třídy pro čtení dat ze sešitů Excel a import obsahu do prezentace. Tato funkce otevírá mocné nové možnosti pro uživatele API, kteří chtějí využívat Excel jako zdroj dat ve svých pracovních tocích s prezentacemi.

Nová funkcionalita je navržena pro obecný přístup k datům a není integrována do Document Object Modelu (DOM) prezentace. To znamená, že *neumožňuje editaci ani uložení souborů Excel* – jejím jediným účelem je otevřít sešit a procházet jeho obsah za účelem získání hodnot buněk.

V jádru této funkce je nová třída [ExcelDataWorkbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.excel/exceldataworkbook/). Tato třída umožňuje načíst sešit Excel ze souboru na disku nebo ze streamu. Po načtení poskytuje několik přetížených metod [get_cell](https://reference.aspose.com/slides/cs/python-net/aspose.slides.excel/exceldataworkbook/get_cell/), které můžete použít k načtení konkrétních buněk podle jejich pozice (např. index řádku a sloupce nebo pojmenované oblasti).

Každé volání [get_cell](https://reference.aspose.com/slides/cs/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) vrací instanci třídy [ExcelDataCell](https://reference.aspose.com/slides/cs/python-net/aspose.slides.excel/exceldatacell/). Tento objekt představuje jednu buňku v sešitu Excel a poskytuje jednoduchý a intuitivní přístup k její hodnotě.

#### **Import Excelového grafu**

Dalším krokem k rozšíření funkčnosti je třída [ExcelWorkbookImporter](https://reference.aspose.com/slides/cs/python-net/aspose.slides.importing/excelworkbookimporter/). Tato pomocná třída poskytuje funkci pro import obsahu ze sešitu Excel do prezentace. Obsahuje několik přetížených metod [add_chart_from_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.importing/excelworkbookimporter/add_chart_from_workbook/), které pomáhají načíst vybraný graf ze zadaného sešitu Excel a přidat jej na konec určené kolekce tvarů na zadaných souřadnicích.

Stručně řečeno, jde o lehké a přímočaré API pro čtení dat z Excelu – přesně to, co mnoho vývojářů potřebuje, aniž by museli využívat plnohodnotnou knihovnu pro zpracování tabulek.

## **Pojďme kódit**

### **Příklad scénáře hromadné korespondence**

V následujícím příkladu implementujeme jednoduchý scénář hromadné korespondence vytvořením několika prezentací na základě dat uložených v sešitu Excel.

Pro zahájení potřebujeme dvě věci:
1. Excelový sešit obsahující data

![Příklad dat v Excelu](example1_image0.png)

2. Šablona prezentace PowerPoint

![Příklad šablony PowerPointu](example1_image1.png)

```py
import aspose.slides as slides

# Načtěte sešit Excel s údaji o zaměstnancích.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Načtěte šablonu prezentace.
with slides.Presentation("PresentationTemplate.pptx") as template_presentation:

    # Procházejte řádky Excelu (vynecháním záhlaví v řádku 0).
    for row_index in range(1, 5):

        # Vytvořte novou prezentaci pro každý záznam zaměstnance.
        with slides.Presentation() as employee_presentation:

            # Odstraňte výchozí prázdný snímek.
            employee_presentation.slides.remove_at(0)

            # Zkopírujte šablonový snímek do nové prezentace.
            slide = employee_presentation.slides.add_clone(template_presentation.slides[0])

            # Získejte odstavce z cílového tvaru (předpokládá se použití indexu tvaru 1).
            paragraphs = slide.shapes[1].text_frame.paragraphs

            # Nahraďte zástupné znaky daty z Excelu.
            employee_name = workbook.get_cell(worksheet_index, row_index, 0).value
            name_portion = paragraphs[0].portions[0]
            name_portion.text = name_portion.text.replace("{{EmployeeName}}", employee_name)

            department = workbook.get_cell(worksheet_index, row_index, 1).value
            department_portion = paragraphs[1].portions[0]
            department_portion.text = department_portion.text.replace("{{Department}}", department)

            years_of_service = str(workbook.get_cell(worksheet_index, row_index, 2).value)
            years_portion = paragraphs[2].portions[0]
            years_portion.text = years_portion.text.replace("{{YearsOfService}}", years_of_service)

            # Uložte personalizovanou prezentaci do samostatného souboru.
            employee_presentation.save(f"{employee_name} Report.pptx", slides.export.SaveFormat.PPTX)
```

![Výsledek](example1_image2.png)

### **Příklad Excelové tabulky**

Ve druhém příkladu jednoduše zkopírujeme data z Excelové tabulky a zobrazíme je na snímku PowerPointu v atraktivnějším formátu.

V tomto příkladu znovu použijeme stejný sešit Excel z prvního příkladu, který obsahuje jednoduchou tabulku zaměstnanců.

```py
# Načtěte sešit Excel obsahující údaje o zaměstnancích.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Vytvořte novou prezentaci PowerPoint.
with slides.Presentation() as presentation:

    # Přidejte tvar tabulky na první snímek.
    table = presentation.slides[0].shapes.add_table(
        50, 200,
        [200, 200, 200],
        [30, 30, 30, 30, 30]
    )

    # Vyplňte tabulku PowerPoint daty ze sešitu Excel.
    for row_index in range(0, 5):
        for column_index in range(0, 3):
            cell_value = str(workbook.get_cell(worksheet_index, row_index, column_index).value)
            table.columns[column_index][row_index].text_frame.text = cell_value

    # Uložte výslednou prezentaci do souboru.
    presentation.save("Table.pptx", slides.export.SaveFormat.PPTX)
```

![Výsledek](example2_image0.png)

### **Příklad importu Excelového grafu**

V tomto příkladu importujeme graf z prvního listu sešitu Excel použitého v předchozím příkladu. Graf bude v výsledné prezentaci odkazovat na externí sešit.

Nejprve přidáme koláčový graf do sešitu Excel na základě tabulky zaměstnanců.

![Příklad Excelového grafu](example3_image0.png)

```py
# Vytvořte novou prezentaci PowerPoint.
with slides.Presentation() as presentation:
    # Získat kolekci tvarů z prvního snímku.
    shapes = presentation.slides[0].shapes

    # Importujte graf s názvem "Chart 1" z prvního listu sešitu a přidejte jej do kolekce tvarů.
    slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
        shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Uložte výslednou prezentaci do souboru.
    presentation.save("Chart.pptx", slides.export.SaveFormat.PPTX)
```

![Výsledek](example3_image1.png)

### **Příklad importu všech Excelových grafů**

Představte si, že máte sešit Excel plný grafů a potřebujete je všechny importovat do prezentace. Každý graf by měl být umístěn na nový snímek.

Následující kód prochází všechny listy ve zdrojovém souboru Excel, extrahuje grafy z každého listu a přidává každý graf na samostatný snímek pomocí prázdného rozvržení snímku. Ve výsledné prezentaci bude vložen pouze datový obsah grafu, nikoli celý sešit.

```py
# Načtěte sešit Excel obsahující údaje o zaměstnancích.
workbook = slides.excel.ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Vytvořte novou prezentaci PowerPoint.
with slides.Presentation() as presentation:
    # Získejte rozložení prázdného snímku.
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Získejte názvy všech listů obsažených v sešitu Excel.
    worksheet_names = workbook.get_worksheet_names()

    for name in worksheet_names:
        # Získejte slovník, který mapuje indexy grafů na názvy grafů pro list.
        worksheet_charts = workbook.get_charts_from_worksheet(name)
        
        for chart in worksheet_charts:
            # Přidejte nový snímek s použitím prázdného rozložení.
            slide = presentation.slides.add_empty_slide(blank_layout)

            # Importujte určený graf ze sešitu Excel do kolekce tvarů snímku.
            slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
                slide.shapes, 10, 10, workbook, name, chart.key, False)

    # Uložte výslednou prezentaci do souboru.
    presentation.save("Charts.pptx", slides.export.SaveFormat.PPTX)
```

## **Shrnutí**

Tento mechanismus, dostupný přímo v Aspose.Slides, spojuje práci s daty z Excelu a prezentacemi na jednom místě. Umožňuje vytvářet snímky s vizuálními grafy a daty prezentovanými jako Excelové tabulky – bez dalších knihoven nebo složitých integrací.