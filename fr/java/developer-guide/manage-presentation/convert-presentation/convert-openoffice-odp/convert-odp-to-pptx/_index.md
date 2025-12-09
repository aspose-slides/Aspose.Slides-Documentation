---
title: Convertir ODP en PPTX en Java
linktitle: ODP en PPTX
type: docs
weight: 10
url: /fr/java/convert-odp-to-pptx/
keywords:
- convertir OpenDocument
- convertir présentation
- convertir diapositive
- convertir ODP
- OpenDocument en PPTX
- ODP en PPTX
- enregistrer ODP en PPTX
- exporter ODP vers PPTX
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Convertissez ODP en PPTX avec Aspose.Slides pour Java. Exemples de code Java clairs, astuces de traitement par lots et résultats de haute qualité — aucun PowerPoint requis."
---

## **Convertir ODP en présentation PPTX/PPT**
Aspose.Slides for Java propose la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) qui représente un fichier de présentation. La classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) peut désormais également accéder aux fichiers ODP via le constructeur [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#Presentation-java.lang.String-) lorsque l'objet est instancié. L'exemple suivant montre comment convertir une présentation ODP en présentation PPTX.
```java
// Ouvrir le fichier ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Enregistrement de la présentation ODP au format PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Exemple en direct**
Vous pouvez visiter l'application web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) qui est construite avec **Aspose.Slides API**. L'application montre comment la conversion d'ODP en PPTX peut être implémentée avec Aspose.Slides API.