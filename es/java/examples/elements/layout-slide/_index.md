---
title: Diapositiva de diseño
type: docs
weight: 20
url: /es/java/examples/elements/layout-slide/
keywords:
- ejemplo de código
- diapositiva de diseño
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Domine las diapositivas de diseño en Aspose.Slides para Java: elija, aplique y personalice diseños de diapositivas, marcadores de posición y patrones maestros con ejemplos en Java para presentaciones PPT, PPTX y ODP."
---
Este artículo demuestra cómo trabajar con **Layout Slides** en Aspose.Slides for Java. Una diapositiva de diseño define el diseño y formato heredados por las diapositivas normales. Puede añadir, acceder, clonar y eliminar diapositivas de diseño, así como limpiar las que no se usan para reducir el tamaño de la presentación.

## **Añadir una diapositiva de diseño**

Puede crear una diapositiva de diseño personalizada para definir un formato reutilizable. Por ejemplo, podría añadir un cuadro de texto que aparezca en todas las diapositivas que utilizan este diseño.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Crear una diapositiva de diseño con un tipo de diseño vacío y un nombre personalizado.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Añadir un cuadro de texto a la diapositiva de diseño.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Añadir dos diapositivas usando este diseño; ambas heredarán el texto del diseño.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota 1:** Las diapositivas de diseño actúan como plantillas para diapositivas individuales. Puede definir elementos comunes una sola vez y reutilizarlos en muchas diapositivas.

> 💡 **Nota 2:** Cuando añade formas o texto a una diapositiva de diseño, todas las diapositivas basadas en ese diseño mostrarán automáticamente ese contenido compartido.  
> La captura de pantalla a continuación muestra dos diapositivas, cada una heredando un cuadro de texto de la misma diapositiva de diseño.

![Diapositivas que heredan contenido de diseño](layout-slide-result.png)

## **Acceder a una diapositiva de diseño**

Las diapositivas de diseño pueden accederse por índice o por tipo de diseño (p. ej., `Blank`, `Title`, `SectionHeader`, etc.).

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Acceder a una diapositiva de diseño por índice.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Acceder a una diapositiva de diseño por tipo.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar una diapositiva de diseño**

Puede eliminar una diapositiva de diseño específica si ya no es necesaria.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Obtener una diapositiva de diseño por tipo y eliminarla.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar diapositivas de diseño no usadas**

Para reducir el tamaño de la presentación, puede que desee eliminar las diapositivas de diseño que no son usadas por ninguna diapositiva normal.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Elimina automáticamente todas las diapositivas de diseño que no estén referenciadas por ninguna diapositiva.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Clonar una diapositiva de diseño**

Puede duplicar una diapositiva de diseño usando el método `addClone`.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Obtener una diapositiva de diseño existente por tipo.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Clonar la diapositiva de diseño al final de la colección de diapositivas de diseño.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Resumen:** Las diapositivas de diseño son herramientas potentes para gestionar un formato coherente en todas las diapositivas. Aspose.Slides permite un control total sobre la creación, gestión y optimización de diapositivas de diseño.