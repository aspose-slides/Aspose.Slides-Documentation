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
description: "Exporter des présentations PowerPoint et OpenDocument en HTML5 responsive avec Aspose.Slides pour .NET. Conserver la mise en forme, les animations et l'interactivité."
---

{{% alert title="Info" color="info" %}}

Dans [Aspose.Slides 21.9](/slides/fr/net/aspose-slides-for-net-21-9-release-notes/), nous avons implémenté la prise en charge de l'exportation HTML5. Cependant, si vous préférez exporter votre PowerPoint vers HTML en utilisant WebExtensions, consultez [cet article](/slides/fr/net/web-extensions/) à la place. 

{{% /alert %}} 

Le processus d'exportation vers HTML5 vous permet de convertir PowerPoint en HTML sans extensions web ni dépendances. Ainsi, en utilisant vos propres modèles, vous pouvez appliquer des options très flexibles qui définissent le processus d'exportation et le HTML, CSS, JavaScript et les attributs d'animation résultants. 

## **Exporter PowerPoint vers HTML5**

Ce code C# montre comment exporter une présentation vers HTML5 sans extensions web ni dépendances :
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```


{{% alert color="primary" %}} 

Dans ce cas, vous obtenez un HTML propre. 

{{% /alert %}}

Vous pouvez spécifier les paramètres des animations de formes et des transitions de diapositives de cette façon :
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```


## **Exporter PowerPoint vers HTML**

Ce code C# montre le processus standard d'exportation de PowerPoint vers HTML :
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```


Dans ce cas, le contenu de la présentation est rendu via SVG sous la forme suivante :
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

Lorsque vous utilisez cette méthode pour exporter PowerPoint vers HTML, en raison du rendu SVG, vous ne pourrez pas appliquer de styles ni animer des éléments spécifiques. 

{{% /alert %}}

## **Exporter PowerPoint vers la vue diapositive HTML5**

**Aspose.Slides** vous permet de convertir une présentation PowerPoint en document HTML5 dans lequel les diapositives sont présentées en mode vue diapositive. Dans ce cas, lorsque vous ouvrez le fichier HTML5 résultant dans un navigateur, vous voyez la présentation en mode vue diapositive sur une page web. 

Ce code C# montre le processus d'exportation PowerPoint vers la vue diapositive HTML5 :
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```


## **Convertir une présentation en document HTML5 avec commentaires**

Les commentaires dans PowerPoint sont un outil qui permet aux utilisateurs de laisser des notes ou des retours sur les diapositives de la présentation. Ils sont particulièrement utiles dans les projets collaboratifs, où plusieurs personnes peuvent ajouter leurs suggestions ou remarques à des éléments spécifiques des diapositives sans modifier le contenu principal. Chaque commentaire affiche le nom de l’auteur, facilitant ainsi le suivi de qui a laissé la remarque.

Imaginons que nous ayons la présentation PowerPoint suivante enregistrée dans le fichier "sample.pptx".

![Deux commentaires sur la diapositive de la présentation](two_comments_pptx.png)

Lorsque vous convertissez une présentation PowerPoint en document HTML5, vous pouvez facilement spécifier si les commentaires de la présentation doivent être inclus dans le document de sortie. Pour ce faire, vous devez spécifier les paramètres d'affichage des commentaires dans la propriété `NotesCommentsLayouting` de la classe [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/).

L'exemple de code suivant convertit une présentation en document HTML5 avec les commentaires affichés à droite des diapositives.
```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```


Le document "output.html" est affiché dans l'image ci‑dessous.

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)

## **FAQ**

**Puis‑je contrôler si les animations d’objets et les transitions de diapositives seront lues en HTML5 ?**

Oui, HTML5 propose des options distinctes pour activer ou désactiver les [animations de formes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) et les [transitions de diapositives](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**La sortie des commentaires est‑elle prise en charge, et où peuvent‑ils être placés par rapport à la diapositive ?**

Oui, les commentaires peuvent être ajoutés en HTML5 et positionnés (par exemple, à droite de la diapositive) via les [paramètres de mise en page](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/) pour les notes et les commentaires.

**Puis‑je ignorer les liens qui invoquent du JavaScript pour des raisons de sécurité ou de CSP ?**

Oui, il existe un [paramètre](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) qui vous permet d'ignorer les hyperliens contenant des appels JavaScript lors de l'enregistrement. Cela aide à respecter des politiques de sécurité strictes.