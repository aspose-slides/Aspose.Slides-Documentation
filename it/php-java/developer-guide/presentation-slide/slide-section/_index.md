---
title: Gestire le sezioni delle diapositive nelle presentazioni con PHP
linktitle: Sezione diapositiva
type: docs
weight: 90
url: /it/php-java/slide-section/
keywords:
- crea sezione
- aggiungi sezione
- modifica sezione
- cambia sezione
- nome sezione
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Ottimizza le sezioni delle diapositive in PowerPoint e OpenDocument con Aspose.Slides per PHP tramite Java — dividile, rinominale e riordinale per ottimizzare i flussi di lavoro PPTX e ODP."
---
## **Introduzione**

Con Aspose.Slides per PHP tramite Java, è possibile organizzare una presentazione PowerPoint in sezioni. È possibile creare sezioni che contengono diapositive specifiche.

Potresti voler creare sezioni e usarle per organizzare o dividere le diapositive di una presentazione in parti logiche in queste situazioni:

- Quando si lavora su una presentazione di grandi dimensioni con altre persone o un team—e si deve assegnare determinate diapositive a un collega o a alcuni membri del team. 
- Quando si gestisce una presentazione che contiene molte diapositive—e si ha difficoltà a gestire o modificare tutto il contenuto in una volta.

Idealmente, dovresti creare una sezione che contenga diapositive simili—le diapositive hanno qualcosa in comune o possono far parte di un gruppo basato su una regola—e assegnare alla sezione un nome che descriva le diapositive al suo interno. 

## **Creare sezioni nelle presentazioni**

Per aggiungere una sezione che contenga diapositive in una presentazione, Aspose.Slides per PHP tramite Java fornisce il metodo [addSection()](https://reference.aspose.com/slides/it/php-java/aspose.slides/sectioncollection/#addSection) che consente di specificare il nome della sezione da creare e la diapositiva da cui la sezione inizia.

Il seguente codice di esempio mostra come creare una sezione in una presentazione:

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 verrà terminata a newSlide2 e dopo di essa section2 inizierà

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modificare i nomi delle sezioni**

Dopo aver creato una sezione in una presentazione PowerPoint, potresti decidere di cambiare il suo nome. 

Il seguente codice di esempio mostra come cambiare il nome di una sezione in una presentazione utilizzando Aspose.Slides:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Le sezioni vengono conservate quando si salva nel formato PPT (PowerPoint 97–2003)?**

No. Il formato PPT non supporta i metadati delle sezioni, quindi il raggruppamento delle sezioni viene perso quando si salva in .ppt.

**È possibile nascondere un'intera sezione?**

No. È possibile nascondere solo le singole diapositive. Una sezione, in quanto entità, non ha uno stato "nascosto".

**È possibile trovare rapidamente una sezione a partire da una diapositiva e, viceversa, la prima diapositiva di una sezione?**

Sì. Una sezione è definita in modo univoco dalla diapositiva iniziale; data una diapositiva è possibile determinare a quale sezione appartiene e, per una sezione, è possibile accedere alla sua prima diapositiva.