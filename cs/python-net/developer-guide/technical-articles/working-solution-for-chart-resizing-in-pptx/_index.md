---
title: Řešení pro změnu velikosti grafu v PPTX
type: docs
weight: 60
url: /cs/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- změna velikosti grafu
- graf Excel
- OLE objekt
- vložit graf
- PowerPoint
- prezentace
- Python via .NET
- Python
- Aspose.Slides
description: "Opravte neočekávanou změnu velikosti grafu v souboru PPTX při použití vložených Excel OLE objektů s Aspose.Slides pro Python via .NET. Nastavte pevné rozměry grafu, aby byly velikosti grafu a OLE rámečku konzistentní."
---
## **Přehled**

Grafy Excel vložené jako OLE objekty do prezentací PowerPoint pomocí komponent Aspose mohou po svém prvním aktivování změnit velikost. To může způsobit patrný rozdíl ve vzhledu grafu před a po aktivaci. Tento článek vysvětluje, proč k přizpůsobení dochází, a ukazuje, jak tomu předejít nastavením pevných rozměrů grafu tak, aby odpovídaly OLE rámečku.

V článku [Vytvořit grafy Excel a vložit je jako OLE objekty v prezentacích](/slides/cs/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) jsme vysvětlili, jak vytvořit graf Excel pomocí Aspose.Cells pro Python via .NET a vložit jej do prezentace PowerPoint pomocí Aspose.Slides pro Python via .NET. Abychom vyřešili [problém s náhledem objektu](/slides/cs/python-net/object-preview-issue-when-adding-oleobjectframe/), přiřadili jsme obrázek grafu k OLE objektovému rámečku grafu. Ve výsledné prezentaci, když dvakrát kliknete na OLE rámeček zobrazující obrázek grafu, aktivuje se graf Excel. Uživatelé mohou upravit vložený sešit Excel a poté se vrátit na snímek kliknutím mimo aktivovaný sešit. Velikost OLE rámečku se změní, když se uživatel vrátí na snímek, a faktor změny velikosti se liší v závislosti na původních rozměrech jak OLE rámečku, tak vloženého sešitu Excel.

## **Příčina změny velikosti**

Vložený sešit Excel má vlastní rozměry okna, které se Excel snaží zachovat při první aktivaci objektu. OLE rámeček na snímku má nezávisle definované rozměry. Když je sešit Excel aktivován, Excel a PowerPoint vyjednávají velikost objektu tak, aby zachovaly jeho proporce jako součást procesu vkládání. Rozdíly mezi oknem sešitu a OLE rámečkem tak mohou způsobit změnu velikosti objektu.

## **Funkční řešení**

Nastavte velikost grafu tak, aby odpovídala OLE rámečku na snímku, a ponechte rozměry grafu nezávislé na okně sešitu. Toto řešení funguje jak s novou prezentací, tak s existující šablonou.

Příklad vyžaduje Aspose.Cells pro Python via .NET a Aspose.Slides pro Python via .NET. Vytvoří jednoduchý sloupcový graf na aktivním listu grafu a vloží sešit ve formátu XLS. Obrázek náhledu grafu není přiřazen; graf se zobrazí, když je OLE objekt aktivován v PowerPointu.

Příklad vytvoří novou prezentaci s OLE rámečkem o rozměrech 9,5 × 4 palce umístěným 0,5 palce od levého okraje a 1 palec od horního okraje. Souřadnice a rozměry snímku jsou v bodech (72 bodů na palec). Pro existující prezentaci viz sekce [Použití šablony](#use-a-template).

## **Nastavení pevné velikosti grafu**

Nastavte [size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) na **false**, aby rozměry grafu byly nezávislé na okně sešitu. Rozměry [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) nastavte pomocí [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) a [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/), přičemž převádíte body na pixely při 96 pixelech na palec: rámeček měřící 684 × 288 bodů odpovídá grafu o rozměrech 912 × 384 pixelů. Nastavte [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) na hodnotu **CUSTOM** typu [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/). Příklad vkládá sešit pomocí [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) a ukládá prezentaci s OLE rámečkem o rozměrech 9,5 × 4 palce.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Souřadnice a rozměry snímku jsou v bodech (72 bodů na palec).
    width = 684.0  # 9,5 palce.
    height = 288.0  # 4 palce.

    chart.size_with_window = False
    # Převést body na pixely grafu při 96 pixelech na palec.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Použití šablony**

Logika velikosti je stejná pro existující prezentaci. Pro úpravu příkladu:

1. Načtěte šablonu prezentace místo vytváření prázdné prezentace.  
2. Ověřte, že první snímek obsahuje alespoň tři tvary, a použijte tvar s indexem 2 jako zástupný objekt.  
3. Vezměte šířku a výšku rámečku z tohoto tvaru místo pevných hodnot 684 a 288. Nechte výpočty velikosti beze změny.  
4. Přidejte OLE rámeček na pozici zástupného objektu místo pevných souřadnic 36 a 72.  
5. Před uložením prezentace odstraňte zástupný objekt.

## **Často kladené otázky**

**Proč se po aktivaci v PowerPointu změnil velikost mého vloženého grafu Excel?**

Stane se to, protože Excel se snaží obnovit původní velikost okna při první aktivaci, zatímco OLE rámeček v PowerPointu má vlastní rozměry. PowerPoint a Excel vyjednávají velikost tak, aby zachovaly poměr stran, což může vést ke změně velikosti.

**Jak mohu udržet velikosti grafu a OLE rámečku konzistentní?**

Nastavte pevné rozměry grafu, které odpovídají OLE rámečku, a použijte vlastní tiskovou velikost grafu před vložením sešitu. Výše uvedený příklad ukazuje potřebná nastavení a převody jednotek.

**Je dostatečné pouze přizpůsobit velikost okna sešitu?**

Pouhé přizpůsobení velikosti okna sešitu spolehlivě nebrání změně velikosti OLE rámečku po aktivaci. Použijte pevné rozměry grafu, jak je ukázáno v příkladu.

**Funguje toto řešení jak pro prezentace založené na šabloně, tak pro nové prezentace?**

Ano. Pro šablonu použijte rozměry a pozici zástupného objektu. Pro novou prezentaci zadejte rozměry a pozici rámečku přímo.

**Mohu použít tento příklad s grafy vytvořenými v jiných tabulkových programech?**

Příklad používá sešit Excel vytvořený pomocí Aspose.Cells. Neukazuje chování aktivace pro jiné tabulkové programy.

## **Související sekce**

- [Vytvořit grafy Excel a vložit je jako OLE objekty v prezentacích](/slides/cs/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Automaticky aktualizovat OLE objekty pomocí doplňku PowerPoint](/slides/cs/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)