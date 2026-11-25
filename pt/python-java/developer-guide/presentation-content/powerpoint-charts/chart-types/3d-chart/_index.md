---
title: Personalizar Gráficos 3D em Apresentações Usando Python
linktitle: Gráfico 3D
type: docs
url: /pt/python-java/3d-chart/
keywords:
- gráfico 3D
- rotação
- profundidade
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Crie gráficos 3D em apresentações do PowerPoint com Aspose.Slides for Python via Java. Ajuste rotação, proporções de altura, profundidade do gráfico e espaçamento entre séries com exemplos em Python."
---
## **Visão geral**

Aspose.Slides for Python via Java permite que você personalize a visualização de um gráfico 3D através do método [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D). Este artigo demonstra como ajustar a rotação, as proporções de altura, a profundidade, eixos de ângulo reto e o espaçamento entre as séries, e então salvar a apresentação no formato PPTX.

## **Definir a Rotação e Profundidade de um Gráfico 3D**

O exemplo abaixo cria uma [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) e usa [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) para adicionar um gráfico de colunas 3D empilhado ao seu primeiro slide. Ele substitui as séries e categorias padrão por duas séries contendo três valores cada. O índice da planilha `0` identifica a primeira planilha de dados do gráfico; a linha `0` contém os nomes das séries, e a coluna `0` contém os rótulos das categorias.

Os métodos [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) e [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) definem a rotação do gráfico para 40 e 270 graus, respectivamente. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) define sua profundidade para 150 % de sua largura, enquanto [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) habilita eixos de ângulo reto em vez de perspectiva. A apresentação resultante contém o gráfico preenchido com essas configurações de visualização 3D.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aplicar Preenchimento com Imagem à Superfície de um Gráfico 3D**

Um gráfico 3D possui três superfícies que podem ser preenchidas independentemente: a [side wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getSideWall), a [back wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) e o [floor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor). Defina o [fill type](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) da superfície como `Picture` e atribua uma imagem. Defina tanto o [picture fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) quanto o [picture type](https://reference.aspose.com/slides/python-java/aspose.slides/chartwall/#setPictureType) da superfície como `Stretch` para ajustar uma única cópia da imagem em toda a superfície.

Salve [arrow.png](arrow.png) no diretório de trabalho. O exemplo rotaciona o gráfico e aumenta o valor máximo no eixo vertical para que o piso fique visível entre as colunas. Em seguida, clona o slide duas vezes e aplica a seta a uma superfície diferente em cada slide. Todos os três gráficos mantêm os mesmos dados, ângulo de visualização e plano de fundo.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, PictureFillMode, PictureType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(30)
    
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(24)

    back_slide = presentation.getSlides().addClone(slide)
    floor_slide = presentation.getSlides().addClone(slide)
    back_chart = back_slide.getShapes().get_Item(0)
    floor_chart = floor_slide.getShapes().get_Item(0)

    image_bytes = Path("arrow.png").read_bytes()
    arrow = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_bytes))

    surfaces = (chart.getSideWall(), back_chart.getBackWall(), floor_chart.getFloor())
    for surface in surfaces:
        fill = surface.getFormat().getFill()
        fill.setFillType(FillType.Picture)
        picture_fill = fill.getPictureFillFormat()
        picture_fill.getPicture().setImage(arrow)
        picture_fill.setPictureFillMode(PictureFillMode.Stretch)
        surface.setPictureType(PictureType.Stretch)

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O Microsoft PowerPoint exibe os três slides da seguinte forma.

| Parede lateral | Parede traseira | Piso |
| --- | --- | --- |
| ![Seta apontando para dentro do gráfico ao longo da parede lateral](side-wall.png) | ![Seta apontando para a direita atravessando a parede traseira](back-wall.png) | ![Seta apontando para a direita atravessando o piso entre as colunas](floor.png) |

## **Ajustar as Proporções de Altura de um Gráfico 3D**

Use [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) para definir a altura de um gráfico 3D como porcentagem de sua largura. Isso altera as proporções da cena 3D sem redimensionar o objeto do gráfico no slide.

O exemplo a seguir cria um gráfico [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) com os dados padrão: três séries e quatro categorias. Ele salva três apresentações com proporções de altura de 50 %, 100 % e 200 %. A posição, largura e altura do gráfico permanecem fixas. Os dados, rotação, profundidade, espaçamento entre séries e formatação são idênticos nos três arquivos; apenas a porcentagem de altura muda.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

As imagens a seguir ilustram as mesmas configurações de altura no exemplo .NET equivalente e foram exportadas usando o Microsoft PowerPoint. Uma porcentagem menor produz uma cena mais plana, enquanto uma porcentagem maior produz uma cena mais alta dentro do mesmo objeto de gráfico. O PowerPoint também pode ajustar os intervalos das marcas dos eixos e a posição dos rótulos para se adequar à cena.

| Altura: 50% | Altura: 100% | Altura: 200% |
| --- | --- | --- |
| ![Gráfico de colunas 3D com altura definida em 50 % de sua largura](height_percent_50.png) | ![Gráfico de colunas 3D com altura definida em 100 % de sua largura](height_percent_100.png) | ![Gráfico de colunas 3D com altura definida em 200 % de sua largura](height_percent_200.png) |

Esses métodos controlam diferentes aspectos do gráfico:

| Método | Efeito |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Altura da cena 3D como porcentagem de sua largura. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Altura do objeto de gráfico no slide, em pontos. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Profundidade da cena 3D como porcentagem de sua largura. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Espaçamento entre séries ao longo do eixo de profundidade, como porcentagem da largura do marcador. |

A configuração de altura afeta gráficos de colunas e barras 3D, incluindo variantes de cilindro, cone e pirâmide, bem como gráficos 3D de linha, área, pizza e superfície. A comparação acima usa o tipo verificado `Column3D`. A configuração não altera a aparência de um gráfico 2D `ClusteredColumn` ou de um gráfico `BubbleWith3D`; esses nomes são membros da classe [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Para outras configurações de aparência de gráficos, veja [Chart Formatting](/slides/pt/python-java/chart-formatting/).

## **Ajustar o Espaço Entre Séries**

Use [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) para controlar a distância entre séries de dados ao longo do eixo de profundidade de um gráfico 3D, expressa como porcentagem da largura do marcador. Use valores de **0 a 500**, inclusive: `0` remove o espaço, enquanto valores maiores aumentam o espaçamento. Com a profundidade do gráfico fixa, aumentar o espaço torna os marcadores mais finos ao longo do eixo de profundidade.

Acesse o grupo através de [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). A configuração se aplica a todas as séries daquele grupo, não apenas à série usada para acessá-lo. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) retorna o espaço de profundidade e reflete a configuração do grupo pai.

Essa configuração afeta gráficos de colunas e barras 3D, incluindo suas variantes de cilindro, cone e pirâmide, bem como gráficos 3D de linha e área. A aparência depende de como as séries estão organizadas em profundidade, agrupadas ou empilhadas. Para uma comparação clara dos espaços entre séries distintas, use `ChartType.Column3D` da classe [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

Esses métodos controlam diferentes aspectos do gráfico:

| Método | Efeito |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Espaçamento entre séries ao longo do eixo de profundidade, como porcentagem da largura do marcador. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Espaçamento entre grupos adjacentes de barras ou colunas, como porcentagem da largura da barra ou coluna. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Profundidade geral do gráfico, como porcentagem da largura do gráfico. |

O exemplo autocontido a seguir usa os dados padrão do gráfico, que contêm três séries e quatro categorias. Ele salva duas apresentações com dados, rotação, largura do espaço e profundidade do gráfico idênticos; apenas o espaço de profundidade muda.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

As imagens a seguir ilustram as mesmas configurações de espaço de profundidade no exemplo .NET equivalente e foram exportadas usando o Microsoft PowerPoint.

| Espaço de profundidade: 0% | Espaço de profundidade: 500% |
| --- | --- |
| ![Gráfico de colunas 3D sem espaço entre as séries ao longo do eixo de profundidade](gap_depth_0.png) | ![Gráfico de colunas 3D com espaço de 500 % entre as séries ao longo do eixo de profundidade](gap_depth_500.png) |

## **Alterar o Tipo de Série 3D e a Forma da Barra**

Em um gráfico de cilindros agrupados, a primeira série começa com uma forma de barra cilíndrica. O exemplo imprime os valores inteiros retornados por [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) e [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) antes e depois de cada alteração. A tabela fornece os nomes constantes correspondentes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Alterar na primeira série | Tipo de série | Forma da barra |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

Definir a forma como `Box` também altera o tipo de série para `ClusteredColumn3D`. Se seu código fizer ramificações com base no tipo de série, chame `series.getType()` após mudar a forma. Um valor armazenado em cache antes da atribuição ainda selecionaria o ramo `ClusteredCone`.

![Comparação no PowerPoint mostrando a primeira série como cilindros, cones e colunas retangulares da esquerda para a direita](series-shapes.png)

## **FAQ**

**Quais tipos de gráfico suportam o modo 3D no Aspose.Slides?**

O Aspose.Slides suporta variantes 3D de gráficos de colunas, incluindo Column 3D, Clustered Column 3D, Stacked Column 3D e 100 % Stacked Column 3D, juntamente com tipos 3D relacionados expostos através da classe [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Para uma lista exata e atualizada, verifique os membros de [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) na referência da API da sua versão instalada.

**Posso obter uma imagem raster de um gráfico 3D para um relatório ou a web?**

Sim. Você pode exportar um gráfico para uma imagem com [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) ou [renderizar o slide inteiro](/slides/pt/python-java/convert-powerpoint-to-png/) para formatos como PNG ou JPEG. Isso é útil quando você precisa de uma pré‑visualização raster ou deseja incorporar o gráfico em documentos, dashboards ou páginas da web sem exigir o PowerPoint.

**Qual o desempenho ao criar e renderizar gráficos 3D grandes?**

O desempenho depende do volume de dados e da complexidade visual. Para obter os melhores resultados, mantenha os efeitos 3D ao mínimo, evite texturas pesadas nas paredes e áreas de plotagem, limite o número de pontos de dados por série quando possível e renderize para uma saída com tamanho adequado (resolução e dimensões) que corresponda ao dispositivo de exibição ou impressão alvo.