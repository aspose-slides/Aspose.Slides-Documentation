---
title: Personalizar legendas de gráficos em apresentações usando Java
linktitle: Legenda de Gráfico
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
description: "Personalize as legendas de gráficos com Aspose.Slides for Java para otimizar apresentações do PowerPoint com formatação de legenda personalizada."
---
## **Visão geral**

O Aspose.Slides oferece opções para personalizar legendas de gráficos em apresentações do PowerPoint. Este artigo mostra como posicionar e dimensionar uma legenda, definir o tamanho da fonte para toda a legenda e aplicar formatação a uma entrada individual da legenda.

Ele também aborda vários comportamentos relacionados nas Perguntas Frequentes, incluindo o uso do modo sem sobreposição para que a área do gráfico reserve espaço para a legenda, permitindo que rótulos longos de legenda sejam ajustados ou utilizem quebras de linha, e permitindo que a formatação da legenda herde do tema da apresentação quando configurações explícitas de texto e preenchimento não são aplicadas.

## **Posicionamento da legenda**
Para definir as propriedades da legenda, siga as etapas abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
- Obtenha a referência do slide.
- Adicione um gráfico ao slide.
- Defina as propriedades da legenda.
- Salve a apresentação como um arquivo PPTX.

No exemplo abaixo, definimos a posição e o tamanho da legenda do gráfico.

```java
// Crie uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenha a referência do slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Adicione um gráfico de colunas agrupadas ao slide
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Definir propriedades da legenda
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Salve a apresentação no disco
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir o tamanho da fonte de uma legenda**
O Aspose.Slides for Java permite que os desenvolvedores definam o tamanho da fonte da legenda. Siga as etapas abaixo:

- Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
- Crie o gráfico padrão.
- Defina o tamanho da fonte.
- Defina o valor mínimo do eixo.
- Defina o valor máximo do eixo.
- Salve a apresentação no disco.

```java
// Crie uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir o tamanho da fonte de uma legenda individual**
O Aspose.Slides for Java permite que os desenvolvedores definam o tamanho da fonte das entradas individuais da legenda. Siga as etapas abaixo:

- Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
- Crie o gráfico padrão.
- Acesse a entrada da legenda.
- Defina o tamanho da fonte.
- Defina o valor mínimo do eixo.
- Defina o valor máximo do eixo.
- Salve a apresentação no disco.

```java
// Crie uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas Frequentes**

**Posso habilitar a legenda para que o gráfico reserve automaticamente espaço para ela em vez de sobrepor?**

Sim. Use o modo sem sobreposição ([setOverlay(false)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/legend/#setOverlay-boolean-)); nesse caso, a área do gráfico será reduzida para acomodar a legenda.

**Posso criar rótulos de legenda em várias linhas?**

Sim. Rótulos longos são ajustados automaticamente quando o espaço é insuficiente; quebras de linha forçadas são suportadas por meio de caracteres de nova linha no nome da série.

**Como faço para que a legenda siga o esquema de cores do tema da apresentação?**

Não defina cores, preenchimentos ou fontes explícitas para a legenda ou seu texto. Eles então herdarão do tema e serão atualizados corretamente quando o design mudar.