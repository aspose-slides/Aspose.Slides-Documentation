---
title: Publikt API och bakåtinkompatibla ändringar i Aspose.Slides för Java 14.5.0
linktitle: Aspose.Slides för Java 14.5.0
type: docs
weight: 40
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- migration
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska uppdateringar av det publika API:t och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP-presentationslösningar."
---
{{% alert color="info" %}} 

Den här sidan listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) klasser, metoder, egenskaper osv., eventuella nya [restriktioner](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) och andra [ändringar](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) som introducerats med Aspose.Slides for Java 14.5.0 API.

{{% /alert %}} 
## **Publikt API och bakåtinkompatibla ändringar**
### **Tillagda klasser och metoder**
#### **Tillagt Aspose.Slides.IPresentationInfo‑gränssnittet och PresentationInfo‑klasserna**
Representerar information om presentationen.

Metoden Boolean isEncrypted() returnerar True om en presentation är krypterad, annars False.

Metoden LoadFormat getLoadFormat() returnerar presentationstypen.
#### **Tillagd metoden Aspose.Slides.IShape.isGrouped()**
Metoden Aspose.Slides.IShape.isGrouped() avgör om formen är grupperad.
#### **Tillagd metoden Aspose.Slides.IShape.getParentGroup()**
Metoden Aspose.Slides.IShape.getParentGroup() returnerar föräldra‑GroupShape‑objektet om formen är grupperad. Annars returneras null.
#### **Tillagd metoden Aspose.Slides.IShapeCollection.addGroupShape()**
Metoden Aspose.Slides.IShapeCollection.addGroupShape() skapar en ny GroupShape och lägger till den i slutet av samlingen.

GroupShape‑ramens storlek och position kommer att anpassas till innehållet när en ny form läggs till i GroupShape.
#### **Tillagd metoden Aspose.Slides.IShapeCollection.clear()**
Metoden Aspose.Slides.IShapeCollection.clear() tar bort alla former från samlingen.
#### **Tillagd metoden Aspose.Slides.IShapeCollection.insertGroupShape(int)**
Metoden Aspose.Slides.IShapeCollection.insertGroupShape(int) skapar en ny GroupShape och infogar den i samlingen på det angivna indexet.
GroupShape‑ramens storlek och position kommer att anpassas till innehållet när en ny form läggs till i GroupShape.
#### **Tillagda metoderna IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream)**
Dessa metoder låter utvecklare hämta information om en presentationsfil/‑ström utan att ladda hela presentationen.
#### **Tillagd metod IPresentationFactory PresentationFactory.getInstance()**
Tillåter användning av fabriksfunktionaliteten utan instansiering.
### **Restriktioner**
#### **Restriktioner har lagts till för användning av odefinierade värden för IShape.getFrame()**
Kod som försöker tilldela en odefinierad ram till IShape.setFrame(IShapeFrame) är meningslös i allmänna fall (särskilt när föräldra‑GroupShape är flera gånger inbäddad i andra {{GroupShape}}s). Till exempel:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // Kastar ett ArgumentException: ramvärdena måste vara definierade.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

eller

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Kastar ett ArgumentException: x-, y-, bredd- och höjdvärden måste vara definierade.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

Sådan kod kan leda till oklara situationer. Därför har restriktioner lagts till för användning av odefinierade värden för IShape.Frame. Värdena x, y, width, height, flipH, flipV och rotationAngle måste vara definierade (inte Float.NaN eller NullableBool.NotDefined). Exempelkoden ovan kastar nu ett ArgumentException‑undantag.
Detta gäller för följande användningsfall:

``` java
// Den ram som skickas till IShape.setFrame(IShapeFrame) får inte innehålla odefinierade värden.

// Parametrarna x, y, bredd och höjd för följande IShapeCollection-metoder
// kan inte heller vara Float.NaN:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

Men ramen för IShape.getRawFrame() kan vara odefinierad. Detta är meningsfullt när en form är länkad till en platshållare. Då åsidosätts odefinierade ramvärden från föräldra‑platshållarformen. Om det inte finns någon föräldra‑platshållarform för den formen så används standardvärden när den beräknar den effektiva ramen baserat på dess IShape.getRawFrame(). Standardvärdena är 0 och NullableBool.False för x, y, width, height, flipH, flipV och rotationAngle. Till exempel:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // Formen är länkad till en platshållare.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // Nu ärver formen x, y, höjd, flipH och flipV värdena från platshållaren
    // och överskriver bredd = 100 och rotationAngle = 0.
} finally {
    if (pres != null) pres.dispose();
}
```
### **Ändrade egenskaper**
#### **Typ och namn för metoden Aspose.Slides.IShapeCollection.getParent() har ändrats**
Typen för egenskapen Aspose.Slides.IShapeCollection.Parent har ändrats från ISlideComponent till det nya IGroupShape‑gränssnittet. IGroupShape‑gränssnittet är en undertyp till ISlideComponent så befintlig kod kräver ingen anpassning.

Namnet på metoden Aspose.Slides.IShapeCollection.getParent() har ändrats från getParent till getParentGroup().
#### **Ändra typ för metoderna Aspose.Slides.IShapeFrame.getFlipH() och .getFlipV()**
Typen för metoden Aspose.Slides.IShapeFrame.getFlipH() har ändrats från bool till NullableBool.

Metoden IShape.getFrame() returnerar den effektiva instansen av IShapeFrame (alla dess egenskaper har definierade effektiva värden).

Metoden IShape.getRawFrame() returnerar en IShapeFrame‑instans där varje egenskap kan ha ett odefinierat värde (särskilt FlipH eller FlipV kan ha värdet NullableBool.NotDefined).