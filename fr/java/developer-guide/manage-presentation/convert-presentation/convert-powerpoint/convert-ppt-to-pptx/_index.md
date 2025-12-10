---
title: Convertir PPT en PPTX en Java
linktitle: PPT en PPTX
type: docs
weight: 20
url: /fr/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Convertissez les présentations PPT hérité en PPTX moderne rapidement en Java avec Aspose.Slides — tutoriel clair, exemples de code gratuits, aucune dépendance à Microsoft Office."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PPT en format PPTX en utilisant Java et une application de conversion en ligne PPT vers PPTX. Le sujet suivant est couvert.

- Convertir PPT en PPTX avec Java

## **Convertir PPT en PPTX avec Java**

Pour le code d'exemple Java permettant de convertir PPT en PPTX, veuillez consulter la section ci-dessous, à savoir [Convertir PPT en PPTX](#convert-ppt-to-pptx). Il charge simplement le fichier PPT et l'enregistre au format PPTX. En spécifiant différents formats d'enregistrement, vous pouvez également enregistrer le fichier PPT dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme expliqué dans ces articles.

- [Java Convertir PPT en PDF](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java Convertir PPT en XPS](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java Convertir PPT en HTML](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java Convertir PPT en ODP](https://docs.aspose.com/slides/java/save-presentation/)
- [Java Convertir PPT en Image](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **À propos de la conversion PPT vers PPTX**

Convertissez l'ancien format PPT en PPTX avec l'API Aspose.Slides. Si vous devez convertir des milliers de présentations PPT en format PPTX, la meilleure solution est de le faire programmatiquement. Avec l'API Aspose.Slides, il est possible de le faire en quelques lignes de code seulement. L'API prend en charge une compatibilité totale pour convertir une présentation PPT en PPTX et il est possible de :

- Convertir des structures complexes de maîtres, de mises en page et de diapositives.
- Convertir une présentation contenant des graphiques.
- Convertir une présentation avec des formes groupées, des formes automatiques (comme des rectangles et des ellipses), des formes à géométrie personnalisée.
- Convertir une présentation comportant des textures et des styles de remplissage d'images pour les formes automatiques.
- Convertir une présentation avec des espaces réservés, des cadres de texte et des porte-texte.

{{% alert color="primary" %}} 

Jetez un œil à l'application [**Aspose.Slides PPT vers PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Cette application est construite sur l'[**API Aspose.Slides**](https://products.aspose.com/slides/java/), vous permettant ainsi de voir un exemple fonctionnel des capacités de conversion de base de PPT vers PPTX. Aspose.Slides Conversion est une application web qui permet de déposer un fichier de présentation au format PPT et de le télécharger converti en PPTX.

Découvrez d'autres exemples en direct de [**Conversion Aspose.Slides**](https://products.aspose.app/slides/conversion/) .
{{% /alert %}} 

## **Convertir PPT en PPTX**

Aspose.Slides pour Java permet désormais aux développeurs d'accéder au PPT à l'aide d'une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) et de le convertir au format [PPTX](https://docs.fileformat.com/presentation/pptx/). Actuellement, il prend en charge la conversion partielle de [PPT](https://docs.fileformat.com/presentation/ppt/) en PPTX. Pour plus de détails sur les fonctionnalités prises en charge ou non dans la conversion PPT vers PPTX, veuillez consulter cette documentation [link](/slides/fr/java/ppt-to-pptx-conversion/).

Aspose.Slides pour Java propose la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) qui représente un fichier de présentation **PPTX**. La classe Presentation peut maintenant également accéder à **PPT** via Presentation lorsque l'objet est instancié. L'exemple suivant montre comment convertir une présentation PPT en présentation PPTX.
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

PPT est l'ancien format de fichier binaire utilisé par Microsoft PowerPoint, tandis que PPTX est le format XML plus récent introduit avec Microsoft Office 2007. Les fichiers PPTX offrent de meilleures performances, une taille de fichier réduite et une récupération des données améliorée.

**Aspose.Slides prend‑t‑il en charge la conversion en lot de plusieurs fichiers PPT en PPTX ?**

Oui, vous pouvez utiliser Aspose.Slides dans une boucle pour convertir plusieurs fichiers PPT en PPTX de manière programmatique, ce qui le rend adapté aux scénarios de conversion en lot.

**Le contenu et la mise en forme seront‑ils conservés après la conversion ?**

Aspose.Slides maintient une grande fidélité lors de la conversion des présentations. Les dispositions des diapositives, les animations, les formes, les graphiques et les autres éléments de conception sont conservés lors de la conversion de PPT en PPTX.

**Puis‑je convertir d'autres formats comme PDF ou HTML à partir de fichiers PPT ?**

Oui, Aspose.Slides prend en charge la conversion des fichiers PPT vers [plusieurs formats](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/), notamment PDF, XPS, HTML, ODP et des formats d'image tels que PNG et JPEG.

**Est‑il possible de convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui, Aspose.Slides est une API autonome qui ne nécessite ni Microsoft PowerPoint ni aucun logiciel tiers pour effectuer la conversion.

**Existe‑t‑il un outil en ligne disponible pour la conversion de PPT en PPTX ?**

Oui, vous pouvez utiliser l'application web gratuite [Convertisseur Aspose.Slides PPT en PPTX](https://products.aspose.app/slides/conversion/ppt-to-pptx) pour effectuer la conversion directement dans votre navigateur sans écrire de code.