---
title: Verwijderen van rij of kolom in tabel in VSTO en Aspose.Slides
type: docs
weight: 130
url: /nl/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---
## **VSTO**
Hieronder staat de code om rijen of kolommen uit een tabel te verwijderen met VSTO Presentation:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Haal de eerste dia

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
Aspose.Slides voor .NET biedt de eenvoudigste API om op de gemakkelijkste manier tabellen te maken. Volg de onderstaande stappen om een tabel in een dia te maken en enkele basisbewerkingen op de tabel uit te voeren:

- Maak een instantie van de klasse Presentation
- Verkrijg de referentie van een dia via de index
- Definieer een array van kolommen met breedte
- Definieer een array van rijen met hoogte
- Voeg een tabel toe aan de dia met de AddTable-methode van het IShapes-object
- Verwijder een tabelrij
- Verwijder een tabelkolom
- Schrijf de gewijzigde presentatie weg als een PPTX-bestand

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Haal eerste dia

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