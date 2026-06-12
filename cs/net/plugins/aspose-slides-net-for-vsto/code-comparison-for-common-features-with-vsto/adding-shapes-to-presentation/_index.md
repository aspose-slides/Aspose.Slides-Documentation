---
title: Přidání tvarů do prezentace
type: docs
weight: 30
url: /cs/net/adding-shapes-to-presentation/
---
## **VSTO**
Níže je úryvek kódu pro přidání čáry:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
Pro přidání jednoduché rovné čáry do vybraného snímku prezentace postupujte podle následujících kroků:

- Vytvořte instanci třídy Presentation
- Získejte referenci na snímek pomocí jeho indexu
- Přidejte AutoShape typu Line pomocí metody AddAutoShape, která je součástí objektu Shapes
- Uložte upravenou prezentaci jako soubor PPTX

V níže uvedeném příkladu jsme přidali čáru na první snímek prezentace.

``` csharp

   //Instancujte třídu Presentation, která představuje PPTX

  Presentation pres = new Presentation();

  //Získejte první snímek

  ISlide slide = pres.Slides[0];

  //Přidejte autoshape typu line

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)