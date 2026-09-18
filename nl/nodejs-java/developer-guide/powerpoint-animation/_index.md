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
- Node.js
- JavaScript
- Aspose.Slides
description: "Gebruik Aspose.Slides for Node.js via Java om PowerPoint-animaties te verwerken. Dit overzicht belicht belangrijke functies en biedt inzichten om je presentaties te verbeteren."
---
## **Introductie**

Aangezien presentaties bedoeld zijn om iets weer te geven, worden hun visuele uiterlijk en interactieve gedrag altijd in overweging genomen tijdens het maken.

**PowerPoint-animatie** speelt een belangrijke rol bij het aantrekkelijk en boeiend maken van een presentatie voor de kijker. Aspose.Slides for Node.js via Java biedt een breed scala aan opties om animaties toe te voegen aan PowerPoint‑presentaties:

- Pas verschillende soorten PowerPoint‑animatie-effecten toe op vormen, grafieken, tabellen, OLE‑objecten en andere presentatieselementen.
- Gebruik meerdere PowerPoint‑animatie-effecten op één vorm.
- Maak gebruik van de animatietijdlijn om animatie‑effecten te beheren.
- Maak aangepaste animaties.

In Aspose.Slides for Node.js via Java kunnen verschillende animatie‑effecten worden toegepast op vormen. Omdat elk element op een dia, inclusief tekst, afbeeldingen, OLE‑objecten en tabellen, wordt beschouwd als een vorm, kunnen animatie‑effecten op elk element van de dia worden toegepast.

## **Animatie‑effecten**
Aspose.Slides ondersteunt **meer dan 150 animatie‑effecten**, waaronder basis‑effecten zoals Bounce, PathFootball en Zoom, en specifieke effecten zoals OLEObjectShow en OLEObjectOpen. Een volledige lijst vind je in de [EffectType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effecttype/)‑enumeratie.

Deze animatie‑effecten kunnen bovendien in combinatie met de volgende gedragselementen worden gebruikt:

- [ColorEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SetEffect)

## **Aangepaste animatie**

Voor volledige JavaScript‑voorbeelden die gedrag en bewerkbare bewegingspaden creëren, inspecteren en wijzigen, zie [Custom Animation](/slides/nl/nodejs-java/custom-animation/).

Het is mogelijk om je eigen **aangepaste animaties** te maken in Aspose.Slides. Dit kan worden bereikt door verschillende gedragselementen te combineren tot een nieuwe aangepaste animatie.

[Behavior](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behavior/) is een bouwsteen van een PowerPoint‑animatie‑effect. Combineer gedragselementen om een effect aan te passen, of voeg een gedragselement toe om een vooraf gedefinieerd effect uit te breiden. Herhaling wordt geconfigureerd via timing‑instellingen in plaats van een afzonderlijk herhaal‑gedrag.

[Animation Point](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/point/) is een punt waarop een gedragselement moet worden toegepast.

## **Animatietijdlijn**
[Sequence](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/) is een verzameling animatie‑effecten die op verschillende vormen kunnen worden toegepast.

[Timeline](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/animationtimeline/) is een verzameling van sequenties die in een specifieke dia worden gebruikt. Het is een animatie‑engine die werd geïntroduceerd in PowerPoint 2002. In eerdere versies van PowerPoint was het toevoegen van animatie‑effecten aan presentaties uitdagend en alleen haalbaar met verschillende oplossingen. De tijdlijn biedt een duidelijker objectmodel voor PowerPoint‑animaties. Een dia kan slechts één animatietijdlijn hebben.

## **Interactieve animatie**
[Trigger](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effecttriggertype/) maakt het mogelijk om gebruikersacties, zoals een knopklik, te definiëren die een bepaalde animatie starten.

## **Vormanimatie**
Aspose.Slides stelt je in staat animaties toe te passen op vormen, die tekst, rechthoeken, lijnen, kaders, OLE‑objecten en meer kunnen omvatten.

{{% alert color="info" title="Note" %}}
Lees meer [**Over vormanimatie**](/slides/nl/nodejs-java/shape-animation/).
{{% /alert %}}

## **Geanimeerde grafieken**
Om geanimeerde grafieken te maken, moet je dezelfde klassen gebruiken als voor vormen. PowerPoint‑animaties kunnen echter alleen worden toegepast op grafiekcategorieën of grafiekreeksen. Je kunt ook animatie‑effecten toepassen op een categorie‑element of een reeks‑element.

{{% alert color="info" title="Note" %}}
Lees meer [**Over geanimeerde grafieken**](/slides/nl/nodejs-java/animated-charts/).
{{% /alert %}}

## **Geanimeerde tekst**
Naast het animeren van tekst kun je ook animatie toepassen op een alinea.

{{% alert color="info" title="Note" %}}
Lees meer [**Over geanimeerde tekst**](/slides/nl/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Wordt de animatie bewaard bij exporteren naar PDF?**

Nee. PDF is een statisch formaat, dus animaties en [dia‑overgangen](/slides/nl/nodejs-java/slide-transition/) worden niet afgespeeld. Als je beweging nodig hebt, exporteer dan naar [HTML5](/slides/nl/nodejs-java/export-to-html5/), [geanimeerde GIF](/slides/nl/nodejs-java/convert-powerpoint-to-animated-gif/), of [video](/slides/nl/nodejs-java/convert-powerpoint-to-video/) in plaats daarvan.

**Kan ik een geanimeerde presentatie omzetten naar een video en de framesnelheid en frame‑grootte regelen?**

Ja. Je kunt de presentatie [renderen als frames](/slides/nl/nodejs-java/convert-powerpoint-to-video/) en deze coderen tot een video (bijv. via ffmpeg), waarbij je de FPS en resolutie kiest. Animaties en dia‑overgangen worden afgespeeld tijdens het renderen.

**Blijven animaties behouden bij het werken met ODP (niet alleen PPTX)?**

PPT, PPTX en ODP worden ondersteund voor [reading](/slides/nl/nodejs-java/open-presentation/) en [writing](/slides/nl/nodejs-java/save-presentation/), maar dit garandeert geen behoud van animaties. Aangepaste animatiegegevens kunnen verloren gaan bij conversie naar ODP. Zie [Custom Animation](/slides/nl/nodejs-java/custom-animation/) voor voorbeelden en richtlijnen om de compatibiliteit van het formaat te controleren.