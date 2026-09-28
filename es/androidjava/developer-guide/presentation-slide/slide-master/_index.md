---
title: Gestionar maestros de diapositivas de presentación en Android
linktitle: Maestro de diapositiva
type: docs
weight: 70
url: /es/androidjava/slide-master/
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
- Android
- Java
- Aspose.Slides
description: "Gestionar maestros de diapositivas en Aspose.Slides para Android mediante Java: acceder, editar, clonar, comparar y eliminar diapositivas maestras en presentaciones de PowerPoint y OpenDocument."
---
## **Visión general**

Un **slide master** define los ajustes de diseño compartidos para un grupo de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, ajustes de tema y ajustes de pie de página. En PowerPoint, editar un slide master es la forma habitual de mantener una presentación coherente sin repetir el mismo formato en cada diapositiva.

Aspose.Slides for Android via Java admite el mismo modelo. Una presentación puede contener una o más master slides, y cada master slide puede contener varias layout slides. Normalmente, las diapositivas normales no hacen referencia directamente a un master slide. En su lugar, una diapositiva normal utiliza una layout slide, y esa layout slide pertenece a un master slide.

La jerarquía es:

1. **Slide master** - define el diseño y tema compartidos.  
1. **Layout slide** - define una disposición específica de marcadores de posición y formato a nivel de diseño.  
1. **Normal slide** - contiene el contenido real de la presentación y usa una layout slide.

![La jerarquía de master slides, layout slides y normal slides](slide-master_2.jpg)

En Aspose.Slides, un slide master está representado por la interfaz [IMasterSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterslide/) . Todos los master slides en una presentación están disponibles a través de la colección [Presentation.getMasters](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getMasters--) , que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterslidecollection/) . Para obtener la superficie completa de la API Android via Java, consulte la [com.aspose.slides API reference](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/) .

{{% alert color="info" title="Inheritance" %}}
Cuando la misma propiedad se define en más de un nivel, prevalece el nivel más específico. Por ejemplo, si un master slide y una layout slide ambos definen un fondo, las diapositivas basadas en esa layout usan el fondo de la layout. Para obtener más información sobre las layout slides, consulte [Aplicar o cambiar diseños de diapositivas](/slides/es/androidjava/slide-layout/) .
{{% /alert %}}

## **Acceso a los slide masters**

En PowerPoint, puede abrir la vista Slide Master desde **Vista** > **Slide Master**.

![El comando Slide Master en la pestaña Vista de PowerPoint](slide-master_3.jpg)

En Aspose.Slides, utilice la colección `getMasters()` para acceder a los master slides:

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

También puede obtener el master slide usado por una diapositiva normal a través de su layout:

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

## **Qué contiene un Slide Master**

Un master slide es un objeto similar a una diapositiva. Implementa [IBaseSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseslide/) , por lo que expone muchas de las mismas propiedades de diapositiva usadas por diapositivas normales y de layout.

| Miembro | Propósito |
| --- | --- |
| `getBackground()` | Establece el fondo de la diapositiva a nivel de master. |
| `getShapes()` | Almacena las formas colocadas en el master, como logotipos, marcos de imagen y texto compartido. |
| `getLayoutSlides()` | Almacena las layout slides que pertenecen al master. |
| `getThemeManager()` | Proporciona acceso a las API del tema del master. |
| `getHeaderFooterManager()` | Controla encabezados, pies de página, fechas y números de diapositiva para el master y sus diseños secundarios. |
| `getDependingSlides()` | Devuelve las diapositivas normales que dependen del master a través de sus layouts. |

## **Agregar una imagen a un Slide Master**

Cuando agrega una imagen a un master slide, aparece en las diapositivas que usan layouts de ese master. Es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales repetidos.

El siguiente ejemplo agrega un logotipo al primer master slide:

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

Para obtener más información sobre marcos de imagen, consulte [Marco de imagen](/slides/es/androidjava/picture-frame/) .

## **Controlar la visibilidad de los gráficos del Master**

Utilice [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) para ocultar los gráficos heredados del master, como logotipos o formas decorativas, sin eliminarlos del master. Pase `false` a [Slide.setShowMasterShapes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) en la diapositiva que debe omitir esos gráficos y mantenga `true` en las diapositivas que deben mostrarlos.

El siguiente ejemplo independiente crea una banda decorativa azul en un master y dos diapositivas que usan el mismo layout en blanco. La banda es visible en la primera diapositiva y está oculta en la segunda. No se requiere una presentación o imagen de entrada.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
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

El ejemplo utiliza el layout **Blank** suministrado con una nueva presentación y elimina los marcadores de posición propios de la diapositiva inicial.

### **Elija el alcance de la configuración**

Una diapositiva normal utiliza su master a través de [ISlide.getLayoutSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islide/#getLayoutSlide--) y [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--) . Establecer la propiedad en una diapositiva individual afecta solo a esa diapositiva. Pasar `false` a [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) oculta los gráficos del master para las diapositivas que usan ese layout compartido, incluso si su propia configuración es `true`. Para ocultar los gráficos en una única diapositiva, cambie la propiedad de la diapositiva y deje el layout compartido sin modificar.

La configuración no se admite como control de visibilidad en el propio master slide. En un master, [getShowMasterShapes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) siempre devuelve `false`, y pasar `true` a [setShowMasterShapes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) genera una excepción. Aplíquelo a una diapositiva normal o a un layout en su lugar.

### **Distinguir los gráficos del fondo**

| Operación | Efecto |
| --- | --- |
| Ocultar los gráficos del master | Controla la visibilidad de las formas heredadas del master sin eliminarlas ni cambiar las propias formas de la diapositiva. |
| Cambiar el relleno del fondo de la diapositiva | Cambia el color, degradado o imagen de fondo. Los gráficos del master son formas independientes y pueden permanecer visibles sobre ese fondo. Consulte [Presentation Background](/slides/es/androidjava/presentation-background/) . |
| Eliminar una forma del master | Elimina la forma fuente compartida, por lo que ya no está disponible para ninguna diapositiva que use ese master. |

## **Trabajar con marcadores de posición**

Los marcadores de posición se definen normalmente en las layout slides. El master slide proporciona el estilo y tema compartidos que esas layouts heredan, mientras que cada layout decide qué marcadores de posición están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcador de posición están disponibles en la vista Slide Master.

![El comando Insertar marcador de posición en la vista Slide Master de PowerPoint](slide-master_5.png)

Para agregar nuevos marcadores de posición con Aspose.Slides, trabaje con la layout slide que pertenece al master:

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

También puede formatear formas de marcador de posición que ya existen en un master slide. El siguiente ejemplo encuentra el marcador de posición de título y le aplica un relleno de degradado lineal:

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

Para obtener más opciones de formato de marcadores de posición y de texto, consulte [Establecer texto de sugerencia en marcador de posición](/slides/es/androidjava/manage-placeholder/) y [Formato de texto](/slides/es/androidjava/text-formatting/) .

## **Cambiar el fondo de un Slide Master**

Un fondo de master se hereda por los layouts y las diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para el primer master slide:

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

Para temas relacionados, consulte [Fondo de la presentación](/slides/es/androidjava/presentation-background/) y [Tema de la presentación](/slides/es/androidjava/presentation-theme/) .

## **Clonar un Slide Master a otra presentación**

Use [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) para copiar un master slide a otra presentación. El master copiado puede entonces ser usado por layouts y diapositivas en la presentación de destino.

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

Si necesita clonar diapositivas normales junto con su master, consulte [Clonar diapositivas](/slides/es/androidjava/clone-slides/) .

## **Agregar varios Slide Masters**

Una presentación puede contener varios master slides. Esto es útil cuando diferentes secciones requieren diferentes marcas, estructuras de página o ajustes de tema.

![Comandos de PowerPoint para insertar y gestionar master slides](slide-master_9.jpg)

El siguiente ejemplo clona el master predeterminado, le da al clon un fondo diferente, crea un layout bajo ese master clonado y agrega una nueva diapositiva basada en ese layout:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

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

Los master slides pueden compararse con el método `equals` heredado de [IBaseSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseslide/) . La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otros ajustes de diapositiva. No compara identificadores únicos, como IDs de diapositiva, ni valores dinámicos de marcadores de posición, como la fecha actual.

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

Para obtener más información, consulte [Comparar diapositivas de presentación](/slides/es/androidjava/compare-slides/) .

## **Establecer la vista Slide Master como vista predeterminada**

Use el método `setLastView` en [ViewProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/viewproperties/) para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en vista Slide Master:

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

Para más ajustes de vista, consulte [Guardar presentación](/slides/es/androidjava/save-presentation/) .

## **Eliminar master slides no utilizados**

Las presentaciones a veces contienen master slides que ya no son usados por ninguna diapositiva normal. Eliminar masters no utilizados puede reducir el tamaño del archivo y simplificar el mantenimiento de plantillas.

Use `removeUnused` para eliminar masters no utilizados de la colección `getMasters()` :

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

También puede usar el método de bajo código [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

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

**¿Cuál es la diferencia entre un slide master y una layout slide?**

Un slide master define ajustes de diseño compartidos como tema, fondo, formas comunes y estilos de texto. Una layout slide pertenece a un slide master y define una disposición específica de marcadores de posición. Una diapositiva normal usa una layout slide, por lo que hereda tanto de la layout como del master.

**¿Puede una presentación contener varios slide masters?**

Sí. Una presentación puede contener varios slide masters. Use varios masters cuando diferentes secciones necesiten sistemas visuales o marcas diferentes.

**¿Debo agregar marcadores de posición a un master slide o a una layout slide?**

En la mayoría de los casos, agregue marcadores de posición a las layout slides. Coloque elementos visuales compartidos y formato compartido en el master slide, y luego coloque los marcadores de posición de contenido en los layouts que usarán las diapositivas normales.

**¿Puedo eliminar un master slide que aún se está usando?**

No. Un master slide que tiene diapositivas dependientes no puede eliminarse de forma segura directamente. Primero mueva esas diapositivas a layouts bajo otro master, o use un método de limpieza de masters no usados que elimine solo los masters que no están en uso.