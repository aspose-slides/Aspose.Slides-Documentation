---
title: Personalizar Áreas de Plotagem de Gráficos de Apresentação em PHP
linktitle: Área de Plotagem
type: docs
url: /pt/php-java/chart-plot-area/
keywords:
- gráfico
- área de plotagem
- largura da área de plotagem
- altura da área de plotagem
- tamanho da área de plotagem
- modo de layout
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Descubra como personalizar áreas de plotagem de gráficos em apresentações PowerPoint com Aspose.Slides para PHP via Java. Melhore os visuais dos seus slides sem esforço."
---
## **Visão geral**

Este artigo mostra como trabalhar com a área de plotagem de um gráfico no Aspose.Slides. Ele explica como obter a posição e o tamanho reais da área de plotagem validando o layout do gráfico e, em seguida, lendo os valores de X, Y, largura e altura.

Ele também demonstra como configurar o modo de layout da área de plotagem quando o layout é definido manualmente, usando `LayoutTargetType` para definir se a área de plotagem é calculada pela sua região interna ou pela sua região externa juntamente com os eixos e os rótulos dos eixos.

## **Obter Largura e Altura de uma Área de Plotagem de Gráfico**
Aspose.Slides for PHP via Java fornece uma API simples para .

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Chame o método [Chart.validateChartLayout](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/validatechartlayout/) antes para obter os valores reais.
1. Obtém a localização X real (esquerda) do elemento do gráfico em relação ao canto superior esquerdo do gráfico.
1. Obtém o topo real do elemento do gráfico em relação ao canto superior esquerdo do gráfico.
1. Obtém a largura real do elemento do gráfico.
1. Obtém a altura real do elemento do gráfico.

```php
  # Criar uma instância da classe Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir o Modo de Layout de uma Área de Plotagem de Gráfico**
Aspose.Slides for PHP via Java fornece uma API simples para definir o modo de layout da área de plotagem do gráfico. Os métodos [**setLayoutTargetType**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) e [**getLayoutTargetType**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) foram adicionados à classe [**ChartPlotArea**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ChartPlotArea). Se o layout da área de plotagem for definido manualmente, esta propriedade especifica se o layout da área de plotagem será feito por dentro (não incluindo eixo e rótulos dos eixos) ou por fora (incluindo eixo e rótulos dos eixos). Existem dois valores possíveis que são definidos no enum [**LayoutTargetType**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/LayoutTargetType#Inner) - indica que o tamanho da área de plotagem determinará o tamanho da área de plotagem, não incluindo as marcas de escala e os rótulos dos eixos.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/LayoutTargetType#Outer) - indica que o tamanho da área de plotagem determinará o tamanho da área de plotagem, as marcas de escala e os rótulos dos eixos.

Um exemplo de código é fornecido abaixo.

```php
  # Criar uma instância da classe Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Em que unidades são retornados x real, y real, largura real e altura real?**

Em pontos; 1 polegada = 72 pontos. Estas são unidades de coordenadas do Aspose.Slides.

**Como a Área de Plotagem difere da Área do Gráfico em termos de conteúdo?**

A Área de Plotagem é a região de desenho dos dados (séries, linhas de grade, linhas de tendência etc.); a Área do Gráfico inclui os elementos circundantes (título, legenda etc.). Em gráficos 3D, a Área de Plotagem também inclui as paredes/piso e os eixos.

**Como são interpretados x, y, largura e altura da Área de Plotagem quando o layout é manual?**

Eles são frações (0–1) do tamanho total do gráfico; neste modo, o posicionamento automático está desativado e as frações definidas são usadas.

**Por que a posição da Área de Plotagem mudou após adicionar/mover a legenda?**

A legenda fica na área do gráfico fora da Área de Plotagem, mas afeta o layout e o espaço disponível, portanto a Área de Plotagem pode deslocar‑se quando o posicionamento automático está em vigor. (Este é o comportamento padrão dos gráficos do PowerPoint.)