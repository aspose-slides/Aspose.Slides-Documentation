---
title: Convertir des présentations en HTML5 dans .NET
linktitle: Présentation en HTML5
type: docs
weight: 40
url: /fr/net/export-to-html5/
keywords:
- PowerPoint vers HTML5
- OpenDocument vers HTML5
- présentation vers HTML5
- diapositive vers HTML5
- PPT vers HTML5
- PPTX vers HTML5
- ODP vers HTML5
- enregistrer PPT en HTML5
- enregistrer PPTX en HTML5
- enregistrer ODP en HTML5
- exporter PPT en HTML5
- exporter PPTX en HTML5
- exporter ODP en HTML5
- .NET
- C#
- Aspose.Slides
description: "Exportez les présentations PowerPoint et OpenDocument vers un HTML5 réactif avec Aspose.Slides pour .NET. Conservez la mise en forme, les animations et l'interactivité."
---

{{% alert title="Info" color="info" %}}

Dans [Aspose.Slides 21.9](/slides/fr/net/aspose-slides-for-net-21-9-release-notes/), nous avons implémenté la prise en charge de l’exportation HTML5. Cependant, si vous préférez exporter votre PowerPoint en HTML en utilisant WebExtensions, consultez [cet article](/slides/fr/net/web-extensions/) à la place. 

{{% /alert %}} 

Le processus d’exportation vers HTML5 permet de convertir PowerPoint en HTML sans extensions web ni dépendances. Ainsi, en utilisant vos propres modèles, vous pouvez appliquer des options très flexibles qui définissent le processus d’exportation et le HTML, CSS, JavaScript et les attributs d’animation résultants. 

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

Vous pouvez spécifier les paramètres pour les animations de formes et les transitions de diapositives de cette façon :
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

Ce code C# illustre le processus standard d’exportation de PowerPoint vers HTML :
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
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


{{% alert title="Note" color="warning" %}} 

Lorsque vous utilisez cette méthode pour exporter PowerPoint vers HTML, en raison du rendu SVG, vous ne pourrez pas appliquer de styles ni animer d’éléments spécifiques. 

{{% /alert %}}

## **Exporter PowerPoint vers la Vue Diapositive HTML5**

**Aspose.Slides** permet de convertir une présentation PowerPoint en document HTML5 dans lequel les diapositives sont présentées en mode vue diapositive. Dans ce cas, lorsque vous ouvrez le fichier HTML5 résultant dans un navigateur, vous voyez la présentation en mode vue diapositive sur une page Web. 

Ce code C# démontre le processus d’exportation PowerPoint vers la Vue Diapositive HTML5 :
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


## **Convertir une Présentation en Document HTML5 avec Commentaires**

Les commentaires dans PowerPoint sont un outil qui permet aux utilisateurs de laisser des notes ou des retours sur les diapositives de la présentation. Ils sont particulièrement utiles dans les projets collaboratifs, où plusieurs personnes peuvent ajouter leurs suggestions ou remarques à des éléments spécifiques des diapositives sans modifier le contenu principal. Chaque commentaire indique le nom de l’auteur, ce qui facilite le suivi de qui a laissé la remarque.

Supposons que nous ayons la présentation PowerPoint suivante enregistrée dans le fichier "sample.pptx".

![Deux commentaires sur la diapositive de la présentation](two_comments_pptx.png)

Lorsque vous convertissez une présentation PowerPoint en document HTML5, vous pouvez facilement spécifier s’il faut inclure les commentaires de la présentation dans le document de sortie. Pour ce faire, vous devez spécifier les paramètres d’affichage des commentaires dans la propriété `NotesCommentsLayouting` de la classe [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) .

L’exemple de code suivant convertit une présentation en document HTML5 avec les commentaires affichés à droite des diapositives.
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


Le document "output.html" est affiché sur l’image ci‑dessous.

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)

## **FAQ**

**Puis‑je contrôler si les animations d’objets et les transitions de diapositives seront lues en HTML5 ?**

Oui, HTML5 offre des options distinctes pour activer ou désactiver les [animations de formes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) et les [transitions de diapositives](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**La sortie des commentaires est‑elle prise en charge, et où peuvent‑ils être placés par rapport à la diapositive ?**

Oui, les commentaires peuvent être ajoutés en HTML5 et positionnés (par exemple, à droite de la diapositive) via les [paramètres de mise en page](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/) pour les notes et les commentaires.

**Puis‑je ignorer les liens qui invoquent du JavaScript pour des raisons de sécurité ou de CSP ?**

Oui, il existe un [paramètre](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) qui permet d’ignorer les hyperliens contenant des appels JavaScript lors de la sauvegarde. Cela aide à respecter des politiques de sécurité strictes.