---
title: Vytvořte grafy v Excelu a vložte je do prezentací jako OLE objekty
type: docs
weight: 50
url: /cs/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- graf Excelu
- vložit graf
- OLE objekt
- PowerPoint
- prezentace
- Python
- Python přes .NET
- Aspose.Slides
description: "Vytvořte graf v Excelu pomocí Aspose.Cells pro Python přes .NET a vložte sešit do prezentace PowerPoint s Aspose.Slides, včetně náhledu grafu."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit sloupcový graf v Excelu pomocí Aspose.Cells pro Python přes .NET a vložit jeho sešit do prezentace PowerPoint pomocí Aspose.Slides pro Python přes .NET. Vložený sešit obsahuje jak zdrojová data, tak graf. Samostatná náhledová PNG zobrazuje graf na snímku před aktivací objektu OLE. Výsledkem je vložený objekt Excel, nikoli nativní graf PowerPoint. Úprava sešitu přes OLE vyžaduje desktopovou aplikaci, která podporuje aktivaci OLE, a kompatibilní instalaci Excelu.

## **Požadavky**

Nainstalujte balíčky `aspose-cells-python` a `aspose-slides` do svého prostředí Python. Microsoft Office není vyžadován k vytvoření prezentace s těmito knihovnami. Žádné vstupní soubory nejsou potřeba: příklad vytvoří data a graf v paměti a poté zapíše `OutputChart.pptx` do aktuálního pracovního adresáře. Při spuštění mimo evaluační režim použijte licence pro oba produkty.

## **Jak funguje vložení**

1. Vytvořte sešit s listem dat a listem grafu.  
2. Aktivujte list grafu, aby se sešit otevřel na grafu.  
3. Nastavte OLE zobrazovací oblast sešitu a vykreslete graf do PNG.  
4. Uložte sešit jako XLSX v paměti a vložte tyto bajty do snímku.  
5. Přiřaďte PNG jako náhled objektu OLE a uložte prezentaci jako PPTX.

Celooblast zobrazování sešitu a rámeček na snímku mají různé role. [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) přijímá nulové indexy začátku/konce řádku a sloupce. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) místo toho přijímá horní řádek, levý sloupec, spodní řádek a pravý sloupec. Příklad používá index řádku 55 a index sloupce 25 jako pravé dolní hranice; tyto hodnoty jsou volby rozvržení, nikoli počet datových řádků nebo sloupců. Rámeček snímku používá body. Příklad ho umístí do snímku a vycentruje, přičemž zachová poměr stran PNG, místo aby náhled roztahoval a vyplnil celý snímek.

## **Vytvoření a vložení grafu**

Následující kompletní příklad naplní `DataSheet` čtyřmi řádky a pěti sloupci hodnot. Každý řádek se stane sérií grafu. `ChartSheet` je vybrán jako aktivní list před uložením sešitu. Sešit je výslovně uložen jako XLSX, což odpovídá příponě `xlsx` předané metodě [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG je načteno přímo ze svého proudu bez mezilehlé konverze bitmapy. Přiřazení pomocí [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) nahradí výchozí placeholder OLE.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# Vykreslete náhled grafu a samostatně serializujte upravitelný sešit.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # Umístěte náhled na snímek tak, aby se vešel, aniž by se změnil poměr stran.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Očekávaný výsledek**

`OutputChart.pptx` obsahuje jeden snímek s vloženým sešitem Excel a náhledem grafu. Sešit obsahuje původní data a sloupcový graf se čtyřmi sériemi. Náhled je vycentrován na snímku a zachovává své proporce.

![Sloupcový graf Excel zobrazený jako náhled vloženého sešitu](excel-chart-ole-preview.png)

V kompatibilním desktopovém prostředí PowerPoint s nainstalovaným Excelem dvojklikněte na objekt, abyste aktivovali a upravili vložený sešit. Aktivace a úpravy závisí na podpoře OLE hostitelské aplikace a nastaveních zabezpečení.

## **FAQ**

**Proč je nutný náhledový obrázek?**  
Vložený sešit a jeho náhled na snímku jsou oddělený obsah. Poskytněte obrázek grafu, aby snímek zobrazoval graf místo výchozího placeholderu „EMBEDDED OLE OBJECT“. Viz [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/python-net/object-preview-issue-when-adding-oleobjectframe/).

**Aktualizuje se náhled automaticky, když v kódu změníme sešit?**  
Považujte náhled za snímek. Při programové aktualizaci dat sešitu vygenerujte znovu obrázek grafu a nahraďte náhled i data vloženého sešitu.

**Mohu použít XLS místo XLSX?**  
Ano. Uložte sešit ve formátu XLS a použijte `xls` jako příponu vložených dat. Přípona musí odpovídat skutečnému formátu sešitu; pouhá změna přípony data nepřevádí.

**Proč se objekt může po aktivaci změnit velikost?**  
Hostitelská aplikace může po aktivaci sešitu aktualizovat vzhled objektu OLE. Důležitá je jak OLE zobrazovací oblast sešitu, tak rozměry rámečku na snímku. Viz [Automatické změny velikosti objektů OLE v prezentacích PowerPoint](/slides/cs/python-net/working-solution-for-worksheet-resizing/).

## **Související sekce**

- [Automatické změny velikosti objektů OLE v prezentacích PowerPoint](/slides/cs/python-net/working-solution-for-worksheet-resizing/)
- [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [Správa OLE objektů](/slides/cs/python-net/manage-ole/)