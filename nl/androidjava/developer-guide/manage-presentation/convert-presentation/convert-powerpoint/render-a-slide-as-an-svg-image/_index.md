---
title: Render presentatiedia's als SVG-afbeeldingen op Android
linktitle: Dia naar SVG
type: docs
weight: 50
url: /nl/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint naar SVG
- presentatie naar SVG
- dia naar SVG
- PPT naar SVG
- PPTX naar SVG
- SVG-exportopties
- interactieve SVG
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Exporteer PowerPoint-dias als SVG-afbeeldingen op Android en beheer lettertypen, tekst, afbeeldingen, ID's en events met Aspose.Slides."
---
## **Overzicht**

SVG is een schaalbaar XML‑gebaseerd afbeeldingsformaat dat goed werkt voor webpublicatie, dia‑viewers, toegankelijkheidsworkflows en geautomatiseerde nabewerking. Aspose.Slides for Android via Java exporteert elke dia naar een afzonderlijk SVG‑bestand en laat u bepalen hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden weggeschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) wanneer de geëxporteerde SVG compact, voorspelbaar over browsers heen of klaar voor interactief gebruik moet zijn.

## **Exporteer een dia als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), selecteer een dia en schrijf deze naar een stream met [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Het volgende voorbeeld exporteert elke dia in een presentatie naar een apart SVG‑bestand.

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

De bestandsnaam gebruikt [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) in plaats van de lusindex. U kunt ook een afzonderlijke vorm exporteren met [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) wanneer een dia‑viewer of webpagina alleen die vorm nodig heeft.

## **Configureer SVG‑output**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) bepaalt de SVG‑rendering. Voor tekstkaders omvat [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) het tekstkader in het rendergebied, en [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) bepaalt of de rotatie van het kader wordt toegepast. Stel [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) in op `true` wanneer tekst moet worden gerenderd zonder ligaturen.

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

Bij het exporteren van dia's naar SVG kunt u bepalen of tekst als tekst behouden blijft of wordt omgezet naar vectorafbeeldingen, en hoe externe lettertypen worden opgenomen of gerefereerd. De volgende opties helpen u een balans te vinden tussen visuele consistentie, tekstselectie en lettertype‑afhankelijkheden in de geëxporteerde SVG.

### **Vectoriseer alle tekst**

Stel [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) in op `true` om alle dia‑tekst als vectorafbeeldingen weg te schrijven. Dit elimineert lettertype‑afhankelijkheden en maakt het visuele resultaat consistenter over browsers, maar de tekst is niet langer selecteerbaar of doorzoekbaar als SVG‑tekst.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)‑waarde voor lettertypen die extern worden geladen. Kies [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) om afzonderlijke lettertype‑bestanden te refereren, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) om lettertype‑data in de SVG op te nemen, of [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) om alleen tekst die externe lettertypen gebruikt als grafieken te renderen. Controleer de licentie van het lettertype voordat u lettertypen inbedt.

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

Gebruik [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) om de resolutie van ingesloten afbeeldingen te verkleinen, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) om bijgesneden brongebieden weg te laten, en [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) om de JPEG‑compressiekwaliteit te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van afbeeldingskwaliteit of behouden afbeeldingsdata.

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

## **Beheer metafile rasterisatie‑resolutie**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) stelt de ondergrens voor de resolutie in bij het rasteriseren van metafiles tijdens SVG‑export. Gebruik dit om een balans te vinden tussen detail en bestandsgrootte wanneer een EMF‑ of WMF‑afbeelding wordt gerasterd. Het definieert geen globale DPI voor de SVG en forceert niet dat elk object op de dia een raster‑afbeelding wordt.

Download [metafile-rasterization.pptx](metafile-rasterization.pptx), dat een EMF‑afbeelding bevat met dicht opeenlopende diagonale lijnen. Het volgende voorbeeld exporteert de eerste dia van deze presentatie met drie rasterisatie‑resoluties via [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Alle andere exportinstellingen blijven identiek zodat de resultaten kunnen worden vergeleken.

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

In de output werd de EMF één ingesloten PNG in elke SVG. De volgende metingen gelden voor de meegeleverde presentatie; ze vormen geen algemene formule voor het omrekenen van DPI naar pixelafmetingen.

| Metafile rasterisatie‑DPI | Ingesloten PNG‑afmetingen | SVG‑bestandsgrootte (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

De vergelijking hieronder toont hetzelfde gebied van de ingesloten rasterafbeelding op dezelfde vergrote weergavegrootte. De diagonale lijnen vertonen zichtbare pixelatie bij 72 DPI en gladdere randen bij hogere resoluties, terwijl het SVG‑bestand groter wordt. Het verhogen van de waarde verbetert niet per se elk detail of wijzigt elke geëxporteerde afbeelding.

![Vergrote diagonale lijn‑detail bij 72, 150 en 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) regelt de reductie van afbeeldingsresolutie en kan het effect van het wijzigen van de metafile rasterisatie‑resolutie maskeren. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) regelt de JPEG‑compressiekwaliteit, niet de rasterisatie‑resolutie van de metafile.

## **Wijs stabiele ID's toe aan vormen en tekst**

Gebruik [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) om [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) voor elke SVG‑vorm in te stellen. Om ook [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) waarden te definiëren op tekst‑`tspan`‑elementen, implementeer [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Wijs een van beide controllers toe met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

De volgende controller gebruikt [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--), dat stabiel blijft gedurende de levensduur van de vorm, en een herhaalbare teller voor de tekst‑spans. Hiermee zijn de gegenereerde ID's geschikt voor nabewerking van een ongewijzigde presentatie.

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

In een [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) roept u [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) aan met een [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/)‑waarde om een JavaScript‑eventhandler toe te voegen aan een geëxporteerde vorm. Wijs de controller toe met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) en definieer de JavaScript‑functie in de pagina of SVG‑document dat het resultaat host.

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

De host‑pagina kan de JavaScript‑functie definiëren die door de handler wordt aangeroepen. Het toewijzen van ID's en eventhandlers maakt het mogelijk dia‑viewers, toegankelijkheidsverbeteringen en andere interactieve SVG‑workflows te ondersteunen.

## **Veelgestelde vragen**

**Wanneer moet ik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) gebruiken in plaats van [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

Gebruik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt moet worden omgezet naar grafieken.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden afbeeldingsgebieden en het kiezen van gelinkte lettertype‑bestanden wanneer de doelomgeving ze kan serveren. Test het resultaat omdat lagere afbeeldingsresolutie, lagere JPEG‑kwaliteit en gevectoriseerde tekst elk verschillende kwaliteits‑ en grootte‑afwegingen hebben.

**Kan ik geëxporteerde SVG‑elementen na export aanpassen?**

Ja. Wijs ID's toe via een formatting‑controller, selecteer vervolgens de overeenkomende SVG‑elementen in uw nabewerkings‑tool of browserscript.