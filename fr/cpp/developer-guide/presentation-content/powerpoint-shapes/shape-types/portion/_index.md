---
title: Gérer les portions de texte dans les présentations à l'aide de C++
linktitle: Portion de texte
type: docs
weight: 70
url: /fr/cpp/portion/
keywords:
- portion de texte
- partie de texte
- coordonnées du texte
- position du texte
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à gérer les portions de texte dans les présentations PowerPoint à l'aide d'Aspose.Slides pour C++, en améliorant les performances et la personnalisation."
---

## **Obtenir les coordonnées d'une portion de texte**
**GetCoordinates()** méthode a été ajoutée à IPortion et à la classe Portion, ce qui permet de récupérer les coordonnées du début de la portion :
``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```


## **FAQ**

**Puis-je appliquer un hyperlien à seulement une partie du texte dans un même paragraphe ?**

Oui, vous pouvez [attribuer un hyperlien](/slides/fr/cpp/manage-hyperlinks/) à une portion individuelle ; seul ce fragment sera cliquable, pas le paragraphe entier.

**Comment fonctionne l'héritage de style : qu'est‑ce qu'une Portion surcharge, et qu'est‑ce qui est repris du Paragraph/TextFrame ?**

Les propriétés au niveau de la Portion ont la priorité la plus élevée. Si une propriété n'est pas définie sur la [Portion](https://reference.aspose.com/slides/cpp/aspose.slides/portion/), le moteur la récupère depuis le [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) ; si elle n'est pas non plus définie là, il la prend du [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) ou du style du [theme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/theme/).

**Que se passe‑t‑il si la police spécifiée pour une Portion est absente sur la machine/serveur cible ?**

Les [règles de substitution de police](/slides/fr/cpp/font-selection-sequence/) s'appliquent. Le texte peut se réorganiser : les métriques, la césure et la largeur peuvent changer, ce qui affecte le positionnement précis.

**Puis‑je définir une transparence ou un dégradé de remplissage de texte spécifique à une Portion, indépendamment du reste du paragraphe ?**

Oui, la couleur du texte, le remplissage et la transparence au niveau de la [Portion](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) peuvent différer des fragments voisins.