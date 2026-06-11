---
title: "Hantera diagramdatamarkörer i presentationer med Python"
linktitle: "Datamarkör"
type: docs
url: /sv/python-net/chart-data-marker/
keywords:
- diagram
- datapunkt
- markör
- marköralternativ
- markörstorlek
- fyllningstyp
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du anpassar diagramdatamarkörer i Aspose.Slides, vilket ökar presentationens genomslag i PPT-, PPTX- och ODP-format med tydliga kodexempel."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med diagramdatamarkörer i Aspose.Slides. Den visar hur man skapar ett diagram, får åtkomst till en serie och dess datapunkter, applicerar bildfyllning på markörer på datapunktsnivå, justerar markörens storlek och sparar den uppdaterade presentationen. Den noterar också att standardmarkörformer finns tillgängliga via `MarkerStyleType`‑enumerationen och att markörens utseende bevaras vid export av diagram till rastrformat eller SVG.

## **Ställ in diagrammarköralternativ**
Markörerna kan ställas in på diagramdatapunkter i specifika serier. För att ställa in diagrammarköralternativ, följ stegen nedan:

- Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
- Skapa standarddiagrammet.
- Ange bilden.
- Hämta den första diagramserien.
- Lägg till en ny datapunkt.
- Skriv presentationen till disk.

I exemplet nedan har vi ställt in diagrammarköralternativen på datapunktsnivå.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Skapa en instans av Presentation-klassen
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Skapar standarddiagrammet
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Hämtar standarddiagrammets dataarbetsbladsindex
    defaultWorksheetIndex = 0

    # Hämtar diagrammets dataarbetsblad
    fact = chart.chart_data.chart_data_workbook

    # Ta bort demoserier
    chart.chart_data.series.clear()

    # Lägg till en ny serie
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # Ange bilden
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Ange bilden
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Hämta första diagramserien
    series = chart.chart_data.series[0]

    # Lägg till en ny punkt (1:3) där.
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

    # Ändrar diagramseriens markör
    series.marker.size = 15

    # Spara presentationen till disk
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Vilka markörformer finns tillgängliga direkt?**

Standardformer finns tillgängliga (cirkel, fyrkant, diamant, triangel osv.); listan definieras av [MarkerStyleType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/markerstyletype/)‑enumerationen. Om du behöver en icke‑standardform, använd en markör med bildfyllning för att efterlikna anpassade visuella element.

**Behålls markörerna vid export av ett diagram till en bild eller SVG?**

Ja. När diagram renderas till [rastrformat](/slides/sv/python-net/convert-powerpoint-to-png/) eller sparas som [former som SVG](/slides/sv/python-net/render-a-slide-as-an-svg-image/), behåller markörerna sitt utseende och sina inställningar, inklusive storlek, fyllning och kontur.