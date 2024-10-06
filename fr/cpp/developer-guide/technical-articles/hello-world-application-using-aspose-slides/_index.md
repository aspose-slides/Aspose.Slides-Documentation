---
title: Application Hello World utilisant Aspose.Slides
type: docs
weight: 80
url: /cpp/hello-world-application-using-aspose-slides/
---

## **Étapes pour créer une application Hello World**
Dans cette simple application, nous allons créer une présentation PowerPoint comportant le texte **Hello World** à une position spécifiée d'une diapositive. Veuillez suivre les étapes ci-dessous pour créer l'application **Hello World** en utilisant l'API Aspose.Slides pour C++ :

- Créer une instance de la classe Presentation
- Obtenir la référence de la première diapositive dans la présentation qui est créée lors de l'instanciation de la présentation.
- Ajouter une AutoShape avec ShapeType comme Rectangle à une position spécifiée de la diapositive.
- Ajouter un TextFrame à l'AutoShape contenant Hello World comme texte par défaut
- Changer la couleur du texte en noir car elle est blanche par défaut et n'est pas visible sur la diapositive avec un fond blanc
- Changer la couleur de la ligne de la forme en blanc afin de cacher la bordure de la forme
- Supprimer le format de remplissage par défaut de la forme
- Enfin, écrire la présentation au format de fichier désiré en utilisant l'objet de Présentation

L'implémentation des étapes ci-dessus est démontrée ci-dessous dans un exemple.

``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // obtenir la première diapositive
    auto slide = pres->get_Slides()->idx_get(0);

    // ajouter une AutoShape de type Rectangle
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // ajouter un TextFrame au Rectangle
    shape->AddTextFrame(u"Hello World");

    // changer la couleur du texte en noir (qui est blanc par défaut)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // changer la couleur de la ligne du rectangle en blanc
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // retirer tout formatage de remplissage dans la forme
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // sauvegarder la présentation sur le disque
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```