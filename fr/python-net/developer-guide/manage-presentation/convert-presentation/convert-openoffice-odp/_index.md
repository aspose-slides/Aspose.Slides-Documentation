---
title: Convertir les présentations OpenDocument en Python
linktitle: Convertir OpenDocument
type: docs
weight: 10
url: /fr/python-net/convert-openoffice-odp/
keywords:
- convertir OpenDocument
- convertir ODP
- ODP vers PDF
- ODP vers PPT
- ODP vers PPTX
- ODP vers XPS
- ODP vers HTML
- ODP vers TIFF
- ODP vers SWF
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Convertir les fichiers OpenDocument ODP en PDF, PPT, PPTX, XPS, HTML, TIFF ou SWF en Python avec Aspose.Slides : exemples de code, haute fidélité, conversion par lots et personnalisation."
---

## **Convertir les fichiers ODP**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) vous permet de convertir des présentations OpenDocument (ODP) en de nombreux formats (HTML, PDF, TIFF, SWF, XPS, etc.). L'API utilisée pour convertir les fichiers ODP vers d'autres formats de documents est la même que celle utilisée pour les opérations de conversion PowerPoint (PPT et PPTX).

Par exemple, si vous devez convertir une présentation ODP en PDF, vous pouvez le faire comme suit :
```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```


## **FAQ**

**Puis-je convertir ODP en PPTX sans installer LibreOffice ou OpenOffice ?**

Oui. Aspose.Slides est une bibliothèque entièrement autonome qui gère les formats PowerPoint et OpenOffice sans nécessiter d'applications externes.

**Aspose.Slides ouvre-t-il et enregistre-t-il les fichiers ODP/OTP protégés par mot de passe ?**

Oui. Il peut [charger des présentations chiffrées](/slides/fr/python-net/password-protected-presentation/) lorsque vous fournissez le mot de passe et peut également enregistrer des présentations avec des paramètres de chiffrement et de protection.

**Puis-je extraire les fichiers multimédias intégrés (audio/vidéo) d'un ODP avant de le convertir ?**

Oui. Aspose.Slides vous permet d'accéder et d'extraire les [audio](/slides/fr/python-net/audio-frame/) et [vidéo](/slides/fr/python-net/video-frame/) intégrés des présentations, ce qui est utile pour le traitement avant conversion ou la réutilisation séparée.

**Puis-je enregistrer l'ODP converti en Strict Office Open XML ?**

Oui. Lors de l'enregistrement au format PPTX, vous pouvez activer le Strict OOXML via les [options d'enregistrement](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) pour répondre à des exigences de conformité plus strictes.