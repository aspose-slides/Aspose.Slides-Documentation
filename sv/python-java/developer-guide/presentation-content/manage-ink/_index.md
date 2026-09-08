---
title: Hantera presentationens bläckobjekt i Python via Java
linktitle: Hantera bläck
type: docs
weight: 95
url: /sv/python-java/manage-ink/
keywords:
- bläck
- bläckobjekt
- bläckspår
- hantera bläck
- rita bläck
- ritning
- bläckexport
- bläckrendering
- dölj bläck
- InkOptions
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Hantera PowerPoint‑bläckobjekt, redigera spår och penselns egenskaper samt kontrollera bläckens utseende vid export till PDF, HTML, SVG, TIFF och bild med Aspose.Slides för Python via Java."
---
## **Introduktion**

PowerPoint erbjuder en bläckfunktion som låter dig rita fria streck. Bläck kan användas för att markera andra objekt, visa samband och processer samt rikta uppmärksamhet mot specifika element på en bild.

Aspose.Slides tillhandahåller de typer som behövs för att arbeta med bläckobjekt. Till exempel representerar klassen [Ink](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ink/) ett bläckobjekt på en bild.

## **Skillnader mellan vanliga objekt och bläckobjekt**

Objekt på en PowerPoint-bild representeras vanligtvis av formobjekt. I sin enklaste form är en form en behållare som definierar objektets område (dess ram) tillsammans med egenskaper såsom behållarens storlek, form och bakgrund. För mer information, se [Shape Layout Format](/slides/sv/python-java/shape-manipulations/#access-layout-formats-for-shape).

Men när PowerPoint hanterar ett bläckobjekt ignorerar det alla egenskaper hos objektets ram (behållare) förutom dess storlek. Storleken på behållarområdet bestäms av de standardmetoder [Shape.getWidth](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getWidth) och [Shape.getHeight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Bläckspår**

Ett bläckspår är ett grundläggande element som används för att registrera en pensels bana när en användare skriver digitalt bläck. Ett spår lagrar en sekvens av sammankopplade punkter.

Den enklaste formen av kodning specificerar X- och Y-koordinaterna för varje sampelpunkt. När alla sammankopplade punkter renderas skapas en bild som denna:

![ink_powerpoint2](ink_powerpoint2.png)

## **Penselns egenskaper för ritning**

En pensel används för att rita linjer som förbinder punkterna i ett bläckspår. Penseln har sin egen färg och storlek, som representeras av metoderna [InkBrush.getColor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/inkbrush/#getColor) och [InkBrush.getSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/inkbrush/#getSize).

### **Ange bläckpenselns färg**

Denna Python‑kod visar hur du anger färgen på en bläckpensel:

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

### **Ange bläckpenselns storlek**

Denna Python‑kod visar hur du anger storleken på en bläckpensel:

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

Generellt matchar inte en pensels bredd och höjd, så PowerPoint visar inte penselns storlek (den motsvarande datasektionen är gråtonad). När penselns bredd och höjd matchar visar PowerPoint dess storlek på följande sätt:

![ink_powerpoint3](ink_powerpoint3.png)

För tydlighetens skull ökar vi höjden på bläckobjektet och granskar de viktiga dimensionerna:

![ink_powerpoint4](ink_powerpoint4.png)

Behållaren (ramen) tar inte hänsyn till penselns storlek – den antar alltid att linjetjockleken är noll (se föregående bild).

Därför måste penselns storlek på dess spår beaktas för att bestämma det synliga området för hela bläckobjektet. Här har målobjektet (det handskrivna textspåret) skalats till storleken på behållaren (ramen). När behållarens storlek ändras förblir penselns storlek konstant, och vice versa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint använder liknande beteende för textobjekt:

![ink_powerpoint6](ink_powerpoint6.png)

## **Styr bläckens utseende vid export och rendering**

Aspose.Slides tillhandahåller klassen [InkOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/inkoptions/) för att styra hur bläckobjekt visas i exporterad eller renderad output. Du kan använda dess egenskaper för att helt dölja bläck eller förändra hur maskoperationer för bläckpenslar tolkas.

Bläckalternativ är tillgängliga via export‑ eller renderingsalternativen för flera output‑typer:

| Output | Ink options property |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/renderingoptions/#getInkOptions) |

Följande [InkOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/inkoptions/)‑metoder exponerar samma två inställningar:

- [getHideInk](https://reference.aspose.com/slides/sv/python-java/aspose.slides/inkoptions/#getHideInk) bestämmer om bläckobjekt inkluderas i output. Standardvärdet är `False`.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) bestämmer om en maskoperation tolkas som opacitet när en bläckpensel renderas. Standardvärdet är `True`; anropa [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) med `False` för att använda ROP‑operationen istället.

### **Dölj bläckobjekt i PDF‑output**

Som standard är bläckobjekt synliga vid export. För att skapa en ren output utan handskrivna kommentarer eller annat bläckinnehåll, anropa [InkOptions.setHideInk](https://reference.aspose.com/slides/sv/python-java/aspose.slides/inkoptions/#setHideInk) med `True`.

Följande Python‑exempel exporterar en presentation till PDF samtidigt som alla bläckobjekt döljs:

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

### **Dölj bläckobjekt när en bild renderas som en bild**

För att dölja bläckobjekt när bilder renderas som bitmap‑bilder, konfigurera [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/renderingoptions/#getInkOptions) och skicka renderingsalternativen till [Slide.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage).

Följande Python‑exempel renderar den första bilden som en PNG‑bild utan bläckobjekt:

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

### **Styr rendering av bläckmask**

Inställningen [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) styr hur maskoperationer tolkas när bläckpenslar renderas. Standardvärdet är `True`, vilket använder opacitet. För att istället använda ROP‑operationen, anropa [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) med `False`.

Följande Python‑exempel exporterar en bild till SVG och använder ROP‑baserad rendering för bläckmask‑operationer:

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

Samma inställning kan tillämpas via [TiffOptions.getInkOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tiffoptions/#getInkOptions) när en presentation exporteras eller en bild renderas till TIFF.

### **Välj om du vill dölja eller bevara bläck**

När du behöver en ren version av en annoterad presentation för distribution utan granskningsmarkeringar, anropa [InkOptions.setHideInk](https://reference.aspose.com/slides/sv/python-java/aspose.slides/inkoptions/#setHideInk) med `True` vid export.

Lämna [InkOptions.getHideInk](https://reference.aspose.com/slides/sv/python-java/aspose.slides/inkoptions/#getHideInk) på standardvärdet `False` när bläckanteckningar är en del av det avsedda innehållet, såsom granskningskommentarer, handskrivna anteckningar, markeringar eller ritningar som ska förbli synliga i den exporterade resultatet. Detta gör att applikationer kan generera separata gransknings‑ och slutresultat från samma presentation utan att ändra de ursprungliga bläckobjekten.

## **FAQ**

**Kan jag ändra färg eller storlek på ett befintligt bläckstreck?**

Ja. Hämta spåret från [Ink.getTraces](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ink/#getTraces), ändra sedan dess [InkTrace.getBrush](https://reference.aspose.com/slides/sv/python-java/aspose.slides/inktrace/#getBrush). Anropa [InkBrush.setColor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/inkbrush/#setColor) eller [InkBrush.setSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/inkbrush/#setSize) för att ändra penseln.

**Påverkar dölja bläck den ursprungliga presentationen?**

Nej. Att anropa [InkOptions.setHideInk](https://reference.aspose.com/slides/sv/python-java/aspose.slides/inkoptions/#setHideInk) påverkar endast det renderade eller exporterade resultatet; det tar inte bort eller ändrar bläckobjekt i den ursprungliga presentationen.

**Vilka exportformat stöder bläckalternativ?**

Du kan konfigurera bläckalternativ för PDF, HTML, SVG, TIFF och bitmap‑bildbilder via motsvarande export‑ eller renderingsalternativ som visas ovan.

**Vidare läsning**

* För att läsa om former i allmänhet, se sektionen [PowerPoint Shapes](/slides/sv/python-java/powerpoint-shapes/).
* För mer information om effektiva värden, se [Shape Effective Properties](/slides/sv/python-java/shape-effective-properties/#get-effective-font-height-value).
* För detaljer om PDF‑export, se [Convert PPT and PPTX to PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/).
* För detaljer om HTML‑export, se [Convert PowerPoint Presentations to HTML](/slides/sv/python-java/convert-powerpoint-to-html/).
* För detaljer om SVG‑export, se [Render Presentation Slides as SVG Images](/slides/sv/python-java/render-a-slide-as-an-svg-image/).
* För detaljer om TIFF‑export, se [Convert PowerPoint Presentations to TIFF](/slides/sv/python-java/convert-powerpoint-to-tiff/).
* För detaljer om rendering av bild till bild, se [Convert Presentation Slides to Images](/slides/sv/python-java/convert-slide/).