---
title: Convertir des présentations en HTML5 avec .NET
linktitle: Présentation en HTML5
type: docs
weight: 40
url: /fr/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "Exportez les présentations PowerPoint et OpenDocument vers du HTML5 responsive avec Aspose.Slides pour .NET. Conservez la mise en forme, les animations et l'interactivité."
---
## **Aperçu**

Cet article explique comment convertir des présentations PowerPoint en HTML5 à l'aide d'Aspose.Slides pour .NET. Il couvre l'exportation de base, le contrôle des animations de formes et des transitions de diapositives, ainsi que la mise en page des commentaires. Il compare également la sortie HTML5 avec la sortie basée sur SVG de l'exportation HTML standard.

## **Exporter PowerPoint vers HTML5**

L'exemple suivant charge une présentation depuis le répertoire de travail et l'enregistre au format HTML5. Il utilise les paramètres d'exportation par défaut ; l'exemple suivant montre comment contrôler explicitement la lecture des animations. Remplacez le chemin d'entrée par le chemin de votre présentation.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Note" %}}
En plus du document HTML, l'exportation écrit des fichiers CSS et JavaScript de prise en charge pour le style des diapositives, les animations, les effets et la navigation. Conservez ces fichiers avec le document HTML lors du déplacement ou de la publication de la sortie. La page générée charge également jQuery et Anime.js depuis des CDN publics ; sans eux, la navigation des diapositives et les animations ne fonctionnent pas.
{{% /alert %}}

Pour exporter sans lire les animations de formes ou les transitions de diapositives, définissez [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) et [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) sur `false` dans [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Ces paramètres sont indépendants, vous pouvez donc activer l'un tout en désactivant l'autre. L'exemple exporte la présentation avec les deux types d'animation désactivés dans la page générée.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **Exporter PowerPoint vers HTML**

L'exportation HTML standard utilise une approche de rendu différente : le contenu des diapositives est représenté par du SVG à l'intérieur d'une page HTML. L'exemple suivant convertit une présentation en document HTML en utilisant cette approche de rendu.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

Le balisage simplifié ci‑dessous illustre la structure de la page générée. L'élément SVG contient le contenu rendu de la diapositive ; le texte de l'espace réservé représente ce contenu et n'est pas la sortie d'exportation littérale.

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
L'exportation basée sur SVG n'expose pas les formes PowerPoint en tant qu'éléments HTML individuels. Utilisez l'exportation HTML5 lorsque vous avez besoin des options d'animation de formes et de transition de diapositives présentées dans cet article.
{{% /alert %}}

## **Exporter PowerPoint vers la vue des diapositives HTML5**

L'exportation HTML5 génère une page permettant de visualiser et de naviguer dans les diapositives de la présentation dans un navigateur. Cet exemple active à la fois [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) et [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) afin que la vue des diapositives exportée puisse reproduire les effets de la présentation source.

Utilisez une présentation contenant déjà des animations de formes et des transitions de diapositives pour voir l'effet de ces paramètres. Leur activation n'ajoute pas de nouveaux effets aux diapositives qui n'en ont pas. Après l'exportation, ouvrez le document HTML5 généré dans un navigateur avec ses fichiers de prise en charge disponibles.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **Convertir une présentation en document HTML5 avec des commentaires**

Vous pouvez inclure les commentaires de diapositive existants dans la sortie HTML5 afin que les lecteurs voient les retours à côté du contenu de la diapositive. L'exemple de cette section suppose que la présentation source contient des commentaires, comme illustré ci‑dessous. Il exporte ces commentaires ; il n'en crée pas de nouveaux.

![Deux commentaires sur la diapositive de présentation](two_comments_pptx.png)

Assignez un objet [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) à la propriété [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) de [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Définissez [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) sur `Right` à partir de l'énumération [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) pour placer les commentaires à droite de chaque diapositive.

L'exemple suivant exporte la présentation en HTML5 avec cette mise en page des commentaires. Une présentation sans commentaires n'aura aucun texte de commentaire à afficher.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

L'image ci‑dessous montre le document HTML5 exporté avec les commentaires affichés à côté de la diapositive.

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)

## **Exclure les hyperliens JavaScript lors de l'exportation**

Supposons que `hyperlinks.pptx` contienne du texte lié avec une cible `javascript:alert('Hello')` et un lien ordinaire `https://example.com/`. Pour exclure l'hyperlien JavaScript lors de l'exportation, définissez [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) sur `true`. La valeur par défaut est `false`, ainsi ces liens ne sont pas filtrés sauf si vous activez l'option.

L'exemple suivant charge la présentation depuis le répertoire de travail et l'exporte en utilisant [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

Le fichier exporté omet l'hyperlien JavaScript tout en conservant son texte et le lien HTTPS ordinaire. La présentation source demeure inchangée.

Cette option filtre les hyperliens JavaScript ; elle ne supprime pas tous les scripts ou autre contenu actif, ni ne garantit la conformité CSP. Par exemple, la sortie HTML5 inclut toujours des scripts pour la navigation des diapositives et les animations.

## **FAQ**

**Puis-je contrôler la lecture des animations d'objets et des transitions de diapositives dans HTML5 ?**  
Oui, l'exportation HTML5 fournit des options séparées pour activer ou désactiver les [shape animations](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) et les [slide transitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**Les commentaires sont-ils pris en charge, et où peuvent-ils être placés par rapport à la diapositive ?**  
Oui, les commentaires existants peuvent être inclus dans la sortie HTML5 et positionnés (par exemple, à droite de la diapositive) via les [layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) pour les notes et les commentaires.

**Puis-je ignorer les liens qui invoquent du JavaScript pour des raisons de sécurité ou de CSP ?**  
Oui, le paramètre [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) vous permet d'ignorer les hyperliens contenant des appels JavaScript lors de l'enregistrement. La valeur par défaut est `false`. Consultez [Exclude JavaScript Hyperlinks During Export](/slides/fr/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) pour un exemple simple d'exportation HTML, HTML5 et PDF ainsi que la portée du filtre. Ce paramètre ne supprime pas le JavaScript utilisé par le visualiseur HTML5 pour la navigation et les animations.