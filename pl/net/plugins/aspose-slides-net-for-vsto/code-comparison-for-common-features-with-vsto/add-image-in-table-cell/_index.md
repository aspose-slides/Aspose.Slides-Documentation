---
title: Dodaj obraz w komórce tabeli
type: docs
weight: 10
url: /pl/net/add-image-in-table-cell/
---
## **VSTO**
Poniżej znajduje się kod dodający obraz w komórce tabeli:

``` csharp

    //Otwórz klasę Presentation, która zawiera tabelę

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Pobierz pierwszy slajd

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
Aspose.Slides for .NET udostępnił najprostsze API do tworzenia tabel w najłatwiejszy sposób. Aby dodać obraz w komórce tabeli podczas tworzenia nowej tabeli, wykonaj poniższe kroki:

- Utwórz instancję klasy Presentation
- Uzyskaj odwołanie do slajdu, używając jego indeksu
- Zdefiniuj tablicę kolumn z szerokością
- Zdefiniuj tablicę wierszy z wysokością
- Dodaj tabelę do slajdu za pomocą metody AddTable udostępnionej przez obiekt IShapes
- Utwórz obiekt Bitmap, aby przechować plik obrazu
- Dodaj obraz Bitmap do obiektu IPPImage
- Ustaw format wypełnienia komórki tabeli jako obraz
- Dodaj obraz do pierwszej komórki tabeli
- Zapisz zmodyfikowaną prezentację jako plik PPTX

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Pobierz pierwszy slajd

  ISlide sld = MyPresentation.Slides[0];

  //Tworzenie obiektu obrazu Bitmap, aby przechować plik obrazu

  using IImage image = Images.FromFile(ImageFile);

  //Utwórz obiekt IPPImage używając obiektu bitmapy

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Dodaj obraz do pierwszej komórki tabeli

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Zapisz PPTX na dysku

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)