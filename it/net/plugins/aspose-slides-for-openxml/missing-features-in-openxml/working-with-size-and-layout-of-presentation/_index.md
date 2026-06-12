---
title: Lavorare con la dimensione e il layout della presentazione
type: docs
weight: 90
url: /it/net/working-with-size-and-layout-of-presentation/
---
**SlideSize.Type** e **SlideSize.Size** sono le proprietà della classe Presentation che possono essere impostate o ottenute come mostrato nell'esempio.
## **Esempio**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//Istanziare un oggetto Presentation che rappresenta un file di presentazione 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Imposta la dimensione della diapositiva delle presentazioni generate a quella della sorgente

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Salva la presentazione su disco

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **Scarica Codice di Esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Scarica Esempio in Esecuzione**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 
Per ulteriori dettagli, visita [Modifica la dimensione della diapositiva della presentazione in .NET](/slides/it/net/slide-size/).
{{% /alert %}}