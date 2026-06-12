---
title: Verander de vulkleur van een vorm in een presentatie
type: docs
weight: 40
url: /nl/net/change-the-fill-color-of-a-shape-in-a-presentation/
---
## **OpenXML-presentatie**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// Verander de vulkleur van een vorm.

// Het testbestand moet een gevulde vorm hebben als de eerste vorm op de eerste dia.

public static void SetPPTShapeColor(string docName)

{
    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))
    {
        // Haal de relatie-ID op van de eerste dia.
        PresentationPart part = ppt.PresentationPart;
        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;
        string relId = (slideIds[0] as SlideId).RelationshipId;
        // Haal het dia-gedeelte op via de relatie-ID.
        SlidePart slide = (SlidePart)part.GetPartById(relId);
        if (slide != null)
        {
            // Haal de shape tree op die de te wijzigen vorm bevat.
            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;
            // Haal de eerste vorm in de shape tree op.
            Shape shape = tree.GetFirstChild<Shape>();
            if (shape != null)
            {
                // Haal de stijl van de vorm op.
                ShapeStyle style = shape.ShapeStyle;
                // Haal de vulling-referentie op.
                Drawing.FillReference fillRef = style.FillReference;
                // Stel de vulkleur in op SchemeColor Accent 6;
                fillRef.SchemeColor = new Drawing.SchemeColor();
                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;
                // Sla de aangepaste dia op.
                slide.Slide.Save();
            }
        }
    }
}
``` 
## **Aspose.Slides**
We moeten de volgende stappen volgen om de vormen in de presentatie in te vullen:

- Maak een instantie van de Presentation-klasse.
- Verkrijg de referentie van een dia door gebruik te maken van de index.
- Voeg een IShape toe aan de dia.
- Stel het opvultype van de vorm in op Solid.
- Stel de kleur van de vorm in.
- Schrijf de aangepaste presentatie weg als een PPTX-bestand.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

//Instantieer de PrseetationEx-klasse die de PPTX voorstelt 
using (Presentation pres = new Presentation())
{
    //Haal de eerste dia op
    ISlide sld = pres.Slides[0];
    //Voeg een auto‑shape van het type rechthoek toe
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    //Stel het vullingstype in op Solid
    shp.FillFormat.FillType = FillType.Solid;
    //Stel de kleur van de rechthoek in
    shp.FillFormat.SolidFillColor.Color = Color.Yellow;
    //Schrijf het PPTX‑bestand naar schijf
    pres.Save(FileName, SaveFormat.Pptx);
}
``` 
## **Download werkende code-voorbeeld**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Voorbeeldcode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)