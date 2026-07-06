---
title: Obtenir les limites de la portion de texte dans les présentations .NET
linktitle: Limites de la portion
type: docs
weight: 47
url: /fr/net/portion-bounds/
keywords:
- limites de la portion de texte
- portion de texte
- partie de texte
- coordonnées du texte
- position du texte
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez comment récupérer les limites d'une portion de texte dans les présentations PowerPoint à l'aide d'Aspose.Slides pour .NET."
---
## **Aperçu**

Une portion de texte représente un fragment spécifique de texte à l'intérieur d'un paragraphe et vous permet de travailler avec ce fragment de manière indépendante du contenu environnant. Dans Aspose.Slides, les portions peuvent être utilisées lorsque vous devez récupérer les limites d'un fragment de texte, appliquer un formatage uniquement à une partie d'un paragraphe ou contrôler le comportement du texte à un niveau plus détaillé.

Cet article montre comment obtenir le rectangle englobant d'une portion en utilisant [IPortion.GetRect](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/getrect/). Il montre également comment obtenir les coordonnées du début d'une portion en utilisant [IPortion.GetCoordinates](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/getcoordinates/). De plus, il met en avant des scénarios courants liés aux portions, tels que l'application d'un hyperlien à un fragment de texte unique, la compréhension de la résolution du formatage via l'héritage de la portion, du paragraphe, du cadre de texte et du thème, ainsi que la gestion des cas où une police spécifiée est indisponible.

## **Obtenir le rectangle englobant d'une portion de texte**

Utilisez [IPortion.GetRect](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/getrect/) pour récupérer le rectangle englobant d'une portion de texte :

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **Obtenir les coordonnées d'une portion de texte**

Utilisez [IPortion.GetCoordinates](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/getcoordinates/) pour récupérer les coordonnées du début d'une portion de texte :

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **FAQ**

**Puis-je appliquer un hyperlien à seulement une partie du texte d'un même paragraphe ?**

Oui, vous pouvez [attribuer un hyperlien](/slides/fr/net/manage-hyperlinks/) à une portion individuelle ; seul ce fragment sera cliquable, pas le paragraphe entier.

**Comment fonctionne l'héritage de style : qu'est‑ce qu'une portion remplace et qu'est‑ce qui est pris d'un paragraphe ou d'un cadre de texte ?**

Les propriétés au niveau de la portion ont la priorité la plus élevée. Si une propriété n'est pas définie sur l'[IPortion](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/), Aspose.Slides la récupère depuis l'[IParagraph](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/). Si elle n'est pas non plus définie là‑bas, Aspose.Slides utilise le style de l'[ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/) ou du [theme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/theme/).

**Que se passe-t-il si la police spécifiée pour une portion est absente sur la machine ou le serveur cible ?**

Les [règles de substitution de police](/slides/fr/net/font-selection-sequence/) s'appliquent. Le texte peut se réorganiser : les métriques, la césure et la largeur peuvent changer, ce qui est important pour un positionnement précis.

**Puis‑je définir la transparence ou un dégradé de remplissage de texte propre à une portion, indépendamment du reste du paragraphe ?**

Oui, la couleur du texte, le remplissage et la transparence au niveau de l'[IPortion](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/) peuvent différer des fragments voisins.