---
title: Dodawanie kształtów do prezentacji
type: docs
weight: 30
url: /pl/net/adding-shapes-to-presentation/
---
## **VSTO**
Poniżej znajduje się fragment kodu dodającego kształt linii:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
Aby dodać prostą linię do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy Presentation
- Pobierz odniesienie do slajdu, używając jego indeksu
- Dodaj AutoShape typu Line przy użyciu metody AddAutoShape udostępnionej przez obiekt Shapes
- Zapisz zmodyfikowaną prezentację jako plik PPTX

W poniższym przykładzie dodaliśmy linię do pierwszego slajdu prezentacji.

``` csharp

   //Utwórz klasę Presentation, która reprezentuje plik PPTX

  Presentation pres = new Presentation();

  //Pobierz pierwszy slajd

  ISlide slide = pres.Slides[0];

  //Dodaj autoshape typu linia

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Pobierz działający kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)