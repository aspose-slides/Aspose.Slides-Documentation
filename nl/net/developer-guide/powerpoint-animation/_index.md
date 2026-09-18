---
title: Verbeter PowerPoint-presentaties met animaties in .NET
linktitle: PowerPoint-animatie
type: docs
weight: 150
url: /nl/net/powerpoint-animation/
keywords:
- animatie toevoegen
- animatie bijwerken
- animatie wijzigen
- animatie verwijderen
- animatie beheren
- animatie besturen
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
- PowerPoint‑presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek de mogelijkheden van Aspose.Slides voor .NET bij het verwerken van PowerPoint‑animaties. Dit algemene overzicht belicht belangrijke functies en biedt inzichten om uw presentaties te verbeteren."
---
## **Inleiding**

Aangezien presentaties bedoeld zijn om iets te presenteren, wordt er bij het maken altijd rekening gehouden met hun visuele uiterlijk en interactieve gedrag.

**PowerPoint‑animatie** speelt een belangrijke rol bij het aantrekkelijk en boeiend maken van een presentatie voor de kijker. Aspose.Slides for .NET biedt een breed scala aan opties om animaties toe te voegen aan PowerPoint‑presentaties:

- Pas diverse soorten PowerPoint‑animatie‑effecten toe op vormen, diagrammen, tabellen, OLE‑objecten en andere presentatie‑elementen.
- Gebruik meerdere PowerPoint‑animatie‑effecten op één vorm.
- Benut de animatietijdlijn om animatie‑effecten te sturen.
- Maak aangepaste animaties.

In Aspose.Slides for .NET kunnen diverse animatie‑effecten op vormen worden toegepast. Aangezien elk element op een dia, inclusief tekst, afbeeldingen, OLE‑objecten en tabellen, als een vorm wordt beschouwd, kunnen animatie‑effecten op elk element op de dia worden toegepast.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/) namespace biedt klassen om met PowerPoint‑animaties te werken.

## **Animatie‑effecten**

Aspose.Slides ondersteunt **meer dan 150 animatie‑effecten**, waaronder basis‑effecten zoals Bounce, PathFootball en Zoom, evenals specifieke effecten zoals OLEObjectShow en OLEObjectOpen. Een volledige lijst met animatie‑effecten vind je in de [EffectType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effecttype)‑enumeratie.

Daarnaast kunnen deze animatie‑effecten in combinatie met het volgende worden gebruikt:

- [ColorEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/seteffect)

## **Aangepaste animatie**

Voor volledige C#‑voorbeelden die gedrag en bewerkbare bewegingspaden creëren, inspecteren en aanpassen, zie [Aangepaste animatie](/slides/nl/net/custom-animation/).

Het is mogelijk om je eigen **aangepaste animaties** te maken in Aspose.Slides. Dit kan worden bereikt door verschillende gedragingen te combineren tot een nieuwe aangepaste animatie.

[Behavior](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/behavior) is een bouwsteen van een PowerPoint‑animatie‑effect. Combineer gedragingen om een effect aan te passen, of voeg een gedrag toe om een vooraf gedefinieerd effect uit te breiden. Herhaling wordt geconfigureerd via timing‑instellingen in plaats van een apart herhaalgedrag.

[Animation Point](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/point) is een punt waarop een gedrag moet worden toegepast.

## **Animatietijdlijn**

[Sequence](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/sequence) is een verzameling animatie‑effecten die op verschillende vormen kunnen worden toegepast.

[Timeline](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/animationtimeline) is een set van sequences die in een specifieke dia worden gebruikt. Het is een animatie‑engine die werd geïntroduceerd in PowerPoint 2002. In eerdere versies van PowerPoint was het toevoegen van animatie‑effecten aan presentaties moeilijk en kon alleen met diverse workarounds worden bereikt. De tijdlijn vervangt de oude AnimationSettings‑klasse en biedt een duidelijker objectmodel voor PowerPoint‑animaties. Een dia kan maar één animatietijdlijn hebben.

## **Interactieve animatie**

[Trigger](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effecttriggertype) stelt je in staat om gebruikersacties (bijv. een klik op een knop) te definiëren die een specifieke animatie activeren. Triggers werden geïntroduceerd in de nieuwste versie van PowerPoint.

## **Vorm‑animatie**

Aspose.Slides maakt het mogelijk om animaties toe te passen op vormen, die tekst, rechthoeken, lijnen, frames, OLE‑objecten en meer kunnen bevatten.

{{% alert color="info" title="Note" %}}
Lees meer [**Over vorm‑animatie**](/slides/nl/net/shape-animation/).
{{% /alert %}}

## **Geanimeerde diagrammen**

Om geanimeerde diagrammen te maken, moet je dezelfde klassen gebruiken als voor vormen. PowerPoint‑animaties kunnen echter alleen op diagramcategorieën of diagramreeksen worden toegepast. Je kunt ook animatie‑effecten toepassen op een categorie‑element of een reeks‑element.

{{% alert color="info" title="Note" %}}
Lees meer [**Over geanimeerde diagrammen**](/slides/nl/net/animated-charts/).
{{% /alert %}}

## **Geanimeerde tekst**

Naast het animeren van tekst kun je animatie toepassen op een alinea.

{{% alert color="info" title="Note" %}}
Lees meer [**Over geanimeerde tekst**](/slides/nl/net/animated-text/).
{{% /alert %}}

## **FAQ**

**Worden animaties behouden bij exporteren naar PDF?**

Nee. PDF is een statisch formaat, waardoor animaties en [dia‑overgangen](/slides/nl/net/slide-transition/) niet worden afgespeeld. Als je beweging nodig hebt, exporteer je in plaats daarvan naar [HTML5](/slides/nl/net/export-to-html5/), [geanimeerde GIF](/slides/nl/net/convert-powerpoint-to-animated-gif/) of [video](/slides/nl/net/convert-powerpoint-to-video/).

**Kan ik een geanimeerde presentatie omzetten naar een video en de framesnelheid en frame‑grootte regelen?**

Ja. Je kunt de presentatie [renderen als frames](/slides/nl/net/convert-powerpoint-to-video/) en deze coderen naar een video (bijv. via ffmpeg), waarbij je de FPS en resolutie kiest. Animaties en dia‑overgangen worden tijdens het renderen afgespeeld.

**Blijven animaties behouden bij het werken met ODP (niet alleen PPTX)?**

PPT, PPTX en ODP worden ondersteund voor [lezen](/slides/nl/net/open-presentation/) en [schrijven](/slides/nl/net/save-presentation/), maar dat garandeert geen behoud van animaties. Aangepaste animatie‑gegevens kunnen verloren gaan bij conversie naar ODP. Zie [Aangepaste animatie](/slides/nl/net/custom-animation/) voor een geteste voorbeeld en format‑beperkingen.