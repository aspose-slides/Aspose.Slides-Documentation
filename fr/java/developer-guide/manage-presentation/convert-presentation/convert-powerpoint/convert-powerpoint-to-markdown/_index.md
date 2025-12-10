---
title: Convertir les présentations PowerPoint en Markdown en Java
linktitle: PowerPoint en Markdown
type: docs
weight: 140
url: /fr/java/convert-powerpoint-to-markdown/
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
- enregistrer PowerPoint en Markdown
- enregistrer présentation en Markdown
- enregistrer diapositive en Markdown
- enregistrer PPT en MD
- enregistrer PPTX en MD
- exporter PPT en MD
- exporter PPTX en MD
- PowerPoint
- présentation
- Markdown
- Java
- Aspose.Slides
description: "Convertissez les diapositives PowerPoint—PPT, PPTX—en Markdown propre avec Aspose.Slides pour Java, automatisez la documentation et conservez la mise en forme."
---

{{% alert color="info" %}} 
La prise en charge de la conversion de PowerPoint en markdown a été implémentée dans [Aspose.Slides 23.7](https://docs.aspose.com/slides/java/aspose-slides-for-java-23-7-release-notes/).
{{% /alert %}} 
{{% alert color="warning" %}} 
L'exportation de PowerPoint vers markdown se fait **sans images** par défaut. Si vous souhaitez exporter un document PowerPoint contenant des images, vous devez définir `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` et également définir le `BasePath` où les images référencées dans le document markdown seront enregistrées.
{{% /alert %}} 
## **Convertir PowerPoint en Markdown**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) pour représenter un objet présentation.  
2. Utilisez la [Save ](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)-method pour enregistrer l'objet sous forme de fichier markdown.  

Ce code Java montre comment convertir PowerPoint en markdown :
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint en saveur Markdown**
Aspose.Slides vous permet de convertir PowerPoint en markdown (contenant la syntaxe de base), CommonMark, le markdown au format GitHub, Trello, XWiki, GitLab et 17 autres variantes de markdown.  

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

Les 23 variantes de markdown prises en charge sont listées sous l'énumération [Flavor](https://reference.aspose.com/slides/java/com.aspose.slides/flavor/) de la classe [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/).  
## **Convertir une présentation contenant des images en Markdown**
La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) fournit des propriétés et des énumérations qui vous permettent d'utiliser certaines options ou paramètres pour le fichier markdown résultant. L'énumération [MarkdownExportType](https://reference.aspose.com/slides/java/com.aspose.slides/markdownexporttype/) peut, par exemple, être définie sur des valeurs qui déterminent la façon dont les images sont rendues ou gérées : `Sequential`, `TextOnly`, `Visual`.  
### **Convertir les images séquentiellement**
Si vous souhaitez que les images apparaissent individuellement les unes après les autres dans le markdown résultant, vous devez choisir l'option séquentielle. Ce code Java montre comment convertir une présentation contenant des images en markdown :
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

### **Convertir les images visuellement**
Si vous souhaitez que les images apparaissent toutes ensemble dans le markdown résultant, vous devez choisir l'option visuelle.   Dans ce cas, les images seront enregistrées dans le répertoire actuel de l'application (et un chemin relatif sera généré pour elles dans le document markdown), ou vous pouvez spécifier le chemin et le nom de dossier de votre choix.  
Ce code Java démontre l'opération :
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
**Les hyperliens survivent-ils à l'exportation vers Markdown ?**  
Oui. Les [hyperliens](/slides/fr/java/manage-hyperlinks/) du texte sont conservés en tant que liens Markdown standards. Les [transitions](/slides/fr/java/slide-transition/) et les [animations](/slides/fr/java/powerpoint-animation/) des diapositives ne sont pas converties.  

**Puis-je accélérer la conversion en l'exécutant sur plusieurs threads ?**  
Vous pouvez paralléliser par fichier, mais [ne partagez pas](/slides/fr/java/multithreading/) la même instance de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) entre les threads. Utilisez des instances ou processus séparés par fichier pour éviter les conflits.  

**Que se passe-t-il avec les images — où sont-elles enregistrées, et les chemins sont-ils relatifs ?**  
Les [images](/slides/fr/java/image/) sont exportées vers un dossier dédié, et le fichier Markdown les référence avec des chemins relatifs par défaut. Vous pouvez configurer le chemin de sortie de base et le nom du dossier des ressources pour conserver une structure de dépôt prévisible.