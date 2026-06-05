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
- propiedades de marco de imagen
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

Un marco de imagen es una forma que contiene una imagen; es como una foto en un marco.

Puedes añadir una imagen a una diapositiva a través de un marco de imagen. De este modo, puedes dar formato a la imagen formateando el marco de imagen.

{{% alert  title="Tip" color="primary" %}} 

Aspose ofrece conversores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/es/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/es/import/png-to-ppt)—que permiten crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

## **Crear un marco de imagen**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva mediante su índice. 
3. Crea un objeto [IPPImage]() añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IImageCollection) asociada al objeto presentation que se usará para rellenar la forma.
4. Especifica el ancho y alto de la imagen.
5. Crea un [PictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/PictureFrame) basado en el ancho y alto de la imagen mediante el método `AddPictureFrame` expuesto por el objeto shape asociado a la diapositiva referenciada.
6. Añade un marco de imagen (que contiene la foto) a la diapositiva.
7. Guarda la presentación modificada como archivo PPTX.

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
4. Crea un objeto [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPPImage) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IImageCollection) asociada al objeto presentation que se usará para rellenar la forma.
5. Especifica el ancho y alto relativos de la imagen en el marco de imagen.
6. Guarda la presentación modificada como archivo PPTX.

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
    
    // Establece la escala relativa de altura y anchura
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

Puedes extraer imágenes raster de objetos [PictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/PictureFrame) y guardarlas en PNG, JPG y otros formatos. El siguiente ejemplo de código demuestra cómo extraer una imagen del documento "sample.pptx" y guardarla en formato PNG.

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

Cuando una presentación contiene gráficos SVG insertados dentro de formas [PictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pictureframe/), Aspose.Slides for Android mediante Java permite recuperar las imágenes vectoriales originales con plena fidelidad. Recorriendo la colección de formas de la diapositiva, puedes identificar cada [PictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pictureframe/), comprobar si el [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/) subyacente contiene contenido SVG y, a continuación, guardar esa imagen en disco o en un flujo en su formato SVG nativo.

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

## **Obtener la transparencia de una imagen**

Aspose.Slides permite obtener el efecto de transparencia aplicado a una imagen. Este código Java muestra la operación:

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

## **Formato de marcos de imagen**

Aspose.Slides ofrece muchas opciones de formato que pueden aplicarse a un marco de imagen. Con esas opciones, puedes modificar un marco de imagen para que cumpla requisitos específicos.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva mediante su índice. 
3. Crea un objeto [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPPImage) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IImageCollection) asociada al objeto presentation que se usará para rellenar la forma.
4. Especifica el ancho y alto de la imagen.
5. Crea un `PictureFrame` basado en el ancho y alto de la imagen mediante el método [AddPictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) expuesto por el objeto [IShapes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IShapeCollection) asociado a la diapositiva referenciada.
6. Añade el marco de imagen (que contiene la foto) a la diapositiva.
7. Establece el color de línea del marco de imagen.
8. Establece el ancho de línea del marco de imagen.
9. Gira el marco de imagen asignándole un valor positivo o negativo.
   * Un valor positivo rota la imagen en sentido horario. 
   * Un valor negativo rota la imagen en sentido antihorario.
10. Añade el marco de imagen (que contiene la foto) a la diapositiva.
11. Guarda la presentación modificada como archivo PPTX.

Este código Java muestra el proceso de formato de marcos de imagen:

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
    
    // Aplica algo de formato al PictureFrameEx
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

Aspose ha desarrollado recientemente un [fabricante de collages gratuito](https://products.aspose.app/slides/es/collage). Si necesitas [fusionar JPG/JPEG](https://products.aspose