---
title: Změňte barvu výplně tvaru v prezentaci
type: docs
weight: 40
url: /cs/net/change-the-fill-color-of-a-shape-in-a-presentation/
---
## **OpenXML Prezentace**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// Změňte barvu výplně tvaru.

// Testovací soubor musí mít vyplněný tvar jako první tvar na první snímku.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // Získejte ID vztahu první snímku.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // Získejte část snímku podle ID vztahu.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // Získejte strom tvarů, který obsahuje tvar k úpravě.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // Získejte první tvar ve stromu tvarů.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // Získejte styl tvaru.

                ShapeStyle style = shape.ShapeStyle;

                // Získejte referenci výplně.

                Drawing.FillReference fillRef = style.FillReference;

                // Nastavte barvu výplně na SchemeColor Accent 6;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // Uložte upravený snímek.

                slide.Slide.Save();

            }

        }

    }

}
``` 
## **Aspose.Slides**
Pro vyplnění tvarů v prezentaci je třeba postupovat podle následujících kroků:

- Vytvořte instanci třídy Presentation.
- Získejte referenci na snímek pomocí jeho indexu.
- Přidejte do snímku IShape.
- Nastavte typ výplně tvaru na Solid.
- Nastavte barvu tvaru.
- Uložte upravenou prezentaci jako soubor PPTX.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

//Instancujte třídu PresentationEx, která představuje PPTX 

using (Presentation pres = new Presentation())

{

    //Získejte první snímek

    ISlide sld = pres.Slides[0];

    //Přidejte automatický tvar typu obdélník

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    //Nastavte typ výplně na Solid

    shp.FillFormat.FillType = FillType.Solid;

    //Nastavte barvu obdélníku

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    //Zapište soubor PPTX na disk

    pres.Save(FileName, SaveFormat.Pptx);

}
``` 
## **Stáhnout spustitelný příklad kódu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)