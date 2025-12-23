---
title: Convertir des présentations PowerPoint en Markdown en PHP
linktitle: PowerPoint en Markdown
type: docs
weight: 140
url: /fr/php-java/convert-powerpoint-to-markdown/
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
- PHP
- Aspose.Slides
description: "Convertir les diapositives PowerPoint — PPT, PPTX — en Markdown propre avec Aspose.Slides pour PHP via Java, automatiser la documentation et conserver le formatage."
---

## **Vue d'ensemble**

Aspose.Slides for PHP via Java permet de convertir le contenu des présentations en Markdown, vous permettant de réutiliser les fichiers PowerPoint (PPT, PPTX) et OpenDocument (ODP) pour les wikis, les dépôts Git et les générateurs de sites statiques. L’API préserve la hiérarchie des diapositives tout en produisant un Markdown léger et lisible, vous permettant d’automatiser les pipelines de documentation et de garder les présentations sources et les fichiers Markdown parfaitement synchronisés.

La prise en charge de la conversion PowerPoint‑vers‑Markdown a été implémentée dans [Aspose.Slides 23.7](https://releases.aspose.com/slides/php-java/release-notes/2023/aspose-slides-for-php-via-java-23-7-release-notes/).

## **Convertir une présentation en Markdown**

Cette section explique comment Aspose.Slides convertit les présentations PowerPoint et OpenDocument (PPT, PPTX, ODP) en Markdown propre, en conservant la hiérarchie originale des diapositives, le texte et le formatage de base intacts, afin que vous puissiez réutiliser le contenu dans la documentation ou des flux de travail contrôlés par version sans effort manuel supplémentaire.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) pour représenter la présentation.
1. Utilisez la méthode [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) pour l’exporter en tant que fichier Markdown.

Ce code PHP montre comment convertir une présentation PowerPoint en Markdown:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```


## **Convertir une présentation en variante Markdown**

Aspose.Slides vous permet de convertir des présentations PowerPoint en Markdown avec une syntaxe de base, ainsi qu’en CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab et dix‑sept autres variantes Markdown.

Le code PHP suivant démontre comment convertir une présentation PowerPoint en CommonMark:
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


Les 23 variantes Markdown prises en charge sont répertoriées dans l’[énumération Flavor](https://reference.aspose.com/slides/php-java/aspose.slides/flavor/).

## **Convertir une présentation contenant des images en Markdown**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/) expose des propriétés et des énumérations qui vous permettent de configurer le fichier Markdown résultant. Par exemple, l’énumération [MarkdownExportType](https://reference.aspose.com/slides/php-java/aspose.slides/markdownexporttype/) spécifie la façon dont les images sont gérées : `Sequential`, `TextOnly` ou `Visual`.

{{% alert color="warning" %}}
Par défaut, l’exportation PowerPoint‑vers‑Markdown **n’inclut pas les images**. Pour intégrer des images, appelez `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` et définissez le `BasePath` qui indique où les images référencées dans le fichier Markdown seront enregistrées.
{{% /alert %}}

### **Convertir les images séquentiellement**

Si vous souhaitez que les images apparaissent individuellement, les unes après les autres, dans le Markdown résultant, vous devez choisir l’option `Sequential`. Le code PHP suivant montre comment convertir une présentation contenant des images en Markdown:
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


### **Convertir les images visuellement**

Si vous voulez que les images apparaissent ensemble dans le Markdown résultant, vous devez choisir l’option `Visual`. Dans ce cas, les images sont enregistrées dans le répertoire de travail actuel de l’application (et un chemin relatif est généré pour elles dans le document Markdown), ou vous pouvez spécifier le répertoire et le nom de dossier de votre choix.

Le code PHP suivant démontre l’opération:
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


## **FAQ**

**Les hyperliens survivent-ils à l’exportation en Markdown ?**

Oui. Les [hyperliens](/slides/fr/php-java/manage-hyperlinks/) du texte sont conservés comme des liens Markdown standards. Les [transitions](/slides/fr/php-java/slide-transition/) et les [animations](/slides/fr/php-java/powerpoint-animation/) des diapositives ne sont pas converties.

**Puis-je accélérer la conversion en l’exécutant sur plusieurs threads ?**

Vous pouvez paralléliser entre les fichiers, mais [ne partagez pas](/slides/fr/php-java/multithreading/) la même instance de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) entre les threads. Utilisez des instances/processus séparés par fichier pour éviter les conflits.

**Que se passe-t-il pour les images — où sont‑elles enregistrées et les chemins sont‑ils relatifs ?**

Les [images](/slides/fr/php-java/image/) sont exportées vers un dossier dédié, et le fichier Markdown les référence avec des chemins relatifs par défaut. Vous pouvez configurer le chemin de sortie de base et le nom du dossier d’actifs pour conserver une structure de dépôt prévisible.