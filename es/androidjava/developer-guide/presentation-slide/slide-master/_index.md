---
title: Administrar maestros de diapositivas de presentación en Android
linktitle: Maestro de diapositiva
type: docs
weight: 70
url: /es/androidjava/slide-master/
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
- Android
- Java
- Aspose.Slides
description: "Administre maestros de diapositivas en Aspose.Slides para Android: cree, edite y aplique diseños, temas y marcadores de posición a PPT, PPTX y ODP con ejemplos concisos en Java."
---

## **Qué es un Slide Master en PowerPoint**

Un **Slide Master** es una plantilla de diapositiva que define el diseño, los estilos, el tema, las fuentes, el fondo y otras propiedades para las diapositivas de una presentación. Si desea crear una presentación (o una serie de presentaciones) con el mismo estilo y plantilla para su empresa, puede usar un Slide Master.  

Un Slide Master es útil porque le permite establecer y cambiar el aspecto de todas las diapositivas de la presentación a la vez. Aspose.Slides admite el mecanismo de Slide Master de PowerPoint.  

VBA también le permite manipular un Slide Master y ejecutar las mismas operaciones que admite PowerPoint: cambiar fondos, agregar formas, personalizar el diseño, etc. Aspose.Slides proporciona mecanismos flexibles para usar Slide Masters y realizar tareas básicas con ellos.  

Estas son operaciones básicas de Slide Master:

- Crear un Slide Master.
- Aplicar Slides Master a las diapositivas de la presentación.
- Cambiar el fondo del Slide Master. 
- Agregar una imagen, marcador de posición, Smart Art, etc. al Slide Master.

Estas son operaciones más avanzadas que involucran Slide Master: 

- Comparar Slide Masters.
- Fusionar Slide Masters.
- Aplicar varios Slide Masters.
- Copiar una diapositiva con Slide Master a otra presentación.
- Encontrar Slide Masters duplicados en presentaciones.
- Establecer el Slide Master como vista predeterminada de la presentación.

{{% alert color="primary" %}} 

Es posible que desee consultar Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) porque es una implementación en vivo de algunos de los procesos principales descritos aquí.

{{% /alert %}} 


## **Cómo se aplica un Slide Master**

Antes de trabajar con un Slide Master, quizás quiera comprender cómo se utilizan en las presentaciones y se aplican a las diapositivas. 

* Cada presentación tiene al menos un Slide Master de forma predeterminada. 
* Una presentación puede contener varios Slide Masters. Puede agregar varios Slide Masters y usarlos para dar estilo a diferentes partes de una presentación de distintas maneras. 

En **Aspose.Slides**, un Slide Master está representado por el tipo [**IMasterSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/).  

El objeto [Presentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) de Aspose.Slides contiene la lista [**getMasters**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) del tipo [**IMasterSlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), que contiene una lista de todas las diapositivas maestras definidas en una presentación.  

Además de las operaciones CRUD, la interfaz [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) contiene estos métodos útiles: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) y [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) . Estos métodos se heredan de la función básica de clonación de diapositivas. Pero al trabajar con Slide Masters, esos métodos le permiten implementar configuraciones complejas.  

Cuando se agrega una nueva diapositiva a una presentación, se le aplica automáticamente un Slide Master. El Slide Master de la diapositiva anterior se selecciona de forma predeterminada.  

**Nota**: Las diapositivas de la presentación se almacenan en la lista [getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--), y cada nueva diapositiva se agrega al final de la colección de forma predeterminada. Si una presentación contiene un único Slide Master, ese Slide Master se selecciona para todas las nuevas diapositivas. Esta es la razón por la que no necesita definir el Slide Master para cada nueva diapositiva que cree.  

El principio es el mismo para PowerPoint y Aspose.Slides. Por ejemplo, en PowerPoint, cuando agrega una nueva diapositiva, puede simplemente pulsar en la línea inferior bajo la última diapositiva y entonces se creará una nueva diapositiva (con el Slide Master de la última presentación):  

![todo:image_alt_text](slide-master_1.jpg)

En Aspose.Slides, puede realizar la tarea equivalente con el método [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) de la clase [Presentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).  


## **Slide Master en la jerarquía de diapositivas**

Usar Slide Layouts con Slide Master permite la máxima flexibilidad. Un Slide Layout le permite establecer los mismos estilos que el Slide Master (fondo, fuentes, formas, etc.). Sin embargo, cuando varios Slide Layouts se combinan en un Slide Master, se crea un nuevo estilo. Cuando aplica un Slide Layout a una sola diapositiva, puede cambiar su estilo respecto al aplicado por el Slide Master.  

Slide Master tiene prioridad sobre todos los elementos de configuración: Slide Master -> Slide Layout -> Slide:  

![todo:image_alt_text](slide-master_2)

Cada objeto [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) tiene una propiedad [**getLayoutSlides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getLayoutSlides--) con una lista de Slide Layouts. Un tipo [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide) posee una propiedad [**getLayoutSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getLayoutSlide--) que enlaza a un Slide Layout aplicado a la diapositiva. La interacción entre una diapositiva y el Slide Master ocurre a través de un Slide Layout.  

{{% alert color="info" title="Note" %}}

* En Aspose.Slides, todas las configuraciones de diapositiva (Slide Master, Slide Layout y la propia diapositiva) son en realidad objetos de diapositiva que implementan la interfaz [**IBaseSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide).  
* Por lo tanto, Slide Master y Slide Layout pueden implementar las mismas propiedades y debe saber cómo se aplicarán sus valores a un objeto [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide). El Slide Master se aplica primero a una diapositiva y luego se aplica el Slide Layout. Por ejemplo, si el Slide Master y el Slide Layout tienen ambos un valor de fondo, la diapositiva terminará con el fondo del Slide Layout.  

{{% /alert %}}


## **Qué contiene un Slide Master**

Para comprender cómo se puede modificar un Slide Master, necesita conocer sus componentes. Estas son las propiedades principales de [MasterSlide](https://reference.aspose.com/slides/androidjava/aspose.slides/masterslide/).  

- [getBackground](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getBackground--) obtener/establecer el fondo de la diapositiva.  
- [getBodyStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getBodyStyle--) - obtener/establecer los estilos de texto del cuerpo de la diapositiva.  
- [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getShapes--) obtener/establecer todas las formas del Slide Master (marcadores de posición, marcos de imagen, etc).  
- [getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getControls--) obtener/establecer controles ActiveX.  
- [getThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterThemeable#getThemeManager--) - obtener el gestor de temas.  
- [getHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) - obtener el gestor de encabezado y pie de página.  

Métodos de Slide Master:  

- [getDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getDependingSlides--) - obtener todas las diapositivas que dependen del Slide Master.  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - permite crear un nuevo Slide Master basado en el Slide Master actual y un nuevo tema. El nuevo Slide Master se aplicará entonces a todas las diapositivas dependientes.  


## **Obtener un Slide Master**

En PowerPoint, el Slide Master se puede acceder desde el menú Ver -> Slide Master:  

![todo:image_alt_text](slide-master_3.jpg)

Con Aspose.Slides, puede acceder a un Slide Master de esta manera:  
```java
Presentation pres = new Presentation();
try {
    // Da acceso a la diapositiva maestra de la presentación
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


La interfaz [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) representa un Slide Master. La propiedad [Masters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getMasters--) (relacionada con el tipo [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/)) contiene una lista de todos los Slide Masters definidos en la presentación.  



## **Agregar una imagen a un Slide Master**

Cuando agrega una imagen a un Slide Master, esa imagen aparecerá en todas las diapositivas dependientes de ese Slide Master.  

Por ejemplo, puede colocar el logotipo de su empresa y algunas imágenes en el Slide Master y luego volver al modo de edición de diapositivas. Debería ver la imagen en cada diapositiva.  

![todo:image_alt_text](slide-master_4.png)

Puede agregar imágenes a un Slide Master con Aspose.Slides:  
```java
Presentation pres = new Presentation();
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    pres.getMasters().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="See also" %}} 

Para obtener más información sobre cómo agregar imágenes a una diapositiva, consulte el artículo [Picture Frame](/slides/es/androidjava/picture-frame/#create-picture-frame).

{{% /alert %}}


## **Agregar un marcador de posición a un Slide Master**

Estos campos de texto son marcadores de posición estándar en un Slide Master: 

* Haga clic para editar el estilo del título del Master
* Editar los estilos de texto del Master
* Segundo nivel
* Tercer nivel  

También aparecen en las diapositivas basadas en el Slide Master. Puede editar esos marcadores de posición en un Slide Master y los cambios se aplican automáticamente a las diapositivas.  

En PowerPoint, puede agregar un marcador de posición a través de la ruta Slide Master -> Insert Placeholder:  

![todo:image_alt_text](slide-master_5.png)

Examinemos un ejemplo más complicado de marcadores de posición con Aspose.Slides. Considere una diapositiva con marcadores de posición basados en el Slide Master:  

![todo:image_alt_text](slide-master_6.png)

Queremos cambiar el formato del Título y Subtítulo en el Slide Master de esta manera:  

![todo:image_alt_text](slide-master_7.png)

Primero, recuperamos el contenido del marcador de posición de título del objeto Slide Master y luego usamos el campo `PlaceHolder.FillFormat`:  
```java
public static void main(String[] args) {
    Presentation pres = new Presentation();
    try {
        IMasterSlide master = pres.getMasters().get_Item(0);
        IAutoShape placeHolder = findPlaceholder(master, PlaceholderType.Title);
        placeHolder.getFillFormat().setFillType(FillType.Gradient);
        placeHolder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(0, new Color(255, 0, 0));
        placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(255, new Color(128, 0, 128));

        pres.save("pres.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
}

static IAutoShape findPlaceholder(IMasterSlide master, int type)
{
    for (IShape shape : master.getShapes())
    {
        IAutoShape autoShape = (IAutoShape) shape;
        if (autoShape != null)
        {
            if (autoShape.getPlaceholder().getType() == type)
            {
                return autoShape;
            }
        }
    }

    return null;
}
```


El estilo y formato del título cambiarán para todas las diapositivas basadas en el Slide Master:  

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/androidjava/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/androidjava/text-formatting/)

{{% /alert %}}


## **Cambiar el fondo en un Slide Master**

Cuando cambia el color de fondo de una diapositiva maestra, todas las diapositivas normales de la presentación obtendrán el nuevo color. Este código Java demuestra la operación:  
```java
Presentation pres = new Presentation();
try {
    IMasterSlide master = pres.getMasters().get_Item(0);
    master.getBackground().setType(BackgroundType.OwnBackground);
    master.getBackground().getFillFormat().setFillType(FillType.Solid);
    master.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="See also" %}} 

- [Presentation Background](https://docs.aspose.com/slides/androidjava/presentation-background/)

- [Presentation Theme](https://docs.aspose.com/slides/androidjava/presentation-theme/)

{{% /alert %}}


## **Clonar un Slide Master a otra presentación**

Para clonar un Slide Master a otra presentación, llame al método [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) de la presentación de destino junto con un Slide Master pasado como argumento. Este código Java le muestra cómo clonar un Slide Master a otra presentación:  
```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```



## **Agregar varios Slide Masters a una presentación**

Aspose.Slides le permite agregar varios Slide Masters y Slide Layouts a cualquier presentación. Esto le permite configurar estilos, diseños y opciones de formato para las diapositivas de la presentación de diversas maneras.  

En PowerPoint, puede agregar nuevos Slide Masters y Layouts (desde el menú "Slide Master") de esta forma:  

![todo:image_alt_text](slide-master_9.jpg)

Con Aspose.Slides, puede agregar un nuevo Slide Master llamando al método [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-):  
```java
// Agrega una nueva diapositiva maestra
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **Comparar Slide Masters**

Un Master Slide implementa la interfaz [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) que contiene el método [**equals**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-) , el cual puede usarse para comparar diapositivas. Devuelve `true` para Master Slides idénticos en estructura y contenido estático.  

Dos Master Slides son iguales si sus formas, estilos, textos, animaciones y demás configuraciones son iguales. La comparación no tiene en cuenta los valores de identificadores únicos (p. ej., SlideId) ni el contenido dinámico (p. ej., el valor de fecha actual en el marcador de posición de fecha).  


## **Establecer un Slide Master como vista predeterminada de la presentación**

Aspose.Slides le permite establecer un Slide Master como vista predeterminada de una presentación. La vista predeterminada es lo que ve primero al abrir una presentación.  

Este código le muestra cómo establecer un Slide Master como vista predeterminada de la presentación en Java:  
```java
// Instancia una clase Presentation que representa el archivo de presentación
Presentation presentation = new Presentation();
try {
    // Establece la vista predeterminada como SlideMasterView
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // Guarda la presentación
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```



## **Eliminar diapositivas maestras no usadas**

Aspose.Slides proporciona el método [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (de la clase [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)) para permitirle eliminar diapositivas maestras no deseadas y no usadas. Este código Java muestra cómo eliminar una diapositiva maestra de una presentación PowerPoint:  
```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```



## **Preguntas frecuentes**

**¿Qué es un Slide Master en PowerPoint?**

Un Slide Master es una plantilla de diapositiva que define el diseño, los estilos, los temas, las fuentes, el fondo y otras propiedades de las diapositivas en una presentación. Le permite establecer y cambiar el aspecto de todas las diapositivas de la presentación a la vez.  

**¿Cómo se aplica un Slide Master en una presentación?**

Cada presentación tiene al menos un Slide Master de forma predeterminada. Cuando se agrega una nueva diapositiva, se le aplica automáticamente un Slide Master, normalmente heredando el maestro de la diapositiva anterior. Una presentación puede contener varios Slide Masters para dar estilo a diferentes partes de forma única.  

**¿Qué elementos pueden personalizarse en un Slide Master?**

Un Slide Master comprende varias propiedades principales que pueden personalizarse:

- **Background**: Establecer el fondo de la diapositiva.  
- **BodyStyle**: Definir los estilos de texto del cuerpo de la diapositiva.  
- **Shapes**: Administrar todas las formas en el Slide Master, incluidos los marcadores de posición y los marcos de imágenes.  
- **Controls**: Gestionar controles ActiveX.  
- **ThemeManager**: Acceder al gestor de temas.  
- **HeaderFooterManager**: Administrar encabezados y pies de página.  

**¿Cómo puedo agregar una imagen a un Slide Master?**

Agregar una imagen a un Slide Master asegura que aparezca en todas las diapositivas que dependen de ese maestro. Por ejemplo, colocar el logotipo de la empresa en el Slide Master lo mostrará en cada diapositiva de la presentación.  

**¿Cómo se relacionan los Slide Masters con los Slide Layouts?**

Los Slide Layouts funcionan en conjunto con los Slide Masters para proporcionar flexibilidad en el diseño de diapositivas. Mientras un Slide Master define estilos y temas generales, los Slide Layouts permiten variaciones en la disposición del contenido. La jerarquía es la siguiente:

- **Slide Master** → Define estilos globales.  
- **Slide Layout** → Proporciona diferentes disposiciones de contenido.  
- **Slide** → Hereda el diseño de su Slide Layout.  

**¿Puedo tener varios Slide Masters en una sola presentación?**

Sí, una presentación puede contener varios Slide Masters. Esto le permite dar estilo a diferentes secciones de la presentación de diversas maneras, proporcionando flexibilidad en el diseño.  

**¿Cómo accedo y modifico un Slide Master usando Aspose.Slides?**

En Aspose.Slides, un Slide Master está representado por la interfaz [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/). Puede acceder a un Slide Master mediante el método [getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) del objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).