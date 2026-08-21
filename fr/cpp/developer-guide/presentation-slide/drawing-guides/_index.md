---
title: Gérer les guides de dessin dans les présentations en C++
linktitle: Guides de dessin
type: docs
weight: 85
url: /fr/cpp/drawing-guides/
keywords:
- guide de dessin
- guide horizontal
- guide vertical
- guide d'alignement
- vue de diapositive
- masque de diapositive
- diapositive de mise en page
- masque de notes
- masque de prospectus
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Ajouter, accéder et supprimer les guides de dessin horizontaux et verticaux dans les présentations PowerPoint à l'aide d'Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Les guides de dessin sont des lignes horizontales et verticales réglables qui aident les utilisateurs à aligner les formes de manière cohérente lors de l'édition d'une présentation dans PowerPoint. Ils sont particulièrement utiles lorsqu'une application génère une présentation qui sera ensuite peaufinée manuellement : l'application peut enregistrer les mêmes aides d'alignement que les auteurs doivent suivre lors de l'ajout ou du déplacement de contenu.

Les guides de dessin sont des aides à l'édition, pas du contenu de diapositive. Ils n'apparaissent pas dans un diaporama ni dans la sortie rendue. Aspose.Slides for C++ les expose via l'interface [IDrawingGuidesCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idrawingguidescollection/). Un guide est représenté par [IDrawingGuide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idrawingguide/) et possède une orientation, une position et une couleur.

La position est mesurée en points depuis le coin supérieur gauche de la diapositive ou du masque concerné. Un guide vertical utilise une coordonnée horizontale, généralement comprise entre zéro et la largeur de la diapositive. Un guide horizontal utilise une coordonnée verticale, généralement comprise entre zéro et la hauteur de la diapositive.

## **Ajouter des guides à la vue des diapositives**

Utilisez [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) pour gérer les guides affichés pendant l'édition des diapositives normales. Appelez [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idrawingguidescollection/add/) avec une valeur [Orientation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/orientation/) et une position en points.

L'exemple suivant ajoute un guide vertical à droite du centre de la diapositive et un guide horizontal en dessous :

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/IViewProperties.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

guides->Add(Orientation::Vertical, slideSize.get_Width() / 2 + 12.5f);
guides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 12.5f);

presentation->Save(u"drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Accéder aux guides de dessin**

Les méthodes [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idrawingguidescollection/get_count/) et [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idrawingguidescollection/idx_get/) permettent d'accéder aux guides existants. Les méthodes [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idrawingguide/get_position/) et [IDrawingGuide::get_Color](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idrawingguide/get_color/) renvoient les propriétés actuelles d'un guide. Leurs méthodes d'affectation correspondantes peuvent modifier ces propriétés.

L'exemple suivant lit les guides de la vue diapositive à partir de la présentation créée ci‑dessus :

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuide.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"drawing-guides.pptx");
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

for (int32_t index = 0; index < guides->get_Count(); index++)
{
    auto guide = guides->idx_get(index);
    System::Console::WriteLine(
        System::String::Format(
            u"Guide {0}: orientation = {1}, position = {2}, color = {3}",
            index,
            guide->get_Orientation(),
            guide->get_Position(),
            guide->get_Color()));
}

presentation->Dispose();
```

## **Ajouter des guides aux masques et aux diapositives de mise en page**

Un masque de diapositive et chacune de ses diapositives de mise en page peuvent posséder leurs propres collections de guides de dessin. Utilisez [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslide/get_drawingguides/) pour un masque de diapositive et [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/get_drawingguides/) pour une diapositive de mise en page.

L'exemple suivant ajoute un guide vertical au premier masque de diapositive et un guide horizontal à la première diapositive de mise en page :

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto masterGuides = presentation->get_Master(0)->get_DrawingGuides();
auto layoutGuides = presentation->get_LayoutSlide(0)->get_DrawingGuides();

masterGuides->Add(Orientation::Vertical, slideSize.get_Width() / 2 - 20.0f);
layoutGuides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 20.0f);

presentation->Save(u"master-layout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ajouter des guides aux masques de notes et de prospectus**

Les masques de notes et les masques de prospectus prennent également en charge les guides de dessin. Utilisez [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasternotesslide/get_drawingguides/) et [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) pour accéder à leurs collections. Si une présentation ne contient pas l'un de ces masques, [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) ou [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) crée le masque par défaut et le renvoie.

L'exemple suivant ajoute un guide horizontal à un masque de notes et un guide vertical à un masque de prospectus :

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/INotesSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto notesSize = presentation->get_NotesSize()->get_Size();
auto notesMaster = presentation->get_MasterNotesSlideManager()->SetDefaultMasterNotesSlide();
auto handoutMaster = presentation->get_MasterHandoutSlideManager()->SetDefaultMasterHandoutSlide();

notesMaster->get_DrawingGuides()->Add(Orientation::Horizontal, notesSize.get_Height() / 2 + 50.0f);
handoutMaster->get_DrawingGuides()->Add(Orientation::Vertical, notesSize.get_Width() / 2 - 50.0f);

presentation->Save(u"notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Effacer les guides de dessin**

Appelez [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idrawingguidescollection/clear/) pour supprimer tous les guides d'une collection donnée. Effacer une collection n'affecte pas les guides stockés dans un autre contexte.

L'exemple suivant efface les guides de la vue diapositive ainsi que tous les guides des masques de diapositives, des diapositives de mise en page, du masque de notes et du masque de prospectus, sans créer les masques manquants :

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation-with-guides.pptx");

presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides()->Clear();

for (auto&& masterSlide : presentation->get_Masters())
{
    masterSlide->get_DrawingGuides()->Clear();
}

for (auto&& layoutSlide : presentation->get_LayoutSlides())
{
    layoutSlide->get_DrawingGuides()->Clear();
}

auto notesMaster = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (notesMaster != nullptr)
{
    notesMaster->get_DrawingGuides()->Clear();
}

auto handoutMaster = presentation->get_MasterHandoutSlideManager()->get_MasterHandoutSlide();
if (handoutMaster != nullptr)
{
    handoutMaster->get_DrawingGuides()->Clear();
}

presentation->Save(u"presentation-without-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Les guides de dessin apparaissent-ils dans un diaporama ou des images exportées ?**

Non. Les guides de dessin sont des aides à l'alignement pour l'édition et ne sont pas rendus comme contenu de la présentation.

**Un guide de dessin peut-il être ajouté directement à une diapositive normale individuelle ?**

Les guides d'édition des diapositives normales sont stockés dans les propriétés de vue de diapositive de la présentation. Des collections de guides distinctes sont disponibles pour les masques de diapositives, les diapositives de mise en page, les masques de notes et les masques de prospectus.

**Quelles unités sont utilisées pour les positions des guides ?**

Les positions sont spécifiées en points, où 72 points correspondent à un pouce. Les positions verticales sont mesurées depuis le bord gauche, et les positions horizontales depuis le bord supérieur.

**La suppression des guides de dessin supprime‑t‑elle des formes ou modifie le contenu de la diapositive ?**

Non. La méthode `Clear` ne supprime que les guides de la collection sélectionnée. Les formes et les autres contenus de la diapositive restent inchangés.