---
title: Recuperar y actualizar propiedades de vista de la presentación en Python mediante Java
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/python-java/presentation-view-properties/
keywords:
- propiedades de vista
- vista normal
- contenido del esquema
- iconos del esquema
- ajustar divisor vertical
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

La vista normal consta de tres regiones de contenido: la diapositiva en sí, una región de contenido lateral y una región de contenido inferior. Las propiedades de la vista normal describen la posición de estas regiones de contenido. Esta información permite que la aplicación guarde su estado de vista en el archivo, de modo que al volver a abrirse la vista esté en el mismo estado que cuando la presentación se guardó por última vez.

Se ha añadido el método [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getNormalViewProperties) para proporcionar acceso a las propiedades de la vista normal de una presentación.

Se han añadido las clases [NormalViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/) y [NormalViewRestoredProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewrestoredproperties/) y la enumeración [SplitterBarStateType](https://reference.aspose.com/slides/es/python-java/aspose.slides/splitterbarstatetype/).

## **Acerca de NormalViewProperties**

Representa las propiedades de la vista normal.

Los métodos [getShowOutlineIcons](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) y [setShowOutlineIcons](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) especifican si la aplicación debe mostrar iconos al mostrar contenido de esquema en cualquiera de las regiones de contenido del modo de vista normal.

Los métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) y [setSnapVerticalSplitter](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) especifican si el divisor vertical debe ajustarse a un estado minimizado cuando la región lateral es lo suficientemente pequeña.

Los métodos [getPreferSingleView](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) y [setPreferSingleView](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) especifican si el usuario prefiere ver una única región de contenido a pantalla completa en lugar de la vista normal estándar con tres regiones de contenido. Si está habilitado, la aplicación puede elegir mostrar una de las regiones de contenido en toda la ventana.

Los métodos [getVerticalBarState](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) y [getHorizontalBarState](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) especifican el estado en el que debe mostrarse la barra divisor horizontal o vertical. Una barra divisor horizontal separa la diapositiva de la región de contenido situada debajo de la diapositiva; una barra divisor vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/es/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/es/python-java/aspose.slides/splitterbarstatetype/#Maximized) y [SplitterBarStateType.Restored](https://reference.aspose.com/slides/es/python-java/aspose.slides/splitterbarstatetype/#Restored).

Los métodos [getRestoredLeft](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) y [getRestoredTop](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredTop) especifican el tamaño de la región de diapositiva superior o lateral de la vista normal, cuando el valor [SplitterBarStateType.Restored](https://reference.aspose.com/slides/es/python-java/aspose.slides/splitterbarstatetype/#Restored) se aplica a [getVerticalBarState](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) y [getHorizontalBarState](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), respectivamente.

## **Acerca de restaurar NormalViewProperties**

Especifica el tamaño de la región de diapositiva (ancho cuando es hijo de [getRestoredTop](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredTop), altura cuando es hijo de [getRestoredLeft](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado).

El método [getDimensionSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) especifica el tamaño de la región de diapositiva (ancho cuando es hijo de [getRestoredTop](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredTop), altura cuando es hijo de [getRestoredLeft](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

El método [getAutoAdjust](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al redimensionar la ventana que contiene la vista dentro de la aplicación.

El ejemplo siguiente muestra cómo acceder a [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getNormalViewProperties) para una presentación.

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
Aspose.Slides para Python vía Java admite la configuración del valor de zoom predeterminado para que ya se aplique cuando se abre la presentación. Esto puede hacerse estableciendo el [ViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/) de una presentación. Los métodos [getSlideViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getSlideViewProperties) y [getNotesViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getNotesViewProperties) pueden configurarse programáticamente. En este tema, veremos con un ejemplo cómo establecer las [View Properties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/) de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) en [Aspose.Slides](/slides/es/).
{{% /alert %}}

Para establecer las propiedades de vista, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Establezca las [View Properties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/) de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
3. Guarde la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

En el ejemplo siguiente, establecemos el valor de zoom tanto para la vista de diapositiva como para la vista de notas.

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

## **Preguntas frecuentes**

**¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?**

Las [View settings](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getViewProperties) se definen a nivel de presentación ([Normal View](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), no por sección, por lo que un único conjunto de parámetros se aplica a todo el documento cuando se abre.

**¿Puedo predefinir diferentes estados de vista para distintos usuarios?**

No. Las configuraciones se almacenan en el archivo y se comparten. Las aplicaciones visor pueden respetar las preferencias del usuario, pero el propio archivo contiene un único conjunto de propiedades de vista.

**¿Puedo preparar una plantilla con View Properties predefinidas para que las nuevas presentaciones se abran de la misma manera?**

Sí. Dado que las [view properties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getViewProperties) se almacenan a nivel de presentación, puede incorporarlas en una plantilla y crear nuevos documentos a partir de ella con la misma configuración de vista inicial.