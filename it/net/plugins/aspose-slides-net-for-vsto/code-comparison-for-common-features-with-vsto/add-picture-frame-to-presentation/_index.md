---
title: Aggiungi riquadro immagine alla presentazione
type: docs
weight: 50
url: /it/net/add-picture-frame-to-presentation/
---
## **VSTO**
Di seguito è riportato il codice per aggiungere un'immagine in una presentazione VSTO:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Per aggiungere un semplice riquadro immagine alla diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe Presentation.
1. Ottieni il riferimento di una diapositiva utilizzando il suo indice.
1. Crea un oggetto Image aggiungendo un'immagine alla collezione Images associata all'oggetto Presentation che verrà utilizzata per riempire lo Shape.
1. Calcola larghezza e altezza dell'immagine.
1. Crea un PictureFrame in base alla larghezza e altezza dell'immagine utilizzando il metodo AddPictureFrame esposto dall'oggetto Shapes associato alla diapositiva di riferimento.
1. Aggiungi un riquadro immagine (contenente l'immagine) alla diapositiva.
1. Scrivi la presentazione modificata come file PPTX.

I passaggi sopra riportati sono implementati nell'esempio mostrato di seguito.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Instanzia la classe Presentation che rappresenta il PPTX
  Presentation pres = new Presentation();

  //Ottieni la prima diapositiva
  ISlide sld = pres.Slides[0];

  //Instanzia la classe ImageEx
  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Aggiungi un riquadro immagine con altezza e larghezza equivalenti all'immagine
  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)