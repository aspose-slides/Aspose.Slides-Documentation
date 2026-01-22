---
title: Convertir PPT en PPTX en PHP
linktitle: PPT en PPTX
type: docs
weight: 20
url: /fr/php-java/convert-ppt-to-pptx/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- PPT en PPTX
- enregistrer PPT en PPTX
- exporter PPT en PPTX
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Convertissez les présentations PPT héritées en PPTX moderne rapidement avec Aspose.Slides pour PHP via Java — tutoriel clair, exemples de code gratuits, aucune dépendance à Microsoft Office."
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format PPT en format PPTX à l'aide de PHP et d'une application en ligne de conversion PPT vers PPTX. Le sujet suivant est couvert.

- Convertir PPT en PPTX

## **Convertir PPT en PPTX en PHP**

Pour le code d'exemple Java visant à convertir PPT en PPTX, veuillez consulter la section ci-dessous, c'est‑à‑dire [Convert PPT to PPTX](#convert-ppt-to-pptx). Il charge simplement le fichier PPT et l'enregistre au format PPTX. En spécifiant différents formats d'enregistrement, vous pouvez également enregistrer le fichier PPT dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme discuté dans ces articles.

- [Convertir PPT en PDF en PHP](/slides/fr/php-java/convert-powerpoint-to-pdf/)
- [Convertir PPT en XPS en PHP](/slides/fr/php-java/convert-powerpoint-to-xps/)
- [Convertir PPT en HTML en PHP](/slides/fr/php-java/convert-powerpoint-to-html/)
- [Convertir PPT en ODP en PHP](/slides/fr/php-java/save-presentation/)
- [Convertir PPT en PNG en PHP](/slides/fr/php-java/convert-powerpoint-to-png/)

## **À propos de la conversion PPT vers PPTX**

Convertissez l'ancien format PPT en PPTX avec l'API Aspose.Slides. Si vous devez convertir des milliers de présentations PPT en format PPTX, la meilleure solution est de le faire programmatiquement. Avec l'API Aspose.Slides, il est possible de le faire en quelques lignes de code seulement. L'API prend en charge une compatibilité totale pour convertir une présentation PPT en PPTX et il est possible de :

- Convertir des structures complexes de maîtres, de mises en page et de diapositives.
- Convertir une présentation contenant des graphiques.
- Convertir une présentation avec des formes groupées, des formes automatiques (comme des rectangles et des ellipses), des formes avec une géométrie personnalisée.
- Convertir une présentation contenant des textures et des styles de remplissage d'images pour les formes automatiques.
- Convertir une présentation avec des espaces réservés, des cadres de texte et des détenteurs de texte.

{{% alert color="primary" %}} 

Jetez un œil à [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) app :
[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Cette application est basée sur [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/), vous pouvez donc voir un exemple réel des capacités de conversion de base de PPT vers PPTX. Aspose.Slides Conversion est une application Web qui permet de déposer un fichier de présentation au format PPT et de le télécharger converti en PPTX.

Découvrez d'autres exemples en ligne de [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .
{{% /alert %}} 

## **Convertir PPT en PPTX**

Aspose.Slides for PHP via Java facilite désormais les développeurs à accéder au PPT à l'aide de l'instance de classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et à le convertir au format [PPTX](https://docs.fileformat.com/presentation/pptx/). Actuellement, il prend en charge la conversion partielle de [PPT](https://docs.fileformat.com/presentation/ppt/) en PPTX. Pour plus de détails sur les fonctionnalités prises en charge et non prises en charge dans la conversion PPT vers PPTX, veuillez consulter cette documentation [link](/slides/fr/php-java/ppt-to-pptx-conversion/).

Aspose.Slides for PHP via Java propose la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) qui représente un fichier de présentation **PPTX**. La classe Presentation peut désormais également accéder au **PPT** via Presentation lorsque l'objet est instancié. L'exemple suivant montre comment convertir une présentation PPT en présentation PPTX.
```php
  # Instancier un objet Presentation qui représente un fichier PPTX
  $pres = new Presentation("Aspose.ppt");
  try {
    # Enregistrement de la présentation PPTX au format PPTX
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figure : Présentation PPT source**|

The above code snippet generated the following PPTX presentation after conversion

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figure : Présentation PPTX générée après conversion**|

## **FAQ**

**Quelle est la différence entre les formats PPT et PPTX ?**

PPT est le format de fichier binaire plus ancien utilisé par Microsoft PowerPoint, tandis que PPTX est le format plus récent basé sur XML introduit avec Microsoft Office 2007. Les fichiers PPTX offrent de meilleures performances, une taille de fichier réduite et une récupération des données améliorée.

**Aspose.Slides prend‑il en charge la conversion en lot de plusieurs fichiers PPT vers PPTX ?**

Oui, vous pouvez utiliser Aspose.Slides dans une boucle pour convertir plusieurs fichiers PPT en PPTX de manière programmatique, ce qui le rend adapté aux scénarios de conversion en lot.

**Le contenu et la mise en forme seront‑ils préservés après la conversion ?**

Aspose.Slides maintient une fidélité élevée lors de la conversion des présentations. Les mises en page des diapositives, les animations, les formes, les graphiques et les autres éléments de conception sont préservés pendant la conversion PPT vers PPTX.

**Puis‑je convertir d'autres formats comme PDF ou HTML à partir de fichiers PPT ?**

Oui, Aspose.Slides prend en charge la conversion des fichiers PPT vers [de multiples formats](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/), y compris PDF, XPS, HTML, ODP et des formats d'image comme PNG et JPEG.

**Est‑il possible de convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui, Aspose.Slides est une API autonome qui ne nécessite ni Microsoft PowerPoint ni aucun logiciel tiers pour effectuer la conversion.

**Existe‑t‑il un outil en ligne disponible pour la conversion PPT vers PPTX ?**

Oui, vous pouvez utiliser l'application Web gratuite [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) pour effectuer la conversion directement dans votre navigateur sans écrire de code.