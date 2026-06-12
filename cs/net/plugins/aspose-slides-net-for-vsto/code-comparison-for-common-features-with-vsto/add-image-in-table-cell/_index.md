---
title: Přidat obrázek do buňky tabulky
type: docs
weight: 10
url: /cs/net/add-image-in-table-cell/
---
## **VSTO**
Níže je kód pro přidání obrázku do buňky tabulky:

``` csharp

    //Otevřete třídu Presentation, která obsahuje tabulku
   string FileName = "Adding Image in Table Cell.pptx";
   string ImageFile = "AsposeLogo.jpg";
   Presentation pres = Application.Presentations.Open(FileName);
   //Získejte první snímek
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
Aspose.Slides pro .NET poskytuje nejjednodušší API pro vytváření tabulek nejjednodušším způsobem. Chcete-li přidat obrázek do buňky tabulky při vytváření nové tabulky, postupujte podle následujících kroků:

- Vytvořte instanci třídy Presentation
- Získejte odkaz na snímek pomocí jeho indexu
- Definujte pole sloupců s šířkou
- Definujte pole řádků s výškou
- Přidejte tabulku do snímku pomocí metody AddTable, kterou vystavuje objekt IShapes
- Vytvořte objekt Bitmap pro uchování souboru obrázku
- Přidejte bitmapový obrázek do objektu IPPImage
- Nastavte formát výplně buňky tabulky jako obrázek
- Přidejte obrázek do první buňky tabulky
- Uložte upravenou prezentaci jako soubor PPTX

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Získat první snímek

  ISlide sld = MyPresentation.Slides[0];

  //Vytvoření objektu Bitmap Image pro uchování souboru obrázku

  using IImage image = Images.FromFile(ImageFile);

  //Vytvoření objektu IPPImage pomocí bitmapového objektu

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Přidat obrázek do první buňky tabulky

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Uložit PPTX na disk

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Stáhnout spuštěný kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)