---
title: Personalizar tabelas de dados de gráficos em apresentações usando JavaScript
linktitle: Tabela de Dados
type: docs
url: /pt/nodejs-java/chart-data-table/
keywords:
- dados de gráfico
- tabela de dados
- propriedades de fonte
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Personalize tabelas de dados de gráficos em JavaScript para PPT e PPTX com Aspose.Slides para Node.js via Java para aumentar a eficiência e a atratividade nas apresentações."
---
## **Visão geral**

Este artigo explica como trabalhar com tabelas de dados de gráfico no Aspose.Slides. Ele mostra como exibir uma tabela de dados para um gráfico e personalizar sua formatação de texto definindo propriedades de fonte, como estilo negrito e altura da fonte. O exemplo demonstra como carregar uma apresentação, adicionar um gráfico, ativar a tabela de dados do gráfico, aplicar as configurações de fonte e salvar a apresentação atualizada.

Ele também inclui respostas breves às perguntas comuns sobre exibir chaves de legenda em uma tabela de dados de gráfico, preservar a tabela de dados durante a exportação, trabalhar com gráficos carregados de apresentações ou modelos existentes e identificar os gráficos onde a tabela de dados está ativada.

## **Definir propriedades de fonte para a tabela de dados do gráfico**

Aspose.Slides para Node.js via Java oferece suporte para alterar a cor das categorias em uma cor de série.  

1. Instanciar o objeto da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Adicionar um gráfico ao slide.
1. Definir a tabela do gráfico.
1. Definir a altura da fonte.
1. Salvar a apresentação modificada.

A seguir, um exemplo de amostra é fornecido.  

```javascript
// Criando apresentação vazia
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas frequentes**

**Posso exibir pequenas chaves de legenda ao lado dos valores na tabela de dados do gráfico?**

Sim. A tabela de dados suporta [legend keys](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/datatable/setshowlegendkey/), e você pode ativá‑las ou desativá‑las.

**A tabela de dados será preservada ao exportar a apresentação para PDF, HTML ou imagens?**

Sim. Aspose.Slides renderiza o gráfico como parte do slide, de modo que o exportado [PDF](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/pt/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/pt/nodejs-java/convert-powerpoint-to-png/) inclui o gráfico com sua tabela de dados.

**As tabelas de dados são compatíveis com gráficos que vêm de um arquivo de modelo?**

Sim. Para qualquer gráfico carregado de uma apresentação ou modelo existente, você pode verificar e alterar se uma tabela de dados [is shown](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/hasdatatable/) usando as propriedades do gráfico.

**Como posso encontrar rapidamente quais gráficos em um arquivo têm a tabela de dados ativada?**

Inspecione a propriedade de cada gráfico que indica se a tabela de dados [is shown](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/hasdatatable/) e percorra os slides para identificar os gráficos onde está ativada.