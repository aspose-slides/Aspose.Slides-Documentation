---
title: Convertir ODP en PPTX
type: docs
weight: 10
url: /fr/androidjava/convert-odp-to-pptx/
---

## **Convertir ODP en présentation PPTX/PPT**
Aspose.Slides pour Android via Java offre la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) qui représente un fichier de présentation. La classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) peut maintenant également accéder à ODP via le constructeur [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) lorsque l'objet est instancié. L'exemple suivant montre comment convertir une présentation ODP en présentation PPTX.

```java
// Ouvrir le fichier ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Sauvegarde de la présentation ODP au format PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Exemple en direct**
Vous pouvez visiter [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) web application, qui est construite avec **Aspose.Slides API.** L'application démontre comment la conversion ODP en PPTX peut être mise en œuvre avec l'API Aspose.Slides.