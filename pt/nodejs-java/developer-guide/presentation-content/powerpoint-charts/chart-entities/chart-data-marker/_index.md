---
title: Gerenciar Marcadores de Dados de Gráficos em Apresentações Usando JavaScript
linktitle: Marcador de Dados
type: docs
url: /pt/nodejs-java/chart-data-marker/
keywords:
- gráfico
- ponto de dados
- marcador
- opções de marcador
- tamanho do marcador
- tipo de preenchimento
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a personalizar marcadores de dados de gráficos no Aspose.Slides para Node.js, aumentando o impacto da apresentação nos formatos PPT e PPTX com exemplos de código claros."
---
## **Visão Geral**

Este artigo explica como trabalhar com marcadores de dados de gráficos no Aspose.Slides. Ele mostra como criar um gráfico, acessar uma série e seus pontos de dados, aplicar preenchimento de imagem aos marcadores no nível do ponto de dados, ajustar o tamanho do marcador e salvar a apresentação atualizada. Também observa que formas padrão de marcadores estão disponíveis através da enumeração `MarkerStyleType` e que a aparência do marcador é preservada ao exportar gráficos para formatos raster ou SVG.

## **Definir Opções de Marcador de Gráfico**

Os marcadores podem ser definidos nos pontos de dados do gráfico dentro de séries específicas. Para definir as opções de marcador do gráfico, siga as etapas abaixo:

- Instanciar a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
- Criar o gráfico padrão.
- Definir a imagem.
- Obter a primeira série do gráfico.
- Adicionar um novo ponto de dados.
- Gravar a apresentação no disco.

No exemplo abaixo, definimos as opções de marcador de gráfico no nível dos pontos de dados.

```javascript
// Criando apresentação vazia
var pres = new aspose.slides.Presentation();
try {
    // Acessar primeiro slide
    var slide = pres.getSlides().get_Item(0);
    // Criando o gráfico padrão
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // Obtendo o índice da planilha de dados padrão do gráfico
    var defaultWorksheetIndex = 0;
    // Obtendo a planilha de dados do gráfico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Excluir série de demonstração
    chart.getChartData().getSeries().clear();
    // Adicionar nova série
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // Carregar a imagem 1
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // Carregar a imagem 2
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // Obter a primeira série do gráfico
    var series = chart.getChartData().getSeries().get_Item(0);
    // Adicionar novo ponto (1:3) ali.
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // Alterando o marcador da série do gráfico
    series.getMarker().setSize(15);
    // Salvar apresentação com o gráfico
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Quais formas de marcadores estão disponíveis por padrão?**

Formas padrão estão disponíveis (círculo, quadrado, diamante, triângulo, etc.); a lista é definida pela enumeração [MarkerStyleType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markerstyletype/). Se precisar de uma forma não padrão, use um marcador com preenchimento de imagem para emular visuais personalizados.

**Os marcadores são preservados ao exportar um gráfico para uma imagem ou SVG?**

Sim. Ao renderizar gráficos para [formatos raster](/slides/pt/nodejs-java/convert-powerpoint-to-png/) ou salvar [formas como SVG](/slides/pt/nodejs-java/render-a-slide-as-an-svg-image/), os marcadores mantêm sua aparência e configurações, incluindo tamanho, preenchimento e contorno.