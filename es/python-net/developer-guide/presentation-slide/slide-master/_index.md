---
title: Gestionar maestros de diapositivas de presentación en Python
linktitle: Maestro de diapositiva
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
description: "Gestionar maestros de diapositivas en Aspose.Slides para Python a través de .NET: acceder, editar, clonar, comparar y eliminar diapositivas maestras en presentaciones de PowerPoint y OpenDocument."
---
## **Visión general**

Un **slide master** define los ajustes de diseño compartidos para un grupo de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, ajustes de tema y configuraciones de pie de página. En PowerPoint, editar un slide master es la forma habitual de mantener una presentación coherente sin tener que repetir el mismo formato en cada diapositiva.

Aspose.Slides for Python via .NET admite el mismo modelo. Una presentación puede contener una o más diapositivas master, y cada diapositiva master puede contener varias diapositivas de diseño. Las diapositivas normales normalmente no se refieren directamente a una diapositiva master. En su lugar, una diapositiva normal utiliza una diapositiva de diseño, y esa diapositiva de diseño pertenece a una diapositiva master.

La jerarquía es:

1. **Slide master** - define el diseño y tema compartidos.  
1. **Layout slide** - define una disposición específica de marcadores de posición y formato a nivel de diseño.  
1. **Normal slide** - contiene el contenido real de la presentación y utiliza una diapositiva de diseño.

![La jerarquía de diapositivas master, diapositivas de diseño y diapositivas normales](slide-master_2.jpg)

En Aspose.Slides, un slide master está representado por la clase [MasterSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslide/) . Todas las diapositivas master de una presentación están disponibles a través de la colección `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}
Cuando la misma propiedad se define en más de un nivel, gana el nivel más específico. Por ejemplo, si una diapositiva master y una diapositiva de diseño ambas definen un fondo, las diapositivas basadas en ese diseño utilizan el fondo del diseño. Para obtener más información sobre las diapositivas de diseño, consulte [Aplicar o cambiar diseños de diapositivas](/python-net/slide-layout/).
{{% /alert %}}

## **Acceder a los slide masters**

En PowerPoint, puede abrir la vista de Slide Master desde **View** > **Slide Master**.

![El comando Slide Master en la pestaña View de PowerPoint](slide-master_3.jpg)

En Aspose.Slides, utilice la colección `masters` para acceder a las diapositivas master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

También puede obtener la diapositiva master utilizada por una diapositiva normal a través de su diseño:

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

Una diapositiva master es un objeto similar a una diapositiva. Hereda el comportamiento común de diapositiva de la clase [BaseSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslide/) , por lo que expone muchas de las mismas propiedades de diapositiva que se usan en diapositivas normales y de diseño. Los miembros específicos del master se enumeran en la página API de [MasterSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslide/) .

Los miembros de diapositiva master más usados incluyen:

| Miembro | Propósito |
| --- | --- |
| `background` | Establece el fondo de la diapositiva a nivel de master. |
| `shapes` | Almacena las formas ubicadas en el master, como logotipos, marcos de imagen y texto compartido. |
| `layout_slides` | Almacena las diapositivas de diseño que pertenecen al master. |
| `theme_manager` | Proporciona acceso a las API del tema del master. |
| `header_footer_manager` | Controla encabezados, pies de página, fechas y números de diapositiva para el master y sus diseños secundarios. |
| `get_depending_slides` | Devuelve las diapositivas normales que dependen del master a través de sus diseños. |

## **Agregar una imagen a un slide master**

Cuando agrega una imagen a una diapositiva master, aparece en las diapositivas que utilizan diseños de ese master. Esto es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales repetidos.

El siguiente ejemplo agrega un logotipo a la primera diapositiva master:

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

Para obtener más información sobre marcos de imagen, consulte [Marco de imagen](/python-net/picture-frame/).

## **Trabajar con marcadores de posición**

Los marcadores de posición normalmente se definen en las diapositivas de diseño. La diapositiva master proporciona el estilo y tema compartidos que esos diseños heredan, mientras que cada diseño decide qué marcadores de posición están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcador de posición están disponibles en la vista Slide Master.

![El comando Insertar marcador de posición en la vista Slide Master de PowerPoint](slide-master_5.png)

Para agregar nuevos marcadores de posición con Aspose.Slides, trabaje con la diapositiva de diseño que pertenece al master:

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

También puede formatear las formas de marcador de posición que ya existen en una diapositiva master. El siguiente ejemplo encuentra el marcador de posición de título y aplica un relleno de degradado lineal:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Marcador de posición de título formateado heredado por diapositivas normales](slide-master_8.png)

Para obtener más opciones de formato de marcadores de posición y texto, consulte [Establecer texto de aviso en marcador de posición](/python-net/manage-placeholder/) y [Formato de texto](/python-net/text-formatting/).

## **Cambiar el fondo de un slide master**

Un fondo de master se hereda por los diseños y diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para la primera diapositiva master:

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

Para temas relacionados, vea [Fondo de presentación](/python-net/presentation-background/) y [Tema de presentación](/python-net/presentation-theme/).

## **Clonar un slide master a otra presentación**

Utilice el método `add_clone` de la clase [MasterSlideCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslidecollection/) para copiar una diapositiva master a otra presentación. El master copiado puede entonces ser usado por los diseños y diapositivas en la presentación de destino.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Si necesita clonar diapositivas normales junto con su master, consulte [Clonar diapositivas](/python-net/clone-slides/).

## **Agregar varios slide masters**

Una presentación puede contener varias diapositivas master. Esto es útil cuando diferentes secciones requieren una marca, estructura de página o ajustes de tema distintos.

![Comandos de PowerPoint para insertar y gestionar diapositivas master](slide-master_9.jpg)

El siguiente ejemplo clona el master predeterminado, le asigna al clon un fondo diferente, obtiene un diseño en blanco bajo ese master clonado y agrega una nueva diapositiva basada en ese diseño:

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

Las diapositivas master pueden compararse con el método `equals` heredado de la clase [BaseSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslide/) . La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otras configuraciones de diapositiva. No compara identificadores únicos, como los ID de diapositiva, ni valores dinámicos de marcadores de posición, como la fecha actual.

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

Para más información, consulte [Comparar diapositivas de presentación](/python-net/compare-slides/).

## **Establecer la vista Slide Master como vista predeterminada**

Utilice la propiedad `last_view` en las [ViewProperties](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/) de la presentación para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en la vista Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Para más configuraciones de vista, vea [Guardar presentación](/python-net/save-presentation/).

## **Eliminar diapositivas master no usadas**

A veces las presentaciones contienen diapositivas master que ya no son usadas por ninguna diapositiva normal. Eliminar masters no usados puede reducir el tamaño del archivo y simplificar el mantenimiento de la plantilla.

Utilice `remove_unused` para eliminar los masters no usados de la colección `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

También puede usar el método de bajo código `remove_unused_master_slides` de la clase [Compress](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/) :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un slide master y una diapositiva de diseño?**

Un slide master define los ajustes de diseño compartidos, como tema, fondo, formas comunes y estilos de texto. Una diapositiva de diseño pertenece a un slide master y define una disposición específica de marcadores de posición. Una diapositiva normal utiliza una diapositiva de diseño, por lo que hereda tanto del diseño como del master.

**¿Puede una presentación contener varios slide masters?**

Sí. Una presentación puede contener varios slide masters. Utilice varios masters cuando diferentes secciones necesiten sistemas visuales o marcas distintas.

**¿Debo agregar marcadores de posición a una diapositiva master o a una diapositiva de diseño?**

En la mayoría de los casos, agregue los marcadores de posición a las diapositivas de diseño. Coloque los elementos visuales compartidos y el formato compartido en la diapositiva master, y luego los marcadores de posición de contenido en los diseños que usarán las diapositivas normales.

**¿Puedo eliminar una diapositiva master que todavía está en uso?**

No. Una diapositiva master que tiene diapositivas dependientes no puede eliminarse de forma segura directamente. Primero mueva esas diapositivas a diseños bajo otro master, o utilice un método de limpieza de masters no usados que elimine solo los masters que no están en uso.