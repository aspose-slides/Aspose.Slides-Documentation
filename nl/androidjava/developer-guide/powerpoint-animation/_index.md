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
- animatie regelen
- animatie-effect
- PowerPoint-animatie
- animatie-tijdlijn
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
- Android
- Java
- Aspose.Slides
description: "Ontdek de mogelijkheden van Aspose.Slides voor Android via Java bij het verwerken van PowerPoint-animaties. Dit algemene overzicht belicht de belangrijkste functies."
---
## **Introductie**

Aangezien presentaties bedoeld zijn om iets te presenteren, wordt hun visuele uiterlijk en interactieve gedrag altijd in rekening gebracht tijdens het maken.

**PowerPoint-animatie** speelt een belangrijke rol bij het aantrekkelijk en boeiend maken van een presentatie voor de kijkers. Aspose.Slides biedt een breed scala aan opties om animaties toe te voegen aan PowerPoint‑presentaties:

- Pas verschillende soorten PowerPoint‑animatie‑effecten toe op vormen, grafieken, tabellen, OLE‑objecten en andere presentatie‑elementen.
- Gebruik meerdere PowerPoint‑animatie‑effecten op één vorm.
- Gebruik de animatietijdlijn om animatie‑effecten te regelen.
- Maak aangepaste animaties.

In Aspose.Slides kunnen verschillende animatie‑effecten op vormen worden toegepast. Aangezien elk element op een dia, inclusief tekst, afbeeldingen, OLE‑objecten en tabellen, als een vorm wordt beschouwd, kunnen animatie‑effecten op elk element op de dia worden toegepast.

## **Animatie‑effecten**

Aspose.Slides ondersteunt **meer dan 150 animatie‑effecten**, waaronder basis­effecten zoals Bounce, PathFootball en Zoom, en specifieke effecten zoals OLEObjectShow en OLEObjectOpen. Een volledige lijst vindt u in de klasse [EffectType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/effecttype/).

Daarnaast kunnen deze animatie‑effecten in combinatie met de volgende gedragstypen worden gebruikt:

- [ColorEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SetEffect)

## **Aangepaste animatie**

Voor volledige Java‑voorbeelden die gedragingen en bewerkbare bewegingspaden maken, inspecteren en wijzigen, zie [Aangepaste animatie](/slides/nl/java/custom-animation/).

Het is mogelijk om uw eigen **aangepaste animaties** te maken in Aspose.Slides. Dit kan worden bereikt door meerdere gedragingen te combineren tot een nieuwe aangepaste animatie.

[Behavior](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/behavior/) is een bouwsteen van een PowerPoint‑animatie‑effect. Combineer gedragingen om een effect aan te passen, of voeg een gedrag toe om een vooraf gedefinieerd effect uit te breiden. Herhaling wordt geconfigureerd via timing‑instellingen in plaats van een apart herhaal‑gedrag.

[Animation Point](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/point/) is een punt waarop een gedrag moet worden toegepast.

## **Animatietijdlijn**
[Sequence](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sequence/) is een verzameling animatie‑effecten die verschillende vormen kunnen targeten.

[Timeline](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/animationtimeline/) is een set van sequenties die in een specifieke dia worden gebruikt. Het is een animatie‑engine die werd geïntroduceerd in PowerPoint 2002. In eerdere versies van PowerPoint was het toevoegen van animatie‑effecten aan presentaties uitdagend en kon alleen worden bereikt met diverse workarounds. De tijdlijn biedt een duidelijker objectmodel voor PowerPoint‑animaties. Een dia kan slechts één animatietijdlijn bevatten.

## **Interactieve animatie**
[Trigger](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/effecttriggertype/) stelt u in staat om gebruikersacties te definiëren, zoals een klik op een knop, die een bepaalde animatie starten.

## **Vormanimatie**
Aspose.Slides stelt u in staat om animaties toe te passen op vormen, die onder meer tekst, rechthoeken, lijnen, kaders, OLE‑objecten en meer kunnen bevatten.

{{% alert color="info" title="Note" %}}
Lees meer [**Over vormanimatie**](/slides/nl/androidjava/shape-animation/).
{{% /alert %}}

## **Geanimeerde grafieken**
Om geanimeerde grafieken te maken, moet u dezelfde klassen gebruiken als voor vormen. Echter, PowerPoint‑animaties kunnen alleen worden toegepast op grafiek‑categorieën of grafiek‑reeksen. U kunt ook animatie‑effecten toepassen op een categorie‑element of een serie‑element.

{{% alert color="info" title="Note" %}}
Lees meer [**Over geanimeerde grafieken**](/slides/nl/androidjava/animated-charts/).
{{% /alert %}}

## **Geanimeerde tekst**
Naast het animeren van tekst kunt u ook animatie toepassen op een alinea.

{{% alert color="info" title="Note" %}}
Lees meer [**Over geanimeerde tekst**](/slides/nl/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Worden animaties behouden bij exporteren naar PDF?**

Nee. PDF is een statisch formaat, dus animaties en [dia‑overgangen](/slides/nl/androidjava/slide-transition/) worden niet afgespeeld. Als u beweging nodig hebt, exporteer dan naar [HTML5](/slides/nl/androidjava/export-to-html5/), [geanimeerde GIF](/slides/nl/androidjava/convert-powerpoint-to-animated-gif/), of [video](/slides/nl/androidjava/convert-powerpoint-to-video/) in plaats daarvan.

**Kan ik een geanimeerde presentatie omzetten naar een video en de framesnelheid en frame‑grootte bepalen?**

Ja. U kunt de presentatie [renderen als afzonderlijke frames](/slides/nl/androidjava/convert-powerpoint-to-video/) en deze coderen tot een video (bijv. via ffmpeg), waarbij u de fps en resolutie kiest. Animaties en dia‑overgangen worden afgespeeld tijdens het renderen.

**Blijven animaties behouden bij het werken met ODP (niet alleen PPTX)?**

PPT, PPTX en ODP worden ondersteund voor [lezen](/slides/nl/androidjava/open-presentation/) en [schrijven](/slides/nl/androidjava/save-presentation/), maar dit garandeert niet dat animaties behouden blijven. Aangepaste animatie‑gegevens kunnen verloren gaan bij conversie naar ODP. Zie [Aangepaste animatie voor Java](/slides/nl/java/custom-animation/) voor voorbeelden en richtlijnen om de compatibiliteit van het formaat te controleren.