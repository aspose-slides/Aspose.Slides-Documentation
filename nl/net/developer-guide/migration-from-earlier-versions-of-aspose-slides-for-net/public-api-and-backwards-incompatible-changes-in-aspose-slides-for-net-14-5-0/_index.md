---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 14.5.0
linktitle: Aspose.Slides voor .NET 14.5.0
type: docs
weight: 70
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- migratie
- oude code
- moderne code
- oude aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de openbare API-updates en brekende wijzigingen in Aspose.Slides voor .NET om uw PowerPoint-PPT, PPTX- en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="primary" %}} 

Deze pagina geeft een overzicht van alle [toegevoegde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) klassen, methoden, eigenschappen enzovoort, van alle nieuwe [beperkingen](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) en andere [wijzigingen](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) die zijn geïntroduceerd met de Aspose.Slides for .NET 14.5.0 API.

{{% /alert %}} 
## **Openbare API en achterwaarts incompatibele wijzigingen**
### **Toegevoegde interfaces, klassen, eigenschappen en methoden**
#### **Toegevoegd de Aspose.Slides.IPresentationInfo interface en PresentationInfo klasse**
Geeft informatie over een presentatie.

- De Boolean‑eigenschap IsEncrypted retourneert True als een presentatie versleuteld is, anders retourneert ze False.
- De eigenschap LoadFormat LoadFormat geeft het type van een presentatie aan.
#### **Toegevoegd de Aspose.Slides.IShape.IsGrouped eigenschap**
De eigenschap Aspose.Slides.IShape.IsGrouped bepaalt of een vorm gegroepeerd is.
#### **Toegevoegd de Aspose.Slides.IShape.ParentGroup eigenschap**
De eigenschap Aspose.Slides.IShape.ParentGroup retourneert het bovenliggende GroupShape‑object als een vorm gegroepeerd is. Anders retourneert ze null.
#### **Toegevoegd de Aspose.Slides.IShapeCollection.AddGroupShape() methode**
De methode Aspose.Slides.IShapeCollection.AddGroupShape() maakt een nieuw GroupShape aan en voegt het toe aan het einde van de collectie.
De frame‑grootte en positie van het GroupShape worden aangepast aan de inhoud wanneer een nieuwe vorm wordt toegevoegd.
#### **Toegevoegd de Aspose.Slides.IShapeCollection.Clear() methode**
De methode Aspose.Slides.IShapeCollection.Clear() verwijdert alle vormen uit de collectie.
#### **Toegevoegd de Aspose.Slides.IShapeCollection.InsertGroupShape(int) methode**
De methode Aspose.Slides.IShapeCollection.InsertGroupShape(int) maakt een nieuw GroupShape aan en voegt het in de collectie in op de opgegeven indexpositie.
De frame‑grootte en positie van het GroupShape worden aangepast aan de inhoud wanneer een nieuwe vorm wordt toegevoegd.
#### **Toegevoegd de IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream) methoden**
Deze methoden maken het mogelijk om informatie over een presentatie‑bestand of stream te ontvangen zonder de volledige presentatie te laden.
#### **Toegevoegd de IPresentationFactory PresentationFactory.Instance eigenschap**
Deze eigenschap stelt ontwikkelaars in staat de fabrieksfunctionaliteit te gebruiken zonder instantiering.
### **Beperkingen**
#### **Beperkingen voor IShape.Frame**
Er zijn beperkingen toegevoegd voor het gebruik van ongedefinieerde waarden voor IShape.Frame. Code die probeert een ongedefinieerde frame toe te wijzen aan IShape.Frame is in de meeste gevallen (met name wanneer de bovenliggende GroupShape meerdere keren genest is in andere {{GroupShape}}s) niet logisch. Bijvoorbeeld:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

of

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Zo’n code kan leiden tot onduidelijke situaties. Daarom zijn er beperkingen toegevoegd voor het gebruik van ongedefinieerde waarden voor IShape.Frame. Waarden van x, y, width, height, flipH, flipV en rotationAngle moeten zijn gedefinieerd (en niet ingesteld op float.NaN of NullableBool.NotDefined). De voorbeeldcode hierboven werpt nu een ArgumentException.
Dit geldt voor de volgende gebruikssituaties:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // Kan niet ongedefinieerd zijn

IShapeCollection shapes = ...;

// x, y, width, height parameters mogen niet float.NaN zijn:

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

Maar de IShape.RawFrame frame‑eigenschappen kunnen ongedefinieerd zijn. Dit is logisch wanneer een vorm gekoppeld is aan een placeholder. Dan worden de ongedefinieerde vorm‑frame‑waarden overschreven door de bovenliggende placeholder‑vorm. Als er geen bovenliggende placeholder‑vorm bestaat, dan gebruikt die vorm standaardwaarden wanneer ze het effectieve frame evalueert op basis van haar IShape.RawFrame. De standaardwaarden zijn 0 en NullableBool.False voor x, y, width, height, flipH, flipV en rotationAngle. Bijvoorbeeld:

``` csharp

 IShape shape = ...; // shape is gekoppeld aan placeholder

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// nu shape erft de x, y, height, flipH, flipV waarden van placeholder en overschrijft width=100 en rotationAngle=0.

``` 
### **Gewijzigde eigenschappen**
#### **Gewijzigde de Aspose.Slides.IShapeCollection.Parent eigenschapnaam en type**
- Het type van de Aspose.Slides.IShapeCollection.Parent eigenschap is gewijzigd van ISlideComponent naar de nieuwe IGroupShape‑interface. De IGroupShape‑interface is een afstammeling van ISlideComponent, dus bestaande code vereist geen aanpassingen.
- De naam van de Aspose.Slides.IShapeCollection.Parent eigenschap is gewijzigd van Parent naar ParentGroup.
#### **Gewijzigde de Aspose.Slides.IShapeFrame.FlipH, .FlipV eigenschapstypen**
- Het type van de Aspose.Slides.IShapeFrame.FlipH eigenschap is gewijzigd van bool naar NullableBool.
- De IShape.Frame eigenschap retourneert een effectief IShapeFrame‑object (waarvan alle eigenschappen gedefinieerde effectieve waarden hebben).
- De IShape.RawFrame eigenschap retourneert een IShapeFrame‑object waarvan elke eigenschap een ongedefinieerde waarde kan hebben (met name FlipH of FlipV kan de waarde NullableBool.NotDefined hebben).