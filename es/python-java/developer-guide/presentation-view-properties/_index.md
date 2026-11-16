---
title: Recuperar y actualizar las propiedades de vista de la presentación en Python vía Java
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/python-java/presentation-view-properties/
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
- Python
- Java
- Aspose.Slides
description: "Utilice Aspose.Slides for Python via Java para configurar la disposición de la vista normal, el zoom de diapositiva y notas, el espaciado de la cuadrícula y la visibilidad de los comentarios en presentaciones de PowerPoint."
---
## **Introducción**

En la vista normal de PowerPoint, la diapositiva aparece entre un panel lateral para miniaturas o un esquema y un panel de notas debajo. Aspose.Slides for Python via Java expone las preferencias de edición guardadas de la presentación mediante [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties). Estas incluyen la disposición de los paneles, los niveles de zoom, el espaciado de la cuadrícula y la visibilidad de los comentarios.

## **Acerca de NormalViewProperties**

Utilice [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) para acceder a la clase [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) controla si aparecen iconos junto a los títulos de diapositiva en el esquema. [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) permite que el panel lateral se ajuste a su estado minimizado cuando el usuario lo reduce. [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) indica una preferencia por mostrar un solo panel en la ventana completa.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) controla el divisor entre el panel lateral y la diapositiva. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) controla el divisor sobre el panel de notas. Ambos aceptan un valor de [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) de `Minimized`, `Maximized` o `Restored`.

## **Acerca de restaurar NormalViewProperties**

Cuando se restaura un divisor, [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) proporciona el tamaño guardado del panel lateral y [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) proporciona el tamaño guardado del área superior de la diapositiva. Ambos devuelven una instancia de [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/). Su método [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) acepta un porcentaje de 0 a 100, y [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) controla si el editor ajusta el tamaño cuando se redimensiona la ventana.

Este ejemplo actualiza una presentación existente. Restaura el divisor horizontal, establece el tamaño devuelto por [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) al 80 % con ajuste automático activado y maximiza el divisor vertical. También llama a [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) para mostrar iconos en la vista de esquema.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer el valor predeterminado de zoom**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) y [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) almacenan configuraciones de zoom independientes para el editor. Estas configuraciones no afectan las dimensiones de la diapositiva, la reproducción de la presentación o la resolución de exportación de imágenes.

Este ejemplo abre una presentación existente y llama a [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) para ajustar la diapositiva a la ventana de edición. Para la página de notas, desactiva el escalado automático y llama a [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) para establecer un zoom fijo del 80 %.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer el espaciado de la cuadrícula**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) define la distancia entre las líneas de la cuadrícula de edición en toda la presentación. Recibe un valor positivo en puntos, con 72 puntos por pulgada. Este ejemplo muestra el espaciado actual en una presentación existente y guarda una cuadrícula de un cuarto de pulgada estableciendo el intervalo a 18 puntos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La cuadrícula se repite a intervalos fijos. [Guías de dibujo](/slides/es/python-java/drawing-guides/) marcan posiciones horizontales o verticales individuales. Ambas son ayudas de edición y solo aparecen en los editores que las muestran. Las presentaciones y las exportaciones a PDF, imágenes o SVG no las incluyen.

## **Mostrar u ocultar comentarios al abrir una presentación**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) almacena una preferencia que los editores compatibles utilizan al abrir la presentación. Para una presentación existente con comentarios, este ejemplo muestra la configuración actual y guarda una copia con los comentarios ocultos. También llama a [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) con [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) para que la copia se abra en vista de diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ocultar los comentarios conserva su texto, autores, posiciones, respuestas y estados. Para modificar los propios comentarios, consulte [Presentation Comments](/slides/es/python-java/presentation-comments/). Las configuraciones de exportación controlan si los comentarios aparecen en PDF, HTML, imágenes, notas o folletos.

## **Preguntas frecuentes**

**¿Por qué la cuadrícula está oculta al volver a abrir la presentación?**

La presentación almacena el intervalo de la cuadrícula. Para verla, habilite la visibilidad de la cuadrícula en el editor.

**¿Eliminar las guías de dibujo cambia el espaciado de la cuadrícula?**

No. Añadir, mover o eliminar una guía no modifica el intervalo de la cuadrícula.

**¿Pueden diferentes secciones de una presentación tener distintas configuraciones de vista?**

No. [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) se aplica a toda la presentación.

**¿Puedo guardar distintas configuraciones de vista para diferentes usuarios?**

El archivo almacena un solo conjunto de propiedades de vista para todos. Un editor también puede aplicar las preferencias locales del usuario.

**¿Puedo guardar configuraciones de vista en una plantilla?**

Sí. Las presentaciones creadas a partir de la plantilla heredan sus configuraciones de vista guardadas.