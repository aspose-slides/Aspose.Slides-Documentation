---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro Java 15.7.0
linktitle: Aspose.Slides pro Java 15.7.0
type: docs
weight: 150
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- migrace
- zastaralý kód
- moderní kód
- zastaralý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Přehled aktualizací veřejného API a nekompatibilních změn v Aspose.Slides pro Java, který usnadní plynulou migraci vašich řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 
Tato stránka uvádí všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) nebo [odebrané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) třídy, metody, vlastnosti a tak dále a další změny zavedené v API Aspose.Slides pro Java 15.7.0.
{{% /alert %}} 
## **Změny veřejného API**
#### **Enum com.aspose.slides.ImagePixelFormat byl přidán**
Enum com.aspose.slides.ImagePixelFormat byl přidán pro určení formátu pixelů pro generované obrázky.
#### **Metoda com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() byla přidána**
Tato metoda vrací automatickou barvu datového bodu na základě indexu řady, indexu datového bodu, parentSeriesGroup, hodnoty isColorVaried a stylu grafu. Tato barva se použije jako výchozí, pokud je fillType rovno NotDefined.
#### **Metody getPixelFormat(), setPixelFormat(int) byly přidány do com.aspose.slides.ITiffOptions**
Metody getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) byly přidány do com.aspose.slides.ITiffOptions a com.aspose.slides.TiffOptions pro určení formátu pixelů pro generované TIFF obrázky.
``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```