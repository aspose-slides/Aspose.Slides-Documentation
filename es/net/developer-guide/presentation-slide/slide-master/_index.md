---
title: Maestro de Diapositivas
type: docs
weight: 80
url: /net/slide-master/
keywords: "Agregar Maestro de Diapositivas, diapositiva maestra de PPT, maestro de diapositivas PowerPoint, Imagen en Maestro de Diapositivas, Marcador de posición, Varios Maestros de Diapositivas, Comparar Maestros de Diapositivas, C#, Csharp, .NET, Aspose.Slides"
description: "Agregar o editar maestro de diapositivas en una presentación de PowerPoint en C# o .NET"
---


## **¿Qué es un Maestro de Diapositivas en PowerPoint?**
Un **Maestro de Diapositivas** es una plantilla de diapositiva que define el diseño, estilos, tema, fuentes, fondo y otras propiedades para las diapositivas en una presentación. Si deseas crear una presentación (o serie de presentaciones) con el mismo estilo y plantilla para tu empresa, puedes utilizar un maestro de diapositivas.

Un Maestro de Diapositivas es útil porque te permite establecer y cambiar el aspecto de todas las diapositivas de la presentación a la vez. Aspose.Slides soporta el mecanismo de Maestro de Diapositivas de PowerPoint.

VBA también te permite manipular un Maestro de Diapositivas y ejecutar las mismas operaciones soportadas en PowerPoint: cambiar fondos, agregar formas, personalizar el diseño, etc. Aspose.Slides proporciona mecanismos flexibles que te permiten utilizar Maestros de Diapositivas y realizar tareas básicas con ellos.

Estas son las operaciones básicas del Maestro de Diapositivas:

- Crear o Slide Master.
- Aplicar Maestros de Diapositivas a las diapositivas de la presentación.
- Cambiar el fondo del Maestro de Diapositivas.
- Agregar una imagen, un marcador de posición, Smart Art, etc. al Maestro de Diapositivas.

Estas son operaciones más avanzadas que involucran el Maestro de Diapositivas:

- Comparar Maestros de Diapositivas.
- Fusionar Maestros de Diapositivas.
- Aplicar varios Maestros de Diapositivas.
- Copiar diapositivas con el Maestro de Diapositivas a otra presentación.
- Encontrar Maestros de Diapositivas duplicados en presentaciones.
- Establecer el Maestro de Diapositivas como la vista predeterminada de la presentación.

{{% alert color="primary" %}}

Es posible que desees consultar el [**Visor de PowerPoint en Línea**](https://products.aspose.app/slides/viewer) de Aspose porque es una implementación en vivo de algunos de los procesos centrales descritos aquí.

{{% /alert %}}


## **¿Cómo se aplica el Maestro de Diapositivas?**
Antes de trabajar con un maestro de diapositivas, es posible que desees comprender cómo se utilizan en las presentaciones y se aplican a las diapositivas.

* Cada presentación tiene al menos un Maestro de Diapositivas por defecto.
* Una presentación puede contener varios Maestros de Diapositivas. Puedes agregar varios Maestros de Diapositivas y usarlos para estilizar diferentes partes de una presentación de diferentes maneras.

En **Aspose.Slides**, un Maestro de Diapositivas es representado por el tipo [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide).

El objeto [Presentación](https://reference.aspose.com/slides/net/aspose.slides/presentation) de Aspose.Slides contiene la lista de [**Masters**](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters) de tipo [**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection), que contiene una lista de todas las diapositivas maestras que están definidas en una presentación.

Además de las operaciones CRUD, la interfaz [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) contiene estos métodos útiles: [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) y [**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone). Estos métodos se heredan de la función básica de clonación de diapositivas. Pero al tratarse de Maestros de Diapositivas, esos métodos te permiten implementar configuraciones complicadas.

Cuando se agrega una nueva diapositiva a una presentación, se aplica automáticamente un Maestro de Diapositivas. El Maestro de Diapositivas de la diapositiva anterior se selecciona por defecto.

**Nota**: Las diapositivas de la presentación se almacenan en la lista [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides), y cada nueva diapositiva se agrega al final de la colección por defecto. Si una presentación contiene un solo Maestro de Diapositivas, ese maestro se selecciona para todas las nuevas diapositivas. Esta es la razón por la que no necesitas definir el Maestro de Diapositivas para cada nueva diapositiva que creas.

El principio es el mismo para PowerPoint y Aspose.Slides. Por ejemplo, en PowerPoint, cuando agregas una nueva presentación, puedes presionar en la línea inferior bajo la última diapositiva y luego se creará una nueva diapositiva (con el Maestro de Diapositivas de la última presentación):

![todo:image_alt_text](slide-master_1.jpg)

En Aspose.Slides, puedes realizar la tarea equivalente con el método [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone) de la clase [Presentación](https://reference.aspose.com/slides/net/aspose.slides/presentation).


## **Maestro de Diapositivas en la jerarquía de Diapositivas**
Usar Diseños de Diapositivas con el Maestro de Diapositivas permite una flexibilidad máxima. Un Diseño de Diapositiva te permite establecer todos los mismos estilos que el Maestro de Diapositivas (fondo, fuentes, formas, etc.). Sin embargo, cuando varios Diseños de Diapositivas se combinan en un Maestro de Diapositivas, se crea un nuevo estilo. Cuando aplicas un Diseño de Diapositiva a una sola diapositiva, puedes cambiar su estilo del que aplica el Maestro de Diapositivas.

El Maestro de Diapositivas tiene prioridad sobre todos los elementos de configuración: Maestro de Diapositivas -> Diseño de Diapositiva -> Diapositiva:

![todo:image_alt_text](slide-master_2)

Cada [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) tiene una propiedad [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides) con una lista de Diseños de Diapositivas. Un tipo [Diapositiva](https://reference.aspose.com/slides/net/aspose.slides/slide) tiene una propiedad [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide) con un enlace al Diseño de Diapositiva aplicado a la diapositiva. La interacción entre una diapositiva y el Maestro de Diapositivas ocurre a través de un Diseño de Diapositiva.

{{% alert color="info" title="Nota" %}}

* 
   En Aspose.Slides, todas las configuraciones de las diapositivas (Maestro de Diapositivas, Diseño de Diapositiva y la propia diapositiva) son en realidad objetos de diapositiva que implementan la interfaz [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide).
* Por lo tanto, el Maestro de Diapositivas y el Diseño de Diapositiva pueden implementar las mismas propiedades y necesitas saber cómo se aplicarán sus valores a un objeto [Diapositiva](https://reference.aspose.com/slides/net/aspose.slides/slide/). El Maestro de Diapositivas se aplica primero a una diapositiva y luego se aplica el Diseño de Diapositiva. Por ejemplo, si el Maestro de Diapositivas y el Diseño de Diapositiva tienen ambos un valor de fondo, la Diapositiva terminará con el fondo del Diseño de Diapositiva.

{{% /alert %}}


## **Qué comprende un Maestro de Diapositivas**
Para entender cómo se puede cambiar un Maestro de Diapositivas, necesitas conocer sus componentes. Estas son las propiedades fundamentales de [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/).

- [Fondo](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) - obtener/establecer el fondo de la diapositiva.
- [CuerpoEstilo](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) - obtener/establecer los estilos de texto del cuerpo de la diapositiva.
- [Formas](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) - obtener/establecer todas las formas del Maestro de Diapositivas (marcadores de posición, marcos de imagen, etc.).
- [Controles](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) - obtener/establecer controles ActiveX.
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) - obtener el administrador de temas.
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) - obtener el administrador de encabezados y pies de página.

Métodos del Maestro de Diapositivas:

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) - obtener todas las Diapositivas que dependen del Maestro de Diapositivas.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) - te permite crear un nuevo Maestro de Diapositivas basado en el Maestro de Diapositivas actual y un nuevo tema. El nuevo Maestro de Diapositivas se aplicará a todas las diapositivas dependientes.


## **Obtener Maestro de Diapositivas**
En PowerPoint, el Maestro de Diapositivas se puede acceder desde el menú Vista -> Maestro de Diapositivas:

![todo:image_alt_text](slide-master_3.jpg)

Usando Aspose.Slides, puedes acceder a un Maestro de Diapositivas de esta manera:

```c#
IMasterSlide master = pres.Masters[0];
```

La interfaz [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) representa un Maestro de Diapositivas. La propiedad [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) (relacionada con el tipo [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)) contiene una lista de todos los Maestros de Diapositivas que están definidos en la presentación.


## **Agregar Imagen al Maestro de Diapositivas**
Cuando agregas una imagen a un Maestro de Diapositivas, esa imagen aparecerá en todas las diapositivas dependientes de ese maestro de diapositivas.

Por ejemplo, puedes colocar el logotipo de tu empresa y algunas imágenes en el Maestro de Diapositivas y luego volver al modo de edición de diapositivas. Deberías ver la imagen en cada diapositiva.

![todo:image_alt_text](slide-master_4.png)

Puedes agregar imágenes a un maestro de diapositivas con Aspose.Slides:

```c#
using (Presentation pres = new Presentation())
{
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    pres.Masters[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" title="Ver también" %}}

Para obtener más información sobre cómo agregar imágenes a una diapositiva, consulta el artículo [Marco de Imagen](/slides/net/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Agregar Marcador de Posición al Maestro de Diapositivas**
Estos campos de texto son marcadores de posición estándar en un Maestro de Diapositivas:

* Haga clic para editar el estilo del título del maestro

* Editar estilos de texto del maestro

* Segundo nivel

* Tercer nivel

También aparecen en las diapositivas basadas en el Maestro de Diapositivas. Puedes editar esos marcadores de posición en un Maestro de Diapositivas y los cambios se aplican automáticamente a las diapositivas.

En PowerPoint, puedes agregar un marcador de posición a través de la ruta Maestro de Diapositivas -> Insertar Marcador de Posición:



![todo:image_alt_text](slide-master_5.png)



Examinemos un ejemplo más complicado de marcadores de posición con Aspose.Slides. Considera una diapositiva con marcadores de posición plantillados desde el Maestro de Diapositivas:



![todo:image_alt_text](slide-master_6.png)



Queremos cambiar el formato del Título y el Subtítulo en el Maestro de Diapositivas de esta manera:

![todo:image_alt_text](slide-master_7.png)



Primero, recuperamos el contenido del marcador de posición del título del objeto Maestro de Diapositivas y luego usamos el campo `PlaceHolder.FillFormat`:

```c#
public static void Main()
{
    using (var pres = new Presentation())
    {
        IMasterSlide master = pres.Masters[0];
        IAutoShape placeHolder = FindPlaceholder(master, PlaceholderType.Title);
        placeHolder.FillFormat.FillType = FillType.Gradient;
        placeHolder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
        placeHolder.FillFormat.GradientFormat.GradientStops.Add(0, Color.FromArgb(255, 0, 0));
        placeHolder.FillFormat.GradientFormat.GradientStops.Add(255, Color.FromArgb(128, 0, 128));
        
        pres.Save("pres.pptx", SaveFormat.Pptx);
    }
}

static IAutoShape FindPlaceholder(IMasterSlide master, PlaceholderType type)
{
    foreach (IShape shape in master.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            if (autoShape.Placeholder.Type == type)
            {
                return autoShape;
            }
        }
    }

    return null;
}
```

El estilo y formato del título cambiarán para todas las diapositivas basadas en el maestro de diapositivas:



![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Ver también" %}}

* [Establecer texto de aviso en el marcador de posición](https://docs.aspose.com/slides/net/manage-placeholder/)
* [Formato de texto](https://docs.aspose.com/slides/net/text-formatting/)

{{% /alert %}}


## **Cambiar el Fondo en el Maestro de Diapositivas**
Cuando cambias el color de fondo de un maestro de diapositivas, todas las diapositivas normales de la presentación obtendrán el nuevo color. Este código C# demuestra la operación:

```c#
using (var pres = new Presentation())
{
    IMasterSlide master = pres.Masters[0];
    master.Background.Type = BackgroundType.OwnBackground;
    master.Background.FillFormat.FillType = FillType.Solid;
    master.Background.FillFormat.SolidFillColor.Color = Color.Green;
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" title="Ver también" %}} 
- [Fondo de Presentación](https://docs.aspose.com/slides/net/presentation-background/)

- [Tema de Presentación](https://docs.aspose.com/slides/net/presentation-theme/)

  {{% /alert %}}

## **Clonar Maestro de Diapositivas a Otra Presentación**
Para clonar un Maestro de Diapositivas a otra presentación, llama al método [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) desde la presentación de destino junto con un Maestro de Diapositivas que se le pase. Este código C# te muestra cómo clonar un Maestro de Diapositivas a otra presentación:

```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```


## **Agregar Múltiples Maestros de Diapositivas a la Presentación**
Aspose.Slides te permite agregar varios Maestros de Diapositivas y Diseños de Diapositivas a cualquier presentación dada. Esto te permite establecer estilos, diseños y opciones de formato para las diapositivas de la presentación de muchas maneras.

En PowerPoint, puedes agregar nuevos Maestros de Diapositivas y Diseños (desde el menú "Maestro de Diapositivas) de esta manera:

![todo:image_alt_text](slide-master_9.jpg)

Usando Aspose.Slides, puedes agregar un nuevo Maestro de Diapositivas llamando al método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/):

```c#
pres.Masters.AddClone(pres.Masters[0]);
```


## **Comparar Maestros de Diapositivas**
Un Maestro de Diapositivas implementa la interfaz [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) que contiene el método [Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals), que luego se puede usar para comparar diapositivas. Devuelve `true` para los Maestros de Diapositivas idénticos en estructura y contenido estático.

Dos Maestros de Diapositivas son iguales si sus formas, estilos, textos, animaciones y otros ajustes, etc. son iguales. La comparación no toma en cuenta valores de identificador único (por ejemplo, SlideId) y contenido dinámico (por ejemplo, valor de fecha actual en el Marcador de Posición de Fecha).


## **Establecer Maestro de Diapositivas como Vista Predeterminada de la Presentación**
Aspose.Slides te permite establecer un Maestro de Diapositivas como la vista predeterminada para una presentación. La vista predeterminada es lo que ves primero cuando abres una presentación.

Este código te muestra cómo establecer un Maestro de Diapositivas como la vista predeterminada de una presentación en C#:

```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```

## **Eliminar Maestro de Diapositivas No Utilizado**

Aspose.Slides proporciona el método [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la clase [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) que te permite eliminar maestros de diapositivas no deseados y no utilizados. Este código C# te muestra cómo eliminar un maestro de diapositivas de una presentación de PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```