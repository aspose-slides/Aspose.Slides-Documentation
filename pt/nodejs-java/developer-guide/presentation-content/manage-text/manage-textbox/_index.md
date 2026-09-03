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
- adicionar hyperlink
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Criar, identificar, formatar e atualizar caixas de texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Node.js via Java."
---
## **Introdução**

No Aspose.Slides para Node.js via Java, o texto dos slides é armazenado em quadros de texto que pertencem a formas. A classe [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) representa a forma mais comum que contém texto e expõe seu texto através do método [AutoShape.getTextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Observação" %}}
Toda auto forma herda de [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/), mas nem toda forma é uma auto forma ou suporta um quadro de texto. Ao processar uma apresentação existente, verifique se uma forma é uma instância de [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) antes de acessar seu texto.
{{% /alert %}}

## **Criar uma Caixa de Texto em um Slide**

Para criar uma caixa de texto, adicione uma auto forma a um slide, adicione texto ao seu quadro de texto e salve a apresentação. O exemplo a seguir cria uma caixa de texto retangular:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

As coordenadas e dimensões passadas para [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/#addAutoShape) são medidas em pontos. [AutoShape.addTextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/#addTextFrame) inicializa o quadro de texto com o texto fornecido.

## **Verificar se uma Forma é Caixa de Texto**

Use o método [AutoShape.isTextBox](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/#isTextBox) para determinar se uma auto forma é tratada como caixa de texto. Isso é útil quando uma apresentação contém tanto auto formas que carregam texto quanto formas puramente gráficas.

![Uma caixa de texto e uma forma](istextbox.png)

O exemplo a seguir inspeciona cada auto forma em uma apresentação:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Uma auto forma recém‑adicionada não é considerada caixa de texto até que contenha texto não vazio. Você pode fornecer esse texto através de [AutoShape.addTextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/#addTextFrame) ou [TextFrame.setText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#setText). Adicionar ou atribuir uma string vazia faz com que [AutoShape.isTextBox](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/#isTextBox) retorne `false`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

## **Encontrar a Forma que Possui um Quadro de Texto**

Código genérico de processamento de texto pode receber um [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) sem saber qual objeto da apresentação o contém. Use o método de somente‑leitura [TextFrame.getParentShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#getParentShape) para navegar de volta ao seu [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/) proprietário.

Para um quadro de texto possuído por uma auto forma ou outra forma que contém texto, [TextFrame.getParentShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#getParentShape) devolve o proprietário e [TextFrame.getParentCell](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#getParentCell) devolve `null`. Verifique o valor retornado antes de acessá‑lo. Para identificar proprietários de forma e de célula de tabela, incluindo formas associadas a nós de SmartArt, veja [Search and Replace Text](/slides/pt/nodejs-java/search-and-replace-text/).

## **Adicionar Colunas a uma Caixa de Texto**

O método [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#setColumnCount) divide o quadro de texto em colunas, enquanto [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing) define o espaço entre colunas em pontos. Ambas as configurações pertencem a [TextFrameFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/) e podem ser alteradas através do quadro de texto de uma caixa de texto existente. O texto é redistribuído entre colunas dentro da mesma forma; ele não continua em outra forma.

O exemplo a seguir cria uma caixa de texto com três colunas e 10 pontos entre colunas, salva a apresentação e lê as configurações armazenadas do arquivo de saída:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Extrair Texto de Colunas Individuais**

Use [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#splitTextByColumns) para obter o texto atribuído a cada coluna visual em um quadro de texto existente. O método devolve uma string para cada coluna, na ordem de leitura baseada em colunas. Um quadro de texto de coluna única produz um array com um elemento, e uma coluna vazia é representada por uma string vazia. As strings contêm apenas texto puro; a formatação em nível de porção não é preservada.

Isso é útil quando você precisa:

- Extrair texto preservando sua ordem de leitura por colunas.
- Indexar ou comparar o conteúdo de slides com múltiplas colunas.
- Exportar cada coluna para um arquivo separado, campo de banco de dados ou outro destino.
- Inspecionar como o texto é redistribuído após alterar a contagem de colunas com [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#setColumnCount), o espaçamento com [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing), a fonte ou o tamanho do quadro de texto.

O método relata o texto distribuído dentro do [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) atual; ele não flui automaticamente texto entre formas ou caixas de texto separadas. A distribuição em colunas pode depender das fontes disponíveis e de outras configurações de layout de texto, portanto certifique‑se de que as fontes necessárias estejam disponíveis quando resultados consistentes forem importantes.

O exemplo a seguir carrega uma apresentação, encontra a primeira auto forma de múltiplas colunas com um quadro de texto, lê sua contagem de colunas configurada e grava o texto de cada coluna em um arquivo separado. Formas que não fornecem um quadro de texto são ignoradas.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Atualizar Texto**

Para atualizar texto em toda a apresentação, itere pelos slides e formas, selecione auto formas e então edite suas porções de texto. Trabalhar no nível de porção permite alterar tanto o texto quanto a formatação de caracteres.

O exemplo a seguir substitui cada ocorrência de `years` por `months` no texto de auto formas e torna cada porção afetada em negrito:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Adicionar uma Caixa de Texto com um Hyperlink**

Um hyperlink pode ser atribuído a uma porção de texto específica, de modo que apenas esse texto funcione como link clicável. Use [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) para associar a porção a uma URL externa.

O exemplo a seguir cria texto com hyperlink e o salva em uma apresentação:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qual é a diferença entre uma caixa de texto e um marcador de texto em um slide mestre ou de layout?**

Um [placeholder](/slides/pt/nodejs-java/manage-placeholder/) pode herdar sua posição e formatação de um [master slide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslide/) ou de um [layout slide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslide/). Uma caixa de texto regular é uma forma independente no slide onde foi criada e não adquire comportamento de placeholder quando o layout é alterado.

**Como posso substituir texto sem alterar o texto em gráficos, tabelas ou SmartArt?**

Limite a travessia às formas que são instâncias de [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/), como mostrado no exemplo Atualizar Texto. Gráficos, tabelas e SmartArt armazenam texto em seus próprios modelos de objeto, portanto não são modificados por esse loop.