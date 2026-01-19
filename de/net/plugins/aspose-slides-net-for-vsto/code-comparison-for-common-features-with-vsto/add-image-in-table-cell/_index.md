---
title: Bild in Tabellenzelle hinzufügen
type: docs
weight: 10
url: /de/net/add-image-in-table-cell/
---

## **VSTO**
Im Folgenden finden Sie den Code zum Hinzufügen eines Bildes in einer Tabellenzelle:

``` csharp

    //Open Prsentation class that contains the table

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Get the first slide

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
Aspose.Slides für .NET bietet die einfachste API, um Tabellen auf einfachste Weise zu erstellen. Um ein Bild in eine Tabellenzelle einzufügen, während Sie eine neue Tabelle erstellen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse Presentation
- Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden
- Definieren Sie ein Array von Spalten mit Breite
- Definieren Sie ein Array von Zeilen mit Höhe
- Fügen Sie der Folie eine Tabelle hinzu, indem Sie die AddTable‑Methode des IShapes‑Objekts verwenden
- Erstellen Sie ein Bitmap‑Objekt, um die Bilddatei zu halten
- Fügen Sie das Bitmap‑Bild dem IPPImage‑Objekt hinzu
- Setzen Sie das Füllformat der Tabellenzelle auf Bild
- Fügen Sie das Bild zur ersten Zelle der Tabelle hinzu
- Speichern Sie die modifizierte Präsentation als PPTX‑Datei

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Get First Slide

  ISlide sld = MyPresentation.Slides[0];

  //Creating a Bitmap Image object to hold the image file

  using IImage image = Images.FromFile(ImageFile);

  //Create an IPPImage object using the bitmap object

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Add image to first table cell

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Save PPTX to Disk

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Laufenden Code herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Beispielcode herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)