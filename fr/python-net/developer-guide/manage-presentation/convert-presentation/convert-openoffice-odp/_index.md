---
title: Convertir des présentations OpenDocument en Python
linktitle: Convertir OpenDocument
type: docs
weight: 10
url: /fr/python-net/convert-openoffice-odp/
keywords:
- convertir OpenDocument
- convertir ODP
- ODP en PDF
- ODP en PPT
- ODP en PPTX
- ODP en XPS
- ODP en HTML
- ODP en TIFF
- ODP en SWF
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Convertir les fichiers OpenDocument ODP en PDF, PPT, PPTX, XPS, HTML, TIFF ou SWF en Python avec Aspose.Slides : exemples de code, haute fidélité, conversion par lots et personnalisation."
---

## **Convertir des fichiers ODP**

[**API Aspose.Slides**](https://products.aspose.com/slides/python-net/) vous permet de convertir les présentations OpenOffice ODP en de nombreux formats. L'API utilisée pour convertir des fichiers ODP vers d'autres formats de document est la même que celle employée pour les opérations de conversion PowerPoint (PPT et PPTX).

Ces exemples vous montrent comment convertir des documents ODP vers d'autres formats (il suffit de changer le fichier ODP source) :

- [Convertir ODP en HTML](/slides/fr/python-net/convert-powerpoint-ppt-and-pptx-to-html/)
- [Convertir ODP en PDF](/slides/fr/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Convertir ODP en TIFF](/slides/fr/python-net/convert-powerpoint-to-tiff/)
- [Convertir ODP en SWF Flash](/slides/fr/python-net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [Convertir ODP en XPS](/slides/fr/python-net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [Convertir ODP en PDF avec notes](/slides/fr/python-net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [Convertir ODP en TIFF avec notes](/slides/fr/python-net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

Par exemple, si vous devez convertir une présentation ODP en PDF, vous pouvez procéder ainsi :

```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **FAQ**

**Puis-je convertir ODP en PPTX sans installer LibreOffice ou OpenOffice ?**

Oui. Aspose.Slides est une bibliothèque entièrement autonome qui gère les formats PowerPoint et OpenOffice sans nécessiter d'applications externes.

**Aspose.Slides ouvre-t-il et enregistre-t-il les fichiers ODP/OTP protégés par mot de passe ?**

Oui. Il peut [charger des présentations chiffrées](/slides/fr/python-net/password-protected-presentation/) lorsqu’on fournit le mot de passe et peut également enregistrer des présentations avec des paramètres de chiffrement et de protection.

**Puis-je extraire les fichiers multimédia intégrés (audio/vidéo) d'un ODP avant de le convertir ?**

Oui. Aspose.Slides vous permet d'accéder et d'extraire les [audio](/slides/fr/python-net/audio-frame/) et les [vidéo](/slides/fr/python-net/video-frame/) intégrés aux présentations, ce qui est utile pour le traitement préalable à la conversion ou une réutilisation séparée.

**Puis-je enregistrer l'ODP converti au format Strict Office Open XML ?**

Oui. Lors de l’enregistrement au format PPTX, vous pouvez activer le mode Strict OOXML via les [options d’enregistrement](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) pour répondre à des exigences de conformité plus strictes.