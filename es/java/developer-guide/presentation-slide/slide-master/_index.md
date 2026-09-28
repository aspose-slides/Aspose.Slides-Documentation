---
title: Gestionar los maestros de diapositivas de la presentación en Java
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
description: "Gestiona los maestros de diapositivas en Aspose.Slides para Java: accede, edita, clona, compara y elimina diapositivas maestras en presentaciones PowerPoint y OpenDocument."
---
## **Visión general**

Un **slide master** define configuraciones de diseño compartidas para un grupo de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, configuraciones de tema y configuraciones de pie de página. En PowerPoint, editar un slide master es la manera habitual de mantener una presentación coherente sin repetir el mismo formato en cada diapositiva.

Aspose.Slides for Java soporta el mismo modelo. Una presentación puede contener una o más diapositivas maestras, y cada diapositiva maestra puede contener varias diapositivas de diseño. Las diapositivas normales normalmente no hacen referencia directamente a una diapositiva maestra. En su lugar, una diapositiva normal utiliza una diapositiva de diseño, y esa diapositiva de diseño pertenece a una diapositiva maestra.

La jerarquía es:

1. **Slide master** – define el diseño y tema compartidos.  
1. **Layout slide** – define una disposición específica de marcadores de posición y formato a nivel de diseño.  
1. **Normal slide** – contiene el contenido real de la presentación y utiliza una diapositiva de diseño.

![La jerarquía de diapositivas maestras, diapositivas de diseño y diapositivas normales](slide-master_2.jpg)

En Aspose.Slides, un slide master está representado por la interfaz [IMasterSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslide/). Todas las diapositivas maestras de una presentación están disponibles a través de la colección [Presentation.getMasters](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getMasters--) , que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Cuando la misma propiedad se define en más de un nivel, gana el nivel más específico. Por ejemplo, si una diapositiva maestra y una diapositiva de diseño definen un fondo, las diapositivas basadas en ese diseño usan el fondo del diseño. Para obtener más información sobre las diapositivas de diseño, consulte [Apply or Change Slide Layouts](/slides/es/java/slide-layout/).
{{% /alert %}}

## **Acceder a los maestros de diapositivas**

En PowerPoint, puedes abrir la vista de **Slide Master** desde **View** > **Slide Master**.

![El comando Slide Master en la pestaña Vista de PowerPoint](slide-master_3.jpg)

En Aspose.Slides, use la colección `getMasters()` para acceder a las diapositivas maestras:

```java
import com.aspose.slides.*;

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

También puede obtener la diapositiva maestra utilizada por una diapositiva normal a través de su diseño:

```java
import com.aspose.slides.*;

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

## **Qué contiene un maestro de diapositivas**

Una diapositiva maestra es un objeto similar a una diapositiva. Implementa [IBaseSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibaseslide/), por lo que expone muchas de las mismas propiedades de diapositiva que utilizan las diapositivas normales y de diseño. Los miembros específicos del maestro se enumeran en la página de la API [IMasterSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslide/).

Los miembros de diapositiva maestra más usados incluyen:

| Miembro | Propósito |
| --- | --- |
| `getBackground()` | Establece el fondo de la diapositiva a nivel de maestro. |
| `getShapes()` | Almacena las formas colocadas en el maestro, como logotipos, marcos de imágenes y texto compartido. |
| `getLayoutSlides()` | Almacena las diapositivas de diseño que pertenecen al maestro. |
| `getThemeManager()` | Proporciona acceso a las API de tema del maestro. |
| `getHeaderFooterManager()` | Controla encabezados, pies de página, fechas y números de diapositiva para el maestro y sus diseños secundarios. |
| `getDependingSlides()` | Devuelve las diapositivas normales que dependen del maestro a través de sus diseños. |

## **Añadir una imagen a un maestro de diapositivas**

Cuando añades una imagen a una diapositiva maestra, aparece en las diapositivas que usan diseños de ese maestro. Esto es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales repetidos.

El siguiente ejemplo añade un logotipo a la primera diapositiva maestra:

```java
import com.aspose.slides.*;

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

Para obtener más información sobre los marcos de imágenes, consulte [Picture Frame](/slides/es/java/picture-frame/).

## **Controlar la visibilidad de los gráficos del maestro**

Utilice [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) para ocultar los gráficos heredados del maestro, como logotipos o formas decorativas, sin eliminarlos del maestro. Pase `false` a [Slide.setShowMasterShapes](https://reference.aspose.com/slides/es/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) en la diapositiva que debe omitir esos gráficos y manténgalo `true` en las diapositivas que deben mostrarlos.

El siguiente ejemplo independiente crea una banda decorativa azul en un maestro y dos diapositivas que utilizan el mismo diseño en blanco. La banda es visible en la primera diapositiva y está oculta en la segunda. No se requiere presentación de entrada ni imagen.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El ejemplo usa el diseño **Blank** suministrado con una nueva presentación y elimina los marcadores de posición propios de la diapositiva inicial.

### **Elegir el alcance de la configuración**

Una diapositiva normal utiliza su maestro a través de [ISlide.getLayoutSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/islide/#getLayoutSlide--) y [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutslide/#getMasterSlide--). Configurar la propiedad en una diapositiva individual afecta solo a esa diapositiva. Pasar `false` a [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/es/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) oculta los gráficos del maestro para las diapositivas que usan ese diseño compartido, incluso si su propia configuración es `true`. Para ocultar los gráficos en una única diapositiva, cambie la propiedad de la diapositiva y deje el diseño compartido sin modificar.

La configuración no se admite como control de visibilidad en la propia diapositiva maestra. En un maestro, [getShowMasterShapes](https://reference.aspose.com/slides/es/java/com.aspose.slides/masterslide/#getShowMasterShapes--) siempre devuelve `false`, y pasar `true` a [setShowMasterShapes](https://reference.aspose.com/slides/es/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) genera una excepción. Aplíquelo a una diapositiva normal o a un diseño.

### **Distinguir los gráficos del fondo**

| Operación | Efecto |
| --- | --- |
| Ocultar gráficos del maestro | Controla la visibilidad de las formas heredadas del maestro sin eliminarlas ni cambiar las propias formas de la diapositiva. |
| Cambiar el relleno del fondo de la diapositiva | Cambia el color, degradado o imagen de fondo. Los gráficos del maestro son formas separadas y pueden seguir visibles sobre ese fondo. Consulte [Presentation Background](/slides/es/java/presentation-background/). |
| Eliminar una forma del maestro | Elimina la forma fuente compartida, de modo que ya no está disponible para ninguna diapositiva que use ese maestro. |

## **Trabajar con marcadores de posición**

Los marcadores de posición se definen normalmente en las diapositivas de diseño. La diapositiva maestra proporciona el estilo y tema compartidos que esos diseños heredan, mientras que cada diseño decide cuáles marcadores de posición están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcadores de posición están disponibles en la vista Slide Master.

![El comando Insertar marcador de posición en la vista Maestro de diapositivas de PowerPoint](slide-master_5.png)

Para añadir nuevos marcadores de posición con Aspose.Slides, trabaje con la diapositiva de diseño que pertenece al maestro:

```java
import com.aspose.slides.*;

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

También puede dar formato a las formas de marcador de posición que ya existen en una diapositiva maestra. El siguiente ejemplo busca el marcador de posición de título y le aplica un relleno de degradado lineal:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Marcador de posición de título formateado heredado por diapositivas normales](slide-master_8.png)

Para más opciones de formato de marcadores de posición y texto, consulte [Set Prompt Text in Placeholder](/slides/es/java/manage-placeholder/) y [Text Formatting](/slides/es/java/text-formatting/).

## **Cambiar el fondo de un maestro de diapositivas**

Un fondo de maestro se hereda por los diseños y diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para la primera diapositiva maestra:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Clonar un maestro de diapositivas a otra presentación**

Utilice [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) para copiar una diapositiva maestra a otra presentación. El maestro copiado puede entonces ser usado por diseños y diapositivas en la presentación de destino.

```java
import com.aspose.slides.*;

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

Si necesita clonar diapositivas normales junto con su maestro, consulte [Clone Slides](/slides/es/java/clone-slides/).

## **Añadir varios maestros de diapositivas**

Una presentación puede contener varios maestros de diapositivas. Esto es útil cuando diferentes secciones requieren distintas marcas, estructuras de página o configuraciones de tema.

![Comandos de PowerPoint para insertar y gestionar maestros de diapositivas](slide-master_9.jpg)

El siguiente ejemplo clona el maestro predeterminado, le asigna un fondo diferente, crea un diseño bajo ese maestro clonado y añade una nueva diapositiva basada en ese diseño:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Comparar maestros de diapositivas**

Los maestros de diapositivas pueden compararse con el método `equals` heredado de [IBaseSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibaseslide/). La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otras configuraciones de la diapositiva. No compara identificadores únicos, como IDs de diapositiva, ni valores dinámicos de marcadores de posición, como la fecha actual.

```java
import com.aspose.slides.*;

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

Para más información, consulte [Compare Presentation Slides](/slides/es/java/compare-slides/).

## **Establecer la vista Maestro de diapositivas como vista predeterminada**

Utilice el método `setLastView` en [ViewProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/viewproperties/) para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en la vista Maestro de diapositivas:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para más configuraciones de vista, consulte [Save Presentation](/slides/es/java/save-presentation/).

## **Eliminar maestros de diapositivas no utilizados**

A veces las presentaciones contienen maestros de diapositivas que ya no son usados por ninguna diapositiva normal. Eliminar los maestros no usados puede reducir el tamaño del archivo y simplificar el mantenimiento de la plantilla.

Use `removeUnused` para eliminar los maestros no usados de la colección `getMasters()`:

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**¿Cuál es la diferencia entre un maestro de diapositivas y una diapositiva de diseño?**

Un maestro de diapositivas define configuraciones de diseño compartidas como tema, fondo, formas comunes y estilos de texto. Una diapositiva de diseño pertenece a un maestro de diapositivas y define una disposición específica de marcadores de posición. Una diapositiva normal utiliza una diapositiva de diseño, por lo que hereda tanto del diseño como del maestro.

**¿Puede una presentación contener varios maestros de diapositivas?**

Sí. Una presentación puede contener varios maestros de diapositivas. Use varios maestros cuando diferentes secciones necesiten distintos sistemas visuales o marcas.

**¿Debo añadir marcadores de posición a un maestro de diapositivas o a una diapositiva de diseño?**

En la mayoría de los casos, añada marcadores de posición a las diapositivas de diseño. Coloque los elementos visuales y formatos compartidos en el maestro de diapositivas y los marcadores de posición de contenido en los diseños que usarán las diapositivas normales.

**¿Puedo eliminar un maestro de diapositivas que todavía se está usando?**

No. Un maestro de diapositivas que tiene diapositivas dependientes no puede eliminarse de forma segura directamente. Primero mueva esas diapositivas a diseños bajo otro maestro, o utilice un método de limpieza de maestros no usados que elimine solo los maestros que no están en uso.