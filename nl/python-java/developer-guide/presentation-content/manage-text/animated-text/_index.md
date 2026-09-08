---
title: "Animeer PowerPoint-tekst in Python via Java"
linktitle: "Geanimeerde tekst"
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
description: "Maak dynamische geanimeerde tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via Java, met gemakkelijk te volgen, geoptimaliseerde Python-codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe u met geanimeerde tekst in Aspose.Slides kunt werken door animatie-effecten toe te passen op individuele alinea's en de reeds toegewezen effecten aan alinea's in een tekstvak op te halen. Het richt zich op de API-methoden die worden gebruikt om animatie op alinea-niveau toe te voegen en bestaande animatie-effecten van alinea's in een presentatie te inspecteren.

## **Animatie-effecten toevoegen aan alinea's**

De [addEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sequence/#addEffect) methode van de [Sequence](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sequence/) klasse stelt u in staat om animatie-effecten toe te voegen aan één alinea. Deze voorbeeldcode laat zien hoe u een animatie-effect aan één alinea kunt toevoegen:

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

    # Voeg een Fly-animatie-effect toe aan de geselecteerde alinea.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animatie-effecten van alinea's ophalen**

U kunt besluiten de animatie-effecten die aan een alinea zijn toegevoegd te achterhalen – bijvoorbeeld in een scenario waarin u de animatie-effecten van een alinea wilt ophalen omdat u die wilt toepassen op een andere alinea of shape.

Aspose.Slides voor Python via Java stelt u in staat om alle animatie-effecten op te halen die zijn toegepast op alinea's die zich in een tekstvak (shape) bevinden. Deze voorbeeldcode laat zien hoe u de animatie-effecten in een alinea kunt ophalen:

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

Tekstanimaties regelen het gedrag van objecten in de loop van de tijd op een dia, terwijl [overgangen](/slides/nl/python-java/slide-transition/) bepalen hoe dia’s wisselen. Ze zijn onafhankelijk van elkaar en kunnen samen worden gebruikt; de afspeelvolgorde wordt bepaald door de animatietijdlijn en de overgangsinstellingen.

**Worden tekstanimaties behouden bij het exporteren naar PDF of afbeeldingen?**

Nee. PDF-bestanden en rasterafbeeldingen zijn statisch, dus u ziet slechts één toestand van de dia zonder beweging. Om beweging te behouden, exporteer naar [video](/slides/nl/python-java/convert-powerpoint-to-video/) of [HTML](/slides/nl/python-java/export-to-html5/).

**Werken tekstanimaties in lay-outs en de dia-master?**

Effecten die op lay-out/master-objecten worden toegepast, worden geërfd door dia's, maar hun timing en interactie met animaties op dia-niveau hangen af van de uiteindelijke volgorde op de dia.