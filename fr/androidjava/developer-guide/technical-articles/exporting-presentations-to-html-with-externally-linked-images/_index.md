---
title: Exporter des présentations au format HTML avec des images liées externes
type: docs
weight: 100
url: /fr/androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- Android
- Java
- Aspose.Slides
description: "Exporter des présentations PowerPoint et OpenDocument au format HTML sur Android via Java en utilisant Aspose.Slides, avec les images et autres ressources enregistrées comme fichiers liés externes."
---
## **Vue d’ensemble**

Par défaut, Aspose.Slides exporte une présentation vers un fichier HTML autonome. Les images et autres ressources sont écrites directement dans le HTML, généralement sous forme de données Base64. Cela est pratique lorsque vous avez besoin d'un seul fichier portable, mais ce n’est pas toujours le meilleur format pour une vue web, un CMS ou un pipeline de conversion côté serveur qui publie ensuite le résultat.

Utilisez des ressources liées externes lorsque vous souhaitez :

- réduire la taille du document HTML ;
- mettre en cache les images, polices, audio ou vidéo séparément dans un navigateur ou un CDN ;
- inspecter, remplacer, compresser ou post‑traiter les ressources générées après l’exportation ;
- garder la structure de sortie plus proche de ce qu’une application web attend.

Pour le flux de travail général de conversion HTML, voir [Convertir des présentations PowerPoint en HTML](/slides/fr/androidjava/convert-powerpoint-to-html/). Cet article se concentre sur la partie liaison des ressources de l’exportation.

## **Comment fonctionne l’exportation de ressources liées**

[ILinkEmbedController](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinkembedcontroller/) permet à votre application de décider, ressource par ressource, si l’exportateur intègre les données dans le HTML ou les enregistre à l’extérieur et écrit un lien.

L’interface possède trois méthodes :

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinkembedcontroller/) détermine si une ressource doit être liée ou intégrée.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinkembedcontroller/) renvoie l’URL qui sera écrite dans le HTML généré ou dans une autre ressource liée.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinkembedcontroller/) écrit les données de la ressource liée sur le disque ou vers un autre support de stockage.

Le chemin du système de fichiers et l’URL du navigateur sont des préoccupations distinctes. Par exemple, l’exemple ci‑dessous écrit les fichiers de ressources dans `html-output/assets` dans le stockage de fichiers de l’application, tandis que le HTML contient des URL relatives comme `assets/resource-1.svg`. Un navigateur résout ces URL relatives au fichier qui contient le lien. Ainsi, un lien de `presentation.html` vers un fichier SVG utilise `assets/resource-1.svg`, tandis qu’un lien depuis ce fichier SVG vers une image enregistrée dans le même dossier `assets` utilise `resource-4.jpg`.

## **Exporter le HTML avec des ressources liées**

L’exemple Android Java suivant crée un répertoire de sortie, y enregistre le fichier HTML et stocke les ressources liées dans un sous‑répertoire `assets`. Passez un répertoire appartenant à l’application tel que `context.getFilesDir()` comme `applicationFilesDirectory`. Le code évite les API `java.nio.file`, il reste donc compatible avec Android `minSdk` 19.

Le contrôleur lie les ressources d’image, police, audio, vidéo et CSS courantes lorsque Aspose.Slides fournit ou peut déduire une extension de fichier sûre. Les ressources non reconnues restent intégrées.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void exportPresentation(File applicationFilesDirectory) {
        if (applicationFilesDirectory == null) {
            throw new IllegalArgumentException("The application files directory must not be null.");
        }

        File inputFile = new File(applicationFilesDirectory, "presentation.pptx");
        File outputDirectory = new File(applicationFilesDirectory, "html-output");
        String assetDirectoryName = "assets";
        File assetDirectory = new File(outputDirectory, assetDirectoryName);

        createDirectory(outputDirectory, "HTML output");
        createDirectory(assetDirectory, "asset output");

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFile.getAbsolutePath());
        try {
            File htmlFile = new File(outputDirectory, "presentation.html");
            presentation.save(htmlFile.getAbsolutePath(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final File assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<Integer, String>();

        private ExternalResourceController(File assetDirectory, String assetUrlPrefix) {
            if (assetDirectory == null) {
                throw new IllegalArgumentException("The asset output directory must not be null.");
            }

            this.assetDirectory = assetDirectory;
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

            createDirectory(assetDirectory, "asset output");

            File outputFile = new File(assetDirectory, fileName);
            FileOutputStream outputStream = null;
            try {
                outputStream = new FileOutputStream(outputFile);
                outputStream.write(entityData);
            } catch (IOException exception) {
                throw new IllegalStateException(
                        "Failed to save external resource " + resourceId +
                                " to " + outputFile.getAbsolutePath() + ".",
                        exception);
            } finally {
                closeOutputStream(outputStream, outputFile);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<String, String>();
            extensionsByContentType.put("image/jpeg", ".jpg");
            extensionsByContentType.put("image/png", ".png");
            extensionsByContentType.put("image/gif", ".gif");
            extensionsByContentType.put("image/bmp", ".bmp");
            extensionsByContentType.put("image/svg+xml", ".svg");
            extensionsByContentType.put("image/tiff", ".tiff");
            extensionsByContentType.put("image/x-emf", ".emf");
            extensionsByContentType.put("image/x-wmf", ".wmf");
            extensionsByContentType.put("font/woff", ".woff");
            extensionsByContentType.put("font/woff2", ".woff2");
            extensionsByContentType.put("font/ttf", ".ttf");
            extensionsByContentType.put("application/font-woff", ".woff");
            extensionsByContentType.put("application/vnd.ms-fontobject", ".eot");
            extensionsByContentType.put("application/x-font-ttf", ".ttf");
            extensionsByContentType.put("text/css", ".css");
            extensionsByContentType.put("audio/mpeg", ".mp3");
            extensionsByContentType.put("audio/mp4", ".m4a");
            extensionsByContentType.put("audio/wav", ".wav");
            extensionsByContentType.put("video/mp4", ".mp4");
            extensionsByContentType.put("video/webm", ".webm");
            return extensionsByContentType;
        }

        private static String resolveExtension(String contentType, String recommendedExtension) {
            if (contentType != null && !contentType.trim().equals("")) {
                String normalizedContentType = contentType.toLowerCase(Locale.US);
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(normalizedContentType);
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
                    (contentType.regionMatches(true, 0, "image/", 0, "image/".length()) ||
                     contentType.regionMatches(true, 0, "font/", 0, "font/".length()) ||
                     contentType.regionMatches(true, 0, "audio/", 0, "audio/".length()) ||
                     contentType.regionMatches(true, 0, "video/", 0, "video/".length()));
        }

        private static String normalizeExtension(String extension) {
            if (extension == null || extension.trim().equals("")) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.equals("")) {
                return null;
            }

            int characterCount = extensionCharacters.length();
            for (int index = 0; index < characterCount; index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.US);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.equals("")) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }

    private static void createDirectory(File directory, String description) {
        if (directory.exists()) {
            if (!directory.isDirectory()) {
                throw new IllegalStateException(
                        "The " + description + " path exists but is not a directory: " +
                                directory.getAbsolutePath());
            }

            return;
        }

        if (!directory.mkdirs()) {
            throw new IllegalStateException(
                    "Failed to create the " + description + " directory: " +
                            directory.getAbsolutePath());
        }
    }

    private static void closeOutputStream(FileOutputStream outputStream, File outputFile) {
        if (outputStream == null) {
            return;
        }

        try {
            outputStream.close();
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Failed to close the external resource file: " +
                            outputFile.getAbsolutePath(),
                    exception);
        }
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

Les fichiers exacts dépendent du contenu de la présentation et des options d’exportation. Par exemple, les images matricielles sont généralement exportées en JPEG ou PNG. Aspose.Slides peut choisir un codec d’image différent de celui utilisé dans la présentation source lorsque cela produit un fichier plus petit ou plus adapté. Les images avec transparence sont exportées en PNG.

## **Choisir les URL pour le déploiement**

L’exemple utilise un préfixe d’URL relatif : `assets/`. Si `presentation.html` est ouvert depuis `html-output/presentation.html`, le navigateur charge `html-output/assets/resource-1.svg`.

Lorsque une ressource liée fait référence à une autre ressource liée, l’exemple utilise le paramètre `referrer` dans [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinkembedcontroller/) et ne renvoie que le nom du fichier. Par exemple, si `resource-1.svg` et `resource-4.jpg` se trouvent tous deux dans le dossier `assets`, le fichier SVG doit référencer `resource-4.jpg`, pas `assets/resource-4.jpg`.

Utilisez un préfixe d’URL différent lorsque les fichiers sont déployés ailleurs :

- Utilisez `assets/` lorsque le répertoire d’actifs se trouve à côté du fichier HTML.
- Utilisez `../assets/` lorsque le répertoire d’actifs se trouve un niveau au‑dessus du fichier HTML.
- Utilisez `https://cdn.example.com/presentations/job-123/assets/` lorsque les fichiers sont téléchargés vers un CDN ou un serveur de fichiers statiques.

L’URL renvoyée par [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinkembedcontroller/) doit correspondre à l’emplacement final déployé du fichier écrit par [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinkembedcontroller/). Dans les applications Android, utilisez un stockage spécifique à l’application, un répertoire cache, ou un répertoire obtenu via le Storage Access Framework selon votre flux de publication. Dans les applications serveur, utilisez un répertoire de sortie unique ou un préfixe de stockage d’objets pour chaque tâche de conversion afin d’éviter d’écraser les fichiers d’une autre exportation.

## **Quand intégrer plutôt**

Le HTML intégré en Base64 reste utile lorsque la sortie doit être un seul fichier, par exemple une pièce jointe d’e‑mail, un aperçu hors ligne ou un document qui sera déplacé sans dossier d’actifs associé. Les ressources liées conviennent mieux lorsque le HTML sera servi par une application web, stocké dans un CMS, optimisé par un pipeline de construction ou mis en cache par les navigateurs indépendamment du HTML.

## **FAQ**

**Puis‑je externaliser uniquement les images et garder les autres ressources intégrées ?**

Oui. Dans [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinkembedcontroller/), renvoyez `Link` depuis [LinkEmbedDecision](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/linkembeddecision/) uniquement pour les types de contenu que vous souhaitez enregistrer en fichiers séparés, et renvoyez `Embed` pour tout le reste.

**Pourquoi l’extension de l’image exportée diffère‑t‑elle de la présentation source ?**

Aspose.Slides peut ré‑encoder les images matricielles lors de l’exportation HTML afin d’améliorer la taille ou la compatibilité navigateur. Par exemple, une image du fichier source peut être écrite en JPEG ou PNG selon le résultat rendu.

**Les URL relatives fonctionnent‑elles après avoir déplacé le fichier HTML ?**

Les URL relatives ne fonctionnent que si la même structure de dossiers relative est conservée. Si le HTML référence `assets/resource-1.png`, le dossier `assets` doit rester à côté du fichier HTML à moins que vous ne génériez un préfixe d’URL différent.

**Puis‑je écrire des ressources sur un stockage externe public sur Android ?**

Oui, si votre application possède une destination valide et le modèle d’autorisations pour la version Android cible. Pour le HTML généré utilisé uniquement par votre application, les fichiers spécifiques à l’application ou les répertoires cache sont généralement plus simples. Pour une sortie visible par l’utilisateur, utilisez un emplacement choisi par l’utilisateur ou une autre approche de stockage adaptée à votre application.

**Les applications serveur doivent‑elles réutiliser le même dossier de sortie ?**

Non. Utilisez un répertoire de sortie unique ou un préfixe de stockage pour chaque tâche de conversion. Cela évite les collisions de noms de fichiers et empêche une exportation d’écraser les ressources générées par une autre exportation.