---
title: Paragraphe
type: docs
weight: 60
url: /fr/cpp/paragraph/
---

## **Obtenir les coordonnées de paragraphe et de portion dans TextFrame**
Avec Aspose.Slides pour C++, les développeurs peuvent désormais obtenir les coordonnées rectangulaires pour Paragraphe à l'intérieur de la collection de paragraphes de TextFrame. Cela vous permet également d'obtenir les coordonnées de portion à l'intérieur de la collection de portions d'un paragraphe. Dans ce sujet, nous allons démontrer avec l'aide d'un exemple comment obtenir les coordonnées rectangulaires pour un paragraphe ainsi que la position de la portion à l'intérieur d'un paragraphe.

## **Obtenir les coordonnées rectangulaires du paragraphe**
La nouvelle méthode **GetRect()** a été ajoutée. Elle permet d'obtenir le rectangle des limites du paragraphe.

``` cpp
// Instancier un objet Presentation qui représente un fichier de présentation
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **Obtenir la taille du paragraphe et de la portion à l'intérieur du cadre de texte de la cellule de tableau**

Pour obtenir la taille et les coordonnées de [Portion](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion) ou de [Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.paragraph) dans un cadre de texte de cellule de tableau, vous pouvez utiliser les méthodes [IPortion::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) et [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t).

Ce code d'exemple illustre l'opération décrite :

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