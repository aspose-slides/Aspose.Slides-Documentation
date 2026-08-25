---
title: "Gerenciar Seções de Slides em Apresentações com C++"
linktitle: "Seção de Slide"
type: docs
weight: 100
url: /pt/cpp/slide-section/
keywords:
- criar seção
- adicionar seção
- editar seção
- alterar seção
- nome da seção
- recuperar slides da seção
- processar slides da seção
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Gerencie seções de slides com Aspose.Slides para C++: crie, renomeie, reordene, recupere e processe slides de seção em apresentações PPTX."
---
## **Introdução**

Seções organizam slides consecutivos em grupos nomeados sem alterar o conteúdo dos slides. Com Aspose.Slides for C++, você pode criar, reorganizar, renomear, inspecionar e remover seções através do método [Presentation::get_Sections](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_sections/).

Seções são especialmente úteis quando:

- uma apresentação grande precisa ser dividida em tópicos ou capítulos lógicos;
- diferentes grupos de slides são atribuídos a diferentes colaboradores;
- slides precisam ser processados, movidos ou mesclados como grupos.

Escolha nomes de seção concisos que descrevam o propósito dos slides agrupados. Como as seções fazem parte da estrutura da apresentação, use as APIs de seção para determinar a associação em vez de derivá‑la a partir das posições dos slides.

## **Criar e Gerenciar Seções**

Use [ISectionCollection::AddSection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isectioncollection/addsection/) para criar uma seção especificando seu nome e slide inicial. Aspose.Slides determina quais slides pertencem à seção a partir da estrutura de seções atual da apresentação.

A mesma [ISectionCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isectioncollection/) também permite:

- mover uma seção junto com seus slides usando [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isectioncollection/reordersectionwithslides/);
- remover apenas a definição da seção com [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isectioncollection/removesection/), que mantém seus slides;
- remover uma seção e seus slides com [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isectioncollection/removesectionwithslides/);
- adicionar uma seção vazia ao final com [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isectioncollection/appendemptysection/).

O exemplo a seguir cria duas seções, move uma delas, a remove junto com seus slides e adiciona uma seção vazia:

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

Após essas operações, a apresentação contém a seção `Introduction` com seus slides e uma seção vazia `Appendix`. A seção `Results` e seus slides foram removidos.

## **Renomear Seções**

Para renomear uma seção, chame [ISection::set_Name](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isection/set_name/). Os slides e a posição da seção permanecem inalterados.

O exemplo a seguir cria uma seção e altera seu nome:

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

## **Obter Slides das Seções**

O método [Presentation::get_Sections](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_sections/) devolve uma [ISectionCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isectioncollection/) que pode ser percorrida. Para cada [ISection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isection/), chame [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isection/getslideslistofsection/) para obter os slides que atualmente pertencem a ela. O método devolve uma [ISectionSlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isectionslidecollection/), que fornece contagem, acesso indexado e enumeração.

O exemplo a seguir cria duas seções preenchidas e uma seção vazia, então imprime o [nome](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isection/get_name/), o [identificador](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isection/get_sectionid/), o [slide inicial](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isection/get_startedfromslide/), a contagem de slides e os números dos slides de cada seção. Ele usa acesso indexado para ler o primeiro slide e um laço `for` baseado em intervalo para processar cada slide. Para a seção vazia, a coleção retornada tem contagem zero, o acesso indexado não é usado e a enumeração não executa iterações.

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

A associação a seções é determinada pela estrutura de seções da apresentação. Não calcule manualmente o intervalo de uma seção a partir de [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isection/get_startedfromslide/), índices de slides e o slide inicial da próxima seção.

Edições estruturais podem alterar tanto os slides retornados para uma seção quanto seus números de slide. Isso inclui reorganizar slides, clonar um slide em uma seção, mover uma seção junto com seus slides, remover slides e remover seções. O próximo exemplo chama [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isection/getslideslistofsection/) após cada uma dessas alterações, em vez de manter suposições sobre os limites anteriores da seção.

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

Chame [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isection/getslideslistofsection/) novamente sempre que slides ou seções forem reorganizados, clonados, movidos ou removidos. Isso mantém o processamento subsequente alinhado com a estrutura atual da apresentação.

O formato PPT (PowerPoint 97–2003) não preserva metadados de seção. Use este fluxo de trabalho com um formato que suporte seções, como PPTX; a conversão para PPT remove a estrutura de seções necessária para enumerações posteriores.

## **Perguntas Frequentes**

**As seções são preservadas ao salvar no formato PPT (PowerPoint 97–2003)?**

Não. O formato PPT não suporta metadados de seção, portanto o agrupamento de seções é perdido ao salvar como .ppt.

**É possível “esconder” uma seção inteira?**

Não. Uma seção não possui estado de visibilidade. Para ocultar seu conteúdo, chame [ISlide::set_Hidden](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/set_hidden/) para cada slide da seção.

**Como posso encontrar a seção que contém um slide?**

Percorra [Presentation::get_Sections](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_sections/), chame [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isection/getslideslistofsection/) para cada seção e compare os slides retornados com o slide alvo. Para uma seção não vazia, [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isection/get_startedfromslide/) devolve seu primeiro slide; para uma seção vazia, ele devolve `nullptr`.