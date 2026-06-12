---
title: Gestisci le sezioni delle diapositive nelle presentazioni con Python
linktitle: Sezione diapositiva
type: docs
weight: 100
url: /it/python-net/slide-section/
keywords:
- crea sezione
- aggiungi sezione
- modifica sezione
- cambia sezione
- nome sezione
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Snellisci le sezioni delle diapositive in PowerPoint e OpenDocument con Aspose.Slides per Python — dividi, rinomina e riordina per ottimizzare i flussi di lavoro PPTX e ODP."
---
## **Introduzione**

Con Aspose.Slides per Python, è possibile organizzare una presentazione PowerPoint in sezioni che raggruppano diapositive specifiche.

Potresti voler creare sezioni per organizzare o suddividere una presentazione in parti logiche in queste situazioni:

- Quando lavori su una presentazione di grandi dimensioni con un team e devi assegnare determinate diapositive a colleghi specifici.
- Quando gestisci una presentazione con molte diapositive e trovi difficile gestire o modificare tutto in una volta.

Idealmente, crea sezioni che raggruppano diapositive correlate—quelle che condividono un tema, un argomento o uno scopo—e assegna a ciascuna sezione un nome che rifletta chiaramente il suo contenuto. 

## **Crea sezioni nelle presentazioni**

Per aggiungere una [Section](https://reference.aspose.com/slides/it/python-net/aspose.slides/section/) che raggruppa diapositive in una presentazione, Aspose.Slides fornisce il metodo [add_section](https://reference.aspose.com/slides/it/python-net/aspose.slides/sectioncollection/add_section/). Consente di specificare il nome della sezione e la diapositiva in cui la sezione inizia.

Il seguente esempio Python mostra come creare una sezione in una presentazione:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # La Sezione 1 termina alla diapositiva 2; La Sezione 2 inizia alla diapositiva 3.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **Modifica i nomi delle sezioni**

Dopo aver creato una [Section](https://reference.aspose.com/slides/it/python-net/aspose.slides/section/) in una presentazione PowerPoint, potresti decidere di cambiare il suo nome.

Il seguente esempio Python mostra come rinominare una sezione in una presentazione:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **FAQ**

**Le sezioni vengono mantenute salvando nel formato PPT (PowerPoint 97–2003)?**

No. Il formato PPT non supporta i metadati delle sezioni, quindi il raggruppamento delle sezioni viene perso quando si salva in .ppt.

**Può un'intera sezione essere "nascosta"?**

No. Solo le singole diapositive possono essere nascoste. Una sezione, in quanto entità, non ha uno stato "nascosto".

**Posso trovare rapidamente una sezione a partire da una diapositiva e, viceversa, la prima diapositiva di una sezione?**

Sì. Una sezione è definita in modo univoco dalla sua diapositiva iniziale; data una diapositiva è possibile determinare a quale sezione appartiene, e per una sezione è possibile accedere alla sua prima diapositiva.