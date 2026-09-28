---
title: Administrar las diapositivas maestras de la presentación en Python mediante Java
linktitle: Diapositiva maestra
type: docs
weight: 70
url: /es/python-java/slide-master/
keywords:
- diapositiva maestra
- diapositiva maestra
- diapositiva maestra PPT
- varias diapositivas maestras
- comparar diapositivas maestras
- fondo
- marcador de posición
- clonar diapositiva maestra
- copiar diapositiva maestra
- duplicar diapositiva maestra
- diapositiva maestra sin usar
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Gestionar las diapositivas maestras en Aspose.Slides para Python mediante Java: acceder, editar, clonar, comparar y eliminar diapositivas maestras en presentaciones PowerPoint y OpenDocument."
---
## **Visión general**

Un **slide master** define los ajustes de diseño compartidos para un grupo de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, ajustes de tema y ajustes de pie de página. En PowerPoint, editar un slide master es la forma habitual de mantener una presentación coherente sin repetir el mismo formato en cada diapositiva.

Aspose.Slides para Python mediante Java admite el mismo modelo. Una presentación puede contener una o más diapositivas maestras, y cada diapositiva maestra puede contener varias diapositivas de diseño. Las diapositivas normales normalmente no hacen referencia directa a una diapositiva maestra. En su lugar, una diapositiva normal utiliza una diapositiva de diseño, y esa diapositiva de diseño pertenece a una diapositiva maestra.

La jerarquía es:

1. **Diapositiva maestra** – define el diseño y tema compartidos.  
1. **Diapositiva de diseño** – define una disposición específica de marcadores de posición y formato a nivel de diseño.  
1. **Diapositiva normal** – contiene el contenido real de la presentación y utiliza una diapositiva de diseño.

![La jerarquía de diapositivas maestras, diapositivas de diseño y diapositivas normales](slide-master_2.jpg)

En Aspose.Slides, una diapositiva maestra se representa mediante la clase [MasterSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/). Todas las diapositivas maestras de una presentación están disponibles a través de la colección [Presentation.getMasters](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getMasters), que se representa con [MasterSlideCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Cuando la misma propiedad se define en más de un nivel, el nivel más específico prevalece. Por ejemplo, si una diapositiva maestra y una diapositiva de diseño ambos definen un fondo, las diapositivas basadas en ese diseño usan el fondo del diseño. Para más información sobre las diapositivas de diseño, consulte [Apply or Change Slide Layouts](/slides/es/python-java/slide-layout/).
{{% /alert %}}

## **Acceder a diapositivas maestras**

En PowerPoint, puede abrir la vista de Diapositiva maestra desde **Vista** > **Diapositiva maestra**.

![El comando Diapositiva maestra en la pestaña Vista de PowerPoint](slide-master_3.jpg)

En Aspose.Slides, use la colección [Presentation.getMasters](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getMasters) para acceder a las diapositivas maestras:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

También puede obtener la diapositiva maestra utilizada por una diapositiva normal a través de su diseño:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **Qué contiene una diapositiva maestra**

Una diapositiva maestra es un objeto similar a una diapositiva. Hereda de [BaseSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/), por lo que expone muchas de las mismas propiedades de diapositiva que se usan en diapositivas normales y de diseño. Los miembros específicos de la maestra se enumeran en la página API de [MasterSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/).

Los miembros de diapositiva maestra más utilizados incluyen:

| Miembro | Propósito |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#getBackground) | Establece el fondo de la diapositiva a nivel de maestra. |
| [getShapes](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#getShapes) | Almacena las formas colocadas en la maestra, como logotipos, marcos de imágenes y texto compartido. |
| [getLayoutSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/#getLayoutSlides) | Almacena las diapositivas de diseño que pertenecen a la maestra. |
| [getThemeManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/#getThemeManager) | Proporciona acceso a las API de tema de la maestra. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Controla encabezados, pies de página, fechas y números de diapositiva para la maestra y sus diseños hijos. |
| [getDependingSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/#getDependingSlides) | Devuelve las diapositivas normales que dependen de la maestra a través de sus diseños. |

## **Añadir una imagen a una diapositiva maestra**

Al añadir una imagen a una diapositiva maestra, aparece en las diapositivas que usan diseños de esa maestra. Es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales repetidos.

El siguiente ejemplo añade un logotipo a la primera diapositiva maestra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para más información sobre marcos de imágenes, consulte [Picture Frame](/slides/es/python-java/picture-frame/).

## **Controlar la visibilidad de los gráficos de la diapositiva maestra**

Utilice [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#setShowMasterShapes) para ocultar los gráficos heredados de la maestra, como logotipos o formas decorativas, sin eliminarlos de la maestra. Pase `False` a [Slide.setShowMasterShapes](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#setShowMasterShapes) en la diapositiva que debe omitir esos gráficos y manténgalo `True` en las diapositivas que deben mostrarlos.

El siguiente ejemplo autónomo crea una banda decorativa azul en una maestra y dos diapositivas que usan el mismo diseño en blanco. La banda es visible en la primera diapositiva y está oculta en la segunda. No se requiere una presentación o imagen de entrada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    layout_slide.setShowMasterShapes(True)

    slide_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    band = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slide_height)
    band_color = Color(70, 130, 180)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(band_color)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    visible_slide = presentation.getSlides().get_Item(0)
    visible_slide.setLayoutSlide(layout_slide)
    visible_slide.getShapes().clear()

    hidden_slide = presentation.getSlides().addEmptySlide(layout_slide)

    visible_slide.setShowMasterShapes(True)
    hidden_slide.setShowMasterShapes(False)

    presentation.save("master-graphics.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El ejemplo usa el diseño **Blank** suministrado con una nueva presentación y elimina los marcadores de posición propios de la diapositiva inicial.

### **Elegir el alcance del ajuste**

Una diapositiva normal utiliza su maestra a través de [Slide.getLayoutSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getLayoutSlide) y [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutslide/#getMasterSlide). Establecer la propiedad en una diapositiva individual afecta solo a esa diapositiva. Pasar `False` a [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutslide/#setShowMasterShapes) oculta los gráficos de la maestra para las diapositivas que usan ese diseño compartido, incluso si su propia configuración es `True`. Para ocultar gráficos en una sola diapositiva, cambie la propiedad de la diapositiva y deje el diseño compartido sin modificar.

El ajuste no se admite como control de visibilidad en la propia diapositiva maestra. En una maestra, [getShowMasterShapes](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/#getShowMasterShapes) siempre devuelve `False`, y pasar `True` a [setShowMasterShapes](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/#setShowMasterShapes) genera una excepción. Aplíquelo a una diapositiva normal o a un diseño.

### **Distinguir los gráficos del fondo**

| Operación | Efecto |
| --- | --- |
| Ocultar los gráficos de la maestra | Controla la visibilidad de las formas heredadas de la maestra sin eliminarlas ni cambiar las propias formas de la diapositiva. |
| Cambiar el relleno de fondo de la diapositiva | Cambia el color, degradado o imagen de fondo. Los gráficos de la maestra son formas separadas y pueden seguir visibles sobre ese fondo. Consulte [Presentation Background](/slides/es/python-java/presentation-background/). |
| Eliminar una forma de la maestra | Elimina la forma fuente compartida, de modo que ya no está disponible para ninguna diapositiva que use esa maestra. |

## **Trabajar con marcadores de posición**

Los marcadores de posición se definen normalmente en las diapositivas de diseño. La diapositiva maestra proporciona el estilo y tema compartidos que heredan esos diseños, mientras que cada diseño decide qué marcadores de posición están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcador de posición están disponibles en la vista Diapositiva maestra.

![El comando Insertar marcador de posición en la vista Diapositiva maestra de PowerPoint](slide-master_5.png)

Para añadir nuevos marcadores de posición con Aspose.Slides, trabaje con la diapositiva de diseño que pertenece a la maestra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

También puede dar formato a las formas de marcador de posición que ya existen en una diapositiva maestra. El siguiente ejemplo encuentra el marcador de posición de título y le aplica un relleno de degradado lineal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Marcador de posición de título formateado heredado por diapositivas normales](slide-master_8.png)

Para más opciones de marcadores de posición y formato de texto, consulte [Set Prompt Text in Placeholder](/slides/es/python-java/manage-placeholder/) y [Text Formatting](/slides/es/python-java/text-formatting/).

## **Cambiar el fondo de una diapositiva maestra**

Un fondo de maestra se hereda por los diseños y diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para la primera diapositiva maestra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para temas relacionados, vea [Presentation Background](/slides/es/python-java/presentation-background/) y [Presentation Theme](/slides/es/python-java/presentation-theme/).

## **Clonar una diapositiva maestra a otra presentación**

Utilice [MasterSlideCollection.addClone](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslidecollection/#addClone) para copiar una diapositiva maestra a otra presentación. La maestra copiada puede entonces ser utilizada por diseños y diapositivas en la presentación de destino.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

Si necesita clonar diapositivas normales junto con su maestra, vea [Clone Slides](/slides/es/python-java/clone-slides/).

## **Añadir varias diapositivas maestras**

Una presentación puede contener varias diapositivas maestras. Esto es útil cuando diferentes secciones requieren distinta identidad visual, estructura de página o ajustes de tema.

![Comandos de PowerPoint para insertar y gestionar diapositivas maestras](slide-master_9.jpg)

El siguiente ejemplo clona la maestra predeterminada, le da a la copia un fondo diferente, crea un diseño bajo esa maestra clonada y añade una nueva diapositiva basada en ese diseño:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Comparar diapositivas maestras**

Las diapositivas maestras pueden compararse con el método [equals](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#equals) heredado de [BaseSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/). La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otros ajustes de la diapositiva. No compara identificadores únicos, como los IDs de diapositiva, ni valores dinámicos de marcadores de posición, como la fecha actual.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

Para más información, vea [Compare Presentation Slides](/slides/es/python-java/compare-slides/).

## **Establecer la vista Diapositiva maestra como vista predeterminada**

Utilice el método [setLastView](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#setLastView) en [ViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/) para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en la vista Diapositiva maestra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para más ajustes de vista, vea [Save Presentation](/slides/es/python-java/save-presentation/).

## **Eliminar diapositivas maestras no usadas**

A veces las presentaciones contienen diapositivas maestras que ya no son utilizadas por ninguna diapositiva normal. Eliminar las maestras no usadas puede reducir el tamaño del archivo y simplificar el mantenimiento de plantillas.

Use [removeUnused](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslidecollection/#removeUnused) para eliminar las maestras no usadas de la colección [Presentation.getMasters](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getMasters):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

También puede usar el método de bajo código [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/compress/#removeUnusedMasterSlides):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una diapositiva maestra y una diapositiva de diseño?**

Una diapositiva maestra define ajustes de diseño compartidos como tema, fondo, formas comunes y estilos de texto. Una diapositiva de diseño pertenece a una diapositiva maestra y define una disposición específica de marcadores de posición. Una diapositiva normal utiliza una diapositiva de diseño, por lo que hereda tanto del diseño como de la maestra.

**¿Puede una presentación contener varias diapositivas maestras?**

Sí. Una presentación puede contener varias diapositivas maestras. Utilice varias maestras cuando diferentes secciones necesiten diferentes sistemas visuales o marcas.

**¿Debo añadir marcadores de posición a una diapositiva maestra o a una diapositiva de diseño?**

En la mayoría de los casos, añada los marcadores de posición a las diapositivas de diseño. Coloque los elementos visuales compartidos y el formato común en la diapositiva maestra, y ponga los marcadores de contenido en los diseños que usarán las diapositivas normales.

**¿Puedo eliminar una diapositiva maestra que sigue estando en uso?**

No. Una diapositiva maestra que tiene diapositivas dependientes no puede eliminarse de forma segura directamente. Primero mueva esas diapositivas a diseños bajo otra maestra, o utilice un método de limpieza de maestras no usadas que elimine solo las maestras que no están en uso.