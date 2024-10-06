---
title: Superposition et Sous-cription
type: docs
weight: 80
url: /net/superscript-and-subscript/
keywords: "Super script, Sous script, Ajouter du texte en superposition, Ajouter du texte en souscription, Présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajoutez du texte en superposition et en souscription aux présentations PowerPoint en C# ou .NET"
---

## **Gérer le Texte en Superposition et en Sous-cription**
Vous pouvez ajouter du texte en superposition et en souscription à l’intérieur de n'importe quelle partie de paragraphe. Pour ajouter du texte en Superposition ou en Souscription dans un cadre de texte Aspose.Slides, il faut utiliser **les propriétés d'Effet de décalage** de la classe PortionFormat.

Cette propriété retourne ou définit le texte en superposition ou en souscription (valeur de -100 % (souscription) à 100 % (superposition). Par exemple :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenir la référence d'une diapositive en utilisant son index.
- Ajouter un IAutoShape de type Rectangle à la diapositive.
- Accéder au ITextFrame associé à l'IAutoShape.
- Effacer les Paragraphes existants.
- Créer un nouvel objet paragraphe pour contenir le texte en superposition et l'ajouter à la collection IParagraphs du ITextFrame.
- Créer un nouvel objet portion.
- Définir la propriété Effet de décalage pour la portion entre 0 et 100 pour ajouter une superposition. (0 signifie pas de superposition)
- Définir du texte pour la Portion et l’ajouter à la collection de portions du paragraphe.
- Créer un nouvel objet paragraphe pour contenir le texte en souscription et l'ajouter à la collection IParagraphs du ITextFrame.
- Créer un nouvel objet portion.
- Définir la propriété Effet de décalage pour la portion entre 0 et -100 pour ajouter une souscription. (0 signifie pas de souscription)
- Définir du texte pour la Portion et l’ajouter à la collection de portions du paragraphe.
- Enregistrer la présentation en tant que fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    // Obtenir la diapositive
    ISlide slide = presentation.Slides[0];

    // Créer une zone de texte
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // Créer un paragraphe pour le texte en superposition
    IParagraph superPar = new Paragraph();

    // Créer une portion avec du texte habituel
    IPortion portion1 = new Portion();
    portion1.Text = "TitreDiapositive";
    superPar.Portions.Add(portion1);

    // Créer une portion avec du texte en superposition
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Créer un paragraphe pour le texte en souscription
    IParagraph paragraph2 = new Paragraph();

    // Créer une portion avec du texte habituel
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Créer une portion avec du texte en souscription
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Ajouter les paragraphes à la zone de texte
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("TestOut.pptx", SaveFormat.Pptx);
    System.Diagnostics.Process.Start("TestOut.pptx");
 } 
```