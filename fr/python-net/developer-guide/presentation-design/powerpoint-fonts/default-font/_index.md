---
title: Police par défaut
type: docs
weight: 30
url: /python-net/default-font/
keywords: "Polices, polices par défaut, présentation PowerPoint de rendu Python, Aspose.Slides pour Python via .NET"
description: "Polices par défaut PowerPoint en Python"
---

## **Utiliser des Polices par Défaut pour le Rendu de Présentation**
Aspose.Slides vous permet de définir la police par défaut pour le rendu de la présentation en PDF, XPS ou vignettes. Cet article montre comment définir DefaultRegular Font et DefaultAsian Font à utiliser comme polices par défaut. Veuillez suivre les étapes ci-dessous pour charger des polices à partir de répertoires externes en utilisant Aspose.Slides pour Python via l'API .NET :

1. Créez une instance de LoadOptions.
1. Définissez le DefaultRegularFont sur la police souhaitée. Dans l'exemple suivant, j'ai utilisé Wingdings.
1. Définissez le DefaultAsianFont sur la police souhaitée. J'ai utilisé Wingdings dans l'exemple suivant.
1. Chargez la présentation en utilisant Presentation et en définissant les options de chargement.
1. Maintenant, générez la vignette de la diapositive, le PDF et le XPS pour vérifier les résultats.

L'implémentation ci-dessus est donnée ci-dessous.

```py
import aspose.slides as slides

# Utiliser les options de chargement pour définir les polices régulières et asiatiques par défaut
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Charger la présentation
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Générer la vignette de la diapositive
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Générer le PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Générer le XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```