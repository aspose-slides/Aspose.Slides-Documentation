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
- Java
- Aspose.Slides
description: "Ontdek de mogelijkheden van Aspose.Slides voor Java bij het verwerken van PowerPoint-animaties. Deze algemene overzicht belicht de belangrijkste functies en biedt inzichten om uw presentaties te verbeteren."
---
## **Inleiding**

Aangezien presentaties bedoeld zijn om iets te tonen, wordt er bij het maken altijd rekening gehouden met hun visuele uiterlijk en interactieve gedrag.

**PowerPoint-animatie** speelt een belangrijke rol bij het aantrekkelijk en boeiend maken van een presentatie voor de kijker. Aspose.Slides biedt een breed scala aan mogelijkheden om animaties toe te voegen aan PowerPoint‑presentaties:

- Pas verschillende soorten PowerPoint‑animatie‑effecten toe op vormen, diagrammen, tabellen, OLE‑objecten en andere presentatiedelen.
- Gebruik meerdere PowerPoint‑animatie‑effecten op één enkele vorm.
- Maak gebruik van de animatietijdlijn om animatie‑effecten te beheersen.
- Creëer aangepaste animaties.

In Aspose.Slides kunnen verschillende animatie‑effecten op vormen worden toegepast. Omdat elk element op een dia, inclusief tekst, afbeeldingen, OLE‑objecten en tabellen, als een vorm wordt beschouwd, kunnen animatie‑effecten op elk element op de dia worden toegepast.

## **Animatie‑effecten**
Aspose.Slides ondersteunt **meer dan 150 animatie‑effecten**, waaronder basis‑effecten zoals Bounce, PathFootball en Zoom, en specifieke effecten zoals OLEObjectShow en OLEObjectOpen. Een volledige lijst vind je in de [EffectType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effecttype/)‑klasse.

Daarnaast kunnen deze animatie‑effecten worden gebruikt in combinatie met de volgende gedragingen:

- [ColorEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SetEffect)

## **Aangepaste animatie**

Voor volledige Java‑voorbeelden die gedrag en bewerkbare bewegingspaden maken, inspecteren en aanpassen, zie [Custom Animation](/slides/nl/java/custom-animation/).

Het is mogelijk om je eigen **aangepaste animaties** te creëren in Aspose.Slides. Dit kan worden bereikt door meerdere gedragingen te combineren tot een nieuwe aangepaste animatie.

[Behavior](https://reference.aspose.com/slides/nl/java/com.aspose.slides/behavior/) is een bouwsteen van een PowerPoint‑animatie‑effect. Combineer gedragingen om een effect aan te passen, of voeg een gedrag toe om een vooraf gedefinieerd effect uit te breiden. Herhaling wordt geconfigureerd via timing‑instellingen in plaats van een afzonderlijk repeat‑gedrag.

[Animation Point](https://reference.aspose.com/slides/nl/java/com.aspose.slides/point/) is een punt waarop een gedrag moet worden toegepast.

## **Animatie‑tijdlijn**
[Sequence](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sequence/) is een collectie animatie‑effecten die op verschillende vormen kan richten.

[Timeline](https://reference.aspose.com/slides/nl/java/com.aspose.slides/animationtimeline/) is een reeks sequensen die in een specifieke dia wordt gebruikt. Het is een animatie‑engine die werd geïntroduceerd in PowerPoint 2002. In eerdere versies van PowerPoint was het toevoegen van animatie‑effecten aan presentaties lastig en alleen mogelijk met verschillende workarounds. De tijdlijn biedt een duidelijker objectmodel voor PowerPoint‑animaties. Een dia kan slechts één animatie‑tijdlijn hebben.

## **Interactieve animatie**
[Trigger](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effecttriggertype/) stelt je in staat om gebruikersacties, zoals een muisklik, te definiëren die een bepaalde animatie starten.

## **Vorm‑animatie**
Aspose.Slides laat je animaties toepassen op vormen, die tekst, rechthoeken, lijnen, frames, OLE‑objecten en meer kunnen omvatten.

{{% alert color="info" title="Opmerking" %}}
Lees meer [**Over Shape‑animatie**](/slides/nl/java/shape-animation/).
{{% /alert %}}

## **Geanimeerde diagrammen**
Om geanimeerde diagrammen te maken, moet je dezelfde klassen gebruiken als voor vormen. PowerPoint‑animaties kunnen echter alleen worden toegepast op diagramcategorieën of diagramreeksen. Je kunt ook animatie‑effecten toepassen op een categoriëlement of een reekselement.

{{% alert color="info" title="Opmerking" %}}
Lees meer [**Over Geanimeerde diagrammen**](/slides/nl/java/animated-charts/).
{{% /alert %}}

## **Geanimeerde tekst**
Naast het animeren van tekst kun je animatie toepassen op een alinea.

{{% alert color="info" title="Opmerking" %}}
Lees meer [**Over Geanimeerde tekst**](/slides/nl/java/animated-text/).
{{% /alert %}}

## **FAQ**

**Worden animaties bewaard bij exporteren naar PDF?**

Nee. PDF is een statisch formaat, dus animaties en [dia‑overgangen](/slides/nl/java/slide-transition/) worden niet afgespeeld. Als je beweging nodig hebt, exporteer dan naar [HTML5](/slides/nl/java/export-to-html5/), [animated GIF](/slides/nl/java/convert-powerpoint-to-animated-gif/) of [video](/slides/nl/java/convert-powerpoint-to-video/) in plaats daarvan.

**Kan ik een geanimeerde presentatie omzetten naar een video en de framesnelheid en frame‑grootte regelen?**

Ja. Je kunt de presentatie [renderen als frames](/slides/nl/java/convert-powerpoint-to-video/) en deze coderen tot een video (bijv. via ffmpeg), waarbij je FPS en resolutie kiest. Animaties en dia‑overgangen worden tijdens het renderen afgespeeld.

**Blijven animaties behouden bij werken met ODP (niet alleen PPTX)?**

PPT, PPTX en ODP worden ondersteund voor [lezen](/slides/nl/java/open-presentation/) en [schrijven](/slides/nl/java/save-presentation/), maar dit garandeert niet dat animaties behouden blijven. Aangepaste animatie‑gegevens kunnen verloren gaan bij conversie naar ODP. Zie [Custom Animation](/slides/nl/java/custom-animation/) voor voorbeelden en richtlijnen om de compatibiliteit van het formaat te controleren.