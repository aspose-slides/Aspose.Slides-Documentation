---
title: Verbeter PowerPoint-presentaties met animaties in .NET
linktitle: PowerPoint-animatie
type: docs
weight: 150
url: /nl/net/powerpoint-animation/
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
- .NET
- C#
- Aspose.Slides
description: "Ontdek de mogelijkheden van Aspose.Slides voor .NET bij het verwerken van PowerPoint-animaties. Dit algemene overzicht belicht belangrijke functies en biedt inzichten om uw presentaties te verbeteren."
---
## **Introductie**

Aangezien presentaties bedoeld zijn om iets te presenteren, wordt tijdens het maken altijd rekening gehouden met hun visuele uiterlijk en interactieve gedrag.

**PowerPoint-animatie** speelt een belangrijke rol bij het aantrekkelijk en boeiend maken van een presentatie voor de kijker. Aspose.Slides for .NET biedt een breed scala aan mogelijkheden om animaties toe te voegen aan PowerPoint‑presentaties:

- Pas verschillende soorten PowerPoint‑animatie‑effecten toe op vormen, grafieken, tabellen, OLE‑objecten en andere presentatie‑elementen.  
- Gebruik meerdere PowerPoint‑animatie‑effecten op één vorm.  
- Maak gebruik van de animatietijdlijn om animatie‑effecten te beheersen.  
- Creëer aangepaste animaties.

In Aspose.Slides for .NET kunnen diverse animatie‑effecten op vormen worden toegepast. Aangezien elk element op een dia, inclusief tekst, afbeeldingen, OLE‑objecten en tabellen, wordt beschouwd als een vorm, kunnen animatie‑effecten op elk element van de dia worden toegepast.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/) namespace biedt klassen om met PowerPoint‑animaties te werken.

## **Animatie‑effecten**

Aspose.Slides ondersteunt **meer dan 150 animatie‑effecten**, waaronder basis‑effecten zoals Bounce, PathFootball en Zoom, en specifieke effecte n zoals OLEObjectShow en OLEObjectOpen. Een volledige lijst van animatie‑effecten vind je in de enumeratie [EffectType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effecttype).

Bovendien kunnen deze animatie‑effecten in combinatie met het volgende worden gebruikt:

- [ColorEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/seteffect)

## **Aangepaste animatie**

Het is mogelijk om je eigen **aangepaste animaties** te maken in Aspose.Slides. Dit kan worden bereikt door verschillende gedragingen te combineren tot een nieuwe aangepaste animatie.

[Behaviour](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/behavior) is een bouwsteen van elk PowerPoint‑animatie‑effect. Alle animatie‑effecten bestaan in feite uit een verzameling gedragingen die tot één strategie zijn samengevoegd. Je kunt gedragingen combineren tot een aangepaste animatie en deze eenmaal hergebruiken in andere presentaties. Als je een nieuw gedrag toevoegt aan een standaard PowerPoint‑animatie‑effect, wordt dit een ander aangepast animatie‑effect. Bijvoorbeeld, je kunt een herhaalgedrag toevoegen aan een animatie om die een paar keer te laten herhalen.

[Animation Point](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/point) is een punt waarop een gedrag moet worden toegepast.

## **Animatietijdlijn**

[Sequence](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/sequence) is een verzameling animatie‑effecten die op een specifieke vorm worden toegepast.

[Timeline](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/animationtimeline) is een set van sequenties die in een specifieke dia worden gebruikt. Het is een animatie‑engine die werd geïntroduceerd in PowerPoint 2002. In eerdere versies van PowerPoint was het toevoegen van animatie‑effecten aan presentaties uitdagend en kon alleen met diverse omwegen worden bereikt. De tijdlijn vervangt de oude AnimationSettings‑klasse en biedt een duidelijker objectmodel voor PowerPoint‑animaties. Een dia kan slechts één animatietijdlijn hebben.

## **Interactieve animatie**

[Trigger](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effecttriggertype) stelt je in staat om gebruikersacties (bijv. een knop‑klik) te definiëren die een specifiek animatie‑effect starten. Triggers werden geïntroduceerd in de laatst‑uitgebrachte versie van PowerPoint.

## **Vormanimatie**

Aspose.Slides stelt je in staat om animaties toe te passen op vormen, waaronder tekst, rechthoeken, lijnen, frames, OLE‑objecten en meer.

{{% alert color="info" %}} 
Lees meer [**Over vormanimatie**](/slides/nl/net/shape-animation/).
{{% /alert %}}

## **Geanimeerde diagrammen**

Om geanimeerde diagrammen te maken, moet je dezelfde klassen gebruiken als voor de vormen. PowerPoint‑animaties kunnen echter alleen worden toegepast op diagram‑categorieën of diagram‑reeksen. Je kunt ook animatie‑effecten toepassen op een categorie‑element of een reeks‑element.

{{% alert color="info" %}} 
Lees meer [**Over geanimeerde diagrammen**](/slides/nl/net/animated-charts/).
{{% /alert %}}

## **Geanimeerde tekst**

Naast geanimeerde tekst is het ook mogelijk om animatie toe te passen op een alinea.

{{% alert color="info" %}} 
Lees meer [**Over geanimeerde tekst**](/slides/nl/net/animated-text/).
{{% /alert %}}

## **FAQ**

### Worden animaties behouden bij exporteren naar PDF?

Nee. PDF is een statisch formaat, dus animaties en [dia‑overgangen](/slides/nl/net/slide-transition/) worden niet afgespeeld. Als je beweging nodig hebt, exporteer dan naar [HTML5](/slides/nl/net/export-to-html5/), [geanimeerde GIF](/slides/nl/net/convert-powerpoint-to-animated-gif/) of [video](/slides/nl/net/convert-powerpoint-to-video/) in plaats daarvan.

### Kan ik een geanimeerde presentatie omzetten naar een video en de framesnelheid en framegrootte regelen?

Ja. Je kunt de presentatie [renderen als frames](/slides/nl/net/convert-powerpoint-to-video/) en deze coderen naar een video (bijv. via ffmpeg), waarbij je FPS en resolutie kiest. Animaties en dia‑overgangen worden afgespeeld tijdens het renderen.

### Blijven animaties intact bij het werken met ODP (niet alleen PPTX)?

PPT, PPTX en ODP worden ondersteund voor [lezen](/slides/nl/net/open-presentation/) en [schrijven](/slides/nl/net/save-presentation/), maar verschillen in formaat betekenen dat bepaalde effecten er iets anders uit kunnen zien of zich iets anders kunnen gedragen. Valideer kritieke gevallen met echte voorbeelden.