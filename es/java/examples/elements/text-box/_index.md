---
title: Cuadro de texto
type: docs
weight: 40
url: /es/java/examples/elements/text-box/
keywords:
- ejemplo de código
- cuadro de texto
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Trabaja con cuadros de texto en Aspose.Slides para Java: agrega, formatea, alinea, ajusta, autoajusta y estiliza texto usando Java para presentaciones PPT, PPTX y ODP."
---
En Aspose.Slides, un **cuadro de texto** está representado por un `AutoShape`. Casi cualquier forma puede contener texto, pero un cuadro de texto típico no tiene relleno ni borde y sólo muestra texto.

Esta guía explica cómo agregar, acceder y eliminar cuadros de texto mediante código.

## **Agregar un cuadro de texto**

Un cuadro de texto es simplemente un `AutoShape` sin relleno ni borde y con algo de texto con formato. He aquí cómo crear uno:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Crear una forma rectangular (por defecto con relleno, borde y sin texto).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Eliminar el relleno y el borde para que parezca un cuadro de texto típico.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Establecer el formato del texto.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Asignar el contenido real del texto.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota:** Cualquier `AutoShape` que contenga un `TextFrame` no vacío puede funcionar como un cuadro de texto.

## **Acceder a los cuadros de texto por contenido**

Para encontrar todos los cuadros de texto que contienen una palabra clave específica (p. ej., "Slide"), recorra las formas y compruebe su texto:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // Solo los AutoShapes pueden contener texto editable.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // Haz algo con el cuadro de texto coincidente.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar los cuadros de texto por contenido**

Este ejemplo encuentra y elimina todos los cuadros de texto de la primera diapositiva que contienen una palabra clave específica:

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

> 💡 **Consejo:** Siempre cree una copia de la colección de formas antes de modificarla durante la iteración para evitar errores de modificación de la colección.