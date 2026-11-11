---
title: Rendera presentationsbilder som SVG-bilder i Java
linktitle: Bild till SVG
type: docs
weight: 50
url: /sv/java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint till SVG
- presentation till SVG
- bild till SVG
- PPT till SVG
- PPTX till SVG
- SVG-exportalternativ
- interaktiv SVG
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Exportera PowerPoint-bilder som SVG-bilder i Java och kontrollera typsnitt, text, bilder, ID:n och händelser med Aspose.Slides."
---
## **Översikt**

SVG är ett skalbart XML-baserat bildformat som fungerar bra för webpublicering, bildspelsvisare, tillgänglighetsarbetsflöden och automatiserad efterbehandling. Aspose.Slides exporterar varje bild till en separat SVG‑fil och låter dig styra hur text, typsnitt, bilder och SVG‑element skrivs.

Använd [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) när den exporterade SVG‑filen måste vara kompakt, förutsägbar i olika webbläsare eller klar för interaktiv användning.

## **Exportera en bild som SVG**

Skapa en [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), välj en bild och skriv den till en ström med [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Följande exempel exporterar varje bild i en presentation som en separat SVG‑fil.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

Filnamnet använder [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) istället för loop‑indexet. Du kan även exportera en enskild form med [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) när en bildvisare eller webbsida bara behöver den formen.

## **Konfigurera SVG‑utdata**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) styr SVG‑renderingen. För textramar inkluderar [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) textram i renderingsområdet, och [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) bestämmer om ramrotationen tillämpas. Ställ in [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) till `true` när text måste renderas utan ligaturer.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Kontrollera beskärning av linjeändar vid pilspetsar**

SVG 1.1 har ingen inställning för markörinräkning som anger var en linje ska sluta under en pilspets. Som standard förkortar Aspose.Slides den exporterade linjen så att dess streck inte sticker igenom markören. Anropa [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) med `true` för att rita strecket hela vägen till linjens ursprungliga slutpunkt. Denna inställning påverkar endast SVG‑utdata. Linjen behåller sin position och längd på bilden.

Exemplet ritar triangel‑ och diamantpilspetsar på linjer med bredden 2 respektive 10 punkter. Det exporterar samma bild två gånger och ändrar endast beskärningsalternativet.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    int y = 40;
    
    for (byte style : new byte[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond }) {
        for (int width : new int[] { 2, 10 }) {
            IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0);
            ILineFormat format = line.getLineFormat();
            format.getFillFormat().setFillType(FillType.Solid);
            format.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
            format.setWidth(width);
            format.setEndArrowheadStyle(style);
            y += 50;
        }
    }

    SVGOptions options = new SVGOptions();
    options.setDisableLineEndCropping(false);
    try (FileOutputStream cropped = new FileOutputStream("cropped.svg")) {
        slide.writeAsSvg(cropped, options);
    }

    options.setDisableLineEndCropping(true);
    try (FileOutputStream uncropped = new FileOutputStream("uncropped.svg")) {
        slide.writeAsSvg(uncropped, options);
    }
} finally {
    presentation.dispose();
}
```

Jämförelsen visar den triangulära pilspetsen på 10‑punktslinjen. Med beskärning aktiverad är spetsen skarp. Med beskärning inaktiverad sticker strecket igenom de sluttande sidorna av markören och lämnar ett plant slut.

![Uppskalad 10‑punkts triangel med en skarp spets när beskärning är aktiverad och ett plant slut när beskärning är inaktiverad](line-end-cropping.png)

I de andra linjerna i exemplet är det utskjutande strecket mindre synligt på 2‑punkts triangeln. Den fyllda diamanten täcker streckets slut på båda breddarna.

## **Styr text och typsnitt**

När du exporterar bilder till SVG kan du kontrollera om text förblir som text eller konverteras till vektorgrafik, samt hur externa typsnitt inkluderas eller refereras. Följande alternativ hjälper dig att balansera visuell konsistens, textval och typsnittsberoenden i den exporterade SVG:n.

### **Vektorisera all text**

Ställ in [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) till `true` för att skriva all bildtext som vektorgrafik. Detta eliminerar typsnittsberoenden och gör det visuella resultatet mer enhetligt i olika webbläsare, men texten blir inte längre markerbar eller sökbar som SVG‑text.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **Välj hur externa typsnitt hanteras**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) använder ett [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)‑värde för typsnitt som laddas externt. Välj `AddLinksToFontFiles` för att referera separata typsnittsfiler, `Embed` för att inkludera typsnittsdata i SVG:n, eller `Vectorize` för att rendera endast text som använder externa typsnitt som grafik. Verifiera typsnittslicenser innan du bäddar in typsnitt.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Minska storlek på inbäddade bilder**

Använd [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) för att minska upplösningen på inbäddade bilder, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) för att utelämna beskurna källområden, och [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) för att kontrollera JPEG‑kodningskvalitet. Dessa inställningar minskar filstorleken på bekostnad av bildkvalitet eller bevarad bilddata.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Styr rasteriseringsupplösning för metafil**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) anger den lägre upplösningsgränsen för rasterisering av metafiler under SVG‑export. Använd den för att balansera detaljrikedom och filstorlek när en EMF‑ eller WMF‑bild rasteriseras. Den definierar inte ett globalt DPI för SVG:n eller tvingar varje objekt på bilden att bli en rasterbild.

Ladda ner [metafile-rasterization.pptx](metafile-rasterization.pptx), som innehåller en EMF‑bild med tätt placerade diagonala linjer. Följande exempel exporterar dess första bild i tre rasteriseringsupplösningar via [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Alla andra exportinställningar förblir identiska så att resultaten kan jämföras.

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

I utdata blev EMF-filen en inbäddad PNG i varje SVG. Följande mätningar gäller den medföljande presentationen; de är inte en allmän formel för att konvertera DPI till pixeldimensioner.

| Metafil rasteriserings DPI | Inbäddade PNG-dimensioner | SVG‑filstorlek (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Jämförelsen nedan visar samma område av den inbäddade rasterbilden i samma förstora visningsstorlek. De diagonala linjerna visar synlig pixelering vid 72 DPI och jämnare kanter vid högre upplösningar, medan SVG‑filen växer. Att öka värdet förbättrar inte nödvändigtvis varje detalj eller förändrar varje exporterad bild.

![Uppskalad diagonal‑linjedetalj vid 72, 150 och 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) styr bildupplösningsreducering och kan dölja effekten av att ändra rasteriseringsupplösning för metafil. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) styr JPEG‑kodningskvalitet, inte rasteriseringsupplösning för metafil.

## **Tilldela stabila ID till former och text**

Använd [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) för att ange [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) för varje SVG‑form. För att även ange [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-)‑värden på text‑`tspan`‑element, implementera [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Tilldela någon av kontrollerna med [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Följande kontroller använder [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--), som är stabil för formens livstid, samt en repeterbar räknare för dess textspän. Detta gör de genererade ID:n lämpliga för efterbehandling av en oförändrad presentation.

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Lägg till SVG‑händelsehanterare**

I en [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) anropar du [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) med ett [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/)‑värde för att lägga till en JavaScript‑händelsehanterare till en exporterad form. Tilldela kontrollern med [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) och definiera JavaScript‑funktionen i sidan eller SVG‑dokumentet som innehåller resultatet.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

Värdsidan kan definiera JavaScript‑funktionen som refereras av hanteraren. Tilldelning av ID:n och händelsehanterare möjliggör bildvisare, förbättringar för tillgänglighet och andra interaktiva SVG‑arbetsflöden.

## **FAQ**

**När bör jag använda [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) istället för [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)?**

Använd [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) när all text måste vara oberoende av typsnitt. Använd [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) när endast text som använder externa typsnitt ska konverteras till grafik.

**Vad är det bästa sättet att göra en SVG mindre?**

Börja med att komprimera inbäddade bilder, radera beskurna bildområden och välja länkade typsnitts‑filer när målmiljön kan leverera dem. Testa resultatet eftersom lägre bildupplösning, lägre JPEG‑kvalitet och vektoriserad text alla har olika kompromisser mellan kvalitet och storlek.

**Kan jag ändra exporterade SVG‑element efter export?**

Ja. Tilldela ID:n via en formateringskontroller och välj sedan motsvarande SVG‑element i ditt efterbearbetningsverktyg eller browserskript.