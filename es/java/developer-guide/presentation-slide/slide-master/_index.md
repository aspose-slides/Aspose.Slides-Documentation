---
title: Patrón de Diapositiva
type: docs
weight: 70
url: /es/java/slide-master/
keywords: "Agregar Patrón de Diapositiva, diapositiva maestra PPT, patrón de diapositiva PowerPoint, imagen a Patrón de Diapositiva, marcador de posición, múltiples Patrones de Diapositiva, comparar Patrones de Diapositiva, Java, Aspose.Slides para Java"
description: "Agregar o editar patrón de diapositiva en presentación de PowerPoint en Java"
---

## **Qué es un Patrón de Diapositiva en PowerPoint**

Un **Patrón de Diapositiva** es una plantilla de diapositiva que define el diseño, estilos, tema, fuentes, fondo y otras propiedades para las diapositivas en una presentación. Si deseas crear una presentación (o una serie de presentaciones) con el mismo estilo y plantilla para tu empresa, puedes utilizar un patrón de diapositiva.

Un Patrón de Diapositiva es útil porque te permite establecer y cambiar la apariencia de todas las diapositivas de la presentación a la vez. Aspose.Slides admite el mecanismo de Patrón de Diapositiva de PowerPoint.

VBA también te permite manipular un Patrón de Diapositiva y ejecutar las mismas operaciones admitidas en PowerPoint: cambiar fondos, agregar formas, personalizar el diseño, etc. Aspose.Slides proporciona mecanismos flexibles que te permiten utilizar Patrones de Diapositiva y realizar tareas básicas con ellos.

Estas son las operaciones básicas de Patrón de Diapositiva:

- Crear o modificar Patrón de Diapositiva.
- Aplicar Patrones de Diapositiva a las diapositivas de la presentación.
- Cambiar el fondo del Patrón de Diapositiva.
- Agregar una imagen, marcador de posición, Smart Art, etc. al Patrón de Diapositiva.

Estas son operaciones más avanzadas que involucran el Patrón de Diapositiva:

- Comparar Patrones de Diapositiva.
- Combinar Patrones de Diapositiva.
- Aplicar varios Patrones de Diapositiva.
- Copiar una diapositiva con el Patrón de Diapositiva a otra presentación.
- Encontrar Patrones de Diapositiva duplicados en las presentaciones.
- Establecer el Patrón de Diapositiva como la vista predeterminada de la presentación.

{{% alert color="primary" %}} 

Es posible que desees consultar el [**Visor de PowerPoint en Línea**](https://products.aspose.app/slides/viewer) de Aspose porque es una implementación en vivo de algunos de los procesos fundamentales descritos aquí.

{{% /alert %}} 

## **Cómo se aplica el Patrón de Diapositiva**

Antes de trabajar con un patrón de diapositiva, es posible que desees entender cómo se utilizan en las presentaciones y se aplican a las diapositivas.

* Cada presentación tiene al menos un Patrón de Diapositiva por defecto.
* Una presentación puede contener varios Patrones de Diapositiva. Puedes agregar varios Patrones de Diapositiva y utilizarlos para dar estilo a diferentes partes de una presentación de diferentes maneras.

En **Aspose.Slides**, un Patrón de Diapositiva está representado por el tipo [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/).

El objeto [Presentación](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) de Aspose.Slides contiene la lista [**getMasters**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) del tipo [**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), que contiene una lista de todas las diapositivas maestras definidas en una presentación.

Además de las operaciones CRUD, la interfaz [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) contiene estos métodos útiles: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) y [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). Estos métodos se heredan de la función de clonación básica de diapositivas. Sin embargo, al tratar con Patrones de Diapositiva, estos métodos te permiten implementar configuraciones complicadas.

Cuando se agrega una nueva diapositiva a una presentación, se aplica automáticamente un Patrón de Diapositiva a ella. Por defecto, se selecciona el Patrón de Diapositiva de la diapositiva anterior.

**Nota**: Las diapositivas de la presentación se almacenan en la lista [getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) y cada nueva diapositiva se agrega al final de la colección por defecto. Si una presentación contiene un solo Patrón de Diapositiva, ese patrón se selecciona para todas las nuevas diapositivas. Esta es la razón por la que no tienes que definir el Patrón de Diapositiva para cada nueva diapositiva que creas.

El principio es el mismo para PowerPoint y Aspose.Slides. Por ejemplo, en PowerPoint, cuando agregas una nueva presentación, solo tienes que presionar la línea inferior debajo de la última diapositiva y luego se creará una nueva diapositiva (con el Patrón de Diapositiva de la última presentación):

![todo:image_alt_text](slide-master_1.jpg)

En Aspose.Slides, puedes realizar la tarea equivalente con el método [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) de la clase [Presentación](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).

## **Patrón de Diapositiva en la jerarquía de diapositivas**

El uso de Diseños de Diapositivas con Patrón de Diapositiva permite una máxima flexibilidad. Un Diseño de Diapositiva te permite establecer todos los mismos estilos que el Patrón de Diapositiva (fondo, fuentes, formas, etc.). Sin embargo, cuando varios Diseños de Diapositivas se combinan en un Patrón de Diapositiva, se crea un nuevo estilo. Cuando aplicas un Diseño de Diapositiva a una diapositiva única, puedes cambiar su estilo respecto al que es aplicado por el Patrón de Diapositiva.

El Patrón de Diapositiva tiene prioridad sobre todos los elementos de configuración: Patrón de Diapositiva -> Diseño de Diapositiva -> Diapositiva:

![todo:image_alt_text](slide-master_2)

Cada objeto [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) tiene una propiedad [**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) con una lista de Diseños de Diapositivas. Un tipo de [Diapositiva](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) tiene una propiedad [**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--) que proporciona un enlace a un Diseño de Diapositiva aplicado a la diapositiva. La interacción entre una diapositiva y el Patrón de Diapositiva ocurre a través de un Diseño de Diapositiva.

{{% alert color="info" title="Nota" %}}

* En Aspose.Slides, todas las configuraciones de las diapositivas (Patrón de Diapositiva, Diseño de Diapositiva y la propia diapositiva) son en realidad objetos de diapositiva que implementan la interfaz [**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide).
* Por lo tanto, el Patrón de Diapositiva y el Diseño de Diapositiva pueden implementar las mismas propiedades y necesitas saber cómo se aplicarán sus valores a un objeto [Diapositiva](https://reference.aspose.com/slides/java/com.aspose.slides/Slide). El Patrón de Diapositiva se aplica primero a una diapositiva y luego se aplica el Diseño de Diapositiva. Por ejemplo, si el Patrón de Diapositiva y el Diseño de Diapositiva tienen ambos un valor de fondo, la diapositiva se mostrará con el fondo del Diseño de Diapositiva.

{{% /alert %}}

## **Qué comprende un Patrón de Diapositiva**

Para entender cómo se puede cambiar un Patrón de Diapositiva, necesitas conocer sus componentes. Estas son las propiedades fundamentales de [MasterSlide](https://reference.aspose.com/slides/java/aspose.slides/masterslide/). 

- [getBackground](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) obtener/establecer el fondo de la diapositiva.
- [getBodyStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) - obtener/establecer los estilos de texto del cuerpo de la diapositiva.
- [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) obtener/establecer todas las formas del Patrón de Diapositiva (marcadores de posición, marcos de imagen, etc).
- [getControls](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) obtener/establecer controles ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) - obtener el gestor de temas.
- [getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) - obtener el gestor de encabezados y pies de página.

Métodos de Patrón de Diapositiva:

- [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) - obtener todas las diapositivas que dependen del Patrón de Diapositiva.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - te permite crear un nuevo Patrón de Diapositiva basado en el Patrón de Diapositiva actual y un nuevo tema. El nuevo Patrón de Diapositiva se aplicará luego a todas las diapositivas dependientes.

## **Obtener Patrón de Diapositiva**

En PowerPoint, el Patrón de Diapositiva se puede acceder desde el menú Ver -> Patrón de Diapositiva:

![todo:image_alt_text](slide-master_3.jpg)

Usando Aspose.Slides, puedes acceder a un Patrón de Diapositiva de esta manera:

```java
Presentation pres = new Presentation();
try {
    // Proporciona acceso a la diapositiva maestra de la Presentación
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```

La interfaz [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) representa un Patrón de Diapositiva. La propiedad [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) (relacionada con el tipo [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection)) contiene una lista de todos los Patrones de Diapositiva definidos en la presentación.

## **Agregar Imagen al Patrón de Diapositiva**

Cuando agregas una imagen a un Patrón de Diapositiva, esa imagen aparecerá en todas las diapositivas dependientes de ese patrón de diapositiva.

Por ejemplo, puedes colocar el logo de tu empresa y algunas imágenes en el Patrón de Diapositiva y luego volver al modo de edición de diapositivas. Deberías ver la imagen en cada diapositiva.

![todo:image_alt_text](slide-master_4.png)

Puedes agregar imágenes a un Patrón de Diapositiva con Aspose.Slides:

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

Para más información sobre cómo agregar imágenes a una diapositiva, consulta el artículo [Marco de Imagen](/slides/es/java/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Agregar Marcador de Posición al Patrón de Diapositiva**

Estos campos de texto son marcadores de posición estándar en un Patrón de Diapositiva:

* Haga clic para editar el estilo de título del Patrón
* Editar estilos de texto del Patrón
* Segundo nivel
* Tercer nivel

También aparecen en las diapositivas basadas en el Patrón de Diapositiva. Puedes editar esos marcadores de posición en un Patrón de Diapositiva y los cambios se aplicarán automáticamente a las diapositivas.

En PowerPoint, puedes agregar un marcador de posición a través de la ruta Patrón de Diapositiva -> Insertar Marcador de Posición:

![todo:image_alt_text](slide-master_5.png)

Examinemos un ejemplo más complicado de marcadores de posición con Aspose.Slides. Considera una diapositiva con marcadores de posición plantados del Patrón de Diapositiva:

![todo:image_alt_text](slide-master_6.png)

Queremos cambiar el formato del Título y Subtítulo en el Patrón de Diapositiva de esta manera:

![todo:image_alt_text](slide-master_7.png)

Primero, recuperamos el contenido del marcador de posición del título del objeto Patrón de Diapositiva y luego utilizamos el campo `PlaceHolder.FillFormat`:

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

El estilo y formato del título cambiarán para todas las diapositivas basadas en el patrón de diapositiva:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Ver también" %}} 

* [Establecer texto de aviso en Marcador de Posición](https://docs.aspose.com/slides/java/manage-placeholder/)
* [Formateo de Texto](https://docs.aspose.com/slides/java/text-formatting/)

{{% /alert %}}

## **Cambiar Fondo en el Patrón de Diapositiva**

Cuando cambias el color de fondo de un patrón de diapositiva, todas las diapositivas normales en la presentación tendrán el nuevo color. Este código Java demuestra la operación:

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

- [Fondo de Presentación](https://docs.aspose.com/slides/java/presentation-background/)

- [Tema de Presentación](https://docs.aspose.com/slides/java/presentation-theme/)

  {{% /alert %}}

## **Clonar Patrón de Diapositiva a Otra Presentación**

Para clonar un Patrón de Diapositiva a otra presentación, llama al método [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) desde la presentación de destino junto con un Patrón de Diapositiva pasado a ella. Este código Java muestra cómo clonar un Patrón de Diapositiva a otra presentación:

```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```

## **Agregar Múltiples Patrones de Diapositiva a la Presentación**

Aspose.Slides te permite agregar varios Patrones de Diapositiva y Diseños de Diapositiva a cualquier presentación dada. Esto te permite configurar estilos, diseños y opciones de formato para las diapositivas de la presentación de muchas maneras.

En PowerPoint, puedes agregar nuevos Patrones de Diapositiva y Diseños (desde el menú "Patrón de Diapositiva) de esta manera:

![todo:image_alt_text](slide-master_9.jpg)

Usando Aspose.Slides, puedes agregar un nuevo Patrón de Diapositiva llamando al método [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-):

```java
// Agrega una nueva diapositiva maestra
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```

## **Comparar Patrones de Diapositiva**

Un Patrón de Diapositiva implementa la interfaz [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) que contiene el método [**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-), el cual se puede usar para comparar diapositivas. Devuelve `true` para Patrones de Diapositiva idénticos en estructura y contenido estático.

Dos Patrones de Diapositiva son iguales si sus formas, estilos, textos, animación y otras configuraciones, etc., son iguales. La comparación no tiene en cuenta los valores de identificadores únicos (por ejemplo, SlideId) y contenido dinámico (por ejemplo, valor de fecha actual en el Marcador de Posición de Fecha).

## **Establecer Patrón de Diapositiva como Vista Predeterminada de Presentación**

Aspose.Slides te permite establecer un Patrón de Diapositiva como la vista predeterminada para una presentación. La vista predeterminada es lo primero que ves al abrir una presentación.

Este código te muestra cómo establecer un Patrón de Diapositiva como vista predeterminada de una presentación en Java:

```java
// Instancia una clase Presentación que representa el archivo de presentación
Presentation presentation = new Presentation();
try {
    // Establece la Vista Predeterminada como SlideMasterView
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // Guarda la presentación
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eliminar Patrón de Diapositiva Sin Usar**

Aspose.Slides proporciona el método [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (de la clase [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)) para permitirte eliminar patrones de diapositiva no deseados y no utilizados. Este código Java te muestra cómo eliminar un Patrón de Diapositiva de una presentación de PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```