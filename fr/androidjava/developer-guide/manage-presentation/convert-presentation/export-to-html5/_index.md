---
title: Convertir les présentations en HTML5 sur Android
linktitle: Présentation en HTML5
type: docs
weight: 40
url: /fr/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "Exportez les présentations PowerPoint et OpenDocument vers du HTML5 adaptatif avec Aspose.Slides pour Android via Java. Conservez la mise en forme, les animations et l’interactivité."
---
## **Vue d'ensemble**

Cet article explique comment convertir des présentations PowerPoint en HTML5 à l'aide d’Aspose.Slides. Il couvre l’exportation HTML5 de base sans extensions Web ni dépendances supplémentaires, ainsi que les options permettant de contrôler les animations de formes et les transitions de diapositives. L’article montre également le processus d’exportation standard de PowerPoint vers HTML, explique comment générer une sortie HTML5 en mode affichage des diapositives, et démontre comment inclure les commentaires dans le document exporté en configurant leur disposition.

## **Exporter PowerPoint vers HTML5**

Ce code Java montre comment exporter une présentation vers HTML5 sans extensions Web ni dépendances :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}}In this case, you get clean HTML.{{% /alert %}}

Vous pouvez spécifier les paramètres pour les animations de formes et les transitions de diapositives de cette manière :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Exporter PowerPoint vers HTML**

Ce code Java montre le processus standard d’exportation de PowerPoint vers HTML :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
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

{{% alert title="Note" color="warning" %}}When you use this method to export PowerPoint to HTML, due to the SVG rendering, you will not be to apply styles or animate specific elements.{{% /alert %}}

## **Exporter PowerPoint vers la vue diapositive HTML5**

**Aspose.Slides** vous permet de convertir une présentation PowerPoint en un document HTML5 dans lequel les diapositives sont présentées en mode vue diapositive. Dans ce cas, lorsque vous ouvrez le fichier HTML5 résultant dans un navigateur, vous voyez la présentation en mode vue diapositive sur une page Web.

Ce code Java montre le processus d’exportation PowerPoint vers la vue diapositive HTML5 :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir une présentation en document HTML5 avec commentaires**

Les commentaires dans PowerPoint sont un outil qui permet aux utilisateurs de laisser des notes ou des retours sur les diapositives d’une présentation. Ils sont particulièrement utiles dans les projets collaboratifs, où plusieurs personnes peuvent ajouter leurs suggestions ou remarques à des éléments spécifiques des diapositives sans modifier le contenu principal. Chaque commentaire indique le nom de l’auteur, ce qui facilite le suivi de qui a laissé la remarque.

Supposons que nous ayons la présentation PowerPoint suivante enregistrée dans le fichier « sample.pptx ».

![Deux commentaires sur la diapositive de la présentation](two_comments_pptx.png)

Lorsque vous convertissez une présentation PowerPoint en document HTML5, vous pouvez facilement spécifier si les commentaires de la présentation doivent être inclus dans le document de sortie. Pour ce faire, vous devez transmettre les paramètres d’affichage des commentaires à la méthode `setSlidesLayoutOptions` de la classe [Html5Options](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/html5options/).

L’exemple de code suivant convertit une présentation en document HTML5 avec les commentaires affichés à droite des diapositives.
```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Le document « output.html » est montré sur l’image ci‑dessous.

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)

## **FAQ**

### Puis‑je contrôler si les animations d’objets et les transitions de diapositives s’exécutent en HTML5 ?

Oui, HTML5 offre des options distinctes pour activer ou désactiver les [animations de formes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) et les [transitions de diapositives](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

### La prise en charge des commentaires est‑elle disponible, et où peuvent‑ils être placés par rapport à la diapositive ?

Oui, les commentaires peuvent être ajoutés en HTML5 et positionnés (par exemple, à droite de la diapositive) via les [paramètres de disposition](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) pour les notes et les commentaires.

### Puis‑je ignorer les liens qui invoquent du JavaScript pour des raisons de sécurité ou de CSP ?

Oui, il existe un [paramètre](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) qui permet d’ignorer les hyperliens contenant des appels JavaScript lors de l’enregistrement. Cela aide à respecter des politiques de sécurité strictes.