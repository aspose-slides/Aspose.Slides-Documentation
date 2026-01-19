---
title: Entfernen von Zeile oder Spalte in Tabelle in VSTO und Aspose.Slides
type: docs
weight: 130
url: /de/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---

## **VSTO**
Im Folgenden finden Sie Code zum Entfernen von Zeilen oder Spalten aus einer Tabelle mit VSTO Presentation:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Get the first slide

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
Aspose.Slides für .NET stellt die einfachste API zum Erstellen von Tabellen auf einfachste Weise bereit. Um eine Tabelle in einer Folie zu erstellen und einige grundlegende Vorgänge an der Tabelle auszuführen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse Presentation
- Holen Sie sich die Referenz einer Folie über deren Index
- Definieren Sie ein Array von Spalten mit Breite
- Definieren Sie ein Array von Zeilen mit Höhe
- Fügen Sie der Folie eine Tabelle hinzu, indem Sie die AddTable-Methode des IShapes-Objekts verwenden
- Entfernen Sie eine Tabellenzeile
- Entfernen Sie eine Tabellenspalte
- Speichern Sie die modifizierte Präsentation als PPTX-Datei

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Get First Slide

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
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)