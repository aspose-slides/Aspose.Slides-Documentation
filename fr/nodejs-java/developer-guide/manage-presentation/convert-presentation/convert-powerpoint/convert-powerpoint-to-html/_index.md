---
title: Convertir les présentations PowerPoint en HTML avec Node.js
linktitle: PowerPoint vers HTML
type: docs
weight: 30
url: /fr/nodejs-java/convert-powerpoint-to-html/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint vers HTML
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir des présentations PowerPoint en HTML avec Node.js. Utilisez Aspose.Slides pour Node.js via Java afin d'exporter les fichiers PPT et PPTX, des diapositives sélectionnées, des notes, des polices, des images, du SVG et des médias."
---
## **Aperçu**

Aspose.Slides for Node.js via Java peut enregistrer des présentations PowerPoint au format HTML sans Microsoft PowerPoint. La conversion de base consiste en un chargement unique d’un [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) puis un appel `save` avec [SaveFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveformat/). Utilisez [HtmlOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/htmloptions/) lorsque vous devez contrôler la disposition exportée, les polices, les images, les notes, les commentaires, la sortie SVG ou les ressources liées.

Ce guide se concentre sur des scénarios pratiques d'exportation HTML :

- Exporter une présentation complète ou des diapositives sélectionnées.
- Générer du HTML à mise en page fixe, responsive ou basé sur SVG.
- Inclure les notes du présentateur et les commentaires.
- Contrôler la qualité des images et les données d'images recadrées.
- Intégrer les polices ou enregistrer les fichiers de polices séparément.
- Choisir comment les ressources externes et les fichiers multimédia sont écrits et référencés.

Par défaut, l'exportation HTML génère un document HTML autonome où la plupart des ressources sont intégrées. Cela est pratique pour partager un seul fichier, mais cela peut augmenter la taille du résultat. Pour la publication sur le Web, envisagez d'utiliser des ressources externes, de réduire le DPI des images et d'intégrer uniquement les polices qui ne sont pas disponibles de manière fiable dans l'environnement cible.

## **Convertir une présentation en HTML**

Pour exporter une présentation en HTML, chargez‑la avec [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) et enregistrez‑la avec [SaveFormat.Html](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Cet exemple écrit un fichier HTML. L'objet presentation est libéré dans le bloc `finally`, ce qui libère les poignées de fichiers et les ressources de rendu après l'exportation.

## **Utiliser HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/htmloptions/) est la classe principale de configuration pour l'exportation HTML. Les paramètres courants incluent :

- `SlidesLayoutOptions` : ajoute des notes, des commentaires, des documents de distribution ou d'autres informations de mise en page.
- `HtmlFormatter` : modifie la structure du document HTML ou délègue le formatage à un contrôleur.
- `SlideImageFormat` : modifie la façon dont les diapositives sont représentées, par exemple en SVG.
- `PicturesCompression` : contrôle le DPI des images et la taille du résultat.
- `DeletePicturesCroppedAreas` : conserve ou supprime les données d'images recadrées.
- `SvgResponsiveLayout` : rend le contenu SVG exporté adaptable à son conteneur.
- `ShowHiddenSlides` : inclut les diapositives masquées lorsque cela est requis.

Les sections suivantes montrent séparément les options les plus courantes afin que vous ne puissiez combiner que celles dont votre flux de travail a besoin.

## **Convertir des diapositives sélectionnées en HTML**

La surcharge `Presentation.save` qui accepte les numéros de diapositives utilise des positions de diapositives basées sur 1. La boucle ci‑dessous enregistre chaque diapositive dans un fichier HTML séparé.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Utilisez ce modèle lorsque un site Web ou une application nécessite une page HTML par diapositive. Si chaque diapositive doit avoir la même mise en page, créez une instance [HtmlOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/htmloptions/) et transmettez‑la à chaque appel `save`.

## **Créer du HTML responsive**

[ResponsiveHtmlController](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/responsivehtmlcontroller/) fournit une sortie HTML responsive via [HtmlFormatter](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/htmlformatter/). Utilisez‑le lorsque la page exportée doit mieux s'adapter à la largeur du navigateur.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Pour une mise en page responsive basée sur SVG, définissez `SvgResponsiveLayout` sur [HtmlOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/htmloptions/). Cela est utile lorsque le contenu des diapositives est exporté sous forme de balisage SVG évolutif.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Inclure les notes du présentateur et les commentaires**

Utilisez [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notescommentslayoutingoptions/) via `HtmlOptions.setSlidesLayoutOptions` pour inclure les notes du présentateur ou les commentaires. Les notes et les commentaires sont masqués par défaut, sauf si vous choisissez leurs positions.

Supposons que la présentation source contienne des notes du présentateur :

![Diapositive avec notes du présentateur dans PowerPoint](slide_with_notes.png)

Le code suivant exporte le contenu de la diapositive avec les notes du présentateur sous la diapositive.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Le HTML exporté inclut la zone des notes :

![Sortie HTML avec la diapositive et les notes du présentateur](HTML_with_notes.png)

Pour exporter les commentaires, définissez `CommentsPosition`, par exemple à `CommentsPositions.Right` ou `CommentsPositions.Bottom`. Si vous avez besoin uniquement des commentaires, omettez `NotesPosition`. Si vous avez besoin à la fois des notes et des commentaires, définissez les deux propriétés.

## **Contrôler la qualité des images et les zones recadrées**

L'exportation HTML peut compresser les images des diapositives pour réduire la taille du résultat. Définissez `PicturesCompression` à une valeur provenant de [PicturesCompression](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturescompression/) lorsque vous avez besoin d'une meilleure qualité d'image.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Par défaut, les zones recadrées des images peuvent être supprimées du résultat exporté. Conservez les données recadrées uniquement lorsque les utilisateurs doivent pouvoir récupérer ou inspecter ces parties cachées de l'image. Les conserver peut augmenter la taille du HTML.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Ajouter du CSS**

Pour une mise en forme simple, passez une chaîne CSS à `HtmlFormatter.createDocumentFormatter`. Cela modifie le document HTML environnant tandis qu'Aspose.Slides continue à rendre le contenu des diapositives.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Pour un en‑tête de document personnalisé, un fichier CSS lié, ou un balisage personnalisé autour des diapositives et des formes, utilisez [HtmlFormatter](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/htmlformatter/) avec un contrôleur de formatage.

## **Intégrer des polices**

Si l'environnement cible ne possède pas les polices de la présentation installées, intégrez les polices dans le HTML avec [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/embedallfontshtmlcontroller/). L'intégration améliore la fidélité visuelle mais augmente la taille du résultat.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Excluez les polices uniquement lorsque vous êtes sûr que les navigateurs ou systèmes cibles les fournissent déjà. Pour les polices de marque ou les polices moins courantes, l'intégration est généralement plus sûre.

## **Lier les fichiers de polices au lieu de les intégrer**

Pour réduire la taille du fichier HTML, vous pouvez écrire les données de police dans des fichiers WOFF séparés et ajouter des règles `@font-face` au HTML. Dans Node.js via Java, ce scénario est généralement implémenté avec une petite classe d'assistance Java qui étend [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/embedallfontshtmlcontroller/), écrit les octets de police dans un répertoire de sortie et injecte les règles `@font-face` dans le HTML généré. Compilez cet assistant, ajoutez‑le au classpath du module Node.js, puis créez‑lui une instance depuis JavaScript avec `java.newInstanceSync`.

Lorsque vous créez un tel assistant, choisissez délibérément deux chemins :

- Le chemin de sortie du système de fichiers, où les fichiers de polices générés sont écrits.
- Le chemin d'URL, que le navigateur utilise depuis le document HTML pour charger ces fichiers de polices.

## **Enregistrer les ressources externes**

Le HTML autonome est facile à déplacer, mais les ressources intégrées en Base64 peuvent alourdir le fichier. Si votre application a besoin de fichiers image, police, audio ou vidéo externes, utilisez un contrôleur d'exportation qui écrit les ressources dans un répertoire choisi et génère des URL visibles par le navigateur. Gardez le chemin du système de fichiers et le chemin d'URL alignés avec la structure de déploiement.

## **Exporter des fichiers multimédia**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) exporte les fichiers vidéo et audio et génère du HTML capable de les lire dans un navigateur. Son constructeur prend :

- `path` : le répertoire où les fichiers multimédia générés seront écrits.
- `fileName` : le nom du fichier HTML en cours de génération.
- `baseUri` : le préfixe URI absolu utilisé dans les liens HTML vers les fichiers multimédia.

Si le fichier HTML est `html-output/presentation.html` et les fichiers multimédia sont enregistrés dans `html-output/media`, `path` doit pointer vers le répertoire média sur le disque, tandis que `baseUri` doit pointer vers le même répertoire du point de vue du navigateur. Pour un aperçu local, vous pouvez créer une URI `file:///` à partir du répertoire média. Pour une application déployée, utilisez l'URL absolue du répertoire multimédia publié.

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Utilisez des répertoires de sortie uniques pour chaque tâche d'exportation, surtout dans les applications serveur. Des chemins de sortie partagés peuvent entraîner le remplacement de fichiers provenant de conversions différentes.

## **Performance et gestion des ressources**

La conversion HTML est une opération de rendu, ainsi le temps de traitement et la consommation de mémoire dépendent du nombre de diapositives, de la résolution des images, des polices, des effets, des graphiques et des médias intégrés. Des valeurs DPI plus élevées pour `PicturesCompression`, les polices intégrées, la sortie SVG et la conservation des zones d'images recadrées peuvent améliorer la fidélité mais augmentent généralement la taille du résultat.

Pour la conversion en lot :

- Libérez chaque instance [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) rapidement.
- Utilisez des répertoires de sortie distincts pour chaque tâche.
- Évitez d'intégrer les polices courantes sauf si la fidélité l'exige.
- Réduisez le DPI des images lorsque le HTML est destiné à la prévisualisation ou aux miniatures.
- Gardez la présentation source, le HTML généré et les ressources externes ensemble jusqu'à ce que les chemins de déploiement soient définitifs.

## **FAQ**

**Les hyperliens sont-ils conservés dans la sortie HTML ?**

Oui. Les hyperliens de la présentation sont exportés vers le HTML et restent cliquables lorsque l'URL cible est valide.

**Puis‑je convertir des présentations en HTML en parallèle ?**

Oui, mais ne partagez pas une même instance [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) entre les travailleurs. Traitez des fichiers différents avec des instances de présentation distinctes, des flux séparés et des répertoires de sortie distincts. Voir les [multithreading guidance](/slides/fr/nodejs-java/multithreading/) pour plus de détails.

**Un objet Presentation est‑il thread‑safe ?**

Non. Une seule instance [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) doit être chargée, modifiée, enregistrée et libérée dans un même travailleur. Pour un travail parallèle, créez une instance indépendante par travailleur ou processus.

**Pourquoi le fichier HTML généré est‑il volumineux ?**

L'exportation par défaut peut intégrer des ressources directement dans le HTML. Les polices intégrées, les images haute résolution, les médias, le contenu SVG et la conservation des zones d'images recadrées augmentent également la taille. Utilisez des ressources externes, excluez les polices courantes de l'intégration et réduisez `PicturesCompression` lorsque la taille plus petite prime sur la fidélité maximale.

**Comment choisir baseUri pour l'exportation multimédia ?**

Choisissez `baseUri` du point de vue du navigateur et passez‑le comme URI absolue. Pour un aperçu local, vous pouvez le dériver du répertoire de sortie avec une URI `file:///`. Pour le déploiement, utilisez l'URL absolue du répertoire multimédia publié. Le chemin du système de fichiers `path` et le `baseUri` du navigateur n'ont pas besoin d'être la même chaîne, mais ils doivent désigner le même emplacement de ressources.

**Puis‑je inclure les diapositives masquées ?**

Oui. Définissez `ShowHiddenSlides` à `true` sur [HtmlOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/htmloptions/) lorsque les diapositives masquées doivent être exportées.