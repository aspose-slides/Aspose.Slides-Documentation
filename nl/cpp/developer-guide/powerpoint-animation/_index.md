---
title: Verbeter PowerPoint-presentaties met animaties in C++
linktitle: PowerPoint-animatie
type: docs
weight: 150
url: /nl/cpp/powerpoint-animation/
keywords:
- animatie toevoegen
- animatie bijwerken
- animatie wijzigen
- animatie verwijderen
- animatie beheren
- animatie controleren
- animatie‑effect
- PowerPoint-animatie
- animatietijdlijn
- interactieve animatie
- aangepaste animatie
- vormanimatie
- geanimeerde grafiek
- geanimeerde tekst
- geanimeerde vorm
- geanimeerd OLE-object
- geanimeerde afbeelding
- geanimeerde tabel
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u geavanceerde animatie‑effecten kunt toevoegen en beheren in Aspose.Slides voor C++ om dynamische PowerPoint‑ en OpenDocument‑presentaties te maken."
---
## **Inleiding**

Aangezien presentaties bedoeld zijn om iets te presenteren, wordt hun visuele uiterlijk en interactieve gedrag altijd in overweging genomen bij het maken ervan.

**PowerPoint-animatie** speelt een belangrijke rol om een presentatie opvallend en aantrekkelijk te maken voor de kijkers. Aspose.Slides for C++ biedt een breed scala aan mogelijkheden om animatie toe te voegen aan een PowerPoint‑presentatie:

- pas verschillende soorten PowerPoint‑animatieeffecten toe op vormen, grafieken, tabellen, OLE‑objecten en andere presentatie‑elementen.
- gebruik meerdere PowerPoint‑animatieeffecten op een vorm.
- gebruik een animatietijdlijn om animatie‑effecten te regelen.
- maak aangepaste animaties.

In Aspose.Slides for C++ kunnen verschillende animatie‑effecten op de vormen worden toegepast. Aangezien elk element op de dia, inclusief tekst, afbeeldingen, OLE‑object, tabel enz., wordt beschouwd als een vorm, betekent dit dat we animatie‑effecten op elk element van een dia kunnen toepassen.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides.animation) **namespace** biedt klassen om met PowerPoint‑animaties te werken.
## **Animatie‑effecten**
Aspose.Slides ondersteunt **meer dan 150 animatie‑effecten**, waaronder basisanimatie‑effecten zoals Bounce, PathFootball, Zoom‑effect en specifieke animatie‑effecten zoals OLEObjectShow, OLEObjectOpen. Een volledige lijst van animatie‑effecten vind je in de [**EffectType**](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31)‑enumeratie.

Bovendien kunnen deze animatie‑effecten in combinatie met elkaar worden gebruikt:

- [ColorEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.set_effect)

## **Aangepaste animatie**
Het is mogelijk om je eigen **aangepaste animaties** te maken in Aspose.Slides. 
Dit kan worden bereikt door verschillende gedragingen samen te voegen tot een nieuwe aangepaste animatie.

[**Behavior**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.behavior) is een bouwsteen van elk PowerPoint‑animatie‑effect. Alle animatie‑effecten bestaan eigenlijk uit een verzameling gedragingen die tot één strategie zijn samengesteld. Je kunt gedragingen combineren tot een aangepaste animatie en deze vervolgens in andere presentaties hergebruiken. Als je een nieuwe gedraging toevoegt aan een standaard PowerPoint‑animatie‑effect, wordt dat een nieuwe aangepaste animatie. Bijvoorbeeld, je kunt een herhaal‑gedrag aan een animatie toevoegen om deze een paar keer te laten herhalen.

[**Animation Point**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.point) is een punt waarop een gedraging moet worden toegepast.

## **Animatie‑tijdlijn**
[**Sequence**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.sequence) is een verzameling animatie‑effecten, toegepast op een specifieke vorm.

[**AnimationTimeLine**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.animation_time_line) is een set van Sequences die in een specifieke dia wordt gebruikt. Het is een animatie‑engine die sinds PowerPoint 2002 aanwezig is. In eerdere PowerPoint‑versies was het lastig om animatie‑effecten aan een presentatie toe te voegen, wat alleen mogelijk was met verschillende workarounds. De tijdlijn vervangt de oude AnimationSettings‑klasse en biedt een duidelijker objectmodel voor PowerPoint‑animatie. Eén dia kan slechts één animatie‑tijdlijn hebben.
## **Interactieve animatie**
[**EffectTriggerType**](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) maakt het mogelijk om gebruikersacties (bijv. een klik op een knop) te definiëren die een bepaalde animatie starten. Triggers zijn alleen toegevoegd in de nieuwste PowerPoint‑versie.

## **Vormanimatie**
Aspose.Slides maakt het mogelijk om animatie toe te passen op vormen, die in feite tekst, rechthoek, lijn, frame, OLE‑object, enz. kunnen zijn.

{{% alert color="info" %}} 
Lees meer [**About Shape Animation**](/slides/nl/cpp/shape-animation/).
{{% /alert %}}

## **Geanimeerde grafieken**
Om geanimeerde grafieken te maken, moet je dezelfde klassen gebruiken als voor vormen. Het is echter alleen mogelijk om PowerPoint‑animatie toe te passen op grafiekcategorieën of -reeksen. Je kunt ook een animatie‑effect toepassen op een categorieel element of een reekselement.

{{% alert color="info" %}} 
Lees meer [**About Animated Charts**](/slides/nl/cpp/animated-charts/).
{{% /alert %}}

## **Geanimeerde tekst**
Naast geanimeerde tekst is het ook mogelijk om animatie toe te passen op een alinea.

{{% alert color="info" %}} 
Lees meer [**About Animated Text**](/slides/nl/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

### Worden animaties behouden bij exporteren naar PDF?

Nee. PDF is een statisch formaat, dus animaties en [dia‑overgangen](/slides/nl/cpp/slide-transition/) worden niet afgespeeld. Als je beweging nodig hebt, exporteer dan naar [HTML5](/slides/nl/cpp/export-to-html5/), [geanimeerde GIF](/slides/nl/cpp/convert-powerpoint-to-animated-gif/), of [video](/slides/nl/cpp/convert-powerpoint-to-video/) in plaats daarvan.

### Kan ik een geanimeerde presentatie omzetten naar een video en de framesnelheid en framegrootte regelen?

Ja. Je kunt de presentatie [renderen als frames](/slides/nl/cpp/convert-powerpoint-to-video/) en deze coderen tot een video (bijv. via ffmpeg), waarbij je fps en resolutie kiest. Animaties en dia‑overgangen worden afgespeeld tijdens het renderen.

### Blijven animaties intact bij het werken met ODP (niet alleen PPTX)?

PPT, PPTX en ODP worden ondersteund voor [lezen](/slides/nl/cpp/open-presentation/) en [schrijven](/slides/nl/cpp/save-presentation/), maar formatverschillen kunnen ertoe leiden dat bepaalde effecten er iets anders uitzien of zich anders gedragen. Valideer kritieke gevallen met echte voorbeelden.