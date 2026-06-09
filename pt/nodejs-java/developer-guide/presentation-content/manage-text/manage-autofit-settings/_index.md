---
title: Aprimore suas apresentações com AutoFit em JavaScript
linktitle: Configurações de Autofit
type: docs
weight: 30
url: /pt/nodejs-java/manage-autofit-settings/
keywords:
- caixa de texto
- autofit
- não autoajustar
- ajustar texto
- reduzir texto
- quebrar texto
- redimensionar forma
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie as configurações de AutoFit no Aspose.Slides para Node.js para otimizar a exibição de texto em suas apresentações PowerPoint e OpenDocument e melhorar a legibilidade do conteúdo."
---
## **Introdução**

Por padrão, ao inserir uma caixa de texto, o Microsoft PowerPoint usa a configuração **Resize shape to fix text** para a caixa de texto—ele redimensiona automaticamente a caixa de texto para garantir que seu texto sempre caiba nela. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Quando o texto na caixa de texto se torna mais longo ou maior, o PowerPoint aumenta automaticamente a caixa de texto—incrementa sua altura—para permitir que contenha mais texto. 
* Quando o texto na caixa de texto se torna mais curto ou menor, o PowerPoint reduz automaticamente a caixa de texto—diminui sua altura—para eliminar espaço redundante. 

No PowerPoint, estes são os 4 parâmetros ou opções importantes que controlam o comportamento de autofit para uma caixa de texto: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Node.js via Java fornece opções semelhantes—algumas propriedades da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrameFormat)—que permitem controlar o comportamento de autofit para caixas de texto em apresentações.

## **Redimensionar forma para ajustar texto**

Se você quiser que o texto em uma caixa sempre caiba nessa caixa após alterações no texto, deve usar a opção **Resize shape to fix text**. Para especificar essa configuração, chame o método [setAutofitType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrameFormat) com o valor `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Este código JavaScript mostra como especificar que um texto deve sempre caber em sua caixa em uma apresentação PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Se o texto ficar mais longo ou maior, a caixa de texto será redimensionada automaticamente (aumentando a altura) para garantir que todo o texto caiba nela. Se o texto ficar mais curto, o processo ocorre em sentido inverso. 

## **Não Autoajustar**

Se você quiser que uma caixa de texto ou forma mantenha suas dimensões independentemente das alterações feitas no texto que contém, deve usar a opção **Do not Autofit**. Para especificar essa configuração, chame o método [setAutofitType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrameFormat) com o valor `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Este código JavaScript mostra como especificar que uma caixa de texto deve sempre manter suas dimensões em uma apresentação PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Quando o texto fica muito longo para a caixa, ele transborda. 

## **Reduzir texto ao transbordar**

Se um texto ficar muito longo para sua caixa, através da opção **Shrink text on overflow**, você pode especificar que o tamanho e o espaçamento do texto devem ser reduzidos para que ele caiba na caixa. Para especificar essa configuração, chame o método [setAutofitType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrameFormat) com o valor `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Este código JavaScript mostra como especificar que um texto deve ser reduzido ao transbordar em uma apresentação PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
Ao usar a opção **Shrink text on overflow**, a configuração é aplicada somente quando o texto fica muito longo para a caixa. 
{{% /alert %}}

## **Quebrar Texto**

Se você quiser que o texto em uma forma seja quebrado dentro dessa forma quando o texto ultrapassar a borda da forma (apenas a largura), deve usar o parâmetro **Wrap text in shape**. Para especificar essa configuração, chame o método [setWrapText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrameFormat) com o valor `true`.

Este código JavaScript mostra como usar a configuração Wrap Text em uma apresentação PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
Se você chamar o método `setWrapText` com o valor `False` para uma forma, quando o texto dentro da forma ficar mais longo que a largura da forma, o texto será estendido além das bordas da forma em uma única linha. 
{{% /alert %}}

## **Perguntas Frequentes**

**As margens internas do quadro de texto afetam o AutoFit?**

Sim. O preenchimento (margens internas) reduz a área utilizável para o texto, fazendo com que o AutoFit seja acionado mais cedo—encolhendo a fonte ou redimensionando a forma antes. Verifique e ajuste as margens antes de afinar o AutoFit.

**Como o AutoFit interage com quebras de linha manuais e suaves?**

Quebras impostas permanecem, e o AutoFit adapta o tamanho da fonte e o espaçamento ao redor delas. Remover quebras desnecessárias costuma reduzir a agressividade com que o AutoFit precisa encolher o texto.

**Alterar a fonte do tema ou acionar substituição de fonte afeta os resultados do AutoFit?**

Sim. Substituir por uma fonte com métricas diferentes altera a largura/altura do texto, o que pode mudar o tamanho final da fonte e a quebra de linha. Depois de qualquer mudança ou substituição de fonte, revise os slides.