---
title: Automatiser la localisation des présentations en Java
linktitle: Localisation de la présentation
type: docs
weight: 100
url: /fr/java/presentation-localization/
keywords:
- changer la langue
- vérification orthographique
- ID de langue
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Automatisez la localisation des diapositives PowerPoint et OpenDocument en Java avec Aspose.Slides, en utilisant des exemples de code pratiques et des conseils pour un déploiement mondial plus rapide."
---

## **Modifier la langue d'une présentation et du texte de forme**
- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtenir la référence d'une diapositive en utilisant son index.
- Ajouter un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) de type [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) à la diapositive.
- Ajouter du texte au TextFrame.
- Appliquer [Setting Language Id](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) au texte.
- Enregistrer la présentation au format PPTX.

L'implémentation des étapes ci‑dessus est démontrée ci‑après dans un exemple.
```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**L'ID de langue déclenche-t-il la traduction automatique du texte ?**

Non. [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) dans Aspose.Slides stocke la langue pour la vérification orthographique et la correction grammaticale, mais il ne traduit pas et ne modifie pas le contenu du texte. C'est une métadonnée que PowerPoint comprend pour la révision.

**L'ID de langue affecte-t-il la césure et les sauts de ligne lors du rendu ?**

Dans Aspose.Slides, [language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) sert à la révision. La qualité de la césure et du retour à la ligne dépend principalement de la disponibilité de [polices appropriées](/slides/fr/java/powerpoint-fonts/) et des paramètres de mise en page/retour à la ligne du système d'écriture. Pour garantir un rendu correct, assurez la disponibilité des polices requises, configurez les [règles de substitution de polices](/slides/fr/java/font-substitution/) et/ou [intégrez les polices](/slides/fr/java/embedded-font/) dans la présentation.

**Puis-je définir différentes langues dans un même paragraphe ?**

Oui. [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) est appliqué au niveau de la portion de texte, ainsi un même paragraphe peut mélanger plusieurs langues avec des paramètres de révision distincts.