---
title: Gestionar marcos de imagen en presentaciones en Android
linktitle: Marco de imagen
type: docs
weight: 10
url: /es/androidjava/picture-frame/
keywords:
- marco de imagen
- añadir marco de imagen
- crear marco de imagen
- añadir imagen
- crear imagen
- extraer imagen
- imagen raster
- imagen vectorial
- recortar imagen
- área recortada
- propiedad StretchOff
- formato de marco de imagen
- propiedades del marco de imagen
- escala relativa
- efecto de imagen
- relación de aspecto
- transparencia de imagen
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Añade marcos de imagen a presentaciones PowerPoint y OpenDocument con Aspose.Slides para Android mediante Java. Optimiza tu flujo de trabajo y mejora el diseño de las diapositivas."
---
## **Introducción**

Un marco de imagen es una forma que contiene una imagen; es como una foto dentro de un marco.

Puedes añadir una imagen a una diapositiva mediante un marco de imagen. De esta forma, formateas la imagen formateando el marco de imagen.

{{% alert  title="Tip" color="primary" %}} 

Aspose ofrece conversores gratuitos—[JPEG to PowerPoint](https://products.aspose.app/slides/es/import/jpg-to-ppt) y [PNG to PowerPoint](https://products.aspose.app/slides/es/import/png-to-ppt)—que permiten crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

## **Crear un marco de imagen**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva mediante su índice. 
3. Crea un objeto [IPPImage]() añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IImageCollection) asociada al objeto de presentación que se usará para rellenar la forma.
4. Especifica el ancho y alto de la imagen.
5. Crea un [PictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/PictureFrame) basado en el ancho y alto de la imagen mediante el método `AddPictureFrame` expuesto por el objeto de forma asociado a la diapositiva referenciada.
6. Añade un marco de imagen (que contiene la foto) a la diapositiva.
7. Guarda la presentación modificada como un archivo PPTX.

Este código Java muestra cómo crear un marco de imagen:

```java
// Instancia la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancia la clase Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Añade un marco de imagen con la altura y anchura equivalentes de la imagen
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Escribe el archivo PPTX en disco
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Crear un marco de imagen con escala relativa**

Al modificar la escala relativa de una imagen, puedes crear un marco de imagen más complejo. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva mediante su índice. 
3. Añade una imagen a la colección de imágenes de la presentación.
4. Crea un objeto [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPPImage) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IImageCollection) asociada al objeto de presentación que se usará para rellenar la forma.
5. Especifica el ancho y alto relativos de la imagen en el marco de imagen.
6. Guarda la presentación modificada como un archivo PPTX.

Este código Java muestra cómo crear un marco de imagen con escala relativa:

```java
// Instancia la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancia la clase Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Añade un marco de imagen con la altura y anchura equivalentes de la imagen
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Establece la escala relativa de anchura y altura
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Escribe el archivo PPTX en disco
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extraer imágenes raster de marcos de imagen**

Puedes extraer imágenes raster de objetos [PictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/PictureFrame) y guardarlas en PNG, JPG y otros formatos. El ejemplo de código a continuación demuestra cómo extraer una imagen del documento "sample.pptx" y guardarla en formato PNG.

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

## **Extraer imágenes SVG de marcos de imagen**

Cuando una presentación contiene gráficos SVG insertados dentro de formas [PictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pictureframe/), Aspose.Slides para Android mediante Java permite recuperar las imágenes vectoriales originales con plena fidelidad. Al recorrer la colección de formas de la diapositiva, puedes identificar cada [PictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pictureframe/), comprobar si el [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/) subyacente contiene contenido SVG y, a continuación, guardar esa imagen en disco o en un flujo en su formato SVG nativo.

El siguiente ejemplo de código demuestra cómo extraer una imagen SVG de un marco de imagen:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Obtener la transparencia de una imagen**

Aspose.Slides permite obtener el efecto de transparencia aplicado a una imagen. Este código Java demuestra la operación:

```java
Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **Obtener brillo y contraste de una imagen**

Aspose.Slides permite obtener el efecto de brillo y contraste aplicado a una imagen. La interfaz [ILuminance](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iluminance/) representa este efecto de transformación de imagen.

Este código Java muestra cómo obtener los valores de brillo y contraste de un marco de imagen:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Formato de marcos de imagen**

Aspose.Slides ofrece muchas opciones de formato que pueden aplicarse a un marco de imagen. Con esas opciones, puedes modificar un marco de imagen para que cumpla requisitos específicos.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva mediante su índice. 
3. Crea un objeto [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPPImage) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IImageCollection) asociada al objeto de presentación que se usará para rellenar la forma.
4. Especifica el ancho y alto de la imagen.
5. Crea un `PictureFrame` basado en el ancho y alto de la imagen mediante el método [AddPictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) expuesto por el objeto [IShapes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IShapeCollection) asociado a la diapositiva referenciada.
6. Añade el marco de imagen (que contiene la foto) a la diapositiva.
7. Establece el color de línea del marco de imagen.
8. Establece el ancho de línea del marco de imagen.
9. Gira el marco de imagen asignándole un valor positivo o negativo.  
   * Un valor positivo gira la imagen en sentido horario.  
   * Un valor negativo gira la imagen en sentido antihorario.
10. Añade el marco de imagen (que contiene la foto) a la diapositiva.
11. Guarda la presentación modificada como un archivo PPTX.

Este código Java demuestra el proceso de formato de marcos de imagen:

```java
// Instancia la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancia la clase Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Añade un marco de imagen con la altura y anchura equivalentes de la imagen
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Aplica algo de formato a PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Escribe el archivo PPTX en disco
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}

Aspose ha desarrollado recientemente un [Collage Maker gratuito](https://products.aspose.app/slides/es/collage). Si alguna vez necesitas [combinar imágenes JPG/JPEG](https://products.aspose.app/slides/es/collage/jpg) o PNG, o [crear cuadrículas a partir de fotos](https://products.aspose.app/slides/es/collage/photo-grid), puedes usar este servicio. 

{{% /alert %}}

## **Añadir una imagen como enlace**

Para evitar presentaciones de gran tamaño, puedes añadir imágenes (o videos) mediante enlaces en lugar de incrustar los archivos directamente en la presentación. Este código Java muestra cómo añadir una imagen y un vídeo a un marcador de posición:

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

## **Recortar imágenes**

Este código Java muestra cómo recortar una imagen existente en una diapositiva:

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

    // Añade un PictureFrame a una diapositiva
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

## **Eliminar áreas recortadas de una imagen**

Si deseas eliminar las áreas recortadas de una imagen contenida en un marco, puedes usar el método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Este método devuelve la imagen recortada o la imagen original si el recorte no es necesario.

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

{{% alert title="NOTE" color="warning" %}} 

El método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) añade la imagen recortada a la colección de imágenes de la presentación. Si la imagen se usa únicamente en el [PictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pictureframe/) procesado, esta configuración puede reducir el tamaño de la presentación. De lo contrario, el número de imágenes en la presentación resultante aumentará.

Este método convierte metarchivos WMF/EMF a imágenes PNG raster en la operación de recorte. 

{{% /alert %}}

## **Comprimir imágenes**

Puedes comprimir una imagen en una presentación usando el método [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) .
Este método comprime una imagen reduciendo su tamaño en función del tamaño de la forma y la resolución especificada, con la opción de eliminar áreas recortadas.

Ajusta el tamaño y la resolución de la imagen de forma similar a la función **Formato de imagen > Comprimir imágenes > Resolución** de PowerPoint.

Los siguientes ejemplos Java demuestran cómo comprimir una imagen en una presentación especificando una resolución objetivo y, opcionalmente, eliminando áreas recortadas:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Comprime la imagen con una resolución objetivo de 150 DPI (resolución web) y elimina las áreas recortadas.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Comprueba el resultado de la compresión.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O usando directamente un valor DPI personalizado:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Comprime la imagen a 150 DPI (resolución web), eliminando áreas recortadas.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

El método convierte la imagen a una resolución inferior en función del tamaño de la forma y el DPI proporcionado. También pueden eliminarse las regiones recortadas para optimizar el tamaño del archivo.  
Si la imagen es un metarchivo (WMF/EMF) o SVG, no se aplicará compresión. Además, la calidad JPEG se conserva o se reduce ligeramente según la resolución, de manera similar a cómo PowerPoint gestiona los JPEG de alta resolución.

{{% /alert %}}

## **Bloquear relación de aspecto**

Si deseas que una forma que contiene una imagen mantenga su relación de aspecto incluso después de cambiar las dimensiones de la imagen, puedes usar el método [setAspectRatioLocked](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) para establecer la opción *Bloquear relación de aspecto*.

Este código Java muestra cómo bloquear la relación de aspecto de una forma:

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

    // establecer forma para que preserve la relación de aspecto al redimensionar
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Esta configuración *Bloquear relación de aspecto* preserva solo la relación de aspecto de la forma y no la de la imagen que contiene.

{{% /alert %}}

## **Usar la propiedad StretchOff**

Utilizando las propiedades [StretchOffsetLeft](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) y [StretchOffsetBottom](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPictureFillFormat) y de la clase [PictureFillFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPictureFillFormat), puedes especificar un rectángulo de relleno.

Cuando se especifica un estiramiento para una imagen, un rectángulo origen se escala para ajustarse al rectángulo de relleno especificado. Cada borde del rectángulo de relleno se define mediante un desplazamiento porcentual respecto al borde correspondiente del cuadro delimitador de la forma. Un porcentaje positivo indica una inserción, mientras que un porcentaje negativo indica una expansión.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva mediante su índice.
3. Añade un rectángulo `AutoShape`. 
4. Crea una imagen.
5. Establece el tipo de relleno de la forma.
6. Establece el modo de relleno de imagen de la forma.
7. Añade la imagen establecida para rellenar la forma.
8. Especifica los desplazamientos de la imagen respecto al borde correspondiente del cuadro delimitador de la forma.
9. Guarda la presentación modificada como un archivo PPTX.

Este código Java demuestra un proceso en el que se usa la propiedad StretchOff:

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

    // Añade una AutoShape configurada como Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Establece el tipo de relleno de la forma
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Establece el modo de relleno de imagen de la forma
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Establece la imagen para rellenar la forma
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Especifica los desplazamientos de la imagen respecto al borde correspondiente del cuadro delimitador de la forma
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    //Escribe el archivo PPTX en disco
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**¿Cómo puedo saber qué formatos de imagen son compatibles con PictureFrame?**

Aspose.Slides soporta tanto imágenes raster (PNG, JPEG, BMP, GIF, etc.) como imágenes vectoriales (por ejemplo, SVG) a través del objeto de imagen que se asigna a un [PictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pictureframe/). La lista de formatos admitidos suele coincidir con las capacidades del motor de conversión de diapositivas e imágenes.

**¿Cómo afectará la incorporación de decenas de imágenes grandes al tamaño y rendimiento del PPTX?**

Incrustar imágenes grandes aumenta el tamaño del archivo y el consumo de memoria; enlazar imágenes ayuda a mantener reducido el tamaño de la presentación pero requiere que los archivos externos permanezcan accesibles. Aspose.Slides permite añadir imágenes mediante enlaces para reducir el tamaño del archivo.

**¿Cómo puedo bloquear un objeto de imagen para que no se mueva o redimensione accidentalmente?**

Utiliza los [bloqueos de forma](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) para un [PictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pictureframe/) (por ejemplo, desactivar el movimiento o el cambio de tamaño). El mecanismo de bloqueo es compatible con varios tipos de forma, incluido [PictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pictureframe/).

**¿Se conserva la fidelidad vectorial del SVG al exportar una presentación a PDF/imágenes?**

Aspose.Slides permite extraer un SVG de un [PictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pictureframe/) como el vector original. Al [exportar a PDF](/slides/es/androidjava/convert-powerpoint-to-pdf/) o a [formatos raster](/slides/es/androidjava/convert-powerpoint-to-png/), el resultado puede rasterizarse según la configuración de exportación; el hecho de que el SVG original se almacene como vector se confirma mediante el comportamiento de extracción.