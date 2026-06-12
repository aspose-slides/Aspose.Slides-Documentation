---
title: Aprire una presentazione in VSTO e Aspose.Slides
type: docs
weight: 120
url: /it/net/opening-a-presentation-in-vsto-and-aspose-slides/
---
## **VSTO**
Di seguito è il frammento di codice per aprire una presentazione:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


```
## **Aspose.Slides**
Aspose.Slides per .NET fornisce la classe **Presentation** che viene utilizzata per aprire una presentazione esistente. Offre alcuni costruttori sovraccaricati e possiamo utilizzare uno dei costruttori appropriati della classe **Presentation** per creare il suo oggetto basandoci su una presentazione esistente. Nell'esempio riportato di seguito, abbiamo passato il nome del file della presentazione (da aprire) al costruttore della classe Presentation. Dopo che il file è stato aperto, otteniamo il numero totale di diapositive presenti nella presentazione da stampare sullo schermo.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

```
## **Scarica Codice Eseguibile**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Scarica Codice di Esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)