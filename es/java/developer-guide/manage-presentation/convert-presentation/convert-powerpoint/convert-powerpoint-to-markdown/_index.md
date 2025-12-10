---
title: Convertir presentaciones de PowerPoint a Markdown en Java
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
- PowerPoint
- presentación
- Markdown
- Java
- Aspose.Slides
description: "Convierte diapositivas de PowerPoint—PPT, PPTX—a Markdown limpio con Aspose.Slides para Java, automatiza la documentación y mantiene el formato."
---

{{% alert color="info" %}}
La compatibilidad con la conversión de PowerPoint a markdown se implementó en [Aspose.Slides 23.7](https://docs.aspose.com/slides/java/aspose-slides-for-java-23-7-release-notes/).
{{% /alert %}}
{{% alert color="warning" %}}
La exportación de PowerPoint a markdown es **sin imágenes** de forma predeterminada. Si desea exportar un documento de PowerPoint que contenga imágenes, debe establecer `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` y también establecer el `BasePath` donde se guardarán las imágenes referenciadas en el documento markdown.
{{% /alert %}}
## **Convertir PowerPoint a Markdown**
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) para representar un objeto de presentación.
2. Utilice el método [Save ](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) para guardar el objeto como un archivo markdown.

Este código Java muestra cómo convertir PowerPoint a markdown:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint a variante Markdown**
Aspose.Slides le permite convertir PowerPoint a markdown (con sintaxis básica), CommonMark, markdown con sabor de GitHub, Trello, XWiki, GitLab y otras 17 variantes de markdown.

Este código Java muestra cómo convertir PowerPoint a CommonMark:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


Las 23 variantes de markdown compatibles están [enumeradas bajo la enumeración Flavor](https://reference.aspose.com/slides/java/com.aspose.slides/flavor/) de la clase [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/).
## **Convertir una presentación que contiene imágenes a Markdown**
La clase [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) proporciona propiedades y enumeraciones que le permiten usar ciertas opciones o configuraciones para el archivo markdown resultante. La enumeración [MarkdownExportType](https://reference.aspose.com/slides/java/com.aspose.slides/markdownexporttype/) puede, por ejemplo, establecerse en valores que determinan cómo se renderizan o manejan las imágenes: `Sequential`, `TextOnly`, `Visual`.
### **Convertir imágenes secuencialmente**
Si desea que las imágenes aparezcan individualmente una tras otra en el markdown resultante, debe elegir la opción secuencial. Este código Java muestra cómo convertir una presentación que contiene imágenes a markdown:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Convertir imágenes visualmente**
Si desea que las imágenes aparezcan juntas en el markdown resultante, debe elegir la opción visual. En este caso, las imágenes se guardarán en el directorio actual de la aplicación (y se construirá una ruta relativa para ellas en el documento markdown), o puede especificar la ruta y el nombre de carpeta que prefiera.
Este código Java demuestra la operación:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Preguntas frecuentes**
**¿Los hipervínculos sobreviven a la exportación a Markdown?**  
Sí. El texto [hyperlinks](/slides/es/java/manage-hyperlinks/) se conserva como enlaces Markdown estándar. Las [transitions](/slides/es/java/slide-transition/) y [animations](/slides/es/java/powerpoint-animation/) de las diapositivas no se convierten.
**¿Puedo acelerar la conversión ejecutándola en varios hilos?**  
Puede paralelizar por archivos, pero [don’t share](/slides/es/java/multithreading/) la misma instancia de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) entre hilos. Utilice instancias o procesos separados por archivo para evitar contención.
**¿Qué ocurre con las imágenes—dónde se guardan y son las rutas relativas?**  
[Images](/slides/es/java/image/) se exportan a una carpeta dedicada, y el archivo Markdown los referencia con rutas relativas de forma predeterminada. Puede configurar la ruta base de salida y el nombre de la carpeta de recursos para mantener una estructura de repositorio predecible.