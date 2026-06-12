---
title: Crea diapositiva come immagine SVG
type: docs
weight: 70
url: /it/net/create-slide-as-svg-image/
---
Per generare un'immagine SVG da qualsiasi diapositiva desiderata con Aspose.Slides.Pptx per .NET, segui i passaggi riportati di seguito:

- Crea un'istanza della classe Presentation.
- Ottieni il riferimento della diapositiva desiderata utilizzando il suo ID o indice.
- Recupera l'immagine SVG in un flusso di memoria.
- Salva il flusso di memoria su file.
## **Esempio**

```

 //Istanziare una classe Presentation che rappresenta il file di presentazione

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //Accedere alla seconda diapositiva

   ISlide sld = pres.Slides[1];

   //Creare un oggetto MemoryStream

   MemoryStream SvgStream = new MemoryStream();

   //Generare l'immagine SVG della diapositiva e salvarla nello stream di memoria

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //Salvare lo stream di memoria su file

   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))

   {

     byte[] buffer = new byte[8 * 1024];

     int len;

     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)

     {

       fileStream.Write(buffer, 0, len);

     }

}

SvgStream.Close();

``` 
## **Scarica Esempio in Esecuzione**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **Scarica Codice di Esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Per ulteriori dettagli, visita [Visualizza le Diapositive di Presentazione come Immagini SVG in .NET](/slides/it/net/render-a-slide-as-an-svg-image/).
{{% /alert %}}