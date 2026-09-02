---
title: Ink-objecten in een presentatie beheren in .NET
linktitle: Ink beheren
type: docs
weight: 95
url: /nl/net/manage-ink/
keywords:
- inkt
- inkobject
- inkspoor
- ink beheren
- ink tekenen
- tekening
- inkexport
- inkrendering
- ink verbergen
- IInkOptions
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer PowerPoint-inkobjecten, bewerk sporen en kwasteigenschappen, en beheer de weergave van ink tijdens export naar PDF, HTML, SVG, TIFF en afbeeldingen met Aspose.Slides voor .NET."
---
## **Introduction**

PowerPoint biedt een ink‑functie waarmee u vrijvormige streken kunt tekenen. Ink kan worden gebruikt om andere objecten te markeren, verbindingen en processen weer te geven, en de aandacht te vestigen op specifieke elementen op een dia.

De [Aspose.Slides.Ink](https://reference.aspose.com/slides/nl/net/aspose.slides.ink/) namespace bevat de klassen en interfaces die nodig zijn om met ink‑objecten te werken. Bijvoorbeeld, de [IInk](https://reference.aspose.com/slides/nl/net/aspose.slides.ink/iink/) interface vertegenwoordigt een ink‑object op een dia.

## **Verschillen tussen gewone objecten en ink‑objecten**

Objecten op een PowerPoint‑dia worden doorgaans weergegeven door vormobjecten. In zijn eenvoudigste vorm is een vorm een container die het gebied van het object zelf (het frame) definieert, samen met eigenschappen zoals de containergrootte, vorm en achtergrond. Voor meer informatie, zie [Shape Layout Format](https://docs.aspose.com/slides/nl/net/shape-manipulations/#access-layout-formats-for-shape).

Wanneer PowerPoint echter een ink‑object verwerkt, negeert het alle eigenschappen van het objectframe (container) behalve de grootte. De grootte van het containergebied wordt bepaald door de standaard [IShape.Width](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/width/) en [IShape.Height](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/height/) eigenschappen:

![ink_powerpoint1](ink_powerpoint1.png)

## **Ink Traces**

Een ink‑spoor is een basiselement dat wordt gebruikt om de baan van een pen vast te leggen terwijl een gebruiker digitale ink schrijft. Een spoor slaat een reeks verbonden punten op.

De eenvoudigste vorm van codering specificeert de X- en Y‑coördinaten van elk monsterpunt. Wanneer alle verbonden punten worden gerenderd, produceren ze een afbeelding zoals deze:

![ink_powerpoint2](ink_powerpoint2.png)

## **Brush Properties for Drawing**

Een kwast wordt gebruikt om lijnen te tekenen die de punten van een ink‑spoor verbinden. De kwast heeft zijn eigen kleur en grootte, weergegeven door de eigenschappen [IInkBrush.Color](https://reference.aspose.com/slides/nl/net/aspose.slides.ink/iinkbrush/color/) en [IInkBrush.Size](https://reference.aspose.com/slides/nl/net/aspose.slides.ink/iinkbrush/size/).

### **Set Ink Brush Color**

Deze C#‑code laat zien hoe u de kleur van een ink‑kwast instelt:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **Set Ink Brush Size**

Deze C#‑code laat zien hoe u de grootte van een ink‑kwast instelt:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

Over het algemeen komen de breedte en hoogte van een kwast niet overeen, waardoor PowerPoint de kwastgrootte niet weergeeft (de overeenkomstige gegevenssectie is grijs). Wanneer de breedte en hoogte van de kwast wel overeenkomen, toont PowerPoint de grootte op deze manier:

![ink_powerpoint3](ink_powerpoint3.png)

Voor duidelijkheid, laten we de hoogte van het ink‑object vergroten en de belangrijke afmetingen bekijken:

![ink_powerpoint4](ink_powerpoint4.png)

De container (frame) houdt geen rekening met de grootte van de kwasten – hij gaat er altijd van uit dat de lijndikte nul is (zie de vorige afbeelding).

Daarom moet, om het zichtbare gebied van het volledige ink‑object te bepalen, de kwastgrootte van de sporen in aanmerking worden genomen. Hier is het doelobject (het handgeschreven tekstspoor) geschaald naar de grootte van de container (frame). Wanneer de grootte van de container verandert, blijft de kwastgrootte constant, en omgekeerd.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint hanteert een vergelijkbaar gedrag voor tekstobjecten:

![ink_powerpoint6](ink_powerpoint6.png)

## **Control Ink Appearance During Export and Rendering**

Aspose.Slides biedt de [IInkOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/iinkoptions/) interface om te bepalen hoe ink‑objecten verschijnen in geëxporteerde of gerenderde uitvoer. U kunt de eigenschappen gebruiken om ink volledig te verbergen of om te wijzigen hoe ink‑kwast‑maskerbewerkingen worden geïnterpreteerd.

Ink‑opties zijn beschikbaar via de export‑ of renderingsopties voor verschillende uitvoertypen:

| Uitvoer | Inktoptie‑eigenschap |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/nl/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/inkoptions/) |
| Slide image | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/nl/net/aspose.slides.export/renderingoptions/inkoptions/) |

Via deze eigenschappen zijn dezelfde twee instellingen beschikbaar:

- `HideInk` bepaalt of ink‑objecten worden opgenomen in de uitvoer. De standaardwaarde is `false`.
- `InterpretMaskOpAsOpacity` bepaalt of een maskerbewerking wordt geïnterpreteerd als opacity bij het renderen van een ink‑kwast. De standaardwaarde is `true`; stel deze in op `false` om in plaats daarvan de ROP‑bewerking te gebruiken.

### **Hide Ink Objects in PDF Output**

Standaard blijven ink‑objecten zichtbaar tijdens export. Stel [IInkOptions.HideInk](https://reference.aspose.com/slides/nl/net/aspose.slides.export/iinkoptions/hideink/) in op `true` wanneer u een nette uitvoer wilt zonder handgeschreven aantekeningen of andere ink‑inhoud.

Het volgende C#‑voorbeeld exporteert een presentatie naar PDF terwijl alle ink‑objecten worden verborgen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Hide Ink Objects When Rendering a Slide as an Image**

Om ink‑objecten te verbergen bij het renderen van dia's als bitmap‑afbeeldingen, configureer [RenderingOptions.InkOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/renderingoptions/inkoptions/) en geef de renderingsopties door aan de [ISlide.GetImage](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/getimage/) methode.

Het volgende C#‑voorbeeld rendert de eerste dia als een PNG‑afbeelding zonder ink‑objecten:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **Control Ink Mask Rendering**

De eigenschap [IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) bepaalt hoe maskerbewerkingen worden geïnterpreteerd bij het renderen van ink‑kwasten. De standaardwaarde is `true`, wat opacity gebruikt. Stel de eigenschap in op `false` om in plaats daarvan de ROP‑bewerking te gebruiken.

Het volgende C#‑voorbeeld exporteert een dia naar SVG en gebruikt ROP‑gebaseerde weergave voor ink‑maskerbewerkingen:

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

Dezelfde instelling kan worden toegepast via [TiffOptions.InkOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/inkoptions/) bij het exporteren van een presentatie of het renderen van een dia naar TIFF.

### **Choose Whether to Hide or Preserve Ink**

Gebruik [IInkOptions.HideInk](https://reference.aspose.com/slides/nl/net/aspose.slides.export/iinkoptions/hideink/) ingesteld op `true` wanneer het geëxporteerde bestand een nette versie van een geannoteerde presentatie moet zijn, bijvoorbeeld een definitieve kopie bedoeld voor distributie zonder review‑markeringen.

Laat [IInkOptions.HideInk](https://reference.aspose.com/slides/nl/net/aspose.slides.export/iinkoptions/hideink/) op de standaardwaarde `false` staan wanneer ink‑annotaties deel uitmaken van de beoogde inhoud, zoals review‑opmerkingen, handgeschreven notities, markeringen of tekeningen die zichtbaar moeten blijven in het geëxporteerde resultaat. Hiermee kunnen toepassingen aparte review‑ en definitieve uitvoer genereren vanuit dezelfde presentatie zonder de bron‑ink‑objecten te wijzigen.

## **Veelgestelde vragen**

**Kan ik de kleur of grootte van een bestaande ink‑streep wijzigen?**

Ja. Haal het spoor op via [IInk.Traces](https://reference.aspose.com/slides/nl/net/aspose.slides.ink/iink/traces/), en wijzig vervolgens de bijbehorende [IInkTrace.Brush](https://reference.aspose.com/slides/nl/net/aspose.slides.ink/iinktrace/brush/). U kunt de eigenschappen [IInkBrush.Color](https://reference.aspose.com/slides/nl/net/aspose.slides.ink/iinkbrush/color/) en [IInkBrush.Size](https://reference.aspose.com/slides/nl/net/aspose.slides.ink/iinkbrush/size/) van de kwast instellen.

**Verandert het verbergen van ink de bronpresentatie?**

Nee. [IInkOptions.HideInk](https://reference.aspose.com/slides/nl/net/aspose.slides.export/iinkoptions/hideink/) beïnvloedt alleen het gerenderde of geëxporteerde resultaat; het verwijdert of wijzigt de ink‑objecten in de bronpresentatie niet.

**Welke exportformaten ondersteunen inktopties?**

U kunt inktopties configureren voor PDF, HTML, SVG, TIFF en bitmap‑dia‑afbeeldingen via de overeenkomstige export‑ of renderingsopties die hierboven worden weergegeven.

**Verdere lectuur**

* Voor algemene informatie over vormen, zie de sectie [PowerPoint Shapes](https://docs.aspose.com/slides/nl/net/powerpoint-shapes/).
* Voor meer informatie over effectieve waarden, zie [Shape Effective Properties](https://docs.aspose.com/slides/nl/net/shape-effective-properties/#get-effective-font-height-value).
* Voor details over PDF‑export, zie [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/nl/net/convert-powerpoint-to-pdf/).
* Voor details over HTML‑export, zie [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/nl/net/convert-powerpoint-to-html/).
* Voor details over SVG‑export, zie [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/nl/net/render-a-slide-as-an-svg-image/).
* Voor details over TIFF‑export, zie [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/nl/net/convert-powerpoint-to-tiff/).
* Voor details over het renderen van dia’s naar afbeelding, zie [Convert Presentation Slides to Images](https://docs.aspose.com/slides/nl/net/convert-slide/).