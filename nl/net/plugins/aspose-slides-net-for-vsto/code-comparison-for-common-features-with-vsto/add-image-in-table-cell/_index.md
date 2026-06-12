---
title: Afbeelding toevoegen in tabelcel
type: docs
weight: 10
url: /nl/net/add-image-in-table-cell/
---
## **VSTO**
Hieronder staat de code om een afbeelding toe te voegen aan een tabelcel:

``` csharp

    //Open presentatieklasse die de tabel bevat

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Verkrijg de eerste dia

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
Aspose.Slides for .NET biedt de eenvoudigste API om op de gemakkelijkste manier tabellen te maken. Om een afbeelding toe te voegen in een tabelcel tijdens het maken van een nieuwe tabel, volgt u de onderstaande stappen:

- Maak een instantie van de Presentation-klasse
- Verkrijg de referentie van een dia via de index
- Definieer een array van kolommen met breedte
- Definieer een array van rijen met hoogte
- Voeg een tabel toe aan de dia met de AddTable-methode van het IShapes-object
- Maak een Bitmap-object aan om het afbeeldingsbestand op te slaan
- Voeg de Bitmap-afbeelding toe aan het IPPImage-object
- Stel het opvulformaat van de tabelcel in als afbeelding
- Voeg de afbeelding toe aan de eerste cel van de tabel
- Sla de aangepaste presentatie op als een PPTX-bestand

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Verkrijg de eerste dia

  ISlide sld = MyPresentation.Slides[0];

  //Maak een Bitmap-afbeeldingsobject aan om het afbeeldingsbestand op te slaan

  using IImage image = Images.FromFile(ImageFile);

  //Maak een IPPImage-object aan met behulp van het bitmap-object

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Voeg afbeelding toe aan de eerste tabelcel

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Sla PPTX op schijf

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)