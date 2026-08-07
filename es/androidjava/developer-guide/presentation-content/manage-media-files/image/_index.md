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
description: "Optimiza la gestión de imágenes en PowerPoint y OpenDocument con Aspose.Slides para Android mediante Java, mejorando el rendimiento y automatizando tu flujo de trabajo."
---
## **Introducción**

Las imágenes hacen que las presentaciones sean más atractivas y visualmente llamativas. En Microsoft PowerPoint, puedes insertar imágenes en las diapositivas desde archivos, internet u otras fuentes. De forma similar, Aspose.Slides permite añadir imágenes a las diapositivas de una presentación de varias maneras.

{{% alert  title="Consejo" color="primary" %}} 

Aspose ofrece convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/es/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/es/import/png-to-ppt)—que te permiten crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

{{% alert title="Información" color="info" %}}

Si deseas añadir una imagen como marco de foto—especialmente si planeas redimensionarla, aplicar efectos o usar otras opciones de formato estándar—consulta [Marco de imagen](/slides/es/androidjava/picture-frame/). 

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}

Puedes convertir imágenes de un formato a otro. Consulta las siguientes páginas: convertir [imagen a JPG](https://products.aspose.com/slides/es/androidjava/conversion/image-to-jpg/), [JPG a imagen](https://products.aspose.com/slides/es/androidjava/conversion/jpg-to-image/), [JPG a PNG](https://products.aspose.com/slides/es/androidjava/conversion/jpg-to-png/), [PNG a JPG](https://products.aspose.com/slides/es/androidjava/conversion/png-to-jpg/), [PNG a SVG](https://products.aspose.com/slides/es/androidjava/conversion/png-to-svg/), y [SVG a PNG](https://products.aspose.com/slides/es/androidjava/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides admite imágenes en formatos populares como JPEG, PNG, BMP, GIF y otros. 

## **Añadir imágenes almacenadas localmente a diapositivas**

Puedes añadir una o más imágenes almacenadas en tu equipo a una diapositiva de la presentación. El siguiente código de ejemplo en Java muestra cómo añadir una imagen a una diapositiva:

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

## **Añadir imágenes desde la web a diapositivas**

Si la imagen que deseas añadir a una diapositiva no está almacenada en tu equipo, puedes añadirla directamente desde la web. 

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

## **Añadir imágenes a los patrones de diapositivas**

Un patrón de diapositiva almacena y controla información como el tema y el diseño de las diapositivas que lo usan. Cuando añades una imagen a un patrón de diapositiva, la imagen aparece en todas las diapositivas basadas en ese patrón. 

El siguiente código de ejemplo en Java muestra cómo añadir una imagen a un patrón de diapositiva:

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

## **Añadir imágenes como fondos de diapositiva**

Puedes usar una imagen como fondo de una o varias diapositivas. Para más detalles, consulta *[Establecer imágenes como fondos de diapositivas](/slides/es/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Añadir SVG a presentaciones**

El contenido SVG puede añadirse a una presentación usando la clase [SvgImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgimage/). El objeto [ISvgImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isvgimage/) resultante puede añadirse a la colección de imágenes de la presentación y usarse para crear un marco de imagen.

El siguiente ejemplo en Java importa una cadena SVG autónoma. Todas las imágenes, estilos y demás recursos utilizados por este SVG están incrustados directamente en el contenido SVG.

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

## **Importar contenido SVG con recursos externos**

Los archivos SVG exportados desde herramientas de diseño, editores de diagramas, sistemas de iconos y pipelines web pueden referenciar recursos que se almacenan fuera del documento SVG. Por ejemplo, un SVG puede contener un enlace a una imagen como `images/photo.png`, un valor CSS `url(...)` o una URL de fuente.

Para importar ese tipo de contenido SVG, crea una implementación de [IExternalResourceResolver](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iexternalresourceresolver/) y pásala, junto con una URI base, a un constructor apropiado de [SvgImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgimage/). La URI base identifica la ubicación del documento SVG y se usa para resolver enlaces relativos.

La interfaz [ISvgImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isvgimage/) brinda acceso a información sobre el SVG importado:

- `getSvgContent()` devuelve el marcado SVG como cadena.
- `getSvgData()` devuelve el contenido SVG como matriz de bytes.
- `getBaseUri()` devuelve la URI base usada para enlaces relativos.
- `getExternalResourceResolver()` devuelve el resolvedor asignado a la imagen SVG.

### **Implementar un resolvedor de recursos externos**

El resolvedor tiene dos métodos:

- `resolveUri` combina la URI base y un enlace de recurso relativo y devuelve una URI absoluta. Devuelve `null` cuando el enlace no puede resolverse o no está permitido.
- `getEntity` devuelve un flujo legible para una URI de recurso absoluta. Devuelve `null` cuando el recurso falta, está bloqueado o no está disponible. También puede devolverse un flujo de respaldo cuando sea apropiado.

El siguiente resolvedor carga recursos vinculados solo desde un directorio local permitido. Los recursos de red y las rutas fuera del directorio permitido se bloquean. Se devuelve una imagen de respaldo opcional para los enlaces de imagen no resueltos.

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

            // Utiliza un recurso de respaldo solo para recursos de imagen. Devolver un flujo de imagen
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

### **Resolver recursos vinculados durante la importación de SVG**

Supón que `assets/diagram.svg` contiene una referencia relativa como:

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

// ISvgImage expone el contenido fuente, los datos binarios, la URI base y el resolvedor.
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

La clase `SvgImage` también ofrece sobrecargas que aceptan datos SVG como matriz de bytes o un flujo de entrada, junto con un resolvedor de recursos externos y una URI base.

{{% alert title="Importante" color="warning" %}}

El resolvedor de recursos hace que los recursos externos estén disponibles mientras Aspose.Slides procesa y representa el SVG. No modifica el marcado SVG original ni incrusta automáticamente los recursos resueltos en él.

Cuando un `ISvgImage` se añade a la colección de imágenes de la presentación, el archivo PPTX puede contener tanto la representación SVG original como una imagen raster de respaldo. Un recurso vinculado puede aparecer en la imagen de respaldo generada mientras que un enlace relativo como `images/photo.png` permanece sin cambios en el SVG almacenado. Una aplicación que representa la representación SVG nativa puede, por lo tanto, omitir el contenido vinculado cuando el recurso externo original no está disponible.

{{% /alert %}}

### **Crear una imagen SVG portátil**

Para crear una imagen SVG que no dependa de archivos externos, haz que el SVG sea autónomo antes de crear el `SvgImage`. Por ejemplo, sustituye las URLs de imágenes vinculadas por URIs `data:` que contengan los datos de la imagen:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Una vez que todos los recursos necesarios estén incrustados en el contenido SVG, crea el `SvgImage`, añádelo a la colección de imágenes de la presentación e insértalo en un marco de imagen como se mostró en el ejemplo anterior.

### **Gestionar recursos faltantes o bloqueados**

Devuelve `null` desde `resolveUri` cuando una URI de recurso sea inválida, prohibida o no pueda resolverse. Devuelve `null` desde `getEntity` cuando el recurso no pueda leerse. Aspose.Slides continúa procesando el SVG sin ese recurso cuando sea posible.

Se puede devolver un flujo de respaldo para un recurso faltante, pero su contenido debe ser compatible con el tipo de recurso solicitado. Por ejemplo, devuelve un flujo de imagen solo para una imagen faltante, no para una fuente o hoja de estilo.

{{% alert title="Seguridad" color="warning" %}}

No resuelvas rutas de archivo arbitrarias ni URLs de red sin restricciones a partir de archivos SVG no confiables. Restringe los esquemas, directorios y hosts permitidos. Para recursos de red, también aplica tiempos de espera de conexión, límites de tamaño de respuesta y validación de contenido.

{{% /alert %}}

## **Convertir SVG en un conjunto de formas**

Aspose.Slides puede convertir un SVG en un conjunto de formas, de forma similar a la funcionalidad correspondiente en PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Esta funcionalidad la proporciona una sobrecarga del método [addGroupShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) de la interfaz [IShapeCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IShapeCollection) que acepta un objeto [ISvgImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISvgImage) como primer argumento.

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

## **Añadir imágenes como EMF a diapositivas**

Aspose.Slides for Android via Java te permite generar imágenes EMF a partir de hojas de cálculo de Excel con Aspose.Cells y añadirlas a diapositivas de presentación.

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

        // Añadir el archivo tal cual para que la imagen permanezca como vector EMF en lugar de rasterizarse.
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

## **Reemplazar imágenes en la colección de imágenes**

Aspose.Slides permite reemplazar imágenes almacenadas en la colección de imágenes de una presentación, incluidas las imágenes usadas por formas de diapositivas. Esta sección describe varias formas de actualizar imágenes en la colección. Puedes reemplazar una imagen usando datos binarios crudos, una instancia de [IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/) o otra imagen que ya exista en la colección.

Sigue los pasos siguientes:

1. Carga el archivo de presentación que contiene imágenes usando la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
1. Carga una nueva imagen desde un archivo a una matriz de bytes.
1. Reemplaza la imagen objetivo con la nueva imagen usando la matriz de bytes.
1. En el segundo enfoque, carga la imagen en un objeto [IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/) y reemplaza la imagen objetivo con ese objeto.
1. En el tercer enfoque, reemplaza la imagen objetivo con una imagen que ya exista en la colección de imágenes de la presentación.
1. Guarda la presentación modificada como archivo PPTX.

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

{{% alert title="Información" color="info" %}}

Con el conversor gratuito de Aspose [Texto a GIF](https://products.aspose.app/slides/es/text-to-gif), puedes animar texto fácilmente y crear GIF a partir de texto. 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Se mantiene la resolución original de la imagen después de insertarla?**

Sí. Los píxeles origen se conservan, pero la apariencia final depende de cómo se escale el [picture](/slides/es/androidjava/picture-frame/) en la diapositiva y de cualquier compresión aplicada al guardar.

**¿Cuál es la mejor forma de reemplazar el mismo logotipo en decenas de diapositivas a la vez?**

Coloca el logotipo en la diapositiva maestra o en una distribución y reemplázalo en la colección de imágenes de la presentación; las actualizaciones se propagarán a todos los elementos que usen ese recurso.

**¿Puede un SVG insertado convertirse en formas editables?**

Sí. Puedes convertir un SVG en un conjunto de formas, tras lo cual cada parte individual se vuelve editable con las propiedades estándar de forma.

**¿Cómo puedo establecer una imagen como fondo de varias diapositivas a la vez?**

[Asigna la imagen como fondo](/slides/es/androidjava/presentation-background/) en la diapositiva maestra o en la distribución correspondiente; cualquier diapositiva que use esa maestra/distribución heredará el fondo.

**¿Cómo evito que una presentación se vuelva demasiado grande por la gran cantidad de imágenes?**

Reutiliza un único recurso de imagen en lugar de duplicados, elige resoluciones razonables, aplica compresión al guardar y mantén los gráficos repetidos en la maestra cuando sea apropiado.