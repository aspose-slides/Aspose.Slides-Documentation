---
title: Convertir PPT en PPTX en C#
linktitle: Convertir PPT en PPTX
type: docs
weight: 20
url: /fr/net/convert-ppt-to-pptx/
keywords: "C# Convertir PPT en PPTX, Convertir présentation PowerPoint, PPT en PPTX, C#, Csharp, .NET, Aspose.Slides"
description: "Convertir un fichier PowerPoint PPT en PPTX en C# ou .NET"
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PPT en format PPTX en utilisant C# et une application en ligne de conversion PPT vers PPTX. Les sujets suivants sont abordés.

- [Convertir PPT en PPTX en C#](#convert-ppt-to-pptx)

## **C# Convertir PPT en PPTX**

Pour le code d'exemple C# permettant de convertir PPT en PPTX, veuillez consulter la section ci-dessous, à savoir [Convertir PPT en PPTX](#convert-ppt-to-pptx). Il charge simplement le fichier PPT et l'enregistre au format PPTX. En spécifiant différents formats d'enregistrement, vous pouvez également enregistrer le fichier PPT dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme discuté dans ces articles. 

- [C# Convertir PPT en PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Convertir PPT en XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Convertir PPT en HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Convertir PPT en ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Convertir PPT en Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **À propos de la conversion PPT en PPTX**
Convertissez l'ancien format PPT en PPTX avec l'API Aspose.Slides. Si vous devez convertir des milliers de présentations PPT en format PPTX, la meilleure solution consiste à le faire de manière programmatique. Avec l'API Aspose.Slides, il est possible de le faire en seulement quelques lignes de code. L'API offre une compatibilité totale pour convertir une présentation PPT en PPTX et il est possible de :

- Convertir des structures complexes de maîtres, de dispositions et de diapositives.
- Convertir une présentation contenant des graphiques.
- Convertir une présentation avec des formes groupées, des formes automatiques (comme des rectangles et des ellipses), des formes avec une géométrie personnalisée.
- Convertir une présentation comportant des textures et des styles de remplissage d'images pour les formes automatiques.
- Convertir une présentation avec des espaces réservés, des cadres de texte et des conteneurs de texte.

{{% alert color="primary" %}} 

Jetez un œil à l'application [**Conversion PPT en PPTX d'Aspose.Slides**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Cette application est construite sur l'**API Aspose.Slides**, vous pouvez donc voir un exemple fonctionnel des capacités de conversion de base de PPT en PPTX. Aspose.Slides Conversion est une application web qui permet de déposer un fichier de présentation au format PPT et de le télécharger converti en PPTX.

Découvrez d'autres exemples en ligne de [**Conversion Aspose.Slides**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 


## **Convertir PPT en PPTX**
Pour convertir un PPT en PPTX, il suffit de transmettre le nom du fichier et le format d'enregistrement à la méthode [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) de la classe [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation). L'exemple de code C# ci-dessous convertit une présentation du format PPT au format PPTX en utilisant les options par défaut.
```c#
// Instancier un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Enregistrement de la présentation PPTX au format PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


En savoir plus sur les formats de présentation [**PPT vs PPTX**](/slides/fr/net/ppt-vs-pptx/) et sur la façon dont [**Aspose.Slides prend en charge la conversion PPT en PPTX**](/slides/fr/net/convert-ppt-to-pptx/).

## **FAQ**

**Quelle est la différence entre les formats PPT et PPTX ?**

PPT est l'ancien format de fichier binaire utilisé par Microsoft PowerPoint, tandis que PPTX est le nouveau format basé sur XML introduit avec Microsoft Office 2007. Les fichiers PPTX offrent de meilleures performances, une taille de fichier réduite et une récupération de données améliorée.

**Puis‑je convertir PPT en PPTX avec .NET ?**

Oui, en utilisant la bibliothèque Aspose.Slides pour .NET, vous pouvez facilement charger un fichier PPT et l'enregistrer au format PPTX en quelques lignes de code seulement.

**Aspose.Slides prend‑il en charge la conversion par lots de plusieurs fichiers PPT en PPTX ?**

Oui, vous pouvez utiliser Aspose.Slides dans une boucle pour convertir plusieurs fichiers PPT en PPTX de manière programmatique, ce qui le rend adapté aux scénarios de conversion par lots.

**Le contenu et la mise en forme seront‑ils conservés après la conversion ?**

Aspose.Slides maintient une haute fidélité lors de la conversion des présentations. Les dispositions des diapositives, les animations, les formes, les graphiques et les autres éléments de conception sont conservés lors de la conversion de PPT en PPTX.

**Puis‑je convertir d'autres formats comme PDF ou HTML à partir de fichiers PPT ?**

Oui, Aspose.Slides prend en charge la conversion des fichiers PPT vers plusieurs formats, notamment PDF, XPS, HTML, ODP et des formats d'image tels que PNG et JPEG.

**Est‑il possible de convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui, Aspose.Slides pour .NET est une API autonome qui ne nécessite pas Microsoft PowerPoint ni aucun logiciel tiers pour effectuer la conversion.

**Existe‑t‑il un outil en ligne disponible pour la conversion PPT en PPTX ?**

Oui, vous pouvez utiliser le [convertisseur en ligne gratuit Aspose.Slides PPT en PPTX](https://products.aspose.app/slides/conversion/ppt-to-pptx) pour effectuer la conversion directement dans votre navigateur, sans écrire de code.