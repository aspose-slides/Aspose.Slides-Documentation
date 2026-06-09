---
title: Personalizar Legendas de Gráficos em Apresentações no Android
linktitle: Legenda de Gráfico
type: docs
url: /pt/androidjava/chart-legend/
keywords:
- legenda de gráfico
- posição da legenda
- tamanho da fonte
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Personalize legendas de gráficos com Aspose.Slides para Android via Java para otimizar apresentações do PowerPoint com formatação de legenda sob medida."
---
## **Visão geral**

O Aspose.Slides oferece opções para personalizar legendas de gráficos em apresentações do PowerPoint. Este artigo mostra como posicionar e dimensionar uma legenda, definir o tamanho da fonte para a legenda inteira e aplicar formatação a uma entrada individual da legenda.

Ele também cobre vários comportamentos relacionados nas Perguntas Frequentes, incluindo o uso do modo sem sobreposição para que a área do gráfico reserve espaço para a legenda, permitir que rótulos longos de legenda sejam quebrados em várias linhas ou usem quebras de linha, e permitir que a formatação da legenda herde do tema da apresentação quando cores, preenchimentos ou fontes explícitos não são definidos.

## **Posicionamento da Legenda**
Para definir as propriedades da legenda, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
- Obtenha a referência do slide.
- Adicione um gráfico ao slide.
- Defina as propriedades da legenda.
- Grave a apresentação como um arquivo PPTX.

No exemplo abaixo, definimos a posição e o tamanho da legenda do Gráfico.

```java
// Crie uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenha a referência do slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Adicione um gráfico de colunas agrupadas no slide
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Defina as propriedades da legenda
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Grave a apresentação no disco
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir o Tamanho da Fonte de uma Legenda**
O Aspose.Slides para Android via Java permite que os desenvolvedores definam o tamanho da fonte da legenda. Siga os passos abaixo:

- Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
- Crie o gráfico padrão.
- Defina o Tamanho da Fonte.
- Defina o valor mínimo do eixo.
- Defina o valor máximo do eixo.
- Grave a apresentação no disco.

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

## **Definir o Tamanho da Fonte de uma Legenda Individual**
O Aspose.Slides para Android via Java permite que os desenvolvedores definam o tamanho da fonte de entradas individuais da legenda. Siga os passos abaixo:

- Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
- Crie o gráfico padrão.
- Acesse a entrada da legenda.
- Defina o Tamanho da Fonte.
- Defina o valor mínimo do eixo.
- Defina o valor máximo do eixo.
- Grave a apresentação no disco.

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

**Posso habilitar a legenda para que o gráfico reserve espaço automaticamente para ela em vez de sobrepor?**

Sim. Use o modo sem sobreposição ([setOverlay(false)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); nesse caso, a área do gráfico será reduzida para acomodar a legenda.

**Posso criar rótulos de legenda em várias linhas?**

Sim. Rótulos longos são quebrados automaticamente quando o espaço é insuficiente; quebras de linha forçadas são suportadas por meio de caracteres de nova linha no nome da série.

**Como faço a legenda seguir o esquema de cores do tema da apresentação?**

Não defina cores, preenchimentos ou fontes explícitos para a legenda ou seu texto. Eles herdarão do tema e serão atualizados corretamente quando o design for alterado.