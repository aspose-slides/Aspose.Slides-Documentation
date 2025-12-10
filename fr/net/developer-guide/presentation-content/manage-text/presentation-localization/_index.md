---
title: Automatiser la localisation des présentations en .NET
linktitle: Localisation de présentation
type: docs
weight: 100
url: /fr/net/presentation-localization/
keywords:
- changer la langue
- vérification orthographique
- ID de langue
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Automatisez la localisation des diapositives PowerPoint et OpenDocument en .NET avec Aspose.Slides, en utilisant des exemples de code C# pratiques et des conseils pour un déploiement mondial plus rapide."
---

## **Modifier la langue d’une présentation et du texte d’une forme**
- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter une AutoShape de type Rectangle à la diapositive.
- Ajouter du texte au TextFrame.
- Définir l’ID de langue pour le texte.
- Enregistrer la présentation au format PPTX.

L’implémentation des étapes ci‑dessus est illustrée ci‑bas dans un exemple.
```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**L’ID de langue déclenche-t‑il une traduction automatique du texte ?**

Non. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) dans Aspose.Slides stocke la langue pour la vérification orthographique et la correction grammaticale, mais il ne traduit pas et ne modifie pas le contenu du texte. C’est une métadonnée que PowerPoint comprend pour la vérification.

**L’ID de langue affecte-t‑il la césure et les sauts de ligne lors du rendu ?**

Dans Aspose.Slides, [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) sert à la vérification. La qualité de la césure et le retour à la ligne dépendent principalement de la disponibilité de [polices appropriées](/slides/fr/net/powerpoint-fonts/) et des paramètres de mise en page/retrait pour le système d’écriture. Pour assurer un rendu correct, rendez les polices requises disponibles, configurez les [règles de substitution de polices](/slides/fr/net/font-substitution/) et/ou [intégrez les polices](/slides/fr/net/embedded-font/) dans la présentation.

**Puis‑je définir différentes langues au sein d’un même paragraphe ?**

Oui. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) est appliqué au niveau de la portion de texte, de sorte qu’un seul paragraphe peut mélanger plusieurs langues avec des paramètres de vérification distincts.