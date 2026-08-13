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
- vormanimatie
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

Aangezien presentaties bedoeld zijn om iets te presenteren, wordt bij het maken altijd rekening gehouden met hun visuele uitstraling en interactieve gedrag.

**PowerPoint-animatie** speelt een belangrijke rol bij het aantrekkelijk en boeiend maken van een presentatie voor de kijker. Aspose.Slides biedt een breed scala aan opties om animaties toe te voegen aan PowerPoint‑presentaties:

- Pas verschillende soorten PowerPoint-animatie‑effecten toe op vormen, grafieken, tabellen, OLE‑objecten en andere presentatie‑elementen.
- Gebruik meerdere PowerPoint-animatie‑effecten op één vorm.
- Maak gebruik van de animatietijdlijn om animatie‑effecten te regelen.
- Maak aangepaste animaties.

## **Animatie‑effecten**
Aspose.Slides ondersteunt **150+ animatie‑effecten**, waaronder basiseffecten zoals Bounce, PathFootball, Zoom‑effect en specifieke animatie‑effecten zoals OLEObjectShow, OLEObjectOpen. Een volledige lijst van animatie‑effecten vind je in de [**EffectType**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effecttype/)‑enumeratie.

Daarnaast kunnen deze animatie‑effecten gecombineerd worden met:

- [ColorEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SetEffect)

## **Aangepaste animatie**
Het is mogelijk om je eigen **aangepaste animaties** te maken in Aspose.Slides.  
Dit kun je bereiken door verschillende gedragspatronen te combineren tot een nieuwe aangepaste animatie.

[**Behavior**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Behavior) is een bouwsteen van elk PowerPoint‑animatie‑effect. Alle animatie‑effecten bestaan eigenlijk uit een verzameling gedragspatronen die tot één strategie zijn samengevoegd. Je kunt gedragspatronen combineren tot een aangepaste animatie eenmalig en deze hergebruiken in andere presentaties. Als je een nieuw gedrag toevoegt aan een standaard PowerPoint‑animatie‑effect, wordt het een andere aangepaste animatie. Bijvoorbeeld, je kunt een herhaal‑gedrag toevoegen aan een animatie zodat deze een paar keer herhaalt.

[**Animation Point**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Point) is een punt waarop gedrag moet worden toegepast.

## **Animatie‑tijdlijn**
[**Sequence**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Sequence) is een verzameling animatie‑effecten die op een bepaalde vorm worden toegepast.

[**Timeline**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/AnimationTimeLine) is een set van Sequences die in een specifieke dia worden gebruikt. Het is een animatie‑engine die bestaat sinds PowerPoint 2002. In vorige PowerPoint‑versies was het lastig om animatie‑effecten aan een presentatie toe te voegen, wat alleen met verschillende workarounds kon worden bereikt. De tijdlijn vervangt de oude AnimationSettings‑klasse en biedt een duidelijker objectmodel voor PowerPoint‑animatie. Eén dia kan slechts één animatie‑tijdlijn hebben.

## **Interactieve animatie**
[**Trigger**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/EffectTriggerType) maakt het mogelijk om gebruikersacties (bijv. klikken op een knop) te definiëren die een bepaalde animatie laten starten. Triggers zijn alleen toegevoegd in de nieuwste versie van PowerPoint.

## **Vorm‑animatie**
Aspose.Slides maakt het mogelijk om animaties toe te passen op vormen, die in feite tekst, rechthoek, lijn, frame, OLE‑object, enz. kunnen zijn.

{{% alert color="info" %}} 
Lees meer [**Over Vorm‑animatie**](/slides/nl/java/shape-animation/).
{{% /alert %}}

## **Geanimeerde grafieken**
Om geanimeerde grafieken te maken, moet je dezelfde klassen gebruiken als voor de vormen. Het is echter mogelijk om PowerPoint‑animatie alleen op grafiek‑categorieën of -reeksen toe te passen. Je kunt ook een animatie‑effect toepassen op een categoriegedeelte of een reeks‑gedeelte.

{{% alert color="info" %}} 
Lees meer [**Over Geanimeerde grafieken**](/slides/nl/java/animated-charts/).
{{% /alert %}}

## **Geanimeerde tekst**
Naast geanimeerde tekst is het ook mogelijk om animatie toe te passen op een alinea.

{{% alert color="info" %}} 
Lees meer [**Over Geanimeerde tekst**](/slides/nl/java/animated-text/).
{{% /alert %}}

## **Veelgestelde vragen**

### Will animations be preserved when exporting to PDF?
Nee. PDF is een statisch formaat, dus animaties en [slide transitions](/slides/nl/java/slide-transition/) worden niet afgespeeld. Als je beweging nodig hebt, exporteer dan naar [HTML5](/slides/nl/java/export-to-html5/), [animated GIF](/slides/nl/java/convert-powerpoint-to-animated-gif/) of [video](/slides/nl/java/convert-powerpoint-to-video/) in plaats daarvan.

### Can I turn an animated presentation into a video and control the frame rate and frame size?
Ja. Je kunt de presentatie [renderen als frames](/slides/nl/java/convert-powerpoint-to-video/) en ze coderen naar een video (bijv. via ffmpeg), waarbij je de FPS en resolutie kiest. Animaties en slide transitions worden tijdens het renderen afgespeeld.

### Will animations remain intact when working with ODP (not just PPTX)?
PPT, PPTX en ODP worden ondersteund voor [reading](/slides/nl/java/open-presentation/) en [writing](/slides/nl/java/save-presentation/), maar formatverschillen kunnen ertoe leiden dat bepaalde effecten er enigszins anders uitzien of zich anders gedragen. Valideer kritieke gevallen met echte exemplaren.