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
- diapositiva maestra sin usar
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Gestiona los maestros de diapositivas en Aspose.Slides para Python vía .NET: accede, edita, clona, compara y elimina diapositivas maestras en presentaciones de PowerPoint y OpenDocument."
---
## **Descripción general**

Un **slide master** define los ajustes de diseño compartidos para un grupo de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, ajustes de tema y configuraciones de pie de página. En PowerPoint, editar un slide master es la forma habitual de mantener una presentación coherente sin repetir el mismo formato en cada diapositiva.

Aspose.Slides for Python via .NET admite el mismo modelo. Una presentación puede contener una o más diapositivas maestras, y cada diapositiva maestra puede contener varias diapositivas de diseño. Las diapositivas normales no suelen referirse directamente a una diapositiva maestra. En su lugar, una diapositiva normal utiliza una diapositiva de diseño, y esa diapositiva de diseño pertenece a una diapositiva maestra.

La jerarquía es:

1. **Slide master** - define el diseño y tema compartidos.  
1. **Layout slide** - define una disposición específica de marcadores de posición y formato a nivel de diseño.  
1. **Normal slide** - contiene el contenido real de la presentación y usa una diapositiva de diseño.

![La jerarquía de slide masters, layout slides y normal slides](slide-master_2.jpg)

En Aspose.Slides, un slide master está representado por la clase [MasterSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslide/). Todas las diapositivas maestras de una presentación están disponibles a través de la colección `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}
Cuando la misma propiedad se define en más de un nivel, gana el nivel más específico. Por ejemplo, si una slide master y una layout slide definen un fondo, las diapositivas basadas en ese diseño usan el fondo del diseño. Para obtener más información sobre las layout slides, consulte [Aplicar o cambiar diseños de diapositivas](/slides/es/python-net/slide-layout/).
{{% /alert %}}

## **Acceder a Slide Masters**

En PowerPoint, puede abrir la vista Slide Master desde **View** > **Slide Master**.

![El comando Slide Master en la pestaña View de PowerPoint](slide-master_3.jpg)

En Aspose.Slides, use la colección `masters` para acceder a las diapositivas maestras:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

También puede obtener la diapositiva maestra utilizada por una diapositiva normal a través de su diseño:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Qué contiene un Slide Master**

Una master slide es un objeto similar a una diapositiva. Hereda el comportamiento común de diapositiva de la clase [BaseSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslide/), por lo que expone muchas de las mismas propiedades de diapositiva usadas por diapositivas normales y de diseño. Los miembros específicos de la master slide se enumeran en la página API de [MasterSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslide/).

Los miembros de slide master más utilizados incluyen:

| Miembro | Propósito |
| --- | --- |
| `background` | Establece el fondo a nivel de master slide. |
| `shapes` | Almacena las formas colocadas en la master, como logotipos, marcos de imágenes y texto compartido. |
| `layout_slides` | Almacena las layout slides que pertenecen a la master. |
| `theme_manager` | Proporciona acceso a las API de tema de la master. |
| `header_footer_manager` | Controla encabezados, pies de página, fechas y números de diapositiva para la master y sus diseños hijos. |
| `get_depending_slides` | Devuelve las diapositivas normales que dependen de la master a través de sus diseños. |

## **Añadir una imagen a un Slide Master**

Cuando añade una imagen a una master slide, aparece en las diapositivas que usan diseños de esa master. Es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales repetidos.

El siguiente ejemplo añade un logotipo a la primera master slide:

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

Para obtener más información sobre los marcos de imágenes, consulte [Picture Frame](/slides/es/python-net/picture-frame/).

## **Trabajar con marcadores de posición**

Los marcadores de posición se definen normalmente en las layout slides. La master slide proporciona el estilo y tema compartidos que esos diseños heredan, mientras que cada diseño decide qué marcadores están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcador de posición están disponibles en la vista Slide Master.

![El comando Insert Placeholder en la vista Slide Master de PowerPoint](slide-master_5.png)

Para añadir nuevos marcadores de posición con Aspose.Slides, trabaje con la layout slide que pertenece a la master:

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

También puede dar formato a las formas de marcador de posición que ya existen en una master slide. El siguiente ejemplo busca el marcador de posición del título y le aplica un relleno de degradado lineal:

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

![Marcador de posición de título formateado heredado por diapositivas normales](slide-master_8.png)

Para más opciones de marcadores y formato de texto, consulte [Set Prompt Text in Placeholder](/slides/es/python-net/manage-placeholder/) y [Text Formatting](/slides/es/python-net/text-formatting/).

## **Cambiar el fondo de una Slide Master**

Un fondo de master se hereda por los diseños y diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para la primera master slide:

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

## **Clonar una Slide Master a otra presentación**

Utilice el método `add_clone` en la clase [MasterSlideCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslidecollection/) para copiar una master slide a otra presentación. La master copiada puede entonces ser usada por diseños y diapositivas en la presentación de destino.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Si necesita clonar diapositivas normales junto con su master, consulte [Clone Slides](/slides/es/python-net/clone-slides/).

## **Añadir varias Slide Masters**

Una presentación puede contener varias master slides. Esto es útil cuando diferentes secciones requieren diferentes marcas, estructuras de página o ajustes de tema.

![Comandos de PowerPoint para insertar y gestionar master slides](slide-master_9.jpg)

El siguiente ejemplo clona la master predeterminada, le asigna un fondo diferente, obtiene un diseño vacío bajo esa master clonada y añade una nueva diapositiva basada en ese diseño:

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

## **Comparar Slide Masters**

Las master slides pueden compararse con el método `equals` heredado de la clase [BaseSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslide/). La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otras configuraciones de diapositiva. No compara identificadores únicos, como IDs de diapositiva, ni valores dinámicos de marcadores, como la fecha actual.

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

Para más información, vea [Compare Presentation Slides](/slides/es/python-net/compare-slides/).

## **Establecer la vista Slide Master como vista predeterminada**

Utilice la propiedad `last_view` en el objeto [ViewProperties](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/) de la presentación para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en la vista Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Para más ajustes de vista, consulte [Save Presentation](/slides/es/python-net/save-presentation/).

## **Eliminar Slide Masters no utilizados**

A veces las presentaciones contienen master slides que ya no son usadas por ninguna diapositiva normal. Eliminar masters no utilizados puede reducir el tamaño del archivo y simplificar el mantenimiento de plantillas.

Use `remove_unused` para eliminar masters no usados de la colección `masters`:

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

### ¿Cuál es la diferencia entre una slide master y una layout slide?

Una slide master define ajustes de diseño compartidos como tema, fondo, formas comunes y estilos de texto. Una layout slide pertenece a una slide master y define una disposición específica de marcadores de posición. Una diapositiva normal usa una layout slide, por lo que hereda tanto del diseño como de la master.

### ¿Una presentación puede contener varias slide masters?

Sí. Una presentación puede contener varias slide masters. Use varias masters cuando diferentes secciones necesiten diferentes sistemas visuales o marcas.

### ¿Debo añadir marcadores de posición a una slide master o a una layout slide?

En la mayoría de los casos, añada marcadores de posición a las layout slides. Coloque los elementos visuales compartidos y el formato común en la slide master, y los marcadores de contenido en los diseños que usarán las diapositivas normales.

### ¿Puedo eliminar una slide master que todavía se está usando?

No. Una slide master que tiene diapositivas dependientes no puede eliminarse de forma segura directamente. Primero mueva esas diapositivas a diseños bajo otra master, o utilice un método de limpieza que elimine solo masters que no estén en uso.