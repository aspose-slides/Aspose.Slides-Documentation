---
title: Erstellen Sie eine Folie als SVG-Bild
type: docs
weight: 70
url: /net/create-slide-as-svg-image/
---

Um ein SVG-Bild aus einer gewünschten Folie mit Aspose.Slides.Pptx für .NET zu generieren, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse Presentation.
- Erhalten Sie die Referenz der gewünschten Folie mit ihrer ID oder ihrem Index.
- Holen Sie sich das SVG-Bild in einem Speicherstrom.
- Speichern Sie den Speicherstrom in einer Datei.
## **Beispiel**

```csharp
//Instanziieren Sie eine Klasse Presentation, die die Präsentationsdatei darstellt

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
   //Greifen Sie auf die zweite Folie zu

   ISlide sld = pres.Slides[1];

   //Erstellen Sie ein Speicherstromobjekt

   MemoryStream SvgStream = new MemoryStream();

   //Generieren Sie ein SVG-Bild der Folie und speichern Sie es im Speicherstrom

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //Speichern Sie den Speicherstrom in einer Datei

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
## **Herunterladen des laufenden Beispiels**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Creating Slide SVG Image/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Herunterladen des Beispielcodes**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Für weitere Details besuchen Sie [Creating Slide SVG Image](/slides/net/presentation-viewer/).

{{% /alert %}}