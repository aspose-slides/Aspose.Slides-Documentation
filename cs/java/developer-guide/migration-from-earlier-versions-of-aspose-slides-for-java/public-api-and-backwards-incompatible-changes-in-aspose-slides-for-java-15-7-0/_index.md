---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro Java 15.7.0
linktitle: Aspose.Slides pro Java 15.7.0
type: docs
weight: 150
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a nekompatibilní změny v Aspose.Slides pro Java, abyste hladce migrovali svá řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) nebo [odstraněné](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) třídy, metody, vlastnosti atd., a další změny zavedené v API Aspose.Slides pro Java 15.7.0.

{{% /alert %}} 
## **Veřejné změny API**
#### **Enum com.aspose.slides.ImagePixelFormat byl přidán**
Enum com.aspose.slides.ImagePixelFormat byl přidán pro určení formátu pixelů pro generované obrázky.
#### **Metoda com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() byla přidána**
Tato metoda vrací automatickou barvu datového bodu na základě indexu řady, indexu datového bodu, parentSeriesGroup, hodnoty isColorVaried a stylu grafu. Tato barva je použita jako výchozí, pokud je fillType roven NotDefined.
#### **Metody getPixelFormat(), setPixelFormat(int) byly přidány do com.aspose.slides.ITiffOptions**
Metody getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) byly přidány do com.aspose.slides.ITiffOptions a com.aspose.slides.TiffOptions pro určení formátu pixelů pro generované TIFF obrázky.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```