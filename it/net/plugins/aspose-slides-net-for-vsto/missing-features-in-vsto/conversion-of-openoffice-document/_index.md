---
title: Conversione di documento OpenOffice
type: docs
weight: 30
url: /it/net/conversion-of-openoffice-document/
---
Aspose.Slides for .NET offre la classe **Presentation** che rappresenta un file di presentazione. La classe **Presentation** può ora accedere anche a **ODP** tramite il costruttore Presentation quando l'oggetto viene istanziato.

Di seguito è riportato l'esempio di conversione da ODP a PPT/PPTX.
## **Esempio**
```

 //Istanzia un oggetto Presentation che rappresenta un file di presentazione

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //Salvataggio della presentazione PPTX in formato PPTX

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

Di seguito è riportato l'esempio di conversione da PPT/PPTX a ODP.
## **Esempio**
``` 

 //Istanzia un oggetto Presentation che rappresenta un file di presentazione

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{
   //Salvataggio della presentazione PPTX in formato PPTX

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);
}

``` 
## **Scarica Esempio Eseguibile**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **Scarica Codice di Esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)