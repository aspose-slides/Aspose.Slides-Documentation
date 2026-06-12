---
title: Layoutdia
type: docs
weight: 20
url: /nl/net/examples/elements/layout-slide/
keywords:
- layoutdia
- layoutdia toevoegen
- layoutdia openen
- layoutdia verwijderen
- ongebruikte layoutdia
- layoutdia klonen
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Master layoutdia's in Aspose.Slides voor .NET: kies, pas toe en pas de dia-lay-outs, plaatshouders en masters aan met C#-voorbeelden voor PPT, PPTX en ODP-presentaties."
---
Dit artikel laat zien hoe u met **Layout Slides** in Aspose.Slides voor .NET werkt. Een layout slide definieert het ontwerp en de opmaak die normale dia's overnemen. U kunt layout slides toevoegen, openen, klonen en verwijderen, en ongebruikte slides opruimen om de grootte van de presentatie te verkleinen.

## **Een layout slide toevoegen**

U kunt een aangepaste layout slide maken om herbruikbare opmaak te definiëren. Bijvoorbeeld, u kunt een tekstvak toevoegen dat op alle dia's met deze layout verschijnt.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // Maak een layoutdia met een leeg layouttype en een aangepaste naam.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // Voeg een tekstvak toe aan de layoutdia.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Voeg twee dia's toe met deze layout; beide erven de tekst van de layout.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Opmerking 1:** Layout slides fungeren als sjablonen voor individuele dia's. U kunt gemeenschappelijke elementen één keer definiëren en ze vervolgens in veel dia's hergebruiken.

> 💡 **Opmerking 2:** Wanneer u vormen of tekst toevoegt aan een layout slide, wordt deze gedeelde inhoud automatisch weergegeven op alle dia's die op die layout zijn gebaseerd.  
> De schermafbeelding hieronder toont twee dia's, elk een tekstvak overgenomen van dezelfde layout slide.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Een layout slide openen**

Layout slides kunnen worden geopend op basis van index of op basis van layout‑type (bijv. `Blank`, `Title`, `SectionHeader`, enz.).

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Toegang tot een layoutdia via index.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // Toegang tot een layoutdia via type.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Een layout slide verwijderen**

U kunt een specifieke layout slide verwijderen als deze niet meer nodig is.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Haal een layoutdia op via type en verwijder deze.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Ongebruikte layout slides verwijderen**

Om de grootte van de presentatie te verkleinen, kunt u layout slides verwijderen die door geen enkele normale dia worden gebruikt.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Verwijdert automatisch alle layoutdia's die niet door een dia worden gebruikt.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **Een layout slide klonen**

U kunt een layout slide dupliceren met de `AddClone`‑methode.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Haal een bestaande layoutdia op via type.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Kloon de layoutdia naar het einde van de layoutdia-collectie.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Samenvatting:** Layout slides zijn krachtige hulpmiddelen voor het consistent beheren van opmaak over dia's heen. Aspose.Slides biedt volledige controle over het maken, beheren en optimaliseren van layout slides.