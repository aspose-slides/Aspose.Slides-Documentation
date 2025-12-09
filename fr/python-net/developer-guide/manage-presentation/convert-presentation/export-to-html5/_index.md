---
title: Convertir des présentations en HTML5 avec Python
linktitle: Exporter en HTML5
type: docs
weight: 40
url: /fr/python-net/export-to-html5/
keywords:
- PowerPoint en HTML5
- OpenDocument en HTML5
- présentation en HTML5
- diapositive en HTML5
- PPT en HTML5
- PPTX en HTML5
- ODP en HTML5
- convertir PowerPoint
- convertir OpenDocument
- convertir présentation
- convertir diapositive
- export HTML5
- exporter présentation
- exporter diapositive
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Exportez les présentations PowerPoint et OpenDocument vers du HTML5 réactif avec Aspose.Slides pour Python via .NET. Conservez la mise en forme, les animations et l'interactivité."
---

{{% alert title="Info" color="info" %}}

Dans **Aspose.Slides 21.9**, nous avons implémenté la prise en charge de l'exportation HTML5. Cependant, si vous préférez exporter votre PowerPoint en HTML en utilisant les WebExtensions, consultez [cet article](/slides/fr/net/web-extensions/) à la place. 

{{% /alert %}} 

Le processus d'exportation vers HTML5 permet de convertir PowerPoint en HTML sans extensions Web ni dépendances. Ainsi, en utilisant vos propres modèles, vous pouvez appliquer des options très flexibles qui définissent le processus d'exportation et le HTML, CSS, JavaScript et les attributs d'animation résultants. 

## **Exporter PowerPoint en HTML5**

Ce code Python montre comment exporter une présentation en HTML5 sans extensions Web ni dépendances :
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```


{{% alert color="primary" %}} 

Dans ce cas, vous obtenez du HTML propre. 

{{% /alert %}}

Vous pouvez spécifier les paramètres pour les animations de formes et les transitions de diapositives de cette façon :
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```


## **Exporter PowerPoint en HTML**

Ce code Python démontre le processus standard d'exportation de PowerPoint en HTML :
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```


Dans ce cas, le contenu de la présentation est rendu via SVG sous une forme comme celle-ci :
```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```


{{% alert title="Note" color="warning" %}} 

Lorsque vous utilisez cette méthode pour exporter PowerPoint en HTML, en raison du rendu SVG, vous ne pourrez pas appliquer de styles ni animer d'éléments spécifiques. 

{{% /alert %}}

## **Exporter PowerPoint en Vue Diapositive HTML5**

**Aspose.Slides** vous permet de convertir une présentation PowerPoint en document HTML5 dans lequel les diapositives sont présentées en mode vue diapositive. Dans ce cas, lorsque vous ouvrez le fichier HTML5 résultant dans un navigateur, vous voyez la présentation en mode vue diapositive sur une page Web. 

Ce code Python montre le processus d'exportation de PowerPoint vers la vue diapositive HTML5 :
```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Exporter une présentation contenant des transitions de diapositives, des animations et des animations de formes en HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Enregistrer la présentation
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```


## **Convertir une présentation en document HTML5 avec commentaires**

Les commentaires dans PowerPoint sont un outil qui permet aux utilisateurs de laisser des notes ou des retours sur les diapositives de la présentation. Ils sont particulièrement utiles dans les projets collaboratifs, où plusieurs personnes peuvent ajouter leurs suggestions ou remarques à des éléments spécifiques des diapositives sans modifier le contenu principal. Chaque commentaire affiche le nom de l'auteur, ce qui facilite le suivi de la personne ayant laissé la remarque.

Supposons que nous ayons la présentation PowerPoint suivante enregistrée dans le fichier "sample.pptx".

![Deux commentaires sur la diapositive de la présentation](two_comments_pptx.png)

Lorsque vous convertissez une présentation PowerPoint en document HTML5, vous pouvez facilement indiquer s'il faut inclure les commentaires de la présentation dans le document de sortie. Pour ce faire, vous devez spécifier les paramètres d'affichage des commentaires dans la propriété `notes_comments_layouting` de la classe [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/).

L'exemple de code suivant convertit une présentation en document HTML5 avec les commentaires affichés à droite des diapositives.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```


Le document "output.html" est affiché dans l'image ci‑dessous.

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)

## **FAQ**

**Puis-je contrôler si les animations d'objets et les transitions de diapositives seront jouées en HTML5 ?**

Oui, HTML5 offre des options séparées pour activer ou désactiver les [animations de formes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) et les [transitions de diapositives](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**La sortie des commentaires est‑elle prise en charge, et où peuvent‑ils être placés par rapport à la diapositive ?**

Oui, les commentaires peuvent être ajoutés en HTML5 et positionnés (par exemple, à droite de la diapositive) via les [paramètres de mise en page](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/notes_comments_layouting/) pour les notes et les commentaires.

**Puis‑je ignorer les liens qui invoquent JavaScript pour des raisons de sécurité ou de CSP ?**

Oui, il existe un [paramètre](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) qui permet d'ignorer les hyperliens avec des appels JavaScript lors de l'enregistrement. Cela aide à se conformer à des politiques de sécurité strictes.