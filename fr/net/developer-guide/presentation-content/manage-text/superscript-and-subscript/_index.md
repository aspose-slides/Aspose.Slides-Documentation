---
title: Gérer les exposants et les indices en C#
linktitle: Exposant et indice
type: docs
weight: 80
url: /fr/net/superscript-and-subscript/
keywords:
- exposant
- indice
- ajouter exposant
- ajouter indice
- PowerPoint
- OpenDocument
- présentation
- C#
- Csharp
- Aspose.Slides
description: "Maîtrisez les exposants et les indices dans Aspose.Slides pour .NET et améliorez vos présentations avec un formatage de texte professionnel pour un impact maximal."
---

## **Vue d'ensemble**

Aspose.Slides for .NET propose des fonctionnalités d'intégration de texte en exposant et en indice dans vos présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP). Que vous ayez besoin de mettre en évidence des formules chimiques, des équations mathématiques ou d'annoter du contenu avec des notes de bas de page, ces options de formatage spécialisées aident à maintenir clarté et précision. Dans cet article, vous apprendrez comment appliquer de manière fluide les styles d'exposant et d'indice et garantir des résultats professionnels sur chaque diapositive.

## **Ajouter du texte en exposant et en indice**

Vous pouvez ajouter du texte en exposant et en indice dans n'importe quel paragraphe d'une présentation. Pour le faire avec Aspose.Slides, vous devez utiliser la propriété `Escapement` de la classe [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) .

Cette propriété vous permet de définir du texte en exposant ou en indice, avec des valeurs comprises entre -100 % (indice) et 100 % (exposant).

Étapes d'implémentation :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Obtenez une référence à une diapositive en utilisant son index.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) de type `Rectangle` à la diapositive.
1. Accédez à l'[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) associé à l'[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) .
1. Effacez les paragraphes existants.
1. Créez un nouveau [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) pour le texte en exposant et ajoutez‑le à la collection de paragraphes de l'[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) .
1. Créez un nouvel objet de portion de texte.
1. Définissez la propriété `Escapement` de la portion de texte entre 0 et 100 pour appliquer l'exposant (0 signifie aucun exposant).
1. Définissez du texte pour la [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) et ajoutez‑le à la collection de portions du paragraphe.
1. Créez un autre [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) pour le texte en indice et ajoutez‑le à la collection de paragraphes.
1. Créez un nouvel objet de portion de texte.
1. Définissez la propriété `Escapement` de la portion de texte entre 0 et -100 pour appliquer l'indice (0 signifie aucun indice).
1. Définissez du texte pour la [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) et ajoutez‑le à la collection de portions du paragraphe.
1. Enregistrez la présentation au format PPTX.

Le code C# suivant implémente ces étapes :
```c#
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Créer une zone de texte.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Créer un paragraphe pour le texte en exposant.
    IParagraph superPar = new Paragraph();

    // Créer une portion de texte avec du texte normal.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Créer une portion de texte avec du texte en exposant.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Créer un paragraphe pour le texte en indice.
    IParagraph paragraph2 = new Paragraph();

    // Créer une portion de texte avec du texte normal.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Créer une portion de texte avec du texte en indice.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Ajouter les paragraphes à la zone de texte.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Superscript and Subscript](superscript_and_subscript.png)

## **FAQ**

**L'exposant et l'indice sont‑ils conservés lors de l'exportation vers PDF ou d'autres formats ?**

Oui, Aspose.Slides for .NET conserve correctement le formatage d'exposant et d'indice lors de l'exportation des présentations vers PDF, PPT/PPTX, images et autres formats pris en charge. Le formatage spécialisé reste intact dans tous les fichiers de sortie.

**L'exposant et l'indice peuvent‑ils être combinés avec d'autres styles de formatage tels que gras ou italique ?**

Oui, Aspose.Slides vous permet de mêler différents styles de texte au sein d'une même portion. Vous pouvez activer le gras, l'italique, le soulignement et appliquer simultanément l'exposant ou l'indice en configurant les propriétés correspondantes dans [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) .

**Le formatage d'exposant et d'indice fonctionne‑t‑il pour le texte à l'intérieur des tableaux, graphiques ou SmartArt ?**

Oui, Aspose.Slides for .NET prend en charge le formatage dans la plupart des objets, y compris les éléments de tableaux et de graphiques. Lors du travail avec SmartArt, vous devez accéder aux éléments appropriés (tels que [SmartArtNode](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartnode/) ) et à leurs conteneurs de texte, puis configurer les propriétés de [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) de manière similaire.