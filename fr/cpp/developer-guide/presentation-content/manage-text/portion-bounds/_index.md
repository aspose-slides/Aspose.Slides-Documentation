---
title: Obtenir les limites de la portion de texte à partir de présentations en C++
linktitle: Limites de la portion
type: docs
weight: 47
url: /fr/cpp/portion-bounds/
keywords:
- limites de la portion de texte
- portion de texte
- partie de texte
- coordonnées du texte
- position du texte
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez comment récupérer les limites des portions de texte dans les présentations PowerPoint à l'aide d'Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Une portion de texte représente un fragment spécifique de texte à l'intérieur d'un paragraphe et vous permet de travailler avec ce fragment de manière indépendante du contenu environnant. Dans Aspose.Slides, les portions peuvent être utilisées lorsque vous devez récupérer les limites d'un fragment de texte, appliquer un formatage uniquement à une partie d'un paragraphe ou contrôler le comportement du texte à un niveau plus détaillé.

Cet article montre comment obtenir le rectangle englobant d'une portion en utilisant [IPortion::GetRect](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportion/getrect/). Il montre également comment obtenir les coordonnées du début d'une portion en utilisant [IPortion::GetCoordinates](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportion/getcoordinates/). De plus, il met en évidence les scénarios courants liés aux portions, tels que l'application d'un hyperlien à un fragment de texte unique, la compréhension du déroulement du formatage à travers la portion, le paragraphe, le cadre de texte et l'héritage du thème, ainsi que la gestion des cas où la police spécifiée est indisponible.

## **Obtenir les limites d'une portion de texte**

Utilisez [IPortion::GetRect](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportion/getrect/) pour récupérer le rectangle englobant d'une portion de texte :

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **Obtenir les coordonnées d'une portion de texte**

Utilisez [IPortion::GetCoordinates](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportion/getcoordinates/) pour récupérer les coordonnées du début d'une portion de texte :

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **FAQ**

**Puis-je appliquer un hyperlien à une partie seulement du texte au sein d'un seul paragraphe ?**

Oui, vous pouvez [attribuer un hyperlien](/slides/fr/cpp/manage-hyperlinks/) à une portion individuelle ; seul ce fragment sera cliquable, pas tout le paragraphe.

**Comment fonctionne l'héritage de style : qu'est‑ce qu'une portion remplace et qu'est‑ce qui provient d'un paragraphe ou d'un cadre de texte ?**

Les propriétés au niveau de la portion ont la priorité la plus élevée. Si une propriété n'est pas définie sur l'[IPortion](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportion/), Aspose.Slides la récupère depuis l'[IParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/). Si elle n'est pas non plus définie là, Aspose.Slides utilise le style de l'[ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) ou du [theme](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/theme/).

**Que se passe-t-il si la police spécifiée pour une portion est absente sur la machine ou le serveur cible ?**

Les [règles de substitution de police](/slides/fr/cpp/font-selection-sequence/) s'appliquent. Le texte peut se réorganiser : les métriques, la césure et la largeur peuvent changer, ce qui est important pour un positionnement précis.

**Puis-je définir la transparence ou un dégradé de remplissage de texte spécifique à une portion indépendamment du reste du paragraphe ?**

Oui, la couleur du texte, le remplissage et la transparence au niveau de l'[IPortion](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportion/) peuvent différer des fragments voisins.