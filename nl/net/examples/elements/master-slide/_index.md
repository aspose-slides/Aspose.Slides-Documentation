---
title: Masterdia
type: docs
weight: 30
url: /nl/net/examples/elements/master-slide/
keywords:
- masterdia
- masterdia toevoegen
- masterdia benaderen
- masterdia verwijderen
- ongebruikte masterdia
- code-voorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek voorbeelden van masterdia's in Aspose.Slides voor .NET: maak, bewerk en style masterdia's, tijdelijke aanduidingen en thema's in PPT, PPTX en ODP met duidelijke C#-code."
---
Master‑slides vormen het hoogste niveau van de slide‑erfhiërarchie in PowerPoint. Een **master slide** definieert gemeenschappelijke ontwerpelementen zoals achtergronden, logo’s en tekstopmaak. **Layout slides** erven van master slides, en **normal slides** erven van layout slides.

Dit artikel laat zien hoe je master‑slides kunt maken, wijzigen en beheren met Aspose.Slides voor .NET.

## **Een master slide toevoegen**

Dit voorbeeld toont hoe je een nieuwe master‑slide maakt door de standaard slide te klonen. Vervolgens voegt het een banner met de bedrijfsnaam toe aan alle slides via layout‑erfenis.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // Kloon de standaard masterdia.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // Voeg een banner met bedrijfsnaam toe aan de bovenkant van de masterdia.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Wijs de nieuwe masterdia toe aan een layoutdia.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // Wijs de layoutdia toe aan de eerste dia in de presentatie.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **Opmerking 1:** Master‑slides bieden een manier om consistente branding of gedeelde designelementen toe te passen op alle slides. Wijzigingen die op de master worden aangebracht, worden automatisch doorgevoerd in afhankelijke layout‑ en normale slides.

> 💡 **Opmerking 2:** Vormen of opmaak die aan een master‑slide worden toegevoegd, worden geërfd door layout‑slides en vervolgens door alle normale slides die die layouts gebruiken.  
> De afbeelding hieronder laat zien hoe een tekstvak dat aan een master‑slide is toegevoegd, automatisch wordt weergegeven op de uiteindelijke slide.

![Voorbeeld van master‑erfenis](master-slide-banner.png)

## **Toegang tot een master slide**

Je kunt master‑slides benaderen via de `Presentation.Masters`‑collectie. Hier lees je hoe je ze kunt ophalen en ermee kunt werken:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // Toegang tot de eerste masterdia.
    var firstMasterSlide = presentation.Masters[0];

    // Verander het achtergrondtype.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **Een master slide verwijderen**

Master‑slides kunnen worden verwijderd op basis van index of via een referentie.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // Verwijder een masterdia op basis van index.
    presentation.Masters.RemoveAt(0);

    // Verwijder een masterdia op basis van referentie.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **Ongebruikte master slides verwijderen**

Sommige presentaties bevatten master‑slides die niet worden gebruikt. Het verwijderen van deze slides kan helpen de bestandsgrootte te verkleinen.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // Verwijder alle ongebruikte masterdia's (ook die gemarkeerd als Preserve).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```