---
title: Gestionar secciones de diapositivas en presentaciones con C++
linktitle: Sección de diapositiva
type: docs
weight: 100
url: /es/cpp/slide-section/
keywords:
- crear sección
- añadir sección
- editar sección
- cambiar sección
- nombre de sección
- recuperar diapositivas de sección
- procesar diapositivas de sección
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Gestiona las secciones de diapositivas con Aspose.Slides para C++: crea, renombra, reordena, recupera y procesa diapositivas de sección en presentaciones PPTX."
---
## **Introducción**

Las secciones organizan diapositivas consecutivas en grupos con nombre sin cambiar el contenido de la diapositiva. Con Aspose.Slides para C++, puedes crear, reordenar, renombrar, inspeccionar y eliminar secciones mediante el método [Presentation::get_Sections](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_sections/).

Las secciones son especialmente útiles cuando:

- una presentación grande necesita dividirse en temas o capítulos lógicos;
- diferentes grupos de diapositivas se asignan a diferentes colaboradores;
- las diapositivas necesitan ser procesadas, movidas o combinadas en grupos.

Elige nombres de sección concisos que describan el propósito de las diapositivas agrupadas. Dado que las secciones forman parte de la estructura de la presentación, utiliza las API de secciones para determinar la pertenencia en lugar de derivarla de las posiciones de las diapositivas.

## **Crear y gestionar secciones**

Utiliza [ISectionCollection::AddSection](https://reference.aspose.com/slides/es/cpp/aspose.slides/isectioncollection/addsection/) para crear una sección especificando su nombre y diapositiva inicial. Aspose.Slides determina qué diapositivas pertenecen a la sección a partir de la estructura de secciones actual de la presentación.

La misma [ISectionCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/isectioncollection/) también permite:

- mover una sección junto con sus diapositivas usando [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides/isectioncollection/reordersectionwithslides/);
- eliminar solo la definición de la sección con [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/es/cpp/aspose.slides/isectioncollection/removesection/), lo que conserva sus diapositivas;
- eliminar una sección y sus diapositivas con [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides/isectioncollection/removesectionwithslides/);
- añadir una sección vacía al final con [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/es/cpp/aspose.slides/isectioncollection/appendemptysection/).

El siguiente ejemplo crea dos secciones, mueve una de ellas, la elimina junto con sus diapositivas y añade una sección vacía:

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

Después de estas operaciones, la presentación contiene la sección `Introduction` con sus diapositivas y una sección vacía `Appendix`. La sección `Results` y sus diapositivas han sido eliminadas.

## **Renombrar secciones**

Para renombrar una sección, llama a [ISection::set_Name](https://reference.aspose.com/slides/es/cpp/aspose.slides/isection/set_name/). Las diapositivas y la posición de la sección permanecen sin cambios.

El siguiente ejemplo crea una sección y cambia su nombre:

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

## **Obtener diapositivas de las secciones**

El método [Presentation::get_Sections](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_sections/) devuelve una [ISectionCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/isectioncollection/) que puedes enumerar. Para cada [ISection](https://reference.aspose.com/slides/es/cpp/aspose.slides/isection/), llama a [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/es/cpp/aspose.slides/isection/getslideslistofsection/) para obtener las diapositivas que le pertenecen actualmente. El método devuelve una [ISectionSlideCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/isectionslidecollection/), que ofrece un recuento, acceso indexado y enumeración.

El siguiente ejemplo crea dos secciones pobladas y una sección vacía, luego muestra el nombre, identificador, diapositiva inicial, número de diapositivas y números de diapositiva de cada sección. Utiliza acceso indexado para leer la primera diapositiva y un bucle `for` basado en rango para procesar cada diapositiva. Para la sección vacía, la colección devuelta tiene un recuento de cero, no se usa acceso indexado y la enumeración no realiza iteraciones.

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

La pertenencia a una sección se determina por la estructura de secciones de la presentación. No calcules manualmente el rango de una sección a partir de [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/isection/get_startedfromslide/), índices de diapositivas y la diapositiva inicial de la siguiente sección.

Las ediciones estructurales pueden cambiar tanto las diapositivas devueltas para una sección como sus números de diapositiva. Esto incluye reordenar diapositivas, clonar una diapositiva en una sección, mover una sección junto con sus diapositivas, eliminar diapositivas y eliminar secciones. El siguiente ejemplo llama a [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/es/cpp/aspose.slides/isection/getslideslistofsection/) después de cada uno de estos cambios en lugar de mantener supuestos sobre los límites anteriores de la sección.

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

Llama a [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/es/cpp/aspose.slides/isection/getslideslistofsection/) nuevamente siempre que se reordenan, clonan, mueven o eliminan diapositivas o secciones. Esto mantiene el procesamiento posterior alineado con la estructura actual de la presentación.

El formato PPT (PowerPoint 97–2003) no conserva los metadatos de sección. Utiliza este flujo de trabajo con un formato que admita secciones, como PPTX; convertir a PPT elimina la estructura de secciones necesaria para la enumeración posterior.

## **Preguntas frecuentes**

**¿Se conservan las secciones al guardar en formato PPT (PowerPoint 97–2003)?**

No. El formato PPT no admite metadatos de sección, por lo que la agrupación de secciones se pierde al guardar en .ppt.

**¿Puede ocultarse una sección completa?**

No. Una sección no tiene estado de visibilidad. Para ocultar su contenido, llama a [ISlide::set_Hidden](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/set_hidden/) para cada diapositiva de la sección.

**¿Cómo puedo encontrar la sección que contiene una diapositiva?**

Enumera [Presentation::get_Sections](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_sections/), llama a [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/es/cpp/aspose.slides/isection/getslideslistofsection/) para cada sección y compara las diapositivas devueltas con la diapositiva objetivo. Para una sección no vacía, [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/isection/get_startedfromslide/) devuelve su primera diapositiva; para una sección vacía, devuelve `nullptr`.