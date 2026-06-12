---
title: Verbeter PowerPoint-presentaties met animaties in Java
linktitle: PowerPoint-animatie
type: docs
weight: 150
url: /nl/java/powerpoint-animation/
keywords:
- animatie toevoegen
- animatie bijwerken
- animatie wijzigen
- animatie verwijderen
- animatie beheren
- animatie besturen
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
- Java
- Aspose.Slides
description: "Ontdek de mogelijkheden van Aspose.Slides voor Java bij het verwerken van PowerPoint-animaties. Dit algemene overzicht belicht belangrijke functies en biedt inzichten om uw presentaties te verbeteren."
---
## **Inleiding**

Aangezien presentaties bedoeld zijn om iets te presenteren, wordt hun visuele uitstraling en interactieve gedrag altijd in overweging genomen bij het maken.

**PowerPoint-animatie** speelt een belangrijke rol bij het aantrekkelijk en boeiend maken van een presentatie voor de kijker. Aspose.Slides biedt een breed scala aan opties om animaties toe te voegen aan PowerPoint‑presentaties:

- Pas verschillende soorten PowerPoint‑animatie‑effecten toe op vormen, grafieken, tabellen, OLE‑objecten en andere presentatie‑elementen.
- Gebruik meerdere PowerPoint‑animatie‑effecten op één enkele vorm.
- Gebruik de animatietijdlijn om animatie‑effecten te beheersen.
- Maak aangepaste animaties.

In Aspose.Slides kunnen verschillende animatie‑effecten op vormen worden toegepast. Aangezien elk element op een dia, inclusief tekst, afbeeldingen, OLE‑objecten en tabellen, als een vorm wordt beschouwd, kunnen animatie‑effecten op elk element op de dia worden toegepast.

## **Animatie‑effecten**

Aspose.Slides ondersteunt **meer dan 150 animatie‑effecten**, waaronder basis‑animatie‑effecten zoals Bounce, PathFootball, Zoom‑effect en specifieke animatie‑effecten zoals OLEObjectShow, OLEObjectOpen. Een volledige lijst van animatie‑effecten vind je in de [**EffectType**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effecttype/)-enumeratie.

Bovendien kunnen deze animatie‑effecten in combinatie met elkaar worden gebruikt:

- [ColorEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SetEffect)

## **Aangepaste animatie**

Het is mogelijk om je eigen **aangepaste animaties** te maken in Aspose.Slides. Dit kan worden bereikt door verschillende gedragingen samen te voegen tot een nieuwe aangepaste animatie.

[**Behavior**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Behavior) is een bouwsteen van elk PowerPoint‑animatie‑effect. Alle animatie‑effecten zijn in feite een verzameling gedragingen die tot één strategie zijn samengesteld. Je kunt gedragingen combineren tot een aangepaste animatie en deze vervolgens in andere presentaties hergebruiken. Als je een nieuw gedrag toevoegt aan een standaard PowerPoint‑animatie‑effect, wordt het een andere aangepaste animatie. Bijvoorbeeld, je kunt een herhaal‑gedrag aan een animatie toevoegen zodat deze een aantal keer wordt herhaald.

[**Animation Point**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Point) is een punt waarop het gedrag moet worden toegepast.

## **Animatie‑tijdlijn**

[**Sequence**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Sequence) is een verzameling animatie‑effecten die op een specifieke vorm worden toegepast.

[**Timeline**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/AnimationTimeLine) is een set van Sequences die in een specifieke dia wordt gebruikt. Het is een animatie‑engine die sinds PowerPoint 2002 bestaat. In eerdere PowerPoint‑versies was het lastig om animatie‑effecten aan een presentatie toe te voegen; dit kon alleen met verschillende workarounds. De Timeline vervangt de oude AnimationSettings‑klasse en biedt een duidelijker objectmodel voor PowerPoint‑animatie. Eén dia kan slechts één animatie‑tijdlijn hebben.

## **Interactieve animatie**

[**Trigger**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/EffectTriggerType) maakt het mogelijk om gebruikersacties (bijv. een muisklik) te definiëren die een bepaalde animatie starten. Triggers zijn alleen toegevoegd in de nieuwste versie van PowerPoint.

## **Vorm‑animatie**

Aspose.Slides maakt het mogelijk om animatie toe te passen op vormen, die bijvoorbeeld tekst, rechthoek, lijn, frame, OLE‑object, enz. kunnen zijn.

{{% alert color="primary" %}} 
Lees meer [**Over vorm‑animatie**](/slides/nl/java/shape-animation/).
{{% /alert %}}

## **Geanimeerde grafieken**

Om geanimeerde grafieken te maken, moet je dezelfde klassen gebruiken als voor vormen. Het is echter mogelijk om PowerPoint‑animatie alleen op grafiek‑categorieën of grafiek‑reeksen toe te passen. Je kunt ook een animatie‑effect toepassen op een categorieel element of een reeks‑element.

{{% alert color="primary" %}} 
Lees meer [**Over geanimeerde grafieken**](/slides/nl/java/animated-charts/).
{{% /alert %}}

## **Geanimeerde tekst**

Naast geanimeerde tekst is het ook mogelijk om animatie toe te passen op een alinea.

{{% alert color="primary" %}} 
Lees meer [**Over geanimeerde tekst**](/slides/nl/java/animated-text/).
{{% /alert %}}

## **FAQ**

**Blijven animaties behouden bij export naar PDF?**

Nee. PDF is een statisch formaat, dus animaties en [dia‑overgangen](/slides/nl/java/slide-transition/) worden niet afgespeeld. Als je beweging nodig hebt, exporteer dan naar [HTML5](/slides/nl/java/export-to-html5/), [geanimeerde GIF](/slides/nl/java/convert-powerpoint-to-animated-gif/) of [video](/slides/nl/java/convert-powerpoint-to-video/) in plaats daarvan.

**Kan ik een geanimeerde presentatie omzetten naar een video en de framerate en frame‑grootte regelen?**

Ja. Je kunt de presentatie [renderen als frames](/slides/nl/java/convert-powerpoint-to-video/) en deze coderen naar een video (bijv. via ffmpeg), waarbij je de fps en resolutie kiest. Animaties en dia‑overgangen worden tijdens het renderen afgespeeld.

**Blijven animaties behouden bij het werken met ODP (en niet alleen PPTX)?**

PPT, PPTX, en ODP worden ondersteund voor [lezen](/slides/nl/java/open-presentation/) en [schrijven](/slides/nl/java/save-presentation/), maar formaatverschillen betekenen dat bepaalde effecten er iets anders uit kunnen zien of zich anders kunnen gedragen. Valideer kritieke gevallen met echte voorbeelden.