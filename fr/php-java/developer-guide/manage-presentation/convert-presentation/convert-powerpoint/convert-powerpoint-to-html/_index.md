---
title: Convertir des présentations PowerPoint en HTML avec PHP
linktitle: PowerPoint vers HTML
type: docs
weight: 30
url: /fr/php-java/convert-powerpoint-to-html/
keywords:
- convertir PowerPoint
- convertir la présentation
- convertir la diapositive
- convertir PPT
- convertir PPTX
- PowerPoint vers HTML
- présentation vers HTML
- diapositive vers HTML
- PPT vers HTML
- PPTX vers HTML
- enregistrer PowerPoint en HTML
- enregistrer la présentation en HTML
- enregistrer la diapositive en HTML
- enregistrer PPT en HTML
- enregistrer PPTX en HTML
- exporter PPT en HTML
- exporter PPTX en HTML
- PHP
- Aspose.Slides
description: "Convertir des présentations PowerPoint en HTML avec PHP. Utilisez Aspose.Slides pour exporter des fichiers PPT et PPTX, des diapositives sélectionnées, des notes, des polices, des images, du SVG et des médias."
---
## **Vue d'ensemble**

Aspose.Slides for PHP via Java peut enregistrer les présentations PowerPoint au format HTML sans Microsoft PowerPoint. La conversion de base consiste à charger une seule [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) et à appeler `save` avec [SaveFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveformat/). Utilisez [HtmlOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/htmloptions/) lorsque vous devez contrôler la disposition exportée, les polices, les images, les notes, les commentaires, la sortie SVG ou les ressources liées.

Ce guide se concentre sur des scénarios pratiques d’exportation HTML :

- Exporter une présentation complète ou des diapositives sélectionnées.
- Générer du HTML à mise en page fixe, réactif ou basé sur SVG.
- Inclure les notes du présentateur et les commentaires.
- Contrôler la qualité des images et les données d’image recadrées.
- Incorporer les polices ou enregistrer les fichiers de police séparément.
- Choisir comment les ressources externes et les fichiers multimédias sont écrits et référencés.

Par défaut, l’exportation HTML produit un document HTML autonome où la plupart des ressources sont incorporées. Cela est pratique pour partager un seul fichier, mais peut augmenter la taille du résultat. Pour la publication Web, envisagez des ressources externes, un DPI d’image plus faible et n’incorporez que les polices qui ne sont pas assurément disponibles dans l’environnement cible.

## **Convertir une présentation en HTML**

Pour exporter une présentation en HTML, chargez‑la avec [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) et enregistrez‑la avec [SaveFormat.Html](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveformat/).

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Cet exemple écrit un fichier HTML. L’objet présentation est libéré dans le bloc `finally`, ce qui libère les poignées de fichiers et les ressources de rendu après l’exportation.

## **Utiliser HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/htmloptions/) est la classe principale de configuration pour l’exportation HTML. Les paramètres courants incluent :

- `SlidesLayoutOptions` : ajoute des notes, commentaires, annexes ou d’autres informations de mise en page.
- `HtmlFormatter` : modifie la structure du document HTML ou délègue le formatage à un contrôleur.
- `SlideImageFormat` : modifie la façon dont les diapositives sont représentées, par exemple en SVG.
- `PicturesCompression` : contrôle le DPI des images et la taille de la sortie.
- `DeletePicturesCroppedAreas` : conserve ou supprime les données d’image recadrées.
- `SvgResponsiveLayout` : rend le contenu SVG exporté adaptable à son conteneur.
- `ShowHiddenSlides` : inclut les diapositives masquées si nécessaire.

Les sections suivantes montrent les options les plus courantes séparément afin que vous puissiez combiner uniquement celles dont votre flux de travail a besoin.

## **Convertir les diapositives sélectionnées en HTML**

La surcharge `save` qui accepte les numéros de diapositives utilise des positions basées sur 1. La boucle ci‑dessous enregistre chaque diapositive dans un fichier HTML séparé.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

Utilisez ce modèle lorsqu’un site Web ou une application a besoin d’une page HTML par diapositive. Si chaque diapositive doit avoir la même mise en page, créez une instance [HtmlOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/htmloptions/) et transmettez‑la à chaque appel `save`.

## **Créer un HTML réactif**

[ResponsiveHtmlController](https://reference.aspose.com/slides/fr/php-java/aspose.slides/responsivehtmlcontroller/) fournit une sortie HTML réactive via [HtmlFormatter](https://reference.aspose.com/slides/fr/php-java/aspose.slides/htmlformatter/). Utilisez‑le lorsque la page exportée doit mieux s’adapter à la largeur du navigateur.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Pour une mise en page réactive basée sur SVG, définissez `SvgResponsiveLayout` sur [HtmlOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/htmloptions/). Cela est utile lorsque le contenu de la diapositive est exporté sous forme de balisage SVG évolutif.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Inclure les notes du présentateur et les commentaires**

Utilisez [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/notescommentslayoutingoptions/) via `HtmlOptions.SlidesLayoutOptions` pour inclure les notes du présentateur ou les commentaires. Les notes et les commentaires sont masqués par défaut sauf si vous choisissez leurs positions.

Supposons que la présentation source contienne des notes du présentateur :

![Diapositive avec notes du présentateur dans PowerPoint](slide_with_notes.png)

Le code suivant exporte le contenu de la diapositive avec les notes du présentateur affichées sous la diapositive.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Le HTML exporté comprend la zone de notes :

![Résultat HTML avec la diapositive et les notes du présentateur](HTML_with_notes.png)

Pour exporter les commentaires, définissez `CommentsPosition`, par exemple à `CommentsPositions.Right` ou `CommentsPositions.Bottom`. Si vous ne souhaitez exporter que les commentaires, omettez `NotesPosition`. Si vous avez besoin à la fois des notes et des commentaires, définissez les deux propriétés.

## **Contrôler la qualité des images et les zones recadrées**

L’exportation HTML peut compresser les images des diapositives afin de réduire la taille du résultat. Réglez `PicturesCompression` sur une valeur de [PicturesCompression](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturescompression/) lorsque vous avez besoin d’une meilleure qualité d’image.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Par défaut, les zones recadrées des images peuvent être supprimées du résultat exporté. Conservez les données recadrées uniquement lorsque les utilisateurs doivent pouvoir récupérer ou inspecter ces parties d’image cachées. Leur conservation peut augmenter la taille du HTML.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Ajouter du CSS**

Pour un style simple, transmettez une chaîne CSS à [HtmlFormatter](https://reference.aspose.com/slides/fr/php-java/aspose.slides/htmlformatter/) via `createDocumentFormatter`. Cela modifie le document HTML environnant tandis qu’Aspose.Slides continue de rendre le contenu des diapositives.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Pour un en‑tête de document personnalisé, un fichier CSS lié ou un balisage personnalisé autour des diapositives et formes, utilisez un contrôleur de formatage personnalisé et transmettez‑le à [HtmlFormatter](https://reference.aspose.com/slides/fr/php-java/aspose.slides/htmlformatter/) avec `createCustomFormatter`.

## **Incorporer les polices**

Si l’environnement cible ne possède pas les polices de la présentation, incorporez les polices dans le HTML avec [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fr/php-java/aspose.slides/embedallfontshtmlcontroller/). L’incorporation améliore la fidélité visuelle mais augmente la taille du résultat.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Excluez les polices uniquement lorsque vous êtes sûr que les navigateurs ou systèmes cibles les fournissent déjà. Pour les polices de marque ou moins courantes, l’incorporation est généralement plus sûre.

## **Lier les fichiers de police au lieu de les incorporer**

Pour réduire la taille du fichier HTML, vous pouvez écrire les données de police dans des fichiers WOFF séparés et ajouter des règles `@font-face` au HTML. En PHP via Java, ce scénario est généralement implémenté avec une petite classe d’assistance Java qui étend [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fr/php-java/aspose.slides/embedallfontshtmlcontroller/), écrit les octets de police dans un répertoire de sortie et injecte les règles `@font-face` dans le HTML généré. Compilez cette classe d’assistance, ajoutez‑la au classpath du PHP Java Bridge, puis instanciez‑la depuis PHP avec `new Java(...)`.

Lors de la création d’une telle assistance, choisissez soigneusement deux chemins :

- Le chemin de sortie du système de fichiers, où les fichiers de police générés sont écrits.
- Le chemin URL, que le navigateur utilise depuis le document HTML pour charger ces fichiers de police.

## **Enregistrer les ressources à l'extérieur**

Le HTML autonome est facile à déplacer, mais les ressources Base64 incorporées peuvent rendre le fichier volumineux. Si votre application a besoin de fichiers image externes, fournissez un contrôleur de lien/incorporation personnalisé au constructeur de [HtmlOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/htmloptions/).

Lorsque vous externalisez les ressources, choisissez soigneusement deux chemins :

- Le chemin de sortie du système de fichiers, où votre application écrit les images, polices, audio ou vidéo générés.
- Le chemin URL, que le navigateur utilise depuis le document HTML pour charger ces fichiers.

Gardez ces chemins cohérents avec la disposition de votre déploiement afin que le HTML généré puisse charger ses ressources externes après son déplacement vers un serveur Web ou un autre répertoire.

## **Exporter les fichiers multimédias**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/fr/php-java/aspose.slides/videoplayerhtmlcontroller/) exporte les fichiers vidéo et audio et génère un HTML capable de les lire dans un navigateur. Son constructeur accepte :

- `path` : le répertoire de sortie utilisé par le HTML généré et les fichiers multimédias.
- `fileName` : le nom du fichier HTML en cours de génération.
- `baseUri` : le préfixe URI absolu utilisé dans les liens HTML vers les fichiers multimédias.

Si le fichier HTML est `html-output/presentation.html`, `path` doit pointer vers `html-output`, et `baseUri` doit pointer vers le même répertoire du point de vue du navigateur. Pour un aperçu local, vous pouvez construire une URI `file:///` à partir du répertoire de sortie. Pour une application déployée, utilisez l’URL absolue du répertoire de sortie publié.

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

Utilisez des répertoires de sortie uniques pour chaque tâche d’exportation, en particulier dans les applications serveur. Des chemins de sortie partagés peuvent entraîner le remplacement de fichiers provenant de conversions différentes.

## **Performances et gestion des ressources**

La conversion HTML est une opération de rendu, de sorte que le temps de traitement et l’utilisation de la mémoire dépendent du nombre de diapositives, de la résolution des images, des polices, des effets, des graphiques et des médias incorporés. Des valeurs de DPI plus élevées pour `PicturesCompression`, l’incorporation de polices, la sortie SVG et la conservation des zones d’image recadrées peuvent améliorer la fidélité mais augmentent généralement la taille du résultat.

Pour une conversion par lots :

- Libérez chaque instance [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) rapidement.
- Utilisez des répertoires de sortie distincts pour chaque tâche.
- Évitez d’incorporer les polices courantes sauf si la fidélité l’exige.
- Réduisez le DPI des images lorsque le HTML est destiné à un aperçu ou à des vignettes.
- Conservez la présentation source, le HTML généré et les ressources externes ensemble jusqu’à ce que les chemins de déploiement soient définitifs.

## **FAQ**

**Les hyperliens sont-ils conservés dans la sortie HTML ?**

Oui. Les hyperliens de la présentation sont exportés vers le HTML et restent cliquables lorsque l’URL cible est valide.

**Puis‑je convertir plusieurs présentations en HTML en parallèle ?**

Oui, mais ne partagez pas une même instance [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) entre plusieurs threads. Traitez des fichiers différents avec des instances de présentation distinctes, des flux séparés et des répertoires de sortie différents.

**Un objet Presentation est‑il thread‑safe ?**

Non. Une seule instance [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) doit être chargée, modifiée, enregistrée et libérée sur un même thread. Pour un traitement parallèle, créez une instance indépendante par thread ou processus.

**Pourquoi le fichier HTML généré est‑il volumineux ?**

L’exportation par défaut peut incorporer les ressources directement dans le HTML. Les polices incorporées, les images haute résolution, les médias, le contenu SVG et la conservation des zones d’image recadrées augmentent également la taille. Utilisez des ressources externes, excluez les polices courantes de l’incorporation et réduisez `PicturesCompression` lorsque la taille réduite prime sur la fidélité maximale.

**Comment choisir baseUri pour l’exportation des médias ?**

Choisissez `baseUri` du point de vue du navigateur et transmettez‑le comme URI absolu. Pour un aperçu local, vous pouvez le dériver du répertoire de sortie avec une URI de fichier Java. Pour le déploiement, utilisez l’URL absolue du répertoire de médias publié. Le chemin système `path` et le `baseUri` du navigateur n’ont pas besoin d’être identiques en texte, mais ils doivent désigner le même emplacement de ressource.

**Puis‑je inclure les diapositives masquées ?**

Oui. Définissez `ShowHiddenSlides` sur `true` dans [HtmlOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/htmloptions/) lorsque les diapositives masquées doivent être exportées.