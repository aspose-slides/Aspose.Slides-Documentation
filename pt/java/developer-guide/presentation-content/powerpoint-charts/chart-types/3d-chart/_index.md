---
title: Personalizar gráficos 3D em apresentações usando Java
linktitle: Gráfico 3D
type: docs
url: /pt/java/3d-chart/
keywords:
- gráfico 3D
- rotação
- profundidade
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Crie gráficos 3D em apresentações PowerPoint com Aspose.Slides para Java. Ajuste rotação, proporções de altura, profundidade do gráfico e espaçamento entre as séries com exemplos em Java."
---
## **Visão geral**

Aspose.Slides for Java permite que você personalize a visualização de um gráfico 3D através do método [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) . Este artigo demonstra como ajustar rotação, proporções de altura, profundidade, eixos em ângulo reto e espaçamento entre as séries, e então salvar a apresentação no formato PPTX.

## **Definir a rotação e a profundidade de um gráfico 3D**

O exemplo a seguir cria uma [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) e usa [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) para adicionar um gráfico de colunas 3D empilhado ao seu primeiro slide. Ele substitui as séries e categorias padrão por duas séries contendo três valores cada. O índice da planilha `0` identifica a primeira planilha de dados do gráfico; a linha `0` contém os nomes das séries e a coluna `0` contém os rótulos das categorias.

Os métodos [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) e [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) definem a rotação do gráfico para 40 e 270 graus, respectivamente. [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) define sua profundidade em 150 % da largura, enquanto [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) habilita eixos em ângulo reto em vez de perspectiva. A apresentação resultante contém o gráfico preenchido com essas configurações de visualização 3D.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aplicar preenchimento de imagem à superfície de um gráfico 3D**

Um gráfico 3D possui três superfícies que podem ser preenchidas independentemente: a [side wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getSideWall--) , a [back wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) e o [floor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--) . Defina o [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) da superfície como `Picture` e atribua uma imagem. Defina tanto o [picture fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) quanto o [picture type](https://reference.aspose.com/slides/java/com.aspose.slides/ichartwall/#setPictureType-int-) da superfície como `Stretch` para que uma única cópia da imagem ocupe a superfície.

Salve [arrow.png](arrow.png) no diretório de trabalho. O exemplo gira o gráfico e eleva o valor máximo no eixo vertical para que o floor fique visível entre as colunas. Em seguida, duplica o slide duas vezes e aplica a seta a uma superfície diferente em cada slide. Todos os três gráficos mantêm os mesmos dados, ângulo de visualização e plano de fundo.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    byte[] imageBytes = Files.readAllBytes(Paths.get("arrow.png"));
    IPPImage arrow = presentation.getImages().addImage(imageBytes);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O Microsoft PowerPoint exibe os três slides da seguinte forma.

| Parede lateral | Parede traseira | Piso |
| --- | --- | --- |
| ![Seta apontando para dentro do gráfico ao longo da parede lateral](side-wall.png) | ![Seta apontando para a direita ao longo da parede traseira](back-wall.png) | ![Seta apontando para a direita ao longo do piso entre as colunas](floor.png) |

## **Ajustar as proporções de altura de um gráfico 3D**

Use [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) para definir a altura de um gráfico 3D como percentual da sua largura. Isso altera as proporções da cena 3D sem redimensionar o objeto do gráfico no slide.

O exemplo a seguir cria um gráfico [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) com os dados padrão: três séries e quatro categorias. Ele salva três apresentações com proporções de altura de 50 %, 100 % e 200 %. A posição, largura e altura do gráfico permanecem fixas. Os dados, rotação, profundidade, espaçamento entre séries e formatação são idênticos nos três arquivos; apenas o percentual de altura varia.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

As imagens a seguir ilustram as mesmas configurações de altura no exemplo .NET equivalente e foram exportadas usando o Microsoft PowerPoint. Um percentual menor produz uma cena mais plana, enquanto um percentual maior produz uma cena mais alta dentro do mesmo objeto do gráfico. O PowerPoint pode também ajustar os intervalos das marcas de eixo e a colocação dos rótulos para caber na cena.

| Altura: 50 % | Altura: 100 % | Altura: 200 % |
| --- | --- | --- |
| ![Gráfico de colunas 3D com altura definida em 50 % da largura](height_percent_50.png) | ![Gráfico de colunas 3D com altura definida em 100 % da largura](height_percent_100.png) | ![Gráfico de colunas 3D com altura definida em 200 % da largura](height_percent_200.png) |

Esses métodos controlam diferentes aspectos do gráfico:

| Método | Efeito |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Altura da cena 3D como percentual da sua largura. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | Altura do objeto do gráfico no slide, em pontos. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Profundidade da cena 3D como percentual da sua largura. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Espaçamento entre séries ao longo do eixo de profundidade, como percentual da largura do marcador. |

A configuração de altura afeta gráficos de colunas e barras 3D, incluindo variantes cilindro, cone e pirâmide, bem como gráficos de linha, área, pizza e superfície 3D. A comparação acima utiliza o tipo verificado `Column3D`. A configuração não altera a aparência de um gráfico 2D `ClusteredColumn` ou de um gráfico `BubbleWith3D`; esses nomes são membros da classe [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Para outras configurações de aparência de gráfico, consulte [Formatação de Gráficos](/slides/pt/java/chart-formatting/).

## **Ajustar o intervalo entre as séries**

Use [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) para controlar a distância entre as séries de dados ao longo do eixo de profundidade de um gráfico 3D, expressa como percentual da largura do marcador. Use valores de **0 a 500**, inclusive: `0` remove o intervalo, enquanto valores maiores aumentam o espaçamento. Com a profundidade do gráfico fixa, aumentar o intervalo torna os marcadores mais finos ao longo do eixo de profundidade.

Acesse o grupo através de [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) . A configuração se aplica a todas as séries desse grupo, não apenas à série usada para acessá‑lo. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) retorna o intervalo de profundidade e reflete a configuração do grupo pai.

Essa configuração afeta gráficos de colunas e barras 3D, incluindo suas variantes cilindro, cone e pirâmide, bem como gráficos de linha e área 3D. A aparência depende de as séries estarem dispostas em profundidade, agrupadas ou empilhadas. Para uma comparação clara dos intervalos entre séries separadas, use `ChartType.Column3D` da classe [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/).

Esses métodos controlam diferentes aspectos do gráfico:

| Método | Efeito |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Espaçamento entre séries ao longo do eixo de profundidade, como percentual da largura do marcador. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Espaçamento entre grupos adjacentes de barras ou colunas, como percentual da largura da barra ou coluna. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Profundidade geral do gráfico, como percentual da largura do gráfico. |

O exemplo autocontido a seguir usa os dados padrão do gráfico, que contêm três séries e quatro categorias. Ele salva duas apresentações com dados idênticos, rotação, largura do intervalo e profundidade do gráfico; apenas a profundidade do intervalo muda.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

As imagens a seguir ilustram as mesmas configurações de profundidade do intervalo no exemplo .NET equivalente e foram exportadas usando o Microsoft PowerPoint.

| Profundidade do intervalo: 0 % | Profundidade do intervalo: 500 % |
| --- | --- |
| ![Gráfico de colunas 3D sem intervalo entre as séries ao longo do eixo de profundidade](gap_depth_0.png) | ![Gráfico de colunas 3D com intervalo de 500 % entre as séries ao longo do eixo de profundidade](gap_depth_500.png) |

## **Alterar o tipo de série 3D e a forma da barra**

Em um gráfico de cilindro agrupado, a primeira série começa com a forma de barra cilíndrica. O exemplo imprime os valores inteiros retornados por [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) e [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) antes e depois de cada mudança. A tabela fornece os nomes das constantes correspondentes.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Alteração na primeira série | Tipo da série | Forma da barra |
| --- | --- | --- |
| Criar o gráfico | `ClusteredCylinder` | `Cylinder` |
| Definir o tipo da série para `ClusteredCone` | `ClusteredCone` | `Cone` |
| Definir a forma da barra para `Box` | `ClusteredColumn3D` | `Box` |

Definir a forma como `Box` também altera o tipo da série para `ClusteredColumn3D`. Se o seu código fizer ramificações com base no tipo da série, chame `series.getType()` após mudar a forma. Um valor armazenado antes da atribuição ainda selecionaria a ramificação `ClusteredCone`.

![Comparação no PowerPoint mostrando a primeira série como cilindros, cones e colunas retangulares da esquerda para a direita](series-shapes.png)

## **FAQ**

**Quais tipos de gráfico suportam modo 3D no Aspose.Slides?**

Aspose.Slides suporta variantes 3D de gráficos de colunas, incluindo Column 3D, Clustered Column 3D, Stacked Column 3D e 100 % Stacked Column 3D, além de tipos 3D relacionados expostos através da classe [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Para uma lista exata e atualizada, verifique os membros de [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) na referência da API da sua versão instalada.

**Posso obter uma imagem raster de um gráfico 3D para um relatório ou a web?**

Sim. Você pode exportar um gráfico para uma imagem com [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) ou [renderizar o slide inteiro](/slides/pt/java/convert-powerpoint-to-png/) para formatos como PNG ou JPEG. Isso é útil quando você precisa de uma pré‑visualização raster ou deseja incorporar o gráfico em documentos, painéis ou páginas da web sem exigir o PowerPoint.

**Quão eficiente é a criação e renderização de gráficos 3D grandes?**

O desempenho depende do volume de dados e da complexidade visual. Para obter os melhores resultados, mantenha os efeitos 3D mínimos, evite texturas pesadas nas paredes e áreas de plotagem, limite o número de pontos de dados por série sempre que possível e renderize para uma saída de tamanho adequado (resolução e dimensões) que corresponda ao destino de exibição ou impressão.