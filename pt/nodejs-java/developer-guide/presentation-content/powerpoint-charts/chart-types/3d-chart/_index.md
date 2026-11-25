---
title: Personalizar Gráficos 3D em Apresentações Usando JavaScript
linktitle: Gráfico 3D
type: docs
url: /pt/nodejs-java/3d-chart/
keywords:
- gráfico 3D
- rotação
- profundidade
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Criar gráficos 3D em apresentações PowerPoint com Aspose.Slides para Node.js via Java. Ajustar rotação, proporções de altura, profundidade do gráfico e espaçamento entre séries com exemplos JavaScript."
---
## **Visão geral**

Aspose.Slides para Node.js via Java permite personalizar a visualização de um gráfico 3D por meio do método [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/). Este artigo demonstra como ajustar a rotação, as proporções de altura, a profundidade, os eixos em ângulo reto e o espaçamento entre séries, e então salvar a apresentação no formato PPTX.

## **Definir a rotação e a profundidade de um gráfico 3D**

O exemplo a seguir cria uma [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) e usa [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) para adicionar um gráfico de colunas 3D empilhado ao seu primeiro slide. Ele substitui as séries e categorias padrão por duas séries contendo três valores cada. O índice da planilha `0` identifica a primeira planilha de dados do gráfico; a linha `0` contém os nomes das séries e a coluna `0` contém os rótulos das categorias.

Os métodos [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) e [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) definem a rotação do gráfico para 40 e 270 graus, respectivamente. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) define sua profundidade para 150 % da sua largura, enquanto [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) habilita eixos em ângulo reto em vez de perspectiva. A apresentação resultante contém o gráfico preenchido com essas configurações de visualização 3D.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aplicar preenchimento de imagem à superfície de um gráfico 3D**

Você pode preencher independentemente a [parede lateral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/), a [parede traseira](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/) e o [piso](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) de um gráfico 3D. Defina o [tipo de preenchimento](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) da superfície como `Picture` e atribua uma imagem. Defina tanto o [modo de preenchimento de imagem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) quanto o [tipo de imagem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) da superfície como `Stretch` para ajustar uma única cópia da imagem em toda a superfície.

Salve [arrow.png](arrow.png) no diretório de trabalho. O exemplo gira o gráfico e eleva o valor máximo no eixo vertical para que o piso fique visível entre as colunas. Em seguida, duplica o slide duas vezes e aplica a seta a uma superfície diferente em cada slide. Todos os três gráficos mantêm os mesmos dados, ângulo de visualização e plano de fundo.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O Microsoft PowerPoint exibe os três slides da seguinte forma.

| Parede lateral | Parede traseira | Piso |
| --- | --- | --- |
| ![Seta apontando para dentro do gráfico ao longo da parede lateral](side-wall.png) | ![Seta apontando para a direita através da parede traseira](back-wall.png) | ![Seta apontando para a direita através do piso entre as colunas](floor.png) |

## **Ajustar as proporções de altura de um gráfico 3D**

Use [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) para definir a altura de um gráfico 3D como uma porcentagem da sua largura. Isso altera as proporções da cena 3D sem redimensionar o objeto do gráfico no slide.

O exemplo a seguir cria um gráfico [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) com os dados padrão: três séries e quatro categorias. Ele salva três apresentações com proporções de altura de 50 %, 100 % e 200 %. A posição, largura e altura do gráfico permanecem fixas. Os dados, rotação, profundidade, espaçamento das séries e formatação são idênticos em todos os três arquivos; somente a porcentagem de altura é alterada.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

As imagens a seguir ilustram as mesmas configurações de altura no exemplo equivalente em .NET e foram exportadas usando o Microsoft PowerPoint. Uma porcentagem menor produz uma cena mais plana, enquanto uma porcentagem maior produz uma cena mais alta dentro do mesmo objeto de gráfico. O PowerPoint também pode ajustar os intervalos de marcações dos eixos e a posição dos rótulos para adaptar a cena.

| Altura: 50% | Altura: 100% | Altura: 200% |
| --- | --- | --- |
| ![Gráfico de colunas 3D com altura definida em 50 % da sua largura](height_percent_50.png) | ![Gráfico de colunas 3D com altura definida em 100 % da sua largura](height_percent_100.png) | ![Gráfico de colunas 3D com altura definida em 200 % da sua largura](height_percent_200.png) |

Esses métodos controlam diferentes aspectos do gráfico:

| Método | Efeito |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Altura da cena 3D como uma porcentagem da sua largura. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Altura do objeto do gráfico no slide, em pontos. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Profundidade da cena 3D como uma porcentagem da sua largura. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Espaçamento entre séries ao longo do eixo de profundidade, como uma porcentagem da largura do marcador. |

A configuração de altura afeta gráficos de colunas e barras 3D, incluindo variantes de cilindro, cone e pirâmide, bem como gráficos 3D de linha, área, pizza e superfície. A comparação acima usa o tipo verificado `Column3D`. A configuração não altera a aparência de um gráfico 2D `ClusteredColumn` ou de um gráfico `BubbleWith3D`; esses nomes são membros da classe [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Para outras configurações de aparência de gráficos, veja [Formatação de Gráfico](/slides/pt/nodejs-java/chart-formatting/).

## **Ajustar o espaço entre séries**

Use [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) para controlar a distância entre as séries de dados ao longo do eixo de profundidade de um gráfico 3D, expressa como uma porcentagem da largura do marcador. Use valores de **0 a 500**, inclusive: `0` remove o espaço, enquanto valores maiores aumentam o espaçamento. Com a profundidade do gráfico fixa, aumentar o espaço deixa os marcadores mais finos ao longo do eixo de profundidade.

Acesse o grupo através de [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). A configuração se aplica a todas as séries desse grupo, não apenas à série usada para acessá-lo. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) retorna o espaço de profundidade e reflete a configuração do grupo pai.

Esta configuração afeta gráficos de colunas e barras 3D, incluindo suas variantes de cilindro, cone e pirâmide, bem como gráficos 3D de linha e área. A aparência depende de como as séries estão organizadas: em profundidade, agrupadas ou empilhadas. Para uma comparação clara dos espaços entre séries distintas, use `ChartType.Column3D` da classe [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

Esses métodos controlam diferentes aspectos do gráfico:

| Método | Efeito |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Espaçamento entre séries ao longo do eixo de profundidade, como uma porcentagem da largura do marcador. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Espaçamento entre clusters de barras ou colunas adjacentes, como uma porcentagem da largura da barra ou coluna. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Profundidade geral do gráfico, como uma porcentagem da largura do gráfico. |

O exemplo autocontido a seguir usa os dados padrão do gráfico, que contêm três séries e quatro categorias. Ele salva duas apresentações com dados, rotação, largura de espaço e profundidade do gráfico idênticos; somente a profundidade do espaço varia.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

As imagens a seguir ilustram as mesmas configurações de profundidade de espaço no exemplo equivalente em .NET e foram exportadas usando o Microsoft PowerPoint.

| Profundidade do espaço: 0% | Profundidade do espaço: 500% |
| --- | --- |
| ![Gráfico de colunas 3D sem espaço entre séries ao longo do eixo de profundidade](gap_depth_0.png) | ![Gráfico de colunas 3D com espaço de 500 % entre séries ao longo do eixo de profundidade](gap_depth_500.png) |

## **Alterar o tipo de série 3D e a forma da barra**

Em um gráfico de cilindro agrupado, a primeira série começa com uma forma de barra cilíndrica. O exemplo exibe os valores inteiros retornados por [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) e [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) antes e depois de cada alteração. A tabela fornece os nomes constantes correspondentes.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Alteração da primeira série | Tipo de série | Forma da barra |
| --- | --- | --- |
| Criar o gráfico | `ClusteredCylinder` | `Cylinder` |
| Definir o tipo de série para `ClusteredCone` | `ClusteredCone` | `Cone` |
| Definir a forma da barra para `Box` | `ClusteredColumn3D` | `Box` |

Definir a forma como `Box` também altera o tipo de série para `ClusteredColumn3D`. Se o seu código faz ramificações com base no tipo de série, chame `series.getType()` após mudar a forma. Um valor armazenado em cache antes da atribuição ainda selecionaria o ramo `ClusteredCone`.

![Comparação no PowerPoint mostrando a primeira série como cilindros, cones e colunas retangulares da esquerda para a direita](series-shapes.png)

## **Perguntas frequentes**

**Quais tipos de gráfico suportam o modo 3D no Aspose.Slides?**

O Aspose.Slides suporta variantes 3D de gráficos de colunas, incluindo Column 3D, Clustered Column 3D, Stacked Column 3D e 100 % Stacked Column 3D, além de tipos 3D relacionados expostos pela classe [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Para obter uma lista exata e atualizada, verifique os membros de [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) na referência da API da versão instalada.

**Posso obter uma imagem raster de um gráfico 3D para um relatório ou a web?**

Sim. Você pode exportar um gráfico para uma imagem com [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) ou [renderizar o slide inteiro](/slides/pt/nodejs-java/convert-powerpoint-to-png/) para formatos como PNG ou JPEG. Isso é útil quando você precisa de uma visualização raster ou deseja incorporar o gráfico em documentos, painéis ou páginas da web sem precisar do PowerPoint.

**Qual é o desempenho ao criar e renderizar gráficos 3D grandes?**

O desempenho depende do volume de dados e da complexidade visual. Para obter os melhores resultados, mantenha os efeitos 3D ao mínimo, evite texturas pesadas nas paredes e áreas de plotagem, limite o número de pontos de dados por série quando possível e renderize para uma saída com tamanho adequado (resolução e dimensões) para atender às necessidades da exibição ou impressão alvo.