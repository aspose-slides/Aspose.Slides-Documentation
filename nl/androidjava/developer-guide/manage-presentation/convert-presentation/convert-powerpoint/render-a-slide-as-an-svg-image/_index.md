---
title: Render presentatieslides als SVG-afbeeldingen op Android
linktitle: Slide naar SVG
type: docs
weight: 50
url: /nl/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint naar SVG
- presentatie naar SVG
- slide naar SVG
- PPT naar SVG
- PPTX naar SVG
- SVG-exportopties
- interactieve SVG
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Export PowerPoint-slides als SVG-afbeeldingen op Android en beheer lettertypen, tekst, afbeeldingen, ID's en gebeurtenissen met Aspose.Slides."
---
## **Overzicht**

SVG is een schaalbaar, op XML gebaseerd afbeeldingsformaat dat goed werkt voor webpublicatie, slide‑viewers, toegankelijkheids‑workflows en geautomatiseerde post‑processing. Aspose.Slides voor Android via Java exporteert elke slide naar een apart SVG‑bestand en stelt u in staat om te bepalen hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden weggeschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgoptions/) wanneer de geëxporteerde SVG compact moet zijn, voorspelbaar over browsers heen, of klaar voor interactief gebruik.

## **Exporteer een slide als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/), selecteer een slide en schrijf deze naar een stream met [ISlide.writeAsSvg](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Het volgende voorbeeld exporteert elke slide in een presentatie naar een apart SVG‑bestand.

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

De bestandsnaam gebruikt [ISlide.getSlideNumber](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/#getSlideNumber--) in plaats van de loop‑index. U kunt ook een individueel vormobject exporteren met [IShape.writeAsSvg](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) wanneer een slide‑viewer of webpagina alleen die vorm nodig heeft.

## **Configureer SVG‑output**

[SVGOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgoptions/) regelt de weergave van SVG. Voor tekstframes zorgt [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) ervoor dat het tekstframe in het weergavegebied wordt meegenomen, en [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) bepaalt of de rotatie van het frame wordt toegepast. Stel [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) in op `true` wanneer tekst zonder ligaturen moet worden gerenderd.

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

## **Beheer tekst en lettertypen**

### **Vectoriseer alle tekst**

Stel [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) in op `true` om alle slide‑tekst als vector‑graphics te schrijven. Dit verwijdert afhankelijkheden van lettertypen en zorgt voor een visueel resultaat dat consistenter is over verschillende browsers, maar de tekst is niet langer selecteerbaar of doorzoekbaar als SVG‑tekst.

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

### **Kies hoe externe lettertypen worden afgehandeld**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgexternalfontshandling/)‑waarde voor lettertypen die extern worden geladen. Kies [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgexternalfontshandling/) om naar afzonderlijke lettertype‑bestanden te verwijzen, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgexternalfontshandling/) om lettertype‑data in de SVG op te nemen, of [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgexternalfontshandling/) om alleen tekst die externe lettertypen gebruikt als graphics weer te geven. Controleer de licentie van het lettertype voordat u lettertypen inbedt.

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

## **Verminder de grootte van ingesloten afbeeldingen**

Gebruik [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) om de resolutie van ingesloten afbeeldingen te verlagen, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) om bijgesneden brongebieden weg te laten, en [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) om de JPEG‑compressiekwaliteit te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van de beeldkwaliteit of de behouden afbeeldingsdata.

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

## **Wijs stabiele ID's toe aan vormen en tekst**

Gebruik [ISvgShapeFormattingController](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) om [ISvgShape.setId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) voor elke SVG‑vorm in te stellen. Om ook [ISvgTSpan.setId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-)‑waarden voor tekst‑`tspan`‑elementen te definiëren, implementeert u [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Wijs één van de controllers toe met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

De volgende controller gebruikt [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) die gedurende de levensduur van de vorm stabiel is, en een herhaalbare teller voor de tekst‑spans. Hierdoor zijn de gegenereerde ID's geschikt voor post‑processing van een onveranderde presentatie.

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

## **Voeg SVG‑eventhandlers toe**

In een [ISvgShapeFormattingController](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) roept u [ISvgShape.setEventHandler](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) aan met een [SvgEvent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgevent/)‑waarde om een JavaScript‑eventhandler toe te voegen aan een geëxporteerde vorm. Wijs de controller toe met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) en definieer de JavaScript‑functie in de pagina of het SVG‑document dat het resultaat host.

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

De host‑pagina kan de JavaScript‑functie die door de handler wordt aangeroepen definiëren. Het toewijzen van ID's en eventhandlers maakt slide‑viewers, toegankelijkheidsverbeteringen en andere interactieve SVG‑workflows mogelijk.

## **FAQ**

**Wanneer moet ik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) gebruiken in plaats van [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

Gebruik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt moet worden omgezet naar graphics.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden afbeeldingsgebieden en het kiezen van gelinkte lettertypebestanden wanneer de doelomgeving ze kan leveren. Test het resultaat omdat lagere afbeeldingsresolutie, lagere JPEG‑kwaliteit en gevectoriseerde tekst elk verschillende kwaliteits‑ en grootte‑afwegingen hebben.

**Kan ik geëxporteerde SVG‑elementen na export aanpassen?**

Ja. Wijs ID's toe via een formatteringscontroller, selecteer vervolgens de overeenkomende SVG‑elementen in uw post‑processingtool of browserscript.