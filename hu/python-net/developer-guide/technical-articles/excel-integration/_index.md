---
title: Excel adatok integrálása PowerPoint prezentációkba
linktitle: Excel integráció
type: docs
weight: 330
url: /hu/python-net/excel-integration/
keywords:
- Excel
- munkafüzet
- Excel olvasása
- Excel integrálása
- adatforrás
- levélösszefűzés
- táblázat importálása
- Excel PowerPointba
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Olvassa be az adatokat Excel-munkafüzetekből az Aspose.Slides segítségével az ExcelDataWorkbook API használatával. Töltse be a lapokat és cellákat, majd használja az értékeket adatvezérelt PowerPoint prezentációk létrehozásához."
---
## **Bevezetés**

A PowerPoint-prezentációk hatékony módja az információk megjelenítésének és közvetítésének. Gyakran használják őket Excel-munkafüzetekkel együtt, ahol az Excel kiváló struktúrált adatforrás, a PowerPoint pedig az adatok vizualizálásában jeleskedik a közönség számára.

Számos gyakorlati helyzetben elengedhetetlen az Excel és a PowerPoint kombinálása: levélösszefűzés, adatbázis táblák feltöltése, egy diát generálni minden adatrekordhoz (csoportos dia generálás), képzési anyagok létrehozása, valamint több Excel-jelentés egyetlen prezentációba történő egyesítése, csak felsorolásként néhányat.

Eddig az ilyen funkciók megvalósítása az Aspose.Slides API-val harmadik fél megoldásaira, például az Aspose.Cells-re támaszkodott. Bár ezek az eszközök robusztusak, túl bonyolultak és költségesek lehetnek azok számára, akiknek csak alapvető adatintegrációs funkcióra van szükségük.

## **Hogyan működik**

Az Excel-adatokkal való munka megkönnyítése és egyszerűsítése érdekében az Aspose.Slides új osztályokat vezetett be az Excel-munkafüzetek adatainak olvasásához és a tartalom prezentációba importálásához. Ez a funkció új, erőteljes lehetőségeket nyit meg az API felhasználói számára, akik az Excelt adatforrásként kívánják használni a prezentációs munkafolyamataikban.

Az új funkcionalitás általános adatlekérdezésre készült, és nincs integrálva a Presentation Document Object Model (DOM)-ba. Ez azt jelenti, hogy *nem teszi lehetővé az Excel-fájlok szerkesztését vagy mentését* – egyetlen célja a munkafüzetek megnyitása és tartalmukban való navigálás a cellaadatok lekérdezéséhez.

A funkció középpontjában az új [ExcelDataWorkbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.excel/exceldataworkbook/) osztály áll. Ez az osztály lehetővé teszi, hogy egy Excel-munkafüzetet helyi fájlból vagy adatfolyamból töltsön be. Betöltés után több overloadot biztosít a [get_cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) metódushoz, amelyet a cellák pozíciója (például sor- és oszlopindex vagy név alapján) alapján történő lekérdezésre használhat.

A [get_cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) minden hívása egy [ExcelDataCell](https://reference.aspose.com/slides/hu/python-net/aspose.slides.excel/exceldatacell/) osztálypéldányt ad vissza. Ez az objektum egyetlen cellát képvisel az Excel-munkafüzetben, és egyszerű, intuitív módon biztosít hozzáférést annak értékéhez.

#### **Excel-diagram importálása**

A következő lépés a funkcionalitás kibővítéséhez a [ExcelWorkbookImporter](https://reference.aspose.com/slides/hu/python-net/aspose.slides.importing/excelworkbookimporter/) osztály. Ez a segédosztály lehetővé teszi az Excel-munkafüzet tartalmának importálását egy prezentációba. Több overloadot tartalmaz a [add_chart_from_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.importing/excelworkbookimporter/add_chart_from_workbook/) metódushoz, amely segít a kiválasztott diagramot a megadott Excel-munkafüzetből lekérni és a megadott koordinátákon a shape gyűjtemény végéhez hozzáadni.

Röviden, ez egy könnyű és egyszerű API az Excel-adatok olvasásához – pontosan azt, amire sok fejlesztőnek szüksége van anélkül, hogy egy teljes táblázatfeldolgozó könyvtár többletterhelését viselné.

## **Kódoljunk**

### **Levélösszefűzés szcenárió példa**

A következő példában egy egyszerű Levélösszefűzés szcenáriót valósítunk meg több prezentáció generálásával, amelyek az Excel-munkafüzetben tárolt adatokon alapulnak.

A kezdéshez két dologra van szükségünk:
1. Egy Excel-munkafüzet, amely tartalmazza az adatokat

![Excel adatok példája](example1_image0.png)

2. PowerPoint prezentációs sablon

![PowerPoint sablon példája](example1_image1.png)

```py
import aspose.slides as slides

# Töltsd be az alkalmazotti adatokat tartalmazó Excel-munkafüzetet.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Töltsd be a prezentáció sablont.
with slides.Presentation("PresentationTemplate.pptx") as template_presentation:

    # Iterálj végig az Excel sorain (kivéve a 0. fejlécsort).
    for row_index in range(1, 5):

        # Hozz létre egy új prezentációt minden alkalmazotti rekordhoz.
        with slides.Presentation() as employee_presentation:

            # Távolítsd el az alapértelmezett üres diát.
            employee_presentation.slides.remove_at(0)

            # Klónozd a sablon diát az új prezentációba.
            slide = employee_presentation.slides.add_clone(template_presentation.slides[0])

            # Szerezz be bekezdéseket a cél alakzatból (feltételezve, hogy az 1. indexű shape használatos).
            paragraphs = slide.shapes[1].text_frame.paragraphs

            # Cseréld le a helyőrzőket az Excel adataival.
            employee_name = workbook.get_cell(worksheet_index, row_index, 0).value
            name_portion = paragraphs[0].portions[0]
            name_portion.text = name_portion.text.replace("{{EmployeeName}}", employee_name)

            department = workbook.get_cell(worksheet_index, row_index, 1).value
            department_portion = paragraphs[1].portions[0]
            department_portion.text = department_portion.text.replace("{{Department}}", department)

            years_of_service = str(workbook.get_cell(worksheet_index, row_index, 2).value)
            years_portion = paragraphs[2].portions[0]
            years_portion.text = years_portion.text.replace("{{YearsOfService}}", years_of_service)

            # Mentsd el a személyre szabott prezentációt egy külön fájlba.
            employee_presentation.save(f"{employee_name} Report.pptx", slides.export.SaveFormat.PPTX)
```

![Eredmény](example1_image2.png)

### **Excel tábla példa**

A második példában egyszerűen átmásoljuk az adatokat egy Excel-táblából, és egy PowerPoint-diára jelenítjük meg vizuálisan vonzóbb formában.

Ebben a példában újra felhasználjuk az első példában szereplő ugyanazt az Excel-munkafüzetet, amely egy egyszerű alkalmazotti táblát tartalmaz.

```py
# Töltsd be az alkalmazotti adatokat tartalmazó Excel-munkafüzetet.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Hozz létre egy új PowerPoint prezentációt.
with slides.Presentation() as presentation:

    # Adj hozzá egy táblázat alakzatot az első diához.
    table = presentation.slides[0].shapes.add_table(
        50, 200,
        [200, 200, 200],
        [30, 30, 30, 30, 30]
    )

    # Töltsd fel a PowerPoint táblázatot az Excel-munkafüzet adataival.
    for row_index in range(0, 5):
        for column_index in range(0, 3):
            cell_value = str(workbook.get_cell(worksheet_index, row_index, column_index).value)
            table.columns[column_index][row_index].text_frame.text = cell_value

    # Mentsd el a létrehozott prezentációt egy fájlba.
    presentation.save("Table.pptx", slides.export.SaveFormat.PPTX)
```

![Eredmény](example2_image0.png)

### **Excel-diagram importálása példa**

Ebben a példában egy diagramot importálunk az előző példában használt Excel-munkafüzet első munkalapjáról. A diagram a végső prezentációban hivatkozni fog a külső munkafüzetre.

Először egy kördiagramot adunk hozzá az Excel-munkafüzethez az alkalmazotti tábla alapján.

![Excel diagram példa](example3_image0.png)

```py
# Hozz létre egy új PowerPoint prezentációt.
with slides.Presentation() as presentation:
    # Szerezd meg az első dia alakzatgyűjteményét.
    shapes = presentation.slides[0].shapes

    # Importáld a "Chart 1" nevű diagramot a munkafüzet első lapjáról, és add hozzá az alakzatgyűjteményhez.
    slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
        shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Mentsd el a létrehozott prezentációt egy fájlba.
    presentation.save("Chart.pptx", slides.export.SaveFormat.PPTX)
```

![Eredmény](example3_image1.png)

### **Minden Excel-diagram importálása példa**

Képzeljük el, hogy van egy Excel-munkafüzet, amely tele van diagramokkal, és ezeket mind importálni kell egy prezentációba. Minden diagramot egy új diára kell helyezni.

Az alábbi kód végig iterál a forrás Excel-fájl összes munkalapján, kinyeri a diagramokat minden munkalapról, és minden diagramot egy külön diára helyez el egy üres diarendezés használatával. A végső prezentációban csak a diagramadatok lesznek beágyazva, nem az egész munkafüzet.

```py
# Töltsd be az alkalmazotti adatokat tartalmazó Excel-munkafüzetet.
workbook = slides.excel.ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Hozz létre egy új PowerPoint prezentációt.
with slides.Presentation() as presentation:
    # Szerezd meg az üres diák elrendezését.
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Szerezd meg az Excel-munkafüzetben található összes munkalap nevét.
    worksheet_names = workbook.get_worksheet_names()

    for name in worksheet_names:
        # Szerezd meg a szótárat, amely a diagram indexeket a munkalap diagramneveire mapálja.
        worksheet_charts = workbook.get_charts_from_worksheet(name)
        
        for chart in worksheet_charts:
            # Adj hozzá egy új diát az üres elrendezés használatával.
            slide = presentation.slides.add_empty_slide(blank_layout)

            # Importáld a megadott diagramot az Excel-munkafüzetről a dia alakzatgyűjteményébe.
            slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
                slide.shapes, 10, 10, workbook, name, chart.key, False)

    # Mentsd el a létrehozott prezentációt egy fájlba.
    presentation.save("Charts.pptx", slides.export.SaveFormat.PPTX)
```

## **Összefoglalás**

Ez a mechanizmus, amely közvetlenül az Aspose.Slides-ben érhető el, egy helyen ötvözi az Excel-adatokkal és prezentációkkal való munkát. Lehetővé teszi, hogy diákon vizuális diagramokkal és Excel táblákként megjelenített adatokkal hozzunk létre – bármilyen további könyvtár vagy összetett integráció nélkül.