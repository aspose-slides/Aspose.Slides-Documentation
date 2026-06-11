---
title: Publikt API och bakåtinkompatibla förändringar i Aspose.Slides för .NET 14.5.0
linktitle: Aspose.Slides för .NET 14.5.0
type: docs
weight: 70
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
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
description: "Granska publika API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP-presentationer."
---
{{% alert color="primary" %}} 
Denna sida listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) klasser, metoder, egenskaper osv., samt eventuella nya [restriktioner](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) och andra [ändringar](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) som introducerats med Aspose.Slides för .NET 14.5.0 API.
{{% /alert %}} 
## **Publikt API och bakåtinkompatibla ändringar**
### **Tillagda gränssnitt, klasser, egenskaper och metoder**
#### **Tillagt Aspose.Slides.IPresentationInfo-gränssnittet och PresentationInfo-klassen**
Representerar information om presentationen.

- Den booleska egenskapen IsEncrypted får True om en presentation är krypterad, annars får den False.
- Egendomen LoadFormat får typ av en presentation.
#### **Tillagd egenskapen Aspose.Slides.IShape.IsGrouped**
Egenskapen Aspose.Slides.IShape.IsGrouped bestämmer om ett objekt är grupperat.
#### **Tillagd egenskapen Aspose.Slides.IShape.ParentGroup**
Egenskapen Aspose.Slides.IShape.ParentGroup returnerar det överordnade GroupShape-objektet om ett objekt är grupperat. Annars returneras null.
#### **Tillagd metoden Aspose.Slides.IShapeCollection.AddGroupShape()**
Metoden Aspose.Slides.IShapeCollection.AddGroupShape() skapar en ny GroupShape och lägger till den i slutet av samlingen.
GroupShape:s ramstorlek och position anpassas till innehållet när en ny form läggs till.
#### **Tillagd metoden Aspose.Slides.IShapeCollection.Clear()**
Metoden Aspose.Slides.IShapeCollection.Clear() tar bort alla former från samlingen.
#### **Tillagd metoden Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
Metoden Aspose.Slides.IShapeCollection.InsertGroupShape(int) skapar en ny GroupShape och sätter in den i samlingen på den angivna indexpositionen.
GroupShape:s ramstorlek och position anpassas till innehållet när en ny form läggs till.
#### **Tillagd metoden IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Dessa metoder möjliggör att hämta information om en presentationsfil eller ström utan att helt ladda presentationen.
#### **Tillagd egenskapen IPresentationFactory PresentationFactory.Instance**
Denna egenskap gör det möjligt för utvecklare att använda fabriksfunktionaliteten utan instansiering.
### **Restriktioner**
#### **Restriktioner för IShape.Frame**
Restriktioner har lagts till för att använda odefinierade värden för IShape.Frame. Kod som försöker tilldela en odefinierad ram till IShape.Frame är ofta meningslös (särskilt när den överordnade GroupShape är flera nivåer inbäddad i andra {{GroupShape}}s). Till exempel:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

eller

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Denna kod kan leda till oklara situationer. Därför har restriktioner lagts till för att använda odefinierade värden för IShape.Frame. Värdena x, y, width, height, flipH, flipV och rotationAngle måste vara definierade (och får inte sättas till float.NaN eller NullableBool.NotDefined). Exempelkoden ovan kastar nu ett ArgumentException‑undantag.
Detta gäller följande användningsfall:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // Kan inte vara odefinierad

IShapeCollection shapes = ...;

// x, y, bredd, höjd parametrar kan inte vara float.NaN:

{
    shapes.AddAudioFrameCD(...);
    shapes.AddAudioFrameEmbedded(...);
    shapes.AddAudioFrameLinked(...);
    shapes.AddAutoShape(...);
    shapes.AddChart(...);
    shapes.AddConnector(...);
    shapes.AddOleObjectFrame(...);
    shapes.AddPictureFrame(...);
    shapes.AddSmartArt(...);
    shapes.AddTable(...);
    shapes.AddVideoFrame(...);
    shapes.InsertAudioFrameEmbedded(...);
    shapes.InsertAudioFrameLinked(...);
    shapes.InsertAutoShape(...);
    shapes.InsertChart(...);
    shapes.InsertConnector(...);
    shapes.InsertOleObjectFrame(...);
    shapes.InsertPictureFrame(...);
    shapes.InsertTable(...);
    shapes.InsertVideoFrame(...);
}
``` 

Men IShape.RawFrame-ramegenskaper kan vara odefinierade. Detta är logiskt när en form är länkad till en platshållare. Då överskrivs de odefinierade ramvärdena från den överordnade platshållarformen. Om det inte finns någon överordnad platshållarform använder formen standardvärden när den beräknar en effektiv ram baserat på sin IShape.RawFrame. Standardvärdena är 0 och NullableBool.False för x, y, width, height, flipH, flipV och rotationAngle. Till exempel:

``` csharp

 IShape shape = ...; // formen är länkad till platshållare

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// nu ärver formen x, y, höjd, flipH, flipV värden från platshållare och åsidosätter bredd=100 och rotationAngle=0.

``` 
### **Ändrade egenskaper**
#### **Ändrat namnet och typen för egenskapen Aspose.Slides.IShapeCollection.Parent**
- Egendomen Aspose.Slides.IShapeCollection.Parent har fått typen ändrad från ISlideComponent till det nya IGroupShape‑gränssnittet. IGroupShape‑gränssnittet är en avkomma till ISlideComponent så befintlig kod kräver inga anpassningar.
- Namnet på egenskapen Aspose.Slides.IShapeCollection.Parent har ändrats från Parent till ParentGroup.
#### **Ändrade typer för egenskaperna Aspose.Slides.IShapeFrame.FlipH och .FlipV**
- Egendomen Aspose.Slides.IShapeFrame.FlipH har ändrats från bool till NullableBool.
- Egendomen IShape.Frame returnerar en effektiv instans av IShapeFrame (alla egenskaper har definierade effektiva värden).
- Egendomen IShape.RawFrame returnerar en instans av IShapeFrame där varje egenskap kan ha ett odefinierat värde (särskilt FlipH eller FlipV kan ha värdet NullableBool.NotDefined).