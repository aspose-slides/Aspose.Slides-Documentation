---
title: Convertir PowerPoint en Markdown en Java
type: docs
weight: 140
url: /androidjava/convert-powerpoint-to-markdown/
keywords: "Convertir PowerPoint en Markdown, Convertir ppt en md, PowerPoint, PPT, PPTX, Présentation, Markdown, Java, Aspose.Slides pour Android via Java"
description: "Convertir PowerPoint en Markdown en Java"
---

{{% alert color="info" %}} 

La prise en charge de la conversion de PowerPoint en markdown a été implémentée dans [Aspose.Slides 23.7](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

L'exportation de PowerPoint en markdown est **sans images** par défaut. Si vous souhaitez exporter un document PowerPoint contenant des images, vous devez définir `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` et également définir le `BasePath` où les images référencées dans le document markdown seront enregistrées.

{{% /alert %}} 

## **Convertir PowerPoint en Markdown**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) pour représenter un objet de présentation.
2. Utilisez la méthode [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) pour enregistrer l'objet en tant que fichier markdown.

Ce code Java vous montre comment convertir PowerPoint en markdown :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## Convertir PowerPoint en Markdown Flavor

Aspose.Slides vous permet de convertir PowerPoint en markdown (contenant une syntaxe de base), CommonMark, markdown flavor GitHub, Trello, XWiki, GitLab, et 17 autres saveurs de markdown.

Ce code Java vous montre comment convertir PowerPoint en CommonMark :

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

Les 23 saveurs de markdown prises en charge sont [listées sous l'énumération Flavor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/) de la classe [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/).

## **Convertir une Présentation Contenant des Images en Markdown**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) fournit des propriétés et des énumérations qui vous permettent d'utiliser certaines options ou paramètres pour le fichier markdown résultant. L'énumération [MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/) par exemple, peut être définie sur des valeurs qui déterminent comment les images sont rendues ou traitées : `Sequential`, `TextOnly`, `Visual`.

### **Convertir les Images Séquentiellement**

Si vous souhaitez que les images apparaissent individuellement les unes après les autres dans le markdown résultant, vous devez choisir l'option séquentielle. Ce code Java vous montre comment convertir une présentation contenant des images en markdown :

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

### **Convertir les Images Visuellement**

Si vous souhaitez que les images apparaissent ensemble dans le markdown résultant, vous devez choisir l'option visuelle. Dans ce cas, les images seront enregistrées dans le répertoire actuel de l'application (et un chemin relatif sera construit pour elles dans le document markdown), ou vous pouvez spécifier votre chemin et nom de dossier préférés.

Ce code Java montre l'opération :

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