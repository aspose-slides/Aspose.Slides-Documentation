---
title: Gestisci le sezioni delle diapositive nelle presentazioni con C++
linktitle: Sezione diapositiva
type: docs
weight: 100
url: /it/cpp/slide-section/
keywords:
- crea sezione
- aggiungi sezione
- modifica sezione
- cambia sezione
- nome sezione
- recupera diapositive sezione
- elabora diapositive sezione
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Gestisci le sezioni delle diapositive con Aspose.Slides per C++: crea, rinomina, riordina, recupera ed elabora le diapositive delle sezioni nelle presentazioni PPTX."
---
## **Introduzione**

Le sezioni organizzano diapositive consecutive in gruppi nominati senza modificare il contenuto della diapositiva. Con Aspose.Slides per C++, è possibile creare, riordinare, rinominare, ispezionare e rimuovere le sezioni tramite il metodo [Presentation::get_Sections](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_sections/).

Le sezioni sono particolarmente utili quando:

- una presentazione di grandi dimensioni deve essere divisa in argomenti o capitoli logici;
- diversi gruppi di diapositive sono assegnati a collaboratori diversi;
- le diapositive devono essere elaborate, spostate o unite come gruppi.

Scegliere nomi di sezione concisi che descrivano lo scopo delle diapositive raggruppate. Poiché le sezioni fanno parte della struttura della presentazione, utilizzare le API delle sezioni per determinare l'appartenenza invece di ricavarla dalle posizioni delle diapositive.

## **Crea e gestisci le sezioni**

Utilizzare [ISectionCollection::AddSection](https://reference.aspose.com/slides/it/cpp/aspose.slides/isectioncollection/addsection/) per creare una sezione specificando il suo nome e la diapositiva di inizio. Aspose.Slides determina a quali diapositive appartiene la sezione dalla struttura delle sezioni corrente della presentazione.

Lo stesso [ISectionCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/isectioncollection/) consente anche di:

- spostare una sezione insieme alle sue diapositive usando [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides/isectioncollection/reordersectionwithslides/);
- rimuovere solo la definizione della sezione con [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/it/cpp/aspose.slides/isectioncollection/removesection/), che conserva le sue diapositive;
- rimuovere una sezione e le sue diapositive con [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides/isectioncollection/removesectionwithslides/);
- aggiungere una sezione vuota alla fine con [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/it/cpp/aspose.slides/isectioncollection/appendemptysection/).

Il seguente esempio crea due sezioni, sposta una di esse, la rimuove insieme alle sue diapositive e aggiunge una sezione vuota:

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

Dopo queste operazioni, la presentazione contiene la sezione `Introduction` con le sue diapositive e una sezione vuota `Appendix`. La sezione `Results` e le sue diapositive sono state rimosse.

## **Rinomina le sezioni**

Per rinominare una sezione, chiamare [ISection::set_Name](https://reference.aspose.com/slides/it/cpp/aspose.slides/isection/set_name/). Le diapositive e la posizione della sezione rimangono inalterate.

Il seguente esempio crea una sezione e ne modifica il nome:

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

## **Recupera diapositive dalle sezioni**

Il metodo [Presentation::get_Sections](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_sections/) restituisce un [ISectionCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/isectioncollection/) che è possibile enumerare. Per ogni [ISection](https://reference.aspose.com/slides/it/cpp/aspose.slides/isection/), chiamare [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/it/cpp/aspose.slides/isection/getslideslistofsection/) per ottenere le diapositive che attualmente vi appartengono. Il metodo restituisce un [ISectionSlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/isectionslidecollection/), che fornisce un conteggio, accesso indicizzato ed enumerazione.

Il seguente esempio crea due sezioni popolate e una sezione vuota, quindi stampa per ogni sezione il suo [nome](https://reference.aspose.com/slides/it/cpp/aspose.slides/isection/get_name/), [identificatore](https://reference.aspose.com/slides/it/cpp/aspose.slides/isection/get_sectionid/), [diapositiva di avvio](https://reference.aspose.com/slides/it/cpp/aspose.slides/isection/get_startedfromslide/), il conteggio delle diapositive e i numeri delle diapositive. Utilizza l'accesso indicizzato per leggere la prima diapositiva e un ciclo `for` basato su intervallo per elaborare ogni diapositiva. Per la sezione vuota, la collezione restituita ha un conteggio pari a zero, l'accesso indicizzato non è utilizzato e l'enumerazione non esegue iterazioni.

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

L'appartenenza a una sezione è determinata dalla struttura delle sezioni della presentazione. Non calcolare manualmente l'intervallo di una sezione a partire da [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/isection/get_startedfromslide/), dagli indici delle diapositive e dalla diapositiva di avvio della sezione successiva.

Le modifiche strutturali possono cambiare sia le diapositive restituite per una sezione sia i loro numeri. Ciò include il riordino delle diapositive, la clonazione di una diapositiva in una sezione, lo spostamento di una sezione insieme alle sue diapositive, la rimozione di diapositive e la rimozione di sezioni. Il prossimo esempio chiama [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/it/cpp/aspose.slides/isection/getslideslistofsection/) dopo ogni tale cambiamento invece di mantenere ipotesi sui confini precedenti della sezione.

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

Chiamare nuovamente [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/it/cpp/aspose.slides/isection/getslideslistofsection/) ogni volta che diapositive o sezioni sono riordinate, clonate, spostate o rimosse. In questo modo l'elaborazione successiva rimane allineata alla struttura corrente della presentazione.

Il formato PPT (PowerPoint 97–2003) non conserva i metadati delle sezioni. Utilizzare questo flusso di lavoro con un formato che supporta le sezioni, ad esempio PPTX; la conversione in PPT rimuove la struttura delle sezioni necessaria per l'enumerazione successiva.

## **FAQ**

**Le sezioni vengono conservate quando si salva nel formato PPT (PowerPoint 97–2003)?**

No. Il formato PPT non supporta i metadati delle sezioni, quindi il raggruppamento delle sezioni viene perso quando si salva in .ppt.

**È possibile nascondere un'intera sezione?**

No. Una sezione non ha uno stato di visibilità. Per nascondere il suo contenuto, chiamare [ISlide::set_Hidden](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/set_hidden/) per ogni diapositiva nella sezione.

**Come posso trovare la sezione che contiene una diapositiva?**

Enumerare [Presentation::get_Sections](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_sections/), chiamare [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/it/cpp/aspose.slides/isection/getslideslistofsection/) per ogni sezione e confrontare le diapositive restituite con la diapositiva target. Per una sezione non vuota, [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/isection/get_startedfromslide/) restituisce la sua prima diapositiva; per una sezione vuota, restituisce `nullptr`.