---
title: Beheer presentatie inktobjecten in Python
linktitle: Ink beheren
type: docs
weight: 95
url: /nl/python-net/manage-ink/
keywords:
- inkt
- inktobject
- inktrace
- ink beheren
- ink tekenen
- tekening
- inkexport
- inkrendering
- ink verbergen
- InkOptions
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Beheer PowerPoint-inktobjecten, bewerk tracés en penseel eigenschappen, en beheer de weergave van inkt tijdens export naar PDF, HTML, SVG, TIFF en afbeeldingsbestanden met Aspose.Slides voor Python via .NET."
---
## **Inleiding**

PowerPoint biedt een inktfunctie waarmee je vrije penstreken kunt tekenen. Inkt kan worden gebruikt om andere objecten te markeren, verbindingen en processen te tonen, en de aandacht te vestigen op specifieke items op een dia.

De [aspose.slides.ink](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ink/) namespace bevat de klassen die nodig zijn om met inktobjecten te werken. De [Ink](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ink/ink/) klasse vertegenwoordigt bijvoorbeeld een inktobject op een dia.

## **Verschillen tussen gewone objecten en inktobjecten**

Objecten op een PowerPoint‑dia worden meestal weergegeven door vormobjecten. In de eenvoudigste vorm is een vorm een container die het gebied van het object zelf (het frame) definieert, samen met eigenschappen zoals de container‑grootte, vorm en achtergrond. Zie voor meer informatie [Shape Layout Format](https://docs.aspose.com/slides/nl/python-net/shape-manipulations/#access-layout-formats-for-shape).

Wanneer PowerPoint echter een inktobject verwerkt, negeert het alle eigenschappen van het objectframe (container) behalve de grootte. De grootte van het containergebied wordt bepaald door de standaard [Ink.width](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ink/ink/width/)‑ en [Ink.height](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ink/ink/height/)‑eigenschappen:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inktracés**

Een inktracé is een basiselement dat de traject van een pen registreert terwijl een gebruiker digitale inkt schrijft. Een tracé slaat een reeks verbonden punten op.

De eenvoudigste vorm van codering geeft de X‑ en Y‑coördinaten van elk monsterpunt weer. Wanneer alle verbonden punten worden gerenderd, ontstaat een afbeelding zoals deze:

![ink_powerpoint2](ink_powerpoint2.png)

## **Penseel‑eigenschappen voor tekenen**

Een penseel wordt gebruikt om lijnen te tekenen die de punten van een inktracé verbinden. De [InkBrush.color](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ink/inkbrush/color/)‑ en [InkBrush.size](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ink/inkbrush/size/)‑eigenschappen bepalen respectievelijk de kleur en de grootte.

### **Kleur van inktpenseel instellen**

Deze Python‑code toont hoe je de kleur van een inktpenseel instelt:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **Grootte van inktpenseel instellen**

Deze Python‑code toont hoe je de grootte van een inktpenseel instelt:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

Over het algemeen komen de breedte en hoogte van een penseel niet overeen, waardoor PowerPoint de penseelgrootte niet weergeeft (de corresponderende gegevenssectie is grijs). Wanneer de breedte en hoogte van het penseel wel overeenkomen, toont PowerPoint de grootte op deze manier:

![ink_powerpoint3](ink_powerpoint3.png)

Voor duidelijkheid verhogen we de hoogte van het inktobject en bekijken we de belangrijke afmetingen:

![ink_powerpoint4](ink_powerpoint4.png)

De container (frame) houdt geen rekening met de grootte van de pennen – hij gaat er altijd van uit dat de lijndikte nul is (zie de vorige afbeelding).

Daarom moet, om het zichtbare gebied van het volledige inktobject te bepalen, de penseelgrootte van de tracés in aanmerking worden genomen. Hier is het doelobject (de handgeschreven teksttracé) geschaald naar de grootte van de container (frame). Wanneer de grootte van de container verandert, blijft de penseelgrootte constant, en omgekeerd.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint hanteert vergelijkbaar gedrag voor tekstobjecten:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controle over weergave van inkt tijdens export en rendering**

Aspose.Slides levert de [InkOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/inkoptions/)‑klasse om te bepalen hoe inktobjecten verschijnen in geëxporteerde of gerenderde uitvoer. Je kunt de eigenschappen gebruiken om inkt volledig te verbergen of om te bepalen hoe inktpenseel‑maskerbewerkingen worden geïnterpreteerd.

Ink‑opties zijn beschikbaar via de export‑ of renderopties voor diverse uitvoertypen:

| Uitvoer | Eigenschap Ink‑opties |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Dia‑afbeelding | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/renderingoptions/ink_options/) |

Via deze eigenschappen zijn dezelfde twee instellingen beschikbaar:

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/inkoptions/hide_ink/) bepaalt of inktobjecten worden opgenomen in de uitvoer. Standaardwaarde is `False`.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) bepaalt of een maskerbewerking wordt geïnterpreteerd als doorzichtigheid bij het renderen van een inktpenseel. Standaardwaarde is `True`; stel in op `False` om in plaats daarvan de ROP‑bewerking te gebruiken.

### **Inktobjecten verbergen in PDF‑uitvoer**

Standaard blijven inktobjecten zichtbaar tijdens export. Stel [InkOptions.hide_ink](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/inkoptions/hide_ink/) in op `True` wanneer je een schone uitvoer wilt zonder handgeschreven aantekeningen of andere inktinhoud.

De volgende Python‑voorbeeld exporteert een presentatie naar PDF terwijl alle inktobjecten verborgen blijven:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Inktobjecten verbergen bij het renderen van een dia als afbeelding**

Om inktobjecten te verbergen bij het renderen van dia’s als bitmap‑afbeeldingen, configureer je [RenderingOptions.ink_options](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/renderingoptions/ink_options/) en geef je de renderopties door aan de [Slide.get_image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/)‑methode.

De volgende Python‑voorbeeld rendert de eerste dia als PNG‑afbeelding zonder inktobjecten:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **Rendering van inktmaskers beheren**

De eigenschap [InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) bepaalt hoe maskerbewerkingen worden geïnterpreteerd bij het renderen van inktpenseels. De standaardwaarde is `True`, waardoor doorzichtigheid wordt gebruikt. Stel de eigenschap in op `False` om de ROP‑bewerking te gebruiken.

De volgende Python‑voorbeeld exporteert een dia naar SVG en gebruikt ROP‑gebaseerde rendering voor inktmaskerbewerkingen:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

Dezelfde instelling kan worden toegepast via [TiffOptions.ink_options](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/ink_options/) bij het exporteren van een presentatie of het renderen van een dia naar TIFF.

### **Kiezen of je ink wilt verbergen of behouden**

Stel [InkOptions.hide_ink](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/inkoptions/hide_ink/) in op `True` wanneer het geëxporteerde bestand een schone versie van een geannoteerde presentatie moet zijn, bijvoorbeeld een definitieve kopie bedoeld voor distributie zonder review‑markeringen.

Laat [InkOptions.hide_ink](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/inkoptions/hide_ink/) op de standaardwaarde `False` wanneer inktannotaties deel uitmaken van de beoogde inhoud, zoals review‑commentaren, handgeschreven notities, markeringen of tekeningen die zichtbaar moeten blijven in de geëxporteerde uitkomst. Dit stelt applicaties in staat om gescheiden review‑ en definitieve uitvoer te genereren vanuit dezelfde presentatie zonder de bron‑inkobjecten te wijzigen.

## **FAQ**

**Kan ik de kleur of grootte van een bestaande inktstreep wijzigen?**

Ja. Haal het tracé op via [Ink.traces](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ink/ink/traces/), wijzig vervolgens het [InkTrace.brush](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ink/inktrace/brush/). Je kunt de [InkBrush.color](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ink/inkbrush/color/)‑ en [InkBrush.size](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ink/inkbrush/size/)‑eigenschappen instellen.

**Verandert het verbergen van inkt de bronpresentatie?**

Nee. [InkOptions.hide_ink](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/inkoptions/hide_ink/) heeft alleen invloed op het gerenderde of geëxporteerde resultaat; het verwijdert of wijzigt geen inktobjecten in de bronpresentatie.

**Welke exportformaten ondersteunen inktopties?**

Je kunt inktopties configureren voor PDF, HTML, SVG, TIFF en bitmap‑dia‑afbeeldingen via de hierboven getoonde export‑ of renderopties.

**Verder lezen**

* Voor algemene informatie over vormen, zie de sectie [PowerPoint Shapes](https://docs.aspose.com/slides/nl/python-net/powerpoint-shapes/).
* Voor meer informatie over effectieve waarden, zie [Shape Effective Properties](https://docs.aspose.com/slides/nl/python-net/shape-effective-properties/#get-effective-font-height-value).
* Voor details over PDF‑export, zie [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/nl/python-net/convert-powerpoint-to-pdf/).
* Voor details over HTML‑export, zie [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/nl/python-net/convert-powerpoint-to-html/).
* Voor details over SVG‑export, zie [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/nl/python-net/render-a-slide-as-an-svg-image/).
* Voor details over TIFF‑export, zie [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/nl/python-net/convert-powerpoint-to-tiff/).
* Voor details over dia‑naar‑afbeelding rendering, zie [Convert Presentation Slides to Images](https://docs.aspose.com/slides/nl/python-net/convert-slide/).