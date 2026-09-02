---
title: Convertir presentaciones de PowerPoint a Markdown en JavaScript
linktitle: PowerPoint a Markdown
type: docs
weight: 140
url: /es/nodejs-java/convert-powerpoint-to-markdown/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir presentaciones PPT y PPTX a Markdown en JavaScript y controlar dónde se guardan y referencian las imágenes exportadas en formato bitmap, metafile y SVG."
---
## **Visión general**

Aspose.Slides for Node.js a través de Java puede convertir presentaciones PPT y PPTX a Markdown para documentación, sitios estáticos, migración de contenido y flujos de trabajo de control de versiones. Puede elegir un sabor de Markdown, controlar cómo se representa el contenido de las diapositivas y decidir dónde se almacenan las imágenes exportadas y cómo las referencias Markdown generadas las apuntan.

Por defecto, la exportación a Markdown utiliza salida solo de texto. Para exportar contenido visual, establezca el tipo de exportación con el [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/markdownsaveoptions/) método al valor `Sequential` o `Visual` de la enumeración [MarkdownExportType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/markdownexporttype/). `Sequential` representa los elementos de la diapositiva por separado y en orden, mientras que `Visual` mantiene los elementos agrupados juntos para preservar su relación visual. El valor `TextOnly` no genera recursos de imagen, por lo que los callbacks de guardado de imágenes no se invocan en ese modo.

## **Convertir una presentación a Markdown**

Cargue el archivo origen con la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) y luego llame al método [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) con el valor `Md` de la enumeración [SaveFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveformat/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Seleccionar un sabor de Markdown**

El método [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/markdownsaveoptions/) controla la especificación de Markdown utilizada para la salida. La enumeración [Flavor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/flavor/) incluye CommonMark, GitHub Flavored Markdown y otras variantes compatibles.

El siguiente ejemplo exporta una presentación como CommonMark:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Exportar imágenes usando el comportamiento predeterminado de guardado local**

La clase [MarkdownSaveOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/markdownsaveoptions/) ofrece dos métodos para configurar la guardado local de imágenes:

- [setBasePath](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/markdownsaveoptions/) especifica el directorio base para el documento Markdown y sus recursos.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/markdownsaveoptions/) especifica el subdirectorio de imágenes. Su valor predeterminado es `Images`.

El siguiente ejemplo representa contenido visual, escribe imágenes en `output/assets` y crea referencias de imagen relativas en el documento Markdown:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Este comportamiento también sirve como alternativa cuando un controlador de guardado de imágenes personalizado devuelve `false`.

## **Personalizar el guardado de imágenes y los enlaces Markdown**

Utilice el método [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/markdownsaveoptions/) para registrar un callback para recursos bitmap y metafile que no son SVG emitidos durante la exportación a Markdown. Su callback `MarkdownImageSavingHandler` recibe el objeto [IImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/), su valor [ImageFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imageformat/) y el enlace Markdown generado como una matriz de cadena de un solo elemento. Guarde o suba la imagen con el formato proporcionado y reemplace `link[0]` con la referencia que debe aparecer en la salida Markdown.

Los recursos emitidos en formato SVG se manejan por separado. Registre un callback con el método [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/markdownsaveoptions/). Su callback `MarkdownSvgImageSavingHandler` recibe un objeto `ISvgImage` y la matriz `link` de un solo elemento. Un SVG no tiene argumento `ImageFormat`; escriba o suba sus datos XML mediante el método `ISvgImage.getSvgData`. Según el modo de exportación y el agrupamiento visual, un SVG en la presentación origen puede rasterizarse o combinarse con otro contenido; el recurso resultante que no es SVG se pasa entonces al callback de guardado de imágenes. Registre ambos callbacks cuando cada recurso visual exportado requiera procesamiento personalizado.

En Node.js, cree implementaciones de estas interfaces de callback con `java.newProxy`.

El valor de retorno del controlador determina quién procesa la imagen:

- Devuelva `true` después de que el controlador haya guardado, subido, transformado o procesado la imagen y haya asignado un valor válido a `link[0]`. Aspose.Slides escribe ese valor en el documento Markdown y no realiza su guardado local predeterminado.
- Devuelva `false` para permitir que Aspose.Slides guarde la imagen localmente y genere su enlace según los valores establecidos por [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/markdownsaveoptions/) y [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Un controlador que devuelve `true` asume la responsabilidad de la imagen. Si devuelve `true` sin asignar un enlace válido y no vacío, la exportación falla con una `InvalidOperationException`.
{{% /alert %}}

### **Guardar imágenes en un directorio de origen CDN y usar URLs externas**

El siguiente ejemplo trata `cdn-origin/presentations/quarterly-report` como un directorio de origen CDN montado o sincronizado. Cada controlador extrae el nombre de archivo generado, guarda la imagen en ese directorio personalizado y sustituye la referencia local generada por una URL pública de CDN. El propio ejemplo no realiza ninguna carga de red: la URL solo se vuelve válida después de que el directorio se monte como origen CDN o sus archivos se publiquen en el CDN. Para almacenamiento de objetos, reemplace la escritura en el sistema de archivos por la operación de carga del SDK de almacenamiento y asigne `link[0]` solo después de que la carga haya tenido éxito.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

El controlador de mapa de bits devuelve deliberadamente `false` para imágenes menores de 128 × 128 píxeles, por lo que Aspose.Slides guarda esas imágenes en `output/fallback-images` usando el comportamiento predeterminado. Los recursos de mapa de bits y metafile más grandes, así como los recursos SVG, son gestionados por el código personalizado. Por ejemplo, una referencia local generada como `fallback-images/image1.png` se convierte en `https://cdn.example.com/presentations/quarterly-report/image1.png`. Los controladores usan rutas del sistema operativo solo al escribir archivos; los enlaces escritos en Markdown utilizan barras diagonales (`/`) y nombres de archivo escapados en URL. Aplique la misma regla al crear enlaces relativos: use `/`, no el separador de directorios propio de la plataforma.

## **FAQ**

**¿Puede un controlador procesar tanto imágenes raster como imágenes SVG?**

No. Utilice [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/markdownsaveoptions/) para recursos bitmap y metafile emitidos y [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/markdownsaveoptions/) para recursos emitidos como SVG. El primero proporciona un objeto [IImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/) y un valor [ImageFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imageformat/); el segundo proporciona un objeto `ISvgImage` cuyos datos SVG pueden leerse con `ISvgImage.getSvgData`. Un SVG de origen que se rasteriza durante la exportación se procesa mediante el callback de guardado de imágenes.

**¿Qué ocurre cuando un controlador de guardado de imágenes devuelve `false`?**

Aspose.Slides utiliza su comportamiento predeterminado de guardado local. La ubicación de la imagen y la referencia generada se controlan mediante los valores establecidos con [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/markdownsaveoptions/) y [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/markdownsaveoptions/).

**¿Puede un controlador proporcionar una URL sin guardar la imagen localmente?**

Sí. El controlador puede subir la imagen a un almacenamiento de objetos o pasarla a otro servicio, asignar la URL resultante a `link[0]` y devolver `true`. El controlador debe completar el procesamiento por sí mismo; devolver `true` impide el guardado local predeterminado.

**¿Por qué la exportación a Markdown lanza una `InvalidOperationException` desde un controlador?**

Esta excepción se produce cuando el controlador devuelve `true` pero no proporciona un enlace válido. Asigne la ruta relativa o la URL externa que debe escribirse en Markdown antes de devolver `true`.

**¿Qué separador de rutas deben usar los enlaces de imagen?**

Utilice barras diagonales (`/`) en los enlaces Markdown y URL. Use `path.join` solo para rutas del sistema de archivos, y luego construya o normalice la referencia Markdown por separado.

**¿Se conservan los hipervínculos durante la exportación a Markdown?**

Sí. Los [hipervínculos](/slides/es/nodejs-java/manage-hyperlinks/) de texto se conservan como enlaces Markdown estándar. Las [transiciones](/slides/es/nodejs-java/slide-transition/) y [animaciones](/slides/es/nodejs-java/powerpoint-animation/) de diapositivas no se convierten.

**¿Pueden las presentaciones convertirse a Markdown en paralelo?**

Puede procesar diferentes archivos de presentación en paralelo, pero no comparta la misma instancia de [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) entre hilos. Siga las [directrices de multihilo](/slides/es/nodejs-java/multithreading/) y utilice una instancia separada para cada archivo.