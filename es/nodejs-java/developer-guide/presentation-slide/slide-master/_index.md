---
title: Gestionar maestros de diapositivas de presentación en JavaScript
linktitle: Maestro de diapositivas
type: docs
weight: 70
url: /es/nodejs-java/slide-master/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Administrar los maestros de diapositivas en Aspose.Slides para Node.js mediante Java: crear, editar y aplicar diseños, temas y marcadores de posición a PPT, PPTX y ODP con ejemplos concisos."
---

## **Qué es un Slide Master en PowerPoint**

Un **Slide Master** es una plantilla de diapositiva que define la disposición, los estilos, el tema, las fuentes, el fondo y otras propiedades de las diapositivas en una presentación. Si desea crear una presentación (o una serie de presentaciones) con el mismo estilo y plantilla para su empresa, puede usar un Slide Master. 

Un Slide Master es útil porque le permite establecer y cambiar el aspecto de todas las diapositivas de la presentación de una vez. Aspose.Slides admite el mecanismo de Slide Master de PowerPoint. 

VBA también le permite manipular un Slide Master y ejecutar las mismas operaciones compatibles en PowerPoint: cambiar fondos, añadir formas, personalizar la distribución, etc. Aspose.Slides proporciona mecanismos flexibles para que pueda usar Slide Masters y realizar tareas básicas con ellos. 

Estas son operaciones básicas de Slide Master:

- Crear un Slide Master.  
- Aplicar el Slide Master a las diapositivas de la presentación.  
- Cambiar el fondo del Slide Master.  
- Añadir una imagen, marcador de posición, Smart Art, etc. al Slide Master.  

Estas son operaciones más avanzadas que implican Slide Master: 

- Comparar Slide Masters.  
- Fusionar Slide Masters.  
- Aplicar varios Slide Masters.  
- Copiar una diapositiva con Slide Master a otra presentación.  
- Detectar Slide Masters duplicados en presentaciones.  
- Establecer el Slide Master como la vista predeterminada de la presentación.  

{{% alert color="primary" %}} 

Es posible que desee consultar Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) porque es una implementación en vivo de algunos de los procesos básicos descritos aquí.

{{% /alert %}} 


## **Cómo se aplica el Slide Master**

Antes de trabajar con un Slide Master, es posible que desee comprender cómo se utilizan en las presentaciones y se aplican a las diapositivas. 

* Cada presentación tiene al menos un Slide Master de forma predeterminada.  
* Una presentación puede contener varios Slide Masters. Puede añadir varios Slide Masters y utilizarlos para dar estilo a diferentes partes de una presentación de distintas maneras.  

En **Aspose.Slides**, un Slide Master está representado por el tipo [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/).  

El objeto [Presentation ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) de Aspose.Slides contiene la lista [**getMasters**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters--) del tipo [**MasterSlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), que contiene una lista de todas las diapositivas maestras definidas en una presentación.  

Además de las operaciones CRUD, la clase [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) contiene estos métodos útiles: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/#addClone-aspose.slides.ILayoutSlide-) y [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/#insertClone-int-aspose.slides.IMasterSlide-). Esos métodos se heredan de la función básica de clonación de diapositivas. Pero al trabajar con Slide Masters, esos métodos permiten implementar configuraciones complicadas.  

Cuando se añade una nueva diapositiva a una presentación, se le aplica automáticamente un Slide Master. El Slide Master de la diapositiva anterior se selecciona de forma predeterminada.  

**Nota**: Las diapositivas de la presentación se almacenan en la lista [getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides--) y cada nueva diapositiva se añade al final de la colección de forma predeterminada. Si una presentación contiene un único Slide Master, ese Slide Master se selecciona para todas las diapositivas nuevas. Esta es la razón por la que no tiene que definir el Slide Master para cada diapositiva nueva que cree.  

El principio es el mismo para PowerPoint y Aspose.Slides. Por ejemplo, en PowerPoint, cuando añade una nueva diapositiva, puede pulsar en la línea inferior bajo la última diapositiva y entonces se creará una nueva diapositiva (con el Slide Master de la última presentación):  

![todo:image_alt_text](slide-master_1.jpg)

En Aspose.Slides, puede realizar la tarea equivalente con el método [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) bajo la clase [Presentation ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).  


## **Slide Master en la jerarquía de Slides**

Usar Slide Layouts con Slide Master permite la máxima flexibilidad. Un Slide Layout le permite establecer los mismos estilos que el Slide Master (fondo, fuentes, formas, etc.). Sin embargo, cuando varios Slide Layouts se combinan en un Slide Master, se crea un estilo nuevo. Cuando aplica un Slide Layout a una sola diapositiva, puede cambiar su estilo respecto al aplicado por el Slide Master.  

El Slide Master precede a todos los elementos de configuración: Slide Master → Slide Layout → Slide:  

![todo:image_alt_text](slide-master_2)

Cada objeto [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) tiene una propiedad [**getLayoutSlides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getLayoutSlides--) con una lista de Slide Layouts. Un tipo [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) tiene una propiedad [**getLayoutSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getLayoutSlide--) que enlaza con el Slide Layout aplicado a la diapositiva. La interacción entre una diapositiva y el Slide Master ocurre a través de un Slide Layout.  

{{% alert color="info" title="Nota" %}}

* En Aspose.Slides, todas las configuraciones de diapositiva (Slide Master, Slide Layout y la propia diapositiva) son en realidad objetos de diapositiva que implementan la clase [**BaseSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide).  
* Por lo tanto, Slide Master y Slide Layout pueden implementar las mismas propiedades y necesita saber cómo se aplicarán sus valores a un objeto [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide). El Slide Master se aplica primero a una diapositiva y luego se aplica el Slide Layout. Por ejemplo, si el Slide Master y el Slide Layout tienen ambos un valor de fondo, la diapositiva terminará con el fondo del Slide Layout.  

{{% /alert %}}


## **Qué compone un Slide Master**

Para comprender cómo se puede modificar un Slide Master, necesita conocer sus componentes. Estas son las propiedades principales de [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/).  

- [getBackground] obtener/establecer el fondo de la diapositiva.  
- [getBodyStyle] - obtener/establecer los estilos de texto del cuerpo de la diapositiva.  
- [getShapes] obtener/establecer todas las formas del Slide Master (marcadores de posición, marcos de imagen, etc).  
- [getControls] obtener/establecer controles ActiveX.  
- [getThemeManager] - obtener el gestor de temas.  
- [getHeaderFooterManager] - obtener el gestor de encabezados y pies de página.  

Métodos del Slide Master:  

- [getDependingSlides] - obtener todas las diapositivas que dependen del Slide Master.  
- [applyExternalThemeToDependingSlides] - permite crear un nuevo Slide Master basado en el Slide Master actual y un tema nuevo. El nuevo Slide Master se aplicará a todas las diapositivas dependientes.  


## **Obtener Slide Master**

En PowerPoint, el Slide Master se puede acceder desde el menú Ver → Slide Master:  

![todo:image_alt_text](slide-master_3.jpg)

Usando Aspose.Slides, puede acceder a un Slide Master de esta manera:  
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Da acceso a la diapositiva maestra de la presentación
    var masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


La clase [MasterSlide] representa un Slide Master. La propiedad [Masters] (relacionada con el tipo [MasterSlideCollection]) contiene una lista de todos los Slide Masters definidos en la presentación.  


## **Añadir imagen al Slide Master**

Cuando añade una imagen a un Slide Master, esa imagen aparecerá en todas las diapositivas que dependan de ese master.  

Por ejemplo, puede colocar el logotipo de su empresa y algunas imágenes en el Slide Master y luego volver al modo de edición de diapositivas. Debería ver la imagen en cada diapositiva.  

![todo:image_alt_text](slide-master_4.png)

Puede añadir imágenes a un slide master con Aspose.Slides:  
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

Para obtener más información sobre cómo añadir imágenes a una diapositiva, consulte el artículo [Picture Frame](/slides/es/nodejs-java/picture-frame/#create-picture-frame).

{{% /alert %}}


## **Añadir marcador de posición al Slide Master**

Estos campos de texto son marcadores de posición estándar en un Slide Master:  

* Haga clic para editar el estilo del título del Master  
* Editar estilos de texto del Master  
* Segundo nivel  
* Tercer nivel  

También aparecen en las diapositivas basadas en el Slide Master. Puede editar esos marcadores de posición en un Slide Master y los cambios se aplican automáticamente a las diapositivas.  

En PowerPoint, puede añadir un marcador de posición a través de la ruta Slide Master → Insert Placeholder:  

![todo:image_alt_text](slide-master_5.png)

Examinemos un ejemplo más complejo de marcadores de posición con Aspose.Slides. Considere una diapositiva con marcadores de posición basados en el Slide Master:  

![todo:image_alt_text](slide-master_6.png)

Queremos cambiar el formato del Título y el Subtítulo en el Slide Master de esta forma:  

![todo:image_alt_text](slide-master_7.png)

Primero, recuperamos el contenido del marcador de posición del título desde el objeto Slide Master y luego usamos el campo `PlaceHolder.FillFormat`:  
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


El estilo y formato del título cambiarán para todas las diapositivas basadas en el slide master:  

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Ver también" %}} 

* [Establecer texto de indicación en marcador de posición](https://docs.aspose.com/slides/nodejs-java/manage-placeholder/)  
* [Formato de texto](https://docs.aspose.com/slides/nodejs-java/text-formatting/)

{{% /alert %}}


## **Cambiar fondo en Slide Master**

Cuando cambia el color de fondo de una diapositiva maestra, todas las diapositivas normales de la presentación obtendrán el nuevo color. Este código JavaScript demuestra la operación:  
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

## **Clonar Slide Master a otra presentación**

Para clonar un Slide Master a otra presentación, llame al método [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) de la presentación de destino pasando un Slide Master como parámetro. Este código JavaScript le muestra cómo clonar un Slide Master a otra presentación:  
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



## **Añadir varios Slide Masters a la presentación**

Aspose.Slides le permite añadir varios Slide Masters y Slide Layouts a cualquier presentación. Esto le permite configurar estilos, distribuciones y opciones de formato para las diapositivas de la presentación de muchas maneras.  

En PowerPoint, puede añadir nuevos Slide Masters y Layouts (desde el “menú Slide Master”) de esta forma:  

![todo:image_alt_text](slide-master_9.jpg)

Usando Aspose.Slides, puede añadir un nuevo Slide Master llamando al método [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-):  
```javascript
// Añade una nueva diapositiva maestra
var secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **Comparar Slide Masters**

Una Master Slide implementa la clase [BaseSlide] que contiene el método [**equals**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#equals-aspose.slides.IBaseSlide-), que puede usarse para comparar diapositivas. Devuelve `true` para Master Slides idénticos en estructura y contenido estático.  

Dos Master Slides son iguales si sus formas, estilos, textos, animaciones y demás configuraciones son iguales. La comparación no tiene en cuenta los valores de identificadores únicos (p. ej., SlideId) ni el contenido dinámico (p. ej., el valor de fecha actual en un marcador de posición de fecha).  


## **Establecer Slide Master como vista predeterminada de la presentación**

Aspose.Slides le permite establecer un Slide Master como la vista predeterminada de una presentación. La vista predeterminada es lo que ve primero al abrir una presentación.  

Este código le muestra cómo establecer un Slide Master como vista predeterminada de una presentación en JavaScript:  
```javascript
// Instancia una clase Presentation que representa el archivo de presentación
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


## **Eliminar Slide Master sin usar**

Aspose.Slides proporciona el método [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (de la clase [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)) para eliminar Slides Masters no deseados y sin uso. Este código JavaScript le muestra cómo eliminar un Slide Master de una presentación PowerPoint:  
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


## **FAQ**

**¿Qué es un Slide Master en PowerPoint?**

Un Slide Master es una plantilla de diapositiva que define la disposición, los estilos, los temas, las fuentes, el fondo y otras propiedades de las diapositivas en una presentación. Permite establecer y cambiar el aspecto de todas las diapositivas de la presentación de una vez.  

**¿Cómo se aplica un Slide Master en una presentación?**

Cada presentación tiene al menos un Slide Master de forma predeterminada. Cuando se añade una nueva diapositiva, se le aplica automáticamente un Slide Master, generalmente heredando el master de la diapositiva anterior. Una presentación puede contener varios Slide Masters para dar estilo a diferentes partes de forma única.  

**¿Qué elementos se pueden personalizar en un Slide Master?**

Un Slide Master comprende varias propiedades principales que pueden personalizarse:

- **Background**: Establecer el fondo de la diapositiva.  
- **BodyStyle**: Definir los estilos de texto del cuerpo de la diapositiva.  
- **Shapes**: Gestionar todas las formas del Slide Master, incluidos marcadores de posición y marcos de imagen.  
- **Controls**: Gestionar controles ActiveX.  
- **ThemeManager**: Acceder al gestor de temas.  
- **HeaderFooterManager**: Gestionar encabezados y pies de página.  

**¿Cómo puedo añadir una imagen a un Slide Master?**

Añadir una imagen a un Slide Master garantiza que aparecerá en todas las diapositivas que dependan de ese master. Por ejemplo, colocar el logotipo de la empresa en el Slide Master hará que se muestre en cada diapositiva de la presentación.  

**¿Cómo se relacionan los Slide Masters con los Slide Layouts?**

Los Slide Layouts funcionan junto con los Slide Masters para ofrecer flexibilidad en el diseño de diapositivas. Mientras que un Slide Master define estilos y temas globales, los Slide Layouts permiten variaciones en la disposición del contenido. La jerarquía es la siguiente:

- **Slide Master** → Define estilos globales.  
- **Slide Layout** → Proporciona diferentes disposiciones de contenido.  
- **Slide** → Hereda el diseño de su Slide Layout.  

**¿Puedo tener varios Slide Masters en una sola presentación?**

Sí, una presentación puede contener varios Slide Masters. Esto permite dar estilo a diferentes secciones de la presentación de diversas maneras, proporcionando mayor flexibilidad en el diseño.  

**¿Cómo accedo y modifico un Slide Master usando Aspose.Slides?**

En Aspose.Slides, un Slide Master está representado por la clase [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/). Puede acceder a un Slide Master mediante el método [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmasters/) del objeto [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).