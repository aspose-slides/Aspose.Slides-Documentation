---
title: Convertir PPT en PPTX dans .NET
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
description: "Convertissez les présentations PPT legacy en PPTX modernes rapidement dans .NET avec Aspose.Slides — tutoriel clair, exemples de code C# gratuits, aucune dépendance à Microsoft Office."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PPT en format PPTX à l'aide de C# et d'une application de conversion en ligne PPT vers PPTX. Le sujet suivant est couvert.

- [Convertir PPT en PPTX en C#](#convert-ppt-to-pptx)

## **Convertir PPT en PPTX en .NET**

Pour le code d'exemple C# permettant de convertir PPT en PPTX, veuillez consulter la section ci‑dessous, c’est‑à‑dire [Convertir PPT en PPTX](#convert-ppt-to-pptx). Il charge simplement le fichier PPT et l’enregistre au format PPTX. En spécifiant différents formats d’enregistrement, vous pouvez également enregistrer le fichier PPT dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme discuté dans ces articles. 

- [Convertir PPT en PDF en .NET](/slides/fr/net/convert-powerpoint-to-pdf/)
- [Convertir PPT en XPS en .NET](/slides/fr/net/convert-powerpoint-to-xps/)
- [Convertir PPT en HTML en .NET](/slides/fr/net/convert-powerpoint-to-html/)
- [Convertir PPT en ODP en .NET](/slides/fr/net/save-presentation/)
- [Convertir PPT en PNG en .NET](/slides/fr/net/convert-powerpoint-to-png/)

## **À propos de la conversion PPT en PPTX**
Convertissez l’ancien format PPT en PPTX avec l’API Aspose.Slides. Si vous devez convertir des milliers de présentations PPT en format PPTX, la meilleure solution est de le faire programmatique­ment. Avec l’API Aspose.Slides, il est possible de le faire en quelques lignes de code seulement. L’API prend en charge une compatibilité totale pour convertir une présentation PPT en PPTX et il est possible de :

- Convertir des structures complexes de masques, de dispositions et de diapositives.
- Convertir une présentation contenant des graphiques.
- Convertir une présentation avec des formes groupées, des auto‑formes (comme les rectangles et les ellipses), des formes à géométrie personnalisée.
- Convertir une présentation possédant des textures et des styles de remplissage d’images pour les auto‑formes.
- Convertir une présentation contenant des espaces réservés, des cadres de texte et des zones de texte.

{{% alert color="primary" %}} 

Découvrez l’application [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Cette application est construite sur **Aspose.Slides API**, vous permettant ainsi de voir un exemple en direct des capacités de conversion de base de PPT en PPTX. Aspose.Slides Conversion est une application web qui permet de déposer un fichier de présentation au format PPT et de le télécharger converti en PPTX.

Découvrez d’autres exemples en direct [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .
{{% /alert %}} 


## **Convertir PPT en PPTX**
Pour convertir un PPT en PPTX, il suffit de transmettre le nom du fichier et le format de sauvegarde à la méthode [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) de la classe [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation). L’exemple de code C# ci‑dessous convertit une présentation de PPT en PPTX en utilisant les options par défaut.
```c#
// Instancier un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Enregistrement de la présentation PPTX au format PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


En savoir plus sur les formats de présentation [**PPT vs PPTX**](/slides/fr/net/ppt-vs-pptx/) et sur la façon dont [**Aspose.Slides supports PPT to PPTX conversion**](/slides/fr/net/convert-ppt-to-pptx/).

## **FAQ**

**Quelle est la différence entre les formats PPT et PPTX ?**

PPT est le format de fichier binaire plus ancien utilisé par Microsoft PowerPoint, tandis que PPTX est le format basé sur XML introduit avec Microsoft Office 2007. Les fichiers PPTX offrent de meilleures performances, une taille de fichier réduite et une récupération de données améliorée.

**Puis‑je convertir PPT en PPTX avec .NET ?**

Oui, en utilisant la bibliothèque Aspose.Slides pour .NET, vous pouvez facilement charger un fichier PPT et l’enregistrer au format PPTX avec seulement quelques lignes de code.

**Aspose.Slides prend‑il en charge la conversion par lots de plusieurs fichiers PPT en PPTX ?**

Oui, vous pouvez utiliser Aspose.Slides dans une boucle pour convertir plusieurs fichiers PPT en PPTX de manière programmatique, ce qui le rend adapté aux scénarios de conversion par lots.

**Le contenu et la mise en forme seront‑ils conservés après la conversion ?**

Aspose.Slides maintient une haute fidélité lors de la conversion des présentations. Les mises en page, les animations, les formes, les graphiques et les autres éléments de conception sont conservés pendant la conversion de PPT en PPTX.

**Puis‑je convertir d’autres formats comme PDF ou HTML à partir de fichiers PPT ?**

Oui, Aspose.Slides prend en charge la conversion des fichiers PPT vers de nombreux formats, notamment PDF, XPS, HTML, ODP et des formats d’image tels que PNG et JPEG.

**Est‑il possible de convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui, Aspose.Slides pour .NET est une API autonome qui ne nécessite ni Microsoft PowerPoint ni aucun logiciel tiers pour effectuer la conversion.

**Existe‑t‑il un outil en ligne disponible pour la conversion PPT en PPTX ?**

Oui, vous pouvez utiliser la version gratuite du [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) directement dans votre navigateur, sans écrire de code.