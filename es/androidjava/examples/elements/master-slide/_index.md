---
title: Diapositiva maestra
type: docs
weight: 30
url: /es/androidjava/examples/elements/master-slide/
keywords:
- ejemplo de código
- diapositiva maestra
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Explore ejemplos de diapositivas maestras de Aspose.Slides para Android: cree, edite y diseñe maestras, marcadores de posición y temas en PPT, PPTX y ODP con código Java claro."
---
Las diapositivas maestras forman el nivel superior de la jerarquía de herencia de diapositivas en PowerPoint. Una **diapositiva maestra** define elementos de diseño comunes como fondos, logotipos y formato de texto. Las **diapositivas de diseño** heredan de las diapositivas maestras, y las **diapositivas normales** heredan de las diapositivas de diseño.

Este artículo muestra cómo crear, modificar y gestionar diapositivas maestras mediante Aspose.Slides for Android a través de Java.

## **Agregar una diapositiva maestra**

Este ejemplo muestra cómo crear una nueva diapositiva maestra clonando la predeterminada. Luego agrega una pancarta con el nombre de la empresa a todas las diapositivas mediante la herencia de diseño.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Clonar la diapositiva maestra predeterminada.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Añadir una pancarta con el nombre de la empresa en la parte superior de la diapositiva maestra.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Asignar la nueva diapositiva maestra a una diapositiva de diseño.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Asignar la diapositiva de diseño a la primera diapositiva de la presentación.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota 1:** Las diapositivas maestras ofrecen una forma de aplicar una identidad corporativa consistente o elementos de diseño compartidos en todas las diapositivas. Cualquier cambio realizado en la maestra se reflejará automáticamente en las diapositivas de diseño y normales dependientes.

> 💡 **Nota 2:** Cualquier forma o formato añadido a una diapositiva maestra se hereda en las diapositivas de diseño y, a su vez, en todas las diapositivas normales que usan esos diseños.  
> La imagen a continuación ilustra cómo un cuadro de texto añadido en una diapositiva maestra se renderiza automáticamente en la diapositiva final.

![Ejemplo de herencia de maestra](master-slide-banner.png)

## **Acceder a una diapositiva maestra**

Puedes acceder a las diapositivas maestras mediante la colección master de la presentación. A continuación se muestra cómo recuperarlas y trabajar con ellas:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Cambiar el tipo de fondo.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar una diapositiva maestra**

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Eliminar una diapositiva maestra por índice.
        presentation.getMasters().removeAt(0);

        // Eliminar una diapositiva maestra por referencia.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar diapositivas maestras no utilizadas**

Algunas presentaciones contienen diapositivas maestras que no están en uso. Eliminar estas diapositivas puede ayudar a reducir el tamaño del archivo.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Eliminar todas las diapositivas maestras no utilizadas (incluso las marcadas como Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```