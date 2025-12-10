---
title: Gestionar maestros de diapositivas de presentación en Java
linktitle: Maestro de diapositiva
type: docs
weight: 70
url: /es/java/slide-master/
keywords:
- maestro de diapositivas
- diapositiva maestra
- diapositiva maestra PPT
- diapositivas maestras múltiples
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
description: "Gestionar maestros de diapositivas en Aspose.Slides para Java: crear, editar y aplicar diseños, temas y marcadores de posición a PPT, PPTX y ODP con ejemplos concisos en Java."
---

## **Qué es un Slide Master en PowerPoint**

Un **Slide Master** es una plantilla de diapositiva que define el diseño, los estilos, el tema, las fuentes, el fondo y otras propiedades de las diapositivas en una presentación. Si deseas crear una presentación (o una serie de presentaciones) con el mismo estilo y plantilla para tu empresa, puedes usar un slide master.

Un Slide Master es útil porque permite establecer y cambiar el aspecto de todas las diapositivas de la presentación de una sola vez. Aspose.Slides admite el mecanismo de Slide Master de PowerPoint.

VBA también permite manipular un Slide Master y ejecutar las mismas operaciones que PowerPoint admite: cambiar fondos, agregar formas, personalizar el diseño, etc. Aspose.Slides ofrece mecanismos flexibles para que uses Slide Masters y realices tareas básicas con ellos.

Estas son operaciones básicas con Slide Master:

- Crear o Slide Master.
- Aplicar Slides Master a las diapositivas de la presentación.
- Cambiar el fondo del Slide Master. 
- Agregar una imagen, marcador de posición, Smart Art, etc. al Slide Master.

Estas son operaciones más avanzadas que involucran Slide Master:

- Comparar Slide Masters.
- Fusionar Slide Masters.
- Aplicar varios Slide Masters.
- Copiar una diapositiva con Slide Master a otra presentación.
- Encontrar Slide Masters duplicados en presentaciones.
- Establecer el Slide Master como la vista predeterminada de la presentación.

{{% alert color="primary" %}} 
Es posible que desees consultar el **Visor de PowerPoint en línea de Aspose**[**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) porque es una implementación en vivo de algunos de los procesos básicos descritos aquí.
{{% /alert %}} 

## **Cómo se aplica un Slide Master**

Antes de trabajar con un slide master, puede que quieras entender cómo se usan en las presentaciones y se aplican a las diapositivas.

* Cada presentación tiene al menos un Slide Master por defecto. 
* Una presentación puede contener varios Slide Masters. Puedes agregar varios Slide Masters y usarlos para dar estilo a diferentes partes de la presentación de distintas maneras. 

En **Aspose.Slides**, un Slide Master está representado por el tipo [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/).

El objeto [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) de Aspose.Slides contiene la lista [**getMasters**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) de tipo [**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), que contiene una lista de todos los masters definidos en una presentación.

Además de las operaciones CRUD, la interfaz [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) incluye los métodos útiles: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) y [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). Esos métodos se heredan de la función básica de clonación de diapositivas. Pero al trabajar con Slide Masters, permiten implementar configuraciones complicadas. 

Cuando se agrega una nueva diapositiva a una presentación, se le aplica automáticamente un Slide Master. Por defecto, se selecciona el Slide Master de la diapositiva anterior.

**Nota**: Las diapositivas de la presentación se almacenan en la lista [getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) y cada nueva diapositiva se agrega al final de la colección por defecto. Si una presentación contiene un solo Slide Master, ese master se selecciona para todas las nuevas diapositivas. Esta es la razón por la que no tienes que definir el Slide Master para cada diapositiva nueva que crees.

El principio es el mismo para PowerPoint y Aspose.Slides. Por ejemplo, en PowerPoint, cuando añades una nueva diapositiva, puedes simplemente hacer clic en la línea inferior bajo la última diapositiva y se creará una nueva diapositiva (con el Slide Master de la última presentación):

![todo:image_alt_text](slide-master_1.jpg)

En Aspose.Slides, puedes realizar la tarea equivalente con el método [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) bajo la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).

## **Slide Master en la jerarquía de Slides**

Usar Slide Layouts con Slide Master permite la máxima flexibilidad. Un Slide Layout permite establecer los mismos estilos que Slide Master (fondo, fuentes, formas, etc.). Sin embargo, cuando varios Slide Layouts se combinan en un Slide Master, se crea un nuevo estilo. Cuando aplicas un Slide Layout a una sola diapositiva, puedes cambiar su estilo respecto al aplicado por el Slide Master.

Slide Master supera a todos los items de configuración: Slide Master → Slide Layout → Slide:

![todo:image_alt_text](slide-master_2)

Cada objeto [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) tiene una propiedad [**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) con una lista de Slide Layouts. Un tipo [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) tiene una propiedad [**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--) que enlaza al Slide Layout aplicado a la diapositiva. La interacción entre una diapositiva y el Slide Master ocurre a través de un Slide Layout.

{{% alert color="info" title="Nota" %}}
* En Aspose.Slides, todas las configuraciones de diapositiva (Slide Master, Slide Layout y la propia diapositiva) son en realidad objetos de diapositiva que implementan la interfaz [**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide).
* Por lo tanto, Slide Master y Slide Layout pueden implementar las mismas propiedades y debes saber cómo se aplicarán sus valores a un objeto [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide). El Slide Master se aplica primero a una diapositiva y luego se aplica el Slide Layout. Por ejemplo, si el Slide Master y el Slide Layout tienen ambos un valor de fondo, la diapositiva terminará con el fondo del Slide Layout.
{{% /alert %}}

## **Qué contiene un Slide Master**

Para entender cómo se puede modificar un Slide Master, necesitas conocer sus componentes. Estos son los atributos centrales de [MasterSlide](https://reference.aspose.com/slides/java/aspose.slides/masterslide/):

- [getBackground](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) obtener/establecer el fondo de la diapositiva.
- [getBodyStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) obtener/establecer los estilos de texto del cuerpo de la diapositiva.
- [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) obtener/establecer todas las formas del Slide Master (marcadores de posición, marcos de imagen, etc.).
- [getControls](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) obtener/establecer los controles ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) obtener el gestor de temas.
- [getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) obtener el gestor de encabezados y pies de página.

Métodos del Slide Master:

- [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) obtener todas las diapositivas que dependen del Slide Master.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) permite crear un nuevo Slide Master basado en el actual y un tema nuevo. El nuevo Slide Master se aplicará luego a todas las diapositivas dependientes.

## **Obtener un Slide Master**

En PowerPoint, el Slide Master se puede acceder desde el menú Vista → Slide Master:

![todo:image_alt_text](slide-master_3.jpg)

Con Aspose.Slides, puedes acceder a un Slide Master de esta manera:
```java
Presentation pres = new Presentation();
try {
    // Da acceso a la diapositiva maestra de la presentación
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


La interfaz [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) representa un Slide Master. La propiedad [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) (relacionada con el tipo [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection)) contiene una lista de todos los Slide Masters definidos en la presentación.

## **Agregar una imagen a un Slide Master**

Cuando agregas una imagen a un Slide Master, esa imagen aparecerá en todas las diapositivas que dependan de ese master.

Por ejemplo, puedes colocar el logotipo de tu empresa y algunas imágenes en el Slide Master y luego volver al modo de edición de diapositivas. Deberías ver la imagen en cada diapositiva.

![todo:image_alt_text](slide-master_4.png)

Puedes agregar imágenes a un slide master con Aspose.Slides:
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
Para más información sobre cómo agregar imágenes a una diapositiva, consulta el artículo [Picture Frame](/slides/es/java/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Agregar un marcador de posición a un Slide Master**

Estos campos de texto son marcadores de posición estándar en un Slide Master:

* Hacer clic para editar el estilo del título del Master
* Editar estilos de texto del Master
* Segundo nivel
* Tercer nivel

También aparecen en las diapositivas basadas en el Slide Master. Puedes editar esos marcadores de posición en el Slide Master y los cambios se aplicarán automáticamente a las diapositivas.

En PowerPoint, puedes agregar un marcador de posición a través de la ruta Slide Master → Insertar marcador de posición:

![todo:image_alt_text](slide-master_5.png)

Examinemos un ejemplo más complejo de marcadores de posición con Aspose.Slides. Considera una diapositiva con marcadores de posición creados a partir del Slide Master:

![todo:image_alt_text](slide-master_6.png)

Queremos cambiar el formato del Título y del Subtítulo en el Slide Master de esta forma:

![todo:image_alt_text](slide-master_7.png)

Primero, obtenemos el contenido del marcador de posición del título del objeto Slide Master y luego usamos el campo `PlaceHolder.FillFormat`:
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


El estilo y formato del título cambiará en todas las diapositivas basadas en el slide master:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Ver también" %}} 
* [Establecer texto de sugerencia en Placeholder](https://docs.aspose.com/slides/java/manage-placeholder/)
* [Formato de texto](https://docs.aspose.com/slides/java/text-formatting/)
{{% /alert %}}

## **Cambiar el fondo en un Slide Master**

Cuando cambias el color de fondo de una diapositiva maestra, todas las diapositivas normales de la presentación obtendrán el nuevo color. Este código Java muestra la operación:
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
- [Fondo de la presentación](https://docs.aspose.com/slides/java/presentation-background/)
- [Tema de la presentación](https://docs.aspose.com/slides/java/presentation-theme/)
{{% /alert %}}

## **Clonar un Slide Master a otra presentación**

Para clonar un Slide Master a otra presentación, llama al método [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) de la presentación de destino pasando el Slide Master que deseas clonar. Este código Java muestra cómo clonar un Slide Master a otra presentación:
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

Aspose.Slides permite agregar varios Slide Masters y Slide Layouts a cualquier presentación. Esto permite configurar estilos, diseños y opciones de formato de muchas maneras distintas.

En PowerPoint, puedes agregar nuevos Slide Masters y Layouts (desde el menú “Slide Master”) de esta forma:

![todo:image_alt_text](slide-master_9.jpg)

Con Aspose.Slides, puedes agregar un nuevo Slide Master llamando al método [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-):
```java
// Agrega una nueva diapositiva maestra
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **Comparar Slide Masters**

Un Master Slide implementa la interfaz [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) que contiene el método [**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-), que puede usarse para comparar diapositivas. Devuelve `true` para Master Slides idénticos en estructura y contenido estático.

Dos Master Slides son iguales si sus formas, estilos, textos, animaciones y otras configuraciones son iguales. La comparación no tiene en cuenta los valores de identificadores únicos (p. ej., SlideId) ni el contenido dinámico (p. ej., fecha actual en un marcador de posición de fecha).

## **Establecer un Slide Master como vista predeterminada de la presentación**

Aspose.Slides permite establecer un Slide Master como la vista predeterminada de una presentación. La vista predeterminada es lo que ves primero al abrir una presentación.

Este código muestra cómo establecer un Slide Master como vista predeterminada de la presentación en Java:
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


## **Eliminar Master Slides no utilizados**

Aspose.Slides proporciona el método [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (de la clase [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)) para eliminar master slides no deseados y sin uso. Este código Java muestra cómo eliminar un master slide de una presentación PowerPoint:
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

**¿Qué es un Slide Master en PowerPoint?**

Un Slide Master es una plantilla de diapositiva que define el diseño, los estilos, los temas, las fuentes, el fondo y otras propiedades de las diapositivas en una presentación. Permite establecer y cambiar el aspecto de todas las diapositivas de la presentación a la vez.

**¿Cómo se aplica un Slide Master en una presentación?**

Cada presentación tiene al menos un Slide Master por defecto. Cuando se agrega una nueva diapositiva, se le aplica automáticamente un Slide Master, generalmente heredando el master de la diapositiva anterior. Una presentación puede contener varios Slide Masters para dar estilo a diferentes partes de forma única.

**¿Qué elementos se pueden personalizar en un Slide Master?**

Un Slide Master comprende varios atributos centrales que pueden personalizarse:

- **Background**: establecer el fondo de la diapositiva.
- **BodyStyle**: definir los estilos de texto del cuerpo de la diapositiva.
- **Shapes**: gestionar todas las formas del Slide Master, incluidos marcadores de posición y marcos de imagen.
- **Controls**: manejar los controles ActiveX.
- **ThemeManager**: acceder al gestor de temas.
- **HeaderFooterManager**: gestionar encabezados y pies de página.

**¿Cómo puedo agregar una imagen a un Slide Master?**

Agregar una imagen a un Slide Master garantiza que aparezca en todas las diapositivas que dependan de ese master. Por ejemplo, colocar el logotipo de la empresa en el Slide Master lo mostrará en cada diapositiva de la presentación.

**¿Cómo se relacionan los Slide Masters con los Slide Layouts?**

Los Slide Layouts funcionan junto con los Slide Masters para proporcionar flexibilidad en el diseño de diapositivas. Mientras que un Slide Master define estilos y temas globales, los Slide Layouts permiten variaciones en la disposición del contenido. La jerarquía es la siguiente:

- **Slide Master** → Define estilos globales.
- **Slide Layout** → Ofrece diferentes disposiciones de contenido.
- **Slide** → Hereda el diseño de su Slide Layout.

**¿Puedo tener varios Slide Masters en una sola presentación?**

Sí, una presentación puede contener varios Slide Masters. Esto permite dar estilo a diferentes secciones de la presentación de diversas maneras, ofreciendo flexibilidad en el diseño.

**¿Cómo accedo y modifico un Slide Master usando Aspose.Slides?**

En Aspose.Slides, un Slide Master está representado por la interfaz [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/). Puedes acceder a un Slide Master mediante el método [getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) del objeto [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).