---
title: Convertir diapositivas de presentaciones a imágenes en JavaScript
linktitle: Diapositiva a imagen
type: docs
weight: 35
url: /es/nodejs-java/convert-slide/
keywords:
- convertir diapositiva
- exportar diapositiva
- diapositiva a imagen
- guardar diapositiva como imagen
- diapositiva a EMF
- diapositiva a PNG
- diapositiva a JPEG
- diapositiva a bitmap
- diapositiva a TIFF
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Convierte diapositivas de presentaciones PPT, PPTX y ODP a PNG, JPEG, GIF, TIFF, EMF y otros formatos de imagen en JavaScript con Aspose.Slides."
---
## **Introducción**

Aspose.Slides para Node.js a través de Java puede renderizar diapositivas individuales de presentaciones PowerPoint y OpenDocument como PNG, JPEG, GIF, TIFF y otros formatos de imagen.

Para convertir una diapositiva en una imagen, siga estos pasos:

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Seleccione la diapositiva que desea renderizar.
3. Si es necesario, configure la renderización con la clase [RenderingOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/renderingoptions/) o [TiffOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tiffoptions/).
4. Llame al método [Slide.getImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/#getImage). Devuelve un objeto [IImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/).
5. Llame al método [IImage.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/#save). y especifique el formato de salida con un valor [ImageFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imageformat/).

## **Convertir una diapositiva a una imagen PNG**

La conversión más simple utiliza la configuración de renderizado predeterminada. El objeto [IImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/) resultante puede procesarse en memoria o guardarse en un archivo.

El siguiente ejemplo en JavaScript renderiza la primera diapositiva y la guarda como una imagen PNG:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Convertir diapositivas a imágenes con tamaños personalizados**

Utilice la sobrecarga [Slide.getImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/#getImage) que acepta un valor `java.awt.Dimension` para renderizar una diapositiva con dimensiones de píxeles exactas.

El siguiente ejemplo crea una imagen JPEG de 1820 × 1040:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Convertir diapositivas con notas y comentarios a imágenes**

Por defecto, las imágenes de diapositivas no incluyen notas ni comentarios. Pase un objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notescommentslayoutingoptions/) al método [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) para controlar dónde aparecen las notas y los comentarios.

El siguiente ejemplo coloca notas truncadas debajo de la diapositiva y comentarios a su derecha:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Para la conversión de diapositiva a imagen, no pase [BottomFull](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notespositions/) al método [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Las notas pueden contener más texto del que el tamaño fijo de la imagen puede albergar. Use [BottomTruncated](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notespositions/) en su lugar.
{{% /alert %}}

## **Convertir diapositivas a imágenes usando opciones TIFF**

La clase [TiffOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tiffoptions/) le permite controlar el tamaño, la resolución y otras propiedades de la imagen TIFF renderizada.

El siguiente ejemplo renderiza la primera diapositiva como una imagen TIFF de 2160 × 2880 a 300 DPI:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
El soporte de TIFF no está garantizado en versiones de Java anteriores a JDK 9.
{{% /alert %}}

## **Convertir todas las diapositivas a imágenes**

Itere a través de la colección de diapositivas para convertir toda la presentación en una serie de imágenes. Las diapositivas ocultas se incluyen a menos que las omita explícitamente.

El siguiente ejemplo renderiza cada diapositiva como una imagen JPEG con factores de escala horizontal y vertical de 2:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Crear salida Metarchivo mejorado**

El Metarchivo Mejorado (EMF) es útil cuando se deben intercambiar gráficos vectoriales con Microsoft Office u otras aplicaciones de Windows que soportan metafiles de Windows. A diferencia de una imagen basada en píxeles, un EMF puede conservar operaciones de dibujo vectorial que escalan sin la misma pérdida de nitidez. Sin embargo, EMF es principalmente un formato de compatibilidad para aplicaciones con soporte de metafiles de Windows, no un formato de intercambio universal. Además, el contenido complejo de una diapositiva, como imágenes de mapa de bits y algunos efectos, puede almacenarse como elementos rasterizados dentro del contenedor del metarchivo vectorial.

### **Exportar una diapositiva a EMF**

El método [Slide.writeAsEmf](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/#writeAsEmf) escribe una diapositiva en un flujo de destino en formato EMF. El siguiente ejemplo carga una presentación, selecciona la primera diapositiva y la escribe en un flujo de archivo EMF:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

El llamador posee el flujo pasado a [Slide.writeAsEmf](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/#writeAsEmf) y es responsable de cerrarlo, como se muestra arriba.

### **Convertir una imagen SVG a EMF y añadirla a una presentación**

Utilice [SvgImage.writeAsEmf](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/svgimage/#writeAsEmf) para convertir contenido SVG a EMF. Los bytes resultantes pueden añadirse a la presentación mediante [ImageCollection.addImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagecollection/#addImage) y colocarse en una diapositiva con [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/#addPictureFrame).

El siguiente ejemplo crea un [SvgImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/svgimage/) a partir de marcado SVG, lo convierte a un EMF en memoria, inserta el metarchivo en la primera diapositiva y guarda la presentación:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/svgimage/#writeAsEmf) no asume la propiedad del flujo de destino. Un `java.io.ByteArrayOutputStream` almacena todos los datos generados en memoria, por lo que no es necesario restablecer la posición antes de llamar a `toByteArray`. El array de bytes devuelto sigue siendo válido después de cerrar el flujo.

La generación de EMF está disponible en los sistemas operativos compatibles con la configuración de Aspose.Slides for Node.js via Java y JDK seleccionada, pero la renderización puede variar entre plataformas cuando faltan fuentes o dependencias gráficas. Instale las fuentes utilizadas por el contenido de origen o configure sustituciones adecuadas, siga los [requisitos de plataforma](/slides/es/nodejs-java/system-requirements/) para Aspose.Slides for Node.js via Java y valide el resultado en la aplicación que consumirá el EMF. Las aplicaciones en Linux y macOS a menudo tienen un soporte limitado o inconsistente para visualizar y editar metafiles de Windows.

## **Renderizado de emojis en color**

{{% alert title="Note" color="info" %}}
Para renderizar correctamente emojis en color al convertir diapositivas de presentaciones a imágenes, las fuentes de emojis utilizadas en la presentación deben estar instaladas y disponibles en el sistema que realiza la conversión. Por ejemplo, si la presentación usa **Segoe UI Emoji** y esa fuente falta, los emojis pueden aparecer en monocromo en las imágenes de salida.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Aspose.Slides admite renderizar diapositivas con animaciones?**

No. El método [Slide.getImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/#getImage) renderiza una imagen estática de la diapositiva y no exporta animaciones.

**¿Se pueden exportar diapositivas ocultas como imágenes?**

Sí. Las diapositivas ocultas pueden renderizarse como diapositivas normales. Inclúyalas en el bucle de procesamiento, como se muestra en el ejemplo anterior.

**¿Se conservan las sombras y otros efectos en las imágenes de diapositivas?**

Sí. Aspose.Slides renderiza sombras, transparencias y otros efectos gráficos compatibles en las imágenes de diapositivas.