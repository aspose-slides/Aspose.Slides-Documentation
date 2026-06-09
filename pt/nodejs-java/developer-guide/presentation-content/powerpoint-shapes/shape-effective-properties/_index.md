---
title: Obter propriedades efetivas de formas de apresentações em JavaScript
linktitle: Propriedades Efetivas
type: docs
weight: 50
url: /pt/nodejs-java/shape-effective-properties/
keywords:
- propriedades de forma
- propriedades de câmera
- rig de luz
- forma chanfrada
- quadro de texto
- estilo de texto
- altura da fonte
- formato de preenchimento
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra como o Aspose.Slides para Node.js via Java calcula e aplica propriedades efetivas de forma para renderização precisa do PowerPoint."
---
## **Visão geral**

Este tópico explica a diferença entre propriedades **locais** e **efetivas**. Valores locais são valores definidos diretamente em um nível específico de formatação, como:

1. Propriedades de porção em um slide.
1. Estilos de texto de forma de protótipo em um slide de layout ou mestre, quando a forma de quadro de texto da porção possui um.
1. Configurações globais de texto em uma apresentação.

Valores locais podem ser definidos ou omitidos em qualquer nível. Quando o Aspose.Slides precisa da formatação final “como renderizada”, ele resolve a cadeia de herança e devolve valores **efetivos**. Você pode obtê‑los chamando o método `getEffective` no objeto de formatação local.

O exemplo a seguir mostra como obter valores efetivos. Ele assume que a primeira forma no primeiro slide é um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) com um quadro de texto e pelo menos uma porção.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Os dados de formatação efetiva representam a formatação calculada atual após a aplicação da herança. Na implementação atual, alguns objetos de dados efetivos podem ser armazenados em cache internamente. Chamar `getEffective` novamente após alterar a formatação pai ou herdada pode atualizar o cache, e um objeto obtido anteriormente pode não representar mais o estado anterior. Se precisar preservar valores efetivos para reutilização posterior, copie as propriedades necessárias, como altura da fonte, cor de preenchimento, estilo da fonte ou alinhamento, para seu próprio objeto de dados.
{{% /alert %}}

## **Obter propriedades efetivas de uma câmera**

O Aspose.Slides permite obter propriedades efetivas de uma câmera. O objeto de dados da câmera efetiva contém propriedades de câmera imutáveis e é exposto por meio dos valores efetivos retornados para [ThreeDFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/).

O exemplo de código a seguir mostra como obter propriedades efetivas da câmera. Ele assume que a primeira forma no primeiro slide possui formatação 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Obter propriedades efetivas de um rig de luz**

O Aspose.Slides permite obter propriedades efetivas de um rig de luz. O objeto de dados do rig de luz efetivo contém propriedades de rig de luz imutáveis e é exposto por meio dos valores efetivos retornados para [ThreeDFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/).

O exemplo de código a seguir mostra como obter propriedades efetivas do rig de luz. Ele assume que a primeira forma no primeiro slide possui formatação 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Obter propriedades efetivas de um shape de chanfrado**

O Aspose.Slides permite obter propriedades efetivas de um chanfrado de forma. O objeto de dados do chanfrado de forma efetivo contém propriedades imutáveis de relevo de face para uma forma e é exposto por meio dos valores efetivos retornados para [ThreeDFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/).

O exemplo de código a seguir mostra como obter propriedades efetivas do chanfrado superior de uma forma. Ele assume que a primeira forma no primeiro slide possui formatação 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Obter propriedades efetivas de um quadro de texto**

Usando o Aspose.Slides, você pode obter propriedades efetivas de um quadro de texto. O objeto de dados efetivo retornado contém propriedades de formatação do quadro de texto.

O exemplo de código a seguir mostra como obter propriedades de formatação efetiva do quadro de texto. Ele assume que a primeira forma no primeiro slide é um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) com um quadro de texto.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Obter propriedades efetivas de um estilo de texto**

Usando o Aspose.Slides, você pode obter propriedades efetivas de um estilo de texto. O objeto de dados efetivo retornado contém propriedades de estilo de texto.

O exemplo de código a seguir mostra como obter propriedades de estilo de texto efetivas. Ele assume que a primeira forma no primeiro slide é um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) com um quadro de texto.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Obter o valor efetivo da altura da fonte**

Usando o Aspose.Slides, você pode obter a altura da fonte efetiva. O código a seguir demonstra como a altura da fonte efetiva de uma porção muda após valores de altura da fonte locais serem definidos em diferentes níveis da estrutura da apresentação.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **Obter o formato de preenchimento efetivo para uma tabela**

Usando o Aspose.Slides, você pode obter formatação de preenchimento efetiva para diferentes partes de uma tabela. O objeto de dados efetivo retornado contém propriedades de formatação de preenchimento. A formatação de célula tem prioridade maior que a formatação de linha, a formatação de linha tem prioridade maior que a de coluna, e a de coluna tem prioridade maior que a formatação de tabela completa.

Consequentemente, as propriedades de formatação de célula efetiva são usadas para desenhar a célula da tabela. O exemplo de código a seguir mostra como obter formatação de preenchimento efetiva para diferentes partes da tabela. Ele assume que a primeira forma no primeiro slide é uma [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/table/).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**O `getEffective` retorna uma captura instantânea?**

Nem sempre. Dados efetivos representam a formatação calculada após a aplicação da herança, mas alguns objetos de dados efetivos podem ser armazenados em cache internamente. Uma chamada subsequente a `getEffective` pode recalcular a formatação e atualizar o cache, portanto um objeto obtido anteriormente não deve ser tratado como uma captura duradoura.

**Quando devo ler as propriedades efetivas novamente?**

Chame `getEffective` novamente após alterar a formatação local, estilos pai, formatação de layout, formatação mestre ou valores padrão ao nível da apresentação. A próxima chamada reavalia a hierarquia de formatação e devolve o resultado efetivo atual.

**Alterar ou remover um slide de layout/mestre afeta propriedades efetivas que já foram obtidas?**

Sim, mas a alteração só será refletida na próxima chamada a `getEffective`. Se uma fonte de formatação pai for alterada ou removida, os dados efetivos obtidos anteriormente podem ficar desatualizados. Quando `getEffective` for chamado novamente, o Aspose.Slides reavalia a árvore de formatação e as fontes, cores, tamanhos ou outros valores resultantes podem mudar.

**Posso modificar valores através de objetos de dados efetivos?**

Não. Objetos de dados efetivos expõem valores calculados. Faça alterações nos objetos de formatação local e, em seguida, obtenha os valores efetivos novamente.

**O que acontece se uma propriedade não estiver definida no nível da forma, nem no layout/mestre, nem nas configurações globais?**

O valor efetivo é determinado pelo mecanismo padrão, que inclui valores padrão do PowerPoint e do Aspose.Slides. Esse valor resolvido passa a fazer parte dos dados efetivos atuais.

**A partir de um valor efetivo de fonte, posso saber qual nível forneceu o tamanho ou a família?**

Não diretamente. Dados efetivos retornam o valor final. Para descobrir a origem, verifique os valores locais na porção, parágrafo, quadro de texto e estilos de texto nos níveis de layout, mestre e apresentação para ver onde a primeira definição explícita aparece.

**Por que valores efetivos às vezes parecem idênticos aos locais?**

Porque o valor local acabou sendo final (nenhuma herança de nível superior foi necessária). Nesses casos, o valor efetivo corresponde ao valor local.

**Quando devo usar propriedades efetivas e quando devo trabalhar apenas com as locais?**

Use dados efetivos quando precisar do resultado “como renderizado” após toda a herança ser aplicada, como para alinhar cores, recuos ou tamanhos. Se precisar preservar esses valores independentemente de mudanças de formatação posteriores, copie as propriedades necessárias para seu próprio objeto. Se precisar alterar a formatação em um nível específico, modifique as propriedades locais e, se necessário, leia os dados efetivos novamente para verificar o resultado.