---
title: Optimizar la gestión de imágenes en presentaciones en Android
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/androidjava/image/
keywords:
- añadir imagen
- añadir foto
- añadir bitmap
- reemplazar imagen
- reemplazar foto
- desde web
- fondo
- añadir PNG
- añadir JPG
- añadir SVG
- añadir EMF
- añadir WMF
- añadir TIFF
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Simplifique la gestión de imágenes en PowerPoint y OpenDocument con Aspose.Slides para Android mediante Java, optimizando el rendimiento y automatizando su flujo de trabajo."
---

## **Imágenes en diapositivas de presentación**

Las imágenes hacen que las presentaciones sean más atractivas e interesantes. En Microsoft PowerPoint, puedes insertar fotos desde un archivo, internet u otras ubicaciones en las diapositivas. De forma similar, Aspose.Slides te permite agregar imágenes a las diapositivas de tus presentaciones mediante diferentes procedimientos. 

{{% alert  title="Tip" color="primary" %}} 

Aspose ofrece convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si deseas agregar una imagen como un objeto de marco—especialmente si planeas usar opciones de formato estándar para cambiar su tamaño, agregar efectos, etc.—consulta [Picture Frame](https://docs.aspose.com/slides/androidjava/picture-frame/).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Puedes manipular operaciones de entrada/salida que involucren imágenes y presentaciones de PowerPoint para convertir una imagen de un formato a otro. Consulta estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides admite operaciones con imágenes en estos formatos populares: JPEG, PNG, GIF y otros. 

## **Agregar imágenes almacenadas localmente a las diapositivas**

Puedes agregar una o varias imágenes de tu computadora a una diapositiva de una presentación. Este código de ejemplo en Java muestra cómo agregar una imagen a una diapositiva:
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
	slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **Agregar imágenes de la web a las diapositivas**

Si la imagen que deseas agregar a una diapositiva no está disponible en tu computadora, puedes añadirla directamente desde la web. 

Este código de ejemplo muestra cómo agregar una imagen desde la web a una diapositiva en Java:
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[REPLACE WITH URL]");
	URLConnection connection = imageUrl.openConnection();
	InputStream inputStream = connection.getInputStream();

	ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
	try {
		byte[] buffer = new byte[1024];
		int read;

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


## **Agregar imágenes a los maestros de diapositivas**

Un maestro de diapositivas es la diapositiva superior que almacena y controla la información (tema, diseño, etc.) de todas las diapositivas bajo él. Por lo tanto, cuando agregas una imagen a un maestro de diapositivas, esa imagen aparece en cada diapositiva bajo ese maestro. 

Este código de ejemplo en Java muestra cómo agregar una imagen a un maestro de diapositivas:
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **Agregar imágenes como fondos de diapositivas**

Puedes decidir usar una foto como fondo para una diapositiva específica o varias diapositivas. En ese caso, debes consultar *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Agregar SVG a presentaciones**
Puedes agregar o insertar cualquier imagen en una presentación usando el método [addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) que pertenece a la interfaz [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

Para crear un objeto de imagen basado en una imagen SVG, puedes hacerlo de esta manera:

1. Crear un objeto SvgImage para insertarlo en ImageShapeCollection
2. Crear un objeto PPImage a partir de ISvgImage
3. Crear un objeto PictureFrame usando la interfaz IPPImage

Este código de ejemplo muestra cómo implementar los pasos anteriores para agregar una imagen SVG a una presentación:
```java
// Instanciar la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
            ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Convertir SVG a un conjunto de formas**
La conversión de SVG a un conjunto de formas de Aspose.Slides es similar a la funcionalidad de PowerPoint utilizada para trabajar con imágenes SVG:

![Menú emergente de PowerPoint](img_01_01.png)

La funcionalidad se proporciona mediante una de las sobrecargas del método [addGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) de la interfaz [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) que acepta un objeto [ISvgImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgImage) como primer argumento.

Este código de ejemplo muestra cómo usar el método descrito para convertir un archivo SVG a un conjunto de formas:
```java 
// Crear nueva presentación
IPresentation presentation = new Presentation();
try {
    // Leer contenido del archivo SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Crear objeto SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Obtener tamaño de la diapositiva
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Convertir imagen SVG a grupo de formas escalándola al tamaño de la diapositiva
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Guardar la presentación en formato PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Agregar imágenes como EMF a las diapositivas**
Aspose.Slides para Android mediante Java permite generar imágenes EMF a partir de hojas de Excel y agregar las imágenes como EMF en diapositivas con Aspose.Cells. 

Este código de ejemplo muestra cómo realizar la tarea descrita:
```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Guardar el libro en el flujo
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Reemplazar imágenes en la colección de imágenes**

Aspose.Slides te permite reemplazar imágenes almacenadas en la colección de imágenes de una presentación (incluidas las utilizadas por las formas de diapositiva). Esta sección muestra varios enfoques para actualizar imágenes en la colección. La API proporciona métodos sencillos para reemplazar una imagen usando datos de bytes sin procesar, una instancia [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) o otra imagen que ya exista en la colección.

Sigue los pasos a continuación:

1. Carga el archivo de presentación que contiene imágenes usando la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Carga una nueva imagen desde un archivo en un arreglo de bytes.
1. Reemplaza la imagen objetivo con la nueva imagen usando el arreglo de bytes.
1. En el segundo enfoque, carga la imagen en un objeto [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) y reemplaza la imagen objetivo con ese objeto.
1. En el tercer enfoque, reemplaza la imagen objetivo con una imagen que ya exista en la colección de imágenes de la presentación.
1. Guarda la presentación modificada como un archivo PPTX.
```java
// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation("sample.pptx");
try {
    // La primera forma.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // La segunda forma.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // La tercera forma.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Guardar la presentación en un archivo.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}

Usando el conversor GRATUITO de Aspose [Text to GIF](https://products.aspose.app/slides/text-to-gif), puedes animar textos fácilmente, crear GIFs a partir de textos, etc. 

{{% /alert %}}

## **FAQ**

**¿Se mantiene la resolución original de la imagen después de insertarla?**

Sí. Los píxeles originales se conservan, pero la apariencia final depende de cómo se escale la [picture](/slides/es/androidjava/picture-frame/) en la diapositiva y de cualquier compresión aplicada al guardar.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en decenas de diapositivas a la vez?**

Coloca el logotipo en la diapositiva maestra o en un diseño y reemplázalo en la colección de imágenes de la presentación; las actualizaciones se propagarán a todos los elementos que usan ese recurso.

**¿Puede un SVG insertado convertirse en formas editables?**

Sí. Puedes convertir un SVG en un grupo de formas, después de lo cual cada parte individual se vuelve editable con las propiedades estándar de forma.

**¿Cómo puedo establecer una imagen como fondo para varias diapositivas a la vez?**

[Asigna la imagen como fondo](/slides/es/androidjava/presentation-background/) en la diapositiva maestra o en el diseño correspondiente; cualquier diapositiva que use ese maestro/diseño heredará el fondo.

**¿Cómo evito que la presentación "infle" de tamaño por muchas imágenes?**

Reutiliza un solo recurso de imagen en lugar de duplicados, elige resoluciones razonables, aplica compresión al guardar y mantén los gráficos repetidos en la maestra cuando sea apropiado.