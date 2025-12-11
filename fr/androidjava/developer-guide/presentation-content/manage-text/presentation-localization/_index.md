---
title: Automatiser la localisation des présentations sur Android
linktitle: Localisation des présentations
type: docs
weight: 100
url: /fr/androidjava/presentation-localization/
keywords:
- changer la langue
- vérification orthographique
- identifiant de langue
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Automatisez la localisation des diapositives PowerPoint et OpenDocument en Java avec Aspose.Slides pour Android, en utilisant des exemples de code pratiques et des conseils pour un déploiement mondial plus rapide."
---

## **Modifier la langue d’une présentation et du texte de forme**
- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) de type [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) à la diapositive.
- Ajouter du texte au TextFrame.
- [Définir l’ID de langue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) du texte.
- Enregistrer la présentation au format PPTX.

L’implémentation des étapes ci‑dessus est illustrée ci‑dessous dans un exemple.
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

**L’ID de langue déclenche‑t‑il la traduction automatique du texte ?**

Non. L’[ID de langue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) dans Aspose.Slides stocke la langue pour le correcteur orthographique et la vérification grammaticale, mais il ne traduit pas et ne modifie pas le contenu du texte. C’est une métadonnée que PowerPoint comprend pour la révision.

**L’ID de langue affecte‑t‑il la césure et les sauts de ligne lors du rendu ?**

Dans Aspose.Slides, l’[ID de langue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) sert à la révision. La qualité de la césure et du retour à la ligne dépend principalement de la disponibilité des [polices appropriées](/slides/fr/androidjava/powerpoint-fonts/) et des paramètres de mise en page/retour à la ligne pour le système d’écriture. Pour garantir un rendu correct, assurez la disponibilité des polices requises, configurez les [règles de substitution de polices](/slides/fr/androidjava/font-substitution/) et/ou intégrez les [polices incorporées](/slides/fr/androidjava/embedded-font/) dans la présentation.

**Puis‑je définir différentes langues au sein d’un même paragraphe ?**

Oui. L’[ID de langue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) s’applique au niveau de la portion de texte, ainsi un même paragraphe peut contenir plusieurs langues avec des paramètres de révision distincts.