---
title: Aggiungere forme alla presentazione
type: docs
weight: 30
url: /it/net/adding-shapes-to-presentation/
---
## **VSTO**
Di seguito è riportato lo snippet di codice per aggiungere una forma di linea:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
Per aggiungere una semplice linea piana a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe Presentation
- Ottieni il riferimento di una diapositiva utilizzando il suo indice
- Aggiungi un'AutoShape di tipo Linea usando il metodo AddAutoShape esposto dall'oggetto Shapes
- Scrivi la presentazione modificata come file PPTX

Nell'esempio riportato di seguito, abbiamo aggiunto una linea alla prima diapositiva della presentazione.

``` csharp

   //Istanzia la classe Presentation che rappresenta il PPTX

  Presentation pres = new Presentation();

  //Ottieni la prima diapositiva

  ISlide slide = pres.Slides[0];

  //Aggiungi un autoshape di tipo linea

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)