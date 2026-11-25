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
description: "Criar gráficos 3D em apresentações PowerPoint com Aspose.Slides for Python via .NET. Ajustar rotação, proporções de altura, profundidade do gráfico e espaçamento entre séries com exemplos em Python."
---
## **Visão geral**

Aspose.Slides for Python via .NET permite personalizar a visualização de um gráfico 3D por meio da propriedade [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/). Este artigo demonstra como ajustar rotação, proporções de altura, profundidade, eixos em ângulo reto e espaçamento entre séries, e então salvar a apresentação no formato PPTX.

## **Definir a rotação e a profundidade de um gráfico 3D**

O exemplo abaixo cria uma [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) e usa [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) para adicionar um gráfico de colunas 3D empilhado ao seu primeiro slide. Ele substitui as séries e categorias padrão por duas séries contendo três valores cada. O índice da planilha de dados `0` identifica a primeira planilha de dados do gráfico; a linha `0` contém os nomes das séries e a coluna `0` contém os rótulos das categorias.

As propriedades [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) e [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) definem a rotação do gráfico para 40 e 270 graus, respectivamente. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) define sua profundidade como 150 % de sua largura, enquanto [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) habilita eixos em ângulo reto em vez de perspectiva. A apresentação resultante contém o gráfico preenchido com essas configurações de visualização 3D.

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

## **Aplicar preenchimento de imagem à superfície de um gráfico 3D**

É possível preencher a [side wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/), [back wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) e o [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) de um gráfico 3D de forma independente. Defina o [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) da superfície como `PICTURE` e atribua uma imagem. Para que uma única cópia da imagem cubra a superfície, defina tanto o [picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) quanto o [picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) da superfície como `STRETCH`.

Salve [arrow.png](arrow.png) no diretório de trabalho. O exemplo gira o gráfico e aumenta o valor máximo no eixo vertical para que o piso fique visível entre as colunas. Ele copia o slide duas vezes e aplica a seta a uma superfície diferente em cada slide. Todos os três gráficos compartilham os mesmos dados, ângulo de visualização e plano de fundo.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

O Microsoft PowerPoint exibe os três slides da seguinte forma.

| parede lateral | parede traseira | piso |
| --- | --- | --- |
| ![Seta apontando para dentro do gráfico ao longo da parede lateral](side-wall.png) | ![Seta apontando para a direita ao longo da parede traseira](back-wall.png) | ![Seta apontando para a direita ao longo do piso entre as colunas](floor.png) |

## **Ajustar as proporções de altura de um gráfico 3D**

Use [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) para definir a altura de um gráfico 3D como porcentagem da sua largura. Isso altera as proporções da cena 3D sem redimensionar o objeto gráfico no slide.

O exemplo a seguir cria um gráfico [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) com os dados padrão: três séries e quatro categorias. Ele salva três apresentações com proporções de altura de 50 %, 100 % e 200 %. A posição, largura e altura do gráfico permanecem fixas. Os dados, rotação, profundidade, espaçamento entre séries e formatação são idênticos nos três arquivos; apenas a porcentagem de altura varia.

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

As imagens a seguir foram exportadas das apresentações geradas usando o Microsoft PowerPoint. Uma porcentagem menor produz uma cena mais plana, enquanto uma maior produz uma cena mais alta dentro do mesmo objeto gráfico. O PowerPoint também pode ajustar os intervalos de marcações dos eixos e a colocação dos rótulos para adequar a cena.

| Altura: 50 % | Altura: 100 % | Altura: 200 % |
| --- | --- | --- |
| ![Gráfico de colunas 3D com altura definida em 50 % da sua largura](height_percent_50.png) | ![Gráfico de colunas 3D com altura definida em 100 % da sua largura](height_percent_100.png) | ![Gráfico de colunas 3D com altura definida em 200 % da sua largura](height_percent_200.png) |

Essas propriedades controlam diferentes aspectos do gráfico:

| Propriedade | Efeito |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Altura da cena 3D como porcentagem da sua largura. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Altura do objeto gráfico no slide, em pontos. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Profundidade da cena 3D como porcentagem da sua largura. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Espaçamento entre séries ao longo do eixo de profundidade, como porcentagem da largura do marcador. |

A configuração de altura afeta gráficos de colunas e barras 3D, incluindo variantes cilindro, cone e pirâmide, bem como gráficos de linhas, áreas, pizza e superfície 3D. A comparação acima utiliza o tipo verificado `COLUMN_3D`. A configuração não altera a aparência de um gráfico 2D `CLUSTERED_COLUMN` ou de um gráfico `BUBBLE_WITH_3D`; esses nomes são membros da enumeração [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Para outras configurações de aparência de gráficos, consulte [Chart Formatting](/slides/pt/python-net/chart-formatting/).

## **Ajustar o intervalo entre as séries**

Use [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) para controlar a distância entre séries de dados ao longo do eixo de profundidade de um gráfico 3D, expressa como porcentagem da largura do marcador. Use valores de **0 a 500**, inclusive: `0` elimina o intervalo, enquanto valores maiores aumentam o espaçamento. Com a profundidade do gráfico fixa, aumentar o intervalo deixa os marcadores mais finos ao longo do eixo de profundidade.

Acesse o grupo via [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). A configuração se aplica a todas as séries naquele grupo, não apenas à série usada para acessá‑lo. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) é somente leitura e reflete a configuração do grupo pai.

Essa configuração afeta gráficos de colunas e barras 3D, incluindo suas variantes cilindro, cone e pirâmide, bem como gráficos de linhas e áreas 3D. A aparência depende de as séries estarem dispostas em profundidade, agrupadas ou empilhadas. Para uma comparação clara dos intervalos entre séries separadas, use `ChartType.COLUMN_3D` da enumeração [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

Essas propriedades controlam diferentes aspectos do gráfico:

| Propriedade | Efeito |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Espaçamento entre séries ao longo do eixo de profundidade, como porcentagem da largura do marcador. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Espaçamento entre grupos adjacentes de barras ou colunas, como porcentagem da largura da barra ou coluna. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Profundidade geral do gráfico, como porcentagem da largura do gráfico. |

O exemplo autônomo a seguir usa os dados padrão do gráfico, que contêm três séries e quatro categorias. Ele salva duas apresentações com dados idênticos, rotação, largura do intervalo e profundidade do gráfico; apenas a profundidade do intervalo varia.

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

| Profundidade do intervalo: 0 % | Profundidade do intervalo: 500 % |
| --- | --- |
| ![Gráfico de colunas 3D sem intervalo entre séries ao longo do eixo de profundidade](gap_depth_0.png) | ![Gráfico de colunas 3D com intervalo de 500 % entre séries ao longo do eixo de profundidade](gap_depth_500.png) |

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

| Alterar para a primeira série | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Criar o gráfico | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Definir `type` como `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Definir `bar_3d_shape` como `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Definir a forma como `BOX` também altera o tipo de série para `CLUSTERED_COLUMN_3D`. Se o seu código fizer ramificações com base no tipo de série, leia `series.type` após alterar a forma. Um valor armazenado antes da atribuição ainda selecionaria a ramificação `CLUSTERED_CONE`.

![Comparação no PowerPoint mostrando a primeira série como cilindros, cones e colunas retangulares da esquerda para a direita](series-shapes.png)

## **Perguntas frequentes**

**Quais tipos de gráfico suportam o modo 3D no Aspose.Slides?**

Aspose.Slides oferece variantes 3D de gráficos de colunas, incluindo Column 3D, Clustered Column 3D, Stacked Column 3D e 100 % Stacked Column 3D, além de tipos 3D relacionados expostos pela enumeração [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Para uma lista exata e atualizada, consulte os membros de [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) na referência da API da versão instalada.

**Posso obter uma imagem raster de um gráfico 3D para um relatório ou a web?**

Sim. Você pode exportar um gráfico para uma imagem com [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) ou [renderizar o slide inteiro](/slides/pt/python-net/convert-powerpoint-to-png/) para formatos como PNG ou JPEG. Isso é útil quando você precisa de uma pré‑visualização raster ou deseja incorporar o gráfico em documentos, painéis ou páginas da web sem exigir o PowerPoint.

**Quão eficiente é a construção e renderização de gráficos 3D grandes?**

O desempenho depende do volume de dados e da complexidade visual. Para obter os melhores resultados, mantenha os efeitos 3D ao mínimo, evite texturas pesadas nas paredes e áreas de plotagem, limite o número de pontos de dados por série sempre que possível e renderize para uma resolução e dimensões adequadas ao destino de exibição ou impressão.