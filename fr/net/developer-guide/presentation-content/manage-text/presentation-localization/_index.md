---
title: Localisation de la présentation
type: docs
weight: 100
url: /fr/net/presentation-localization/
keywords: "Modifier la langue, Vérification orthographique, Vérification orthographique, Correcteur orthographique, Présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Modifier ou vérifier la langue dans une présentation PowerPoint. Vérifier l'orthographe du texte en C# ou .NET"
---

## **Modifier la langue pour la présentation et le texte de la forme**
- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenez la référence d’une diapositive en utilisant son Index.
- Ajoutez une AutoShape de type Rectangle à la diapositive.
- Ajoutez du texte au TextFrame.
- Définissez LanguageId sur le texte.
- Enregistrez la présentation au format PPTX.

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

**Le LanguageId déclenche-t-il une traduction automatique du texte ?**

Non. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) dans Aspose.Slides stocke la langue pour la vérification orthographique et la correction grammaticale, mais il ne traduit pas et ne modifie pas le contenu du texte. Il s'agit de métadonnées que PowerPoint comprend pour la révision.

**Le LanguageId affecte-t-il l'hyphenation et les sauts de ligne lors du rendu ?**

Dans Aspose.Slides, [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) sert à la révision. La qualité de l'hyphenation et le passage à la ligne dépendent principalement de la disponibilité des [polices appropriées](/slides/fr/net/powerpoint-fonts/) et des paramètres de mise en page/passage à la ligne du système d'écriture. Pour garantir un rendu correct, rendez les polices nécessaires disponibles, configurez les [règles de substitution de polices](/slides/fr/net/font-substitution/), et/ou [intégrez les polices](/slides/fr/net/embedded-font/) dans la présentation.

**Puis-je définir différentes langues au sein d'un même paragraphe ?**

Oui. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) s'applique au niveau de la portion de texte, de sorte qu'un même paragraphe peut mélanger plusieurs langues avec des paramètres de révision distincts.
