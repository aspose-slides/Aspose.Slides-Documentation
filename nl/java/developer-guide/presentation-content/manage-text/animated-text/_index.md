---
title: Animeer PowerPoint-tekst in Java
linktitle: Geanimeerde tekst
type: docs
weight: 60
url: /nl/java/animated-text/
keywords:
- geanimeerde tekst
- tekstanimatie
- geanimeerde alinea
- alinea-animatie
- animatie-effect
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Maak dynamische geanimeerde tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides for Java, met gemakkelijk te volgen, geoptimaliseerde Java-codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe u met geanimeerde tekst in Aspose.Slides kunt werken door animatie‑effecten toe te passen op individuele alinea’s en de al toegewezen effecten op alinea’s in een tekstvak op te halen. Het richt zich op de API‑methoden die worden gebruikt om animatie op alinea‑niveau toe te voegen en bestaande animatie‑effecten van alinea’s in een presentatie te inspecteren.

## **Animatie-effecten toevoegen aan alinea's**

We hebben de [**addEffect()**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) methode toegevoegd aan de [**Sequence**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Sequence) en [**ISequence**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISequence) klassen. Deze methode stelt u in staat om animatie‑effecten toe te voegen aan één alinea. Deze voorbeeldcode laat zien hoe u een animatie‑effect aan één alinea kunt toevoegen:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // selecteer alinea om effect toe te voegen
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // voeg Fly-animatieeffect toe aan geselecteerde alinea
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Animatie-effecten van alinea's ophalen**

U zou kunnen besluiten de animatie‑effecten die aan een alinea zijn toegevoegd te achterhalen — bijvoorbeeld in een scenario waarin u de animatie‑effecten in een alinea wilt ophalen omdat u die effecten wilt toepassen op een andere alinea of vorm.

Aspose.Slides for Java maakt het mogelijk om alle animatie‑effecten op te halen die zijn toegepast op alinea’s binnen een tekstvak (vorm). Deze voorbeeldcode laat zien hoe u de animatie‑effecten in een alinea kunt ophalen:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```

## **FAQ**

**Hoe verschillen tekstanimaties van dia‑overgangen, en kunnen ze gecombineerd worden?**

Tekstanimaties regelen het gedrag van objecten in de tijd op een dia, terwijl [transitions](/slides/nl/java/slide-transition/) bepalen hoe dia's veranderen. Ze zijn onafhankelijk en kunnen samen worden gebruikt; de afspeelvolgorde wordt bepaald door de animatietijdlijn en de overgangsinstellingen.

**Worden tekstanimaties behouden bij exporteren naar PDF of afbeeldingen?**

Nee. PDF‑bestanden en rasterafbeeldingen zijn statisch, dus u ziet één statische weergave van de dia zonder beweging. Om beweging te behouden, gebruikt u [video](/slides/nl/java/convert-powerpoint-to-video/) of [HTML](/slides/nl/java/export-to-html5/) export.

**Werken tekstanimaties in lay‑outs en de dia‑master?**

Effecten die op layout-/master‑objecten worden toegepast, worden geërfd door dia's, maar hun timing en interactie met dia‑niveau animaties hangen af van de uiteindelijke volgorde op de dia.