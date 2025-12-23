---
title: Convertir presentaciones PowerPoint a Markdown en PHP
linktitle: PowerPoint a Markdown
type: docs
weight: 140
url: /es/php-java/convert-powerpoint-to-markdown/
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
- PHP
- Aspose.Slides
description: "Convierte diapositivas PowerPoint — PPT, PPTX — a Markdown limpio con Aspose.Slides para PHP vía Java, automatiza la documentación y conserva el formato."
---

## **Visión general**

Aspose.Slides for PHP via Java permite la conversión del contenido de presentaciones a Markdown, lo que le permite reutilizar archivos PowerPoint (PPT, PPTX) y OpenDocument (ODP) para wikis, repositorios Git y generadores de sitios estáticos. La API conserva la jerarquía de las diapositivas mientras genera Markdown ligero y legible, de modo que puede automatizar flujos de trabajo de documentación y mantener las presentaciones de origen y los archivos Markdown sincronizados perfectamente.

El soporte para la conversión de PowerPoint a Markdown se implementó en [Aspose.Slides 23.7](https://releases.aspose.com/slides/php-java/release-notes/2023/aspose-slides-for-php-via-java-23-7-release-notes/).

## **Convertir una presentación a Markdown**

Esta sección explica cómo Aspose.Slides convierte presentaciones PowerPoint y OpenDocument (PPT, PPTX, ODP) en Markdown limpio, manteniendo la jerarquía original de las diapositivas, el texto y el formato básico intactos para que pueda reutilizar el contenido en documentación o flujos de trabajo con control de versiones sin esfuerzo manual adicional.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) para representar la presentación.
1. Utilice el método [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) para exportarla como un archivo Markdown.

Este código PHP muestra cómo convertir una presentación PowerPoint a Markdown:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```


## **Convertir una presentación a una variante de Markdown**

Aspose.Slides le permite convertir presentaciones PowerPoint a Markdown con sintaxis básica, así como a CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab y diecisiete variantes adicionales de Markdown.

El siguiente código PHP demuestra cómo convertir una presentación PowerPoint a CommonMark:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```


Las 23 variantes de Markdown compatibles se enumeran en la [enumeración Flavor](https://reference.aspose.com/slides/php-java/aspose.slides/flavor/).

## **Convertir una presentación que contiene imágenes a Markdown**

La clase [MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/) expone propiedades y enumeraciones que le permiten configurar el archivo Markdown resultante. Por ejemplo, la enumeración [MarkdownExportType](https://reference.aspose.com/slides/php-java/aspose.slides/markdownexporttype/) especifica cómo se manejan las imágenes: `Sequential`, `TextOnly` o `Visual`.

{{% alert color="warning" %}}
Por defecto, la exportación de PowerPoint a Markdown **no incluye imágenes**. Para incrustar imágenes, llame a `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` y establezca el `BasePath` que especifica dónde se guardarán las imágenes referenciadas en el archivo Markdown.
{{% /alert %}}

### **Convertir imágenes secuencialmente**

Si desea que las imágenes aparezcan individualmente, una tras otra, en el Markdown resultante, debe elegir la opción `Sequential`. El siguiente código PHP muestra cómo convertir una presentación que contiene imágenes a Markdown:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```


### **Convertir imágenes visualmente**

Si desea que las imágenes aparezcan juntas en el Markdown resultante, debe elegir la opción `Visual`. En este caso, las imágenes se guardan en el directorio actual de la aplicación (y se genera una ruta relativa para ellas en el documento Markdown), o puede especificar el directorio y nombre de carpeta que prefiera.

El siguiente código PHP demuestra la operación:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```


## **Preguntas frecuentes**

**¿Los hipervínculos sobreviven a la exportación a Markdown?**

Sí. Los [hipervínculos](/slides/es/php-java/manage-hyperlinks/) de texto se conservan como enlaces Markdown estándar. Las [transiciones](/slides/es/php-java/slide-transition/) y [animaciones](/slides/es/php-java/powerpoint-animation/) de diapositivas no se convierten.

**¿Puedo acelerar la conversión ejecutándola en varios hilos?**

Puede paralelizar entre archivos, pero [no comparta](/slides/es/php-java/multithreading/) la misma instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) entre hilos. Use instancias/processos separados por archivo para evitar contención.

**¿Qué ocurre con las imágenes—dónde se guardan y son las rutas relativas?**

Las [imágenes](/slides/es/php-java/image/) se exportan a una carpeta dedicada, y el archivo Markdown las referencia con rutas relativas por defecto. Puede configurar la ruta de salida base y el nombre de la carpeta de recursos para mantener una estructura de repositorio predecible.