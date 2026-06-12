---
title: Versterk PowerPoint‑presentaties met animaties in PHP
linktitle: PowerPoint‑animatie
type: docs
weight: 150
url: /nl/php-java/powerpoint-animation/
keywords:
- animatie toevoegen
- animatie bijwerken
- animatie wijzigen
- animatie verwijderen
- animatie beheren
- animatie controleren
- animatie‑effect
- PowerPoint‑animatie
- animatietijdlijn
- interactieve animatie
- aangepaste animatie
- vormanimatie
- geanimeerde grafiek
- geanimeerde tekst
- geanimeerde vorm
- geanimeerd OLE‑object
- geanimeerde afbeelding
- geanimeerde tabel
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek de mogelijkheden van Aspose.Slides voor PHP via Java bij het verwerken van PowerPoint‑animaties. Belangrijke functies en inzichten om je presentaties te verbeteren."
---
## **Introductie**

Aangezien presentaties bedoeld zijn om iets te presenteren, wordt hun visuele uiterlijk en interactief gedrag altijd meegewogen bij het maken ervan.

**PowerPoint animation** speelt een belangrijke rol om de presentatie opvallend en aantrekkelijk te maken voor de kijkers. Aspose.Slides voor PHP via Java biedt een breed scala aan opties om animatie toe te voegen aan een PowerPoint‑presentatie:

- verschillende soorten PowerPoint‑animatie‑effecten toepassen op vormen, grafieken, tabellen, OLE‑objecten en andere presentaties‑elementen.
- meerdere PowerPoint‑animatie‑effecten op één vorm gebruiken.
- de animatietijdlijn gebruiken om animatie‑effecten te regelen.
- aangepaste animatie maken.

In Aspose.Slides voor PHP via Java kunnen verschillende animatie‑effecten op de vormen worden toegepast. Aangezien elk element op de dia, waaronder tekst, afbeeldingen, OLE‑object, tabel enz., als een vorm wordt beschouwd, betekent dit dat we animatie‑effecten op elk element van een dia kunnen toepassen.

## **Animatie‑effecten**
Aspose.Slides ondersteunt **meer dan 150 animatie‑effecten**, waaronder basisanimaties zoals Bounce, PathFootball, Zoom‑effect en specifieke animatie‑effecten zoals OLEObjectShow, OLEObjectOpen. Een volledige lijst met animatie‑effecten vind je in de [**EffectType**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effecttype/)‑enumeratie.

Daarnaast kunnen deze animatie‑effecten in combinatie met de volgende worden gebruikt:

- [ColorEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SetEffect)

## **Aangepaste animatie**
Het is mogelijk om je eigen **aangepaste animaties** te maken in Aspose.Slides.  
Dit kan worden bereikt door verschillende gedragingen te combineren tot een nieuwe aangepaste animatie.

[**Behavior**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Behavior) is een bouwsteen van elk PowerPoint‑animatie‑effect. Alle animatie‑effecten bestaan eigenlijk uit een verzameling gedragingen die tot één strategie zijn samengesteld. Je kunt gedragingen combineren tot een aangepaste animatie en deze vervolgens in andere presentaties hergebruiken. Als je een nieuwe gedraging toevoegt aan een standaard PowerPoint‑animatie‑effect, ontstaat er een andere aangepaste animatie. Bijvoorbeeld, je kunt een herhalings‑gedrag toevoegen aan een animatie zodat deze meerdere keren wordt herhaald.

[**Animation Point**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Point) is een punt waarop een gedrag moet worden toegepast.

## **Animatietijdlijn**
[**Sequence**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Sequence) is een verzameling animatie‑effecten die op een specifieke vorm worden toegepast.

[**Timeline**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/AnimationTimeLine) is een set van Sequences die in een specifieke dia worden gebruikt. Het is een animatie‑engine die sinds PowerPoint 2002 aanwezig is. In eerdere PowerPoint‑versies was het lastig om animatie‑effecten aan een presentatie toe te voegen; dat kon alleen met diverse workarounds. De Timeline vervangt de oude AnimationSettings‑klasse en biedt een duidelijker objectmodel voor PowerPoint‑animaties. Eén dia kan slechts één animatietijdlijn hebben.

## **Interactieve animatie**
[**Trigger**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/EffectTriggerType) maakt het mogelijk om gebruikersacties (bijv. een klik op een knop) te definiëren die een bepaalde animatie starten. Triggers zijn alleen toegevoegd in de nieuwste versie van PowerPoint.

## **Vorm‑animatie**
Aspose.Slides maakt het mogelijk om animatie toe te passen op vormen, die in feite tekst, rechthoek, lijn, kader, OLE‑object, enz. kunnen zijn.

{{% alert color="primary" %}} 
Lees meer [**Over vorm‑animatie**](/slides/nl/php-java/shape-animation/).
{{% /alert %}}

## **Geanimeerde diagrammen**
Om geanimeerde diagrammen te maken, moet je dezelfde klassen gebruiken als voor vormen. Het is echter mogelijk om PowerPoint‑animatie alleen toe te passen op diagramcategorieën of -reeksen. Je kunt ook een animatie‑effect toepassen op een categorie‑element of een reeks‑element.

{{% alert color="primary" %}} 
Lees meer [**Over geanimeerde diagrammen**](/slides/nl/php-java/animated-charts/).
{{% /alert %}}

## **Geanimeerde tekst**
Naast geanimeerde tekst is het ook mogelijk om animatie toe te passen op een alinea.

{{% alert color="primary" %}} 
Lees meer [**Over geanimeerde tekst**](/slides/nl/php-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Worden animaties behouden bij exporteren naar PDF?**

Nee. PDF is een statisch formaat, dus animaties en [dia‑overgangen](/slides/nl/php-java/slide-transition/) worden niet afgespeeld. Als je beweging nodig hebt, exporteer dan naar [HTML5](/slides/nl/php-java/export-to-html5/), [geanimeerde GIF](/slides/nl/php-java/convert-powerpoint-to-animated-gif/), of [video](/slides/nl/php-java/convert-powerpoint-to-video/) in plaats daarvan.

**Kan ik een geanimeerde presentatie omzetten naar een video en de framesnelheid en frame‑grootte regelen?**

Ja. Je kunt de presentatie [renderen als frames](/slides/nl/php-java/convert-powerpoint-to-video/) en deze coderen tot een video (bijv. via ffmpeg), waarbij je de FPS en resolutie kiest. Animaties en dia‑overgangen worden tijdens het renderen afgespeeld.

**Blijven animaties intact bij het werken met ODP (niet alleen PPTX)?**

PPT, PPTX en ODP worden ondersteund voor [lezen](/slides/nl/php-java/open-presentation/) en [schrijven](/slides/nl/php-java/save-presentation/), maar verschillen in formaten kunnen ervoor zorgen dat bepaalde effecten er iets anders uitzien of zich iets anders gedragen. Valideer kritieke gevallen met echte voorbeelden.