---
title: Localisation de la présentation
type: docs
weight: 100
url: /fr/net/presentation-localization/
keywords: "Modifier la langue, Vérification orthographique, Vérification orthographique, Vérificateur d'orthographe, Présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Changer ou vérifier la langue dans une présentation PowerPoint. Vérifier l'orthographe du texte en C# ou .NET"
---

## **Modifier la langue du texte de la présentation et de la forme**
- Créer une instance de la classe [Présentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter une AutoShape de type Rectangle à la diapositive.
- Ajouter du texte au TextFrame.
- Définir l’Id de langue du texte.
- Enregistrer la présentation au format PPTX.

L’implémentation des étapes ci‑dessus est illustrée ci‑après dans un exemple.
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

**Le language_id déclenche-t-il une traduction automatique du texte ?**

Non. [language_id](https://reference.aspose.com/slides/net/aspose.slides/portionformat/languageid/) dans Aspose.Slides stocke la langue pour la vérification orthographique et la correction grammaticale, mais il ne traduit pas et ne modifie pas le contenu du texte. Il s’agit de métadonnées que PowerPoint comprend pour la révision.

**Le language_id affecte-t-il la césure et les sauts de ligne lors du rendu ?**

Dans Aspose.Slides, [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) sert à la révision. La qualité de la césure et le passage à la ligne dépendent principalement de la disponibilité de [polices appropriées](/slides/fr/net/powerpoint-fonts/) et des paramètres de mise en page/coupure de ligne pour le système d’écriture. Pour garantir un rendu correct, assurez‑vous que les polices requises sont disponibles, configurez les [règles de substitution de polices](/slides/fr/net/font-substitution/), et/ou [intégrez les polices](/slides/fr/net/embedded-font/) dans la présentation.

**Puis-je définir différentes langues au sein d’un même paragraphe ?**

Oui. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) est appliqué au niveau de chaque portion de texte, de sorte qu’un même paragraphe peut mêler plusieurs langues avec des paramètres de révision distincts.