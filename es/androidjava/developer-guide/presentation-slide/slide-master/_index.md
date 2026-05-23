---
title: Gestionar maestros de diapositivas de presentación en Android
linktitle: Maestra de diapositiva
type: docs
weight: 70
url: /es/androidjava/slide-master/
keywords:
- maestra de diapositiva
- diapositiva maestra
- diapositiva maestra PPT
- varias diapositivas maestras
- comparar diapositivas maestras
- fondo
- marcador de posición
- clonar diapositiva maestra
- copiar diapositiva maestra
- duplicar diapositiva maestra
- diapositiva maestra no usada
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Gestiona las maestras de diapositivas en Aspose.Slides para Android mediante Java: accede, edita, clona, compara y elimina diapositivas maestras en presentaciones de PowerPoint y OpenDocument."
---
## **Visión general**

Una **maestra de diapositivas** define configuraciones de diseño compartidas para un grupo de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, configuraciones de tema y de pie de página. En PowerPoint, editar una maestra de diapositivas es la forma habitual de mantener una presentación coherente sin repetir el mismo formato en cada diapositiva.

Aspose.Slides para Android mediante Java es compatible con el mismo modelo. Una presentación puede contener una o más diapositivas maestras, y cada diapositiva maestra puede contener varias diapositivas de diseño. Las diapositivas normales normalmente no hacen referencia a una diapositiva maestra directamente. En su lugar, una diapositiva normal usa una diapositiva de diseño, y esa diapositiva de diseño pertenece a una diapositiva maestra.

La jerarquía es:

1. **Maestra de diapositivas** – define el diseño y tema compartidos.  
1. **Diapositiva de diseño** – define una disposición específica de marcadores de posición y formato a nivel de diseño.  
1. **Diapositiva normal** – contiene el contenido real de la presentación y usa una diapositiva de diseño.

![La jerarquía de diapositivas maestras, diapositivas de diseño y diapositivas normales](slide-master_2.jpg)

En Aspose.Slides, una maestra de diapositivas está representada por la interfaz [IMasterSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterslide/). Todas las maestras de diapositivas de una presentación están disponibles a través de la colección [Presentation.getMasters](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getMasters--) , que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterslidecollection/). Para obtener la referencia completa de la API Android mediante Java, consulte la [referencia de la API com.aspose.slides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/).

{{% alert color="info" title="Herencia" %}}

Cuando la misma propiedad se define en más de un nivel, gana el nivel más específico. Por ejemplo, si una diapositiva maestra y una diapositiva de diseño definen un fondo, las diapositivas basadas en ese diseño usan el fondo del diseño. Para obtener más información sobre las diapositivas de diseño, vea [Aplicar o cambiar diseños de diapositivas](/slides/es/androidjava/slide-layout/).

{{% /alert %}}

## **Acceder a las maestras de diapositivas**

En PowerPoint, puede abrir la vista Maestra de diapositivas desde **Vista** > **Maestra de diapositivas**.

![El comando Maestra de diapositivas en la pestaña Vista de PowerPoint](slide-master_3.jpg)

En Aspose.Slides, use la colección `getMasters()` para acceder a las maestras de diapositivas:

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

También puede obtener la diapositiva maestra usada por una diapositiva normal a través de su diseño:

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

## **Qué contiene una maestra de diapositivas**

Una diapositiva maestra es un objeto similar a una diapositiva. Implementa [IBaseSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseslide/), por lo que expone muchas de las mismas propiedades de diapositiva usadas por diapositivas normales y de diseño.

Los miembros de la diapositiva maestra más usados incluyen:

| Miembro | Propósito |
| --- | --- |
| `getBackground()` | Establece el fondo de la diapositiva a nivel de maestra. |
| `getShapes()` | Almacena las formas colocadas en la maestra, como logotipos, marcos de imágenes y texto compartido. |
| `getLayoutSlides()` | Almacena las diapositivas de diseño que pertenecen a la maestra. |
| `getThemeManager()` | Proporciona acceso a las API del tema de la maestra. |
| `getHeaderFooterManager()` | Controla encabezados, pies de página, fechas y números de diapositiva para la maestra y sus diseños secundarios. |
| `getDependingSlides()` | Devuelve las diapositivas normales que dependen de la maestra a través de sus diseños. |

## **Añadir una imagen a una maestra de diapositivas**

Cuando añade una imagen a una diapositiva maestra, aparece en las diapositivas que usan diseños de esa maestra. Esto es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales repetidos.

El siguiente ejemplo añade un logotipo a la primera maestra de diapositivas:

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

Para obtener más información sobre marcos de imágenes, vea [Marco de imagen](/slides/es/androidjava/picture-frame/).

## **Trabajar con marcadores de posición**

Los marcadores de posición se definen normalmente en las diapositivas de diseño. La diapositiva maestra proporciona el estilo y tema compartidos que esos diseños heredan, mientras que cada diseño decide qué marcadores de posición están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcador de posición están disponibles en la vista Maestra de diapositivas.

![El comando Insertar marcador de posición en la vista Maestra de diapositivas de PowerPoint](slide-master_5.png)

Para añadir nuevos marcadores de posición con Aspose.Slides, trabaje con la diapositiva de diseño que pertenece a la maestra:

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

También puede dar formato a las formas de marcador de posición que ya existen en una diapositiva maestra. El siguiente ejemplo busca el marcador de posición del título y le aplica un relleno de degradado lineal:

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
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Marcador de posición de título formateado heredado por diapositivas normales](slide-master_8.png)

Para más opciones de formato de marcadores de posición y texto, vea [Establecer texto del aviso en marcador de posición](/slides/es/androidjava/manage-placeholder/) y [Formato de texto](/slides/es/androidjava/text-formatting/).

## **Cambiar el fondo de una maestra de diapositivas**

Un fondo de maestra se hereda por los diseños y diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para la primera maestra de diapositivas:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para temas relacionados, vea [Fondo de la presentación](/slides/es/androidjava/presentation-background/) y [Tema de la presentación](/slides/es/androidjava/presentation-theme/).

## **Clonar una maestra de diapositivas a otra presentación**

Utilice [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) para copiar una maestra de diapositivas a otra presentación. La maestra copiada puede entonces usarse en los diseños y diapositivas de la presentación de destino.

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

Si necesita clonar diapositivas normales junto con su maestra, vea [Clonar diapositivas](/slides/es/androidjava/clone-slides/).

## **Añadir varias maestras de diapositivas**

Una presentación puede contener varias maestras de diapositivas. Esto es útil cuando diferentes secciones requieren distintas marcas, estructura de página o configuraciones de tema.

![Comandos de PowerPoint para insertar y gestionar maestras de diapositivas](slide-master_9.jpg)

El siguiente ejemplo clona la maestra predeterminada, le asigna un fondo diferente, crea un diseño bajo esa maestra clonada y añade una nueva diapositiva basada en ese diseño:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

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

## **Comparar maestras de diapositivas**

Las maestras de diapositivas pueden compararse con el método `equals` heredado de [IBaseSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseslide/). La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otras configuraciones de diapositiva. No compara identificadores únicos, como los IDs de diapositiva, ni valores dinámicos de marcadores de posición, como la fecha actual.

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

Para más información, vea [Comparar diapositivas de presentación](/slides/es/androidjava/compare-slides/).

## **Establecer la vista Maestra de diapositivas como vista predeterminada**

Utilice el método `setLastView` en [ViewProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/viewproperties/) para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en la vista Maestra de diapositivas:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para más configuraciones de vista, vea [Guardar presentación](/slides/es/androidjava/save-presentation/).

## **Eliminar maestras de diapositivas no usadas**

Algunas presentaciones contienen maestras de diapositivas que ya no son usadas por ninguna diapositiva normal. Eliminar maestras no usadas puede reducir el tamaño del archivo y simplificar el mantenimiento de la plantilla.

Use `removeUnused` para eliminar maestras no usadas de la colección `getMasters()`:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

También puede usar el método de bajo código [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-):

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una maestra de diapositivas y una diapositiva de diseño?**

Una maestra de diapositivas define configuraciones de diseño compartidas como tema, fondo, formas comunes y estilos de texto. Una diapositiva de diseño pertenece a una maestra y define una disposición específica de marcadores de posición. Una diapositiva normal usa una diapositiva de diseño, por lo que hereda tanto del diseño como de la maestra.

**¿Puede una presentación contener varias maestras de diapositivas?**

Sí. Una presentación puede contener varias maestras de diapositivas. Use varias maestras cuando diferentes secciones necesiten sistemas visuales o marcas distintas.

**¿Debo añadir marcadores de posición a una maestra de diapositivas o a una diapositiva de diseño?**

En la mayoría de los casos, añada marcadores de posición a las diapositivas de diseño. Coloque los elementos visuales compartidos y el formato común en la maestra, y los marcadores de posición de contenido en los diseños que usarán las diapositivas normales.

**¿Puedo eliminar una maestra de diapositivas que todavía se está usando?**

No. Una maestra que tiene diapositivas dependientes no puede eliminarse de forma segura directamente. Primero mueva esas diapositivas a diseños bajo otra maestra, o utilice un método de limpieza de maestras no usadas que elimine sólo las que no están en uso.