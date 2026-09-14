---
title: Gestire le sezioni delle diapositive nelle presentazioni con Python via Java
linktitle: Sezione diapositiva
type: docs
weight: 90
url: /it/python-java/slide-section/
keywords:
- creare sezione
- aggiungere sezione
- modificare sezione
- cambiare sezione
- nome sezione
- recuperare diapositive di sezione
- elaborare diapositive di sezione
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Gestire le sezioni delle diapositive con Aspose.Slides per Python via Java: creare, rinominare, riordinare, recuperare ed elaborare le diapositive delle sezioni nelle presentazioni PPTX."
---
## **Introduzione**

Le sezioni organizzano diapositive consecutive in gruppi nominati senza modificare il contenuto delle diapositive. Con Aspose.Slides per Python tramite Java, è possibile creare, riordinare, rinominare, ispezionare e rimuovere le sezioni tramite il metodo [Presentation.getSections](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSections).

Le sezioni sono particolarmente utili quando:

- una presentazione di grandi dimensioni deve essere divisa in argomenti o capitoli logici;
- diversi gruppi di diapositive vengono assegnati a collaboratori diversi;
- le diapositive devono essere elaborate, spostate o unite come gruppi.

Scegli nomi di sezione concisi che descrivano lo scopo delle diapositive raggruppate. Poiché le sezioni fanno parte della struttura della presentazione, utilizza le API delle sezioni per determinare l'appartenenza invece di derivarla dalle posizioni delle diapositive.

## **Creare e gestire le sezioni**

Usa [SectionCollection.addSection](https://reference.aspose.com/slides/it/python-java/aspose.slides/sectioncollection/#addSection) per creare una sezione specificando il suo nome e la diapositiva iniziale. Aspose.Slides determina quali diapositive appartengono alla sezione dalla struttura delle sezioni corrente della presentazione.

La stessa [SectionCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/sectioncollection/) consente inoltre di:

- spostare una sezione insieme alle sue diapositive usando [reorderSectionWithSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- rimuovere solo la definizione della sezione con [removeSection](https://reference.aspose.com/slides/it/python-java/aspose.slides/sectioncollection/#removeSection), mantenendo le sue diapositive;
- rimuovere una sezione e le sue diapositive con [removeSectionWithSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/sectioncollection/#removeSectionwithslides);
- aggiungere una sezione vuota alla fine con [appendEmptySection](https://reference.aspose.com/slides/it/python-java/aspose.slides/sectioncollection/#appendEmptySection).

Il seguente esempio crea due sezioni, ne sposta una, la rimuove insieme alle sue diapositive e aggiunge una sezione vuota:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    title_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    results_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", title_slide)
    results_section = presentation.getSections().addSection("Results", results_slide)

    presentation.getSections().reorderSectionWithSlides(results_section, 0)
    presentation.getSections().removeSectionWithSlides(results_section)
    presentation.getSections().appendEmptySection("Appendix")
finally:
    presentation.dispose()
```

Dopo queste operazioni, la presentazione contiene la sezione `Introduction` con le sue diapositive e una sezione vuota `Appendix`. La sezione `Results` e le sue diapositive sono state rimosse.

## **Rinominare le sezioni**

Per rinominare una sezione, chiama il suo metodo [Section.setName](https://reference.aspose.com/slides/it/python-java/aspose.slides/section/#setName). Le diapositive e la posizione della sezione rimangono invariate.

Il seguente esempio crea una sezione e ne modifica il nome:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **Recuperare le diapositive dalle sezioni**

Il metodo [Presentation.getSections](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSections) restituisce una [SectionCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/sectioncollection/) che puoi iterare. Per ogni [Section](https://reference.aspose.com/slides/it/python-java/aspose.slides/section/), chiama [Section.getSlidesListOfSection](https://reference.aspose.com/slides/it/python-java/aspose.slides/section/#getSlidesListOfSection) per ottenere le diapositive che attualmente vi appartengono. Il metodo restituisce una [SectionSlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/sectionslidecollection/), che fornisce un conteggio, accesso indicizzato e iterazione.

Il seguente esempio crea due sezioni popolate e una sezione vuota, quindi stampa per ogni sezione il suo [name](https://reference.aspose.com/slides/it/python-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/it/python-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/it/python-java/aspose.slides/section/#getStartedFromSlide), il conteggio delle diapositive e i numeri delle diapositive. Usa [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/it/python-java/aspose.slides/sectionslidecollection/#get_Item) per leggere la prima diapositiva e una dichiarazione `for` per elaborare ogni diapositiva. Per la sezione vuota, la collezione restituita ha dimensione zero, il metodo non viene chiamato e l'iterazione non esegue alcuna operazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", first_slide)
    presentation.getSections().addSection("Details", third_slide)
    presentation.getSections().appendEmptySection("Appendix")

    for section in presentation.getSections():
        section_slides = section.getSlidesListOfSection()
        starting_slide = "none" if section.getStartedFromSlide() is None else str(section.getStartedFromSlide().getSlideNumber())

        print("Section: ", section.getName(), sep="")
        print("ID: ", section.getSectionId(), sep="")
        print("Starting slide: ", starting_slide, sep="")
        print("Slide count: ", section_slides.size(), sep="")

        if section_slides.size() > 0:
            print("First slide via get_Item: ", section_slides.get_Item(0).getSlideNumber(), sep="")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()
finally:
    presentation.dispose()
```

L'appartenenza a una sezione è determinata dalla struttura delle sezioni della presentazione. Non calcolare manualmente l'intervallo di una sezione da [Section.getStartedFromSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/section/#getStartedFromSlide), gli indici delle diapositive e la diapositiva iniziale della sezione successiva.

Le modifiche strutturali possono cambiare sia le diapositive restituite per una sezione sia i loro numeri. Ciò include il riordino delle diapositive, la clonazione di una diapositiva in una sezione, lo spostamento di una sezione insieme alle sue diapositive, la rimozione di diapositive e la rimozione di sezioni. Il prossimo esempio chiama [Section.getSlidesListOfSection](https://reference.aspose.com/slides/it/python-java/aspose.slides/section/#getSlidesListOfSection) dopo ogni modifica invece di mantenere ipotesi sui confini precedenti della sezione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    first_section = presentation.getSections().addSection("First", first_slide)
    second_section = presentation.getSections().addSection("Second", third_slide)

    def print_section_slides(label, section):
        section_slides = section.getSlidesListOfSection()
        print(f"{label} ({section_slides.size()} slides):", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.getSlidesListOfSection()
    presentation.getSlides().addClone(slides_before_clone.get_Item(0), first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.getSlidesListOfSection()
    first_section_position = slides_before_reorder.get_Item(0).getSlideNumber() - 1
    presentation.getSlides().reorder(first_section_position, slides_before_reorder.get_Item(slides_before_reorder.size() - 1))
    print_section_slides("After reordering slides", first_section)

    presentation.getSections().reorderSectionWithSlides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.getSlidesListOfSection()
    presentation.getSlides().remove(slides_before_removal.get_Item(0))
    print_section_slides("After removing a slide", first_section)

    presentation.getSections().removeSectionWithSlides(second_section)
    for section in presentation.getSections():
        print_section_slides("Remaining section", section)
finally:
    presentation.dispose()
```

Chiama nuovamente [Section.getSlidesListOfSection](https://reference.aspose.com/slides/it/python-java/aspose.slides/section/#getSlidesListOfSection) ogni volta che le diapositive o le sezioni vengono riordinate, clonate, spostate o rimosse. In questo modo l'elaborazione successiva rimane allineata con la struttura corrente della presentazione.

Il formato PPT (PowerPoint 97–2003) non conserva i metadati delle sezioni. Utilizza questo flusso di lavoro con un formato che supporta le sezioni, come PPTX; la conversione in PPT rimuove la struttura delle sezioni necessaria per l'iterazione successiva.

## **FAQ**

**Le sezioni sono conservate quando si salva nel formato PPT (PowerPoint 97–2003)?**

No. Il formato PPT non supporta i metadati delle sezioni, quindi il raggruppamento delle sezioni viene perso quando si salva in .ppt.

**È possibile "nascondere" un'intera sezione?**

No. Una sezione non ha uno stato di visibilità. Per nascondere il suo contenuto, chiama [Slide.setHidden](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#setHidden) per ogni diapositiva nella sezione.

**Come posso trovare la sezione che contiene una diapositiva?**

Itera sulla collezione restituita da [Presentation.getSections](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSections), chiama [Section.getSlidesListOfSection](https://reference.aspose.com/slides/it/python-java/aspose.slides/section/#getSlidesListOfSection) per ogni sezione e confronta le diapositive restituite con la diapositiva target. Per una sezione non vuota, [Section.getStartedFromSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/section/#getStartedFromSlide) restituisce la sua prima diapositiva; per una sezione vuota, restituisce `None`.