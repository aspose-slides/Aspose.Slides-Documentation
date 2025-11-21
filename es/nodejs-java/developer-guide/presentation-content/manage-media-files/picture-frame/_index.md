---
title: Marco de Imagen
type: docs
weight: 10
url: /es/nodejs-java/picture-frame/
keywords:
- marco de imagen
- agregar un marco de imagen
- crear un marco de imagen
- agregar una imagen
- crear una imagen
- extraer una imagen
- recortar una imagen
- propiedad StretchOff
- formato de marco de imagen
- propiedades del marco de imagen
- efecto de imagen
- relación de aspecto
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides para Node.js vía Java
description: "Agregar un marco de imagen a una presentación de PowerPoint con JavaScript"
---

Un marco de imagen es una forma que contiene una imagen—es como una foto en un marco. 

Puede agregar una imagen a una diapositiva a través de un marco de imagen. De esta manera, puede dar formato a la imagen formateando el marco de imagen.

{{% alert  title="Tip" color="primary" %}} 

Aspose ofrece conversores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

## **Crear Marco de Imagen**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Cree un objeto `PPImage` añadiendo una imagen a la [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) asociada al objeto de presentación que se utilizará para rellenar la forma.
4. Especifique el ancho y la altura de la imagen.
5. Cree un [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame) basado en el ancho y la altura de la imagen mediante el método `addPictureFrame` expuesto por el objeto de forma asociado a la diapositiva referenciada.
6. Añada un marco de imagen (que contiene la foto) a la diapositiva.
7. Guarde la presentación modificada como un archivo PPTX.

Este código JavaScript le muestra cómo crear un marco de imagen:
```javascript
// Instancia la clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtiene la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Instancia la clase Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Añade un marco de imagen con la altura y anchura equivalentes de la imagen
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Escribe el archivo PPTX en disco
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" %}} 

Los marcos de imagen le permiten crear rápidamente diapositivas de presentación basadas en imágenes. Cuando combina el marco de imagen con las opciones de guardado de Aspose.Slides, puede manipular operaciones de entrada/salida para convertir imágenes de un formato a otro. Es posible que desee ver estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

## **Crear Marco de Imagen con Escala Relativa**

Al modificar la escala relativa de una imagen, puede crear un marco de imagen más complejo. 

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Añada una imagen a la colección de imágenes de la presentación.
4. Cree un objeto [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) añadiendo una imagen a la [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) asociada al objeto de presentación que se utilizará para rellenar la forma.
5. Especifique el ancho y la altura relativos de la imagen en el marco de imagen.
6. Guarde la presentación modificada como un archivo PPTX.

Este código JavaScript le muestra cómo crear un marco de imagen con escala relativa:
```javascript
// Instanciar la clase Presentation que representa el PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Instanciar la clase Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Añadir un Marco de Imagen con altura y anchura equivalentes de la Imagen
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Establecer escala relativa de ancho y alto
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Escribir el archivo PPTX en disco
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Extraer Imágenes Raster de Marcos de Imagen**

Puede extraer imágenes raster de objetos [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame) y guardarlas en PNG, JPG y otros formatos. El ejemplo de código a continuación muestra cómo extraer una imagen del documento "sample.pptx" y guardarla en formato PNG.
```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```


## **Extraer Imágenes SVG de Marcos de Imagen**

Cuando una presentación contiene gráficos SVG colocados dentro de formas [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), Aspose.Slides for Node.js via Java le permite recuperar las imágenes vectoriales originales con fidelidad completa. Al recorrer la colección de formas de la diapositiva, puede identificar cada [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), comprobar si el [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) subyacente contiene contenido SVG y luego guardar esa imagen en disco o en un flujo en su formato SVG nativo.

El siguiente ejemplo de código muestra cómo extraer una imagen SVG de un marco de imagen:
```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```


## **Obtener Transparencia de la Imagen**

Aspose.Slides permite obtener el efecto de transparencia aplicado a una imagen. Este código JavaScript demuestra la operación:
```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```


## **Formato de Marco de Imagen**

Aspose.Slides proporciona muchas opciones de formato que pueden aplicarse a un marco de imagen. Con esas opciones, puede modificar un marco de imagen para que cumpla requisitos específicos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Cree un objeto [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) añadiendo una imagen a la [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) asociada al objeto de presentación que se utilizará para rellenar la forma.
4. Especifique el ancho y la altura de la imagen.
5. Cree un `PictureFrame` basado en el ancho y la altura de la imagen mediante el método [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) expuesto por el objeto [Shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) asociado a la diapositiva referenciada.
6. Añada el marco de imagen (que contiene la foto) a la diapositiva.
7. Establezca el color de línea del marco de imagen.
8. Establezca el ancho de línea del marco de imagen.
9. Gire el marco de imagen asignándole un valor positivo o negativo.
   * Un valor positivo gira la imagen en sentido horario. 
   * Un valor negativo gira la imagen en sentido antihorario.
10. Añada el marco de imagen (que contiene la foto) a la diapositiva.
11. Guarde la presentación modificada como un archivo PPTX.

Este código JavaScript demuestra el proceso de formato del marco de imagen:
```javascript
// Instancia la clase Presentation que representa el PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtiene la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Instancia la clase Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Añade un marco de imagen con altura y anchura equivalentes de la imagen
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Aplica algo de formato a PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // Escribe el archivo PPTX en disco
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Tip" color="primary" %}}

Aspose desarrolló recientemente un [Collage Maker gratuito](https://products.aspose.app/slides/collage). Si alguna vez necesita [combinar JPG/JPEG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG, [crear cuadrículas a partir de fotos](https://products.aspose.app/slides/collage/photo-grid), puede usar este servicio. 

{{% /alert %}}

## **Agregar Imagen como Enlace**

Para evitar presentaciones de gran tamaño, puede agregar imágenes (o videos) mediante enlaces en lugar de incrustar los archivos directamente en la presentación. Este código JavaScript le muestra cómo agregar una imagen y un video en un marcador de posición:
```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Recortar Imagen**

Este código JavaScript le muestra cómo recortar una imagen existente en una diapositiva:
```javascript
var pres = new aspose.slides.Presentation();
// Crea un nuevo objeto de imagen
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Añade un PictureFrame a una diapositiva
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Recorta la imagen (valores en porcentaje)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // Guarda el resultado
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Eliminar Áreas Recortadas de la Imagen**

Si desea eliminar las áreas recortadas de una imagen contenida en un marco, puede usar el método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) . Este método devuelve la imagen recortada o la imagen original si el recorte no es necesario.

Este código JavaScript demuestra la operación:
```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Obtiene el PictureFrame de la primera diapositiva
    var picFrame = slide.getShapes().get_Item(0);
    // Elimina las áreas recortadas de la imagen del PictureFrame y devuelve la imagen recortada
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // Guarda el resultado
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


{{% alert title="NOTE" color="warning" %}} 

El método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) añade la imagen recortada a la colección de imágenes de la presentación. Si la imagen se usa solo en el [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) procesado, esta configuración puede reducir el tamaño de la presentación. De lo contrario, el número de imágenes en la presentación resultante aumentará.

Este método convierte metarchivos WMF/EMF a imágenes PNG raster en la operación de recorte. 

{{% /alert %}}

## **Bloquear Relación de Aspecto**

Si desea que una forma que contiene una imagen mantenga su relación de aspecto incluso después de cambiar las dimensiones de la imagen, puede usar el método [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) para establecer la configuración *Bloquear Relación de Aspecto*.

Este código JavaScript le muestra cómo bloquear la relación de aspecto de una forma:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // establecer la forma para que preserve la relación de aspecto al redimensionar
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="NOTE" color="warning" %}} 

Esta configuración *Bloquear Relación de Aspecto* conserva solo la relación de aspecto de la forma y no de la imagen que contiene.

{{% /alert %}}

## **Usar Propiedad StretchOff**

Utilizando los métodos [setStretchOffsetLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) y [setStretchOffsetBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) de la clase [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat), puede especificar un rectángulo de relleno.

Cuando se especifica estiramiento para una imagen, un rectángulo fuente se escala para ajustarse al rectángulo de relleno especificado. Cada borde del rectángulo de relleno se define mediante un desplazamiento porcentual desde el borde correspondiente del cuadro delimitador de la forma. Un porcentaje positivo indica una inserción mientras que un porcentaje negativo indica una expansión.

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentatio) clase.
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Añada un rectángulo `AutoShape`. 
4. Cree una imagen.
5. Establezca el tipo de relleno de la forma.
6. Establezca el modo de relleno de imagen de la forma.
7. Añada una imagen establecida para rellenar la forma.
8. Especifique los desplazamientos de la imagen desde el borde correspondiente del cuadro delimitador de la forma
9. Guarde la presentación modificada como un archivo PPTX.

Este código JavaScript demuestra un proceso en el que se utiliza la propiedad StretchOff:
```javascript
// Instancia la clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtiene la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Instancia la clase ImageEx
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Añade un AutoShape configurado como Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Establece el tipo de relleno de la forma
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Establece el modo de relleno de imagen de la forma
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Establece la imagen para rellenar la forma
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Especifica los desplazamientos de la imagen desde el borde correspondiente del cuadro delimitador de la forma
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // Escribe el archivo PPTX en disco
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿Cómo puedo averiguar qué formatos de imagen son compatibles con PictureFrame?**

Aspose.Slides es compatible tanto con imágenes raster (PNG, JPEG, BMP, GIF, etc.) como con imágenes vectoriales (por ejemplo, SVG) a través del objeto de imagen que se asigna a un [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/). La lista de formatos compatibles generalmente se superpone con las capacidades del motor de conversión de diapositivas e imágenes.

**¿Cómo afectará la adición de decenas de imágenes grandes al tamaño y rendimiento del PPTX?**

Incrustar imágenes grandes incrementa el tamaño del archivo y el uso de memoria; enlazar imágenes ayuda a mantener pequeño el tamaño de la presentación pero requiere que los archivos externos permanezcan accesibles. Aspose.Slides permite agregar imágenes mediante enlace para reducir el tamaño del archivo.

**¿Cómo puedo bloquear un objeto de imagen para que no se mueva o redimensione accidentalmente?**

Utilice [bloqueos de forma](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) para un [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) (por ejemplo, desactivar mover o redimensionar). El mecanismo de bloqueo se describe para formas en un [artículo de protección](/slides/es/nodejs-java/applying-protection-to-presentation/) y es compatible con varios tipos de forma, incluidos los [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/).

**¿Se conserva la fidelidad vectorial del SVG al exportar una presentación a PDF/imágenes?**

Aspose.Slides permite extraer un SVG de un [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) como el vector original. Al [exportar a PDF](/slides/es/nodejs-java/convert-powerpoint-to-pdf/) o a [formatos raster](/slides/es/nodejs-java/convert-powerpoint-to-png/), el resultado puede rasterizarse según la configuración de exportación; el hecho de que el SVG original se almacene como vector se confirma mediante el comportamiento de extracción.