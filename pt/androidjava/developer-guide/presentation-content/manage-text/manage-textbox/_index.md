---
title: Gerenciar Caixas de Texto em Apresentações no Android
linktitle: Gerenciar Caixa de Texto
type: docs
weight: 20
url: /pt/androidjava/manage-textbox/
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
- Android
- Java
- Aspose.Slides
description: "Criar, identificar, formatar e atualizar caixas de texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Android via Java."
---
## **Introdução**

No Aspose.Slides for Android via Java, o texto dos slides é armazenado em quadros de texto que pertencem a formas. A interface [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) representa a forma mais comum que contém texto e expõe seu texto através do método [IAutoShape.getTextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) .

{{% alert color="info" title="Nota" %}}

Todo AutoShape implementa [IShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/), mas nem toda forma é um AutoShape ou suporta um quadro de texto. Ao processar uma apresentação existente, verifique se uma forma implementa [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) antes de acessar seu texto.

{{% /alert %}}

## **Criar uma Caixa de Texto em um Slide**

Para criar uma caixa de texto, adicione um AutoShape a um slide, adicione texto ao seu quadro de texto e salve a apresentação. O exemplo a seguir cria uma caixa de texto retangular:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

As coordenadas e dimensões passadas para [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) são medidas em pontos. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) inicializa o quadro de texto com o texto fornecido.

## **Verificar se é uma Forma de Caixa de Texto**

Use o método [IAutoShape.isTextBox](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/#isTextBox--) para determinar se um AutoShape é tratado como uma caixa de texto. Isso é útil quando uma apresentação contém tanto AutoShapes que contêm texto quanto formas puramente gráficas.

![Uma caixa de texto e uma forma](istextbox.png)

O exemplo a seguir inspeciona cada AutoShape em uma apresentação:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Um AutoShape recém‑adicionado não é considerado uma caixa de texto até que contenha texto não vazio. Você pode fornecer esse texto através de [IAutoShape.addTextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) ou [ITextFrame.setText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-). Adicionar ou atribuir uma string vazia faz com que [IAutoShape.isTextBox](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/#isTextBox--) retorne `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

As duas primeiras chamadas imprimem `true`; as duas últimas imprimem `false`.

## **Encontrar a Forma que Possui um Quadro de Texto**

Código genérico de processamento de texto pode receber um [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) sem saber qual objeto da apresentação o contém. Use o método somente leitura [ITextFrame.getParentShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#getParentShape--) para navegar de volta ao seu [IShape] proprietário.

Para um quadro de texto de propriedade de um AutoShape ou outra forma que contém texto, [ITextFrame.getParentShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#getParentShape--) retorna o proprietário e [ITextFrame.getParentCell](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#getParentCell--) retorna `null`. Verifique o valor retornado antes de acessá‑lo. Para identificar proprietários de forma e de célula de tabela, incluindo formas associadas a nós de SmartArt, consulte [Search and Replace Text](/slides/pt/androidjava/search-and-replace-text/).

## **Adicionar Colunas a uma Caixa de Texto**

O método [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) divide o quadro de texto em colunas, enquanto [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) define o espaço entre as colunas em pontos. Ambas as configurações pertencem a [ITextFrameFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframeformat/) e podem ser alteradas através do quadro de texto de uma caixa de texto existente. O texto se reorganiza entre as colunas dentro da mesma forma; não continua para outra forma.

O exemplo a seguir cria uma caixa de texto de três colunas com 10 pontos entre as colunas, salva a apresentação e lê as configurações armazenadas de volta do arquivo de saída:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Extrair Texto de Colunas Individuais**

Use [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#splitTextByColumns--) para recuperar o texto atribuído a cada coluna visual em um quadro de texto existente. O método retorna uma string para cada coluna, na ordem de leitura baseada em colunas. Um quadro de texto de coluna única produz um array com um elemento, e uma coluna vazia é representada por uma string vazia. As strings contêm somente texto puro; a formatação ao nível de porções não é preservada.

Isso é útil quando você precisa:
- Extrair texto preservando sua ordem de leitura baseada em colunas.
- Indexar ou comparar o conteúdo de slides com múltiplas colunas.
- Exportar cada coluna para um arquivo separado, campo de banco de dados ou outro destino.
- Inspecionar como o texto é redistribuído após alterar a contagem de colunas com [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-), o espaçamento com [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), a fonte ou o tamanho do quadro de texto.

O método relata o texto distribuído dentro do [ITextFrame] atual; ele não faz fluxo automático de texto entre formas ou caixas de texto separadas. A distribuição de colunas pode depender das fontes disponíveis e de outras configurações de layout de texto, portanto, certifique‑se de que as fontes necessárias estejam disponíveis quando resultados consistentes forem importantes.

O exemplo a seguir carrega uma apresentação, encontra o primeiro AutoShape de múltiplas colunas com um quadro de texto, lê sua contagem de colunas configurada e grava o texto de cada coluna em um arquivo separado. Formas que não fornecem um quadro de texto são ignoradas.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Atualizar Texto**

Para atualizar texto em toda a apresentação, percorra os slides e as formas, selecione AutoShapes e então edite suas porções de texto. Trabalhar ao nível de porção permite alterar tanto o texto quanto a formatação de caracteres.

O exemplo a seguir substitui cada ocorrência de `years` por `months` no texto de AutoShapes e deixa cada porção afetada em negrito:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Esta travessia atualiza texto apenas em AutoShapes. Texto armazenado em tabelas, gráficos, SmartArt ou formas agrupadas requer a travessia das coleções próprias desses objetos.

## **Adicionar uma Caixa de Texto com um Hyperlink**

Um hyperlink pode ser atribuído a uma porção de texto específica, de modo que apenas esse texto funcione como link clicável. Use [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) para associar a porção a uma URL externa.

O exemplo a seguir cria texto com link e o salva em uma apresentação:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qual é a diferença entre uma caixa de texto e um placeholder de texto em um slide mestre ou de layout?**

Um [placeholder](/slides/pt/androidjava/manage-placeholder/) pode herdar sua posição e formatação de um [master slide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/masterslide/) ou de um [layout slide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/layoutslide/). Uma caixa de texto regular é uma forma independente no slide onde foi criada e não adquire o comportamento de placeholder quando o layout é alterado.

**Como posso substituir texto sem alterar o texto em gráficos, tabelas ou SmartArt?**

Limite a travessia às formas que implementam [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/), como demonstrado no exemplo Atualizar Texto. Gráficos, tabelas e SmartArt armazenam texto em seus próprios modelos de objeto, portanto não são modificados por esse loop.