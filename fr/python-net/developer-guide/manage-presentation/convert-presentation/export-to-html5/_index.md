---
title: Exporter vers HTML5
type: docs
weight: 40
url: /fr/python-net/export-to-html5/
keywords:
- PowerPoint vers HTML
- diapositives vers HTML
- HTML5
- exportation HTML
- exportation de présentation
- conversion de présentation
- conversion de diapositives
- Java
- Aspose.Slides pour Python via .NET
description: "Exporter PowerPoint vers HTML5 en Python"
---

{{% alert title="Info" color="info" %}}

Dans **Aspose.Slides 21.9**, nous avons implémenté le support pour l'exportation HTML5. Cependant, si vous préférez exporter votre PowerPoint vers HTML en utilisant les WebExtensions, consultez [cet article](/slides/fr/net/web-extensions/) à la place.

{{% /alert %}} 

Le processus d'exportation vers HTML5 ici vous permet de convertir PowerPoint en HTML sans WebExtensions ni dépendances. De cette manière, en utilisant vos propres modèles, vous pouvez appliquer des options très flexibles qui définissent le processus d'exportation et le HTML résultant, CSS, JavaScript et les attributs d'animation.

## **Exporter PowerPoint vers HTML5**

Ce code Python montre comment exporter une présentation vers HTML5 sans WebExtensions ni dépendances :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 

Dans ce cas, vous obtenez un HTML propre. 

{{% /alert %}}

Vous voudrez peut-être spécifier les paramètres pour les animations de formes et les transitions de diapositives de cette manière :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

#### **Exporter PowerPoint vers HTML**

Ce code Python illustre le processus standard d'exportation de PowerPoint vers HTML :

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
         <g> LE CONTENU DE LA DIAPOSITIVE VA ICI </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 

Lorsque vous utilisez cette méthode pour exporter PowerPoint vers HTML, en raison du rendu SVG, vous ne pourrez pas appliquer de styles ni animer des éléments spécifiques. 

{{% /alert %}}

## **Exporter PowerPoint vers HTML5 en mode Diaporama**

**Aspose.Slides** vous permet de convertir une présentation PowerPoint en un document HTML5 dans lequel les diapositives sont présentées en mode diaporama. Dans ce cas, lorsque vous ouvrez le fichier HTML5 résultant dans un navigateur, vous voyez la présentation en mode diaporama sur une page web.

Ce code Python montre le processus d'exportation PowerPoint vers HTML5 en mode Diaporama :

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Exporter une présentation contenant des transitions de diapositives, des animations et des animations de formes vers HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Sauvegarder la présentation
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## Convertir une présentation en document HTML5 avec commentaires

Les commentaires dans PowerPoint sont un outil qui permet aux utilisateurs de laisser des notes ou des retours sur les diapositives de présentation. Ils sont particulièrement utiles dans les projets collaboratifs, où plusieurs personnes peuvent ajouter leurs suggestions ou remarques à des éléments de diapositives spécifiques sans modifier le contenu principal. Chaque commentaire affiche le nom de l'auteur, ce qui facilite le suivi de qui a laissé la remarque.

Disons que nous avons la présentation PowerPoint suivante enregistrée dans le fichier "sample.pptx".

![Deux commentaires sur la diapositive de présentation](two_comments_pptx.png)

Lorsque vous convertissez une présentation PowerPoint en document HTML5, vous pouvez facilement spécifier si vous souhaitez inclure les commentaires de la présentation dans le document de sortie. Pour ce faire, vous devez spécifier les paramètres d'affichage des commentaires dans la propriété `notes_comments_layouting` de la classe [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/).

L'exemple de code suivant convertit une présentation en document HTML5 avec des commentaires affichés à droite des diapositives.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

Le document "output.html" est montré dans l'image ci-dessous.

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)