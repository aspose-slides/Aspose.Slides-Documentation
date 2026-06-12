---
title: Grafico
type: docs
weight: 60
url: /it/python-net/examples/elements/chart/
keywords:
- grafico
- aggiungi grafico
- accedi al grafico
- rimuovi grafico
- aggiorna grafico
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Crea e personalizza i grafici in Python con Aspose.Slides: aggiungi dati, formatta serie, assi ed etichette, cambia i tipi e esporta—funziona con PPT, PPTX e ODP."
---
Esempi per aggiungere, accedere, rimuovere e aggiornare diversi tipi di grafico con **Aspose.Slides for Python via .NET**. I frammenti seguenti dimostrano le operazioni di base sui grafici.

## **Aggiungi un grafico**

Questo metodo aggiunge un semplice grafico a zona alla prima diapositiva.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Aggiungi un semplice grafico a colonne alla prima diapositiva.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedi a un grafico**

Il codice seguente recupera un grafico dalla collezione di forme.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Accedi al primo grafico sulla diapositiva.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **Rimuovi un grafico**

Il codice seguente rimuove un grafico da una diapositiva.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia un grafico.
        chart = slide.shapes[0]

        # Rimuovi il grafico.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiorna i dati del grafico**

È possibile modificare le proprietà del grafico, ad esempio il titolo.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia un grafico.
        chart = slide.shapes[0]

        # Cambia il titolo del grafico.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```