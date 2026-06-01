---
title: Convertir des présentations PowerPoint en HTML avec Python
linktitle: PowerPoint en HTML
type: docs
weight: 30
url: /fr/python-net/convert-powerpoint-to-html/
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
- Python
- Aspose.Slides
description: "Convertir des présentations PowerPoint en HTML avec Python. Utilisez Aspose.Slides pour exporter des fichiers PPT et PPTX, des diapositives sélectionnées, des notes, des polices, des images, du SVG et des médias."
---
## **Aperçu**

Aspose.Slides for Python via .NET peut enregistrer les présentations PowerPoint au format HTML sans Microsoft PowerPoint. La conversion de base consiste en un seul [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) chargé et un appel `save` avec [SaveFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/saveformat/). Utilisez [HtmlOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/htmloptions/) lorsque vous devez contrôler la disposition exportée, les polices, les images, les notes, les commentaires, la sortie SVG ou les ressources liées.

Ce guide se concentre sur des scénarios pratiques d’exportation HTML :

- Exporter une présentation complète ou des diapositives sélectionnées.  
- Générer du HTML à mise en page fixe, réactif ou basé sur SVG.  
- Inclure les notes du présentateur et les commentaires.  
- Contrôler la qualité des images et les données d’images rognées.  
- Incorporer les polices ou enregistrer les fichiers de police séparément.  
- Choisir la manière dont les ressources externes et les fichiers multimédias sont écrits et référencés.

Par défaut, l’exportation HTML produit un document HTML autonome où la plupart des ressources sont intégrées. Cela facilite le partage d’un seul fichier, mais peut augmenter la taille du résultat. Pour la publication Web, envisagez des ressources externes, une résolution d’image plus faible et n’incorporez que les polices qui ne sont pas fiables dans l’environnement cible.

## **Convertir une présentation en HTML**

Pour exporter une présentation en HTML, chargez‑la avec [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) et enregistrez‑la avec [SaveFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

Cet exemple écrit un fichier HTML. L’instruction `with` libère l’objet présentation ainsi que les poignées de fichier et les ressources de rendu après l’exportation.

## **Utiliser HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/htmloptions/) est la classe principale de configuration pour l’exportation HTML. Les réglages courants incluent :

- `slides_layout_options` : ajoute des notes, des commentaires, des documents d’accompagnement ou d’autres informations de mise en page.  
- `html_formatter` : modifie la structure du document HTML ou délègue le formatage à un contrôleur.  
- `slide_image_format` : change la façon dont les diapositives sont représentées, par exemple en SVG.  
- `pictures_compression` : contrôle la DPI des images et la taille du résultat.  
- `delete_pictures_cropped_areas` : conserve ou supprime les données d’images rognées.  
- `svg_responsive_layout` : rend le contenu SVG exporté adaptable à son conteneur.  
- `show_hidden_slides` : inclut les diapositives masquées lorsqu’elles sont requises.

Les sections suivantes présentent les options les plus courantes séparément afin que vous puissiez combiner uniquement celles dont votre flux de travail a besoin.

## **Convertir des diapositives sélectionnées en HTML**

La surcharge `save` qui accepte des numéros de diapositives utilise des positions basées sur 1. La boucle ci‑dessous enregistre chaque diapositive dans un fichier HTML séparé.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

Utilisez ce modèle lorsqu’un site Web ou une application a besoin d’une page HTML par diapositive. Si chaque diapositive doit partager la même mise en page, créez une instance de [HtmlOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/htmloptions/) et transmettez‑la à chaque appel `save`.

## **Créer du HTML réactif**

[ResponsiveHtmlController](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/responsivehtmlcontroller/) fournit une sortie HTML réactive via [HtmlFormatter](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/htmlformatter/). Utilisez‑le lorsque la page exportée doit mieux s’adapter à la largeur du navigateur.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

Pour une mise en page réactive basée sur SVG, définissez `svg_responsive_layout` sur [HtmlOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/htmloptions/). Cela est utile lorsque le contenu des diapositives est exporté sous forme de balisage SVG évolutif.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **Inclure les notes du présentateur et les commentaires**

Utilisez [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/notescommentslayoutingoptions/) via `html_options.slides_layout_options` pour inclure les notes du présentateur ou les commentaires. Les notes et les commentaires sont cachés par défaut, sauf si vous choisissez leurs positions.

Supposons que la présentation source contienne des notes du présentateur :

![Diapositive avec notes du présentateur dans PowerPoint](slide_with_notes.png)

Le code suivant exporte le contenu de la diapositive avec les notes du présentateur en dessous de la diapositive.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

Le HTML exporté inclut la zone des notes :

![Résultat HTML avec la diapositive et les notes du présentateur](HTML_with_notes.png)

Pour exporter les commentaires, définissez `comments_position`, par exemple `CommentsPositions.RIGHT` ou `CommentsPositions.BOTTOM`. Si vous avez seulement besoin des commentaires, omettez `notes_position`. Si vous avez besoin à la fois des notes et des commentaires, définissez les deux propriétés.

## **Contrôler la qualité de l'image et les zones rognées**

L’exportation HTML peut compresser les images des diapositives afin de réduire la taille du fichier. Définissez `pictures_compression` sur une valeur de [PicturesCompression](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/picturescompression/) lorsque vous avez besoin d’une qualité d’image supérieure.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

Par défaut, les zones rognées des images peuvent être supprimées du résultat exporté. Conservez les données rognées uniquement lorsque les utilisateurs doivent pouvoir récupérer ou inspecter ces parties d’images cachées. Conserver ces données peut augmenter la taille du HTML.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **Ajouter du CSS**

Pour un style simple, transmettez une chaîne CSS à [HtmlFormatter](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/htmlformatter/). Cela modifie le document HTML environnant tandis qu’Aspose.Slides continue de rendre le contenu des diapositives.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

Pour un en‑tête de document personnalisé, un fichier CSS lié ou un balisage personnalisé autour des diapositives et des formes, utilisez un contrôleur de formatage personnalisé et passez‑le à [HtmlFormatter](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/htmlformatter/) avec `create_custom_formatter`.

## **Incorporer des polices**

Si l’environnement cible peut ne pas avoir les polices de la présentation installées, incorporez les polices dans le HTML avec [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/embedallfontshtmlcontroller/). L’incorporation améliore la fidélité visuelle mais augmente la taille du résultat.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

Excluez une police uniquement lorsque vous êtes certain que les navigateurs ou systèmes cibles la fournissent déjà. Pour les polices de marque ou moins courantes, l’incorporation est généralement plus sûre.

## **Lier les fichiers de police plutôt que de les incorporer**

Pour réduire la taille du fichier HTML, vous pouvez écrire les données de police dans des fichiers WOFF distincts et ajouter des règles `@font-face` au HTML. Cela nécessite un contrôleur qui personnalise la façon dont les données de police sont écrites pendant l’exportation. En Python via .NET, implémentez ce contrôleur dans une petite assembly .NET d’assistance, chargez‑le en Python et transmettez l’objet d’aide à [HtmlFormatter](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/htmlformatter/) avec `create_custom_formatter`.

Lorsque vous externalisez les polices, choisissez deux chemins de manière délibérée :

- Le répertoire de sortie du système de fichiers où les fichiers WOFF générés seront écrits.  
- Le chemin URL qui apparaîtra dans le document HTML et que le navigateur utilisera pour charger ces fichiers de police.

Conservez le fichier HTML et les fichiers de police générés ensemble jusqu’à ce que les chemins de déploiement soient définitifs. Si les fichiers sont déployés ailleurs, faites correspondre le préfixe URL au chemin URL déployé.

## **Enregistrer les ressources à l'extérieur**

Le HTML autonome est facile à déplacer, mais les ressources Base64 intégrées peuvent rendre le fichier volumineux. Si votre application a besoin de fichiers image, police, audio ou vidéo externes, utilisez un contrôleur de liaison/incorporation personnalisé et transmettez‑le au constructeur de [HtmlOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/htmloptions/).

Lorsque vous externalisez les ressources, choisissez deux chemins de manière délibérée :

- Le chemin de sortie du système de fichiers où votre application écrit les images, polices, audio ou vidéo générés.  
- Le chemin URL, qui est ce que le navigateur utilise depuis le document HTML pour charger ces fichiers.

Pour une discussion complète sur le lien d’images, voyez [Exporter les présentations au format HTML avec des images liées extérieurement](/slides/fr/python-net/exporting-presentations-to-html-with-externally-linked-images/).

## **Exporter les fichiers multimédias**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/videoplayerhtmlcontroller/) exporte les fichiers vidéo et audio et génère du HTML capable de les lire dans un navigateur. Son constructeur prend :

- `path` : le répertoire où les fichiers multimédia générés seront écrits.  
- `file_name` : le nom du fichier HTML en cours de génération.  
- `base_uri` : le préfixe URI absolu utilisé dans les liens HTML vers les fichiers multimédia.

Si le fichier HTML est `html-output/presentation.html` et les fichiers multimédia sont enregistrés dans `html-output/media`, `path` doit pointer vers le répertoire multimédia sur le disque, tandis que `base_uri` doit pointer vers le même répertoire du point de vue du navigateur. Pour un aperçu local, vous pouvez construire un URI `file:///` à partir du répertoire multimédia. Pour une application déployée, utilisez l’URL absolue du répertoire multimédia publié.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

Utilisez des répertoires de sortie uniques par tâche d’exportation, en particulier dans les applications serveur. Des chemins de sortie partagés peuvent provoquer l’écrasement de fichiers provenant de conversions différentes.

## **Performance et gestion des ressources**

La conversion HTML est une opération de rendu, donc le temps de traitement et l’utilisation de la mémoire dépendent du nombre de diapositives, de la résolution des images, des polices, des effets, des graphiques et du multimédia intégré. Des valeurs DPI plus élevées de `pictures_compression`, des polices incorporées, une sortie SVG et la conservation des zones d’image rognées peuvent améliorer la fidélité mais augmentent généralement la taille du résultat.

Pour la conversion par lots :

- Libérez chaque instance de [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) rapidement.  
- Utilisez des répertoires de sortie distincts pour des travaux distincts.  
- Évitez d’incorporer les polices communes sauf si la fidélité l’exige.  
- Réduisez la DPI des images lorsque le HTML est destiné à une prévisualisation ou à des miniatures.  
- Conservez la présentation source, le HTML généré et les ressources externes ensemble jusqu’à ce que les chemins de déploiement soient définitifs.

## **FAQ**

**Les hyperliens sont‑ils conservés dans le rendu HTML ?**

Oui. Les hyperliens de la présentation sont exportés vers le HTML et restent cliquables lorsque l’URL cible est valide.

**Puis‑je convertir des présentations en HTML en parallèle ?**

Oui, mais ne partagez pas une même instance de [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) entre plusieurs threads. Traitez différents fichiers avec des instances de présentation distinctes, des flux distincts et des répertoires de sortie distincts. Consultez les directives sur le [multithreading](/slides/fr/python-net/multithreading/) pour plus de détails.

**Un objet Presentation est‑il thread‑safe ?**

Non. Une instance unique de [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) doit être chargée, modifiée, enregistrée et libérée sur un seul thread. Pour un travail parallèle, créez une instance indépendante par thread ou processus.

**Pourquoi le fichier HTML généré est‑il volumineux ?**

L’exportation par défaut peut incorporer les ressources directement dans le HTML. Les polices incorporées, les images haute DPI, le multimédia, le contenu SVG et la conservation des zones d’image rognées augmentent également la taille. Utilisez des ressources externes, excluez les polices courantes de l’incorporation et réduisez `pictures_compression` lorsque la taille réduite prime sur la fidélité maximale.

**Comment choisir base_uri pour l’exportation multimédia ?**

Choisissez `base_uri` du point de vue du navigateur et transmettez‑le comme URI absolu. Pour un aperçu local, vous pouvez le dériver du répertoire de sortie avec `Path(media_directory).as_uri() + "/"`. En production, utilisez l’URL absolue du répertoire multimédia publié. Le `path` du système de fichiers et le `base_uri` du navigateur n’ont pas besoin d’être la même chaîne, mais ils doivent désigner le même emplacement de ressource.

**Puis‑je inclure les diapositives masquées ?**

Oui. Définissez `show_hidden_slides = True` sur [HtmlOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/htmloptions/) lorsque les diapositives masquées doivent être exportées.