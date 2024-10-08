---
title: Convertir PPT en PPTX en C#
linktitle: Convertir PPT en PPTX
type: docs
weight: 20
url: /fr/net/convert-ppt-to-pptx/
keywords: "C# Convertir PPT en PPTX, Convertir Présentation PowerPoint, PPT en PPTX, C#, Csharp, .NET, Aspose.Slides"
description: "Convertir PowerPoint PPT en PPTX en C# ou .NET"
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format PPT en format PPTX en utilisant C# et avec une application de conversion en ligne PPT en PPTX. Les sujets suivants sont abordés.

- [Convertir PPT en PPTX en C#](#convertir-ppt-en-pptx)

## **C# Convertir PPT en PPTX**

Pour un exemple de code C# pour convertir PPT en PPTX, veuillez consulter la section ci-dessous i.e. [Convertir PPT en PPTX](#convertir-ppt-en-pptx). Il suffit de charger le fichier PPT et de l'enregistrer au format PPTX. En spécifiant différents formats de sauvegarde, vous pouvez également enregistrer le fichier PPT dans de nombreux autres formats comme PDF, XPS, ODP, HTML, etc. comme discuté dans ces articles.

- [C# Convertir PPT en PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Convertir PPT en XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Convertir PPT en HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Convertir PPT en ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Convertir PPT en Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **À propos de la conversion PPT en PPTX**
Convertissez l'ancien format PPT en PPTX avec l'API Aspose.Slides. Si vous devez convertir des milliers de présentations PPT en format PPTX, la meilleure solution est de le faire par programme. Avec l'API Aspose.Slides, il est possible de le faire en quelques lignes de code. L'API prend en charge une compatibilité totale pour convertir une présentation PPT en PPTX et il est possible de :

- Convertir des structures compliquées de maîtres, de mises en page et de diapositives.
- Convertir des présentations avec des graphiques.
- Convertir des présentations avec des formes groupées, des formes automatiques (comme des rectangles et des ellipses), des formes avec une géométrie personnalisée.
- Convertir des présentations ayant des styles de remplissage de textures et d'images pour des formes automatiques.
- Convertir des présentations avec des espaces réservés, des cadres de texte et des supports de texte.

{{% alert color="primary" %}} 

Jetez un œil à l'application [**Aspose.Slides Conversion PPT en PPTX**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Cette application est construite sur la base de l'**API Aspose.Slides**, vous pouvez donc voir un exemple vivant des capacités de conversion de base de PPT en PPTX. La conversion Aspose.Slides est une application web, qui permet de déposer un fichier de présentation au format PPT et de le télécharger converti en PPTX.

Trouvez d'autres exemples en direct de [**Conversion Aspose.Slides**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

## **Convertir PPT en PPTX**
Pour convertir un PPT en PPTX, il suffit de passer le nom du fichier et le format de sauvegarde à la méthode [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) de la classe [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation). L'exemple de code C# ci-dessous convertit une présentation de PPT en PPTX en utilisant les options par défaut.

```c#
// Instancier un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Sauvegarder la présentation PPTX au format PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

Lisez-en plus sur les formats de présentation [**PPT vs PPTX**](/slides/fr/net/ppt-vs-pptx/) et comment [**Aspose.Slides prend en charge la conversion PPT en PPTX**](/slides/fr/net/convert-ppt-to-pptx/).