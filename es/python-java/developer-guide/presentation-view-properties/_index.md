---
title: Recuperar y actualizar las propiedades de vista de la presentación en Python mediante Java
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/python-java/presentation-view-properties/
keywords:
- propiedades de vista
- vista normal
- contenido de esquema
- iconos de esquema
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
description: "Descubra las propiedades de vista de Aspose.Slides para Python mediante Java para personalizar diapositivas PPT, PPTX y ODP: ajuste diseños, niveles de zoom y configuraciones de visualización."
---
## **Introducción**

La vista normal consta de tres regiones de contenido: la diapositiva en sí, una región de contenido lateral y una región de contenido inferior. Las propiedades de la vista normal describen la posición de estas regiones de contenido. Esta información permite a la aplicación guardar su estado de vista en el archivo, de modo que al volver a abrirlo la vista se encuentre en el mismo estado que cuando se guardó por última vez la presentación.

Se ha añadido el método [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getNormalViewProperties) para proporcionar acceso a las propiedades de vista normal de una presentación.

Se han añadido las clases [NormalViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/) y [NormalViewRestoredProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewrestoredproperties/) y la enumeración [SplitterBarStateType](https://reference.aspose.com/slides/es/python-java/aspose.slides/splitterbarstatetype/).

## **Acerca de NormalViewProperties**

Representa las propiedades de la vista normal.

Los métodos [getShowOutlineIcons](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) y [setShowOutlineIcons](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) indican si la aplicación debe mostrar iconos al visualizar contenido de esquema en cualquiera de las regiones de contenido del modo de vista normal.

Los métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) y [setSnapVerticalSplitter](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) indican si el divisor vertical debe ajustarse a un estado minimizado cuando la región lateral es lo suficientemente pequeña.

Los métodos [getPreferSingleView](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) y [setPreferSingleView](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) indican si el usuario prefiere ver una única región de contenido ocupando toda la ventana en lugar de la vista normal estándar con tres regiones de contenido. Si está activado, la aplicación puede optar por mostrar una de las regiones de contenido en la ventana completa.

Los métodos [getVerticalBarState](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) y [getHorizontalBarState](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) especifican el estado en el que debe mostrarse la barra divisor horizontal o vertical. Una barra divisor horizontal separa la diapositiva de la región de contenido situada bajo la diapositiva; una barra divisor vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/es/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/es/python-java/aspose.slides/splitterbarstatetype/#Maximized) y [SplitterBarStateType.Restored](https://reference.aspose.com/slides/es/python-java/aspose.slides/splitterbarstatetype/#Restored).

Los métodos [getRestoredLeft](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) y [getRestoredTop](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredTop) especifican el dimensionado de la región superior o lateral de la diapositiva en la vista normal, cuando se aplica el valor [SplitterBarStateType.Restored](https://reference.aspose.com/slides/es/python-java/aspose.slides/splitterbarstatetype/#Restored) a [getVerticalBarState](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) y [getHorizontalBarState](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), respectivamente.

## **Acerca de la restauración de NormalViewProperties**

Especifica el dimensionado de la región de la diapositiva (anchura cuando es hijo de [getRestoredTop](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredTop), altura cuando es hijo de [getRestoredLeft](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado).

El método [getDimensionSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) especifica el tamaño de la región de la diapositiva (anchura cuando es hijo de [getRestoredTop](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredTop), altura cuando es hijo de [getRestoredLeft](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

El método [getAutoAdjust](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) indica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al redimensionar la ventana que contiene la vista dentro de la aplicación.

El ejemplo a continuación muestra cómo acceder a [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getNormalViewProperties) para una presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # Restaurar las propiedades de vista de la presentación.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer el valor de zoom predeterminado**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java admite la configuración del valor de zoom predeterminado para que ya esté aplicado cuando se abra la presentación. Esto puede hacerse estableciendo las [ViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/) de una presentación. Los métodos [getSlideViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getSlideViewProperties) así como [getNotesViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getNotesViewProperties) pueden configurarse programáticamente. En este tema veremos, con un ejemplo, cómo establecer las [View Properties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/) de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) en Aspose.Slides.
{{% /alert %}}

Para establecer las propiedades de vista, siga estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Establecer las [View Properties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/) de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Guardar la presentación como archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

En el ejemplo a continuación, establecemos el valor de zoom tanto para la vista de diapositiva como para la vista de notas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Establecer las propiedades de vista de la presentación.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Porcentaje de zoom para la vista de diapositiva.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Porcentaje de zoom para la vista de notas.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer el espaciado de la cuadrícula**

Utilice [Presentation.getViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getViewProperties) para acceder a la configuración de vista a nivel de presentación. Los métodos [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getGridSpacing) y [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#setGridSpacing) leen o modifican el intervalo de la cuadrícula de edición subyacente. Esta configuración se aplica a toda la presentación, no a una diapositiva individual. El espaciado de la cuadrícula se especifica en puntos, donde 72 puntos equivalen a una pulgada. Utilice un valor positivo, tal como lo requiere la documentación de la API.

El ejemplo siguiente abre un `demo.pptx` existente, muestra su espaciado de cuadrícula actual, establece un intervalo de un cuarto de pulgada y guarda el resultado.

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

La cuadrícula es distinta de los [drawing guides](/slides/es/python-java/drawing-guides/). El espaciado de la cuadrícula controla un intervalo regular, mientras que las guías de dibujo son líneas de alineación horizontales o verticales posicionadas individualmente. Añadir, mover o borrar guías de dibujo no modifica el espaciado de la cuadrícula.

Tanto la cuadrícula como las guías de dibujo son ayudas de edición. No se renderizan como contenido de diapositiva en PDF, imágenes, SVG o en una presentación de diapositivas. Almacenar el espaciado de la cuadrícula no garantiza que un editor muestre la cuadrícula: su visibilidad también depende de las preferencias del visor o del editor.

## **Mostrar u ocultar comentarios al abrir una presentación**

Utilice [Presentation.getViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getViewProperties) para acceder a la configuración de vista a nivel de presentación. Utilice [ViewProperties.getShowComments](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getShowComments) y [ViewProperties.setShowComments](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#setShowComments) para leer o cambiar la preferencia almacenada sobre si los comentarios deben mostrarse cuando la presentación se abre en PowerPoint u otro editor compatible.

Esta configuración sólo controla la preferencia de vista almacenada. No añade, elimina, edita ni resuelve comentarios. Ocultar los comentarios preserva su contenido, autores, posiciones, respuestas y estados. Consulte [Presentation Comments](/slides/es/python-java/presentation-comments/) para las operaciones que modifican los propios comentarios.

El ejemplo siguiente requiere un `comments.pptx` existente que contenga comentarios. Muestra la configuración de visibilidad actual, solicita que los comentarios se oculten y guarda un nuevo PPTX sin eliminar ningún comentario. También utiliza [ViewProperties.setLastView](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#setLastView) con [ViewType.SlideView](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewtype/#SlideView) para configurar la vista de edición inicial junto con la visibilidad de los comentarios.

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

Esta configuración no determina si los comentarios se incluyen en las exportaciones a PDF, HTML, imagen, notas o folletos. Configure las opciones específicas de exportación por separado.

## **Preguntas frecuentes**

**¿Por qué la cuadrícula no es visible después de volver a abrir la presentación?**

El archivo almacena el espaciado de la cuadrícula, pero el editor controla si la cuadrícula se muestra. Compruebe la configuración de visibilidad de la cuadrícula en el editor.

**¿Eliminar las guías de dibujo cambia el espaciado de la cuadrícula?**

No. Las guías de dibujo y el espaciado de la cuadrícula son configuraciones independientes. Eliminar las guías deja sin cambios el intervalo de la cuadrícula almacenado.

**¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?**

Las [configuraciones de vista](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getViewProperties) se definen a nivel de presentación ([Normal View](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), no por sección, por lo que un único conjunto de parámetros se aplica a todo el documento cuando se abre.

**¿Puedo predefinir diferentes estados de vista para distintos usuarios?**

No. Las configuraciones se almacenan en el archivo y se comparten. Las aplicaciones de visualización pueden respetar las preferencias del usuario, pero el archivo en sí contiene un único conjunto de propiedades de vista.

**¿Puedo crear una plantilla con propiedades de vista predefinidas para que las nuevas presentaciones se abran de la misma manera?**

Sí. Como las [propiedades de vista](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getViewProperties) se almacenan a nivel de presentación, puede incrustarlas en una plantilla y crear nuevos documentos a partir de ella con la misma configuración de vista inicial.