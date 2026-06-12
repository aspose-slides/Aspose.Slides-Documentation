---
title: Animaties toevoegen aan PowerPoint‑presentaties in C++
linktitle: PowerPoint‑animatie
type: docs
weight: 150
url: /nl/cpp/powerpoint-animation/
keywords:
- animatie toevoegen
- animatie bijwerken
- animatie wijzigen
- animatie verwijderen
- animatie beheren
- animatie regelen
- animatie‑effect
- PowerPoint‑animatie
- animatie‑tijdlijn
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
- C++
- Aspose.Slides
description: "Leer hoe u geavanceerde animatie‑effecten kunt toevoegen en beheren in Aspose.Slides voor C++ om dynamische PowerPoint‑ en OpenDocument‑presentaties te maken."
---
## **Inleiding**

Aangezien presentaties bedoeld zijn om iets te presenteren, wordt hun visuele uiterlijk en interactieve gedrag altijd in overweging genomen bij het maken ervan.

**PowerPoint-animatie** speelt een belangrijke rol om een presentatie opvallend en aantrekkelijk voor de kijkers te maken. Aspose.Slides voor C++ biedt een breed scala aan opties om animatie aan een PowerPoint-presentatie toe te voegen:

- verschillende soorten PowerPoint-animatie-effecten toepassen op vormen, diagrammen, tabellen, OLE‑objecten en andere presentatie‑elementen.
- meerdere PowerPoint-animatie-effecten gebruiken op een vorm.
- de animatietijdlijn gebruiken om animatie-effecten te regelen.
- aangepaste animatie maken.

In Aspose.Slides voor C++ kunnen verschillende animatie-effecten op de vormen worden toegepast. Aangezien elk element op de dia, inclusief tekst, afbeeldingen, OLE‑object, tabel enz., wordt beschouwd als een vorm, betekent dit dat we animatie-effecten op elk element van een dia kunnen toepassen.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides.animation) **namespace** biedt klassen om met PowerPoint-animaties te werken.
## **Animatie-effecten**

Aspose.Slides ondersteunt **meer dan 150 animatie-effecten**, waaronder basisanimatie-effecten zoals Bounce, PathFootball, Zoom-effect en specifieke animatie-effecten zoals OLEObjectShow, OLEObjectOpen. Een volledige lijst van animatie-effecten kun je vinden in de [**EffectType**](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) enumeratie.

Daarnaast kunnen deze animatie-effecten in combinatie met elkaar worden gebruikt:
- [KleurEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/coloreffect/)
- [OpdrachtEffect](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.filter_effect)
- [BewegingsEffect](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.motion_effect)
- [EigenschapEffect](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.property_effect)
- [RotatieEffect](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.rotation_effect)
- [SchaalEffect](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.scale_effect)
- [InstellingEffect](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.set_effect)

## **Aangepaste animatie**

Het is mogelijk om je eigen **aangepaste animaties** te maken in Aspose.Slides. 
Dit kan worden bereikt door verschillende gedragspatronen samen te voegen tot een nieuwe aangepaste animatie.

[**Behavior**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.behavior) is een bouwsteen van elk PowerPoint-animatie-effect. Alle animatie-effecten zijn in feite een verzameling gedragspatronen die tot één strategie zijn samengesteld. Je kunt gedragspatronen combineren tot een aangepaste animatie en deze vervolgens in andere presentaties hergebruiken. Als je een nieuw gedragspatroon toevoegt aan een standaard PowerPoint-animatie-effect, ontstaat er een andere aangepaste animatie. Bijvoorbeeld, je kunt een herhaal‑gedrag toevoegen aan een animatie om deze een paar keer te herhalen.

[**Animation Point**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.point) is een punt waarop gedrag moet worden toegepast.

## **Animatie‑tijdlijn**

[**Sequence**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.sequence) is een verzameling animatie-effecten, toegepast op een concrete vorm.

[**AnimationTimeLine**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.animation_time_line) is een set van Sequenties die worden gebruikt in een concrete dia. Het is een animatie‑engine die sinds PowerPoint 2002 bestaat. In eerdere PowerPoint‑versies was het lastig om animatie-effecten aan een presentatie toe te voegen; dit kon alleen met verschillende workarounds. De tijdlijn vervangt de oude AnimationSettings‑klasse en biedt een duidelijker objectmodel voor PowerPoint-animatie. Eén dia kan slechts één animatie‑tijdlijn hebben.

## **Interactieve animatie**

[**EffectTriggerType**](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) maakt het mogelijk om gebruikersacties (bijv. een knop‑klik) te definiëren die een bepaalde animatie starten. Triggers zijn alleen toegevoegd in de nieuwste PowerPoint‑versie.

## **Vorm‑animatie**

Aspose.Slides maakt het mogelijk om animatie toe te passen op vormen, die daadwerkelijk tekst, rechthoek, lijn, frame, OLE‑object, enz. kunnen zijn.

{{% alert color="primary" %}} 
Lees meer [**Over vorm‑animatie**](/slides/nl/cpp/shape-animation/).
{{% /alert %}}

## **Geanimeerde diagrammen**

Om geanimeerde diagrammen te maken, moet je dezelfde klassen gebruiken als voor vormen. Het is echter mogelijk om PowerPoint‑animatie alleen toe te passen op diagramcategorieën of diagramreeksen. Je kunt ook een animatie‑effect toepassen op een categorie‑element of reeks‑element.

{{% alert color="primary" %}} 
Lees meer [**Over geanimeerde diagrammen**](/slides/nl/cpp/animated-charts/).
{{% /alert %}}

## **Geanimeerde tekst**

Naast geanimeerde tekst is het ook mogelijk om animatie toe te passen op een alinea.

{{% alert color="primary" %}} 
Lees meer [**Over geanimeerde tekst**](/slides/nl/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**Worden animaties behouden bij exporteren naar PDF?**

Nee. PDF is een statisch formaat, dus animaties en [dia‑overgangen](/slides/nl/cpp/slide-transition/) worden niet afgespeeld. Als je beweging nodig hebt, exporteer dan naar [HTML5](/slides/nl/cpp/export-to-html5/), [animatie‑GIF](/slides/nl/cpp/convert-powerpoint-to-animated-gif/) of [video](/slides/nl/cpp/convert-powerpoint-to-video/) in plaats daarvan.

**Kan ik een geanimeerde presentatie omzetten naar een video en de framesnelheid en frame‑grootte controleren?**

Ja. Je kunt de presentatie [renderen als frames](/slides/nl/cpp/convert-powerpoint-to-video/) en deze coderen naar een video (bijv. via ffmpeg), waarbij je FPS en resolutie kiest. Animaties en dia‑overgangen worden afgespeeld tijdens het renderen.

**Blijven animaties intact bij het werken met ODP (niet alleen PPTX)?**

PPT, PPTX en ODP worden ondersteund voor [lezen](/slides/nl/cpp/open-presentation/) en [schrijven](/slides/nl/cpp/save-presentation/), maar formatverschillen kunnen ertoe leiden dat bepaalde effecten er iets anders uitzien of anders gedragen. Valideer kritieke gevallen met echte voorbeelden.