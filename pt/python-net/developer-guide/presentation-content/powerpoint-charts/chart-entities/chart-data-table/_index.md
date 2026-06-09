---
title: Personalizar tabelas de dados de gráficos em Python
linktitle: Tabela de Dados
type: docs
url: /pt/python-net/chart-data-table/
keywords:
- dados de gráfico
- tabela de dados
- propriedades de fonte
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Personalize tabelas de dados de gráficos em Python para PPT, PPTX e ODP com Aspose.Slides para aumentar a eficiência e o apelo nas apresentações."
---
## **Visão geral**

Este artigo explica como trabalhar com tabelas de dados de gráficos no Aspose.Slides. Ele mostra como exibir uma tabela de dados para um gráfico e personalizar sua formatação de texto definindo propriedades de fonte como estilo negrito e altura da fonte. O exemplo demonstra como carregar uma apresentação, adicionar um gráfico, habilitar a tabela de dados do gráfico, aplicar configurações de fonte e salvar a apresentação atualizada.

Ele também inclui respostas breves a perguntas comuns sobre exibir chaves de legenda em uma tabela de dados de gráfico, preservar a tabela de dados durante a exportação, trabalhar com gráficos carregados de apresentações ou modelos existentes e identificar gráficos onde a tabela de dados está habilitada.

## **Definir propriedades de fonte para a tabela de dados do gráfico**
Aspose.Slides for Python via .NET oferece suporte para alterar a cor de categorias em uma cor de série. 

1. Instanciar [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) objeto da classe.
1. Adicionar gráfico ao slide.
1. Definir tabela do gráfico.
1. Definir altura da fonte.
1. Salvar a apresentação modificada.

Exemplo de amostra abaixo. 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso mostrar pequenas chaves de legenda ao lado dos valores na tabela de dados do gráfico?**

Sim. A tabela de dados suporta [legend keys](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datatable/show_legend_key/), e você pode ativá‑las ou desativá‑las.

**A tabela de dados será preservada ao exportar a apresentação para PDF, HTML ou imagens?**

Sim. Aspose.Slides renderiza o gráfico como parte do slide, de modo que o exportado [PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/pt/python-net/convert-powerpoint-to-html/)/[image](/slides/pt/python-net/convert-powerpoint-to-png/) inclui o gráfico com sua tabela de dados.

**As tabelas de dados são suportadas para gráficos que vêm de um arquivo de modelo?**

Sim. Para qualquer gráfico carregado de uma apresentação ou modelo existente, você pode verificar e alterar se uma tabela de dados [is shown](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/has_data_table/) usando as propriedades do gráfico.

**Como posso encontrar rapidamente quais gráficos em um arquivo têm a tabela de dados habilitada?**

Inspecione a propriedade de cada gráfico que indica se a tabela de dados [is shown](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/has_data_table/) e percorra os slides para identificar os gráficos onde está habilitada.