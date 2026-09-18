---
title: Verbeter PowerPoint-presentaties met animaties in PHP
linktitle: PowerPoint-animatie
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
- animatie‑tijdlijn
- interactieve animatie
- aangepaste animatie
- vorm‑animatie
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
description: "Ontdek de mogelijkheden van Aspose.Slides for PHP via Java voor het verwerken van PowerPoint‑animaties. Belangrijke functies en inzichten om uw presentaties te verbeteren."
---
## **Inleiding**

Aangezien presentaties bedoeld zijn om iets te tonen, wordt bij het maken altijd rekening gehouden met hun visuele uiterlijk en interactieve gedrag.

**PowerPoint-animatie** speelt een belangrijke rol om een presentatie opvallend en boeiend te maken voor kijkers. Aspose.Slides for PHP via Java biedt een breed scala aan opties om animaties aan PowerPoint‑presentaties toe te voegen:

- Pas verschillende soorten PowerPoint‑animatie‑effecten toe op vormen, grafieken, tabellen, OLE‑objecten en andere presentatie‑elementen.  
- Gebruik meerdere PowerPoint‑animatie‑effecten op één vorm.  
- Benut de animatietijdlijn om animatie‑effecten te regelen.  
- Maak aangepaste animaties.

In Aspose.Slides for PHP via Java kunnen diverse animatie‑effecten op vormen worden toegepast. Omdat elk element op een dia, inclusief tekst, afbeeldingen, OLE‑objecten en tabellen, als een vorm wordt beschouwd, kunnen animatie‑effecten op elk element van de dia worden toegepast.

## **Animatie‑effecten**
Aspose.Slides ondersteunt **meer dan 150 animatie‑effecten**, waaronder basis­effecten zoals Bounce, PathFootball en Zoom, en specifieke effect­en zoals OLEObjectShow en OLEObjectOpen. Een volledige lijst vind je in de klasse [EffectType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effecttype/).

Bovendien kunnen deze animatie‑effecten worden gecombineerd met de volgende gedragingen:

- [ColorEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SetEffect)

## **Aangepaste animatie**

Voor volledige PHP‑voorbeelden die gedragingen en bewerkbare bewegingspaden creëren, inspecteren en wijzigen, zie [Aangepaste animatie](/slides/nl/php-java/custom-animation/).

Het is mogelijk om je eigen **aangepaste animaties** te maken in Aspose.Slides. Dit kan worden bereikt door verschillende gedragingen te combineren tot een nieuwe aangepaste animatie.

[Behavior](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behavior/) is een bouwsteen van een PowerPoint‑animatie‑effect. Combineer gedragingen om een effect aan te passen, of voeg een gedrag toe om een vooraf gedefinieerd effect uit te breiden. Herhaling wordt geconfigureerd via timing‑instellingen in plaats van een aparte repeat‑behavior.

[Animation Point](https://reference.aspose.com/slides/nl/php-java/aspose.slides/point/) is een punt waarop een gedrag moet worden toegepast.

## **Animatie‑tijdlijn**
[Sequence](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sequence/) is een verzameling animatie‑effecten die verschillende vormen kunnen targeten.

[Timeline](https://reference.aspose.com/slides/nl/php-java/aspose.slides/animationtimeline/) is een reeks sequenties die in een specifieke dia worden gebruikt. Het is een animatie‑engine die werd geïntroduceerd in PowerPoint 2002. In eerdere versies van PowerPoint was het toevoegen van animatie‑effecten aan presentaties ingewikkeld en alleen mogelijk via diverse workarounds. De tijdlijn biedt een helderder objectmodel voor PowerPoint‑animaties. Een dia kan slechts één animatie‑tijdlijn hebben.

## **Interactieve animatie**
[Trigger](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effecttriggertype/) stelt je in staat om gebruikersacties, zoals een klik op een knop, te definiëren die een bepaalde animatie starten.

## **Vorm‑animatie**
Aspose.Slides stelt je in staat animaties toe te passen op vormen, waaronder tekst, rechthoeken, lijnen, frames, OLE‑objecten en meer.

{{% alert color="info" title="Note" %}}
Read more [**About Shape Animation**](/slides/nl/php-java/shape-animation/).
{{% /alert %}}

## **Geanimeerde grafieken**
Om geanimeerde grafieken te maken, moet je dezelfde klassen gebruiken als voor vormen. Echter, PowerPoint‑animaties kunnen alleen worden toegepast op grafiekcategorieën of grafiekseries. Je kunt animatie‑effecten ook toepassen op een categorie‑element of een series‑element.

{{% alert color="info" title="Note" %}}
Read more [**About Animated Charts**](/slides/nl/php-java/animated-charts/).
{{% /alert %}}

## **Geanimeerde tekst**
Naast het animeren van tekst kun je ook animatie toepassen op een alinea.

{{% alert color="info" title="Note" %}}
Read more [**About Animated Text**](/slides/nl/php-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Worden animaties behouden bij export naar PDF?**

Nee. PDF is een statisch formaat, dus animaties en [slide transitions](/slides/nl/php-java/slide-transition/) worden niet afgespeeld. Als je beweging nodig hebt, exporteer dan naar [HTML5](/slides/nl/php-java/export-to-html5/), [animated GIF](/slides/nl/php-java/convert-powerpoint-to-animated-gif/) of [video](/slides/nl/php-java/convert-powerpoint-to-video/) in plaats daarvan.

**Kan ik een geanimeerde presentatie omzetten naar een video en de framesnelheid en frame‑grootte bepalen?**

Ja. Je kunt de presentatie [renderen als frames](/slides/nl/php-java/convert-powerpoint-to-video/) en ze coderen tot een video (bijv. via ffmpeg), waarbij je FPS en resolutie kiest. Animaties en dia‑overgangen worden afgespeeld tijdens het renderen.

**Blijven animaties behouden bij het werken met ODP (niet alleen PPTX)?**

PPT, PPTX en ODP worden ondersteund voor [lezen](/slides/nl/php-java/open-presentation/) en [schrijven](/slides/nl/php-java/save-presentation/), maar dit garandeert niet dat animaties behouden blijven. Aangepaste animatie‑gegevens kunnen verloren gaan bij conversie naar ODP. Zie [Custom Animation](/slides/nl/php-java/custom-animation/) voor voorbeelden en richtlijnen om de compatibiliteit van het formaat te controleren.