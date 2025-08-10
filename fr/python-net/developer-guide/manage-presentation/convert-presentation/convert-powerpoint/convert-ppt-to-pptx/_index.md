---
title: Convertir PPT en PPTX en Python
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
description: "Convertissez rapidement des présentations PPT anciennes en PPTX modernes en Python avec Aspose.Slides — tutoriel clair, exemples de code gratuits, sans dépendance à Microsoft Office."
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format PPT en format PPTX en utilisant Python et avec une application de conversion en ligne de PPT à PPTX. Le sujet suivant est couvert.

- Convertir PPT en PPTX en Python

## **Python Convertir PPT en PPTX**

Pour obtenir le code d'exemple en Python pour convertir PPT en PPTX, veuillez consulter la section ci-dessous c'est-à-dire [Convertir PPT en PPTX](#convert-ppt-to-pptx). Il charge simplement le fichier PPT et le sauvegarde au format PPTX. En spécifiant différents formats de sauvegarde, vous pouvez également enregistrer le fichier PPT dans de nombreux autres formats comme PDF, XPS, ODP, HTML, etc. comme discuté dans ces articles.

- [Python Convertir PPT en PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python Convertir PPT en XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python Convertir PPT en HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python Convertir PPT en ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python Convertir PPT en Image](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **À propos de la conversion PPT en PPTX**
Convertir l'ancien format PPT en PPTX avec l'API Aspose.Slides. Si vous devez convertir des milliers de présentations PPT en format PPTX, la meilleure solution consiste à le faire par programmation. Avec l'API Aspose.Slides, cela est possible en quelques lignes de code. L'API supporte une compatibilité complète pour convertir une présentation PPT en PPTX et il est possible de :

- Convertir des structures compliquées de maîtres, de mises en page et de diapositives.
- Convertir une présentation avec des graphiques.
- Convertir une présentation avec des formes groupées, des formes automatiques (comme des rectangles et des ellipses), des formes avec une géométrie personnalisée.
- Convertir une présentation ayant des styles de remplissage de textures et d'images pour des formes automatiques.
- Convertir une présentation avec des espaces réservés, des cadres de texte et des détenteurs de texte.

{{% alert color="primary" %}} 

Jetez un œil à [**Aspose.Slides Conversion PPT en PPTX**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Cette application est construite sur l'**API Aspose.Slides**, vous pouvez donc voir un exemple vivant des capacités de conversion basiques de PPT en PPTX. La conversion Aspose.Slides est une application web, qui permet de déposer un fichier de présentation au format PPT et de le télécharger converti en PPTX.

Trouvez d'autres exemples vivants de [**conversion Aspose.Slides**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 


## **Convertir PPT en PPTX**
Pour convertir un PPT en PPTX, il suffit de passer le nom du fichier et le format de sauvegarde au [**méthode Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) de la classe [**Présentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Le code d'exemple Python ci-dessous convertit une présentation de PPT en PPTX en utilisant les options par défaut.

```py
import aspose.slides as slides

# Instancier un objet Présentation qui représente un fichier PPTX
pres = slides.Presentation("PPTtoPPTX.ppt")

# Sauvegarder la présentation PPTX au format PPTX
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```



Lisez-en plus sur les formats de présentation [**PPT vs PPTX**](/slides/fr/python-net/ppt-vs-pptx/) et comment [**Aspose.Slides supporte la conversion de PPT en PPTX**](/slides/fr/python-net/convert-ppt-to-pptx/).