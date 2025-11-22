---
title: Patrón de diapositivas
type: docs
weight: 70
url: /es/nodejs-java/slide-master/
keywords: "Añadir Patrón de diapositivas, Diapositiva maestra PPT, Patrón de diapositivas PowerPoint, Imagen al Patrón de diapositivas, Marcador de posición, Múltiples Patrones de diapositivas, Comparar Patrones de diapositivas, Java, Aspose.Slides para Node.js mediante Java"
description: "Agregar o editar el patrón de diapositivas en una presentación de PowerPoint con JavaScript"
---

## **Qué es un Patrón de diapositivas en PowerPoint**

Un **Patrón de diapositivas** es una plantilla de diapositiva que define la distribución, estilos, tema, fuentes, fondo y otras propiedades de las diapositivas en una presentación. Si deseas crear una presentación (o una serie de presentaciones) con el mismo estilo y plantilla para tu empresa, puedes usar un patrón de diapositivas. 

Un Patrón de diapositivas es útil porque te permite establecer y cambiar la apariencia de todas las diapositivas de la presentación a la vez. Aspose.Slides soporta el mecanismo de Patrón de diapositivas de PowerPoint. 

VBA también permite manipular un Patrón de diapositivas y ejecutar las mismas operaciones que PowerPoint admite: cambiar fondos, añadir formas, personalizar la distribución, etc. Aspose.Slides proporciona mecanismos flexibles para que uses Patrones de diapositivas y realices tareas básicas con ellos. 

Estas son operaciones básicas con el Patrón de diapositivas:

- Crear o Patrón de diapositivas.
- Aplicar el Patrón de diapositivas a las diapositivas de la presentación.
- Cambiar el fondo del Patrón de diapositivas. 
- Añadir una imagen, marcador de posición, Smart Art, etc. al Patrón de diapositivas.

Estas son operaciones más avanzadas que implican el Patrón de diapositivas: 

- Comparar Patrones de diapositivas.
- Fusionar Patrones de diapositivas.
- Aplicar varios Patrones de diapositivas.
- Copiar una diapositiva con Patrón de diapositivas a otra presentación.
- Encontrar Patrones de diapositivas duplicados en presentaciones.
- Establecer el Patrón de diapositivas como la vista predeterminada de la presentación.

{{% alert color="primary" %}} 

Es posible que desees probar el [**Visor de PowerPoint en línea de Aspose**](https://products.aspose.app/slides/viewer) porque es una implementación en vivo de algunos de los procesos centrales descritos aquí.

{{% /alert %}} 


## **Cómo se aplica el Patrón de diapositivas**

Antes de trabajar con un patrón de diapositivas, quizás quieras entender cómo se usan en las presentaciones y cómo se aplican a las diapositivas. 

* Cada presentación tiene al menos un Patrón de diapositivas de manera predeterminada. 
* Una presentación puede contener varios Patrones de diapositivas. Puedes añadir varios Patrones de diapositivas y usarlos para estilizar diferentes partes de una presentación de distintas maneras. 

En **Aspose.Slides**, un Patrón de diapositivas está representado por el tipo [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/). 

El objeto [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) de Aspose.Slides contiene la lista de [**getMasters**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters--) de tipo [**MasterSlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), que contiene una lista de todos los patrones maestros definidos en una presentación. 

Además de las operaciones CRUD, la clase [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) incluye estos métodos útiles: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/#addClone-aspose.slides.ILayoutSlide-) y [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/#insertClone-int-aspose.slides.IMasterSlide-). Esos métodos se heredan de la función básica de clonación de diapositivas. Pero cuando se trata de Patrones de diapositivas, esos métodos te permiten implementar configuraciones complicadas. 

Cuando se añade una nueva diapositiva a una presentación, se le aplica un Patrón de diapositivas automáticamente. El Patrón de diapositivas de la diapositiva anterior se selecciona de forma predeterminada. 

**Nota**: Las diapositivas de la presentación se almacenan en la lista [getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides--) y cada nueva diapositiva se añade al final de la colección por defecto. Si una presentación contiene un solo Patrón de diapositivas, ese patrón se selecciona para todas las nuevas diapositivas. Esta es la razón por la que no tienes que definir el Patrón de diapositivas para cada nueva diapositiva que crees. 

El principio es el mismo para PowerPoint y Aspose.Slides. Por ejemplo, en PowerPoint, cuando añades una nueva diapositiva, solo tienes que pulsar en la línea inferior bajo la última diapositiva y entonces se creará una nueva diapositiva (con el Patrón de diapositivas de la última presentación):

![todo:image_alt_text](slide-master_1.jpg)

En Aspose.Slides, puedes realizar la tarea equivalente con el método [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) bajo la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). 


## **Patrón de diapositivas en la jerarquía de Slides**

Usar Distribuciones de diapositivas con el Patrón de diapositivas permite la máxima flexibilidad. Una Distribución de diapositiva te permite establecer los mismos estilos que el Patrón de diapositivas (fondo, fuentes, formas, etc.). Sin embargo, cuando se combinan varias Distribuciones de diapositivas en un Patrón de diapositivas, se crea un nuevo estilo. Cuando aplicas una Distribución de diapositiva a una sola diapositiva, puedes cambiar su estilo respecto al aplicado por el Patrón de diapositivas. 

El Patrón de diapositivas supera a todos los elementos de configuración: Patrón de diapositivas → Distribución de diapositiva → Diapositiva:

![todo:image_alt_text](slide-master_2)



Cada objeto [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) tiene una propiedad [**getLayoutSlides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getLayoutSlides--) con una lista de Distribuciones de diapositivas. Un tipo [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) tiene una propiedad [**getLayoutSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getLayoutSlide--) que enlaza a la Distribución de diapositiva aplicada a la diapositiva. La interacción entre una diapositiva y el Patrón de diapositivas ocurre a través de una Distribución de diapositiva. 

{{% alert color="info" title="Nota" %}}

* En Aspose.Slides, todas las configuraciones de diapositiva (Patrón de diapositivas, Distribución de diapositiva y la propia diapositiva) son en realidad objetos de diapositiva que implementan la clase [**BaseSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide). 
* Por lo tanto, el Patrón de diapositivas y la Distribución de diapositiva pueden implementar las mismas propiedades y debes saber cómo se aplicarán sus valores a un objeto [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide). El Patrón de diapositivas se aplica primero a una diapositiva y luego se aplica la Distribución de diapositiva. Por ejemplo, si el Patrón de diapositivas y la Distribución de diapositiva ambos tienen un valor de fondo, la diapositiva terminará con el fondo de la Distribución de diapositiva. 

{{% /alert %}}


## **De qué está compuesto un Patrón de diapositivas**

Para entender cómo se puede cambiar un Patrón de diapositivas, necesitas conocer sus componentes. Estos son los atributos principales de [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/). 

- [getBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getBackground--) obtener/establecer el fondo de la diapositiva. 
- [getBodyStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getBodyStyle--) obtener/establecer los estilos de texto del cuerpo de la diapositiva. 
- [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getShapes--) obtener/establecer todas las formas del Patrón de diapositivas (marcadores de posición, marcos de imagen, etc.). 
- [getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getControls--) obtener/establecer controles ActiveX. 
- [getThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterThemeable#getThemeManager--) obtener el gestor de temas. 
- [getHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getHeaderFooterManager--) obtener el gestor de encabezado y pie de página. 

Métodos del Patrón de diapositivas:

- [getDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getDependingSlides--) obtener todas las diapositivas que dependen del Patrón de diapositivas. 
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) permite crear un nuevo Patrón de diapositivas basado en el actual y un nuevo tema. El nuevo Patrón de diapositivas se aplicará entonces a todas las diapositivas dependientes. 


## **Obtener el Patrón de diapositivas**

En PowerPoint, el Patrón de diapositivas se puede acceder desde el menú Vista → Patrón de diapositivas:

![todo:image_alt_text](slide-master_3.jpg)



Usando Aspose.Slides, puedes acceder a un Patrón de diapositivas de esta manera: 
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Proporciona acceso a la diapositiva maestra de la presentación
    var masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


La clase [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) representa un Patrón de diapositivas. La propiedad [Masters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getMasters--) (relacionada con el tipo [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection)) contiene una lista de todos los Patrones de diapositivas definidos en la presentación. 


## **Añadir imagen al Patrón de diapositivas**

Cuando añades una imagen a un Patrón de diapositivas, esa imagen aparecerá en todas las diapositivas que dependan de ese patrón. 

Por ejemplo, puedes colocar el logotipo de tu empresa y algunas imágenes en el Patrón de diapositivas y luego volver al modo de edición de diapositivas. Deberías ver la imagen en cada diapositiva. 

![todo:image_alt_text](slide-master_4.png)

Puedes añadir imágenes a un Patrón de diapositivas con Aspose.Slides:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    pres.getMasters().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="Ver también" %}} 

Para obtener más información sobre cómo añadir imágenes a una diapositiva, consulta el artículo sobre [Marco de imagen](/slides/es/nodejs-java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Añadir marcador de posición al Patrón de diapositivas**

Estos campos de texto son marcadores de posición estándar en un Patrón de diapositivas: 

* Haga clic para editar el estilo del título del patrón
* Editar estilos de texto del patrón
* Segundo nivel
* Tercer nivel 

  También aparecen en las diapositivas basadas en el Patrón de diapositivas. Puedes editar esos marcadores de posición en el Patrón de diapositivas y los cambios se aplicarán automáticamente a las diapositivas. 

En PowerPoint, puedes añadir un marcador de posición mediante la ruta Patrón de diapositivas → Insertar marcador de posición:

![todo:image_alt_text](slide-master_5.png)

Examinemos un ejemplo más complicado de marcadores de posición con Aspose.Slides. Considera una diapositiva con marcadores de posición creados a partir del Patrón de diapositivas:

![todo:image_alt_text](slide-master_6.png)

Queremos cambiar el formato del Título y Subtítulo en el Patrón de diapositivas de esta manera:

![todo:image_alt_text](slide-master_7.png)

Primero, recuperamos el contenido del marcador de posición del título desde el objeto Patrón de diapositivas y luego usamos el campo `PlaceHolder.FillFormat`: 
```javascript
var pres = new aspose.slides.Presentation();
try {
    var master = pres.getMasters().get_Item(0);
    var placeHolder = findPlaceholder(master, aspose.slides.PlaceholderType.Title);
    placeHolder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    placeHolder.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    var awtColor = java.import('java.awt.Color');
    placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(0, java.newInstanceSync('java.awt.Color', 255, 0, 0));
    placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(255, java.newInstanceSync('java.awt.Color', 128, 0, 128));

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

function findPlaceholder(master, type)
{    
    for (var i = 0 ; i < master.getShapes().size(); i++)
    {
        var autoShape = master.getShapes().get_Item(i);
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


El estilo y formato del título cambiará en todas las diapositivas basadas en el patrón de diapositivas:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Ver también" %}} 

* [Establecer texto de sugerencia en el marcador de posición](https://docs.aspose.com/slides/nodejs-java/manage-placeholder/)
* [Formato de texto](https://docs.aspose.com/slides/nodejs-java/text-formatting/)

{{% /alert %}}


## **Cambiar el fondo en el Patrón de diapositivas**

Cuando cambias el color de fondo de una diapositiva maestra, todas las diapositivas normales de la presentación obtendrán el nuevo color. Este código JavaScript muestra la operación:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var master = pres.getMasters().get_Item(0);
    master.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    master.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    master.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="Ver también" %}} 

- [Fondo de la presentación](https://docs.aspose.com/slides/nodejs-java/presentation-background/)
- [Tema de la presentación](https://docs.aspose.com/slides/nodejs-java/presentation-theme/)

{{% /alert %}}

## **Clonar el Patrón de diapositivas a otra presentación**

Para clonar un Patrón de diapositivas a otra presentación, llama al método [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) de la presentación de destino pasando como argumento el Patrón de diapositivas. Este código JavaScript muestra cómo clonar un Patrón de diapositivas a otra presentación:
```javascript
var presSource = new aspose.slides.Presentation();
var presTarget = new aspose.slides.Presentation();
try {
    var master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) {
        presSource.dispose();
    }
}
```



## **Añadir varios Patrones de diapositivas a la presentación**

Aspose.Slides permite añadir varios Patrones de diapositivas y Distribuciones de diapositivas a cualquier presentación. Esto permite configurar estilos, distribuciones y opciones de formato para las diapositivas de la presentación de muchas maneras. 

En PowerPoint, puedes añadir nuevos Patrones de diapositivas y Distribuciones (desde el “menú Patrón de diapositivas”) de esta forma:

![todo:image_alt_text](slide-master_9.jpg)

Usando Aspose.Slides, puedes añadir un nuevo Patrón de diapositivas llamando al método [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-):
```javascript
// Añade una nueva diapositiva maestra
var secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **Comparar Patrones de diapositivas**

Un Maestro de diapositiva implementa la clase [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) que contiene el método [**equals**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#equals-aspose.slides.IBaseSlide-), que puede usarse para comparar diapositivas. Devuelve `true` para los Maestros de diapositiva idénticos en estructura y contenido estático. 

Dos Maestros de diapositiva son iguales si sus formas, estilos, textos, animaciones y otras configuraciones, etc., son iguales. La comparación no tiene en cuenta valores de identificadores únicos (p.ej., SlideId) ni contenido dinámico (p.ej., valor de fecha actual en un marcador de posición de fecha). 


## **Establecer el Patrón de diapositivas como vista predeterminada de la presentación**

Aspose.Slides permite establecer un Patrón de diapositivas como la vista predeterminada de una presentación. La vista predeterminada es lo que ves primero al abrir una presentación. 

Este código muestra cómo establecer un Patrón de diapositivas como la vista predeterminada de una presentación en JavaScript:
```javascript
// Instancia una clase Presentation que representa el archivo de la presentación
var presentation = new aspose.slides.Presentation();
try {
    // Establece la vista predeterminada como SlideMasterView
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    // Guarda la presentación
    presentation.save("PresView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Eliminar Maestro de diapositiva no utilizado**

Aspose.Slides proporciona el método [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (de la clase [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)) para que puedas eliminar maestros de diapositiva no deseados y sin usar. Este código JavaScript muestra cómo eliminar un maestro de diapositiva de una presentación de PowerPoint:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Qué es un Patrón de diapositivas en PowerPoint?**

Un Patrón de diapositivas es una plantilla que define la distribución, estilos, temas, fuentes, fondo y otras propiedades de las diapositivas en una presentación. Permite establecer y cambiar la apariencia de todas las diapositivas de la presentación a la vez.  

**¿Cómo se aplica un Patrón de diapositivas en una presentación?**

Cada presentación tiene al menos un Patrón de diapositivas por defecto. Cuando se añade una nueva diapositiva, se le aplica automáticamente un Patrón de diapositivas, normalmente heredando el patrón de la diapositiva anterior. Una presentación puede contener varios Patrones de diapositivas para estilizar diferentes partes de forma única.  

**¿Qué elementos se pueden personalizar en un Patrón de diapositivas?**

Un Patrón de diapositivas está compuesto por varios atributos principales que pueden personalizarse:

- **Background**: establecer el fondo de la diapositiva. 
- **BodyStyle**: definir los estilos de texto del cuerpo de la diapositiva. 
- **Shapes**: gestionar todas las formas del Patrón de diapositivas, incluidos marcadores de posición y marcos de imagen. 
- **Controls**: manejar controles ActiveX. 
- **ThemeManager**: acceder al gestor de temas. 
- **HeaderFooterManager**: gestionar encabezados y pies de página.  

**¿Cómo puedo añadir una imagen a un Patrón de diapositivas?**

Añadir una imagen a un Patrón de diapositivas garantiza que aparezca en todas las diapositivas que dependan de ese patrón. Por ejemplo, colocar el logotipo de la empresa en el Patrón de diapositivas lo mostrará en cada diapositiva de la presentación.  

**¿Cómo se relacionan los Patrones de diapositivas con las Distribuciones de diapositivas?**

Las Distribuciones de diapositivas funcionan junto con los Patrones de diapositivas para ofrecer flexibilidad en el diseño. Mientras el Patrón de diapositivas define los estilos y temas globales, las Distribuciones permiten variaciones en la disposición del contenido. La jerarquía es la siguiente:

- **Patrón de diapositivas** → Define estilos globales. 
- **Distribución de diapositiva** → Proporciona diferentes disposiciones de contenido. 
- **Diapositiva** → Hereda el diseño de su Distribución de diapositiva. 

**¿Puedo tener varios Patrones de diapositivas en una sola presentación?**

Sí, una presentación puede contener varios Patrones de diapositivas. Esto permite estilizar diferentes secciones de una presentación de diversas maneras, ofreciendo flexibilidad en el diseño.  

**¿Cómo accedo y modifico un Patrón de diapositivas usando Aspose.Slides?**

En Aspose.Slides, un Patrón de diapositivas está representado por la clase [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/). Puedes acceder a un Patrón de diapositivas mediante el método [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmasters/) del objeto [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).