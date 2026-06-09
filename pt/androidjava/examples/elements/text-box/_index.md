---
title: Caixa de Texto
type: docs
weight: 40
url: /pt/androidjava/examples/elements/text-box/
keywords:
- exemplo de código
- caixa de texto
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Trabalhe com caixas de texto no Aspose.Slides para Android: adicione, formate, alinhe, quebre linha, ajuste automático e estilize texto usando Java para apresentações PPT, PPTX e ODP."
---
No Aspose.Slides, uma **caixa de texto** é representada por um `AutoShape`. Quase qualquer forma pode conter texto, mas uma caixa de texto típica não tem preenchimento nem borda e exibe apenas texto.

Este guia explica como adicionar, acessar e remover caixas de texto programaticamente.

## **Adicionar uma Caixa de Texto**

Uma caixa de texto é simplesmente um `AutoShape` sem preenchimento nem borda e com algum texto formatado. Veja como criar uma:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Crie uma forma retangular (padrão preenchido com borda e sem texto).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Remova o preenchimento e a borda para que pareça uma caixa de texto típica.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Defina a formatação do texto.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Atribua o conteúdo de texto real.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota:** Qualquer `AutoShape` que contenha um `TextFrame` não vazio pode funcionar como uma caixa de texto.

## **Acessar Caixas de Texto por Conteúdo**

Para encontrar todas as caixas de texto que contenham uma palavra‑chave específica (ex.: "Slide"), itere pelas formas e verifique o texto delas:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // Apenas AutoShapes podem conter texto editável.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // Faça algo com a caixa de texto correspondente.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remover Caixas de Texto por Conteúdo**

Este exemplo encontra e exclui todas as caixas de texto no primeiro slide que contenham uma palavra‑chave específica:

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Dica:** Sempre crie uma cópia da coleção de formas antes de modificá‑la durante a iteração para evitar erros de modificação da coleção.