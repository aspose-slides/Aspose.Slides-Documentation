---
title: Exporter des présentations au format HTML avec des images liées externes
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
- PowerPoint vers HTML
- OpenDocument vers HTML
- présentation vers HTML
- diapositive vers HTML
- PPT vers HTML
- PPTX vers HTML
- ODP vers HTML
- image liée
- image liée externement
- ressource liée
- ressource externe
- JavaScript
- Node.js
- Aspose.Slides
description: "Exporter des présentations PowerPoint et OpenDocument au format HTML en JavaScript en utilisant Aspose.Slides pour Node.js via Java, avec les images et autres ressources enregistrées en fichiers externes liés."
---
## **Vue d’ensemble**

Par défaut, Aspose.Slides exporte une présentation vers un fichier HTML autonome. Les images et autres ressources sont écrites directement dans le HTML, généralement sous forme de données Base64. Cela est pratique lorsque vous avez besoin d’un seul fichier portable, mais ce n’est pas toujours le meilleur format pour un site web, un CMS ou un pipeline de conversion côté serveur.

Utilisez des ressources liées externes lorsque vous souhaitez :

- réduire la taille du document HTML ;
- mettre en cache séparément les images, polices, audio ou vidéo dans un navigateur ou un CDN ;
- inspecter, remplacer, compresser ou post‑traiter les ressources générées après l’exportation ;
- conserver une structure de sortie plus proche de ce qu’une application web attend.

Pour le flux de travail général de conversion HTML, consultez [Convert PowerPoint Presentations to HTML](/slides/fr/nodejs-java/convert-powerpoint-to-html/). Cet article se concentre sur la partie liaison des ressources de l’exportation.

## **Fonctionnement de l’exportation avec ressources liées**

Un proxy Java pour [ILinkEmbedController](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilinkembedcontroller/) permet à votre application de décider, ressource par ressource, si l’exportateur intègre les données dans le HTML ou les enregistre séparément et écrit un lien.

Le contrôleur possède trois méthodes :

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilinkembedcontroller/) détermine si une ressource doit être liée ou intégrée.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilinkembedcontroller/) renvoie l’URL qui sera écrite dans le HTML généré ou vers une autre ressource liée.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilinkembedcontroller/) écrit les données de la ressource liée sur le disque ou vers une autre destination de stockage.

Le chemin du système de fichiers et l’URL du navigateur sont des préoccupations distinctes. Par exemple, l’exemple ci‑dessous écrit les fichiers de ressources dans `html-output/assets` sur le disque, tandis que le HTML contient des URL relatives comme `assets/resource-1.svg`. Un navigateur résout ces URL par rapport au fichier qui contient le lien. Ainsi, un lien depuis `presentation.html` vers un fichier SVG utilise `assets/resource-1.svg`, tandis qu’un lien depuis ce fichier SVG vers une image enregistrée dans le même dossier `assets` utilise `resource-4.jpg`.

## **Exporter du HTML avec des ressources liées**

L’exemple JavaScript suivant crée un répertoire de sortie, enregistre le fichier HTML à cet emplacement et stocke les ressources liées dans un sous‑répertoire `assets`. Le contrôleur lie les ressources communes d’images, de polices, d’audio, de vidéo et de CSS lorsque Aspose.Slides fournit ou peut déduire une extension de fichier sûre. Les ressources non reconnues restent intégrées.

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

Après l’exportation, le dossier de sortie possède cette structure :

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

Les fichiers exacts dépendent du contenu de la présentation et des options d’exportation. Par exemple, les images matricielles sont généralement exportées au format JPEG ou PNG. Aspose.Slides peut choisir un codec d’image différent de celui utilisé dans la présentation source lorsque cela produit un fichier plus petit ou plus approprié. Les images avec transparence sont exportées au format PNG.

## **Choix des URL pour le déploiement**

L’exemple utilise un préfixe d’URL relatif : `assets/`. Si `presentation.html` est ouvert depuis `html-output/presentation.html`, le navigateur charge `html-output/assets/resource-1.svg`.

Lorsque qu’une ressource liée fait référence à une autre ressource liée, l’exemple utilise le paramètre `referrer` dans [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilinkembedcontroller/) et renvoie uniquement le nom du fichier. Par exemple, si `resource-1.svg` et `resource-4.jpg` se trouvent tous deux dans le dossier `assets`, le fichier SVG doit référencer `resource-4.jpg`, et non `assets/resource-4.jpg`.

Utilisez un préfixe d’URL différent lorsque les fichiers sont déployés ailleurs :

- Utilisez `assets/` lorsque le répertoire d’actifs se trouve à côté du fichier HTML.
- Utilisez `../assets/` lorsque le répertoire d’actifs est un niveau au-dessus du fichier HTML.
- Utilisez `https://cdn.example.com/presentations/job-123/assets/` lorsque les fichiers sont téléchargés sur un CDN ou un serveur de fichiers statiques.

L’URL renvoyée par [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilinkembedcontroller/) doit correspondre à l’emplacement final déployé du fichier écrit par [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilinkembedcontroller/). Dans les applications serveur, utilisez un répertoire de sortie unique ou un préfixe de stockage d’objets pour chaque travail de conversion afin d’éviter d’écraser les fichiers d’une autre exportation.

## **Quand intégrer au lieu de cela**

Le HTML intégré en Base64 reste utile lorsque la sortie doit être un seul fichier, comme une pièce jointe d’email, un aperçu hors ligne ou un document qui sera déplacé sans dossier d’actifs associé. Les ressources liées sont plus appropriées lorsque le HTML sera servi par une application web, stocké dans un CMS, optimisé par une chaîne de construction ou mis en cache par les navigateurs de façon indépendante du HTML.

## **FAQ**

**Puis-je externaliser uniquement les images et laisser les autres ressources intégrées ?**

Oui. Dans [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilinkembedcontroller/), renvoyez `LinkEmbedDecision.Link` uniquement pour les types de contenu que vous souhaitez enregistrer comme fichiers séparés, et renvoyez `LinkEmbedDecision.Embed` pour tout le reste.

**Pourquoi l’extension de l’image exportée diffère‑t‑elle de celle de la présentation source ?**

Aspose.Slides peut ré‑encoder les images matricielles lors de l’exportation HTML afin d’améliorer la taille ou la compatibilité avec les navigateurs. Par exemple, une image du fichier source peut être écrite en JPEG ou en PNG selon le résultat rendu.

**Les URL relatives fonctionnent‑elles après avoir déplacé le fichier HTML ?**

Les URL relatives fonctionnent uniquement si la même structure de dossiers relative est préservée. Si le HTML fait référence à `assets/resource-1.png`, le dossier `assets` doit rester à côté du fichier HTML, sauf si vous générez un préfixe d’URL différent.

**Les applications serveur doivent‑elles réutiliser le même dossier de sortie ?**

Non. Utilisez un répertoire de sortie unique ou un préfixe de stockage pour chaque travail de conversion. Cela évite les collisions de noms de fichiers et empêche une exportation d’écraser les ressources générées par une autre exportation.