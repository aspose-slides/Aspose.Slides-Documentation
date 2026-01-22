---
title: Convertir des présentations PowerPoint en Markdown avec JavaScript
linktitle: PowerPoint vers Markdown
type: docs
weight: 140
url: /fr/nodejs-java/convert-powerpoint-to-markdown/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir les diapositives PowerPoint en JavaScript — PPT, PPTX — en Markdown propre avec Aspose.Slides pour Node.js via Java, automatiser la documentation et conserver la mise en forme."
---

{{% alert color="warning" %}} 
L'exportation PowerPoint vers markdown se fait **sans images** par défaut. Si vous souhaitez exporter un document PowerPoint contenant des images, vous devez appeler `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` et également définir le `BasePath` où les images référencées dans le document markdown seront enregistrées.
{{% /alert %}} 

## **Convertir PowerPoint en Markdown**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) pour représenter un objet de présentation.  
2. Utilisez la méthode [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) pour enregistrer l'objet sous forme de fichier markdown.

Ce code JavaScript vous montre comment convertir PowerPoint en markdown:
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


## **Convertir PowerPoint en variante Markdown**

Aspose.Slides vous permet de convertir PowerPoint en markdown (avec une syntaxe de base), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab et 17 autres variantes markdown.

Ce code JavaScript vous montre comment convertir PowerPoint en CommonMark:
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


Les 23 variantes markdown prises en charge sont [répertoriées sous l'énumération Flavor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/flavor/) de la classe [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/).

## **Convertir une présentation contenant des images en Markdown**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/) fournit des propriétés et des énumérations qui vous permettent d'utiliser certaines options ou paramètres pour le fichier markdown résultant. L'énumération [MarkdownExportType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownexporttype/), par exemple, peut être définie sur des valeurs qui déterminent la façon dont les images sont rendues ou gérées : `Sequential`, `TextOnly`, `Visual`.

### **Convertir les images séquentiellement**

Si vous souhaitez que les images apparaissent individuellement, l'une après l'autre, dans le markdown résultant, vous devez choisir l'option séquentielle. Ce code JavaScript vous montre comment convertir une présentation contenant des images en markdown:
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


### **Convertir les images visuellement**

Si vous souhaitez que les images apparaissent ensemble dans le markdown résultant, vous devez choisir l'option visuelle. Dans ce cas, les images seront enregistrées dans le répertoire actuel de l'application (et un chemin relatif sera créé pour elles dans le document markdown), ou vous pouvez spécifier le chemin et le nom de dossier de votre choix.

Ce code JavaScript démontre l'opération:
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


## **FAQ**

**Les hyperliens survivent-ils à l'exportation vers Markdown ?**

Oui. Le texte des [hyperliens](/slides/fr/nodejs-java/manage-hyperlinks/) est conservé sous forme de liens Markdown standard. Les [transitions](/slides/fr/nodejs-java/slide-transition/) et les [animations](/slides/fr/nodejs-java/powerpoint-animation/) des diapositives ne sont pas convertis.

**Puis-je accélérer la conversion en l'exécutant sur plusieurs threads ?**

Vous pouvez paralléliser entre les fichiers, mais [ne partagez pas](/slides/fr/nodejs-java/multithreading/) la même instance de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) entre les threads. Utilisez des instances/processus distincts par fichier pour éviter les conflits.

**Que se passe-t-il avec les images — où sont‑elles enregistrées et les chemins sont‑ils relatifs ?**

Les [images](/slides/fr/nodejs-java/image/) sont exportées vers un dossier dédié, et le fichier Markdown les référence avec des chemins relatifs par défaut. Vous pouvez configurer le chemin de sortie de base et le nom du dossier d'actifs pour conserver une structure de référentiel prévisible.