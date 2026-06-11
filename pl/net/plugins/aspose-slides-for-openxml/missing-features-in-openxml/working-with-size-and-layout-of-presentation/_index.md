---
title: Praca z rozmiarem i układem prezentacji
type: docs
weight: 90
url: /pl/net/working-with-size-and-layout-of-presentation/
---
**SlideSize.Type** oraz **SlideSize.Size** są właściwościami klasy prezentacji, które można ustawiać i odczytywać, jak pokazano poniżej w przykładzie.
## **Przykład**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//Utwórz obiekt Presentation, który reprezentuje plik prezentacji 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Ustaw rozmiar slajdu wygenerowanych prezentacji na taki sam jak źródłowa

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Zapisz prezentację na dysku

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Pobierz działający przykład**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 
Aby uzyskać więcej informacji, odwiedź [Zmienianie rozmiaru slajdu prezentacji w .NET](/slides/pl/net/slide-size/)
{{% /alert %}}