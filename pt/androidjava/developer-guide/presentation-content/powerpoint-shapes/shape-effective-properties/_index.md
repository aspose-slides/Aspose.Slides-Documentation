---
title: Obter propriedades efetivas de forma de apresentações no Android
linktitle: Propriedades efetivas
type: docs
weight: 50
url: /pt/androidjava/shape-effective-properties/
keywords:
- propriedades de forma
- propriedades de câmera
- rig de luz
- forma de bisel
- quadro de texto
- estilo de texto
- altura da fonte
- formato de preenchimento
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Descubra como o Aspose.Slides para Android via Java calcula e aplica propriedades efetivas de forma para renderização precisa do PowerPoint."
---
## **Visão geral**

Este tópico explica a diferença entre propriedades **locais** e **efetivas**. Valores locais são valores que são definidos diretamente em um nível específico de formatação, como:

1. Propriedades de porção em um slide.
1. Estilos de texto de forma de protótipo em um layout ou slide mestre, quando a forma de quadro de texto da porção tem um.
1. Configurações de texto globais em uma apresentação.

Valores locais podem ser definidos ou omitidos em qualquer nível. Quando Aspose.Slides precisa da formatação final “como renderizada”, resolve a cadeia de herança e devolve valores **efetivos**. Você pode obtê-los chamando o método `getEffective()` no objeto de formatação local.

O exemplo a seguir mostra como obter valores efetivos. Assume que a primeira forma no primeiro slide é um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) com um quadro de texto e ao menos uma porção.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Dados de formatação efetiva representam a formatação calculada atual após a aplicação da herança. Na implementação atual, alguns objetos de dados efetivos, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportionformateffectivedata/), podem ser armazenados em cache internamente. Chamar `getEffective()` novamente após mudar a formatação pai ou herdada pode atualizar o cache, e um objeto obtido anteriormente pode não representar mais o estado anterior. Se precisar preservar valores efetivos para reutilização posterior, copie as propriedades necessárias, como altura da fonte, cor de preenchimento, estilo da fonte ou alinhamento, para seu próprio objeto de dados.
{{% /alert %}}

## **Obter propriedades efetivas de uma câmera**

Aspose.Slides permite que você obtenha propriedades efetivas de uma câmera. A interface [ICameraEffectiveData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icameraeffectivedata/) representa um objeto imutável que contém propriedades efetivas da câmera. Uma instância de [ICameraEffectiveData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icameraeffectivedata/) é exposta através de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformateffectivedata/), que fornece valores efetivos para [IThreeDFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **Obter propriedades efetivas de um rig de luz**

Aspose.Slides permite que você obtenha propriedades efetivas de um rig de luz. A interface [ILightRigEffectiveData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilightrigeffectivedata/) representa um objeto imutável que contém propriedades efetivas do rig de luz. Uma instância de [ILightRigEffectiveData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilightrigeffectivedata/) é exposta através de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformateffectivedata/), que fornece valores efetivos para [IThreeDFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **Obter propriedades efetivas de um bisel de forma**

Aspose.Slides permite que você obtenha propriedades efetivas de um bisel de forma. A interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapebeveleffectivedata/) representa um objeto imutável que contém propriedades efetivas de relevo de face para uma forma. Uma instância de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapebeveleffectivedata/) é exposta através de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformateffectivedata/), que fornece valores efetivos para [IThreeDFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **Obter propriedades efetivas de um quadro de texto**

Usando Aspose.Slides, você pode obter propriedades efetivas de um quadro de texto. A interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframeformateffectivedata/) contém propriedades efetivas de formatação de quadro de texto.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **Obter propriedades efetivas de um estilo de texto**

Usando Aspose.Slides, você pode obter propriedades efetivas de um estilo de texto. A interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextstyleeffectivedata/) contém propriedades efetivas de estilo de texto.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **Obter o valor efetivo da altura da fonte**

Usando Aspose.Slides, você pode obter a altura da fonte efetiva. O código a seguir demonstra como a altura da fonte efetiva de uma porção muda após valores locais de altura de fonte serem definidos em diferentes níveis da estrutura da apresentação.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obter o formato de preenchimento efetivo para uma tabela**

Usando Aspose.Slides, você pode obter formatação de preenchimento efetiva para diferentes partes de uma tabela. A interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifillformateffectivedata/) contém propriedades efetivas de formatação de preenchimento. A formatação de célula tem prioridade maior que a formatação de linha, a formatação de linha tem prioridade maior que a formatação de coluna e a formatação de coluna tem prioridade maior que a formatação de tabela completa.

Como resultado, as propriedades de [ICellFormatEffectiveData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icellformateffectivedata/) são usadas para desenhar a célula da tabela. O exemplo a seguir mostra como obter formatação de preenchimento efetiva para diferentes partes da tabela. Assume que a primeira forma no primeiro slide é um [ITable](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itable/).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **Perguntas frequentes**

**`getEffective()` retorna um instantâneo?**

Nem sempre. Dados efetivos representam a formatação calculada após a aplicação da herança, mas alguns objetos de dados efetivos podem ser armazenados em cache internamente. Uma chamada subsequente a `getEffective()` pode recalcular a formatação e atualizar o cache, de modo que um objeto obtido anteriormente não deve ser tratado como um instantâneo durável.

**Quando devo ler as propriedades efetivas novamente?**

Chame `getEffective()` novamente após mudar a formatação local, estilos pai, formatação de layout, formatação mestre ou valores padrão ao nível da apresentação. A chamada seguinte reavalia a hierarquia de formatação e devolve o resultado efetivo atual.

**Alterar ou remover um slide de layout/mestre afeta as propriedades efetivas que já foram obtidas?**

Sim, mas a alteração só se reflete na próxima chamada a `getEffective()`. Se uma fonte de formatação pai for alterada ou removida, os dados efetivos obtidos anteriormente podem ficar desatualizados. Quando `getEffective()` for chamado novamente, Aspose.Slides reavalia a árvore de formatação e as fontes, cores, tamanhos ou outros valores resultantes podem mudar.

**Posso modificar valores através de objetos de dados efetivos?**

Não. Objetos de dados efetivos expõem valores calculados. Faça alterações nos objetos de formatação local e, em seguida, obtenha os valores efetivos novamente.

**O que acontece se uma propriedade não for definida no nível da forma, nem no layout/mestre, nem nas configurações globais?**

O valor efetivo é determinado pelo mecanismo padrão, que inclui os padrões do PowerPoint e do Aspose.Slides. Esse valor resolvido passa a fazer parte dos dados efetivos atuais.

**A partir de um valor de fonte efetivo, posso identificar qual nível forneceu o tamanho ou a família tipográfica?**

Não diretamente. Dados efetivos retornam o valor final. Para descobrir a origem, verifique os valores locais na porção, parágrafo, quadro de texto e estilos de texto nos níveis de layout, mestre e apresentação, para ver onde a primeira definição explícita aparece.

**Por que valores efetivos às vezes parecem idênticos aos locais?**

Porque o valor local acabou sendo o final (nenhuma herança de nível superior foi necessária). Nesses casos, o valor efetivo coincide com o local.

**Quando devo usar propriedades efetivas e quando devo trabalhar apenas com as locais?**

Use dados efetivos quando precisar do resultado “como renderizado” após toda a herança ser aplicada, como para alinhar cores, recuos ou tamanhos. Se precisar preservar esses valores independentemente de alterações de formatação posteriores, copie as propriedades necessárias para seu próprio objeto. Se precisar mudar a formatação em um nível específico, modifique as propriedades locais e, se necessário, leia os dados efetivos novamente para verificar o resultado.