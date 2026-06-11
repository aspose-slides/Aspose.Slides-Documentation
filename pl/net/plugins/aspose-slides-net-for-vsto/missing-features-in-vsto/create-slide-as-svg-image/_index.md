---
title: Utwórz slajd jako obraz SVG
type: docs
weight: 70
url: /pl/net/create-slide-as-svg-image/
---
Aby wygenerować obraz SVG z dowolnego wybranego slajdu przy użyciu Aspose.Slides.Pptx dla .NET, postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy Presentation.
- Uzyskaj referencję do wybranego slajdu, korzystając z jego identyfikatora lub indeksu.
- Pobierz obraz SVG w strumieniu pamięci.
- Zapisz strumień pamięci do pliku.
## **Przykład**

```

 //Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{
   //Uzyskaj dostęp do drugiego slajdu
   ISlide sld = pres.Slides[1];
   //Utwórz obiekt strumienia pamięci
   MemoryStream SvgStream = new MemoryStream();
   //Wygeneruj obraz SVG slajdu i zapisz w strumieniu pamięci
   sld.WriteAsSvg(SvgStream);
   SvgStream.Position = 0;
   //Zapisz strumień pamięci do pliku
   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))
   {
     byte[] buffer = new byte[8 * 1024];
     int len;
     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)
     {
       fileStream.Write(buffer, 0, len);
     }
   }
}
SvgStream.Close();
``` 
## **Pobierz działający przykład**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Aby uzyskać więcej informacji, odwiedź [Render Presentation Slides as SVG Images in .NET](/slides/pl/net/render-a-slide-as-an-svg-image/).
{{% /alert %}}