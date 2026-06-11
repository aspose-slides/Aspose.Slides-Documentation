---
title: Masterbild
type: docs
weight: 30
url: /sv/net/examples/elements/master-slide/
keywords:
- masterbild
- lägg till masterbild
- åtkomst till masterbild
- ta bort masterbild
- oanvänd masterbild
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Utforska Aspose.Slides för .NET master‑bild‑exempel: skapa, redigera och formatera master‑bilder, platshållare och teman i PPT, PPTX och ODP med tydlig C#‑kod."
---
Master slides utgör den översta nivån i slide‑arvshierarkin i PowerPoint. En **master slide** definierar gemensamma designelement såsom bakgrunder, logotyper och textformatering. **Layout slides** ärver från master slides, och **normal slides** ärver från layout slides.

Den här artikeln visar hur man skapar, modifierar och hanterar master slides med Aspose.Slides för .NET.

## **Lägg till en master slide**

Det här exemplet visar hur man skapar en ny master slide genom att klona standard‑sliden. Det lägger sedan till en företagsnamns‑banner på alla slides genom layout‑arv.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // Klona standard‑master‑bilden.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // Lägg till en banner med företagsnamnet högst upp på master‑bilden.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Tilldela den nya master‑bilden till en layout‑bild.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // Tilldela layout‑bilden till den första bilden i presentationen.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **Obs 1:** Master slides erbjuder ett sätt att tillämpa konsekvent varumärkesprofil eller delade designelement på alla slides. Alla ändringar som görs i master‑sliden återspeglas automatiskt i beroende layout‑ och normal‑slides.  
> 💡 **Obs 2:** Alla former eller formatering som läggs till på en master slide ärvs av layout‑slides och i sin tur av alla normal‑slides som använder dessa layouter.  
> Bilden nedan visar hur en textruta som lagts till på en master slide automatiskt renderas på den slutgiltiga sliden.

![Exempel på master‑arv](master-slide-banner.png)

## **Åtkomst till en master slide**

Du kan få åtkomst till master slides med `Presentation.Masters`‑samlingen. Så här hämtar och arbetar du med dem:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // Åtkomst till den första masterbilden.
    var firstMasterSlide = presentation.Masters[0];

    // Ändra bakgrundstypen.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **Ta bort en master slide**

Master slides kan tas bort antingen genom index eller genom referens.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // Ta bort en masterbild efter index.
    presentation.Masters.RemoveAt(0);

    // Ta bort en masterbild efter referens.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **Ta bort oanvända master slides**

Vissa presentationer innehåller master slides som inte används. Att ta bort dessa slides kan hjälpa till att minska filstorleken.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // Ta bort alla oanvända masterbilder (även de som är markerade som Preserve).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```