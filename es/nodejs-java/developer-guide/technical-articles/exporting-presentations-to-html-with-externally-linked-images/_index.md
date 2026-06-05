---
title: Exportar presentaciones a HTML con imágenes vinculadas externamente
type: docs
weight: 100
url: /es/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
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
- JavaScript
- Node.js
- Aspose.Slides
description: "Exportar presentaciones PowerPoint y OpenDocument a HTML en JavaScript usando Aspose.Slides para Node.js a través de Java, con imágenes y otros recursos guardados como archivos externos vinculados."
---
## **Visión general**

De forma predeterminada, Aspose.Slides exporta una presentación a un archivo HTML autocontenido. Las imágenes y otros recursos se escriben directamente en el HTML, normalmente como datos Base64. Esto es cómodo cuando necesita un único archivo portátil, pero no siempre es el formato más adecuado para un sitio web, un CMS o una canalización de conversión del lado del servidor.

Utilice recursos vinculados externamente cuando quiera:

- reducir el tamaño del documento HTML;
- almacenar en caché imágenes, fuentes, audio o vídeo por separado en un navegador o CDN;
- inspeccionar, reemplazar, comprimir o posprocesar los recursos generados tras la exportación;
- mantener la estructura de salida más cercana a lo que espera una aplicación web.

Para el flujo de trabajo general de conversión a HTML, consulte [Convert PowerPoint Presentations to HTML](/slides/es/nodejs-java/convert-powerpoint-to-html/). Este artículo se centra en la parte de enlace de recursos de la exportación.

## **Cómo funciona la exportación con recursos enlazados**

Un proxy Java para [ILinkEmbedController](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilinkembedcontroller/) permite a su aplicación decidir, recurso por recurso, si el exportador incrusta los datos en el HTML o los guarda externamente y escribe un enlace.

El controlador tiene tres métodos:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilinkembedcontroller/) decide si un recurso debe enlazarse o incrustarse.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilinkembedcontroller/) devuelve la URL que se escribirá en el HTML generado o en otro recurso enlazado.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilinkembedcontroller/) escribe los datos del recurso enlazado en disco o en otro destino de almacenamiento.

La ruta del sistema de archivos y la URL del navegador son aspectos separados. Por ejemplo, el ejemplo a continuación escribe los archivos de recursos en `html-output/assets` en disco, mientras que el HTML contiene URLs relativas como `assets/resource-1.svg`. Un navegador resuelve esas URLs en relación al archivo que contiene el enlace. Por lo tanto, un enlace de `presentation.html` a un archivo SVG utiliza `assets/resource-1.svg`, mientras que un enlace de ese archivo SVG a una imagen guardada en la misma carpeta `assets` utiliza `resource-4.jpg`.

## **Exportar HTML con recursos enlazados**

El siguiente ejemplo en JavaScript crea un directorio de salida, guarda el archivo HTML allí y almacena los recursos enlazados en un subdirectorio `assets`. El controlador enlaza recursos comunes de imagen, fuente, audio, vídeo y CSS cuando Aspose.Slides proporciona o puede inferir una extensión de archivo segura. Los recursos que no se reconocen permanecen incrustados.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
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

Los archivos exactos dependen del contenido de la presentación y de las opciones de exportación. Por ejemplo, las imágenes raster típicamente se exportan como JPEG o PNG. Aspose.Slides puede elegir un códec de imagen diferente al usado en la presentación original cuando eso produce un archivo más pequeño o más adecuado. Las imágenes con transparencia se exportan como PNG.

## **Elegir URLs para la implementación**

El ejemplo utiliza un prefijo de URL relativo: `assets/`. Si `presentation.html` se abre desde `html-output/presentation.html`, el navegador carga `html-output/assets/resource-1.svg`.

Cuando un recurso enlazado hace referencia a otro recurso enlazado, el ejemplo usa el parámetro `referrer` en [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilinkembedcontroller/) y devuelve solo el nombre del archivo. Por ejemplo, si `resource-1.svg` y `resource-4.jpg` están ambos en la carpeta `assets`, el archivo SVG debe referirse a `resource-4.jpg`, no a `assets/resource-4.jpg`.

Utilice un prefijo de URL diferente cuando los archivos se implementen en otro lugar:

- Use `assets/` cuando el directorio de recursos está junto al archivo HTML.
- Use `../assets/` cuando el directorio de recursos está un nivel por encima del archivo HTML.
- Use `https://cdn.example.com/presentations/job-123/assets/` cuando los archivos se cargan en un CDN o servidor de archivos estático.

La URL devuelta por [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilinkembedcontroller/) debe coincidir con la ubicación final donde se despliegue el archivo escrito por [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilinkembedcontroller/). En aplicaciones de servidor, utilice un directorio de salida único o un prefijo de almacenamiento de objetos para cada trabajo de conversión, a fin de evitar sobrescribir archivos de otra exportación.

## **Cuándo incrustar en su lugar**

El HTML incrustado en Base64 sigue siendo útil cuando la salida debe ser un único archivo, como un adjunto de correo electrónico, una vista previa sin conexión o un documento que se moverá sin una carpeta de recursos de apoyo. Los recursos enlazados son más adecuados cuando el HTML será servido por una aplicación web, almacenado en un CMS, optimizado por una canalización de compilación o almacenado en caché por los navegadores de forma independiente del HTML.

## **FAQ**

**¿Puedo externalizar solo las imágenes y mantener los demás recursos incrustados?**

Sí. En [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilinkembedcontroller/), devuelva `LinkEmbedDecision.Link` solo para los tipos de contenido que desea guardar como archivos separados, y devuelva `LinkEmbedDecision.Embed` para todo lo demás.

**¿Por qué la extensión de la imagen exportada difiere de la presentación original?**

Aspose.Slides puede volver a codificar imágenes raster durante la exportación a HTML para mejorar el tamaño o la compatibilidad con el navegador. Por ejemplo, una imagen del archivo original puede escribirse como JPEG o PNG según el resultado renderizado.

**¿Funcionan las URLs relativas después de mover el archivo HTML?**

Las URLs relativas solo funcionan cuando se mantiene la misma estructura de carpetas relativa. Si el HTML hace referencia a `assets/resource-1.png`, la carpeta `assets` debe permanecer junto al archivo HTML a menos que se genere un prefijo de URL diferente.

**¿Deben las aplicaciones de servidor reutilizar la misma carpeta de salida?**

No. Utilice un directorio de salida único o un prefijo de almacenamiento para cada trabajo de conversión. Esto evita colisiones de nombres de archivo y previene que una exportación sobrescriba los recursos generados por otra exportación.