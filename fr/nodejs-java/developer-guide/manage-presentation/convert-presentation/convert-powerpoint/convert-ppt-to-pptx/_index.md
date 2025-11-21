---
title: Convertir PPT en PPTX en JavaScript
linktitle: Convertir PPT en PPTX
type: docs
weight: 20
url: /fr/nodejs-java/convert-ppt-to-pptx/
keywords: "Java Convertir PPT en PPTX, PowerPoint PPT en PPTX en JavaScript"
description: "Convertir PowerPoint PPT en PPTX en JavaScript."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PPT en format PPTX à l'aide de JavaScript et d'une application de conversion en ligne PPT vers PPTX. Les sujets suivants sont abordés.

- Convertir PPT en PPTX avec JavaScript

## **Java Convert PPT to PPTX**

Pour le code d'exemple JavaScript permettant de convertir PPT en PPTX, voir la section ci‑dessous : [Convert PPT to PPTX](#convert-ppt-to-pptx). Le code charge simplement le fichier PPT et le sauvegarde au format PPTX. En spécifiant différents formats de sauvegarde, vous pouvez également enregistrer le fichier PPT dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme expliqué dans ces articles.

- [Java Convert PPT to PDF](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-pdf/)
- [Java Convert PPT to XPS](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-xps/)
- [Java Convert PPT to HTML](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-html/)
- [Java Convert PPT to ODP](https://docs.aspose.com/slides/nodejs-java/save-presentation/)
- [Java Convert PPT to Image](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-png/)

## **À propos de la conversion PPT vers PPTX**
Convertissez le format PPT ancien en PPTX avec l’API Aspose.Slides. Si vous devez convertir des milliers de présentations PPT en PPTX, la meilleure solution consiste à le faire de façon programmatique. Avec l’API Aspose.Slides, cela est possible en quelques lignes de code. L’API assure une compatibilité totale pour convertir une présentation PPT en PPTX et permet de :

- Convertir des structures complexes de maîtres, de dispositions et de diapositives.
- Convertir des présentations contenant des graphiques.
- Convertir des présentations avec des formes groupées, des auto‑formes (comme des rectangles et des ellipses), des formes à géométrie personnalisée.
- Convertir des présentations possédant des textures et des images comme styles de remplissage pour les auto‑formes.
- Convertir des présentations avec des espaces réservés, des cadres de texte et des zones de texte.

{{% alert color="primary" %}} 

Découvrez l’application [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Cette application est basée sur l’[**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/), vous pouvez donc voir un exemple fonctionnel des capacités de conversion de base de PPT vers PPTX. Aspose.Slides Conversion est une application web qui permet de déposer un fichier de présentation au format PPT et de le télécharger converti en PPTX.

Découvrez d’autres exemples en direct de [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

## **Convertir PPT en PPTX**
Aspose.Slides pour Node.js via Java permet désormais aux développeurs d’accéder à la présentation PPT à l’aide de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) et de la convertir au format [PPTX](https://docs.fileformat.com/presentation/pptx/). Actuellement, il prend en charge la conversion partielle de [PPT](https://docs.fileformat.com/presentation/ppt/) en PPTX. Pour plus de détails sur les fonctionnalités prises en charge et non prises en charge dans la conversion PPT vers PPTX, consultez la documentation suivante : [link](/slides/fr/nodejs-java/ppt-to-pptx-conversion/).

Aspose.Slides pour Node.js via Java offre la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) qui représente un fichier de présentation **PPTX**. La classe Presentation peut désormais accéder également à **PPT** lorsqu’elle est instanciée. L’exemple suivant montre comment convertir une présentation PPT en présentation PPTX.
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

Le fragment de code ci‑dessus génère la présentation PPTX suivante après conversion

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figure : Présentation PPTX générée après conversion**|

## **FAQ**

**Quelle est la différence entre les formats PPT et PPTX ?**

PPT est l’ancien format binaire utilisé par Microsoft PowerPoint, tandis que PPTX est le nouveau format basé sur XML introduit avec Microsoft Office 2007. Les fichiers PPTX offrent de meilleures performances, une taille de fichier réduite et une récupération de données améliorée.

**Aspose.Slides prend‑il en charge la conversion en lots de plusieurs fichiers PPT en PPTX ?**

Oui, vous pouvez utiliser Aspose.Slides dans une boucle pour convertir plusieurs fichiers PPT en PPTX de façon programmatique, ce qui convient aux scénarios de conversion en lots.

**Le contenu et le formatage seront‑ils conservés après la conversion ?**

Aspose.Slides maintient une haute fidélité lors de la conversion des présentations. Les dispositions de diapositives, les animations, les formes, les graphiques et les autres éléments de conception sont préservés pendant la conversion PPT en PPTX.

**Puis‑je convertir d’autres formats comme PDF ou HTML à partir de fichiers PPT ?**

Oui, Aspose.Slides prend en charge la conversion des fichiers PPT vers plusieurs formats, notamment PDF, XPS, HTML, ODP et des formats d’image tels que PNG et JPEG.

**Est‑il possible de convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui, Aspose.Slides est une API autonome qui ne nécessite ni Microsoft PowerPoint ni aucun logiciel tiers pour effectuer la conversion.

**Existe‑t‑il un outil en ligne pour la conversion PPT en PPTX ?**

Oui, vous pouvez utiliser gratuitement l’application web [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) pour réaliser la conversion directement dans votre navigateur sans écrire de code.