---
title: Personalizar gráficos de rosca em apresentações usando Python via Java
linktitle: Gráfico de rosca
type: docs
weight: 30
url: /pt/python-java/doughnut-chart/
keywords:
- gráfico de rosca
- espaço central
- tamanho do buraco
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Descubra como criar e personalizar gráficos de rosca no Aspose.Slides para Python via Java, com suporte a formatos PowerPoint para apresentações dinâmicas."
---
## **Visão geral**

Este artigo mostra como trabalhar com um gráfico de rosca no Aspose.Slides adicionando o gráfico a um slide, definindo o tamanho do seu buraco central e salvando a apresentação. Ele se concentra no método [setDoughnutHoleSize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) e demonstra as etapas básicas necessárias para personalizar esse tipo de gráfico no código.

Ele também inclui uma breve FAQ que cobre cenários relacionados a gráficos de rosca, como usar várias séries para criar vários anéis, trabalhar com gráficos de rosca “explodidos” e exportar um gráfico como imagem raster ou SVG.

## **Especificar o espaço central em um gráfico de rosca**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java oferece suporte à especificação do tamanho do buraco em um gráfico de rosca. Esta seção demonstra como definir o tamanho do buraco com um exemplo.
{{% /alert %}}

Para especificar o tamanho do buraco em um gráfico de rosca, siga estas etapas:

1. Instancie um objeto [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Adicione um gráfico de rosca ao slide.
3. Especifique o tamanho do buraco no gráfico de rosca.
4. Grave a apresentação no disco.

O exemplo a seguir define o tamanho do buraco em um gráfico de rosca.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Crie uma instância da classe Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # Grave a apresentação no disco.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**Posso criar uma rosca multinível com vários anéis?**

Sim. Adicione várias séries a um único gráfico de rosca — cada série se torna um anel separado. A ordem dos anéis é determinada pela ordem das séries na coleção.

**Um gráfico de rosca “explodido” (fatias separadas) é suportado?**

Sim. Existe um tipo de gráfico Exploded Doughnut [tipo de gráfico](https://reference.aspose.com/slides/pt/python-java/aspose.slides/charttype/) e uma propriedade de explosão nos pontos de dados; você pode separar fatias individuais.

**Como posso obter uma imagem de um gráfico de rosca (PNG/SVG) para um relatório?**

Um gráfico é uma [forma](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/); você pode renderizá-lo como uma [imagem raster](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getImage) ou exportar o gráfico para uma imagem SVG.