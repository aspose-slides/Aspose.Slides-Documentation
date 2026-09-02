---
title: Verbeter PowerPoint-presentaties met animaties in Python
linktitle: PowerPoint-animatie
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
- animatie-effect
- PowerPoint-animatie
- animatie-tijdlijn
- interactieve animatie
- aangepaste animatie
- vorm-animatie
- geanimeerde grafiek
- geanimeerde tekst
- geanimeerde vorm
- geanimeerd OLE-object
- geanimeerde afbeelding
- geanimeerde tabel
- PowerPoint-presentatie
- Python
- Aspose.Slides
description: "Ontdek de mogelijkheden van Aspose.Slides voor Python via .NET bij het verwerken van PowerPoint-animaties. Dit algemene overzicht belicht belangrijke functies en biedt inzichten om uw presentaties te verbeteren."
---
## **Inleiding**

Presentaties zijn ontworpen om informatie over te brengen, dus hun visuele uiterlijk en interactieve gedrag zijn belangrijke overwegingen tijdens het maken.

**PowerPoint-animatie** speelt een belangrijke rol bij het aantrekkelijk en boeiend maken van een presentatie voor kijkers. Aspose.Slides for Python via .NET biedt een breed scala aan opties om animatie toe te voegen aan een PowerPoint-presentatie. Je kunt:

- Diverse animatie‑effecten toepassen op vormen, grafieken, tabellen, OLE‑objecten en andere elementen.
- Meerdere animatie‑effecten gebruiken op één vorm.
- Effecten beheersen via de animatie‑tijdlijn.
- Aangepaste animaties maken.

In Aspose.Slides for Python via .NET kunnen animatie‑effecten op vormen worden toegepast. Omdat elk element op een dia — inclusief tekst, afbeeldingen, OLE‑objecten en tabellen — als een vorm wordt behandeld, kun je animatie‑effecten op elk element van de dia toepassen.

De [aspose.slides.animation](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/) namespace biedt de klassen voor het werken met PowerPoint‑animaties.

## **Installatie**

```bash
pip install aspose.slides
```

## **Een animatie‑effect toevoegen aan een vorm in Python**

Animatie‑effecten bevinden zich in de hoofd‑reeks van een dia. Voeg een vorm toe en roep vervolgens `add_effect` aan op `slide.timeline.main_sequence`, waarbij je het type effect, de subtype en de trigger die het start, doorgeeft.

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

Het opgeslagen bestand bevat één effect op de eerste dia: de rechthoek vliegt van links naar binnen over twee seconden wanneer de presentator klikt. Het opnieuw openen en uitlezen van `slide.timeline.main_sequence` geeft dat effect terug, zodat de animatie de volledige cyclus overleeft in plaats van alleen in het geheugen te bestaan.

## **Animatie‑effecten**

Aspose.Slides ondersteunt **meer dan 150 animatie‑effecten**, waaronder basis­effecten zoals Bounce, PathFootball en Zoom, evenals gespecialiseerde effecten zoals OLEObjectShow en OLEObjectOpen. Je kunt de volledige lijst vinden in de [EffectType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effecttype/) enumeratie.

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

Je kunt je eigen **aangepaste animaties** maken in Aspose.Slides door meerdere gedragingen te combineren in één effect.

[Behavior](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behavior/) is het basis‑bouwblok van elk PowerPoint‑animatie‑effect. Elk animatie‑effect bestaat in feite uit een reeks gedragingen die in één strategie of tijdlijn zijn geplaatst. Je kunt gedragingen eenmalig samenstellen tot een aangepaste animatie en deze hergebruiken in andere presentaties. Als je een nieuwe gedraging toevoegt aan een standaard PowerPoint‑animatie‑effect, wordt het een aangepaste animatie – bijvoorbeeld door een herhaal‑gedraging toe te voegen zodat de animatie meerdere keren wordt afgespeeld.

[Animation Point](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/point/) markeert het moment of de positie waarop een gedraging wordt toegepast (een keyframe).

## **Animatie‑tijdlijn**

[Sequence](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/) is een verzameling animatie‑effecten die op een specifieke vorm worden toegepast.

[Timeline](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/animationtimeline/) is de verzameling reeksen die op een specifieke dia worden gebruikt. Het werd geïntroduceerd in PowerPoint 2002. In eerdere versies van PowerPoint was het toevoegen van animatie‑effecten moeilijk en vaak vereist het omwegen. Timeline vervangt de oude `AnimationSettings`‑klasse en biedt een duidelijker objectmodel voor PowerPoint‑animatie. Elke dia kan slechts één animatie‑tijdlijn hebben.

## **Interactieve animatie**

[Trigger](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effecttriggertype/) stelt je in staat om gebruikersacties (bijv. een knop‑klik) te definiëren die een specifieke animatie starten. Triggers werden alleen toegevoegd in de nieuwste versies van PowerPoint.

## **Vorm‑animatie**

Aspose.Slides stelt je in staat animaties toe te passen op vormen — zoals tekst, rechthoeken, lijnen, frames, OLE‑objecten en meer.

{{% alert color="primary" %}}
Lees meer [**Over vorm‑animatie**](/slides/nl/python-net/shape-animation/).
{{% /alert %}}

## **Geanimeerde grafieken**

Om geanimeerde grafieken te maken, gebruik je dezelfde klassen als voor vormen. PowerPoint‑animaties kunnen echter alleen worden toegepast op grafiekcategorieën of grafiekreeksen. Je kunt ook een animatie‑effect toepassen op een individueel categorie‑element of serierelement.

{{% alert color="primary" %}}
Lees meer [**Over geanimeerde grafieken**](/slides/nl/python-net/animated-charts/).
{{% /alert %}}

## **Geanimeerde tekst**

Naast het animeren van tekst kun je ook animatie toepassen op een alinea.

{{% alert color="primary" %}}
Lees meer [**Over geanimeerde tekst**](/slides/nl/python-net/animated-text/).
{{% /alert %}}

## **Veelgestelde vragen**

### Worden animaties behouden bij exporteren naar PDF?

Nee. PDF is een statisch formaat, dus animaties en [dia‑overgangen](/slides/nl/python-net/slide-transition/) worden niet afgespeeld. Als je beweging nodig hebt, exporteer dan naar [HTML5](/slides/nl/python-net/export-to-html5/), [geanimeerde GIF](/slides/nl/python-net/convert-powerpoint-to-animated-gif/) of [video](/slides/nl/python-net/convert-powerpoint-to-video/) in plaats daarvan.

### Kan ik een geanimeerde presentatie omzetten naar een video en de frame‑rate en frame‑grootte beheersen?

Ja. Je kunt de presentatie [renderen als frames](/slides/nl/python-net/convert-powerpoint-to-video/) en deze in een video coderen (bijv. via ffmpeg), waarbij je de FPS en resolutie kiest. Animaties en dia‑overgangen worden afgespeeld tijdens het renderen.

### Blijven animaties intact bij het werken met ODP (niet alleen PPTX)?

PPT, PPTX en ODP worden ondersteund voor [lezen](/slides/nl/python-net/open-presentation/) en [schrijven](/slides/nl/python-net/save-presentation/), maar formatverschillen kunnen ervoor zorgen dat bepaalde effecten er iets anders uitzien of zich anders gedragen. Valideer kritieke gevallen met echte voorbeelden.