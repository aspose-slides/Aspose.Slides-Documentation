---
title: Entfernen von Zeilen oder Spalten in Tabellen in VSTO und Aspose.Slides
type: docs
weight: 130
url: /net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---

## **VSTO**
Unten steht der Code zum Entfernen von Zeilen oder Spalten aus einer Tabelle mithilfe der VSTO-Präsentation:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Erhalte die erste Folie

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
Aspose.Slides für .NET hat die einfachste API bereitgestellt, um Tabellen auf die einfachste Weise zu erstellen. Um eine Tabelle in einer Folie zu erstellen und einige grundlegende Operationen auf der Tabelle auszuführen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Präsentationsklasse
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden
- Definieren Sie ein Array von Spalten mit Breite
- Definieren Sie ein Array von Zeilen mit Höhe
- Fügen Sie eine Tabelle zur Folie mit der Methode AddTable hinzu, die vom IShapes-Objekt bereitgestellt wird
- Tabelle Zeile entfernen
- Tabelle Spalte entfernen
- Speichern Sie die modifizierte Präsentation als PPTX-Datei

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Erhalte die erste Folie

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);


``` 
## **Herunterladen des ausführbaren Codes**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Herunterladen des Beispielcodes**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Removing Row Or Column in Table/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)