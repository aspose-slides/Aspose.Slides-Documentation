---
title: Gestionar maestros de diapositivas de presentación en JavaScript
linktitle: Maestro de diapositiva
type: docs
weight: 70
url: /es/nodejs-java/slide-master/
keywords:
- maestro de diapositiva
- maestro de diapositiva
- maestro de diapositiva PPT
- varios maestros de diapositivas
- comparar maestros de diapositivas
- fondo
- marcador de posición
- clonar maestro de diapositiva
- copiar maestro de diapositiva
- duplicar maestro de diapositiva
- maestro de diapositiva no usado
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestiona los maestros de diapositivas en Aspose.Slides para Node.js mediante Java: accede, edita, clona, compara y elimina maestros de diapositivas en presentaciones PowerPoint y OpenDocument."
---
## **Descripción general**

Un **maestro de diapositivas** define ajustes de diseño compartidos para un grupo de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, ajustes del tema y ajustes de pie de página. En PowerPoint, editar un maestro de diapositivas es la forma habitual de mantener una presentación coherente sin repetir el mismo formato en cada diapositiva.

Aspose.Slides for Node.js via Java admite el mismo modelo. Una presentación puede contener una o más diapositivas maestras, y cada diapositiva maestra puede contener varias diapositivas de diseño. Las diapositivas normales no suelen referirse directamente a una diapositiva maestra. En su lugar, una diapositiva normal utiliza una diapositiva de diseño, y esa diapositiva de diseño pertenece a una diapositiva maestra.

La jerarquía es:

1. **Maestro de diapositivas** - define el diseño y el tema compartidos.  
1. **Diapositiva de diseño** - define una disposición específica de marcadores de posición y formato a nivel de diseño.  
1. **Diapositiva normal** - contiene el contenido real de la presentación y usa una diapositiva de diseño.

![La jerarquía de diapositivas maestras, diapositivas de diseño y diapositivas normales](slide-master_2.jpg)

En Aspose.Slides, un maestro de diapositivas está representado por la clase [MasterSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterslide/). Todas las diapositivas maestras de una presentación están disponibles a través de la colección `Presentation.getMasters()`.

{{% alert color="info" title="Herencia" %}}
Cuando la misma propiedad se define en más de un nivel, gana el nivel más específico. Por ejemplo, si una diapositiva maestra y una diapositiva de diseño definen ambas un fondo, las diapositivas basadas en ese diseño usan el fondo del diseño. Para obtener más información sobre las diapositivas de diseño, consulta [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Acceso a maestros de diapositivas**

En PowerPoint, puedes abrir la vista Maestro de diapositivas desde **Vista** > **Maestro de diapositivas**.

![El comando Maestro de diapositivas en la pestaña Vista de PowerPoint](slide-master_3.jpg)

En Aspose.Slides, usa la colección `getMasters()` para acceder a las diapositivas maestras:

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

También puedes obtener la diapositiva maestra utilizada por una diapositiva normal a través de su diseño:

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

## **Qué contiene un maestro de diapositivas**

Una diapositiva maestra es un objeto similar a una diapositiva. Hereda el comportamiento común de las diapositivas de [BaseSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslide/), por lo que expone muchas de las mismas propiedades de diapositiva utilizadas por diapositivas normales y de diseño. Los miembros específicos del maestro se enumeran en la página API de [MasterSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterslide/).

Los miembros del maestro de diapositivas más utilizados incluyen:

| Miembro | Propósito |
| --- | --- |
| `getBackground()` | Establece el fondo a nivel de maestro de diapositiva. |
| `getShapes()` | Almacena las formas colocadas en el maestro, como logotipos, marcos de imagen y texto compartido. |
| `getLayoutSlides()` | Almacena las diapositivas de diseño que pertenecen al maestro. |
| `getThemeManager()` | Proporciona acceso a las API del tema del maestro. |
| `getHeaderFooterManager()` | Controla encabezados, pies de página, fechas y números de diapositiva para el maestro y sus diseños hijos. |
| `getDependingSlides()` | Devuelve las diapositivas normales que dependen del maestro a través de sus diseños. |

## **Añadir una imagen a un maestro de diapositivas**

Cuando añades una imagen a una diapositiva maestra, aparece en las diapositivas que usan diseños de ese maestro. Esto es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales repetidos.

El siguiente ejemplo añade un logotipo a la primera diapositiva maestra:

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

Para obtener más información sobre los marcos de imagen, consulta [Marco de imagen](/nodejs-java/picture-frame/).

## **Controlar la visibilidad de los gráficos del maestro**

Utiliza [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) para ocultar los gráficos heredados del maestro, como logotipos o formas decorativas, sin eliminarlos del maestro. Pasa `false` a [Slide.setShowMasterShapes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/#setShowMasterShapes) en la diapositiva que debe omitir esos gráficos y mantenlo `true` en las diapositivas que deben mostrarlos.

El siguiente ejemplo autónomo crea una banda decorativa azul en un maestro y dos diapositivas que usan el mismo diseño en blanco. La banda es visible en la primera diapositiva y está oculta en la segunda. No se requiere ninguna presentación de entrada ni imagen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El ejemplo usa el diseño **Blank** suministrado con una nueva presentación y elimina los marcadores de posición propios de la diapositiva inicial.

### **Elegir el alcance de la configuración**

Una diapositiva normal usa su maestro a través de [Slide.getLayoutSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/#getLayoutSlide) y [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutslide/#getMasterSlide). Establecer la propiedad en una diapositiva individual afecta solo a esa diapositiva. Pasar `false` a [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) oculta los gráficos del maestro para las diapositivas que usan ese diseño compartido, incluso si su propia configuración es `true`. Para ocultar gráficos solo en una diapositiva, cambia la propiedad de la diapositiva y deja el diseño compartido sin modificar.

La configuración no se admite como control de visibilidad en la propia diapositiva maestra. En un maestro, [getShowMasterShapes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) siempre devuelve `false`, y pasar `true` a [setShowMasterShapes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) genera una excepción. Aplícala a una diapositiva normal o a un diseño.

### **Distinguir los gráficos del fondo**

| Operación | Efecto |
| --- | --- |
| Ocultar gráficos del maestro | Controla la visibilidad de las formas heredadas del maestro sin eliminarlas ni cambiar las propias formas de la diapositiva. |
| Cambiar el relleno del fondo de la diapositiva | Cambia el color, degradado o imagen del fondo. Los gráficos del maestro son formas separadas y pueden permanecer visibles sobre ese fondo. Consulta [Presentation Background](/slides/es/nodejs-java/presentation-background/). |
| Eliminar una forma del maestro | Elimina la forma fuente compartida, de modo que ya no esté disponible para ninguna diapositiva que use ese maestro. |

## **Trabajar con marcadores de posición**

Los marcadores de posición se definen normalmente en las diapositivas de diseño. La diapositiva maestra proporciona el estilo y el tema compartidos que esos diseños heredan, mientras que cada diseño decide qué marcadores de posición están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcadores de posición están disponibles en la vista Maestro de diapositivas.

![El comando Insertar marcador de posición en la vista Maestro de diapositivas de PowerPoint](slide-master_5.png)

Para añadir nuevos marcadores de posición con Aspose.Slides, trabaja con la diapositiva de diseño que pertenece al maestro:

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

También puedes dar formato a las formas de marcador de posición que ya existen en una diapositiva maestra. El siguiente ejemplo encuentra el marcador de posición del título y le aplica un relleno degradado lineal:

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

Para más opciones de marcadores de posición y formato de texto, consulta [Establecer texto de sugerencia en marcador de posición](/nodejs-java/manage-placeholder/) y [Formato de texto](/nodejs-java/text-formatting/).

## **Cambiar el fondo de un maestro de diapositivas**

El fondo del maestro se hereda por los diseños y las diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para la primera diapositiva maestra:

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

Para temas relacionados, consulta [Fondo de presentación](/nodejs-java/presentation-background/) y [Tema de presentación](/nodejs-java/presentation-theme/).

## **Clonar un maestro de diapositivas a otra presentación**

Utiliza `MasterSlideCollection.addClone` para copiar una diapositiva maestra a otra presentación. El maestro copiado puede entonces ser usado por diseños y diapositivas en la presentación de destino.

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

Si necesitas clonar diapositivas normales junto con su maestro, consulta [Clonar diapositivas](/nodejs-java/clone-slides/).

## **Añadir varios maestros de diapositivas**

Una presentación puede contener varios maestros de diapositivas. Esto es útil cuando diferentes secciones requieren diferentes marcas, estructuras de página o ajustes de tema.

![Comandos de PowerPoint para insertar y administrar maestros de diapositivas](slide-master_9.jpg)

El siguiente ejemplo clona el maestro predeterminado, le da al clon un fondo diferente, crea un diseño bajo ese maestro clonado y añade una nueva diapositiva basada en ese diseño:

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

## **Comparar maestros de diapositivas**

Los maestros de diapositivas pueden compararse con el método `equals` heredado de [BaseSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslide/). La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otros ajustes de la diapositiva. No compara identificadores únicos, como IDs de diapositiva, ni valores dinámicos de marcadores de posición, como la fecha actual.

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

Para más información, consulta [Comparar diapositivas de presentación](/slides/es/nodejs-java/compare-slides/).

## **Establecer la vista de maestro de diapositivas como vista predeterminada**

Utiliza el método `setLastView` en [ViewProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/viewproperties/) para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en la vista Maestro de diapositivas:

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

Para más ajustes de vista, consulta [Guardar presentación](/slides/es/nodejs-java/save-presentation/).

## **Eliminar maestros de diapositivas no utilizados**

A veces las presentaciones contienen maestros de diapositivas que ya no son usados por ninguna diapositiva normal. Eliminar los maestros no utilizados puede reducir el tamaño del archivo y simplificar el mantenimiento de la plantilla.

Utiliza `removeUnused` para eliminar los maestros no utilizados de la colección `getMasters()`:

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

También puedes usar el método de bajo código `Compress.removeUnusedMasterSlides`:

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

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un maestro de diapositivas y una diapositiva de diseño?**

Un maestro de diapositivas define ajustes de diseño compartidos como tema, fondo, formas comunes y estilos de texto. Una diapositiva de diseño pertenece a un maestro de diapositivas y define una disposición específica de marcadores de posición. Una diapositiva normal usa una diapositiva de diseño, por lo que hereda tanto del diseño como del maestro.

**¿Puede una presentación contener varios maestros de diapositivas?**

Sí. Una presentación puede contener varios maestros de diapositivas. Usa varios maestros cuando diferentes secciones necesitan sistemas visuales o marcas diferentes.

**¿Debo añadir marcadores de posición a una diapositiva maestra o a una diapositiva de diseño?**

En la mayoría de los casos, añade los marcadores de posición a las diapositivas de diseño. Coloca los elementos visuales compartidos y el formato común en la diapositiva maestra y luego coloca los marcadores de posición de contenido en los diseños que usarán las diapositivas normales.

**¿Puedo eliminar una diapositiva maestra que aún está en uso?**

No. Una diapositiva maestra que tiene diapositivas dependientes no puede eliminarse de forma segura directamente. Primero traslada esas diapositivas a diseños bajo otro maestro, o utiliza un método de limpieza de maestros no usados que elimine solo los maestros que no están en uso.