---
title: Application Hello World utilisant Aspose.Slides pour C++
type: docs
weight: 80
url: /fr/cpp/hello-world-application-using-aspose-slides/
keywords:
- bonjour monde
- application
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Créez votre première application C++ avec Aspose.Slides, un exemple Hello World simple qui vous prépare à automatiser les présentations PPT, PPTX et ODP."
---

## **Étapes pour créer une application Hello World**
Dans cette application simple, nous allons créer une présentation PowerPoint contenant le texte **Hello World** à une position spécifiée d'une diapositive. Veuillez suivre les étapes ci-dessous pour créer une application **Hello World** en utilisant l'API Aspose.Slides pour C++ :

- Créer une instance de la classe Presentation
- Obtenir la référence de la première diapositive de la présentation, qui est créée lors de l'instanciation de Presentation.
- Ajouter une AutoShape avec ShapeType egal a Rectangle a une position specifiee de la diapositive.
- Ajouter un TextFrame a l'AutoShape contenant Hello World comme texte par defaut
- Modifier la couleur du texte en noir car il est blanc par defaut et n'est pas visible sur la diapositive avec un fond blanc
- Modifier la couleur du contour de la forme en blanc afin de masquer la bordure de la forme
- Supprimer le format de remplissage par defaut de la forme
- Enfin, enregistrer la presentation dans le format de fichier souhaite a l'aide de l'objet Presentation

L'implementation des etapes ci-dessus est illustree ci-dessous dans un exemple.
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

    // supprimer tout format de remplissage dans la forme
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // enregistrer la présentation sur le disque
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```
