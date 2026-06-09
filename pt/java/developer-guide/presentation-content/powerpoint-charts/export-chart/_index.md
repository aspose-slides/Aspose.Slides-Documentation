---
title: Exportar Gráficos de Apresentação em Java
linktitle: Exportar Gráfico
type: docs
weight: 90
url: /pt/java/export-chart/
keywords:
- gráfico
- gráfico para imagem
- gráfico como imagem
- extrair imagem de gráfico
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda como exportar gráficos de apresentação com Aspose.Slides para Java, suportando formatos PPT e PPTX, e simplifique a geração de relatórios em qualquer fluxo de trabalho."
---
## **Visão geral**

Aspose.Slides permite exportar um gráfico de uma apresentação como uma imagem. Este artigo mostra como obter uma imagem de um gráfico e salvá‑la, o que é útil quando você precisa reutilizar os visuais do gráfico fora de uma apresentação do PowerPoint.

Além do fluxo básico de exportação de imagem, o artigo também aborda questões comuns relacionadas à exportação, incluindo salvar o conteúdo do gráfico em SVG, controlar o tamanho da saída por meio de opções de renderização, carregar fontes para preservar a aparência de rótulos e legendas, e manter a formatação original da apresentação, como temas, estilos, preenchimentos e efeitos durante a renderização.

## **Obter uma Imagem de Gráfico**
Aspose.Slides for Java fornece suporte para extrair a imagem de um gráfico específico. A seguir, um exemplo de amostra é apresentado.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas Frequentes**

**Posso exportar um gráfico como vetor (SVG) em vez de uma imagem raster?**

Sim. Um gráfico é uma forma, e seu conteúdo pode ser salvo em SVG usando o [método de salvamento shape-to-SVG](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Como posso definir o tamanho exato do gráfico exportado em pixels?**

Use as sobrecargas de renderização de imagem que permitem especificar tamanho ou escala — a biblioteca suporta renderizar objetos com dimensões/escala fornecidas.

**O que devo fazer se as fontes em rótulos e na legenda parecerem incorretas após a exportação?**

[Carregue as fontes necessárias](/slides/pt/java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsloader/) para que a renderização do gráfico preserve as métricas e a aparência do texto.

**A exportação respeita o tema, estilos e efeitos do PowerPoint?**

Sim. O renderizador do Aspose.Slides segue a formatação da apresentação (temas, estilos, preenchimentos, efeitos), portanto a aparência do gráfico é preservada.

**Onde posso encontrar recursos de renderização/exportação disponíveis além de imagens de gráficos?**

Consulte a [API](https://reference.aspose.com/slides/pt/java/com.aspose.slides/)/[documentação](/slides/pt/java/convert-powerpoint/) para destinos de saída ([PDF](/slides/pt/java/convert-powerpoint-to-pdf/), [SVG](/slides/pt/java/render-a-slide-as-an-svg-image/), [XPS](/slides/pt/java/convert-powerpoint-to-xps/), [HTML](/slides/pt/java/convert-powerpoint-to-html/), etc.) e as opções de renderização relacionadas.