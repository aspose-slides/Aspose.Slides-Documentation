---
title: Tinta
type: docs
weight: 180
url: /pt/java/examples/elements/ink/
keywords:
- exemplo de código
- tinta
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Trabalhe com Tinta no Aspose.Slides para Java: desenhe, importe e edite traços, ajuste cor e largura, e exporte para PPT, PPTX e ODP usando exemplos em Java."
---
Este artigo fornece exemplos de acesso a formas de tinta existentes e sua remoção usando **Aspose.Slides for Java**.

> ❗ **Observação:** Formas de tinta representam a entrada do usuário de dispositivos especializados. Aspose.Slides não pode criar novos traços de tinta programaticamente, mas você pode ler e modificar tinta existente.

## **Acessar tinta**

Leia as tags da primeira forma de tinta em um slide.

```java
static void accessInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IShape shape = slide.getShapes().get_Item(0);
        if (shape instanceof IInk) {
            IInk inkShape = (IInk) shape;
            ITagCollection tags = inkShape.getCustomData().getTags();
            if (tags.size() > 0) {
                String tagName = tags.getNameByIndex(0);
                // Use tagName conforme necessário.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remover tinta**

Exclua uma forma de tinta do slide, se houver.

```java
static void removeInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IInk ink = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IInk) {
                ink = (IInk) shape;
                break;
            }
        }
        if (ink != null) {
            slide.getShapes().remove(ink);
        }
    } finally {
        presentation.dispose();
    }
}
```