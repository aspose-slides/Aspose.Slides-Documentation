---
title: Criar ou Atualizar Gráficos de Apresentação PowerPoint em PHP
linktitle: Criar ou Atualizar Gráficos
type: docs
weight: 10
url: /pt/php-java/create-chart/
keywords:
- adicionar gráfico
- criar gráfico
- editar gráfico
- alterar gráfico
- atualizar gráfico
- gráfico de dispersão
- gráfico de pizza
- gráfico de linha
- gráfico de mapa de árvore
- gráfico de ações
- gráfico de caixa e bigodes
- gráfico em funil
- gráfico Sunburst
- gráfico de histograma
- gráfico de radar
- gráfico de múltiplas categorias
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Crie e customize gráficos em apresentações PowerPoint usando Aspose.Slides para PHP via Java. Adicione, formate e edite gráficos com exemplos de código práticos."
---
## **Visão geral**

Este artigo fornece um guia abrangente sobre como criar e personalizar gráficos usando Aspose.Slides. Você aprenderá como adicionar programaticamente um gráfico a um slide, preenchê‑lo com dados e aplicar várias opções de formatação para atender aos seus requisitos de design específicos. Ao longo do artigo, exemplos de código detalhados ilustram cada etapa, desde a inicialização da apresentação e do objeto de gráfico até a configuração de séries, eixos e legendas. Seguindo este guia, você obterá uma compreensão sólida de como integrar a geração dinâmica de gráficos em suas aplicações, simplificando o processo de criação de apresentações orientadas a dados.

## **Criar um Gráfico**

Os gráficos ajudam as pessoas a visualizar rapidamente os dados e obter insights, que podem não ser imediatamente óbvios em uma tabela ou planilha.

**Por que criar gráficos?**

Usando gráficos, você pode

* agregar, condensar ou resumir grandes quantidades de dados em um único slide de uma apresentação
* revelar padrões e tendências nos dados
* deduzir a direção e o impulso dos dados ao longo do tempo ou em relação a uma unidade de medida específica
* identificar valores atípicos, aberrações, desvios, erros, dados sem sentido, etc.
* comunicar ou apresentar dados complexos

No PowerPoint, você pode criar gráficos através da função inserir, que fornece modelos usados para projetar diversos tipos de gráficos. Usando Aspose.Slides, você pode criar gráficos regulares (com base em tipos de gráfico populares) e gráficos personalizados.

{{% alert color="primary" %}} 

Para permitir que você crie gráficos, Aspose.Slides fornece a classe [ChartType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ChartType). Os campos desta classe correspondem a diferentes tipos de gráfico.

{{% /alert %}} 

### **Criar Gráficos Normais**

_Etapas: Criar Gráfico_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Etapas:</em> Criar Gráfico PowerPoint </strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Etapas:</em> Criar Gráfico de Apresentação </strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Etapas:</em> Criar Gráfico de Apresentação PowerPoint </strong></a>

**Etapas de Código:**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através do seu índice.
3. Adicione um gráfico com alguns dados e especifique o tipo de gráfico desejado.
4. Adicione um título para o gráfico.
5. Acesse a planilha de dados do gráfico.
6. Limpe todas as séries e categorias padrão.
7. Adicione novas séries e categorias.
8. Adicione novos dados ao gráfico para as séries.
9. Defina uma cor de preenchimento para as séries do gráfico.
10. Adicione rótulos para as séries do gráfico.
11. Salve a apresentação modificada como um arquivo PPTX.

Este código PHP mostra como criar um gráfico normal:

```php
  # Instancia uma classe de apresentação que representa um arquivo PPTX
  $pres = new Presentation();
  try {
    # Acessa o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Adiciona um gráfico com seus dados padrão
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Define o título do gráfico
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # Define a primeira série para exibir valores
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Define o índice para a planilha de dados do gráfico
    $defaultWorksheetIndex = 0;
    # Obtém a planilha de dados do gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Exclui as séries e categorias geradas por padrão
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # Adiciona novas séries
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Adiciona novas categorias
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Obtém a primeira série do gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Agora preenche os dados da série
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Define a cor de preenchimento para a série
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Obtém a segunda série do gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Preenche os dados da série
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Define a cor de preenchimento para a série
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Cria rótulos personalizados para cada categoria da nova série
    # Define o primeiro rótulo para exibir o nome da categoria
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # Exibe o valor para o terceiro rótulo
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # Salva a apresentação com o gráfico
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Criar Gráficos Dispersos**

Gráficos dispersos (também conhecidos como diagramas de dispersão ou gráficos x‑y) são frequentemente usados para verificar padrões ou demonstrar correlações entre duas variáveis.

Você pode querer usar um gráfico disperso quando

* você tem dados numéricos pareados
* você tem 2 variáveis que se combinam bem
* deseja determinar se 2 variáveis estão relacionadas
* você tem uma variável independente com múltiplos valores para uma variável dependente

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Etapas:</em> Criar Gráfico Disperso </strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Etapas:</em> Criar Gráfico Disperso PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Etapas:</em> Criar Gráfico Disperso de Apresentação PowerPoint </strong></a>

1. Por favor, siga as etapas mencionadas acima em [Criando Gráficos Normais](#creating-normal-charts)
2. No terceiro passo, adicione um gráfico com alguns dados e especifique o tipo de gráfico como um dos seguintes
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/pt/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Representa um Gráfico de Dispersão com Marcadores._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/pt/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Representa um Gráfico de Dispersão conectado por curvas, com marcadores de dados._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/pt/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Representa um Gráfico de Dispersão conectado por curvas, sem marcadores de dados._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/pt/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Representa um Gráfico de Dispersão conectado por linhas retas, com marcadores de dados._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/pt/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Representa um Gráfico de Dispersão conectado por linhas retas, sem marcadores de dados._

Este código PHP mostra como criar gráficos dispersos com diferentes séries de marcadores:

```php
  # Instancia uma classe de apresentação que representa um arquivo PPTX
  $pres = new Presentation();
  try {
    # Acessa o primeiro slide
    $slide = $pres->getSlides()->get_Item(0);
    # Cria o gráfico padrão
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Obtém o índice da planilha de dados padrão do gráfico
    $defaultWorksheetIndex = 0;
    # Obtém a planilha de dados do gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Exclui a série de demonstração
    $chart->getChartData()->getSeries()->clear();
    # Adiciona novas séries
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # Obtém a primeira série do gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Adiciona um novo ponto (1:3) à série
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # Adiciona um novo ponto (2:10)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # Altera o tipo da série
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Altera o marcador da série do gráfico
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # Obtém a segunda série do gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Adiciona um novo ponto (5:2) lá
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Adiciona um novo ponto (3:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Adiciona um novo ponto (2:2)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Adiciona um novo ponto (5:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Altera o marcador da série do gráfico
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Criar Gráficos de Pizza**

Gráficos de pizza são mais adequados para mostrar a relação parte‑total em dados, especialmente quando os dados contêm rótulos categóricos com valores numéricos. No entanto, se seus dados contêm muitas partes ou rótulos, você pode considerar usar um gráfico de barras em vez disso.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Etapas:</em> Criar Gráfico de Pizza </strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Etapas:</em> Criar Gráfico de Pizza PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Etapas:</em> Criar Gráfico de Pizza de Apresentação PowerPoint </strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide pelo seu índice.
3. Adicione um gráfico com dados padrão juntamente com o tipo desejado (neste caso, [ChartType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ChartType).Pie).
4. Acesse o [ChartDataWorkbook](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/).
5. Limpe as séries e categorias padrão.
6. Adicione novas séries e categorias.
7. Adicione novos dados ao gráfico para as séries.
8. Adicione novos pontos ao gráfico e adicione cores personalizadas para os setores do gráfico de pizza.
9. Defina rótulos para as séries.
10. Defina linhas guias para os rótulos das séries.
11. Defina o ângulo de rotação para os slides do gráfico de pizza.
12. Salve a apresentação modificada em um arquivo PPTX.

Este código PHP mostra como criar um gráfico de pizza:

```php
  # Instancia uma classe de apresentação que representa um arquivo PPTX
  $pres = new Presentation();
  try {
    # Acessa o primeiro slide
    $slides = $pres->getSlides()->get_Item(0);
    # Adiciona um gráfico com dados padrão
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Define o Título do gráfico
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Define a primeira série para mostrar valores
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Define o índice da planilha de dados do gráfico
    $defaultWorksheetIndex = 0;
    # Obtém a planilha de dados do gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Exclui as séries e categorias geradas por padrão
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Adiciona novas categorias
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Adiciona novas séries
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Preenche os dados da série
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Não funciona na nova versão
    # Adicionando novos pontos e definindo a cor do setor
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # Define a borda do setor
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Define a borda do setor
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Define a borda do setor
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # Cria rótulos personalizados para cada categoria da nova série
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # Exibe linhas de ligação para o gráfico
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # Define o ângulo de rotação para os setores do gráfico de pizza
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # Salva a apresentação com um gráfico
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Criar Gráficos de Linha**

Gráficos de linha (também conhecidos como gráficos de linhas) são mais adequados em situações em que você deseja demonstrar alterações de valor ao longo do tempo. Usando um gráfico de linha, você pode comparar muitos dados ao mesmo tempo, rastrear mudanças e tendências ao longo do tempo, destacar anomalias nas séries de dados, etc.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Obtenha a referência de um slide através do seu índice.
1. Adicione um gráfico com dados padrão juntamente com o tipo desejado (neste caso, `ChartType::Line`).
1. Acesse a planilha de dados do gráfico IChartDataWorkbook.
1. Limpe as séries e categorias padrão.
1. Adicione novas séries e categorias.
1. Adicione novos dados ao gráfico para as séries.
1. Salve a apresentação modificada em um arquivo PPTX.

Este código PHP mostra como criar um gráfico de linha:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Por padrão, os pontos em um gráfico de linha são ligados por linhas retas contínuas. Se você quiser que os pontos sejam ligados por traços, pode especificar seu tipo de traço preferido desta forma:

```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```

### **Criar Gráficos de Mapa de Árvore**

Gráficos de mapa de árvore são mais adequados para dados de vendas quando você deseja mostrar o tamanho relativo das categorias de dados e (ao mesmo tempo) chamar rapidamente a atenção para itens que são grandes contribuintes de cada categoria.

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Etapas:</em> Criar Gráfico de Mapa de Árvore </strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Etapas:</em> Criar Gráfico de Mapa de Árvore PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Etapas:</em> Criar Gráfico de Mapa de Árvore de Apresentação PowerPoint </strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através do seu índice.
3. Adicione um gráfico com dados padrão juntamente com o tipo desejado (neste caso, [ChartType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ChartType).TreeMap).
4. Acesse o [ChartDataWorkbook](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/).
5. Limpe as séries e categorias padrão.
6. Adicione novas séries e categorias.
7. Adicione novos dados ao gráfico para as séries.
8. Salve a apresentação modificada em um arquivo PPTX.

Este código PHP mostra como criar um gráfico de mapa de árvore:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # ramo 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # ramo 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Criar Gráficos de Ações**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Etapas:</em> Criar Gráfico de Ações </strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Etapas:</em> Criar Gráfico de Ações PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Etapas:</em> Criar Gráfico de Ações de Apresentação PowerPoint </strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide pelo seu índice.
3. Adicione um gráfico com dados padrão juntamente com o tipo desejado ([ChartType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ChartType).OpenHighLowClose).
4. Acesse o [ChartDataWorkbook](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/).
5. Limpe as séries e categorias padrão.
6. Adicione novas séries e categorias.
7. Adicione novos dados ao gráfico para as séries.
8. Especifique o formato HiLowLines.
9. Salve a apresentação modificada em um arquivo PPTX.

Exemplo de código PHP usado para criar um gráfico de ações:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "Open"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "High"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "Low"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "Close"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    foreach($chart->getChartData()->getSeries() as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Criar Gráficos de Caixa e Bigodes**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Etapas:</em> Criar Gráfico de Caixa e Bigodes </strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Etapas:</em> Criar Gráfico de Caixa e Bigodes PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Etapas:</em> Criar Gráfico de Caixa e Bigodes de Apresentação PowerPoint </strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através do seu índice.
3. Adicione um gráfico com dados padrão juntamente com o tipo desejado ([ChartType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ChartType).BoxAndWhisker).
4. Acesse o [ChartDataWorkbook](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/).
5. Limpe as séries e categorias padrão.
6. Adicione novas séries e categorias.
7. Adicione novos dados ao gráfico para as séries.
8. Salve a apresentação modificada em um arquivo PPTX.

Este código PHP mostra como criar um gráfico de caixa e bigodes:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Criar Gráficos em Funil**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Etapas:</em> Criar Gráfico em Funil </strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Etapas:</em> Criar Gráfico em Funil PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Etapas:</em> Criar Gráfico em Funil de Apresentação PowerPoint </strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através do seu índice.
3. Adicione um gráfico com dados padrão juntamente com o tipo desejado ([ChartType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ChartType).Funnel).
4. Salve a apresentação modificada em um arquivo PPTX.

O código PHP mostra como criar um gráfico em funil:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Criar Gráficos Sunburst**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Etapas:</em> Criar Gráfico Sunburst </strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Etapas:</em> Criar Gráfico Sunburst PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Etapas:</em> Criar Gráfico Sunburst de Apresentação PowerPoint </strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através do seu índice.
3. Adicione um gráfico com dados padrão juntamente com o tipo desejado (neste caso, [ChartType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ChartType).sunburst).
4. Salve a apresentação modificada em um arquivo PPTX.

Este código PHP mostra como criar um gráfico Sunburst:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # ramo 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # ramo 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Criar Gráficos de Histograma**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Etapas:</em> Criar Gráfico de Histograma </strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Etapas:</em> Criar Gráfico de Histograma PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Etapas:</em> Criar Gráfico de Histograma de Apresentação PowerPoint </strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através do seu índice.
3. Adicione um gráfico com dados padrão juntamente com o tipo desejado ([ChartType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ChartType).Histogram).
4. Acesse o [ChartDataWorkbook](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/).
5. Limpe as séries e categorias padrão.
6. Adicione novas séries e categorias.
7. Salve a apresentação modificada em um arquivo PPTX.

Este código PHP mostra como criar um gráfico de histograma:

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);
```

### **Criar Gráficos de Radar**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Etapas:</em> Criar Gráfico de Radar </strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Etapas:</em> Criar Gráfico de Radar PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Etapas:</em> Criar Gráfico de Radar de Apresentação PowerPoint </strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através do seu índice.
3. Adicione um gráfico com alguns dados e especifique seu tipo de gráfico preferido (`ChartType::Radar` neste caso).
4. Salve a apresentação modificada em um arquivo PPTX.

Este código PHP mostra como criar um gráfico de radar:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Criar Gráficos Multi‑Categoria**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Etapas:</em> Criar Gráfico Multi‑Categoria </strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Etapas:</em> Criar Gráfico Multi‑Categoria PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Etapas:</em> Criar Gráfico Multi‑Categoria de Apresentação PowerPoint </strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através do seu índice.
3. Adicione um gráfico com dados padrão juntamente com o tipo desejado ([ChartType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ChartType).ClusteredColumn).
4. Acesse o [ChartDataWorkbook](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/).
5. Limpe as séries e categorias padrão.
6. Adicione novas séries e categorias.
7. Adicione novos dados ao gráfico para as séries.
8. Salve a apresentação modificada em um arquivo PPTX.

Este código PHP mostra como criar um gráfico multi‑categoria:

```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # Adicionando Série
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # Salvar apresentação com gráfico
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Criar Gráficos de Mapa**

Um gráfico de mapa é uma visualização de uma área contendo dados. Gráficos de mapa são mais adequados para comparar dados ou valores entre regiões geográficas.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Etapas:</em> Criar Gráfico de Mapa </strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Etapas:</em> Criar Gráfico de Mapa PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Etapas:</em> Criar Gráfico de Mapa de Apresentação PowerPoint </strong></a>

Este código PHP mostra como criar um gráfico de mapa:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Criar Gráficos de Combinação**

Um gráfico de combinação (ou gráfico combo) combina dois ou mais tipos de gráfico em um único gráfico. Este gráfico permite que você destaque, compare ou examine diferenças entre dois ou mais conjuntos de dados, ajudando a identificar relações entre eles.

![O gráfico de combinação](combination_chart.png)

O código PHP a seguir mostra como criar o gráfico de combinação exibido acima em uma apresentação PowerPoint:

```php
function createComboChart() {
    $presentation = new Presentation();
    $slide = $presentation->getSlides()->get_Item(0);
    try {
        $chart = createChartWithFirstSeries($slide);

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide) {
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // Definir o título do gráfico.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Definir a legenda do gráfico.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Excluir as séries e categorias geradas por padrão.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Adicionar novas categorias.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // Adicionar a primeira série.
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 4.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 2.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 3.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 4.5));

    return $chart;
}

function addSecondSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 2, 2.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 2, 4.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 2, 1.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 1, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 2, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 3, 3, 3.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 4, 3, 5.0));

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart) {
    // Definir o eixo horizontal.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // Definir o eixo vertical.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // Definir a cor das linhas de grade principais verticais.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // Definir o eixo horizontal secundário.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // Definir o eixo vertical secundário.
    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle) {
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titleParagraph = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(12);
}
```

## **Atualizar Gráficos**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Etapas:</em> Atualizar Gráfico PowerPoint </strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Etapas:</em> Atualizar Gráfico de Apresentação </strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Etapas:</em> Atualizar Gráfico de Apresentação PowerPoint </strong></a>

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) que representa a apresentação contendo o gráfico que você deseja atualizar.
2. Obtenha a referência de um slide usando seu índice.
3. Percorra todas as formas para encontrar o gráfico desejado.
4. Acesse a planilha de dados do gráfico.
5. Modifique os dados da série do gráfico alterando os valores das séries.
6. Adicione uma nova série e preencha os dados nela.
7. Salve a apresentação modificada como um arquivo PPTX.

Este código PHP mostra como atualizar um gráfico:

```php
  $pres = new Presentation();
  try {
    # Acessar primeiro slideMarker
    $sld = $pres->getSlides()->get_Item(0);
    # Obter gráfico com dados padrão
    $chart = $sld->getShapes()->get_Item(0);
    # Definir o índice da planilha de dados do gráfico
    $defaultWorksheetIndex = 0;
    # Obter a planilha de dados do gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Alterar o nome da categoria do gráfico
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # Obter a primeira série do gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Agora atualizando os dados da série
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Modificando o nome da série

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # Obter a segunda série do gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Agora atualizando os dados da série
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Modificando o nome da série

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Agora, adicionando uma nova série
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # Obter a terceira série do gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Agora populando os dados da série
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # Salvar apresentação com gráfico
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir Intervalo de Dados para um Gráfico**

Para definir o intervalo de dados para um gráfico, faça o seguinte:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) que representa a apresentação contendo o gráfico.
2. Obtenha a referência de um slide através do seu índice.
3. Percorra todas as formas para encontrar o gráfico desejado.
4. Acesse os dados do gráfico e defina o intervalo.
5. Salve a apresentação modificada como um arquivo PPTX.

Este código PHP mostra como definir o intervalo de dados para um gráfico:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Usar Marcadores Padrão em Gráficos**

Quando você usa um marcador padrão em gráficos, cada série de gráfico recebe automaticamente símbolos de marcador diferentes.

Este código PHP mostra como definir automaticamente um marcador de série de gráfico:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "Series 2"), $chart->getType());
    # Obter a segunda série do gráfico
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # Agora populando os dados da série
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Quais tipos de gráficos são suportados pelo Aspose.Slides?**

Aspose.Slides suporta uma ampla variedade de [chart types](https://reference.aspose.com/slides/pt/php-java/aspose.slides/charttype/), incluindo barra, linha, pizza, área, dispersão, histograma, radar e muitos mais. Essa flexibilidade permite que você escolha o tipo de gráfico mais adequado para as necessidades de visualização dos seus dados.

**Como adiciono um novo gráfico a um slide?**

Para adicionar um gráfico, primeiro crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) , recupere o slide desejado usando seu índice e, em seguida, chame o método para adicionar um gráfico, especificando o tipo de gráfico e os dados iniciais. Esse processo integra o gráfico diretamente à sua apresentação.

**Como posso atualizar os dados exibidos em um gráfico?**

Você pode atualizar os dados de um gráfico acessando sua planilha de dados ([ChartDataWorkbook](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/)), limpando quaisquer séries e categorias padrão e, em seguida, adicionando seus dados personalizados. Isso permite que você atualize o gráfico para refletir os dados mais recentes.

**É possível personalizar a aparência do gráfico?**

Sim, Aspose.Slides oferece amplas opções de personalização. Você pode modificar cores, fontes, rótulos, legendas e outros [formatting elements](/slides/pt/php-java/chart-entities/) para adequar a aparência do gráfico aos seus requisitos de design específicos.