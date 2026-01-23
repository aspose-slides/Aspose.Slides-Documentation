---
title: Convertir les présentations en HTML5 en PHP
linktitle: Présentation en HTML5
type: docs
weight: 40
url: /fr/php-java/export-to-html5/
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
- PHP
- Aspose.Slides
description: "Exportez les présentations PowerPoint et OpenDocument en HTML5 réactif avec Aspose.Slides pour PHP via Java. Conservez la mise en forme, les animations et l'interactivité."
---

Aspose.Slides prend en charge l'exportation HTML5. Le processus d'exportation vers HTML5 présenté ici vous permet de convertir PowerPoint en HTML sans extensions Web ni dependances. Ainsi, en utilisant vos propres modèles, vous pouvez appliquer des options très flexibles qui definissent le processus d'exportation et le HTML, CSS, JavaScript et les attributs d'animation resultants. 

## **Exporter PowerPoint en HTML5**

Ce code PHP montre comment exporter une presentation en HTML5 sans extensions Web ni dependances:
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

Vous pouvez specifier les parametres des animations de formes et des transitions de diapositive de cette maniere:
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

Ce code Java demontre le processus standard d'exportation de PowerPoint en HTML:
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


Dans ce cas, le contenu de la presentation est rendu via SVG sous une forme comme celle-ci:
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
Lorsque vous utilisez cette methode pour exporter PowerPoint en HTML, en raison du rendu SVG, vous ne pourrez pas appliquer de styles ni animer des elements specifications.
{{% /alert %}}

## **Exporter PowerPoint en Vue Diapositive HTML5**

**Aspose.Slides** vous permet de convertir une presentation PowerPoint en document HTML5 dans lequel les diapos sont presentees en mode vue diapositive. Dans ce cas, lorsque vous ouvrez le fichier HTML5 resultant dans un navigateur, vous voyez la presentation en mode vue diapositive sur une page Web. 

Ce code PHP demonstre le processus d'exportation PowerPoint vers HTML5 Vue Diapositive:
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


## **Convertir les presentations en documents HTML5 avec commentaires**

Les commentaires dans PowerPoint sont un outil qui permet aux utilisateurs de laisser des notes ou des retours sur les diapos de la presentation. Ils sont particulièrement utiles dans les projets collaboratifs, ou plusieurs personnes peuvent ajouter leurs suggestions ou remarques a des elements specifiques des diapos sans modifier le contenu principal. Chaque commentaire indique le nom de l'auteur, ce qui facilite le suivi de la personne ayant laisse la remarque.

Imaginons que nous ayons la presentation PowerPoint suivante enregistree dans le fichier "sample.pptx".

![Deux commentaires sur la diapositive de la presentation](two_comments_pptx.png)

Lorsque vous convertissez une presentation PowerPoint en document HTML5, vous pouvez facilement specifier s'il faut inclure les commentaires de la presentation dans le document de sortie. Pour ce faire, vous devez specifier les parametres d'affichage des commentaires dans la methode `getNotesCommentsLayouting` de la classe `Html5Options`.

L'exemple de code suivant convertit une presentation en document HTML5 avec les commentaires affiches a droite des diapositives.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```


Le document "output.html" est affiche sur l'image ci-dessous.

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)

## **FAQ**

**Puis-je contrôler si les animations d'objets et les transitions de diapositives seront lues en HTML5 ?**

Oui, HTML5 propose des options distinctes pour activer ou désactiver les [animations de formes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) et les [transitions de diapositives](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/).

**La sortie des commentaires est-elle prise en charge, et où peuvent-ils être placés par rapport à la diapositive ?**

Oui, les commentaires peuvent être ajoutes en HTML5 et positions (par exemple, a droite de la diapositive) via les [parametres de mise en page](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) pour les notes et les commentaires.

**Puis-je ignorer les liens qui invoquent du JavaScript pour des raisons de securite ou de CSP ?**

Oui, il existe un [parametre](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) qui permet d'ignorer les hyperliens contenant des appels JavaScript lors de l'enregistrement. Cela aide a respecter des politiques de securite strictes.