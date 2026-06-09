---
title: Forma de Grupo
type: docs
weight: 170
url: /pt/nodejs-java/examples/elements/group-shape/
keywords:
- exemplo de código
- forma de grupo
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie formas agrupadas no Aspose.Slides para Node.js: crie, aninhe, alinhe, reordene e estilize formas de grupo com exemplos em apresentações PPT, PPTX e ODP."
---
Exemplos de criação de grupos de formas, acesso a eles, desagrupamento e remoção usando **Aspose.Slides for Node.js via Java**.

## **Adicionar um Grupo de Formas**

Crie um grupo contendo duas formas básicas.

```js
function addGroupShape() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 60, 0, 50, 50);

        presentation.save("group_shape.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar um Grupo de Formas**

Recupere o primeiro grupo de formas de um slide.

```js
function accessGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstGroup = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                firstGroup = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remover um Grupo de Formas**

Exclua um grupo de formas do slide.

```js
function removeGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assumindo que a primeira forma é um grupo de formas.
        slide.getShapes().removeAt(0);

        presentation.save("group_shape_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Desagrupar Formas**

Mova as formas para fora de um contêiner de grupo.

```js
function ungroupShapes() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assumindo que a primeira forma é um grupo de formas.
        let group = slide.getShapes().get_Item(0);

        for (let i = 0; i < group.getShapes().size(); i++) {
            let shape = group.getShapes().get_Item(i);
            // Clone cada forma do grupo para o slide.
            slide.getShapes().addClone(shape);
        }

        slide.getShapes().remove(group);

        presentation.save("group_shape_ungrouped.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```