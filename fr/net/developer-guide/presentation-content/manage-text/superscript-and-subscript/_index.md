---
title: Gérer les exposants et indices dans les présentations en .NET
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
- .NET
- C#
- Aspose.Slides
description: "Maîtrisez les exposants et indices dans Aspose.Slides pour .NET et améliorez vos présentations avec une mise en forme de texte professionnelle pour un impact maximal."
---

## **Vue d'ensemble**

Aspose.Slides for .NET offre des fonctionnalités d'intégration de texte en exposant et indice dans vos présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP). Que vous ayez besoin de mettre en valeur des formules chimiques, des équations mathématiques ou d'annoter du contenu avec des notes de bas de page, ces options de mise en forme spécialisées permettent de conserver clarté et précision. Dans cet article, vous apprendrez comment appliquer de manière fluide les styles exposant et indice et obtenir des résultats professionnels sur chaque diapositive.

## **Ajouter du texte en exposant et indice**

Vous pouvez ajouter du texte en exposant et indice à l'intérieur de n'importe quel paragraphe d'une présentation. Pour cela avec Aspose.Slides, vous devez utiliser la propriété `Escapement` de la classe [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) .

Cette propriété vous permet de définir du texte en exposant ou indice, avec des valeurs allant de -100 % (indice) à 100 % (exposant).

Étapes d'implémentation :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Obtenez une référence à une diapositive en utilisant son indice.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) de type `Rectangle` à la diapositive.
1. Accédez au [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) associé à l'[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) .
1. Effacez les paragraphes existants.
1. Créez un nouveau [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) pour le texte en exposant et ajoutez‑le à la collection de paragraphes du [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) .
1. Créez un nouvel objet de portion de texte.
1. Définissez la propriété `Escapement` pour la portion de texte entre 0 et 100 afin d'appliquer l'exposant (0 signifie aucun exposant).
1. Définissez du texte pour la [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) et ajoutez‑le à la collection de portions du paragraphe.
1. Créez un autre [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) pour le texte en indice et ajoutez‑le à la collection de paragraphes.
1. Créez un nouvel objet de portion de texte.
1. Définissez la propriété `Escapement` pour la portion de texte entre 0 et -100 afin d'appliquer l'indice (0 signifie aucun indice).
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

**Le texte en exposant et indice sera-t-il conservé lors de l'exportation vers PDF ou d'autres formats ?**

Oui, Aspose.Slides for .NET conserve correctement la mise en forme en exposant et indice lors de l'exportation des présentations vers PDF, PPT/PPTX, images et autres formats pris en charge. Le formatage spécialisé reste intact dans tous les fichiers de sortie.

**L'exposant et l'indice peuvent-ils être combinés avec d'autres styles de mise en forme tels que gras ou italique ?**

Oui, Aspose.Slides vous permet de mêler différents styles de texte au sein d'une même portion. Vous pouvez activer le gras, l'italique, le souligné et appliquer simultanément l'exposant ou l'indice en configurant les propriétés correspondantes dans [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) .

**La mise en forme en exposant et indice fonctionne‑t‑elle pour le texte à l'intérieur des tableaux, graphiques ou SmartArt ?**

Oui, Aspose.Slides for .NET prend en charge la mise en forme dans la plupart des objets, y compris les éléments de tableaux et de graphiques. Lors du travail avec SmartArt, vous devez accéder aux éléments appropriés (tels que [SmartArtNode](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartnode/)) et à leurs conteneurs de texte, puis configurer les propriétés de [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) de manière similaire.