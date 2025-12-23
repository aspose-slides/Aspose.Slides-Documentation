---
title: Convertir des présentations en HTML5 en PHP
linktitle: Présentation en HTML5
type: docs
weight: 40
url: /fr/php-java/export-to-html5/
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
- PHP
- Aspose.Slides
description: "Exportez les présentations PowerPoint et OpenDocument en HTML5 réactif avec Aspose.Slides pour PHP via Java. Conservez le formatage, les animations et l'interactivité."
---

{{% alert title="Info" color="info" %}}

Dans [Aspose.Slides 21.9](/slides/fr/php-java/aspose-slides-for-java-21-9-release-notes/), nous avons implémenté la prise en charge de l'exportation HTML5.

{{% /alert %}} 

Le processus d'exportation vers HTML5 vous permet de convertir PowerPoint en HTML sans extensions web ni dépendances. Ainsi, en utilisant vos propres modèles, vous pouvez appliquer des options très flexibles qui définissent le processus d'exportation ainsi que le HTML, le CSS, le JavaScript et les attributs d'animation résultants. 

## **Exporter PowerPoint en HTML5**

Ce code PHP montre comment exporter une présentation en HTML5 sans extensions web ni dépendances :
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html5);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 

Dans ce cas, vous obtenez du HTML propre. 

{{% /alert %}}

Vous pouvez spécifier les paramètres des animations de formes et des transitions de diapositives de cette manière :
```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(false);
    $html5Options->setAnimateTransitions(false);
    $pres->save("pres5.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Exporter PowerPoint en HTML**

Ce code Java illustre le processus standard d'exportation de PowerPoint vers HTML :
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
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
```php

```


{{% alert title="Note" color="warning" %}} 

Lorsque vous utilisez cette méthode pour exporter PowerPoint en HTML, en raison du rendu SVG, vous ne pourrez pas appliquer de styles ni animer d'éléments spécifiques. 

{{% /alert %}}

## **Exporter PowerPoint en HTML5 avec vue diapositive**

**Aspose.Slides** permet de convertir une présentation PowerPoint en un document HTML5 dans lequel les diapositives sont présentées en mode vue diapositive. Dans ce cas, lorsque vous ouvrez le fichier HTML5 résultant dans un navigateur, vous voyez la présentation en mode vue diapositive sur une page Web. 

Ce code PHP démontre le processus d'exportation PowerPoint vers HTML5 avec vue diapositive :
```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(true);
    $html5Options->setAnimateTransitions(true);
    $pres->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Convertir des présentations en documents HTML5 avec commentaires**

Les commentaires dans PowerPoint sont un outil qui permet aux utilisateurs de laisser des notes ou des retours sur les diapositives de la présentation. Ils sont particulièrement utiles dans les projets collaboratifs, où plusieurs personnes peuvent ajouter leurs suggestions ou remarques à des éléments spécifiques des diapositives sans modifier le contenu principal. Chaque commentaire affiche le nom de l’auteur, ce qui facilite le suivi de qui a laissé la remarque.

Imaginons que nous ayons la présentation PowerPoint suivante enregistrée dans le fichier "sample.pptx".

![Deux commentaires sur la diapositive de la présentation](two_comments_pptx.png)

Lorsque vous convertissez une présentation PowerPoint en document HTML5, vous pouvez facilement spécifier s’il faut inclure les commentaires de la présentation dans le document de sortie. Pour ce faire, vous devez spécifier les paramètres d’affichage des commentaires dans la méthode `getNotesCommentsLayouting` de la classe `Html5Options`.

L’exemple de code suivant convertit une présentation en document HTML5 avec les commentaires affichés à droite des diapositives.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```


Le document "output.html" est illustré sur l’image ci‑dessous.

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)

## **FAQ**

**Puis‑je contrôler si les animations d’objets et les transitions de diapositives seront lues en HTML5 ?**

Oui, HTML5 propose des options distinctes pour activer ou désactiver les [shape animations](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) et les [slide transitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/).

**La sortie des commentaires est‑elle prise en charge, et où peuvent‑ils être placés par rapport à la diapositive ?**

Oui, les commentaires peuvent être ajoutés en HTML5 et positionnés (par exemple, à droite de la diapositive) via les [layout settings](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) pour les notes et les commentaires.

**Puis‑je ignorer les liens qui invoquent du JavaScript pour des raisons de sécurité ou de CSP ?**

Oui, il existe un [setting](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) qui permet de sauter les hyperliens contenant des appels JavaScript lors de l’enregistrement. Cela aide à se conformer aux politiques de sécurité strictes.