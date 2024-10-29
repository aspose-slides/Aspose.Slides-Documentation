---
title: Ändern der Füllfarbe einer Form in einer Präsentation
type: docs
weight: 40
url: /de/net/change-the-fill-color-of-a-shape-in-a-presentation/
---

## **OpenXML-Präsentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Füllfarbe einer Form.pptx";

SetPPTShapeColor(FileName);

// Ändern der Füllfarbe einer Form.

// Die Testdatei muss eine ausgefüllte Form als erste Form auf der ersten Folie haben.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // Erhalten Sie die Beziehung-ID der ersten Folie.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // Holen Sie sich das Folienpart aus der Beziehung-ID.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // Holen Sie sich den Formbaum, der die zu ändernde Form enthält.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // Holen Sie sich die erste Form im Formbaum.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // Holen Sie sich den Stil der Form.

                ShapeStyle style = shape.ShapeStyle;

                // Holen Sie sich die Füllreferenz.

                Drawing.FillReference fillRef = style.FillReference;

                // Setzen Sie die Füllfarbe auf SchemeColor Accent 6;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // Speichern Sie die modifizierte Folie.

                slide.Slide.Save();

            }

        }

    }

}

``` 
## **Aspose.Slides**
Wir müssen die folgenden Schritte ausführen, um die Formen in der Präsentation zu füllen:

- Erstellen Sie eine Instanz der Präsentationsklasse.
- Erhalten Sie die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie eine IShape zur Folie hinzu.
- Setzen Sie den Fülltyp der Form auf Solid.
- Setzen Sie die Farbe der Form.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Füllfarbe einer Form.pptx";

//Instanziieren Sie die PrseetationEx-Klasse, die das PPTX repräsentiert

using (Presentation pres = new Presentation())

{

    //Holen Sie sich die erste Folie

    ISlide sld = pres.Slides[0];

    //Fügen Sie eine Autoshape vom Rechtecktyp hinzu

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    //Setzen Sie den Fülltyp auf Solid

    shp.FillFormat.FillType = FillType.Solid;

    //Setzen Sie die Farbe des Rechtecks

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    //Schreiben Sie die PPTX-Datei auf die Festplatte

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Download Beispiellaufcode**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Beispielcode**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Apply Theme to Presentation/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)