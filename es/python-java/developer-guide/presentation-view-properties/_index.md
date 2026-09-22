---
title: Recuperar y actualizar las propiedades de vista de la presentación en Python mediante Java
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
- estado de la barra
- tamaño de dimensión
- ajuste automático
- zoom predeterminado
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Descubra las propiedades de vista de Aspose.Slides para Python mediante Java para personalizar diapositivas PPT, PPTX y ODP: ajuste de diseños, niveles de zoom y configuraciones de visualización."
---
## **Introducción**

La vista normal consta de tres regiones de contenido: la propia diapositiva, una región de contenido lateral y una región de contenido inferior. Las propiedades de la vista normal describen la ubicación de estas regiones de contenido. Esta información permite a la aplicación guardar su estado de vista en el archivo, de modo que al volver a abrirlo la vista se encuentre en el mismo estado que cuando la presentación se guardó por última vez.

El método [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getNormalViewProperties) se ha añadido para proporcionar acceso a las propiedades de vista normal de una presentación.

Se han añadido las clases [NormalViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/) y [NormalViewRestoredProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewrestoredproperties/) y la enumeración [SplitterBarStateType](https://reference.aspose.com/slides/es/python-java/aspose.slides/splitterbarstatetype/).

## **Acerca de NormalViewProperties**

Representa las propiedades de vista normal.

Los métodos [getShowOutlineIcons](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) y [setShowOutlineIcons](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) especifican si la aplicación debe mostrar iconos al mostrar contenido del esquema en cualquiera de las regiones de contenido del modo de vista normal.

Los métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) y [setSnapVerticalSplitter](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) especifican si el divisor vertical debe ajustarse a un estado minimizado cuando la zona lateral es suficientemente pequeña.

Los métodos [getPreferSingleView](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) y [setPreferSingleView](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) especifican si el usuario prefiere ver una única región de contenido a pantalla completa en lugar de la vista normal estándar con tres regiones de contenido. Si está habilitado, la aplicación puede elegir mostrar una de las regiones de contenido en toda la ventana.

Los métodos [getVerticalBarState](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) y [getHorizontalBarState](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) especifican el estado en el que debe mostrarse la barra divisor horizontal o vertical. Una barra divisor horizontal separa la diapositiva de la zona de contenido situada debajo de la diapositiva; una barra divisor vertical separa la diapositiva de la zona de contenido lateral. Los valores posibles son: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/es/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/es/python-java/aspose.slides/splitterbarstatetype/#Maximized) y [SplitterBarStateType.Restored](https://reference.aspose.com/slides/es/python-java/aspose.slides/splitterbarstatetype/#Restored).

Los métodos [getRestoredLeft](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) y [getRestoredTop](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredTop) especifican el dimensionado de la zona de la diapositiva superior o lateral de la vista normal, cuando se aplica el valor [SplitterBarStateType.Restored](https://reference.aspose.com/slides/es/python-java/aspose.slides/splitterbarstatetype/#Restored) a [getVerticalBarState](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) y [getHorizontalBarState](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), respectivamente.

## **Acerca de la restauración de NormalViewProperties**

Especifica el dimensionado de la zona de la diapositiva (ancho cuando es hijo de [getRestoredTop](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredTop), alto cuando es hijo de [getRestoredLeft](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) de la vista normal, cuando la zona tiene un tamaño restaurado variable (ni minimizado ni maximizado).

El método [getDimensionSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) especifica el tamaño de la zona de la diapositiva (ancho cuando es hijo de [getRestoredTop](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredTop), alto cuando es hijo de [getRestoredLeft](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

El método [getAutoAdjust](https://reference.aspose.com/slides/es/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) especifica si el tamaño de la zona de contenido lateral debe compensar el nuevo tamaño al redimensionar la ventana que contiene la vista dentro de la aplicación.

El siguiente ejemplo muestra cómo acceder a [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getNormalViewProperties) para una presentación.

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
Aspose.Slides para Python a través de Java admite la configuración del valor de zoom predeterminado para que ya se aplique cuando se abra la presentación. Esto puede hacerse configurando el [ViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/) de una presentación. [getSlideViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getSlideViewProperties) así como [getNotesViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getNotesViewProperties) pueden configurarse mediante código. En este tema, veremos con un ejemplo cómo establecer las [View Properties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/) de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) en Aspose.Slides.
{{% /alert %}}

Para establecer las propiedades de vista, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Establezca las [View Properties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/) de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Guarde la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

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

## **Establecer el espaciado de la cuadrícula**

Utilice [Presentation.getViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getViewProperties) para acceder a la configuración de vista a nivel de presentación. Los métodos [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getGridSpacing) y [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#setGridSpacing) leen o cambian el intervalo de la cuadrícula de edición subyacente. Esta configuración se aplica a toda la presentación, no a una diapositiva individual. El espaciado de la cuadrícula se especifica en puntos, donde 72 puntos equivalen a una pulgada. Utilice un valor positivo, según lo requiera la documentación de la API.

El siguiente ejemplo abre un `demo.pptx` existente, muestra su espaciado de cuadrícula actual, establece un intervalo de un cuarto de pulgada y guarda el resultado.

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

La cuadrícula es diferente de los [drawing guides](/slides/es/python-java/drawing-guides/). El espaciado de la cuadrícula controla un intervalo regular, mientras que las guías de dibujo son líneas de alineación horizontales o verticales posicionadas individualmente. Añadir, mover o eliminar guías de dibujo no cambia el espaciado de la cuadrícula.

Tanto la cuadrícula como las guías de dibujo son ayudas de edición. No se renderizan como contenido de diapositiva en PDF, imágenes, SVG ni en una presentación. Guardar el espaciado de la cuadrícula no garantiza que un editor muestre la cuadrícula: su visibilidad también depende de las preferencias del visor o del editor.

## **Preguntas frecuentes**

**¿Por qué la cuadrícula no es visible después de volver a abrir la presentación?**

El archivo almacena el espaciado de la cuadrícula, pero el editor controla si la cuadrícula se muestra. Verifique la configuración de visibilidad de la cuadrícula del editor.

**¿Eliminar las guías de dibujo cambia el espaciado de la cuadrícula?**

No. Las guías de dibujo y el espaciado de la cuadrícula son configuraciones independientes. Eliminar las guías deja el intervalo de cuadrícula almacenado sin cambios.

**¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?**

Las [view settings](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getViewProperties) se definen a nivel de presentación ([Normal View](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), no por sección, por lo que un único conjunto de parámetros se aplica a todo el documento al abrirse.

**¿Puedo predefinir diferentes estados de vista para distintos usuarios?**

No. La configuración se almacena en el archivo y se comparte. Las aplicaciones visor pueden respetar las preferencias del usuario, pero el propio archivo contiene un único conjunto de propiedades de vista.

**¿Puedo preparar una plantilla con propiedades de vista predefinidas para que las nuevas presentaciones se abran de la misma manera?**

Sí. Dado que las [view properties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getViewProperties) se almacenan a nivel de presentación, puede incrustarlas en una plantilla y crear documentos nuevos a partir de ella con la misma configuración de vista inicial.