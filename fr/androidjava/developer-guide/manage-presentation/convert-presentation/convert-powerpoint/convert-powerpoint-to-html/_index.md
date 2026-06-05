---
title: Convertir les présentations PowerPoint en HTML sur Android
linktitle: PowerPoint en HTML
type: docs
weight: 30
url: /fr/androidjava/convert-powerpoint-to-html/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en HTML
- présentation en HTML
- diapositive en HTML
- PPT en HTML
- PPTX en HTML
- enregistrer PowerPoint en HTML
- enregistrer présentation en HTML
- enregistrer diapositive en HTML
- enregistrer PPT en HTML
- enregistrer PPTX en HTML
- exporter PPT en HTML
- exporter PPTX en HTML
- Android
- Java
- Aspose.Slides
description: "Convertir les présentations PowerPoint en HTML sur Android. Utilisez Aspose.Slides pour Android via Java pour exporter des fichiers PPT et PPTX, des diapositives sélectionnées, des notes, des polices, des images, du SVG et des médias."
---
## **Aperçu**

Aspose.Slides for Android via Java peut enregistrer des présentations PowerPoint au format HTML sans Microsoft PowerPoint. La conversion de base consiste en un chargement d’un [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) et un appel `save` avec [SaveFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveformat/). Utilisez [HtmlOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/htmloptions/) lorsque vous devez contrôler la mise en page exportée, les polices, les images, les notes, les commentaires, la sortie SVG ou les ressources liées.

Ce guide se concentre sur des scénarios pratiques d’exportation HTML :

- Exporter une présentation complète ou des diapositives sélectionnées.
- Générer du HTML à mise en page fixe, réactif ou basé sur SVG.
- Inclure les notes du présentateur et les commentaires.
- Contrôler la qualité des images et les données d’image recadrées.
- Intégrer les polices ou enregistrer les fichiers de police séparément.
- Choisir la façon dont les ressources externes et les fichiers multimédias sont écrits et référencés.

Par défaut, l’exportation HTML produit un document HTML autonome où la plupart des ressources sont intégrées. Cela est pratique pour partager un seul fichier, mais cela peut augmenter la taille du résultat. Pour la publication sur le web, envisagez d’utiliser des ressources externes, de réduire le DPI des images, et d’intégrer uniquement les polices qui ne sont pas fiables dans l’environnement cible.

## **Convertir une présentation en HTML**

Pour exporter une présentation en HTML, chargez‑la avec [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) et enregistrez‑la avec [SaveFormat.Html](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Cet exemple écrit un fichier HTML. L’objet presentation est libéré dans le bloc `finally`, ce qui libère les poignées de fichiers et les ressources de rendu après l’exportation.

## **Utiliser HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/htmloptions/) est la classe principale de configuration pour l’exportation HTML. Les paramètres courants incluent :

- `SlidesLayoutOptions` : ajoute des notes, des commentaires, des documents ou d’autres informations de mise en page.
- `HtmlFormatter` : modifie la structure du document HTML ou délègue le formatage à un contrôleur.
- `SlideImageFormat` : change la façon dont les diapositives sont représentées, par exemple en SVG.
- `PicturesCompression` : contrôle le DPI des images et la taille du résultat.
- `DeletePicturesCroppedAreas` : conserve ou supprime les données d’image recadrées.
- `SvgResponsiveLayout` : rend le contenu SVG exporté adaptable à son conteneur.
- `ShowHiddenSlides` : inclut les diapositives masquées lorsqu’elles sont nécessaires.

Les sections suivantes montrent séparément les options les plus courantes afin que vous puissiez combiner uniquement celles dont votre flux de travail a besoin.

## **Convertir des diapositives sélectionnées en HTML**

La surcharge `Presentation.save` qui accepte des numéros de diapositives utilise des positions de diapositives indexées à partir de 1. La boucle suivante enregistre chaque diapositive dans un fichier HTML séparé.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Utilisez ce modèle lorsqu’un site web ou une application nécessite une page HTML par diapositive. Si chaque diapositive doit avoir la même mise en page, créez une instance de [HtmlOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/htmloptions/) et transmettez‑la à chaque appel `save`.

## **Créer du HTML réactif**

[ResponsiveHtmlController](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/responsivehtmlcontroller/) fournit une sortie HTML réactive via [HtmlFormatter](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/htmlformatter/). Utilisez‑le lorsque la page exportée doit mieux s’adapter à la largeur du navigateur.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Pour une mise en page réactive basée sur SVG, définissez `SvgResponsiveLayout` sur [HtmlOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/htmloptions/). Cela est utile lorsque le contenu des diapositives est exporté sous forme de balisage SVG évolutif.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Inclure les notes du présentateur et les commentaires**

Utilisez [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/notescommentslayoutingoptions/) via `HtmlOptions.SlidesLayoutOptions` pour inclure les notes du présentateur ou les commentaires. Les notes et les commentaires sont masqués par défaut, sauf si vous choisissez leurs positions.

Supposons que la présentation source contienne des notes du présentateur :

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Le code suivant exporte le contenu de la diapositive avec les notes du présentateur sous la diapositive.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Le HTML exporté inclut la zone des notes :

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Pour exporter les commentaires, définissez `CommentsPosition`, par exemple sur `CommentsPositions.Right` ou `CommentsPositions.Bottom`. Si vous avez besoin uniquement des commentaires, omettez `NotesPosition`. Si vous avez besoin à la fois des notes et des commentaires, définissez les deux propriétés.

## **Contrôler la qualité des images et les zones recadrées**

L’exportation HTML peut compresser les images des diapositives afin de réduire la taille du résultat. Définissez `PicturesCompression` sur une valeur provenant de [PicturesCompression](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/picturescompression/) lorsque vous avez besoin d’une qualité d’image supérieure.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Par défaut, les zones recadrées des images peuvent être supprimées du résultat exporté. Conservez les données recadrées uniquement lorsque les utilisateurs doivent pouvoir récupérer ou inspecter ces parties d’image masquées. Leur conservation peut augmenter la taille du HTML.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Ajouter du CSS**

Pour un style simple, transmettez une chaîne CSS à `HtmlFormatter.createDocumentFormatter`. Cela modifie le document HTML environnant tandis qu’Aspose.Slides continue de rendre le contenu des diapositives.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Pour un en‑tête de document personnalisé, un fichier CSS lié ou un balisage personnalisé autour des diapositives et des formes, implémentez [IHtmlFormattingController](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihtmlformattingcontroller/) et transmettez‑le à [HtmlFormatter](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/htmlformatter/) avec `createCustomFormatter`.

## **Intégrer les polices**

Si l’environnement cible ne possède pas forcément les polices de la présentation installées, intégrez les polices dans le HTML avec [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/embedallfontshtmlcontroller/). L’intégration améliore la fidélité visuelle mais augmente la taille du résultat.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial", "Calibri" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Excluez les polices uniquement lorsque vous êtes certain que les navigateurs ou systèmes cibles les fournissent déjà. Pour des polices de marque ou moins courantes, l’intégration est généralement plus sûre.

## **Lier les fichiers de police au lieu de les intégrer**

Pour réduire la taille du fichier HTML, vous pouvez écrire les données de police dans des fichiers WOFF séparés et ajouter des règles `@font-face` au HTML. L’assistant ci‑dessous étend [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) et surcharge `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final String fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            String fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";
        
        File dirs = new File(fontOutputDirectory);
        dirs.mkdirs();
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            String fontFilePath = fontOutputDirectory + "/" + fontFileName;

            FileOutputStream fos = new FileOutputStream(fontFilePath);
            fos.write(fontData);
            fos.close();

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

String outputDirectory = System.getProperty("user.dir") + "/html-output";
String fontsDirectory = outputDirectory + "/fonts";
File dir = new File("path/to/folder");
dir.mkdir();

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    String htmlFilePath = outputDirectory + "/presentation.html";
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Dans cet exemple, les fichiers de police sont enregistrés dans `html-output/fonts`, et le HTML les référence avec des URL telles que `fonts/BrandFont-normal-400.woff`. Si le fichier HTML et les polices sont déployés à un autre emplacement, choisissez `fontUrlPrefix` afin qu’il corresponde au chemin URL déployé.

## **Enregistrer les ressources à l’extérieur**

Le HTML autonome est facile à déplacer, mais les ressources Base64 intégrées peuvent rendre le fichier volumineux. Si votre application a besoin de fichiers image externes, implémentez [ILinkEmbedController](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinkembedcontroller/) et transmettez‑le au constructeur de [HtmlOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/htmloptions/).

Lorsque vous externalisez les ressources, choisissez délibérément deux chemins :

- Le chemin de sortie du système de fichiers, où votre application écrit les images, polices, audio ou vidéo générés.
- Le chemin URL, qui est ce que le navigateur utilise depuis le document HTML pour charger ces fichiers.

## **Exporter les fichiers multimédias**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) exporte les fichiers vidéo et audio et écrit du HTML pouvant les lire dans un navigateur. Son constructeur prend :

- `path` : le répertoire où les fichiers multimédias générés seront écrits.
- `fileName` : le nom du fichier HTML en cours de génération.
- `baseUri` : le préfixe URI absolu utilisé dans les liens HTML vers les fichiers multimédias.

Si le fichier HTML est `html-output/presentation.html` et que les fichiers multimédias sont enregistrés dans `html-output/media`, `path` doit pointer vers le répertoire média sur le disque, tandis que `baseUri` doit pointer vers le même répertoire du point de vue du navigateur. Pour un aperçu local, vous pouvez construire une URI `file:///` à partir du répertoire média. Pour une application déployée, utilisez l’URL absolue du répertoire média publié.

```java
String outputDirectory = System.getProperty("user.dir") + "/html-output";
String mediaDirectory = outputDirectory + "/media";
File outDir = new File(outputDirectory);
outDir.mkdir();
File mediaDir = new File(mediaDirectory);
mediaDir.mkdir();

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory;

Presentation presentation = new Presentation();
try {
    byte[] videoData = ...;// intro.mp4

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory;
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    String htmlFilePath = outputDirectory + "/" + htmlFileName;
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Utilisez des répertoires de sortie uniques par travail d’exportation, en particulier dans les applications serveur. Des chemins de sortie partagés peuvent provoquer le remplacement de fichiers provenant de conversions différentes.

## **Performances et gestion des ressources**

La conversion HTML est une opération de rendu, ainsi le temps de traitement et l’utilisation de la mémoire dépendent du nombre de diapositives, de la résolution des images, des polices, des effets, des graphiques et des médias intégrés. Des valeurs DPI plus élevées pour `PicturesCompression`, les polices intégrées, la sortie SVG et la conservation des zones d’image recadrées peuvent améliorer la fidélité mais augmentent généralement la taille du résultat.

Pour la conversion en lot :

- Libérez chaque instance de [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) rapidement.
- Utilisez des répertoires de sortie distincts pour chaque travail.
- Évitez d’intégrer les polices communes sauf si la fidélité l’exige.
- Réduisez le DPI des images lorsque le HTML est destiné à un aperçu ou à des vignettes.
- Conservez la présentation source, le HTML généré et les ressources externes ensemble jusqu’à ce que les chemins de déploiement soient définitifs.

## **FAQ**

**Les hyperliens sont-ils conservés dans la sortie HTML ?**  
Oui. Les hyperliens de la présentation sont exportés vers le HTML et restent cliquables lorsque l’URL cible est valide.

**Puis-je convertir des présentations en HTML en parallèle ?**  
Oui, mais ne partagez pas une même instance de [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) entre plusieurs threads. Traitez des fichiers différents avec des instances de présentation distinctes, des flux distincts et des répertoires de sortie séparés. Consultez la [multithreading guidance](/slides/fr/androidjava/multithreading/) pour plus de détails.

**Un objet Presentation est-il sûr pour le multithreading ?**  
Non. Une seule instance de [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) doit être chargée, modifiée, enregistrée et libérée sur un même thread. Pour un travail parallèle, créez une instance indépendante par thread ou par processus.

**Pourquoi le fichier HTML généré est-il volumineux ?**  
L’exportation par défaut peut intégrer directement les ressources dans le HTML. Les polices intégrées, les images à haute résolution DPI, les médias, le contenu SVG et la conservation des zones d’image recadrées augmentent également la taille. Utilisez des ressources externes, excluez les polices courantes de l’intégration et baissez `PicturesCompression` lorsque la taille réduite est plus importante que la fidélité maximale.

**Comment choisir baseUri pour l’exportation des médias ?**  
Choisissez `baseUri` du point de vue du navigateur et transmettez‑le comme URI absolu. Pour un aperçu local, vous pouvez le dériver du répertoire de sortie avec `mediaDirectory.toUri().toString()`. Pour le déploiement, utilisez l’URL absolue du répertoire média publié. Le chemin système `path` et le `baseUri` du navigateur n’ont pas besoin d’être la même chaîne, mais ils doivent désigner le même emplacement de ressources.

**Puis-je inclure les diapositives masquées ?**  
Oui. Définissez `ShowHiddenSlides` sur `true` sur [HtmlOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/htmloptions/) lorsque les diapositives masquées doivent être exportées.