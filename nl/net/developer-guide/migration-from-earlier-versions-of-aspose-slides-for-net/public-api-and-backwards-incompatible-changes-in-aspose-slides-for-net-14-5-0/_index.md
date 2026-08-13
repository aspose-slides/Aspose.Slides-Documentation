---
title: Publieke API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 14.5.0
linktitle: Aspose.Slides voor .NET 14.5.0
type: docs
weight: 70
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- migratie
- verouderde code
- moderne code
- ouderwetse benadering
- moderne benadering
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de publieke API-updates en brekende wijzigingen in Aspose.Slides voor .NET om uw PowerPoint PPT, PPTX en ODP presentatie‑oplossingen soepel te migreren."
---
{{% alert color="info" %}} 

Deze pagina geeft een overzicht van alle [toegevoegd](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) klassen, methoden, eigenschappen enz., alle nieuwe [beperkingen](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) en andere [wijzigingen](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) die geïntroduceerd zijn met de Aspose.Slides for .NET 14.5.0 API.

{{% /alert %}} 
## **Openbare API en achterwaarts incompatibele wijzigingen**
### **Toegevoegde interfaces, klassen, eigenschappen en methoden**
#### **Toegevoegd de Aspose.Slides.IPresentationInfo interface en PresentationInfo klasse**
Geeft informatie over een presentatie.

- De Boolean‑eigenschap IsEncrypted geeft True terug als een presentatie versleuteld is, anders False.
- De eigenschap LoadFormat LoadFormat geeft het type van een presentatie terug.
#### **Toegevoegd de Aspose.Slides.IShape.IsGrouped eigenschap**
De eigenschap Aspose.Slides.IShape.IsGrouped bepaalt of een vorm gegroepeerd is.
#### **Toegevoegd de Aspose.Slides.IShape.ParentGroup eigenschap**
De eigenschap Aspose.Slides.IShape.ParentGroup retourneert het bovenliggende GroupShape‑object als een vorm gegroepeerd is. Anders retourneert zij null.
#### **Toegevoegd de Aspose.Slides.IShapeCollection.AddGroupShape() methode**
De methode Aspose.Slides.IShapeCollection.AddGroupShape() maakt een nieuw GroupShape aan en voegt het toe aan het einde van de collectie. Het frame‑formaat en de positie van het GroupShape worden aangepast aan de inhoud wanneer een nieuwe vorm wordt toegevoegd.
#### **Toegevoegd de Aspose.Slides.IShapeCollection.Clear() methode**
De methode Aspose.Slides.IShapeCollection.Clear() verwijdert alle vormen uit de collectie.
#### **Toegevoegd de Aspose.Slides.IShapeCollection.InsertGroupShape(int) methode**
De methode Aspose.Slides.IShapeCollection.InsertGroupShape(int) maakt een nieuw GroupShape aan en plaatst het in de collectie op de opgegeven indexpositie. Het frame‑formaat en de positie van het GroupShape worden aangepast aan de inhoud wanneer een nieuwe vorm wordt toegevoegd.
#### **Toegevoegd de IPresentationFactory.GetPresentationInfo(string file), IPresentationFactory.GetPresentationInfo(Stream stream) methoden**
Deze methoden maken het mogelijk om informatie over een presentatie‑bestand of -stream op te halen zonder de volledige presentatie te laden.
#### **Toegevoegd de IPresentationFactory PresentationFactory.Instance eigenschap**
Deze eigenschap stelt ontwikkelaars in staat de fabrieksfunctionaliteit te gebruiken zonder instantiering.
### **Beperkingen**
#### **Beperkingen op IShape.Frame**
Er zijn beperkingen toegevoegd voor het gebruik van ongedefinieerde waarden voor IShape.Frame. Code die probeert een ongedefinieerde frame‑waarde toe te wijzen aan IShape.Frame is in de meeste gevallen onzinnig (vooral wanneer het bovenliggende GroupShape meerdere keren genest is in andere {{GroupShape}}s). Bijvoorbeeld:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// Werpt ArgumentException: de frame-waarden moeten gedefinieerd zijn.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

of

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Werpt ArgumentException: x, y, breedte en hoogte moeten gedefinieerd zijn.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

Zo’n code kan leiden tot onduidelijke situaties. Daarom zijn er beperkingen toegevoegd voor het gebruik van ongedefinieerde waarden voor IShape.Frame. De waarden van x, y, width, height, flipH, flipV en rotationAngle moeten gedefinieerd zijn (en mogen niet ingesteld zijn op float.NaN of NullableBool.NotDefined). De voorbeeldcode hierboven veroorzaakt nu een ArgumentException.
Dit geldt voor de volgende gebruikssituaties:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// De x, y, breedte en hoogte parameters kunnen niet float.NaN zijn, en flipH, flipV
// kunnen niet NullableBool.NotDefined zijn:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// Dezelfde beperking geldt voor elke methode die een vorm creëert:
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

Maar de IShape.RawFrame‑frame‑eigenschappen kunnen ongedefinieerd zijn. Dit is logisch wanneer een vorm gekoppeld is aan een placeholder. Dan worden de ongedefinieerde frame‑waarden van de vorm overschreven door de bovenliggende placeholder‑vorm. Als er geen bovenliggende placeholder‑vorm bestaat, gebruikt die vorm standaardwaarden bij het berekenen van het effectieve frame op basis van zijn IShape.RawFrame. De standaardwaarden zijn 0 en NullableBool.False voor x, y, width, height, flipH, flipV en rotationAngle. Bijvoorbeeld:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // De vorm is gekoppeld aan een placeholder
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // nu erft de vorm x, y, hoogte, flipH, flipV waarden van de placeholder en overschrijft breedte=100 en rotationAngle=0.
}
``` 
### **Gewijzigde eigenschappen**
#### **Gewijzigde naam en type van de Aspose.Slides.IShapeCollection.Parent eigenschap**
- Het type van de eigenschap Aspose.Slides.IShapeCollection.Parent is gewijzigd van ISlideComponent naar de nieuwe IGroupShape‑interface. De IGroupShape‑interface is een afstammeling van ISlideComponent, zodat bestaande code geen aanpassingen nodig heeft.
- De naam van de eigenschap Aspose.Slides.IShapeCollection.Parent is gewijzigd van Parent naar ParentGroup.
#### **Gewijzigde typen van de Aspose.Slides.IShapeFrame.FlipH, .FlipV eigenschappen**
- Het type van de eigenschap Aspose.Slides.IShapeFrame.FlipH is gewijzigd van bool naar NullableBool.
- De IShape.Frame eigenschap retourneert een effectief IShapeFrame‑instance (waarbij alle eigenschappen gedefinieerde effectieve waarden hebben).
- De IShape.RawFrame eigenschap retourneert een IShapeFrame‑instance waarvan elke eigenschap een ongedefinieerde waarde kan hebben (bijvoorbeeld FlipH of FlipV kan de waarde NullableBool.NotDefined hebben).