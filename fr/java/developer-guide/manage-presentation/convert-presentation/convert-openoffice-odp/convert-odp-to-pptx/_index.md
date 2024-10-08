---
title: Convertir ODP en PPTX
type: docs
weight: 10
url: /fr/java/convert-odp-to-pptx/
---

## **Convertir ODP en Présentation PPTX/PPT**
Aspose.Slides pour Java offre la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) qui représente un fichier de présentation. La classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) peut maintenant également accéder à ODP via le constructeur [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#Presentation-java.lang.String-) lorsque l'objet est instancié. L'exemple suivant montre comment convertir une présentation ODP en présentation PPTX.

```java
// Ouvrir le fichier ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Sauvegarder la présentation ODP au format PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Exemple en Direct**
Vous pouvez visiter l'application web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/), qui est construite avec l’**API Aspose.Slides.** L'application démontre comment la conversion ODP en PPTX peut être implémentée avec l’API Aspose.Slides.