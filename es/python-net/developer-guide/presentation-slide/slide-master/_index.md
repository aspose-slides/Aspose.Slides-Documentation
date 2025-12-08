---
title: Administrar Slide Masters de PowerPoint en Python
linktitle: Master de diapositivas
type: docs
weight: 80
url: /es/python-net/slide-master/
keywords:
- master de diapositiva
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
- Python
- Aspose.Slides
description: "Automatiza los masters de diapositivas de PowerPoint y OpenDocument con Aspose.Slides para Python a través de .NET para maximizar la eficiencia del desarrollo. Una guía completa para principiantes y usuarios avanzados."
---

## **Descripción general**

Un **Slide Master** es una plantilla de diapositiva que define el diseño, los estilos, el tema, las fuentes, el fondo y otras propiedades para las diapositivas de una presentación. Si desea crear una presentación (o una serie de presentaciones) con el mismo estilo y plantilla para su empresa, puede usar un Slide Master.

Un Slide Master es útil porque le permite establecer y cambiar el aspecto de todas las diapositivas de la presentación a la vez. Aspose.Slides admite el mecanismo de Slide Master de PowerPoint.

VBA también le permite manipular el Slide Master y realizar las mismas operaciones admitidas en PowerPoint: cambiar fondos, agregar formas, personalizar diseños y más. Aspose.Slides proporciona API flexibles que le permiten trabajar con Slide Masters y realizar tareas comunes.

Estas son operaciones básicas con Slide Master:

- Crear un Slide Master.
- Aplicar el Slide Master a las diapositivas de la presentación.
- Cambiar el fondo del Slide Master.
- Agregar una imagen, marcador de posición, SmartArt, etc., al Slide Master.

Estas son operaciones más avanzadas que involucran al Slide Master:

- Comparar Slide Masters.
- Fusionar Slide Masters.
- Aplicar varios Slide Masters.
- Copiar una diapositiva junto con su Slide Master a otra presentación.
- Identificar Slide Masters duplicados en presentaciones.
- Establecer el Slide Master como la vista predeterminada de la presentación.

{{% alert color="primary" %}}
Puede que desee consultar el [Visor de PowerPoint en línea de Aspose](https://products.aspose.app/slides/viewer) porque es una implementación en vivo de algunos de los procesos principales descritos aquí.
{{% /alert %}}

## **Cómo se aplica el Slide Master**

Antes de trabajar con un Slide Master, es posible que desee comprender cómo se utilizan los Slide Masters en las presentaciones y cómo se aplican a las diapositivas.

- Cada presentación tiene al menos un Slide Master de forma predeterminada.
- Una presentación puede contener varios Slide Masters. Puede agregar varios Slide Masters y usarlos para dar estilo a diferentes partes de una presentación de distintas maneras.

En Aspose.Slides, un Slide Master está representado por el tipo [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/).

El objeto Aspose.Slides [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) contiene la colección [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) de tipo [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/), que almacena todos los slide masters definidos en una presentación.

Más allá de las operaciones CRUD, la clase [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) proporciona métodos útiles como [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) e [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/insert_clone/). Estos amplían la funcionalidad básica de clonación de diapositivas y, al trabajar con Slide Masters, le permiten implementar configuraciones más complejas.

Cuando se agrega una nueva diapositiva a una presentación, se le aplica automáticamente un Slide Master. De forma predeterminada, se selecciona el Slide Master de la diapositiva anterior.

**Nota:** Las diapositivas de la presentación se almacenan en la colección [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/), y cada nueva diapositiva se agrega al final de esa colección de forma predeterminada. Si una presentación contiene un único Slide Master, ese Slide Master se selecciona para todas las diapositivas nuevas. Por esta razón, no tiene que especificar el Slide Master para cada diapositiva nueva que cree.

El mismo principio se aplica en PowerPoint y Aspose.Slides. Por ejemplo, en PowerPoint, cuando agrega una nueva diapositiva, puede hacer clic en el área debajo de la última diapositiva, y se creará una nueva diapositiva (usando el Slide Master de la diapositiva anterior).

![todo:image_alt_text](slide-master_1.jpg)

En Aspose.Slides, puede realizar la tarea equivalente usando el método [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) de la clase [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).

## **Slide Master en la jerarquía de Slides**

Usar **Slide Layouts** con el **Slide Master** proporciona la máxima flexibilidad. Un Slide Layout puede definir los mismos tipos de estilos que el Slide Master (fondo, fuentes, formas, etc.). Cuando se definen varios Slide Layouts bajo un Slide Master, forman colectivamente un sistema de estilo cohesivo. Al aplicar un Slide Layout a una diapositiva individual, puede ajustar su estilo respecto a lo que ofrece el Slide Master.

La precedencia es: **Slide Master** → **Slide Layout** → **Slide**.

![todo:image_alt_text](slide-master_2.jpg)

Cada objeto [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) tiene una propiedad [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) que contiene la lista de slide layouts. Un [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) tiene una propiedad [layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) que referencia el slide layout aplicado a ella. La interacción entre una diapositiva y el Slide Master ocurre a través de su Slide Layout.

{{% alert color="info" title="Note" %}}
- En Aspose.Slides, todas las construcciones de diapositivas (Slide Master, Slide Layout y la propia diapositiva) son objetos de diapositiva que extienden la clase [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/).
- Debido a que Slide Master y Slide Layout exponen muchas de las mismas propiedades, debe saber cómo se aplican sus valores a un objeto [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/). El Slide Master se aplica primero, luego el Slide Layout. Por ejemplo, si tanto el Slide Master como el Slide Layout definen un fondo, la diapositiva usa el fondo del Slide Layout.
{{% /alert %}}

## **Qué compone un Slide Master**

Para comprender cómo se puede modificar un Slide Master, necesita conocer sus componentes. Estas son las propiedades principales de [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/):

- `background` — obtiene/establece el fondo de la diapositiva.
- `body_style` — obtiene/establece los estilos de texto para el cuerpo de la diapositiva.
- `shapes` — obtiene/establece todas las formas en el Slide Master (marcadores de posición, marcos de imagen, etc.).
- `controls` — obtiene/establece los controles ActiveX.
- `theme_manager` — obtiene el gestor de temas.
- `header_footer_manager` — obtiene el gestor de encabezados y pies de página.

Métodos del Slide Master:

- `get_depending_slides()` — obtiene todas las diapositivas que dependen del Slide Master.
- `apply_external_theme_to_depending_slides(fname)` — crea un nuevo Slide Master basado en el actual y un tema externo, luego aplica el nuevo Slide Master a todas las diapositivas dependientes.

## **Obtener el Slide Master**

En PowerPoint, puede acceder al Slide Master mediante **View** → **Slide Master**:

![todo:image_alt_text](slide-master_3.jpg)

Usando Aspose.Slides, puede acceder a un Slide Master de la siguiente manera:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Obtenga la primera diapositiva maestra de la presentación.
    master_slide = presentation.masters[0]
```


La clase [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) representa un Slide Master. La propiedad [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) (una [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)) contiene todos los Slide Masters definidos en la presentación.

## **Agregar una imagen al Slide Master**

Cuando agrega una imagen a un Slide Master, esa imagen aparece en todas las diapositivas que dependen de ese master.

Por ejemplo, coloque el logotipo de su empresa u otras imágenes en el Slide Master, luego vuelva a la vista Normal. Verá la imagen en cada diapositiva dependiente.

![todo:image_alt_text](slide-master_4.png)

Puede agregar imágenes a un Slide Master con Aspose.Slides:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    with open("image.png", "rb") as image_stream:
        image = presentation.images.add_image(image_stream.read())

    master_slide = presentation.masters[0]
    master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" title="See also" %}}
Para obtener más información sobre cómo agregar imágenes a una diapositiva, consulte el artículo [Agregar marcos de imagen a presentaciones con Python](/slides/es/python-net/picture-frame/).
{{% /alert %}}

## **Agregar un marcador de posición al Slide Master**

Estos campos de texto son los marcadores de posición estándar en un Slide Master:

- Haga clic para editar el estilo del título del Master
- Editar estilos de texto del Master
- Segundo nivel
- Tercer nivel

Estos marcadores de posición también aparecen en las diapositivas basadas en el Slide Master. Puede editarlos en el Slide Master y los cambios se aplicarán automáticamente a las diapositivas.

En PowerPoint, puede agregar un marcador de posición mediante **Slide Master** → **Insert Placeholder**:

![todo:image_alt_text](slide-master_5.png)

Examinemos un ejemplo más complejo de marcadores de posición en Aspose.Slides. Considere una diapositiva con marcadores de posición heredados del Slide Master:

![todo:image_alt_text](slide-master_6.png)

Queremos actualizar el formato del Título y Subtítulo en el Slide Master como sigue:

![todo:image_alt_text](slide-master_7.png)

Primero, recupere el marcador de posición del título del Slide Master y luego use la propiedad `PlaceHolder.fill_format`:
```python
# Obtenga una referencia al marcador de posición del título de la diapositiva maestra.
title_placeholder = master_slide.shapes[0]

# Establezca el formato de relleno como gradiente.
title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
title_placeholder.fill_format.gradient_format.gradient_stops.add(0, draw.Color.red)
title_placeholder.fill_format.gradient_format.gradient_stops.add(50, draw.Color.green)
title_placeholder.fill_format.gradient_format.gradient_stops.add(100, draw.Color.blue)
```


El estilo y formato del título cambiarán en todas las diapositivas basadas en el Slide Master:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}}
* [Administrar marcadores de posición en presentaciones con Python](/slides/es/python-net/manage-placeholder/)
* [Dar formato al texto de PowerPoint en Python](/slides/es/python-net/text-formatting/)
{{% /alert %}}

## **Cambiar el fondo del Slide Master**

Cuando cambia el color de fondo de un Slide Master, todas las diapositivas normales de la presentación heredan el nuevo color. El siguiente código Python lo demuestra:
```python
master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
master_slide.background.fill_format.fill_type = slides.FillType.SOLID
master_slide.background.fill_format.solid_fill_color.color = draw.Color.gray
```


{{% alert color="primary" title="See also" %}}
- [Administrar fondos de presentación en Python](/slides/es/python-net/presentation-background/)
- [Administrar temas de presentación de PowerPoint en Python](/slides/es/python-net/presentation-theme/)
{{% /alert %}}

## **Agregar varios Slide Masters a una presentación**

Aspose.Slides le permite agregar múltiples Slide Masters y Slide Layouts a cualquier presentación. Esto le permite configurar estilos, diseños y opciones de formato para diapositivas de muchas maneras diferentes.

En PowerPoint, puede agregar nuevos Slide Masters y Slide Layouts desde el menú **Slide Master** de la siguiente forma:

![todo:image_alt_text](slide-master_9.jpg)

Usando Aspose.Slides, puede agregar un nuevo Slide Master llamando al método `add_clone`:
```python
# Agregar una nueva diapositiva maestra.
master_slide2 = presentation.masters.add_clone(master_slide1)
```


## **Comparar Slide Masters**

Un Slide Master extiende la clase [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/), que incluye el método `equals(slide)` para comparar diapositivas. Este método devuelve true cuando los Slide Masters son idénticos en estructura y contenido estático.

Dos Slide Masters se consideran iguales si sus formas, estilos, texto, animaciones y otras configuraciones son las mismas. La comparación ignora los valores de identificadores únicos (por ejemplo, `slide_id`) y el contenido dinámico (por ejemplo, la fecha actual en un marcador de posición de Fecha).

## **Establecer el Slide Master como la vista predeterminada de la presentación**

Aspose.Slides le permite establecer un Slide Master como la vista predeterminada de la presentación. La vista predeterminada es lo que ve primero al abrir la presentación. El siguiente ejemplo Python muestra cómo establecer un Slide Master como la vista predeterminada de la presentación:
```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:
    # Establecer la vista predeterminada como Vista de Slide Master.
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW

    # Guardar la presentación.
    presentation.save("presentation_view.pptx", slides.export.SaveFormat.PPTX)
```


## **Eliminar un Master Slide sin usar**

Aspose.Slides proporciona el método `remove_unused_master_slides` (en la clase [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)) para eliminar master slides no deseados o sin uso. El siguiente código Python muestra cómo eliminar master slides sin usar de una presentación PowerPoint:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **Preguntas frecuentes**

**¿Qué es un Slide Master en PowerPoint?**

Un Slide Master es una plantilla de diapositiva que define el diseño, los estilos, los temas, las fuentes, el fondo y otras propiedades para las diapositivas de una presentación. Le permite establecer y cambiar el aspecto de todas las diapositivas de la presentación a la vez.

**¿Cómo se relacionan los Slide Masters con los Slide Layouts?**

Los Slide Layouts funcionan en conjunto con los Slide Masters para proporcionar flexibilidad en el diseño de diapositivas. Mientras que un Slide Master define estilos y temas globales, los [Slide Layouts](/slides/es/python-net/slide-layout/) permiten variaciones en la disposición del contenido. La jerarquía es la siguiente:

- **Slide Master** → Define estilos globales.
- **Slide Layout** → Proporciona diferentes disposiciones de contenido.
- **Slide** → Hereda el diseño de su Slide Layout.

**¿Puedo tener varios Slide Masters en una sola presentación?**

Sí, una presentación puede contener varios Slide Masters. Esto le permite dar estilo a diferentes secciones de una presentación de varias maneras, ofreciendo flexibilidad en el diseño.

**¿Cómo accedo y modifico un Slide Master usando Aspose.Slides?**

En Aspose.Slides, un Slide Master está representado por la clase [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). Puede acceder a un Slide Master mediante la propiedad [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) del objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).