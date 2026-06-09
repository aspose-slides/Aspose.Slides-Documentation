---
title: Personalizar Tabelas de Dados de Gráficos em Apresentações Usando Java
linktitle: Tabela de Dados
type: docs
url: /pt/java/chart-data-table/
keywords:
- dados de gráfico
- tabela de dados
- propriedades de fonte
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Personalize tabelas de dados de gráficos em Java para PPT e PPTX com Aspose.Slides para aumentar a eficiência e o apelo nas apresentações."
---
## **Visão geral**

Este artigo explica como trabalhar com tabelas de dados de gráficos no Aspose.Slides. Ele mostra como exibir uma tabela de dados para um gráfico e personalizar a formatação de texto definindo propriedades de fonte, como estilo negrito e altura da fonte. O exemplo demonstra o carregamento de uma apresentação, a adição de um gráfico, a habilitação da tabela de dados do gráfico, a aplicação das configurações de fonte e a gravação da apresentação atualizada.

Ele também inclui respostas breves às perguntas comuns sobre exibir chaves de legenda em uma tabela de dados de gráfico, preservar a tabela de dados durante a exportação, trabalhar com gráficos carregados de apresentações ou modelos existentes e identificar gráficos onde a tabela de dados está habilitada.

## **Definir propriedades de fonte para uma tabela de dados de gráfico**
O Aspose.Slides for Java oferece suporte para alterar a cor das categorias em uma cor de série.

1. Instancie o objeto da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
2. Adicione um gráfico no slide.
3. Defina a tabela do gráfico.
4. Defina a altura da fonte.
5. Salve a apresentação modificada.

A seguir, um exemplo de amostra é fornecido.  

```java
// Criando apresentação vazia
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas frequentes**

**Posso exibir pequenas chaves de legenda ao lado dos valores na tabela de dados do gráfico?**

Sim. A tabela de dados suporta [legend keys](https://reference.aspose.com/slides/pt/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-), e você pode ativá‑las ou desativá‑las.

**A tabela de dados será preservada ao exportar a apresentação para PDF, HTML ou imagens?**

Sim. O Aspose.Slides renderiza o gráfico como parte do slide, portanto o exportado [PDF](/slides/pt/java/convert-powerpoint-to-pdf/)/[HTML](/slides/pt/java/convert-powerpoint-to-html/)/[image](/slides/pt/java/convert-powerpoint-to-png/) inclui o gráfico com sua tabela de dados.

**As tabelas de dados são suportadas para gráficos que vêm de um arquivo de modelo?**

Sim. Para qualquer gráfico carregado de uma apresentação ou modelo existente, você pode verificar e alterar se uma tabela de dados [is shown](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chart/#hasDataTable--) usando as propriedades do gráfico.

**Como posso encontrar rapidamente quais gráficos em um arquivo têm a tabela de dados habilitada?**

Inspecione a propriedade de cada gráfico que indica se a tabela de dados [is shown](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chart/#hasDataTable--) e percorra os slides para identificar os gráficos onde ela está habilitada.