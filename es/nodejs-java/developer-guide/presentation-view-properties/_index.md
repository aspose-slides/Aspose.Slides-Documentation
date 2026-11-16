---
title: Recuperar y actualizar propiedades de vista de la presentación en JavaScript
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/nodejs-java/presentation-view-properties/
keywords:
- propiedades de vista
- vista normal
- contenido del esquema
- iconos del esquema
- ajuste del divisor vertical
- vista única
- estado de barra
- tamaño de dimensión
- ajuste automático
- zoom predeterminado
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Utilice Aspose.Slides para Node.js a través de Java para configurar el diseño de la vista normal, el zoom de diapositivas y notas, el espaciado de la cuadrícula y la visibilidad de los comentarios en presentaciones de PowerPoint."
---
## **Introducción**

En la vista normal de PowerPoint, la diapositiva aparece entre un panel lateral de miniaturas o un esquema y un panel de notas situado debajo. Aspose.Slides for Node.js a través de Java expone las preferencias de edición guardadas de la presentación mediante [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties). Estas incluyen la disposición de los paneles, los niveles de zoom, el espaciado de la cuadrícula y la visibilidad de los comentarios.

## **Acerca de NormalViewProperties**

Utilice [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) para acceder a la clase [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) controla si los iconos aparecen junto a los títulos de las diapositivas en el esquema. [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) permite que el panel lateral se ajuste a su estado minimizado cuando el usuario lo estrecha. [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) indica una preferencia por mostrar un solo panel en la ventana completa.

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) controla el divisor entre el panel lateral y la diapositiva. [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) controla el divisor situado sobre el panel de notas. Ambos aceptan un valor [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) de `Minimized`, `Maximized` o `Restored`.

## **Acerca de restaurar NormalViewProperties**

Cuando se restaura un divisor, [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) proporciona el tamaño guardado del panel lateral y [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) proporciona el tamaño guardado de la zona superior de la diapositiva. Ambos exponen [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/). Su método [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) acepta un porcentaje de 0 a 100, y [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) controla si el editor ajusta el tamaño cuando la ventana se redimensiona.

Este ejemplo actualiza una presentación existente. Restaura el divisor horizontal, establece el tamaño devuelto por [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) al 80 % con el ajuste automático habilitado, y maximiza el divisor vertical. También llama a [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) para mostrar iconos en la vista de esquema.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer el valor de zoom predeterminado**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) y [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) almacenan configuraciones de zoom independientes para el editor. Estas configuraciones no afectan las dimensiones de la diapositiva, la reproducción de la presentación o la resolución de exportación de imágenes.

Este ejemplo abre una presentación existente y llama a [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) para ajustar la diapositiva a la ventana de edición. Para la página de notas, desactiva el escalado automático y llama a [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) para establecer un zoom fijo del 80 %.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer el espaciado de la cuadrícula**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) establece la distancia entre las líneas de la cuadrícula de edición en toda la presentación. Recibe un valor positivo en puntos, con 72 puntos por pulgada. Este ejemplo muestra el espaciado actual en una presentación existente y guarda una cuadrícula de un cuarto de pulgada configurando el intervalo a 18 puntos.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La cuadrícula se repite a un intervalo fijo. [Drawing guides](/slides/es/nodejs-java/drawing-guides/) marcan posiciones horizontales o verticales individuales. Ambos son instrumentos de edición y aparecen solo en los editores que los muestran. Las presentaciones y las exportaciones a PDF, imágenes o SVG los omiten.

## **Mostrar u ocultar comentarios al abrir una presentación**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) almacena una preferencia que los editores compatibles utilizan al abrir la presentación. Para una presentación existente con comentarios, este ejemplo muestra la configuración actual y guarda una copia con los comentarios ocultos. También llama a [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) con [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) para que la copia se abra en vista de diapositiva.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ocultar los comentarios preserva su texto, autores, posiciones, respuestas y estados. Para modificar los propios comentarios, consulte [Presentation Comments](/slides/es/nodejs-java/presentation-comments/). Las configuraciones de exportación controlan si los comentarios aparecen en PDF, HTML, imágenes, notas o folletos.

## **Preguntas frecuentes**

**Why is the grid hidden when I reopen the presentation?**

La presentación almacena el intervalo de la cuadrícula. Para ver la cuadrícula, habilite la visibilidad de la cuadrícula en el editor.

**Does clearing drawing guides change the grid spacing?**

No. Añadir, mover o eliminar una guía no altera el intervalo de la cuadrícula.

**Can different sections of a presentation have different view settings?**

No. [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) se aplica a toda la presentación.

**Can I save different view settings for different users?**

El archivo almacena un único conjunto de propiedades de vista para todos. Un editor también puede aplicar las preferencias locales de un usuario.

**Can I save view settings in a template?**

Sí. Las presentaciones creadas a partir de la plantilla heredan sus configuraciones de vista guardadas.