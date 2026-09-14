---
title: Gestionar maestros de diapositivas de presentación en Python vía Java
linktitle: Maestro de diapositiva
type: docs
weight: 70
url: /es/python-java/slide-master/
keywords:
- maestro de diapositiva
- diapositiva maestra
- diapositiva maestra PPT
- múltiples diapositivas maestras
- comparar diapositivas maestras
- fondo
- marcador de posición
- clonar diapositiva maestra
- copiar diapositiva maestra
- duplicar diapositiva maestra
- diapositiva maestra no utilizada
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Gestionar maestros de diapositivas en Aspose.Slides para Python vía Java: acceder, editar, clonar, comparar y eliminar diapositivas maestras en presentaciones PowerPoint y OpenDocument."
---
## **Resumen**

Un **maestro de diapositiva** define la configuración de diseño compartida para un conjunto de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, configuraciones de tema y de pie de página. En PowerPoint, editar un maestro de diapositiva es la forma habitual de mantener una presentación coherente sin repetir el mismo formato en cada diapositiva.

Aspose.Slides for Python via Java admite el mismo modelo. Una presentación puede contener una o más diapositivas maestras, y cada diapositiva maestra puede contener varias diapositivas de diseño. Las diapositivas normales no suelen referirse directamente a una diapositiva maestra. En su lugar, una diapositiva normal utiliza una diapositiva de diseño, y esa diapositiva de diseño pertenece a una diapositiva maestra.

La jerarquía es:

1. **Maestro de diapositiva** – define el diseño y tema compartidos.  
1. **Diapositiva de diseño** – define una disposición específica de marcadores de posición y formato a nivel de diseño.  
1. **Diapositiva normal** – contiene el contenido real de la presentación y usa una diapositiva de diseño.

![La jerarquía de diapositivas maestras, diapositivas de diseño y diapositivas normales](slide-master_2.jpg)

En Aspose.Slides, un maestro de diapositiva está representado por la clase [MasterSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/). Todas las diapositivas maestras de una presentación están disponibles a través de la colección [Presentation.getMasters](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getMasters), que se representa mediante [MasterSlideCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Herencia" %}}
Cuando la misma propiedad se define en más de un nivel, gana el nivel más específico. Por ejemplo, si una diapositiva maestra y una diapositiva de diseño definen un fondo, las diapositivas basadas en ese diseño usan el fondo del diseño. Para obtener más información sobre las diapositivas de diseño, consulte [Apply or Change Slide Layouts](/slides/es/python-java/slide-layout/).
{{% /alert %}}

## **Acceder a los maestros de diapositiva**

En PowerPoint, puede abrir la vista Maestro de diapositiva desde **Ver** > **Maestro de diapositiva**.

![El comando Maestro de diapositiva en la pestaña Ver de PowerPoint](slide-master_3.jpg)

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

También puede obtener la diapositiva maestra que usa una diapositiva normal a través de su diseño:

```python
import jpime
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

## **Qué contiene un maestro de diapositiva**

Una diapositiva maestra es un objeto similar a una diapositiva. Hereda de [BaseSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/), por lo que expone muchas de las mismas propiedades de diapositiva que se usan en diapositivas normales y de diseño. Los miembros específicos del maestro aparecen en la página de la API [MasterSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/).

Los miembros de maestro de diapositiva más usados incluyen:

| Miembro | Propósito |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#getBackground) | Establece el fondo a nivel de maestro. |
| [getShapes](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#getShapes) | Almacena las formas colocadas en el maestro, como logotipos, marcos de imagen y texto compartido. |
| [getLayoutSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/#getLayoutSlides) | Almacena las diapositivas de diseño que pertenecen al maestro. |
| [getThemeManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/#getThemeManager) | Proporciona acceso a las API del tema del maestro. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Controla encabezados, pies de página, fechas y números de diapositiva para el maestro y sus diseños hijos. |
| [getDependingSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/#getDependingSlides) | Devuelve las diapositivas normales que dependen del maestro a través de sus diseños. |

## **Agregar una imagen a un maestro de diapositiva**

Cuando agrega una imagen a una diapositiva maestra, aparece en las diapositivas que usan diseños de ese maestro. Es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales que se repiten.

El siguiente ejemplo agrega un logotipo a la primera diapositiva maestra:

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

Para obtener más información sobre marcos de imagen, consulte [Picture Frame](/slides/es/python-java/picture-frame/).

## **Trabajar con marcadores de posición**

Los marcadores de posición se definen normalmente en las diapositivas de diseño. La diapositiva maestra proporciona el estilo y tema compartidos que esos diseños heredan, mientras que cada diseño decide qué marcadores están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcador de posición están disponibles en la vista Maestro de diapositiva.

![El comando Insertar marcador de posición en la vista Maestro de diapositiva de PowerPoint](slide-master_5.png)

Para agregar nuevos marcadores de posición con Aspose.Slides, trabaje con la diapositiva de diseño que pertenece al maestro:

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

También puede formatear las formas de marcador de posición que ya existen en una diapositiva maestra. El siguiente ejemplo encuentra el marcador de posición de título y le aplica un relleno de degradado lineal:

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

Para más opciones de formato de marcadores y texto, consulte [Set Prompt Text in Placeholder](/slides/es/python-java/manage-placeholder/) y [Text Formatting](/slides/es/python-java/text-formatting/).

## **Cambiar el fondo de un maestro de diapositiva**

El fondo del maestro se hereda por los diseños y diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para la primera diapositiva maestra:

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

## **Clonar un maestro de diapositiva a otra presentación**

Use [MasterSlideCollection.addClone](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslidecollection/#addClone) para copiar una diapositiva maestra a otra presentación. El maestro copiado puede entonces ser usado por diseños y diapositivas en la presentación de destino.

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

Si necesita clonar diapositivas normales junto con su maestro, consulte [Clone Slides](/slides/es/python-java/clone-slides/).

## **Agregar varios maestros de diapositiva**

Una presentación puede contener múltiples diapositivas maestras. Es útil cuando diferentes secciones requieren distinta identidad corporativa, estructura de página o configuraciones de tema.

![Comandos de PowerPoint para insertar y gestionar maestros de diapositiva](slide-master_9.jpg)

El siguiente ejemplo clona el maestro predeterminado, le asigna un fondo diferente, crea un diseño bajo ese maestro clonado y añade una nueva diapositiva basada en ese diseño:

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

## **Comparar maestros de diapositiva**

Los maestros de diapositiva pueden compararse con el método [equals](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#equals) heredado de [BaseSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/). La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otras configuraciones de diapositiva. No compara identificadores únicos, como IDs de diapositiva, ni valores dinámicos de marcadores, como la fecha actual.

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

Para obtener más información, vea [Compare Presentation Slides](/slides/es/python-java/compare-slides/).

## **Establecer la vista Maestro de diapositiva como vista predeterminada**

Use el método [setLastView](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#setLastView) en [ViewProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/) para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en la vista Maestro de diapositiva:

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

Para más configuraciones de vista, consulte [Save Presentation](/slides/es/python-java/save-presentation/).

## **Eliminar maestros de diapositiva no utilizados**

A veces las presentaciones contienen maestros de diapositiva que ya no son usados por ninguna diapositiva normal. Eliminar los maestros no utilizados puede reducir el tamaño del archivo y simplificar el mantenimiento de la plantilla.

Use [removeUnused](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslidecollection/#removeUnused) para eliminar los maestros no utilizados de la colección [Presentation.getMasters](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getMasters):

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

**¿Cuál es la diferencia entre un maestro de diapositiva y una diapositiva de diseño?**

Un maestro de diapositiva define la configuración de diseño compartida como el tema, fondo, formas comunes y estilos de texto. Una diapositiva de diseño pertenece a un maestro y define una disposición específica de marcadores de posición. Una diapositiva normal usa una diapositiva de diseño, por lo que hereda tanto del diseño como del maestro.

**¿Puede una presentación contener varios maestros de diapositiva?**

Sí. Una presentación puede contener varios maestros de diapositiva. Use varios maestros cuando diferentes secciones necesiten distintos sistemas visuales o identidades corporativas.

**¿Debo agregar marcadores de posición a un maestro de diapositiva o a una diapositiva de diseño?**

En la mayoría de los casos, agregue los marcadores de posición a las diapositivas de diseño. Coloque los elementos visuales compartidos y el formato compartido en el maestro, y los marcadores de contenido en los diseños que usarán las diapositivas normales.

**¿Puedo eliminar un maestro de diapositiva que sigue en uso?**

No. Un maestro de diapositiva que tiene diapositivas dependientes no puede eliminarse de forma segura directamente. Primero mueva esas diapositivas a diseños bajo otro maestro, o utilice un método de limpieza de maestros no usados que elimine solo los maestros que no estén en uso.