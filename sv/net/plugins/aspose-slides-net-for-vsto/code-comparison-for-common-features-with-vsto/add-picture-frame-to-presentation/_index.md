---
title: Lägg till bildram i presentation
type: docs
weight: 50
url: /sv/net/add-picture-frame-to-presentation/
---
## **VSTO**
Nedan visas koden för att lägga till en bild i en VSTO‑presentation:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
För att lägga till en enkel bildram på din bild, följ stegen nedan:

1. Skapa en instans av Presentation‑klassen.  
1. Hämta referensen till en bild genom att använda dess index.  
1. Skapa ett Image‑objekt genom att lägga till en bild i Images‑samlingen som är associerad med Presentation‑objektet som ska användas för att fylla Shape.  
1. Beräkna bildens bredd och höjd.  
1. Skapa ett PictureFrame enligt bildens bredd och höjd genom att använda AddPictureFrame‑metoden som exponeras av Shapes‑objektet som är kopplat till den refererade bilden.  
1. Lägg till en bildram (som innehåller bilden) på bilden.  
1. Skriv den modifierade presentationen som en PPTX‑fil.

Stegen ovan är implementerade i exemplet nedan.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Instansiera Presentation-klassen som representerar PPTX

  Presentation pres = new Presentation();

  //Hämta den första sliden

  ISlide sld = pres.Slides[0];

  //Instansiera ImageEx-klassen

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Lägg till bildram med bildens höjd och bredd

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);
``` 
## **Ladda ner körkod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Ladda ner exempelkod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)