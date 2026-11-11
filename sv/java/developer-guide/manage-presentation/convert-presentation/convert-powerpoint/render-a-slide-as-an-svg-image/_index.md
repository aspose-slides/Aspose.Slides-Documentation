---
title: Rendera presentationsbilder som SVG‑bilder i Java
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
- SVG‑exportalternativ
- interaktiv SVG
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Exportera PowerPoint‑bilder som SVG‑bilder i Java och kontrollera teckensnitt, text, bilder, ID:n och händelser med Aspose.Slides."
---
## **Översikt**

SVG är ett skalbart XML‑baserat bildformat som fungerar bra för webbpublicering, bildspelsvisare, tillgänglighetsflöden och automatiserad efterbehandling. Aspose.Slides exporterar varje bild till en separat SVG‑fil och låter dig kontrollera hur text, teckensnitt, bilder och SVG‑element skrivs.

Använd [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) när den exporterade SVG‑filen måste vara kompakt, förutsägbar över webbläsare eller klar för interaktiv användning.

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

Filnamnet använder [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) istället för loopindexet. Du kan också exportera en enskild form med [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) när en bildvisare eller webbsida bara behöver den formen.

## **Konfigurera SVG‑utdata**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) styr SVG‑renderingen. För textramar inkluderar [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) textramens storlek i renderingsområdet, och [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) bestämmer om ramens rotation tillämpas. Ställ in [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) till `true` när text måste renderas utan ligaturer.

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

## **Styr text och teckensnitt**

När du exporterar bilder till SVG kan du kontrollera om text förblir som text eller konverteras till vektorgrafik, samt hur externa teckensnitt inkluderas eller refereras. Följande alternativ hjälper dig att balansera visuell konsistens, textval och teckensnittsberoenden i den exporterade SVG‑filen.

### **Vektorisera all text**

Ställ in [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) till `true` för att skriva all bildtext som vektorgrafik. Detta eliminerar teckensnittsberoenden och gör det visuella resultatet mer enhetligt över webbläsare, men texten blir inte längre markerbar eller sökbar som SVG‑text.

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

### **Välj hur externa teckensnitt hanteras**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) använder ett [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)‑värde för teckensnitt som laddas externt. Välj `AddLinksToFontFiles` för att referera till separata teckensnittsfiler, `Embed` för att inkludera teckensnittsdata i SVG‑filen, eller `Vectorize` för att rendera endast text som använder externa teckensnitt som grafik. Kontrollera teckensnittslicensen innan du bäddar in teckensnitt.

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

Använd [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) för att minska upplösningen på inbäddade bilder, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) för att utesluta beskurna källområden, och [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) för att styra JPEG‑kodningskvaliteten. Dessa inställningar minskar filstorleken på bekostnad av bildens trohet eller bibehållen bilddata.

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

## **Styr upplösning för metafil rasterisering**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) anger den lägre upplösningsgränsen för rasterisering av metafiler under SVG‑export. Använd den för att balansera detaljnivå och filstorlek när en EMF‑ eller WMF‑bild rasteriseras. Den definierar inte ett globalt DPI för SVG‑filen eller tvingar varje objekt på bilden att bli en rasterbild.

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

I resultatet blev EMF‑filen en inbäddad PNG i varje SVG. Följande mått gäller den medföljande presentationen; de är inte en generell formel för att konvertera DPI till pixelmått.

| Metafil rasteriserings‑DPI | Inbäddade PNG‑dimensioner | SVG‑filstorlek (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Jämförelsen nedan visar samma område av den inbäddade rasteren i samma förstora visningsstorlek. De diagonala linjerna visar synlig pixellering vid 72 DPI och jämnare kanter vid högre upplösningar, medan SVG‑filen växer. Att öka värdet förbättrar inte nödvändigtvis varje detalj eller förändrar varje exporterad bild.

![Förstorad diagonallinjedetalj vid 72, 150 och 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) styr minskning av bildupplösning och kan dölja effekten av att ändra metafil rasteriseringsupplösning. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) styr JPEG‑kodningskvaliteten, inte metafil rasteriseringsupplösning.

## **Tilldela stabila ID:n till former och text**

Använd [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) för att sätta [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) för varje SVG‑form. För att även sätta [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-)‑värden på text‑`tspan`‑element, implementera [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Tilldela någon av kontrollerna med [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Följande kontroller använder [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--), vilket är stabilt under formens livstid, samt en upprepningsbar räknare för dess textsporter. Detta gör de genererade ID:n lämpliga för efterbehandling av en oförändrad presentation.

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

I en [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) anropa [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) med ett [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/)‑värde för att lägga till en JavaScript‑händelsehanterare till en exporterad form. Tilldela kontrollern med [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) och definiera JavaScript‑funktionen i sidan eller SVG‑dokumentet som innehåller resultatet.

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

Värdsidan kan definiera den JavaScript‑funktion som refereras av hanteraren. Att tilldela ID:n och händelsehanterare möjliggör bildvisare, tillgänglighetsförbättringar och andra interaktiva SVG‑arbetsflöden.

## **FAQ**

**När bör jag använda [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) i stället för [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)?**

Använd [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) när all text måste vara oberoende av teckensnitt. Använd [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) när endast text som använder externa teckensnitt ska konverteras till grafik.

**Vad är det bästa sättet att göra en SVG mindre?**

Börja med att komprimera inbäddade bilder, ta bort beskurna bildområden och välja länkade teckensnittsfiler när målmiljön kan leverera dem. Testa resultatet eftersom lägre bildupplösning, lägre JPEG‑kvalitet och vektorisering av text har olika kvalitet‑ och storleksavvägningar.

**Kan jag ändra exporterade SVG‑element efter export?**

Ja. Tilldela ID:n via en formateringskontroller och välj sedan de motsvarande SVG‑elementen i ditt efterbehandlingsverktyg eller browserskript.