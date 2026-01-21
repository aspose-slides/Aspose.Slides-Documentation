---
title: Gestionar patrones de diapositivas de presentación en Java
linktitle: Patrón de diapositiva
type: docs
weight: 70
url: /es/java/slide-master/
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
- Java
- Aspose.Slides
description: "Gestionar patrones de diapositivas en Aspose.Slides para Java: crear, editar y aplicar diseños, temas y marcadores de posición a PPT, PPTX y ODP con ejemplos concisos en Java."
---

## **Qué es un Patrón de diapositivas en PowerPoint**

Un **Patrón de diapositivas** es una plantilla de diapositiva que define el diseño, los estilos, el tema, las fuentes, el fondo y otras propiedades de las diapositivas en una presentación. Si deseas crear una presentación (o una serie de presentaciones) con el mismo estilo y plantilla para tu empresa, puedes usar un patrón de diapositivas. 

Un Patrón de diapositivas es útil porque permite establecer y cambiar el aspecto de todas las diapositivas de la presentación de una sola vez. Aspose.Slides admite el mecanismo de Patrón de diapositivas de PowerPoint. 

VBA también permite manipular un Patrón de diapositivas y ejecutar las mismas operaciones admitidas en PowerPoint: cambiar fondos, añadir formas, personalizar el diseño, etc. Aspose.Slides proporciona mecanismos flexibles para que puedas usar Patrones de diapositivas y realizar tareas básicas con ellos. 

Estas son operaciones básicas de Patrón de diapositivas:

- Crear un Patrón de diapositivas.  
- Aplicar el Patrón de diapositivas a las diapositivas de la presentación.  
- Cambiar el fondo del Patrón de diapositivas.  
- Añadir una imagen, marcador de posición, Smart Art, etc., al Patrón de diapositivas.  

Estas son operaciones más avanzadas con el Patrón de diapositivas: 

- Comparar Patrones de diapositivas.  
- Combinar Patrones de diapositivas.  
- Aplicar varios Patrones de diapositivas.  
- Copiar una diapositiva con Patrón de diapositivas a otra presentación.  
- Encontrar Patrones de diapositivas duplicados en presentaciones.  
- Establecer el Patrón de diapositivas como vista predeterminada de la presentación.  

{{% alert color="primary" %}} 

Quizá quieras probar Aspose [**Visor online de PowerPoint**](https://products.aspose.app/slides/viewer) porque es una implementación en vivo de algunos de los procesos principales descritos aquí.

{{% /alert %}} 


## **Cómo se aplica un Patrón de diapositivas**

Antes de trabajar con un Patrón de diapositivas, quizá quieras entender cómo se utilizan en las presentaciones y se aplican a las diapositivas. 

* Cada presentación tiene al menos un Patrón de diapositivas por defecto. 
* Una presentación puede contener varios Patrones de diapositivas. Puedes añadir varios Patrones de diapositivas y utilizarlos para dar estilo a diferentes partes de una presentación de diferentes maneras. 

En **Aspose.Slides**, un Patrón de diapositivas está representado por [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) tipo. 

El objeto [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) de Aspose.Slides contiene la lista [**getMasters**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) de tipo [**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) que contiene una lista de todos los patrones de diapositivas que están definidos en una presentación. 

Además de las operaciones CRUD, la interfaz [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) contiene estos métodos útiles: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) y [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) . Esos métodos se heredan de la función básica de clonación de diapositivas. Pero al trabajar con Patrones de diapositivas, esos métodos permiten implementar configuraciones complicadas. 

Cuando se añade una nueva diapositiva a una presentación, se le aplica automáticamente un Patrón de diapositivas. Por defecto se selecciona el Patrón de diapositivas de la diapositiva anterior. 

**Nota**: Las diapositivas de la presentación se almacenan en la lista [getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) y cada nueva diapositiva se agrega al final de la colección por defecto. Si una presentación contiene un único Patrón de diapositivas, ese patrón se selecciona para todas las nuevas diapositivas. Esta es la razón por la que no tienes que definir el Patrón de diapositivas para cada nueva diapositiva que creas.

El principio es el mismo para PowerPoint y Aspose.Slides. Por ejemplo, en PowerPoint, cuando añades una nueva diapositiva, puedes simplemente pulsar en la línea inferior bajo la última diapositiva y entonces se creará una nueva diapositiva (con el Patrón de diapositivas de la presentación anterior):

![todo:image_alt_text](slide-master_1.jpg)

En Aspose.Slides, puedes realizar la tarea equivalente con el método [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) bajo la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).


## **Patrón de diapositivas en la jerarquía de Slides**

Usar Diseños de diapositiva con el Patrón de diapositivas permite la máxima flexibilidad. Un Diseño de diapositiva permite establecer los mismos estilos que el Patrón de diapositivas (fondo, fuentes, formas, etc.). Sin embargo, cuando varios Diseños de diapositiva se combinan en un Patrón de diapositivas, se crea un nuevo estilo. Cuando aplicas un Diseño de diapositiva a una sola diapositiva, puedes cambiar su estilo respecto al aplicado por el Patrón de diapositivas.

El Patrón de diapositivas supera a todos los elementos de configuración: Patrón de diapositivas → Diseño de diapositiva → Diapositiva:

![todo:image_alt_text](slide-master_2)



Cada objeto [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) tiene una propiedad [**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) con una lista de Diseños de diapositiva. Un tipo [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) tiene una propiedad [**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--) con un enlace a un Diseño de diapositiva aplicado a la diapositiva. La interacción entre una diapositiva y el Patrón de diapositivas ocurre a través de un Diseño de diapositiva.

{{% alert color="info" title="Nota" %}}

* En Aspose.Slides, todas las configuraciones de diapositiva (Patrón de diapositivas, Diseño de diapositiva y la propia diapositiva) son en realidad objetos de diapositiva que implementan la interfaz [**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide).  
* Por lo tanto, Patrón de diapositivas y Diseño de diapositiva pueden implementar las mismas propiedades y debes saber cómo se aplicarán sus valores a un objeto [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide). El Patrón de diapositivas se aplica primero a una diapositiva y luego se aplica el Diseño de diapositiva. Por ejemplo, si el Patrón de diapositivas y el Diseño de diapositiva tienen ambos un valor de fondo, la diapositiva terminará con el fondo del Diseño de diapositiva.

{{% /alert %}}


## **Qué contiene un Patrón de diapositivas**

Para entender cómo se puede modificar un Patrón de diapositivas, necesitas conocer sus componentes. Estas son las propiedades principales de [MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/). 

- [getBackground](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) get/set fondo de la diapositiva.  
- [getBodyStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) get/set estilos de texto del cuerpo de la diapositiva.  
- [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) get/set todas las formas del Patrón de diapositivas (marcadores de posición, marcos de imagen, etc.).  
- [getControls](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) get/set controles ActiveX.  
- [getThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) get/get gestor de temas.  
- [getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) get/get gestor de encabezado y pie de página.  

Métodos del Patrón de diapositivas:

- [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) get/get todas las diapositivas que dependen del Patrón de diapositivas.  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) permite crear un nuevo Patrón de diapositivas basado en el actual y un nuevo tema. El nuevo Patrón de diapositivas se aplicará a todas las diapositivas dependientes.  


## **Obtener un Patrón de diapositivas**

En PowerPoint, el Patrón de diapositivas se puede acceder desde el menú Vista → Patrón de diapositivas:

![todo:image_alt_text](slide-master_3.jpg)



Con Aspose.Slides, puedes acceder a un Patrón de diapositivas de esta manera: 
```java
Presentation pres = new Presentation();
try {
    // Da acceso al patrón maestro de la presentación
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


La interfaz [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) representa un Patrón de diapositivas. La propiedad [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) (relacionada con el tipo [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection)) contiene una lista de todos los Patrones de diapositivas que están definidos en la presentación.  


## **Añadir una imagen a un Patrón de diapositivas**

Cuando añades una imagen a un Patrón de diapositivas, esa imagen aparecerá en todas las diapositivas que dependan de ese patrón. 

Por ejemplo, puedes colocar el logotipo de tu empresa y algunas imágenes en el Patrón de diapositivas y luego volver al modo de edición de diapositivas. Deberías ver la imagen en cada diapositiva. 

![todo:image_alt_text](slide-master_4.png)

Puedes añadir imágenes a un Patrón de diapositivas con Aspose.Slides:
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


{{% alert color="primary" title="Ver también" %}} 

Para más información sobre cómo añadir imágenes a una diapositiva, consulta el artículo [Picture Frame](/slides/es/java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Añadir un marcador de posición a un Patrón de diapositivas**

Estos campos de texto son marcadores de posición estándar en un Patrón de diapositivas: 

* Haz clic para editar el estilo del título del patrón  
* Editar los estilos de texto del patrón  
* Segundo nivel  
* Tercer nivel  

También aparecen en las diapositivas basadas en el Patrón de diapositivas. Puedes editar esos marcadores de posición en un Patrón de diapositivas y los cambios se aplicarán automáticamente a las diapositivas. 

En PowerPoint, puedes añadir un marcador de posición a través de la ruta Patrón de diapositivas → Insertar marcador de posición:

![todo:image_alt_text](slide-master_5.png)

Veamos un ejemplo más complicado de marcadores de posición con Aspose.Slides. Considera una diapositiva con marcadores de posición basados en el Patrón de diapositivas:

![todo:image_alt_text](slide-master_6.png)

Queremos cambiar el formato del Título y el Subtítulo en el Patrón de diapositivas de esta manera:

![todo:image_alt_text](slide-master_7.png)

Primero, obtenemos el contenido del marcador de posición del título del objeto Patrón de diapositivas y luego usamos el campo `PlaceHolder.FillFormat`:
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


El estilo y formato del título cambiará en todas las diapositivas basadas en el patrón:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Ver también" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/java/manage-placeholder/)  
* [Text Formatting](https://docs.aspose.com/slides/java/text-formatting/)

{{% /alert %}}


## **Cambiar el fondo en un Patrón de diapositivas**

Cuando cambias el color de fondo de una diapositiva maestra, todas las diapositivas normales de la presentación obtendrán el nuevo color. Este código Java demuestra la operación:
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


{{% alert color="primary" title="Ver también" %}} 

- [Presentation Background](https://docs.aspose.com/slides/java/presentation-background/)  
- [Presentation Theme](https://docs.aspose.com/slides/java/presentation-theme/)

{{% /alert %}}

## **Clonar un Patrón de diapositivas a otra presentación**

Para clonar un Patrón de diapositivas a otra presentación, llama al método [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) de la presentación de destino junto con un Patrón de diapositivas pasado como argumento. Este código Java muestra cómo clonar un Patrón de diapositivas a otra presentación:
```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```



## **Añadir varios Patrones de diapositivas a una presentación**

Aspose.Slides permite añadir varios Patrones de diapositivas y Diseños de diapositiva a cualquier presentación. Esto permite configurar estilos, diseños y opciones de formato para las diapositivas de la presentación de muchas maneras. 

En PowerPoint, puedes añadir nuevos Patrones de diapositivas y Diseños (desde el “menú Patrón de diapositivas”) de esta forma:

![todo:image_alt_text](slide-master_9.jpg)

Con Aspose.Slides, puedes añadir un nuevo Patrón de diapositivas llamando al método [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-):
```java
// Añade una nueva diapositiva maestra
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **Comparar Patrones de diapositivas**

Un Patrón de diapositivas implementa la interfaz [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) que contiene el método [**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-), que puede usarse para comparar diapositivas. Devuelve `true` para Patrones de diapositivas idénticos en estructura y contenido estático. 

Dos Patrones de diapositivas son iguales si sus formas, estilos, textos, animaciones y demás configuraciones son iguales. La comparación no tiene en cuenta valores de identificadores únicos (p. ej., SlideId) ni contenido dinámico (p. ej., el valor de fecha actual en un marcador de posición de fecha). 


## **Establecer un Patrón de diapositivas como vista predeterminada de la presentación**

Aspose.Slides permite establecer un Patrón de diapositivas como vista predeterminada de una presentación. La vista predeterminada es lo que ves primero al abrir una presentación. 

Este código muestra cómo establecer un Patrón de diapositivas como vista predeterminada de una presentación en Java:
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


## **Eliminar Patrones de diapositivas no utilizados**

Aspose.Slides proporciona el método [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (de la clase [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)) para permitir eliminar patrones de diapositivas no deseados y sin usar. Este código Java muestra cómo eliminar un patrón de diapositivas de una presentación PowerPoint:
```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```


## **FAQ**

**¿Qué es un Patrón de diapositivas en PowerPoint?**

Un Patrón de diapositivas es una plantilla de diapositiva que define el diseño, los estilos, los temas, las fuentes, el fondo y otras propiedades de las diapositivas en una presentación. Permite establecer y cambiar el aspecto de todas las diapositivas de la presentación de una sola vez.  

**¿Cómo se aplica un Patrón de diapositivas en una presentación?**

Cada presentación tiene al menos un Patrón de diapositivas por defecto. Cuando se añade una nueva diapositiva, se le aplica automáticamente un Patrón de diapositivas, normalmente heredando el patrón de la diapositiva anterior. Una presentación puede contener varios Patrones de diapositivas para dar estilo a diferentes partes de forma única.  

**¿Qué elementos pueden personalizarse en un Patrón de diapositivas?**

Un Patrón de diapositivas comprende varias propiedades principales que pueden personalizarse:

- **Background**: establecer el fondo de la diapositiva.  
- **BodyStyle**: definir los estilos de texto del cuerpo de la diapositiva.  
- **Shapes**: gestionar todas las formas del Patrón de diapositivas, incluidos marcadores de posición y marcos de imagen.  
- **Controls**: manejar controles ActiveX.  
- **ThemeManager**: acceder al gestor de temas.  
- **HeaderFooterManager**: gestionar encabezados y pies de página.  

**¿Cómo puedo añadir una imagen a un Patrón de diapositivas?**

Añadir una imagen a un Patrón de diapositivas asegura que aparezca en todas las diapositivas que dependen de ese patrón. Por ejemplo, colocar el logotipo de la empresa en el Patrón de diapositivas hará que se muestre en cada diapositiva de la presentación.  

**¿Cómo se relacionan los Patrones de diapositivas con los Diseños de diapositiva?**

Los Diseños de diapositiva trabajan junto con los Patrones de diapositivas para ofrecer flexibilidad en el diseño. Mientras que un Patrón de diapositivas define estilos y temas globales, los Diseños de diapositiva permiten variaciones en la disposición del contenido. La jerarquía es la siguiente:

- **Patrón de diapositivas** → Define estilos globales.  
- **Diseño de diapositiva** → Proporciona diferentes disposiciones de contenido.  
- **Diapositiva** → Hereda el diseño de su Diseño de diapositiva.  

**¿Puedo tener varios Patrones de diapositivas en una sola presentación?**

Sí, una presentación puede contener varios Patrones de diapositivas. Esto permite dar estilo a diferentes secciones de una presentación de diversas maneras, proporcionando flexibilidad en el diseño.  

**¿Cómo accedo y modifico un Patrón de diapositivas usando Aspose.Slides?**

En Aspose.Slides, un Patrón de diapositivas está representado por la interfaz [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/). Puedes acceder a un Patrón de diapositivas mediante el método [getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) del objeto [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).