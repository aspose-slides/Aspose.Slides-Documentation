---
title: Kép hozzáadása a táblázat cellájába
type: docs
weight: 10
url: /hu/net/add-image-in-table-cell/
---
## **VSTO**
Az alább látható kód a kép hozzáadásához a táblázat cellájába:

``` csharp

    //Nyissa meg a táblázatot tartalmazó Presentation osztályt

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Szerezze meg az első diát

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          Cell cell= shp.Table.Rows[1].Cells[1];

          cell.Shape.Fill.UserPicture(ImageFile);

      }

   }


``` 
## **Aspose.Slides**
Az Aspose.Slides for .NET a legegyszerűbb API-t biztosítja a táblázatok legkönnyebb módon történő létrehozásához. A kép egy táblázat cellájába való hozzáadásához új táblázat létrehozása során, kérjük, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a Presentation osztályból
- Szerezze meg a diára mutató hivatkozást az Index használatával
- Határozza meg az oszlopok tömbjét szélességgel
- Határozza meg a sorok tömbjét magassággal
- Adjon hozzá egy táblázatot a diára az IShapes objektum által biztosított AddTable metódussal
- Hozzon létre egy Bitmap objektumot a képfájl tárolásához
- Adja hozzá a Bitmap képet az IPPImage objektumhoz
- Állítsa be a táblázat cellájának kitöltési formátumát Képnek
- Adja hozzá a képet a táblázat első cellájához
- Mentse a módosított prezentációt PPTX fájlként

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Szerezze meg az első diát

  ISlide sld = MyPresentation.Slides[0];

  //Bitmap képobjektum létrehozása a képfájl tárolásához

  using IImage image = Images.FromFile(ImageFile);

  //IPPImage objektum létrehozása a bitmap objektum használatával

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Kép hozzáadása az első táblázatcella

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //PPTX mentése lemezre

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)