---
title: Convertir diapositivas de presentación a imágenes en Java
linktitle: Diapositiva a Imagen
type: docs
weight: 35
url: /es/java/convert-slide/
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
- Java
- Aspose.Slides
description: "Convertir diapositivas de presentaciones PPT, PPTX y ODP a PNG, JPEG, GIF, TIFF, EMF y otros formatos de imagen en Java con Aspose.Slides."
---
## **Introducción**

Aspose.Slides for Java puede renderizar diapositivas individuales de presentaciones PowerPoint y OpenDocument como PNG, JPEG, GIF, TIFF y otros formatos de imagen.

Para convertir una diapositiva en una imagen, siga estos pasos:

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/).
2. Seleccione la diapositiva que desea renderizar.
3. Si es necesario, configure la renderización con la clase [RenderingOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/renderingoptions/) o [TiffOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/tiffoptions/).
4. Llame al método [ISlide.getImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/islide/#getImage--) . Devuelve un objeto [IImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/).
5. Llame al método [IImage.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/#save-java.lang.String-int-) y especifique el formato de salida con un valor [ImageFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/imageformat/).

## **Convertir una diapositiva a una imagen PNG**

La conversión más simple utiliza la configuración de renderizado predeterminada. El objeto [IImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/) resultante puede procesarse en memoria o guardarse en un archivo.

El siguiente ejemplo en Java renderiza la primera diapositiva y la guarda como una imagen PNG:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Convertir diapositivas a imágenes con tamaños personalizados**

Utilice la sobrecarga [ISlide.getImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) que acepta un valor [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) para renderizar una diapositiva con dimensiones de píxeles exactas.

El siguiente ejemplo crea una imagen JPEG de 1820 × 1040:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import java.awt.Dimension;

Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Convertir diapositivas con notas y comentarios a imágenes**

Por defecto, las imágenes de las diapositivas no incluyen notas ni comentarios. Pase un objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/notescommentslayoutingoptions/) al método [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) para controlar dónde aparecen las notas y los comentarios.

El siguiente ejemplo coloca notas truncadas debajo de la diapositiva y comentarios a su derecha:

```java
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import java.awt.Color;

float scaleX = 2f;
float scaleY = scaleX;

Color commentsAreaColor = new Color(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Para la conversión de diapositiva a imagen, no pase [BottomFull](https://reference.aspose.com/slides/es/java/com.aspose.slides/notespositions/) al método [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/es/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-). Las notas pueden contener más texto del que el tamaño de imagen fijo puede albergar. Utilice [BottomTruncated](https://reference.aspose.com/slides/es/java/com.aspose.slides/notespositions/) en su lugar.
{{% /alert %}}

## **Convertir diapositivas a imágenes usando opciones TIFF**

La clase [TiffOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/tiffoptions/) le permite controlar el tamaño, la resolución y otras propiedades de la imagen TIFF renderizada.

El siguiente ejemplo renderiza la primera diapositiva como una imagen TIFF de 2160 × 2880 a 300 DPI:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import java.awt.Dimension;

Dimension imageSize = new Dimension(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
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

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Crear salida Enhanced Metafile**

Enhanced Metafile (EMF) es útil cuando se deben intercambiar gráficos basados en vectores con Microsoft Office u otras aplicaciones Windows que admiten metafiles de Windows. A diferencia de una imagen basada en píxeles, un EMF puede conservar operaciones de dibujo vectorial que se escalan sin la misma pérdida de nitidez. Sin embargo, EMF es principalmente un formato de compatibilidad para aplicaciones con soporte de metafiles de Windows, no un formato universal de intercambio. Además, el contenido complejo de la diapositiva, como imágenes bitmap y algunos efectos, puede almacenarse como elementos rasterizados dentro del contenedor de metafile vectorial.

### **Exportar una diapositiva a EMF**

El método [ISlide.writeAsEmf](https://reference.aspose.com/slides/es/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) escribe una [ISlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/islide/) en un flujo de destino en formato EMF. El siguiente ejemplo carga una presentación, selecciona la primera diapositiva y la escribe en un flujo de archivo EMF:

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

El llamador es propietario del flujo pasado a [ISlide.writeAsEmf](https://reference.aspose.com/slides/es/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) y es responsable de cerrarlo, como se muestra arriba.

### **Convertir una imagen SVG a EMF y añadirla a una presentación**

Utilice [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/es/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) para convertir contenido SVG a EMF. Los bytes resultantes pueden añadirse a la presentación mediante [IImageCollection.addImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) y colocarse en una diapositiva con [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-).

El siguiente ejemplo crea un [SvgImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/svgimage/) a partir de marcado SVG, lo convierte a un EMF en memoria, inserta el metafile en la primera diapositiva y guarda la presentación:

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/es/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) no se hace propietario del flujo de destino. Un [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) almacena todos los datos generados en memoria, por lo que no se requiere restablecer la posición antes de llamar a `toByteArray`. El array de bytes devuelto sigue siendo válido después de cerrar el flujo.

La generación de EMF está disponible en los sistemas operativos compatibles con la configuración seleccionada de Aspose.Slides for Java y JDK, pero la renderización puede diferir entre plataformas cuando las fuentes o dependencias gráficas no están disponibles. Instale las fuentes usadas por el contenido fuente o configure sustituciones adecuadas, siga los [requisitos de plataforma](/slides/es/java/system-requirements/) para Aspose.Slides for Java y valide el resultado en la aplicación destino que consuma EMF. Las aplicaciones Linux y macOS suelen tener soporte limitado o inconsistente para mostrar y editar metafiles de Windows.

## **Renderizado de Emoji a Color**

{{% alert title="Note" color="info" %}}
Para renderizar correctamente emojis a color al convertir diapositivas de una presentación a imágenes, las fuentes de emojis usadas en la presentación deben estar instaladas y disponibles en el sistema que realiza la conversión. Por ejemplo, si la presentación utiliza **Segoe UI Emoji** y esa fuente falta, los emojis pueden aparecer en monocromo en las imágenes de salida.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Aspose.Slides admite renderizar diapositivas con animaciones?**

No. El método [ISlide.getImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/islide/#getImage--) renderiza una imagen estática de la diapositiva y no exporta animaciones.

**¿Se pueden exportar como imágenes las diapositivas ocultas?**

Sí. Las diapositivas ocultas pueden renderizarse como diapositivas normales. Inclúyalas en el bucle de procesamiento, como se muestra en el ejemplo anterior.

**¿Se conservan las sombras y otros efectos en las imágenes de diapositivas?**

Sí. Aspose.Slides renderiza sombras, transparencia y otros efectos gráficos compatibles en las imágenes de diapositivas.