---
title: Optimizar la gestión de imágenes en presentaciones con JavaScript
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/nodejs-java/image/
keywords:
- añadir imagen
- añadir foto
- añadir mapa de bits
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
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "Simplifique la gestión de imágenes en PowerPoint y OpenDocument con JavaScript y Aspose.Slides para Node.js, optimizando el rendimiento y automatizando su flujo de trabajo."
---

## **Imágenes en diapositivas en presentaciones**

Las imágenes hacen que las presentaciones sean más atractivas e interesantes. En Microsoft PowerPoint, puedes insertar imágenes desde un archivo, internet u otras ubicaciones en las diapositivas. De forma similar, Aspose.Slides permite añadir imágenes a las diapositivas de tus presentaciones mediante diferentes procedimientos. 

{{% alert  title="Tip" color="primary" %}} 

Aspose proporciona convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si deseas añadir una imagen como objeto de marco —especialmente si planeas usar opciones de formato estándar para cambiar su tamaño, añadir efectos, etc.— consulta [Picture Frame](https://docs.aspose.com/slides/nodejs-java/picture-frame/).

{{% /alert %}} 

Aspose.Slides admite operaciones con imágenes en estos formatos populares: JPEG, PNG, GIF y otros. 

## **Añadir imágenes almacenadas localmente a diapositivas**

Puedes añadir una o varias imágenes de tu ordenador a una diapositiva en una presentación. Este código de ejemplo en JavaScript muestra cómo añadir una imagen a una diapositiva:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Añadir imágenes desde el flujo a diapositivas**

Si la imagen que deseas añadir a una diapositiva no está disponible en tu ordenador, puedes añadirla directamente desde la web. 

Este código de ejemplo muestra cómo añadir una imagen desde la web a una diapositiva en JavaScript:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Accede a la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Carga un archivo de Excel a un flujo
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // Crea un objeto de datos para incrustar
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Añade una forma de marco de objeto Ole
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // Escribe el archivo PPTX en disco
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Añadir imágenes a maestros de diapositivas**

Un maestro de diapositivas es la diapositiva superior que almacena y controla la información (tema, diseño, etc.) de todas las diapositivas bajo ella. Por lo tanto, cuando añades una imagen a un maestro de diapositivas, esa imagen aparece en cada diapositiva bajo ese maestro. 

Este JavaScript sample code muestra cómo añadir una imagen a un maestro de diapositivas:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Añadir imágenes como fondo de diapositiva**

Puedes decidir usar una imagen como fondo de una diapositiva específica o de varias diapositivas. En ese caso, debes consultar *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Añadir SVG a presentaciones**
Puedes añadir o insertar cualquier imagen en una presentación utilizando el método [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) que pertenece a la clase [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection). 

Para crear un objeto de imagen a partir de una imagen SVG, puedes hacerlo de esta manera:

1. Crear un objeto SvgImage para insertarlo en ImageShapeCollection
2. Crear un objeto PPImage a partir de ISvgImage
3. Crear un objeto PictureFrame utilizando la clase PPImage

Este código de ejemplo muestra cómo implementar los pasos anteriores para añadir una imagen SVG a una presentación:
```javascript
// Instanciar la clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir SVG a un conjunto de formas**
La conversión de SVG a un conjunto de formas de Aspose.Slides es similar a la funcionalidad de PowerPoint utilizada para trabajar con imágenes SVG:

![PowerPoint Popup Menu](img_01_01.png)

La funcionalidad se ofrece mediante una de las sobrecargas del método [addGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) de la clase [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) que recibe un objeto [SvgImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SvgImage) como primer argumento.

Este código de ejemplo muestra cómo usar el método descrito para convertir un archivo SVG a un conjunto de formas:
```javascript
// Crear una nueva presentación
var presentation = new aspose.slides.Presentation();
try {
    // Leer el contenido del archivo SVG
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // Crear objeto SvgImage
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // Obtener el tamaño de la diapositiva
    var slideSize = presentation.getSlideSize().getSize();
    // Convertir la imagen SVG en un grupo de formas escalándola al tamaño de la diapositiva
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // Guardar la presentación en formato PPTX
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Añadir imágenes como EMF en diapositivas**
Aspose.Slides for Node.js via Java permite generar imágenes EMF a partir de hojas de Excel y añadir las imágenes como EMF en diapositivas con Aspose.Cells. 

Este código de ejemplo muestra cómo realizar la tarea descrita:
```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Reemplazar imágenes en la colección de imágenes**

Aspose.Slides permite reemplazar imágenes almacenadas en la colección de imágenes de una presentación (incluidas las usadas por formas de diapositivas). Esta sección muestra varios enfoques para actualizar imágenes en la colección. La API ofrece métodos sencillos para reemplazar una imagen mediante datos de bytes sin procesar, una instancia de [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) o otra imagen que ya exista en la colección.

1. Cargar el archivo de presentación que contiene imágenes usando la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Cargar una nueva imagen desde un archivo en una matriz de bytes.
3. Reemplazar la imagen objetivo con la nueva imagen usando la matriz de bytes.
4. En el segundo enfoque, cargar la imagen en un objeto [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) y reemplazar la imagen objetivo con ese objeto.
5. En el tercer enfoque, reemplazar la imagen objetivo con una imagen que ya exista en la colección de imágenes de la presentación.
6. Guardar la presentación modificada como un archivo PPTX.
```js
// Instanciar la clase Presentation que representa un archivo de presentación.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // La primera forma.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // La segunda forma.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // La tercera forma.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Guardar la presentación en un archivo.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}

Usando el convertidor GRATUITO de Aspose [Text to GIF](https://products.aspose.app/slides/text-to-gif), puedes animar textos fácilmente, crear GIFs a partir de textos, etc. 

{{% /alert %}}

## **FAQ**

**¿Se mantiene la resolución original de la imagen después de la inserción?**

Sí. Los píxeles originales se conservan, pero el aspecto final depende de cómo se escale la [picture](/slides/es/nodejs-java/picture-frame/) en la diapositiva y de cualquier compresión aplicada al guardar.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en decenas de diapositivas a la vez?**

Coloca el logotipo en la diapositiva maestra o en una disposición y reemplázalo en la colección de imágenes de la presentación; las actualizaciones se propagarán a todos los elementos que utilicen ese recurso.

**¿Puede un SVG insertado convertirse en formas editables?**

Sí. Puedes convertir un SVG en un grupo de formas, tras lo cual cada parte individual se vuelve editable con las propiedades estándar de forma.

**¿Cómo puedo establecer una imagen como fondo de varias diapositivas a la vez?**

[Asignar la imagen como fondo](/slides/es/nodejs-java/presentation-background/) en la diapositiva maestra o en el diseño correspondiente; cualquier diapositiva que use esa maestra/diseño heredará el fondo.

**¿Cómo evitar que la presentación aumente de tamaño debido a muchas imágenes?**

Reutiliza un único recurso de imagen en lugar de duplicados, elige resoluciones razonables, aplica compresión al guardar y mantén los gráficos repetidos en la maestra cuando sea apropiado.