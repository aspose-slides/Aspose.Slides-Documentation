---
title: Gerenciar caixas de texto em apresentações usando JavaScript
linktitle: Gerenciar caixa de texto
type: docs
weight: 20
url: /pt/nodejs-java/manage-textbox/
keywords:
- caixa de texto
- quadro de texto
- adicionar texto
- atualizar texto
- criar caixa de texto
- verificar caixa de texto
- adicionar coluna de texto
- adicionar hiperlink
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js facilita a criação, edição e clonagem de caixas de texto em arquivos PowerPoint e OpenDocument, aprimorando a automação de suas apresentações."
---
## **Introdução**

Os textos em slides normalmente existem em caixas de texto ou formas. Portanto, para adicionar um texto a um slide, você precisa adicionar uma caixa de texto e, em seguida, colocar algum texto dentro da caixa de texto. Aspose.Slides for Node.js via Java fornece a [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape) que permite adicionar uma forma contendo algum texto.

{{% alert title="Info" color="info" %}}

Aspose.Slides também fornece a [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape) que permite adicionar formas aos slides. No entanto, nem todas as formas adicionadas através da classe `Shape` podem conter texto. Mas as formas adicionadas através da classe [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape) podem conter texto.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Portanto, ao lidar com uma forma à qual você deseja adicionar texto, pode ser necessário verificar e confirmar que ela foi convertida através da classe `AutoShape`. Só então você poderá trabalhar com [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrame), que é uma propriedade da `AutoShape`. Consulte a seção [Update Text](https://docs.aspose.com/slides/pt/nodejs-java/manage-textbox/#update-text) nesta página.

{{% /alert %}}

## **Criar Caixa de Texto no Slide**

Para criar uma caixa de texto em um slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha uma referência para o primeiro slide na apresentação recém‑criada. 
3. Adicione um objeto [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape) com [ShapeType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) definido como `Rectangle` em uma posição especificada no slide e obtenha a referência para o objeto `AutoShape` recém‑adicionado.
4. Adicione a propriedade `TextFrame` ao objeto `AutoShape` que conterá um texto. No exemplo abaixo, adicionamos este texto: *Aspose TextBox*
5. Finalmente, grave o arquivo PPTX através do objeto `Presentation`. 

Este código JavaScript—uma implementação das etapas acima—mostra como adicionar texto a um slide:

```javascript
// Instancia a Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide na apresentação
    var sld = pres.getSlides().get_Item(0);
    // Adiciona um AutoShape com o tipo definido como Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Adiciona TextFrame ao Rectangle
    ashp.addTextFrame(" ");
    // Acessa o quadro de texto
    var txtFrame = ashp.getTextFrame();
    // Cria o objeto Paragraph para o quadro de texto
    var para = txtFrame.getParagraphs().get_Item(0);
    // Cria um objeto Portion para o parágrafo
    var portion = para.getPortions().get_Item(0);
    // Define o texto
    portion.setText("Aspose TextBox");
    // Salva a apresentação no disco
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Verificar Forma de Caixa de Texto**

Aspose.Slides fornece o método [isTextBox](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/#isTextBox) da classe [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) que permite examinar formas e identificar caixas de texto.

![Caixa de texto e forma](istextbox.png)

Este código JavaScript mostra como verificar se uma forma foi criada como caixa de texto:

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Observe que, se você simplesmente adicionar uma autoshape usando o método `addAutoShape` da classe [ShapeCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/), o método `isTextBox` da autoshape retornará `false`. No entanto, depois de adicionar texto à autoshape usando o método `addTextFrame` ou o método `setText`, a propriedade `isTextBox` retornará `true`.

```javascript
var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() retorna false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() retorna true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() retorna false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() retorna true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() retorna false
shape3.addTextFrame("");
// shape3.isTextBox() retorna false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() retorna false
shape4.getTextFrame().setText("");
// shape4.isTextBox() retorna false
```

## **Adicionar Coluna na Caixa de Texto**

Aspose.Slides fornece os métodos [setColumnCount](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) e [setColumnSpacing](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrameFormat) que permitem adicionar colunas a caixas de texto. Você pode especificar o número de colunas em uma caixa de texto e definir o espaçamento em pontos entre as colunas.

Este código em JavaScript demonstra a operação descrita: 

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide na apresentação
    var slide = pres.getSlides().get_Item(0);
    // Adiciona um AutoShape com o tipo definido como Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Adiciona TextFrame ao Rectangle
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // Obtém o formato de texto do TextFrame
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Define o número de colunas no TextFrame
    format.setColumnCount(3);
    // Define o espaçamento entre colunas
    format.setColumnSpacing(10);
    // Salva a apresentação
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adicionar Coluna no Quadro de Texto**

Aspose.Slides for Node.js via Java fornece o método [setColumnCount](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrameFormat) que permite adicionar colunas em quadros de texto. Por meio desta propriedade, você pode especificar o número desejado de colunas em um quadro de texto.

Este código JavaScript mostra como adicionar uma coluna dentro de um quadro de texto:

```javascript
var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Atualizar Texto**

Aspose.Slides permite mudar ou atualizar o texto contido em uma caixa de texto ou todos os textos contidos em uma apresentação. 

Este código JavaScript demonstra uma operação em que todos os textos de uma apresentação são atualizados ou alterados:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Verifica se a forma suporta quadro de texto (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Itera pelos parágrafos no quadro de texto
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Itera por cada porção no parágrafo
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Altera o texto
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Altera a formatação
                    }
                }
            }
        }
    }
    // Salva a apresentação modificada
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adicionar Caixa de Texto com Hyperlink** 

Você pode inserir um link dentro de uma caixa de texto. Quando a caixa de texto for clicada, os usuários serão direcionados para abrir o link. 

Para adicionar uma caixa de texto contendo um link, siga estas etapas:

1. Crie uma instância da classe `Presentation`. 
2. Obtenha uma referência para o primeiro slide na apresentação recém‑criada. 
3. Adicione um objeto `AutoShape` com `ShapeType` definido como `Rectangle` em uma posição especificada no slide e obtenha a referência do objeto `AutoShape` recém‑adicionado.
4. Adicione um `TextFrame` ao objeto `AutoShape` que contém *Aspose TextBox* como texto padrão. 
5. Instancie a classe `HyperlinkManager`. 
6. Atribua o objeto `HyperlinkManager` à propriedade [HyperlinkClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) associada à sua porção preferida do `TextFrame`.
7. Finalmente, grave o arquivo PPTX através do objeto `Presentation`. 

Este código JavaScript—uma implementação das etapas acima—mostra como adicionar uma caixa de texto com hyperlink a um slide:

```javascript
// Instancia uma classe Presentation que representa um PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide na apresentação
    var slide = pres.getSlides().get_Item(0);
    // Adiciona um objeto AutoShape com o tipo definido como Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Converte a forma para AutoShape
    var pptxAutoShape = shape;
    // Acessa a propriedade ITextFrame associada ao AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Adiciona texto ao quadro
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Define o Hyperlink para o texto da porção
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Salva a apresentação PPTX
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Qual é a diferença entre uma caixa de texto e um marcador de texto ao trabalhar com slides mestres?**

Um [placeholder](/slides/pt/nodejs-java/manage-placeholder/) herda estilo/posição do [master](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslide/) e pode ser sobrescrito em [layouts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslide/), enquanto uma caixa de texto comum é um objeto independente em um slide específico e não muda quando você troca de layout.

**Como posso realizar uma substituição em massa de texto em toda a apresentação sem alterar o texto dentro de gráficos, tabelas e SmartArt?**

Limite sua iteração a auto‑shapes que possuam quadros de texto e exclua objetos incorporados ([charts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/smartart/)) percorrendo suas coleções separadamente ou ignorando esses tipos de objeto.