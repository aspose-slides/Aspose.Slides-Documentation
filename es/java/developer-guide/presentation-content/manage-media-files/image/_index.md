---
title: Imagen
type: docs
weight: 10
url: /java/image/
description: Trabaja con imágenes en Diapositivas en Presentaciones de PowerPoint usando Java. Agrega imágenes desde el disco o desde la web en Diapositivas de PowerPoint usando Java. Agrega imágenes a Maestros de Diapositivas o como Fondo de Diapositiva usando Java. Agrega SVG a Presentaciones de PowerPoint usando Java. Convierte SVG a Formas en PowerPoint usando Java. Agrega imágenes como EMF en Diapositivas usando Java.
---

## **Imágenes en Diapositivas en Presentaciones**

Las imágenes hacen que las presentaciones sean más atractivas e interesantes. En Microsoft PowerPoint, puedes insertar fotos desde un archivo, internet u otras ubicaciones en las diapositivas. De manera similar, Aspose.Slides te permite agregar imágenes a las diapositivas en tus presentaciones a través de diferentes procedimientos.

{{% alert title="Consejo" color="primary" %}}

Aspose proporciona conversores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten a las personas crear presentaciones rápidamente a partir de imágenes.

{{% /alert %}}

{{% alert title="Información" color="info" %}}

Si deseas agregar una imagen como un objeto marco—especialmente si planeas usar opciones de formato estándar en ella para cambiar su tamaño, agregar efectos, etc.—consulta [Marco de Imagen](https://docs.aspose.com/slides/java/picture-frame/).

{{% /alert %}}

{{% alert title="Nota" color="warning" %}}

Puedes manipular operaciones de entrada/salida que involucran imágenes y presentaciones de PowerPoint para convertir una imagen de un formato a otro. Consulta estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/java/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides admite operaciones con imágenes en estos formatos populares: JPEG, PNG, GIF y otros.

## **Agregando Imágenes Almacenadas Localmente a Diapositivas**

Puedes agregar una o varias imágenes de tu computadora a una diapositiva en una presentación. Este código de ejemplo en Java te muestra cómo agregar una imagen a una diapositiva:

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

## **Agregando Imágenes Desde la Web a Diapositivas**

Si la imagen que deseas agregar a una diapositiva no está disponible en tu computadora, puedes agregar la imagen directamente desde la web.

Este código de ejemplo te muestra cómo agregar una imagen desde la web a una diapositiva en Java:

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

## **Agregando Imágenes a Maestros de Diapositivas**

Un maestro de diapositivas es la diapositiva superior que almacena y controla la información (tema, diseño, etc.) sobre todas las diapositivas que están debajo de ella. Así que, cuando agregas una imagen a un maestro de diapositivas, esa imagen aparece en cada diapositiva debajo de ese maestro de diapositivas.

Este código de ejemplo en Java te muestra cómo agregar una imagen a un maestro de diapositivas:

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

## **Agregando Imágenes como Fondo de Diapositiva**

Puedes decidir usar una imagen como fondo para una diapositiva específica o varias diapositivas. En ese caso, debes consultar *[Establecer Imágenes como Fondos para Diapositivas](https://docs.aspose.com/slides/java/presentation-background/#setting-images-as-background-for-slides)*.

## **Agregando SVG a Presentaciones**
Puedes agregar o insertar cualquier imagen en una presentación utilizando el método [addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) que pertenece a la interfaz [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

Para crear un objeto de imagen basado en una imagen SVG, puedes hacerlo de esta manera:

1. Crea un objeto SvgImage para insertarlo en ImageShapeCollection
2. Crea un objeto PPImage desde ISvgImage
3. Crea un objeto PictureFrame utilizando la interfaz IPPImage

Este código de ejemplo te muestra cómo implementar los pasos anteriores para agregar una imagen SVG en una presentación:
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

## **Convirtiendo SVG a un Conjunto de Formas**
La conversión de SVG a un conjunto de formas en Aspose.Slides es similar a la funcionalidad de PowerPoint utilizada para trabajar con imágenes SVG:

![Menú Popup de PowerPoint](img_01_01.png)

La funcionalidad es proporcionada por una de las sobrecargas del método [addGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) de la interfaz [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) que toma un objeto [ISvgImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgImage) como primer argumento.

Este código de ejemplo te muestra cómo usar el método descrito para convertir un archivo SVG en un conjunto de formas:

```java 
// Crear nueva presentación
IPresentation presentation = new Presentation();
try {
    // Leer el contenido del archivo SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Crear objeto SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Obtener el tamaño de la diapositiva
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Convertir la imagen SVG en un grupo de formas escalándola al tamaño de la diapositiva
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Guardar la presentación en formato PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Agregando Imágenes como EMF en Diapositivas**
Aspose.Slides para Java te permite generar imágenes EMF a partir de hojas de Excel y agregar las imágenes como EMF en diapositivas con Aspose.Cells.

Este código de ejemplo te muestra cómo realizar la tarea descrita:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Guardar el libro en un flujo
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

{{% alert title="Información" color="info" %}}

Usando el convertidor gratuito de Aspose [Texto a GIF](https://products.aspose.app/slides/text-to-gif), puedes animar fácilmente textos, crear GIFs a partir de textos, etc.

{{% /alert %}}