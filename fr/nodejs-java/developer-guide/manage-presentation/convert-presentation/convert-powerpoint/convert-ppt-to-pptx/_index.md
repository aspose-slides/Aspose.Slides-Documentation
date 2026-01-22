---
title: Convertir PPT en PPTX en JavaScript
linktitle: PPT en PPTX
type: docs
weight: 20
url: /fr/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertissez rapidement les présentations PPT héritées en PPTX moderne avec Aspose.Slides pour Node.js — tutoriel clair, exemples de code gratuits, sans dépendance à Microsoft Office."
---

## **Vue d’ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PPT en format PPTX à l'aide de JavaScript et d'une application de conversion en ligne PPT vers PPTX. Le sujet suivant est couvert.

- Convertir PPT en PPTX avec JavaScript

## **Java Convertir PPT en PPTX**

Pour le code d'exemple JavaScript permettant de convertir PPT en PPTX, veuillez consulter la section ci‑dessous, à savoir [Convertir PPT en PPTX](#convert-ppt-to-pptx). Il charge simplement le fichier PPT et l'enregistre au format PPTX. En spécifiant différents formats d'enregistrement, vous pouvez également enregistrer le fichier PPT dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme expliqué dans ces articles.

- [Convertir PPT en PDF avec JavaScript](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/)
- [Convertir PPT en XPS avec JavaScript](/slides/fr/nodejs-java/convert-powerpoint-to-xps/)
- [Convertir PPT en HTML avec JavaScript](/slides/fr/nodejs-java/convert-powerpoint-to-html/)
- [Convertir PPT en ODP avec JavaScript](/slides/fr/nodejs-java/save-presentation/)
- [Convertir PPT en PNG avec JavaScript](/slides/fr/nodejs-java/convert-powerpoint-to-png/)

## **À propos de la conversion PPT en PPTX**
Convertissez l'ancien format PPT en PPTX avec l'API Aspose.Slides. Si vous devez convertir des milliers de présentations PPT en format PPTX, la meilleure solution est de le faire de manière programmatique. Avec l'API Aspose.Slides, il est possible de le faire en quelques lignes de code seulement. L'API offre une compatibilité totale pour convertir une présentation PPT en PPTX et il est possible de :

- Convertir des structures complexes de masques, mises en page et diapositives.
- Convertir une présentation contenant des graphiques.
- Convertir une présentation avec des formes groupées, des formes automatiques (comme des rectangles et des ellipses), des formes à géométrie personnalisée.
- Convertir une présentation contenant des textures et des styles de remplissage d'images pour les formes automatiques.
- Convertir une présentation avec des espaces réservés, des cadres de texte et des blocs de texte.

{{% alert color="primary" %}} 

Jetez un œil à l'application [**Conversion Aspose.Slides PPT en PPTX**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Cette application est construite sur l'[**API Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/), vous pouvez donc voir un exemple fonctionnel des capacités de conversion de base de PPT en PPTX. Aspose.Slides Conversion est une application web qui permet de déposer un fichier de présentation au format PPT et de le télécharger converti en PPTX.

Découvrez d'autres exemples en direct de [**Conversion Aspose.Slides**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **Convertir PPT en PPTX**
Aspose.Slides pour Node.js via Java facilite désormais les développeurs à accéder au PPT à l'aide de l'instance de classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) et à le convertir au format [PPTX](https://docs.fileformat.com/presentation/pptx/) correspondant. Actuellement, il prend en charge la conversion partielle de [PPT](https://docs.fileformat.com/presentation/ppt/) en PPTX.

Aspose.Slides pour Node.js via Java propose la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) qui représente un fichier de présentation **PPTX**. La classe Presentation peut désormais également accéder à **PPT** via Presentation lorsque l'objet est instancié. L'exemple suivant montre comment convertir une présentation PPT en présentation PPTX.
```javascript
// Instancier un objet Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // Enregistrement de la présentation PPTX au format PPTX
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figure : Présentation PPT source**|

Le fragment de code ci‑dessus a généré la présentation PPTX suivante après conversion

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figure : Présentation PPTX générée après conversion**|

## **FAQ**

**Quelle est la différence entre les formats PPT et PPTX ?**

PPT est le format de fichier binaire plus ancien utilisé par Microsoft PowerPoint, tandis que PPTX est le format XML plus récent introduit avec Microsoft Office 2007. Les fichiers PPTX offrent de meilleures performances, une taille de fichier réduite et une récupération de données améliorée.

**Aspose.Slides prend‑il en charge la conversion par lot de plusieurs fichiers PPT en PPTX ?**

Oui, vous pouvez utiliser Aspose.Slides dans une boucle pour convertir plusieurs fichiers PPT en PPTX de manière programmatique, ce qui le rend adapté aux scénarios de conversion par lot.

**Le contenu et la mise en forme seront‑ils conservés après la conversion ?**

Aspose.Slides maintient une grande fidélité lors de la conversion des présentations. Les mises en page des diapositives, les animations, les formes, les graphiques et d'autres éléments de conception sont préservés pendant la conversion PPT en PPTX.

**Puis‑je convertir d’autres formats comme PDF ou HTML à partir de fichiers PPT ?**

Oui, Aspose.Slides prend en charge la conversion de fichiers PPT vers plusieurs formats, y compris PDF, XPS, HTML, ODP et les formats d’image tels que PNG et JPEG.

**Est‑il possible de convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui, Aspose.Slides est une API autonome et ne nécessite ni Microsoft PowerPoint ni aucun logiciel tiers pour effectuer la conversion.

**Existe‑t‑il un outil en ligne disponible pour la conversion PPT en PPTX ?**

Oui, vous pouvez utiliser l'application web gratuite [Convertisseur Aspose.Slides PPT en PPTX](https://products.aspose.app/slides/conversion/ppt-to-pptx) pour effectuer la conversion directement dans votre navigateur sans écrire de code.