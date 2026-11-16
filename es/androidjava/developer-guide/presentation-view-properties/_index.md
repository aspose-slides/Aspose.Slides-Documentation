---
title: Recuperar y actualizar propiedades de vista de la presentación en Android
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/androidjava/presentation-view-properties/
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
- Android
- Java
- Aspose.Slides
description: "Utilice Aspose.Slides para Android mediante Java para configurar la distribución de la vista normal, el zoom de diapositivas y notas, el espaciado de la cuadrícula y la visibilidad de los comentarios en presentaciones de PowerPoint."
---
## **Introducción**

En la vista normal de PowerPoint, la diapositiva aparece entre un panel lateral de miniaturas o esquema y un panel de notas inferior. Aspose.Slides for Android mediante Java expone las preferencias de edición guardadas de la presentación a través de [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--). Estas incluyen la disposición de los paneles, los niveles de zoom, el espaciado de la cuadrícula y la visibilidad de los comentarios.

## **Sobre INormalViewProperties**

Utilice [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) para acceder a la interfaz [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) controla si aparecen iconos junto a los títulos de diapositiva en el esquema. [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) permite que el panel lateral se ajuste a su estado minimizado cuando el usuario lo reduce. [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) indica una preferencia por mostrar un solo panel en la ventana completa.

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) controla el divisor entre el panel lateral y la diapositiva. [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) controla el divisor encima del panel de notas. Ambos aceptan un valor de [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) de `Minimized`, `Maximized` o `Restored`.

## **Sobre la restauración de INormalViewProperties**

Cuando se restaura un divisor, [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) proporciona el tamaño guardado del panel lateral y [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) proporciona el tamaño guardado del área superior de la diapositiva. Ambos exponen [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/). Su método [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) acepta un porcentaje de 0 a 100, y [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) controla si el editor ajusta el tamaño cuando la ventana se redimensiona.

Este ejemplo actualiza una presentación existente. Restaura el divisor horizontal, establece el tamaño devuelto por [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) al 80% con el ajuste automático habilitado, y maximiza el divisor vertical. También llama a [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) para mostrar iconos en la vista de esquema.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer el valor de zoom predeterminado**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) y [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) almacenan configuraciones de zoom independientes para el editor. Estas configuraciones no afectan las dimensiones de la diapositiva, la reproducción de la presentación o la resolución de exportación de imágenes.

Este ejemplo abre una presentación existente y llama a [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) para ajustar la diapositiva a la ventana de edición. Para la página de notas, desactiva el escalado automático y llama a [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) para establecer un zoom fijo del 80%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer el espaciado de la cuadrícula**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) establece la distancia entre las líneas de la cuadrícula de edición en toda la presentación. Recibe un valor positivo en puntos, con 72 puntos por pulgada. Este ejemplo muestra el espaciado actual en una presentación existente y guarda una cuadrícula de un cuarto de pulgada estableciendo el intervalo a 18 puntos.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La cuadrícula se repite a intervalos fijos. [Guías de dibujo](/slides/es/androidjava/drawing-guides/) marcan posiciones horizontales o verticales individuales. Ambos son recursos de edición y aparecen solo en los editores que los muestran. Las presentaciones y las exportaciones a PDF, imágenes o SVG los omiten.

## **Mostrar u ocultar comentarios al abrir una presentación**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) almacena una preferencia que los editores compatibles usan al abrir la presentación. Para una presentación existente con comentarios, este ejemplo muestra la configuración actual y guarda una copia con los comentarios ocultos. También llama a [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) con [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) para que la copia se abra en la vista de diapositiva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ocultar los comentarios conserva su texto, autores, posiciones, respuestas y estados. Para cambiar los propios comentarios, consulte [Comentarios de la presentación](/slides/es/androidjava/presentation-comments/). La configuración de exportación controla si los comentarios aparecen en PDF, HTML, imágenes, notas o resúmenes.

## **Preguntas frecuentes**

**¿Por qué la cuadrícula está oculta cuando vuelvo a abrir la presentación?**

La presentación guarda el intervalo de la cuadrícula. Para verla, habilite la visibilidad de la cuadrícula en el editor.

**¿Eliminar las guías de dibujo cambia el espaciado de la cuadrícula?**

No. Añadir, mover o eliminar una guía no modifica el intervalo de la cuadrícula.

**¿Pueden diferentes secciones de una presentación tener distintas configuraciones de vista?**

No. [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) se aplica a toda la presentación.

**¿Puedo guardar distintas configuraciones de vista para diferentes usuarios?**

El archivo almacena un único conjunto de propiedades de vista para todos. Un editor también puede aplicar las preferencias locales de un usuario.

**¿Puedo guardar las configuraciones de vista en una plantilla?**

Sí. Las presentaciones creadas a partir de la plantilla heredan sus configuraciones de vista guardadas.