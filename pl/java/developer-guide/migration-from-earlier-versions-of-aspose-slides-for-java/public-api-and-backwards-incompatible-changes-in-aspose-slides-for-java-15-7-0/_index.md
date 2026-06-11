---
title: Publiczne API i zmiany niezgodne wstecz w Aspose.Slides for Java 15.7.0
linktitle: Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- podejście nowoczesne
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API i zmiany łamiące w Aspose.Slides for Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona zawiera listę wszystkich [dodanych](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) lub [usuniętych](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) klas, metod, właściwości i podobnych, a także innych zmian wprowadzonych w API Aspose.Slides for Java 15.7.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
#### **Enum com.aspose.slides.ImagePixelFormat został dodany**
Enum com.aspose.slides.ImagePixelFormat został dodany w celu określenia formatu pikseli dla generowanych obrazów.
#### **Metoda com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() została dodana**
Ta metoda zwraca automatyczny kolor punktu danych na podstawie indeksu serii, indeksu punktu danych, parentSeriesGroup, wartości isColorVaried oraz stylu wykresu. Ten kolor jest używany domyślnie, gdy fillType ma wartość NotDefined.
#### **Metody getPixelFormat(), setPixelFormat(int) zostały dodane do com.aspose.slides.ITiffOptions**
Metody getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) zostały dodane do com.aspose.slides.ITiffOptions i com.aspose.slides.TiffOptions w celu określenia formatu pikseli dla generowanych obrazów TIFF.

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```