---
title: Alakzat kitöltőszínének módosítása egy prezentációban
type: docs
weight: 40
url: /hu/net/change-the-fill-color-of-a-shape-in-a-presentation/
---
## **OpenXML prezentáció**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// Alakzat kitöltőszínének módosítása.

// A tesztfájlnak egy kitöltött alakzatot kell tartalmaznia, mint az első alakzat az első dián.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // Szerezze meg az első dia kapcsolati azonosítóját.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // Szerezze meg a dia részét a kapcsolati azonosítóból.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // Szerezze be a shape tree-et, amely a módosítandó alakzatot tartalmazza.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // Kapja meg a shape tree első alakzatát.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // Szerezze meg az alakzat stílusát.

                ShapeStyle style = shape.ShapeStyle;

                // Szerezze meg a kitöltés hivatkozását.

                Drawing.FillReference fillRef = style.FillReference;

                // Állítsa be a kitöltőszínt a SchemeColor Accent 6-ra;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // Mentse a módosított diát.

                slide.Slide.Save();

            }

        }

    }

}
```
## **Aspose.Slides**
A következő lépéseket kell követni a prezentáció alakzatainak kitöltéséhez:

- Hozzon létre egy Presentation osztály példányt.
- Szerezze be egy diára a hivatkozást az indexe segítségével.
- Adjon hozzá egy IShape objektumot a diára.
- Állítsa be az alakzat kitöltési típusát Szilárdra.
- Állítsa be az alakzat színét.
- Mentse a módosított prezentációt PPTX fájlként.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

    //Példányosítsa a PrseetationEx osztályt, amely a PPTX-et képviseli

using (Presentation pres = new Presentation())

{

    //Szerezze meg az első diát

    ISlide sld = pres.Slides[0];

    //Adjon hozzá automatikus alakzatot téglalap típusú

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    //Állítsa be a kitöltés típusát Szilártra

    shp.FillFormat.FillType = FillType.Solid;

    //Állítsa be a téglalap színét

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    //Írja a PPTX fájlt a lemezre

    pres.Save(FileName, SaveFormat.Pptx);

}
```
## **Futtatható kódpélda letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Minta kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)