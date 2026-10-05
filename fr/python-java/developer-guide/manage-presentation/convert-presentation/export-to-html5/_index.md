---
title: Convertir des présentations en HTML5 en Python via Java
linktitle: Présentation en HTML5
type: docs
weight: 40
url: /fr/python-java/export-to-html5/
keywords:
- PowerPoint vers HTML5
- OpenDocument vers HTML5
- présentation vers HTML5
- diapositive vers HTML5
- PPT en HTML5
- PPTX en HTML5
- ODP en HTML5
- enregistrer PPT en HTML5
- enregistrer PPTX en HTML5
- enregistrer ODP en HTML5
- exporter PPT en HTML5
- exporter PPTX en HTML5
- exporter ODP en HTML5
- Python
- Java
- Aspose.Slides
description: "Exportez les présentations PowerPoint et OpenDocument au format HTML5 responsive avec Aspose.Slides pour Python via Java. Conservez la mise en forme, les animations et l'interactivité."
---
## **Vue d'ensemble**

Cet article explique comment convertir des présentations PowerPoint en HTML5 à l'aide d'Aspose.Slides pour Python via Java. Il couvre l'exportation de base, le contrôle des animations de formes et des transitions de diapositive, ainsi que la mise en page des commentaires. Il compare également la sortie HTML5 avec la sortie basée sur SVG de l'exportation HTML standard.

Les exemples nécessitent Aspose.Slides pour Python via Java et un runtime Java compatible. Placez les présentations d'entrée dans le répertoire de travail actuel. Chaque exemple démarre la JVM uniquement si elle n'est pas déjà en cours d'exécution.

## **Exporter PowerPoint vers HTML5**

L'exemple suivant charge une présentation depuis le répertoire de travail et l'enregistre au format HTML5. Il utilise les paramètres d'exportation par défaut ; l'exemple suivant montre comment contrôler explicitement la lecture des animations. Remplacez le chemin d'entrée par le chemin de votre présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
En plus du document HTML, l'exportation écrit des fichiers CSS et JavaScript de support pour le style des diapositives, les animations, les effets et la navigation. Conservez ces fichiers avec le document HTML lors du déplacement ou de la publication du résultat. La page générée charge également jQuery et Anime.js depuis des CDN publics ; sans eux, la navigation et les animations des diapositives ne fonctionnent pas.
{{% /alert %}}

Pour exporter sans lire les animations de formes ou les transitions de diapositive, passez `False` à [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) et [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) dans [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Ces paramètres sont indépendants, vous pouvez donc activer l'un tout en désactivant l'autre. L'exemple exporte la présentation avec les deux types d'animation désactivés dans la page générée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(False)
html5_options.setAnimateTransitions(False)

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Exporter PowerPoint en HTML**

L'exportation HTML standard utilise une approche de rendu différente : le contenu des diapositives est représenté par du SVG à l'intérieur d'une page HTML. L'exemple suivant convertit une présentation en un document HTML en utilisant cette approche de rendu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Le balisage simplifié ci‑dessous illustre la structure de la page générée. L'élément SVG contient le contenu rendu de la diapositive ; le texte de substitution représente ce contenu et n'est pas la sortie d'exportation littérale.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
L'exportation basée sur SVG n'expose pas les formes PowerPoint en tant qu'éléments HTML individuels. Utilisez l'exportation HTML5 lorsque vous avez besoin des options d'animation de forme et de transition de diapositive présentées dans cet article.
{{% /alert %}}

## **Exporter PowerPoint en vue de diapositive HTML5**

L'exportation HTML5 produit une page pour visualiser et naviguer dans les diapositives de la présentation dans un navigateur. Cet exemple active à la fois [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) et [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) afin que la vue de diapositive exportée puisse lire les effets de la présentation source.

Utilisez une présentation contenant déjà des animations de forme et des transitions de diapositive pour voir l'effet de ces paramètres. Les activer n'ajoute pas de nouveaux effets aux diapositives qui n'en ont pas. Après l'exportation, ouvrez le document HTML5 généré dans un navigateur avec ses fichiers de support disponibles.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(True)
html5_options.setAnimateTransitions(True)

presentation = Presentation("pres.pptx")
try:
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Convertir une présentation en document HTML5 avec commentaires**

Vous pouvez inclure les commentaires de diapositive existants dans la sortie HTML5 afin que les lecteurs voient les retours à côté du contenu de la diapositive. L'exemple de cette section suppose que la présentation source contient des commentaires, comme illustré ci‑dessous. Il exporte ces commentaires ; il ne crée pas de nouveaux.

![Deux commentaires sur la diapositive de la présentation](two_comments_pptx.png)

Passez un objet [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) à la méthode [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) de [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Utilisez [setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) pour sélectionner `Right` dans l'énumération [CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/) afin de placer les commentaires à droite de chaque diapositive.

L'exemple suivant exporte la présentation en HTML5 avec cette mise en page des commentaires. Une présentation sans commentaires n'affichera aucun texte de commentaire.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, Html5Options, NotesCommentsLayoutingOptions, Presentation, SaveFormat

layout_options = NotesCommentsLayoutingOptions()
layout_options.setCommentsPosition(CommentsPositions.Right)

html5_options = Html5Options()
html5_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

L'image ci‑dessous montre le document HTML5 exporté avec les commentaires affichés à côté de la diapositive.

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)

## **Exclure les hyperliens JavaScript lors de l'exportation**

Supposons que `hyperlinks.pptx` contienne un texte lié avec une cible `javascript:alert('Hello')` et un lien ordinaire `https://example.com/`. Pour exclure l'hyperlien JavaScript lors de l'exportation, passez `True` à [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). La valeur par défaut est `False`, donc ces liens ne sont pas filtrés à moins d'activer l'option.

L'exemple suivant charge la présentation depuis le répertoire de travail et l'exporte en utilisant [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setSkipJavaScriptLinks(True)

presentation = Presentation("hyperlinks.pptx")
try:
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Le fichier exporté omet l'hyperlien JavaScript tout en conservant son texte et le lien HTTPS ordinaire. La présentation source reste inchangée.

Cette option filtre les hyperliens JavaScript ; elle ne supprime pas tous les scripts ou autre contenu actif, et ne garantit pas la conformité CSP. Par exemple, la sortie HTML5 inclut toujours des scripts pour la navigation des diapositives et les animations.

## **FAQ**

**Puis-je contrôler si les animations d'objets et les transitions de diapositive seront lues en HTML5 ?**

Oui, l'exportation HTML5 propose des options distinctes pour activer ou désactiver les [animations de forme](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) et les [transitions de diapositive](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions).

**Les commentaires sont-ils pris en charge, et où peuvent-ils être placés par rapport à la diapositive ?**

Oui, les commentaires existants peuvent être inclus dans la sortie HTML5 et positionnés (par exemple, à droite de la diapositive) via les [paramètres de mise en page](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) pour les notes et les commentaires.

**Puis-je ignorer les liens qui invoquent du JavaScript pour des raisons de sécurité ou de CSP ?**

Oui, le paramètre [setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) vous permet d'ignorer les hyperliens contenant des appels JavaScript lors de l'enregistrement. La valeur par défaut est `False`. Consultez [Exclure les hyperliens JavaScript lors de l'exportation](/slides/fr/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) pour un exemple d'exportation HTML5 et la portée du filtre. Ce paramètre ne supprime pas le JavaScript utilisé par le visualiseur HTML5 pour la navigation et les animations.