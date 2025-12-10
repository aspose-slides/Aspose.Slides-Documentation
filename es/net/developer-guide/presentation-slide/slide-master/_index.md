---
title: Gestionar patrones de diapositiva de presentación en .NET
linktitle: Patrón de diapositiva
type: docs
weight: 80
url: /es/net/slide-master/
keywords:
- patrón de diapositiva
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
- .NET
- C#
- Aspose.Slides
description: "Gestionar patrones de diapositivas en Aspose.Slides para .NET: crear, editar y aplicar diseños, temas y marcadores de posición a PPT, PPTX y ODP con ejemplos concisos en C#."
---

## **Qué es un Patrón de diapositivas en PowerPoint**
Un **Patrón de diapositivas** en PowerPoint es una función que controla el diseño, las fuentes y los estilos en múltiples diapositivas. Ayuda a mantener la coherencia y la identidad de marca en las presentaciones. Si deseas crear una presentación (o una serie de presentaciones) con el mismo estilo y plantilla para tu empresa, puedes usar un patrón de diapositivas. 

Un Patrón de diapositivas es útil porque permite establecer y cambiar el aspecto de todas las diapositivas de la presentación de una sola vez. Aspose.Slides admite el mecanismo de Patrón de diapositivas de PowerPoint. 

VBA también permite manipular un Patrón de diapositivas y ejecutar las mismas operaciones compatibles con PowerPoint: cambiar fondos, agregar formas, personalizar el diseño, etc. Aspose.Slides ofrece mecanismos flexibles para que puedas usar Patrones de diapositivas y realizar tareas básicas con ellos. 

Estas son operaciones básicas con el Patrón de diapositivas:

- Crear o Patrón de diapositivas.
- Aplicar el Patrón de diapositivas a las diapositivas de la presentación.
- Cambiar el fondo del Patrón de diapositivas. 
- Agregar una imagen, marcador de posición, Smart Art, etc. al Patrón de diapositivas.

Estas son operaciones más avanzadas que involucran el Patrón de diapositivas: 

- Comparar Patrones de diapositivas.
- Fusionar Patrones de diapositivas.
- Aplicar varios Patrones de diapositivas.
- Copiar una diapositiva con Patrón de diapositivas a otra presentación.
- Encontrar Patrones de diapositivas duplicados en presentaciones.
- Establecer el Patrón de diapositivas como la vista predeterminada de la presentación.

{{% alert color="primary" %}} 

Puede que quieras probar Aspose [**Visor de PowerPoint en línea**](https://products.aspose.app/slides/viewer) porque es una implementación en vivo de algunos de los procesos centrales descritos aquí.

{{% /alert %}} 


## **Cómo se aplica un Patrón de diapositivas**
Antes de trabajar con un patrón de diapositivas, puede que desees entender cómo se usan en las presentaciones y se aplican a las diapositivas. 

* Cada presentación tiene al menos un Patrón de diapositivas por defecto. 
* Una presentación puede contener varios Patrones de diapositivas. Puedes agregar varios Patrones de diapositivas y usarlos para dar estilo a diferentes partes de una presentación de distintas maneras. 

En **Aspose.Slides**, un Patrón de diapositivas está representado por [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) type. 

El objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) de Aspose.Slides contiene la lista de [**Masters**](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters) de tipo [**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection), que contiene una lista de todos los patrones de diapositivas definidos en una presentación. 

Además de las operaciones CRUD, la interfaz [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) incluye estos métodos útiles: [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) y [**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone). Esos métodos se heredan de la función básica de clonación de diapositivas. Pero al tratar con Patrones de diapositivas, esos métodos permiten implementar configuraciones complicadas. 

Cuando se agrega una nueva diapositiva a una presentación, se le aplica automáticamente un Patrón de diapositivas. El Patrón de diapositivas de la diapositiva anterior se selecciona por defecto. 

**Nota**: Las diapositivas de la presentación se almacenan en la lista [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) y cada nueva diapositiva se agrega al final de la colección por defecto. Si una presentación contiene un solo Patrón de diapositivas, ese patrón se selecciona para todas las nuevas diapositivas. Esta es la razón por la que no tienes que definir el Patrón de diapositivas para cada nueva diapositiva que creas.

El principio es el mismo para PowerPoint y Aspose.Slides. Por ejemplo, en PowerPoint, cuando agregas una nueva diapositiva, puedes simplemente pulsar en la línea inferior bajo la última diapositiva y entonces se creará una nueva diapositiva (con el Patrón de diapositivas de la última presentación):

![todo:image_alt_text](slide-master_1.jpg)

En Aspose.Slides, puedes realizar la tarea equivalente con el método [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone) de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).


## **Patrón de diapositivas en la jerarquía de Slides**
Usar Diseños de diapositivas con el Patrón de diapositivas permite la máxima flexibilidad. Un Diseño de diapositiva te permite establecer todos los mismos estilos que el Patrón de diapositivas (fondo, fuentes, formas, etc.). Sin embargo, cuando varios Diseños de diapositivas se combinan en un Patrón de diapositivas, se crea un nuevo estilo. Cuando aplicas un Diseño de diapositiva a una sola diapositiva, puedes cambiar su estilo del que aplicó el Patrón de diapositivas.

El Patrón de diapositivas supera a todos los elementos de configuración: Patrón de diapositivas -> Diseño de diapositiva -> Diapositiva:

![todo:image_alt_text](slide-master_2)



Cada objeto [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) tiene una propiedad [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides) con una lista de Diseños de diapositiva. Un tipo [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) tiene una propiedad [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide) con un vínculo al Diseño de diapositiva aplicado a la diapositiva. La interacción entre una diapositiva y el Patrón de diapositivas ocurre a través de un Diseño de diapositiva.

{{% alert color="info" title="Nota" %}}

* En Aspose.Slides, todas las configuraciones de diapositiva (Patrón de diapositivas, Diseño de diapositiva y la propia diapositiva) son en realidad objetos de diapositiva que implementan la interfaz [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide). 
* Por lo tanto, Patrón de diapositivas y Diseño de diapositiva pueden implementar las mismas propiedades y debes saber cómo se aplicarán sus valores a un objeto [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/) . El Patrón de diapositivas se aplica primero a una diapositiva y luego se aplica el Diseño de diapositiva. Por ejemplo, si el Patrón de diapositivas y el Diseño de diapositiva ambos tienen un valor de fondo, la diapositiva terminará con el fondo del Diseño de diapositiva.

{{% /alert %}}


## **Qué contiene un Patrón de diapositivas**
Para entender cómo se puede cambiar un Patrón de diapositivas, necesitas conocer sus componentes. Estos son los atributos principales de [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) :

- [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) - obtener/establecer el fondo de la diapositiva. 
- [BodyStyle](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) - obtener/establecer los estilos de texto del cuerpo de la diapositiva. 
- [Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) - obtener/establecer todas las formas del Patrón de diapositivas (marcadores de posición, marcos de imagen, etc.). 
- [Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) - obtener/establecer controles ActiveX. 
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) - obtener el administrador de temas. 
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) - obtener el administrador de encabezados y pies de página. 

Métodos del Patrón de diapositivas:

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) - obtener todas las diapositivas que dependen del Patrón de diapositivas. 
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) - permite crear un nuevo Patrón de diapositivas basado en el actual y un tema nuevo. El nuevo Patrón de diapositivas se aplicará luego a todas las diapositivas dependientes.


## **Obtener un Patrón de diapositivas**
En PowerPoint, el Patrón de diapositivas se puede acceder desde el menú Vista -> Patrón de diapositivas:

![todo:image_alt_text](slide-master_3.jpg)



Con Aspose.Slides, puedes acceder a un Patrón de diapositivas de esta manera:
```c#
IMasterSlide master = pres.Masters[0];
```


La interfaz [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) representa un Patrón de diapositivas. La propiedad [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) (relacionada con el tipo [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)) contiene una lista de todos los Patrones de diapositivas definidos en la presentación. 


## **Agregar una imagen a un Patrón de diapositivas**
Cuando agregas una imagen a un Patrón de diapositivas, esa imagen aparecerá en todas las diapositivas que dependan de ese patrón. 

Por ejemplo, puedes colocar el logotipo de tu empresa y algunas imágenes en el Patrón de diapositivas y luego volver al modo de edición de diapositivas. Deberías ver la imagen en cada diapositiva. 

![todo:image_alt_text](slide-master_4.png)

Puedes agregar imágenes a un Patrón de diapositivas con Aspose.Slides: 
```c#
using (Presentation pres = new Presentation())
{
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    pres.Masters[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" title="Ver también" %}} 

Para más información sobre cómo agregar imágenes a una diapositiva, consulta el artículo [Picture Frame](/slides/es/net/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Agregar un marcador de posición a un Patrón de diapositivas**
Estos campos de texto son marcadores de posición estándar en un Patrón de diapositivas: 

* Haz clic para editar el estilo del título del patrón

* Editar estilos de texto del patrón

* Segundo nivel

* Tercer nivel 

  También aparecen en las diapositivas basadas en el Patrón de diapositivas. Puedes editar esos marcadores de posición en el Patrón de diapositivas y los cambios se aplicarán automáticamente a las diapositivas. 

En PowerPoint, puedes agregar un marcador de posición a través de la ruta Patrón de diapositivas -> Insertar marcador de posición:

![todo:image_alt_text](slide-master_5.png)

Examinemos un ejemplo más complicado de marcadores de posición con Aspose.Slides. Considera una diapositiva con marcadores de posición templados desde el Patrón de diapositivas:

![todo:image_alt_text](slide-master_6.png)

Queremos cambiar el formato del Título y Subtítulo en el Patrón de diapositivas de esta forma:

![todo:image_alt_text](slide-master_7.png)

Primero, obtenemos el contenido del marcador de posición del título del objeto Patrón de diapositivas y luego usamos el campo `PlaceHolder.FillFormat`: 
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


El estilo y formato del título cambiarán para todas las diapositivas basadas en el patrón de diapositivas:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Ver también" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/net/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/net/text-formatting/)

{{% /alert %}}


## **Cambiar el fondo en un Patrón de diapositivas**
Cuando cambias el color de fondo de una diapositiva maestra, todas las diapositivas normales de la presentación obtendrán el nuevo color. Este código C# muestra la operación:
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
- [Presentation Background](https://docs.aspose.com/slides/net/presentation-background/)

- [Presentation Theme](https://docs.aspose.com/slides/net/presentation-theme/)

{{% /alert %}}

## **Clonar un Patrón de diapositivas a otra presentación**
Para clonar un Patrón de diapositivas a otra presentación, llama al método [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) de la presentación de destino pasando el Patrón de diapositivas. Este código C# muestra cómo clonar un Patrón de diapositivas a otra presentación:
```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```



## **Agregar varios Patrones de diapositivas a una presentación**
Aspose.Slides permite agregar varios Patrones de diapositivas y Diseños de diapositivas a cualquier presentación. Esto permite configurar estilos, diseños y opciones de formato para las diapositivas de la presentación de muchas maneras. 

En PowerPoint, puedes agregar nuevos Patrones de diapositivas y Diseños (desde el “menú Patrón de diapositivas”) de esta forma:

![todo:image_alt_text](slide-master_9.jpg)

Con Aspose.Slides, puedes agregar un nuevo Patrón de diapositivas llamando al método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) :
```c#
pres.Masters.AddClone(pres.Masters[0]);
```



## **Comparar Patrones de diapositivas**
Un Patrón de diapositiva implementa la interfaz [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) que contiene el método [Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals), que puede usarse para comparar diapositivas. Devuelve `true` para Patrones de diapositivas idénticos en estructura y contenido estático. 

Dos Patrones de diapositivas son iguales si sus formas, estilos, textos, animaciones y otras configuraciones, etc., son iguales. La comparación no tiene en cuenta los valores de identificadores únicos (p. ej., SlideId) ni el contenido dinámico (p. ej., valor de fecha actual en el marcador de posición de fecha). 


## **Establecer un Patrón de diapositivas como la vista predeterminada de la presentación**
Aspose.Slides permite establecer un Patrón de diapositivas como la vista predeterminada de una presentación. La vista predeterminada es lo que ves primero al abrir una presentación. 

Este código muestra cómo establecer un Patrón de diapositivas como la vista predeterminada de la presentación en C#:
```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```


## **Eliminar Patrones de diapositivas no usados**

Aspose.Slides ofrece el método [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la clase [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) para eliminar los patrones de diapositivas no deseados y no usados. Este código C# muestra cómo eliminar un patrón de diapositivas de una presentación de PowerPoint:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**¿Qué es un Patrón de diapositivas en PowerPoint?**

Un Patrón de diapositivas es una plantilla que define el diseño, estilos, temas, fuentes, fondo y otras propiedades para las diapositivas de una presentación. Permite establecer y cambiar el aspecto de todas las diapositivas de la presentación de una sola vez.  

**¿Cómo se aplica un Patrón de diapositivas en una presentación?**

Cada presentación tiene al menos un Patrón de diapositivas por defecto. Cuando se agrega una nueva diapositiva, se le aplica automáticamente un Patrón de diapositivas, normalmente heredando el patrón de la diapositiva anterior. Una presentación puede contener varios Patrones de diapositivas para dar estilo a distintas partes de forma única.  

**¿Qué elementos pueden personalizarse en un Patrón de diapositivas?**

Un Patrón de diapositivas comprende varios atributos principales que pueden personalizarse:

- **Background**: establecer el fondo de la diapositiva. 
- **BodyStyle**: definir los estilos de texto del cuerpo de la diapositiva. 
- **Shapes**: gestionar todas las formas del Patrón de diapositivas, incluidos marcadores de posición y marcos de imagen. 
- **Controls**: manejar controles ActiveX. 
- **ThemeManager**: acceder al administrador de temas. 
- **HeaderFooterManager**: gestionar encabezados y pies de página.  

**¿Cómo puedo agregar una imagen a un Patrón de diapositivas?**

Agregar una imagen a un Patrón de diapositivas asegura que aparezca en todas las diapositivas que dependan de ese patrón. Por ejemplo, colocar el logotipo de la empresa en el Patrón de diapositivas hará que se muestre en cada diapositiva de la presentación.  

**¿Cómo se relacionan los Patrones de diapositivas con los Diseños de diapositivas?**

Los Diseños de diapositivas trabajan junto con los Patrones de diapositivas para ofrecer flexibilidad en el diseño. Mientras que un Patrón de diapositivas define estilos y temas globales, los Diseños de diapositivas permiten variaciones en la disposición del contenido. La jerarquía es la siguiente:

- **Patrón de diapositivas** → Define estilos globales. 
- **Diseño de diapositiva** → Proporciona diferentes disposiciones de contenido. 
- **Diapositiva** → Hereda el diseño de su Diseño de diapositiva. 

**¿Puedo tener varios Patrones de diapositivas en una sola presentación?**

Sí, una presentación puede contener varios Patrones de diapositivas. Esto permite dar estilo a diferentes secciones de la presentación de distintas maneras, proporcionando flexibilidad en el diseño.  

**¿Cómo accedo y modifico un Patrón de diapositivas usando Aspose.Slides?**

En Aspose.Slides, un Patrón de diapositivas está representado por la interfaz `IMasterSlide`. Puedes acceder a un Patrón de diapositivas usando la propiedad `Masters` del objeto `Presentation`.