---
title: Offentlig API och bakåtinkompatibla förändringar i Aspose.Slides för .NET 14.3.0
linktitle: Aspose.Slides för .NET 14.3.0
type: docs
weight: 50
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint-PPT, PPTX- och ODP-presentationslösningar."
---
## **Offentlig API och bakåtinkompatibla förändringar**
### **Aspose.Slides.ShapeThumbnailBounds‑enumeration och Aspose.Slides.IShape.GetThumbnail()‑metoder har lagts till**
Metoderna GetThumbnail() och GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) används för att skapa en separat form‑miniatyrbild. ShapeThumbnailBounds‑enumerationen definierar de möjliga typerna av form‑miniatyrgränser.
### **Egenskapen UniqueId har lagts till i Aspose.Slides.IShape**
Aspose.Slides.IShape.UniqueId‑egenskapen ger en unik identifierare för en form inom presentationsomfånget. Dessa unika identifierare lagras i formens anpassade taggar.
### **Signaturen för SetGroupingItem‑metoden har ändrats i IChartCategoryLevelsManager**
Signaturen för IChartCategoryLevelsManager‑metoden

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

```

är nu föråldrad och har ersatts med signaturen

``` csharp

 void SetGroupingItem(int level, object value);

```

Anrop som

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

```

måste ändras till anrop som

``` csharp

 .SetGroupingItem(1, "Group 1");

```

Skicka ett värde som "Group 1" till SetGroupingItem men inte ett värde av typen IChartDataCell. Att konstruera IChartDataCell med ett definierat kalkylblad, rad och kolumn för kategorinivåer måste uppfylla vissa krav och har kapslats in i SetGroupingItem(int, object)-metoden.
### **SlideId‑egenskapen har lagts till i Aspose.Slides.IBaseSlide‑gränssnittet**
SlideId‑egenskapen ger en unik bildidentifierare.
### **SoundName‑egenskapen har lagts till i ISlideShowTransition**
Läs‑skriv‑sträng. Anger ett mänskligt läsbart namn för övergångens ljud. Sound‑egenskapen måste tilldelas för att hämta eller sätta ljudnamnet. Detta namn visas i PowerPoint‑användargränssnittet när övergångsljudet konfigureras manuellt. Kan kasta PptxException när Sound‑egenskapen inte har tilldelats.
### **Typen för ChartSeriesGroup.Type‑egenskapen har ändrats**
ChartSeriesGroup.Type‑egenskapen har ändrats från ChartType‑enumerationen till den nya CombinableSeriesTypesGroup‑enumerationen. CombinableSeriesTypesGroup‑enumet representerar grupper av kombinerbara serietyper.
### **Stöd för att generera individuella form‑miniatyrbilder har lagts till**
Aspose.Slides.ShapeThumbnailBounds

Nya medlemmar i Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)