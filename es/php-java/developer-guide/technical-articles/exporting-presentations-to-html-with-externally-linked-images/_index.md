---
title: Exportar presentaciones a HTML con imágenes vinculadas externamente
type: docs
weight: 100
url: /es/php-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- exportar PowerPoint
- exportar OpenDocument
- exportar presentación
- exportar diapositiva
- exportar PPT
- exportar PPTX
- exportar ODP
- PowerPoint a HTML
- OpenDocument a HTML
- presentación a HTML
- diapositiva a HTML
- PPT a HTML
- PPTX a HTML
- ODP a HTML
- imagen vinculada
- imagen vinculada externamente
- recurso vinculado
- recurso externo
- PHP
- Aspose.Slides
description: "Exportar presentaciones de PowerPoint y OpenDocument a HTML en PHP mediante Java usando Aspose.Slides con imágenes y otros recursos guardados como archivos vinculados externamente."
---
## **Descripción general**

Por defecto, Aspose.Slides exporta una presentación a un archivo HTML autónomo. Las imágenes y otros recursos se escriben directamente en el HTML, normalmente como datos Base64. Esto es cómodo cuando se necesita un único archivo portátil, pero no siempre es el formato más adecuado para un sitio web, un CMS o una canalización de conversión del lado del servidor.

Utilice recursos vinculados externamente cuando quiera:

- reducir el tamaño del documento HTML;
- almacenar en caché imágenes, fuentes, audio o vídeo por separado en un navegador o CDN;
- inspeccionar, sustituir, comprimir o procesar posteriormente los recursos generados tras la exportación;
- mantener la estructura de salida más cercana a lo que espera una aplicación web.

Para el flujo de trabajo general de conversión a HTML, consulte [Convertir presentaciones de PowerPoint a HTML](/slides/es/php-java/convert-powerpoint-to-html/). Este artículo se centra en la parte de enlazado de recursos de la exportación.

## **Cómo funciona la exportación con recursos vinculados**

[HtmlOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmloptions/) puede usar un controlador personalizado de enlace/inserción cuando Aspose.Slides exporta una presentación a HTML. En PHP vía Java, este escenario suele implementarse con una pequeña clase auxiliar en Java. Compile esa clase auxiliar, añádala al classpath del PHP Java Bridge e instánciela desde PHP con `new Java(...)`.

La clase auxiliar decide, recurso por recurso, si el exportador inserta los datos en el HTML o los guarda externamente y escribe un enlace. Necesita tres métodos de devolución de llamada:

- `ExternalResourceController.getObjectStoringLocation` decide si un recurso debe enlazarse o incrustarse.
- `ExternalResourceController.getUrl` devuelve la URL que se escribirá en el HTML generado o en otro recurso vinculado.
- `ExternalResourceController.saveExternal` escribe los datos del recurso vinculado en disco o en otro destino de almacenamiento.

La ruta del sistema de archivos y la URL del navegador son preocupaciones distintas. Por ejemplo, el ejemplo siguiente escribe archivos de recursos en `html-output/assets` en disco, mientras que el HTML contiene URLs relativas como `assets/resource-1.svg`. Un navegador resuelve esas URLs en relación con el archivo que contiene el enlace. Por lo tanto, un enlace de `presentation.html` a un archivo SVG usa `assets/resource-1.svg`, mientras que un enlace de ese archivo SVG a una imagen guardada en la misma carpeta `assets` usa `resource-4.jpg`.

## **Crear la clase auxiliar en Java**

Cree una clase Java como `com.example.slides.ExternalResourceController`, compílala con Aspose.Slides para Java en el classpath y haga que la clase compilada o el JAR estén disponibles para PHP Java Bridge.

El ayudante de abajo enlaza recursos comunes de imagen, fuente, audio, vídeo y CSS cuando Aspose.Slides proporciona o puede inferir una extensión de archivo segura. Los recursos que no se reconocen permanecen incrustados.

```java
package com.example.slides;

import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public final class ExternalResourceController implements ILinkEmbedController {
    private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionMap();

    private final Path assetDirectory;
    private final String assetUrlPrefix;
    private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

    public ExternalResourceController(String assetDirectory, String assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().isEmpty()) {
            throw new IllegalArgumentException("The asset output directory must not be empty.");
        }

        this.assetDirectory = Paths.get(assetDirectory);
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
    }

    @Override
    public int getObjectStoringLocation(
            int resourceId,
            byte[] entityData,
            String semanticName,
            String contentType,
            String recommendedExtension) {
        String extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId.put(resourceId, "resource-" + resourceId + extension);
        return LinkEmbedDecision.Link;
    }

    @Override
    public String getUrl(int resourceId, int referrer) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (fileNamesByResourceId.containsKey(referrer)) {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    @Override
    public void saveExternal(int resourceId, byte[] entityData) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length == 0) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " contains no data and cannot be saved.");
        }

        Path filePath = assetDirectory.resolve(fileName);
        try {
            Files.createDirectories(assetDirectory);
            Files.write(filePath, entityData);
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Could not save linked resource " + resourceId + " to " + filePath + ".",
                    exception);
        }
    }

    private static Map<String, String> createExtensionMap() {
        Map<String, String> extensions = new HashMap<>();
        extensions.put("image/jpeg", ".jpg");
        extensions.put("image/png", ".png");
        extensions.put("image/gif", ".gif");
        extensions.put("image/bmp", ".bmp");
        extensions.put("image/svg+xml", ".svg");
        extensions.put("image/tiff", ".tiff");
        extensions.put("image/x-emf", ".emf");
        extensions.put("image/x-wmf", ".wmf");
        extensions.put("font/woff", ".woff");
        extensions.put("font/woff2", ".woff2");
        extensions.put("font/ttf", ".ttf");
        extensions.put("application/font-woff", ".woff");
        extensions.put("application/vnd.ms-fontobject", ".eot");
        extensions.put("application/x-font-ttf", ".ttf");
        extensions.put("text/css", ".css");
        extensions.put("audio/mpeg", ".mp3");
        extensions.put("audio/mp4", ".m4a");
        extensions.put("audio/wav", ".wav");
        extensions.put("video/mp4", ".mp4");
        extensions.put("video/webm", ".webm");
        return extensions;
    }

    private static String resolveExtension(String contentType, String recommendedExtension) {
        if (contentType != null && !contentType.trim().isEmpty()) {
            String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(contentType);
            if (mappedExtension != null) {
                return mappedExtension;
            }
        }

        if (!isSupportedContentType(contentType)) {
            return null;
        }

        return normalizeExtension(recommendedExtension);
    }

    private static boolean isSupportedContentType(String contentType) {
        return contentType != null &&
                (contentType.regionMatches(true, 0, "image/", 0, 6) ||
                 contentType.regionMatches(true, 0, "font/", 0, 5) ||
                 contentType.regionMatches(true, 0, "audio/", 0, 6) ||
                 contentType.regionMatches(true, 0, "video/", 0, 6));
    }

    private static String normalizeExtension(String extension) {
        if (extension == null || extension.trim().isEmpty()) {
            return null;
        }

        String extensionCharacters = extension.trim();
        while (extensionCharacters.startsWith(".")) {
            extensionCharacters = extensionCharacters.substring(1);
        }

        for (int characterIndex = 0; characterIndex < extensionCharacters.length(); characterIndex++) {
            if (!Character.isLetterOrDigit(extensionCharacters.charAt(characterIndex))) {
                return null;
            }
        }

        return "." + extensionCharacters.toLowerCase(Locale.ROOT);
    }

    private static String normalizeUrlPrefix(String urlPrefix) {
        if (urlPrefix == null || urlPrefix.isEmpty()) {
            return "";
        }

        String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
        return normalizedUrlPrefix.endsWith("/")
                ? normalizedUrlPrefix
                : normalizedUrlPrefix + "/";
    }
}
```

## **Exportar HTML con recursos vinculados**

El siguiente código PHP crea un directorio de salida, guarda el archivo HTML allí y almacena los recursos vinculados en un subdirectorio `assets`. Combina [HtmlOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmloptions/), [SVGOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideimageformat/) y [SaveFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveformat/) para la exportación.

```php
$inputFilePath = "presentation.pptx";
$outputDirectory = "html-output";
$assetDirectoryName = "assets";
$assetDirectory = $outputDirectory . DIRECTORY_SEPARATOR . $assetDirectoryName;

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the HTML output directory: " . $outputDirectory);
}

if (!is_dir($assetDirectory) && !mkdir($assetDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the asset output directory: " . $assetDirectory);
}

$assetUrlPrefix = $assetDirectoryName . "/";
$controller = new Java("com.example.slides.ExternalResourceController", $assetDirectory, $assetUrlPrefix);
$svgOptions = new SVGOptions($controller);
$slideImageFormat = SlideImageFormat::svg($svgOptions);

$htmlOptions = new HtmlOptions($controller);
$htmlFormatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false);
$htmlOptions->setHtmlFormatter($htmlFormatter);
$htmlOptions->setSlideImageFormat($slideImageFormat);

$presentation = new Presentation($inputFilePath);
try {
    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.html";
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Después de la exportación, la carpeta de salida tiene esta estructura:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Los archivos exactos dependen del contenido de la presentación y de las opciones de exportación. Por ejemplo, las imágenes rasterizadas se exportan habitualmente como JPEG o PNG. Aspose.Slides puede elegir un códec de imagen diferente al usado en la presentación original cuando eso produce un archivo más pequeño o más adecuado. Las imágenes con transparencia se exportan como PNG.

## **Elección de URLs para la implementación**

El ejemplo usa un prefijo de URL relativo: `assets/`. Si `presentation.html` se abre desde `html-output/presentation.html`, el navegador carga `html-output/assets/resource-1.svg`.

Cuando un recurso vinculado se refiere a otro recurso vinculado, el ejemplo usa el parámetro `referrer` en `ExternalResourceController.getUrl` y devuelve solo el nombre de archivo. Por ejemplo, si `resource-1.svg` y `resource-4.jpg` están ambos en la carpeta `assets`, el archivo SVG debe referirse a `resource-4.jpg`, no a `assets/resource-4.jpg`.

Utilice un prefijo de URL distinto cuando los archivos se desplieguen en otro lugar:

- Use `assets/` cuando el directorio de activos esté junto al archivo HTML.
- Use `../assets/` cuando el directorio de activos esté un nivel por encima del archivo HTML.
- Use `https://cdn.example.com/presentations/job-123/assets/` cuando los archivos se carguen en un CDN o servidor de archivos estático.

La URL devuelta por `ExternalResourceController.getUrl` debe coincidir con la ubicación final donde se despliegue el archivo escrito por `ExternalResourceController.saveExternal`. En aplicaciones de servidor, utilice un directorio de salida único o un prefijo de almacenamiento de objetos para cada trabajo de conversión y evitar sobrescribir archivos de otra exportación.

## **Cuándo incrustar en su lugar**

El HTML incrustado en Base64 sigue siendo útil cuando la salida debe ser un solo archivo, como un adjunto de correo electrónico, una vista previa sin conexión o un documento que se moverá sin una carpeta de activos de soporte. Los recursos vinculados son más apropiados cuando el HTML será servido por una aplicación web, almacenado en un CMS, optimizado por una canalización de compilación o almacenado en caché por los navegadores de forma independiente del HTML.

## **Preguntas frecuentes**

**¿Puedo externalizar solo las imágenes y mantener los demás recursos incrustados?**

Sí. En `ExternalResourceController.getObjectStoringLocation`, devuelva el valor `Link` de [LinkEmbedDecision](https://reference.aspose.com/slides/es/php-java/aspose.slides/linkembeddecision/) solo para los tipos de contenido que desea guardar como archivos separados, y devuelva el valor `Embed` para todo lo demás.

**¿Por qué la extensión de la imagen exportada difiere de la presentación original?**

Aspose.Slides puede volver a codificar imágenes rasterizadas durante la exportación a HTML para mejorar el tamaño o la compatibilidad con el navegador. Por ejemplo, una imagen del archivo origen puede escribirse como JPEG o PNG según el resultado renderizado.

**¿Funcionan las URLs relativas después de mover el archivo HTML?**

Las URLs relativas funcionan solo cuando se conserva la misma estructura de carpetas relativa. Si el HTML hace referencia a `assets/resource-1.png`, la carpeta `assets` debe permanecer junto al archivo HTML a menos que genere un prefijo de URL diferente.

**¿Deben las aplicaciones de servidor reutilizar la misma carpeta de salida?**

No. Utilice un directorio de salida único o un prefijo de almacenamiento para cada trabajo de conversión. Esto evita colisiones de nombres de archivo y evita que una exportación sobrescriba recursos generados por otra exportación.