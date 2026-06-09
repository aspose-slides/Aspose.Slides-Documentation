---
title: Personalizar legendas de gráfico em apresentações usando JavaScript
linktitle: Legenda de Gráfico
type: docs
url: /pt/nodejs-java/chart-legend/
keywords:
- legenda de gráfico
- posicionamento da legenda
- tamanho da fonte
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Personalize as legendas de gráficos com JavaScript e Aspose.Slides para Node.js para otimizar apresentações do PowerPoint com formatação de legenda sob medida."
---
## **Visão geral**

Aspose.Slides oferece opções para personalizar legendas de gráficos em apresentações do PowerPoint. Este artigo mostra como posicionar e dimensionar uma legenda, definir o tamanho da fonte para toda a legenda e aplicar formatação a uma entrada individual da legenda.

Ele também aborda vários comportamentos relacionados nas Perguntas Frequentes, incluindo o uso do modo sem sobreposição para que a área do gráfico reserve espaço para a legenda, permitir que rótulos longos de legenda quebrem em linhas ou usem quebras de linha, e permitir que a formatação da legenda herde do tema da apresentação quando configurações explícitas de texto e preenchimento não forem aplicadas.

## **Posicionamento da legenda**

Para definir as propriedades da legenda, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
- Obtenha a referência do slide.
- Adicione um gráfico ao slide.
- Defina as propriedades da legenda.
- Grave a apresentação como um arquivo PPTX.

No exemplo abaixo, definimos a posição e o tamanho da legenda do gráfico.

```javascript
// Crie uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtenha a referência do slide
    var slide = pres.getSlides().get_Item(0);
    // Adicione um gráfico de colunas agrupadas no slide
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // Defina as propriedades da legenda
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // Grave a apresentação no disco
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir tamanho da fonte da legenda**

O Aspose.Slides para Node.js via Java permite que os desenvolvedores definam o tamanho da fonte da legenda. Siga os passos abaixo:

- Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
- Crie o gráfico padrão.
- Defina o tamanho da fonte.
- Defina o valor mínimo do eixo.
- Defina o valor máximo do eixo.
- Grave a apresentação no disco.

```javascript
// Crie uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir tamanho da fonte de legenda individual**

O Aspose.Slides para Node.js via Java permite que os desenvolvedores definam o tamanho da fonte de entradas individuais da legenda. Siga os passos abaixo:

- Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
- Crie o gráfico padrão.
- Acesse a entrada da legenda.
- Defina o tamanho da fonte.
- Defina o valor mínimo do eixo.
- Defina o valor máximo do eixo.
- Grave a apresentação no disco.

```javascript
// Crie uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas Frequentes**

**Posso habilitar a legenda para que o gráfico aloque automaticamente espaço para ela em vez de sobrepô-la?**

Sim. Use o modo sem sobreposição ([setOverlay(false)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/legend/setoverlay/)); nesse caso, a área do gráfico será reduzida para acomodar a legenda.

**Posso criar rótulos de legenda em várias linhas?**

Sim. Rótulos longos são quebrados automaticamente quando o espaço é insuficiente; quebras de linha forçadas são suportadas por meio de caracteres de nova linha no nome da série.

**Como faço a legenda seguir o esquema de cores do tema da apresentação?**

Não defina cores/preenchimentos/fontes explícitos para a legenda ou seu texto. Eles então herdarão do tema e serão atualizados corretamente quando o design mudar.