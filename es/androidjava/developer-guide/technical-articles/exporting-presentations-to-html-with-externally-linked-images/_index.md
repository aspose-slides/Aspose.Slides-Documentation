---
title: Exportar presentaciones a HTML con imágenes vinculadas externamente
type: docs
weight: 100
url: /es/androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- Android
- Java
- Aspose.Slides
description: "Exportar presentaciones PowerPoint y OpenDocument a HTML en Android mediante Java usando Aspose.Slides, con imágenes y otros recursos guardados como archivos vinculados externamente."
---
## **Visión general**

Por defecto, Aspose.Slides exporta una presentación a un archivo HTML autocontenible. Las imágenes y otros recursos se escriben directamente en el HTML, normalmente como datos Base64. Esto es conveniente cuando necesita un único archivo portátil, pero no siempre es el formato óptimo para una vista web, un CMS o una canalización de conversión del lado del servidor que publique posteriormente la salida.

Utilice recursos vinculados externamente cuando quiera:

- reducir el tamaño del documento HTML;
- almacenar en caché imágenes, fuentes, audio o vídeo por separado en un navegador o CDN;
- inspeccionar, reemplazar, comprimir o posprocesar los recursos generados después de la exportación;
- mantener la estructura de salida más cercana a lo que espera una aplicación web.

Para el flujo de trabajo general de conversión a HTML, consulte [Convert PowerPoint Presentations to HTML](/slides/es/androidjava/convert-powerpoint-to-html/). Este artículo se centra en la parte de enlazado de recursos de la exportación.

## **Cómo funciona la exportación con recursos vinculados**

[ILinkEmbedController](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ilinkembedcontroller/) permite a su aplicación decidir, recurso por recurso, si el exportador incrusta los datos en el HTML o los guarda externamente y escribe un enlace.

La interfaz tiene tres métodos:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ilinkembedcontroller/) decide si un recurso debe estar enlazado o incrustado.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ilinkembedcontroller/) devuelve la URL que se escribirá en el HTML generado o en otro recurso enlazado.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ilinkembedcontroller/) escribe los datos del recurso enlazado en disco o en otro destino de almacenamiento.

La ruta del sistema de archivos y la URL del navegador son cuestiones independientes. Por ejemplo, el ejemplo a continuación escribe los archivos de recursos en `html-output/assets` en el almacenamiento de archivos de la aplicación, mientras que el HTML contiene URL relativas como `assets/resource-1.svg`. Un navegador resuelve esas URL en relación con el archivo que contiene el enlace. Por lo tanto, un enlace de `presentation.html` a un archivo SVG usa `assets/resource-1.svg`, mientras que un enlace de ese archivo SVG a una imagen guardada en la misma carpeta `assets` usa `resource-4.jpg`.

## **Exportar HTML con recursos vinculados**

El siguiente ejemplo de Android Java crea un directorio de salida, guarda el archivo HTML allí y almacena los recursos vinculados en un subdirectorio `assets`. Pase un directorio propio de la aplicación, como `context.getFilesDir()`, como `applicationFilesDirectory`. El código evita las API `java.nio.file`, por lo que sigue siendo compatible con Android `minSdk` 19.

El controlador enlaza recursos comunes de imagen, fuente, audio, vídeo y CSS cuando Aspose.Slides proporciona o puede inferir una extensión de archivo segura. Los recursos que no se reconocen permanecen incrustados.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void exportPresentation(File applicationFilesDirectory) {
        if (applicationFilesDirectory == null) {
            throw new IllegalArgumentException("The application files directory must not be null.");
        }

        File inputFile = new File(applicationFilesDirectory, "presentation.pptx");
        File outputDirectory = new File(applicationFilesDirectory, "html-output");
        String assetDirectoryName = "assets";
        File assetDirectory = new File(outputDirectory, assetDirectoryName);

        createDirectory(outputDirectory, "HTML output");
        createDirectory(assetDirectory, "asset output");

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFile.getAbsolutePath());
        try {
            File htmlFile = new File(outputDirectory, "presentation.html");
            presentation.save(htmlFile.getAbsolutePath(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final File assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<Integer, String>();

        private ExternalResourceController(File assetDirectory, String assetUrlPrefix) {
            if (assetDirectory == null) {
                throw new IllegalArgumentException("The asset output directory must not be null.");
            }

            this.assetDirectory = assetDirectory;
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

            createDirectory(assetDirectory, "asset output");

            File outputFile = new File(assetDirectory, fileName);
            FileOutputStream outputStream = null;
            try {
                outputStream = new FileOutputStream(outputFile);
                outputStream.write(entityData);
            } catch (IOException exception) {
                throw new IllegalStateException(
                        "Failed to save external resource " + resourceId +
                                " to " + outputFile.getAbsolutePath() + ".",
                        exception);
            } finally {
                closeOutputStream(outputStream, outputFile);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<String, String>();
            extensionsByContentType.put("image/jpeg", ".jpg");
            extensionsByContentType.put("image/png", ".png");
            extensionsByContentType.put("image/gif", ".gif");
            extensionsByContentType.put("image/bmp", ".bmp");
            extensionsByContentType.put("image/svg+xml", ".svg");
            extensionsByContentType.put("image/tiff", ".tiff");
            extensionsByContentType.put("image/x-emf", ".emf");
            extensionsByContentType.put("image/x-wmf", ".wmf");
            extensionsByContentType.put("font/woff", ".woff");
            extensionsByContentType.put("font/woff2", ".woff2");
            extensionsByContentType.put("font/ttf", ".ttf");
            extensionsByContentType.put("application/font-woff", ".woff");
            extensionsByContentType.put("application/vnd.ms-fontobject", ".eot");
            extensionsByContentType.put("application/x-font-ttf", ".ttf");
            extensionsByContentType.put("text/css", ".css");
            extensionsByContentType.put("audio/mpeg", ".mp3");
            extensionsByContentType.put("audio/mp4", ".m4a");
            extensionsByContentType.put("audio/wav", ".wav");
            extensionsByContentType.put("video/mp4", ".mp4");
            extensionsByContentType.put("video/webm", ".webm");
            return extensionsByContentType;
        }

        private static String resolveExtension(String contentType, String recommendedExtension) {
            if (contentType != null && !contentType.trim().equals("")) {
                String normalizedContentType = contentType.toLowerCase(Locale.US);
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(normalizedContentType);
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
                    (contentType.regionMatches(true, 0, "image/", 0, "image/".length()) ||
                     contentType.regionMatches(true, 0, "font/", 0, "font/".length()) ||
                     contentType.regionMatches(true, 0, "audio/", 0, "audio/".length()) ||
                     contentType.regionMatches(true, 0, "video/", 0, "video/".length()));
        }

        private static String normalizeExtension(String extension) {
            if (extension == null || extension.trim().equals("")) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.equals("")) {
                return null;
            }

            int characterCount = extensionCharacters.length();
            for (int index = 0; index < characterCount; index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.US);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.equals("")) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }

    private static void createDirectory(File directory, String description) {
        if (directory.exists()) {
            if (!directory.isDirectory()) {
                throw new IllegalStateException(
                        "The " + description + " path exists but is not a directory: " +
                                directory.getAbsolutePath());
            }

            return;
        }

        if (!directory.mkdirs()) {
            throw new IllegalStateException(
                    "Failed to create the " + description + " directory: " +
                            directory.getAbsolutePath());
        }
    }

    private static void closeOutputStream(FileOutputStream outputStream, File outputFile) {
        if (outputStream == null) {
            return;
        }

        try {
            outputStream.close();
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Failed to close the external resource file: " +
                            outputFile.getAbsolutePath(),
                    exception);
        }
    }
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

Los archivos exactos dependen del contenido de la presentación y de las opciones de exportación. Por ejemplo, las imágenes rasterizadas suelen exportarse como JPEG o PNG. Aspose.Slides puede elegir un códec de imagen diferente al utilizado en la presentación original cuando eso produce un archivo más pequeño o más adecuado. Las imágenes con transparencia se exportan como PNG.

## **Elección de URL para la publicación**

El ejemplo utiliza un prefijo de URL relativo: `assets/`. Si `presentation.html` se abre desde `html-output/presentation.html`, el navegador carga `html-output/assets/resource-1.svg`.

Cuando un recurso vinculado hace referencia a otro recurso vinculado, el ejemplo utiliza el parámetro `referrer` en [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ilinkembedcontroller/) y devuelve solo el nombre de archivo. Por ejemplo, si `resource-1.svg` y `resource-4.jpg` están ambos en la carpeta `assets`, el archivo SVG debe referirse a `resource-4.jpg`, no a `assets/resource-4.jpg`.

Utilice un prefijo de URL diferente cuando los archivos se publiquen en otro lugar:

- Utilice `assets/` cuando el directorio de recursos esté junto al archivo HTML.
- Utilice `../assets/` cuando el directorio de recursos esté un nivel arriba del archivo HTML.
- Utilice `https://cdn.example.com/presentations/job-123/assets/` cuando los archivos se suban a un CDN o a un servidor de archivos estático.

La URL devuelta por [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ilinkembedcontroller/) debe coincidir con la ubicación final de publicación del archivo escrito por [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ilinkembedcontroller/). En aplicaciones Android, utilice almacenamiento específico de la aplicación, un directorio de caché o un directorio obtenido a través del Storage Access Framework según su flujo de publicación. En aplicaciones de servidor, utilice un directorio de salida único o un prefijo de almacenamiento de objetos para cada trabajo de conversión para evitar sobrescribir archivos de otra exportación.

## **Cuándo incrustar en su lugar**

El HTML incrustado en Base64 sigue siendo útil cuando la salida debe ser un único archivo, como un adjunto de correo electrónico, una vista previa sin conexión o un documento que se moverá sin una carpeta de recursos de soporte. Los recursos vinculados son más adecuados cuando el HTML será servido por una aplicación web, almacenado en un CMS, optimizado por una canalización de compilación o almacenado en caché por los navegadores de forma independiente del HTML.

## **Preguntas frecuentes**

**¿Puedo externalizar solo las imágenes y mantener los demás recursos incrustados?**

Sí. En [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ilinkembedcontroller/), devuelva `Link` de [LinkEmbedDecision](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/linkembeddecision/) solo para los tipos de contenido que desea guardar como archivos separados, y devuelva `Embed` para todo lo demás.

**¿Por qué la extensión de la imagen exportada difiere de la presentación original?**

Aspose.Slides puede volver a codificar las imágenes rasterizadas durante la exportación a HTML para mejorar el tamaño o la compatibilidad con el navegador. Por ejemplo, una imagen del archivo original puede escribirse como JPEG o PNG según el resultado renderizado.

**¿Funcionan las URL relativas después de mover el archivo HTML?**

Las URL relativas funcionan solo cuando se preserva la misma estructura de carpetas relativa. Si el HTML hace referencia a `assets/resource-1.png`, la carpeta `assets` debe permanecer junto al archivo HTML a menos que genere un prefijo de URL diferente.

**¿Puedo escribir los recursos en almacenamiento externo público en Android?**

Sí, si su aplicación tiene un destino válido y un modelo de permisos para la versión de Android objetivo. Para HTML generado que se utiliza solo en su aplicación, los archivos específicos de la aplicación o los directorios de caché suelen ser más simples. Para salida visible por el usuario, utilice una ubicación seleccionada por el usuario u otro enfoque de almacenamiento que se ajuste a su aplicación.

**¿Deben las aplicaciones de servidor reutilizar la misma carpeta de salida?**

No. Utilice un directorio de salida único o un prefijo de almacenamiento para cada trabajo de conversión. Esto evita colisiones de nombres de archivo y previene que una exportación sobrescriba los recursos generados por otra exportación.