---
title: Convertir PPT en PPTX avec Python
linktitle: PPT en PPTX
type: docs
weight: 20
url: /fr/python-net/convert-ppt-to-pptx/
keywords:
- Convertir PPT
- PPT en PPTX
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Convertissez les présentations PPT héritées en PPTX modernes rapidement avec Python et Aspose.Slides — tutoriel clair, exemples de code gratuits, aucune dépendance à Microsoft Office."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PPT en format PPTX en utilisant Python et une application en ligne de conversion PPT vers PPTX. Le sujet suivant est couvert :

- Convertir PPT en PPTX avec Python

## **Python Convertir PPT en PPTX**

Pour le code d'exemple Python pour convertir PPT en PPTX, veuillez consulter la section ci‑dessous, c’est‑à‑dire [Convert PPT to PPTX](#convert-ppt-to-pptx). Il charge simplement le fichier PPT et l’enregistre au format PPTX. En spécifiant différents formats d’enregistrement, vous pouvez également enregistrer un fichier PPT dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme expliqué dans ces articles :

- [Python Convertir PPT en PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python Convertir PPT en XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python Convertir PPT en HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python Convertir PPT en ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python Convertir PPT en Image](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **À propos de la conversion PPT en PPTX**

Convertissez l'ancien format PPT en PPTX avec l'API Aspose.Slides. Si vous devez convertir des milliers de présentations PPT en format PPTX, la meilleure solution est de le faire programmatiquement. Avec l'API Aspose.Slides, il est possible de le faire en quelques lignes de code seulement. L'API garantit une compatibilité totale pour convertir une présentation PPT en PPTX, et il est possible de :

- Convertir des structures complexes de maîtres, de mises en page et de diapositives.
- Convertir une présentation contenant des graphiques.
- Convertir une présentation contenant des formes groupées, des formes automatiques (comme des rectangles et des ellipses) et des formes avec une géométrie personnalisée.
- Convertir une présentation comportant des textures et des styles de remplissage d'image pour les formes automatiques.
- Convertir une présentation contenant des espaces réservés, des cadres de texte et des zones de texte.

{{% alert color="primary" %}}

Jetez un œil à l'application [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Cette application est basée sur l'**Aspose.Slides API**, vous pouvez donc voir un exemple en direct des capacités de conversion basiques de PPT en PPTX. Aspose.Slides Conversion est une application web qui vous permet de déposer un fichier de présentation au format PPT et de le télécharger converti en PPTX.

Trouvez d'autres exemples en direct de [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}}

## **Convertir PPT en PPTX**

Pour convertir un PPT en PPTX, il suffit de fournir le nom du fichier et le format d’enregistrement à la méthode [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) de la classe [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). L'exemple de code Python ci‑dessous convertit une présentation de PPT en PPTX en utilisant les options par défaut.
```python
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier PPT
pres = slides.Presentation("PPTtoPPTX.ppt")

# Enregistrer la présentation au format PPTX
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```


En savoir plus sur les formats de présentation [**PPT vs PPTX**](/slides/fr/python-net/ppt-vs-pptx/) et sur la façon dont [**Aspose.Slides prend en charge la conversion PPT en PPTX**](/slides/fr/python-net/convert-ppt-to-pptx/).

## **FAQ**

**Quelle est la différence entre les formats PPT et PPTX ?**

PPT est le format de fichier binaire plus ancien utilisé par Microsoft PowerPoint, tandis que PPTX est le format plus récent basé sur XML introduit avec Microsoft Office 2007. Les fichiers PPTX offrent de meilleures performances, une taille de fichier réduite et une récupération de données améliorée.

**Puis‑je convertir PPT en PPTX avec Python ?**

Oui, en utilisant la bibliothèque Aspose.Slides for Python via .NET, vous pouvez facilement charger un fichier PPT et l’enregistrer au format PPTX en quelques lignes de code seulement.

**Aspose.Slides prend‑il en charge la conversion par lots de plusieurs fichiers PPT en PPTX ?**

Oui, vous pouvez utiliser Aspose.Slides dans une boucle pour convertir plusieurs fichiers PPT en PPTX de manière programmée, ce qui le rend adapté aux scénarios de conversion par lots.

**Le contenu et la mise en forme seront‑ils préservés après la conversion ?**

Aspose.Slides maintient une haute fidélité lors de la conversion des présentations. Les mises en page des diapositives, les animations, les formes, les graphiques et les autres éléments de conception sont conservés pendant la conversion de PPT en PPTX.

**Puis‑je convertir d’autres formats comme PDF ou HTML à partir de fichiers PPT ?**

Oui, Aspose.Slides prend en charge la conversion des fichiers PPT vers plusieurs formats, notamment PDF, XPS, HTML, ODP et les formats d’image tels que PNG et JPEG.

**Est‑il possible de convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui, Aspose.Slides for Python via .NET est une API autonome qui ne nécessite ni Microsoft PowerPoint ni aucun logiciel tiers pour effectuer la conversion.

**Existe‑t‑il un outil en ligne disponible pour la conversion PPT en PPTX ?**

Oui, vous pouvez utiliser le convertisseur gratuit [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) en ligne pour effectuer la conversion directement dans votre navigateur, sans écrire de code.