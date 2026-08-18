---
title: Gérer les en-têtes et pieds de page de la présentation en C++
linktitle: En-tête et pied de page
type: docs
weight: 140
url: /fr/cpp/presentation-header-and-footer/
keywords:
- en-tête
- "texte d'en-tête"
- pied de page
- "texte de pied de page"
- "définir l'en-tête"
- "définir le pied de page"
- fascicule
- notes
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Apprenez à gérer les espaces réservés de pied de page, date‑heure, numéro de diapositive et en‑tête sur les diapositives, les pages de notes et les fascicules avec Aspose.Slides pour C++."
---
## **Vue d’ensemble**

PowerPoint utilise différents espaces réservés d’en‑tête et de pied de page en fonction du type de page. Aspose.Slides pour C++ vous permet de contrôler le texte et la visibilité de ces espaces réservés via les interfaces du gestionnaire d’en‑tête/pied de page.

Les espaces réservés disponibles dépendent de la portée :

| Portée | En‑tête | Pied de page | Date/heure | Numéro de diapositive/page |
|---|---|---|---|---|
| Diapositive ordinaire | Non | Oui | Oui | Oui |
| Masque des notes | Oui | Oui | Oui | Oui |
| Diapositive de notes | Oui | Oui | Oui | Oui |
| Masque du fascicule | Oui | Oui | Oui | Oui |

Une diapositive de présentation ordinaire ne possède pas d’espace réservé d’en‑tête. Les en‑têtes sont disponibles sur les pages de notes et les fascicules. Pour les diapositives ordinaires, utilisez les espaces réservés de pied de page, de date/heure et de numéro de diapositive à la place.

La portée d’une modification dépend du gestionnaire que vous utilisez. L’interface [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideheaderfootermanager/) contrôle une diapositive ordinaire. L’interface [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/inotesslideheaderfootermanager/) contrôle une diapositive de notes. Les gestionnaires de masque et de mise en page peuvent également propager les paramètres aux diapositives dépendantes, tandis que l’interface [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) contrôle le masque du fascicule.

## **Définir le pied de page, la date/heure et les numéros de diapositive sur les diapositives ordinaires**

Pour les diapositives ordinaires, le flux de travail de base consiste à accéder au gestionnaire d’en‑tête/pied de page de chaque diapositive, définir le texte du pied de page et de la date/heure, activer les espaces réservés requis, puis enregistrer la présentation. Les numéros de diapositive sont générés par la présentation, vous n’avez donc besoin de contrôler que leur visibilité.

Utilisez [`SetFooterText`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) et [`SetDateTimeText`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) pour définir le texte, et utilisez [`SetFooterVisibility`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/) et [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) pour afficher les espaces réservés correspondants.

L’exemple complet suivant applique le même pied de page, le même texte de date/heure et la même visibilité du numéro de diapositive à toutes les diapositives ordinaires :

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

Si vous devez mettre à jour une seule diapositive, accédez directement à cette diapositive via [`Presentation::get_Slide`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_slide/) au lieu d’itérer sur l’ensemble de la collection de diapositives.

## **Définir les en‑têtes et pieds de page sur le masque de notes**

Le masque de notes définit la mise en forme commune et le comportement des espaces réservés pour les pages de notes. Utilisez l’interface [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasternotesslideheaderfootermanager/) lorsque vous souhaitez ne modifier que le masque de notes lui‑même.

L’exemple suivant définit le texte d’en‑tête, de pied de page et de date/heure sur le masque de notes et rend tous les espaces réservés pris en charge visibles sur ce masque :

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

La méthode [`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) renvoie `nullptr` lorsque la présentation ne contient pas de masque de notes.

## **Appliquer les paramètres du masque de notes aux diapositives de notes enfants**

Un masque de notes peut appliquer les paramètres d’en‑tête et de pied de page à lui‑même et à toutes les diapositives de notes dépendantes. Utilisez les méthodes de propagation dédiées sur [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasternotesslideheaderfootermanager/) lorsque les mêmes paramètres doivent être appliqués à toute la hiérarchie de notes.

Par exemple, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) et [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) mettent à jour l’en‑tête du masque de notes et tous les en‑têtes enfants. Des méthodes équivalentes sont disponibles pour les pieds de page, la date/heure et les numéros de diapositive.

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

Les méthodes de propagation utilisées ci‑above sont [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) et [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Définir les en‑têtes et pieds de page sur une diapositive de notes individuelle**

Une diapositive de notes appartient à une diapositive ordinaire spécifique. Utilisez son interface [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/inotesslideheaderfootermanager/) lorsque vous souhaitez ne personnaliser que cette page de notes.

La méthode [`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/inotesslidemanager/addnotesslide/) renvoie la diapositive de notes pour la diapositive courante et en crée une si elle n’existe pas déjà. L’exemple suivant configuration la page de notes associée à la première diapositive de la présentation :

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

Si vous propagez d’abord les paramètres depuis le masque de notes, puis modifiez une diapositive de notes individuelle, les paramètres ultérieurs par diapositive vous permettent de personnaliser cette page de notes de façon indépendante.

## **Définir les en‑têtes et pieds de page sur le masque du fascicule**

Les pages de fascicule utilisent le masque du fascicule pour leurs espaces réservés d’en‑tête, de pied de page, de date/heure et de numéro de page. Contrairement aux pages de notes, les paramètres du fascicule sont gérés via le masque du fascicule plutôt que via des fascicules individuels.

Utilisez [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) pour accéder au masque du fascicule. S’il n’est pas présent, appelez [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) pour créer le masque de fascicule par défaut.

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **Comprendre la portée et l’héritage**

Choisissez le gestionnaire d’en‑tête/pied de page qui correspond à la portée que vous souhaitez modifier :

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideheaderfootermanager/) modifie les paramètres de pied de page, de date/heure et de numéro de diapositive pour une diapositive ordinaire.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslideheaderfootermanager/) contrôle une diapositive de mise en page et peut propager les paramètres pris en charge aux diapositives dépendantes.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslideheaderfootermanager/) contrôle un masque de diapositive ordinaire et peut propager les paramètres pris en charge aux diapositives dépendantes.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasternotesslideheaderfootermanager/) contrôle le masque de notes et peut propager les paramètres à toutes les diapositives de notes dépendantes.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/inotesslideheaderfootermanager/) modifie une diapositive de notes et prend en charge un espace réservé d’en‑tête en plus du pied de page, de la date/heure et du numéro de diapositive.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) modifie le masque du fascicule et prend en charge les quatre types d’espace réservé.

Utilisez la propagation depuis un masque ou une mise en page lorsque le même paramètre doit s’appliquer à toute sa hiérarchie. Utilisez un gestionnaire de diapositive individuelle ou de diapositive de notes lorsque vous avez besoin d’un paramètre local pour une page.

## **FAQ**

**Puis-je ajouter un en‑tête à une diapositive ordinaire ?**

Non. PowerPoint ne définit pas d’espace réservé d’en‑tête pour les diapositives ordinaires. Sur les diapositives ordinaires, utilisez les espaces réservés de pied de page, de date/heure et de numéro de diapositive. Les espaces réservés d’en‑tête sont disponibles sur les pages de notes et les fascicules.

**Que faire si un espace réservé de pied de page, de date/heure ou de numéro de diapositive n’est pas visible ?**

Utilisez le gestionnaire d’en‑tête/pied de page correspondant pour vérifier sa visibilité et l’activer si nécessaire. Par exemple, [`get_IsFooterVisible`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) indique si un espace réservé de pied de page est présent, et [`SetFooterVisibility`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) modifie sa visibilité.

**Comment démarrer la numérotation des diapositives à partir d’une valeur autre que 1 ?**

Utilisez [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/set_firstslidenumber/) pour définir le numéro de la première diapositive. Les espaces réservés de numéro de diapositive utiliseront alors la séquence de numérotation mise à jour.

**Que se passe-t-il pour les en‑têtes et pieds de page lors de l’exportation en PDF, images ou HTML ?**

Les éléments d’en‑tête et de pied de page visibles sont rendus avec le reste du contenu de la présentation dans le format de sortie. Leur apparence dépend du type de page exporté et des paramètres de visibilité des espaces réservés correspondants.