---
title: Convertir des présentations en HTML5 avec Python
linktitle: Exporter vers HTML5
type: docs
weight: 40
url: /fr/python-net/export-to-html5/
keywords:
- PowerPoint vers HTML5
- OpenDocument vers HTML5
- présentation vers HTML5
- diapositive vers HTML5
- PPT vers HTML5
- PPTX vers HTML5
- ODP vers HTML5
- convertir PowerPoint
- convertir OpenDocument
- convertir présentation
- convertir diapositive
- exportation HTML5
- exporter présentation
- exporter diapositive
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Exportez des présentations PowerPoint et OpenDocument vers du HTML5 adaptatif avec Aspose.Slides pour Python via .NET. Conservez la mise en forme, les animations et l’interactivité."
---

{{% alert title="Info" color="info" %}}

Dans **Aspose.Slides 21.9**, nous avons ajouté la prise en charge de l’exportation HTML5. Cependant, si vous préférez exporter votre PowerPoint en HTML à l’aide de WebExtensions, consultez [cet article](/slides/fr/net/web-extensions/) à la place. 

{{% /alert %}} 

Le processus d’exportation vers HTML5 présenté ici vous permet de convertir un PowerPoint en HTML sans extensions web ni dépendances. Ainsi, en utilisant vos propres modèles, vous pouvez appliquer des options très flexibles qui définissent le processus d’exportation et le HTML, CSS, JavaScript et les attributs d’animation résultants. 

## **Exporter PowerPoint vers HTML5**

Ce code Python montre comment exporter une présentation vers HTML5 sans extensions web ni dépendances :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 

Dans ce cas, vous obtenez du HTML propre. 

{{% /alert %}}

Vous pouvez spécifier les paramètres pour les animations de formes et les transitions de diapositives ainsi :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **Exporter PowerPoint vers HTML**

Ce code Python montre le processus standard d’exportation de PowerPoint vers HTML :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

Dans ce cas, le contenu de la présentation est rendu via SVG sous la forme suivante :

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> LE CONTENU DE LA DIAPOSITIVE VA ICI </g>
     </svg>
</div>
</body>
```

{{% alert title="Remarque" color="warning" %}} 

Lorsque vous utilisez cette méthode pour exporter PowerPoint vers HTML, le rendu SVG empêche l’application de styles ou l’animation d’éléments spécifiques. 

{{% /alert %}}

## **Exporter PowerPoint vers Vue Diapositive HTML5**

**Aspose.Slides** vous permet de convertir une présentation PowerPoint en un document HTML5 dans lequel les diapositives sont présentées en mode vue diapositive. Dans ce cas, lorsque vous ouvrez le fichier HTML5 résultant dans un navigateur, vous voyez la présentation en mode vue diapositive sur une page web. 

Ce code Python montre le processus d’exportation PowerPoint vers Vue Diapositive HTML5 :

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Exporter une présentation contenant des transitions, des animations et des animations de formes vers HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Enregistrer la présentation
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **Convertir une présentation en document HTML5 avec commentaires**

Les commentaires dans PowerPoint sont un outil qui permet aux utilisateurs de laisser des notes ou des retours sur les diapositives. Ils sont particulièrement utiles dans les projets collaboratifs, où plusieurs personnes peuvent ajouter leurs suggestions ou remarques à des éléments spécifiques sans modifier le contenu principal. Chaque commentaire affiche le nom de l’auteur, ce qui facilite le suivi de qui a laissé la remarque.

Supposons que nous disposions de la présentation PowerPoint suivante enregistrée dans le fichier **sample.pptx**.

![Deux commentaires sur la diapositive de la présentation](two_comments_pptx.png)

Lorsque vous convertissez une présentation PowerPoint en document HTML5, vous pouvez facilement choisir d’inclure ou non les commentaires de la présentation dans le document de sortie. Pour ce faire, vous devez spécifier les paramètres d’affichage des commentaires dans la propriété `notes_comments_layouting` de la classe [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/).

L’exemple de code suivant convertit une présentation en document HTML5 avec les commentaires affichés à droite des diapositives.

```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

Le document **output.html** est illustré sur l’image ci‑dessous.

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)

## **FAQ**

**Puis‑je contrôler si les animations d’objets et les transitions de diapositives seront jouées en HTML5 ?**

Oui, HTML5 propose des options distinctes pour activer ou désactiver les [animations de formes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) et les [transitions de diapositives](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**La prise en charge de la sortie des commentaires est‑elle disponible, et où peuvent‑ils être placés par rapport à la diapositive ?**

Oui, les commentaires peuvent être ajoutés en HTML5 et positionnés (par exemple, à droite de la diapositive) via les [paramètres de mise en page](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/notes_comments_layouting/) pour les notes et les commentaires.

**Puis‑je ignorer les liens qui invoquent du JavaScript pour des raisons de sécurité ou de CSP ?**

Oui, il existe un [paramètre](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) qui vous permet de sauter les hyperliens contenant des appels JavaScript lors de l’enregistrement. Cela aide à respecter des politiques de sécurité strictes.