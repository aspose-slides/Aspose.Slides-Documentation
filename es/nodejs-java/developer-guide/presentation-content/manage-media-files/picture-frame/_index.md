---
title: Gestionar fotogramas de imagen en presentaciones usando JavaScript
linktitle: Fotograma de imagen
type: docs
weight: 10
url: /es/nodejs-java/picture-frame/
keywords:
- fotograma de imagen
- añadir fotograma de imagen
- crear fotograma de imagen
- imagen incrustada
- imagen vinculada
- extraer imagen
- imagen rasterizada
- imagen SVG
- recortar imagen
- eliminar áreas recortadas
- comprimir imagen
- StretchOffset
- formato de fotograma de imagen
- escala relativa
- efecto de imagen
- relación de aspecto
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Cree, formatee, vincule, recorte, extraiga y comprima marcos de imagen en presentaciones con Aspose.Slides para Node.js mediante JavaScript."
---
## **Visión general**

Un fotograma de imagen es una forma de diapositiva que muestra una imagen. En Aspose.Slides, el recurso de imagen y la forma que la muestra son objetos independientes: una [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) posee recursos de imagen incrustados a través de su [ImageCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagecollection/), mientras que un [PictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) controla la posición, el tamaño, el formato de línea, la rotación, el recorte, los efectos de imagen y otras configuraciones a nivel de marco.

Esta separación es útil cuando la misma imagen se muestra más de una vez. Añada la imagen a la presentación una sola vez, conserve el [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) devuelto y utilice ese recurso de imagen al crear fotogramas de imagen.

Los fotogramas pueden contener imágenes rasterizadas como PNG o JPEG y imágenes vectoriales SVG. También pueden referirse a imágenes vinculadas en lugar de almacenar los bytes de la imagen en la presentación. La elección afecta la portabilidad, el tamaño del archivo, la extracción y el comportamiento de exportación, por lo que es útil decidir cómo debe almacenarse la imagen antes de aplicar formato u optimización.

## **Añadir y dar formato a una imagen incrustada**

Para una imagen incrustada, añada los datos de la imagen a la presentación y cree un fotograma con [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). La imagen pasa a formar parte del paquete de la presentación, de modo que la presentación permanece autónoma cuando se traslada a otro equipo.

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

El fotograma controla la geometría mostrada; cambiar el tamaño del marco no modifica las dimensiones de píxel originales almacenadas en el recurso de imagen incrustada. Esta distinción es importante cuando después se recorta o comprime una imagen.

## **Utilizar escala relativa**

[PictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) expone la escala relativa de ancho y alto del marco mediante [setRelativeScaleWidth](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) y [setRelativeScaleHeight](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Un valor de `1.0` corresponde al 100 % del tamaño original de la imagen. La escala relativa es útil cuando un flujo de trabajo necesita preservar una relación con el tamaño de la imagen fuente en lugar de calcular manualmente las dimensiones finales.

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

La escala relativa modifica los ajustes de escala del marco; no vuelve a muestrear ni comprime la imagen incrustada.

## **Imágenes incrustadas y vinculadas**

Una imagen incrustada almacena los datos de la imagen dentro de la presentación y, por tanto, es la opción más segura para la portabilidad y una renderización predecible. Una imagen vinculada almacena una ubicación externa mediante el método [Picture.setLinkPathLong](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) en lugar de incrustar los datos de la imagen de la misma forma.

Las imágenes vinculadas pueden reducir la cantidad de datos almacenados en el PPTX, pero introducen una dependencia externa. El archivo vinculado debe seguir siendo accesible para la aplicación que abra o renderice la presentación. Si la ruta cambia, el archivo se mueve o el recurso no está disponible, la imagen vinculada puede no mostrarse como se espera. Para presentaciones que deben enviarse por correo, archivarse o renderizarse en entornos aislados, las imágenes incrustadas suelen ser más fiables.

### **Añadir una imagen vinculada**

El siguiente ejemplo crea un fotograma y lo apunta a un archivo de imagen local. Sólo trata el vínculo de la imagen; el vínculo de vídeo es un flujo de medios independiente y no se mezcla intencionadamente en este ejemplo.

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

Utilice vínculos cuando la gestión externa de archivos sea intencional. No los use simplemente como sustituto de la compresión: un PPTX pequeño con dependencias de imagen rotas suele ser menos útil que una presentación más grande y autónoma.

## **Extraer imágenes de fotogramas de imagen**

Antes de extraer una imagen de una presentación existente, compruebe que una forma sea realmente un [PictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) y que contenga una imagen incrustada. Los fotogramas vinculados pueden no contener bytes de imagen que puedan extraerse de la misma manera.

### **Extraer una imagen rasterizada**

La API moderna de imágenes utiliza directamente [IImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/). El siguiente ejemplo encuentra la primera imagen rasterizada incrustada en una diapositiva y la guarda como PNG:

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

Guardar mediante [IImage.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/#save) convierte la imagen extraída al formato de salida solicitado. Si necesita los bytes codificados almacenados en la presentación en lugar de un archivo rasterizado convertido, use los datos binarios del recurso de imagen.

### **Extraer una imagen SVG**

Para una imagen SVG, el [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) expone un objeto [SvgImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/svgimage/). Esto permite recuperar los datos SVG directamente en lugar de rasterizar la imagen primero.

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

Mantener el contenido SVG como SVG preserva la fuente vectorial dentro de la presentación. Las exportaciones rasterizadas como PNG o JPEG convierten necesariamente ese contenido vectorial en píxeles. La exportación de diapositivas a PDF o SVG también es una operación de renderizado, por lo que los gráficos exportados no deben considerarse una copia byte a byte del SVG incrustado original; use los datos de [SvgImage.getSvgData](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/svgimage/#getSvgData--) cuando sea necesario el recurso vectorial original.

## **Recortar una imagen**

El recorte cambia qué parte de una imagen es visible dentro del marco. Los valores de recorte en [PictureFillFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/) son porcentajes de las dimensiones de la imagen fuente. El recorte no elimina inicialmente los píxeles ocultos de la imagen incrustada; solo cambia la región visible.

El siguiente ejemplo encuentra un fotograma de manera segura y aplica valores de recorte:

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

Como los datos de la imagen oculta siguen presentes, el recorte puede modificarse más adelante sin perder los píxeles originales. Si el tamaño del archivo es más importante que la reversibilidad, las regiones recortadas pueden eliminarse físicamente como se describe en la sección siguiente.

## **Eliminar datos de imagen recortados**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) elimina los datos de imagen fuera del rectángulo de recorte actual y devuelve el recurso de imagen resultante. Esto puede reducir el tamaño del archivo, pero es una optimización destructiva: tras guardar la presentación, los píxeles eliminados ya no estarán disponibles para una operación de desrecorte posterior.

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

El método puede añadir un nuevo recurso de imagen a la presentación. Si la imagen original también se utiliza en otros fotogramas, esos fotogramas siguen necesitando su recurso existente, por lo que eliminar áreas recortadas no reduce necesariamente el número total de imágenes. Recortar contenido WMF o EMF con este método rasteriza el resultado recortado a PNG.

## **Comprimir imágenes rasterizadas**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) reduce la resolución de la imagen rasterizada en relación con el tamaño al que se muestra la foto. También puede eliminar regiones recortadas en la misma operación. El método devuelve `true` cuando la imagen se redimensionó o recortó y `false` cuando no fue necesario ningún cambio.

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

La compresión está pensada para imágenes rasterizadas. El contenido SVG y de metarchivo no se reduce con este flujo de compresión raster. También recuerde que la resolución inferior y las regiones recortadas eliminadas no pueden recuperarse de la presentación optimizada. Elija una resolución objetivo basada en el mayor tamaño al que la imagen será realmente visualizada o exportada, en lugar de aplicar el DPI más bajo de forma global.

## **Inspeccionar efectos de imagen**

Los efectos de imagen se almacenan en la imagen utilizada por el marco. La colección de transformaciones de la imagen puede contener efectos como modulación alfa fija para transparencia y luminancia para brillo y contraste. El ejemplo a continuación lee de forma segura ambos tipos de efectos del primer fotograma de una diapositiva:

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
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Estos efectos modifican la forma en que la imagen se renderiza en el marco; no reescriben los bytes originales de la imagen incrustada.

## **Bloquear la geometría del fotograma de imagen**

Los ajustes de [PictureFrameLock](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframelock/) controlan qué operaciones de edición están desactivadas para un fotograma. Por ejemplo, [setAspectRatioLocked](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) preserva las proporciones de la forma mientras se redimensiona.

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

El bloqueo se aplica a la forma del fotograma de imagen. No obliga a que la imagen fuente sea remuestreada ni cambiada permanentemente al mismo aspecto.

## **Ajustar los valores StretchOffset**

Cuando el modo de relleno de imagen es estirado, los valores stretch‑offset en [PictureFillFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/) definen el rectángulo de relleno relativo al cuadro delimitador del fotograma. Los porcentajes positivos crean una inserción desde el borde, mientras que los porcentajes negativos crean una expansión.

Esto difiere del recorte. Los valores de recorte seleccionan qué parte de la imagen fuente es visible; los stretch‑offset cambian el rectángulo en el que se estira el relleno visible de la imagen.

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

Use stretch‑offset para la posición del relleno. Use las propiedades de recorte cuando el objetivo sea ocultar los bordes de la imagen fuente.

## **Consideraciones de almacenamiento, tamaño de archivo y exportación**

Los principales compromisos son más fáciles de gestionar cuando el almacenamiento de imágenes y el formato del fotograma se tratan por separado:

- **Imágenes incrustadas** hacen que la presentación sea autónoma y son las más fiables para compartir y renderizar en servidor, pero las imágenes rasterizadas grandes aumentan el tamaño del PPTX y el uso de memoria.
- **Imágenes vinculadas** pueden mantener el paquete más pequeño, pero la presentación depende de que los archivos externos permanezcan disponibles en las rutas o ubicaciones almacenadas.
- **Recorte** es inicialmente no destructivo. Los píxeles ocultos permanecen incrustados hasta que las áreas recortadas se eliminen explícitamente o se eliminen durante la compresión.
- **Compresión** puede reducir considerablemente el tamaño del archivo para imágenes rasterizadas sobredimensionadas, pero sacrifica la resolución origen. Debe aplicarse después de conocer el tamaño final que tendrá la imagen en la diapositiva.
- **Imágenes SVG** deben permanecer como SVG cuando la preservación vectorial es importante. Extraiga el SVG incrustado directamente cuando necesite el recurso vectorial en sí. Las exportaciones raster de diapositivas siempre convierten la diapositiva renderizada a píxeles.
- **Imágenes repetidas** deben reutilizar un recurso [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) existente siempre que sea posible en lugar de cargar repetidamente el mismo archivo en el flujo de trabajo de la presentación.

Para presentaciones grandes, la optimización de imágenes suele ser más eficaz cuando se realiza de forma selectiva: mantenga logotipos y diagramas como contenido vectorial, comprima fotografías según su tamaño real de visualización, elimine píxeles recortados sólo cuando no se requiera edición posterior y evite vínculos externos salvo que la gestión de dependencias forme parte del diseño de despliegue.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un fotograma de imagen y un recurso de imagen?**

Un [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) representa un recurso de imagen asociado a la presentación. Un [PictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) es una forma en una diapositiva que muestra una imagen y almacena geometría y formato a nivel de marco, como tamaño, rotación, valores de recorte, efectos y bloqueos.

**¿Debo incrustar o vincular imágenes?**

Incruste imágenes cuando la presentación deba ser portátil, archivada o renderizada sin acceso a recursos externos. Vincule imágenes sólo cuando mantener los archivos de imagen fuera del PPTX sea intencional y las ubicaciones externas puedan mantenerse de forma fiable.

**¿El recorte reduce el tamaño del archivo PPTX?**

No por sí mismo. Los ajustes de recorte normales ocultan partes de la imagen fuente pero conservan los píxeles subyacentes. Utilice [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) o la compresión de imágenes con eliminación de áreas recortadas cuando esos píxeles puedan descartarse permanentemente.

**¿Puedo restaurar la calidad de la imagen después de la compresión?**

No. La compresión puede reducir la resolución raster almacenada y la eliminación de regiones recortadas descarta datos de imagen. Conserve la imagen fuente original fuera de la presentación si más adelante pudiera requerirse una edición en alta resolución.

**¿Cómo deben gestionarse las imágenes SVG?**

Mantenga el contenido SVG como SVG cuando la fidelidad vectorial sea importante. El [SvgImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/svgimage/) incrustado puede extraerse directamente. Renderizar una diapositiva a un formato raster como PNG o JPEG rasteriza el SVG como parte de la imagen de la diapositiva.

**¿Cómo evitar conversiones inseguras al leer diapositivas existentes?**

Compruebe el tipo de forma antes de usar miembros específicos de fotogramas. Una comprobación `java.instanceOf` contra [PictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) evita conversiones inválidas y permite al código gestionar diapositivas que no contengan fotogramas de imagen.