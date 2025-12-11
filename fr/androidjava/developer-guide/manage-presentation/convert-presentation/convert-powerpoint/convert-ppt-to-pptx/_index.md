---
title: Convertir PPT en PPTX sur Android
linktitle: PPT en PPTX
type: docs
weight: 20
url: /fr/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Convertissez les présentations PPT anciennes en PPTX modernes rapidement en Java avec Aspose.Slides pour Android — tutoriel clair, exemples de code gratuits, aucune dépendance à Microsoft Office."
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format PPT en format PPTX en utilisant Java et une application de conversion en ligne de PPT vers PPTX. Le sujet suivant est couvert.

- Convertir PPT en PPTX en Java

## **Convertir PPT en PPTX sur Android**

Pour le code d'exemple Java permettant de convertir PPT en PPTX, veuillez consulter la section ci‑dessous, c’est‑à‑dire [Convertir PPT en PPTX](#convert-ppt-to-pptx). Il charge simplement le fichier PPT et l’enregistre au format PPTX. En spécifiant différents formats de sauvegarde, vous pouvez également enregistrer le fichier PPT dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme indiqué dans ces articles.

- [Convertir PPT en PDF avec Java](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Convertir PPT en XPS avec Java](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Convertir PPT en HTML avec Java](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Convertir PPT en ODP avec Java](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Convertir PPT en image avec Java](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **À propos de la conversion PPT en PPTX**

Convertissez l’ancien format PPT en PPTX avec l’API Aspose.Slides. Si vous devez convertir des milliers de présentations PPT au format PPTX, la meilleure solution consiste à le faire de manière programmatique. Avec l’API Aspose.Slides, il est possible de le faire en quelques lignes de code seulement. L’API prend en charge une compatibilité totale pour convertir une présentation PPT en PPTX et il est possible de :

- Convertir des structures complexes de maîtres, de mises en page et de diapositives.
- Convertir une présentation contenant des graphiques.
- Convertir une présentation avec des formes groupées, des formes automatiques (comme des rectangles et des ellipses), des formes à géométrie personnalisée.
- Convertir une présentation contenant des textures et des styles de remplissage d’images pour les formes automatiques.
- Convertir une présentation avec des espaces réservés, des cadres de texte et des contenants de texte.

{{% alert color="primary" %}} 

Jetez un œil à l’application [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Cette application est construite sur la [**API Aspose.Slides**](https://products.aspose.com/slides/androidjava/), vous pouvez donc voir un exemple fonctionnel des capacités de conversion de base de PPT en PPTX. Aspose.Slides Conversion est une application web qui permet de déposer un fichier de présentation au format PPT et de le télécharger converti en PPTX.

Découvrez d’autres exemples en direct de [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **Convertir PPT en PPTX**

Aspose.Slides pour Android via Java permet désormais aux développeurs d’accéder au PPT à l’aide de l’instance de classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) et de le convertir au format [PPTX](https://docs.fileformat.com/presentation/pptx/). Actuellement, il prend en charge la conversion partielle de [PPT ](https://docs.fileformat.com/presentation/ppt/) en PPTX. Pour plus de détails sur les fonctionnalités prises en charge ou non dans la conversion PPT vers PPTX, veuillez consulter cette documentation [link](/slides/fr/androidjava/ppt-to-pptx-conversion/).

Aspose.Slides pour Android via Java propose la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) qui représente un fichier de présentation **PPTX**. La classe Presentation peut désormais également accéder à **PPT** via Presentation lors de l’instanciation de l’objet. L’exemple suivant montre comment convertir une présentation PPT en présentation PPTX.
```java
// Instancier un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
// Enregistrement de la présentation PPTX au format PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figure : Présentation PPT source**|

Le code ci‑dessus génère la présentation PPTX suivante après conversion

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figure : Présentation PPTX générée après conversion**|

## **FAQ**

**Quelle est la différence entre les formats PPT et PPTX ?**

PPT est l’ancien format de fichier binaire utilisé par Microsoft PowerPoint, tandis que PPTX est le nouveau format basé sur XML introduit avec Microsoft Office 2007. Les fichiers PPTX offrent de meilleures performances, une taille de fichier réduite et une récupération de données améliorée.

**Aspose.Slides prend‑il en charge la conversion par lots de plusieurs fichiers PPT en PPTX ?**

Oui, vous pouvez utiliser Aspose.Slides dans une boucle pour convertir plusieurs fichiers PPT en PPTX de manière programmatique, ce qui le rend adapté aux scénarios de conversion par lots.

**Le contenu et la mise en forme seront-ils conservés après la conversion ?**

Aspose.Slides conserve une haute fidélité lors de la conversion des présentations. Les dispositions des diapositives, les animations, les formes, les graphiques et les autres éléments de conception sont préservés durant la conversion de PPT en PPTX.

**Puis‑je convertir d’autres formats comme PDF ou HTML à partir de fichiers PPT ?**

Oui, Aspose.Slides prend en charge la conversion des fichiers PPT vers [de multiples formats](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/), y compris PDF, XPS, HTML, ODP et des formats d’image tels que PNG et JPEG.

**Est‑il possible de convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui, Aspose.Slides est une API autonome et ne nécessite ni Microsoft PowerPoint ni aucun logiciel tiers pour effectuer la conversion.

**Existe‑t‑il un outil en ligne pour la conversion PPT en PPTX ?**

Oui, vous pouvez utiliser la gratuité de l’application web [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) pour réaliser la conversion directement dans votre navigateur sans écrire de code.