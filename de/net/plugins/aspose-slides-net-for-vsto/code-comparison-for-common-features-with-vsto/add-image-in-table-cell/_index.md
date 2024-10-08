---
title: Bild in Tabellenzelle hinzufügen
type: docs
weight: 10
url: /net/add-image-in-table-cell/
---

## **VSTO**
Unten finden Sie den Code zum Hinzufügen eines Bildes in eine Tabellenzelle:

``` csharp

    //Öffnen Sie die Präsentationsklasse, die die Tabelle enthält

   string FileName = "Bild in Tabellenzelle hinzufügen.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Erhalten Sie die erste Folie

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
Aspose.Slides für .NET bietet die einfachste API, um Tabellen auf die einfachste Weise zu erstellen. Um ein Bild in eine Tabellenzelle hinzuzufügen, während Sie eine neue Tabelle erstellen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Präsentationsklasse
- Erhalten Sie die Referenz einer Folie, indem Sie deren Index verwenden
- Definieren Sie ein Array von Spalten mit Breite
- Definieren Sie ein Array von Zeilen mit Höhe
- Fügen Sie der Folie eine Tabelle mit der von IShapes bereitgestellten Methode AddTable hinzu
- Erstellen Sie ein Bitmap-Objekt, um die Bilddatei zu halten
- Fügen Sie das Bitmap-Bild zum IPPImage-Objekt hinzu
- Setzen Sie das Füllformat der Tabellenzelle als Bild
- Fügen Sie das Bild in die erste Zelle der Tabelle ein
- Speichern Sie die modifizierte Präsentation als PPTX-Datei

``` csharp

   string FileName = "Bild in Tabellenzelle hinzufügen.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Get Erste Folie

  ISlide sld = MyPresentation.Slides[0];

  //Erstellen eines Bitmap-Bildobjekts, um die Bilddatei zu halten

  using IImage image = Images.FromFile(ImageFile);

  //Erstellen Sie ein IPPImage-Objekt mit dem Bitmap-Objekt

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Bild in die erste Tabellenzelle einfügen

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Speichern Sie PPTX auf der Festplatte

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Download lauffähiger Code**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Beispielcode**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Bild in Tabellenzelle hinzufügen/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Bild%20in%20Tabellenzelle%20hinzufügen)