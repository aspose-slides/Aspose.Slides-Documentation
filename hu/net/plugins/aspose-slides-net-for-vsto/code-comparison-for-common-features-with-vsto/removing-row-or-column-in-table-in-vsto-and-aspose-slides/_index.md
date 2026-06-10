---
title: Sor vagy oszlop eltávolítása a táblázatban VSTO és Aspose.Slides
type: docs
weight: 130
url: /hu/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---
## **VSTO**
Az alábbi kód a VSTO Presentation segítségével táblázat sorainak vagy oszlopainak eltávolítását mutatja:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Az első dia lekérése

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          shp.Table.Rows[1].Delete();

      }

   }

``` 
## **Aspose.Slides**
Az Aspose.Slides for .NET a legegyszerűbb API-t biztosítja a táblázatok legkönnyebb létrehozásához. Egy táblázat létrehozásához egy dián, és alapvető műveletek végrehajtásához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a Presentation osztályból
- Szerezze meg egy dia hivatkozását az Indexe használatával
- Határozza meg az oszlopok szélességét tartalmazó tömböt
- Határozza meg a sorok magasságát tartalmazó tömböt
- Adjon hozzá egy táblázatot a diához az IShapes objektum által biztosított AddTable metódussal
- Táblázat sorának eltávolítása
- Táblázat oszlopának eltávolítása
- Írja ki a módosított prezentációt PPTX fájlként

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Első dia lekérése

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)