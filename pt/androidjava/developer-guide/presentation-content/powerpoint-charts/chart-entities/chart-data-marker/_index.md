---
title: Gerenciar Marcadores de Dados de Gráficos em Apresentações no Android
linktitle: Marcador de Dados
type: docs
url: /pt/androidjava/chart-data-marker/
keywords:
- gráfico
- ponto de dado
- marcador
- opções de marcador
- tamanho do marcador
- tipo de preenchimento
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Personalize os marcadores de dados de gráficos no Aspose.Slides para Android, aumentando o impacto das apresentações nos formatos PPT e PPTX com exemplos claros de código Java."
---
## **Visão geral**

Este artigo explica como trabalhar com marcadores de dados de gráfico no Aspose.Slides. Ele mostra como criar um gráfico, acessar uma série e seus pontos de dados, aplicar preenchimento de imagem aos marcadores no nível do ponto de dados, ajustar o tamanho do marcador e salvar a apresentação atualizada. Também observa que as formas padrão de marcadores estão disponíveis através da enumeração `MarkerStyleType` e que a aparência do marcador é preservada ao exportar gráficos para formatos raster ou SVG.

## **Definir opções de marcador de gráfico**
Os marcadores podem ser definidos nos pontos de dados do gráfico dentro de séries específicas. Para definir as opções de marcador de gráfico, siga as etapas abaixo:

- Instanciar a classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
- Criar o gráfico padrão.
- Definir a imagem.
- Obter a primeira série do gráfico.
- Adicionar um novo ponto de dados.
- Salvar a apresentação no disco.

No exemplo abaixo, definimos as opções de marcador de gráfico no nível dos pontos de dados.

```java
// Criando apresentação vazia
Presentation pres = new Presentation();
try {
    // Acessar o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Criando o gráfico padrão
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Obtendo o índice da planilha de dados do gráfico padrão
    int defaultWorksheetIndex = 0;
    
    // Obtendo a planilha de dados do gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Excluir série de demonstração
    chart.getChartData().getSeries().clear();
    
    // Adicionar nova série
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Carregar a imagem 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Carregar a imagem 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Obter a primeira série do gráfico
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Adicionar novo ponto (1:3) lá.
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // Alterando o marcador da série de gráfico
    series.getMarker().setSize(15);
    
    // Salvar apresentação com o gráfico
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas Frequentes**

**Quais formas de marcadores estão disponíveis por padrão?**

Formas padrão estão disponíveis (círculo, quadrado, losango, triângulo, etc.); a lista é definida pela classe [MarkerStyleType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/markerstyletype/). Se precisar de uma forma não padrão, use um marcador com preenchimento de imagem para emular visuais personalizados.

**Os marcadores são preservados ao exportar um gráfico para uma imagem ou SVG?**

Sim. Ao renderizar gráficos para [formatos raster](/slides/pt/androidjava/convert-powerpoint-to-png/) ou ao salvar [formas como SVG](/slides/pt/androidjava/render-a-slide-as-an-svg-image/), os marcadores mantêm sua aparência e configurações, incluindo tamanho, preenchimento e contorno.