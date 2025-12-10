---
title: Administrar Marcos de Imagen en Presentaciones con Java
linktitle: Marco de Imagen
type: docs
weight: 10
url: /es/java/picture-frame/
keywords:
- marco de imagen
- agregar marco de imagen
- crear marco de imagen
- agregar imagen
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
- Java
- Aspose.Slides
description: "Agregue marcos de imagen a presentaciones de PowerPoint y OpenDocument con Aspose.Slides para Java. Optimice su flujo de trabajo y mejore el diseño de las diapositivas."
---

Un marco de imagen es una forma que contiene una imagen—es como una foto dentro de un marco.  

Puede agregar una imagen a una diapositiva mediante un marco de imagen. De esta manera, puede formatear la imagen formateando el marco de imagen.

{{% alert  title="Tip" color="primary" %}} 

Aspose ofrece convertidores gratuitos—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

## **Crear un Marco de Imagen**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Obtenga la referencia de una diapositiva mediante su índice.  
3. Cree un objeto [IPPImage]() añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) asociada con el objeto de presentación que se utilizará para rellenar la forma.  
4. Especifique el ancho y la altura de la imagen.  
5. Cree un [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) basado en el ancho y la altura de la imagen mediante el método `AddPictureFrame` expuesto por el objeto de forma asociado con la diapositiva referenciada.  
6. Añada un marco de imagen (que contiene la foto) a la diapositiva.  
7. Guarde la presentación modificada como un archivo PPTX.  

Este código Java le muestra cómo crear un marco de imagen:
```java
// Instancia la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancia la clase Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Añade un marco de imagen con la altura y ancho equivalentes de la imagen
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Guarda el archivo PPTX en disco
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}} 

Los marcos de imagen le permiten crear diapositivas de presentación rápidamente a partir de imágenes. Cuando combina el marco de imagen con las opciones de guardado de Aspose.Slides, puede manipular operaciones de entrada/salida para convertir imágenes de un formato a otro. Es posible que desee consultar estas páginas: convertir [image to JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); convertir [JPG to image](https://products.aspose.com/slides/java/conversion/jpg-to-image/); convertir [JPG to PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/), convertir [PNG to JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); convertir [PNG to SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/), convertir [SVG to PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/). 

{{% /alert %}}

## **Crear un Marco de Imagen con Escala Relativa**

Al alterar la escala relativa de una imagen, puede crear un marco de imagen más complejo.  

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Obtenga la referencia de una diapositiva mediante su índice.  
3. Añada una imagen a la colección de imágenes de la presentación.  
4. Cree un objeto [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) asociada con el objeto de presentación que se utilizará para rellenar la forma.  
5. Especifique el ancho y la altura relativos de la imagen en el marco de imagen.  
6. Guarde la presentación modificada como un archivo PPTX.  

Este código Java le muestra cómo crear un marco de imagen con escala relativa:
```java
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanciar la clase Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Agregar marco de imagen con altura y ancho equivalentes de la imagen
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Establecer escala relativa de altura y ancho
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Guardar el archivo PPTX en disco
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Extraer Imágenes Raster de Marcos de Imagen**

Puede extraer imágenes raster de objetos [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) y guardarlas en PNG, JPG y otros formatos. El ejemplo de código a continuación muestra cómo extraer una imagen del documento “sample.pptx” y guardarla en formato PNG.  
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


## **Extraer Imágenes SVG de Marcos de Imagen**

Cuando una presentación contiene gráficos SVG colocados dentro de formas [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/), Aspose.Slides for Java le permite recuperar las imágenes vectoriales originales con fidelidad total. Al recorrer la colección de formas de la diapositiva, puede identificar cada [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/), comprobar si el [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) subyacente contiene contenido SVG y, a continuación, guardar esa imagen en disco o en un flujo en su formato SVG nativo.  

El siguiente ejemplo de código muestra cómo extraer una imagen SVG de un marco de imagen:
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


## **Obtener la Transparencia de una Imagen**

Aspose.Slides le permite obtener el efecto de transparencia aplicado a una imagen. Este código Java demuestra la operación:
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


## **Formato de Marcos de Imagen**

Aspose.Slides ofrece muchas opciones de formato que pueden aplicarse a un marco de imagen. Con esas opciones, puede modificar un marco de imagen para que cumpla requisitos específicos.  

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Obtenga la referencia de una diapositiva mediante su índice.  
3. Cree un objeto [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) asociada con el objeto de presentación que se utilizará para rellenar la forma.  
4. Especifique el ancho y la altura de la imagen.  
5. Cree un `PictureFrame` basado en el ancho y la altura de la imagen mediante el método [AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) expuesto por el objeto [IShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) asociado con la diapositiva referenciada.  
6. Añada el marco de imagen (que contiene la foto) a la diapositiva.  
7. Establezca el color de línea del marco de imagen.  
8. Establezca el ancho de línea del marco de imagen.  
9. Gire el marco de imagen proporcionando un valor positivo o negativo.  
   * Un valor positivo gira la imagen en sentido horario.  
   * Un valor negativo gira la imagen en sentido antihorario.  
10. Añada el marco de imagen (que contiene la foto) a la diapositiva.  
11. Guarde la presentación modificada como un archivo PPTX.  

Este código Java demuestra el proceso de formato de marcos de imagen:
```java
// Instancia la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancia la clase Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Agrega un marco de imagen con la altura y anchura equivalentes de la imagen
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

Aspose desarrolló recientemente un [free Collage Maker](https://products.aspose.app/slides/collage). Si alguna vez necesita [combinar JPG/JPEG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG, [crear cuadrículas a partir de fotos](https://products.aspose.app/slides/collage/photo-grid), puede usar este servicio. 

{{% /alert %}}

## **Agregar una Imagen como Enlace**

Para evitar tamaños de presentación grandes, puede agregar imágenes (o videos) a través de enlaces en lugar de incrustar los archivos directamente en las presentaciones. Este código Java muestra cómo agregar una imagen y un video en un marcador de posición:
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


## **Recortar Imágenes**

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

    // Recorta la imagen (valores porcentuales)
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


## **Eliminar Áreas Recortadas de un Marco de Imagen**

Si desea eliminar las áreas recortadas de una imagen contenida en un marco, puede usar el método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Este método devuelve la imagen recortada o la imagen original si el recorte no es necesario.  

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

El método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) agrega la imagen recortada a la colección de imágenes de la presentación. Si la imagen se usa solo en el [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) procesado, esta configuración puede reducir el tamaño de la presentación. De lo contrario, el número de imágenes en la presentación resultante aumentará.  

Este método convierte archivos metafile WMF/EMF a imágenes PNG raster en la operación de recorte. 

{{% /alert %}}

## **Bloquear Proporción de Aspecto**

Si desea que una forma que contiene una imagen mantenga su proporción de aspecto incluso después de cambiar las dimensiones de la imagen, puede usar el método [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) para establecer la configuración *Lock Aspect Ratio*.  

Este código Java muestra cómo bloquear la proporción de aspecto de una forma:
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

    // establecer que la forma preserve la proporción de aspecto al redimensionar
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 

Esta configuración *Lock Aspect Ratio* conserva solo la proporción de aspecto de la forma y no la de la imagen que contiene. 

{{% /alert %}}

## **Usar la Propiedad StretchOff**

Usando las propiedades [StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) y [StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) y de la clase [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat), puede especificar un rectángulo de relleno.  

Cuando se especifica el estiramiento para una imagen, un rectángulo fuente se escala para ajustarse al rectángulo de relleno especificado. Cada borde del rectángulo de relleno se define mediante un desplazamiento porcentual desde el borde correspondiente del cuadro delimitador de la forma. Un porcentaje positivo indica una inserción mientras que un porcentaje negativo indica una expansión.  

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentatio) class.  
2. Obtenga la referencia de una diapositiva mediante su índice.  
3. Añada un rectángulo `AutoShape`.  
4. Cree una imagen.  
5. Establezca el tipo de relleno de la forma.  
6. Establezca el modo de relleno de imagen de la forma.  
7. Añada una imagen establecida para rellenar la forma.  
8. Especifique los desplazamientos de la imagen desde el borde correspondiente del cuadro delimitador de la forma.  
9. Guarde la presentación modificada como un archivo PPTX.  

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

    // Agrega un AutoShape configurado como Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Establece el tipo de relleno de la forma
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Establece el modo de relleno de imagen de la forma
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Establece la imagen para rellenar la forma
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Especifica los desplazamientos de la imagen desde el borde correspondiente del cuadro delimitador de la forma
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

**¿Cómo puedo averiguar qué formatos de imagen son compatibles con PictureFrame?**

Aspose.Slides admite tanto imágenes raster (PNG, JPEG, BMP, GIF, etc.) como imágenes vectoriales (por ejemplo, SVG) a través del objeto de imagen asignado a un [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/). La lista de formatos compatibles generalmente se superpone con las capacidades del motor de conversión de diapositivas e imágenes.

**¿Cómo afectará la incorporación de decenas de imágenes grandes al tamaño y rendimiento del PPTX?**

Incrustar imágenes grandes aumenta el tamaño del archivo y el uso de memoria; enlazar imágenes ayuda a mantener bajo el tamaño de la presentación pero requiere que los archivos externos permanezcan accesibles. Aspose.Slides permite agregar imágenes mediante enlace para reducir el tamaño del archivo.

**¿Cómo puedo bloquear un objeto de imagen para que no se mueva o redimensione accidentalmente?**

Utilice [shape locks](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) para un [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) (por ejemplo, deshabilitar mover o redimensionar). El mecanismo de bloqueo se describe para formas en un artículo de [protección](/slides/es/java/applying-protection-to-presentation/) separado y es compatible con varios tipos de forma, incluido [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/).

**¿Se conserva la fidelidad vectorial SVG al exportar una presentación a PDF/imágenes?**

Aspose.Slides permite extraer un SVG de un [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) como el vector original. Al [exportar a PDF](/slides/es/java/convert-powerpoint-to-pdf/) o a [formatos raster](/slides/es/java/convert-powerpoint-to-png/), el resultado puede rasterizarse según la configuración de exportación; el hecho de que el SVG original se almacene como vector se confirma mediante el comportamiento de extracción.