---
title: Animeer PowerPoint-tekst in Python via Java
linktitle: Geanimeerde tekst
type: docs
weight: 60
url: /nl/python-java/animated-text/
keywords:
- geanimeerde tekst
- tekstanimatie
- geanimeerde alinea
- alinea-animatie
- animatie-effect
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Maak dynamische, geanimeerde tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via Java, met gemakkelijk te volgen, geoptimaliseerde Python-codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe je in Aspose.Slides kunt werken met geanimeerde tekst door animatie‑effecten toe te passen op individuele alinea’s en de reeds toegewezen effecten van alinea’s in een tekstvak op te halen. Het richt zich op de API‑methoden die gebruikt worden om animatie op alinea‑niveau toe te voegen en om bestaande animatie‑effecten van alinea’s in een presentatie te inspecteren.

## **Animatie‑effecten toevoegen aan alinea’s**

De [addEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sequence/#addEffect)‑methode van de [Sequence](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sequence/)‑klasse maakt het mogelijk om animatie‑effecten toe te voegen aan één enkele alinea. Deze voorbeeldcode laat zien hoe je een animatie‑effect toevoegt aan één alinea:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Selecteer de alinea om een effect aan toe te voegen.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Voeg een Fly-animatieeffect toe aan de geselecteerde alinea.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animatie‑effecten van alinea’s ophalen**

Je wilt misschien de animatie‑effecten die op een alinea zijn toegepast ophalen – bijvoorbeeld om die effecten toe te passen op een andere alinea of vorm.

Aspose.Slides for Python via Java maakt het mogelijk om alle animatie‑effecten op te halen die zijn toegepast op alinea’s in een tekstvak (vorm). Deze voorbeeldcode laat zien hoe je de animatie‑effecten van een alinea ophaalt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **FAQ**

**Hoe verschillen tekstanimaties van diaovergangen, en kunnen ze gecombineerd worden?**

Tekstanimaties bepalen het gedrag van een object in de tijd op een dia, terwijl [transitions](/slides/nl/python-java/slide-transition/) bepalen hoe dia’s wisselen. Ze zijn onafhankelijk en kunnen samen gebruikt worden; de afspeelvolgorde wordt bepaald door de animatietijdlijn en de overgangsinstellingen.

**Worden tekstanimaties behouden bij het exporteren naar PDF of afbeeldingen?**

Nee. PDF- en rasterafbeeldingen zijn statisch, dus je ziet slechts één momentopname van de dia zonder beweging. Om de beweging te behouden, gebruik je [video](/slides/nl/python-java/convert-powerpoint-to-video/) of [HTML](/slides/nl/python-java/export-to-html5/) export.

**Werken tekstanimaties in lay-outs en de dia-master?**

Effecten die op lay-out-/master-objecten worden toegepast, worden geërfd door de dia’s, maar hun timing en interactie met animaties op dia-niveau hangen af van de definitieve volgorde op de dia.