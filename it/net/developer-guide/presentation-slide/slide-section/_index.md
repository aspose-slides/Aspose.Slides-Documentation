---
title: Gestire le sezioni delle diapositive nelle presentazioni in .NET
linktitle: Sezione diapositiva
type: docs
weight: 100
url: /it/net/slide-section/
keywords:
- creare sezione
- aggiungere sezione
- modificare sezione
- cambiare sezione
- nome della sezione
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Semplifica le sezioni delle diapositive in PowerPoint e OpenDocument con Aspose.Slides per .NET — dividi, rinomina e riordina per ottimizzare i flussi di lavoro PPTX e ODP."
---
## **Introduzione**

Con Aspose.Slides per .NET, è possibile organizzare una presentazione PowerPoint in sezioni. Puoi creare sezioni che contengono diapositive specifiche. 

Potresti voler creare sezioni e usarle per organizzare o dividere le diapositive di una presentazione in parti logiche in queste situazioni:

- Quando lavori su una presentazione di grandi dimensioni con altre persone o un team—e devi assegnare determinate diapositive a un collega o a dei membri del team. 
- Quando hai a che fare con una presentazione che contiene molte diapositive—e fai fatica a gestire o modificare tutto il contenuto in una volta.

Idealmente, dovresti creare una sezione che raggruppi diapositive simili—le diapositive hanno qualcosa in comune o possono esistere in un gruppo basato su una regola—e dare alla sezione un nome che descriva le diapositive al suo interno. 

## **Creare sezioni nelle presentazioni**

Per aggiungere una sezione che conterrà diapositive in una presentazione, Aspose.Slides per .NET fornisce il metodo AddSection che consente di specificare il nome della sezione da creare e la diapositiva da cui la sezione inizia. 

Questo esempio di codice mostra come creare una sezione in una presentazione in C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 terminerà a newSlide2 e dopo di esso inizierà section2   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## **Modificare i nomi delle sezioni**

Dopo aver creato una sezione in una presentazione PowerPoint, potresti decidere di cambiarne il nome. 

Questo esempio di codice mostra come modificare il nome di una sezione in una presentazione in C# usando Aspose.Slides:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```

## **FAQ**

**Le sezioni vengono conservate quando si salva nel formato PPT (PowerPoint 97–2003)?**

No. Il formato PPT non supporta i metadati delle sezioni, quindi il raggruppamento delle sezioni viene perso quando si salva in .ppt.

**È possibile "nascondere" un'intera sezione?**

No. È possibile nascondere solo diapositive individuali. Una sezione come entità non ha uno stato "nascosto".

**Posso trovare rapidamente una sezione a partire da una diapositiva e, viceversa, la prima diapositiva di una sezione?**

Sì. Una sezione è definita univocamente dalla sua diapositiva iniziale; data una diapositiva è possibile determinare a quale sezione appartiene, e per una sezione è possibile accedere alla sua prima diapositiva.