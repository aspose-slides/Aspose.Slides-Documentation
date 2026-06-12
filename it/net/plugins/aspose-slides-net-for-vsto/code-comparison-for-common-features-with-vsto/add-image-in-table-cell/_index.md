---
title: Aggiungi immagine in cella di tabella
type: docs
weight: 10
url: /it/net/add-image-in-table-cell/
---
## **VSTO**
Di seguito il codice per aggiungere un'immagine in una cella di tabella:

``` csharp

    //Apri la classe Presentation che contiene la tabella

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Ottieni la prima diapositiva

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
Aspose.Slides per .NET ha fornito l'API più semplice per creare tabelle nel modo più semplice. Per aggiungere un'immagine in una cella di una tabella durante la creazione di una nuova tabella, segui i passaggi indicati di seguito:

- Crea un'istanza della classe Presentation
- Ottieni il riferimento di una diapositiva utilizzando il suo indice
- Definisci un array di colonne con larghezza
- Definisci un array di righe con altezza
- Aggiungi una tabella alla diapositiva usando il metodo AddTable esposto dall'oggetto IShapes
- Crea un oggetto Bitmap per contenere il file immagine
- Aggiungi l'immagine Bitmap all'oggetto IPPImage
- Imposta il formato di riempimento della cella della tabella come Immagine
- Aggiungi l'immagine alla prima cella della tabella
- Salva la presentazione modificata come file PPTX

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Ottieni la prima diapositiva

  ISlide sld = MyPresentation.Slides[0];

  //Creazione di un oggetto Bitmap per contenere il file immagine

  using IImage image = Images.FromFile(ImageFile);

  //Crea un oggetto IPPImage usando l'oggetto bitmap

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Aggiungi l'immagine alla prima cella della tabella

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Salva il PPTX su disco

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);
``` 
## **Scarica Codice Eseguibile**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Scarica Codice di Esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)