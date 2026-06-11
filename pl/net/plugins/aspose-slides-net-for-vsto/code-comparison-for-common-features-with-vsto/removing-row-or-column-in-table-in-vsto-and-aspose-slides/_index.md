---
title: Usuwanie wiersza lub kolumny w tabeli w VSTO i Aspose.Slides
type: docs
weight: 130
url: /pl/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---
## **VSTO**
Poniżej znajduje się kod usuwający wiersze lub kolumny z tabeli przy użyciu VSTO Presentation:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Pobierz pierwszy slajd

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
Aspose.Slides dla .NET udostępnia najprostsze API do tworzenia tabel w najłatwiejszy sposób. Aby utworzyć tabelę na slajdzie i wykonać podstawowe operacje na tabeli, postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy Presentation
- Uzyskaj odwołanie do slajdu, używając jego indeksu
- Zdefiniuj tablicę kolumn z szerokością
- Zdefiniuj tablicę wierszy z wysokością
- Dodaj tabelę do slajdu za pomocą metody AddTable udostępnionej przez obiekt IShapes
- Usuń wiersz tabeli
- Usuń kolumnę tabeli
- Zapisz zmodyfikowaną prezentację jako plik PPTX

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Pobierz pierwszy slajd

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