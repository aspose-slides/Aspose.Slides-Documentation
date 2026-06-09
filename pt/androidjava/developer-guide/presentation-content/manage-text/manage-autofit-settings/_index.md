---
title: Melhore suas apresentações com AutoFit no Android
linktitle: Configurações de Autofit
type: docs
weight: 30
url: /pt/androidjava/manage-autofit-settings/
keywords:
- caixa de texto
- autofit
- não autofit
- ajustar texto
- reduzir texto
- quebrar texto
- redimensionar forma
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Gerencie as configurações de AutoFit no Aspose.Slides para Android via Java para otimizar a exibição de texto em suas apresentações PowerPoint e OpenDocument e melhorar a legibilidade do conteúdo."
---
## **Introdução**

Por padrão, quando você adiciona uma caixa de texto, o Microsoft PowerPoint usa a configuração **Resize shape to fix text** para a caixa de texto—ela redimensiona automaticamente a caixa de texto para garantir que o texto sempre caiba nela. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Quando o texto na caixa de texto fica mais longo ou maior, o PowerPoint aumenta automaticamente a caixa de texto—incrementa sua altura—para permitir que ela contenha mais texto. 
* Quando o texto na caixa de texto fica mais curto ou menor, o PowerPoint reduz automaticamente a caixa de texto—diminui sua altura—para eliminar espaço redundante. 

No PowerPoint, estes são os 4 parâmetros ou opções importantes que controlam o comportamento de autofit para uma caixa de texto: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**.

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java fornece opções semelhantes—algumas propriedades na classe [TextFrameFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/TextFrameFormat)—que permitem controlar o comportamento de autofit para caixas de texto em apresentações.

## **Resize a Shape to Fit Text**

Se você deseja que o texto em uma caixa sempre caiba naquela caixa após alterações no texto, deve usar a opção **Resize shape to fix text**. Para especificar essa configuração, defina a propriedade [AutofitType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/TextFrameFormat)) como `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Este código Java mostra como especificar que um texto deve sempre caber em sua caixa em uma apresentação do PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Se o texto ficar mais longo ou maior, a caixa de texto será redimensionada automaticamente (aumentando a altura) para garantir que todo o texto caiba nela. Se o texto ficar mais curto, ocorre o inverso. 

## **Do Not Autofit**

Se você deseja que uma caixa de texto ou forma mantenha suas dimensões independentemente das alterações feitas no texto que contém, deve usar a opção **Do not Autofit**. Para especificar essa configuração, defina a propriedade [AutofitType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/TextFrameFormat)) como `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Este código Java mostra como especificar que uma caixa de texto deve sempre manter suas dimensões em uma apresentação do PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Quando o texto fica muito longo para sua caixa, ele transborda. 

## **Shrink Text on Overflow**

Se um texto ficar muito longo para sua caixa, usando a opção **Shrink text on overflow** você pode especificar que o tamanho e o espaçamento do texto devem ser reduzidos para que ele caiba na caixa. Para especificar essa configuração, defina a propriedade [AutofitType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/TextFrameFormat)) como `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Este código Java mostra como especificar que um texto deve ser reduzido ao transbordar em uma apresentação do PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Quando a opção **Shrink text on overflow** é usada, a configuração é aplicada somente quando o texto fica muito longo para sua caixa. 
{{% /alert %}}

## **Wrap Text**

Se você deseja que o texto em uma forma seja quebrado dentro dessa forma quando o texto ultrapassar a borda da forma (apenas largura), deve usar o parâmetro **Wrap text in shape**. Para especificar essa configuração, defina a propriedade [WrapText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/TextFrameFormat)) como `true`.

Este código Java mostra como usar a configuração Wrap Text em uma apresentação do PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Se você definir a propriedade `WrapText` como `False` para uma forma, quando o texto dentro da forma ficar mais longo que a largura da forma, o texto se estenderá além das bordas da forma em uma única linha. 
{{% /alert %}}

## **FAQ**

**Os limites internos da caixa de texto afetam o AutoFit?**  
Sim. O preenchimento (margens internas) reduz a área utilizável para o texto, portanto o AutoFit será acionado mais cedo—encolhendo a fonte ou redimensionando a forma antes. Verifique e ajuste as margens antes de calibrar o AutoFit.

**Como o AutoFit interage com quebras de linha manuais e suaves?**  
Quebras forçadas permanecem no lugar, e o AutoFit ajusta o tamanho da fonte e o espaçamento ao redor delas. Remover quebras desnecessárias costuma reduzir a agressividade com que o AutoFit precisa encolher o texto.

**Alterar a fonte do tema ou acionar substituição de fonte afeta os resultados do AutoFit?**  
Sim. Substituir por uma fonte com métricas de glifo diferentes altera a largura/altura do texto, o que pode mudar o tamanho final da fonte e a quebra de linha. Após qualquer alteração ou substituição de fonte, revise novamente os slides.