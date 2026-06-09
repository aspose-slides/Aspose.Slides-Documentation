---
title: Personalizar Pontos de Dados em Gráficos Treemap e Sunburst Usando PHP
linktitle: Pontos de Dados em Gráficos Treemap e Sunburst
type: docs
url: /pt/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- gráfico treemap
- gráfico sunburst
- ponto de dados
- cor do rótulo
- cor do ramo
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda a gerenciar pontos de dados em gráficos treemap e sunburst com Aspose.Slides para PHP via Java, compatível com formatos do PowerPoint."
---
## **Introdução**

Entre outros tipos de gráficos do PowerPoint, existem dois tipos “hierárquicos” – **Treemap** e **Sunburst** (chart também conhecido como Gráfico Sunburst, Diagrama Sunburst, Gráfico Radial, Gráfico Radial ou Gráfico de Pizza Multinível). Esses gráficos exibem dados hierárquicos organizados como uma árvore – das folhas até o topo do ramo. As folhas são definidas pelos pontos de dados da série, e cada nível subsequente de agrupamento aninhado é definido pela categoria correspondente. Aspose.Slides for PHP via Java permite formatar pontos de dados do Gráfico Sunburst e Treemap .

Eis um Gráfico Sunburst, onde os dados na coluna Series1 definem os nós folha, enquanto as demais colunas definem pontos de dados hierárquicos:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Vamos começar adicionando um novo gráfico Sunburst à apresentação:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="Veja também" %}} 
- [**Criar ou Atualizar Gráficos de Apresentação PowerPoint em PHP**](/slides/pt/php-java/create-chart/)
{{% /alert %}}

Se for necessário formatar os pontos de dados do gráfico, devemos usar o seguinte:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatapointlevelsmanager/), 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatapointlevel/) classes 
e [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) method 
fornecem acesso para formatar pontos de dados de gráficos Treemap e Sunburst. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatapointlevelsmanager/)
é usado para acessar categorias de múltiplos níveis – representa o contêiner de 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatapointlevel/) objetos.
Basicamente é um wrapper para 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartcategorylevelsmanager/) com
as propriedades adicionadas específicas para pontos de dados. 
A classe [**ChartDataPointLevel**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatapointlevel/) tem
dois métodos: [**getFormat**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatapointlevel/#getFormat) e 
[**getDataLabel**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatapointlevel/#getLabel) que
fornecem acesso às configurações correspondentes.

## **Exibir Valor de um Ponto de Dados**
Mostrar o valor do ponto de dados "Leaf 4":

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Definir Rótulo e Cor de um Ponto de Dados**
Defina o rótulo de dados "Branch 1" para exibir o nome da série ("Series1") ao invés do nome da categoria. Em seguida, defina a cor do texto para amarelo:

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Definir Cor de Ramo de um Ponto de Dados**
Alterar a cor do ramo "Steam 4":

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Perguntas Frequentes**

**Posso mudar a ordem (classificação) dos segmentos em Sunburst/Treemap?**

Não. O PowerPoint classifica os segmentos automaticamente (normalmente por valores decrescentes, no sentido horário). O Aspose.Slides replica esse comportamento: não é possível alterar a ordem diretamente; isso é feito pré‑processando os dados.

**Como o tema da apresentação afeta as cores dos segmentos e rótulos?**

As cores dos gráficos herdam o [tema/paleta](/slides/pt/php-java/presentation-theme/) da apresentação, a menos que você defina explicitamente preenchimentos/fontes. Para resultados consistentes, fixe preenchimentos sólidos e formatação de texto nos níveis necessários.

**A exportação para PDF/PNG preservará cores de ramos personalizadas e configurações de rótulos?**

Sim. Ao exportar a apresentação, as configurações do gráfico (preenchimentos, rótulos) são preservadas nos formatos de saída porque o Aspose.Slides renderiza com a formatação do gráfico aplicada.

**Posso calcular as coordenadas reais de um rótulo/elemento para posicionamento de sobreposição personalizada sobre o gráfico?**

Sim. Após a disposição do gráfico ser validada, os valores reais de *x* e *y* ficam disponíveis para os elementos (por exemplo, um [DataLabel](https://reference.aspose.com/slides/pt/php-java/aspose.slides/datalabel/)), o que auxilia no posicionamento preciso das sobreposições.