---
title: Exportar gráficos de apresentação em C++
linktitle: Exportar gráfico
type: docs
weight: 90
url: /pt/cpp/export-chart/
keywords:
- gráfico
- gráfico para imagem
- gráfico como imagem
- extrair imagem do gráfico
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a exportar gráficos de apresentações com Aspose.Slides para C++, com suporte aos formatos PPT e PPTX, e simplifique a criação de relatórios em qualquer fluxo de trabalho."
---
## **Visão geral**

O Aspose.Slides permite exportar um gráfico de uma apresentação como imagem. Este artigo mostra como obter uma imagem de um gráfico e salvá‑la, o que é útil quando você precisa reutilizar os elementos visuais do gráfico fora de uma apresentação do PowerPoint.

## **Obter uma imagem de gráfico**
O Aspose.Slides for C++ oferece suporte para extrair a imagem de um gráfico específico. O exemplo abaixo é fornecido.  

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Posso exportar um gráfico como vetor (SVG) em vez de imagem raster?**

Sim. Um gráfico é uma forma, e seu conteúdo pode ser salvo em SVG usando o [shape-to-SVG saving method](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/writeassvg/).

**Como posso definir o tamanho exato do gráfico exportado em pixels?**

Use as sobrecargas de renderização de imagem que permitem especificar tamanho ou escala — a biblioteca suporta renderizar objetos com dimensões/escala fornecidas.

**O que devo fazer se as fontes em rótulos e na legenda aparecerem incorretas após a exportação?**

[Load the required fonts](/slides/pt/cpp/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsloader/) para que a renderização do gráfico preserve as métricas e a aparência do texto.

**A exportação respeita o tema, estilos e efeitos do PowerPoint?**

Sim. O renderizador do Aspose.Slides segue a formatação da apresentação (temas, estilos, preenchimentos, efeitos), de modo que a aparência do gráfico é preservada.

**Onde posso encontrar recursos de renderização/exportação disponíveis além de imagens de gráficos?**

Veja a seção de exportação da [API](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/)/[documentation](/slides/pt/cpp/convert-powerpoint/) para destinos de saída ([PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/pt/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/pt/cpp/convert-powerpoint-to-xps/), [HTML](/slides/pt/cpp/convert-powerpoint-to-html/), etc.) e opções de renderização relacionadas.