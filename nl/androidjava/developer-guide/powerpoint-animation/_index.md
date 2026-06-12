---
title: Verbeter PowerPoint-presentaties met animaties op Android
linktitle: PowerPoint-animatie
type: docs
weight: 150
url: /nl/androidjava/powerpoint-animation/
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
- Android
- Java
- Aspose.Slides
description: "Ontdek de mogelijkheden van Aspose.Slides for Android via Java voor het verwerken van PowerPoint-animaties. Dit algemene overzicht belicht de belangrijkste functies."
---
## **Introductie**

Aangezien presentaties bedoeld zijn om iets te presenteren, wordt hun visuele uitstraling en interactieve gedrag altijd in overweging genomen bij het maken ervan.

**PowerPoint-animatie** speelt een belangrijke rol om een presentatie opvallend en aantrekkelijk te maken voor de kijkers. Aspose.Slides for Android via Java biedt een breed scala aan opties om animatie toe te voegen aan een PowerPoint-presentatie:

- doe verschillende soorten PowerPoint-animatie-effecten toe op vormen, diagrammen, tabellen, OLE-objecten en andere presentatie‑elementen.
- gebruik meerdere PowerPoint-animatie-effecten op één vorm.
- gebruik een animatietijdlijn om animatie‑effecten te beheren.
- maak aangepaste animaties.

In Aspose.Slides for Android via Java kunnen diverse animatie‑effecten op de vormen worden toegepast. Aangezien elk element op de dia, inclusief tekst, afbeeldingen, OLE‑object, tabel enz., wordt beschouwd als een vorm, betekent dit dat we animatie‑effecten op elk element van een dia kunnen toepassen.

## **Animatie‑effecten**

Aspose.Slides ondersteunt **meer dan 150 animatie‑effecten**, waaronder basis‑animatie‑effecten zoals Bounce, PathFootball, Zoom‑effect en specifieke animatie‑effecten zoals OLEObjectShow, OLEObjectOpen. Een volledige lijst van animatie‑effecten vind je in de **EffectType**‑enumeratie.

Bovendien kunnen deze animatie‑effecten in combinatie ermee worden gebruikt:

- [ColorEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SetEffect)

## **Aangepaste animatie**

Het is mogelijk om je eigen **aangepaste animaties** te maken in Aspose.Slides. Dit kan worden bereikt door verschillende gedragingen samen te voegen tot een nieuwe aangepaste animatie.

[**Behavior**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Behavior) is een bouwsteen van elk PowerPoint‑animatie‑effect. Alle animatie‑effecten bestaan eigenlijk uit een set van gedragingen die tot één strategie zijn samengevoegd. Je kunt gedragingen combineren tot een aangepaste animatie en deze vervolgens in andere presentaties hergebruiken. Als je een nieuwe gedraging toevoegt aan een standaard PowerPoint‑animatie‑effect, ontstaat er een andere aangepaste animatie. Bijvoorbeeld, je kunt een herhalings‑gedrag aan een animatie toevoegen zodat deze een paar keer wordt herhaald.

[**Animation Point**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Point) is een punt waarop een gedrag moet worden toegepast.

## **Animatie‑tijdlijn**

[**Sequence**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Sequence) is een verzameling animatie‑effecten, toegepast op een specifieke vorm.

[**Timeline**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/AnimationTimeLine) is een set van Sequences die in een specifieke dia worden gebruikt. Het is een animatie‑engine die bestaat sinds PowerPoint 2002. In eerdere PowerPoint‑versies was het moeilijk om animatie‑effecten aan een presentatie toe te voegen; dit kon alleen met verschillende workarounds. Timeline vervangt de oude AnimationSettings‑klasse en biedt een duidelijker object‑model voor PowerPoint‑animaties. Eén dia kan maar één animatie‑tijdlijn hebben.

## **Interactieve animatie**

[**Trigger**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/EffectTriggerType) maakt het mogelijk om gebruikersacties (bijv. klik op een knop) te definiëren die een bepaalde animatie starten. Triggers zijn alleen toegevoegd in de nieuwste PowerPoint‑versie.

## **Vorm‑animatie**

Aspose.Slides maakt het mogelijk om animatie toe te passen op vormen, die bijvoorbeeld tekst, rechthoek, lijn, frame, OLE‑object enz. kunnen zijn.

{{% alert color="primary" %}} 
Lees meer [**Over Vorm‑animatie**](/slides/nl/androidjava/shape-animation/).
{{% /alert %}}

## **Geanimeerde grafieken**

Om geanimeerde grafieken te maken, moet je dezelfde klassen gebruiken als voor de vormen. Het is echter mogelijk om PowerPoint‑animatie alleen toe te passen op grafiek‑categorieën of grafiek‑reeksen. Je kunt ook een animatie‑effect toepassen op een categorie‑element of een reeks‑element.

{{% alert color="primary" %}} 
Lees meer [**Over Geanimeerde grafieken**](/slides/nl/androidjava/animated-charts/).
{{% /alert %}}

## **Geanimeerde tekst**

Naast geanimeerde tekst is het ook mogelijk om animatie toe te passen op een alinea.

{{% alert color="primary" %}} 
Lees meer [**Over Geanimeerde tekst**](/slides/nl/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Worden animaties behouden bij exporteren naar PDF?**

Nee. PDF is een statisch formaat, dus animaties en [slide transitions](/slides/nl/androidjava/slide-transition/) worden niet afgespeeld. Als je beweging nodig hebt, exporteer dan naar [HTML5](/slides/nl/androidjava/export-to-html5/), [animated GIF](/slides/nl/androidjava/convert-powerpoint-to-animated-gif/), of [video](/slides/nl/androidjava/convert-powerpoint-to-video/) in plaats daarvan.

**Kan ik een geanimeerde presentatie omzetten naar een video en de framesnelheid en framegrootte regelen?**

Ja. Je kunt de presentatie [renderen als frames](/slides/nl/androidjava/convert-powerpoint-to-video/) en deze coderen naar een video (bijv. via ffmpeg), waarbij je FPS en resolutie kiest. Animaties en slide transitions worden tijdens het renderen afgespeeld.

**Blijven animaties behouden bij het werken met ODP (niet alleen PPTX)?**

PPT, PPTX en ODP worden ondersteund voor [lezen](/slides/nl/androidjava/open-presentation/) en [schrijven](/slides/nl/androidjava/save-presentation/), maar formatverschillen kunnen ertoe leiden dat bepaalde effecten er iets anders uitzien of zich iets anders gedragen. Controleer kritieke gevallen met echte voorbeelden.