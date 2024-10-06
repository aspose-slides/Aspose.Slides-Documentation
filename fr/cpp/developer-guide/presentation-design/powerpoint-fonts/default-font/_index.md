---
title: Police par défaut
type: docs
weight: 30
url: /cpp/default-font/
keywords: 
- police
- police par défaut
- présentation de rendu
- PowerPoint
- présentation
- C++
- Aspose.Slides pour C++
description: L'API PowerPoint C++ vous permet de définir la police par défaut pour le rendu des présentations au format PDF, XPS ou vignettes
---

## **Définir la police par défaut**
En utilisant Aspose.Slides pour C++, vous pouvez définir la police par défaut dans les présentations PowerPoint. Une nouvelle méthode [set_DefaultRegularFont()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_save_options/#a9df129ea6e65c8196e08173799a10492) a été ajoutée à la classe [**SaveOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.save_options/). Elle permet de définir la police par défaut utilisée au lieu de toutes les polices manquantes lors de la sauvegarde des présentations dans différents formats sans recharge des présentations.

Le code ci-dessous montre comment sauvegarder une présentation en [HTML](https://docs.fileformat.com/web/html/) et [PDF](https://docs.fileformat.com/pdf/) avec une police régulière par défaut différente.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetDefaultFont-SetDefaultFont.cpp" >}}


## **Utiliser des polices par défaut pour le rendu de la présentation**
Aspose.Slides vous permet de définir la police par défaut pour le rendu de la présentation au format PDF, XPS ou vignettes. Cet article montre comment définir la police régulière par défaut et la police asiatique par défaut à utiliser comme polices par défaut. Veuillez suivre les étapes ci-dessous pour charger des polices à partir de répertoires externes en utilisant l'API Aspose.Slides pour C++ :

1. Créez une instance de LoadOptions.
1. Définissez la DefaultRegularFont sur la police souhaitée. Dans l'exemple suivant, j'ai utilisé Wingdings.
1. Définissez la DefaultAsianFont sur la police souhaitée. J'ai utilisé Wingdings dans l'exemple suivant.
1. Chargez la présentation en utilisant Presentation et en définissant les options de chargement.
1. Maintenant, générez la vignette de la diapositive, le PDF et le XPS pour vérifier les résultats.

L'implémentation de ce qui précède est donnée ci-dessous.

```cpp
// Utilisez les options de chargement pour spécifier les polices régulières et asiatiques par défaut
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```