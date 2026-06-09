---
title: Personalizar gráficos 3D em apresentações com Python
linktitle: Gráfico 3D
type: docs
url: /pt/python-net/3d-chart/
keywords:
- gráfico 3d
- rotação
- profundidade
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Saiba como criar e personalizar gráficos 3D no Aspose.Slides para Python via .NET, com suporte a arquivos PPT, PPTX e ODP — impulsione suas apresentações hoje."
---
## **Visão geral**

Este artigo explica como personalizar um gráfico 3D no Aspose.Slides configurando as definições `rotation_3d` como `rotation_x`, `rotation_y`, `depth_percents` e `right_angle_axes`. Ele descreve a criação de uma apresentação, a adição de um gráfico 3D com dados padrão, a aplicação das configurações de visualização 3D necessárias e a gravação da apresentação modificada como um arquivo PPTX.

## **Definir as propriedades RotationX, RotationY e DepthPercents de um gráfico 3D**
Aspose.Slides para Python via .NET fornece uma API simples para definir essas propriedades. O artigo a seguir ajudará você a definir diferentes propriedades, como rotação X, Y, **DepthPercents**, etc. O código de exemplo aplica a definição das propriedades mencionadas acima.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Adicione um gráfico com dados padrão.
4. Defina as propriedades Rotation3D.
5. Grave a apresentação modificada em um arquivo PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Criar uma instância da classe Presentation
with slides.Presentation() as presentation:
            
    # Acessar o primeiro slide
    slide = presentation.slides[0]

    # Adicionar gráfico com dados padrão
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Definir o índice da planilha de dados do gráfico
    defaultWorksheetIndex = 0

    # Obter a planilha de dados do gráfico
    fact = chart.chart_data.chart_data_workbook

    # Adicionar série
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Adicionar categorias
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Definir propriedades Rotation3D
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Obter a segunda série do gráfico
    series = chart.chart_data.series[1]

    # Agora preenchendo os dados da série
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Definir valor OverLap
    series.parent_series_group.overlap = 100         

    # Gravar a apresentação no disco
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas frequentes**

**Quais tipos de gráfico suportam o modo 3D no Aspose.Slides?**

Aspose.Slides suporta variantes 3D de gráficos de colunas, incluindo Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, além de tipos 3D relacionados expostos através da enumeração [ChartType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/charttype/). Para obter uma lista exata e atualizada, verifique os membros de [ChartType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/charttype/) na referência de API da versão instalada.

**Posso obter uma imagem raster de um gráfico 3D para um relatório ou a web?**

Sim. Você pode exportar um gráfico para uma imagem via a [chart API](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/get_image/) ou [render the entire slide](/slides/pt/python-net/convert-powerpoint-to-png/) para formatos como PNG ou JPEG. Isso é útil quando você precisa de uma pré‑visualização pixel‑perfeita ou deseja incorporar o gráfico em documentos, painéis ou páginas da web sem a necessidade do PowerPoint.

**Quão performante é a criação e renderização de grandes gráficos 3D?**

O desempenho depende do volume de dados e da complexidade visual. Para obter os melhores resultados, mantenha os efeitos 3D ao mínimo, evite texturas pesadas nas paredes e áreas de plotagem, limite o número de pontos de dados por série quando possível e renderize para uma saída com tamanho adequado (resolução e dimensões) que corresponda à exibição ou necessidades de impressão desejadas.