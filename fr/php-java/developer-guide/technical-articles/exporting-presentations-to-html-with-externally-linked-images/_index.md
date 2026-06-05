---
title: Exporter des présentations vers HTML avec des images liées externes
type: docs
weight: 100
url: /fr/php-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- exporter PowerPoint
- exporter OpenDocument
- exporter présentation
- exporter diapositive
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
- image liée extérieure
- ressource liée
- ressource externe
- PHP
- Aspose.Slides
description: "Exporter des présentations PowerPoint et OpenDocument vers HTML en PHP via Java en utilisant Aspose.Slides avec les images et autres ressources enregistrées comme fichiers liés externes."
---
## **Vue d'ensemble**

Par défaut, Aspose.Slides exporte une présentation vers un fichier HTML autonome. Les images et autres ressources sont écrites directement dans le HTML, généralement sous forme de données Base64. Cela est pratique lorsque vous avez besoin d’un seul fichier portable, mais ce n’est pas toujours le meilleur format pour un site web, un CMS ou une chaîne de conversion côté serveur.

Utilisez des ressources liées externes lorsque vous voulez :

- réduire la taille du document HTML ;
- mettre en cache les images, polices, audio ou vidéo séparément dans un navigateur ou un CDN ;
- inspecter, remplacer, compresser ou post‑traiter les ressources générées après l’exportation ;
- garder la structure de sortie plus proche de ce qu’attend une application web.

Pour le flux de travail général de conversion HTML, voir [Convertir des présentations PowerPoint en HTML](/slides/fr/php-java/convert-powerpoint-to-html/). Cet article se concentre sur la partie liaison des ressources de l’export.

## **Fonctionnement de l'exportation avec ressources liées**

[HtmlOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/htmloptions/) peut utiliser un contrôleur personnalisé de lien/intégration lorsque Aspose.Slides exporte une présentation en HTML. En PHP via Java, ce scénario est généralement implémenté avec une petite classe d’aide Java. Compilez cette classe, ajoutez‑la au classpath du PHP Java Bridge, et instanciez‑la depuis PHP avec `new Java(...)`.

La classe d’aide décide, ressource par ressource, si l’exportateur intègre les données dans le HTML ou les enregistre à l’extérieur et écrit un lien. Elle nécessite trois méthodes de rappel :

- `ExternalResourceController.getObjectStoringLocation` détermine si une ressource doit être liée ou intégrée.
- `ExternalResourceController.getUrl` renvoie l’URL qui sera écrite dans le HTML généré ou vers une autre ressource liée.
- `ExternalResourceController.saveExternal` écrit les données de la ressource liée sur le disque ou vers une autre destination de stockage.

Le chemin du système de fichiers et l’URL du navigateur sont des préoccupations distinctes. Par exemple, l’exemple ci‑dessous écrit les fichiers de ressources dans `html-output/assets` sur le disque, tandis que le HTML contient des URL relatives comme `assets/resource-1.svg`. Un navigateur résout ces URL par rapport au fichier qui contient le lien. Ainsi, un lien de `presentation.html` vers un fichier SVG utilise `assets/resource-1.svg`, tandis qu’un lien depuis ce fichier SVG vers une image enregistrée dans le même dossier `assets` utilise `resource-4.jpg`.

## **Créer la classe d’aide Java**

Créez une classe Java telle que `com.example.slides.ExternalResourceController`, compilez‑la avec Aspose.Slides for Java dans le classpath, et rendez la classe ou le JAR compilé disponible pour le PHP Java Bridge.

L’aide ci‑dessous lie les ressources d’image, de police, d’audio, de vidéo et de CSS courantes lorsque Aspose.Slides fournit ou peut déduire une extension de fichier sûre. Les ressources non reconnues restent intégrées.

```java
package com.example.slides;

import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public final class ExternalResourceController implements ILinkEmbedController {
    private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionMap();

    private final Path assetDirectory;
    private final String assetUrlPrefix;
    private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

    public ExternalResourceController(String assetDirectory, String assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().isEmpty()) {
            throw new IllegalArgumentException("The asset output directory must not be empty.");
        }

        this.assetDirectory = Paths.get(assetDirectory);
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
    }

    @Override
    public int getObjectStoringLocation(
            int resourceId,
            byte[] entityData,
            String semanticName,
            String contentType,
            String recommendedExtension) {
        String extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId.put(resourceId, "resource-" + resourceId + extension);
        return LinkEmbedDecision.Link;
    }

    @Override
    public String getUrl(int resourceId, int referrer) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (fileNamesByResourceId.containsKey(referrer)) {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    @Override
    public void saveExternal(int resourceId, byte[] entityData) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length == 0) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " contains no data and cannot be saved.");
        }

        Path filePath = assetDirectory.resolve(fileName);
        try {
            Files.createDirectories(assetDirectory);
            Files.write(filePath, entityData);
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Could not save linked resource " + resourceId + " to " + filePath + ".",
                    exception);
        }
    }

    private static Map<String, String> createExtensionMap() {
        Map<String, String> extensions = new HashMap<>();
        extensions.put("image/jpeg", ".jpg");
        extensions.put("image/png", ".png");
        extensions.put("image/gif", ".gif");
        extensions.put("image/bmp", ".bmp");
        extensions.put("image/svg+xml", ".svg");
        extensions.put("image/tiff", ".tiff");
        extensions.put("image/x-emf", ".emf");
        extensions.put("image/x-wmf", ".wmf");
        extensions.put("font/woff", ".woff");
        extensions.put("font/woff2", ".woff2");
        extensions.put("font/ttf", ".ttf");
        extensions.put("application/font-woff", ".woff");
        extensions.put("application/vnd.ms-fontobject", ".eot");
        extensions.put("application/x-font-ttf", ".ttf");
        extensions.put("text/css", ".css");
        extensions.put("audio/mpeg", ".mp3");
        extensions.put("audio/mp4", ".m4a");
        extensions.put("audio/wav", ".wav");
        extensions.put("video/mp4", ".mp4");
        extensions.put("video/webm", ".webm");
        return extensions;
    }

    private static String resolveExtension(String contentType, String recommendedExtension) {
        if (contentType != null && !contentType.trim().isEmpty()) {
            String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(contentType);
            if (mappedExtension != null) {
                return mappedExtension;
            }
        }

        if (!isSupportedContentType(contentType)) {
            return null;
        }

        return normalizeExtension(recommendedExtension);
    }

    private static boolean isSupportedContentType(String contentType) {
        return contentType != null &&
                (contentType.regionMatches(true, 0, "image/", 0, 6) ||
                 contentType.regionMatches(true, 0, "font/", 0, 5) ||
                 contentType.regionMatches(true, 0, "audio/", 0, 6) ||
                 contentType.regionMatches(true, 0, "video/", 0, 6));
    }

    private static String normalizeExtension(String extension) {
        if (extension == null || extension.trim().isEmpty()) {
            return null;
        }

        String extensionCharacters = extension.trim();
        while (extensionCharacters.startsWith(".")) {
            extensionCharacters = extensionCharacters.substring(1);
        }

        for (int characterIndex = 0; characterIndex < extensionCharacters.length(); characterIndex++) {
            if (!Character.isLetterOrDigit(extensionCharacters.charAt(characterIndex))) {
                return null;
            }
        }

        return "." + extensionCharacters.toLowerCase(Locale.ROOT);
    }

    private static String normalizeUrlPrefix(String urlPrefix) {
        if (urlPrefix == null || urlPrefix.isEmpty()) {
            return "";
        }

        String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
        return normalizedUrlPrefix.endsWith("/")
                ? normalizedUrlPrefix
                : normalizedUrlPrefix + "/";
    }
}
```

## **Exporter le HTML avec des ressources liées**

Le code PHP suivant crée un répertoire de sortie, y enregistre le fichier HTML et stocke les ressources liées dans un sous‑répertoire `assets`. Il combine [HtmlOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/htmloptions/), [SVGOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideimageformat/), et [SaveFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveformat/) pour l’exportation.

```php
$inputFilePath = "presentation.pptx";
$outputDirectory = "html-output";
$assetDirectoryName = "assets";
$assetDirectory = $outputDirectory . DIRECTORY_SEPARATOR . $assetDirectoryName;

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the HTML output directory: " . $outputDirectory);
}

if (!is_dir($assetDirectory) && !mkdir($assetDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the asset output directory: " . $assetDirectory);
}

$assetUrlPrefix = $assetDirectoryName . "/";
$controller = new Java("com.example.slides.ExternalResourceController", $assetDirectory, $assetUrlPrefix);
$svgOptions = new SVGOptions($controller);
$slideImageFormat = SlideImageFormat::svg($svgOptions);

$htmlOptions = new HtmlOptions($controller);
$htmlFormatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false);
$htmlOptions->setHtmlFormatter($htmlFormatter);
$htmlOptions->setSlideImageFormat($slideImageFormat);

$presentation = new Presentation($inputFilePath);
try {
    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.html";
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Après l’exportation, le dossier de sortie a cette structure :

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

Les fichiers exacts dépendent du contenu de la présentation et des options d’exportation. Par exemple, les images matricielles sont généralement exportées en JPEG ou PNG. Aspose.Slides peut choisir un codec d’image différent de celui utilisé dans la présentation source lorsque cela produit un fichier plus petit ou plus adapté. Les images avec transparence sont exportées en PNG.

## **Choisir les URL pour le déploiement**

L’exemple utilise un préfixe d’URL relatif : `assets/`. Si `presentation.html` est ouvert depuis `html-output/presentation.html`, le navigateur charge `html-output/assets/resource-1.svg`.

Lorsque une ressource liée fait référence à une autre ressource liée, l’exemple utilise le paramètre `referrer` dans `ExternalResourceController.getUrl` et renvoie uniquement le nom du fichier. Par exemple, si `resource-1.svg` et `resource-4.jpg` se trouvent tous deux dans le dossier `assets`, le fichier SVG doit faire référence à `resource-4.jpg`, pas à `assets/resource-4.jpg`.

Utilisez un préfixe d’URL différent lorsque les fichiers sont déployés ailleurs :

- Utilisez `assets/` lorsque le répertoire d’actifs est à côté du fichier HTML.
- Utilisez `../assets/` lorsque le répertoire d’actifs est un niveau au‑dessus du fichier HTML.
- Utilisez `https://cdn.example.com/presentations/job-123/assets/` lorsque les fichiers sont téléchargés vers un CDN ou un serveur de fichiers statiques.

L’URL renvoyée par `ExternalResourceController.getUrl` doit correspondre à l’emplacement final de déploiement du fichier écrit par `ExternalResourceController.saveExternal`. Dans les applications serveur, utilisez un répertoire de sortie unique ou un préfixe de stockage d’objets pour chaque tâche de conversion afin d’éviter d’écraser les fichiers d’une autre exportation.

## **Quand privilégier l’intégration**

Le HTML intégré en Base64 reste utile lorsque la sortie doit être un fichier unique, comme une pièce jointe d’e‑mail, un aperçu hors ligne, ou un document qui sera déplacé sans dossier d’actifs associé. Les ressources liées sont plus appropriées lorsque le HTML sera servi par une application web, stocké dans un CMS, optimisé par une chaîne de construction, ou mis en cache par les navigateurs indépendamment du HTML.

## **FAQ**

**Puis‑je externaliser uniquement les images et garder les autres ressources intégrées ?**

Oui. Dans `ExternalResourceController.getObjectStoringLocation`, renvoyez la valeur `Link` de [LinkEmbedDecision](https://reference.aspose.com/slides/fr/php-java/aspose.slides/linkembeddecision/) uniquement pour les types de contenu que vous souhaitez enregistrer comme fichiers séparés, et renvoyez la valeur `Embed` pour tout le reste.

**Pourquoi l’extension de l’image exportée diffère‑t‑elle de celle de la présentation source ?**

Aspose.Slides peut ré‑encoder les images matricielles lors de l’exportation HTML afin d’améliorer la taille ou la compatibilité avec les navigateurs. Par exemple, une image provenant du fichier source peut être écrite en JPEG ou PNG selon le rendu obtenu.

**Les URL relatives fonctionnent‑elles après le déplacement du fichier HTML ?**

Les URL relatives ne fonctionnent que lorsque la même structure de dossiers relative est conservée. Si le HTML référence `assets/resource-1.png`, le dossier `assets` doit rester à côté du fichier HTML, sauf si vous générez un préfixe d’URL différent.

**Les applications serveur doivent‑elles réutiliser le même dossier de sortie ?**

Non. Utilisez un répertoire de sortie unique ou un préfixe de stockage pour chaque tâche de conversion. Cela évite les collisions de noms de fichiers et empêche une exportation d’écraser les ressources générées par une autre exportation.