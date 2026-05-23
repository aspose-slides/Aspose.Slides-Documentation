---
title: Gestionar maestros de diapositivas de presentación en Java
linktitle: Maestro de diapositiva
type: docs
weight: 70
url: /es/java/slide-master/
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
- Java
- Aspose.Slides
description: "Gestionar maestros de diapositivas en Aspose.Slides para Java: acceder, editar, clonar, comparar y eliminar diapositivas maestras en presentaciones de PowerPoint y OpenDocument."
---
## **Visión general**

Un **slide master** define configuraciones de diseño compartidas para un grupo de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, configuraciones de tema y configuraciones de pie de página. En PowerPoint, editar un slide master es la forma habitual de mantener una presentación coherente sin repetir el mismo formato en cada diapositiva.

Aspose.Slides for Java admite el mismo modelo. Una presentación puede contener una o más diapositivas master, y cada diapositiva master puede contener varias diapositivas de diseño. Las diapositivas normales normalmente no hacen referencia a una diapositiva master directamente. En su lugar, una diapositiva normal usa una diapositiva de diseño, y esa diapositiva de diseño pertenece a una diapositiva master.

La jerarquía es:

1. **Slide master** - define el diseño y tema compartidos.  
1. **Layout slide** - define una disposición específica de marcadores de posición y formato a nivel de diseño.  
1. **Normal slide** - contiene el contenido real de la presentación y usa una diapositiva de diseño.

![La jerarquía de diapositivas master, diapositivas de diseño y diapositivas normales](slide-master_2.jpg)

En Aspose.Slides, un slide master está representado por la interfaz [IMasterSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslide/). Todas las diapositivas master en una presentación están disponibles a través de la colección [Presentation.getMasters](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getMasters--) , que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Cuando la misma propiedad se define en más de un nivel, el nivel más específico prevalece. Por ejemplo, si una diapositiva master y una diapositiva de diseño ambas definen un fondo, las diapositivas basadas en ese diseño usan el fondo del diseño. Para obtener más información sobre las diapositivas de diseño, consulte [Apply or Change Slide Layouts](/slides/es/java/slide-layout/).
{{% /alert %}}

## **Acceder a los slide masters**

En PowerPoint, puede abrir la vista Slide Master desde **View** > **Slide Master**.

![El comando Slide Master en la pestaña View de PowerPoint](slide-master_3.jpg)

En Aspose.Slides, use la colección `getMasters()` para acceder a diapositivas master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

También puede obtener la diapositiva master usada por una diapositiva normal a través de su diseño:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Qué contiene un Slide Master**

Una diapositiva master es un objeto similar a una diapositiva. Implementa [IBaseSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibaseslide/), por lo que expone muchas de las mismas propiedades de diapositiva utilizadas por diapositivas normales y de diseño. Los miembros específicos de master se enumeran en la página de API [IMasterSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslide/).

Los miembros de diapositiva master más utilizados incluyen:

| Miembro | Propósito |
| --- | --- |
| `getBackground()` | Establece el fondo de la diapositiva a nivel de master. |
| `getShapes()` | Almacena las formas colocadas en el master, como logotipos, marcos de imagen y texto compartido. |
| `getLayoutSlides()` | Almacena las diapositivas de diseño que pertenecen al master. |
| `getThemeManager()` | Proporciona acceso a las API del tema del master. |
| `getHeaderFooterManager()` | Controla encabezados, pies de página, fechas y números de diapositiva para el master y sus diseños secundarios. |
| `getDependingSlides()` | Devuelve las diapositivas normales que dependen del master a través de sus diseños. |

## **Agregar una imagen a un Slide Master**

Cuando agrega una imagen a una diapositiva master, aparece en las diapositivas que usan diseños de ese master. Esto es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales repetidos.

El siguiente ejemplo agrega un logotipo a la primera diapositiva master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para obtener más información sobre los marcos de imagen, consulte [Picture Frame](/slides/es/java/picture-frame/).

## **Trabajar con marcadores de posición**

Los marcadores de posición normalmente se definen en las diapositivas de diseño. La diapositiva master proporciona el estilo y tema compartidos que esos diseños heredan, mientras que cada diseño decide qué marcadores de posición están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcador de posición están disponibles en la vista Slide Master.

![El comando Insert Placeholder en la vista Slide Master de PowerPoint](slide-master_5.png)

Para agregar nuevos marcadores de posición con Aspose.Slides, trabaje con la diapositiva de diseño que pertenece al master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

También puede formatear formas de marcador de posición que ya existen en una diapositiva master. El siguiente ejemplo encuentra el marcador de posición de título y aplica un relleno de degradado lineal:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Marcador de posición de título formateado heredado por diapositivas normales](slide-master_8.png)

Para obtener más opciones de formato de marcadores de posición y texto, consulte [Set Prompt Text in Placeholder](/slides/es/java/manage-placeholder/) y [Text Formatting](/slides/es/java/text-formatting/).

## **Cambiar el fondo de un Slide Master**

Un fondo de master se hereda por los diseños y diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para la primera diapositiva master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para temas relacionados, consulte [Presentation Background](/slides/es/java/presentation-background/) y [Presentation Theme](/slides/es/java/presentation-theme/).

## **Clonar un Slide Master a otra presentación**

Utilice [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) para copiar una diapositiva master a otra presentación. El master copiado puede entonces ser usado por los diseños y diapositivas en la presentación de destino.

```java
Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Si necesita clonar diapositivas normales junto con su master, consulte [Clone Slides](/slides/es/java/clone-slides/).

## **Agregar varios Slide Masters**

Una presentación puede contener varias diapositivas master. Esto es útil cuando diferentes secciones requieren diferentes marcas, estructura de página o configuraciones de tema.

![Comandos de PowerPoint para insertar y gestionar diapositivas master](slide-master_9.jpg)

El siguiente ejemplo clona el master predeterminado, le asigna al clon un fondo diferente, crea un diseño bajo ese master clonado y agrega una nueva diapositiva basada en ese diseño:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comparar Slide Masters**

Las diapositivas master pueden compararse con el método `equals` heredado de [IBaseSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibaseslide/). La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otras configuraciones de diapositiva. No compara identificadores únicos, como los IDs de diapositiva, ni valores dinámicos de marcadores de posición, como la fecha actual.

```java
Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Para obtener más información, consulte [Compare Presentation Slides](/slides/es/java/compare-slides/).

## **Establecer la vista Slide Master como vista predeterminada**

Utilice el método `setLastView` en [ViewProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/viewproperties/) para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en la vista Slide Master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para más configuraciones de vista, consulte [Save Presentation](/slides/es/java/save-presentation/).

## **Eliminar diapositivas master sin usar**

A veces las presentaciones contienen diapositivas master que ya no son usadas por ninguna diapositiva normal. Eliminar masters sin usar puede reducir el tamaño del archivo y simplificar el mantenimiento de la plantilla.

Use `removeUnused` para eliminar masters sin usar de la colección `getMasters()`:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

También puede usar el método de bajo código [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/es/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**¿Cuál es la diferencia entre un slide master y una diapositiva de diseño?**

Un slide master define configuraciones de diseño compartidas como tema, fondo, formas comunes y estilos de texto. Una diapositiva de diseño pertenece a una diapositiva master y define una disposición específica de marcadores de posición. Una diapositiva normal usa una diapositiva de diseño, por lo que hereda tanto del diseño como del master.

**¿Puede una presentación contener varios slide masters?**

Sí. Una presentación puede contener varios slide masters. Utilice varios masters cuando diferentes secciones necesiten sistemas visuales o marcas diferentes.

**¿Debo añadir marcadores de posición a una diapositiva master o a una diapositiva de diseño?**

En la mayoría de los casos, añada marcadores de posición a las diapositivas de diseño. Coloque los elementos visuales compartidos y el formato compartido en la diapositiva master, y luego ponga los marcadores de posición de contenido en los diseños que usarán las diapositivas normales.

**¿Puedo eliminar una diapositiva master que todavía se está usando?**

No. Una diapositiva master que tiene diapositivas dependientes no puede eliminarse de forma segura directamente. Primero mueva esas diapositivas a diseños bajo otro master, o utilice un método de limpieza de masters sin usar que elimine solo los masters que no estén en uso.