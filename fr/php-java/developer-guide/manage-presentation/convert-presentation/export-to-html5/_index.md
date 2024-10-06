---
title: Exporter vers HTML5
type: docs
weight: 40
url: /php-java/export-to-html5/
keywords:
- PowerPoint vers HTML
- diapositives vers HTML
- HTML5
- export HTML
- exporter présentation
- convertir présentation
- convertir diapositives
- PHP
- Aspose.Slides pour PHP via Java
description: "Exporter PowerPoint vers HTML5 en PHP"
---

{{% alert title="Info" color="info" %}}

Dans [Aspose.Slides 21.9](/slides/php-java/aspose-slides-for-java-21-9-release-notes/), nous avons implémenté le support pour l'exportation HTML5.

{{% /alert %}} 

Le processus d'exportation vers HTML5 ici vous permet de convertir PowerPoint en HTML sans extensions web ni dépendances. De cette façon, en utilisant vos propres modèles, vous pouvez appliquer des options très flexibles qui définissent le processus d'exportation et le HTML, CSS, JavaScript et les attributs d'animation résultants. 

## **Exporter PowerPoint vers HTML5**

Ce code PHP montre comment exporter une présentation vers HTML5 sans extensions web ni dépendances :

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

Dans ce cas, vous obtenez un HTML propre. 

{{% /alert %}}

Vous pouvez vouloir spécifier des paramètres pour les animations des formes et les transitions des diapositives de cette manière :

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

## **Exporter PowerPoint vers HTML**

Cette Java démontre le processus standard de PowerPoint vers HTML :

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

Dans ce cas, le contenu de la présentation est rendu à travers SVG sous une forme comme celle-ci :

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> LE CONTENU DE LA DIAPOSITIVE VA ICI </g>
     </svg>
</div>
</body>
```php

```

{{% alert title="Note" color="warning" %}} 

Lorsque vous utilisez cette méthode pour exporter PowerPoint vers HTML, en raison du rendu SVG, vous ne pourrez pas appliquer des styles ou animer des éléments spécifiques. 

{{% /alert %}}

## **Exporter PowerPoint vers HTML5 Mode Diapositive**

**Aspose.Slides** vous permet de convertir une présentation PowerPoint en un document HTML5 dans lequel les diapositives sont présentées en mode diapositive. Dans ce cas, lorsque vous ouvrez le fichier HTML5 résultant dans un navigateur, vous voyez la présentation en mode diapositive sur une page web. 

Ce code PHP démontre le processus d'exportation de PowerPoint vers HTML5 Mode Diapositive :

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

## Convertir une Présentation en un Document HTML5 avec Commentaires

Les commentaires dans PowerPoint sont un outil qui permet aux utilisateurs de laisser des notes ou des retours sur les diapositives de présentation. Ils sont particulièrement utiles dans les projets collaboratifs, où plusieurs personnes peuvent ajouter leurs suggestions ou remarques sur des éléments spécifiques de la diapositive sans modifier le contenu principal. Chaque commentaire indique le nom de l'auteur, ce qui facilite le suivi de qui a laissé la remarque.

Disons que nous avons la présentation PowerPoint suivante enregistrée dans le fichier "sample.pptx".

![Deux commentaires sur la diapositive de présentation](two_comments_pptx.png)

Lorsque vous convertissez une présentation PowerPoint en un document HTML5, vous pouvez facilement spécifier s'il faut inclure les commentaires de la présentation dans le document de sortie. Pour ce faire, vous devez spécifier les paramètres d'affichage des commentaires dans la méthode `getNotesCommentsLayouting` de la classe `Html5Options`.

L'exemple de code suivant convertit une présentation en un document HTML5 avec les commentaires affichés à droite des diapositives.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```

Le document "output.html" est montré dans l'image ci-dessous.

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)