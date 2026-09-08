---
title: Convertir des présentations en HTML5 avec Python via Java
linktitle: Présentation en HTML5
type: docs
weight: 40
url: /fr/python-java/export-to-html5/
keywords:
- PowerPoint en HTML5
- OpenDocument en HTML5
- présentation en HTML5
- diapositive en HTML5
- PPT en HTML5
- PPTX en HTML5
- ODP en HTML5
- enregistrer PPT comme HTML5
- enregistrer PPTX comme HTML5
- enregistrer ODP comme HTML5
- exporter PPT en HTML5
- exporter PPTX en HTML5
- exporter ODP en HTML5
- Python
- Java
- Aspose.Slides
description: "Exporter des présentations PowerPoint et OpenDocument en HTML5 réactif avec Aspose.Slides pour Python via Java. Conserver la mise en forme, les animations et l'interactivité."
---
## **Vue d'ensemble**

Cet article explique comment convertir des présentations PowerPoint en HTML5 à l'aide d'Aspose.Slides. Il couvre l'exportation HTML5 de base sans extensions Web supplémentaires, ainsi que les options de contrôle des animations de formes et des transitions de diapositives. L'article montre également le processus d'exportation standard de PowerPoint vers HTML, décrit comment générer une sortie HTML5 en mode vue des diapositives et démontre comment inclure des commentaires dans le document exporté en configurant leur mise en page.

Les exemples nécessitent Aspose.Slides for Python via Java et un runtime Java compatible. Placez `pres.pptx` (ou `sample.pptx` pour l'exemple des commentaires) dans le répertoire de travail actuel. Chaque exemple démarre la JVM uniquement si elle n'est pas déjà en cours d'exécution.

## **Exporter PowerPoint en HTML5**

Utilisez [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) avec [SaveFormat.Html5](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Html5) pour exporter une présentation sans extensions Web supplémentaires :

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
L'exportateur HTML5 crée du contenu HTML pour la visualisation dans un navigateur. 
{{% /alert %}}

Utilisez [Html5Options](https://reference.aspose.com/slides/fr/python-java/aspose.slides/html5options/) pour configurer l'exportation. Appelez [setAnimateShapes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/html5options/#setAnimateShapes) et [setAnimateTransitions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/html5options/#setAnimateTransitions) avec `False` pour désactiver les animations de formes et les transitions de diapositives :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Exporter PowerPoint en HTML**

Utilisez [SaveFormat.Html](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Html) pour une exportation HTML standard. Voir [Convertir PowerPoint en HTML](/slides/fr/python-java/convert-powerpoint-to-html/) pour plus d'options :

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

Dans ce cas, le contenu de la présentation est rendu via SVG sous une forme comme celle‑ci :

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
L'exportation HTML standard rend le contenu des diapositives via SVG et ne propose pas les options d'animation de formes et de transitions de diapositives HTML5. 
{{% /alert %}}

## **Exporter PowerPoint en vue diapositive HTML5**

**Aspose.Slides** vous permet de convertir une présentation PowerPoint en document HTML5 dans lequel les diapositives sont présentées en mode vue diapositive. Dans ce cas, lorsque vous ouvrez le fichier HTML5 résultant dans un navigateur, vous voyez la présentation en mode vue diapositive sur une page Web. 

Ce code Python montre le processus d'exportation PowerPoint vers la vue diapositive HTML5 :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Convertir des présentations en documents HTML5 avec commentaires**

Les commentaires dans PowerPoint sont un outil qui permet aux utilisateurs de laisser des notes ou des retours sur les diapositives de la présentation. Ils sont particulièrement utiles dans les projets collaboratifs, où plusieurs personnes peuvent ajouter leurs suggestions ou remarques à des éléments spécifiques des diapositives sans modifier le contenu principal. Chaque commentaire indique le nom de l'auteur, ce qui facilite le suivi de qui a laissé la remarque.

Supposons que nous ayons la présentation PowerPoint suivante enregistrée dans le fichier "sample.pptx".

![Deux commentaires sur la diapositive de présentation](two_comments_pptx.png)

Lorsque vous convertissez une présentation PowerPoint en document HTML5, vous pouvez facilement spécifier s'il faut inclure les commentaires de la présentation dans le document de sortie. Pour ce faire, transmettez les paramètres d'affichage des commentaires à la méthode [setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) de la classe [Html5Options](https://reference.aspose.com/slides/fr/python-java/aspose.slides/html5options/).

Utilisez [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notescommentslayoutingoptions/) et [setCommentsPosition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) avec [CommentsPositions.Right](https://reference.aspose.com/slides/fr/python-java/aspose.slides/commentspositions/#Right). L'exemple de code suivant convertit une présentation en document HTML5 avec les commentaires affichés à droite des diapositives.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Le document "output.html" est affiché dans l'image ci‑début.

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)

## **FAQ**

**Puis-je contrôler si les animations d'objets et les transitions de diapositives seront lues en HTML5 ?**

Oui, HTML5 propose des options distinctes pour activer ou désactiver les [animations de formes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/html5options/#setAnimateShapes) et les [transitions de diapositives](https://reference.aspose.com/slides/fr/python-java/aspose.slides/html5options/#setAnimateTransitions).

**La sortie des commentaires est‑elle prise en charge, et où peuvent‑ils être placés par rapport à la diapositive ?**

Oui, les commentaires peuvent être ajoutés en HTML5 et positionnés (par exemple, à droite de la diapositive) via les [paramètres de mise en page](https://reference.aspose.com/slides/fr/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) pour les notes et les commentaires.

**Puis‑je ignorer les liens qui invoquent du JavaScript pour des raisons de sécurité ou de CSP ?**

Oui, il existe un [paramètre](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) qui vous permet d'ignorer les hyperliens avec des appels JavaScript lors de l'enregistrement. Cela supprime ces hyperliens ; cela ne garantit pas à lui seul que tous les scripts HTML5 générés respectent la politique de sécurité du contenu d'un site.