---
title: Beheer PowerPoint-inktopjecten in Python via Java
linktitle: Beheer Inkt
type: docs
weight: 95
url: /nl/python-java/manage-ink/
keywords:
- inkt
- inktobject
- inktspoor
- beheer inkt
- teken inkt
- tekening
- inktexport
- inktrendering
- verberg inkt
- InkOptions
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheer PowerPoint-inktopjecten, bewerk sporen en kwasteigenschappen, en regel de weergave van inkt tijdens export naar PDF, HTML, SVG, TIFF en afbeelding met Aspose.Slides voor Python via Java."
---
## **Inleiding**

PowerPoint biedt een inkt‑functie waarmee u vrije tekenstreken kunt maken. Inkt kan worden gebruikt om andere objecten te markeren, verbindingen en processen weer te geven en de aandacht op specifieke items op een dia te vestigen.

Aspose.Slides levert de typen die nodig zijn om met inktobjecten te werken. De [Ink](https://reference.aspose.com/slides/nl/python-java/aspose.slides/ink/)‑klasse vertegenwoordigt bijvoorbeeld een inktobject op een dia.

## **Verschillen tussen reguliere objecten en inktobjecten**

Objecten op een PowerPoint‑dia worden meestal weergegeven door shape‑objecten. In de eenvoudigste vorm is een shape een container die het gebied van het object zelf (het frame) definieert, samen met eigenschappen zoals de container‑grootte, vorm en achtergrond. Zie voor meer informatie [Shape Layout Format](/slides/nl/python-java/shape-manipulations/#access-layout-formats-for-shape).

Wanneer PowerPoint echter een inktobject afhandelt, negeert het alle eigenschappen van het object‑frame (container) behalve de grootte. De grootte van het container‑gebied wordt bepaald door de standaardmethoden [Shape.getWidth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getWidth) en [Shape.getHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Inktsporen**

Een inktspoor is een basiselement dat de trajectorie van een pen registreert wanneer een gebruiker digitale inkt schrijft. Een spoor slaat een reeks verbonden punten op.

De eenvoudigste coderingsvorm specificeert de X‑ en Y‑coördinaten van elk monsterpunt. Wanneer alle verbonden punten worden gerenderd, ontstaat een afbeelding als deze:

![ink_powerpoint2](ink_powerpoint2.png)

## **Kwast‑eigenschappen voor tekenen**

Een kwast wordt gebruikt om lijnen te tekenen die de punten van een inktspoor verbinden. De kwast heeft zijn eigen kleur en grootte, weergegeven door de methoden [InkBrush.getColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/inkbrush/#getColor) en [InkBrush.getSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/inkbrush/#getSize).

### **Stel inkt‑kwastkleur in**

Deze Python‑code laat zien hoe u de kleur van een inktkwast instelt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **Stel inkt‑kwastgrootte in**

Deze Python‑code laat zien hoe u de grootte van een inktkwast instelt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

Over het algemeen komen de breedte en hoogte van een kwast niet overeen, waardoor PowerPoint de kwastgrootte niet weergeeft (de overeenkomstige gegevenssectie is grijs). Wanneer de breedte en hoogte wel overeenkomen, toont PowerPoint de grootte als volgt:

![ink_powerpoint3](ink_powerpoint3.png)

Voor de duidelijkheid vergroten we de hoogte van het inktobject en bekijken we de belangrijke afmetingen:

![ink_powerpoint4](ink_powerpoint4.png)

De container (frame) houdt geen rekening met de grootte van de kwasten — hij gaat er altijd van uit dat de lijndikte nul is (zie de vorige afbeelding).

Daarom moet, om het zichtbare gebied van het volledige inktobject te bepalen, de kwastgrootte van de sporen in aanmerking worden genomen. Hier is het doelobject (het handgeschreven tekstspoor) geschaald naar de grootte van de container (frame). Wanneer de grootte van de container verandert, blijft de kwastgrootte constant, en omgekeerd.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint gebruikt vergelijkbaar gedrag voor tekstobjecten:

![ink_powerpoint6](ink_powerpoint6.png)

## **Regel de weergave van inkt tijdens export en rendering**

Aspose.Slides levert de [InkOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/inkoptions/)‑klasse om te bepalen hoe inktobjecten verschijnen in geëxporteerde of gerenderde output. U kunt de eigenschappen gebruiken om inkt volledig te verbergen of om de interpretatie van inkt‑kwastmasker‑operaties aan te passen.

Ink‑opties zijn beschikbaar via de export‑ of rendering‑opties voor verschillende output‑typen:

| Uitvoer | Eigenschap Ink‑opties |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Dia‑afbeelding | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/renderingoptions/#getInkOptions) |

De volgende [InkOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/inkoptions/)‑methoden bieden dezelfde twee instellingen:

- [getHideInk](https://reference.aspose.com/slides/nl/python-java/aspose.slides/inkoptions/#getHideInk) bepaalt of inktobjecten worden opgenomen in de output. Standaard is `False`.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) bepaalt of een masker‑operatie wordt geïnterpreteerd als doorzichtigheid bij het renderen van een inktkwast. Standaard is `True`; roep [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) aan met `False` om de ROP‑operatie te gebruiken.

### **Verberg inktobjecten in PDF‑output**

Standaard blijven inktobjecten zichtbaar tijdens export. Om een schone output zonder handgeschreven aantekeningen of andere inktinhoud te maken, roep [InkOptions.setHideInk](https://reference.aspose.com/slides/nl/python-java/aspose.slides/inkoptions/#setHideInk) aan met `True`.

De volgende Python‑voorbeeld exporteert een presentatie naar PDF terwijl alle inktobjecten worden verborgen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Verberg inktobjecten bij het renderen van een dia als afbeelding**

Om inktobjecten te verbergen bij het renderen van dia’s als bitmap‑afbeeldingen, configureer [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/renderingoptions/#getInkOptions) en geef de rendering‑opties door aan [Slide.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage).

De volgende Python‑voorbeeld renderen de eerste dia als PNG‑afbeelding zonder inktobjecten:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **Regel weergave van inktmaskers**

De instelling [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) bepaalt hoe masker‑operaties worden geïnterpreteerd bij het renderen van inktkwasten. De standaardwaarde is `True`, waardoor doorzichtigheid wordt gebruikt. Om in plaats daarvan de ROP‑operatie te gebruiken, roep [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) aan met `False`.

De volgende Python‑voorbeeld exporteert een dia naar SVG en gebruikt ROP‑gebaseerde rendering voor inktmasker‑operaties:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

Dezelfde instelling kan worden toegepast via [TiffOptions.getInkOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tiffoptions/#getInkOptions) bij het exporteren van een presentatie of het renderen van een dia naar TIFF.

### **Kies of u inkt wilt verbergen of behouden**

Wanneer u een schone versie van een geannoteerde presentatie nodig heeft voor distributie zonder review‑markeringen, roep dan [InkOptions.setHideInk](https://reference.aspose.com/slides/nl/python-java/aspose.slides/inkoptions/#setHideInk) aan met `True` tijdens export.

Laat [InkOptions.getHideInk](https://reference.aspose.com/slides/nl/python-java/aspose.slides/inkoptions/#getHideInk) op de standaardwaarde `False` staan wanneer inktannotaties deel uitmaken van de beoogde inhoud, zoals review‑opmerkingen, handgeschreven notities, markeringen of tekeningen die zichtbaar moeten blijven in het geëxporteerde resultaat. Dit stelt toepassingen in staat om afzonderlijke review‑ en definitieve outputs te genereren vanuit dezelfde presentatie zonder de bron‑inktopjecten te wijzigen.

## **FAQ**

**Kan ik de kleur of grootte van een bestaande inktstreep wijzigen?**

Ja. Haal het spoor op via [Ink.getTraces](https://reference.aspose.com/slides/nl/python-java/aspose.slides/ink/#getTraces) en wijzig vervolgens de bijbehorende [InkTrace.getBrush](https://reference.aspose.com/slides/nl/python-java/aspose.slides/inktrace/#getBrush). Roep [InkBrush.setColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/inkbrush/#setColor) of [InkBrush.setSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/inkbrush/#setSize) aan om de kwast aan te passen.

**Veroorzaakt het verbergen van inkt wijzigingen in de bronpresentatie?**

Nee. Het aanroepen van [InkOptions.setHideInk](https://reference.aspose.com/slides/nl/python-java/aspose.slides/inkoptions/#setHideInk) beïnvloedt alleen het gerenderde of geëxporteerde resultaat; het verwijdert of wijzigt de inktobjecten niet in de bronpresentatie.

**Welke exportformaten ondersteunen inktopties?**

U kunt inktopties configureren voor PDF, HTML, SVG, TIFF en bitmap‑dia‑afbeeldingen via de hierboven genoemde export‑ of rendering‑opties.

**Verdere lectuur**

* Lees voor algemene informatie over shapes de sectie [PowerPoint Shapes](/slides/nl/python-java/powerpoint-shapes/).
* Voor meer informatie over effectieve waarden, zie [Shape Effective Properties](/slides/nl/python-java/shape-effective-properties/#get-effective-font-height-value).
* Voor details over PDF‑export, zie [Convert PPT and PPTX to PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/).
* Voor details over HTML‑export, zie [Convert PowerPoint Presentations to HTML](/slides/nl/python-java/convert-powerpoint-to-html/).
* Voor details over SVG‑export, zie [Render Presentation Slides as SVG Images](/slides/nl/python-java/render-a-slide-as-an-svg-image/).
* Voor details over TIFF‑export, zie [Convert PowerPoint Presentations to TIFF](/slides/nl/python-java/convert-powerpoint-to-tiff/).
* Voor details over dia‑naar‑afbeelding rendering, zie [Convert Presentation Slides to Images](/slides/nl/python-java/convert-slide/).