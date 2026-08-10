---
title: Presentatiedia's renderen als SVG-afbeeldingen in Java
linktitle: Dia naar SVG
type: docs
weight: 50
url: /nl/java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint naar SVG
- presentatie naar SVG
- dia naar SVG
- PPT naar SVG
- PPTX naar SVG
- SVG exportopties
- interactieve SVG
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Exporteer PowerPoint-dia's als SVG-afbeeldingen in Java en beheer lettertypen, tekst, afbeeldingen, ID's en events met Aspose.Slides."
---
## **Overzicht**

SVG is een schaalbaar XML‑gebaseerd afbeeldingsformaat dat goed werkt voor webpublicatie, slide‑viewers, toegankelijkheidswerkstromen en geautomatiseerde nabewerking. Aspose.Slides exporteert elke dia naar een apart SVG‑bestand en stelt u in staat te bepalen hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden geschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgoptions/) wanneer de geëxporteerde SVG compact moet zijn, voorspelbaar over browsers, of klaar voor interactief gebruik.

## **Dia exporteren als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/), selecteer een dia en schrijf deze naar een stream met [ISlide.writeAsSvg](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Het volgende voorbeeld exporteert elke dia in een presentatie naar een apart SVG‑bestand.

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

De bestandsnaam gebruikt [ISlide.getSlideNumber](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/#getSlideNumber--) in plaats van de lusindex. U kunt ook een individuele vorm exporteren met [IShape.writeAsSvg](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) wanneer een slide‑viewer of webpagina alleen die vorm nodig heeft.

## **SVG‑uitvoer configureren**

[SVGOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgoptions/) regelt de weergave van SVG. Voor tekstframes zorgt [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) ervoor dat het tekstframe wordt opgenomen in het rendergebied, en [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) bepaalt of de rotatie van het frame wordt toegepast. Stel [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) in op `true` wanneer tekst zonder ligaturen moet worden gerenderd.

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

## **Tekst en lettertypen beheersen**

### **Alle tekst vectoriseren**

Stel [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) in op `true` om alle dia‑tekst als vectorafbeeldingen te schrijven. Dit verwijdert afhankelijkheden van lettertypen en maakt het visuele resultaat consistenter over browsers, maar de tekst is niet langer selecteerbaar of doorzoekbaar als SVG‑tekst.

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

### **Kies hoe externe lettertypen worden behandeld**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgexternalfontshandling/)‑waarde voor lettertypen die extern worden geladen. Kies `AddLinksToFontFiles` om afzonderlijke font‑bestanden te refereren, `Embed` om lettertype‑data in de SVG op te nemen, of `Vectorize` om alleen tekst die externe lettertypen gebruikt als graphics te renderen. Controleer de licentie van het lettertype voordat u lettertypen insluit.

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

## **Embedded afbeeldingsgrootte verkleinen**

Gebruik [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) om de resolutie van ingesloten afbeeldingen te verlagen, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) om bijgesneden brongebieden weg te laten, en [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) om de JPEG‑coderingskwaliteit te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van de beeldkwaliteit of bewaarde beelddata.

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

## **Stabiele ID's toewijzen aan vormen en tekst**

Gebruik [ISvgShapeFormattingController](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isvgshapeformattingcontroller/) om [ISvgShape.setId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) voor elke SVG‑vorm in te stellen. Om ook [ISvgTSpan.setId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) waarden op tekst‑`tspan`‑elementen te zetten, implementeer [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Wijs een van beide controllers toe met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

De volgende controller gebruikt [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--), die stabiel is gedurende de levensduur van de vorm, en een herhaalbare teller voor zijn tekst‑spans. Dit maakt de gegenereerde ID's geschikt voor nabewerking van een onveranderde presentatie.

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

## **SVG‑eventhandlers toevoegen**

In een [ISvgShapeFormattingController](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isvgshapeformattingcontroller/) roep je [ISvgShape.setEventHandler](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) aan met een [SvgEvent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgevent/)‑waarde om een JavaScript‑eventhandler toe te voegen aan een geëxporteerde vorm. Wijs de controller toe met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) en definieer de JavaScript‑functie in de pagina of het SVG‑document dat het resultaat host.

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

De host‑pagina kan de JavaScript‑functie definiëren die door de handler wordt aangeroepen. Het toewijzen van ID's en event‑handlers maakt slide‑viewers, toegankelijkheidsverbeteringen en andere interactieve SVG‑werkstromen mogelijk.

## **FAQ**

**Wanneer moet ik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) gebruiken in plaats van [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgexternalfontshandling/)?**

Gebruik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt moet worden omgezet naar graphics.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden afbeeldingsgebieden en het kiezen van gekoppelde font‑bestanden wanneer de doelomgeving ze kan leveren. Test het resultaat omdat een lagere beeldresolutie, lagere JPEG‑kwaliteit en gevectoriseerde tekst elk verschillende kwaliteit‑ en grootte‑afwegingen hebben.

**Kan ik geëxporteerde SVG‑elementen na export aanpassen?**

Ja. Ken ID's toe via een formatteringscontroller en selecteer vervolgens de bijbehorende SVG‑elementen in uw nabewerkings‑tool of browserscript.