---
title: Ta bort rad eller kolumn i tabell i VSTO och Aspose.Slides
type: docs
weight: 130
url: /sv/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---
## **VSTO**
Nedan finns kod för att ta bort rader eller kolumner från en tabell med VSTO Presentation:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Hämta den första bilden

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
Aspose.Slides för .NET har tillhandahållit det enklaste API:et för att skapa tabeller på ett enkelt sätt. För att skapa en tabell i en bild och utföra några grundläggande operationer på tabellen, följ stegen nedan:

- Skapa en instans av Presentation‑klassen
- Hämta referensen till en bild genom att använda dess index
- Definiera en array av kolumner med bredd
- Definiera en array av rader med höjd
- Lägg till en tabell på bilden med hjälp av AddTable‑metoden som exponeras av IShapes‑objektet
- Ta bort tabellrad
- Ta bort tabellkolumn
- Skriv den modifierade presentationen som en PPTX‑fil

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Hämta första bilden

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);


``` 
## **Ladda ner körande kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Ladda ner exempelkod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)