---
title: Hantera PowerPoint‑bläckobjekt i Java
linktitle: Hantera bläck
type: docs
weight: 95
url: /sv/java/manage-ink/
keywords:
- bläck
- bläckobjekt
- bläckspår
- hantera bläck
- rita bläck
- ritning
- bläckexport
- bläkrendering
- dölj bläck
- IInkOptions
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Hantera PowerPoint‑bläckobjekt, redigera spår och pensel­egenskaper, samt kontrollera bläckens utseende vid PDF‑, HTML‑, SVG‑, TIFF‑ och bildexport med Aspose.Slides för Java."
---
## **Introduktion**

PowerPoint har en bläckfunktion som låter dig rita fria penseldrag. Bläck kan användas för att markera andra objekt, visa kopplingar och processer samt dra uppmärksamhet till specifika element på en bild.

Aspose.Slides tillhandahåller de typer som behövs för att arbeta med bläckobjekt. Till exempel representerar gränssnittet [IInk](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iink/) ett bläckobjekt på en bild.

## **Skillnader mellan vanliga objekt och bläckobjekt**

Objekt på en PowerPoint‑bild representeras vanligtvis av formobjekt. I sin enklaste form är en form en behållare som definierar objektets område (dess ram) samt egenskaper som behållarens storlek, form och bakgrund. För mer information, se [Formlayoutformat](https://docs.aspose.com/slides/sv/java/shape-manipulations/#access-layout-formats-for-shape).

När PowerPoint hanterar ett bläckobjekt ignoreras dock alla egenskaper för objektets ram (behållare) förutom dess storlek. Storleken på behållarområdet bestäms av de standardmetoderna [IShape.getWidth](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getWidth--) och [IShape.getHeight](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Bläckspår**

Ett bläckspår är ett grundläggande element som används för att registrera en pennas bana när en användare skriver digitalt bläck. Ett spår lagrar en sekvens av sammankopplade punkter.

Den enklaste formen av kodning specificerar X‑ och Y‑koordinaterna för varje provpunkt. När alla sammankopplade punkter renderas, bildas en bild som denna:

![ink_powerpoint2](ink_powerpoint2.png)

## **Pensel‑egenskaper för ritning**

En pensel används för att rita linjer som förbinder punkterna i ett bläckspår. Penseln har sin egen färg och storlek, representerade av metoderna [IInkBrush.getColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinkbrush/#getColor--) och [IInkBrush.getSize](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinkbrush/#getSize--) .

### **Ställ in bläckpenselfärg**

Denna Java‑kod visar hur man ställer in färgen på en bläckpensel:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **Ställ in bläckpenselstorlek**

Denna Java‑kod visar hur man ställer in storleken på en bläckpensel:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Generellt matchar en pensels bredd och höjd inte, så PowerPoint visar inte penselns storlek (den motsvarande datasektionen är gråtonad). När penselns bredd och höjd matchar visar PowerPoint dess storlek på följande sätt:

![ink_powerpoint3](ink_powerpoint3.png)

För tydlighetens skull, låt oss öka höjden på bläckobjektet och granska de viktiga dimensionerna:

![ink_powerpoint4](ink_powerpoint4.png)

Behållaren (ramen) tar inte hänsyn till penselns storlek – den antar alltid att linjetjockleken är noll (se föregående bild).

Därför måste penselns storlek för dess spår beaktas för att bestämma det synliga området för hela bläckobjektet. Här har målobjektet (det handskrivna textspåret) skalats till behållarens (ramens) storlek. När behållarens storlek ändras förblir penselns storlek konstant, och vice versa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint använder liknande beteende för textobjekt:

![ink_powerpoint6](ink_powerpoint6.png)

## **Styr bläckens utseende vid export och rendering**

Aspose.Slides tillhandahåller gränssnittet [IInkOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinkoptions/) för att kontrollera hur bläckobjekt visas i exporterad eller renderad output. Du kan använda dess egenskaper för att dölja bläck helt eller ändra hur maskoperationer för bläckpenslar tolkas.

Bläckalternativ är tillgängliga via export‑ eller renderingsalternativ för flera output‑typer:

| Utdata | Ink‑alternativ egenskap |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/sv/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/sv/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/sv/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/sv/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

Följande [IInkOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinkoptions/)‑metoder exponerar samma två inställningar:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinkoptions/#getHideInk--) avgör om bläckobjekt inkluderas i outputen. Standardvärdet är `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) avgör om en maskoperation tolkas som opacitet när en bläckpensel renderas. Standardvärdet är `true`; anropa [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) med `false` för att använda ROP‑operationen istället.

### **Dölj bläckobjekt i PDF‑utdata**

Som standard förblir bläckobjekt synliga vid export. För att skapa en ren output utan handskrivna kommentarer eller annat bläckinnehåll, anropa [IInkOptions.setHideInk](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) med `true`.

Följande Java‑exempel exporterar en presentation till PDF samtidigt som alla bläckobjekt döljs:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Dölj bläckobjekt vid rendering av en bild som bild**

För att dölja bläckobjekt vid rendering av bilder som bitmap‑bilder, konfigurera [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/renderingoptions/#getInkOptions--) och skicka renderingsalternativen till [ISlide.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

Följande Java‑exempel renderar den första bilden som en PNG‑bild utan bläckobjekt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Styr rendering av bläckmask**

[IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--)‑inställningen styr hur maskoperationer tolkas när bläckpenslar renderas. Standardvärdet är `true`, vilket använder opacitet. För att använda ROP‑operationen istället, anropa [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) med `false`.

Följande Java‑exempel exporterar en bild till SVG och använder ROP‑baserad rendering för bläckmask‑operationer:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

Samma inställning kan tillämpas via [TiffOptions.getInkOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/tiffoptions/#getInkOptions--) vid export av en presentation eller rendering av en bild till TIFF.

### **Välj om du vill dölja eller bevara bläck**

När du behöver en ren version av en annoterad presentation för distribution utan granskningsmarkeringar, anropa [IInkOptions.setHideInk](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) med `true` under export.

Lämna [IInkOptions.getHideInk](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinkoptions/#getHideInk--) på standardvärdet `false` när bläckkommentarer är en del av det avsedda innehållet, såsom granskningskommentarer, handskrivna anteckningar, markeringar eller teckningar som ska förbli synliga i den exporterade resultatet. Detta gör att applikationer kan generera separata gransknings‑ och slutresultat från samma presentation utan att ändra käll‑bläckobjekten.

## **Vanliga frågor**

**Kan jag ändra färg eller storlek på ett befintligt bläckstreck?**

Ja. Hämta spåret från [IInk.getTraces](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iink/#getTraces--) och ändra sedan dess [IInkTrace.getBrush](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinktrace/#getBrush--). Anropa [IInkBrush.setColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-) eller [IInkBrush.setSize](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) för att ändra penseln.

**Påverkar dölja bläck källpresentationen?**

Nej. Att anropa [IInkOptions.setHideInk](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) påverkar endast den renderade eller exporterade resultatet; det tar inte bort eller modifierar bläckobjekt i källpresentationen.

**Vilka exportformat stöder bläckalternativ?**

Du kan konfigurera bläckalternativ för PDF, HTML, SVG, TIFF och bitmap‑bildbilder av bilder via motsvarande export‑ eller renderingsalternativ som visas ovan.

**Vidare läsning**

* För att läsa om former i allmänhet, se avsnittet [PowerPoint Shapes](https://docs.aspose.com/slides/sv/java/powerpoint-shapes/).
* För mer information om effektiva värden, se [Shape Effective Properties](https://docs.aspose.com/slides/sv/java/shape-effective-properties/#get-effective-font-height-value).
* För detaljer om PDF‑export, se [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/sv/java/convert-powerpoint-to-pdf/).
* För detaljer om HTML‑export, se [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/sv/java/convert-powerpoint-to-html/).
* För detaljer om SVG‑export, se [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/sv/java/render-a-slide-as-an-svg-image/).
* För detaljer om TIFF‑export, se [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/sv/java/convert-powerpoint-to-tiff/).
* För detaljer om rendering av bild till bild, se [Convert Presentation Slides to Images](https://docs.aspose.com/slides/sv/java/convert-slide/).