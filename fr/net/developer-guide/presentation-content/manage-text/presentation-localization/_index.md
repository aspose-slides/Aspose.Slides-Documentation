---
title: Localisation de la Présentation
type: docs
weight: 100
url: /net/presentation-localization/
keywords: "Changer de langue, Vérification orthographique, Vérification de l'orthographe, Correcteur orthographique, Présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Changer ou vérifier la langue dans une présentation PowerPoint. Vérifier l'orthographe du texte en C# ou .NET"
---
## **Changer la Langue pour le Texte de la Présentation et de la Forme**
- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenir la référence d'une diapositive en utilisant son Index.
- Ajouter une forme auto de type Rectangle à la diapositive.
- Ajouter du texte au TextFrame.
- Définir l'ID de langue pour le texte.
- Écrire la présentation en tant que fichier PPTX.

L'implémentation des étapes ci-dessus est démontrée ci-dessous dans un exemple.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Texte pour appliquer la langue de vérification orthographique");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```