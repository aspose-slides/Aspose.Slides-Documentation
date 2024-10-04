---
title: Maestro de Diapositivas
type: docs
weight: 70
url: /androidjava/slide-master/
keywords: "Agregar Maestro de Diapositivas, diapositiva maestra de PPT, maestro de diapositivas de PowerPoint, imagen al Maestro de Diapositivas, marcador de posición, múltiples Maestros de Diapositivas, comparar Maestros de Diapositivas, Java, Aspose.Slides para Android a través de Java"
description: "Agregar o editar maestro de diapositivas en presentación de PowerPoint en Java"
---

## **¿Qué es un Maestro de Diapositivas en PowerPoint?**

Un **Maestro de Diapositivas** es una plantilla de diapositiva que define el diseño, estilos, tema, fuentes, fondo y otras propiedades para las diapositivas en una presentación. Si deseas crear una presentación (o serie de presentaciones) con el mismo estilo y plantilla para tu empresa, puedes utilizar un maestro de diapositivas.

Un Maestro de Diapositivas es útil porque te permite establecer y cambiar el aspecto de todas las diapositivas de la presentación a la vez. Aspose.Slides admite el mecanismo del Maestro de Diapositivas de PowerPoint.

VBA también te permite manipular un Maestro de Diapositivas y ejecutar las mismas operaciones que se admiten en PowerPoint: cambiar fondos, agregar formas, personalizar el diseño, etc. Aspose.Slides proporciona mecanismos flexibles para permitirte usar Maestros de Diapositivas y realizar tareas básicas con ellos.

Estas son las operaciones básicas del Maestro de Diapositivas:

- Crear o Editar Maestro de Diapositivas.
- Aplicar Maestros de Diapositivas a diapositivas de presentación.
- Cambiar el fondo del Maestro de Diapositivas.
- Agregar una imagen, marcador de posición, Smart Art, etc. al Maestro de Diapositivas.

Estas son operaciones más avanzadas que involucran el Maestro de Diapositivas:

- Comparar Maestros de Diapositivas.
- Fusionar Maestros de Diapositivas.
- Aplicar varios Maestros de Diapositivas.
- Copiar una diapositiva con su Maestro de Diapositivas a otra presentación.
- Identificar Maestros de Diapositivas duplicados en las presentaciones.
- Configurar el Maestro de Diapositivas como la vista predeterminada de la presentación.

{{% alert color="primary" %}} 

Puede que desees consultar el [**Visor de PowerPoint en Línea**](https://products.aspose.app/slides/viewer) de Aspose porque es una implementación en vivo de algunos de los procesos fundamentales descritos aquí.

{{% /alert %}} 

## **¿Cómo se aplica el Maestro de Diapositivas?**

Antes de trabajar con un maestro de diapositivas, puede que quieras entender cómo se utilizan en las presentaciones y se aplican a las diapositivas.

* Cada presentación tiene al menos un Maestro de Diapositivas por defecto.
* Una presentación puede contener varios Maestros de Diapositivas. Puedes agregar varios Maestros de Diapositivas y utilizarlos para estilizar diferentes partes de una presentación de diferentes maneras.

En **Aspose.Slides**, un Maestro de Diapositivas está representado por el tipo [**IMasterSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/).

El objeto [Presentación](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) de Aspose.Slides contiene la lista [**getMasters**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) del tipo [**IMasterSlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), que contiene una lista de todas las diapositivas maestras que están definidas en una presentación.

Además de las operaciones CRUD, la interfaz [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) contiene estos métodos útiles: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) y [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) métodos. Estos métodos se heredan de la función básica de clonación de diapositivas. Pero al tratar con Maestros de Diapositivas, esos métodos te permiten implementar configuraciones complicadas.

Cuando se agrega una nueva diapositiva a una presentación, un Maestro de Diapositivas se aplica automáticamente a ella. El Maestro de Diapositivas de la diapositiva anterior se selecciona por defecto.

**Nota**: Las diapositivas de la presentación se almacenan en la lista [getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) y cada nueva diapositiva se agrega al final de la colección por defecto. Si una presentación contiene un solo Maestro de Diapositivas, ese maestro se selecciona para todas las nuevas diapositivas. Esta es la razón por la cual no es necesario definir el Maestro de Diapositivas para cada nueva diapositiva que creas.

El principio es el mismo para PowerPoint y Aspose.Slides. Por ejemplo, en PowerPoint, cuando agregas una nueva presentación, puedes presionar en la línea inferior debajo de la última diapositiva y luego se creará una nueva diapositiva (con el Maestro de Diapositivas de la última presentación):

![todo:image_alt_text](slide-master_1.jpg)

En Aspose.Slides, puedes realizar la tarea equivalente con el método [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) bajo la clase [Presentación](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).

## **Maestro de Diapositivas en la jerarquía de Diapositivas**

Utilizar Diseños de Diapositivas con el Maestro de Diapositivas permite la máxima flexibilidad. Un Diseño de Diapositiva te permite establecer todos los mismos estilos que el Maestro de Diapositivas (fondo, fuentes, formas, etc.). Sin embargo, cuando varios Diseños de Diapositivas se combinan en un Maestro de Diapositivas, se crea un nuevo estilo. Cuando aplicas un Diseño de Diapositiva a una sola diapositiva, puedes cambiar su estilo a partir del que aplica el Maestro de Diapositivas.

El Maestro de Diapositivas supera todos los elementos de configuración: Maestro de Diapositivas -> Diseño de Diapositiva -> Diapositiva:

![todo:image_alt_text](slide-master_2)

Cada [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) objeto tiene una propiedad [**getLayoutSlides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getLayoutSlides--) con una lista de Diseños de Diapositivas. Un tipo [Diapositiva](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide) tiene una propiedad [**getLayoutSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getLayoutSlide--) con un enlace a un Diseño de Diapositiva aplicado a la diapositiva. La interacción entre una diapositiva y el Maestro de Diapositivas ocurre a través de un Diseño de Diapositiva.

{{% alert color="info" title="Nota" %}}

* En Aspose.Slides, todas las configuraciones de diapositivas (Maestro de Diapositivas, Diseño de Diapositiva y la diapositiva misma) son en realidad objetos de diapositivas que implementan la interfaz [**IBaseSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide).
* Por lo tanto, el Maestro de Diapositivas y el Diseño de Diapositiva pueden implementar las mismas propiedades y necesitas saber cómo se aplicarán sus valores a un objeto [Diapositiva](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide). El Maestro de Diapositivas se aplica primero a una diapositiva y luego se aplica el Diseño de Diapositiva. Por ejemplo, si el Maestro de Diapositivas y el Diseño de Diapositiva ambos tienen un valor de fondo, la diapositiva terminará con el fondo del Diseño de Diapositiva.

{{% /alert %}}

## **¿Qué Comprende un Maestro de Diapositivas?**

Para entender cómo se puede cambiar un Maestro de Diapositivas, necesitas conocer sus componentes. Estas son las propiedades fundamentales de [MasterSlide](https://reference.aspose.com/slides/androidjava/aspose.slides/masterslide/).

- [getBackground](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getBackground--) obtener/establecer el fondo de la diapositiva.
- [getBodyStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getBodyStyle--) - obtener/establecer los estilos de texto del cuerpo de la diapositiva.
- [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getShapes--) obtener/establecer todas las formas del Maestro de Diapositivas (marcadores de posición, marcos de imagen, etc.).
- [getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getControls--) obtener/establecer controles ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterThemeable#getThemeManager--) - obtener el administrador de temas.
- [getHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) - obtener el administrador de encabezados y pies de página.

Métodos del Maestro de Diapositivas:

- [getDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getDependingSlides--) - obtener todas las Diapositivas que dependen del Maestro de Diapositivas.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - permite crear un nuevo Maestro de Diapositivas basado en el Maestro de Diapositivas actual y un nuevo tema. El nuevo Maestro de Diapositivas se aplicará a todas las diapositivas dependientes.

## **Obtener Maestro de Diapositivas**

En PowerPoint, el Maestro de Diapositivas se puede acceder desde el menú Ver -> Maestro de Diapositivas:

![todo:image_alt_text](slide-master_3.jpg)

Utilizando Aspose.Slides, puedes acceder a un Maestro de Diapositivas de esta manera:

```java
Presentation pres = new Presentation();
try {
    // Proporciona acceso a la diapositiva maestra de la Presentación
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```

La interfaz [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) representa un Maestro de Diapositivas. La propiedad [Masters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getMasters--) (relacionada con el tipo [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection)) contiene una lista de todos los Maestros de Diapositivas que están definidos en la presentación.

## **Agregar Imagen al Maestro de Diapositivas**

Cuando agregas una imagen a un Maestro de Diapositivas, esa imagen aparecerá en todas las diapositivas dependientes de ese maestro de diapositivas.

Por ejemplo, puedes colocar el logo de tu empresa y algunas imágenes en el Maestro de Diapositivas y luego volver al modo de edición de diapositivas. Deberías ver la imagen en cada diapositiva.

![todo:image_alt_text](slide-master_4.png)

Puedes agregar imágenes a un maestro de diapositivas con Aspose.Slides:

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

Para más información sobre cómo agregar imágenes a una diapositiva, consulta el artículo [Marco de Imagen](/slides/androidjava/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Agregar Marcador de Posición al Maestro de Diapositivas**

Estos campos de texto son marcadores de posición estándar en un Maestro de Diapositivas:

* Haga clic para editar el estilo del título del Maestro

* Editar estilos de texto del Maestro

* Segundo nivel

* Tercer nivel 

También aparecen en las diapositivas basadas en el Maestro de Diapositivas. Puedes editar esos marcadores de posición en un Maestro de Diapositivas y los cambios se aplican automáticamente a las diapositivas.

En PowerPoint, puedes agregar un marcador de posición a través de la ruta Maestro de Diapositivas -> Insertar Marcador de Posición:

![todo:image_alt_text](slide-master_5.png)

Examinemos un ejemplo más complicado para marcadores de posición con Aspose.Slides. Considera una diapositiva con marcadores de posición en plantilla del Maestro de Diapositivas:

![todo:image_alt_text](slide-master_6.png)

Queremos cambiar el formato del Título y el Subtítulo en el Maestro de Diapositivas de esta manera:

![todo:image_alt_text](slide-master_7.png)

Primero, recuperamos el contenido del marcador de título del objeto Maestro de Diapositivas y luego usamos el campo `PlaceHolder.FillFormat`:

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

El estilo y formato del título cambiarán para todas las diapositivas basadas en el maestro de diapositivas:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Ver también" %}} 

* [Establecer Texto de Sugerencia en Marcador de Posición](https://docs.aspose.com/slides/androidjava/manage-placeholder/)
* [Formato de Texto](https://docs.aspose.com/slides/androidjava/text-formatting/)

{{% /alert %}}

## **Cambiar el Fondo en el Maestro de Diapositivas**

Cuando cambias el color de fondo de un maestro de diapositivas, todas las diapositivas normales en la presentación obtendrán el nuevo color. Este código Java demuestra la operación:

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

- [Fondo de la Presentación](https://docs.aspose.com/slides/androidjava/presentation-background/)

- [Tema de la Presentación](https://docs.aspose.com/slides/androidjava/presentation-theme/)

{{% /alert %}}

## **Clonar Maestro de Diapositivas a Otra Presentación**

Para clonar un Maestro de Diapositivas a otra presentación, llama al método [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) desde la presentación de destino junto con un Maestro de Diapositivas pasado a él. Este código Java te muestra cómo clonar un Maestro de Diapositivas a otra presentación:

```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```

## **Agregar Múltiples Maestros de Diapositivas a la Presentación**

Aspose.Slides te permite agregar varios Maestros de Diapositivas y Diseños de Diapositivas a cualquier presentación dada. Esto te permite configurar estilos, diseños y opciones de formato para las diapositivas de la presentación de muchas maneras.

En PowerPoint, puedes agregar nuevos Maestros de Diapositivas y Diseños (desde el menú "Maestro de Diapositivas") de esta manera:

![todo:image_alt_text](slide-master_9.jpg)

Utilizando Aspose.Slides, puedes agregar un nuevo Maestro de Diapositivas llamando al método [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-):

```java
// Agrega un nuevo maestro de diapositivas
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```

## **Comparar Maestros de Diapositivas**

Un Maestro de Diapositivas implementa la interfaz [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) que contiene el método [**equals**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-) que se puede utilizar para comparar diapositivas. Devuelve `true` para Maestros de Diapositivas idénticos en estructura y contenido estático.

Dos Maestros de Diapositivas son iguales si sus formas, estilos, textos, animaciones y otras configuraciones, etc. son iguales. La comparación no toma en cuenta los valores de identificador único (por ejemplo, SlideId) y contenido dinámico (por ejemplo, valor actual de fecha en el Marcador de Posición de Fecha).

## **Establecer el Maestro de Diapositivas como Vista Predeterminada de la Presentación**

Aspose.Slides te permite establecer un Maestro de Diapositivas como la vista predeterminada para una presentación. La vista predeterminada es lo que ves primero al abrir una presentación.

Este código te muestra cómo establecer un Maestro de Diapositivas como vista predeterminada de una presentación en Java:

```java
// Instancia una clase Presentación que representa el archivo de presentación
Presentation presentation = new Presentation();
try {
    // Establece la Vista Predeterminada como Vista de Maestro de Diapositivas
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // Guarda la presentación
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eliminar Maestro de Diapositivas No Utilizado**

Aspose.Slides proporciona el método [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (de la clase [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)) para permitirte eliminar maestros de diapositivas no deseados y no utilizados. Este código Java te muestra cómo eliminar un maestro de diapositivas de una presentación de PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```