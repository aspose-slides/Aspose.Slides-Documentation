---
title: Gráfico
type: docs
weight: 60
url: /pt/python-java/examples/elements/chart/
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
- Java
- Aspose.Slides
description: "Criar, acessar, remover e atualizar gráficos em apresentações PowerPoint e OpenDocument com Aspose.Slides for Python via Java."
---
Este artigo demonstra como adicionar, acessar, remover e atualizar gráficos em uma apresentação usando **Aspose.Slides for Python via Java**.

Instale o pacote conforme descrito em [Instalação](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM, depois importa a API após a JVM estar em execução. Execute primeiro o exemplo de adição para criar `chart.pptx` para os exemplos restantes.

## **Adicionar um Gráfico**

Adicione um gráfico de área ao primeiro slide e salve a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Adicionar um gráfico de área ao primeiro slide.
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acessar um Gráfico**

Encontre o primeiro gráfico na coleção de formas do primeiro slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Acessar o primeiro gráfico no slide.
    first_chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            first_chart = shape
            break

    if first_chart is None:
        print("The first slide contains no charts.")
finally:
    presentation.dispose()
```

## **Remover um Gráfico**

Remova o primeiro gráfico do slide e salve a apresentação modificada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Encontrar e remover o primeiro gráfico no slide.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        slide.getShapes().remove(chart)
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Atualizar Dados do Gráfico**

Exiba o título do gráfico, altere seu texto e salve a apresentação atualizada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Encontrar o primeiro gráfico no slide.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # Exibir o título do gráfico e alterar seu texto.
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```