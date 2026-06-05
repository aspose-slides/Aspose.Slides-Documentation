---
title: Exporter des présentations en HTML avec des images liées externes
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
- image liée externement
- ressource liée
- ressource externe
- Android
- Java
- Aspose.Slides
description: "Exporter des présentations PowerPoint et OpenDocument vers HTML sur Android via Java en utilisant Aspose.Slides avec les images et autres ressources enregistrées comme fichiers liés externes."
---
## **Vue d'ensemble**

Par défaut, Aspose.Slides exporte une présentation vers un fichier HTML autonome. Les images et autres ressources sont ecrites directement dans le HTML, généralement sous forme de donnees Base64. Cela est pratique lorsque vous avez besoin d'un seul fichier portable, mais ce n'est pas toujours le meilleur format pour une vue web, un CMS, ou un pipeline de conversion côté serveur qui publie ensuite le resultat.

Utilisez des ressources liees externe lorsque vous souhaitez :

- reduire la taille du document HTML;
- mettre en cache les images, polices, audio ou video separement dans un navigateur ou un CDN;
- inspector, remplacer, compresser ou post-traiter les ressources generees apres l'exportation;
- conserver une structure de sortie plus proche de ce qu'attend une application web.

Pour le flux de travail general de conversion HTML, voir [Convertir des presentations PowerPoint en HTML](/slides/fr/androidjava/convert-powerpoint-to-html/). Cet article se concentre sur la partie liaison des ressources de l'exportation.

## **Comment fonctionne l'exportation de ressources liées**

[ILinkEmbedController](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinkembedcontroller/) permet a votre application de decidir, ressource par ressource, si l'exportateur integre les donnees dans le HTML ou les enregistre en externe et ecrit un lien.

L'interface comporte trois methodes :

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinkembedcontroller/) decide si une ressource doit etre liee ou integree.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinkembedcontroller/) retourne l'URL qui sera ecrite dans le HTML genere ou vers une autre ressource liee.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinkembedcontroller/) ecrit les donnees de la ressource liee sur le disque ou vers une autre cible de stockage.

Le chemin du systeme de fichiers et l'URL du navigateur sont des concerns separes. Par exemple, l'exemple ci-dessous ecrit les fichiers de ressources dans `html-output/assets` dans le stockage de fichiers de l'application, tandis que le HTML contient des URLs relatives telles que `assets/resource-1.svg`. Un navigateur resolut ces URLs relatives au fichier qui contient le lien. Ainsi, un lien de `presentation.html` vers un fichier SVG utilise `assets/resource-1.svg`, tandis qu'un lien de ce fichier SVG vers une image enregistree dans le meme dossier `assets` utilise `resource-4.jpg`.

## **Exporter du HTML avec des ressources liées**

L'exemple Android Java suivant cree un repertoire de sortie, enregistre le fichier HTML dedans, et stocke les ressources liees dans un sous-repertoire `assets`. Passez un repertoire possede par l'application tel que `context.getFilesDir()` comme `applicationFilesDirectory`. Le code evite les API `java.nio.file`, il reste donc compatible avec Android `minSdk` 19.

Le controleur lie les ressources d'image, police, audio, video et CSS communes lorsque Aspose.Slides fournit ou peut deduire une extension de fichier sûre. Les ressources qui ne sont pas reconnues restent integrees.

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

Apres l'exportation, le dossier de sortie a cette structure :

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

Les fichiers exacts dependent du contenu de la presentation et des options d'exportation. Par exemple, les images raster sont couramment exportees en JPEG ou PNG. Aspose.Slides peut choisir un codec d'image different de celui utilise dans la presentation source lorsqu cela produit un fichier plus petit ou plus approprie. Les images avec transparence sont exportees en PNG.

## **Choisir les URL pour le deploiement**

L'exemple utilise un prefixe d'URL relative : `assets/`. Si `presentation.html` est ouvert depuis `html-output/presentation.html`, le navigateur charge `html-output/assets/resource-1.svg`.

Lorsque une ressource liee fait reference a une autre ressource liee, l'exemple utilise le parametre `referrer` dans [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinkembedcontroller/) et ne retourne que le nom du fichier. Par exemple, si `resource-1.svg` et `resource-4.jpg` sont tous deux dans le dossier `assets`, le fichier SVG doit referencer `resource-4.jpg`, et non `assets/resource-4.jpg`.

Utilisez un prefixe d'URL different lorsque les fichiers sont deploies ailleurs :

- Utilisez `assets/` lorsque le repertoire d'actifs se trouve a cote du fichier HTML.
- Utilisez `../assets/` lorsque le repertoire d'actifs se trouve un niveau au-dessus du fichier HTML.
- Utilisez `https://cdn.example.com/presentations/job-123/assets/` lorsque les fichiers sont telecharges vers un CDN ou un serveur de fichiers statiques.

L'URL retournee par [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinkembedcontroller/) doit correspondre a l'emplacement final du fichier ecrit par [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinkembedcontroller/). Dans les applications Android, utilisez le stockage specifique a l'application, un repertoire de cache, ou un repertoire obtenu via le Storage Access Framework selon votre flux de travail de publication. Dans les applications serveur, utilisez un repertoire de sortie unique ou un prefixe de stockage d'objet pour chaque job de conversion afin d'eviter d'ecraser les fichiers d'un autre export.

## **Quand integrer a la place**

Le HTML Base64 integre reste utile lorsque la sortie doit etre un seul fichier, comme une piece jointe d'email, un apercu hors ligne, ou un document qui sera deplace sans un dossier d'actifs support. Les ressources liees sont plus appropriees lorsque le HTML sera servi par une application web, stocke dans un CMS, optimise par un pipeline de construction, ou mis en cache par les navigateurs independamment du HTML.

## **FAQ**

**Puis-je externaliser uniquement les images et laisser les autres ressources integrees ?**

Oui. Dans [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinkembedcontroller/), retournez `Link` depuis [LinkEmbedDecision](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/linkembeddecision/) uniquement pour les types de contenu que vous voulez enregistrer comme fichiers separés, et retournez `Embed` pour tout le reste.

**Pourquoi l'extension de l'image exportée diffère-t-elle de celle de la presentation source ?**

Aspose.Slides peut re-encoder les images raster lors de l'exportation HTML afin d'optimiser la taille ou la compatibilite avec le navigateur. Par exemple, une image du fichier source peut etre ecrite en JPEG ou PNG selon le rendu obtenu.

**Les URL relatives fonctionnent-elles après avoir deplace le fichier HTML ?**

Les URL relatives ne fonctionnent que si la meme structure de dossiers relatives est preservee. Si le HTML fait reference a `assets/resource-1.png`, le dossier `assets` doit rester a cote du fichier HTML sauf si vous generez un prefixe d'URL different.

**Puis-je ecrire les ressources sur un stockage externe public sur Android ?**

Oui, si votre application possede une destination valable et le modele d'autorisations approprie pour la version cible d'Android. Pour le HTML genere utilise uniquement par votre application, les fichiers specifique a l'application ou les repertoires de cache sont généralement plus simples. Pour une sortie visible par l'utilisateur, utilisez un emplacement choisi par l'utilisateur ou une autre approche de stockage qui convienne a votre app.

**Les applications serveur doivent-elles reutiliser le meme dossier de sortie ?**

Non. Utilisez un repertoire de sortie unique ou un prefixe de stockage pour chaque job de conversion. Cela evite les collisions de noms de fichiers et empêche un export d'ecraser les ressources generees par un autre export.