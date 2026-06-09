---
title: Exportar gráficos de apresentação com Python
linktitle: Exportar gráfico
type: docs
weight: 90
url: /pt/python-net/export-chart/
keywords:
- gráfico
- gráfico para imagem
- gráfico como imagem
- extrair imagem do gráfico
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda como exportar os gráficos de apresentações com Aspose.Slides for Python via .NET, suportando formatos PPT, PPTX e ODP, e simplifique a geração de relatórios em qualquer fluxo de trabalho."
---
## **Visão geral**

Aspose.Slides permite exportar um gráfico de uma apresentação como uma imagem. Este artigo mostra como obter uma imagem de um gráfico e salvá‑la, o que é útil quando você precisa reutilizar os visuais do gráfico fora de uma apresentação do PowerPoint.

## **Obter imagem do gráfico**
Aspose.Slides for Python via .NET oferece suporte para extrair a imagem de um gráfico específico. Abaixo está um exemplo de código.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **Perguntas frequentes**

**Posso exportar um gráfico como vetor (SVG) em vez de uma imagem raster?**

Sim. Um gráfico é uma forma, e seu conteúdo pode ser salvo em SVG usando o [método de salvamento shape-to‑SVG](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/write_as_svg/).

**Como posso definir o tamanho exato do gráfico exportado em pixels?**

Use as sobrecargas de renderização de imagem que permitem especificar tamanho ou escala — a biblioteca suporta renderizar objetos com dimensões/escala fornecidas.

**O que fazer se as fontes em rótulos e na legenda ficarem incorretas após a exportação?**

[Carregue as fontes necessárias](/slides/pt/python-net/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsloader/) para que a renderização do gráfico preserve as métricas e a aparência do texto.

**A exportação respeita o tema, estilos e efeitos do PowerPoint?**

Sim. O renderizador do Aspose.Slides segue a formatação da apresentação (temas, estilos, preenchimentos, efeitos), de modo que a aparência do gráfico é preservada.

**Onde posso encontrar as capacidades de renderização/exportação disponíveis além de imagens de gráficos?**

Consulte a seção de exportação da [API](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/)/[documentação](/slides/pt/python-net/convert-powerpoint/) para destinos de saída ([PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/pt/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/pt/python-net/convert-powerpoint-to-xps/), [HTML](/slides/pt/python-net/convert-powerpoint-to-html/), etc.) e opções de renderização relacionadas.