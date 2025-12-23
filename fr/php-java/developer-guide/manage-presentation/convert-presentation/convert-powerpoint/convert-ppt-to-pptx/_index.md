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
description: "Convertir rapidement les présentations PPT héritées en PPTX modernes avec Aspose.Slides pour PHP via Java — tutoriel clair, exemples de code gratuits, aucune dépendance à Microsoft Office."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PPT en format PPTX en utilisant PHP et une application de conversion en ligne PPT vers PPTX. Le sujet suivant est couvert.

- Convertir PPT en PPTX

## **Convertir PPT en PPTX avec PHP**

Pour le code d'exemple Java de conversion PPT en PPTX, veuillez consulter la section ci‑dessus, à savoir [Convert PPT to PPTX](#convert-ppt-to-pptx). Il suffit de charger le fichier PPT et de l'enregistrer au format PPTX. En spécifiant différents formats d'enregistrement, vous pouvez également enregistrer le fichier PPT dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme discuté dans ces articles.

- [Java Convertir PPT en PDF](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java Convertir PPT en XPS](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java Convertir PPT en HTML](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java Convertir PPT en ODP](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java Convertir PPT en Image](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **À propos de la conversion PPT vers PPTX**

Convertissez l'ancien format PPT en PPTX avec l'API Aspose.Slides. Si vous devez convertir des milliers de présentations PPT au format PPTX, la meilleure solution est de le faire programmatiquement. Avec l'API Aspose.Slides, il est possible de le faire en quelques lignes de code seulement. L'API offre une compatibilité complète pour convertir une présentation PPT en PPTX et il est possible de :

- Convertir des structures complexes de masques, de mises en page et de diapositives.
- Convertir des présentations contenant des graphiques.
- Convertir des présentations avec des formes groupées, des formes automatiques (comme des rectangles et des ellipses), des formes à géométrie personnalisée.
- Convertir des présentations comportant des textures et des styles de remplissage d'images pour les formes automatiques.
- Convertir des présentations contenant des espaces réservés, des cadres de texte et des zones de texte.

{{% alert color="primary" %}} 

Découvrez l'application [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Cette application est construite sur la base de [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/), vous pouvez donc voir un exemple réel des capacités de conversion de PPT en PPTX. Aspose.Slides Conversion est une application web qui permet de déposer un fichier de présentation au format PPT et de le télécharger converti en PPTX.

Trouvez d'autres exemples en ligne de [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **Convertir PPT en PPTX**

Aspose.Slides pour PHP via Java permet désormais aux développeurs d'accéder au PPT à l'aide de l'instance de classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et de le convertir au format [PPTX](https://docs.fileformat.com/presentation/pptx/). Actuellement, il prend en charge la conversion partielle de [PPT](https://docs.fileformat.com/presentation/ppt/) en PPTX. Pour plus de détails sur les fonctionnalités prises en charge ou non dans la conversion PPT vers PPTX, veuillez consulter cette documentation [link](/slides/fr/php-java/ppt-to-pptx-conversion/).

Aspose.Slides pour PHP via Java propose la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) qui représente un fichier de présentation **PPTX**. La classe Presentation peut désormais également accéder à **PPT** via Presentation lorsque l'objet est instancié. L'exemple suivant montre comment convertir une présentation PPT en présentation PPTX.
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

Le fragment de code ci‑-dessus génère la présentation PPTX suivante après conversion

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figure : Présentation PPTX générée après conversion**|

## **FAQ**

**Quelle est la différence entre les formats PPT et PPTX ?**

PPT est l'ancien format de fichier binaire utilisé par Microsoft PowerPoint, tandis que PPTX est le format plus récent basé sur XML introduit avec Microsoft Office 2007. Les fichiers PPTX offrent de meilleures performances, une taille de fichier réduite et une récupération de données améliorée.

**Aspose.Slides prend‑il en charge la conversion par lots de plusieurs fichiers PPT en PPTX ?**

Oui, vous pouvez utiliser Aspose.Slides dans une boucle pour convertir plusieurs fichiers PPT en PPTX de façon programmée, ce qui le rend adapté aux scénarios de conversion par lots.

**Le contenu et la mise en forme seront‑ils conservés après la conversion ?**

Aspose.Slides maintient une haute fidélité lors de la conversion des présentations. Les mises en page des diapositives, les animations, les formes, les graphiques et d'autres éléments de conception sont préservés pendant la conversion PPT en PPTX.

**Puis‑je convertir d'autres formats comme PDF ou HTML à partir de fichiers PPT ?**

Oui, Aspose.Slides prend en charge la conversion des fichiers PPT vers [multiple formats](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/), notamment PDF, XPS, HTML, ODP et les formats d'image tels que PNG et JPEG.

**Est‑il possible de convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui, Aspose.Slides est une API autonome qui ne nécessite pas Microsoft PowerPoint ni aucun logiciel tiers pour effectuer la conversion.

**Existe‑t‑il un outil en ligne disponible pour la conversion PPT en PPTX ?**

Oui, vous pouvez utiliser le convertisseur en ligne gratuit [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) pour effectuer la conversion directement dans votre navigateur sans écrire de code.