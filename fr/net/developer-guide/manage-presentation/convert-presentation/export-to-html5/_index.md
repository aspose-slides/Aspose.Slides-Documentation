---
title: Exporter vers HTML5
type: docs
weight: 40
url: /fr/net/export-to-html5/
keywords:
- PowerPoint vers HTML
- diapositives vers HTML
- HTML5
- export HTML
- exporter présentation
- convertir présentation
- convertir diapositives
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Exporter PowerPoint vers HTML5 en C# ou .NET"
---

{{% alert title="Info" color="info" %}}

Dans [Aspose.Slides 21.9](/slides/fr/net/aspose-slides-for-net-21-9-release-notes/), nous avons mis en œuvre le support pour l'exportation HTML5. Cependant, si vous préférez exporter votre PowerPoint vers HTML en utilisant les WebExtensions, consultez [cet article](/slides/fr/net/web-extensions/) à la place. 

{{% /alert %}} 

Le processus d'exportation vers HTML5 ici vous permet de convertir PowerPoint en HTML sans WebExtensions ni dépendances. De cette façon, en utilisant vos propres modèles, vous pouvez appliquer des options très flexibles qui définissent le processus d'exportation et le HTML, CSS, JavaScript et les attributs d'animation résultants. 

## **Exporter PowerPoint vers HTML5**

Ce code C# montre comment exporter une présentation vers HTML5 sans WebExtensions ni dépendances :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}} 

Dans ce cas, vous obtenez un HTML propre. 

{{% /alert %}}

Vous pouvez vouloir spécifier les paramètres pour les animations des formes et les transitions des diapositives de cette manière :

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

#### **Exporter PowerPoint vers HTML**

Ce C# démontre le processus standard d'exportation de PowerPoint vers HTML :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

Dans ce cas, le contenu de la présentation est rendu à travers SVG sous une forme comme celle-ci :

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

Lorsque vous utilisez cette méthode pour exporter PowerPoint vers HTML, en raison du rendu SVG, vous ne pourrez pas appliquer de styles ou animer des éléments spécifiques. 

{{% /alert %}}

## **Exporter PowerPoint vers HTML5 en Vue Diapositive**

**Aspose.Slides** vous permet de convertir une présentation PowerPoint en un document HTML5 dans lequel les diapositives sont présentées en mode vue diapositive. Dans ce cas, lorsque vous ouvrez le fichier HTML5 résultant dans un navigateur, vous voyez la présentation en mode vue diapositive sur une page web. 

Ce code C# démontre le processus d'exportation de PowerPoint vers HTML5 en Vue Diapositive :

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

## Convertir une Présentation en Document HTML5 avec Commentaires

Les commentaires dans PowerPoint sont un outil qui permet aux utilisateurs de laisser des notes ou des retours sur les diapositives de présentation. Ils sont particulièrement utiles dans les projets collaboratifs, où plusieurs personnes peuvent ajouter leurs suggestions ou remarques sur des éléments de diapositive spécifiques sans altérer le contenu principal. Chaque commentaire montre le nom de l'auteur, ce qui facilite le suivi de qui a laissé la remarque.

Supposons que nous ayons la présentation PowerPoint suivante enregistrée dans le fichier "sample.pptx".

![Deux commentaires sur la diapositive de présentation](two_comments_pptx.png)

Lorsque vous convertissez une présentation PowerPoint en document HTML5, vous pouvez facilement spécifier si vous souhaitez inclure les commentaires de la présentation dans le document de sortie. Pour ce faire, vous devez spécifier les paramètres d'affichage des commentaires dans la propriété `NotesCommentsLayouting` de la classe [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/).

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

Le document "output.html" est montré dans l'image ci-dessous.

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)