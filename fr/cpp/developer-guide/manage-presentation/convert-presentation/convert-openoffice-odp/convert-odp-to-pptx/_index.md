---
title: Convertir ODP en PPTX
type: docs
weight: 10
url: /cpp/convert-odp-to-pptx/
---

Aspose.Slides pour .NET offre la classe Presentation qui représente un fichier de présentation. [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) peut maintenant également accéder à ODP par le biais du constructeur Presentation lors de l'instanciation de l'objet. L'exemple suivant montre comment convertir une présentation ODP en présentation PPTX.

``` cpp
// Le chemin du répertoire des documents.
String dataDir = GetDataPath();

// Ouvrir le fichier ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Sauvegarder la présentation ODP au format PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```



## **Exemple en direct**
Vous pouvez visiter [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) application web, qui est construite avec **Aspose.Slides API.** L'application démontre comment la conversion ODP en PPTX peut être implémentée avec l'API Aspose.Slides.