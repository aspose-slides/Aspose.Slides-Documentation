---
title: Verbeter PowerPoint‑presentaties met animaties in Python
linktitle: PowerPoint‑animatie
type: docs
weight: 150
url: /nl/python-net/powerpoint-animation/
keywords:
- animatie toevoegen
- animatie bijwerken
- animatie wijzigen
- animatie verwijderen
- animatie beheren
- animatie controleren
- animatie‑effect
- PowerPoint‑animatie
- animatie‑tijdlijn
- interactieve animatie
- aangepaste animatie
- vorm‑animatie
- geanimeerde grafiek
- geanimeerde tekst
- geanimeerde vorm
- geanimeerd OLE‑object
- geanimeerde afbeelding
- geanimeerde tabel
- PowerPoint‑presentatie
- Python
- Aspose.Slides
description: "Ontdek de mogelijkheden van Aspose.Slides for Python via .NET bij het verwerken van PowerPoint‑animaties. Deze algemene overzicht belicht de belangrijkste kenmerken en biedt inzichten om uw presentaties te verbeteren."
---
## **Inleiding**

Presentaties zijn ontworpen om informatie over te brengen, dus is hun visuele uitstraling en interactieve gedrag een belangrijk aandachtspunt tijdens het maken.

**PowerPoint-animatie** speelt een belangrijke rol bij het aantrekkelijk en boeiend maken van een presentatie voor de kijker. Aspose.Slides for Python via .NET biedt een breed scala aan opties om animatie toe te voegen aan een PowerPoint-presentatie. U kunt:

- Diverse animatie‑effecten toepassen op vormen, diagrammen, tabellen, OLE‑objecten en andere elementen.
- Meerdere animatie‑effecten gebruiken op één vorm.
- Effecten beheersen via de animatietijdlijn.
- Aangepaste animaties maken.

In Aspose.Slides for Python via .NET kunnen animatie‑effecten op vormen worden toegepast. Omdat elk element op een dia — inclusief tekst, afbeeldingen, OLE‑objecten en tabellen — wordt behandeld als een vorm, kunt u animatie‑effecten op elk element van de dia toepassen.

De [aspose.slides.animation](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/) namespace biedt de klassen voor het werken met PowerPoint‑animaties.

## **Installatie**

```bash
pip install aspose.slides
```

## **Een animatie‑effect toevoegen aan een vorm in Python**

Animatie‑effecten bestaan in de hoofdreeks van een dia. Voeg een vorm toe en roep vervolgens `add_effect` aan op `slide.timeline.main_sequence`, waarbij u het type effect, de subtype en de trigger die het start, doorgeeft.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

Het opgeslagen bestand bevat één effect op de eerste dia: de rechthoek vliegt van links naar binnen gedurende twee seconden wanneer de presentator klikt. Bij het heropenen en lezen van `slide.timeline.main_sequence` wordt dat effect teruggegeven, zodat de animatie de volledige cyclus overleeft en niet alleen in het geheugen bestaat.

## **Animatie‑effecten**

Aspose.Slides ondersteunt **meer dan 150 animatie‑effecten**, waaronder basis‑effecten zoals Bounce, PathFootball en Zoom, evenals gespecialiseerde effecten zoals OLEObjectShow en OLEObjectOpen. De volledige lijst vindt u in de [EffectType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effecttype/) enumeratie.

Daarnaast kunnen deze animatie‑effecten worden gecombineerd met de volgende effecten:

- [ColorEffect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/seteffect/)

## **Aangepaste animatie**

Voor volledige Python‑voorbeelden die gedrag en bewerkbare bewegingspaden creëren, inspecteren en aanpassen, zie [Custom Animation](/slides/nl/python-net/custom-animation/).

U kunt uw eigen **aangepaste animaties** maken in Aspose.Slides door meerdere gedragingen te combineren tot één effect.

[Behavior](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behavior/) is een bouwblok van een PowerPoint‑animatie‑effect. Combineer behaviors om een effect aan te passen, of voeg een behavior toe om een vooraf gedefinieerd effect uit te breiden. Herhaling wordt geconfigureerd via timing‑instellingen in plaats van een apart repeat‑behavior.

[Animation Point](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/point/) geeft het moment of de positie aan waarop een behavior wordt toegepast (een keyframe).

## **Animatie‑tijdlijn**

[Sequence](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/) is een verzameling van animatie‑effecten die op verschillende vormen gericht kunnen zijn.

[Timeline](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/animationtimeline/) is de verzameling van sequenties die op een specifieke dia wordt gebruikt. Het werd geïntroduceerd in PowerPoint 2002. In eerdere versies van PowerPoint was het toevoegen van animatie‑effecten moeilijk en vaak vereist het workarounds. Timeline vervangt de oude `AnimationSettings`‑klasse en biedt een duidelijker objectmodel voor PowerPoint‑animaties. Elke dia kan slechts één animatie‑tijdlijn hebben.

## **Interactieve animatie**

[Trigger](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effecttriggertype/) stelt u in staat om gebruikersacties (bijv. een knopklikken) te definiëren die een specifieke animatie starten. Triggers werden alleen toegevoegd in de nieuwste versies van PowerPoint.

## **Vorm‑animatie**

Aspose.Slides maakt het mogelijk om animaties toe te passen op vormen — zoals tekst, rechthoeken, lijnen, frames, OLE‑objecten en meer.

{{% alert color="info" title="Note" %}}
Lees meer [**Over vorm‑animatie**](/slides/nl/python-net/shape-animation/).
{{% /alert %}}

## **Geanimeerde diagrammen**

Om geanimeerde diagrammen te maken, gebruikt u dezelfde klassen als voor vormen. PowerPoint‑animaties kunnen echter alleen op diagramcategorieën of diagramreeksen worden toegepast. U kunt ook een animatie‑effect toepassen op een individueel categorie‑element of reeks‑element.

{{% alert color="info" title="Note" %}}
Lees meer [**Over geanimeerde diagrammen**](/slides/nl/python-net/animated-charts/).
{{% /alert %}}

## **Geanimeerde tekst**

Naast het animeren van tekst kunt u animatie toepassen op een alinea.

{{% alert color="info" title="Note" %}}
Lees meer [**Over geanimeerde tekst**](/slides/nl/python-net/animated-text/).
{{% /alert %}}

## **FAQ**

**Wordt animatie behouden bij exporteren naar PDF?**

Nee. PDF is een statisch formaat, dus animaties en [dia‑overgangen](/slides/nl/python-net/slide-transition/) worden niet afgespeeld. Als u beweging nodig heeft, exporteer dan naar [HTML5](/slides/nl/python-net/export-to-html5/), [animated GIF](/slides/nl/python-net/convert-powerpoint-to-animated-gif/), of [video](/slides/nl/python-net/convert-powerpoint-to-video/) in plaats daarvan.

**Kan ik een geanimeerde presentatie omzetten naar een video en de framesnelheid en frame‑grootte regelen?**

Ja. U kunt de presentatie [renderen als frames](/slides/nl/python-net/convert-powerpoint-to-video/) en ze coderen tot een video (bijv. via ffmpeg), waarbij u de FPS en resolutie kiest. Animaties en dia‑overgangen worden afgespeeld tijdens het renderen.

**Blijven animaties behouden bij het werken met ODP (niet alleen PPTX)?**

PPT, PPTX en ODP worden ondersteund voor [lezen](/slides/nl/python-net/open-presentation/) en [schrijven](/slides/nl/python-net/save-presentation/), maar dit garandeert geen behoud van animaties. Aangepaste animatiegegevens kunnen verloren gaan bij conversie naar ODP. Zie [Custom Animation](/slides/nl/python-net/custom-animation/) voor voorbeelden en richtlijnen om de compatibiliteit van het formaat te controleren.