---
title: Hiperlink
type: docs
weight: 130
url: /pt/java/examples/elements/hyperlink/
keywords:
- exemplo de código
- hiperlink
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Adicione e gerencie hiperlinks no Aspose.Slides for Java: vincule texto, formas e imagens, defina destinos e ações para PPT, PPTX e ODP com exemplos em Java."
---
Este artigo demonstra como adicionar, acessar, remover e atualizar hiperlinks em formas usando **Aspose.Slides for Java**.

## **Adicionar um Hiperlink**

Crie uma forma retangular com um hiperlink apontando para um site externo.

```java
static void addHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar um Hiperlink**

Leia as informações do hiperlink a partir da parte de texto de uma forma.

```java
static void accessHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        IHyperlink hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Remover um Hiperlink**

Remova o hiperlink do texto de uma forma.

```java
static void removeHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        textPortion.getPortionFormat().setHyperlinkClick(null);
    } finally {
        presentation.dispose();
    }
}
```

## **Atualizar um Hiperlink**

Altere o destino de um hiperlink existente. Use `HyperlinkManager` para modificar o texto que já contém um hiperlink, o que imita como o PowerPoint atualiza hiperlinks com segurança.

```java
static void updateHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://old.example.com"));

        // Alterar um hiperlink dentro de texto existente deve ser feito via
        // HyperlinkManager ao invés de definir a propriedade diretamente.
        // Isso imita como o PowerPoint atualiza hiperlinks com segurança.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```