---
title: Convertir PPTX en PPT en Python
linktitle: PPTX vers PPT
linktitle: Convertir PPTX en PPT
type: docs
weight: 21
url: /fr/python-net/convert-pptx-to-ppt/
keywords:
- PPTX vers PPT
- convertir PPTX en PPT
- convertir PowerPoint
- convertir présentation
- Python
- Aspose.Slides
description: "Convertissez facilement des fichiers PPTX en PPT avec Aspose.Slides for Python via .NET — assurez une compatibilité parfaite avec les formats PowerPoint tout en préservant la mise en page et la qualité de votre présentation."
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format PPTX en format PPT en utilisant Python. Le sujet suivant est abordé.

- Convertir PPTX en PPT en Python

## **Python Convertir PPTX en PPT**

Pour un exemple de code Python permettant de convertir PPTX en PPT, veuillez consulter la section ci-dessous, c'est-à-dire [Convertir PPTX en PPT](#convert-pptx-to-ppt). Cela charge simplement le fichier PPTX et l'enregistre au format PPT. En spécifiant différents formats de sauvegarde, vous pouvez également enregistrer le fichier PPTX dans de nombreux autres formats comme PDF, XPS, ODP, HTML, etc., comme discuté dans ces articles.

- [Python Convertir PPTX en PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python Convertir PPTX en XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python Convertir PPTX en HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python Convertir PPTX en ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python Convertir PPTX en Image](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **Convertir PPTX en PPT**
Pour convertir un PPTX en PPT, il suffit de passer le nom du fichier et le format de sauvegarde à la méthode [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) de la classe [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). L'exemple de code Python ci-dessous convertit une présentation de PPTX en PPT en utilisant les options par défaut.

```py
import aspose.slides as slides

# Instancier un objet Presentation représentant un fichier PPTX
pres = slides.Presentation("presentation.pptx")

# Enregistrer la présentation PPTX au format PPT
pres.save("presentation.ppt", slides.export.SaveFormat.PPT)
```