---
title: Personalize tabelas de dados de gráficos em apresentações usando Python
linktitle: Tabela de Dados
type: docs
url: /pt/python-java/chart-data-table/
keywords:
- dados do gráfico
- tabela de dados
- propriedades de fonte
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Personalize tabelas de dados de gráficos em Python para PPT e PPTX com Aspose.Slides for Python via Java para aumentar a eficiência e o apelo nas apresentações."
---
## **Visão geral**

Este artigo explica como trabalhar com tabelas de dados de gráficos no Aspose.Slides. Ele mostra como exibir uma tabela de dados para um gráfico e personalizar a formatação de texto definindo propriedades de fonte, como estilo em negrito e altura da fonte. O exemplo demonstra a criação de uma apresentação, a adição de um gráfico, a habilitação da tabela de dados do gráfico, a aplicação das configurações de fonte e a gravação da apresentação atualizada.

Ele também inclui respostas breves a perguntas comuns sobre exibir chaves de legenda em uma tabela de dados de gráfico, preservar a tabela de dados durante a exportação, trabalhar com gráficos carregados de apresentações ou modelos existentes e identificar gráficos nos quais a tabela de dados está habilitada.

## **Definir propriedades de fonte para uma tabela de dados de gráfico**

O Aspose.Slides for Python via Java permite exibir a tabela de dados de um gráfico e alterar as propriedades de fonte do seu texto.

1. Instanciar a classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Adicionar um gráfico ao slide.
1. Exibir a tabela de dados do gráfico.
1. Definir o estilo em negrito e a altura da fonte do texto da tabela de dados.
1. Salvar a apresentação modificada.

O exemplo a seguir demonstra estas etapas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Crie uma apresentação vazia.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso mostrar pequenas chaves de legenda ao lado dos valores na tabela de dados do gráfico?**

Sim. A tabela de dados suporta [chaves de legenda](https://reference.aspose.com/slides/pt/python-java/aspose.slides/datatable/#setShowLegendKey), e você pode ativá‑las ou desativá‑las.

**A tabela de dados será preservada ao exportar a apresentação para PDF, HTML ou imagens?**

Sim. O Aspose.Slides renderiza o gráfico como parte do slide, portanto o [PDF](/slides/pt/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/pt/python-java/convert-powerpoint-to-html/)/[imagem](/slides/pt/python-java/convert-powerpoint-to-png/) exportado inclui o gráfico com sua tabela de dados.

**As tabelas de dados são suportadas para gráficos que vêm de um arquivo de modelo?**

Sim. Para qualquer gráfico carregado de uma apresentação ou modelo existente, você pode verificar e alterar se uma tabela de dados [é exibida](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#hasDataTable) usando as propriedades do gráfico.

**Como posso encontrar rapidamente quais gráficos em um arquivo têm a tabela de dados habilitada?**

Inspecione a propriedade de cada gráfico que indica se a tabela de dados [é exibida](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#hasDataTable) e percorra os slides para identificar os gráficos em que ela está habilitada.