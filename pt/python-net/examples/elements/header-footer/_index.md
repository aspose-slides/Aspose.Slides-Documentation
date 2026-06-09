---
title: "Cabeçalho e Rodapé"
type: docs
weight: 220
url: /pt/python-net/examples/elements/header-footer/
keywords:
- cabeçalho rodapé
- adicionar cabeçalho e rodapé
- atualizar cabeçalho rodapé
- definir data e hora
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Controle cabeçalhos e rodapés em Python com Aspose.Slides: adicione ou edite data/hora, números de slides e texto do rodapé, exiba ou oculte marcadores em PPT, PPTX e ODP."
---
Mostra como adicionar rodapés e atualizar marcadores de data e hora usando **Aspose.Slides for Python via .NET**.

## **Adicionar Rodapé**

Adicione texto à área de rodapé de um slide e torne‑o visível.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **Atualizar Data e Hora**

Modifique o marcador de data e hora em um slide.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```