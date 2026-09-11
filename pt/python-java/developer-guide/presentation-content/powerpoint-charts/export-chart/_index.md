---
title: Exportar gráficos de apresentação em Python via Java
linktitle: Exportar gráfico
type: docs
weight: 90
url: /pt/python-java/export-chart/
keywords:
- gráfico
- gráfico para imagem
- gráfico como imagem
- extrair imagem do gráfico
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda como exportar gráficos de apresentação com Aspose.Slides para Python via Java, oferecendo suporte aos formatos PPT e PPTX, e simplifique a geração de relatórios em qualquer fluxo de trabalho."
---
## **Visão geral**

O Aspose.Slides permite exportar um gráfico de uma apresentação como uma imagem. Este artigo mostra como obter uma imagem de um gráfico e salvá‑la, o que é útil quando você precisa reutilizar os elementos visuais do gráfico fora de uma apresentação do PowerPoint.

Além do fluxo básico de exportação de imagens, o artigo também aborda perguntas comuns relacionadas à exportação, incluindo salvar o conteúdo do gráfico em SVG, controlar o tamanho da saída por meio de opções de renderização, carregar fontes para preservar a aparência de rótulos e legendas e manter a formatação original da apresentação, como temas, estilos, preenchimentos e efeitos durante a renderização.

## **Obter uma imagem de gráfico**
O Aspose.Slides for Python via Java oferece suporte à extração de uma imagem de um gráfico específico. O exemplo a seguir demonstra como fazer isso.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Posso exportar um gráfico como vetor (SVG) em vez de uma imagem raster?**

Sim. Um gráfico é uma forma, e seu conteúdo pode ser salvo em SVG usando o [método de salvamento shape-to-SVG](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#writeAsSvgToBytes).

**Como posso definir o tamanho exato do gráfico exportado em pixels?**

Use as sobrecargas de renderização de imagem que permitem especificar tamanho ou escala — a biblioteca oferece suporte à renderização de objetos com dimensões ou escala definidas.

**O que devo fazer se as fontes em rótulos e legendas ficarem erradas após a exportação?**

[Carregue as fontes necessárias](/slides/pt/python-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsloader/) para que a renderização do gráfico preserve as métricas e a aparência do texto.

**A exportação respeita o tema, estilos e efeitos do PowerPoint?**

Sim. O renderizador do Aspose.Slides segue a formatação da apresentação (temas, estilos, preenchimentos, efeitos), garantindo que a aparência do gráfico seja preservada.

**Onde posso encontrar recursos de renderização/exportação disponíveis além de imagens de gráficos?**

Consulte a [API](https://reference.aspose.com/slides/pt/python-java/aspose.slides/)/[documentação](/slides/pt/python-java/convert-powerpoint/) para destinos de saída ([PDF](/slides/pt/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/pt/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/pt/python-java/convert-powerpoint-to-xps/), [HTML](/slides/pt/python-java/convert-powerpoint-to-html/), etc.) e opções de renderização relacionadas.