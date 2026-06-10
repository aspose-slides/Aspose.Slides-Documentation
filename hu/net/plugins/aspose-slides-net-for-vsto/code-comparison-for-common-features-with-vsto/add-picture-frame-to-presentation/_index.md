---
title: Képkeret hozzáadása a prezentációhoz
type: docs
weight: 50
url: /hu/net/add-picture-frame-to-presentation/
---
## **VSTO**
Az alábbi kód a kép hozzáadását mutatja egy VSTO prezentációba:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Egyszerű képkeret hozzáadásához a diádhoz kövesd az alábbi lépéseket:

1. Hozz létre egy példányt a Presentation osztályból.
1. Szerezd meg egy dia hivatkozását az indexével.
1. Hozz létre egy Image objektumot úgy, hogy képet adsz hozzá a Presentation objektumhoz tartozó Images gyűjteményhez, amely a Shape kitöltésére szolgál.
1. Számold ki a kép szélességét és magasságát.
1. A hivatkozott diahoz tartozó Shapes objektum AddPictureFrame metódusával a kép szélessége és magassága alapján hozz létre egy PictureFrame-et.
1. Adj hozzá egy képkeretet (amely a képet tartalmazza) a diához.
1. Írd ki a módosított prezentációt PPTX fájlként.

A fenti lépéseket az alább bemutatott példában valósítottuk meg.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Példányosítja a Presentation osztályt, amely a PPTX-et képviseli
  Presentation pres = new Presentation();

  //Az első dia lekérése
  ISlide sld = pres.Slides[0];

  //Példányosítja az ImageEx osztályt
  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Képkeret hozzáadása a kép magasságával és szélességével megegyező mérettel
  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);
``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)