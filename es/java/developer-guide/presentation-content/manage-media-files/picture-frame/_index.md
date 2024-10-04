---
title: Marco de Imagen
type: docs
weight: 10
url: /java/picture-frame/
keywords: "Agregar marco de imagen, crear marco de imagen, agregar imagen, crear imagen, extraer imagen, propiedad StretchOff, formato de marco de imagen, propiedades de marco de imagen, presentación de PowerPoint, Java, Aspose.Slides para Java"
description: "Agregar un marco de imagen a una presentación de PowerPoint en Java"

---

Un marco de imagen es una forma que contiene una imagen; es como una imagen en un marco.

Puedes agregar una imagen a una diapositiva a través de un marco de imagen. De esta manera, puedes formatear la imagen formateando el marco de imagen.

{{% alert  title="Consejo" color="primary" %}} 

Aspose proporciona convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten a las personas crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

## **Crear Marco de Imagen**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtén una referencia de la diapositiva a través de su índice. 
3. Crea un objeto [IPPImage]() agregando una imagen a la colección [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) asociada al objeto de presentación que se utilizará para llenar la forma.
4. Especifica la anchura y altura de la imagen.
5. Crea un [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) basado en la anchura y altura de la imagen a través del método `AddPictureFrame` expuesto por el objeto de forma asociado con la diapositiva referenciada.
6. Agrega un marco de imagen (contiene la imagen) a la diapositiva.
7. Escribe la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo crear un marco de imagen:

```java
// Instancia la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancia la clase Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Agrega un marco de imagen con la altura y ancho equivalentes de la imagen
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Escribe el archivo PPTX en el disco
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

Los marcos de imagen permiten crear rápidamente diapositivas de presentación basadas en imágenes. Cuando combinas el marco de imagen con las opciones de guardado de Aspose.Slides, puedes manipular las operaciones de entrada/salida para convertir imágenes de un formato a otro. Quizás quieras ver estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/java/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).

{{% /alert %}}

## **Crear Marco de Imagen con Escala Relativa**

Al alterar la escala relativa de una imagen, puedes crear un marco de imagen más complicado. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtén una referencia de la diapositiva a través de su índice. 
3. Agrega una imagen a la colección de imágenes de la presentación.
4. Crea un objeto [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) agregando una imagen a la colección [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) asociada al objeto de presentación que se utilizará para llenar la forma.
5. Especifica la anchura y altura relativas de la imagen en el marco de imagen.
6. Escribe la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo crear un marco de imagen con escala relativa:

```java
// Instancia la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancia la clase Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Agrega un marco de imagen con la altura y ancho equivalentes de la imagen
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Configuración de la escala relativa de anchura y altura
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Escribe el archivo PPTX en el disco
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extraer Imagen de un Marco de Imagen**

Puedes extraer imágenes de objetos [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) y guardarlas en formatos PNG, JPG y otros. El siguiente ejemplo de código muestra cómo extraer una imagen del documento "sample.pptx" y guardarla en formato PNG.

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
                IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
                slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
            } finally {
                     if (slideImage != null) slideImage.dispose();
                 }
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Obtener Transparencia de la Imagen**

Aspose.Slides te permite obtener la transparencia de una imagen. Este código Java demuestra la operación:

```java
Presentation presentation = new Presentation(folderPath + "Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Transparencia de la imagen: " + transparencyValue);
    }
}
```

## **Formateo de Marco de Imagen**

Aspose.Slides proporciona muchas opciones de formato que se pueden aplicar a un marco de imagen. Utilizando estas opciones, puedes alterar un marco de imagen para que cumpla con requisitos específicos.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtén una referencia de la diapositiva a través de su índice. 
3. Crea un objeto [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) agregando una imagen a la colección [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) asociada al objeto de presentación que se utilizará para llenar la forma.
4. Especifica la anchura y altura de la imagen.
5. Crea un `PictureFrame` basado en la anchura y altura de la imagen a través del método [AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) expuesto por el objeto [IShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) asociado con la diapositiva referenciada.
6. Agrega el marco de imagen (contiene la imagen) a la diapositiva.
7. Establece el color de línea del marco de imagen.
8. Establece el ancho de línea del marco de imagen.
9. Rota el marco de imagen dándole un valor positivo o negativo.
   * Un valor positivo rota la imagen en el sentido de las agujas del reloj. 
   * Un valor negativo rota la imagen en el sentido contrario a las agujas del reloj.
10. Agrega el marco de imagen (contiene la imagen) a la diapositiva.
11. Escribe la presentación modificada como un archivo PPTX.

Este código Java demuestra el proceso de formateo del marco de imagen:

```java
// Instancia la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancia la clase Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Agrega un marco de imagen con la altura y ancho equivalentes de la imagen
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Aplica algunos formatos a PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Escribe el archivo PPTX en el disco
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Consejo" color="primary" %}}

Aspose desarrolló recientemente un [Creador de Collages gratuito](https://products.aspose.app/slides/collage). Si alguna vez necesitas [fusionar JPG/JPEG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG, [crear rejillas a partir de fotos](https://products.aspose.app/slides/collage/photo-grid), puedes usar este servicio. 

{{% /alert %}}

## **Agregar Imagen como Enlace**

Para evitar tamaños grandes de presentación, puedes agregar imágenes (o videos) a través de enlaces en lugar de incrustar los archivos directamente en las presentaciones. Este código Java te muestra cómo agregar una imagen y un video en un marcador de posición:

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Recortar Imagen**

Este código Java te muestra cómo recortar una imagen existente en una diapositiva:

```java
Presentation pres = new Presentation();
// Crea un nuevo objeto de imagen
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Agrega un marco de imagen a una diapositiva
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Recorta la imagen (valores en porcentaje)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Guarda el resultado
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Eliminar Áreas Recortadas de la Imagen

Si deseas eliminar las áreas recortadas de una imagen contenida en un marco, puedes usar el método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--). Este método devuelve la imagen recortada o la imagen original si el recorte no es necesario.

Este código Java demuestra la operación:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Obtiene el PictureFrame de la primera diapositiva
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Elimina las áreas recortadas de la imagen del PictureFrame y devuelve la imagen recortada
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Guarda el resultado
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTA" color="warning" %}} 

El método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) agrega la imagen recortada a la colección de imágenes de la presentación. Si la imagen solo se usa en el [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) procesado, esta configuración puede reducir el tamaño de la presentación. De lo contrario, el número de imágenes en la presentación resultante aumentará.

Este método convierte archivos de metadatos WMF/EMF en imágenes PNG rasterizadas en la operación de recorte. 

{{% /alert %}}

## **Bloquear la Relación de Aspecto**

Si deseas que una forma que contenga una imagen mantenga su relación de aspecto incluso después de cambiar las dimensiones de la imagen, puedes usar el método [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) para establecer la configuración de *Bloquear Relación de Aspecto*. 

Este código Java te muestra cómo bloquear la relación de aspecto de una forma:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // Establecer forma para preservar relación de aspecto al redimensionar
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTA" color="warning" %}} 

Esta configuración de *Bloquear Relación de Aspecto* preserva solo la relación de aspecto de la forma y no de la imagen que contiene.

{{% /alert %}}

## **Usar Propiedad StretchOff**

Usando las propiedades [StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) y [StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) y de la clase [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat), puedes especificar un rectángulo de llenado. 

Cuando se especifica estiramiento para una imagen, un rectángulo fuente se escala para adaptarse al rectángulo de llenado especificado. Cada borde del rectángulo de llenado se define por un desplazamiento porcentual desde el borde correspondiente del cuadro delimitador de la forma. Un porcentaje positivo especifica un inseto mientras que un porcentaje negativo especifica un outset.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega un rectángulo `AutoShape`. 
4. Crea una imagen.
5. Establece el tipo de llenado de la forma.
6. Establece el modo de llenado de imagen de la forma.
7. Agrega la imagen establecida para llenar la forma.
8. Especifica los desplazamientos de la imagen desde el borde correspondiente del cuadro delimitador de la forma.
9. Escribe la presentación modificada como un archivo PPTX.

Este código Java demuestra un proceso en el cual se utiliza una propiedad StretchOff:

```java
// Instancia la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Instancia la clase ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Agrega un AutoShape configurado como Rectángulo
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Establece el tipo de llenado de la forma
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Establece el modo de llenado de imagen de la forma
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Establece la imagen para llenar la forma
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Especifica los desplazamientos de la imagen desde el borde correspondiente del cuadro delimitador de la forma
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // Escribe el archivo PPTX en el disco
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```