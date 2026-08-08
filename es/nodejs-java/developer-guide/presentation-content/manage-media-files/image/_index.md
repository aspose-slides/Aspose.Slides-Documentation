---
title: Optimizar la gestión de imágenes en presentaciones usando JavaScript
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/nodejs-java/image/
keywords:
- añadir imagen
- añadir foto
- añadir bitmap
- reemplazar imagen
- reemplazar foto
- de la web
- fondo
- añadir PNG
- añadir JPG
- añadir SVG
- recursos SVG externos
- resolvedor SVG
- imágenes SVG vinculadas
- fuentes SVG
- añadir EMF
- añadir WMF
- añadir TIFF
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Optimiza la gestión de imágenes en PowerPoint y OpenDocument con Aspose.Slides para Node.js mediante Java, mejorando el rendimiento y automatizando tu flujo de trabajo."
---
## **Introducción**

Las imágenes hacen que las presentaciones sean más atractivas y visualmente interesantes. En Microsoft PowerPoint, puedes insertar imágenes en las diapositivas desde archivos, internet u otras fuentes. De forma similar, Aspose.Slides permite añadir imágenes a las diapositivas de una presentación de varias maneras.

{{% alert  title="Consejo" color="primary" %}} 

Aspose ofrece convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/es/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/es/import/png-to-ppt)—que te permiten crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

{{% alert title="Información" color="info" %}}

Si deseas añadir una imagen como marco de foto—especialmente si planeas cambiar su tamaño, aplicar efectos o usar otras opciones de formato estándar—consulta [Marco de imagen](/slides/es/nodejs-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}

Puedes convertir imágenes de un formato a otro. Consulta las siguientes páginas: convertir [imagen a JPG](https://products.aspose.com/slides/es/nodejs-java/conversion/image-to-jpg/), [JPG a imagen](https://products.aspose.com/slides/es/nodejs-java/conversion/jpg-to-image/), [JPG a PNG](https://products.aspose.com/slides/es/nodejs-java/conversion/jpg-to-png/), [PNG a JPG](https://products.aspose.com/slides/es/nodejs-java/conversion/png-to-jpg/), [PNG a SVG](https://products.aspose.com/slides/es/nodejs-java/conversion/png-to-svg/), y [SVG a PNG](https://products.aspose.com/slides/es/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides admite imágenes en formatos populares como JPEG, PNG, BMP, GIF y otros. 

## **Añadir imágenes almacenadas localmente a las diapositivas**

Puedes añadir una o varias imágenes almacenadas en tu ordenador a una diapositiva de la presentación. El siguiente fragmento de código JavaScript muestra cómo añadir una imagen a una diapositiva:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Añadir imágenes desde la web a las diapositivas**

Si la imagen que deseas añadir a una diapositiva no está almacenada en tu ordenador, puedes añadirla directamente desde la web. 

El siguiente fragmento de código JavaScript muestra cómo añadir una imagen desde la web a una diapositiva:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Añadir imágenes a los maestros de diapositivas**

Un maestro de diapositivas almacena y controla información como el tema y la disposición de las diapositivas que lo utilizan. Cuando añades una imagen a un maestro de diapositivas, la imagen aparece en cada diapositiva basada en ese maestro. 

El siguiente fragmento de código JavaScript muestra cómo añadir una imagen a un maestro de diapositivas:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Añadir imágenes como fondos de diapositiva**

Puedes usar una imagen como fondo de una o varias diapositivas. Para más detalles, consulta *[Establecer imágenes como fondos de diapositivas](/slides/es/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Añadir SVG a presentaciones**

El contenido SVG puede añadirse a una presentación usando la clase [SvgImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/svgimage/). El objeto de imagen SVG resultante puede luego añadirse a la colección de imágenes de la presentación y usarse para crear un marco de foto.

El siguiente ejemplo JavaScript importa una cadena SVG autónoma. Todas las imágenes, estilos y otros recursos utilizados por este SVG se incrustan directamente en el contenido SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Importar contenido SVG con recursos externos**

Los archivos SVG exportados desde herramientas de diseño, editores de diagramas, sistemas de iconos y flujos de trabajo web pueden hacer referencia a recursos que se encuentran fuera del documento SVG. Por ejemplo, un SVG puede contener un enlace de imagen como `images/photo.png`, un valor CSS `url(...)` o una URL de fuente.

Para importar dicho contenido SVG, proporciona un resolvedor de recursos externos y pásalo, junto con una URI base, a un constructor apropiado de [SvgImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/svgimage/). La URI base identifica la ubicación del documento SVG y se usa para resolver enlaces relativos.

La clase `SvgImage` proporciona acceso a la información del SVG importado:

- `getSvgContent()` devuelve el marcado SVG como cadena.
- `getSvgData()` devuelve el contenido SVG como matriz de bytes.
- `getBaseUri()` devuelve la URI base usada para enlaces relativos.
- `getExternalResourceResolver()` devuelve el resolvedor asignado a la imagen SVG.

### **Implementar un resolvedor de recursos externos**

El resolvedor tiene dos métodos:

- `resolveUri` combina la URI base y un enlace de recurso relativo y devuelve una URI absoluta. Devuelve `null` cuando el enlace no se puede resolver o no está permitido.
- `getEntity` devuelve un flujo Java legible para una URI de recurso absoluta. Devuelve `null` cuando el recurso falta, está bloqueado o no está disponible. También se puede devolver un flujo de reserva cuando sea apropiado.

El siguiente asistente crea un resolvedor que carga recursos vinculados solo desde un directorio local permitido. Los recursos de red y rutas fuera del directorio permitido están bloqueados. Se devuelve una imagen de reserva opcional para enlaces de imagen no resueltos.

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // Este resolvedor permite intencionalmente solo archivos locales.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // Use una reserva solo para recursos de imagen. Devolver un flujo de imagen
                // para una fuente o hoja de estilo faltante no sería válido.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **Resolver recursos vinculados durante la importación de SVG**

Supón que `assets/diagram.svg` contiene una referencia relativa como:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

El siguiente ejemplo JavaScript pasa la URI del archivo SVG como URI base y proporciona un resolvedor personalizado. El resolvedor convierte el enlace de imagen relativo en una URI absoluta y devuelve un flujo que contiene el recurso vinculado mientras Aspose.Slides procesa el SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// La URI base representa la ubicación del documento SVG.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage exposes the source content, binary data, base URI, and resolver.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La clase `SvgImage` también ofrece sobrecargas que aceptan datos SVG como una matriz de bytes, así como métodos de fábrica basados en flujos, junto con un resolvedor de recursos externo y una URI base.

{{% alert title="Importante" color="warning" %}}

El resolvedor de recursos hace que los recursos externos estén disponibles mientras Aspose.Slides procesa y renderiza el SVG. No modifica el marcado SVG original ni incrusta automáticamente los recursos resueltos en él.

Cuando una imagen SVG se añade a la colección de imágenes de la presentación, el archivo PPTX puede contener tanto la representación SVG original como una imagen raster de reserva. Un recurso vinculado puede aparecer en la imagen de reserva generada mientras que un enlace relativo como `images/photo.png` permanece sin cambios en el SVG almacenado. Por lo tanto, una aplicación que renderice la representación SVG nativa puede omitir el contenido vinculado cuando el recurso externo original no está disponible.

{{% /alert %}}

### **Crear una imagen SVG portátil**

Para crear una imagen SVG que no dependa de archivos externos, haz que el SVG sea autónomo antes de crear el `SvgImage`. Por ejemplo, sustituye las URL de imágenes vinculadas por URIs `data:` que contengan los datos de la imagen:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Después de que todos los recursos necesarios estén incrustados en el contenido SVG, crea el `SvgImage`, añádelo a la colección de imágenes de la presentación e insértalo en un marco de foto como se muestra en el ejemplo anterior.

### **Gestionar recursos faltantes o bloqueados**

Devuelve `null` desde `resolveUri` cuando una URI de recurso es inválida, está prohibida o no se puede resolver. Devuelve `null` desde `getEntity` cuando el recurso no puede leerse. Aspose.Slides continúa procesando el SVG sin ese recurso cuando sea posible.

Se puede devolver un flujo de reserva para un recurso faltante, pero su contenido debe ser compatible con el tipo de recurso solicitado. Por ejemplo, devuelve un flujo de imagen solo para una imagen faltante, no para una fuente o una hoja de estilo.

{{% alert title="Seguridad" color="warning" %}}

No resuelvas rutas de archivo arbitrarias ni URLs de red sin restricciones a partir de archivos SVG no confiables. Restringe los esquemas, directorios y hosts permitidos. Para recursos de red, también aplica límites de tiempo de conexión, tamaños de respuesta y validación de contenido.

{{% /alert %}}

## **Convertir SVG a un conjunto de formas**

Aspose.Slides puede convertir un SVG en un conjunto de formas, similar a la funcionalidad correspondiente en PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Esta funcionalidad se proporciona mediante una sobrecarga del método [addGroupShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) de la clase [ShapeCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ShapeCollection) que recibe un objeto de imagen SVG como su primer argumento.

El siguiente fragmento de código JavaScript muestra cómo usar este método para convertir un archivo SVG en un conjunto de formas:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Nombre del archivo SVG fuente.
const svgFileName = "sample.svg";

// Nombre del archivo de salida de la presentación.
const outPptxPath = "presentation.pptx";

// Crear una nueva presentación.
const presentation = new aspose.slides.Presentation();
try {
    // Leer el contenido del archivo SVG.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // Crear un objeto SvgImage.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // Obtener el tamaño de la diapositiva.
    const slideSize = presentation.getSlideSize().getSize();

    // Convertir la imagen SVG en un grupo de formas y escalarla al tamaño de la diapositiva.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // Guardar la presentación en formato PPTX.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Añadir imágenes como EMF a las diapositivas**

Aspose.Slides para Node.js mediante Java te permite generar imágenes EMF a partir de hojas de cálculo Excel con Aspose.Cells y añadirlas a las diapositivas de la presentación.

El siguiente fragmento de código JavaScript muestra cómo hacerlo:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// Guardar el libro de trabajo en un flujo.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Añadir el archivo tal cual para que la imagen permanezca como vector EMF en lugar de rasterizarse.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Reemplazar imágenes en la colección de imágenes**

Aspose.Slides permite reemplazar imágenes almacenadas en la colección de imágenes de una presentación, incluidas las imágenes usadas por formas de diapositivas. Esta sección describe varias formas de actualizar imágenes en la colección. Puedes reemplazar una imagen usando datos de bytes sin procesar, una instancia de [IImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/), o otra imagen que ya exista en la colección.

Sigue los pasos a continuación:

1. Carga el archivo de presentación que contiene imágenes usando la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
1. Carga una nueva imagen desde un archivo en una matriz de bytes.
1. Reemplaza la imagen objetivo con la nueva imagen usando la matriz de bytes.
1. En el segundo enfoque, carga la imagen en un objeto [IImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/) y reemplaza la imagen objetivo con ese objeto.
1. En el tercer enfoque, reemplaza la imagen objetivo con una imagen que ya exista en la colección de imágenes de la presentación.
1. Escribe la presentación modificada como un archivo PPTX.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Instanciar la clase Presentation que representa un archivo de presentación.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // La primera forma.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // La segunda forma.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // La tercera forma.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Guardar la presentación en un archivo.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Información" color="info" %}}

Con el convertidor gratuito [Texto a GIF](https://products.aspose.app/slides/es/text-to-gif) de Aspose, puedes animar texto fácilmente y crear GIFs a partir de texto. 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Se mantiene la resolución original de la imagen después de insertarla?**

Sí. Los píxeles originales se conservan, pero el aspecto final depende de cómo se escale la [imagen](/slides/es/nodejs-java/picture-frame/) en la diapositiva y de cualquier compresión aplicada al guardar.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en decenas de diapositivas a la vez?**

Coloca el logotipo en la diapositiva maestra o en una disposición y reemplázalo en la colección de imágenes de la presentación; las actualizaciones se propagarán a todos los elementos que usen ese recurso.

**¿Puede un SVG insertado convertirse en formas editables?**

Sí. Puedes convertir un SVG en un grupo de formas, tras lo cual cada parte individual se vuelve editable con las propiedades estándar de forma.

**¿Cómo puedo establecer una imagen como fondo de varias diapositivas a la vez?**

[Asigna la imagen como fondo](/slides/es/nodejs-java/presentation-background/) en la diapositiva maestra o en el diseño correspondiente; cualquier diapositiva que use esa maestra/diseño heredará el fondo.

**¿Cómo evito que una presentación se vuelva demasiado grande por la gran cantidad de imágenes?**

Reutiliza un único recurso de imagen en lugar de duplicados, elige resoluciones razonables, aplica compresión al guardar y mantén los gráficos repetidos en la maestra cuando sea apropiado.