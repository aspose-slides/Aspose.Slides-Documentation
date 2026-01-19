---
title: Folien als SVG-Bild erstellen
type: docs
weight: 70
url: /de/net/create-slide-as-svg-image/
---

Um ein SVG‑Bild aus einer gewünschten Folie mit Aspose.Slides.Pptx für .NET zu erzeugen, befolgen Sie bitte die nachstehenden Schritte:

- Erstellen Sie eine Instanz der Klasse Presentation.
- Ermitteln Sie die Referenz der gewünschten Folie mithilfe ihrer ID oder ihres Index.
- Erhalten Sie das SVG‑Bild in einem Memory‑Stream.
- Speichern Sie den Memory‑Stream in einer Datei.
## **Beispiel**

```

 //Instantiate a Presentation class that represents the presentation file

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //Access the second slide

   ISlide sld = pres.Slides[1];

   //Create a memory stream object

   MemoryStream SvgStream = new MemoryStream();

   //Generate SVG image of slide and save in memory stream

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //Save memory stream to file

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
## **Laufendes Beispiel herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Weitere Details finden Sie unter [Präsentationsfolien als SVG‑Bilder in .NET rendern](/slides/de/net/render-a-slide-as-an-svg-image/).

{{% /alert %}}