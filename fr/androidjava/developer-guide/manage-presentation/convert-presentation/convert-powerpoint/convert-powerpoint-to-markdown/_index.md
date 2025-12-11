---
title: Convertir des présentations PowerPoint en Markdown sur Android
linktitle: PowerPoint en Markdown
type: docs
weight: 140
url: /fr/androidjava/convert-powerpoint-to-markdown/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en MD
- présentation en MD
- diapositive en MD
- PPT en MD
- PPTX en MD
- enregistrer PowerPoint au format Markdown
- enregistrer présentation au format Markdown
- enregistrer diapositive au format Markdown
- enregistrer PPT au format MD
- enregistrer PPTX au format MD
- exporter PPT en MD
- exporter PPTX en MD
- PowerPoint
- présentation
- Markdown
- Android
- Java
- Aspose.Slides
description: "Convertir les diapositives PowerPoint—PPT, PPTX—en Markdown propre avec Aspose.Slides pour Android via Java, automatiser la documentation et conserver le formatage."
---

{{% alert color="info" %}} 

La prise en charge de la conversion PowerPoint vers markdown a été implémentée dans [Aspose.Slides 23.7](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

L’exportation PowerPoint vers markdown se fait **sans images** par défaut. Si vous souhaitez exporter un document PowerPoint contenant des images, vous devez définir `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` et également définir le `BasePath` où les images référencées dans le document markdown seront enregistrées.

{{% /alert %}} 

## **Convert PowerPoint to Markdown**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) pour représenter un objet de présentation.  
2. Utilisez la méthode [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) pour enregistrer l’objet sous forme de fichier markdown.

Ce code Java montre comment convertir PowerPoint en markdown :
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Convert PowerPoint to Markdown Flavor**

Aspose.Slides vous permet de convertir PowerPoint en markdown (syntaxe de base), CommonMark, markdown au format GitHub, Trello, XWiki, GitLab et 17 autres variantes de markdown.

Ce code Java montre comment convertir PowerPoint en CommonMark :
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


Les 23 variantes de markdown prises en charge sont [listées dans l’énumération Flavor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/) de la classe [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/).

## **Convert a Presentation Containing Images to Markdown**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) fournit des propriétés et des énumérations qui vous permettent d’utiliser certaines options ou paramètres pour le fichier markdown résultant. L’énumération [MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/) peut, par exemple, être définie sur des valeurs qui déterminent comment les images sont rendues ou gérées : `Sequential`, `TextOnly`, `Visual`.

### **Convert Images Sequentially**

Si vous voulez que les images apparaissent individuellement, les unes après les autres, dans le markdown résultant, vous devez choisir l’option séquentielle. Ce code Java montre comment convertir une présentation contenant des images en markdown :
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


### **Convert Images Visually**

Si vous voulez que les images apparaissent groupées dans le markdown résultant, vous devez choisir l’option visuelle. Dans ce cas, les images seront enregistrées dans le répertoire courant de l’application (et un chemin relatif sera créé pour elles dans le document markdown), ou vous pouvez spécifier votre chemin et nom de dossier préférés.

Ce code Java illustre l’opération :
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


## **FAQ**

**Les hyperliens survivent-ils à l’exportation vers Markdown ?**

Oui. Le texte [hyperliens](/slides/fr/androidjava/manage-hyperlinks/) est conservé sous forme de liens Markdown standards. Les [transitions](/slides/fr/androidjava/slide-transition/) et les [animations](/slides/fr/androidjava/powerpoint-animation/) des diapositives ne sont pas convertis.

**Puis‑je accélérer la conversion en l’exécutant sur plusieurs threads ?**

Vous pouvez paralléliser le traitement fichier par fichier, mais [ne partagez pas](/slides/fr/androidjava/multithreading/) la même instance de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) entre les threads. Utilisez des instances ou processus séparés par fichier pour éviter les contentions.

**Que se passe‑t‑il avec les images — où sont‑elles enregistrées et les chemins sont‑ils relatifs ?**

Les [images](/slides/fr/androidjava/image/) sont exportées vers un dossier dédié, et le fichier Markdown les référence avec des chemins relatifs par défaut. Vous pouvez configurer le chemin de sortie de base et le nom du dossier d’actifs pour maintenir une structure de référentiel prévisible.