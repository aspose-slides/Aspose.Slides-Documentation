---
title: Gestionar maestros de diapositivas de presentación en JavaScript
linktitle: Maestro de diapositiva
type: docs
weight: 70
url: /es/nodejs-java/slide-master/
keywords:
- maestro de diapositiva
- diapositiva maestra
- diapositiva maestra PPT
- diapositivas maestras múltiples
- comparar diapositivas maestras
- fondo
- marcador de posición
- clonar diapositiva maestra
- copiar diapositiva maestra
- duplicar diapositiva maestra
- diapositiva maestra sin uso
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestiona los maestros de diapositivas en Aspose.Slides para Node.js mediante Java: accede, edita, clona, compara y elimina diapositivas maestras en presentaciones de PowerPoint y OpenDocument."
---
## **Visión general**

Un **slide master** define configuraciones de diseño compartidas para un grupo de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, configuraciones de tema y configuraciones de pie de página. En PowerPoint, editar un slide master es la forma habitual de mantener una presentación coherente sin repetir el mismo formato en cada diapositiva.

Aspose.Slides para Node.js mediante Java admite el mismo modelo. Una presentación puede contener una o más diapositivas master, y cada diapositiva master puede contener varias diapositivas de diseño. Las diapositivas normales normalmente no hacen referencia a una diapositiva master directamente. En su lugar, una diapositiva normal utiliza una diapositiva de diseño, y esa diapositiva de diseño pertenece a una diapositiva master.

La jerarquía es:

1. **Slide master** - define el diseño y tema compartidos.  
1. **Layout slide** - define una disposición específica de marcadores de posición y formato a nivel de diseño.  
1. **Normal slide** - contiene el contenido real de la presentación y utiliza una diapositiva de diseño.

![La jerarquía de diapositivas master, diapositivas de diseño y diapositivas normales](slide-master_2.jpg)

En Aspose.Slides, un slide master está representado por la clase [MasterSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterslide/). Todas las diapositivas master en una presentación están disponibles mediante la colección `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
Cuando la misma propiedad se define en más de un nivel, el nivel más específico gana. Por ejemplo, si una diapositiva master y una diapositiva de diseño ambos definen un fondo, las diapositivas basadas en ese diseño usan el fondo del diseño. Para obtener más información sobre las diapositivas de diseño, consulte [Aplicar o cambiar diseños de diapositivas](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Acceder a los slide masters**

En PowerPoint, puedes abrir la vista Slide Master desde **View** > **Slide Master**.

![El comando Slide Master en la pestaña View de PowerPoint](slide-master_3.jpg)

En Aspose.Slides, usa la colección `getMasters()` para acceder a las diapositivas master:

```javascript
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

También puedes obtener la diapositiva master utilizada por una diapositiva normal a través de su diseño:

```javascript
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

## **Qué contiene un slide master**

Una diapositiva master es un objeto similar a una diapositiva. Hereda el comportamiento común de diapositivas de [BaseSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslide/), por lo que expone muchas de las mismas propiedades de diapositiva utilizadas por diapositivas normales y de diseño. Los miembros específicos de master se enumeran en la página API de [MasterSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterslide/).

Los miembros de diapositiva master más usados incluyen:

| Miembro | Propósito |
| --- | --- |
| `getBackground()` | Establece el fondo de diapositiva a nivel de master. |
| `getShapes()` | Almacena las formas colocadas en el master, como logotipos, marcos de imagen y texto compartido. |
| `getLayoutSlides()` | Almacena las diapositivas de diseño que pertenecen al master. |
| `getThemeManager()` | Proporciona acceso a las API del tema del master. |
| `getHeaderFooterManager()` | Controla encabezados, pies de página, fechas y números de diapositiva para el master y sus diseños hijos. |
| `getDependingSlides()` | Devuelve las diapositivas normales que dependen del master a través de sus diseños. |

## **Agregar una imagen a un slide master**

Cuando añades una imagen a una diapositiva master, aparece en las diapositivas que usan diseños de ese master. Esto es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales repetidos.

El siguiente ejemplo agrega un logotipo a la primera diapositiva master:

```javascript
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

Para obtener más información sobre los marcos de imagen, consulte [Marco de imagen](/nodejs-java/picture-frame/).

## **Trabajar con marcadores de posición**

Los marcadores de posición normalmente se definen en las diapositivas de diseño. La diapositiva master proporciona el estilo y tema compartidos que esos diseños heredan, mientras que cada diseño decide qué marcadores de posición están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcador de posición están disponibles en la vista Slide Master.

![El comando Insertar marcador de posición en la vista Slide Master de PowerPoint](slide-master_5.png)

Para agregar nuevos marcadores de posición con Aspose.Slides, trabaja con la diapositiva de diseño que pertenece al master:

```javascript
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

También puedes dar formato a las formas de marcador de posición que ya existen en una diapositiva master. El siguiente ejemplo encuentra el marcador de posición de título y aplica un relleno de degradado lineal:

```javascript
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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Marcador de posición de título formateado heredado por diapositivas normales](slide-master_8.png)

Para obtener más opciones de marcadores de posición y formato de texto, consulte [Establecer texto de solicitud en marcador de posición](/nodejs-java/manage-placeholder/) y [Formato de texto](/nodejs-java/text-formatting/).

## **Cambiar el fondo de un slide master**

Un fondo de master es heredado por los diseños y diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para la primera diapositiva master:

```javascript
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

Para temas relacionados, consulte [Fondo de presentación](/nodejs-java/presentation-background/) y [Tema de presentación](/nodejs-java/presentation-theme/).

## **Clonar un slide master en otra presentación**

Utiliza `MasterSlideCollection.addClone` para copiar una diapositiva master a otra presentación. El master copiado puede entonces ser utilizado por los diseños y diapositivas en la presentación de destino.

```javascript
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

Si necesitas clonar diapositivas normales junto con su master, consulta [Clonar diapositivas](/nodejs-java/clone-slides/).

## **Agregar varios slide masters**

Una presentación puede contener varias diapositivas master. Esto es útil cuando diferentes secciones requieren diferentes marcas, estructuras de página o configuraciones de tema.

![Comandos de PowerPoint para insertar y gestionar diapositivas master](slide-master_9.jpg)

El siguiente ejemplo clona el master predeterminado, le asigna al clon un fondo diferente, crea un diseño bajo ese master clonado y agrega una nueva diapositiva basada en ese diseño:

```javascript
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

## **Comparar slide masters**

Las diapositivas master pueden compararse con el método `equals` heredado de [BaseSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslide/). La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otras configuraciones de diapositiva. No compara identificadores únicos, como los IDs de diapositiva, ni valores dinámicos de marcadores de posición, como la fecha actual.

```javascript
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

Para obtener más información, consulte [Comparar diapositivas de presentación](/nodejs-java/compare-slides/).

## **Establecer la vista Slide Master como vista predeterminada**

Utiliza el método `setLastView` en [ViewProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/viewproperties/) para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en la vista Slide Master:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para más ajustes de vista, consulte [Guardar presentación](/nodejs-java/save-presentation/).

## **Eliminar diapositivas master no usadas**

A veces las presentaciones contienen diapositivas master que ya no son usadas por ninguna diapositiva normal. Eliminar masters no usados puede reducir el tamaño del archivo y simplificar el mantenimiento de la plantilla.

Utiliza `removeUnused` para eliminar los masters no usados de la colección `getMasters()`:

```javascript
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
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**¿Cuál es la diferencia entre un slide master y una diapositiva de diseño?**

Un slide master define configuraciones de diseño compartidas como tema, fondo, formas comunes y estilos de texto. Una diapositiva de diseño pertenece a un slide master y define una disposición específica de marcadores de posición. Una diapositiva normal usa una diapositiva de diseño, por lo que hereda tanto del diseño como del master.

**¿Puede una presentación contener varios slide masters?**

Sí. Una presentación puede contener varios slide masters. Utiliza varios masters cuando diferentes secciones necesitan sistemas visuales o marcas diferentes.

**¿Debo añadir marcadores de posición a una diapositiva master o a una diapositiva de diseño?**

En la mayoría de los casos, agrega marcadores de posición a las diapositivas de diseño. Coloca los elementos visuales compartidos y el formato compartido en la diapositiva master, y luego pon los marcadores de posición de contenido en los diseños que usarán las diapositivas normales.

**¿Puedo eliminar una diapositiva master que todavía está en uso?**

No. Una diapositiva master que tiene diapositivas dependientes no puede eliminarse de forma segura directamente. Primero mueve esas diapositivas a diseños bajo otro master, o utiliza un método de limpieza de masters no usados que elimine solo los masters que no están en uso.