---
title: Beheer presentatie‑plaatsaanduidingen in Java
linktitle: Beheer plaatsaanduidingen
type: docs
weight: 10
url: /nl/java/manage-placeholder/
keywords:
- plaatsaanduiding
- tekstplaatsaanduiding
- afbeeldingplaatsaanduiding
- grafiekplaatsaanduiding
- prompttekst
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer plaatsaanduidingen moeiteloos in Aspose.Slides voor Java: vervang tekst, pas prompts aan en stel afbeeldings‑transparantie in PowerPoint en OpenDocument in."
---
## **Overzicht**

Aspose.Slides stelt u in staat om presentatietplaatsaanduidingen programmatisch te beheren. Dit artikel legt uit hoe u plaatsaanduidingen op dia's kunt vinden en hun tekst kunt wijzigen, aangepaste prompttekst kunt instellen voor plaatsaanduidingslay-outs, en de transparantie van een afbeelding die als achtergrond van een plaatsaanduiding wordt gebruikt kunt aanpassen. Het bevat ook een korte FAQ die het verschil tussen basisplaatsaanduidingen en lokale vormen verduidelijkt, uitlegt hoe plaatsaanduidingswijzigingen kunnen worden toegepast via lay‑outs of masters, en wijst op het beheer van header‑ en footer‑plaatsaanduidingen.

## **Tekst wijzigen in een plaatsaanduiding**
Met [Aspose.Slides for Java](/slides/nl/java/) kunt u plaatsaanduidingen op dia's in presentaties vinden en aanpassen. Aspose.Slides stelt u in staat om wijzigingen aan te brengen in de tekst van een plaatsaanduiding.

**Voorwaarde**: U hebt een presentatie nodig die een plaatsaanduiding bevat. Zo’n presentatie kunt u maken met de standaard Microsoft PowerPoint‑app.

Zo gebruikt u Aspose.Slides om de tekst in de plaatsaanduiding in die presentatie te vervangen:

1. Instantieer de [`Presentation`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse en geef de presentatie als argument door.
2. Haal een dia‑referentie op via de index.
3. Itereer door de vormen om de plaatsaanduiding te vinden.
4. Cast de plaatsaanduidingsvorm naar een [`AutoShape`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/AutoShape) en wijzig de tekst via het [`TextFrame`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/TextFrame) dat gekoppeld is aan de [`AutoShape`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/AutoShape).
5. Sla de aangepaste presentatie op.

Deze Java‑code toont hoe u de tekst in een plaatsaanduiding kunt wijzigen:

```java
// Instantieert een Presentation-klasse
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Benadert de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Itereert door de vormen om de plaatsaanduiding te vinden
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Wijzigt de tekst in elke plaatsaanduiding
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Slaat de presentatie op naar schijf
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Prompttekst instellen in een plaatsaanduiding**
Standaard‑ en vooraf gebouwde lay‑outs bevatten plaatsaanduidings‑promptteksten zoals ***Klik om een titel toe te voegen*** of ***Klik om een ondertitel toe te voegen***. Met Aspose.Slides kunt u uw gewenste promptteksten in plaatsaanduidings‑lay‑outs invoegen.

Deze Java‑code laat zien hoe u de prompttekst in een plaatsaanduiding instelt:

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

## **Transparantie van plaatsaanduidingsafbeelding instellen**
Aspose.Slides stelt u in staat om de transparantie van de achtergrondafbeelding in een tekst‑plaatsaanduiding in te stellen. Door de transparantie van de afbeelding in zo’n kader aan te passen, kunt u de tekst of de afbeelding laten opvallen (afhankelijk van de kleuren van de tekst en de afbeelding).

Deze Java‑code laat zien hoe u de transparantie voor een afbeelding‑achtergrond (binnen een vorm) instelt:

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

**Wat is een basisplaatsaanduiding en hoe verschilt deze van een lokale vorm op een dia?**

Een basisplaatsaanduiding is de oorspronkelijke vorm op een lay‑out of master waarvan de vorm van de dia erft — type, positie en een deel van de opmaak komen van die vorm. Een lokale vorm is onafhankelijk; als er geen basisplaatsaanduiding is, is er geen erfenis.

**Hoe kan ik alle titels of bijschriften in een presentatie bijwerken zonder over elke dia te itereren?**

Bewerk de overeenkomstige plaatsaanduiding op de lay‑out of de master. Dia's die op die lay‑outs/masters zijn gebaseerd, erven de wijziging automatisch.

**Hoe beheer ik de standaard header/footer‑plaatsaanduidingen — datum & tijd, paginanummer en footer‑tekst?**

Gebruik de HeaderFooter‑beheerders op het juiste bereik (normale dia's, lay‑outs, master, notities/hand‑outs) om die plaatsaanduidingen in of uit te schakelen en hun inhoud in te stellen.