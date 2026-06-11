---
title: Otwieranie prezentacji w VSTO i Aspose.Slides
type: docs
weight: 120
url: /pl/net/opening-a-presentation-in-vsto-and-aspose-slides/
---
## **VSTO**
Poniżej znajduje się fragment kodu otwierającego prezentację:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


```
## **Aspose.Slides**
Aspose.Slides for .NET udostępnia klasę **Presentation**, która służy do otwierania istniejącej prezentacji. Posiada kilka przeciążonych konstruktorów i możemy skorzystać z jednego z odpowiednich konstruktorów klasy **Presentation**, aby utworzyć jej obiekt na podstawie istniejącej prezentacji. W podanym poniżej przykładzie przekazaliśmy nazwę pliku prezentacji (do otwarcia) do konstruktora klasy Presentation. Po otwarciu pliku pobieramy łączną liczbę slajdów w prezentacji i wyświetlamy ją na ekranie.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

```
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)