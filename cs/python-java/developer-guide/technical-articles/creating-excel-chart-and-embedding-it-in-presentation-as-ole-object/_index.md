---
title: Vytvořte grafy Excel a vložte je do prezentací jako OLE objekty
type: docs
weight: 30
url: /cs/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel graf
- vložit graf
- OLE objekt
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvořte graf Excel pomocí Aspose.Cells pro Python přes Java a vložte sešit do prezentace PowerPoint s Aspose.Slides, včetně náhledu grafu."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit sloupcový graf Excel pomocí Aspose.Cells pro Python přes Java a vložit jeho sešit do prezentace PowerPoint s Aspose.Slides pro Python přes Java. Vložený sešit obsahuje jak zdrojová data, tak graf. Samostatná náhledová PNG zobrazuje graf na snímku před aktivací objektu OLE.

Výsledkem je vložený objekt Excel, nikoli nativní graf PowerPoint. Úprava sešitu prostřednictvím OLE vyžaduje desktopovou aplikaci, která podporuje aktivaci OLE, a kompatibilní instalaci Excelu.

## **Předpoklady**

Nainstalujte balíčky Python `aspose-cells` a `aspose-slides-java` a kompatibilní běhové prostředí Java. Naimportujte oba balíčky před spuštěním JVM, aby jejich Java knihovny byly k dispozici pro JPype. Microsoft Office není vyžadován k vytvoření prezentace s těmito knihovnami.

Žádné vstupní soubory nejsou vyžadovány: příklad vytvoří data a graf v paměti a poté zapíše `OutputChart.pptx` do aktuálního pracovního adresáře. Použijte licence pro oba produkty při provozu mimo evaluační režim.

## **Jak funguje vkládání**

1. Vytvořte sešit s listem dat a listem grafu.  
2. Aktivujte list grafu, aby se sešit otevřel na grafu.  
3. Nastavte OLE zobrazovací rozsah sešitu a vykreslete graf do PNG.  
4. Uložte sešit jako XLSX v paměti a vložte tyto bajty do snímku.  
5. Přiřaďte PNG jako náhled objektu OLE a uložte prezentaci jako PPTX.

Zobrazovací rozsah sešitu a rámec na snímku mají různé role. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) používá nulové indexy počátečního/konečného řádku a sloupce. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) místo toho používá horní řádek, levý sloupec, dolní řádek a pravý sloupec. Příklad používá index řádku 55 a index sloupce 25 jako pravé dolní hranice; tyto hodnoty jsou volby rozvržení, nikoli počet řádků nebo sloupců v datech.

Rámec snímku používá body. Příklad jej umístí do snímku a vycentruje, přičemž zachová poměr stran PNG, místo aby natahoval náhled tak, aby vyplnil snímek.

## **Vytvoření a vložení grafu**

Následující úplný příklad naplní `DataSheet` čtyřmi řádky a pěti sloupci hodnot. Každý řádek se stane sérií grafu. `ChartSheet` je vybrán jako aktivní list před uložením sešitu.

Sešit je explicitně uložen jako XLSX, což odpovídá příponě `xlsx` předané do [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/). Java proudy bajtových polí uchovávají sešit a obrázek v paměti a poskytují bajtová pole požadovaná Java API. PNG je načten přímo z jeho bajtů bez mezikroku bitmapové konverze. Přiřazením prostřednictvím [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) se nahradí výchozí OLE placeholder.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # Vygenerujte náhled grafu a samostatně serializujte editovatelný sešit.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # Přizpůsobte náhled snímku bez změny poměru stran.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **Očekávaný výsledek**

`OutputChart.pptx` obsahuje jeden snímek s vloženým sešitem Excel a náhledem grafu. Sešit obsahuje původní data a sloupcový graf se čtyřmi sériemi. Náhled je vycentrován na snímku a zachovává své proporce.

![Sloupcový graf Excel zobrazený jako náhled vloženého sešitu](excel-chart-ole-preview.png)

V kompatibilním desktopovém prostředí PowerPoint s dostupným Excelem dvojklikněte na objekt pro aktivaci a úpravu vloženého sešitu. Aktivace a úpravy závisí na podpoře OLE hostitelské aplikace a bezpečnostních nastaveních.

## **Často kladené otázky**

**Proč je potřeba obrázek náhledu?**

Vložený sešit a jeho náhled na snímku jsou oddělený obsah. Poskytněte obrázek grafu, aby snímek zobrazoval graf místo výchozího placeholderu „EMBEDDED OLE OBJECT“. Viz [Object Preview Issue when Adding OleObjectFrame](/slides/cs/python-java/object-preview-issue-when-adding-oleobjectframe/).

**Aktualizuje se náhled automaticky při změně sešitu v kódu?**

Považujte náhled za snímek. Při programové aktualizaci dat sešitu vygenerujte znovu obrázek grafu a nahraďte náhled i data vloženého sešitu.

**Mohu použít XLS místo XLSX?**

Ano. Uložte sešit ve formátu XLS a použijte `xls` jako příponu vložených dat. Přípona musí odpovídat skutečnému formátu sešitu; pouhá změna přípony data nekonvertuje.

**Proč může objekt po aktivaci změnit velikost?**

Hostitelská aplikace může aktualizovat prezentaci objektu OLE při aktivaci sešitu. Na OLE zobrazovacím rozsahu sešitu i rozměrech rámce snímku záleží. Viz [Working Solution for Chart Resizing in PPTX](/slides/cs/python-java/working-solution-for-chart-resizing-in-pptx/).

## **Související sekce**

- [Řešení pro změnu velikosti grafu v PPTX](/slides/cs/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/python-java/object-preview-issue-when-adding-oleobjectframe/)