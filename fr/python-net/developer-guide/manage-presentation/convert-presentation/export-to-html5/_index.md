---
title: Convertir des présentations en HTML5 avec Python
linktitle: Présentation en HTML5
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
- enregistrer PPT en HTML5
- enregistrer PPTX en HTML5
- enregistrer ODP en HTML5
- exporter PPT en HTML5
- exporter PPTX en HTML5
- exporter ODP en HTML5
- Python
- Aspose.Slides
description: "Exportez des présentations PowerPoint et OpenDocument en HTML5 réactif avec Aspose.Slides pour Python via .NET. Conservez la mise en forme, les animations et l'interactivité."
---
## **Vue d'ensemble**

Cet article explique comment convertir des présentations PowerPoint en HTML5 à l’aide d'Aspose.Slides pour Python via .NET. Il couvre l'exportation de base, le contrôle des animations de formes et des transitions de diapositives, ainsi que la disposition des commentaires. Il compare également la sortie HTML5 avec la sortie basées sur SVG de l'exportation HTML standard.

## **Exporter PowerPoint vers HTML5**

L'exemple suivant charge une présentation depuis le répertoire de travail et l'enregistre au format HTML5. Il utilise les paramètres d'exportation par défaut ; l'exemple suivant montre comment contrôler explicitement la lecture des animations. Remplacez le chemin d'entrée par le chemin de votre présentation.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}
En plus du document HTML, l'exportation écrit des fichiers CSS et JavaScript supportés pour le style des diapositives, les animations, les effets et la navigation. Conservez ces fichiers avec le document HTML lors du déplacement ou de la publication du résultat. La page générée charge également jQuery et Anime.js depuis des CDN publics ; sans eux, la navigation et les animations des diapositives ne fonctionnent pas.
{{% /alert %}}

Pour exporter sans lire les animations de formes ou les transitions de diapositives, définissez [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) et [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) sur `False` dans [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Ces paramètres sont independants, vous pouvez donc activer l'un tout en désactivant l'autre. L'exemple exporte la présentation avec les deux types d'animation désactivés dans la page générée.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Exporter PowerPoint vers HTML**

L'exportation HTML standard utilise une approche de rendu différente : le contenu des diapositives est représenté par du SVG dans une page HTML. L'exemple suivant convertit une présentation en document HTML en utilisant cette approche de rendu.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

La balise simplifiée ci-dessous illustre la structure de la page générée. L'élément SVG contient le contenu rendu de la diapositive ; le texte de substitution représente ce contenu et n'est pas la sortie d'exportation littérale.

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
L'exportation basée sur SVG n'expose pas les formes PowerPoint comme des éléments HTML individuels. Utilisez l'exportation HTML5 lorsque vous avez besoin des options d'animation de forme et de transition de diapositive démontrées dans cet article.
{{% /alert %}}

## **Exporter PowerPoint vers la Vue de Diapositive HTML5**

L'exportation HTML5 produit une page pour visualiser et naviguer les diapositives de la présentation dans un navigateur. Cet exemple active à la fois [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) et [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) afin que la vue de diapositive exportée puisse lire les effets de la présentation source.

Utilisez une présentation contenant déjà des animations de formes et des transitions de diapositives pour voir l'effet de ces paramètres. Leur activation n'ajoute pas de nouveaux effets aux diapositives qui n'en ont pas. Après l'exportation, ouvrez le document HTML5 généré dans un navigateur avec ses fichiers supports disponibles.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Convertir une Presentation en Document HTML5 avec Commentaires**

Vous pouvez inclure les commentaires existants des diapositives dans la sortie HTML5 afin que les lecteurs voient les retours à côté du contenu de la diapositive. L'exemple de cette section suppose que la présentation source contient des commentaires, comme illustré ci-dessous. Il exporte ces commentaires ; il ne crée pas de nouveaux.

![Deux commentaires sur la diapositive de présentation](two_comments_pptx.png)

Attribuez un objet [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) à la propriété [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) de [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Définissez [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) sur `RIGHT` à partir de l'énumération [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) pour placer les commentaires à droite de chaque diapositive.

L'exemple suivant exporte la présentation en HTML5 avec cette disposition des commentaires. Une présentation sans commentaires n'aura aucun texte de commentaire à afficher.

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)

## **Exclure les Hyperliens JavaScript lors de l'Exportation**

Supposons que `hyperlinks.pptx` contienne du texte lié avec une cible `javascript:alert('Hello')` et un lien ordinaire `https://example.com/`. Pour exclure le lien hypertexte JavaScript lors de l'exportation, réglez [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) sur `True`. La valeur par défaut est `False`, de sorte que ces liens ne sont pas filtrés à moins d'activer l'option.

L'exemple suivant charge la présentation depuis le répertoire de travail et l'exporte en utilisant [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) :

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

Le fichier exporté omet le lien hypertexte JavaScript tout en conservant son texte et le lien HTTPS ordinaire. La présentation source reste inchangée.

Cette option filtre les hyperliens JavaScript ; elle ne supprime pas tous les scripts ou autres contenus actifs, ni ne garantit la conformité CSP. Par exemple, la sortie HTML5 inclut toujours des scripts pour la navigation des diapositives et les animations.

## **FAQ**

**Puis-je contrôler si les animations d'objets et les transitions de diapositives seront lues en HTML5 ?**

Oui, l'exportation HTML5 propose des options séparées pour activer ou désactiver les [animations de formes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) et les [transitions de diapositives](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**Les commentaires sont-ils pris en charge, et où peuvent-ils être placés par rapport à la diapositive ?**

Oui, les commentaires existants peuvent être inclus dans la sortie HTML5 et positionnés (par exemple, à droite de la diapositive) via les [paramètres de disposition](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) pour les notes et les commentaires.

**Puis-je ignorer les liens qui invoquent du JavaScript pour des raisons de sécurité ou de CSP ?**

Oui, le paramètre [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) vous permet d'ignorer les hyperliens contenant des appels JavaScript lors de l'enregistrement. La valeur par défaut est `False`. Consultez [Exclure les Hyperliens JavaScript lors de l'Exportation](/slides/fr/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) pour un exemple d'exportation HTML5 et la portée du filtre. Ce paramètre ne supprime pas le JavaScript utilisé par le visualiseur HTML5 pour la navigation et les animations.