---
title: Lägg till bild i tabellcell
type: docs
weight: 10
url: /sv/net/add-image-in-table-cell/
---
## **VSTO**
Nedan är koden för att lägga till en bild i en tabellcell:

``` csharp

    //Öppna Presentation-klassen som innehåller tabellen

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Hämta den första bilden

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
Aspose.Slides för .NET har tillhandahållit det enklaste API‑et för att skapa tabeller på ett enkelt sätt. Följ stegen nedan för att lägga till en bild i en tabellcell när du skapar en ny tabell:

- Skapa en instans av Presentation‑klassen
- Hämta referensen till en bild genom att använda dess index
- Definiera en array av kolumner med bredd
- Definiera en array av rader med höjd
- Lägg till en tabell på bilden med metoden AddTable som exponeras av IShapes‑objektet
- Skapa ett Bitmap‑objekt för att hålla bildfilen
- Lägg till Bitmap‑bilden till IPPImage‑objektet
- Ställ in fyllningsformatet för tabellcellen som bild
- Lägg till bilden i tabellens första cell
- Spara den modifierade presentationen som en PPTX‑fil

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Hämta första bilden

  ISlide sld = MyPresentation.Slides[0];

  //Skapar ett Bitmap-bildobjekt för att hålla bildfilen

  using IImage image = Images.FromFile(ImageFile);

  //Skapa ett IPPImage-objekt med bitmap-objektet

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Lägg till bild i första tabellcellen

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Spara PPTX till disk

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)