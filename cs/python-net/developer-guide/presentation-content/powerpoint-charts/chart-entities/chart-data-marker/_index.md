---
title: Správa značek dat v grafech v prezentacích pomocí Pythonu
linktitle: Datová značka
type: docs
url: /cs/python-net/chart-data-marker/
keywords:
- graf
- datový bod
- značka
- možnosti značky
- velikost značky
- typ výplně
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak přizpůsobit značky dat v grafech v Aspose.Slides, zvýšením dopadu prezentací ve formátech PPT, PPTX a ODP pomocí jasných ukázek kódu."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat se značkami dat v grafech v Aspose.Slides. Ukazuje, jak vytvořit graf, přistoupit k sérii a jejím datovým bodům, použít obrázkové výplně na značky na úrovni datového bodu, upravit velikost značky a uložit aktualizovanou prezentaci. Také poznamenává, že standardní tvary značek jsou dostupné prostřednictvím výčtu `MarkerStyleType` a že vzhled značky je zachován při exportu grafů do rastrových formátů nebo SVG.

## **Nastavení možností značek grafu**
Značky lze nastavit na datových bodech grafu v konkrétních sériích. Pro nastavení možností značek grafu postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
- Vytvoření výchozího grafu.
- Nastavte obrázek.
- Získejte první sérii grafu.
- Přidejte nový datový bod.
- Uložte prezentaci na disk.

V následujícím příkladu jsme nastavili možnosti značek grafu na úrovni datových bodů.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Vytvoření výchozího grafu
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Získání indexu výchozího listu dat grafu
    defaultWorksheetIndex = 0

    # Získání listu dat grafu
    fact = chart.chart_data.chart_data_workbook

    # Odstranit demonstrační řadu
    chart.chart_data.series.clear()

    # Přidat novou řadu
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # Nastavit obrázek
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Nastavit obrázek
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Získat první řadu grafu
    series = chart.chart_data.series[0]

    # Přidat nový bod (1:3) tam.
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # Změna značky řady grafu
    series.marker.size = 15

    # Uložit prezentaci na disk
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Jaké tvary značek jsou k dispozici přímo?**

Standardní tvary jsou k dispozici (kruh, čtverec, diamant, trojúhelník atd.); seznam je definován výčtem [MarkerStyleType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/markerstyletype/). Pokud potřebujete nestandardní tvar, použijte značku s obrázkovou výplní k napodobení vlastního vzhledu.

**Zůstávají značky zachovány při exportu grafu do obrázku nebo SVG?**

Ano. Při vykreslování grafů do [rastrové formáty](/slides/cs/python-net/convert-powerpoint-to-png/) nebo ukládání [tvarů jako SVG](/slides/cs/python-net/render-a-slide-as-an-svg-image/) si značky zachovávají svůj vzhled a nastavení, včetně velikosti, výplně a obrysu.