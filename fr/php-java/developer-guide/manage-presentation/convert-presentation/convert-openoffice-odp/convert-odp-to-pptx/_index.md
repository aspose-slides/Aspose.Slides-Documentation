---
title: Convertir ODP en PPTX
type: docs
weight: 10
url: /fr/php-java/convert-odp-to-pptx/
---

## **Convertir ODP en présentation PPTX/PPT**
Aspose.Slides pour PHP via Java propose la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) qui représente un fichier de présentation. La classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) peut désormais également accéder à ODP via le constructeur [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) lorsque l'objet est instancié. L'exemple suivant montre comment convertir une présentation ODP en présentation PPTX.

```php
// Ouvrir le fichier ODP
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # Sauvegarder la présentation ODP au format PPTX
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Exemple en direct**
Vous pouvez visiter [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) web app, qui est construit avec **Aspose.Slides API.** L'application démontre comment la conversion ODP en PPTX peut être implémentée avec l'API Aspose.Slides.