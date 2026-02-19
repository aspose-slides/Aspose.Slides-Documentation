---
title: Diapositiva de diseño
type: docs
weight: 20
url: /es/nodejs-java/examples/elements/layout-slide/
keywords:
- ejemplo de código
- diapositiva de diseño
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Domina las diapositivas de diseño en Aspose.Slides para Node.js: elige, aplica y personaliza diseños de diapositivas, marcadores de posición y maestros con ejemplos para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo trabajar con **Layout Slides** en Aspose.Slides para Node.js a través de Java. Una diapositiva de diseño define el aspecto y el formato heredados por las diapositivas normales. Puede agregar, acceder, clonar y eliminar diapositivas de diseño, así como limpiar las que no se usan para reducir el tamaño de la presentación.

## **Agregar una diapositiva de diseño**

Puede crear una diapositiva de diseño personalizada para definir un formato reutilizable.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // Crear una diapositiva de diseño con un tipo de diseño en blanco y un nombre personalizado.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota 1:** Las diapositivas de diseño actúan como plantillas para diapositivas individuales. Puede definir elementos comunes una sola vez y reutilizarlos en muchas diapositivas.

> 💡 **Nota 2:** Cuando agrega formas o texto a una diapositiva de diseño, todas las diapositivas basadas en ese diseño mostrarán automáticamente ese contenido compartido.  
> La captura de pantalla a continuación muestra dos diapositivas, cada una heredando un cuadro de texto de la misma diapositiva de diseño.

![Diapositivas que heredan contenido de diseño](layout-slide-result.png)

## **Acceder a una diapositiva de diseño**

Las diapositivas de diseño pueden accederse por índice o por tipo de diseño (por ejemplo, `Blank`, `Title`, `SectionHeader`, etc.).

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Acceder a una diapositiva de diseño por índice.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Acceder a una diapositiva de diseño por tipo.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar una diapositiva de diseño**

Puede eliminar una diapositiva de diseño específica si ya no es necesaria.

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Obtener una diapositiva de diseño por tipo y eliminarla.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar diapositivas de diseño no utilizadas**

Para reducir el tamaño de la presentación, puede eliminar las diapositivas de diseño que no sean utilizadas por ninguna diapositiva normal.

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Elimina automáticamente todas las diapositivas de diseño que no estén referenciadas por ninguna diapositiva.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Clonar una diapositiva de diseño**

Puede duplicar una diapositiva de diseño utilizando el método `addClone`.

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Obtener una diapositiva de diseño existente por tipo.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // Clonar la diapositiva de diseño al final de la colección de diapositivas de diseño.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Resumen:** Las diapositivas de diseño son herramientas poderosas para gestionar un formato coherente en todas las diapositivas. Aspose.Slides permite un control total sobre la creación, gestión y optimización de las diapositivas de diseño.