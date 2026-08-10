---
title: Rendera presentationsbilder som SVG-bilder på Android
linktitle: Bild till SVG
type: docs
weight: 50
url: /sv/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "Exportera PowerPoint‑bilder som SVG‑bilder på Android och kontrollera typsnitt, text, bilder, ID:n och händelser med Aspose.Slides."
---
## **Översikt**

SVG är ett skalbart XML-baserat bildformat som fungerar bra för webbpublicering, bildspelsvisare, tillgänglighetsarbetsflöden och automatiserad efterbehandling. Aspose.Slides för Android via Java exporterar varje bild till en separat SVG-fil och låter dig kontrollera hur text, typsnitt, bilder och SVG‑element skrivs.

Använd [SVGOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgoptions/) när den exporterade SVG‑filen måste vara kompakt, förutsägbar i olika webbläsare eller klar för interaktiv användning.

## **Exportera en bild som SVG**

Skapa en [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/), välj en bild och skriv den till en ström med [ISlide.writeAsSvg](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Följande exempel exporterar varje bild i en presentation som en separat SVG‑fil.

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

Filnamnet använder [ISlide.getSlideNumber](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/#getSlideNumber--) istället för loop‑indexet. Du kan även exportera en enskild form med [IShape.writeAsSvg](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) när en bildvisare eller webbsida bara behöver den formen.

## **Konfigurera SVG‑utdata**

[SVGOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgoptions/) styr SVG‑rendering. För textramar inkluderar [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) textramen i renderingsområdet, och [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) bestämmer om ramrotationen tillämpas. Sätt [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) till `true` när texten måste renderas utan ligaturer.

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

## **Styr text och typsnitt**

### **Vektorisera all text**

Sätt [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) till `true` för att skriva all bildtext som vektor‑grafik. Detta eliminerar beroenden av typsnitt och gör det visuella resultatet mer konsekvent i olika webbläsare, men texten är inte längre markerbar eller sökbar som SVG‑text.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) använder ett [SvgExternalFontsHandling](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgexternalfontshandling/)-värde för typsnitt som laddas externt. Välj [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgexternalfontshandling/) för att referera till separata typsnittsfiler, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgexternalfontshandling/) för att inkludera typsnittsdata i SVG‑filen, eller [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgexternalfontshandling/) för att rendera endast text som använder externa typsnitt som grafik. Verifiera typsnittslicenser innan du bäddar in typsnitt.

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

Använd [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) för att minska upplösningen på inbäddade bilder, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) för att utelämna beskurna källområden och [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) för att kontrollera JPEG‑komprimeringskvaliteten. Dessa inställningar minskar filstorleken på bekostnad av bildkvalitet eller bevarad bilddata.

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

## **Tilldela stabila ID:n till former och text**

Använd [ISvgShapeFormattingController](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) för att sätta [ISvgShape.setId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) för varje SVG‑form. För att även sätta värden på [ISvgTSpan.setId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) för text‑`tspan`‑element, implementera [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Tilldela någon av kontrollerna med [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Följande kontroller använder [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--), vilket är stabilt under formens livstid, samt en återupprepningsbar räknare för dess text‑spannen. Detta gör de genererade ID:n lämpliga för efterbehandling av en oförändrad presentation.

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

I en [ISvgShapeFormattingController](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) anropa [ISvgShape.setEventHandler](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) med ett [SvgEvent](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgevent/)-värde för att lägga till en JavaScript‑händelsehanterare på en exporterad form. Tilldela kontrollern med [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) och definiera JavaScript‑funktionen i sidan eller SVG‑dokumentet som visar resultatet.

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

Värdsidan kan definiera JavaScript‑funktionen som refereras av hanteraren. Tilldelning av ID:n och händelsehanterare möjliggör bildvisare, tillgänglighetsförbättringar och andra interaktiva SVG‑arbetsflöden.

## **FAQ**

**När bör jag använda [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) istället för [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

Använd [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) när all text måste vara oberoende av typsnitt. Använd [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgexternalfontshandling/) när endast text som använder externa typsnitt ska konverteras till grafik.

**Vad är det bästa sättet att göra en SVG mindre?**

Börja med att komprimera inbäddade bilder, ta bort beskurna bildområden och välja länkade typsnittsfiler när målmiljön kan leverera dem. Testa resultatet eftersom lägre bildupplösning, lägre JPEG‑kvalitet och vektorisering av text har olika kompromisser mellan kvalitet och storlek.

**Kan jag ändra exporterade SVG‑element efter export?**

Ja. Tilldela ID:n via en formateringskontroller och välj sedan de motsvarande SVG‑elementen i ditt efterbearbetningsverktyg eller browserskript.