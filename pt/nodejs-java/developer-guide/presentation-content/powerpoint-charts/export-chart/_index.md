---
title: Exportar gráficos de apresentação em JavaScript
linktitle: Exportar Gráfico
type: docs
weight: 90
url: /pt/nodejs-java/export-chart/
keywords:
- gráfico
- gráfico para imagem
- gráfico como imagem
- extrair imagem do gráfico
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a exportar gráficos de apresentações com Aspose.Slides para Node.js via Java, suportando formatos PPT e PPTX, e simplifique a geração de relatórios em qualquer fluxo de trabalho."
---
## **Visão geral**

Aspose.Slides permite exportar um gráfico de uma apresentação como imagem. Este artigo mostra como obter uma imagem de um gráfico e salvá‑la, o que é útil quando você precisa reutilizar os visuais do gráfico fora de uma apresentação do PowerPoint.

## **Obter imagem do gráfico**
Aspose.Slides for Node.js via Java oferece suporte para extrair a imagem de um gráfico específico. A seguir, um exemplo de amostra é apresentado. 

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso exportar um gráfico como vetor (SVG) em vez de imagem raster?**

Sim. Um gráfico é uma forma, e seu conteúdo pode ser salvo em SVG usando o [método de salvamento shape‑to‑SVG](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/writeassvg/).

**Como definir o tamanho exato do gráfico exportado em pixels?**

Use as sobrecargas de renderização de imagem que permitem especificar tamanho ou escala — a biblioteca suporta renderizar objetos com dimensões/escala fornecidas.

**O que fazer se as fontes em rótulos e na legenda aparecerem incorretas após a exportação?**

[Carregue as fontes necessárias](/slides/pt/nodejs-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsloader/) para que a renderização do gráfico preserve métricas e a aparência do texto.

**A exportação respeita o tema, estilos e efeitos do PowerPoint?**

Sim. O renderizador do Aspose.Slides segue a formatação da apresentação (temas, estilos, preenchimentos, efeitos), preservando a aparência do gráfico.

**Onde encontrar as capacidades de renderização/exportação disponíveis além de imagens de gráficos?**

Consulte a [API](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/)/[documentação](/slides/pt/nodejs-java/convert-powerpoint/) para destinos de saída ([PDF](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/pt/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/pt/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/pt/nodejs-java/convert-powerpoint-to-html/), etc.) e opções de renderização relacionadas.