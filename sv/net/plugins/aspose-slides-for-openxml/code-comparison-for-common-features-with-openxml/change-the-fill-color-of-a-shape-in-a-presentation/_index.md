---
title: Ändra fyllningsfärgen på en form i en presentation
type: docs
weight: 40
url: /sv/net/change-the-fill-color-of-a-shape-in-a-presentation/
---
## **OpenXML-presentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// Ändra fyllningsfärgen på en form.

// Testfilen måste ha en fylld form som den första formen på den första bilden.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // Hämta relations-ID för den första bilden.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // Hämta bilddelen från relations-ID:t.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // Hämta formträdet som innehåller formen som ska ändras.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // Hämta den första formen i formträdet.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // Hämta stil för formen.

                ShapeStyle style = shape.ShapeStyle;

                // Hämta fyllningsreferensen.

                Drawing.FillReference fillRef = style.FillReference;

                // Sätt fyllningsfärgen till SchemeColor Accent 6;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // Spara den modifierade bilden.

                slide.Slide.Save();

            }

        }

    }

}
``` 
## **Aspose.Slides**
Vi måste följa följande steg för att fylla i formerna i presentationen:

- Skapa en instans av Presentation-klassen.
- Hämta referensen till en bild genom att använda dess index.
- Lägg till ett IShape på bilden.
- Ställ in fyllningstypen för formen till Solid.
- Ange färgen på formen.
- Skriv den modifierade presentationen som en PPTX-fil.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

//Instansiera PrseetationEx-klassen som representerar PPTX 

using (Presentation pres = new Presentation())

{

    //Hämta den första bilden

    ISlide sld = pres.Slides[0];

    //Lägg till en autoshape av rektangeltyp

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    //Ställ in fyllningstypen till Solid

    shp.FillFormat.FillType = FillType.Solid;

    //Ställ in färgen på rektangeln

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    //Skriv PPTX-filen till disk

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Ladda ner körande kodexempel**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Exempelkod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)