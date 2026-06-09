---
title: Forma de Grupo
type: docs
weight: 170
url: /pt/java/examples/elements/group-shape/
keywords:
- exemplo de código
- forma de grupo
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Gerencie formas agrupadas no Aspose.Slides for Java: crie, aninhe, alinhe, reordene e estilize formas de grupo com exemplos Java em apresentações PPT, PPTX e ODP."
---
Exemplos de criação de grupos de formas, acesso a eles, desagrupamento e remoção usando **Aspose.Slides for Java**.

## **Adicionar um Grupo de Formas**

Crie um grupo contendo duas formas básicas.

```java
static void addGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar um Grupo de Formas**

Recupere a primeira forma de grupo de um slide.

```java
static void accessGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        IGroupShape firstGroup = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IGroupShape) {
                firstGroup = (IGroupShape) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remover um Grupo de Formas**

Exclua uma forma de grupo do slide.

```java
static void removeGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();

        slide.getShapes().remove(group);
    } finally {
        presentation.dispose();
    }
}
```

## **Desagrupar Formas**

Mova as formas para fora de um contêiner de grupo.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Mover forma para fora do grupo.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```