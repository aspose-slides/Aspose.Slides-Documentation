---
title: Automatiser la localisation des présentations en .NET
linktitle: Localisation de présentation
type: docs
weight: 100
url: /fr/net/presentation-localization/
keywords:
- changement de langue
- vérification orthographique
- identifiant de langue
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Automatisez la localisation des diapositives PowerPoint et OpenDocument en .NET avec Aspose.Slides, en utilisant des exemples de code C# pratiques et des conseils pour un déploiement mondial plus rapide."
---

## **Modifier la langue du texte de la présentation et de la forme**
- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter une AutoShape de type Rectangle à la diapositive.
- Ajouter du texte au TextFrame.
- Définir l’identifiant de langue (Language Id) du texte.
- Enregistrer la présentation au format PPTX.

L'implémentation des étapes ci‑dessus est démontrée ci‑dessous dans un exemple.
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

**L’identifiant de langue déclenche‑t‑il une traduction automatique du texte ?**

Non. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) dans Aspose.Slides stocke la langue pour la vérification orthographique et la correction grammaticale, mais il ne traduit pas et ne modifie pas le contenu du texte. C’est une métadonnée que PowerPoint comprend pour la révision.

**L’identifiant de langue affecte‑t‑il la césure et les retours à la ligne lors du rendu ?**

Dans Aspose.Slides, [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) sert à la révision. La qualité de la césure et le passage à la ligne dépendent principalement de la disponibilité des [polices appropriées](/slides/fr/net/powerpoint-fonts/) et des paramètres de mise en page/coupure de ligne pour le système d’écriture. Pour garantir un rendu correct, assurez la disponibilité des polices requises, configurez les [règles de substitution de police](/slides/fr/net/font-substitution/) et/ou [intégrez les polices](/slides/fr/net/embedded-font/) dans la présentation.

**Puis‑je définir différentes langues au sein d’un même paragraphe ?**

Oui. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) s’applique au niveau de la portion de texte, de sorte qu’un même paragraphe peut mélanger plusieurs langues avec des paramètres de révision distincts.