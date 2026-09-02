---
title: Hantera presentationsbläckobjekt i .NET
linktitle: Hantera bläck
type: docs
weight: 95
url: /sv/net/manage-ink/
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
- IInkOptions
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera PowerPoint-bläckobjekt, redigera spår och pensel-egenskaper samt kontrollera bläckets utseende vid export till PDF, HTML, SVG, TIFF och bild med Aspose.Slides för .NET."
---
## **Introduktion**

PowerPoint erbjuder en bläckfunktion som låter dig rita fria penseldrag. Bläck kan användas för att markera andra objekt, visa samband och processer samt rikta uppmärksamhet mot specifika element på en bild.

Namnutrymmet [Aspose.Slides.Ink](https://reference.aspose.com/slides/sv/net/aspose.slides.ink/) innehåller de klasser och gränssnitt som behövs för att arbeta med bläckobjekt. Till exempel representerar gränssnittet [IInk](https://reference.aspose.com/slides/sv/net/aspose.slides.ink/iink/) ett bläckobjekt på en bild.

## **Skillnader mellan vanliga objekt och bläckobjekt**

Objekt på en PowerPoint‑bild representeras vanligtvis av formobjekt. I sin enklaste form är en form en behållare som definierar objektets område (dess ram) samt egenskaper såsom behållarens storlek, form och bakgrund. För mer information, se [Formlayoutformat](https://docs.aspose.com/slides/sv/net/shape-manipulations/#access-layout-formats-for-shape).

När PowerPoint däremot hanterar ett bläckobjekt ignorerar det alla egenskaper för objektets ram (behållare) förutom dess storlek. Storleken på behållarområdet bestäms av de standardegenskaper [IShape.Width](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/width/) och [IShape.Height](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/height/) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Bläckspår**

Ett bläckspår är ett grundelement som används för att registrera en pensels bana när en användare skriver digitalt bläck. Ett spår lagrar en sekvens av sammankopplade punkter.

Den enklaste kodningsformen specificerar X‑ och Y‑koordinaterna för varje provpunkt. När alla sammankopplade punkter renderas får man en bild som denna:

![ink_powerpoint2](ink_powerpoint2.png)

## **Penselattribut för ritning**

En pensel används för att rita linjer som förbinder punkterna i ett bläckspår. Penseln har sin egen färg och storlek, representerade av egenskaperna [IInkBrush.Color](https://reference.aspose.com/slides/sv/net/aspose.slides.ink/iinkbrush/color/) och [IInkBrush.Size](https://reference.aspose.com/slides/sv/net/aspose.slides.ink/iinkbrush/size/).

### **Ange bläckpenselfärg**

Den här C#‑koden visar hur du anger färgen på en bläckpensel:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **Ange bläckpenselstorlek**

Den här C#‑koden visar hur du anger storleken på en bläckpensel:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

Generellt matchar en pensels bredd och höjd inte, så PowerPoint visar inte penselns storlek (det motsvarande datasegmentet är grått). När penselns bredd och höjd matchar visar PowerPoint dess storlek på följande sätt:

![ink_powerpoint3](ink_powerpoint3.png)

För tydlighetens skull ökar vi höjden på bläckobjektet och granskar de viktiga dimensionerna:

![ink_powerpoint4](ink_powerpoint4.png)

Behållaren (ramen) tar inte hänsyn till penslarnas storlek – den antar alltid att linjetjockleken är noll (se föregående bild).

Därför måste penselstorleken för dess spår beaktas för att bestämma det synliga området för hela bläckobjektet. Här har målobjektet (det handskrivna textspåret) skalats till behållarens (ramens) storlek. När behållarens storlek förändras förblir penselstorleken konstant, och vice versa.

PowerPoint använder liknande beteende för textobjekt:

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint använder liknande beteende för textobjekt:

![ink_powerpoint6](ink_powerpoint6.png)

## **Styr bläckutseende vid export och rendering**

Aspose.Slides tillhandahåller gränssnittet [IInkOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/iinkoptions/) för att styra hur bläckobjekt visas i exporterad eller renderad output. Du kan använda dess egenskaper för att dölja bläck helt eller ändra hur maskoperationer för bläckpenslar tolkas.

Bläckalternativ är tillgängliga via export‑ eller renderingsalternativen för flera utdataformat:

| Utdata | Ink‑alternativ egenskap |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/sv/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/inkoptions/) |
| Slide image | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/sv/net/aspose.slides.export/renderingoptions/inkoptions/) |

Samma två inställningar finns tillgängliga via dessa egenskaper:

- [`HideInk`](https://reference.aspose.com/slides/sv/net/aspose.slides.export/iinkoptions/hideink/) avgör om bläckobjekt inkluderas i outputen. Standardvärdet är `false`.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/sv/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) avgör om en maskoperation tolkas som opacitet när en bläckpensel renderas. Standardvärdet är `true`; sätt den till `false` för att använda ROP‑operationen istället.

### **Dölj bläckobjekt i PDF‑utdata**

Som standard är bläckobjekt synliga under export. Ställ in [IInkOptions.HideInk](https://reference.aspose.com/slides/sv/net/aspose.slides.export/iinkoptions/hideink/) till `true` när du behöver en ren utdata utan handskrivna anteckningar eller annat bläckinnehåll.

Följande C#‑exempel exporterar en presentation till PDF samtidigt som alla bläckobjekt döljs:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Dölj bläckobjekt när en bild renderas som en bild**

För att dölja bläckobjekt när bilder renderas som bitmap‑bilder, konfigurera [RenderingOptions.InkOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/renderingoptions/inkoptions/) och skicka renderingsalternativen till metoden [ISlide.GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/getimage/).

Följande C#‑exempel renderar den första bilden som en PNG‑bild utan bläckobjekt:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **Styr rendering av bläckmask**

Egenskapen [IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) styr hur maskoperationer tolkas när bläckpenslar renderas. Standardvärdet är `true`, vilket använder opacitet. Sätt egenskapen till `false` för att istället använda ROP‑operationen.

Följande C#‑exempel exporterar en bild till SVG och använder ROP‑baserad rendering för bläckmaskoperationer:

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

Samma inställning kan tillämpas via [TiffOptions.InkOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/inkoptions/) när en presentation exporteras eller en bild renderas till TIFF.

### **Välj om du vill dölja eller bevara bläck**

Använd [IInkOptions.HideInk](https://reference.aspose.com/slides/sv/net/aspose.slides.export/iinkoptions/hideink/) med värdet `true` när den exporterade filen ska vara en ren version av en annoterad presentation, t.ex. en slutgiltig kopia avsedd för distribution utan granskningsmarkeringar.

Låt [IInkOptions.HideInk](https://reference.aspose.com/slides/sv/net/aspose.slides.export/iinkoptions/hideink/) behålla standardvärdet `false` när bläckanteckningar är en del av det avsedda innehållet, såsom granskningskommentarer, handskrivna noteringar, markeringar eller teckningar som ska förbli synliga i exportresultatet. Detta möjliggör att applikationer kan generera separata gransknings‑ och slututdata från samma presentation utan att ändra källbläckobjekten.

## **FAQ**

**Kan jag ändra färgen eller storleken på ett befintligt bläcksteg?**

Ja. Hämta spåret från [IInk.Traces](https://reference.aspose.com/slides/sv/net/aspose.slides.ink/iink/traces/), ändra sedan dess [IInkTrace.Brush](https://reference.aspose.com/slides/sv/net/aspose.slides.ink/iinktrace/brush/). Du kan ange penselns [IInkBrush.Color](https://reference.aspose.com/slides/sv/net/aspose.slides.ink/iinkbrush/color/) och [IInkBrush.Size](https://reference.aspose.com/slides/sv/net/aspose.slides.ink/iinkbrush/size/) egenskaper.

**Ändrar dölja bläck den ursprungliga presentationen?**

Nej. [IInkOptions.HideInk](https://reference.aspose.com/slides/sv/net/aspose.slides.export/iinkoptions/hideink/) påverkar endast det renderade eller exporterade resultatet; den tar inte bort eller ändrar bläckobjekt i källpresentationen.

**Vilka exportformat stödjer bläckalternativ?**

Du kan konfigurera bläckalternativ för PDF, HTML, SVG, TIFF och bitmap‑bilder av bilder via motsvarande export‑ eller renderingsalternativ som visas ovan.

**Vidare läsning**

* För allmän information om former, se avsnittet [PowerPoint‑former](https://docs.aspose.com/slides/sv/net/powerpoint-shapes/).
* För mer information om effektiva värden, se [Formens effektiva egenskaper](https://docs.aspose.com/slides/sv/net/shape-effective-properties/#get-effective-font-height-value).
* För detaljer om PDF‑export, se [Konvertera PPT och PPTX till PDF](https://docs.aspose.com/slides/sv/net/convert-powerpoint-to-pdf/).
* För detaljer om HTML‑export, se [Konvertera PowerPoint‑presentationer till HTML](https://docs.aspose.com/slides/sv/net/convert-powerpoint-to-html/).
* För detaljer om SVG‑export, se [Rendera presentationsbilder som SVG‑bilder](https://docs.aspose.com/slides/sv/net/render-a-slide-as-an-svg-image/).
* För detaljer om TIFF‑export, se [Konvertera PowerPoint‑presentationer till TIFF](https://docs.aspose.com/slides/sv/net/convert-powerpoint-to-tiff/).
* För detaljer om rendering av bild till bild, se [Konvertera presentationsbilder till bilder](https://docs.aspose.com/slides/sv/net/convert-slide/).