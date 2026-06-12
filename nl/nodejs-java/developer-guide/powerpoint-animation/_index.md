---
title: Verbeter PowerPoint-presentaties met animaties in JavaScript
linktitle: PowerPoint-animatie
type: docs
weight: 150
url: /nl/nodejs-java/powerpoint-animation/
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
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Gebruik Aspose.Slides voor Node.js via Java om PowerPoint-animaties te verwerken. Dit overzicht belicht belangrijke functies en biedt inzichten om uw presentaties te verbeteren."
---
## **Introductie**

Aangezien presentaties bedoeld zijn om iets te presenteren, wordt hun visuele uiterlijk en interactieve gedrag altijd in overweging genomen bij het maken ervan.

**PowerPoint-animatie** speelt een belangrijke rol om een presentatie opvallend en aantrekkelijk voor de kijkers te maken. Aspose.Slides voor Node.js via Java biedt een breed scala aan opties om animatie aan een PowerPoint-presentatie toe te voegen:

- verschillende typen PowerPoint-animatie-effecten toepassen op vormen, diagrammen, tabellen, OLE‑objecten en andere presentatie‑elementen.
- meerdere PowerPoint-animatie-effecten op één vorm gebruiken.
- een animatietijdlijn gebruiken om animatie-effecten te beheersen.
- aangepaste animatie maken.

In Aspose.Slides voor Node.js via Java kunnen verschillende animatie-effecten op de vormen worden toegepast. Aangezien elk element op de dia, inclusief tekst, afbeeldingen, OLE‑object, tabel enz., als een vorm wordt beschouwd, betekent dit dat we animatie-effecten op elk element van een dia kunnen toepassen.

## **Animatie‑effecten**
Aspose.Slides ondersteunt **150+ animatie‑effecten**, waaronder basisanimatie-effecten zoals Bounce, PathFootball, Zoom‑effect en specifieke animatie-effecten zoals OLEObjectShow, OLEObjectOpen. Een volledige lijst van animatie-effecten kun je vinden in de [**EffectType**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effecttype/)‑enumeratie.

Daarnaast kunnen deze animatie-effecten in combinatie met elkaar worden gebruikt:

- [ColorEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SetEffect)

## **Aangepaste animatie**
Het is mogelijk om je eigen **aangepaste animaties** te maken in Aspose.Slides.  
Dit kan worden bereikt door verschillende gedragingen samen te voegen tot een nieuwe aangepaste animatie.

[**Behavior**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Behavior) is een bouwsteen van elk PowerPoint-animatie‑effect. Alle animatie‑effecten bestaan eigenlijk uit een set gedragingen die tot één strategie zijn gevormd. Je kunt gedragingen combineren tot een aangepaste animatie eenmalig en deze hergebruiken in andere presentaties. Als je een nieuwe gedraging toevoegt aan een standaard PowerPoint-animatie‑effect, wordt dit een andere aangepaste animatie. Bijvoorbeeld, je kunt een herhaal‑gedrag aan een animatie toevoegen zodat deze een paar keer wordt herhaald.

[**Animation Point**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Point) is een punt waar het gedrag moet worden toegepast.

## **Animatie‑tijdlijn**
[**Sequence**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Sequence) is een verzameling animatie‑effecten die op een specifieke vorm worden toegepast.

[**Timeline**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AnimationTimeLine) is een set van Sequences die in een specifieke dia wordt gebruikt. Het is een animatie‑engine die sinds PowerPoint 2002 bestaat. In eerdere PowerPoint‑versies was het moeilijk om animatie‑effecten aan een presentatie toe te voegen, wat alleen kon met verschillende workarounds. Timeline vervangt de oude AnimationSettings‑klasse en biedt een duidelijker objectmodel voor PowerPoint‑animatie. Eén dia kan slechts één animatie‑tijdlijn hebben.

## **Interactieve animatie**
[**Trigger**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/EffectTriggerType) maakt het mogelijk om gebruikersacties (bijv. een klik op een knop) te definiëren die een bepaalde animatie starten. Triggers zijn alleen toegevoegd in de nieuwste PowerPoint‑versie.

## **Vorm‑animatie**
Aspose.Slides maakt het mogelijk om animatie toe te passen op vormen, die feitelijk tekst, rechthoek, lijn, frame, OLE‑object, enz. kunnen zijn.

{{% alert color="primary" %}} 
Lees meer [**Over vorm‑animatie**](/slides/nl/nodejs-java/shape-animation/).
{{% /alert %}}

## **Geanimeerde diagrammen**
Om geanimeerde diagrammen te maken, moet je dezelfde klassen gebruiken als voor vormen. Het is echter mogelijk om PowerPoint‑animatie alleen op diagramcategorieën of diagramreeksen toe te passen. Je kunt ook een animatie‑effect op een categorie‑element of reeks‑element toepassen.

{{% alert color="primary" %}} 
Lees meer [**Over geanimeerde diagrammen**](/slides/nl/nodejs-java/animated-charts/).
{{% /alert %}}

## **Geanimeerde tekst**
Naast geanimeerde tekst is het ook mogelijk om animatie op een alinea toe te passen.

{{% alert color="primary" %}} 
Lees meer [**Over geanimeerde tekst**](/slides/nl/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Worden animaties behouden bij exporteren naar PDF?**

Nee. PDF is een statisch formaat, dus animaties en [dia‑overgangen](/slides/nl/nodejs-java/slide-transition/) worden niet afgespeeld. Als je beweging nodig hebt, exporteer dan in plaats daarvan naar [HTML5](/slides/nl/nodejs-java/export-to-html5/), [geanimeerde GIF](/slides/nl/nodejs-java/convert-powerpoint-to-animated-gif/) of [video](/slides/nl/nodejs-java/convert-powerpoint-to-video/).

**Kan ik een geanimeerde presentatie omzetten naar een video en de beeldsnelheid en frame‑grootte regelen?**

Ja. Je kunt de presentatie [renderen als frames](/slides/nl/nodejs-java/convert-powerpoint-to-video/) en deze coderen naar een video (bijv. via ffmpeg), waarbij je de FPS en resolutie kiest. Animaties en dia‑overgangen worden tijdens het renderen afgespeeld.

**Blijven animaties intact wanneer je werkt met ODP (niet alleen PPTX)?**

PPT, PPTX en ODP worden ondersteund voor [lezen](/slides/nl/nodejs-java/open-presentation/) en [schrijven](/slides/nl/nodejs-java/save-presentation/), maar formatverschillen kunnen ertoe leiden dat bepaalde effecten er iets anders uitzien of zich iets anders gedragen. Valideer kritieke gevallen met echte voorbeelden.