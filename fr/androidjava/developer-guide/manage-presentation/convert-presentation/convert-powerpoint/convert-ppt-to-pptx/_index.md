---
title: Convertir PPT en PPTX en Java
linktitle: Convertir PPT en PPTX
type: docs
weight: 20
url: /androidjava/convert-ppt-to-pptx/
keywords: "Java Convertir PPT en PPTX, PowerPoint PPT en PPTX en Java"
description: "Convertir PowerPoint PPT en PPTX en Java."
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format PPT en format PPTX en utilisant Java et une application en ligne de conversion PPT en PPTX. Le sujet suivant est couvert.

- Convertir PPT en PPTX en Java

## **Java Convertir PPT en PPTX**

Pour voir du code d'exemple Java pour convertir PPT en PPTX, veuillez consulter la section ci-dessous, c'est-à-dire [Convertir PPT en PPTX](#convert-ppt-to-pptx). Cela charge simplement le fichier PPT et l'enregistre au format PPTX. En spécifiant différents formats d'enregistrement, vous pouvez également enregistrer le fichier PPT dans de nombreux autres formats comme PDF, XPS, ODP, HTML, etc. comme discuté dans ces articles.

- [Java Convertir PPT en PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java Convertir PPT en XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java Convertir PPT en HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java Convertir PPT en ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java Convertir PPT en Image](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **À propos de la conversion PPT en PPTX**
Convertir l'ancien format PPT en PPTX avec l'API Aspose.Slides. Si vous devez convertir des milliers de présentations PPT en format PPTX, la meilleure solution est de le faire par programmation. Avec l'API Aspose.Slides, il est possible de le faire en quelques lignes de code. L'API prend en charge une compatibilité totale pour convertir la présentation PPT en PPTX et il est possible de :

- Convertir des structures compliquées de maîtres, de mises en page et de diapositives.
- Convertir des présentations avec des graphiques.
- Convertir des présentations avec des formes groupées, des formes automatiques (comme des rectangles et des ellipses), des formes avec une géométrie personnalisée.
- Convertir des présentations ayant des styles de remplissage de textures et d'images pour des formes automatiques.
- Convertir des présentations avec des espaces réservés, des cadres de texte et des conteneurs de texte.

{{% alert color="primary" %}} 

Jetez un œil à l'application [**Aspose.Slides Conversion PPT en PPTX**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Cette application est construite sur la base de [**l'API Aspose.Slides**](https://products.aspose.com/slides/androidjava/), vous pouvez donc voir un exemple en direct des capacités de conversion de PPT en PPTX. La conversion Aspose.Slides est une application web qui permet de déposer un fichier de présentation au format PPT et de le télécharger converti au format PPTX.

Trouvez d'autres exemples en direct de [**Conversion Aspose.Slides**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

## **Convertir PPT en PPTX**
Aspose.Slides pour Android via Java facilite maintenant aux développeurs l'accès à PPT en utilisant une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) et de la convertir au format [PPTX](https://docs.fileformat.com/presentation/pptx/). Actuellement, cela prend en charge la conversion partielle de [PPT](https://docs.fileformat.com/presentation/ppt/) en PPTX. Pour plus de détails sur les fonctionnalités prises en charge et non prises en charge dans la conversion PPT en PPTX, veuillez consulter cette documentation [lien](/slides/androidjava/ppt-to-pptx-conversion/).

Aspose.Slides pour Android via Java offre la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) qui représente un fichier de présentation **PPTX**. La classe Presentation peut maintenant également accéder au **PPT** lorsque l'objet est instancié. L'exemple suivant montre comment convertir une présentation PPT en présentation PPTX.

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
|**Figure : Présentation PPT Source**|

Le code ci-dessus a généré la présentation PPTX suivante après conversion

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figure : Présentation PPTX générée après conversion**|