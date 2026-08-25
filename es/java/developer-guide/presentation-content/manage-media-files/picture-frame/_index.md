---
title: Administrar marcos de imagen en presentaciones usando Java
linktitle: Marco de imagen
type: docs
weight: 10
url: /es/java/picture-frame/
keywords:
- marco de imagen
- añadir marco de imagen
- crear marco de imagen
- imagen incrustada
- imagen vinculada
- extraer imagen
- imagen raster
- imagen SVG
- recortar imagen
- eliminar áreas recortadas
- comprimir imagen
- StretchOffset
- formato de marco de imagen
- escala relativa
- efecto de imagen
- relación de aspecto
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Crear, dar formato, vincular, recortar, extraer y comprimir marcos de imagen en presentaciones con Aspose.Slides para Java."
---
## **Visión general**

Un marco de imagen es una forma de diapositiva que muestra una imagen. En Aspose.Slides, el recurso de imagen y la forma que la muestra son objetos separados: una [Presentación](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) posee recursos de imagen incrustados a través de su [IImageCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimagecollection/), mientras que un [IPictureFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipictureframe/) controla la posición, tamaño, formato de línea, rotación, recorte, efectos de imagen y otros ajustes a nivel de marco.

Esta separación es útil cuando la misma imagen se muestra más de una vez. Añada la imagen a la presentación una sola vez, conserve el [IPPImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/ippimage/) devuelto y utilice ese recurso de imagen al crear marcos de imagen.

Los marcos de imagen pueden contener imágenes raster como PNG o JPEG e imágenes vectoriales SVG. También pueden referirse a imágenes vinculadas en lugar de almacenar los bytes de la imagen en la presentación. La elección afecta la portabilidad, el tamaño del archivo, la extracción y el comportamiento de exportación, por lo que es conveniente decidir cómo debe almacenarse la imagen antes de aplicar formato u optimización.

## **Agregar y dar formato a una imagen incrustada**

Para una imagen incrustada, añada los datos de la imagen a la presentación y cree un marco de imagen con [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). La imagen pasa a formar parte del paquete de la presentación, por lo que la presentación sigue siendo autosuficiente cuando se traslada a otro equipo.

El siguiente ejemplo añade una imagen JPEG, crea un marco con las dimensiones nativas de la imagen y aplica formato de línea y rotación:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El marco de imagen controla la geometría mostrada; cambiar el tamaño del marco no modifica las dimensiones de píxel originales almacenadas en el recurso de imagen incrustado. Esta distinción se vuelve importante al recortar o comprimir una imagen más adelante.

## **Utilizar escala relativa**

[IPictureFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipictureframe/) expone el escalado relativo de ancho y altura del marco a través de [setRelativeScaleWidth](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) y [setRelativeScaleHeight](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Un valor de `1.0` corresponde al 100 % del tamaño original de la imagen. La escala relativa es útil cuando un flujo de trabajo necesita conservar una relación con el tamaño de la imagen original en lugar de calcular manualmente las dimensiones finales.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La escala relativa modifica la configuración de escala del marco; no vuelve a muestrear ni comprime la imagen incrustada.

## **Imágenes incrustadas y vinculadas**

Una imagen incrustada almacena los datos de la imagen dentro de la presentación y, por tanto, es la opción más segura para la portabilidad y una renderización predecible. Una imagen vinculada guarda una ubicación externa mediante el método [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/es/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) en lugar de incrustar los datos de la imagen de la misma forma.

Las imágenes vinculadas pueden reducir la cantidad de datos de imagen almacenados en el PPTX, pero introducen una dependencia externa. El archivo vinculado debe seguir siendo accesible para la aplicación que abre o renderiza la presentación. Si la ruta cambia, el archivo se mueve o el recurso no está disponible, la imagen vinculada puede no mostrarse como se espera. Para presentaciones que deben enviarse por correo, archivarse o renderizarse en entornos aislados, las imágenes incrustadas suelen ser más fiables.

### **Agregar una imagen vinculada**

El siguiente ejemplo crea un marco de imagen y lo apunta a un archivo de imagen local. Solo trata el enlace de imágenes; el enlace de video es un flujo de trabajo multimedia separado y deliberadamente no se mezcla en este ejemplo.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilice enlaces cuando la gestión de archivos externos sea intencional. No los use simplemente como sustituto de la compresión: un PPTX pequeño con dependencias de imagen rotas suele ser menos útil que una presentación más grande y autosuficiente.

## **Extraer imágenes de marcos de imagen**

Antes de extraer una imagen de una presentación existente, verifique que una forma sea realmente un [IPictureFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipictureframe/) y que contenga una imagen incrustada. Los marcos de imagen vinculados pueden no contener los bytes de la imagen que puedan extraerse de la misma manera.

### **Extraer una imagen raster**

La API de imágenes moderna utiliza [IImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/) directamente y no requiere el contenedor de imagen Java más antiguo. El siguiente ejemplo encuentra la primera imagen raster incrustada en una diapositiva y la guarda como PNG:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Guardar mediante [IImage.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/#save-java.lang.String-int-) convierte la imagen extraída al formato de salida solicitado. Si necesita los bytes codificados almacenados en la presentación en lugar de un archivo raster convertido, utilice los datos binarios del recurso de imagen.

### **Extraer una imagen SVG**

Para una imagen SVG, el [IPPImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/ippimage/) expone un objeto [ISvgImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/isvgimage/). Esto permite recuperar los datos SVG directamente en lugar de rasterizar la imagen primero.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Conservar el contenido SVG como SVG preserva la fuente vectorial dentro de la presentación. Las exportaciones raster como PNG o JPEG convierten necesariamente ese contenido vectorial a píxeles. La exportación de diapositivas a PDF o SVG también es una operación de renderizado, por lo que los gráficos exportados no deben considerarse una copia idéntica byte a byte del SVG incrustado original; utilice los datos de [ISvgImage.getSvgData](https://reference.aspose.com/slides/es/java/com.aspose.slides/isvgimage/#getSvgData--) incrustados cuando se requiera el recurso vectorial original.

## **Recortar una imagen**

El recorte cambia qué parte de una imagen es visible dentro del marco. Los valores de recorte en [IPictureFillFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipicturefillformat/) son porcentajes de las dimensiones de la imagen original. El recorte no elimina inicialmente los píxeles ocultos de la imagen incrustada; solo modifica la región visible.

El siguiente ejemplo localiza de forma segura un marco de imagen y aplica valores de recorte:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Como los datos de la imagen oculta siguen presentes, el recorte puede modificarse más adelante sin perder los píxeles originales. Si el tamaño del archivo es más importante que la reversibilidad, las regiones recortadas pueden eliminarse físicamente como se describe en la siguiente sección.

## **Eliminar datos de imagen recortados**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) elimina los datos de imagen que están fuera del rectángulo de recorte actual y devuelve el recurso de imagen resultante. Esto puede reducir el tamaño del archivo, pero es una optimización destructiva: después de guardar la presentación, los píxeles eliminados ya no están disponibles para una operación de desrecorte posterior.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

El método puede añadir un nuevo recurso de imagen a la presentación. Si la imagen original también es utilizada por otros marcos de imagen, esos marcos siguen necesitando su recurso existente, por lo que eliminar áreas recortadas no reduce necesariamente el número total de imágenes. Recortar contenido WMF o EMF con este método rasteriza el resultado recortado a PNG.

## **Comprimir imágenes raster**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) reduce la resolución de la imagen raster en relación con el tamaño en que se muestra la imagen. También puede eliminar regiones recortadas en la misma operación. El método devuelve `true` cuando la imagen fue redimensionada o recortada y `false` cuando no fue necesario ningún cambio.

Utilice un valor predefinido de [PicturesCompression](https://reference.aspose.com/slides/es/java/com.aspose.slides/picturescompression/) cuando una resolución objetivo estándar sea suficiente:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Se puede pasar un valor DPI positivo personalizado en lugar de un valor predefinido cuando se requiere un objetivo específico.

La compresión está pensada para imágenes raster. El contenido SVG y de metarchivo no se reduce con este flujo de compresión raster. También recuerde que la menor resolución y las regiones recortadas eliminadas no pueden recuperarse de la presentación optimizada. Elija una resolución objetivo basada en el mayor tamaño en el que la imagen será realmente visualizada o exportada, en lugar de aplicar el DPI más bajo de forma global.

## **Administrar efectos de transformación de imagen**

Para un flujo de trabajo completo que cubra brillo, contraste, transformaciones de color, desenfoque, efectos alpha, cadenas ordenadas, inspección, eliminación y verificación de ida y vuelta, consulte [Efectos de transformación de imagen](/java/image-transform-effects/).

## **Bloquear la geometría del marco de imagen**

La configuración de [IPictureFrameLock](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipictureframelock/) controla qué operaciones de edición están deshabilitadas para un marco de imagen. Por ejemplo, [setAspectRatioLocked](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) conserva las proporciones de la forma mientras se redimensiona.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El bloqueo se aplica a la forma del marco de imagen. No obliga a que la imagen original sea remuestreada ni cambiada permanentemente al mismo aspecto.

## **Ajustar los valores StretchOffset**

Cuando el modo de relleno de imagen es estirado, los valores stretch‑offset en [IPictureFillFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipicturefillformat/) definen el rectángulo de relleno relativo al cuadro delimitador del marco de imagen. Los porcentajes positivos crean una inserción desde un borde, mientras que los porcentajes negativos crean una protrusión.

Esto difiere del recorte. Los valores de recorte seleccionan qué parte de la imagen original es visible; los offsets de estiramiento cambian el rectángulo en el que se estira el relleno visible de la imagen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilice los offsets de estiramiento para la colocación del relleno. Utilice las propiedades de recorte cuando el objetivo sea ocultar los bordes de la imagen original.

## **Consideraciones de almacenamiento, tamaño de archivo y exportación**

Los principales compromisos son más fáciles de gestionar cuando el almacenamiento de imágenes y el formato del marco de imagen se tratan por separado:

- **Imágenes incrustadas** hacen que la presentación sea autosuficiente y son las más fiables para compartir y renderizar en el servidor, pero las imágenes raster grandes aumentan el tamaño del PPTX y el uso de memoria.
- **Imágenes vinculadas** pueden mantener el paquete más pequeño, pero la presentación depende de que los archivos externos permanezcan disponibles en las rutas o ubicaciones almacenadas.
- **Recorte** es inicialmente no destructivo. Los píxeles ocultos permanecen incrustados hasta que las áreas recortadas se eliminen explícitamente o se eliminen durante la compresión.
- **Compresión** puede reducir considerablemente el tamaño del archivo para imágenes raster de gran tamaño, pero sacrifica la resolución original. Debe aplicarse después de conocer el tamaño previsto en la diapositiva.
- **Imágenes SVG** deben permanecer como SVG cuando la preservación vectorial es importante. Extraiga el SVG incrustado directamente cuando necesite el recurso vectorial en sí. Las exportaciones raster de diapositivas siempre convierten la diapositiva renderizada a píxeles.
- **Imágenes repetidas** deben reutilizar un recurso [IPPImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/ippimage/) existente cuando sea posible en lugar de cargar repetidamente el mismo archivo en el flujo de trabajo de la presentación.

Para presentaciones grandes, la optimización de imágenes suele ser más efectiva cuando se realiza de forma selectiva: mantenga logotipos y diagramas como contenido vectorial, comprima fotografías según su tamaño de visualización real, elimine los píxeles recortados solo cuando la edición posterior no sea necesaria y evite enlaces externos a menos que la gestión de dependencias forme parte del diseño de despliegue.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un marco de imagen y un recurso de imagen?**

Un [IPPImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/ippimage/) representa un recurso de imagen asociado a la presentación. Un [IPictureFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipictureframe/) es una forma en una diapositiva que muestra una imagen y almacena la geometría y el formato a nivel de marco, como tamaño, rotación, valores de recorte, efectos y bloqueos.

**¿Debo incrustar o vincular imágenes?**

Incruste imágenes cuando la presentación deba ser portable, archivada o renderizada sin acceso a recursos externos. Víncule imágenes solo cuando mantener los archivos de imagen fuera del PPTX sea intencional y las ubicaciones externas puedan mantenerse de forma fiable.

**¿El recorte reduce el tamaño del archivo PPTX?**

No por sí mismo. Los ajustes normales de recorte ocultan partes de la imagen original pero mantienen los píxeles subyacentes. Utilice [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) o la compresión de imágenes con eliminación de áreas recortadas cuando esos píxeles puedan descartarse permanentemente.

**¿Puedo restaurar la calidad de la imagen después de la compresión?**

No. La compresión puede reducir la resolución raster almacenada, y eliminar las regiones recortadas descarta datos de la imagen. Mantenga la imagen fuente original fuera de la presentación si más adelante pudiera requerirse una edición de alta resolución.

**¿Cómo se deben manejar las imágenes SVG?**

Mantenga el contenido SVG como SVG cuando la fidelidad vectorial sea importante. El [ISvgImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/isvgimage/) incrustado puede extraerse directamente. Renderizar una diapositiva a un formato raster como PNG o JPEG rasteriza el SVG como parte de la imagen de la diapositiva.

**¿Cómo puedo evitar conversiones inseguras al leer diapositivas existentes?**

Compruebe el tipo de forma antes de usar miembros específicos de marcos de imagen. Una comprobación `instanceof` contra [IPictureFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipictureframe/) evita conversiones inválidas y permite que el código maneje diapositivas que no contienen marcos de imagen.