---
title: Gestionar masters de diapositivas de presentación en JavaScript
linktitle: Master de diapositiva
type: docs
weight: 70
url: /es/nodejs-java/slide-master/
keywords:
- master de diapositiva
- diapositiva maestra
- diapositiva maestra PPT
- varias diapositivas maestras
- comparar diapositivas maestras
- fondo
- marcador de posición
- clonar diapositiva maestra
- copiar diapositiva maestra
- duplicar diapositiva maestra
- diapositiva maestra no utilizada
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestiona los masters de diapositivas en Aspose.Slides para Node.js a través de Java: accede, edita, clona, compara y elimina masters de diapositivas en presentaciones PowerPoint y OpenDocument."
---
## **Descripción general**

Un **slide master** define los ajustes de diseño compartidos para un grupo de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, ajustes de tema y ajustes de pie de página. En PowerPoint, editar un slide master es la forma habitual de mantener una presentación coherente sin repetir el mismo formato en cada diapositiva.

Aspose.Slides para Node.js a través de Java es compatible con el mismo modelo. Una presentación puede contener una o más master slides, y cada master slide puede contener varias layout slides. Normalmente, las diapositivas normales no hacen referencia directamente a un master slide. En su lugar, una diapositiva normal utiliza una layout slide, y esa layout slide pertenece a un master slide.

La jerarquía es:

1. **Slide master** - define el diseño y tema compartidos.  
1. **Layout slide** - define una disposición específica de marcadores de posición y formato a nivel de diseño.  
1. **Normal slide** - contiene el contenido real de la presentación y utiliza una layout slide.

![Jerarquía de master slides, layout slides y normal slides](slide-master_2.jpg)

En Aspose.Slides, un slide master se representa mediante la clase [MasterSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterslide/) . Todas las master slides de una presentación están disponibles a través de la colección `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
Cuando la misma propiedad se define en más de un nivel, gana el nivel más específico. Por ejemplo, si un master slide y una layout slide ambos definen un fondo, las diapositivas basadas en esa layout usarán el fondo de la layout. Para obtener más información sobre las layout slides, consulte [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Acceder a los slide masters**

En PowerPoint, puede abrir la vista Slide Master desde **View** > **Slide Master**.

![El comando Slide Master en la pestaña Vista de PowerPoint](slide-master_3.jpg)

En Aspose.Slides, use la colección `getMasters()` para acceder a los master slides:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

También puede obtener el master slide utilizado por una diapositiva normal a través de su layout:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Qué contiene un Slide Master**

Un master slide es un objeto similar a una diapositiva. Hereda el comportamiento común de las diapositivas de [BaseSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslide/), por lo que expone muchas de las mismas propiedades de diapositiva que usan las diapositivas normales y de layout. Los miembros específicos del master se enumeran en la página API de [MasterSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterslide/).

Los miembros de master slide más usados incluyen:

| Miembro | Propósito |
| --- | --- |
| `getBackground()` | Establece el fondo de la diapositiva a nivel de master. |
| `getShapes()` | Almacena las formas colocadas en el master, como logotipos, marcos de imágenes y texto compartido. |
| `getLayoutSlides()` | Almacena las layout slides que pertenecen al master. |
| `getThemeManager()` | Proporciona acceso a las API de tema del master. |
| `getHeaderFooterManager()` | Controla encabezados, pies de página, fechas y números de diapositiva para el master y sus diseños hijos. |
| `getDependingSlides()` | Devuelve las diapositivas normales que dependen del master a través de sus layouts. |

## **Añadir una imagen a un Slide Master**

Cuando añade una imagen a un master slide, aparece en las diapositivas que usan layouts de ese master. Esto es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales repetidos.

El siguiente ejemplo añade un logotipo al primer master slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para más información sobre los marcos de imágenes, consulte [Picture Frame](/nodejs-java/picture-frame/).

## **Trabajar con marcadores de posición**

Los marcadores de posición se definen normalmente en las layout slides. El master slide proporciona el estilo y tema compartidos que esos layouts heredan, mientras que cada layout decide qué marcadores de posición están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcador de posición están disponibles en la vista Slide Master.

![El comando Insertar marcador de posición en la vista Slide Master de PowerPoint](slide-master_5.png)

Para añadir nuevos marcadores de posición con Aspose.Slides, trabaje con la layout slide que pertenece al master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

También puede dar formato a las formas de marcador de posición que ya existen en un master slide. El siguiente ejemplo encuentra el marcador de posición de título y le aplica un relleno de degradado lineal:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Marcador de posición de título formateado heredado por diapositivas normales](slide-master_8.png)

Para más opciones de formato de marcadores de posición y texto, consulte [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) y [Text Formatting](/nodejs-java/text-formatting/).

## **Cambiar el fondo de un Slide Master**

Un fondo de master se hereda por los layouts y las diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para el primer master slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para temas relacionados, consulte [Presentation Background](/nodejs-java/presentation-background/) y [Presentation Theme](/nodejs-java/presentation-theme/).

## **Clonar un Slide Master a otra presentación**

Utilice `MasterSlideCollection.addClone` para copiar un master slide a otra presentación. El master copiado puede entonces ser usado por layouts y diapositivas en la presentación de destino.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Si necesita clonar diapositivas normales junto con su master, consulte [Clone Slides](/nodejs-java/clone-slides/).

## **Añadir varios Slide Masters**

Una presentación puede contener varios master slides. Esto es útil cuando diferentes secciones requieren distintas marcas, estructuras de página o ajustes de tema.

![Comandos de PowerPoint para insertar y gestionar master slides](slide-master_9.jpg)

El siguiente ejemplo clona el master predeterminado, asigna al clon un fondo diferente, crea una layout bajo ese master clonado y añade una nueva diapositiva basada en esa layout:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comparar Slide Masters**

Los master slides pueden compararse con el método `equals` heredado de [BaseSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslide/). La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otros ajustes de la diapositiva. No compara identificadores únicos, como los IDs de diapositiva, ni valores dinámicos de marcadores de posición, como la fecha actual.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Para más información, consulte [Compare Presentation Slides](/slides/es/nodejs-java/compare-slides/).

## **Establecer la vista Slide Master como vista predeterminada**

Utilice el método `setLastView` en [ViewProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/viewproperties/) para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en la vista Slide Master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para más ajustes de vista, consulte [Save Presentation](/slides/es/nodejs-java/save-presentation/).

## **Eliminar master slides no utilizados**

A veces las presentaciones contienen master slides que ya no son usados por ninguna diapositiva normal. Eliminar los masters no utilizados puede reducir el tamaño del archivo y simplificar el mantenimiento de plantillas.

Utilice `removeUnused` para eliminar los masters no usados de la colección `getMasters()`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

También puede usar el método de bajo código `Compress.removeUnusedMasterSlides`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### ¿Cuál es la diferencia entre un slide master y una layout slide?

Un slide master define los ajustes de diseño compartidos, como tema, fondo, formas comunes y estilos de texto. Una layout slide pertenece a un master slide y define una disposición específica de marcadores de posición. Una diapositiva normal usa una layout slide, por lo que hereda tanto del layout como del master.

### ¿Puede una presentación contener varios slide masters?

Sí. Una presentación puede contener varios slide masters. Utilice múltiples masters cuando diferentes secciones necesiten sistemas visuales o marcas distintas.

### ¿Debo añadir marcadores de posición a un master slide o a una layout slide?

En la mayoría de los casos, añada marcadores de posición a las layout slides. Coloque los elementos visuales y formatos compartidos en el master slide y los marcadores de posición de contenido en los layouts que usarán las diapositivas normales.

### ¿Puedo eliminar un master slide que todavía se utiliza?

No. Un master slide que tiene diapositivas dependientes no puede eliminarse de forma segura. Primero mueva esas diapositivas a layouts bajo otro master, o utilice un método de limpieza de masters no usados que elimine sólo los masters que no están en uso.