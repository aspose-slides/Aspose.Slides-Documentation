---
title: Beheer presentatie‑placeholders op Android
linktitle: Beheer placeholders
type: docs
weight: 10
url: /nl/androidjava/manage-placeholder/
keywords:
- placeholder
- tekstplaceholder
- afbeeldingsplaceholder
- grafiekplaceholder
- prompt‑tekst
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer eenvoudig placeholders in Aspose.Slides voor Android via Java: vervang tekst, pas prompts aan en stel transparantie van afbeeldingen in in PowerPoint en OpenDocument."
---
## **Overzicht**

Aspose.Slides stelt u in staat om presentatie‑placeholders programmatisch te beheren. Dit artikel legt uit hoe u placeholders op dia’s kunt vinden en hun tekst kunt wijzigen, aangepaste prompt‑tekst voor placeholder‑layouts kunt instellen en de transparantie van een afbeelding die als placeholder‑achtergrond wordt gebruikt kunt aanpassen. Het bevat ook een korte FAQ die het verschil tussen basis‑placeholders en lokale vormen verduidelijkt, uitlegt hoe placeholder‑wijzigingen via layouts of masters kunnen worden toegepast, en wijst op het beheer van header‑ en footer‑placeholders.

## **Tekst wijzigen in een placeholder**
Met [Aspose.Slides for Android via Java](/slides/nl/androidjava/) kunt u placeholders op dia’s in presentaties vinden en wijzigen. Aspose.Slides stelt u in staat om de tekst in een placeholder aan te passen.

**Voorwaarde**: U heeft een presentatie nodig die een placeholder bevat. Zo’n presentatie kunt u maken met de standaard Microsoft PowerPoint‑app.

Zo gebruikt u Aspose.Slides om de tekst in de placeholder in die presentatie te vervangen:

1. Instantieer de [`Presentation`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse en geef de presentatie als argument door.
2. Haal een dia‑referentie op via de index.
3. Itereer door de shapes om de placeholder te vinden.
4. Cast de placeholder‑shape naar een [`AutoShape`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/AutoShape) en wijzig de tekst via het [`TextFrame`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TextFrame) dat aan de [`AutoShape`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/AutoShape) is gekoppeld.
5. Sla de gewijzigde presentatie op.

Deze Java‑code laat zien hoe u de tekst in een placeholder wijzigt:

```java
// Instantieert een Presentation-klasse
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Toegang tot de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Loopt door de shapes om de placeholder te vinden
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Wijzigt de tekst in elke placeholder
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Slaat de presentatie op naar schijf
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Prompt‑tekst instellen in een placeholder**
Standaard‑ en vooraf gebouwde layouts bevatten placeholder‑prompt‑teksten zoals ***Click to add a title*** of ***Click to add a subtitle***. Met Aspose.Slides kunt u uw eigen prompt‑teksten in placeholder‑layouts invoegen.

Deze Java‑code laat zien hoe u de prompt‑tekst in een placeholder instelt:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Itereert door de dia
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint toont "Klik om een titel toe te voegen"
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Voegt ondertitel toe
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Transparantie van placeholder‑afbeelding instellen**

Aspose.Slides stelt u in staat de transparantie van de achtergrondafbeelding in een tekst‑placeholder in te stellen. Door de transparantie van de afbeelding in zo’n frame aan te passen, kunt u de tekst of de afbeelding laten opvallen (afhankelijk van de kleuren van de tekst en de afbeelding).

Deze Java‑code laat zien hoe u de transparantie van een afbeeldingachtergrond (binnen een shape) instelt:

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Wat is een basis‑placeholder en hoe verschilt deze van een lokale shape op een dia?**

Een basis‑placeholder is de oorspronkelijke shape op een layout of master waarvan de shape op de dia erft — type, positie en een deel van de opmaak komen hiervan. Een lokale shape is onafhankelijk; als er geen basis‑placeholder is, geldt er geen overerving.

**Hoe kan ik alle titels of ondertitels in een presentatie bijwerken zonder over elke dia te itereren?**

Bewerk de betreffende placeholder op de layout of de master. Dia's die op die layouts/master zijn gebaseerd, zullen de wijziging automatisch overnemen.

**Hoe kan ik de standaard header/footer‑placeholders—datum & tijd, dia‑nummer en voettekst—beheren?**

Gebruik de HeaderFooter‑managers op de juiste scope (normale dia's, layouts, master, notities/hand-outs) om die placeholders in of uit te schakelen en hun inhoud in te stellen.