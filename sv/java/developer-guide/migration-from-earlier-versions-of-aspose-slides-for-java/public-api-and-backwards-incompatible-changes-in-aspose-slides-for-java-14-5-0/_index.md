---
title: Offentlig API och bakåtinkompatibla ändringar i Aspose.Slides för Java 14.5.0
linktitle: Aspose.Slides för Java 14.5.0
type: docs
weight: 40
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammalt tillvägagångssätt
- modernt tillvägagångssätt
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska uppdateringar av offentligt API och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP-presentationer."
---
{{% alert color="primary" %}} 

Denna sida listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) klasser, metoder, egenskaper med mera, eventuella nya [restriktioner](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) och andra [ändringar](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) som introducerats med Aspose.Slides för Java 14.5.0 API.

{{% /alert %}} 
## **Offentlig API och bakåtinkompatibla ändringar**
### **Tillagda klasser och metoder**
#### **Tillagd Aspose.Slides.IPresentationInfo‑gränssnittet och PresentationInfo‑klasser**
Representerar information om presentationen.

Metoden Boolean isEncrypted() returnerar True om en presentation är krypterad, annars returnerar den False.

Metoden LoadFormat getLoadFormat() returnerar presentationens typ.
#### **Tillagd metoden Aspose.Slides.IShape.isGrouped()**
Metoden Aspose.Slides.IShape.isGrouped() bestämmer om formen är grupperad.
#### **Tillagd metoden Aspose.Slides.IShape.getParentGroup()**
Metoden Aspose.Slides.IShape.getParentGroup() returnerar föräldra‑GroupShape‑objektet om formen är grupperad. Annars returneras null.
#### **Tillagd metoden Aspose.Slides.IShapeCollection.addGroupShape()**
Metoden Aspose.Slides.IShapeCollection.addGroupShape() skapar en ny GroupShape och lägger till den i slutet av samlingen.

GroupShape‑ramens storlek och position kommer att anpassas till innehållet när en ny form läggs till i GroupShape.
#### **Tillagd metoden Aspose.Slides.IShapeCollection.clear()**
Metoden Aspose.Slides.IShapeCollection.clear() tar bort alla former från samlingen.
#### **Tillagd metoden Aspose.Slides.IShapeCollection.insertGroupShape(int)**
Metoden Aspose.Slides.IShapeCollection.insertGroupShape(int) skapar en ny GroupShape och sätter in den i samlingen på angivet index.
GroupShape‑ramens storlek och position kommer att anpassas till innehållet när en ny form läggs till i GroupShape.
#### **Tillagda IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream) metoder**
Dessa metoder låter utvecklare få information om en presentationsfil/ström utan att ladda hela presentationen.
#### **Tillagd metoden IPresentationFactory PresentationFactory.getInstance()**
Tillåter att använda fabrikens funktionalitet utan instansiering.
### **Restriktioner**
#### **Restriktioner har lagts till för användning av odefinierade värden för IShape.getFrame()**
Kod som försöker tilldela en odefinierad ram till IShape.setFrame(IShapeFrame) är inte meningsfull i allmänna fall (särskilt när föräldra‑GroupShape är flera lager inbäddad i andra {{GroupShape}}s). Till exempel:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

eller

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Sådan kod kan leda till oklara situationer. Därför har restriktioner lagts till för att använda odefinierade värden för IShape.Frame. Värdena för x, y, width, height, flipH, flipV och rotationAngle måste vara definierade (inte Float.NaN eller NullableBool.NotDefined). Exempelkoden ovan kastar nu ett ArgumentException‑undantag.
Detta gäller för följande användningsfall:

``` java

 IShape shape = ...;

shape.setFrame(...); // kan inte vara odefinierad

IShapeCollection shapes = ...;

// x, y, width, height parametrar kan inte vara Float.NaN:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}
```

Men ramen från IShape.getRawFrame() kan vara odefinierad. Detta är meningsfullt när en form är länkad till en platshållare. Då ersätts de odefinierade ramvärdena från föräldra‑platshållarformen. Om det inte finns någon föräldra‑platshållarform för den formen används standardvärden när den beräknar den effektiva ramen baserat på dess IShape.getRawFrame(). Standardvärdena är 0 och NullableBool.False för x, y, width, height, flipH, flipV och rotationAngle. Till exempel:

``` java

 IShape shape = ...; // formen är länkad till en platshållare

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// nu ärver formen x, y, height, flipH, flipV värden från platshållaren och åsidosätter width=100 och rotationAngle=0.

```
### **Ändrade egenskaper**
#### **Ändrad typ och namn på Aspose.Slides.IShapeCollection.getParent()‑metoden**
Typen för Aspose.Slides.IShapeCollection.Parent‑egenskapen har ändrats från ISlideComponent till det nya IGroupShape‑gränssnittet. IGroupShape‑gränssnittet är en avkomma till ISlideComponent så befintlig kod kräver ingen anpassning.

Namnet på Aspose.Slides.IShapeCollection.getParent()‑metoden har ändrats från getParent till getParentGroup().
#### **Ändrad typ för Aspose.Slides.IShapeFrame.getFlipH() och .getFlipV()‑metoderna**
Typen för Aspose.Slides.IShapeFrame.getFlipH()‑metoden har ändrats från bool till NullableBool.

Metoden IShape.getFrame() returnerar den effektiva instansen av IShapeFrame (alla dess egenskaper har definierade effektiva värden).

Metoden IShape.getRawFrame() returnerar en IShapeFrame‑instans där varje egenskap kan ha ett odefinierat värde (särskilt FlipH eller FlipV kan ha värdet NullableBool.NotDefined).