---
title: Personalizar tabelas de dados de gráfico em apresentações usando Java
linktitle: Tabela de dados
type: docs
url: /pt/java/chart-data-table/
keywords:
- dados do gráfico
- tabela de dados
- propriedades da fonte
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Personalize as fontes, bordas e chaves da legenda da tabela de dados de gráfico em apresentações PowerPoint usando Aspose.Slides para Java."
---
## **Visão geral**

Aspose.Slides for Java permite exibir a tabela de dados de um gráfico e personalizar sua formatação de texto, bordas e chaves da legenda. Este artigo explica como habilitar a tabela, formatar seu texto, controlar cada tipo de borda e mostrar ou ocultar as chaves da legenda. Os exemplos salvam os gráficos configurados em arquivos PPTX.

## **Definir propriedades da fonte**

Para exibir a tabela de dados de um gráfico, passe `true` para [setDataTable](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chart/#setDataTable-boolean-). Use [getChartDataTable](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chart/#getChartDataTable--) para acessar a tabela e configurar sua formatação de texto.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/).
1. Adicione um gráfico de colunas agrupadas ao primeiro slide.
1. Habilite a tabela de dados do gráfico.
1. Ative texto em negrito com [setFontBold](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) e passe `20` para [setFontHeight](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) para texto de 20 pontos.
1. Salve a apresentação modificada.

O exemplo a seguir requer `test.pptx` no diretório de trabalho com ao menos um slide. Ele adiciona um gráfico com dados padrão na posição (50, 50), com largura de 600 pontos e altura de 400 pontos. O `output.pptx` salvo contém o gráfico com a tabela de dados habilitada e as configurações de fonte especificadas aplicadas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Personalizar bordas da tabela de dados**

Habilite a tabela com [IChart.setDataTable](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichart/#setDataTable-boolean-) e acesse-a através de [IChart.getChartDataTable](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichart/#getChartDataTable--). Você pode controlar três tipos de bordas independentemente:

- [setBorderHorizontal](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) controla bordas horizontais das células.
- [setBorderVertical](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) controla bordas verticais das células.
- [setBorderOutline](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) controla a borda externa da tabela.

Passe `true` para cada método para exibir suas bordas ou `false` para ocultá-las. O exemplo a seguir cria um gráfico de colunas agrupadas com dados padrão, exibe as bordas horizontais e a borda externa, e oculta as bordas verticais. Não requer nenhum arquivo de entrada. A posição e tamanho do gráfico são especificados em pontos.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A comparação abaixo usa os mesmos dados do gráfico e a mesma configuração de chave da legenda em todos os quatro casos. Começando com todas as bordas habilitadas, cada variante restante desabilita apenas uma configuração de borda. A variante inferior esquerda corresponde às configurações de borda do exemplo.

![Tabelas de dados de gráfico com todas as bordas habilitadas, sem bordas horizontais, sem bordas verticais e sem borda externa](data-table-borders.png)

## **Mostrar ou ocultar chaves da legenda**

As chaves da legenda são pequenos marcadores coloridos ao lado dos nomes das séries na tabela de dados. Elas ajudam os leitores a associar cada linha da tabela a uma série do gráfico. Passe `true` para [setShowLegendKey](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) para mostrar esses marcadores ou `false` para ocultá-los.

A legenda separada do gráfico é controlada por [IChart.setLegend](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichart/#setLegend-boolean-). Essas configurações são independentes: ocultar a legenda separada não oculta as chaves dentro da tabela de dados, e ocultar as chaves da tabela não oculta a legenda separada.

O exemplo a seguir cria um gráfico com dados padrão, habilita sua tabela de dados e mostra as chaves da legenda dentro dela enquanto oculta a legenda separada. Todas as bordas da tabela são explicitamente habilitadas. Não é necessária nenhuma apresentação de entrada. Para ocultar apenas as chaves da tabela, passe `false` para [setShowLegendKey](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A comparação abaixo mostra a mesma tabela com as chaves da legenda habilitadas e desabilitadas. Todas as bordas permanecem habilitadas, e a legenda separada do gráfico está oculta em ambos os casos.

![Tabelas de dados de gráfico com chaves da legenda mostradas à esquerda e ocultas à direita](data-table-legend-keys.png)

## **FAQ**

**Posso exibir chaves da legenda na tabela de dados de um gráfico?**

Sim. Passe `true` para [setShowLegendKey](https://reference.aspose.com/slides/pt/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) para exibir as chaves da legenda ou `false` para ocultá-las.

**A tabela de dados será preservada ao exportar a apresentação para PDF, HTML ou imagens?**

Sim. Aspose.Slides renderiza o gráfico e sua tabela de dados exibida como parte do slide ao exportar para [PDF](/slides/pt/java/convert-powerpoint-to-pdf/), [HTML](/slides/pt/java/convert-powerpoint-to-html/) ou [imagens](/slides/pt/java/convert-powerpoint-to-png/).

**Posso trabalhar com tabelas de dados em gráficos carregados a partir de um modelo?**

Sim. Para um gráfico carregado de uma apresentação ou modelo existente, use [hasDataTable](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chart/#hasDataTable--) e [setDataTable](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chart/#setDataTable-boolean-) para verificar ou alterar se sua tabela de dados está exibida.

**Como posso encontrar gráficos que têm a tabela de dados habilitada?**

Itere pelas formas em cada slide, identifique os gráficos e chame o método [hasDataTable](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chart/#hasDataTable--). Um valor `true` indica que a tabela de dados está habilitada.