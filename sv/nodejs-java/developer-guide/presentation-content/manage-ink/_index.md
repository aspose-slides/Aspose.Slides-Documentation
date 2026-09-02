---
title: "Hantera presentationsinkobjekt i JavaScript"
linktitle: "Hantera ink"
type: docs
weight: 95
url: /sv/nodejs-java/manage-ink/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera PowerPoint-inkobjekt, redigera spår och penselinställningar, samt kontrollera bläckens utseende vid PDF-, HTML-, SVG-, TIFF- och bildexport med Aspose.Slides för Node.js via Java."
---
## **Introduktion**

PowerPoint innehåller en bläckfunktion som låter dig rita fria penseldrag. Bläck kan användas för att framhäva andra objekt, visa kopplingar och processer samt rikta uppmärksamhet mot specifika element på en bild.

Aspose.Slides tillhandahåller de typer som behövs för att arbeta med bläckobjekt. Till exempel representerar klassen [Ink](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ink/) ett bläckobjekt på en bild.

## **Skillnader mellan vanliga objekt och bläckobjekt**

Objekt på en PowerPoint‑bild representeras vanligtvis av formobjekt. I sin enklaste form är en form en behållare som definierar objektets område (dess ram) tillsammans med egenskaper som behållarens storlek, form och bakgrund. För mer information, se [Shape Layout Format](https://docs.aspose.com/slides/sv/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

När PowerPoint däremot hanterar ett bläckobjekt ignorerar det alla egenskaper för objektets ram (behållare) förutom dess storlek. Storleken på behållarområdet bestäms av de standardmetoder [Shape.getWidth](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getWidth--) och [Shape.getHeight](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getHeight--) .
![ink_powerpoint1](ink_powerpoint1.png)

## **Bläckspår**

Ett bläckspår är ett grundelement som används för att registrera en pennas bana när en användare skriver digitalt bläck. Ett spår lagrar en sekvens av sammankopplade punkter.

Den enklaste formen av kodning anger X‑ och Y‑koordinaterna för varje sampelpunk. När alla anslutna punkter renderas får man en bild som denna:
![ink_powerpoint2](ink_powerpoint2.png)

## **Pensel egenskaper för ritning**

En pensel används för att rita linjer som kopplar ihop punkterna i ett bläckspår. Penseln har sin egen färg och storlek, representerade av metoderna [InkBrush.getColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/inkbrush/#getColor--) och [InkBrush.getSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/inkbrush/#getSize--).

### **Ange bläckpenselns färg**

Denna JavaScript‑kod visar hur du anger färgen på en bläckpensel:
```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **Ange bläckpenselns storlek**

Denna JavaScript‑kod visar hur du anger storleken på en bläckpensel:
```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Vanligtvis matchar inte en pensels bredd och höjd, så PowerPoint visar inte penselns storlek (den motsvarande datasektionen är grå markerad). När penselns bredd och höjd matchar visar PowerPoint storleken på följande sätt:
![ink_powerpoint3](ink_powerpoint3.png)

För tydlighetens skull, låt oss öka höjden på bläckobjektet och granska de viktiga dimensionerna:
![ink_powerpoint4](ink_powerpoint4.png)

Behållaren (ramen) tar inte hänsyn till penslarnas storlek – den antar alltid att linjetjockleken är noll (se föregående bild).

Därför måste penselns storlek för dess spår tas med i beräkningen för att avgöra det synliga området för hela bläckobjektet. Här har målobjektet (det handskrivna textspåret) skalats till behållarens (ramens) storlek. När behållarens storlek ändras förblir penselns storlek konstant, och tvärtom.
![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint använder liknande beteende för textobjekt:
![ink_powerpoint6](ink_powerpoint6.png)

## **Styr bläckens utseende vid export och rendering**

Aspose.Slides tillhandahåller klassen [InkOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/inkoptions/) för att styra hur bläckobjekt visas i exporterat eller renderat resultat. Du kan använda dess egenskaper för att dölja bläck helt eller ändra hur maskoperationer för bläckpenslar tolkas.

Bläckalternativ finns tillgängliga via export‑ eller renderingsalternativen för flera utmatningstyper:

| Utdata | Egenskap för bläckalternativ |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

Följande [InkOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/inkoptions/)‑metoder visar samma två inställningar:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/inkoptions/#getHideInk--) bestämmer om bläckobjekt inkluderas i resultatet. Standardvärdet är `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) bestämmer om en maskoperation tolkas som opacitet vid rendering av en bläckpensel. Standardvärdet är `true`; anropa [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) med `false` för att använda ROP‑operationen istället.

### **Dölj bläckobjekt i PDF‑utdata**

Som standard förblir bläckobjekt synliga vid export. För att skapa en ren utdata utan handskrivna kommentarer eller annat bläckinnehåll, anropa [InkOptions.setHideInk](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) med `true`.

Följande JavaScript‑exempel exporterar en presentation till PDF samtidigt som alla bläckobjekt döljs:
```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Dölj bläckobjekt vid rendering av en bild som bild**

För att dölja bläckobjekt när du renderar bilder som bitmap‑bilder, konfigurera [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) och skicka renderingsalternativen till [Slide.getImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-).

Följande JavaScript‑exempel renderar den första bilden som en PNG‑bild utan bläckobjekt:
```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Styr rendering av bläckmask**

[InkOptions.getInterpretMaskOpAsOpacity]‑inställningen styr hur maskoperationer tolkas vid rendering av bläckpenslar. Standardvärdet är `true`, vilket använder opacitet. För att använda ROP‑operationen istället, anropa [InkOptions.setInterpretMaskOpAsOpacity] med `false`.

Följande JavaScript‑exempel exporterar en bild till SVG och använder ROP‑baserad rendering för bläckmaskoperationer:
```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

Samma inställning kan tillämpas via [TiffOptions.getInkOptions] när du exporterar en presentation eller renderar en bild till TIFF.

### **Välj om du vill dölja eller bevara bläck**

När du behöver en ren version av en kommenterad presentation för distribution utan granskningsmarkeringar, anropa [InkOptions.setHideInk](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) med `true` vid export.

Lämna [InkOptions.getHideInk] på standardvärdet `false` när bläckanteckningar är en del av det avsedda innehållet, exempelvis granskningskommentarer, handskrivna anteckningar, markeringar eller teckningar som ska förbli synliga i det exporterade resultatet. Detta gör att program kan generera separata gransknings‑ och slututdata från samma presentation utan att ändra de ursprungliga bläckobjekten.

## **FAQ**

**Kan jag ändra färg eller storlek på ett befintligt bläcksteg?**

Ja. Hämta spåret från [Ink.getTraces](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ink/#getTraces--) och ändra sedan dess [InkTrace.getBrush](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/inktrace/#getBrush--). Anropa [InkBrush.setColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) eller [InkBrush.setSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) för att ändra penseln.

**Är det så att dölja bläck ändrar källpresentationen?**

Nej. Att anropa [InkOptions.setHideInk](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) påverkar endast det renderade eller exporterade resultatet; det tar inte bort eller ändrar bläckobjekt i källpresentationen.

**Vilka exportformat stödjer bläckalternativ?**

Du kan konfigurera bläckalternativ för PDF, HTML, SVG, TIFF och bitmap‑bilder av bilder via de motsvarande export‑ eller renderingsalternativen som visas ovan.

**Ytterligare läsning**

* För att läsa om former i allmänhet, se avsnittet [PowerPoint Shapes](https://docs.aspose.com/slides/sv/nodejs-java/powerpoint-shapes/).
* För mer information om effektiva värden, se [Shape Effective Properties](https://docs.aspose.com/slides/sv/nodejs-java/shape-effective-properties/#get-effective-font-height-value).
* För detaljer om PDF‑export, se [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/sv/nodejs-java/convert-powerpoint-to-pdf/).
* För detaljer om HTML‑export, se [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/sv/nodejs-java/convert-powerpoint-to-html/).
* För detaljer om SVG‑export, se [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/sv/nodejs-java/render-a-slide-as-an-svg-image/).
* För detaljer om TIFF‑export, se [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/sv/nodejs-java/convert-powerpoint-to-tiff/).
* För detaljer om rendering av bild till bild, se [Convert Presentation Slides to Images](https://docs.aspose.com/slides/sv/nodejs-java/convert-slide/).