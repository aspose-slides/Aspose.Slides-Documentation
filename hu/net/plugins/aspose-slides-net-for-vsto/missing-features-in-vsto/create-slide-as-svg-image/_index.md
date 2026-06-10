---
title: Diát SVG képként létrehozni
type: docs
weight: 70
url: /hu/net/create-slide-as-svg-image/
---
Az Aspose.Slides.Pptx for .NET segítségével SVG képet generálásához bármely kívánt diáról, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a Presentation osztályból.
- Szerezze be a kívánt dia hivatkozását az ID vagy index használatával.
- Szerezze meg az SVG képet egy memóriastreamben.
- Mentse a memóriastreamet fájlba.

## **Példa**

```

 //Példányosít egy Presentation osztályt, amely a prezentációfájlt képviseli

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //A második dia elérése

   ISlide sld = pres.Slides[1];

   //Memóriastream objektum létrehozása

   MemoryStream SvgStream = new MemoryStream();

   //A dia SVG képének generálása és mentése a memóriastreambe

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //A memóriastream mentése fájlba

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
## **Futtató példa letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)

## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

További részletekért látogassa meg a [Prezentációs diák SVG képként való renderelése .NET-ben](/slides/hu/net/render-a-slide-as-an-svg-image/).

{{% /alert %}}