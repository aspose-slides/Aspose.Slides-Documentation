---
title: Gestionar marcadores de posición de presentación en JavaScript
linktitle: Gestionar marcadores
type: docs
weight: 10
url: /es/nodejs-java/manage-placeholder/
keywords:
- marcador
- marcador de texto
- marcador de imagen
- marcador de gráfico
- marcador de contenido
- texto de sugerencia
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a inspeccionar y editar marcadores de texto, imagen, gráfico y contenido, y a comprender la herencia de marcadores de posición con Aspose.Slides para Node.js mediante Java."
---
## **Visión general**

Un marcador de posición es una forma que reserva una posición para un tipo particular de contenido en una plantilla de presentación. Los ejemplos más comunes son marcadores de título, cuerpo, imagen, gráfico y marcadores de contenido de uso general. A diferencia de una forma ordinaria, un marcador de posición puede heredar su posición, tamaño, formato y otras configuraciones de una diapositiva de diseño o de la diapositiva maestra.

Aspose.Slides expone la información de los marcadores de posición a través del método [Shape.getPlaceholder](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getPlaceholder). El método devuelve un objeto [Placeholder](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/placeholder/) o `null` para una forma normal. Utilice [Placeholder.getType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/placeholder/#getType) para determinar qué se pretende que contenga el marcador de posición.

La clase de la forma sigue siendo importante después de conocer el tipo de marcador de posición:

- Un marcador de posición vacío de texto, imagen, gráfico o contenido suele representarse mediante un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/).
- Un marcador de posición de imagen rellenado puede representarse mediante un [PictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/).
- Un marcador de posición de gráfico rellenado puede representarse mediante un [Chart](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/).
- Un marcador de posición de contenido puede contener varios tipos de contenido. Verifique tanto [Placeholder.getType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/placeholder/#getType) como la clase de forma en tiempo de ejecución en lugar de asumir que cada marcador de posición es un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/placeholder/#getType) describe el rol de un marcador de posición; no garantiza el tipo de forma en tiempo de ejecución. Siempre utilice una verificación de tipo antes de acceder a miembros específicos de texto, imagen, gráfico, tabla o medios.
{{% /alert %}}

## **Comprender la herencia de marcadores de posición**

Los marcadores de posición forman una jerarquía:

1. Una diapositiva maestra define estilos reutilizables y, en algunos casos, marcadores de posición a nivel maestro.
2. Una diapositiva de diseño define la disposición utilizada por una o más diapositivas normales y puede heredar de la maestra.
3. Una diapositiva normal contiene los marcadores de posición de esa diapositiva y puede heredar de su diseño.

Llame a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getBasePlaceholder) para subir un nivel en esta jerarquía. Un marcador de posición de diapositiva normalmente devuelve su marcador de posición de diseño; un marcador de posición de diseño puede devolver su marcador de posición maestro. El método devuelve `null` cuando la forma no tiene un marcador de posición base.

El siguiente ejemplo enumera los marcadores de posición en la primera diapositiva y muestra sus marcadores de posición base:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Editar un marcador de posición en una diapositiva normal crea o modifica una anulación local para esa diapositiva. Editar el diseño o la maestra relacionada puede afectar a todas las diapositivas que aún hereden esa configuración. Una forma ordinaria local no tiene marcador de posición base y no comienza a heredar simplemente porque ocupa las mismas coordenadas.

## **Cambiar texto en un marcador de posición**

Los marcadores de posición de título, título centrado, subtítulo, cuerpo y texto suelen admitir texto. Verifique si es un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) antes de usar su método [getTextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/#getTextFrame).

Este ejemplo actualiza el primer marcador de posición de título en la primera diapositiva y guarda el resultado:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Este patrón evita tratar los marcadores de posición de imagen, gráfico, tabla o medios como objetos [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/). También identifica el marcador de posición por su propósito en lugar de depender de un índice de forma frágil.

## **Establecer texto de sugerencia en un diseño**

El texto de sugerencia es la instrucción en tiempo de diseño que se muestra en un marcador de posición vacío, como *Haga clic para agregar un título*. Establezca un texto de sugerencia personalizado en el marcador de posición del diseño en lugar de intentar alcanzarlo a través de la colección de formas de una diapositiva normal. Acceda al diseño mediante [Slide.getLayoutSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/#getLayoutSlide) y recorra la colección devuelta por [BaseSlide.getShapes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslide/#getShapes).

El siguiente ejemplo cambia las sugerencias de título y subtítulo en el diseño utilizado por la primera diapositiva:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El texto de sugerencia no es contenido normal de la diapositiva. Está destinado a marcadores de posición vacíos en aplicaciones de edición como PowerPoint. Una vez que un usuario o programa proporciona contenido real, la sugerencia ya no se muestra. Cambiar una sugerencia tampoco sustituye el texto existente en las diapositivas que usan el diseño.

## **Actualizar un marcador de posición de imagen**

Hay dos casos a manejar:

- Si el marcador de posición de imagen ya está rellenado y representado por un [PictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/), reemplace la imagen mediante [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/#getPicture) y [Picture.setImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picture/#setImage).
- Si sigue siendo un marcador de posición vacío, añada un marco de imagen en las coordenadas del marcador de posición con [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) y elimine el marcador de posición vacío.

El siguiente ejemplo admite ambos casos y guarda la presentación:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El reemplazo creado para un marcador de posición vacío es un marco de imagen local, no un nuevo marcador de posición, porque [Shape.getPlaceholder](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getPlaceholder) no ofrece un setter. Conserva la posición reservada pero ya no hereda el comportamiento específico del marcador de posición. Si es esencial mantener la relación del marcador de posición, prepare y rellene el marcador de posición en PowerPoint primero, y luego actualice el [PictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) resultante con Aspose.Slides.

Para la transparencia de imágenes, recorte y otros efectos específicos de imágenes, consulte [Manage Picture Frames](/slides/es/nodejs-java/picture-frame/). esas operaciones pertenecen al marco de imagen o al relleno de imagen, no a los metadatos del marcador de posición.

## **Trabajar con marcadores de posición de gráfico y contenido**

Un marcador de posición de gráfico rellenado puede representarse mediante un [Chart](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/). Este ejemplo encuentra dicho gráfico tanto por tipo de marcador de posición como por clase en tiempo de ejecución, cambia su título y guarda el archivo:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Un marcador de posición de contenido general suele tener [PlaceholderType.Object](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/placeholdertype/#Object). En PowerPoint actúa como lanzador de varios tipos de contenido, incluidos gráficos, tablas, diagramas, imágenes y medios. Después de haber sido rellenado, inspeccione la clase de forma real para saber qué contiene. Los diseños especializados también pueden exponer [PlaceholderType.Chart](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/placeholdertype/#Media) o [PlaceholderType.Diagram](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides no convierte un marcador de posición vacío [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) en un [Chart](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/) simplemente cambiando [Placeholder.getType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/placeholder/#getType); el tipo no puede modificarse a través del objeto. Para rellenar programáticamente un área de gráfico o contenido vacío, añada el objeto requerido en las coordenadas del marcador de posición y luego elimine el marcador de posición vacío. El siguiente ejemplo hace eso para un gráfico:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El gráfico añadido es un gráfico local ordinario. Ocupa el área del marcador de posición pero no hereda del marcador de posición del diseño. Utilice los artículos dedicados a la gestión de gráficos [chart management articles](/slides/es/nodejs-java/powerpoint-charts/) cuando necesite sustituir sus categorías, series o datos de libro de trabajo.

## **Ejemplo completo: actualizar contenido de texto o imagen**

El siguiente ejemplo de extremo a extremo abre una plantilla, busca en la primera diapositiva un marcador de posición de título o de imagen, verifica los tipos de marcador de posición y forma, actualiza el contenido apropiado y guarda la salida. El ejemplo evita deliberadamente asumir un índice de forma o tratar cada marcador de posición como la misma clase.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Qué es un marcador de posición base?**

Un marcador de posición base es la forma correspondiente en el diseño o la maestra de la que hereda otro marcador de posición. Use [Shape.getBasePlaceholder](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getBasePlaceholder) para recuperarlo. Una forma local ordinaria devuelve `null` porque no forma parte de la jerarquía de marcadores de posición.

**¿Puedo cambiar todos los títulos de las diapositivas editando un marcador de posición de diseño?**

Puede cambiar el formato heredado o el texto de sugerencia mediante un diseño, pero el contenido del título existente se almacena en las diapositivas normales. Para reemplazar el texto real del título en toda la presentación, recorra las diapositivas y actualice cada marcador de posición de título.

**¿Cómo gestiono los marcadores de posición de fecha, número de diapositiva, encabezado y pie de página?**

Utilice los administradores de encabezado y pie de página en la diapositiva, diseño, maestra, notas o alcance de folletos correspondiente. Consulte [Manage Presentation Header and Footer](/slides/es/nodejs-java/presentation-header-and-footer/) para ejemplos completos.