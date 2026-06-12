---
title: Converti presentazione in Tiff con note
type: docs
weight: 50
url: /it/net/convert-presentation-to-tiff-with-notes/
---
TIFF è uno dei numerosi formati immagine ampiamente utilizzati che Aspose.Slides per .NET supporta per convertire una presentazione con note in immagini. È anche possibile generare miniature delle diapositive nella visualizzazione Note Slide. Di seguito sono riportati due snippet di codice che mostrano come generare immagini TIFF di una presentazione nella visualizzazione Note Slide.

Il metodo [Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/methods/save) esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) può essere utilizzato per convertire l'intera presentazione nella visualizzazione Note Slide in TIFF. È inoltre possibile generare una miniatura di una diapositiva nella visualizzazione Note Slide per diapositive individuali.
## **Esempio**

``` 
  //Instanzia un oggetto Presentation che rappresenta un file di presentazione

 Presentation pres = new Presentation("Conversion.pptx");

 //Salvataggio della presentazione in TIFF con note

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);
``` 
## **Scarica Esempio in Esecuzione**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **Scarica Codice di Esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Per ulteriori dettagli, visita [Converti presentazioni PowerPoint in TIFF con note in .NET](/slides/it/net/convert-powerpoint-to-tiff-with-notes/).

{{% /alert %}}