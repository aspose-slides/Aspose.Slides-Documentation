---
title: Gestionar marcadores de posición de presentación en Java
linktitle: Gestionar marcadores
type: docs
weight: 10
url: /es/java/manage-placeholder/
keywords:
- marcador de posición
- marcador de posición de texto
- marcador de posición de imagen
- marcador de posición de gráfico
- marcador de posición de contenido
- texto de sugerencia
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda a inspeccionar y editar marcadores de posición de texto, imagen, gráfico y contenido, y a comprender la herencia de marcadores de posición con Aspose.Slides para Java."
---
## **Descripción general**

Un marcador de posición es una forma que reserva una posición para un tipo particular de contenido en una plantilla de presentación. Los ejemplos más habituales son los marcadores de título, cuerpo, imagen, gráfico y de contenido de uso general. A diferencia de una forma ordinaria, un marcador de posición puede heredar su posición, tamaño, formato y otros ajustes de una diapositiva de diseño o de una diapositiva maestra.

Aspose.Slides expone la información de los marcadores de posición a través del método [IShape.getPlaceholder](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/). El método devuelve un objeto [IPlaceholder](https://reference.aspose.com/slides/es/java/com.aspose.slides/placeholder/) o `null` para una forma normal. Utilice [IPlaceholder.getType](https://reference.aspose.com/slides/es/java/com.aspose.slides/placeholder/) para determinar qué se pretende que contenga el marcador de posición.

La interfaz de la forma sigue siendo importante después de conocer el tipo de marcador de posición:

- Un marcador de posición vacío de texto, imagen, gráfico o contenido se representa normalmente mediante un [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/).
- Un marcador de posición de imagen ya poblado puede representarse mediante un [IPictureFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipictureframe/).
- Un marcador de posición de gráfico ya poblado puede representarse mediante un [IChart](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichart/).
- Un marcador de posición de contenido puede contener varios tipos de contenido. Verifique tanto [IPlaceholder.getType](https://reference.aspose.com/slides/es/java/com.aspose.slides/placeholder/) como la interfaz de forma en tiempo de ejecución en lugar de asumir que cada marcador de posición es un [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/es/java/com.aspose.slides/placeholder/) describe el papel de un marcador de posición; no garantiza el tipo de forma en tiempo de ejecución. Siempre realice una comprobación de tipo antes de acceder a miembros específicos de texto, imagen, gráfico, tabla o multimedia.
{{% /alert %}}

## **Comprender la herencia de marcadores de posición**

Los marcadores de posición forman una jerarquía:

1. Una diapositiva maestra define estilos reutilizables y, en algunos casos, marcadores de posición a nivel de maestra.
2. Una diapositiva de diseño define la disposición utilizada por una o más diapositivas normales y puede heredar de la maestra.
3. Una diapositiva normal contiene los marcadores de posición para esa diapositiva y puede heredar de su diseño.

Llame a [IShape.getBasePlaceholder](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/) para subir un nivel en esta jerarquía. Un marcador de posición de diapositiva normalmente devuelve su marcador de posición de diseño; un marcador de posición de diseño puede devolver su marcador de posición de maestra. El método devuelve `null` cuando la forma no tiene marcador de posición base.

El siguiente ejemplo enumera los marcadores de posición en la primera diapositiva e informa de sus marcadores de posición base:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Editar un marcador de posición en una diapositiva normal crea o modifica una anulación local para esa diapositiva. Editar el diseño o la maestra relacionados puede afectar a todas las diapositivas que aún hereden esa configuración. Una forma ordinaria local no tiene marcador de posición base y no comienza a heredar solo porque ocupe las mismas coordenadas.

## **Cambiar texto en un marcador de posición**

Los marcadores de posición de título, título centrado, subtítulo, cuerpo y texto suelen admitir texto. Verifique que sea un [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/) antes de usar su método [getTextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/).

Este ejemplo actualiza el primer marcador de posición de título en la primera diapositiva y guarda el resultado:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Este patrón evita convertir en [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/) los marcadores de posición de imagen, gráfico, tabla o multimedia. También identifica el marcador de posición por su propósito en lugar de depender de un índice de forma frágil.

## **Establecer texto de sugerencia en un diseño**

El texto de sugerencia es la indicación en tiempo de diseño que se muestra en un marcador de posición vacío, como *Haga clic para añadir título*. Defina texto de sugerencia personalizado en el marcador de posición del diseño en lugar de intentar obtenerlo a través de la colección de formas de una diapositiva normal. Acceda al diseño mediante [ISlide.getLayoutSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/islide/) y recorra la colección devuelta por [ILayoutSlide.getShapes](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibaseslide/).

El siguiente ejemplo cambia los textos de sugerencia de título y subtítulo en el diseño utilizado por la primera diapositiva:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El texto de sugerencia no es contenido de diapositiva normal. Está destinado a marcadores de posición vacíos en aplicaciones de edición como PowerPoint. Una vez que el usuario o el programa suministra contenido real, la sugerencia deja de mostrarse. Cambiar una sugerencia tampoco sustituye el texto existente en las diapositivas que usan el diseño.

## **Actualizar un marcador de posición de imagen**

Hay dos casos a tratar:

- Si el marcador de posición de imagen ya está poblado y se representa mediante un [IPictureFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipictureframe/), reemplace la imagen mediante [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipicturefillformat/) y [ISlidesPicture.setImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/islidespicture/).
- Si sigue siendo un marcador de posición vacío, añada un marco de imagen en las coordenadas del marcador de posición con [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/) y elimine el marcador de posición vacío.

El siguiente ejemplo admite ambos casos y guarda la presentación:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El reemplazo creado para un marcador de posición vacío es un marco de imagen local, no un nuevo marcador de posición, porque [IShape.getPlaceholder](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/) no dispone de un setter. Conserva la posición reservada pero ya no hereda el comportamiento específico del marcador de posición. Si es esencial mantener la relación de marcador de posición, prepare y rellene el marcador de posición en PowerPoint primero y, a continuación, actualice el [IPictureFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipictureframe/) resultante con Aspose.Slides.

Para transparencia de imagen, recorte y otros efectos específicos de imagen, consulte [Manage Picture Frames](/slides/es/java/picture-frame/). esas operaciones pertenecen al marco de imagen o al relleno de imagen, no a los metadatos del marcador de posición.

## **Trabajar con marcadores de posición de gráfico y contenido**

Un marcador de posición de gráfico ya poblado puede representarse mediante un [IChart](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichart/). Este ejemplo encuentra dicho gráfico tanto por tipo de marcador de posición como por interfaz en tiempo de ejecución, cambia su título y guarda el archivo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Un marcador de posición de contenido general suele tener [PlaceholderType.Object](https://reference.aspose.com/slides/es/java/com.aspose.slides/placeholdertype/). En PowerPoint actúa como lanzador para varios tipos de contenido, incluidos gráficos, tablas, diagramas, imágenes y multimedia. Después de estar poblado, inspeccione la interfaz de forma real para conocer su contenido. Los diseños especializados también pueden exponer [PlaceholderType.Chart](https://reference.aspose.com/slides/es/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/es/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/es/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/es/java/com.aspose.slides/placeholdertype/), o [PlaceholderType.Diagram](https://reference.aspose.com/slides/es/java/com.aspose.slides/placeholdertype/).

Aspose.Slides no convierte un marcador de posición vacío de [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/) en un [IChart](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichart/) simplemente cambiando [IPlaceholder.getType](https://reference.aspose.com/slides/es/java/com.aspose.slides/placeholder/); el tipo no puede modificarse mediante la interfaz. Para rellenar programáticamente un área de gráfico o contenido vacía, añada el objeto necesario en las coordenadas del marcador de posición y luego elimine el marcador de posición vacío. El siguiente ejemplo lo hace para un gráfico:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El gráfico añadido es un gráfico local ordinario. Ocupa el área del marcador de posición pero no hereda del marcador de posición de diseño. Utilice los artículos dedicados a la gestión de gráficos [/slides/es/java/powerpoint-charts/] cuando necesite reemplazar sus categorías, series o datos del libro de trabajo.

## **Ejemplo completo: actualizar contenido de texto o imagen**

El siguiente ejemplo de extremo a extremo abre una plantilla, busca en la primera diapositiva un marcador de posición de título o de imagen, verifica los tipos de marcador de posición y de forma, actualiza el contenido apropiado y guarda el resultado. El ejemplo evita deliberadamente asumir un índice de forma o convertir todos los marcadores de posición a la misma interfaz.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Qué es un marcador de posición base?**

Un marcador de posición base es la forma correspondiente en el diseño o la maestra de la que otro marcador de posición hereda. Utilice [IShape.getBasePlaceholder](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/) para recuperarlo. Una forma local ordinaria devuelve `null` porque no forma parte de la jerarquía de marcadores de posición.

**¿Puedo cambiar todos los títulos de diapositiva editando un marcador de posición de diseño?**

Puede modificar el formato heredado o el texto de sugerencia mediante un diseño, pero el contenido real de los títulos está almacenado en las diapositivas normales. Para reemplazar el texto real de los títulos en toda la presentación, recorra las diapositivas y actualice cada marcador de posición de título.

**¿Cómo gestiono los marcadores de posición de fecha, número de diapositiva, encabezado y pie de página?**

Utilice los gestores de encabezado y pie de página en el alcance apropiado (diapositiva, diseño, maestra, notas o folletos). Consulte [Manage Presentation Header and Footer](/slides/es/java/presentation-header-and-footer/) para ejemplos completos.