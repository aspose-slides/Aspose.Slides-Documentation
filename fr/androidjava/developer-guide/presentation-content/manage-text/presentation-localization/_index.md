---
title: Localisation de la Présentation
type: docs
weight: 100
url: /fr/androidjava/presentation-localization/
---

## **Changer la Langue pour le Texte de la Présentation et de la Forme**
- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenir la référence d'une diapositive en utilisant son Index.
- Ajouter un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) de type [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) à la diapositive.
- Ajouter du texte au TextFrame.
- [Définir l'Identifiant de Langue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) pour le texte.
- Écrire la présentation en tant que fichier PPTX.

L'implémentation des étapes ci-dessus est démontrée ci-dessous dans un exemple.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Texte pour appliquer la langue de vérification orthographique");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```