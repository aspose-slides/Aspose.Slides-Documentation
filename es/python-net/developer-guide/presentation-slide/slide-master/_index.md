---
title: Diapositiva Maestra
type: docs
weight: 80
url: /python-net/slide-master/
keywords: "Agregar Diapositiva Maestra, diapositiva maestra PPT, diapositiva maestra PowerPoint, Imagen a Diapositiva Maestra, Marcador de posición, Múltiples Diapositivas Maestras, Comparar Diapositivas Maestras, Python, Aspose.Slides"
description: "Agregar o editar diapositiva maestra en presentación de PowerPoint en Python"
---

## **¿Qué es una Diapositiva Maestra en PowerPoint?**

Una **Diapositiva Maestra** es una plantilla de diapositiva que define el diseño, estilos, tema, fuentes, fondo y otras propiedades para las diapositivas en una presentación. Si deseas crear una presentación (o serie de presentaciones) con el mismo estilo y plantilla para tu empresa, puedes usar una diapositiva maestra.

Una Diapositiva Maestra es útil porque te permite establecer y cambiar la apariencia de todas las diapositivas de la presentación de una vez. Aspose.Slides admite el mecanismo de Diapositiva Maestra de PowerPoint.

VBA también te permite manipular una Diapositiva Maestra y ejecutar las mismas operaciones compatibles en PowerPoint: cambiar fondos, agregar formas, personalizar el diseño, etc. Aspose.Slides proporciona mecanismos flexibles que te permiten usar Diapositivas Maestras y realizar tareas básicas con ellas.

Estas son las operaciones básicas de la Diapositiva Maestra:

- Crear o Diapositiva Maestra.
- Aplicar Diapositivas Maestras a las diapositivas de la presentación.
- Cambiar el fondo de la Diapositiva Maestra.
- Agregar una imagen, marcador de posición, Smart Art, etc. a la Diapositiva Maestra.

Estas son operaciones más avanzadas que involucran la Diapositiva Maestra:

- Comparar Diapositivas Maestras.
- Fusionar Diapositivas Maestras.
- Aplicar varias Diapositivas Maestras.
- Copiar diapositiva con Diapositiva Maestra a otra presentación.
- Investigar duplicados de Diapositivas Maestras en presentaciones.
- Establecer Diapositiva Maestra como la vista predeterminada de la presentación.

{{% alert color="primary" %}} 

Es posible que desees consultar el [**Visor de PowerPoint en Línea**](https://products.aspose.app/slides/viewer) de Aspose porque es una implementación en vivo de algunos de los procesos centrales aquí descritos.

{{% /alert %}} 

## **Cómo se aplica la Diapositiva Maestra**

Antes de trabajar con una diapositiva maestra, es posible que desees comprender cómo se utilizan en las presentaciones y se aplican a las diapositivas.

* Cada presentación tiene al menos una Diapositiva Maestra por defecto.
* Una presentación puede contener varias Diapositivas Maestras. Puedes agregar varias Diapositivas Maestras y utilizarlas para estilizar diferentes partes de una presentación de diferentes maneras.

En **Aspose.Slides**, una Diapositiva Maestra está representada por el tipo [**IMasterSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/).

El objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) de Aspose.Slides contiene la lista de [**masters**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) del tipo [**IMasterSlideCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/), que contiene una lista de todas las diapositivas maestras que se definen en una presentación.

Además de las operaciones CRUD, la interfaz [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) contiene estos métodos útiles: [**add_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) y [**insert_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/). Esos métodos se heredan de la función básica de clonación de diapositivas. Pero al tratar con Diapositivas Maestras, esos métodos te permiten implementar configuraciones complicadas.

Cuando se agrega una nueva diapositiva a una presentación, se aplica automáticamente una Diapositiva Maestra. La Diapositiva Maestra de la diapositiva anterior se selecciona por defecto.

**Nota**: Las diapositivas de la presentación se almacenan en la lista [Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), y cada nueva diapositiva se agrega al final de la colección por defecto. Si una presentación contiene una única Diapositiva Maestra, esa diapositiva maestra se selecciona para todas las nuevas diapositivas. Esta es la razón por la cual no tienes que definir la Diapositiva Maestra para cada nueva diapositiva que creas.

El principio es el mismo para PowerPoint y Aspose.Slides. Por ejemplo, en PowerPoint, cuando agregas una nueva presentación, solo puedes presionar en la línea inferior debajo de la última diapositiva, y luego se creará una nueva diapositiva (con la Diapositiva Maestra de la última presentación):

![todo:image_alt_text](slide-master_1.jpg)

En Aspose.Slides, puedes realizar la tarea equivalente con el método [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) de la clase [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

## **Diapositiva Maestra en la jerarquía de Diapositivas**

Usar Diseños de Diapositivas con Diapositiva Maestra permite la máxima flexibilidad. Un Diseño de Diapositiva te permite establecer todos los mismos estilos que la Diapositiva Maestra (fondo, fuentes, formas, etc.). Sin embargo, cuando se combinan varios Diseños de Diapositivas en una Diapositiva Maestra, se crea un nuevo estilo. Cuando aplicas un Diseño de Diapositiva a una sola diapositiva, puedes cambiar su estilo en comparación con el que aplica la Diapositiva Maestra.

La Diapositiva Maestra prevalece sobre todos los elementos de configuración: Diapositiva Maestra -> Diseño de Diapositiva -> Diapositiva:

![todo:image_alt_text](slide-master_2)

Cada [IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) tiene una propiedad [**LayoutSlides**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) con una lista de Diseños de Diapositivas. Un tipo [Slide ](https://reference.aspose.com/slides/python-net/aspose.slides/slide) tiene una propiedad [**LayoutSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) con un enlace a un Diseño de Diapositiva aplicado a la diapositiva. La interacción entre una diapositiva y la Diapositiva Maestra ocurre a través de un Diseño de Diapositiva.

{{% alert color="info" title="Nota" %}}

* En Aspose.Slides, todos los elementos de configuración de diapositivas (Diapositiva Maestra, Diseño de Diapositiva y la propia diapositiva) son objetos de diapositiva que implementan la interfaz [**IBaseSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/).
* Por lo tanto, la Diapositiva Maestra y el Diseño de Diapositiva pueden implementar las mismas propiedades y necesitas saber cómo se aplicarán sus valores a un objeto [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/). La Diapositiva Maestra se aplica primero a una diapositiva y luego se aplica el Diseño de Diapositiva. Por ejemplo, si la Diapositiva Maestra y el Diseño de Diapositiva tienen ambos un valor de fondo, la Diapositiva terminará con el fondo del Diseño de Diapositiva.

{{% /alert %}}

## **Qué comprende una Diapositiva Maestra**

Para entender cómo se puede cambiar una Diapositiva Maestra, necesitas conocer sus componentes. Estas son las propiedades centrales de [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/).

- `background` obtener/establecer fondo de la diapositiva.
- `body_style` obtener/establecer estilos de texto del cuerpo de la diapositiva.
- `shapes` obtener/establecer todas las formas de la Diapositiva Maestra (marcadores de posición, marcos de imagen, etc.).
- `controls` - obtener/establecer controles ActiveX.
- `theme_manager` - obtener el administrador de temas.
- `header_footer_manager` - obtener el administrador de encabezados y pies de página.

Métodos de Diapositiva Maestra:

- `get_depending_slides()` - obtener todas las Diapositivas que dependen de la Diapositiva Maestra.
- `apply_external_theme_to_depending_slides(fname)` - te permite crear una nueva Diapositiva Maestra basada en la Diapositiva Maestra actual y un nuevo tema. La nueva Diapositiva Maestra se aplicará a todas las diapositivas dependientes.

## **Obtener Diapositiva Maestra**

En PowerPoint, se puede acceder a la Diapositiva Maestra desde el menú Vista -> Diapositiva Maestra:

![todo:image_alt_text](slide-master_3.jpg)

Usando Aspose.Slides, puedes acceder a una Diapositiva Maestra de esta manera:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    # Da acceso a la diapositiva maestra de la presentación
    masterSlide = pres.masters[0]
```

La interfaz [IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) representa una Diapositiva Maestra. La propiedad `masters` (relacionada con el tipo [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/)) contiene una lista de todas las Diapositivas Maestras que están definidas en la presentación.

## **Agregar Imagen a la Diapositiva Maestra**

Cuando agregas una imagen a una Diapositiva Maestra, esa imagen aparecerá en todas las diapositivas que dependen de esa diapositiva maestra.

Por ejemplo, puedes colocar el logo de tu empresa y algunas imágenes en la Diapositiva Maestra y luego volver al modo de edición de diapositivas. Deberías ver la imagen en cada diapositiva.

![todo:image_alt_text](slide-master_4.png)

Puedes agregar imágenes a una diapositiva maestra con Aspose.Slides:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    image = pres.images.add_image(open("image.png", "rb").read())
    pres.masters[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" title="Ver también" %}} 

Para obtener más información sobre cómo agregar imágenes a una diapositiva, consulta el artículo [Marco de Imagen](/slides/python-net/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Agregar Marcador de Posición a la Diapositiva Maestra**

Estos campos de texto son marcadores de posición estándar en una Diapositiva Maestra:

* Haga clic para editar el estilo del título de la Maestra

* Editar estilos de texto de la Maestra

* Segundo nivel

* Tercer nivel

También aparecen en las diapositivas basadas en la Diapositiva Maestra. Puedes editar esos marcadores de posición en una Diapositiva Maestra y los cambios se aplican automáticamente a las diapositivas.

En PowerPoint, puedes agregar un marcador de posición a través de la ruta Diapositiva Maestra -> Insertar Marcador de Posición:

![todo:image_alt_text](slide-master_5.png)

Examinemos un ejemplo más complicado para marcadores de posición con Aspose.Slides. Considera una diapositiva con marcadores de posición plantillados de la Diapositiva Maestra:

![todo:image_alt_text](slide-master_6.png)

Queremos cambiar el formato del Título y Subtítulo en la Diapositiva Maestra de esta manera:

![todo:image_alt_text](slide-master_7.png)

Primero, recuperamos el contenido del marcador de posición del título del objeto Diapositiva Maestra y luego usamos el campo `PlaceHolder.FillFormat`:

```python
# Obtiene la referencia al marcador de posición del título de la maestra
titlePlaceholder = masterSlide.shapes[0]

# Establece el formato de relleno como relleno en degradado
titlePlaceholder.fill_format.fill_type = slides.FillType.GRADIENT
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(0, draw.Color.red)
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(50, draw.Color.green)
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(100, draw.Color.blue)
```

El estilo y formato del título cambiarán para todas las diapositivas basadas en la diapositiva maestra:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Ver también" %}} 

* [Establecer Texto de Sugerencia en Marcador de Posición](https://docs.aspose.com/slides/python-net/manage-placeholder/)
* [Formato de Texto](https://docs.aspose.com/slides/python-net/text-formatting/)

{{% /alert %}}

## **Cambiar Fondo en la Diapositiva Maestra**

Cuando cambias el color de fondo de una diapositiva maestra, todas las diapositivas normales en la presentación obtendrán el nuevo color. Este código Python demuestra la operación:

```python
masterSlide.background.type = slides.BackgroundType.OWN_BACKGROUND
masterSlide.background.fill_format.fill_type = slides.FillType.SOLID
masterSlide.background.fill_format.solid_fill_color.color = draw.Color.gray
```

{{% alert color="primary" title="Ver también" %}} 

- [Fondo de Presentación](https://docs.aspose.com/slides/python-net/presentation-background/)

- [Tema de Presentación](https://docs.aspose.com/slides/python-net/presentation-theme/)

  {{% /alert %}}

## **Clonar Diapositiva Maestra a Otra Presentación**

Para clonar una Diapositiva Maestra a otra presentación, llama al método `add_clone(source_slide, dest_master, allow_clone_missing_layout)` de la presentación de destino junto con una Diapositiva Maestra pasada a él. Este código Python te muestra cómo clonar una Diapositiva Maestra a otra presentación:

```python
# Agrega una nueva diapositiva maestra
pres1MasterSlide = pres.masters.add_clone(masterSlide)
```

## **Agregar Múltiples Diapositivas Maestras a la Presentación**

Aspose.Slides te permite agregar varias Diapositivas Maestras y Diseños de Diapositivas a cualquier presentación dada. Esto te permite configurar estilos, diseños y opciones de formato para las diapositivas de la presentación de muchas maneras.

En PowerPoint, puedes agregar nuevas Diapositivas Maestras y Diseños (desde el menú "Diapositiva Maestra") de esta manera:

![todo:image_alt_text](slide-master_9.jpg)

Usando Aspose.Slides, puedes agregar una nueva Diapositiva Maestra llamando al método `add_clone`:

```python
# Agrega una nueva diapositiva maestra
secondMasterSlide = pres.masters.add_clone(masterSlide)
```

## **Comparar Diapósitos Maestros**

Una Diapositiva Maestra implementa la interfaz [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) que contiene el método `equals(slide)`, que puede ser utilizado para comparar diapositivas. Devuelve `true` para las Diapositivas Maestras idénticas en estructura y contenido estático.

Dos Diapositivas Maestras son iguales si sus formas, estilos, textos, animaciones y otras configuraciones son iguales, etc. La comparación no tiene en cuenta los valores de identificador único (por ejemplo, SlideId) y el contenido dinámico (por ejemplo, el valor de la fecha actual en el Marcador de Posición de Fecha).

## **Establecer la Diapositiva Maestra como Vista Predeterminada de la Presentación**

Aspose.Slides te permite establecer una Diapositiva Maestra como la vista predeterminada para una presentación. La vista predeterminada es lo que ves primero al abrir una presentación.

Este código te muestra cómo establecer una Diapositiva Maestra como la vista predeterminada de una presentación en Python:

```py
import aspose.slides as slides

# Instancia una clase Presentation que representa el archivo de presentación
with slides.Presentation() as presentation:
    # Establece la Vista Predeterminada como DiapositivaMaestraVista
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW

    # Guarda la presentación
    presentation.save("PresView.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminar Diapositiva Maestra No Utilizada**

Aspose.Slides proporciona el método `remove_unused_master_slides` (de la clase [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)) para permitirte eliminar diapositivas maestras no deseadas y no utilizadas. Este código Python te muestra cómo eliminar una diapositiva maestra de una presentación de PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_master_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```