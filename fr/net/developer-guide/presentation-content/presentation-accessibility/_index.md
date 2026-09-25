---
title: Gérer l'accessibilité des présentations dans .NET
linktitle: Accessibilité des présentations
type: docs
weight: 30
url: /fr/net/presentation-accessibility/
keywords:
- accessibilité des présentations
- texte alternatif
- titre du texte alternatif
- description du texte alternatif
- marquer comme décoratif
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Automatisez les vérifications d'accessibilité des présentations dans les fichiers PPT, PPTX et ODP avec Aspose.Slides pour .NET—améliorez l'expérience des lecteurs d'écran et renforcez la conformité."
---
## **Introduction**

Le texte alternatif aide les personnes utilisant des technologies d'assistance à comprendre la signification des images, graphiques et autres formes informatives. Cet article explique comment lire et mettre à jour les titres et descriptions de texte alternatif avec Aspose.Slides pour .NET, distinguer les descriptions d'accessibilité des noms de formes utilisés dans le code, et vérifier si une forme est marquée comme décorative.

Ces fonctionnalités favorisent l'accessibilité des présentations, mais ne la garantissent pas. L'ordre de lecture, le contraste des couleurs, la lisibilité du texte et d'autres exigences d'accessibilité doivent également être examinés.

## **Gérer les titres et descriptions de texte alternatif**

Utilisez le texte alternatif pour expliquer la signification des images, graphiques et autres formes informatives aux personnes qui ne peuvent pas les voir. Les propriétés suivantes servent à des fins différentes :

| Propriété ou contenu | Objectif |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/alternativetexttitle/) | Un titre court pour la description alternative. |
| [AlternativeText](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/alternativetext/) | Une description significative du contenu ou de l'objectif de la forme dans le contexte de la diapositive. |
| [Name](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/name/) | Le nom de la forme, que le code peut utiliser pour trouver une forme spécifique dans la présentation. |
| Texte visible | Contenu affiché sur la diapositive, comme le texte d'une forme ou le titre et les étiquettes d'un graphique. La mise à jour du texte alternatif ne modifie pas ce contenu. |

Lorsque une présentation est réutilisée comme modèle, le code peut trouver une forme par son [Name](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/name/) avant de la mettre à jour. Ce nom a un objectif différent du texte alternatif, qui explique ce que le visuel communique au lecteur. La recherche par nom permet aux auteurs d'améliorer ou de traduire les descriptions sans changer la façon dont le code trouve la forme. Les noms peuvent être modifiés et ne sont pas garantis d'être uniques, il faut donc vérifier que le nom correspond à la forme prévue ; voir [Identifier et trouver des formes](/slides/fr/net/shape-manipulations/#identify-and-find-shapes).

L'exemple suivant nécessite `input.pptx` contenant une image d'une entrée de bureau en tant que première forme de la première diapositive. L'image ne doit pas être marquée comme décorative. L'exemple lit et affiche le titre et la description actuels du texte alternatif, met à jour les deux valeurs et enregistre la présentation sous `output.pptx`. Adaptez le libellé à l'image réelle et aux informations qu'elle transmet.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var shape = presentation.Slides[0].Shapes[0];

Console.WriteLine($"Alternative text title: {shape.AlternativeTextTitle}");
Console.WriteLine($"Alternative text description: {shape.AlternativeText}");

shape.AlternativeTextTitle = "Office entrance";
shape.AlternativeText = "The office entrance has a wheelchair ramp to the right of the steps.";

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Ajouter uniquement du texte alternatif ne garantit pas l'accessibilité de la présentation ni la conformité aux normes d'accessibilité. Vérifiez l'exactitude et la pertinence des descriptions, ainsi que l'ordre de lecture, le contraste des couleurs, la lisibilité du texte et d'autres exigences d'accessibilité. Les visuels informatifs ne doivent pas être marqués comme décoratifs ; la section suivante montre comment lire [IsDecorative](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/isdecorative/).

## **Marquer comme décoratif**

Le drapeau « marquer comme décoratif » indique que les visuels purement ornementaux sont ignorés par les lecteurs d'écran, réduisant le bruit et maintenant le focus sur le contenu significatif. Appliquez‑le aux arrière‑plans, aux ornements et aux espaces — jamais aux graphiques, icônes ou images qui véhiculent de l'information. Aspose.Slides expose ce drapeau pour la détection et la validation, permettant des contrôles d'accessibilité automatisés et le nettoyage.

![Mark as Decorative](mark_as_decorative.png)

Le code suivant montre comment déterminer si une forme est marquée comme décorative.

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```

## **FAQ**

**Que dois‑je mettre dans le titre et la description du texte alternatif ?**

Utilisez un titre court pour identifier le sujet et une description pour expliquer l'information que le visuel transmet dans le contexte de la diapositive. Pour un graphique, décrivez la tendance ou la comparaison pertinente plutôt que de simplement indiquer « graphique ».

**Dois‑je utiliser le texte alternatif pour localiser les formes dans un modèle ?**

Il est préférable de trouver la forme par son [Name](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/name/) et de vérifier qu'il s'agit de la forme attendue. Le texte alternatif peut être modifié ou traduit, ce qui peut casser le code qui recherche une description exacte ; voir [Identifier et trouver des formes](/slides/fr/net/shape-manipulations/).

**Quand une forme doit‑elle être marquée comme décorative ?**

Utilisez le drapeau décoratif pour les visuels qui n'apportent aucune information, comme les ornements décoratifs. Les images et graphiques qui communiquent un sens nécessitent une description appropriée à la place.

**L’ajout de texte alternatif rend‑il une présentation entièrement accessible ?**

Non. Le texte alternatif ne couvre qu'une partie de l'accessibilité. Il faut également examiner l'ordre de lecture, le contraste des couleurs, la lisibilité du texte et les autres exigences applicables ; la simple définition de ces propriétés n'établit pas la conformité.