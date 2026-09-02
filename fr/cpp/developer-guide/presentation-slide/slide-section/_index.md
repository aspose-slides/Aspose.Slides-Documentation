---
title: Gérer les sections de diapositives dans les présentations avec C++
linktitle: Section de diapositive
type: docs
weight: 100
url: /fr/cpp/slide-section/
keywords:
- créer une section
- ajouter une section
- modifier une section
- changer une section
- nom de la section
- récupérer les diapositives de la section
- traiter les diapositives de la section
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Gérez les sections de diapositives avec Aspose.Slides pour C++ : créez, renommez, réorganisez, récupérez et traitez les diapositives de section dans les présentations PPTX."
---
## **Introduction**

Les sections organisent les diapositives consécutives en groupes nommés sans modifier le contenu des diapositives. Avec Aspose.Slides pour C++, vous pouvez créer, réorganiser, renommer, inspecter et supprimer des sections via la méthode [Presentation::get_Sections](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_sections/).

Les sections sont particulièrement utiles lorsque :

- une grande présentation doit être divisée en sujets ou chapitres logiques ;
- différents groupes de diapositives sont attribués à différents collaborateurs ;
- les diapositives doivent être traitées, déplacées ou fusionnées en groupes.

Choisissez des noms de sections concis qui décrivent le but des diapositives groupées. Comme les sections font partie de la structure de la présentation, utilisez les API de section pour déterminer l’appartenance plutôt que de la déduire à partir des positions des diapositives.

## **Créer et gérer les sections**

Utilisez [ISectionCollection::AddSection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isectioncollection/addsection/) pour créer une section en précisant son nom et la diapositive de départ. Aspose.Slides détermine quelles diapositives appartiennent à la section à partir de la structure actuelle des sections de la présentation.

Le même [ISectionCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isectioncollection/) vous permet également de :

- déplacer une section avec ses diapositives en utilisant [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isectioncollection/reordersectionwithslides/) ;
- supprimer uniquement la définition de la section avec [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isectioncollection/removesection/), ce qui conserve ses diapositives ;
- supprimer une section et ses diapositives avec [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isectioncollection/removesectionwithslides/) ;
- ajouter une section vide à la fin avec [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isectioncollection/appendemptysection/).

L’exemple suivant crée deux sections, déplace l’une d’elles, la supprime avec ses diapositives, puis ajoute une section vide :

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto titleSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto resultsSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", titleSlide);
auto resultsSection = sections->AddSection(u"Results", resultsSlide);

sections->ReorderSectionWithSlides(resultsSection, 0);
sections->RemoveSectionWithSlides(resultsSection);
sections->AppendEmptySection(u"Appendix");
```

Après ces opérations, la présentation contient la section `Introduction` avec ses diapositives et une section vide `Appendix`. La section `Results` et ses diapositives ont été supprimées.

## **Renommer les sections**

Pour renommer une section, appelez [ISection::set_Name](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isection/set_name/). Les diapositives et la position de la section restent inchangées.

L’exemple suivant crée une section et en modifie le nom :

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto section = presentation->get_Sections()->AddSection(u"Overview", slide);
section->set_Name(u"Introduction");
```

## **Récupérer les diapositives des sections**

La méthode [Presentation::get_Sections](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_sections/) renvoie une [ISectionCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isectioncollection/) que vous pouvez parcourir. Pour chaque [ISection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isection/), appelez [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isection/getslideslistofsection/) afin d’obtenir les diapositives qui lui appartiennent actuellement. La méthode renvoie une [ISectionSlideCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isectionslidecollection/), qui fournit un compteur, un accès indexé et une énumération.

L’exemple suivant crée deux sections remplies et une section vide, puis affiche le [nom](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isection/get_name/), l’[identifiant](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isection/get_sectionid/), la [diapositive de départ](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isection/get_startedfromslide/), le nombre de diapositives et les numéros de diapositives de chaque section. Il utilise l’accès indexé pour lire la première diapositive et une boucle `for` basée sur la portée pour traiter chaque diapositive. Pour la section vide, la collection renvoyée a un compteur de zéro, l’accès indexé n’est pas utilisé et l’énumération ne s’exécute pas.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", firstSlide);
sections->AddSection(u"Details", thirdSlide);
sections->AppendEmptySection(u"Appendix");

for (const auto& section : sections)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    auto startingSlide = section->get_StartedFromSlide();

    System::Console::WriteLine(u"Section: {0}", section->get_Name());
    System::Console::WriteLine(u"ID: {0}", section->get_SectionId().ToString());
    if (startingSlide == nullptr)
    {
        System::Console::WriteLine(u"Starting slide: none");
    }
    else
    {
        System::Console::WriteLine(u"Starting slide: {0}", startingSlide->get_SlideNumber());
    }
    System::Console::WriteLine(u"Slide count: {0}", sectionSlides->get_Count());

    if (sectionSlides->get_Count() > 0)
    {
        System::Console::WriteLine(u"First slide via index: {0}", sectionSlides->idx_get(0)->get_SlideNumber());
    }

    System::Console::Write(u"Slide numbers:");
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
}
```

L’appartenance à une section est déterminée par la structure des sections de la présentation. Ne calculez pas manuellement la plage d’une section à partir de [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isection/get_startedfromslide/), des index de diapositives et de la diapositive de départ de la section suivante.

Les modifications structurelles peuvent modifier à la fois les diapositives renvoyées pour une section et leurs numéros. Cela inclut le réordonnancement des diapositives, la duplication d’une diapositive dans une section, le déplacement d’une section avec ses diapositives, la suppression de diapositives et la suppression de sections. L’exemple suivant appelle [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isection/getslideslistofsection/) après chaque changement au lieu de conserver des hypothèses sur les anciennes limites de la section.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
auto firstSection = sections->AddSection(u"First", firstSlide);
auto secondSection = sections->AddSection(u"Second", thirdSlide);

auto printSectionSlides = [](const System::String& label, const System::SharedPtr<ISection>& section)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    System::Console::Write(u"{0} ({1} slides):", label, sectionSlides->get_Count());
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
};

printSectionSlides(u"Initially", firstSection);

auto slidesBeforeClone = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->AddClone(slidesBeforeClone->idx_get(0), firstSection);
printSectionSlides(u"After cloning into the section", firstSection);

auto slidesBeforeReorder = firstSection->GetSlidesListOfSection();
auto firstSlideInSection = slidesBeforeReorder->idx_get(0);
auto lastSlideInSection = slidesBeforeReorder->idx_get(slidesBeforeReorder->get_Count() - 1);
auto firstSectionPosition = firstSlideInSection->get_SlideNumber() - 1;
presentation->get_Slides()->Reorder(firstSectionPosition, lastSlideInSection);
printSectionSlides(u"After reordering slides", firstSection);

sections->ReorderSectionWithSlides(firstSection, 1);
printSectionSlides(u"After moving the section", firstSection);

auto slidesBeforeRemoval = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->Remove(slidesBeforeRemoval->idx_get(0));
printSectionSlides(u"After removing a slide", firstSection);

sections->RemoveSectionWithSlides(secondSection);
for (const auto& section : sections)
{
    printSectionSlides(u"Remaining section", section);
}
```

Appelez à nouveau [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isection/getslideslistofsection/) chaque fois que des diapositives ou des sections sont réordonnées, dupliquées, déplacées ou supprimées. Cela maintient le traitement ultérieur aligné avec la structure actuelle de la présentation.

Le format PPT (PowerPoint 97–2003) ne conserve pas les métadonnées de section. Utilisez ce flux de travail avec un format qui prend en charge les sections, tel que PPTX ; la conversion vers PPT supprime la structure de section nécessaire pour les énumérations ultérieures.

## **FAQ**

**Les sections sont-elles conservées lors de l'enregistrement au format PPT (PowerPoint 97–2003) ?**

Non. Le format PPT ne prend pas en charge les métadonnées de section, de sorte que le regroupement des sections est perdu lors de l'enregistrement au format .ppt.

**Une section entière peut-elle être « masquée » ?**

Non. Une section n'a aucun état de visibilité. Pour masquer son contenu, appelez [ISlide::set_Hidden](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/set_hidden/) pour chaque diapositive de la section.

**Comment puis‑je trouver la section qui contient une diapositive ?**

Parcourez [Presentation::get_Sections](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_sections/), appelez [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isection/getslideslistofsection/) pour chaque section, et comparez les diapositives renvoyées avec la diapositive cible. Pour une section non vide, [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isection/get_startedfromslide/) renvoie sa première diapositive ; pour une section vide, il renvoie `nullptr`.