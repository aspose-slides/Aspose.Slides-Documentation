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
description: "Ontdek de mogelijkheden van Aspose.Slides voor .NET bij het verwerken van PowerPoint-animaties. Deze algemene overzicht belicht belangrijke functies en biedt inzichten om uw presentaties te verbeteren."
---
## **Introductie**

Aangezien presentaties bedoeld zijn om iets te presenteren, wordt hun uiterlijk en interactieve gedrag altijd in aanmerking genomen bij het maken.

**PowerPoint-animatie** speelt een belangrijke rol om een presentatie visueel aantrekkelijk en boeiend te maken voor de kijker. Aspose.Slides voor .NET biedt een breed scala aan opties om animaties toe te voegen aan PowerPoint-presentaties:

- Pas verschillende soorten PowerPoint-animatie-effecten toe op vormen, grafieken, tabellen, OLE-objecten en andere presentaties-elementen.
- Gebruik meerdere PowerPoint-animatie-effecten op één vorm.
- Gebruik de animatie-tijdlijn om animatie-effecten te beheersen.
- Maak aangepaste animaties.

In Aspose.Slides voor .NET kunnen verschillende animatie-effecten op vormen worden toegepast. Omdat elk element op een dia, inclusief tekst, afbeeldingen, OLE-objecten en tabellen, wordt beschouwd als een vorm, kunnen animatie-effecten op elk element van de dia worden toegepast.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/) namespace biedt klassen om met PowerPoint-animaties te werken.

## **Animatie-effecten**

Aspose.Slides ondersteunt **meer dan 150 animatie-effecten**, waaronder basis-effecten zoals Bounce, PathFootball en Zoom, evenals specifieke effecten zoals OLEObjectShow en OLEObjectOpen. Een volledige lijst met animatie-effecten vind je in de [EffectType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effecttype) enumeratie.

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

[Behaviour](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/behavior) is een bouwsteen van elk PowerPoint-animatie-effect. Alle animatie-effecten bestaan in feite uit een verzameling gedragingen die tot één strategie zijn samengevoegd. Je kunt gedragingen combineren tot een aangepaste animatie en deze vervolgens in andere presentaties hergebruiken. Als je een nieuw gedrag toevoegt aan een standaard PowerPoint-animatie-effect, wordt dit een andere aangepaste animatie. Bijvoorbeeld, je kunt een herhaal-gedrag toevoegen aan een animatie zodat deze een paar keer wordt herhaald.

[Animation Point](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/point) is een punt waarop een gedrag moet worden toegepast.

## **Animatietijdlijn**

[Sequence](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/sequence) is een verzameling animatie-effecten die op een specifieke vorm worden toegepast.

[Timeline](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/animationtimeline) is een verzameling sequences die in een specifieke dia wordt gebruikt. Het is een animatie-engine geïntroduceerd in PowerPoint 2002. In eerdere versies van PowerPoint was het toevoegen van animatie-effecten aan presentaties uitdagend en alleen mogelijk met verschillende workarounds. De tijdlijn vervangt de oude AnimationSettings-klasse en biedt een duidelijker objectmodel voor PowerPoint-animaties. Een dia kan slechts één animatie-tijdlijn hebben.

## **Interactieve animatie**

[Trigger](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effecttriggertype) stelt je in staat om gebruikersacties (bijv. een klik op een knop) te definiëren die een specifieke animatie starten. Triggers werden geïntroduceerd in de nieuwste versie van PowerPoint.

## **Vorm-animatie**

Aspose.Slides maakt het mogelijk om animaties toe te passen op vormen, die onder andere tekst, rechthoeken, lijnen, frames, OLE-objecten en meer kunnen bevatten.

{{% alert color="primary" %}} 
Lees meer [**Over Shape-animatie**](/slides/nl/net/shape-animation/).
{{% /alert %}}

## **Geanimeerde grafieken**

Om geanimeerde grafieken te maken, moet je dezelfde klassen gebruiken als voor vormen. PowerPoint-animaties kunnen echter alleen op grafiekcategorieën of -reeksen worden toegepast. Je kunt animatie-effecten ook toepassen op een categorielement of een reekselement.

{{% alert color="primary" %}} 
Lees meer [**Over Geanimeerde Grafieken**](/slides/nl/net/animated-charts/).
{{% /alert %}}

## **Geanimeerde tekst**

Naast geanimeerde tekst is het ook mogelijk om een animatie toe te passen op een alinea.

{{% alert color="primary" %}} 
Lees meer [**Over Geanimeerde Tekst**](/slides/nl/net/animated-text/).
{{% /alert %}}

## **FAQ**

**Blijven animaties behouden bij export naar PDF?**

Nee. PDF is een statisch formaat, waardoor animaties en [dia-overgangen](/slides/nl/net/slide-transition/) niet worden afgespeeld. Als je beweging nodig hebt, exporteer dan naar [HTML5](/slides/nl/net/export-to-html5/), [animated GIF](/slides/nl/net/convert-powerpoint-to-animated-gif/), of [video](/slides/nl/net/convert-powerpoint-to-video/) in plaats daarvan.

**Kan ik een geanimeerde presentatie omzetten naar een video en de framerate en frame-grootte aanpassen?**

Ja. Je kunt de presentatie renderen als frames en coderen tot een video (bijv. via ffmpeg), waarbij je fps en resolutie kiest. Animaties en dia-overgangen worden afgespeeld tijdens het renderen.

**Blijven animaties behouden bij het werken met ODP (niet alleen PPTX)?**

PPT, PPTX en ODP worden ondersteund voor [lezen](/slides/nl/net/open-presentation/) en [schrijven](/slides/nl/net/save-presentation/), maar verschillen in formaat betekenen dat bepaalde effecten er iets anders uit kunnen zien of zich anders kunnen gedragen. Valideer kritieke gevallen met echte exemplaren.