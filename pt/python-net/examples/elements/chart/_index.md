---
title: Gráfico
type: docs
weight: 60
url: /pt/python-net/examples/elements/chart/
keywords:
- gráfico
- adicionar gráfico
- acessar gráfico
- remover gráfico
- atualizar gráfico
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Crie e personalize gráficos em Python com Aspose.Slides: adicione dados, formate séries, eixos e rótulos, altere tipos e exporte — funciona com PPT, PPTX e ODP."
---
Exemplos de como adicionar, acessar, remover e atualizar diferentes tipos de gráfico com **Aspose.Slides for Python via .NET**. Os trechos abaixo demonstram operações básicas com gráficos.

## **Adicionar um Gráfico**

Este método adiciona um gráfico de área simples ao primeiro slide.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Adicione um gráfico de colunas simples ao primeiro slide.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar um Gráfico**

O código a seguir recupera um gráfico da coleção de formas.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Acesse o primeiro gráfico no slide.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **Remover um Gráfico**

O código a seguir remove um gráfico de um slide.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Pressupondo que a primeira forma é um gráfico.
        chart = slide.shapes[0]

        # Remova o gráfico.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Atualizar Dados do Gráfico**

Você pode alterar propriedades do gráfico, como o título.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Pressupondo que a primeira forma seja um gráfico.
        chart = slide.shapes[0]

        # Altere o título do gráfico.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```