---
title: Exportar Gráficos de Apresentação em .NET
linktitle: Exportar Gráfico
type: docs
weight: 90
url: /pt/net/export-chart/
keywords:
- gráfico
- gráfico para imagem
- gráfico como imagem
- extrair imagem de gráfico
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda como exportar gráficos de apresentação com Aspose.Slides para .NET, suportando formatos PPT e PPTX, e simplifique a geração de relatórios em qualquer fluxo de trabalho."
---
## **Visão geral**

O Aspose.Slides permite exportar um gráfico de uma apresentação como uma imagem. Este artigo mostra como obter uma imagem de um gráfico e salvá‑la, o que é útil quando você precisa reutilizar visualizações de gráficos fora de uma apresentação do PowerPoint.

Além do fluxo de trabalho básico de exportação de imagens, o artigo também aborda perguntas comuns relacionadas à exportação, incluindo salvar o conteúdo do gráfico em SVG, controlar o tamanho de saída por meio de opções de renderização, carregar fontes para preservar a aparência de rótulos e legendas e manter a formatação original da apresentação, como temas, estilos, preenchimentos e efeitos, durante a renderização.

## **Obter uma imagem de gráfico**
O Aspose.Slides para .NET fornece suporte para extrair a imagem de um gráfico específico. Abaixo é apresentado um exemplo de amostra.  

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```

## **Perguntas frequentes**

**Posso exportar um gráfico como vetor (SVG) em vez de uma imagem raster?**

Sim. Um gráfico é uma forma, e seu conteúdo pode ser salvo em SVG usando o [método de salvamento shape-to-SVG](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/writeassvg/).

**Como posso definir o tamanho exato do gráfico exportado em pixels?**

Use as sobrecargas de renderização de imagem que permitem especificar o tamanho ou a escala — a biblioteca suporta renderizar objetos com dimensões/escala fornecidas.

**O que devo fazer se as fontes em rótulos e na legenda aparecerem incorretas após a exportação?**

[Carregue as fontes necessárias](/slides/pt/net/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsloader/) para que a renderização do gráfico preserve métricas e a aparência do texto.

**A exportação respeita o tema, estilos e efeitos do PowerPoint?**

Sim. O renderizador do Aspose.Slides segue a formatação da apresentação (temas, estilos, preenchimentos, efeitos), de modo que a aparência do gráfico é preservada.

**Onde posso encontrar recursos de renderização/exportação disponíveis além de imagens de gráficos?**

Consulte a seção de exportação da [API](https://reference.aspose.com/slides/pt/net/aspose.slides.export/)/[documentação](/slides/pt/net/convert-powerpoint/) para destinos de saída ([PDF](/slides/pt/net/convert-powerpoint-to-pdf/), [SVG](/slides/pt/net/render-a-slide-as-an-svg-image/), [XPS](/slides/pt/net/convert-powerpoint-to-xps/), [HTML](/slides/pt/net/convert-powerpoint-to-html/), etc.) e opções de renderização relacionadas.