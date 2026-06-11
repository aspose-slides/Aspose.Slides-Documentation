---
title: Zmień kolor wypełnienia kształtu w prezentacji
type: docs
weight: 40
url: /pl/net/change-the-fill-color-of-a-shape-in-a-presentation/
---
## **Prezentacja OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// Zmień kolor wypełnienia kształtu.

// Plik testowy musi zawierać wypełniony kształt jako pierwszy kształt na pierwszym slajdzie.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // Pobierz identyfikator relacji pierwszego slajdu.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // Pobierz część slajdu na podstawie identyfikatora relacji.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // Pobierz drzewo kształtów, które zawiera kształt do zmiany.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // Pobierz pierwszy kształt w drzewie kształtów.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // Pobierz styl kształtu.

                ShapeStyle style = shape.ShapeStyle;

                // Pobierz odniesienie do wypełnienia.

                Drawing.FillReference fillRef = style.FillReference;

                // Ustaw kolor wypełnienia na SchemeColor Accent 6;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // Zapisz zmodyfikowany slajd.

                slide.Slide.Save();

            }

        }

    }

}
``` 
## **Aspose.Slides**
Musimy wykonać następujące kroki, aby wypełnić kształty w prezentacji:

- Utwórz instancję klasy Presentation.
- Uzyskaj referencję slajdu, używając jego indeksu.
- Dodaj IShape do slajdu.
- Ustaw typ wypełnienia kształtu na Solid.
- Ustaw kolor kształtu.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

//Utwórz instancję klasy PresentationEx, która reprezentuje plik PPTX

using (Presentation pres = new Presentation())

{

    //Pobierz pierwszy slajd

    ISlide sld = pres.Slides[0];

    //Dodaj autokształt typu prostokąt

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    //Ustaw typ wypełnienia na Solid

    shp.FillFormat.FillType = FillType.Solid;

    //Ustaw kolor prostokąta

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    //Zapisz plik PPTX na dysku

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Pobierz działający przykład kodu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)