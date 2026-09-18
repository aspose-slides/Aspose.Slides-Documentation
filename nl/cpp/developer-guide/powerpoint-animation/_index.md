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
- animatie-effect
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
description: "Leer hoe je geavanceerde animatie‑effecten kunt toevoegen en beheren in Aspose.Slides voor C++ om dynamische PowerPoint‑ en OpenDocument‑presentaties te maken."
---
## **Inleiding**

Aangezien presentaties bedoeld zijn om iets te presenteren, worden hun visuele uitstraling en interactieve gedrag altijd in overweging genomen tijdens het maken.

**PowerPoint-animatie** speelt een belangrijke rol bij het aantrekkelijk en boeiend maken van een presentatie voor kijkers. Aspose.Slides biedt een breed scala aan mogelijkheden om animaties aan PowerPoint-presentaties toe te voegen:

- Pas verschillende typen PowerPoint-animatie-effecten toe op vormen, grafieken, tabellen, OLE-objecten en andere presentaties-elementen.
- Gebruik meerdere PowerPoint-animatie-effecten op één vorm.
- Gebruik de animatietijdlijn om animatie-effecten te regelen.
- Maak aangepaste animaties.

In Aspose.Slides kunnen verschillende animatie-effecten worden toegepast op vormen. Aangezien elk element op een dia, inclusief tekst, afbeeldingen, OLE-objecten en tabellen, wordt beschouwd als een vorm, kunnen animatie-effecten op elk element op de dia worden toegepast.

De [Aspose::Slides::Animation](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/) namespace biedt klassen voor het werken met PowerPoint-animaties.

## **Animatie-effecten**
Aspose.Slides ondersteunt **meer dan 150 animatie-effecten**, inclusief basis-effecten zoals Bounce, PathFootball en Zoom, en specifieke effecten zoals OLEObjectShow en OLEObjectOpen. Een volledige lijst vind je in de enumeratie [EffectType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/effecttype/).

Daarnaast kunnen deze animatie-effecten in combinatie met de volgende gedragingen worden gebruikt:

- [ColorEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/seteffect/)

## **Aangepaste animatie**

Voor volledige C++-voorbeelden die gedragingen en bewerkbare bewegingspaden maken, inspecteren en wijzigen, zie [Aangepaste animatie](/slides/nl/cpp/custom-animation/).

Het is mogelijk om je eigen **aangepaste animaties** te maken in Aspose.Slides. Dit kan worden bereikt door verschillende gedragingen te combineren tot een nieuwe aangepaste animatie.

[Behavior](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/behavior/) is een bouwsteen van een PowerPoint-animatie-effect. Combineer gedragingen om een effect aan te passen, of voeg een gedrag toe om een vooraf gedefinieerd effect uit te breiden. Herhaling wordt ingesteld via tijdsinstellingen in plaats van een aparte repeat-gedrag.

[Animation Point](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/point/) is een punt waarop een gedrag moet worden toegepast.

## **Animatie-tijdlijn**
[Sequence](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/sequence/) is een verzameling animatie-effecten die op verschillende vormen kunnen worden toegepast.

[IAnimationTimeLine](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ianimationtimeline/) is een set van sequenties die in een specifieke dia worden gebruikt. Het is een animatie-engine geïntroduceerd in PowerPoint 2002. In eerdere versies van PowerPoint was het toevoegen van animatie-effecten aan presentaties lastig en alleen mogelijk met diverse workarounds. De tijdlijn biedt een duidelijker objectmodel voor PowerPoint-animaties. Een dia kan slechts één animatie-tijdlijn hebben.

## **Interactieve animatie**
[Trigger](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/effecttriggertype/) stelt je in staat om gebruikersacties, zoals een knop-klik, te definiëren die een bepaalde animatie starten.

## **Vorm-animatie**
Aspose.Slides stelt je in staat om animaties toe te passen op vormen, die tekst, rechthoeken, lijnen, kaders, OLE-objecten en meer kunnen omvatten.

{{% alert color="info" title="Opmerking" %}}
Lees meer [**Over vorm-animatie**](/slides/nl/cpp/shape-animation/).
{{% /alert %}}

## **Geanimeerde diagrammen**
Om geanimeerde diagrammen te maken, moet je dezelfde klassen gebruiken als voor vormen. Echter, PowerPoint-animaties kunnen alleen worden toegepast op diagramcategorieën of diagramreeksen. Je kunt animatie-effecten ook toepassen op een categorie-element of een reeks-element.

{{% alert color="info" title="Opmerking" %}}
Lees meer [**Over geanimeerde diagrammen**](/slides/nl/cpp/animated-charts/).
{{% /alert %}}

## **Geanimeerde tekst**
Naast het animeren van tekst kun je animatie toepassen op een alinea.

{{% alert color="info" title="Opmerking" %}}
Lees meer [**Over geanimeerde tekst**](/slides/nl/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**Worden animaties behouden bij het exporteren naar PDF?**

Nee. PDF is een statisch formaat, dus animaties en [dia-overgangen](/slides/nl/cpp/slide-transition/) worden niet afgespeeld. Als je beweging nodig hebt, exporteer dan naar [HTML5](/slides/nl/cpp/export-to-html5/), [geanimeerde GIF](/slides/nl/cpp/convert-powerpoint-to-animated-gif/), of [video](/slides/nl/cpp/convert-powerpoint-to-video/) in plaats daarvan.

**Kan ik een geanimeerde presentatie omzetten naar een video en de framesnelheid en framegrootte beheersen?**

Ja. Je kunt de presentatie [renderen als frames](/slides/nl/cpp/convert-powerpoint-to-video/) en deze coderen naar een video (bijv. via ffmpeg), waarbij je de FPS en resolutie kiest. Animaties en dia-overgangen worden tijdens het renderen afgespeeld.

**Blijven animaties behouden bij het werken met ODP (niet alleen PPTX)?**

PPT, PPTX en ODP worden ondersteund voor [lezen](/slides/nl/cpp/open-presentation/) en [schrijven](/slides/nl/cpp/save-presentation/), maar dit garandeert geen behoud van animaties. Aangepaste animatie-gegevens kunnen verloren gaan bij conversie naar ODP. Zie [Aangepaste animatie](/slides/nl/cpp/custom-animation/) voor voorbeelden en richtlijnen om de compatibiliteit van het formaat te controleren.