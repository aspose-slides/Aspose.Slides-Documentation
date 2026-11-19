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
description: "Crie gráficos 3D em apresentações do PowerPoint com Aspose.Slides para Node.js via Java. Ajuste rotação, proporções de altura, profundidade do gráfico e espaçamento entre séries com exemplos em JavaScript."
---
## **Visão geral**

Aspose.Slides for Node.js via Java permite personalizar a visualização de um gráfico 3D através do método [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/). Este artigo demonstra como ajustar rotação, proporções de altura, profundidade, eixos em ângulo reto e espaçamento entre séries, e então salvar a apresentação no formato PPTX.

## **Definir rotação e profundidade de um gráfico 3D**

O exemplo abaixo cria uma [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) e usa [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) para adicionar um gráfico de colunas 3D empilhado ao seu primeiro slide. Ele substitui as séries e categorias padrão por duas séries contendo três valores cada. O índice da planilha `0` identifica a primeira planilha de dados do gráfico; a linha `0` contém os nomes das séries e a coluna `0` contém os rótulos das categorias.

Os métodos [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) e [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) definem a rotação do gráfico para 40 e 270 graus, respectivamente. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) define sua profundidade em 150 % da largura, enquanto [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) habilita eixos em ângulo reto em vez de perspectiva. A apresentação resultante contém o gráfico preenchido com essas configurações de visualização 3D.

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

## **Ajustar proporções de altura de um gráfico 3D**

Use [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) para definir a altura de um gráfico 3D como porcentagem de sua largura. Isso altera as proporções da cena 3D sem redimensionar o objeto do gráfico no slide.

O exemplo a seguir cria um gráfico [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) com os dados padrão: três séries e quatro categorias. Ele salva três apresentações com proporções de altura de 50 %, 100 % e 200 %. A posição, largura e altura do gráfico permanecem fixas. Os dados, rotação, profundidade, espaçamento entre séries e formatação são idênticos nos três arquivos; apenas a porcentagem de altura é alterada.

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

As imagens a seguir ilustram as mesmas configurações de altura no exemplo equivalente em .NET e foram exportadas usando o Microsoft PowerPoint. Uma porcentagem menor produz uma cena mais plana, enquanto uma porcentagem maior produz uma cena mais alta dentro do mesmo objeto de gráfico. O PowerPoint também pode ajustar os intervalos de marcações dos eixos e a colocação dos rótulos para caber na cena.

| Altura: 50% | Altura: 100% | Altura: 200% |
| --- | --- | --- |
| ![gráfico de colunas 3D com altura definida em 50 por cento da sua largura](height_percent_50.png) | ![gráfico de colunas 3D com altura definida em 100 por cento da sua largura](height_percent_100.png) | ![gráfico de colunas 3D com altura definida em 200 por cento da sua largura](height_percent_200.png) |

Estes métodos controlam diferentes aspectos do gráfico:

| Método | Efeito |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Altura da cena 3D como porcentagem da sua largura. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Altura do objeto do gráfico no slide, em pontos. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Profundidade da cena 3D como porcentagem da sua largura. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Espaçamento entre séries ao longo do eixo de profundidade, como porcentagem da largura do marcador. |

A configuração de altura afeta gráficos de colunas e barras 3D, incluindo variantes cilindro, cone e pirâmide, bem como gráficos de linha, área, pizza e superfície 3D. A comparação acima utiliza o tipo verificado `Column3D`. A configuração não altera a aparência de um gráfico 2D `ClusteredColumn` ou de um gráfico `BubbleWith3D`; esses nomes são membros da classe [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Para outras configurações de aparência de gráfico, veja [Chart Formatting](/slides/pt/nodejs-java/chart-formatting/).

## **Ajustar o espaçamento entre séries**

Use [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) para controlar a distância entre séries de dados ao longo do eixo de profundidade de um gráfico 3D, expressa como porcentagem da largura do marcador. Use valores de **0 a 500**, inclusive: `0` remove o espaçamento, enquanto valores maiores aumentam o espaço. Com profundidade de gráfico fixa, aumentar o espaçamento deixa os marcadores mais finos ao longo do eixo de profundidade.

Acesse o grupo através de [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). A configuração se aplica a todas as séries desse grupo, não apenas à série usada para acessá‑lo. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) devolve o espaçamento de profundidade e reflete a configuração do grupo pai.

Esta configuração afeta gráficos de colunas e barras 3D, incluindo suas variantes cilindro, cone e pirâmide, bem como gráficos de linha e área 3D. A aparência depende de as séries estarem dispostas em profundidade, agrupadas ou empilhadas. Para uma comparação clara dos espaçamentos entre séries distintas, use `ChartType.Column3D` da classe [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

Estes métodos controlam diferentes aspectos do gráfico:

| Método | Efeito |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Espaçamento entre séries ao longo do eixo de profundidade, como porcentagem da largura do marcador. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Espaçamento entre clusters adjacentes de barras ou colunas, como porcentagem da largura da barra ou coluna. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Profundidade geral do gráfico, como porcentagem da largura do gráfico. |

O exemplo autônomo a seguir usa os dados padrão do gráfico, que contêm três séries e quatro categorias. Ele salva duas apresentações com dados, rotação, largura do espaçamento e profundidade do gráfico idênticos; apenas a profundidade do espaçamento é alterada.

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

As imagens a seguir ilustram as mesmas configurações de profundidade de espaçamento no exemplo equivalente em .NET e foram exportadas usando o Microsoft PowerPoint.

| Profundidade do espaçamento: 0% | Profundidade do espaçamento: 500% |
| --- | --- |
| ![gráfico de colunas 3D sem espaço entre séries ao longo do eixo de profundidade](gap_depth_0.png) | ![gráfico de colunas 3D com um espaço de 500 por cento entre séries ao longo do eixo de profundidade](gap_depth_500.png) |

## **Alterar o tipo de série 3D e a forma da barra**

Em um gráfico de cilindro agrupado, a primeira série inicia com a forma de barra cilíndrica. O exemplo imprime os valores inteiros retornados por [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) e [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) antes e depois de cada alteração. A tabela fornece os nomes constantes correspondentes.

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

| Alterar na primeira série | Tipo de série | Forma da barra |
| --- | --- | --- |
| Criar o gráfico | `ClusteredCylinder` | `Cylinder` |
| Definir o tipo da série para `ClusteredCone` | `ClusteredCone` | `Cone` |
| Definir a forma da barra para `Box` | `ClusteredColumn3D` | `Box` |

Definir a forma para `Box` também altera o tipo da série para `ClusteredColumn3D`. Se seu código ramifica com base no tipo da série, chame `series.getType()` após mudar a forma. Um valor armazenado em cache antes da atribuição ainda selecionaria o ramo `ClusteredCone`.

![comparação no PowerPoint mostrando a primeira série como cilindros, cones e colunas retangulares da esquerda para a direita](series-shapes.png)

## **Perguntas frequentes**

**Quais tipos de gráfico suportam modo 3D no Aspose.Slides?**

Aspose.Slides suporta variantes 3D de gráficos de colunas, incluindo Column 3D, Clustered Column 3D, Stacked Column 3D e 100 % Stacked Column 3D, além de tipos 3D relacionados expostos através da classe [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Para uma lista exata e atualizada, verifique os membros de [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) na referência da API da versão instalada.

**Posso obter uma imagem raster de um gráfico 3D para um relatório ou web?**

Sim. Você pode exportar um gráfico para uma imagem com [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) ou [renderizar o slide inteiro](/slides/pt/nodejs-java/convert-powerpoint-to-png/) para formatos como PNG ou JPEG. Isso é útil quando você precisa de uma pré‑visualização raster ou deseja incorporar o gráfico em documentos, painéis ou páginas web sem exigir o PowerPoint.

**Qual é o desempenho ao criar e renderizar grandes gráficos 3D?**

O desempenho depende do volume de dados e da complexidade visual. Para obter os melhores resultados, mantenha os efeitos 3D ao mínimo, evite texturas pesadas nas paredes e áreas de plotagem, limite o número de pontos de dados por série sempre que possível e renderize para uma saída de tamanho adequado (resolução e dimensões) que corresponda ao dispositivo de exibição ou impressão alvo.