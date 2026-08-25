---
title: Gestisci le sezioni delle diapositive nelle presentazioni con Python
linktitle: Sezione Diapositiva
type: docs
weight: 100
url: /it/python-net/slide-section/
keywords:
- creare sezione
- aggiungere sezione
- modificare sezione
- cambiare sezione
- nome sezione
- recuperare diapositive sezione
- elaborare diapositive sezione
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Gestisci le sezioni delle diapositive con Aspose.Slides per Python via .NET: crea, rinomina, riordina, recupera ed elabora le diapositive delle sezioni nelle presentazioni PPTX."
---
## **Introduzione**

Le sezioni organizzano le diapositive consecutive in gruppi denominati senza modificare il contenuto delle diapositive. Con Aspose.Slides per Python via .NET, è possibile creare, riordinare, rinominare, ispezionare e rimuovere le sezioni tramite la proprietà [Presentation.sections](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/sections/) .

Le sezioni sono particolarmente utili quando:

- una presentazione di grandi dimensioni deve essere suddivisa in argomenti o capitoli logici;
- diversi gruppi di diapositive sono assegnati a collaboratori diversi;
- le diapositive devono essere elaborate, spostate o unite come gruppi.

Scegliere nomi di sezione concisi che descrivano lo scopo delle diapositive raggruppate. Poiché le sezioni fanno parte della struttura della presentazione, utilizzare le API delle sezioni per determinare l'appartenenza invece di derivarla dalle posizioni delle diapositive.

## **Crea e gestisci le sezioni**

Utilizzare [SectionCollection.add_section](https://reference.aspose.com/slides/it/python-net/aspose.slides/sectioncollection/add_section/) per creare una sezione specificando il suo nome e la diapositiva iniziale. Aspose.Slides determina quali diapositive appartengono alla sezione dalla struttura di sezione corrente della presentazione.

La stessa [SectionCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/sectioncollection/) consente anche di:

- spostare una sezione insieme alle sue diapositive usando [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/);
- rimuovere solo la definizione della sezione con [SectionCollection.remove_section](https://reference.aspose.com/slides/it/python-net/aspose.slides/sectioncollection/remove_section/), che mantiene le sue diapositive;
- rimuovere una sezione e le sue diapositive con [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/sectioncollection/remove_section_with_slides/);
- aggiungere una sezione vuota alla fine con [SectionCollection.append_empty_section](https://reference.aspose.com/slides/it/python-net/aspose.slides/sectioncollection/append_empty_section/).

Il seguente esempio crea due sezioni, sposta una di esse, la rimuove insieme alle sue diapositive e aggiunge una sezione vuota:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    title_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    results_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", title_slide)
    results_section = presentation.sections.add_section("Results", results_slide)

    presentation.sections.reorder_section_with_slides(results_section, 0)
    presentation.sections.remove_section_with_slides(results_section)
    presentation.sections.append_empty_section("Appendix")
```

Dopo queste operazioni, la presentazione contiene la sezione `Introduction` con le sue diapositive e una sezione `Appendix` vuota. La sezione `Results` e le sue diapositive sono state rimosse.

## **Rinomina le sezioni**

Per rinominare una sezione, impostare la sua proprietà [Section.name](https://reference.aspose.com/slides/it/python-net/aspose.slides/section/name/). Le diapositive e la posizione della sezione rimangono invariate.

Il seguente esempio crea una sezione e ne cambia il nome:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **Recupera le diapositive dalle sezioni**

La proprietà [Presentation.sections](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/sections/) restituisce una [SectionCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/sectioncollection/) su cui è possibile iterare. Per ogni [Section](https://reference.aspose.com/slides/it/python-net/aspose.slides/section/), chiamare [Section.get_slides_list_of_section](https://reference.aspose.com/slides/it/python-net/aspose.slides/section/get_slides_list_of_section/) per ottenere le diapositive che attualmente le appartengono. Il metodo restituisce una [SectionSlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/sectionslidecollection/), che fornisce un conteggio, accesso indicizzato e iterazione.

Il seguente esempio crea due sezioni popolate e una sezione vuota, quindi stampa per ogni sezione il [name](https://reference.aspose.com/slides/it/python-net/aspose.slides/section/name/), l'[identifier](https://reference.aspose.com/slides/it/python-net/aspose.slides/section/section_id/), la [starting slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/section/started_from_slide/), il conteggio delle diapositive e i numeri delle diapositive. Utilizza l'accesso indicizzato per leggere la prima diapositiva e un ciclo `for` per elaborare ogni diapositiva. Per la sezione vuota, la collezione restituita ha un conteggio pari a zero, l'indice non è accessibile e l'iterazione non esegue passaggi.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", first_slide)
    presentation.sections.add_section("Details", third_slide)
    presentation.sections.append_empty_section("Appendix")

    for section in presentation.sections:
        section_slides = section.get_slides_list_of_section()
        starting_slide = "none" if section.started_from_slide is None else str(section.started_from_slide.slide_number)

        print(f"Section: {section.name}")
        print(f"ID: {section.section_id}")
        print(f"Starting slide: {starting_slide}")
        print(f"Slide count: {section_slides.count}")

        if section_slides.count > 0:
            print(f"First slide via index: {section_slides[0].slide_number}")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(f" {slide.slide_number}", end="")
        print()
```

L'appartenenza a una sezione è determinata dalla struttura delle sezioni della presentazione. Non calcolare manualmente l'intervallo di una sezione da [Section.started_from_slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/section/started_from_slide/), dagli indici delle diapositive e dalla diapositiva iniziale della sezione successiva.

Le modifiche strutturali possono cambiare sia le diapositive restituite per una sezione sia i loro numeri. Ciò include riordinare le diapositive, clonare una diapositiva in una sezione, spostare una sezione insieme alle sue diapositive, rimuovere diapositive e rimuovere sezioni. Il prossimo esempio chiama [Section.get_slides_list_of_section](https://reference.aspose.com/slides/it/python-net/aspose.slides/section/get_slides_list_of_section/) dopo ogni modifica di questo tipo invece di mantenere ipotesi sui precedenti limiti della sezione.

```py
import aspose.slides as slides


def print_section_slides(label, section):
    section_slides = section.get_slides_list_of_section()
    print(f"{label} ({section_slides.count} slides):", end="")
    for slide in section_slides:
        print(f" {slide.slide_number}", end="")
    print()


with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    first_section = presentation.sections.add_section("First", first_slide)
    second_section = presentation.sections.add_section("Second", third_slide)

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.get_slides_list_of_section()
    presentation.slides.add_clone(slides_before_clone[0], first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.get_slides_list_of_section()
    first_section_position = slides_before_reorder[0].slide_number - 1
    presentation.slides.reorder(first_section_position, slides_before_reorder[slides_before_reorder.count - 1])
    print_section_slides("After reordering slides", first_section)

    presentation.sections.reorder_section_with_slides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.get_slides_list_of_section()
    presentation.slides.remove(slides_before_removal[0])
    print_section_slides("After removing a slide", first_section)

    presentation.sections.remove_section_with_slides(second_section)
    for section in presentation.sections:
        print_section_slides("Remaining section", section)
```

Richiamare nuovamente [Section.get_slides_list_of_section](https://reference.aspose.com/slides/it/python-net/aspose.slides/section/get_slides_list_of_section/) ogni volta che diapositive o sezioni sono riordinate, clonate, spostate o rimosse. Ciò mantiene l'elaborazione successiva allineata con la struttura attuale della presentazione.

Il formato PPT (PowerPoint 97–2003) non conserva i metadati delle sezioni. Utilizzare questo flusso di lavoro con un formato che supporta le sezioni, come PPTX; la conversione in PPT rimuove la struttura delle sezioni necessaria per l'iterazione successiva.

## **FAQ**

**Le sezioni vengono conservate quando si salva nel formato PPT (PowerPoint 97–2003)?**

No. Il formato PPT non supporta i metadati delle sezioni, quindi il raggruppamento delle sezioni viene perso quando si salva in .ppt.

**È possibile "nascondere" un'intera sezione?**

No. Una sezione non ha uno stato di visibilità. Per nascondere il suo contenuto, impostare la proprietà [Slide.hidden](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/hidden/) per ogni diapositiva nella sezione.

**Come posso trovare la sezione che contiene una diapositiva?**

Iterare su [Presentation.sections](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/sections/), chiamare [Section.get_slides_list_of_section](https://reference.aspose.com/slides/it/python-net/aspose.slides/section/get_slides_list_of_section/) per ogni sezione e confrontare le diapositive restituite con la diapositiva target. Per una sezione non vuota, [Section.started_from_slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/section/started_from_slide/) restituisce la sua prima diapositiva; per una sezione vuota, restituisce `None`.