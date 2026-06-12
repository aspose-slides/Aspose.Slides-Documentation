---
title: Plaatsaanduidingen in presentaties beheren in .NET
linktitle: Plaatsaanduidingen beheren
type: docs
weight: 10
url: /nl/net/manage-placeholder/
keywords:
- plaatsaanduiding
- tekstplaatsaanduiding
- afbeeldingsplaatsaanduiding
- grafiekplaatsaanduiding
- prompttekst
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer moeiteloos plaatsaanduidingen in Aspose.Slides voor .NET: vervang tekst, pas prompts aan en stel de transparantie van afbeeldingen in PowerPoint en OpenDocument in."
---
## **Overzicht**

Aspose.Slides stelt u in staat om presentatiesleufplaatsen programmatisch te beheren. Dit artikel legt uit hoe u plaatsaanduidingen op dia's kunt vinden en hun tekst kunt wijzigen, aangepaste prompttekst kunt instellen voor lay‑out placeholders, en de transparantie van een afbeelding die als achtergrond van een placeholder wordt gebruikt kunt aanpassen. Het bevat ook een korte FAQ die het verschil tussen basisplaatsaanduidingen en lokale vormen verduidelijkt, uitlegt hoe wijzigingen aan placeholders kunnen worden toegepast via lay‑outs of masters, en wijst naar het beheer van header‑ en footer‑plaatsaanduidingen.

## **Tekst wijzigen in een placeholder**
Met [Aspose.Slides for .NET](/slides/nl/net/) kunt u placeholders op dia's in presentaties vinden en aanpassen. Aspose.Slides stelt u in staat om wijzigingen aan te brengen in de tekst van een placeholder.

**Voorwaarde**: U hebt een presentatie nodig die een placeholder bevat. Zo'n presentatie kunt u maken met de standaard Microsoft PowerPoint‑applicatie.

Zo gebruikt u Aspose.Slides om de tekst in de placeholder van die presentatie te vervangen:

1. Instantieer de [`Presentation`](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse en geef de presentatie als argument door.
2. Haal een dia‑referentie op via de index.
3. Itereer door de shapes om de placeholder te vinden.
4. Cast de placeholder‑shape naar een [`AutoShape`](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/) en wijzig de tekst via het [`TextFrame`](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/) dat gekoppeld is aan de [`AutoShape`](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/). 
5. Sla de gewijzigde presentatie op.

Deze C#‑code toont hoe u de tekst in een placeholder wijzigt:

```c#
// Instantiëert een Presentation-klasse
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // Toegang tot de eerste dia
    ISlide sld = pres.Slides[0];

    // Itereert door shapes om de placeholder te vinden
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // Wijzigt de tekst in elke placeholder
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // Slaat de presentatie op naar schijf
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Prompttekst instellen in een placeholder**
Standaard‑ en vooraf gebouwde lay‑outs bevatten prompt‑teksten voor placeholders, zoals ***Click to add a title*** of ***Click to add a subtitle***. Met Aspose.Slides kunt u uw eigen gewenste prompt‑teksten in placeholder‑lay‑outs invoegen.

Deze C#‑code laat zien hoe u de prompttekst in een placeholder instelt:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Itereert door de dia
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint toont "Click to add title"
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Voegt ondertitel toe
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **Transparantie van placeholder‑afbeelding instellen**

Aspose.Slides stelt u in staat de transparantie van de achtergrondafbeelding in een tekst‑placeholder in te stellen. Door de transparantie van de afbeelding in zo’n frame aan te passen, kunt u de tekst of de afbeelding laten opvallen (afhankelijk van de kleuren van de tekst en de afbeelding).

Deze C#‑code toont hoe u de transparantie voor een afbeeldingsachtergrond (binnen een shape) instelt:

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```

## **FAQ**

**Wat is een basis‑placeholder, en hoe verschilt deze van een lokale shape op een dia?**

Een basis‑placeholder is de oorspronkelijke shape op een lay‑out of master waar de shape van de dia van erft — type, positie en enkele opmaak komen van deze shape. Een lokale shape is onafhankelijk; als er geen basis‑placeholder bestaat, is er geen overerving.

**Hoe kan ik alle titels of bijschriften in een hele presentatie bijwerken zonder elke dia te doorlopen?**

Bewerk de betreffende placeholder op de lay‑out of de master. Dia's die gebaseerd zijn op die lay‑outs/master erven de wijziging automatisch.

**Hoe beheer ik de standaard header/footer‑placeholders — datum‑ en tijd, dia‑nummer en footer‑tekst?**

Gebruik de HeaderFooter‑managers op het juiste niveau (normale dia's, lay‑outs, master, notities/hand‑outs) om die placeholders in of uit te schakelen en hun inhoud in te stellen.