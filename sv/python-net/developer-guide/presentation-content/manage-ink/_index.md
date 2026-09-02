---
title: Hantera presentationens bläckobjekt i Python
linktitle: Hantera bläck
type: docs
weight: 95
url: /sv/python-net/manage-ink/
keywords:
- bläck
- bläckobjekt
- bläckspår
- hantera bläck
- rita bläck
- teckning
- bläckexport
- bläckrendering
- dölj bläck
- InkOptions
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Hantera PowerPoint bläckobjekt, redigera spår och penselinställningar samt kontrollera bläckutseende vid export till PDF, HTML, SVG, TIFF och bild med Aspose.Slides för Python via .NET."
---
## **Introduktion**

PowerPoint erbjuder en bläckfunktion som låter dig rita fria streck. Bläck kan användas för att markera andra objekt, visa samband och processer samt rikta uppmärksamheten mot specifika element på en bild.

Namnområdet [aspose.slides.ink](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ink/) innehåller de klasser som behövs för att arbeta med bläckobjekt. Till exempel representerar klassen [Ink](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ink/ink/) ett bläckobjekt på en bild.

## **Skillnader mellan vanliga objekt och bläckobjekt**

Objekt på en PowerPoint‑bild representeras vanligtvis av formobjekt. I sin enklaste form är en form en behållare som definierar objektets område (dess ram) tillsammans med egenskaper såsom behållarens storlek, form och bakgrund. För mer information, se [Shape Layout Format](https://docs.aspose.com/slides/sv/python-net/shape-manipulations/#access-layout-formats-for-shape).

När PowerPoint däremot hanterar ett bläckobjekt ignoreras alla egenskaper för objektets ram (behållare) förutom dess storlek. Storleken på behållarområdet bestäms av de standardiserade egenskaperna [Ink.width](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ink/ink/width/) och [Ink.height](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ink/ink/height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Bläckspår**

Ett bläckspår är ett grundelement som används för att registrera penningens bana när en användare skriver digitalt bläck. Ett spår lagrar en sekvens av sammankopplade punkter.

Den enklaste kodningsformen specificerar X‑ och Y‑koordinaterna för varje samplingspunkt. När alla sammankopplade punkter renderas bildas en bild som denna:

![ink_powerpoint2](ink_powerpoint2.png)

## **Pensel­egenskaper för ritning**

En pensel används för att rita linjer som förbinder punkterna i ett bläckspår. Dess egenskaper [InkBrush.color](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ink/inkbrush/color/) och [InkBrush.size](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ink/inkbrush/size/) styr färg och storlek.

### **Ange bläckpenselfärg**

Denna Python‑kod visar hur du anger färgen på en bläckpensel:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **Ange bläckpenselstorlek**

Denna Python‑kod visar hur du anger storleken på en bläckpensel:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

Generellt matchar inte en pensels bredd och höjd, så PowerPoint visar inte penselns storlek (den motsvarande datasektionen är gråtonad). När penselns bredd och höjd matchar visas storleken så här:

![ink_powerpoint3](ink_powerpoint3.png)

För tydlighetens skull ökar vi höjden på bläckobjektet och granskar de viktiga dimensionerna:

![ink_powerpoint4](ink_powerpoint4.png)

Behållaren (ramen) tar inte hänsyn till penselstorleken – den antar alltid att linjetjockleken är noll (se föregående bild).

För att bestämma det synliga området för hela bläckobjektet måste penselstorleken för dess spår tas i beaktning. Här har målobjektet (spåret med handskriven text) skalats till behållarens (ramens) storlek. När behållarens storlek ändras förblir penselstorleken konstant, och vice versa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint använder liknande beteende för textobjekt:

![ink_powerpoint6](ink_powerpoint6.png)

## **Styr bläckutseende vid export och rendering**

Aspose.Slides tillhandahåller klassen [InkOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/inkoptions/) för att styra hur bläckobjekt visas i exporterade eller renderade resultat. Du kan använda dess egenskaper för att dölja bläck helt eller förändra hur bläckpenselmaskoperationer tolkas.

Bläckalternativ är tillgängliga via export‑ eller renderingsalternativ för flera utmatningstyper:

| Utdata | Ink‑alternativ egenskap |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Bild av bild | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/renderingoptions/ink_options/) |

De två samma inställningarna finns via dessa egenskaper:

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/inkoptions/hide_ink/) bestämmer om bläckobjekt ska inkluderas i utdata. Standardvärdet är `False`.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) bestämmer om en maskoperation tolkas som opacitet när en bläckpensel renderas. Standardvärdet är `True`; sätt det till `False` för att använda ROP‑operationen istället.

### **Dölj bläckobjekt i PDF‑utdata**

Som standard förblir bläckobjekt synliga vid export. Sätt [InkOptions.hide_ink](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/inkoptions/hide_ink/) till `True` när du behöver en ren utdata utan handskrivna kommentarer eller annat bläckinnehåll.

Följande Python‑exempel exporterar en presentation till PDF samtidigt som alla bläckobjekt döljs:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Dölj bläckobjekt när en bild renderas**

För att dölja bläckobjekt när bilder renderas som bitmapar, konfigurera [RenderingOptions.ink_options](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/renderingoptions/ink_options/) och skicka renderingsalternativen till metoden [Slide.get_image](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/).

Följande Python‑exempel renderar den första bilden som en PNG‑bild utan bläckobjekt:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **Styr rendering av bläckmask**

Egenskapen [InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) styr hur maskoperationer tolkas vid rendering av bläckpenslar. Standardvärdet är `True`, vilket innebär att opacitet används. Sätt egenskapen till `False` för att använda ROP‑operationen istället.

Följande Python‑exempel exporterar en bild till SVG och använder ROP‑baserad rendering för bläckmaskoperationer:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

Samma inställning kan tillämpas via [TiffOptions.ink_options](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/ink_options/) när en presentation exporteras eller en bild renderas till TIFF.

### **Välj om du vill dölja eller bevara bläck**

Sätt [InkOptions.hide_ink](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/inkoptions/hide_ink/) till `True` när den exporterade filen ska vara en ren version av en annoterad presentation, till exempel en slutkopi avsedd för distribution utan granskningsmarkeringar.

Lämna [InkOptions.hide_ink](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/inkoptions/hide_ink/) på standardvärdet `False` när bläckkommentarer är en del av det avsedda innehållet, såsom granskningskommentarer, handskrivna anteckningar, markeringar eller teckningar som ska förbli synliga i det exporterade resultatet. Detta möjliggör att applikationer kan generera separata gransknings‑ och slututdata från samma presentation utan att ändra källbläcket.

## **FAQ**

**Kan jag ändra färg eller storlek på ett befintligt bläckstreck?**

Ja. Hämta spåret från [Ink.traces](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ink/ink/traces/), och ändra sedan dess [InkTrace.brush](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ink/inktrace/brush/). Du kan sätta penselns [InkBrush.color](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ink/inkbrush/color/) och [InkBrush.size](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ink/inkbrush/size/) egenskaper.

**Ändrar dölja bläck presentationens källa?**

Nej. [InkOptions.hide_ink](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/inkoptions/hide_ink/) påverkar endast det renderade eller exporterade resultatet; det tar inte bort eller ändrar bläckobjekt i källpresentationen.

**Vilka exportformat stödjer bläckalternativ?**

Du kan konfigurera bläckalternativ för PDF, HTML, SVG, TIFF och bitmap‑bilder av bilder via de motsvarande export‑ eller renderingsalternativen som visas ovan.

**Vidare läsning**

* För att läsa om former i allmänhet, se avsnittet [PowerPoint Shapes](https://docs.aspose.com/slides/sv/python-net/powerpoint-shapes/).
* För mer information om effektiva värden, se [Shape Effective Properties](https://docs.aspose.com/slides/sv/python-net/shape-effective-properties/#get-effective-font-height-value).
* För detaljer om PDF‑export, se [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/sv/python-net/convert-powerpoint-to-pdf/).
* För detaljer om HTML‑export, se [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/sv/python-net/convert-powerpoint-to-html/).
* För detaljer om SVG‑export, se [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/sv/python-net/render-a-slide-as-an-svg-image/).
* För detaljer om TIFF‑export, se [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/sv/python-net/convert-powerpoint-to-tiff/).
* För detaljer om rendering av bild till bild, se [Convert Presentation Slides to Images](https://docs.aspose.com/slides/sv/python-net/convert-slide/).