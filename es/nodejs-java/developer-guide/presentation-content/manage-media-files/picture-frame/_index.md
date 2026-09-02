---
title: Gestionar marcos de imagen en presentaciones usando JavaScript
linktitle: Marco de imagen
type: docs
weight: 10
url: /es/nodejs-java/picture-frame/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea, formatea, vincula, recorta, extrae y comprime marcos de imagen en presentaciones con Aspose.Slides para Node.js a través de Java."
---
## **Visión general**

Un marco de imagen es una forma de diapositiva que muestra una imagen. En Aspose.Slides, el recurso de imagen y la forma que la muestra son objetos separados: una [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) posee recursos de imagen incrustados a través de su [ImageCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagecollection/), mientras que un [PictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) controla la posición, el tamaño, el formato de línea, la rotación, el recorte, los efectos de imagen y otras configuraciones a nivel de marco.

Esta separación es útil cuando la misma imagen se muestra más de una vez. Añada la imagen a la presentación una sola vez, conserve el [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) devuelto y utilice ese recurso de imagen al crear marcos de imagen.

Los marcos de imagen pueden contener imágenes raster como PNG o JPEG e imágenes vectoriales SVG. También pueden referirse a imágenes vinculadas en lugar de almacenar los bytes de la imagen en la presentación. La elección afecta la portabilidad, el tamaño del archivo, la extracción y el comportamiento de exportación, por lo que es útil decidir cómo debe almacenarse la imagen antes de aplicar formato u optimización.

## **Añadir y formatear una imagen incrustada**

Para una imagen incrustada, añada los datos de la imagen a la presentación y cree un marco de imagen con [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). La imagen pasa a ser parte del paquete de la presentación, de modo que la presentación sigue siendo autónoma cuando se traslada a otro equipo.

El siguiente ejemplo añade una imagen PNG, crea un marco con las dimensiones nativas de la imagen y aplica formato de línea y rotación:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El marco de imagen controla la geometría mostrada; cambiar el tamaño del marco no modifica las dimensiones de píxel originales almacenadas en el recurso de imagen incrustada. Esta distinción se vuelve importante al recortar o comprimir una imagen más adelante.

## **Usar escala relativa**

[PictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) expone el escalado relativo de ancho y alto para el marco mediante [setRelativeScaleWidth](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) y [setRelativeScaleHeight](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Un valor de `1.0` corresponde al 100 % del tamaño original de la imagen. La escala relativa es útil cuando un flujo de trabajo necesita preservar una relación con el tamaño de la imagen fuente en lugar de calcular dimensiones finales manualmente.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El escalado relativo cambia la configuración de escala del marco; no vuelve a muestrear ni comprime la imagen incrustada.

## **Imágenes incrustadas y vinculadas**

Una imagen incrustada almacena los datos de la imagen dentro de la presentación y, por tanto, es la opción más segura para la portabilidad y una renderización predecible. Una imagen vinculada almacena una ubicación externa mediante el método [Picture.setLinkPathLong](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) en lugar de incrustar los datos de la imagen de la misma manera.

Las imágenes vinculadas pueden reducir la cantidad de datos de imagen almacenados en el PPTX, pero introducen una dependencia externa. El archivo vinculado debe seguir siendo accesible para la aplicación que abre o renderiza la presentación. Si la ruta cambia, el archivo se mueve o el recurso no está disponible, la imagen vinculada puede no mostrarse como se espera. Para presentaciones que deben enviarse por correo electrónico, archivarse o renderizarse en entornos aislados, las imágenes incrustadas suelen ser más fiables.

### **Añadir una imagen vinculada**

El siguiente ejemplo crea un marco de imagen y lo apunta a un archivo de imagen local. Sólo trata el enlace de imágenes; el enlace de vídeo es un flujo de trabajo multimedia separado y se ha omitido deliberadamente en este ejemplo.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilice enlaces cuando la gestión de archivos externos sea intencional. No los use simplemente como sustituto de la compresión: un PPTX pequeño con dependencias de imagen rotas suele ser menos útil que una presentación mayor y autónoma.

## **Extraer imágenes de marcos de imagen**

Antes de extraer una imagen de una presentación existente, compruebe que una forma es realmente un [PictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) y que contiene una imagen incrustada. Los marcos de imagen vinculados pueden no contener bytes de imagen que puedan extraerse de la misma forma.

### **Extraer una imagen raster**

La API moderna de imágenes usa [IImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/) directamente. El siguiente ejemplo encuentra la primera imagen raster incrustada en una diapositiva y la guarda como PNG:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Guardar mediante [IImage.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/#save) convierte la imagen extraída al formato de salida solicitado. Si necesita los bytes codificados almacenados en la presentación en lugar de un archivo raster convertido, use los datos binarios del recurso de imagen.

### **Extraer una imagen SVG**

Para una imagen SVG, el [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) expone un objeto [SvgImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/svgimage/). Esto permite recuperar los datos SVG directamente en vez de rasterizar la imagen primero.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

Mantener el contenido SVG como SVG preserva la fuente vectorial dentro de la presentación. Las exportaciones raster como PNG o JPEG convierten necesariamente ese contenido vectorial a píxeles. La exportación de diapositivas a PDF o SVG también es una operación de renderizado, por lo que los gráficos exportados no deben considerarse una copia byte a byte del SVG incrustado original; use los datos de [SvgImage.getSvgData](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/svgimage/#getSvgData--) cuando se requiera el recurso vectorial original.

## **Recortar una imagen**

El recorte cambia qué parte de una imagen es visible dentro del marco. Los valores de recorte en [PictureFillFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/) son porcentajes de las dimensiones de la imagen fuente. Recortar no elimina inicialmente los píxeles ocultos de la imagen incrustada; sólo cambia la región visible.

El siguiente ejemplo localiza de forma segura un marco de imagen y aplica valores de recorte:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Como los datos de la imagen oculta siguen presentes, el recorte puede modificarse después sin perder los píxeles originales. Si el tamaño del archivo es más importante que la reversibilidad, las áreas recortadas pueden eliminarse físicamente como se describe en la sección siguiente.

## **Eliminar datos de imagen recortados**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) elimina los datos de imagen fuera del rectángulo de recorte actual y devuelve el recurso de imagen resultante. Esto puede reducir el tamaño del archivo, pero es una optimización destructiva: tras guardar la presentación, los píxeles eliminados ya no están disponibles para una operación de "desrecorte" posterior.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

El método puede añadir un nuevo recurso de imagen a la presentación. Si la imagen original también se usa en otros marcos de imagen, esos marcos siguen necesitando su recurso existente, de modo que eliminar áreas recortadas no reduce necesariamente el número total de imágenes. Recortar contenido WMF o EMF con este método rasteriza el resultado recortado a PNG.

## **Comprimir imágenes raster**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) reduce la resolución de la imagen raster en relación con el tamaño al que se muestra la imagen. También puede eliminar regiones recortadas en la misma operación. El método devuelve `true` cuando la imagen se ha redimensionado o recortado y `false` cuando no era necesario ningún cambio.

Utilice un valor predefinido de [PicturesCompression](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturescompression/) cuando una resolución objetivo estándar sea suficiente:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Se puede pasar un valor DPI positivo personalizado en lugar de un valor predefinido cuando se requiere un objetivo específico.

La compresión está pensada para imágenes raster. El contenido SVG y de metarchivo no se reduce con este flujo de compresión raster. Además, recuerde que la menor resolución y las regiones recortadas eliminadas no pueden recuperarse de la presentación optimizada. Elija una resolución objetivo basada en el mayor tamaño al que la imagen será realmente vista o exportada, en lugar de aplicar el DPI más bajo de forma global.

## **Gestionar efectos de transformación de imagen**

Para un flujo de trabajo completo que cubra brillo, contraste, transformaciones de color, desenfoque, efectos alfa, cadenas ordenadas, inspección, eliminación y verificación de ida y vuelta, consulte [Image Transform Effects](/nodejs-java/image-transform-effects/).

## **Bloquear la geometría del marco de imagen**

Los ajustes de [PictureFrameLock](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframelock/) controlan qué operaciones de edición están deshabilitadas para un marco de imagen. Por ejemplo, [setAspectRatioLocked](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) conserva las proporciones de la forma mientras se redimensiona.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El bloqueo se aplica a la forma del marco de imagen. No obliga a que la imagen fuente sea remuestreada o cambiada permanentemente al mismo ratio de aspecto.

## **Ajustar los valores StretchOffset**

Cuando el modo de relleno de imagen es estirado, los valores stretch‑offset en [PictureFillFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/) definen el rectángulo de relleno relativo al cuadro delimitador del marco de imagen. Los porcentajes positivos crean una inserción desde un borde, mientras que los porcentajes negativos crean una expansión.

Esto es diferente del recorte. Los valores de recorte seleccionan qué parte de la imagen fuente es visible; los offsets de estiramiento cambian el rectángulo en el que el relleno de imagen visible se estira.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Use los offsets de estiramiento para la colocación del relleno. Use las propiedades de recorte cuando el objetivo sea ocultar los bordes de la imagen fuente.

## **Almacenamiento, tamaño del archivo y consideraciones de exportación**

Los principales compromisos son más fáciles de gestionar cuando el almacenamiento de imágenes y el formato del marco de imagen se tratan por separado:

- **Imágenes incrustadas** hacen que la presentación sea autónoma y son la opción más fiable para compartir y renderizar del lado del servidor, pero las imágenes raster grandes aumentan el tamaño del PPTX y el uso de memoria.
- **Imágenes vinculadas** pueden mantener el paquete más pequeño, pero la presentación depende de que los archivos externos permanezcan disponibles en las rutas o ubicaciones almacenadas.
- **Recorte** es inicialmente no destructivo. Los píxeles ocultos permanecen incrustados hasta que las áreas recortadas se eliminen explícitamente o se eliminen durante la compresión.
- **Compresión** puede reducir considerablemente el tamaño del archivo para imágenes raster sobredimensionadas, pero sacrifica la resolución original. Debe aplicarse después de conocer el tamaño final en la diapositiva.
- **Imágenes SVG** deben permanecer como SVG cuando la preservación vectorial es importante. Extraiga el SVG incrustado directamente cuando necesite el recurso vectorial en sí. Las exportaciones de diapositivas a raster siempre convierten la diapositiva renderizada a píxeles.
- **Imágenes repetidas** deben reutilizar un recurso [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) existente cuando sea posible en lugar de cargar repetidamente el mismo archivo en el flujo de trabajo de la presentación.

Para presentaciones grandes, la optimización de imágenes suele ser más eficaz cuando se realiza de forma selectiva: mantenga logotipos y diagramas como contenido vectorial, comprima fotografías según su tamaño de visualización real, elimine píxeles recortados sólo cuando no se requiera edición posterior y evite enlaces externos a menos que la gestión de dependencias forme parte del diseño de implementación.

## **FAQ**

**¿Cuál es la diferencia entre un marco de imagen y un recurso de imagen?**

Un [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) representa un recurso de imagen asociado a la presentación. Un [PictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) es una forma en una diapositiva que muestra una imagen y almacena geometría y formato a nivel de marco, como tamaño, rotación, valores de recorte, efectos y bloqueos.

**¿Debo incrustar o vincular imágenes?**

Incruste imágenes cuando la presentación deba ser portátil, archivada o renderizada sin acceso a recursos externos. Vincule imágenes sólo cuando mantener los archivos de imagen fuera del PPTX sea intencional y las ubicaciones externas puedan mantenerse de forma fiable.

**¿El recorte reduce el tamaño del archivo PPTX?**

No por sí mismo. La configuración de recorte normal oculta partes de la imagen fuente pero mantiene los píxeles subyacentes. Utilice [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) o la compresión de imagen con eliminación de áreas recortadas cuando esos píxeles puedan descartarse permanentemente.

**¿Puedo restaurar la calidad de la imagen después de la compresión?**

No. La compresión puede reducir la resolución raster almacenada, y la eliminación de regiones recortadas descarta datos de imagen. Mantenga la imagen original fuera de la presentación si más adelante puede requerirse una edición de alta resolución.

**¿Cómo se deben manejar las imágenes SVG?**

Mantenga el contenido SVG como SVG cuando la fidelidad vectorial sea importante. El [SvgImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/svgimage/) incrustado puede extraerse directamente. Renderizar una diapositiva a un formato raster como PNG o JPEG rasteriza el SVG como parte de la imagen de la diapositiva.

**¿Cómo puedo evitar casts inseguros al leer diapositivas existentes?**

Compruebe el tipo de forma antes de usar miembros específicos de marco de imagen. Una comprobación `java.instanceOf` contra [PictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) evita casts inválidos y permite al código gestionar diapositivas que no contengan marcos de imagen.