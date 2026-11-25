---
title: Personalizar Gráficos 3D em Apresentações Usando PHP
linktitle: Gráfico 3D
type: docs
url: /pt/php-java/3d-chart/
keywords:
- gráfico 3D
- rotação
- profundidade
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Crie gráficos 3D em apresentações PowerPoint com Aspose.Slides para PHP via Java. Ajuste rotação, proporções de altura, profundidade do gráfico e espaçamento entre séries com exemplos PHP."
---
## **Visão geral**

Aspose.Slides for PHP via Java permite personalizar a visualização de um gráfico 3D através do método [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D). Este artigo demonstra como ajustar rotação, proporções de altura, profundidade, eixos em ângulo reto e espaçamento entre séries, e então salvar a apresentação no formato PPTX.

## **Definir a Rotação e Profundidade de um Gráfico 3D**

O exemplo abaixo cria uma [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) e usa [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) para adicionar um gráfico de colunas 3D empilhadas ao seu primeiro slide. Ele substitui as séries e categorias padrão por duas séries contendo três valores cada. O índice da planilha `0` identifica a primeira planilha de dados do gráfico; a linha `0` contém os nomes das séries e a coluna `0` contém os rótulos das categorias.

Os métodos [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) e [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) definem a rotação do gráfico para 40 e 270 graus, respectivamente. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) define sua profundidade em 150 % da largura, enquanto [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) habilita eixos em ângulo reto em vez de perspectiva. A apresentação resultante contém o gráfico preenchido com essas configurações de visualização 3D.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Aplicar Preenchimento de Imagem à Superfície de um Gráfico 3D**

Você pode preencher a [side wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/), [back wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/), e o [floor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) de um gráfico 3D de forma independente. Defina o [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) da superfície como `Picture` e atribua uma imagem. Defina tanto o [picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) quanto o [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) da superfície como `Stretch` para ajustar uma cópia da imagem em toda a superfície.

Salve [arrow.png](arrow.png) ao lado do script PHP. O exemplo gira o gráfico e aumenta o valor máximo no eixo vertical para que o piso fique visível entre as colunas. Em seguida, ele duplica o slide duas vezes e aplica a seta a uma superfície diferente em cada slide. Todos os três gráficos mantêm os mesmos dados, ângulo de visualização e plano de fundo.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O Microsoft PowerPoint exibe os três slides da seguinte forma.

| Parede lateral | Parede traseira | Piso |
| --- | --- | --- |
| ![Seta apontando para dentro do gráfico ao longo da parede lateral](side-wall.png) | ![Seta apontando para a direita ao longo da parede traseira](back-wall.png) | ![Seta apontando para a direita ao longo do piso entre as colunas](floor.png) |

## **Ajustar as Proporções de Altura de um Gráfico 3D**

Use [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) para definir a altura de um gráfico 3D como percentual da sua largura. Isso altera as proporções da cena 3D sem redimensionar o objeto do gráfico no slide.

O exemplo a seguir cria um gráfico [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) com os dados padrão: três séries e quatro categorias. Ele salva três apresentações com proporções de altura de 50 %, 100 % e 200 %. A posição, largura e altura do gráfico permanecem fixas. Os dados, rotação, profundidade, espaçamento das séries e formatação são idênticos nos três arquivos; somente a porcentagem de altura varia.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

As imagens a seguir ilustram as mesmas configurações de altura no exemplo equivalente em .NET e foram exportadas usando o Microsoft PowerPoint. Um percentual menor produz uma cena mais achatada, enquanto um percentual maior produz uma cena mais alta dentro do mesmo objeto de gráfico. O PowerPoint também pode ajustar os intervalos de marcas do eixo e a posição dos rótulos para caber na cena.

| Altura: 50% | Altura: 100% | Altura: 200% |
| --- | --- | --- |
| ![Gráfico de coluna 3D com altura definida em 50 % da largura](height_percent_50.png) | ![Gráfico de coluna 3D com altura definida em 100 % da largura](height_percent_100.png) | ![Gráfico de coluna 3D com altura definida em 200 % da largura](height_percent_200.png) |

Esses métodos controlam diferentes aspectos do gráfico:

| Método | Efeito |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | Altura da cena 3D como percentual de sua largura. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Altura do objeto gráfico no slide, em pontos. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Profundidade da cena 3D como percentual de sua largura. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Espaçamento entre séries ao longo do eixo de profundidade, como percentual da largura do marcador. |

A configuração de altura afeta gráficos de colunas e barras 3D, incluindo variantes cilindro, cone e pirâmide, bem como gráficos de linha, área, pizza e superfície 3D. A comparação acima usa o tipo verificado `Column3D`. A configuração não altera a aparência de um gráfico 2D `ClusteredColumn` ou de um gráfico `BubbleWith3D`; esses nomes são membros da classe [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Para outras configurações de aparência de gráfico, veja a [Chart Formatting](/slides/pt/php-java/chart-formatting/).

## **Ajustar o Espaço Entre Séries**

Use [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) para controlar a distância entre séries de dados ao longo do eixo de profundidade de um gráfico 3D, expressa como percentual da largura do marcador. Use valores de **0 a 500**, inclusive: `0` remove o espaço, enquanto valores maiores aumentam o espaçamento. Com a profundidade do gráfico fixa, aumentar o espaço torna os marcadores mais finos ao longo do eixo de profundidade.

Acesse o grupo através de [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup). A configuração se aplica a todas as séries desse grupo, não apenas à série usada para acessá‑lo. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) retorna o espaço de profundidade e reflete a configuração do grupo pai.

Essa configuração afeta gráficos de colunas e barras 3D, incluindo suas variantes cilindro, cone e pirâmide, bem como gráficos de linha e área 3D. A aparência depende de as séries estarem dispostas em profundidade, em clusters ou empilhadas. Para uma comparação clara dos espaços entre séries separadas, use `ChartType::Column3D` da classe [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

Esses métodos controlam diferentes aspectos do gráfico:

| Método | Efeito |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Espaçamento entre séries ao longo do eixo de profundidade, como percentual da largura do marcador. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Espaçamento entre clusters adjacentes de barras ou colunas, como percentual da largura da barra ou coluna. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Profundidade geral do gráfico, como percentual da largura do gráfico. |

O exemplo autocontido a seguir usa os dados padrão do gráfico, que contêm três séries e quatro categorias. Ele salva duas apresentações com dados idênticos, rotação, largura do espaço e profundidade do gráfico; apenas o espaço de profundidade varia.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

As imagens a seguir ilustram as mesmas configurações de espaço de profundidade no exemplo equivalente em .NET e foram exportadas usando o Microsoft PowerPoint.

| Profundidade da lacuna: 0% | Profundidade da lacuna: 500% |
| --- | --- |
| ![Gráfico de coluna 3D sem espaço entre séries ao longo do eixo de profundidade](gap_depth_0.png) | ![Gráfico de coluna 3D com espaço de 500 % entre séries ao longo do eixo de profundidade](gap_depth_500.png) |

## **Alterar o Tipo de Série 3D e a Forma da Barra**

Em um gráfico de cilindro agrupado, a primeira série começa com a forma de barra cilíndrica. O exemplo imprime os valores inteiros retornados por [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) e [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) antes e depois de cada alteração. A tabela fornece os nomes de constantes correspondentes.

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Alteração na primeira série | Tipo de série | Forma da barra |
| --- | --- | --- |
| Crie o gráfico | `ClusteredCylinder` | `Cylinder` |
| Defina o tipo de série para `ClusteredCone` | `ClusteredCone` | `Cone` |
| Defina a forma da barra para `Box` | `ClusteredColumn3D` | `Box` |

Definir a forma como `Box` também altera o tipo de série para `ClusteredColumn3D`. Se o seu código branches com base no tipo de série, chame [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) após mudar a forma. Um valor armazenado antes da atribuição ainda selecionaria o branch `ClusteredCone`.

![Comparação no PowerPoint mostrando a primeira série como cilindros, cones e colunas retangulares da esquerda para a direita](series-shapes.png)

## **Perguntas frequentes**

**Quais tipos de gráfico suportam o modo 3D no Aspose.Slides?**

Aspose.Slides suporta variantes 3D de gráficos de colunas, incluindo Column 3D, Clustered Column 3D, Stacked Column 3D e 100 % Stacked Column 3D, além dos tipos 3D relacionados expostos pela classe [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Para obter uma lista exata e atualizada, verifique os membros de [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) na referência da API da sua versão instalada.

**Posso obter uma imagem raster de um gráfico 3D para um relatório ou a web?**

Sim. Você pode exportar um gráfico para uma imagem com [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) ou [renderizar o slide inteiro](/slides/pt/php-java/convert-powerpoint-to-png/) para formatos como PNG ou JPEG. Isso é útil quando você precisa de uma pré‑visualização raster ou deseja incorporar o gráfico em documentos, painéis ou páginas da web sem exigir o PowerPoint.

**Qual é o desempenho ao criar e renderizar grandes gráficos 3D?**

O desempenho depende do volume de dados e da complexidade visual. Para obter melhores resultados, mantenha os efeitos 3D ao mínimo, evite texturas pesadas nas paredes e áreas de trama, limite o número de pontos de dados por série quando possível e renderize para uma saída de tamanho adequado (resolução e dimensões) que corresponda ao dispositivo de exibição ou impressão alvo.