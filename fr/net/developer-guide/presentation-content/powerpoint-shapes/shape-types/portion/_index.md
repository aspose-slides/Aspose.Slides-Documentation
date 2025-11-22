---
title: Portion
type: docs
weight: 70
url: /fr/net/portion/
keywords: "Portion, forme PowerPoint, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Obtenir une portion dans une présentation PowerPoint en C# ou .NET"
---

## **Obtenir les coordonnées de position de la portion**
**GetCoordinates()** a été ajouté à l'interface IPortion et à la classe Portion, ce qui permet de récupérer les coordonnées du début de la portion:
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

**Puis-je appliquer un hyperlien à seulement une partie du texte dans un même paragraphe ?**

Oui, vous pouvez [assigner un hyperlien](/slides/fr/net/manage-hyperlinks/) à une portion individuelle ; seul ce fragment sera cliquable, pas le paragraphe entier.

**Comment fonctionne l'héritage de style : qu'est-ce qu'une Portion écrase, et qu'est-ce qui est hérité du Paragraph/TextFrame ?**

Les propriétés au niveau de la Portion ont la priorité la plus élevée. Si une propriété n'est pas définie sur la [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/), le moteur la récupère depuis le [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) ; si elle n'est pas non plus définie là, elle provient du [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) ou du style du [theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/).

**Que se passe-t-il si la police spécifiée pour une Portion est absente sur la machine/serveur cible ?**

Les [règles de substitution de police](/slides/fr/net/font-selection-sequence/) s'appliquent. Le texte peut se reconstituer : les métriques, la césure et la largeur peuvent changer, ce qui affecte le positionnement précis.

**Puis-je définir une transparence ou un dégradé de remplissage du texte propre à une Portion, indépendant du reste du paragraphe ?**

Oui, la couleur du texte, le remplissage et la transparence au niveau de la [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) peuvent différer des fragments voisins.