---
title: "Convertir des présentations PowerPoint en HTML avec Python via Java"
linktitle: "PowerPoint en HTML"
type: docs
weight: 30
url: /fr/python-java/convert-powerpoint-to-html/
keywords:
- "convertir PowerPoint"
- "convertir présentation"
- "convertir diapositive"
- "convertir PPT"
- "convertir PPTX"
- "PowerPoint en HTML"
- "présentation en HTML"
- "diapositive en HTML"
- "PPT en HTML"
- "PPTX en HTML"
- "enregistrer PowerPoint en HTML"
- "enregistrer présentation en HTML"
- "enregistrer diapositive en HTML"
- "enregistrer PPT en HTML"
- "enregistrer PPTX en HTML"
- "exporter PPT en HTML"
- "exporter PPTX en HTML"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Convertir des présentations PowerPoint en HTML avec Python via Java. Utilisez Aspose.Slides pour exporter les fichiers PPT et PPTX, les diapositives sélectionnées, les notes, les polices, les images, le SVG et les médias."
---
## **Aperçu**

Aspose.Slides for Python via Java peut enregistrer les présentations PowerPoint au format HTML sans Microsoft PowerPoint. La conversion de base consiste en un unique chargement de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et un appel [save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) avec [SaveFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/). Utilisez [HtmlOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/) lorsque vous devez contrôler la mise en page exportée, les polices, les images, les notes, les commentaires, la sortie SVG ou les ressources liées.

Ce guide se concentre sur des scénarios pratiques d’exportation HTML :

- Exporter une présentation complète ou des diapositives sélectionnées.
- Générer du HTML à mise en page fixe, réactif ou basé sur SVG.
- Inclure les notes du présentateur et les commentaires.
- Contrôler la qualité des images et les données d’images recadrées.
- Incorporer les polices ou enregistrer les fichiers de polices séparément.
- Choisir comment les ressources externes et les fichiers multimédias sont écrits et référencés.

Par défaut, l’exportation HTML produit un document HTML autonome où la plupart des ressources sont intégrées. Cela est pratique pour partager un seul fichier, mais cela peut augmenter la taille du résultat. Pour la publication sur le web, envisagez des ressources externes, une résolution DPI d’image plus basse et n’incorporez que les polices qui ne sont pas disponibles de façon fiable dans l’environnement cible.

## **Convertir une présentation en HTML**

Pour exporter une présentation en HTML, chargez‑la avec [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et enregistrez‑la avec [SaveFormat.Html](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Html).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Chaque exemple charge `presentation.pptx` depuis le répertoire de travail actuel. Installez Aspose.Slides for Python via Java et un runtime Java compatible avant de l’exécuter. La JVM est démarrée une fois par processus Python.

Cet exemple écrit un seul fichier HTML. L’objet présentation est libéré dans le bloc `finally`, ce qui libère les poignées de fichier et les ressources de rendu après l’exportation.

## **Configurer l’exportation HTML**

[HtmlOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/) est la classe de configuration principale pour l’exportation HTML. Les paramètres courants incluent :

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) : ajoute des notes, des commentaires, des documents de distribution ou d’autres informations de mise en page.
- [setHtmlFormatter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/#setHtmlFormatter) : modifie la structure du document HTML ou délègue le formatage à un contrôleur.
- [setSlideImageFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/#setSlideImageFormat) : change la représentation des diapositives, par exemple en SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/#setPicturesCompression) : contrôle le DPI des images et la taille du résultat.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas) : conserve ou supprime les données d’images recadrées.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) : rend le contenu SVG exporté adaptable à son conteneur.
- [setShowHiddenSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) : inclut les diapositives masquées lorsque cela est requis.

Les sections suivantes présentent les options les plus courantes séparément afin que vous ne combiniez que celles dont votre flux de travail a besoin.

## **Convertir des diapositives sélectionnées en HTML**

La surcharge [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) qui accepte des numéros de diapositives utilise des positions de diapositives basées sur 1. La boucle ci‑dessous enregistre chaque diapositive dans un fichier HTML séparé.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

Utilisez ce modèle lorsqu’un site Web ou une application nécessite une page HTML par diapositive. Si chaque diapositive doit avoir la même mise en page, créez une instance [HtmlOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/) et transmettez‑la à chaque appel [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save).

## **Créer du HTML réactif**

[ResponsiveHtmlController](https://reference.aspose.com/slides/fr/python-java/aspose.slides/responsivehtmlcontroller/) fournit une sortie HTML réactive via [HtmlFormatter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmlformatter/). Utilisez‑le lorsque la page exportée doit mieux s’adapter à la largeur du navigateur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Pour une mise en page réactive basée sur SVG, appelez [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) avec `True`. Ceci est utile lorsque le contenu des diapositives est exporté sous forme de balisage SVG scalable.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Inclure les notes du présentateur et les commentaires**

Utilisez [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notescommentslayoutingoptions/) via [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) pour inclure les notes du présentateur ou les commentaires. Les notes et les commentaires sont masqués par défaut, sauf si vous choisissez leurs positions.

Supposons que la présentation source contienne des notes du présentateur :

![Diapositive avec notes du présentateur dans PowerPoint](slide_with_notes.png)

Le code suivant exporte le contenu de la diapositive avec les notes du présentateur sous la diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Le HTML exporté comprend la zone des notes :

![Sortie HTML avec la diapositive et les notes du présentateur](HTML_with_notes.png)

Pour exporter les commentaires, appelez [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition), par exemple avec [CommentsPositions.Right](https://reference.aspose.com/slides/fr/python-java/aspose.slides/commentspositions/#Right) ou [CommentsPositions.Bottom](https://reference.aspose.com/slides/fr/python-java/aspose.slides/commentspositions/#Bottom). Si vous avez uniquement besoin des commentaires, omettez [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Si vous avez besoin à la fois des notes et des commentaires, appelez les deux méthodes.

## **Contrôler la qualité des images et les zones recadrées**

L’exportation HTML peut compresser les images des diapositives afin de réduire la taille du résultat. Transmettez une valeur à [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/#setPicturesCompression) depuis [PicturesCompression](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturescompression/) lorsque vous avez besoin d’une meilleure qualité d’image.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Par défaut, les zones recadrées des images peuvent être supprimées du résultat exporté. Conservez les données recadrées uniquement lorsque les utilisateurs doivent pouvoir récupérer ou inspecter ces parties d’image cachées. Les conserver peut augmenter la taille du HTML.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Ajouter du CSS**

Pour un style simple, transmettez une chaîne CSS à [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmlformatter/#createDocumentFormatter). Cela modifie le document HTML environnant tandis qu’Aspose.Slides continue de rendre le contenu des diapositives.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Pour un en‑tête de document personnalisé, un fichier CSS lié ou un balisage personnalisé autour des diapositives et des formes, utilisez un contrôleur de formatage personnalisé via un proxy d’interface JPype et transmettez‑le à [HtmlFormatter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmlformatter/) avec [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmlformatter/#createCustomFormatter).

## **Incorporer des polices**

Si l’environnement cible peut ne pas avoir les polices de la présentation installées, intégrez les polices dans le HTML avec [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fr/python-java/aspose.slides/embedallfontshtmlcontroller/). L’incorporation améliore la fidélité visuelle mais augmente la taille du résultat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Excluez les polices uniquement lorsque vous êtes certain que les navigateurs ou systèmes cibles les fournissent déjà. Pour les polices de marque ou moins courantes, l’incorporation est généralement plus sûre.

## **Enregistrer les ressources en externe**

Le HTML autonome est facile à déplacer, mais les ressources Base64 intégrées peuvent rendre le fichier volumineux. Si votre application a besoin de fichiers image externes, implémentez un contrôleur de liaison de ressources via un proxy d’interface JPype et transmettez‑le au constructeur [HtmlOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/).

Lorsque vous externalisez les ressources, choisissez deux chemins de façon délibérée :

- Le chemin de sortie du système de fichiers, où votre application écrit les images, polices, audio ou vidéo générés.
- Le chemin URL, qui est celui utilisé par le navigateur depuis le document HTML pour charger ces fichiers.

## **Exporter des fichiers multimédias**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoplayerhtmlcontroller/) exporte les fichiers vidéo et audio et écrit du HTML capable de les lire dans un navigateur. Son constructeur prend :

- `path` : le répertoire où les fichiers multimédias générés seront écrits.
- `fileName` : le nom du fichier HTML en cours de génération.
- `baseUri` : le préfixe URI absolu utilisé dans les liens HTML vers les fichiers multimédias.

L’exemple suivant exporte les médias déjà incorporés dans `presentation.pptx`. Le HTML généré référence les fichiers multimédias uniquement par leur nom de fichier, relatif au document HTML, ainsi `path` doit être le même répertoire qui reçoit également le fichier HTML. `baseUri` doit être une URI absolue : pour un aperçu local, construisez une URI `file:///` à partir du répertoire de sortie ; pour une application déployée, utilisez l’URL absolue du répertoire publié.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Utilisez des répertoires de sortie uniques par tâche d’exportation, en particulier dans les applications serveur. Des chemins de sortie partagés peuvent entraîner l’écrasement de fichiers provenant de conversions différentes.

## **Performances et gestion des ressources**

La conversion HTML est une opération de rendu, donc le temps de traitement et la consommation mémoire dépendent du nombre de diapositives, de la résolution des images, des polices, des effets, des graphiques et des médias incorporés. Des valeurs DPI d’image plus élevées passées à [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/#setPicturesCompression), les polices incorporées, la sortie SVG et la conservation des zones d’image recadrées peuvent améliorer la fidélité mais augmentent généralement la taille du résultat.

Pour la conversion en lot :

- Libérez rapidement chaque instance [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
- Utilisez des répertoires de sortie distincts pour des tâches distinctes.
- Évitez d’incorporer les polices courantes sauf si la fidélité l’exige.
- Réduisez le DPI des images lorsque le HTML est destiné à un aperçu ou à des vignettes.
- Conservez la présentation source, le HTML généré et les ressources externes ensemble jusqu’à ce que les chemins de déploiement soient définitifs.

## **FAQ**

**Les hyperliens sont‑ils conservés dans la sortie HTML ?**

Oui. Les hyperliens de la présentation sont exportés vers le HTML et restent cliquables tant que l’URL cible est valide.

**Puis‑je convertir des présentations en HTML en parallèle ?**

Oui, mais ne partagez pas une même instance [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) entre plusieurs threads. Traitez des fichiers différents avec des instances de présentation distinctes, des flux distincts et des répertoires de sortie séparés. Consultez les [directives multithreading](/slides/fr/python-java/multithreading/) pour plus de détails.

**Un objet présentation est‑il thread‑safe ?**

Non. Une seule instance [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) doit être chargée, modifiée, enregistrée et libérée sur un seul thread. Pour un travail parallèle, créez une instance indépendante par thread ou processus.

**Pourquoi le fichier HTML généré est‑il volumineux ?**

L’exportation par défaut peut incorporer les ressources directement dans le HTML. Les polices incorporées, les images haute DPI, les médias, le contenu SVG et la conservation des zones d’image recadrées augmentent également la taille. Utilisez des ressources externes, excluez les polices courantes de l’incorporation et transmettez une valeur DPI inférieure à [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/#setPicturesCompression) lorsque la taille réduite prime sur la fidélité maximale.

**Pourquoi les valeurs de font‑size dans le HTML diffèrent‑elles de celles de PowerPoint ?**

La page exportée peut utiliser des systèmes de coordonnées SVG et des transformations d’échelle. Une valeur brute de CSS ou de SVG font‑size ne décrit pas la taille affichée finale. Comparez la diapositive rendue au niveau de zoom prévu et vérifiez la disponibilité des polices si le texte semble différent.

**Comment choisir baseUri pour l’exportation des médias ?**

Choisissez `baseUri` du point de vue du navigateur et transmettez‑le comme URI absolue. Pour un aperçu local, vous pouvez le dériver du répertoire de sortie avec `output_directory.as_uri() + "/"`. Pour le déploiement, utilisez l’URL absolue du répertoire publié. Le `path` du système de fichiers et le `baseUri` du navigateur n’ont pas besoin d’être la même chaîne, mais ils doivent désigner le même emplacement, et cet emplacement doit être le répertoire contenant le fichier HTML généré car les liens médias sont écrits relatifs à celui‑ci.

**Puis‑je inclure les diapositives masquées ?**

Oui. Appelez [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) avec `True` lorsque les diapositives masquées doivent être exportées.