---
title: Diapositiva maestra
type: docs
weight: 30
url: /es/nodejs-java/examples/elements/master-slide/
keywords:
- ejemplo de código
- diapositiva maestra
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Explore los ejemplos de diapositivas maestras de Aspose.Slides para Node.js: cree, edite y estilice maestros, marcadores de posición y temas en PPT, PPTX y ODP con código claro."
---
Las diapositivas maestras forman el nivel superior de la jerarquía de herencia de diapositivas en PowerPoint. Una **diapositiva maestra** define elementos de diseño comunes como fondos, logotipos y formato de texto. Las **diapositivas de diseño** heredan de las diapositivas maestras, y las **diapositivas normales** heredan de las diapositivas de diseño.

Este artículo muestra cómo crear, modificar y gestionar diapositivas maestras utilizando Aspose.Slides para Node.js a través de Java.

## **Agregar una diapositiva maestra**

Este ejemplo muestra cómo crear una nueva diapositiva maestra clonando la predeterminada. Luego agrega una pancarta con el nombre de la empresa a todas las diapositivas mediante la herencia de diseño.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Clonar la diapositiva maestra predeterminada.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // Añadir una pancarta con el nombre de la empresa en la parte superior de la diapositiva maestra.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // Asignar la nueva diapositiva maestra a una diapositiva de diseño.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Asignar la diapositiva de diseño a la primera diapositiva de la presentación.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota 1:** Las diapositivas maestras ofrecen una forma de aplicar una coherencia de marca o elementos de diseño compartidos en todas las diapositivas. Cualquier cambio realizado en la maestra se reflejará automáticamente en las diapositivas de diseño y normales dependientes.
> 
> 💡 **Nota 2:** Todas las formas o formatos añadidos a una diapositiva maestra se heredan por las diapositivas de diseño y, a su vez, por todas las diapositivas normales que utilizan esos diseños.
> 
> La imagen a continuación ilustra cómo un cuadro de texto añadido en una diapositiva maestra se renderiza automáticamente en la diapositiva final.

![Ejemplo de herencia de maestra](master-slide-banner.png)

## **Acceder a una diapositiva maestra**

Puedes acceder a las diapositivas maestras utilizando la colección maestra de la presentación. A continuación se muestra cómo recuperarlas y trabajar con ellas:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // Cambiar el tipo de fondo.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar una diapositiva maestra**

Las diapositivas maestras pueden eliminarse por índice o por referencia.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Eliminar una diapositiva maestra por índice.
        presentation.getMasters().removeAt(0);

        // Eliminar una diapositiva maestra por referencia.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar diapositivas maestras no usadas**

Algunas presentaciones contienen diapositivas maestras que no se utilizan. Eliminar estas diapositivas puede ayudar a reducir el tamaño del archivo.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Eliminar todas las diapositivas maestras no usadas (incluso las marcadas como Preserve).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```