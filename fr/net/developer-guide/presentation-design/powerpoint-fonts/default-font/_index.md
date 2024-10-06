---
title: Police par défaut - API PowerPoint C#
linktitle: Police par défaut
type: docs
weight: 30
url: /net/default-font/
keywords: 
- police
- police par défaut
- rendre présentation
- PowerPoint
- présentation
- C#
- Csharp
- Aspose.Slides pour .NET
description: L'API PowerPoint C# vous permet de définir la police par défaut pour rendre des présentations au format PDF, XPS ou vignettes
---

## **Utilisation des polices par défaut pour rendre la présentation**
Aspose.Slides vous permet de définir la police par défaut pour rendre la présentation au format PDF, XPS ou vignettes. Cet article montre comment définir DefaultRegular
Font et DefaultAsian Font pour les utiliser comme polices par défaut. Veuillez suivre les étapes ci-dessous pour charger des polices à partir de répertoires externes en utilisant l'API Aspose.Slides pour .NET :

1. Créez une instance de LoadOptions.
1. Définissez le DefaultRegularFont sur la police de votre choix. Dans l'exemple suivant, j'ai utilisé Wingdings.
1. Définissez le DefaultAsianFont sur la police de votre choix. J'ai utilisé Wingdings dans l'échantillon suivant.
1. Chargez la présentation en utilisant Presentation et en définissant les options de chargement.
1. Maintenant, générez la vignette de la diapositive, le PDF et le XPS pour vérifier les résultats.

L'implémentation de ce qui précède est donnée ci-dessous.

```c#
// Utilisez les options de chargement pour spécifier les polices régulières et asiatiques par défaut
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```