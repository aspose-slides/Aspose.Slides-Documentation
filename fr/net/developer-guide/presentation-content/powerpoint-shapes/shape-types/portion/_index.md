---
title: Gérer les portions de texte dans les présentations en .NET
linktitle: Portion de texte
type: docs
weight: 70
url: /fr/net/portion/
keywords:
- portion de texte
- partie de texte
- coordonnées du texte
- position du texte
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à gérer les portions de texte dans les présentations PowerPoint à l'aide d'Aspose.Slides pour .NET, en améliorant les performances et la personnalisation."
---

## **Obtenir les coordonnées de position de la Portion**
**GetCoordinates()** method a été ajouté à IPortion et à la classe Portion, ce qui permet de récupérer les coordonnées du début de la portion :
```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```


## **FAQ**

**Puis-je appliquer un hyperlien uniquement à une partie du texte dans un même paragraphe ?**

Oui, vous pouvez [attribuer un hyperlien](/slides/fr/net/manage-hyperlinks/) à une portion individuelle ; seul ce fragment sera cliquable, pas le paragraphe entier.

**Comment fonctionne l’héritage de style : qu’est‑ce qu’une Portion surcharge, et qu’est‑ce qui provient du Paragraph/TextFrame ?**

Les propriétés au niveau de la Portion ont la priorité la plus élevée. Si une propriété n’est pas définie sur la [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/), le moteur la récupère depuis le [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/); si elle n’est pas non plus définie là, depuis le [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) ou le style du [theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/).

**Que se passe-t-il si la police spécifiée pour une Portion est absente sur la machine/serveur cible ?**

[Règles de substitution de police](/slides/fr/net/font-selection-sequence/) s’appliquent. Le texte peut se réarranger : les métriques, la césure et la largeur peuvent changer, ce qui est important pour un positionnement précis.

**Puis‑je définir une transparence ou un dégradé de remplissage de texte propre à une Portion, indépendamment du reste du paragraphe ?**

Oui, la couleur du texte, le remplissage et la transparence au niveau de la [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) peuvent différer des fragments voisins.