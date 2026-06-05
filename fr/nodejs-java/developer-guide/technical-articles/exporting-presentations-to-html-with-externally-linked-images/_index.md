---
title: Exporter des présentations en HTML avec des images liées externes
type: docs
weight: 100
url: /fr/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- exporter PowerPoint
- exporter OpenDocument
- exporter la présentation
- exporter la diapositive
- exporter PPT
- exporter PPTX
- exporter ODP
- PowerPoint en HTML
- OpenDocument en HTML
- présentation en HTML
- diapositive en HTML
- PPT en HTML
- PPTX en HTML
- ODP en HTML
- image liée
- image liée externement
- ressource liée
- ressource externe
- JavaScript
- Node.js
- Aspose.Slides
description: "Exportez des présentations PowerPoint et OpenDocument vers HTML en JavaScript en utilisant Aspose.Slides pour Node.js via Java, avec les images et autres ressources enregistrées comme fichiers liés externes."
---
## **Vue d'ensemble**

Par defaut, Aspose.Slides exporte une presentation vers un fichier HTML autonome. Les images et autres ressources sont ecrites directement dans le HTML, généralement sous forme de donnees Base64. Cela est pratique lorsque vous avez besoin d'un seul fichier portable, mais ce n'est pas toujours le meilleur format pour un site Web, un CMS ou un pipeline de conversion cote serveur.

Utilisez des ressources liees externement lorsque vous voulez:
- reduire la taille du document HTML;
- mettre en cache les images, polices, audio ou video separement dans un navigateur ou un CDN;
- inspector, remplacer, compresser ou post-traiter les ressources generees apres l'exportation;
- conserver la structure de sortie plus proche de ce qu'une application Web attend.

Pour le workflow general de conversion HTML, consultez [Convertir des presentations PowerPoint en HTML](/slides/fr/nodejs-java/convert-powerpoint-to-html/). Cet article se concentre sur la partie liaison des ressources de l'exportation.

## **Comment fonctionne l'exportation avec ressources liees**

Un proxy Java pour [ILinkEmbedController](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilinkembedcontroller/) permet à votre application de décider, ressource par ressource, si l'exportateur integre les donnees dans le HTML ou les enregistre a l'exterieur et ecrit un lien.

Le controleur possede trois methodes:
- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilinkembedcontroller/) determine si une ressource doit etre liee ou integree.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilinkembedcontroller/) renvoie l'URL qui sera ecrite dans le HTML genere ou vers une autre ressource liee.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilinkembedcontroller/) ecrit les donnees de la ressource liee sur le disque ou vers une autre cible de stockage.

Le chemin du systeme de fichiers et l'URL du navigateur sont des preoccupations distinctes. Par exemple, l'exemple ci-dessous écrit les fichiers de ressources dans `html-output/assets` sur le disque, tandis que le HTML contient des URL relatives comme `assets/resource-1.svg`. Un navigateur resolve ces URL par rapport au fichier qui contient le lien. Ainsi, un lien de `presentation.html` vers un fichier SVG utilise `assets/resource-1.svg`, tandis qu'un lien de ce fichier SVG vers une image enregistree dans le meme dossier `assets` utilise `resource-4.jpg`.

## **Exporter le HTML avec des ressources liees**

L'exemple JavaScript suivant cree un repertoire de sortie, y enregistre le fichier HTML, et stocke les ressources liees dans un sous-repertoire `assets`. Le controleur lie les ressources d'image, de police, audio, video et CSS courantes lorsque Aspose.Slides fournit ou peut deduire une extension de fichier sûre. Les ressources non reconnues restent integrees.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Apres l'exportation, le dossier de sortie a cette structure:
```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Les fichiers exacts dependent du contenu de la presentation et des options d'exportation. Par exemple, les images matricielles sont généralement exportees en JPEG ou PNG. Aspose.Slides peut choisir un codec d'image different de celui utilise dans la presentation source lorsque cela produit un fichier plus petit ou plus adapte. Les images avec transparence sont exportees au format PNG.

## **Choisir les URL pour le deploiement**

L'exemple utilise un prefixe d'URL relatif: `assets/`. Si `presentation.html` est ouvert depuis `html-output/presentation.html`, le navigateur charge `html-output/assets/resource-1.svg`.

Lorsque une ressource liee fait reference a une autre ressource liee, l'exemple utilise le parametre `referrer` dans [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilinkembedcontroller/) et renvoie uniquement le nom de fichier. Par exemple, si `resource-1.svg` et `resource-4.jpg` sont tous deux dans le dossier `assets`, le fichier SVG doit referencer `resource-4.jpg`, et non `assets/resource-4.jpg`.

Utilisez un prefixe d'URL different lorsque les fichiers sont deployes ailleurs:
- Utilisez `assets/` lorsque le repertoire des actifs se trouve a cote du fichier HTML.
- Utilisez `../assets/` lorsque le repertoire des actifs est situe un niveau au-dessus du fichier HTML.
- Utilisez `https://cdn.example.com/presentations/job-123/assets/` lorsque les fichiers sont telecharges sur un CDN ou un serveur de fichiers statiques.

L'URL renvoyee par [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilinkembedcontroller/) doit correspondre a l'emplacement final de deploiement du fichier ecrit par [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilinkembedcontroller/). Dans les applications serveur, utilisez un repertoire de sortie unique ou un prefixe de stockage d'objets pour chaque tache de conversion afin d'eviter d'ecraser les fichiers d'une autre exportation.

## **Quand integrer plutot**

Le HTML integre en Base64 reste utile lorsque la sortie doit etre un seul fichier, comme une piece jointe d'email, un aperçu hors ligne, ou un document qui sera deplace sans dossier d'actifs associe. Les ressources liees conviennent mieux lorsque le HTML sera servi par une application Web, stocke dans un CMS, optimise par un pipeline de construction, ou mis en cache par les navigateurs independamment du HTML.

## **FAQ**

**Puis-je externaliser uniquement les images et garder les autres ressources integrees?**

Oui. Dans [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilinkembedcontroller/), renvoyez `LinkEmbedDecision.Link` uniquement pour les types de contenu que vous souhaitez enregistrer comme fichiers separes, et renvoyez `LinkEmbedDecision.Embed` pour tout le reste.

**Pourquoi l'extension de l'image exportee differe-t-elle de celle de la presentation source?**

Aspose.Slides peut re-encoder les images matricielles lors de l'exportation HTML afin d'ameliorer la taille ou la compatibilite avec les navigateurs. Par exemple, une image du fichier source peut etre ecrite en JPEG ou PNG selon le rendu obtenu.

**Les URL relatives fonctionnent-elles apres avoir deplace le fichier HTML?**

Les URL relatives ne fonctionnent que lorsque la meme structure de dossiers relative est conservee. Si le HTML reference `assets/resource-1.png`, le dossier `assets` doit rester a cote du fichier HTML a moins que vous ne generez un prefixe d'URL different.

**Les applications serveur doivent-elles reutiliser le meme dossier de sortie?**

Non. Utilisez un repertoire de sortie unique ou un prefixe de stockage pour chaque tache de conversion. Cela evite les collisions de noms de fichiers et empêche un export d'ecraser les ressources generatees par un autre export.