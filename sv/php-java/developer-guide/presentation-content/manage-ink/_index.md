---
title: Hantera presentationsbläckobjekt i PHP
linktitle: Hantera bläck
type: docs
weight: 95
url: /sv/php-java/manage-ink/
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
- PHP
- Aspose.Slides
description: "Hantera PowerPoint-bläckobjekt, redigera spår och penselinställningar samt kontrollera bläckens utseende vid export till PDF, HTML, SVG, TIFF och bilder med Aspose.Slides för PHP via Java."
---
## **Introduktion**

PowerPoint erbjuder en bläckfunktion som låter dig rita fria penseldrag. Bläck kan användas för att markera andra objekt, visa samband och processer samt rikta uppmärksamheten mot specifika element på en bild.

Aspose.Slides tillhandahåller de typer som behövs för att arbeta med bläckobjekt. Till exempel representerar klassen [Ink](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ink/) ett bläckobjekt på en bild.

## **Skillnader mellan vanliga objekt och bläckobjekt**

Objekt på en PowerPoint-bild representeras vanligtvis av [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/) objekt. I sin enklaste form är en shape en behållare som definierar objektets område (dess ram) tillsammans med egenskaper som behållarens storlek, form och bakgrund. För mer information, se [Shape Layout Format](https://docs.aspose.com/slides/sv/php-java/shape-manipulations/#access-layout-formats-for-shape).

Men när PowerPoint hanterar ett bläckobjekt ignorerar det alla egenskaper för objektets ram (behållare) förutom dess storlek. Storleken på behållarområdet bestäms av de standard [Shape.getWidth](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getWidth) och [Shape.getHeight](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getHeight) metoderna:

![ink_powerpoint1](ink_powerpoint1.png)

## **Bläckspår**

Ett bläckspår är ett grundelement som används för att registrera en pennas bana när en användare skriver digitalt bläck. Ett spår lagrar en sekvens av sammanhängande punkter.

Den enklaste formen av kodning specificerar X- och Y-koordinaterna för varje samplingspunkt. När alla sammankopplade punkter renderas får man en bild som denna:

![ink_powerpoint2](ink_powerpoint2.png)

## **Penselinställningar för ritning**

En pensel används för att rita linjer som förbinder punkterna i ett bläckspår. Penseln har sin egen färg och storlek, representerade av metoderna [InkBrush.getColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/inkbrush/#getColor) och [InkBrush.getSize](https://reference.aspose.com/slides/sv/php-java/aspose.slides/inkbrush/#getSize).

### **Ange bläckpenselns färg**

Denna PHP‑kod visar hur man sätter färgen på en bläckpensel:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **Ange bläckpenselns storlek**

Denna PHP‑kod visar hur man sätter storleken på en bläckpensel:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

Generellt sett matchar inte penselns bredd och höjd, så PowerPoint visar inte penselns storlek (den motsvarande datasektionen är gråmarkerad). När penselns bredd och höjd matchar visar PowerPoint dess storlek på följande sätt:

![ink_powerpoint3](ink_powerpoint3.png)

För tydlighetens skull ökar vi höjden på bläckobjektet och granskar de viktiga dimensionerna:

![ink_powerpoint4](ink_powerpoint4.png)

Behållaren (ramen) tar inte hänsyn till penselns storlek – den antar alltid att linjetjockleken är noll (se föregående bild).

Därför måste penselns storlek på dess spår beaktas för att bestämma det synliga området för hela bläckobjektet. Här har målobjektet (det handskrivna textspåret) skalats till storleken på behållaren (ramen). När behållarens storlek ändras förblir penselns storlek konstant, och vice versa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint använder liknande beteende för textobjekt:

![ink_powerpoint6](ink_powerpoint6.png)

## **Styr bläckens utseende vid export och rendering**

Aspose.Slides tillhandahåller klassen [InkOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/inkoptions/) för att styra hur bläckobjekt visas i exporterad eller renderad output. Du kan använda dess egenskaper för att dölja bläck helt eller ändra hur maskoperationer för bläckpenslar tolkas.

Bläckalternativ är tillgängliga via export- eller renderingsalternativen för flera output‑typer:

| Utdata | Ink‑alternativ egenskap |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/renderingoptions/#getInkOptions) |

Följande [InkOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/inkoptions/) metoder exponerar samma två inställningar:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/sv/php-java/aspose.slides/inkoptions/#getHideInk) avgör om bläckobjekt inkluderas i output. Dess standardvärde är `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) avgör om en maskoperation tolkas som opacitet när en bläckpensel renderas. Dess standardvärde är `true`; anropa [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) med `false` för att använda ROP‑operationen istället.

### **Dölj bläckobjekt i PDF‑output**

Som standard förblir bläckobjekt synliga vid export. För att skapa en ren output utan handskrivna kommentarer eller annat bläckinnehåll, anropa [InkOptions.setHideInk](https://reference.aspose.com/slides/sv/php-java/aspose.slides/inkoptions/#setHideInk) med `true`.

Följande PHP‑exempel exporterar en presentation till PDF samtidigt som alla bläckobjekt döljs:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Dölj bläckobjekt när en bildruta renderas som bild**

För att dölja bläckobjekt när bildspel renderas som bitmap‑bilder, konfigurera [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/renderingoptions/#getInkOptions) och skicka renderingsalternativen till [Slide.getImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getImage).

Följande PHP‑exempel renderar den första bilden som en PNG‑bild utan bläckobjekt:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **Styr rendering av bläckmask**

[InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity)‑inställningen styr hur maskoperationer tolkas när bläckpenslar renderas. Standardvärdet är `true`, vilket använder opacitet. För att använda ROP‑operationen istället, anropa [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) med `false`.

Följande PHP‑exempel exporterar en bild till SVG och använder ROP‑baserad rendering för bläckmask‑operationer:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Samma inställning kan tillämpas via [TiffOptions.getInkOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/#getInkOptions) när en presentation exporteras eller en bild renderas till TIFF.

### **Välj om du vill dölja eller bevara bläck**

När du behöver en ren version av en annoterad presentation för distribution utan granskningsmarkeringar, anropa [InkOptions.setHideInk](https://reference.aspose.com/slides/sv/php-java/aspose.slides/inkoptions/#setHideInk) med `true` vid export.

Lämna [InkOptions.getHideInk](https://reference.aspose.com/slides/sv/php-java/aspose.slides/inkoptions/#getHideInk) på standardvärdet `false` när bläckanteckningar är en del av det avsedda innehållet, såsom granskningskommentarer, handskrivna noteringar, markeringar eller teckningar som ska förbli synliga i den exporterade resultatet. Detta möjliggör att applikationer kan generera separata gransknings‑ och slutresultat från samma presentation utan att ändra bläckobjekten i källfilen.

## **Vanliga frågor**

**Kan jag ändra färg eller storlek på ett befintligt bläckstreck?**

Ja. Hämta spåret från [Ink.getTraces](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ink/#getTraces) och ändra sedan dess [InkTrace.getBrush](https://reference.aspose.com/slides/sv/php-java/aspose.slides/inktrace/#getBrush). Anropa [InkBrush.setColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/inkbrush/#setColor) eller [InkBrush.setSize](https://reference.aspose.com/slides/sv/php-java/aspose.slides/inkbrush/#setSize) för att ändra penseln.

**Är det så att dölja bläck ändrar källpresentationen?**

Nej. Att anropa [InkOptions.setHideInk](https://reference.aspose.com/slides/sv/php-java/aspose.slides/inkoptions/#setHideInk) påverkar endast det renderade eller exporterade resultatet; det tar inte bort eller modifierar bläckobjekt i källpresentationen.

**Vilka exportformat stödjer bläckalternativ?**

Du kan konfigurera bläckalternativ för PDF, HTML, SVG, TIFF och bitmap‑bilder av bildspel via motsvarande export‑ eller renderingsalternativ som visas ovan.

**Vidare läsning**

* Läs mer om former i allmänhet i avsnittet [PowerPoint Shapes](https://docs.aspose.com/slides/sv/php-java/powerpoint-shapes/).
* För mer information om effektiva värden, se [Shape Effective Properties](https://docs.aspose.com/slides/sv/php-java/shape-effective-properties/#get-effective-font-height-value).
* För detaljer om PDF‑export, se [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/sv/php-java/convert-powerpoint-to-pdf/).
* För detaljer om HTML‑export, se [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/sv/php-java/convert-powerpoint-to-html/).
* För detaljer om SVG‑export, se [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/sv/php-java/render-a-slide-as-an-svg-image/).
* För detaljer om TIFF‑export, se [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/sv/php-java/convert-powerpoint-to-tiff/).
* För detaljer om rendering av bild till bild, se [Convert Presentation Slides to Images](https://docs.aspose.com/slides/sv/php-java/convert-slide/).