---
title: Exportar gráficos de apresentação no Android
linktitle: Exportar Gráfico
type: docs
weight: 90
url: /pt/androidjava/export-chart/
keywords:
- gráfico
- gráfico para imagem
- gráfico como imagem
- extrair imagem do gráfico
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda a exportar gráficos de apresentações com Aspose.Slides para Android via Java, com suporte aos formatos PPT e PPTX, e simplifique a geração de relatórios em qualquer fluxo de trabalho."
---
## **Visão geral**

Aspose.Slides permite exportar um gráfico de uma apresentação como imagem. Este artigo mostra como obter uma imagem de um gráfico e salvá-la, o que é útil quando você precisa reutilizar os visuais do gráfico fora de uma apresentação do PowerPoint.

Além do fluxo básico de exportação de imagem, o artigo também aborda perguntas comuns relacionadas à exportação, incluindo salvar o conteúdo do gráfico como SVG, controlar o tamanho da saída por meio de opções de renderização, carregar fontes para preservar a aparência de rótulos e legendas, e manter a formatação original da apresentação, como temas, estilos, preenchimentos e efeitos durante a renderização.

## **Obter uma imagem de gráfico**
Aspose.Slides for Android via Java oferece suporte à extração de imagem de um gráfico específico. Abaixo está um exemplo de amostra.

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

## **Perguntas frequentes**

**Posso exportar um gráfico como vetor (SVG) em vez de uma imagem raster?**

Sim. Um gráfico é uma forma, e seu conteúdo pode ser salvo como SVG usando o [método de salvamento shape-to-SVG](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Como posso definir o tamanho exato do gráfico exportado em pixels?**

Use as sobrecargas de renderização de imagem que permitem especificar tamanho ou escala — a biblioteca suporta renderizar objetos com dimensões/escala especificadas.

**O que devo fazer se as fontes em rótulos e na legenda ficarem erradas após a exportação?**

[Carregue as fontes necessárias](/slides/pt/androidjava/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsloader/) para que a renderização do gráfico preserve métricas e a aparência do texto.

**A exportação respeita o tema, estilos e efeitos do PowerPoint?**

Sim. O renderizador do Aspose.Slides segue a formatação da apresentação (temas, estilos, preenchimentos, efeitos), de modo que a aparência do gráfico é preservada.

**Onde posso encontrar recursos de renderização/exportação disponíveis além de imagens de gráficos?**

Consulte a [API](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/)/[documentação](/slides/pt/androidjava/convert-powerpoint/) para destinos de saída ([PDF](/slides/pt/androidjava/convert-powerpoint-to-pdf/), [SVG](/slides/pt/androidjava/render-a-slide-as-an-svg-image/), [XPS](/slides/pt/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/pt/androidjava/convert-powerpoint-to-html/), etc.) e opções de renderização relacionadas.