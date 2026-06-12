---
title: Gestisci le sezioni delle diapositive nelle presentazioni usando C++
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
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Ottimizza le sezioni delle diapositive in PowerPoint e OpenDocument con Aspose.Slides per C++ — dividi, rinomina e riordina per ottimizzare i flussi di lavoro PPTX e ODP."
---
## **Introduzione**

Con Aspose.Slides per C++ è possibile organizzare una presentazione PowerPoint in sezioni. È possibile creare sezioni che contengono diapositive specifiche. 

Potresti voler creare sezioni e usarle per organizzare o dividere le diapositive di una presentazione in parti logiche in queste situazioni:

- Quando lavori su una presentazione di grandi dimensioni con altre persone o un team—e devi assegnare alcune diapositive a un collega o a membri del team. 
- Quando gestisci una presentazione che contiene molte diapositive—e hai difficoltà a gestire o modificare il suo contenuto tutto insieme.

Idealmente, dovresti creare una sezione che contiene diapositive simili—le diapositive hanno qualcosa in comune o possono esistere in un gruppo basato su una regola—e assegnare alla sezione un nome che descriva le diapositive contenute. 

## **Crea sezioni nelle presentazioni**

Per aggiungere una sezione che conterrà diapositive in una presentazione, Aspose.Slides per C++ fornisce il metodo AddSection che consente di specificare il nome della sezione da creare e la diapositiva da cui la sezione inizia. 

Questo esempio di codice mostra come creare una sezione in una presentazione in C++:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 terminerà a newSlide2 e dopo di esso inizierà section2   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## **Modifica i nomi delle sezioni**

Dopo aver creato una sezione in una presentazione PowerPoint, potresti decidere di cambiarne il nome. 

Questo esempio di codice mostra come cambiare il nome di una sezione in una presentazione in C++ usando Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```

## **FAQ**

**Le sezioni vengono conservate quando si salva nel formato PPT (PowerPoint 97–2003)?**

No. Il formato PPT non supporta i metadati delle sezioni, quindi il raggruppamento delle sezioni viene perso quando si salva in .ppt.

**Un'intera sezione può essere "nascosta"?**

No. Solo le singole diapositive possono essere nascoste. Una sezione, in quanto entità, non ha uno stato "nascosto".

**Posso trovare rapidamente una sezione a partire da una diapositiva e, al contrario, la prima diapositiva di una sezione?**

Sì. Una sezione è definita in modo univoco dalla sua diapositiva iniziale; data una diapositiva è possibile determinare a quale sezione appartiene, e per una sezione è possibile accedere alla sua prima diapositiva.