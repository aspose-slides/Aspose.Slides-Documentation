---
title: Convertir PPT en PPTX avec .NET
linktitle: PPT en PPTX
type: docs
weight: 20
url: /fr/net/convert-ppt-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "Convertissez les présentations PPT héritées en PPTX modernes rapidement avec .NET et Aspose.Slides — tutoriel clair, exemples de code C# gratuits, aucune dépendance à Microsoft Office."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PPT en format PPTX en utilisant C# et une application de conversion en ligne PPT vers PPTX. Le sujet suivant est couvert.

- [Convertir PPT en PPTX en C#](#convert-ppt-to-pptx)

## **Convertir PPT en PPTX dans .NET**

Pour le code d'exemple C# permettant de convertir PPT en PPTX, veuillez consulter la section ci-dessous, c'est‑à‑dire [Convertir PPT en PPTX](#convert-ppt-to-pptx). Il charge simplement le fichier PPT et l'enregistre au format PPTX. En spécifiant différents formats d'enregistrement, vous pouvez également enregistrer le fichier PPT dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme expliqué dans ces articles.

- [C# Convertir PPT en PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Convertir PPT en XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Convertir PPT en HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Convertir PPT en ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Convertir PPT en Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **À propos de la conversion PPT en PPTX**

Convertissez l'ancien format PPT en PPTX avec l'API Aspose.Slides. Si vous devez convertir des milliers de présentations PPT en format PPTX, la meilleure solution est de le faire de manière programmatique. Avec l'API Aspose.Slides, il est possible de le faire en quelques lignes de code. L'API prend en charge la compatibilité complète pour convertir une présentation PPT en PPTX et il est possible de :

- Convertir des structures compliquées de maîtres, de mises en page et de diapositives.
- Convertir des présentations contenant des graphiques.
- Convertir des présentations avec des formes groupées, des auto‑shapes (comme des rectangles et des ellipses), des formes avec une géométrie personnalisée.
- Convertir des présentations contenant des textures et des styles de remplissage d'images pour les auto‑shapes.
- Convertir des présentations avec des espaces réservés, des cadres de texte et des zones de texte.

{{% alert color="primary" %}} 

Jetez un œil à l'application [**Conversion Aspose.Slides PPT en PPTX**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Cette application est construite sur **Aspose.Slides API**, vous permettant de voir un exemple fonctionnel des capacités de conversion de base de PPT en PPTX. Aspose.Slides Conversion est une application Web qui permet de déposer un fichier de présentation au format PPT et de le télécharger converti en PPTX.

Trouvez d'autres exemples en direct de [**Conversion Aspose.Slides**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

## **Convertir PPT en PPTX**

Pour convertir un PPT en PPTX, transmettez simplement le nom du fichier et le format d'enregistrement à la méthode [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) de la classe [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation). Le code d'exemple C# ci‑dessous convertit une présentation de PPT en PPTX en utilisant les options par défaut.
```c#
// Instancier un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Enregistrer la présentation PPTX au format PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


Read more about [**PPT vs PPTX**](/slides/fr/net/ppt-vs-pptx/) formats de présentation et comment [**Aspose.Slides prend en charge la conversion PPT en PPTX**](/slides/fr/net/convert-ppt-to-pptx/).

## **FAQ**

**Quelle est la différence entre les formats PPT et PPTX ?**

PPT est l'ancien format de fichier binaire utilisé par Microsoft PowerPoint, tandis que PPTX est le format XML plus récent introduit avec Microsoft Office 2007. Les fichiers PPTX offrent de meilleures performances, une taille de fichier réduite et une récupération de données améliorée.

**Puis‑je convertir PPT en PPTX avec .NET ?**

Oui, en utilisant la bibliothèque Aspose.Slides pour .NET, vous pouvez facilement charger un fichier PPT et l'enregistrer au format PPTX en quelques lignes de code seulement.

**Aspose.Slides prend‑il en charge la conversion en lot de plusieurs fichiers PPT en PPTX ?**

Oui, vous pouvez utiliser Aspose.Slides dans une boucle pour convertir plusieurs fichiers PPT en PPTX de manière programmatique, ce qui le rend adapté aux scénarios de conversion par lots.

**Le contenu et la mise en forme seront-ils conservés après la conversion ?**

Aspose.Slides maintient une grande fidélité lors de la conversion des présentations. Les mises en page des diapositives, les animations, les formes, les graphiques et d'autres éléments de conception sont préservés pendant la conversion de PPT en PPTX.

**Puis‑je convertir d'autres formats comme PDF ou HTML à partir de fichiers PPT ?**

Oui, Aspose.Slides prend en charge la conversion des fichiers PPT vers plusieurs formats, notamment PDF, XPS, HTML, ODP et les formats d'image comme PNG et JPEG.

**Est‑il possible de convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui, Aspose.Slides pour .NET est une API autonome qui ne nécessite ni Microsoft PowerPoint ni aucun logiciel tiers pour effectuer la conversion.

**Existe‑t‑il un outil en ligne disponible pour la conversion PPT en PPTX ?**

Oui, vous pouvez utiliser le convertisseur gratuit [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) en ligne pour effectuer la conversion directement dans votre navigateur sans écrire de code.