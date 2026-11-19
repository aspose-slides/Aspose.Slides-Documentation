---
title: Personalizar gráficos 3D em apresentações com Python
linktitle: Gráfico 3D
type: docs
url: /pt/python-net/3d-chart/
keywords:
- gráfico 3D
- rotação
- profundidade
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Crie gráficos 3D em apresentações do PowerPoint com Aspose.Slides para Python via .NET. Ajuste rotação, proporções de altura, profundidade do gráfico e espaçamento entre as séries com exemplos em Python."
---
## **Visão Geral**

Aspose.Slides for Python via .NET permite personalizar a visualização de um gráfico 3D por meio da propriedade [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) . Este artigo demonstra como ajustar rotação, proporções de altura, profundidade, eixos em ângulo reto e espaçamento entre as séries, e então salvar a apresentação no formato PPTX.

## **Definir a rotação e a profundidade de um gráfico 3D**

O exemplo abaixo cria uma [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) e usa [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) para adicionar um gráfico de colunas 3D empilhadas ao seu primeiro slide. Ele substitui as séries e categorias padrão por duas séries contendo três valores cada. O índice da planilha `0` identifica a primeira planilha de dados do gráfico; a linha `0` contém os nomes das séries e a coluna `0` contém os rótulos das categorias.

As propriedades [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) e [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) definem a rotação do gráfico em 40 e 270 graus, respectivamente. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) define sua profundidade em 150 % da sua largura, enquanto [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) habilita eixos em ângulo reto em vez de perspectiva. A apresentação resultante contém o gráfico preenchido com essas configurações de visualização 3D.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajustar as proporções de altura de um gráfico 3D**

Use [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) para definir a altura de um gráfico 3D como porcentagem da sua largura. Isso altera as proporções da cena 3D sem redimensionar o objeto do gráfico no slide.

O exemplo a seguir cria um gráfico [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) com os dados padrão: três séries e quatro categorias. Ele salva três apresentações com proporções de altura de 50 %, 100 % e 200 %. A posição, largura e altura do gráfico permanecem fixas. Os dados, rotação, profundidade, espaçamento das séries e formatação são idênticos nos três arquivos; apenas a porcentagem de altura muda.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

As imagens a seguir foram exportadas das apresentações geradas usando o Microsoft PowerPoint. Uma porcentagem menor produz uma cena mais plana, enquanto uma maior produz uma cena mais alta dentro do mesmo objeto de gráfico. O PowerPoint também pode ajustar os intervalos das marcações dos eixos e a posição dos rótulos para caber na cena.

| Altura: 50 % | Altura: 100 % | Altura: 200 % |
| --- | --- | --- |
| ![Gráfico de colunas 3D com altura definida em 50 % da largura](height_percent_50.png) | ![Gráfico de colunas 3D com altura definida em 100 % da largura](height_percent_100.png) | ![Gráfico de colunas 3D com altura definida em 200 % da largura](height_percent_200.png) |

Essas propriedades controlam diferentes aspectos do gráfico:

| Propriedade | Efeito |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Altura da cena 3D como porcentagem da sua largura. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Altura do objeto do gráfico no slide, em pontos. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Profundidade da cena 3D como porcentagem da sua largura. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Espaçamento entre séries ao longo do eixo de profundidade, como porcentagem da largura do marcador. |

A configuração de altura afeta gráficos de colunas e barras 3D, incluindo variantes de cilindro, cone e pirâmide, bem como gráficos de linha, área, pizza e superfície 3D. A comparação acima usa o tipo verificado `COLUMN_3D`. A configuração não altera a aparência de um gráfico 2D `CLUSTERED_COLUMN` ou de um gráfico `BUBBLE_WITH_3D`; esses nomes são membros da enumeração [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Para outras configurações de aparência de gráfico, consulte [Chart Formatting](/slides/pt/python-net/chart-formatting/).

## **Ajustar o espaço entre as séries**

Use [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) para controlar a distância entre as séries de dados ao longo do eixo de profundidade de um gráfico 3D, expressa como porcentagem da largura do marcador. Use valores de **0 a 500**, inclusive: `0` remove o espaço, enquanto valores maiores aumentam o espaçamento. Com a profundidade do gráfico fixa, aumentar o espaço faz os marcadores ficarem mais finos ao longo do eixo de profundidade.

Acesse o grupo através de [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). A configuração se aplica a todas as séries desse grupo, não apenas à série usada para acessá‑lo. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) é somente leitura e reflete a configuração do grupo pai.

Essa configuração afeta gráficos de colunas e barras 3D, incluindo suas variantes de cilindro, cone e pirâmide, bem como gráficos de linha e área 3D. A aparência depende de as séries estarem dispostas em profundidade, agrupadas ou empilhadas. Para uma comparação clara dos espaços entre séries separadas, use `ChartType.COLUMN_3D` da enumeração [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

Essas propriedades controlam diferentes aspectos do gráfico:

| Propriedade | Efeito |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Espaçamento entre séries ao longo do eixo de profundidade, como porcentagem da largura do marcador. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Espaçamento entre clusters adjacentes de barras ou colunas, como porcentagem da largura da barra ou coluna. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Profundidade geral do gráfico, como porcentagem da largura do gráfico. |

O exemplo autocontido a seguir usa os dados padrão do gráfico, que contêm três séries e quatro categorias. Ele salva duas apresentações com dados, rotação, largura do espaço e profundidade do gráfico idênticos; apenas a profundidade do espaço muda.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

As imagens a seguir foram exportadas das apresentações geradas usando o Microsoft PowerPoint.

| Profundidade do espaço: 0 % | Profundidade do espaço: 500 % |
| --- | --- |
| ![Gráfico de colunas 3D sem espaço entre as séries ao longo do eixo de profundidade](gap_depth_0.png) | ![Gráfico de colunas 3D com espaço de 500 % entre as séries ao longo do eixo de profundidade](gap_depth_500.png) |

## **Alterar o tipo de série 3D e a forma da barra**

Em um gráfico de cilindro agrupado, a primeira série começa com barras cilíndricas. O exemplo lê [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) e [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) antes e depois de cada alteração.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| Alteração na primeira série | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Criar o gráfico | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Definir `type` como `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Definir `bar_3d_shape` como `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Definir a forma como `BOX` também altera o tipo da série para `CLUSTERED_COLUMN_3D`. Se o seu código fizer ramificações com base no tipo da série, leia `series.type` depois de alterar a forma. Um valor armazenado antes da atribuição ainda selecionaria a ramificação `CLUSTERED_CONE`.

![Comparação no PowerPoint mostrando a primeira série como cilindros, cones e colunas retangulares da esquerda para a direita](series-shapes.png)

## **FAQ**

**Quais tipos de gráfico suportam modo 3D no Aspose.Slides?**

Aspose.Slides suporta variantes 3D de gráficos de colunas, incluindo Column 3D, Clustered Column 3D, Stacked Column 3D e 100 % Stacked Column 3D, além de tipos 3D relacionados expostos por meio da enumeração [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Para uma lista exata e atualizada, verifique os membros de [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) na referência da API da versão instalada.

**Posso obter uma imagem raster de um gráfico 3D para um relatório ou a web?**

Sim. Você pode exportar um gráfico para uma imagem com [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) ou [renderizar o slide inteiro](/slides/pt/python-net/convert-powerpoint-to-png/) para formatos como PNG ou JPEG. Isso é útil quando você precisa de uma pré‑visualização raster ou deseja incorporar o gráfico em documentos, painéis ou páginas da web sem exigir o PowerPoint.

**Qual é o desempenho ao criar e renderizar gráficos 3D grandes?**

O desempenho depende do volume de dados e da complexidade visual. Para obter os melhores resultados, mantenha os efeitos 3D mínimos, evite texturas pesadas nas paredes e áreas de plotagem, limite o número de pontos de dados por série quando possível e renderize em uma resolução e dimensões adequadas ao destino de exibição ou impressão.