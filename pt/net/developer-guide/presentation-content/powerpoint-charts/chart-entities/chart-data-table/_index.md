---
title: Personalizar tabelas de dados de gráficos em apresentações no .NET
linktitle: Tabela de Dados
type: docs
url: /pt/net/chart-data-table/
keywords:
- dados de gráfico
- tabela de dados
- propriedades de fonte
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Personalize tabelas de dados de gráficos em .NET para PPT e PPTX com Aspose.Slides para aumentar a eficiência e o apelo nas apresentações."
---
## **Visão geral**

Este artigo explica como trabalhar com tabelas de dados de gráfico no Aspose.Slides. Ele mostra como exibir uma tabela de dados para um gráfico e personalizar sua formatação de texto definindo propriedades de fonte, como estilo em negrito e altura da fonte. O exemplo demonstra como carregar uma apresentação, adicionar um gráfico, habilitar a tabela de dados do gráfico, aplicar configurações de fonte e salvar a apresentação atualizada.

Também inclui respostas breves a perguntas comuns sobre exibir chaves de legenda em uma tabela de dados de gráfico, preservar a tabela de dados durante a exportação, trabalhar com gráficos carregados de apresentações ou modelos existentes e identificar gráficos onde a tabela de dados está habilitada.

## **Definir propriedades de fonte para uma tabela de dados de gráfico**
Aspose.Slides for .NET oferece suporte para alterar a cor das categorias em uma cor de série. 

1. Instanciar objeto da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Adicionar um gráfico no slide.
3. Definir a tabela do gráfico.
4. Definir a altura da fonte.
5. Salvar a apresentação modificada.

Abaixo está um exemplo de amostra. 

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Posso exibir pequenas chaves de legenda ao lado dos valores na tabela de dados do gráfico?**

Sim. A tabela de dados suporta [legend keys](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/datatable/showlegendkey/), e você pode habilitá‑las ou desabilitá‑las.

**A tabela de dados será preservada ao exportar a apresentação para PDF, HTML ou imagens?**

Sim. O Aspose.Slides renderiza o gráfico como parte do slide, portanto o [PDF](/slides/pt/net/convert-powerpoint-to-pdf/)/[HTML](/slides/pt/net/convert-powerpoint-to-html/)/[image](/slides/pt/net/convert-powerpoint-to-png/) exportado inclui o gráfico com sua tabela de dados.

**As tabelas de dados são suportadas para gráficos provenientes de um arquivo de modelo?**

Sim. Para qualquer gráfico carregado de uma apresentação ou modelo existente, você pode verificar e alterar se uma tabela de dados [is shown](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chart/hasdatatable/) usando as propriedades do gráfico.

**Como posso encontrar rapidamente quais gráficos em um arquivo têm a tabela de dados habilitada?**

Inspecione a propriedade de cada gráfico que indica se a tabela de dados [is shown](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chart/hasdatatable/) e percorra os slides para identificar os gráficos onde está habilitada.