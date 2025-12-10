---
title: Obtenir les limites du paragraphe à partir des présentations en C++
linktitle: Paragraphe
type: docs
weight: 60
url: /fr/cpp/paragraph/
keywords:
- limites du paragraphe
- limites de la portion de texte
- coordonnée du paragraphe
- coordonnée de la portion
- taille du paragraphe
- taille de la portion de texte
- cadre de texte
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez comment récupérer les limites du paragraphe et de la portion de texte dans Aspose.Slides pour C++ afin d'optimiser le positionnement du texte dans les présentations PowerPoint."
---

## **Obtenir les coordonnées du paragraphe et de la portion dans un TextFrame**
En utilisant Aspose.Slides pour C++, les développeurs peuvent désormais obtenir les coordonnées rectangulaires d’un paragraphe dans la collection de paragraphes d’un TextFrame. Cela permet également d’obtenir les coordonnées d’une portion dans la collection de portions d’un paragraphe. Dans cet article, nous allons démontrer, à l’aide d’un exemple, comment obtenir les coordonnées rectangulaires d’un paragraphe ainsi que la position d’une portion à l’intérieur d’un paragraphe.

## **Obtenir les coordonnées rectangulaires d’un paragraphe**
La nouvelle méthode **GetRect()** a été ajoutée. Elle permet d’obtenir le rectangle de délimitations du paragraphe.
``` cpp
// Instancier un objet Presentation qui représente un fichier de présentation
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```


## **Obtenir la taille d’un paragraphe et d’une portion à l’intérieur d’un TextFrame de cellule de tableau**

Pour obtenir la taille et les coordonnées du [Portion](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion) ou du [Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.paragraph) dans un TextFrame de cellule de tableau, vous pouvez utiliser les méthodes [IPortion::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) et [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t).

Ce code d’exemple illustre l’opération décrite :
``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```


## **FAQ**

**Dans quelles unités les coordonnées retournées pour un paragraphe et des portions de texte sont‑elles mesurées ?**

En points, où 1 pouce = 72 points. Cela s’applique à toutes les coordonnées et dimensions sur la diapositive.

**L’ajustement du texte influence‑t‑il les limites du paragraphe ?**

Oui. Si le [wrapping](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_wraptext/) est activé dans le [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/), le texte se coupe pour s’ajuster à la largeur de la zone, ce qui modifie les limites réelles du paragraphe.

**Les coordonnées du paragraphe peuvent‑elles être converties de manière fiable en pixels dans l’image exportée ?**

Oui. Convertissez les points en pixels avec : pixels = points × (DPI / 72). Le résultat dépend du DPI choisi pour le rendu/l’exportation.

**Comment obtenir les paramètres de formatage « effectif » d’un paragraphe en tenant compte de l’héritage des styles ?**

Utilisez la [structure de données de formatage de paragraphe effectif](/slides/fr/cpp/shape-effective-properties/); elle renvoie les valeurs consolidées finales pour les retraits, l’espacement, le wrapping, le RTL, etc.