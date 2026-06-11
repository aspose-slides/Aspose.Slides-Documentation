---
title: Layoutbild
type: docs
weight: 20
url: /sv/net/examples/elements/layout-slide/
keywords:
- layoutbild
- lägga till layoutbild
- komma åt layoutbild
- ta bort layoutbild
- oanvänd layoutbild
- klona layoutbild
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Behärska layoutbilder i Aspose.Slides för .NET: välj, tillämpa och anpassa bildlayouter, platshållare och masterbilder med C#‑exempel för PPT-, PPTX- och ODP‑presentationer."
---
Den här artikeln visar hur du arbetar med **Layout Slides** i Aspose.Slides för .NET. En layout‑bild definierar designen och formateringen som ärvts av vanliga bilder. Du kan lägga till, komma åt, klona och ta bort layout‑bilder, samt rensa bort oanvända för att minska presentationens storlek.

## **Add a Layout Slide**

Du kan skapa en anpassad layout‑bild för att definiera återanvändbar formatering. Till exempel kan du lägga till en textruta som visas på alla bilder som använder den här layouten.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // Skapa en layoutbild med en tom layouttyp och ett anpassat namn.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // Lägg till en textruta på layoutbilden.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Lägg till två bilder med denna layout; båda kommer att ärva texten från layouten.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Note 1:** Layout‑bilder fungerar som mallar för enskilda bilder. Du kan definiera gemensamma element en gång och återanvända dem i många bilder.

> 💡 **Note 2:** När du lägger till former eller text i en layout‑bild kommer alla bilder som baseras på den layouten automatiskt att visa detta delade innehåll.  
> Skärmbilden nedanför visar två bilder, där var och en ärver en textruta från samma layout‑bild.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Access a Layout Slide**

Layout‑bilder kan nås via index eller via layout‑typ (t.ex. `Blank`, `Title`, `SectionHeader` osv.).

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Åtkomst till en layoutbild efter index.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // Åtkomst till en layoutbild efter typ.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Remove a Layout Slide**

Du kan ta bort en specifik layout‑bild om den inte längre behövs.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Hämta en layoutbild efter typ och ta bort den.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Remove Unused Layout Slides**

För att minska presentationens storlek kan du vilja ta bort layout‑bilder som inte används av några vanliga bilder.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Tar automatiskt bort alla layoutbilder som inte refereras av någon bild.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **Clone a Layout Slide**

Du kan duplicera en layout‑bild med metoden `AddClone`.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Hämta en befintlig layoutbild efter typ.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Klona layoutbilden till slutet av samlingen av layoutbilder.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Summary:** Layout‑bilder är kraftfulla verktyg för att hantera enhetlig formatering över bilder. Aspose.Slides ger full kontroll över att skapa, hantera och optimera layout‑bilder.