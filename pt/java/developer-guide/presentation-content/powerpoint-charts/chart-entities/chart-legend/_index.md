---
title: Personalizar Legendas de Gráficos em Apresentações Usando Java
linktitle: Legenda do Gráfico
type: docs
url: /pt/java/chart-legend/
keywords:
- legenda de gráfico
- posição da legenda
- tamanho da fonte
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Personalize legendas de gráficos com Aspose.Slides para Java para otimizar apresentações do PowerPoint com formatação de legenda personalizada."
---
## **Visão geral**

Aspose.Slides for Java oferece opções para personalizar legendas de gráficos em apresentações do PowerPoint. Este artigo mostra como posicionar e dimensionar uma legenda, definir o tamanho da fonte para toda a legenda, formatar uma entrada de legenda individual e ocultar ou restaurar entradas selecionadas.

A FAQ cobre comportamentos relacionados, incluindo reservar espaço para a legenda, exibir rótulos em várias linhas e herdar a formatação do tema da apresentação.

## **Posicionamento da Legenda**

Use os métodos [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-), e [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) da legenda para especificar sua posição e tamanho como frações das dimensões do gráfico.

Este exemplo cria uma apresentação e adiciona um gráfico de colunas agrupadas com dados padrão ao primeiro slide. Dividir os deslocamentos e dimensões desejados da legenda pela largura e altura do gráfico os converte em valores relativos: a legenda é deslocada 50 pontos do canto superior esquerdo do gráfico e tem tamanho de 100 por 100 pontos.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Expresse a posição e o tamanho da legenda em relação ao gráfico.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir o Tamanho da Fonte de uma Legenda**

Use o [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) da legenda para acessar a formatação de texto e use [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) para definir o tamanho da fonte em pontos.

Este exemplo cria um gráfico com dados padrão e define o texto da legenda para 20 pontos. Ele também desabilita os limites automáticos para o eixo vertical e define seu intervalo de -5 a 10.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir o Tamanho da Fonte de uma Entrada Individual da Legenda**

Use a coleção retornada pelo método [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) da legenda para acessar a formatação de uma entrada específica. Os índices das entradas são baseados em zero, portanto o índice `1` refere‑se à segunda entrada.

Este exemplo cria um gráfico de colunas agrupadas cujos dados padrão incluem pelo menos duas séries. Ele formata a segunda entrada da legenda com texto em negrito, itálico e azul de 20 pontos.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ocultar Entradas Individuais da Legenda**

Para excluir uma série auxiliar da legenda mantendo seus dados visíveis, chame [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) com `true` via [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Isso oculta apenas a entrada de legenda selecionada; não remove a série nem seus pontos de dados. Chamar [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) com `false`, por outro lado, oculta a legenda inteira.

O exemplo abaixo cria um gráfico de colunas agrupadas com várias séries usando dados padrão. Ele oculta a entrada de legenda da segunda série (índice `1`) e salva a apresentação. Em seguida, restaura a entrada chamando [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) com `false` e salva uma segunda cópia. As colunas permanecem visíveis em ambos os arquivos.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // Restaurar a mesma entrada sem alterar os dados do gráfico.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A comparação abaixo mostra o mesmo gráfico com todas as entradas da legenda visíveis e com a segunda entrada oculta da legenda; todas as colunas permanecem visíveis.

![Comparação de um gráfico com todas as entradas da legenda visíveis e com a Série 2 oculta da legenda; todas as colunas permanecem visíveis.](hide-legend-entry.png)

Em gráficos de colunas, barras e linhas, as entradas da legenda identificam séries. Em gráficos de pizza, elas identificam pontos de dados individuais (fatias), portanto use [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) na fatia selecionada. A API documenta este método de ponto de dados para os tipos de gráfico `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` e `BarOfPie`. Não suponha que ele se aplique a gráficos de rosquinha, que não estão incluídos nessa lista.

## **FAQ**

**Posso fazer o gráfico reservar espaço para a legenda em vez de sobrepô-la?**  
Sim. Chame [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) com `false` para reservar espaço para a legenda em vez de permitir que ela sobreponha a área do gráfico.

**Posso criar rótulos de legenda em várias linhas?**  
Sim. Rótulos longos podem ser quebrados quando a largura disponível é insuficiente. Também é possível usar caracteres de nova linha nos nomes das séries para solicitar quebras de linha.

**Como faço a legenda seguir o esquema de cores do tema da apresentação?**  
Deixe as cores, preenchimentos e fontes da legenda sem definição para que ela possa herdar a formatação do tema. A formatação explícita substitui as configurações correspondentes do tema.