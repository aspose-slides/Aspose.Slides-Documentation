---
title: Imagen
type: docs
weight: 10
url: /es/nodejs-java/image/
keywords:
- agregar imagen
- agregar imagen
- agregar mapa de bits
- reemplazar imagen
- reemplazar imagen
- desde la web
- fondo
- agregar PNG
- agregar JPG
- agregar SVG
- agregar EMF
- agregar WMF
- agregar TIFF
- PowerPoint
- OpenDocument
- presentación
- EMF
- SVG
- Node.js
- Aspose.Slides
description: "Optimiza la gestión de imágenes en PowerPoint y OpenDocument con Aspose.Slides para Node.js, mejorando el rendimiento y automatizando tu flujo de trabajo."
---

## **Imágenes en diapositivas en presentaciones**

Las imágenes hacen que las presentaciones sean más atractivas e interesantes. En Microsoft PowerPoint, puedes insertar imágenes desde un archivo, internet u otras ubicaciones en las diapositivas. De manera similar, Aspose.Slides permite agregar imágenes a las diapositivas de tus presentaciones mediante diferentes procedimientos. 

{{% alert  title="Tip" color="primary" %}} 

Aspose ofrece convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si deseas agregar una imagen como un objeto de marco—especialmente si planeas usar opciones de formato estándar para cambiar su tamaño, agregar efectos, etc.—consulta [Marco de imagen](https://docs.aspose.com/slides/nodejs-java/picture-frame/).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Puedes manipular operaciones de entrada/salida que involucren imágenes y presentaciones de PowerPoint para convertir una imagen de un formato a otro. Consulta estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides admite operaciones con imágenes en estos formatos populares: JPEG, PNG, GIF y otros. 

## **Agregar imágenes almacenadas localmente a las diapositivas**

Puedes agregar una o varias imágenes de tu computadora a una diapositiva en una presentación. Este código de ejemplo en JavaScript muestra cómo agregar una imagen a una diapositiva:
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


## **Agregar imágenes desde el flujo a las diapositivas**

Si la imagen que deseas agregar a una diapositiva no está disponible en tu computadora, puedes agregarla directamente desde la web. 

Este código de ejemplo muestra cómo agregar una imagen desde la web a una diapositiva en JavaScript:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Accede a la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Carga un archivo Excel al flujo
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // Crea un objeto de datos para incrustar
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Agrega una forma de marco de objeto Ole
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


## **Agregar imágenes a los maestros de diapositivas**

Un maestro de diapositivas es la diapositiva superior que almacena y controla información (tema, diseño, etc.) sobre todas las diapositivas que están bajo ella. Por lo tanto, cuando agregas una imagen a un maestro de diapositivas, esa imagen aparece en cada diapositiva bajo ese maestro. 

Este código de ejemplo en JavaScript muestra cómo agregar una imagen a un maestro de diapositivas:
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


## **Agregar imágenes como fondo de diapositiva**

Puedes decidir usar una imagen como fondo para una diapositiva específica o varias diapositivas. En ese caso, debes consultar *[Configurar imágenes como fondos para diapositivas](https://docs.aspose.com/slides/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Agregar SVG a presentaciones**
Puedes agregar o insertar cualquier imagen en una presentación usando el método [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) que pertenece a la clase [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).

Para crear un objeto de imagen basado en una imagen SVG, puedes hacerlo de esta manera:

1. Crear un objeto SvgImage para insertarlo en ImageShapeCollection
2. Crear un objeto PPImage a partir de ISvgImage
3. Crear un objeto PictureFrame usando la clase PPImage

Este código de ejemplo muestra cómo implementar los pasos anteriores para agregar una imagen SVG en una presentación:
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

La funcionalidad se proporciona mediante una de las sobrecargas del método [addGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) de la clase [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) que recibe un objeto [SvgImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SvgImage) como primer argumento.

Este código de ejemplo muestra cómo usar el método descrito para convertir un archivo SVG a un conjunto de formas:
```javascript
// Crear nueva presentación
var presentation = new aspose.slides.Presentation();
try {
    // Leer el contenido del archivo SVG
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // Crear objeto SvgImage
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // Obtener el tamaño de la diapositiva
    var slideSize = presentation.getSlideSize().getSize();
    // Convertir la imagen SVG a un grupo de formas escalándola al tamaño de la diapositiva
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


## **Agregar imágenes como EMF en diapositivas**
Aspose.Slides for Node.js via Java permite generar imágenes EMF a partir de hojas de Excel y agregar las imágenes como EMF en diapositivas con Aspose.Cells. 

Este código de ejemplo muestra cómo realizar la tarea descrita:
```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Guardar el libro en el flujo
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

Aspose.Slides permite reemplazar imágenes almacenadas en la colección de imágenes de una presentación (incluidas las usadas por formas de diapositivas). Esta sección muestra varios enfoques para actualizar imágenes en la colección. La API ofrece métodos sencillos para reemplazar una imagen usando datos de bytes sin procesar, una instancia [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) o otra imagen que ya exista en la colección.

1. Cargar el archivo de presentación que contiene imágenes usando la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Cargar una nueva imagen desde un archivo en un arreglo de bytes.
1. Reemplazar la imagen objetivo con la nueva imagen usando el arreglo de bytes.
1. En el segundo enfoque, cargar la imagen en un objeto [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) y reemplazar la imagen objetivo con ese objeto.
1. En el tercer enfoque, reemplazar la imagen objetivo con una imagen que ya exista en la colección de imágenes de la presentación.
1. Guardar la presentación modificada como un archivo PPTX.
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

## **Preguntas frecuentes**

**¿Se mantiene la resolución original de la imagen después de la inserción?**

Sí. Los píxeles originales se conservan, pero la apariencia final depende de cómo se escale la [imagen](/slides/es/nodejs-java/picture-frame/) en la diapositiva y de cualquier compresión aplicada al guardar.

**¿Cuál es la mejor manera de reemplazar el mismo logo en decenas de diapositivas a la vez?**

Coloca el logo en la diapositiva maestra o en una disposición y reemplázalo en la colección de imágenes de la presentación; las actualizaciones se propagarán a todos los elementos que usan ese recurso.

**¿Puede un SVG insertado convertirse en formas editables?**

Sí. Puedes convertir un SVG en un grupo de formas, después de lo cual las partes individuales se vuelven editables con las propiedades estándar de formas.

**¿Cómo puedo establecer una imagen como fondo de varias diapositivas a la vez?**

[Asignar la imagen como fondo](/slides/es/nodejs-java/presentation-background/) en la diapositiva maestra o en la disposición correspondiente—cualquier diapositiva que use esa maestra/disposición heredará el fondo.

**¿Cómo evitar que la presentación se inflccione en tamaño debido a muchas imágenes?**

Reutiliza un solo recurso de imagen en lugar de duplicados, elige resoluciones razonables, aplica compresión al guardar y mantén los gráficos repetidos en la maestra cuando sea apropiado.