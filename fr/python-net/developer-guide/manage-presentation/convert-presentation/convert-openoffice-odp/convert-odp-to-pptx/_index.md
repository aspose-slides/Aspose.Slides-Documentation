---
title: Convertir ODP en PPTX
type: docs
weight: 10
url: /fr/python-net/convert-odp-to-pptx/
keywords: "Convertir OpenOffice Presentation, ODP, ODP en PPTX, Python"
description: "Convertir OpenOffice ODP en présentation PowerPoint PPTX en Python"
---

Aspose.Slides pour Python via .NET offre une classe Presentation qui représente un fichier de présentation. La classe [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) peut désormais également accéder à ODP via le constructeur Presentation lors de l'instanciation de l'objet. L'exemple suivant montre comment convertir une présentation ODP en présentation PPTX.

```py
# Importer le module Aspose.Slides pour Python via .NET
import aspose.slides as slides

# Ouvrir le fichier ODP
pres = slides.Presentation("AccessOpenDoc.odp")

# Sauvegarder la présentation ODP au format PPTX
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Exemple en direct**
Vous pouvez visiter [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) application web, qui est construite avec **Aspose.Slides API.** L'application démontre comment la conversion ODP en PPTX peut être implémentée avec l'API Aspose.Slides.