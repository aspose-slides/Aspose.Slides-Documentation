---
title: Formatar Gráficos de Apresentação em PHP
linktitle: Formatação de Gráficos
type: docs
weight: 60
url: /pt/php-java/chart-formatting/
keywords:
- formatar gráfico
- formatação de gráfico
- entidade de gráfico
- propriedades de gráfico
- configurações de gráfico
- opções de gráfico
- propriedades de fonte
- borda arredondada
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda a formatar gráficos no Aspose.Slides para PHP via Java e eleve sua apresentação PowerPoint com estilos profissionais e atraentes."
---
## **Visão geral**

Este artigo explica como formatar gráficos em apresentações do PowerPoint usando Aspose.Slides. Ele mostra como personalizar os principais elementos do gráfico, como eixos, linhas de grade, títulos, legendas, a área de plotagem e os preenchimentos de parede, para melhorar a aparência e a legibilidade dos dados do gráfico.

Também demonstra como definir propriedades de fonte para o texto do gráfico, aplicar formatos numéricos predefinidos e personalizados aos dados do gráfico e habilitar cantos arredondados para a área do gráfico. Juntos, esses exemplos mostram como controlar tanto o estilo visual quanto a apresentação dos dados dos gráficos em uma apresentação.

## **Formatar Entidades de Gráfico**
Aspose.Slides for PHP via Java permite que desenvolvedores adicionem gráficos personalizados aos seus slides do zero. Este artigo explica como formatar diferentes entidades de gráfico, incluindo o eixo de categoria e o eixo de valores.

Aspose.Slides for PHP via Java fornece uma API simples para gerenciar diferentes entidades de gráfico e formatá‑las usando valores personalizados:

1. Crie uma instância da classe [**Presentation**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione um gráfico com dados padrão juntamente com qualquer tipo desejado (neste exemplo usaremos ChartType::LineWithMarkers).
1. Acesse o Eixo de Valores do gráfico e defina as seguintes propriedades:
   1. Definindo **Line format** para as linhas de grade principais do Eixo de Valores
   1. Definindo **Line format** para as linhas de grade secundárias do Eixo de Valores
   1. Definindo **Number Format** para o Eixo de Valores
   1. Definindo **Min, Max, Major and Minor units** para o Eixo de Valores
   1. Definindo **Text Properties** para os dados do Eixo de Valores
   1. Definindo **Title** para o Eixo de Valores
   1. Definindo **Line Format** para o Eixo de Valores
1. Acesse o Eixo de Categoria do gráfico e defina as seguintes propriedades:
   1. Definindo **Line format** para as linhas de grade principais do Eixo de Categoria
   1. Definindo **Line format** para as linhas de grade secundárias do Eixo de Categoria
   1. Definindo **Text Properties** para os dados do Eixo de Categoria
   1. Definindo **Title** para o Eixo de Categoria
   1. Definindo **Label Positioning** para o Eixo de Categoria
   1. Definindo **Rotation Angle** para os rótulos do Eixo de Categoria
1. Acesse a legenda do gráfico e defina as **Text Properties** para ela
1. Defina a exibição das legendas do gráfico sem sobrepor o gráfico
1. Acesse o **Secondary Value Axis** do gráfico e defina as seguintes propriedades:
   1. Habilite o **Value Axis** secundário
   1. Definindo **Line Format** para o Secondary Value Axis
   1. Definindo **Number Format** para o Secondary Value Axis
   1. Definindo **Min, Max, Major and Minor units** para o Secondary Value Axis
1. Agora plotar a primeira série de gráfico no Eixo de Valores Secundário
1. Defina a cor de preenchimento da parede traseira do gráfico
1. Defina a cor de preenchimento da área de plotagem do gráfico
1. Grave a apresentação modificada em um arquivo PPTX

```php
  # Crie uma instância da classe Presentation
  $pres = new Presentation();
  try {
    # Acessando o primeiro slide
    $slide = $pres->getSlides()->get_Item(0);
    # Adicionando o gráfico de exemplo
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # Definindo o Título do Gráfico
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Definindo o formato das linhas de grade principais para o eixo de valores
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Definindo o formato das linhas de grade secundárias para o eixo de valores
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Definindo o formato numérico do eixo de valores
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # Definindo os valores máximo e mínimo do gráfico
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # Definindo as Propriedades de Texto do Eixo de Valores
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # Definindo o título do eixo de valores
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Definindo o formato das linhas de grade principais para o eixo de Categoria
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Definindo o formato das linhas de grade secundárias para o eixo de Categoria
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Definindo as Propriedades de Texto do Eixo de Categoria
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # Definindo o Título da Categoria
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Definindo a posição dos rótulos do eixo de categoria
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Definindo o ângulo de rotação dos rótulos do eixo de categoria
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Definindo as Propriedades de Texto das Legendas
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # Definir exibição das legendas do gráfico sem sobrepor o gráfico
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # Definindo eixo de valor secundário
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # Definindo o formato numérico do eixo de valor secundário
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # Definindo os valores máximo e mínimo do gráfico
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # Definindo a cor da parede traseira do gráfico
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Definindo a cor da área de plotagem
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # Salvar Apresentação
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir Propriedades de Fonte para um Gráfico**
Aspose.Slides for PHP via Java oferece suporte para definir as propriedades relacionadas à fonte para o gráfico. Siga os passos abaixo para definir as propriedades de fonte do gráfico.

- Instancie o objeto da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
- Adicione um gráfico ao slide.
- Defina a altura da fonte.
- Salve a apresentação modificada.

Um exemplo de amostra é fornecido abaixo.

```php
  # Crie uma instância da classe Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $pres->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir o Formato Numérico**
Aspose.Slides for PHP via Java fornece uma API simples para gerenciar o formato de dados do gráfico:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione um gráfico com dados padrão juntamente com qualquer tipo desejado (este exemplo usa **ChartType::ClusteredColumn**).
1. Defina o formato numérico predefinido a partir dos valores predefinidos possíveis.
1. Percorra cada célula de dados do gráfico em todas as séries e defina o formato numérico dos dados do gráfico.
1. Salve a apresentação.
1. Defina o formato numérico personalizado.
1. Percorra cada célula de dados do gráfico dentro de todas as séries e defina um formato numérico diferente para os dados.
1. Salve a apresentação.

```php
  # Crie uma instância da classe Presentation
  $pres = new Presentation();
  try {
    # Acesse o primeiro slide da apresentação
    $slide = $pres->getSlides()->get_Item(0);
    # Adicionando um gráfico de colunas agrupadas padrão
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # Acessando a coleção de séries do gráfico
    $series = $chart->getChartData()->getSeries();
    # Percorrendo cada série do gráfico
    foreach($series as $ser) {
      # Percorrendo cada célula de dados na série
      foreach($ser->getDataPoints() as $cell) {
        # Definindo o formato numérico
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%
      }
    }
    # Salvando a apresentação
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Os valores de formato numérico predefinidos possíveis, juntamente com seus índices predefinidos, que podem ser usados, são apresentados abaixo:

|**0**|Geral|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Definir Bordas Arredondadas da Área do Gráfico**
Aspose.Slides for PHP via Java oferece suporte para definir a área do gráfico. Métodos [**hasRoundedCorners**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/hasroundedcorners/) e [**setRoundedCorners**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/setroundedcorners/) foram adicionados à classe [Chart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Chart).

1. Instancie o objeto da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Adicione um gráfico ao slide.
1. Defina o tipo de preenchimento e a cor de preenchimento do gráfico
1. Defina a propriedade de canto arredondado como True.
1. Salve a apresentação modificada.

Um exemplo de amostra é fornecido abaixo.  

```php
  # Crie uma instância da classe Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->setStyle(LineStyle->Single);
    $chart->setRoundedCorners(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso definir preenchimentos semitransparentes para colunas/áreas mantendo a borda opaca?**

Sim. A transparência do preenchimento e o contorno são configurados separadamente. Isso é útil para melhorar a legibilidade da grade e dos dados em visualizações densas.

**Como lidar com rótulos de dados quando eles se sobrepõem?**

Reduza o tamanho da fonte, desative componentes de rótulo não essenciais (por exemplo, categorias), ajuste o deslocamento/posição do rótulo, exiba rótulos somente para pontos selecionados se necessário ou altere o formato para "valor + legenda".

**Posso aplicar preenchimentos de gradiente ou padrão às séries?**

Sim. Tanto preenchimentos sólidos quanto gradientes/padrões geralmente estão disponíveis. Na prática, use gradientes com moderação e evite combinações que reduzam o contraste com a grade e o texto.