---
title: IntestazionePièDiPagina
type: docs
weight: 220
url: /it/python-net/examples/elements/header-footer/
keywords:
- intestazione piè di pagina
- aggiungi intestazione piè di pagina
- aggiorna intestazione piè di pagina
- imposta data e ora
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Controlla intestazioni e piè di pagina in Python con Aspose.Slides: aggiungi o modifica data/ora, numeri diapositiva e testo del piè di pagina, mostra o nascondi i segnaposto in PPT, PPTX e ODP."
---
Mostra come aggiungere piè di pagina e aggiornare i segnaposto di data e ora usando **Aspose.Slides for Python via .NET**.

## **Aggiungi un piè di pagina**

Aggiungi testo all'area del piè di pagina di una diapositiva e rendilo visibile.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiorna data e ora**

Modifica il segnaposto di data e ora su una diapositiva.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```