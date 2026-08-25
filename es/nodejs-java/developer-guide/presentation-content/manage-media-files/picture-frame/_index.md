---
title: Gestionar marcos de imagen en presentaciones con JavaScript
linktitle: Marco de imagen
type: docs
weight: 10
url: /es/nodejs-java/picture-frame/
keywords:
- marco de imagen
- añadir marco de imagen
- crear marco de imagen
- imagen incrustada
- imagen enlazada
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
description: "Crear, formatear, enlazar, recortar, extraer y comprimir marcos de imagen en presentaciones con Aspose.Slides para Node.js mediante Java."
---
## **Descripción general**

Un marco de imagen es una forma de diapositiva que muestra una imagen. En Aspose.Slides, el recurso de imagen y la forma que la muestra son objetos separados: una [Presentación](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) posee recursos de imágenes incrustadas a través de su [ColecciónDeImágenes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagecollection/), mientras que un [MarcoDeImagen](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) controla la posición, el tamaño, el formato de línea, la rotación, el recorte, los efectos de imagen y otras configuraciones a nivel de marco.

Esta separación resulta útil cuando la misma imagen se muestra más de una vez. Añada la imagen a la presentación una sola vez, conserve el [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) devuelto y utilice ese recurso de imagen al crear marcos de imagen.

Los marcos de imagen pueden contener imágenes raster como PNG o JPEG e imágenes vectoriales SVG. También pueden referirse a imágenes enlazadas en lugar de almacenar los bytes de la imagen en la presentación. La elección afecta la portabilidad, el tamaño del archivo, la extracción y el comportamiento de exportación, por lo que es útil decidir cómo debe almacenarse la imagen antes de aplicar formato u optimización.

## **Agregar y formatear una imagen incrustada**

Para una imagen incrustada, añada los datos de la imagen a la presentación y cree un marco de imagen con [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). La imagen pasa a formar parte del paquete de la presentación, de modo que la presentación sigue siendo autónoma al trasladarse a otro equipo.

El ejemplo siguiente añade una imagen PNG, crea un marco con las dimensiones nativas de la imagen y aplica formato de línea y rotación:

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

El marco de imagen controla la geometría mostrada; cambiar el tamaño del marco no modifica las dimensiones de píxel originales almacenadas en el recurso de imagen incrustado. Esta distinción se vuelve importante al recortar o comprimir una imagen más adelante.

## **Usar escala relativa**

[MarcoDeImagen](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) expone el escalado relativo de ancho y alto del marco mediante [setRelativeScaleWidth](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) y [setRelativeScaleHeight](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Un valor de `1.0` corresponde al 100 % del tamaño original de la imagen. La escala relativa es útil cuando un flujo de trabajo necesita preservar una relación con el tamaño de la imagen origen en lugar de calcular manualmente las dimensiones finales.

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

El escalado relativo cambia la configuración de escala del marco; no remuestrea ni comprime la imagen incrustada.

## **Imágenes incrustadas y enlazadas**

Una imagen incrustada almacena los datos de la imagen dentro de la presentación y, por tanto, es la opción más segura para la portabilidad y una representación predecible. Una imagen enlazada guarda una ubicación externa mediante el método [Picture.setLinkPathLong](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) en lugar de incrustar los datos de la imagen de la misma manera.

Las imágenes enlazadas pueden reducir la cantidad de datos de imagen almacenados en el PPTX, pero introducen una dependencia externa. El archivo enlazado debe seguir siendo accesible para la aplicación que abre o renderiza la presentación. Si la ruta cambia, el archivo se mueve o el recurso no está disponible, la imagen enlazada puede no mostrarse como se espera. Para presentaciones que deben enviarse por correo, archivarse o renderizarse en entornos aislados, las imágenes incrustadas suelen ser más fiables.

### **Agregar una imagen enlazada**

El ejemplo siguiente crea un marco de imagen y lo apunta a un archivo de imagen local. Sólo trata el enlace de imágenes; el enlace de vídeo es un flujo de trabajo multimedia independiente y se ha excluido intencionalmente de este ejemplo.

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

Utilice enlaces cuando la gestión de archivos externos sea deliberada. No los use simplemente como sustituto de la compresión: un PPTX pequeño con dependencias de imagen rotas suele ser menos útil que una presentación más grande y autónoma.

## **Extraer imágenes de marcos de imagen**

Antes de extraer una imagen de una presentación existente, compruebe que una forma es realmente un [MarcoDeImagen](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) y que contiene una imagen incrustada. Los marcos de imagen enlazados pueden no contener bytes de imagen que puedan extraerse de la misma forma.

### **Extraer una imagen raster**

La API de imágenes moderna usa directamente [IImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/). El ejemplo siguiente encuentra la primera imagen raster incrustada en una diapositiva y la guarda como PNG:

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

Para una imagen SVG, el [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) expone un objeto [SvgImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/svgimage/). Esto le permite obtener los datos SVG directamente sin rasterizar la imagen primero.

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

Mantener el contenido SVG como SVG preserva la fuente vectorial dentro de la presentación. Las exportaciones raster como PNG o JPEG obligan a renderizar ese contenido vectorial a píxeles. La exportación de diapositivas a PDF o SVG también es una operación de renderizado, por lo que los gráficos exportados no deben considerarse una copia bit‑a‑bit del SVG original incrustado; use los datos de [SvgImage.getSvgData](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/svgimage/#getSvgData--) cuando se requiera el recurso vectorial original.

## **Recortar una imagen**

El recorte cambia qué parte de una imagen es visible dentro del marco. Los valores de recorte en [PictureFillFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/) son porcentajes de las dimensiones de la imagen origen. El recorte no elimina inicialmente los píxeles ocultos de la imagen incrustada; solo modifica la región visible.

El ejemplo siguiente encuentra un marco de imagen de forma segura y aplica valores de recorte:

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

Como los datos de la imagen oculta siguen presentes, el recorte puede modificarse posteriormente sin perder los píxeles originales. Si el tamaño del archivo es más importante que la reversibilidad, las regiones recortadas pueden eliminarse físicamente como se describe en la siguiente sección.

## **Eliminar datos de imagen recortados**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) elimina los datos de imagen fuera del rectángulo de recorte actual y devuelve el recurso de imagen resultante. Esto puede reducir el tamaño del archivo, pero es una optimización destructiva: tras guardar la presentación, los píxeles eliminados ya no están disponibles para una operación de des‑recorte posterior.

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

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) reduce la resolución de la imagen raster en relación con el tamaño al que se muestra la imagen. También puede eliminar regiones recortadas en la misma operación. El método devuelve `true` cuando la imagen se redimensionó o recortó y `false` cuando no fue necesario ningún cambio.

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

En su lugar, puede pasarse un valor DPI positivo personalizado cuando se requiera un objetivo específico.

La compresión está pensada para imágenes raster. El contenido SVG y de metarchivo no se reduce con este flujo de compresión raster. Además, recuerde que una resolución menor y las regiones recortadas eliminadas no pueden recuperarse de la presentación optimizada. Elija una resolución objetivo basada en el mayor tamaño al que la imagen será realmente vista o exportada, en lugar de aplicar el DPI más bajo de forma global.

## **Gestionar efectos de transformación de imagen**

Para un flujo de trabajo completo que cubra brillo, contraste, transformaciones de color, desenfoque, efectos alfa, cadenas ordenadas, inspección, eliminación y verificación de ida y vuelta, consulte [Efectos de transformación de imagen](/slides/es/nodejs-java/image-transform-effects/).

## **Bloquear la geometría del marco de imagen**

Los ajustes de [PictureFrameLock](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframelock/) controlan qué operaciones de edición están deshabilitadas para un marco de imagen. Por ejemplo, [setAspectRatioLocked](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) preserva las proporciones de la forma mientras se redimensiona.

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

El bloqueo se aplica a la forma del marco de imagen. No obliga a que la imagen origen sea remuestreada o cambiada permanentemente al mismo proporción.

## **Ajustar los valores StretchOffset**

Cuando el modo de relleno de imagen es estirado, los valores stretch‑offset en [PictureFillFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/) definen el rectángulo de relleno relativo al cuadro delimitador del marco de imagen. Los porcentajes positivos crean una inserción desde un borde, mientras que los porcentajes negativos crean una expansión.

Esto difiere del recorte. Los valores de recorte seleccionan qué parte de la imagen origen es visible; los stretch‑offset cambian el rectángulo en el que se estira el relleno visible.

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

Utilice los stretch‑offset para la colocación del relleno. Use los valores de recorte cuando el objetivo sea ocultar los bordes de la imagen origen.

## **Almacenamiento, tamaño de archivo y consideraciones de exportación**

Los principales compromisos son más fáciles de gestionar cuando el almacenamiento de imágenes y el formato del marco de imagen se tratan por separado:

- **Imágenes incrustadas** hacen que la presentación sea autónoma y son la opción más fiable para compartir y renderizar en servidor, pero las imágenes raster grandes aumentan el tamaño del PPTX y el uso de memoria.
- **Imágenes enlazadas** pueden mantener el paquete más pequeño, pero la presentación depende de que los archivos externos sigan disponibles en las rutas o ubicaciones almacenadas.
- **Recorte** es inicialmente no destructivo. Los píxeles ocultos permanecen incrustados hasta que las áreas recortadas se eliminen explícitamente o se borren durante la compresión.
- **Compresión** puede reducir considerablemente el tamaño del archivo para imágenes raster sobredimensionadas, pero sacrifica la resolución origen. Debe aplicarse después de conocer el tamaño final en la diapositiva.
- **Imágenes SVG** deben permanecer como SVG cuando la preservación vectorial sea importante. Extraiga el SVG incrustado directamente cuando necesite el recurso vectorial en sí. Las exportaciones de diapositivas a raster siempre convierten la diapositiva renderizada a píxeles.
- **Imágenes repetidas** deberían reutilizar un recurso [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) existente cuando sea posible, en lugar de cargar repetidamente el mismo archivo en el flujo de trabajo de la presentación.

Para presentaciones grandes, la optimización de imágenes suele ser más eficaz cuando se realiza de manera selectiva: mantenga logotipos y diagramas como contenido vectorial, comprima fotografías según su tamaño de visualización real, elimine píxeles recortados sólo cuando no sea necesario editarlos más tarde y evite enlaces externos a menos que la gestión de dependencias forme parte del diseño de despliegue.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un marco de imagen y un recurso de imagen?**

Un [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) representa un recurso de imagen asociado a la presentación. Un [MarcoDeImagen](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) es una forma en una diapositiva que muestra una imagen y almacena la geometría y el formato a nivel de marco, como tamaño, rotación, valores de recorte, efectos y bloqueos.

**¿Debo incrustar o enlazar imágenes?**

Incruste imágenes cuando la presentación deba ser portable, archivada o renderizada sin acceso a recursos externos. Enlace imágenes solo cuando mantener los archivos de imagen fuera del PPTX sea intencional y las ubicaciones externas puedan mantenerse de forma fiable.

**¿El recorte reduce el tamaño del archivo PPTX?**

No por sí mismo. Los ajustes de recorte normales ocultan partes de la imagen origen pero conservan los píxeles subyacentes. Use [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) o compresión de imagen con eliminación de áreas recortadas cuando esos píxeles puedan descartarse permanentemente.

**¿Puedo restaurar la calidad de la imagen después de la compresión?**

No. La compresión puede reducir la resolución raster almacenada y la eliminación de regiones recortadas descarta datos de imagen. Mantenga la imagen origen fuera de la presentación si más adelante puede requerirse una edición de alta resolución.

**¿Cómo deben gestionarse las imágenes SVG?**

Mantenga el contenido SVG como SVG cuando la fidelidad vectorial sea relevante. El [SvgImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/svgimage/) incrustado puede extraerse directamente. Renderizar una diapositiva a un formato raster como PNG o JPEG rasteriza el SVG como parte de la imagen de la diapositiva.

**¿Cómo evitar conversiones inseguras al leer diapositivas existentes?**

Compruebe el tipo de forma antes de usar miembros específicos de marcos de imagen. Una comprobación `java.instanceOf` contra [MarcoDeImagen](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) evita conversiones inválidas y permite que el código maneje diapositivas que no contengan marcos de imagen.