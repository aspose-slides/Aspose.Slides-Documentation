---
title: Convertir presentaciones PowerPoint a Markdown en Java
linktitle: PowerPoint a Markdown
type: docs
weight: 140
url: /es/java/convert-powerpoint-to-markdown/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a MD
- presentación a MD
- diapositiva a MD
- PPT a MD
- PPTX a MD
- guardar PowerPoint como Markdown
- guardar presentación como Markdown
- guardar diapositiva como Markdown
- guardar PPT como MD
- guardar PPTX como MD
- exportar PPT a MD
- exportar PPTX a MD
- exportación de imágenes Markdown
- enlaces de imágenes CDN
- PowerPoint
- presentación
- Markdown
- Java
- Aspose.Slides
description: "Convertir presentaciones PPT y PPTX a Markdown en Java y controlar dónde se guardan y referencian las imágenes exportadas en bitmap, metarchivo y SVG."
---
## **Visión general**

Aspose.Slides para Java puede convertir presentaciones PPT y PPTX a Markdown para documentación, sitios estáticos, migración de contenido y flujos de trabajo de control de versiones. Puedes elegir un sabor de Markdown, controlar cómo se renderiza el contenido de las diapositivas y decidir dónde se almacenan las imágenes exportadas y cómo el Markdown generado las referencia.

Por defecto, la exportación a Markdown usa salida sólo de texto. Para exportar contenido visual, establece el tipo de exportación con el método [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/es/java/com.aspose.slides/markdownsaveoptions/) al valor `Sequential` o `Visual` de la enumeración [MarkdownExportType](https://reference.aspose.com/slides/es/java/com.aspose.slides/markdownexporttype/). `Sequential` renderiza los elementos de la diapositiva por separado y en orden, mientras que `Visual` mantiene los elementos agrupados juntos para preservar su relación visual. El valor `TextOnly` no genera recursos de imagen, por lo que los callbacks de guardado de imágenes no se invocan en ese modo.

## **Convertir una presentación a Markdown**

Carga el archivo fuente con la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) y luego llama al método [Presentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) con el valor `Md` de la enumeración [SaveFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/saveformat/).

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Seleccionar un sabor de Markdown**

El método [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/es/java/com.aspose.slides/markdownsaveoptions/) controla la especificación de Markdown utilizada para la salida. La enumeración [Flavor](https://reference.aspose.com/slides/es/java/com.aspose.slides/flavor/) incluye CommonMark, GitHub Flavored Markdown y otras variantes compatibles.

El siguiente ejemplo exporta una presentación como CommonMark:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Exportar imágenes usando el comportamiento predeterminado de guardado local**

La clase [MarkdownSaveOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/markdownsaveoptions/) proporciona dos métodos para configurar imágenes guardadas localmente:

- [setBasePath](https://reference.aspose.com/slides/es/java/com.aspose.slides/markdownsaveoptions/) especifica el directorio base para el documento Markdown y sus recursos.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/es/java/com.aspose.slides/markdownsaveoptions/) especifica el subdirectorio de imágenes. Su valor predeterminado es `Images`.

El siguiente ejemplo renderiza contenido visual, escribe imágenes en `output/assets` y crea referencias de imagen relativas en el documento Markdown:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Este comportamiento también sirve como alternativa cuando un manejador personalizado de guardado de imágenes devuelve `false`.

## **Personalizar el guardado de imágenes y los enlaces Markdown**

Utiliza el método [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/es/java/com.aspose.slides/markdownsaveoptions/) para registrar un callback para recursos de bitmap y metarchivo que no sean SVG emitidos durante la exportación a Markdown. Su callback `MarkdownImageSavingHandler` recibe el objeto [IImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/), su valor [ImageFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/imageformat/) y el enlace Markdown generado como un parámetro `String[]` de un solo elemento. Guarda o sube la imagen con el formato suministrado y reemplaza `link[0]` con la referencia que debe aparecer en la salida Markdown.

Los recursos emitidos en formato SVG se manejan por separado. Registra un callback con el método [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/es/java/com.aspose.slides/markdownsaveoptions/). Su callback `MarkdownSvgImageSavingHandler` recibe un objeto [ISvgImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/isvgimage/) y el parámetro `String[] link` de un solo elemento. Un SVG no tiene argumento `ImageFormat`; escribe o sube sus datos XML mediante el método [ISvgImage.getSvgData](https://reference.aspose.com/slides/es/java/com.aspose.slides/isvgimage/). Según el modo de exportación y el agrupamiento visual, un SVG en la presentación de origen puede rasterizarse o combinarse con otros contenidos; el recurso no‑SVG resultante se pasa entonces al callback de guardado de imágenes. Registra ambos callbacks cuando cada recurso visual exportado requiera un procesamiento personalizado.

El valor de retorno del manejador determina quién procesa la imagen:

- Devuelve `true` después de que el manejador haya guardado, subido, transformado o procesado de otro modo la imagen y haya asignado un valor válido a `link[0]`. Aspose.Slides escribe ese valor en el documento Markdown y no realiza su guardado local predeterminado.
- Devuelve `false` para que Aspose.Slides guarde la imagen localmente y genere su enlace según los valores establecidos por [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/es/java/com.aspose.slides/markdownsaveoptions/) y [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/es/java/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Un manejador que devuelve `true` asume la responsabilidad de la imagen. Si devuelve `true` sin asignar un enlace válido y no vacío, la exportación falla con una `InvalidOperationException`.
{{% /alert %}}

### **Guardar imágenes en un directorio origen de CDN y usar URLs externas**

El siguiente ejemplo trata `cdn-origin/presentations/quarterly-report` como un directorio origen de CDN montado o sincronizado. Cada manejador extrae el nombre de archivo generado, guarda la imagen en ese directorio personalizado y reemplaza la referencia local generada con una URL pública de CDN. El ejemplo en sí no realiza ninguna subida de red: la URL solo se vuelve válida después de que el directorio se monte como origen de CDN o sus archivos se publiquen en el CDN. Para almacenamiento de objetos, sustituye la escritura en el sistema de archivos por la operación de subida del SDK de almacenamiento y asigna `link[0]` solo después de que la subida tenga éxito.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

El manejador de bitmap devuelve deliberadamente `false` para imágenes menores de 128 × 128 píxeles, por lo que Aspose.Slides guarda esas imágenes en `output/fallback-images` usando el comportamiento predeterminado. Los recursos de bitmap y metarchivo más grandes, así como los recursos SVG, son manejados por el código personalizado. Por ejemplo, una referencia local generada como `fallback-images/image1.png` se convierte en `https://cdn.example.com/presentations/quarterly-report/image1.png`. Los manejadores utilizan rutas del sistema operativo solo al escribir archivos; los enlaces escritos en Markdown usan barras diagonales y nombres de archivo escapados en URL. Aplica la misma regla al crear enlaces relativos: usa `/`, no el separador de directorios específico de la plataforma.

## **Preguntas frecuentes**

**¿Puede un manejador procesar tanto imágenes raster como imágenes SVG?**

No. Utiliza [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/es/java/com.aspose.slides/markdownsaveoptions/) para los recursos de bitmap y metarchivo emitidos y [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/es/java/com.aspose.slides/markdownsaveoptions/) para los recursos emitidos como SVG. El primero proporciona un objeto [IImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/) y un valor [ImageFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/imageformat/); el segundo proporciona un objeto [ISvgImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/isvgimage/) cuyo dato SVG puede leerse con [ISvgImage.getSvgData](https://reference.aspose.com/slides/es/java/com.aspose.slides/isvgimage/). Un SVG de origen que se rasteriza durante la exportación se procesa mediante el callback de guardado de imágenes.

**¿Qué ocurre cuando un manejador de guardado de imágenes devuelve `false`?**

Aspose.Slides utiliza su comportamiento predeterminado de guardado local. La ubicación de la imagen y la referencia generada están controladas por los valores establecidos con [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/es/java/com.aspose.slides/markdownsaveoptions/) y [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/es/java/com.aspose.slides/markdownsaveoptions/).

**¿Puede un manejador proporcionar una URL sin guardar la imagen localmente?**

Sí. El manejador puede subir la imagen a un almacenamiento de objetos o pasarla a otro servicio, asignar la URL resultante a `link[0]` y devolver `true`. El manejador debe completar el procesamiento por sí mismo; devolver `true` impide el guardado local predeterminado.

**¿Por qué la exportación a Markdown lanza una `InvalidOperationException` desde un manejador?**

Esta excepción se produce cuando el manejador devuelve `true` pero no proporciona un enlace válido. Asigna la ruta relativa o la URL externa que debe escribirse en Markdown antes de devolver `true`.

**¿Qué separador de ruta deben usar los enlaces de imágenes?**

Utiliza barras diagonales (`/`) en los enlaces Markdown y URLs. Usa `Path.resolve` solo para rutas del sistema de archivos y luego construye o normaliza la referencia Markdown por separado.

**¿Se conservan los hipervínculos durante la exportación a Markdown?**

Sí. Los [hipervínculos](/slides/es/java/manage-hyperlinks/) de texto se conservan como enlaces Markdown estándar. Las [transiciones](/slides/es/java/slide-transition/) y [animaciones](/slides/es/java/powerpoint-animation/) de diapositivas no se convierten.

**¿Se pueden convertir presentaciones a Markdown en paralelo?**

Puedes procesar diferentes archivos de presentación en paralelo, pero no compartas la misma instancia de [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) entre hilos. Sigue las [directrices de multihilo](/slides/es/java/multithreading/) y utiliza una instancia independiente para cada archivo.