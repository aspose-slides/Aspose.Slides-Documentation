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
description: "Convertissez rapidement les présentations PPT héritées en PPTX moderne avec .NET et Aspose.Slides — tutoriel clair, exemples de code C# gratuits, aucune dépendance à Microsoft Office."
---
## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format PPT en format PPTX à l’aide de C# et d’une application de conversion en ligne PPT vers PPTX. Les sujets suivants sont abordés.

- [Convertir PPT en PPTX en C#](#convert-ppt-to-pptx)

## **Convertir PPT en PPTX avec .NET**

Pour le code d’exemple C# permettant de convertir PPT en PPTX, consultez la section ci‑dessous, c’est‑à‑dire [Convertir PPT en PPTX](#convert-ppt-to-pptx). Il suffit de charger le fichier PPT et de l’enregistrer au format PPTX. En spécifiant d’autres formats de sauvegarde, vous pouvez également enregistrer le fichier PPT dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme indiqué dans ces articles.

- [Convertir PPT en PDF avec .NET](/slides/fr/net/convert-powerpoint-to-pdf/)
- [Convertir PPT en XPS avec .NET](/slides/fr/net/convert-powerpoint-to-xps/)
- [Convertir PPT en HTML avec .NET](/slides/fr/net/convert-powerpoint-to-html/)
- [Convertir PPT en ODP avec .NET](/slides/fr/net/save-presentation/)
- [Convertir PPT en PNG avec .NET](/slides/fr/net/convert-powerpoint-to-png/)

## **À propos de la conversion PPT vers PPTX**
Convertissez l’ancien format PPT en PPTX avec l’API Aspose.Slides. Si vous devez convertir des milliers de présentations PPT en format PPTX, la meilleure solution consiste à le faire programmatiquement. Avec l’API Aspose.Slides, cela est possible en seulement quelques lignes de code. L’API assure une compatibilité totale pour convertir une présentation PPT en PPTX et permet :

- De convertir des structures complexes de maîtres, de mises en page et de diapositives.
- De convertir des présentations contenant des graphiques.
- De convertir des présentations avec des formes groupées, des auto‑formes (comme des rectangles et des ellipses), des formes à géométrie personnalisée.
- De convertir des présentations contenant des textures et des styles de remplissage d’images pour les auto‑formes.
- De convertir des présentations avec des espaces réservés, des zones de texte et des détenteurs de texte.

{{% alert color="info" %}} 
Jetez un œil à l’application [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx)

Cette application est construite sur l’**API Aspose.Slides**, vous permettant ainsi de voir un exemple en direct des capacités de conversion basique de PPT en PPTX. Aspose.Slides Conversion est une application Web qui permet de déposer un fichier de présentation au format PPT et de le télécharger converti en PPTX.

Découvrez d’autres exemples en ligne de [**Aspose.Slides Conversion**](https://products.aspose.app/slides/fr/conversion/).
{{% /alert %}} 

## **Convertir PPT en PPTX**
Pour convertir un PPT en PPTX, transmettez simplement le nom du fichier et le format de sauvegarde à la méthode [**Save**](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/methods/save/index) de la classe [**Presentation**](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation). L’exemple de code C# ci‑dessous convertit une présentation de PPT en PPTX en utilisant les options par défaut.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancier un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Enregistrement de la présentation PPTX au format PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

En savoir plus sur les formats de présentation [**PPT vs PPTX**](/slides/fr/net/ppt-vs-pptx/) et sur la façon dont [**Aspose.Slides prend en charge la conversion PPT en PPTX**](/slides/fr/net/convert-ppt-to-pptx/).

## **FAQ**

### Quelle est la différence entre les formats PPT et PPTX ?

PPT est l’ancien format binaire utilisé par Microsoft PowerPoint, tandis que PPTX est le nouveau format basé sur XML introduit avec Microsoft Office 2007. Les fichiers PPTX offrent de meilleures performances, une taille de fichier réduite et une récupération de données améliorée.

### Puis‑je convertir un PPT en PPTX avec .NET ?

Oui, en utilisant la bibliothèque Aspose.Slides pour .NET, vous pouvez facilement charger un fichier PPT et l’enregistrer au format PPTX en quelques lignes de code seulement.

### Aspose.Slides prend‑il en charge la conversion par lot de plusieurs fichiers PPT en PPTX ?

Oui, vous pouvez utiliser Aspose.Slides dans une boucle pour convertir plusieurs fichiers PPT en PPTX de manière programmatique, ce qui le rend adapté aux scénarios de conversion par lot.

### Le contenu et le formatage seront‑ils conservés après la conversion ?

Aspose.Slides maintient une haute fidélité lors de la conversion des présentations. Les mises en page des diapositives, les animations, les formes, les graphiques et les autres éléments de conception sont préservés pendant la conversion PPT en PPTX.

### Puis‑je convertir d’autres formats comme PDF ou HTML à partir de fichiers PPT ?

Oui, Aspose.Slides prend en charge la conversion des fichiers PPT vers plusieurs formats, notamment PDF, XPS, HTML, ODP et les formats d’image tels que PNG et JPEG.

### Est‑il possible de convertir PPT en PPTX sans Microsoft PowerPoint installé ?

Oui, Aspose.Slides pour .NET est une API autonome qui ne nécessite ni Microsoft PowerPoint ni aucun logiciel tiers pour effectuer la conversion.

### Existe‑t‑il un outil en ligne pour la conversion PPT en PPTX ?

Oui, vous pouvez utiliser le convertisseur gratuit [**Aspose.Slides PPT to PPTX Converter**](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx) dans votre navigateur sans écrire de code.