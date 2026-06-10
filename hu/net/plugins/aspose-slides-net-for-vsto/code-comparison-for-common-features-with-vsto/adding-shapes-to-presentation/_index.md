---
title: Alakzatok hozzáadása a bemutatóhoz
type: docs
weight: 30
url: /hu/net/adding-shapes-to-presentation/
---
## **VSTO**
Az alábbi kódrészlet a vonal alakzat hozzáadásához:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

```
## **Aspose.Slides**
Egyszerű egyenes vonal hozzáadásához a bemutató egy kiválasztott diájához, kérjük, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a Presentation osztályból
- Szerezze be a dia hivatkozását az Index használatával
- Adjon hozzá egy Line típusú AutoShape-et az AddAutoShape metódussal, amelyet a Shapes objektum biztosít
- Írja ki a módosított bemutatót PPTX fájlként

Az alább bemutatott példában egy vonalat adtunk hozzá a bemutató első diájához.

``` csharp

   //PPTX-et képviselő Presentation osztály példányosítása

  Presentation pres = new Presentation();

  //Az első diát lekérjük

  ISlide slide = pres.Slides[0];

  //Vonal típusú autoshape hozzáadása

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

```
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)