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
- PowerPoint
- presentación
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "Convierte diapositivas de PowerPoint en JavaScript—PPT, PPTX—a un Markdown limpio con Aspose.Slides para Node.js mediante Java, automatiza la documentación y conserva el formato."
---

{{% alert color="warning" %}}

La exportación de PowerPoint a markdown es **sin imágenes** por defecto. Si deseas exportar un documento PowerPoint que contenga imágenes, debes llamar a `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` y también establecer el `BasePath` donde se guardarán las imágenes referenciadas en el documento markdown.

{{% /alert %}}

## **Convertir PowerPoint a Markdown**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) para representar un objeto de presentación.
2. Usa el método [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) para guardar el objeto como un archivo markdown.

Este código JavaScript muestra cómo convertir PowerPoint a markdown:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir PowerPoint a un sabor de Markdown**

Aspose.Slides te permite convertir PowerPoint a markdown (con sintaxis básica), CommonMark, markdown con sabor de GitHub, Trello, XWiki, GitLab y 17 sabores de markdown adicionales.

Este código JavaScript muestra cómo convertir PowerPoint a CommonMark:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Los 23 sabores de markdown compatibles están [listados bajo la enumeración Flavor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/flavor/) de la clase [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/).

## **Convertir Presentación que Contenga Imágenes a Markdown**

La clase [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/) proporciona propiedades y enumeraciones que permiten usar determinadas opciones o configuraciones para el archivo markdown resultante. La enumeración [MarkdownExportType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownexporttype/) , por ejemplo, puede establecerse en valores que determinan cómo se procesan o representan las imágenes: `Sequential`, `TextOnly`, `Visual`.

### **Convertir Imágenes Secuencialmente**

Si deseas que las imágenes aparezcan individualmente una tras otra en el markdown resultante, debes elegir la opción secuencial. Este código JavaScript muestra cómo convertir una presentación que contiene imágenes a markdown:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Convertir Imágenes Visualmente**

Si deseas que las imágenes aparezcan juntas en el markdown resultante, debes elegir la opción visual. En este caso, las imágenes se guardarán en el directorio actual de la aplicación (y se construirá una ruta relativa para ellas en el documento markdown), o puedes especificar la ruta y el nombre de carpeta que prefieras.

Este código JavaScript demuestra la operación:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Los hipervínculos sobreviven a la exportación a Markdown?**

Sí. Los [hipervínculos](/slides/es/nodejs-java/manage-hyperlinks/) de texto se conservan como enlaces Markdown estándar. Las [transiciones](/slides/es/nodejs-java/slide-transition/) y [animaciones](/slides/es/nodejs-java/powerpoint-animation/) de diapositivas no se convierten.

**¿Puedo acelerar la conversión ejecutándola en varios hilos?**

Puedes paralelizar por archivos, pero [no compartas](/slides/es/nodejs-java/multithreading/) la misma instancia de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) entre hilos. Utiliza instancias/procesos separados por archivo para evitar contenciones.

**¿Qué ocurre con las imágenes — dónde se guardan y si las rutas son relativas?**

Las [imágenes](/slides/es/nodejs-java/image/) se exportan a una carpeta dedicada, y el archivo Markdown las referencia con rutas relativas por defecto. Puedes configurar la ruta base de salida y el nombre de la carpeta de recursos para mantener una estructura de repositorio predecible.