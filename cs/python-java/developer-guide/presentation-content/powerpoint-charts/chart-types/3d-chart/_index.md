---
title: Přizpůsobení 3D grafů v prezentacích pomocí Pythonu
linktitle: 3D graf
type: docs
url: /cs/python-java/3d-chart/
keywords:
- 3D graf
- rotace
- hloubka
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Zjistěte, jak vytvářet a přizpůsobovat 3D grafy v Aspose.Slides pro Python prostřednictvím Java, s podporou souborů PPT a PPTX - posilte své prezentace ještě dnes."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit 3D graf v Aspose.Slides konfigurací nastavení [Rotation3D](https://reference.aspose.com/slides/cs/python-java/aspose.slides/rotation3d/) jako jsou [setRotationX](https://reference.aspose.com/slides/cs/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/cs/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/cs/python-java/aspose.slides/rotation3d/#setDepthPercents) a [setRightAngleAxes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/rotation3d/#setRightAngleAxes). Prochází se vytvořením prezentace, přidáním 3D grafu s výchozími daty, aplikací požadovaných nastavení 3D zobrazení a uložením upravené prezentace jako souboru PPTX.

## **Nastavení rotace X, rotace Y a hloubky 3D grafu**
Aspose.Slides for Python via Java poskytuje jednoduché API pro nastavení těchto vlastností. Následující příklad ukazuje, jak nastavit rotaci X, rotaci Y a hloubku 3D grafu.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Přistupte k prvnímu snímku.
3. Přidejte graf s výchozími daty.
4. Nastavte vlastnosti 3D rotace.
5. Uložte upravenou prezentaci do souboru PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # Přístup k prvnímu snímku.
    slide = presentation.getSlides().get_Item(0)

    # Přidání grafu s výchozími daty.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # Nastavení indexu listu s daty grafu.
    default_worksheet_index = 0

    # Získání sešitu s daty grafu.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Přidání sérií.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Přidání kategorií.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # Nastavení vlastností 3D rotace.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # Přístup k druhé sérii grafu.
    series = chart.getChartData().getSeries().get_Item(1)

    # Naplnění dat série.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # Uložení prezentace.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100% Stacked Column 3D, spolu s příbuznými 3D typy dostupnými prostřednictvím třídy [ChartType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/charttype/). Pro přesný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/charttype/) v referenci API ve vaší nainstalované verzi.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Můžete exportovat graf jako obrázek pomocí [chart API](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getImage) nebo [render the entire slide](/slides/cs/python-java/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, když potřebujete pixelově dokonalý náhled nebo chcete vložit graf do dokumentů, dashboardů či webových stránek bez nutnosti PowerPointu.

**Jak výkonná je tvorba a vykreslování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro nejlepší výsledky udržujte 3D efekty na minimu, vyhněte se těžkým texturám na stěnách a plotových oblastech, omezte počet datových bodů v sérii, pokud je to možné, a vykreslujte do výstupu s vhodnou velikostí (rozlišení a rozměry), který odpovídá cílovému displeji nebo tisku.