---
title: Ändern der Füllfarbe einer Form in einer Präsentation
type: docs
weight: 40
url: /de/net/change-the-fill-color-of-a-shape-in-a-presentation/
---

## **OpenXML-Präsentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// Change the fill color of a shape.

// The test file must have a filled shape as the first shape on the first slide.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // Get the relationship ID of the first slide.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // Get the slide part from the relationship ID.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // Get the shape tree that contains the shape to change.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // Get the first shape in the shape tree.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // Get the style of the shape.

                ShapeStyle style = shape.ShapeStyle;

                // Get the fill reference.

                Drawing.FillReference fillRef = style.FillReference;

                // Set the fill color to SchemeColor Accent 6;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // Save the modified slide.

                slide.Slide.Save();

            }

        }

    }

}

``` 
## **Aspose.Slides**
Wir müssen die folgenden Schritte ausführen, um die Formen in der Präsentation zu füllen:

- Erstellen Sie eine Instanz der Klasse Presentation.
- Holen Sie die Referenz einer Folie über deren Index.
- Fügen Sie der Folie ein IShape hinzu.
- Setzen Sie den Fülltyp der Form auf Solid.
- Setzen Sie die Farbe der Form.
- Speichern Sie die modifizierte Präsentation als PPTX-Datei.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

//Instantiate PrseetationEx class that represents the PPTX 

using (Presentation pres = new Presentation())

{

    //Get the first slide

    ISlide sld = pres.Slides[0];

    //Add autoshape of rectangle type

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    //Set the fill type to Solid

    shp.FillFormat.FillType = FillType.Solid;

    //Set the color of the rectangle

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    //Write the PPTX file to disk

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Laufendes Codebeispiel herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Beispielcode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)