---
title: Odebrání řádku nebo sloupce v tabulce ve VSTO a Aspose.Slides
type: docs
weight: 130
url: /cs/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---
## **VSTO**
Níže je kód pro odebrání řádků nebo sloupců z tabulky pomocí VSTO Presentation:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Získejte první snímek

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
Aspose.Slides pro .NET poskytuje nejjednodušší rozhraní API pro vytváření tabulek nejjednodušším způsobem. Chcete-li vytvořit tabulku na snímku a provést některé základní operace s tabulkou, postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy Presentation
- Získejte odkaz na snímek pomocí jeho indexu
- Definujte pole sloupců se šířkou
- Definujte pole řádků s výškou
- Přidejte tabulku na snímek pomocí metody AddTable, kterou poskytuje objekt IShapes
- Odeberte řádek tabulky
- Odeberte sloupec tabulky
- Uložte upravenou prezentaci jako soubor PPTX

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Získejte první snímek

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