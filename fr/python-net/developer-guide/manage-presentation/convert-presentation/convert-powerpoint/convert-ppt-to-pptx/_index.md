---
title: Convertir PPT en PPTX avec Python
linktitle: PPT en PPTX
type: docs
weight: 20
url: /fr/python-net/convert-ppt-to-pptx/
keywords:
- convertir PPT
- PPT en PPTX
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Convertissez rapidement des présentations PPT héritées en PPTX moderne avec Python et Aspose.Slides — didacticiel clair, exemples de code gratuits, aucune dépendance à Microsoft Office."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PPT en format PPTX en utilisant Python et une application de conversion en ligne PPT vers PPTX. Le sujet suivant est couvert :

- Convertir PPT en PPTX avec Python

## **Conversion PPT en PPTX avec Python**

Pour le code d'exemple Python de conversion PPT en PPTX, veuillez consulter la section ci-dessous, à savoir [Convertir PPT en PPTX](#convert-ppt-to-pptx). Il charge simplement le fichier PPT et l’enregistre au format PPTX. En spécifiant différents formats d’enregistrement, vous pouvez également enregistrer un fichier PPT dans de nombreux autres formats comme PDF, XPS, ODP, HTML, etc., comme expliqué dans ces articles :

- [Python Convertir PPT en PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python Convertir PPT en XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python Convertir PPT en HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python Convertir PPT en ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python Convertir PPT en Image](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **À propos de la conversion PPT en PPTX**

Convertissez l’ancien format PPT en PPTX avec l’API Aspose.Slides. Si vous devez convertir des milliers de présentations PPT en format PPTX, la meilleure solution est de le faire programmatiquement. Avec l’API Aspose.Slides, il est possible de le faire en quelques lignes de code. L’API prend en charge une compatibilité totale pour convertir une présentation PPT en PPTX, et il est possible de :

- Convertir des structures complexes de maîtres, de dispositions et de diapositives.
- Convertir une présentation contenant des graphiques.
- Convertir une présentation contenant des formes groupées, des formes automatiques (comme des rectangles et des ellipses), et des formes avec une géométrie personnalisée.
- Convertir une présentation présentant des textures et des styles de remplissage d’image pour les formes automatiques.
- Convertir une présentation avec des espaces réservés, des cadres de texte et des détenteurs de texte.

{{% alert color="primary" %}}

Jetez un œil à l’application [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Cette application est construite sur l’**Aspose.Slides API**, vous pouvez donc voir un exemple en direct des capacités de conversion de base de PPT en PPTX. Aspose.Slides Conversion est une application web qui vous permet de déposer un fichier de présentation au format PPT et de le télécharger converti en PPTX.

Trouvez d’autres exemples en direct d’**Aspose.Slides Conversion** [**ici**](https://products.aspose.app/slides/conversion/).

{{% /alert %}}

## **Convertir PPT en PPTX**

Pour convertir un PPT en PPTX, il suffit de passer le nom du fichier et le format d’enregistrement à la méthode [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) de la classe [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). L’exemple de code Python ci‑dessous convertit une présentation de PPT en PPTX en utilisant les options par défaut.

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPT file
pres = slides.Presentation("PPTtoPPTX.ppt")

# Save the presentation in PPTX format
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

En savoir plus sur les formats de présentation [**PPT vs PPTX**](/slides/fr/python-net/ppt-vs-pptx/) et comment [**Aspose.Slides prend en charge la conversion PPT en PPTX**](/slides/fr/python-net/convert-ppt-to-pptx/).

## Foire aux questions

### **Quelle est la différence entre les formats PPT et PPTX ?**

PPT est l’ancien format binaire utilisé par Microsoft PowerPoint, tandis que PPTX est le format XML plus récent introduit avec Microsoft Office 2007. Les fichiers PPTX offrent de meilleures performances, une taille de fichier réduite et une récupération de données améliorée.

### **Puis‑je convertir un PPT en PPTX avec Python ?**

Oui, en utilisant la bibliothèque Aspose.Slides for Python via .NET, vous pouvez facilement charger un fichier PPT et l’enregistrer au format PPTX en quelques lignes de code.

### **L’API Aspose.Slides for Python via .NET est‑elle requise pour la conversion PPT en PPTX ?**

Oui, l’API Aspose.Slides fournit les méthodes et classes nécessaires pour convertir, manipuler et enregistrer des présentations PowerPoint programmatiquement sans dépendre de Microsoft PowerPoint.

### **Aspose.Slides prend‑il en charge la conversion en lot de plusieurs fichiers PPT vers PPTX ?**

Oui, vous pouvez utiliser Aspose.Slides dans une boucle pour convertir plusieurs fichiers PPT en PPTX programmatiquement, ce qui le rend adapté aux scénarios de conversion par lots.

### **Le contenu et la mise en forme sont‑ils préservés après la conversion ?**

Aspose.Slides maintient une haute fidélité lors de la conversion des présentations. Les dispositions de diapositives, les animations, les formes, les graphiques et les autres éléments de conception sont conservés pendant la conversion PPT vers PPTX.

### **Puis‑je convertir d’autres formats comme PDF ou HTML à partir de fichiers PPT ?**

Oui, Aspose.Slides prend en charge la conversion des fichiers PPT vers de multiples formats, dont PDF, XPS, HTML, ODP et des formats d’image comme PNG et JPEG.

### **Est‑il possible de convertir un PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui, Aspose.Slides for Python via .NET est une API autonome qui ne nécessite ni Microsoft PowerPoint ni aucun logiciel tiers pour effectuer la conversion.

### **Existe‑t‑il un outil en ligne pour la conversion PPT en PPTX ?**

Oui, vous pouvez utiliser gratuitement l’application web [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) pour effectuer la conversion directement dans votre navigateur sans écrire de code.