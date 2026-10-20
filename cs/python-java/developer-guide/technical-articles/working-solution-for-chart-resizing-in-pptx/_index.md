---
title: Funkční řešení pro změnu velikosti grafu v PPTX
type: docs
weight: 40
url: /cs/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- změna velikosti grafu
- graf Excel
- OLE objekt
- vložit graf
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Opravte neočekávanou změnu velikosti grafu v PPTX při použití vložených OLE objektů Excel s Aspose.Slides pro Python via Java. Nastavte pevné rozměry grafu, aby velikosti grafu a OLE rámce byly konzistentní."
---
## **Pozadí**

Grafy Excel vložené jako OLE objekty v prezentacích PowerPoint pomocí komponent Aspose se po první aktivaci mohou změnit velikost. To může způsobit výrazný rozdíl ve vzhledu grafu před a po aktivaci. Tento článek vysvětluje, proč k změně velikosti dochází, a ukazuje, jak tomu předejít nastavením pevných rozměrů grafu podle OLE rámce.

V [Vytvořit grafy Excel a vložit je jako OLE objekty v prezentacích](/slides/cs/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) jsme vysvětlili, jak vytvořit graf Excel pomocí Aspose.Cells pro Python via Java a vložit jej do prezentace PowerPoint pomocí Aspose.Slides pro Python via Java. Pro řešení [problému s náhledem objektu](/slides/cs/python-java/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek grafu k OLE objektovému rámečku grafu. V výsledné prezentaci, když dvakrát kliknete na OLE rámec zobrazující obrázek grafu, aktivuje se graf Excel. Uživatel může upravovat vloženou sešitu Excel a poté se vrátit na snímek kliknutím mimo aktivovaný sešit. Velikost OLE rámce se změní, když se uživatel vrátí na snímek, a faktor změny velikosti se liší v závislosti na původních rozměrech jak OLE rámce, tak vloženého sešitu Excel.

## **Příčina změny velikosti**

Vložený sešit Excel má vlastní rozměry okna, které se Excel snaží zachovat při první aktivaci objektu. OLE rámec na snímku má nezávisle definované rozměry. Když je sešit Excel aktivován, Excel a PowerPoint vyjednávají velikost objektu, aby zachovaly poměr stran jako součást procesu vkládání. Rozdíly mezi oknem sešitu a OLE rámcem tak mohou způsobit změnu velikosti objektu.

## **Fungující řešení**

Přizpůsobte velikost grafu OLE rámci na snímku a udržujte rozměry grafu nezávislé na okně sešitu. Toto řešení funguje s novou prezentací i s existující šablonou.

Příklad vyžaduje Aspose.Cells pro Python via Java a Aspose.Slides pro Python via Java. Vytvoří jednoduchý sloupcový graf na aktivním listu grafu a vloží sešit ve formátu XLS. Žádný náhledový obrázek grafu není přiřazen; graf se zobrazí, když je OLE objekt aktivován v PowerPointu.

Příklad vytvoří novou prezentaci s OLE rámcem o velikosti 9,5 × 4 palce umístěným 0,5 palce od levého okraje a 1 palec od horního okraje. Souřadnice a rozměry snímku jsou v bodech (72 bodů na palec). Pro existující prezentaci viz [Použít šablonu](#use-a-template).

## **Nastavit pevnou velikost grafu**

Nastavte [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) na false, aby rozměry grafu byly nezávislé na okně sešitu. Rozměry [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) nastavte pomocí [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) a [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height), přičemž body převedete na pixely při 96 pixelích na palec: rámec o rozměrech 684 × 288 bodů odpovídá grafu o rozměrech 912 × 384 pixelů. Nastavte [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) na hodnotu CUSTOM typu [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/). Příklad vloží sešit pomocí [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) a uloží prezentaci s OLE rámcem o velikosti 9,5 × 4 palce.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # Souřadnice a rozměry snímku jsou v bodech (72 bodů na palec).
        width = 684.0  # 9,5 palce.
        height = 288.0  # 4 palce.

        chart.setSizeWithWindow(False)
        # Převést body na pixely grafu při 96 pixelech na palec.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **Použít šablonu**

Logika změny velikosti je stejná i pro existující prezentaci. Pro úpravu příkladu:

1. Načtěte šablonu prezentace místo vytváření prázdné prezentace.  
2. Ověřte, že první snímek obsahuje alespoň tři tvary, a použijte tvar s indexem 2 jako zástupný objekt.  
3. Vezměte šířku a výšku rámce z tohoto tvaru místo pevných hodnot 684 a 288. Zachovejte výpočty velikosti beze změny.  
4. Přidejte OLE rámec na pozici zástupného objektu místo pevných souřadnic 36 a 72.  
5. Odstraňte zástupný objekt před uložením prezentace.

## **Často kladené otázky**

**Proč se můj vložený graf Excel po aktivaci v PowerPointu zvětší nebo zmenší?**  
Stane se to, protože Excel se při první aktivaci snaží obnovit původní velikost okna, zatímco OLE objektový rámec v PowerPointu má vlastní rozměry. PowerPoint a Excel vyjednávají velikost, aby zachovaly poměr stran, což může vést ke změně velikosti.

**Jak udržet velikosti grafu a OLE rámce konzistentní?**  
Nastavte pevné rozměry grafu, které odpovídají OLE rámci, a použijte vlastní velikost tisku grafu před vložením sešitu. Výše uvedený příklad ukazuje potřebná nastavení a převody jednotek.

**Je dostačující jen přizpůsobit velikost okna sešitu?**  
Pouze přizpůsobení velikosti okna sešitu spolehlivě nebrání změně velikosti OLE rámce po aktivaci. Použijte pevné rozměry grafu, jak je ukázáno v příkladu.

**Funguje toto řešení jak pro prezentace založené na šabloně, tak pro nové prezentace?**  
Ano. Pro šablonu použijte rozměry a pozici zástupného objektu. Pro novou prezentaci zadejte rozměry a pozici rámce přímo.

**Mohu tento příklad použít s grafy vytvořenými v jiných tabulkových programech?**  
Příklad používá sešit Excel vytvořený pomocí Aspose.Cells. Neukazuje chování aktivace pro jiné tabulkové programy.

## **Související sekce**

- [Vytvořit grafy Excel a vložit je jako OLE objekty v prezentacích](/slides/cs/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)