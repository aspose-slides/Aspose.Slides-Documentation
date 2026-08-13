---
title: Optimizar la gestión de imágenes en presentaciones en Android
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/androidjava/image/
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
- Android
- Java
- Aspose.Slides
description: "Simplifique la gestión de imágenes en PowerPoint y OpenDocument con Aspose.Slides para Android mediante Java, optimizando el rendimiento y automatizando su flujo de trabajo."
---
## **Introducción**

Las imágenes hacen que las presentaciones sean más atractivas y visualmente agradables. En Microsoft PowerPoint, puedes insertar imágenes en las diapositivas desde archivos, Internet u otras fuentes. De manera similar, Aspose.Slides te permite añadir imágenes a las diapositivas de una presentación de varias formas.

{{% alert  title="Tip" color="info" %}} 

Aspose ofrece conversores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/es/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/es/import/png-to-ppt)—que te permiten crear rápidamente presentaciones a partir de imágenes. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si deseas añadir una imagen como marco de foto—especialmente si planeas cambiar su tamaño, aplicar efectos o usar otras opciones de formato estándar—consulta [Marco de Imagen](/slides/es/androidjava/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Puedes convertir imágenes de un formato a otro. Consulta las siguientes páginas: convertir [imagen a JPG](https://products.aspose.com/slides/es/androidjava/conversion/image-to-jpg/), [JPG a imagen](https://products.aspose.com/slides/es/androidjava/conversion/jpg-to-image/), [JPG a PNG](https://products.aspose.com/slides/es/androidjava/conversion/jpg-to-png/), [PNG a JPG](https://products.aspose.com/slides/es/androidjava/conversion/png-to-jpg/), [PNG a SVG](https://products.aspose.com/slides/es/androidjava/conversion/png-to-svg/), y [SVG a PNG](https://products.aspose.com/slides/es/androidjava/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides admite imágenes en formatos populares como JPEG, PNG, BMP, GIF y otros. 

## **Añadir Imágenes Almacenadas Localmente a Diapositivas**

Puedes añadir una o varias imágenes almacenadas en tu ordenador a una diapositiva de la presentación. El siguiente código de ejemplo en Java muestra cómo añadir una imagen a una diapositiva:

```java
import com.aspose.slides.*;

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
    pres.dispose();
}
```

## **Añadir Imágenes desde la Web a Diapositivas**

Si la imagen que deseas añadir a una diapositiva no está almacenada en tu ordenador, puedes añadirla directamente desde la web. 

El siguiente código de ejemplo en Java muestra cómo añadir una imagen desde la web a una diapositiva:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

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

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Añadir Imágenes a los Masters de Diapositivas**

Un master de diapositivas almacena y controla información como el tema y el diseño de las diapositivas que lo utilizan. Cuando añades una imagen a un master de diapositivas, la imagen aparece en todas las diapositivas basadas en ese master. 

El siguiente código de ejemplo en Java muestra cómo añadir una imagen a un master de diapositivas:

```java
import com.aspose.slides.*;

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
    pres.dispose();
}
```

## **Añadir Imágenes como Fondos de Diapositiva**

Puedes usar una imagen como fondo de una o varias diapositivas. Para más detalles, consulta *[Establecer Imágenes como Fondos de Diapositivas](/slides/es/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Añadir SVG a Presentaciones**

Se puede añadir contenido SVG a una presentación mediante la clase [SvgImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgimage/). El objeto [ISvgImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isvgimage/) resultante puede entonces añadirse a la colección de imágenes de la presentación y usarse para crear un marco de imagen.

El siguiente ejemplo en Java importa una cadena SVG autocontenida. Todas las imágenes, estilos y demás recursos utilizados por este SVG están incrustados directamente en el contenido SVG.

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Importar Contenido SVG con Recursos Externos**

Los archivos SVG exportados desde herramientas de diseño, editores de diagramas, sistemas de iconos y canalizaciones web pueden referenciar recursos que se almacenan fuera del documento SVG. Por ejemplo, un SVG puede contener un enlace a una imagen como `images/photo.png`, un valor CSS `url(...)` o una URL de fuente.

Para importar dicho contenido SVG, crea una implementación de [IExternalResourceResolver](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iexternalresourceresolver/) y pásala, junto con una URI base, al constructor correspondiente de [SvgImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgimage/). La URI base identifica la ubicación del documento SVG y se utiliza para resolver enlaces relativos.

La interfaz [ISvgImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isvgimage/) proporciona acceso a información sobre el SVG importado:

- `getSvgContent()` devuelve el marcado SVG como una cadena.
- `getSvgData()` devuelve el contenido SVG como una matriz de bytes.
- `getBaseUri()` devuelve la URI base utilizada para enlaces relativos.
- `getExternalResourceResolver()` devuelve el resolvedor asignado a la imagen SVG.

### **Implementar un Resolvedor de Recursos Externos**

El resolvedor tiene dos métodos:

- `resolveUri` combina la URI base y un enlace de recurso relativo y devuelve una URI absoluta. Devuelve `null` cuando el enlace no puede resolverse o no está permitido.
- `getEntity` devuelve un flujo legible para una URI de recurso absoluta. Devuelve `null` cuando el recurso falta, está bloqueado o no está disponible. También se puede devolver un flujo de reserva cuando sea apropiado.

El siguiente resolvedor carga recursos vinculados solo desde un directorio local permitido. Los recursos de red y rutas fuera del directorio permitido están bloqueados. Se devuelve una imagen de reserva opcional para enlaces de imagen no resueltos.

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // Este resolvedor permite intencionalmente solo archivos locales.
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // Utilice una imagen de reserva solo para recursos de imagen. Devolver un flujo de imagen
            // para una fuente o hoja de estilo faltante no sería válido.
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **Resolver Recursos Vinculados Durante la Importación de SVG**

Supongamos que `assets/diagram.svg` contiene una referencia relativa como:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

El siguiente ejemplo en Java pasa la URI del archivo SVG como URI base y proporciona un resolvedor personalizado. El resolvedor convierte el enlace de imagen relativo en una URI absoluta y devuelve un flujo que contiene el recurso vinculado mientras Aspose.Slides procesa el SVG.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// La URI base representa la ubicación del documento SVG.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage expone el contenido fuente, datos binarios, URI base y resolvedor.
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La clase `SvgImage` también ofrece sobrecargas que aceptan datos SVG como una matriz de bytes o un flujo de entrada, junto con un resolvedor de recursos externos y una URI base.

{{% alert title="Important" color="warning" %}}

El resolvedor de recursos pone los recursos externos a disposición mientras Aspose.Slides procesa y renderiza el SVG. No modifica el marcado SVG original ni incrusta automáticamente los recursos resueltos en él.

Cuando se añade un `ISvgImage` a la colección de imágenes de la presentación, el archivo PPTX puede contener tanto la representación SVG original como una imagen raster de reserva. Un recurso vinculado puede aparecer en la imagen de reserva generada mientras que un enlace relativo como `images/photo.png` permanece sin cambios en el SVG almacenado. Una aplicación que renderiza la representación SVG nativa puede, por tanto, omitir el contenido vinculado cuando el recurso externo original no está disponible.

{{% /alert %}}

### **Crear una Imagen SVG Portátil**

Para crear una imagen SVG que no dependa de archivos externos, haz que el SVG sea autocontenido antes de crear el `SvgImage`. Por ejemplo, sustituye las URLs de imágenes vinculadas por URIs `data:` que contengan los datos de la imagen:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Una vez que todos los recursos requeridos estén incrustados en el contenido SVG, crea el `SvgImage`, añádelo a la colección de imágenes de la presentación e insértalo en un marco de imagen como se muestra en el ejemplo anterior.

### **Gestionar Recursos Faltantes o Bloqueados**

Devuelve `null` desde `resolveUri` cuando una URI de recurso es inválida, está prohibida o no puede resolverse. Devuelve `null` desde `getEntity` cuando el recurso no puede leerse. Aspose.Slides continúa procesando el SVG sin ese recurso cuando es posible.

Se puede devolver un flujo de reserva para un recurso faltante, pero su contenido debe ser compatible con el tipo de recurso solicitado. Por ejemplo, devuelve un flujo de imagen solo para una imagen faltante, no para una fuente o una hoja de estilo.

{{% alert title="Security" color="warning" %}}

No resuelvas rutas de archivo arbitrarias ni URLs de red sin restricciones desde archivos SVG no confiables. Restringe los esquemas, directorios y hosts permitidos. Para recursos de red, también aplica límites de tiempo de conexión, tamaño de respuesta y validación de contenido.

{{% /alert %}}

## **Convertir SVG a un Conjunto de Formas**

Aspose.Slides puede convertir un SVG en un conjunto de formas, similar a la funcionalidad correspondiente en PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Esta funcionalidad se proporciona mediante una sobrecarga del método [addGroupShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) de la interfaz [IShapeCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IShapeCollection) que recibe un objeto [ISvgImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISvgImage) como su primer argumento.

El siguiente código de ejemplo en Java muestra cómo usar este método para convertir un archivo SVG en un conjunto de formas:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Nombre del archivo SVG de origen.
String svgFileName = "sample.svg";

// Nombre del archivo de presentación de salida.
String outPptxPath = "presentation.pptx";

// Crear una nueva presentación.
IPresentation presentation = new Presentation();
try {
    // Leer el contenido del archivo SVG.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // Crear un objeto SvgImage.
    ISvgImage svgImage = new SvgImage(svgContent);

    // Obtener el tamaño de la diapositiva.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Convertir la imagen SVG en un grupo de formas y escalarla al tamaño de la diapositiva.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // Guardar la presentación en formato PPTX.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Añadir Imágenes como EMF a Diapositivas**

Aspose.Slides para Android mediante Java te permite generar imágenes EMF a partir de hojas de cálculo Excel con Aspose.Cells y añadirlas a las diapositivas de la presentación.

El siguiente código de ejemplo en Java muestra cómo hacerlo:

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// Guardar el libro de trabajo en un flujo.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Añadir el archivo tal cual para que la imagen permanezca como un vector EMF en lugar de rasterizarse.
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Reemplazar Imágenes en la Colección de Imágenes**

Aspose.Slides te permite reemplazar imágenes almacenadas en la colección de imágenes de una presentación, incluidas las imágenes utilizadas por las formas de las diapositivas. Esta sección describe varias formas de actualizar imágenes en la colección. Puedes reemplazar una imagen usando datos de bytes sin procesar, una instancia de [IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/) o otra imagen que ya exista en la colección.

Sigue los pasos a continuación:

1. Carga el archivo de presentación que contiene imágenes usando la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
1. Carga una nueva imagen desde un archivo en una matriz de bytes.
1. Reemplaza la imagen objetivo con la nueva imagen usando la matriz de bytes.
1. En el segundo enfoque, carga la imagen en un objeto [IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/) y reemplaza la imagen objetivo con ese objeto.
1. En el tercer enfoque, reemplaza la imagen objetivo con una imagen que ya exista en la colección de imágenes de la presentación.
1. Escribe la presentación modificada como un archivo PPTX.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation("sample.pptx");
try {
    // La primera forma.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // La segunda forma.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

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

Con el conversor gratuito de Aspose [Text to GIF](https://products.aspose.app/slides/es/text-to-gif), puedes animar fácilmente texto y crear GIFs a partir de texto. 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Se mantiene la resolución original de la imagen después de la inserción?**

Sí. Los píxeles originales se conservan, pero el aspecto final depende de cómo se escale la [imagen](/slides/es/androidjava/picture-frame/) en la diapositiva y de cualquier compresión aplicada al guardar.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en docenas de diapositivas a la vez?**

Coloca el logotipo en la diapositiva maestra o en una disposición y reemplázalo en la colección de imágenes de la presentación; las actualizaciones se propagarán a todos los elementos que usan ese recurso.

**¿Puede un SVG insertado convertirse en formas editables?**

Sí. Puedes convertir un SVG en un grupo de formas, tras lo cual las partes individuales son editables con las propiedades habituales de forma.

**¿Cómo puedo establecer una imagen como fondo de varias diapositivas a la vez?**

[Asigna la imagen como fondo](/slides/es/androidjava/presentation-background/) en la diapositiva maestra o en la disposición correspondiente; cualquier diapositiva que use esa maestra/disposición heredará el fondo.

**¿Cómo evito que una presentación se vuelva demasiado grande debido a muchas imágenes?**

Reutiliza un único recurso de imagen en lugar de duplicados, elige resoluciones razonables, aplica compresión al guardar y mantén los gráficos repetidos en la maestra cuando sea apropiado.