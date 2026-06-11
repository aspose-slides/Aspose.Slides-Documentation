---
title: Konwertuj prezentację na Tiff z notatkami
type: docs
weight: 50
url: /pl/net/convert-presentation-to-tiff-with-notes/
---
TIFF jest jednym z kilku szeroko używanych formatów obrazu, które Aspose.Slides for .NET obsługuje przy konwertowaniu prezentacji z notatkami na obrazy. Możesz także generować miniatury slajdów w widoku Notatki slajdu. Poniżej znajdują się dwa fragmenty kodu, które pokazują, jak generować obrazy TIFF prezentacji w widoku Notatki slajdu.

Metoda [Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/methods/save) udostępniona przez klasę [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) może być użyta do konwersji całej prezentacji w widoku Notatki slajdu na TIFF. Możesz także generować miniaturę slajdu w widoku Notatki slajdu dla pojedynczych slajdów.
## **Przykład**

``` 

  //Utwórz obiekt Presentation, który reprezentuje plik prezentacji

 Presentation pres = new Presentation("Conversion.pptx");

 //Zapis prezentacji do TIFF z notatkami

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **Pobierz działający przykład**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Aby uzyskać więcej szczegółów, odwiedź [Convert PowerPoint Presentations to TIFF with Notes in .NET](/slides/pl/net/convert-powerpoint-to-tiff-with-notes/).

{{% /alert %}}