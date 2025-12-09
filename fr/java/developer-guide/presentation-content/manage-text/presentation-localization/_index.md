---
title: Automatiser la localisation des présentations en Java
linktitle: Localisation de présentation
type: docs
weight: 100
url: /fr/java/presentation-localization/
keywords:
- modifier la langue
- vérification orthographique
- identifiant de langue
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Automatisez la localisation des diapositives PowerPoint et OpenDocument en Java avec Aspose.Slides, en utilisant des exemples de code pratiques et des conseils pour un déploiement mondial plus rapide."
---

## **Modifier la langue pour la présentation et le texte de la forme**
- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) de type [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) à la diapositive.
- Ajouter du texte au TextFrame.
- [Setting Language Id](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) au texte.
- Enregistrer la présentation sous forme de fichier PPTX.

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

**L’identifiant de langue déclenche‑t‑il une traduction automatique du texte ?**

Non. L’[Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) dans Aspose.Slides stocke la langue pour la vérification orthographique et grammaticale, mais il ne traduit pas le texte ni ne le modifie. Il s’agit de métadonnées que PowerPoint comprend pour la correction.

**L’identifiant de langue affecte‑t‑il la césure et les sauts de ligne lors du rendu ?**

Dans Aspose.Slides, l’[language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) sert à la correction. La qualité de la césure et le retour à la ligne dépendent principalement de la disponibilité des [polices appropriées](/slides/fr/java/powerpoint-fonts/) et des paramètres de mise en page/retour à la ligne pour le système d’écriture. Pour garantir un rendu correct, rendez les polices nécessaires disponibles, configurez les [règles de substitution de polices](/slides/fr/java/font-substitution/) et/ou [intégrez des polices](/slides/fr/java/embedded-font/) dans la présentation.

**Puis‑je définir différentes langues au sein d’un même paragraphe ?**

Oui. L’[Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) est appliqué au niveau de la portion de texte, de sorte qu’un même paragraphe peut mélanger plusieurs langues avec des paramètres de correction distincts.