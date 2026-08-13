---
title: Public API oraz zmiany niezgodne wstecz w Aspose.Slides dla Javy 15.7.0
linktitle: Aspose.Slides dla Javy 15.7.0
type: docs
weight: 150
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- tradycyjne podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API oraz zmiany łamiące w Aspose.Slides dla Javy, aby płynnie migrować swoje rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 
Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) lub [usunięte](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) klasy, metody, właściwości i tak dalej, a także inne zmiany wprowadzone w API Aspose.Slides for Java 15.7.0.
{{% /alert %}} 
## **Zmiany w publicznym API**
#### **Enum com.aspose.slides.ImagePixelFormat został dodany**
Enum com.aspose.slides.ImagePixelFormat został dodany w celu określenia formatu pikseli dla generowanych obrazów.
#### **Metoda com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() została dodana**
Ta metoda zwraca automatyczny kolor punktu danych na podstawie indeksu serii, indeksu punktu danych, parentSeriesGroup, wartości isColorVaried oraz stylu wykresu. Ten kolor jest używany domyślnie, jeśli fillType jest równe NotDefined.
#### **Metody getPixelFormat(), setPixelFormat(int) zostały dodane do com.aspose.slides.ITiffOptions**
Metody getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) zostały dodane do com.aspose.slides.ITiffOptions oraz com.aspose.slides.TiffOptions w celu określenia formatu pikseli dla generowanych obrazów TIFF.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```