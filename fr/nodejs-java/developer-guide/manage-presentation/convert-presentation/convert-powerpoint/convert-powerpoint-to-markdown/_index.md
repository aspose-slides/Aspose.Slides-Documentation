---
title: Convertir les présentations PowerPoint en Markdown en JavaScript
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
- PowerPoint vers MD
- présentation vers MD
- diapositive vers MD
- PPT vers MD
- PPTX vers MD
- enregistrer PowerPoint en Markdown
- enregistrer présentation en Markdown
- enregistrer diapositive en Markdown
- enregistrer PPT en MD
- enregistrer PPTX en MD
- exporter PPT en MD
- exporter PPTX en MD
- exportation d'images Markdown
- liens d'images CDN
- PowerPoint
- présentation
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir les présentations PPT et PPTX en Markdown avec JavaScript et contrôler l'emplacement où les images bitmap, métafichier et SVG exportées sont enregistrées et référencées."
---
## **Vue d'ensemble**

Aspose.Slides for Node.js via Java peut convertir les présentations PPT et PPTX en Markdown pour la documentation, les sites statiques, la migration de contenu et les flux de travail de contrôle de version. Vous pouvez choisir une variante de Markdown, contrôler la façon dont le contenu des diapositives est rendu, et décider où les images exportées sont stockées ainsi que la manière dont le Markdown généré les référence.

Par défaut, l'exportation Markdown utilise une sortie texte uniquement. Pour exporter du contenu visuel, définissez le type d'exportation avec la méthode [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/markdownsaveoptions/) sur la valeur `Sequential` ou `Visual` de l'énumération [MarkdownExportType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/markdownexporttype/). `Sequential` rend les éléments des diapositives séparément et dans l'ordre, tandis que `Visual` maintient les éléments groupés ensemble afin de préserver leur relation visuelle. La valeur `TextOnly` n'émet pas de ressources d'image, ainsi les rappels d'enregistrement d'image ne sont pas appelés dans ce mode.

## **Convertir une présentation en Markdown**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/), puis appelez la méthode [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) avec la valeur `Md` de l'énumération [SaveFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveformat/).

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

## **Sélectionner une variante de Markdown**

La méthode [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/markdownsaveoptions/) contrôle la spécification Markdown utilisée pour la sortie. L'énumération [Flavor](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/flavor/) comprend CommonMark, GitHub Flavored Markdown et d'autres variantes prises en charge.

L'exemple suivant exporte une présentation au format CommonMark :

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

## **Exporter les images en utilisant le comportement d'enregistrement local par défaut**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/markdownsaveoptions/) propose deux méthodes pour configurer l'enregistrement local des images :

- [setBasePath](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/markdownsaveoptions/) spécifie le répertoire de base pour le document Markdown et ses ressources.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/markdownsaveoptions/) spécifie le sous‑répertoire des images. Sa valeur par défaut est `Images`.

L'exemple suivant rend le contenu visuel, écrit les images dans `output/assets` et crée des références d'image relatives dans le document Markdown :

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

Ce comportement sert également de solution de secours lorsqu'un gestionnaire d'enregistrement d'image personnalisé renvoie `false`.

## **Personnaliser l'enregistrement d'images et les liens Markdown**

Utilisez la méthode [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/markdownsaveoptions/) pour enregistrer un rappel pour les ressources bitmap et métafichier non SVG émises lors de l'exportation Markdown. Son rappel `MarkdownImageSavingHandler` reçoit l'objet [IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/), sa valeur [ImageFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/imageformat/) et le lien Markdown généré sous forme de tableau de chaîne à un seul élément. Enregistrez ou téléversez l'image avec le format fourni, et remplacez `link[0]` par la référence qui doit apparaître dans la sortie Markdown.

Les ressources émises au format SVG sont gérées séparément. Enregistrez un rappel avec la méthode [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/markdownsaveoptions/). Son rappel `MarkdownSvgImageSavingHandler` reçoit un objet `ISvgImage` et le tableau `link` à un seul élément. Un SVG n'a pas d'argument `ImageFormat ;` écrivez ou téléversez ses données XML à partir de la méthode `ISvgImage.getSvgData`. Selon le mode d'exportation et le groupement visuel, un SVG dans la présentation source peut être rasterisé ou combiné avec d'autres contenus ; la ressource non SVG résultante est alors transmise au rappel d'enregistrement d'image. Enregistrez les deux rappels lorsque chaque ressource visuelle exportée nécessite un traitement personnalisé.

Dans Node.js, créez des implémentations de ces interfaces de rappel avec `java.newProxy`.

La valeur de retour du gestionnaire détermine qui traite l'image :

- Retourner `true` après que le gestionnaire a enregistré, téléversé, transformé ou traité l'image d'une quelconque manière et a attribué une valeur valide à `link[0]`. Aspose.Slides écrit cette valeur dans le document Markdown et n'effectue pas son enregistrement local par défaut.
- Retourner `false` pour laisser Aspose.Slides enregistrer l'image localement et générer son lien selon les valeurs définies par [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/markdownsaveoptions/) et [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Un gestionnaire qui renvoie `true` prend la responsabilité de l'image. S'il renvoie `true` sans attribuer un lien valide et non vide, l'exportation échoue avec une `InvalidOperationException`.
{{% /alert %}}

### **Enregistrer les images dans un répertoire d'origine CDN et utiliser des URL externes**

L'exemple suivant considère `cdn-origin/presentations/quarterly-report` comme un répertoire d'origine CDN monté ou synchronisé. Chaque gestionnaire extrait le nom de fichier généré, enregistre l'image dans ce répertoire personnalisé et remplace la référence locale générée par une URL CDN publique. L'exemple lui‑même n'effectue aucun téléversement réseau : l'URL devient valide uniquement après que le répertoire est monté comme origine CDN ou que ses fichiers sont publiés sur le CDN. Pour le stockage d'objets, remplacez l'écriture du système de fichiers par l'opération de téléversement du SDK de stockage et attribuez `link[0]` uniquement après la réussite du téléversement.

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

Le gestionnaire bitmap renvoie délibérément `false` pour les images inférieures à 128 × 128 pixels, de sorte qu'Aspose.Slides enregistre ces images dans `output/fallback-images` en utilisant le comportement par défaut. Les ressources bitmap et métafichier plus grandes, ainsi que les ressources SVG, sont traitées par le code personnalisé. Par exemple, une référence locale générée telle que `fallback-images/image1.png` devient `https://cdn.example.com/presentations/quarterly-report/image1.png`. Les gestionnaires utilisent les chemins du système d'exploitation uniquement lors de l'écriture des fichiers ; les liens écrits dans le Markdown utilisent des barres obliques et des noms de fichiers échappés en URL. Appliquez la même règle lors de la création de liens relatifs : utilisez `/`, pas le séparateur de répertoire spécifique à la plateforme.

## **FAQ**

**Un gestionnaire peut‑il traiter à la fois les images raster et les images SVG ?**

Non. Utilisez [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/markdownsaveoptions/) pour les ressources bitmap et métafichier émises et [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/markdownsaveoptions/) pour les ressources émises en SVG. Le premier fournit un objet [IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/) et une valeur [ImageFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/imageformat/); le second fournit un objet `ISvgImage` dont les données SVG peuvent être lues avec `ISvgImage.getSvgData`. Un SVG source rasterisé lors de l'exportation est traité par le rappel d'enregistrement d'image à la place.

**Que se passe‑t‑il lorsqu'un gestionnaire d'enregistrement d'image renvoie `false` ?**

Aspose.Slides utilise son comportement d'enregistrement local par défaut. L'emplacement de l'image et la référence générée sont contrôlés par les valeurs définies avec [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/markdownsaveoptions/) et [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/markdownsaveoptions/).

**Un gestionnaire peut‑il fournir une URL sans enregistrer l'image localement ?**

Oui. Le gestionnaire peut téléverser l'image vers un stockage d'objets ou la transmettre à un autre service, attribuer l'URL résultante à `link[0]` et retourner `true`. Le gestionnaire doit effectuer lui‑même le traitement ; retourner `true` empêche l'enregistrement local par défaut.

**Pourquoi l'exportation Markdown lève‑t‑elle une `InvalidOperationException` provenant d'un gestionnaire ?**

Cette exception se produit lorsque le gestionnaire renvoie `true` mais ne fournit pas de lien valide. Attribuez le chemin relatif ou l'URL externe qui doit être écrit dans le Markdown avant de retourner `true`.

**Quel séparateur de chemin les liens d'image doivent‑ils utiliser ?**

Utilisez des barres obliques dans les liens Markdown et les URL. Utilisez `path.join` uniquement pour les chemins du système de fichiers, puis construisez ou normalisez séparément la référence Markdown.

**Les hyperliens sont‑ils conservés lors de l'exportation Markdown ?**

Oui. Les [hyperliens](/slides/fr/nodejs-java/manage-hyperlinks/) du texte sont conservés sous forme de liens Markdown standard. Les [transitions](/slides/fr/nodejs-java/slide-transition/) et [animations](/slides/fr/nodejs-java/powerpoint-animation/) des diapositives ne sont pas converties.

**Les présentations peuvent‑elles être converties en Markdown en parallèle ?**

Vous pouvez traiter différents fichiers de présentation en parallèle, mais ne partagez pas la même instance [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) entre les threads. Suivez les [directives multithreading](/slides/fr/nodejs-java/multithreading/) et utilisez une instance distincte pour chaque fichier.