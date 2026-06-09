---
title: Personalizar gráficos de rosca em apresentações com Python
linktitle: Gráfico de Rosca
type: docs
weight: 30
url: /pt/python-net/doughnut-chart/
keywords:
- gráfico de rosca
- buraco central
- tamanho do buraco
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Descubra como criar e personalizar gráficos de rosca no Aspose.Slides para Python via .NET, com suporte aos formatos PowerPoint e OpenDocument para apresentações dinâmicas."
---
## **Visão geral**

Este artigo mostra como trabalhar com um gráfico de rosca no Aspose.Slides adicionando o gráfico a um slide, definindo o tamanho do furo central e salvando a apresentação. Ele se concentra na configuração `doughnut_hole_size` e demonstra as etapas básicas necessárias para personalizar esse tipo de gráfico por código.

Também inclui um FAQ curto cobrindo cenários relacionados a gráficos de rosca, como usar várias séries para criar múltiplos anéis, trabalhar com gráficos de rosca explodidos e exportar um gráfico como imagem raster ou SVG.

## **Especificar o intervalo central no gráfico de rosca**
Para especificar o tamanho do furo em um gráfico de rosca. Siga as etapas abaixo:

- Instanciar a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
- Adicionar gráfico de rosca ao slide.
- Especificar o tamanho do furo no gráfico de rosca.
- Gravar a apresentação no disco.

No exemplo abaixo, definimos o tamanho do furo em um gráfico de rosca.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Crie uma instância da classe Presentation
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Gravar a apresentação no disco
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso criar uma rosca de vários níveis com múltiplos anéis?**

Sim. Adicione várias séries a um único gráfico de rosca—cada série se torna um anel separado. A ordem dos anéis é determinada pela ordem das séries na coleção.

**Um gráfico de rosca “explodido” (fatias separadas) é suportado?**

Sim. Existe um tipo de gráfico Exploded Doughnut [chart type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/charttype/) e uma propriedade de explosão nos pontos de dados; você pode separar fatias individuais.

**Como obter uma imagem de um gráfico de rosca (PNG/SVG) para um relatório?**

Um gráfico é uma forma; você pode renderizá‑lo para uma [raster image](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/get_image/) ou exportar o gráfico para uma [SVG image](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/write_as_svg/).