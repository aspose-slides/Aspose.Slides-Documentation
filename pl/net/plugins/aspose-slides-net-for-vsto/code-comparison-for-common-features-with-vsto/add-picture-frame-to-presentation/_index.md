---
title: Dodaj ramkę obrazu do prezentacji
type: docs
weight: 50
url: /pl/net/add-picture-frame-to-presentation/
---
## **VSTO**
Poniżej znajduje się kod dodający obraz do prezentacji VSTO:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Aby dodać prostą ramkę obrazu do slajdu, wykonaj poniższe kroki:

1. Utwórz instancję klasy Presentation.
1. Uzyskaj odwołanie do slajdu, używając jego indeksu.
1. Utwórz obiekt Image, dodając obraz do kolekcji Images powiązanej z obiektem Presentation, który będzie używany do wypełnienia kształtu.
1. Oblicz szerokość i wysokość obrazu.
1. Utwórz PictureFrame o wymiarach obrazu, używając metody AddPictureFrame udostępnionej przez obiekt Shapes powiązany z wybranym slajdem.
1. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Powyższe kroki zostały zaimplementowane w poniższym przykładzie.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Utwórz instancję klasy Presentation, która reprezentuje plik PPTX

  Presentation pres = new Presentation();

  //Pobierz pierwszy slajd

  ISlide sld = pres.Slides[0];

  //Instancjonuj klasę ImageEx

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Dodaj ramkę obrazu o wysokości i szerokości równych obrazowi

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);
``` 
## **Pobierz kod uruchamiany**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)