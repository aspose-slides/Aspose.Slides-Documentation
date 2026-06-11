---
title: Lägg till former i presentationen
type: docs
weight: 30
url: /sv/net/adding-shapes-to-presentation/
---
## **VSTO**
Nedan är kodsnutten för att lägga till linjeform:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
För att lägga till en enkel rak linje på ett valt bildspel, följ stegen nedan:

- Skapa en instans av Presentation‑klassen
- Hämta referensen till en bild genom att använda dess Index
- Lägg till en AutoShape av typ Linje med hjälp av AddAutoShape‑metoden som exponeras av Shapes‑objektet
- Skriv den ändrade presentationen som en PPTX‑fil

I exemplet nedan har vi lagt till en linje på den första bilden i presentationen.

``` csharp

   //Instansiera Presentation‑klassen som representerar PPTX

  Presentation pres = new Presentation();

  //Hämta den första bilden

  ISlide slide = pres.Slides[0];

  //Lägg till en autoshape av typ linje

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Ladda ner körbar kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Ladda ner exempel kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)