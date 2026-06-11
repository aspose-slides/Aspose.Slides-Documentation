---
title: Przejścia slajdów
type: docs
weight: 80
url: /pl/net/slide-transitions/
---
Aby ułatwić zrozumienie, przedstawiliśmy użycie Aspose.Slides dla .NET do zarządzania prostymi przejściami slajdów. Programiści mogą nie tylko stosować różne efekty przejść slajdów, ale także dostosowywać zachowanie tych efektów przejścia. Aby utworzyć prosty efekt przejścia slajdu, wykonaj poniższe kroki:

- Utwórz instancję klasy Presentation
- Zastosuj typ przejścia slajdu na slajdzie, wybierając jeden z efektów przejścia oferowanych przez Aspose.Slides dla .NET przy użyciu wyliczenia **TransitionType**
- Zapisz zmodyfikowany plik prezentacji.
## **Przykład**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji

using (Presentation pres = new Presentation(FileName))

{

    //Zastosuj przejście typu circle na slajdzie 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Zastosuj przejście typu comb na slajdzie 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Zastosuj przejście typu zoom na slajdzie 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Zapisz prezentację na dysku

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Pobierz kod przykładowy**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Pobierz działający przykład**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 
Aby uzyskać więcej szczegółów, odwiedź [Zarządzanie przejściami slajdów](/slides/pl/net/slide‑transition/).
{{% /alert %}}