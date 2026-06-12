---
title: Animeer PowerPoint-tekst op Android
linktitle: Geanimeerde tekst
type: docs
weight: 60
url: /nl/androidjava/animated-text/
keywords:
- geanimeerde tekst
- tekstanimatie
- geanimeerde alinea
- alinea-animatie
- animatie-effect
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Creëer dynamische, geanimeerde tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Android, met gemakkelijk te volgen, geoptimaliseerde Java-voorbeeldcode."
---
## **Overzicht**

Dit artikel legt uit hoe u met geanimeerde tekst in Aspose.Slides kunt werken door animatie-effecten toe te passen op individuele alinea's en de al reeds toegewezen effecten op alinea's in een tekstvak op te halen. Het richt zich op de API-methoden die worden gebruikt om animatie op alinea-niveau toe te voegen en bestaande animatie-effecten van alinea's in een presentatie te inspecteren.

## **Animatie-effecten toevoegen aan alinea's**

We hebben de [**addEffect()**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) methode toegevoegd aan de klassen [**Sequence**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Sequence) en [**ISequence**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISequence). Deze methode stelt u in staat om animatie-effecten toe te voegen aan één alinea. Deze voorbeeldcode laat zien hoe u een animatie-effect aan één alinea kunt toevoegen:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // selecteer alinea om effect toe te voegen
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // voeg Fly-animatie-effect toe aan de geselecteerde alinea
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Animatie-effecten van alinea's ophalen**

U wilt misschien de animatie-effecten die aan een alinea zijn toegevoegd achterhalen - bijvoorbeeld in een scenario waarin u de animatie-effecten van een alinea wilt ophalen omdat u die wilt toepassen op een andere alinea of vorm.

Aspose.Slides for Android via Java stelt u in staat om alle animatie-effecten op te halen die zijn toegepast op alinea's die zich in een tekstvak (vorm) bevinden. Deze voorbeeldcode laat zien hoe u de animatie-effecten in een alinea kunt ophalen:

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

**Hoe verschillen tekstananimaties van dia-overgangen, en kunnen ze gecombineerd worden?**

Tekstanimaties bepalen het gedrag van een object in de tijd op een dia, terwijl [overgangen](/slides/nl/androidjava/slide-transition/) bepalen hoe dia's veranderen. Ze zijn onafhankelijk en kunnen samen worden gebruikt; de afspeelvolgorde wordt beheerd door de animatietijdlijn en de instellingen van de overgang.

**Worden tekstananimaties behouden bij export naar PDF of afbeeldingen?**

Nee. PDF- en rasterafbeeldingen zijn statisch, dus u ziet één enkele weergave van de dia zonder beweging. Om beweging te behouden, gebruikt u export naar [video](/slides/nl/androidjava/convert-powerpoint-to-video/) of [HTML](/slides/nl/androidjava/export-to-html5/).

**Werken tekstananimaties in lay-outs en de diamaster?**

Effecten die op lay-out-/masterobjecten worden toegepast, worden geërfd door de dia's, maar hun timing en interactie met animaties op dia-niveau hangen af van de uiteindelijke volgorde op de dia.