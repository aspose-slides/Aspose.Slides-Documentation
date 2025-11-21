---
title: Exportation vers HTML5
type: docs
weight: 40
url: /fr/nodejs-java/export-to-html5/
keywords:
- PowerPoint vers HTML
- diapositives vers HTML
- HTML5
- export HTML
- exportation de la présentation
- conversion de la présentation
- conversion de diapositives
- Java
- Aspose.Slides pour Node.js via Java
description: "Exportation de PowerPoint vers HTML5 en JavaScript"
---

{{% alert title="Info" color="info" %}}

Dans [Aspose.Slides 21.9](/slides/fr/nodejs-java/aspose-slides-for-java-21-9-release-notes/), nous avons implémenté la prise en charge de l'exportation HTML5.

{{% /alert %}} 

Le processus d'exportation vers HTML5 vous permet de convertir PowerPoint en HTML sans extensions web ni dépendances. Ainsi, en utilisant vos propres modèles, vous pouvez appliquer des options très flexibles qui définissent le processus d'exportation ainsi que le HTML, CSS, JavaScript et les attributs d'animation résultants. 

## **Exporter PowerPoint en HTML5**

Ce code JavaScript montre comment exporter une présentation en HTML5 sans extensions web ni dépendances :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

Dans ce cas, vous obtenez un HTML propre. 

{{% /alert %}}

Vous pouvez spécifier les paramètres des animations de formes et des transitions de diapositives de cette manière :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Exporter PowerPoint en HTML**

Ce JavaScript démontre le processus standard d'exportation de PowerPoint vers HTML :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
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

Lorsque vous utilisez cette méthode pour exporter PowerPoint en HTML, en raison du rendu SVG, vous ne pourrez pas appliquer de styles ni animer d'éléments spécifiques. 

{{% /alert %}}

## **Exporter PowerPoint en vue diapositive HTML5**

**Aspose.Slides** vous permet de convertir une présentation PowerPoint en document HTML5 dans lequel les diapositives sont présentées en mode vue diapositive. Dans ce cas, lorsque vous ouvrez le fichier HTML5 résultant dans un navigateur, vous voyez la présentation en mode vue diapositive sur une page web. 

Ce code JavaScript démontre le processus d'exportation de PowerPoint vers la vue diapositive HTML5 :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir une présentation en document HTML5 avec commentaires**

Les commentaires dans PowerPoint sont un outil qui permet aux utilisateurs de laisser des notes ou des retours sur les diapositives de la présentation. Ils sont particulièrement utiles dans les projets collaboratifs, où plusieurs personnes peuvent ajouter leurs suggestions ou remarques à des éléments spécifiques des diapositives sans modifier le contenu principal. Chaque commentaire indique le nom de l'auteur, ce qui facilite le suivi de la personne ayant laissé la remarque.

Supposons que nous ayons la présentation PowerPoint suivante enregistrée dans le fichier "sample.pptx".

![Deux commentaires sur la diapositive de la présentation](two_comments_pptx.png)

Lorsque vous convertissez une présentation PowerPoint en document HTML5, vous pouvez facilement spécifier s'il faut inclure les commentaires de la présentation dans le document de sortie. Pour ce faire, vous devez spécifier les paramètres d'affichage des commentaires dans la propriété `notes_comments_layouting` de la classe [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/).

L'exemple de code suivant convertit une présentation en document HTML5 avec les commentaires affichés à droite des diapositives.
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```


Le document "output.html" est affiché sur l'image ci-dessous.

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)

## **FAQ**

**Puis-je contrôler si les animations d'objets et les transitions de diapositives seront jouées en HTML5 ?**

Oui, HTML5 propose des options distinctes pour activer ou désactiver les [animations de formes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimateshapes/) et les [transitions de diapositives](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimatetransitions/).

**La sortie des commentaires est-elle prise en charge, et où peuvent-ils être placés par rapport à la diapositive ?**

Oui, les commentaires peuvent être ajoutés en HTML5 et positionnés (par exemple, à droite de la diapositive) via les [paramètres de mise en page](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) pour les notes et les commentaires.

**Puis-je ignorer les liens qui invoquent du JavaScript pour des raisons de sécurité ou de CSP ?**

Oui, il existe un [paramètre](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) qui vous permet d'ignorer les hyperliens contenant des appels JavaScript lors de l'enregistrement. Cela aide à respecter des politiques de sécurité strictes.