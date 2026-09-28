---
title: Gestionar maestros de diapositivas de presentación en Python
linktitle: Maestro de diapositivas
type: docs
weight: 80
url: /es/python-net/slide-master/
keywords:
- maestro de diapositiva
- diapositiva maestra
- diapositiva maestra PPT
- varias diapositivas maestras
- comparar diapositivas maestras
- fondo
- marcador de posición
- clonar diapositiva maestra
- copiar diapositiva maestra
- duplicar diapositiva maestra
- diapositiva maestra no usada
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Gestionar los maestros de diapositivas en Aspose.Slides para Python mediante .NET: acceder, editar, clonar, comparar y eliminar diapositivas maestras en presentaciones PowerPoint y OpenDocument."
---
## **Visión general**

Un **slide master** define ajustes de diseño compartidos para un grupo de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, ajustes de tema y ajustes de pie de página. En PowerPoint, editar un slide master es la forma habitual de mantener una presentación coherente sin repetir el mismo formato en cada diapositiva.

Aspose.Slides for Python via .NET soporta el mismo modelo. Una presentación puede contener una o más diapositivas maestras, y cada diapositiva maestra puede contener varias diapositivas de diseño. Las diapositivas normales normalmente no hacen referencia directa a una diapositiva maestra. En su lugar, una diapositiva normal usa una diapositiva de diseño, y esa diapositiva de diseño pertenece a una diapositiva maestra.

La jerarquía es:

1. **Slide master** – define el diseño y tema compartidos.  
1. **Layout slide** – define una disposición específica de marcadores de posición y formato a nivel de diseño.  
1. **Normal slide** – contiene el contenido real de la presentación y utiliza una diapositiva de diseño.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

En Aspose.Slides, un slide master está representado por la clase [MasterSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslide/). Todas las diapositivas maestras de una presentación están disponibles a través de la colección `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}

Cuando la misma propiedad se define en más de un nivel, gana el nivel más específico. Por ejemplo, si una diapositiva maestra y una diapositiva de diseño ambas definen un fondo, las diapositivas basadas en ese diseño usan el fondo del diseño. Para obtener más información sobre las diapositivas de diseño, consulte [Apply or Change Slide Layouts](/slides/es/python-net/slide-layout/).

{{% /alert %}}

## **Acceder a los slide masters**

En PowerPoint, puede abrir la vista Slide Master desde **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

En Aspose.Slides, utilice la colección `masters` para acceder a las diapositivas maestras:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

También puede obtener la diapositiva maestra usada por una diapositiva normal a través de su diseño:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Qué contiene un slide master**

Una diapositiva maestra es un objeto similar a una diapositiva. Hereda el comportamiento común de diapositivas de la clase [BaseSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslide/), por lo que expone muchas de las mismas propiedades de diapositiva usadas por diapositivas normales y de diseño. Los miembros específicos del maestro se enumeran en la página de la API [MasterSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslide/).

Los miembros de slide master más utilizados incluyen:

| Miembro | Propósito |
| --- | --- |
| `background` | Define el fondo a nivel de maestro. |
| `shapes` | Almacena las formas colocadas en el maestro, como logotipos, marcos de imágenes y texto compartido. |
| `layout_slides` | Almacena las diapositivas de diseño que pertenecen al maestro. |
| `theme_manager` | Proporciona acceso a las API de tema del maestro. |
| `header_footer_manager` | Controla encabezados, pies de página, fechas y números de diapositiva para el maestro y sus diseños hijos. |
| `get_depending_slides` | Devuelve las diapositivas normales que dependen del maestro a través de sus diseños. |

## **Añadir una imagen a un slide master**

Cuando añade una imagen a una diapositiva maestra, aparece en las diapositivas que usan diseños de ese maestro. Es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales repetidos.

El siguiente ejemplo añade un logotipo a la primera diapositiva maestra:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

Para obtener más información sobre marcos de imagen, consulte [Picture Frame](/slides/es/python-net/picture-frame/).

## **Controlar la visibilidad de los gráficos del maestro**

Utilice [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslide/show_master_shapes/) para ocultar los gráficos heredados del maestro, como logotipos o formas decorativas, sin eliminarlos del maestro. Establezca [Slide.show_master_shapes](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/show_master_shapes/) en `False` en la diapositiva que debe omitir esos gráficos y manténgalo en `True` en las diapositivas que deben mostrarlos.

El siguiente ejemplo autocontenido crea una banda decorativa azul en un maestro y dos diapositivas que usan el mismo diseño en blanco. La banda es visible en la primera diapositiva y está oculta en la segunda. No se necesita una presentación de entrada ni una imagen.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

El ejemplo utiliza el diseño **Blank** suministrado con una nueva presentación y elimina los marcadores de posición propios de la diapositiva inicial.

### **Elegir el alcance de la configuración**

Una diapositiva normal usa su maestro a través de [Slide.layout_slide](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/layout_slide/) y [LayoutSlide.master_slide](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/master_slide/). Establecer la propiedad en una diapositiva individual afecta solo a esa diapositiva. Establecer [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/show_master_shapes/) en `False` oculta los gráficos del maestro para todas las diapositivas que usan ese diseño compartido, aun cuando su propia configuración sea `True`. Para ocultar los gráficos en una sola diapositiva, cambie la propiedad de la diapositiva y deje el diseño compartido sin modificar.

La configuración no se admite como control de visibilidad en la propia diapositiva maestra. En un maestro siempre devuelve `False`, y asignar `True` genera una excepción. Aplíquelo a una diapositiva normal o a un diseño.

### **Distinguir los gráficos del fondo**

| Operación | Efecto |
| --- | --- |
| Ocultar los gráficos del maestro | Controla la visibilidad de las formas heredadas del maestro sin eliminarlas ni modificar las propias formas de la diapositiva. |
| Cambiar el relleno de fondo de la diapositiva | Cambia el color, degradado o imagen de fondo. Los gráficos del maestro son formas independientes y pueden permanecer visibles sobre ese fondo. Consulte [Presentation Background](/slides/es/python-net/presentation-background/). |
| Eliminar una forma del maestro | Elimina la forma fuente compartida, de modo que ya no esté disponible para ninguna diapositiva que use ese maestro. |

## **Trabajar con marcadores de posición**

Los marcadores de posición se definen normalmente en las diapositivas de diseño. La diapositiva maestra proporciona el estilo y tema compartidos que esos diseños heredan, mientras que cada diseño decide qué marcadores de posición están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcador de posición están disponibles en la vista Slide Master.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Para añadir nuevos marcadores de posición con Aspose.Slides, trabaje con la diapositiva de diseño que pertenece al maestro:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

También puede dar formato a las formas de marcador de posición que ya existen en una diapositiva maestra. El siguiente ejemplo encuentra el marcador de posición de título y le aplica un relleno degradado lineal:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Para más opciones de formato de marcadores de posición y texto, consulte [Set Prompt Text in Placeholder](/slides/es/python-net/manage-placeholder/) y [Text Formatting](/slides/es/python-net/text-formatting/).

## **Cambiar el fondo de un slide master**

Un fondo de maestro se hereda por los diseños y diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para la primera diapositiva maestra:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

Para temas relacionados, vea [Presentation Background](/slides/es/python-net/presentation-background/) y [Presentation Theme](/slides/es/python-net/presentation-theme/).

## **Clonar un slide master a otra presentación**

Utilice el método `add_clone` de la clase [MasterSlideCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslidecollection/) para copiar una diapositiva maestra a otra presentación. El maestro copiado puede entonces ser usado por diseños y diapositivas en la presentación de destino.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Si necesita clonar diapositivas normales junto con su maestro, consulte [Clone Slides](/slides/es/python-net/clone-slides/).

## **Añadir varios slide masters**

Una presentación puede contener múltiples diapositivas maestras. Esto es útil cuando diferentes secciones requieren distintas marcas, estructuras de página o ajustes de tema.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

El siguiente ejemplo clona el maestro predeterminado, le asigna un fondo diferente, obtiene un diseño en blanco bajo ese maestro clonado y añade una nueva diapositiva basada en ese diseño:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **Comparar slide masters**

Los slide masters pueden compararse con el método `equals` heredado de la clase [BaseSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslide/). La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otros ajustes de la diapositiva. No compara identificadores únicos, como IDs de diapositiva, ni valores dinámicos de marcadores de posición, como la fecha actual.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

Para más información, consulte [Compare Presentation Slides](/slides/es/python-net/compare-slides/).

## **Establecer la vista Slide Master como vista predeterminada**

Utilice la propiedad `last_view` en las [ViewProperties](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/) de la presentación para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en la vista Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Para más ajustes de vista, vea [Save Presentation](/slides/es/python-net/save-presentation/).

## **Eliminar slide masters no usados**

A veces las presentaciones contienen slide masters que ya no son usados por ninguna diapositiva normal. Eliminar los maestros no usados puede reducir el tamaño del archivo y simplificar el mantenimiento de la plantilla.

Use `remove_unused` para eliminar los maestros no usados de la colección `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

También puede usar el método de bajo código `remove_unused_master_slides` de la clase [Compress](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/):

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**¿Cuál es la diferencia entre un slide master y una layout slide?**

Un slide master define ajustes de diseño compartidos como tema, fondo, formas comunes y estilos de texto. Una layout slide pertenece a un slide master y define una disposición específica de marcadores de posición. Una diapositiva normal usa una layout slide, por lo que hereda tanto del diseño como del maestro.

**¿Puede una presentación contener varios slide masters?**

Sí. Una presentación puede contener varios slide masters. Utilice varios maestros cuando diferentes secciones necesiten sistemas visuales o marcas diferentes.

**¿Debo añadir marcadores de posición a un slide master o a una layout slide?**

En la mayoría de los casos, añada marcadores de posición a las layout slides. Coloque los elementos visuales y el formato compartido en el slide master y los marcadores de posición de contenido en los diseños que usarán las diapositivas normales.

**¿Puedo eliminar un slide master que sigue siendo usado?**

No. Un slide master que tiene diapositivas dependientes no puede eliminarse de forma segura directamente. Primero mueva esas diapositivas a diseños bajo otro maestro, o utilice un método de limpieza de maestros no usados que elimine solo los maestros que no están en uso.