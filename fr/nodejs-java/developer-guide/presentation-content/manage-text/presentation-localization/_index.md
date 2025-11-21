---
title: Localisation de la présentation
type: docs
weight: 100
url: /fr/nodejs-java/presentation-localization/
---

## **Modifier la langue pour le texte de la présentation et de la forme**

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) de type [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) à la diapositive.
- Ajoutez du texte au TextFrame.
- Définissez l'Id de langue ([Setting Language Id](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-)) du texte.
- Enregistrez la présentation au format PPTX.

L'implémentation des étapes ci‑dessus est démontrée ci‑dessous dans un exemple.
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**L'ID de langue déclenche-t-il une traduction automatique du texte ?**

Non. [setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) dans Aspose.Slides stocke la langue pour la vérification orthographique et grammaticale, mais il ne traduit pas et ne modifie pas le contenu du texte. Il s'agit de métadonnées que PowerPoint comprend pour la révision.

**L'ID de langue affecte-t-il la césure et les sauts de ligne lors du rendu ?**

Dans Aspose.Slides, [setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) est destiné à la révision. La qualité de la césure et le retour à la ligne dépendent principalement de la disponibilité des [polices appropriées](/slides/fr/nodejs-java/powerpoint-fonts/) et des paramètres de mise en page/retour à la ligne du système d'écriture. Pour assurer un rendu correct, rendez les polices requises disponibles, configurez les [règles de substitution de polices](/slides/fr/nodejs-java/font-substitution/), et/ou [intégrez les polices](/slides/fr/nodejs-java/embedded-font/) dans la présentation.

**Puis-je définir différentes langues au sein d'un même paragraphe ?**

Oui. [setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) s'applique au niveau de la portion de texte, de sorte qu'un même paragraphe peut mélanger plusieurs langues avec des paramètres de révision distincts.