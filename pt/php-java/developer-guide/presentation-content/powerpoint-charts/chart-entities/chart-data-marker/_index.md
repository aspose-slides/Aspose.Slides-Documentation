---
title: "Gerenciar Marcadores de Dados de Gráfico em Apresentações Usando PHP"
linktitle: "Marcador de Dados"
type: docs
url: /pt/php-java/chart-data-marker/
keywords:
- gráfico
- ponto de dados
- marcador
- opções de marcador
- tamanho do marcador
- tipo de preenchimento
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda como personalizar marcadores de dados de gráfico no Aspose.Slides para PHP, aumentando o impacto das apresentações nos formatos PPT e PPTX com exemplos de código claros."
---
## **Visão geral**

Este artigo explica como trabalhar com marcadores de dados de gráfico no Aspose.Slides. Ele mostra como criar um gráfico, acessar uma série e seus pontos de dados, aplicar preenchimento de imagem aos marcadores no nível do ponto de dados, ajustar o tamanho do marcador e salvar a apresentação atualizada. Também observa que formas padrão de marcadores estão disponíveis através da enumeração `MarkerStyleType` e que a aparência do marcador é preservada ao exportar gráficos para formatos raster ou SVG.

## **Definir opções de marcador de gráfico**
Os marcadores podem ser definidos nos pontos de dados do gráfico dentro de séries específicas. Para definir opções de marcador de gráfico, siga as etapas abaixo:

- Instanciar a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
- Criar o gráfico padrão.
- Definir a imagem.
- Obter a primeira série do gráfico.
- Adicionar um novo ponto de dados.
- Gravar a apresentação no disco.

No exemplo abaixo, definimos as opções de marcador de gráfico no nível dos pontos de dados.

```php
  # Criando apresentação vazia
  $pres = new Presentation();
  try {
    # Acessar o primeiro slide
    $slide = $pres->getSlides()->get_Item(0);
    # Criando o gráfico padrão
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Obtendo o índice da planilha de dados do gráfico padrão
    $defaultWorksheetIndex = 0;
    # Obtendo a planilha de dados do gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Excluir série de demonstração
    $chart->getChartData()->getSeries()->clear();
    # Adicionar nova série
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # Carregar a imagem 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # Carregar a imagem 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # Obter a primeira série do gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Adicionar novo ponto (1:3) lá.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # Alterando o marcador da série do gráfico
    $series->getMarker()->setSize(15);
    # Salvar a apresentação com o gráfico
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas frequentes**

**Quais formas de marcador estão disponíveis por padrão?**

Formas padrão estão disponíveis (círculo, quadrado, diamante, triângulo, etc.); a lista é definida pela classe [MarkerStyleType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/markerstyletype/). Se precisar de uma forma não padrão, use um marcador com preenchimento de imagem para emular visuais personalizados.

**Os marcadores são preservados ao exportar um gráfico para uma imagem ou SVG?**

Sim. Ao renderizar gráficos para [formatos raster](/slides/pt/php-java/convert-powerpoint-to-png/) ou salvar [formas como SVG](/slides/pt/php-java/render-a-slide-as-an-svg-image/), os marcadores mantêm sua aparência e configurações, incluindo tamanho, preenchimento e contorno.