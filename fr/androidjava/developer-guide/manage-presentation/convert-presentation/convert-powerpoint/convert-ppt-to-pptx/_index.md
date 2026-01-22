---
title: Convertir PPT en PPTX sur Android
linktitle: PPT vers PPTX
type: docs
weight: 20
url: /fr/androidjava/convert-ppt-to-pptx/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- PPT en PPTX
- enregistrer PPT au format PPTX
- exporter PPT en PPTX
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Convertissez rapidement les présentations PPT héritées en PPTX moderne en Java avec Aspose.Slides pour Android — tutoriel clair, exemples de code gratuits, aucune dépendance à Microsoft Office."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PPT en format PPTX en utilisant Java et une application de conversion en ligne PPT vers PPTX. Les sujets suivants sont abordés.

- Convertir PPT en PPTX avec Java

## **Convertir PPT en PPTX sur Android**

Pour le code d'exemple Java permettant de convertir PPT en PPTX, veuillez consulter la section ci‑dessous, à savoir [Convert PPT to PPTX](#convert-ppt-to-pptx). Il charge simplement le fichier PPT et l’enregistre au format PPTX. En spécifiant différents formats de sauvegarde, vous pouvez également enregistrer le fichier PPT dans de nombreux autres formats comme PDF, XPS, ODP, HTML, etc., comme expliqué dans ces articles.

- [Convertir PPT en PDF sur Android](/slides/fr/androidjava/convert-powerpoint-to-pdf/)
- [Convertir PPT en XPS sur Android](/slides/fr/androidjava/convert-powerpoint-to-xps/)
- [Convertir PPT en HTML sur Android](/slides/fr/androidjava/convert-powerpoint-to-html/)
- [Convertir PPT en ODP sur Android](/slides/fr/androidjava/save-presentation/)
- [Convertir PPT en PNG sur Android](/slides/fr/androidjava/convert-powerpoint-to-png/)

## **À propos de la conversion PPT vers PPTX**
Convertissez l’ancien format PPT en PPTX avec l’API Aspose.Slides. Si vous devez convertir des milliers de présentations PPT en format PPTX, la meilleure solution consiste à le faire de manière programmatique. Avec l’API Aspose.Slides, il suffit de quelques lignes de code. L’API prend en charge une compatibilité complète pour convertir une présentation PPT en PPTX et permet de :

- Convertir des structures complexes de maîtres, de mises en page et de diapositives.
- Convertir des présentations contenant des graphiques.
- Convertir des présentations avec des formes groupées, des auto‑formes (comme des rectangles et des ellipses), des formes à géométrie personnalisée.
- Convertir des présentations comportant des textures et des styles de remplissage d’images pour les auto‑formes.
- Convertir des présentations contenant des espaces réservés, des cadres de texte et des zones de texte.

{{% alert color="primary" %}} 

Découvrez l’application [**Conversion Aspose.Slides PPT vers PPTX**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Cette application est basée sur l’[**API Aspose.Slides**](https://products.aspose.com/slides/androidjava/), vous pourrez donc voir un exemple en direct des capacités de conversion de base PPT en PPTX. Aspose.Slides Conversion est une application Web qui permet de déposer un fichier de présentation au format PPT et de le télécharger converti en PPTX.

Trouvez d’autres exemples en ligne de [**Conversion Aspose.Slides**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

## **Convertir PPT en PPTX**
Aspose.Slides pour Android via Java permet désormais aux développeurs d’accéder au PPT à l’aide de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) et de le convertir au format [PPTX](https://docs.fileformat.com/presentation/pptx/). Actuellement, il prend en charge la conversion partielle de [PPT](https://docs.fileformat.com/presentation/ppt/) vers PPTX.

Aspose.Slides pour Android via Java propose la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) qui représente un fichier de présentation **PPTX**. La classe Presentation peut désormais aussi accéder aux fichiers **PPT** lorsqu’elle est instanciée. L’exemple suivant montre comment convertir une présentation PPT en présentation PPTX.
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

Le fragment de code ci‑dessus génère la présentation PPTX suivante après conversion

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figure : Présentation PPTX générée après conversion**|

## **FAQ**

**Quelle est la différence entre les formats PPT et PPTX ?**

PPT est l’ancien format binaire utilisé par Microsoft PowerPoint, tandis que PPTX est le nouveau format basé sur XML introduit avec Microsoft Office 2007. Les fichiers PPTX offrent de meilleures performances, une taille de fichier réduite et une récupération de données améliorée.

**Aspose.Slides prend‑il en charge la conversion par lots de plusieurs fichiers PPT en PPTX ?**

Oui, vous pouvez utiliser Aspose.Slides dans une boucle pour convertir plusieurs fichiers PPT en PPTX de façon programmatique, ce qui le rend adapté aux scénarios de conversion par lots.

**Le contenu et la mise en forme seront‑ils conservés après la conversion ?**

Aspose.Slides maintient une haute fidélité lors de la conversion des présentations. Les dispositions des diapositives, les animations, les formes, les graphiques et les autres éléments de conception sont conservés pendant la conversion PPT en PPTX.

**Puis‑je convertir d’autres formats comme PDF ou HTML à partir de fichiers PPT ?**

Oui, Aspose.Slides prend en charge la conversion de fichiers PPT vers [plusieurs formats](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/), y compris PDF, XPS, HTML, ODP et les formats image tels que PNG et JPEG.

**Est‑il possible de convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui, Aspose.Slides est une API autonome qui ne nécessite ni Microsoft PowerPoint ni aucun logiciel tiers pour effectuer la conversion.

**Existe‑t‑il un outil en ligne disponible pour la conversion PPT en PPTX ?**

Oui, vous pouvez utiliser l’application web gratuite [Convertisseur Aspose.Slides PPT vers PPTX](https://products.aspose.app/slides/conversion/ppt-to-pptx) pour réaliser la conversion directement dans votre navigateur, sans écrire de code.