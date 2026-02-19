---
title: Tinta
type: docs
weight: 180
url: /es/androidjava/examples/elements/ink/
keywords:
- ejemplo de código
- tinta
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Trabaje con tinta en Aspose.Slides para Android: dibuje, importe y edite trazos, ajuste el color y el ancho, y exporte a PPT, PPTX y ODP mediante ejemplos en Java."
---
Este artículo proporciona ejemplos de cómo acceder a formas de tinta existentes y eliminarlas usando **Aspose.Slides for Android via Java**.

> ❗ **Nota:** Las formas de tinta representan la entrada del usuario desde dispositivos especializados. Aspose.Slides no puede crear nuevos trazos de tinta programáticamente, pero puede leer y modificar tinta existente.

## **Acceso a tinta**

Lea las etiquetas de la primera forma de tinta en una diapositiva.

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
                // Utilice tagName según sea necesario.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar tinta**

Elimine una forma de tinta de la diapositiva si existe.

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