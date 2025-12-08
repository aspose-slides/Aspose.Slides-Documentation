---
title: ¿Qué es Slide Master en PowerPoint? Guía de definición y uso
linktitle: Slide Master
type: docs
weight: 80
url: /es/net/slide-master/
keywords: "Agregar Slide Master, diapositiva maestra PPT, Slide Master PowerPoint, Imagen a Slide Master, Marcador de posición, Varios Slide Masters, Comparar Slide Masters, C#, Csharp, .NET, Aspose.Slides"
description: "Aprenda qué es un Slide Master en PowerPoint y cómo le ayuda a controlar los diseños de diapositivas, fuentes, colores y la imagen de marca. Guía paso a paso fácil con ejemplos en C# o .NET."
---

## **Qué es un Slide Master en PowerPoint**
Un **Slide Master** en PowerPoint es una función que controla el diseño, las fuentes y los estilos en múltiples diapositivas. Ayuda a mantener la consistencia y la imagen de marca en las presentaciones. Si desea crear una presentación (o una serie de presentaciones) con el mismo estilo y plantilla para su empresa, puede usar un Slide Master. 

Un Slide Master es útil porque le permite establecer y cambiar el aspecto de todas las diapositivas de la presentación a la vez. Aspose.Slides admite el mecanismo de Slide Master de PowerPoint. 

VBA también permite manipular un Slide Master y ejecutar las mismas operaciones compatibles en PowerPoint: cambiar fondos, agregar formas, personalizar el diseño, etc. Aspose.Slides proporciona mecanismos flexibles para permitirle usar Slide Masters y realizar tareas básicas con ellos. 

Estas son operaciones básicas de Slide Master:

- Crear un Slide Master.
- Aplicar Slide Master a las diapositivas de la presentación.
- Cambiar el fondo del Slide Master. 
- Agregar una imagen, marcador de posición, Smart Art, etc. al Slide Master.

Estas son operaciones más avanzadas que involucran Slide Master: 

- Comparar Slide Masters.
- Combinar Slide Masters.
- Aplicar varios Slide Masters.
- Copiar diapositiva con Slide Master a otra presentación.
- Encontrar Slide Masters duplicados en presentaciones.
- Establecer Slide Master como la vista predeterminada de la presentación.

{{% alert color="primary" %}} 

Es posible que desee consultar Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) porque es una implementación en vivo de algunos de los procesos clave descritos aquí.

{{% /alert %}} 


## **Cómo se aplica el Slide Master**
Antes de trabajar con un Slide Master, es posible que desee comprender cómo se usan en las presentaciones y se aplican a las diapositivas. 

* Cada presentación tiene al menos un Slide Master por defecto. 
* Una presentación puede contener varios Slide Masters. Puede agregar varios Slide Masters y usarlos para dar estilo a diferentes partes de una presentación de distintas maneras. 

En **Aspose.Slides**, un Slide Master está representado por el tipo [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide). 

El objeto [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) de Aspose.Slides contiene la lista de [**Masters** ](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters) de tipo [**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection), que contiene una lista de todos los master slides definidos en una presentación. 

Además de las operaciones CRUD, la interfaz [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) incluye estos métodos útiles: los métodos [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) y [**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone). Esos métodos se heredan de la función básica de clonación de diapositivas. Pero al trabajar con Slide Masters, esos métodos le permiten implementar configuraciones complicadas. 

Cuando se agrega una nueva diapositiva a una presentación, se le aplica automáticamente un Slide Master. Por defecto, se selecciona el Slide Master de la diapositiva anterior. 

**Nota**: Las diapositivas de la presentación se almacenan en la lista [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides), y cada nueva diapositiva se agrega al final de la colección por defecto. Si una presentación contiene un solo Slide Master, ese master se selecciona para todas las nuevas diapositivas. Esta es la razón por la que no tiene que definir el Slide Master para cada nueva diapositiva que cree.

El principio es el mismo para PowerPoint y Aspose.Slides. Por ejemplo, en PowerPoint, cuando agrega una nueva presentación, puede simplemente hacer clic en la línea inferior bajo la última diapositiva y entonces se creará una nueva diapositiva (con el Slide Master de la última presentación):

![todo:image_alt_text](slide-master_1.jpg)

En Aspose.Slides, puede realizar la tarea equivalente con el método [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone) de la clase [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).


## **Slide Master en la jerarquía de Slides**
Usar Slide Layouts con Slide Master permite la máxima flexibilidad. Un Slide Layout le permite establecer los mismos estilos que el Slide Master (fondo, fuentes, formas, etc.). Sin embargo, cuando se combinan varios Slide Layouts en un Slide Master, se crea un nuevo estilo. Cuando aplica un Slide Layout a una sola diapositiva, puede cambiar su estilo respecto al aplicado por el Slide Master.

Slide Master supera a todos los elementos de configuración: Slide Master -> Slide Layout -> Slide:

![todo:image_alt_text](slide-master_2)



Cada objeto [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) tiene una propiedad [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides) con una lista de Slide Layouts. Un tipo [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) tiene una propiedad [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide) con un vínculo al Slide Layout aplicado a la diapositiva. La interacción entre una diapositiva y el Slide Master ocurre a través de un Slide Layout.

{{% alert color="info" title="Note" %}}

* En Aspose.Slides, todas las configuraciones de diapositiva (Slide Master, Slide Layout y la propia diapositiva) son en realidad objetos de diapositiva que implementan la interfaz [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide).
* Por lo tanto, Slide Master y Slide Layout pueden implementar las mismas propiedades y necesita saber cómo se aplicarán sus valores a un objeto [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/). El Slide Master se aplica primero a una diapositiva y luego se aplica el Slide Layout. Por ejemplo, si el Slide Master y el Slide Layout ambos tienen un valor de fondo, la diapositiva terminará con el fondo del Slide Layout.

{{% /alert %}}


## **Qué compone un Slide Master**
Para comprender cómo se puede cambiar un Slide Master, necesita conocer sus componentes. Estas son las propiedades principales de [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/). 

- [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) - obtener/establecer el fondo de la diapositiva.
- [BodyStyle](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) - obtener/establecer los estilos de texto del cuerpo de la diapositiva.
- [Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) - obtener/establecer todas las formas del Slide Master (marcadores de posición, marcos de imagen, etc.).
- [Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) - obtener/establecer controles ActiveX.
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) - obtener el administrador de temas.
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) - obtener el administrador de encabezados y pies de página.

Métodos del Slide Master:

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) - obtener todas las diapositivas que dependen del Slide Master.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) - permite crear un nuevo Slide Master basado en el Slide Master actual y un tema nuevo. El nuevo Slide Master se aplicará entonces a todas las diapositivas dependientes.


## **Obtener Slide Master**
En PowerPoint, el Slide Master se puede acceder desde el menú Ver -> Slide Master:

![todo:image_alt_text](slide-master_3.jpg)



Usando Aspose.Slides, puede acceder a un Slide Master de esta manera:
```c#
IMasterSlide master = pres.Masters[0];
```


La interfaz [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) representa un Slide Master. La propiedad [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) (relacionada con el tipo [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)) contiene una lista de todos los Slide Masters definidos en la presentación. 


## **Agregar imagen al Slide Master**
Al agregar una imagen a un Slide Master, esa imagen aparecerá en todas las diapositivas que dependen de ese master. 

Por ejemplo, puede colocar el logotipo de su empresa y algunas imágenes en el Slide Master y luego volver al modo de edición de diapositivas. Debería ver la imagen en cada diapositiva. 

![todo:image_alt_text](slide-master_4.png)

Puede agregar imágenes a un Slide Master con Aspose.Slides: 
```c#
using (Presentation pres = new Presentation())
{
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    pres.Masters[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" title="See also" %}} 

Para obtener más información sobre cómo agregar imágenes a una diapositiva, consulte el artículo [Picture Frame](/slides/es/net/picture-frame/#create-picture-frame).

{{% /alert %}}


## **Agregar marcador de posición al Slide Master**
Estos campos de texto son marcadores de posición estándar en un Slide Master: 

* Haga clic para editar el estilo del título del Master

* Editar estilos de texto del Master

* Segundo nivel

* Tercer nivel 

  También aparecen en las diapositivas basadas en el Slide Master. Puede editar esos marcadores de posición en un Slide Master y los cambios se aplicarán automáticamente a las diapositivas. 

En PowerPoint, puede agregar un marcador de posición a través de la ruta Slide Master -> Insert Placeholder:



![todo:image_alt_text](slide-master_5.png)



Examinemos un ejemplo más complicado de marcadores de posición con Aspose.Slides. Considere una diapositiva con marcadores de posición creados a partir del Slide Master:



![todo:image_alt_text](slide-master_6.png)



Queremos cambiar el formato del Título y Subtítulo en el Slide Master de esta manera:

![todo:image_alt_text](slide-master_7.png)



Primero, recuperamos el contenido del marcador de posición del título del objeto Slide Master y luego usamos el campo `PlaceHolder.FillFormat`: 
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


El estilo y formato del título cambiarán para todas las diapositivas basadas en el slide master:



![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/net/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/net/text-formatting/)

{{% /alert %}}


## **Cambiar fondo en Slide Master**
Al cambiar el color de fondo de una diapositiva maestra, todas las diapositivas normales de la presentación obtendrán el nuevo color. Este código C# demuestra la operación:
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


{{% alert color="primary" title="See also" %}} 
- [Presentation Background](https://docs.aspose.com/slides/net/presentation-background/)

- [Presentation Theme](https://docs.aspose.com/slides/net/presentation-theme/)

{{% /alert %}}

## **Clonar Slide Master a otra presentación**
Para clonar un Slide Master a otra presentación, llame al método [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) de la presentación de destino pasando el Slide Master. Este código C# le muestra cómo clonar un Slide Master a otra presentación:
```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```



## **Agregar varios Slide Masters a la presentación**
Aspose.Slides le permite agregar varios Slide Masters y Slide Layouts a cualquier presentación. Esto le permite configurar estilos, diseños y opciones de formato para las diapositivas de la presentación de muchas formas. 

En PowerPoint, puede agregar nuevos Slide Masters y Layouts (desde el menú "Slide Master") de esta manera:

![todo:image_alt_text](slide-master_9.jpg)

Usando Aspose.Slides, puede agregar un nuevo Slide Master llamando al método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/):
```c#
pres.Masters.AddClone(pres.Masters[0]);
```



## **Comparar Slide Masters**
Un Master Slide implementa la interfaz [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) que contiene el método [Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals), que puede usarse para comparar diapositivas. Devuelve `true` para Master Slides idénticos en estructura y contenido estático. 

Dos Master Slides son iguales si sus formas, estilos, textos, animaciones y otras configuraciones son iguales. La comparación no tiene en cuenta los valores de identificadores únicos (p. ej., SlideId) ni el contenido dinámico (p. ej., valor de fecha actual en el marcador de posición de fecha). 


## **Establecer Slide Master como vista predeterminada de la presentación**
Aspose.Slides le permite establecer un Slide Master como la vista predeterminada de una presentación. La vista predeterminada es lo que ve primero al abrir una presentación. 

Este código le muestra cómo establecer un Slide Master como la vista predeterminada de una presentación en C#:
```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```


## **Eliminar Slide Master no usado**

Aspose.Slides proporciona el método [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la clase [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) para permitirle eliminar master slides no deseados y no usados. Este código C# le muestra cómo eliminar un master slide de una presentación PowerPoint:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Qué es un Slide Master en PowerPoint?**

Un Slide Master es una plantilla de diapositiva que define el diseño, los estilos, los temas, las fuentes, el fondo y otras propiedades para las diapositivas de una presentación. Le permite establecer y cambiar el aspecto de todas las diapositivas de la presentación a la vez.  

**¿Cómo se aplica un Slide Master en una presentación?**

Cada presentación tiene al menos un Slide Master por defecto. Cuando se agrega una nueva diapositiva, se le aplica automáticamente un Slide Master, generalmente heredando el master de la diapositiva anterior. Una presentación puede contener varios Slide Masters para dar estilo a diferentes partes de forma única.  

**¿Qué elementos pueden personalizarse en un Slide Master?**

Un Slide Master comprende varias propiedades principales que pueden personalizarse:

- **Background**: Establecer el fondo de la diapositiva.
- **BodyStyle**: Definir los estilos de texto del cuerpo de la diapositiva.
- **Shapes**: Gestionar todas las formas del Slide Master, incluidos marcadores de posición y marcos de imagen.
- **Controls**: Manejar controles ActiveX.
- **ThemeManager**: Acceder al administrador de temas.
- **HeaderFooterManager**: Gestionar encabezados y pies de página.  

**¿Cómo puedo agregar una imagen a un Slide Master?**

Agregar una imagen a un Slide Master asegura que aparezca en todas las diapositivas que dependen de ese master. Por ejemplo, colocar el logotipo de la empresa en el Slide Master lo mostrará en cada diapositiva de la presentación.  

**¿Cómo se relacionan los Slide Masters con los Slide Layouts?**

Los Slide Layouts trabajan en conjunto con los Slide Masters para proporcionar flexibilidad en el diseño de diapositivas. Mientras que un Slide Master define los estilos y temas globales, los Slide Layouts permiten variaciones en la disposición del contenido. La jerarquía es la siguiente:

- **Slide Master** → Define estilos globales.
- **Slide Layout** → Proporciona diferentes disposiciones de contenido.
- **Slide** → Hereda el diseño de su Slide Layout.

**¿Puedo tener varios Slide Masters en una sola presentación?**

Sí, una presentación puede contener varios Slide Masters. Esto le permite dar estilo a diferentes secciones de una presentación de diversas maneras, proporcionando flexibilidad en el diseño.  

**¿Cómo accedo y modifico un Slide Master usando Aspose.Slides?**

En Aspose.Slides, un Slide Master está representado por la interfaz `IMasterSlide`. Puede acceder a un Slide Master usando la propiedad `Masters` del objeto `Presentation`.