---
title: Offentlig API och bakåtinkompatibla förändringar i Aspose.Slides för .NET 14.5.0
linktitle: Aspose.Slides för .NET 14.5.0
type: docs
weight: 70
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- migrering
- äldre kod
- modern kod
- äldre tillvägagångssätt
- modernt tillvägagångssätt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT, PPTX och ODP presentationslösningar."
---
{{% alert color="info" %}} 

Denna sida listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) klasser, metoder, egenskaper osv, eventuella nya [restriktioner](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) och andra [ändringar](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) som införts med Aspose.Slides för .NET 14.5.0 API.

{{% /alert %}} 
## **Offentlig API och bakåtinkompatibla förändringar**
### **Tillagda gränssnitt, klasser, egenskaper och metoder**
#### **Tillade Aspose.Slides.IPresentationInfo-gränssnittet och PresentationInfo-klassen**
Representerar information om presentationen.

- Booleska egenskapen IsEncrypted returnerar True om en presentation är krypterad, annars False.
- Egenskapen LoadFormat returnerar typen av en presentation.
#### **Tillagd egenskapen Aspose.Slides.IShape.IsGrouped**
Egenskapen Aspose.Slides.IShape.IsGrouped bestämmer om en form är grupperad.
#### **Tillagd egenskapen Aspose.Slides.IShape.ParentGroup**
Egenskapen Aspose.Slides.IShape.ParentGroup returnerar det överordnade GroupShape-objektet om en form är grupperad. Annars returneras null.
#### **Tillagd metoden Aspose.Slides.IShapeCollection.AddGroupShape()**
Metoden Aspose.Slides.IShapeCollection.AddGroupShape() skapar ett nytt GroupShape och lägger till det i slutet av samlingen.
GroupShape-ramens storlek och position anpassas till innehållet när en ny form läggs till.
#### **Tillagd metoden Aspose.Slides.IShapeCollection.Clear()**
Metoden Aspose.Slides.IShapeCollection.Clear() tar bort alla former från samlingen.
#### **Tillagd metoden Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
Metoden Aspose.Slides.IShapeCollection.InsertGroupShape(int) skapar ett nytt GroupShape och infogar det i samlingen på den angivna indexpositionen.
GroupShape-ramens storlek och position anpassas till innehållet när en ny form läggs till.
#### **Tillagda metoderna IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Dessa metoder möjliggör att hämta information om en presentationsfil eller -ström utan att fullständigt ladda presentationen.
#### **Tillagd egenskapen IPresentationFactory PresentationFactory.Instance**
Denna egenskap gör det möjligt för utvecklare att använda fabriksfunktionaliteten utan instansiering.
### **Restriktioner**
#### **Restriktioner för IShape.Frame**
Restriktioner har lagts till för att använda odefinierade värden för IShape.Frame. Kod som försöker tilldela en odefinierad ram till IShape.Frame är ofta meningslös (särskilt när den överordnade GroupShape är flera nivåer inbäddad i andra {{GroupShape}}s). Till exempel:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// Kastar ArgumentException: ramvärdena måste vara definierade.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

eller

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Kastar ArgumentException: x, y, bredd och höjd måste vara definierade.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

Sådan kod kan leda till oklara situationer. Därför har restriktioner lagts till för att använda odefinierade värden för IShape.Frame. Värdena x, y, width, height, flipH, flipV och rotationAngle måste vara definierade (och får inte sättas till float.NaN eller NullableBool.NotDefined). Exempelkoden ovan kastar nu ett ArgumentException‑undantag.
Detta gäller för följande användningsfall:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// x, y, bredd och höjd parametrarna kan inte vara float.NaN, och flipH, flipV
// kan inte vara NullableBool.NotDefined:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// Samma restriktion gäller för alla metoder som skapar en form:
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

Men IShape.RawFrame-ramegenskaper kan vara odefinierade. Detta är logiskt när en form är länkad till en platshållare. Då överskrivs de odefinierade ramvärdena från den överordnade platshållarformen. Om det inte finns någon överordnad platshållarform använder den formen standardvärden när den beräknar den effektiva ramen baserat på sin IShape.RawFrame. Standardvärdena är 0 och NullableBool.False för x, y, width, height, flipH, flipV och rotationAngle. Till exempel:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Formen är länkad till en platshållare
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // nu ärver formen x, y, höjd, flipH, flipV-värden från platshållaren och åsidosätter bredd=100 och rotationAngle=0.
}
``` 
### **Ändrade egenskaper**
#### **Ändrad namn och typ för Aspose.Slides.IShapeCollection.Parent‑egenskapen**
- Typen för Aspose.Slides.IShapeCollection.Parent‑egenskapen har ändrats från ISlideComponent till det nya IGroupShape‑gränssnittet. IGroupShape‑gränssnittet är en avkomma till ISlideComponent så befintlig kod kräver inga anpassningar.
- Namnet på Aspose.Slides.IShapeCollection.Parent‑egenskapen har ändrats från Parent till ParentGroup.
#### **Ändrade typer för Aspose.Slides.IShapeFrame.FlipH, .FlipV‑egenskaperna**
- Typen för Aspose.Slides.IShapeFrame.FlipH‑egenskapen har ändrats från bool till NullableBool.
- IShape.Frame‑egenskapen returnerar en effektiv instans av IShapeFrame (alla egenskaper har definierade effektiva värden).
- IShape.RawFrame‑egenskapen returnerar en instans av IShapeFrame där varje egenskap kan ha ett odefinierat värde (särskilt FlipH eller FlipV kan ha värdet NullableBool.NotDefined).