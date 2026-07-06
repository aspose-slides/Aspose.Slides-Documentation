---
title: Obtenir les limites des paragraphes à partir de présentations en C++
linktitle: Limites de paragraphe
type: docs
weight: 43
url: /fr/cpp/paragraph-bounds/
keywords:
- limites de paragraphe
- coordonnées de paragraphe
- taille de paragraphe
- cadre de texte
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez comment récupérer les limites des paragraphes dans Aspose.Slides pour C++ afin d'optimiser le positionnement du texte dans les présentations PowerPoint."
---
## **Vue d'ensemble**

Cet article explique comment obtenir les limites, la taille et les coordonnées des paragraphes dans Aspose.Slides. Il montre comment récupérer un rectangle de paragraphe à partir d'un [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) en utilisant [IParagraph::GetRect](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/getrect/), comment obtenir les coordonnées d'un paragraphe à l'intérieur d'un cadre de texte de cellule de tableau, et met en évidence des détails importants tels que les unités de mesure, l'effet de l'habillage du texte sur les limites, la conversion en pixels et les valeurs de mise en forme effectives du paragraphe.

## **Obtenir les coordonnées rectangulaires d'un paragraphe**

Utilisez [IParagraph::GetRect](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/getrect/) pour obtenir le rectangle englobant d'un paragraphe.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **Obtenir la taille d'un paragraphe à l'intérieur d'un TextFrame de cellule de tableau**

Pour obtenir la taille et les coordonnées d'un [IParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/) dans un cadre de texte de cellule de tableau, utilisez [IParagraph::GetRect](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/getrect/). Le rectangle retourné est relatif au cadre de texte de la cellule du tableau, il faut donc ajouter la position du tableau et le décalage de la cellule lorsque vous avez besoin de coordonnées au niveau de la diapositive.

L'exemple suivant récupère les limites du paragraphe à l'intérieur d'une cellule de tableau et dessine des rectangles sur la diapositive pour visualiser ces limites :

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Dans quelles unités les coordonnées du paragraphe sont‑elles mesurées ?**

Elles sont mesurées en points, où 1 pouce équivaut à 72 points. Cela s'applique à toutes les coordonnées et dimensions de la diapositive.

**L'habillage du texte affecte‑t‑il les limites d'un paragraphe ?**

Oui. Si [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframeformat/set_wraptext/) est activé pour le [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/), le texte se coupe pour s'adapter à la largeur de la zone, ce qui modifie les limites réelles du paragraphe.

**Les coordonnées du paragraphe peuvent‑elles être mappées de manière fiable aux pixels dans l'image exportée ?**

Oui. Convertissez les points en pixels à l'aide de cette formule : pixels = points × (DPI / 72). Le résultat dépend du DPI choisi pour le rendu ou l'exportation.

**Comment obtenir les paramètres de mise en forme « effectifs » du paragraphe, en tenant compte de l'héritage des styles ?**

Utilisez la [effective paragraph formatting data structure](/slides/fr/cpp/shape-effective-properties/); elle renvoie les valeurs consolidées finales pour les retraits, l'espacement, l'habillage, le RTL, et plus encore.