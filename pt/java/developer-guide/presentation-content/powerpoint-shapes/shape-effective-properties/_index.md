---  
title: Obter propriedades efetivas de formas em apresentações Java  
linktitle: Propriedades efetivas  
type: docs  
weight: 50  
url: /pt/java/shape-effective-properties/  
keywords:  
- propriedades da forma  
- propriedades da câmera  
- conjunto de luzes  
- forma chanfrada  
- quadro de texto  
- estilo de texto  
- altura da fonte  
- formato de preenchimento  
- PowerPoint  
- apresentação  
- Java  
- Aspose.Slides  
description: "Descubra como o Aspose.Slides para Java calcula e aplica propriedades efetivas de formas para renderização precisa no PowerPoint."  
---
## **Visão geral**

Este tópico explica a diferença entre propriedades **local** e **efetiva**. Valores locais são valores que são definidos diretamente em um nível específico de formatação, como:

1. Propriedades de porção em um slide.  
1. Estilos de texto de forma de protótipo em um layout ou slide mestre, quando a forma de quadro de texto da porção possui um.  
1. Configurações globais de texto em uma apresentação.

Valores locais podem ser definidos ou omitidos em qualquer nível. Quando o Aspose.Slides precisa da formatação final “como renderizada”, ele resolve a cadeia de herança e retorna valores **efetivos**. Você pode obtê-los chamando o método `getEffective` no objeto de formato local.

O exemplo a seguir mostra como obter valores efetivos. Ele assume que a primeira forma no primeiro slide é um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IAutoShape) com um quadro de texto e pelo menos uma porção.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Os dados de formatação efetiva representam a formatação calculada atual após a aplicação da herança. Na implementação atual, alguns objetos de dados efetivos, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPortionFormatEffectiveData), podem ser armazenados em cache internamente. Chamar `getEffective` novamente após alterar a formatação do pai ou herdada pode atualizar o cache, e um objeto obtido anteriormente pode não representar mais o estado anterior. Se precisar preservar valores efetivos para reutilização posterior, copie as propriedades necessárias, como altura da fonte, cor de preenchimento, estilo da fonte ou alinhamento, para seu próprio objeto de dados.
{{% /alert %}}

## **Obter propriedades efetivas de uma câmera**

Aspose.Slides permite que você obtenha propriedades efetivas de uma câmera. A interface [ICameraEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ICameraEffectiveData) representa um objeto imutável que contém propriedades efetivas da câmera. Uma instância de [ICameraEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ICameraEffectiveData) é exposta através de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IThreeDFormatEffectiveData), que fornece valores efetivos para [IThreeDFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IThreeDFormat).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Obter propriedades efetivas de um conjunto de luzes**

Aspose.Slides permite que você obtenha propriedades efetivas de um conjunto de luzes. A interface [ILightRigEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ILightRigEffectiveData) representa um objeto imutável que contém propriedades efetivas do conjunto de luzes. Uma instância de [ILightRigEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ILightRigEffectiveData) é exposta através de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IThreeDFormatEffectiveData), que fornece valores efetivos para [IThreeDFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IThreeDFormat).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Obter propriedades efetivas de um chanfrado de forma**

Aspose.Slides permite que você obtenha propriedades efetivas de um chanfrado de forma. A interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShapeBevelEffectiveData) representa um objeto imutável que contém propriedades efetivas de relevo de faces para uma forma. Uma instância de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShapeBevelEffectiveData) é exposta através de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IThreeDFormatEffectiveData), que fornece valores efetivos para [IThreeDFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IThreeDFormat).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Obter propriedades efetivas de um quadro de texto**

Usando Aspose.Slides, você pode obter propriedades efetivas de um quadro de texto. A interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ITextFrameFormatEffectiveData) contém propriedades efetivas de formatação de quadro de texto.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Obter propriedades efetivas de um estilo de texto**

Usando Aspose.Slides, você pode obter propriedades efetivas de um estilo de texto. A interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ITextStyleEffectiveData) contém propriedades efetivas de estilo de texto.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Obter o valor efetivo da altura da fonte**

Usando Aspose.Slides, você pode obter a altura da fonte efetiva. O código a seguir demonstra como a altura da fonte efetiva de uma porção muda após valores locais de altura da fonte serem definidos em diferentes níveis da estrutura da apresentação.

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

Usando Aspose.Slides, você pode obter o formato de preenchimento efetivo para diferentes partes de uma tabela. A interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IFillFormatEffectiveData) contém propriedades efetivas de preenchimento. A formatação de célula tem prioridade maior que a formatação de linha, a formatação de linha tem prioridade maior que a formatação de coluna, e a formatação de coluna tem prioridade maior que a formatação de toda a tabela.

Como resultado, as propriedades de [ICellFormatEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ICellFormatEffectiveData) são usadas para desenhar a célula da tabela. O código a seguir mostra como obter o formato de preenchimento efetivo para diferentes partes da tabela. Ele assume que a primeira forma no primeiro slide é um [ITable](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ITable).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **Perguntas frequentes**

**`getEffective` retorna um instantâneo?**

Nem sempre. Dados efetivos representam a formatação calculada após a herança ser aplicada, mas alguns objetos de dados efetivos podem ser armazenados em cache internamente. Uma chamada subsequente a `getEffective` pode recalcular a formatação e atualizar os dados em cache, portanto um objeto obtido anteriormente não deve ser tratado como um instantâneo durável.

**Quando devo ler as propriedades efetivas novamente?**

Chame `getEffective` novamente após alterar a formatação local, estilos de pai, formatação de layout, formatação de mestre ou padrões de nível de apresentação. A próxima chamada reavalia a hierarquia de formatação e retorna o resultado efetivo atual.

**Alterar ou remover um slide de layout/mestre afeta as propriedades efetivas que já foram recuperadas?**

Sim, mas a alteração só se reflete na próxima chamada a `getEffective`. Se uma fonte de formatação pai for alterada ou removida, os dados efetivos obtidos anteriormente podem ficar desatualizados. Quando `getEffective` for chamado novamente, Aspose.Slides reavalia a árvore de formatação e as fontes, cores, tamanhos ou outros valores resultantes podem mudar.

**Posso modificar valores através de objetos de dados efetivos?**

Não. Objetos de dados efetivos expõem valores calculados. Faça alterações nos objetos de formatação local e, em seguida, obtenha os valores efetivos novamente.

**O que acontece se uma propriedade não estiver definida no nível da forma, nem no layout/mestre, nem nas configurações globais?**

O valor efetivo é determinado pelo mecanismo padrão, que inclui valores padrão do PowerPoint e do Aspose.Slides. Esse valor resolvido passa a fazer parte dos dados efetivos atuais.

**A partir de um valor de fonte efetivo, posso identificar qual nível forneceu o tamanho ou a família tipográfica?**

Não diretamente. Dados efetivos retornam o valor final. Para encontrar a fonte, verifique os valores locais na porção, parágrafo, quadro de texto e estilos de texto nos níveis de layout, mestre e apresentação para ver onde a primeira definição explícita aparece.

**Por que valores efetivos às vezes parecem idênticos aos locais?**

Porque o valor local acabou sendo o final (não foi necessária herança de nível superior). Nesses casos, o valor efetivo coincide com o local.

**Quando devo usar propriedades efetivas e quando devo trabalhar apenas com as locais?**

Use dados efetivos quando precisar do resultado “como renderizado” após toda a herança ser aplicada, como para alinhar cores, recuos ou tamanhos. Se precisar preservar esses valores independentemente de alterações posteriores de formatação, copie as propriedades necessárias para seu próprio objeto. Se precisar mudar a formatação em um nível específico, modifique as propriedades locais e, se necessário, leia os dados efetivos novamente para verificar o resultado.