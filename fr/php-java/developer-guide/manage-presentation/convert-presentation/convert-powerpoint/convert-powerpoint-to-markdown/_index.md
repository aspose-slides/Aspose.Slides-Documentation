---
title: Convertir PowerPoint en Markdown
type: docs
weight: 140
url: /php-java/convert-powerpoint-to-markdown/
keywords: "Convertir PowerPoint en Markdown, Convertir ppt en md, PowerPoint, PPT, PPTX, Présentation, Markdown, Java, Aspose.Slides pour PHP via Java"
description: "Convertir PowerPoint en Markdown"
---

{{% alert color="info" %}} 

Le support pour la conversion de PowerPoint en markdown a été implémenté dans [Aspose.Slides 23.7](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

L’exportation de PowerPoint en markdown est **sans images** par défaut. Si vous souhaitez exporter un document PowerPoint contenant des images, vous devez définir `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` et également définir le `BasePath` où les images référencées dans le document markdown seront sauvegardées.

{{% /alert %}} 

## **Convertir PowerPoint en Markdown**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) pour représenter un objet de présentation.
2. Utilisez la méthode [Save ](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) pour sauvegarder l'objet sous forme de fichier markdown.

Ce code PHP vous montre comment convertir PowerPoint en markdown :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.md", SaveFormat::Md);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Convertir PowerPoint en Markdown Flavor

Aspose.Slides vous permet de convertir PowerPoint en markdown (contenant une syntaxe de base), CommonMark, markdown de GitHub, Trello, XWiki, GitLab et 17 autres goûts de markdown.

Ce code PHP vous montre comment convertir PowerPoint en CommonMark :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setFlavor(Flavor->CommonMark);
    $pres->save("pres.md", SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Les 23 goûts de markdown pris en charge sont [énumérés sous l'énumération Flavor](https://reference.aspose.com/slides/php-java/aspose.slides/flavor/) de la classe [MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/).

## **Convertir une Présentation Contenant des Images en Markdown**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/) fournit des propriétés et des énumérations qui vous permettent d'utiliser certaines options ou paramètres pour le fichier markdown résultant. L'énumération [MarkdownExportType](https://reference.aspose.com/slides/php-java/aspose.slides/markdownexporttype/) peut, par exemple, être définie sur des valeurs qui déterminent comment les images sont rendues ou gérées : `Sequential`, `TextOnly`, `Visual`.

### **Convertir les Images Séquentiellement**

Si vous souhaitez que les images apparaissent individuellement les unes après les autres dans le markdown résultant, vous devez choisir l'option séquentielle. Ce code PHP vous montre comment convertir une présentation contenant des images en markdown :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setShowHiddenSlides(true);
    $markdownSaveOptions->setShowSlideNumber(true);
    $markdownSaveOptions->setFlavor(Flavor->Github);
    $markdownSaveOptions->setExportType(MarkdownExportType::Sequential);
    $markdownSaveOptions->setNewLineType(NewLineType::Windows);
    $pres->save("doc.md", array(1, 2, 3, 4, 5, 6, 7, 8, 9 ), SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Convertir les Images Visuellement**

Si vous souhaitez que les images apparaissent ensemble dans le markdown résultant, vous devez choisir l'option visuelle. Dans ce cas, les images seront sauvegardées dans le répertoire actuel de l'application (et un chemin relatif sera construit pour elles dans le document markdown), ou vous pouvez spécifier votre chemin et nom de dossier préférés.

Ce code PHP démontre l'opération :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $outPath = "c:/documents";
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setExportType(MarkdownExportType::Visual);
    $markdownSaveOptions->setImagesSaveFolderName("md-images");
    $markdownSaveOptions->setBasePath($outPath);
    $pres->save("pres.md", SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```