---
title: Rimozione di riga o colonna in una tabella in VSTO e Aspose.Slides
type: docs
weight: 130
url: /it/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---
## **VSTO**
Di seguito è riportato il codice per rimuovere righe o colonne da una tabella utilizzando VSTO Presentation:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Ottieni la prima diapositiva

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
Aspose.Slides per .NET fornisce l'API più semplice per creare tabelle nel modo più facile. Per creare una tabella in una diapositiva ed eseguire alcune operazioni di base sulla tabella, segui i passaggi seguenti:

- Crea un'istanza della classe Presentation
- Ottieni il riferimento di una diapositiva usando il suo indice
- Definisci un array di colonne con larghezza
- Definisci un array di righe con altezza
- Aggiungi una tabella alla diapositiva usando il metodo AddTable esposto dall'oggetto IShapes
- Rimuovi una riga dalla tabella
- Rimuovi una colonna dalla tabella
- Scrivi la presentazione modificata come file PPTX

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Ottieni la prima diapositiva

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);


``` 
## **Scarica il codice in esecuzione**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Scarica il codice di esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)