---
title: Presentatiedia's renderen als SVG-afbeeldingen op Android
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
description: "Exporteer PowerPoint-dia's als SVG-afbeeldingen op Android en beheer lettertypen, tekst, afbeeldingen, ID's en events met Aspose.Slides."
---
## **Overzicht**

SVG is een schaalbaar XML‑gebaseerd afbeeldingformaat dat goed werkt voor webpublicatie, slide‑viewers, toegankelijkheids‑werkstromen en geautomatiseerde nabewerking. Aspose.Slides for Android via Java exporteert elke dia naar een afzonderlijk SVG‑bestand en stelt u in staat te bepalen hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden weggeschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) wanneer de geëxporteerde SVG compact moet zijn, voorspelbaar over browsers, of klaar voor interactief gebruik.

## **Export een dia als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) aan, selecteer een dia en schrijf deze naar een stream met [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Het volgende voorbeeld exporteert elke dia in een presentatie naar een afzonderlijk SVG‑bestand.

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

De bestandsnaam gebruikt [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) in plaats van de lus‑index. U kunt ook een afzonderlijk object exporteren met [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) wanneer een slide‑viewer of webpagina alleen dat object nodig heeft.

## **SVG‑output configureren**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) regelt het renderen van SVG. Voor tekstframes zorgt [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) ervoor dat het tekstframe wordt meegenomen in het rendergebied, en [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) bepaalt of de rotatie van het frame wordt toegepast. Stel [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) in op `true` wanneer tekst zonder ligaturen moet worden gerenderd.

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

## **Bijsnijden van lijneinden bij pijlpuntjes beheren**

SVG 1.1 heeft geen marker‑inset‑instelling om te bepalen waar een lijn moet stoppen onder een pijlpunt. Standaard verkort Aspose.Slides de geëxporteerde lijn zodat de penseelstreek niet door de marker heen steekt. Roep [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) aan met `true` om de penseelstreek helemaal tot het oorspronkelijke eindpunt van de lijn te tekenen. Deze instelling heeft alleen invloed op de SVG‑output. De lijn behoudt zijn positie en lengte op de dia.

Het voorbeeld tekent driehoek‑ en ruit‑pijlpuntjes op lijnen van respectievelijk 2 en 10 punten breed. Het exporteert dezelfde dia twee keer, waarbij alleen de bijsnijd‑optie wordt gewijzigd.

```java
import com.aspose.slides.*;
import android.graphics.Color;
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
            format.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

De vergelijking toont de driehoekige pijlpunt op de 10‑puntlijn. Met bijsnijden ingeschakeld is de punt scherp. Met bijsnijden uitgeschakeld steekt de penseelstreek door de schuine zijden van de marker en laat een vlak einde achter.

![Vergrote driehoek van 10 punten met een scherpe punt wanneer bijsnijden is ingeschakeld en een vlak einde wanneer bijsnijden is uitgeschakeld](line-end-cropping.png)

In de andere lijnen van het voorbeeld is de uitsteekende penseelstreek minder zichtbaar op de 2‑punt driehoek. Het gevulde ruitje bedekt het einde van de penseelstreek bij beide breedtes.

## **Tekst en lettertypen beheren**

Bij het exporteren van dia's naar SVG kunt u bepalen of tekst behouden blijft als tekst of wordt omgezet naar vectorafbeeldingen, en hoe externe lettertypen worden opgenomen of gerefereerd. De volgende opties helpen u visuele consistentie, tekstselectie en lettertype‑afhankelijkheden in de geëxporteerde SVG in balans te brengen.

### **Alle tekst vectoriseren**

Stel [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) in op `true` om alle dia‑tekst als vectorafbeeldingen te schrijven. Dit verwijdert lettertype‑afhankelijkheden en maakt het visuele resultaat consistenter over browsers, maar de tekst is niet langer selecteerbaar of doorzoekbaar als SVG‑tekst.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)‑waarde voor lettertypen die extern worden geladen. Kies [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) om naar afzonderlijke lettertype‑bestanden te verwijzen, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) om lettertype‑gegevens in de SVG op te nemen, of [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) om alleen tekst die externe lettertypen gebruikt als afbeeldingen te renderen. Controleer de licentie van het lettertype voordat u lettertypen embed.

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

## **De grootte van ingesloten afbeeldingen verkleinen**

Gebruik [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) om de resolutie van ingesloten afbeeldingen te verlagen, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) om bijgesneden brongebieden weg te laten, en [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) om de JPEG‑compressiekwaliteit te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van afbeeldingskwaliteit of bewaarde afbeeldingsdata.

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

## **Resolutie van metafile‑rasterisatie beheren**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) stelt de onder‑resolutielimiet in voor het rasteren van metafiles tijdens SVG‑export. Gebruik het om detail en bestandsgrootte in balans te brengen wanneer een EMF‑ of WMF‑afbeelding wordt gerasterd. Het definieert geen globale DPI voor de SVG en dwingt niet elk object op de dia om een rasterafbeelding te worden.

Download [metafile-rasterization.pptx](metafile-rasterization.pptx), die een EMF‑afbeelding met dicht opeengepakte diagonale lijnen bevat. Het volgende voorbeeld exporteert de eerste dia op drie rasterisatie‑resoluties via [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Alle andere exportinstellingen blijven identiek zodat de resultaten kunnen worden vergeleken.

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

In de output is de EMF omgezet in één ingesloten PNG in elke SVG. De volgende metingen gelden voor de meegeleverde presentatie; ze vormen geen algemene formule voor het omrekenen van DPI naar pixelafmetingen.

| Metafile rasterisatie DPI | Ingesloten PNG-afmetingen | SVG‑bestandsgrootte (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

De onderstaande vergelijking toont hetzelfde gebied van de ingesloten rasterafbeelding op dezelfde vergrote weergavegrootte. De diagonale lijnen vertonen zichtbare pixelatie bij 72 DPI en gladdere randen bij hogere resoluties, terwijl het SVG‑bestand groter wordt. Het verhogen van de waarde verbetert niet noodzakelijk elk detail of verandert elke geëxporteerde afbeelding.

![Vergrote diagonalelijndetails bij 72, 150 en 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) regelt de reductie van de afbeeldingsresolutie en kan het effect van het wijzigen van de metafile‑rasterisatie‑resolutie maskeren. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) regelt de JPEG‑compressiekwaliteit, niet de metafile‑rasterisatie‑resolutie.

## **Stabiele ID's toewijzen aan Shapes en tekst**

Gebruik [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) om [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) in te stellen voor elk SVG‑shape. Om ook [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) waarden op tekst‑`tspan`‑elementen te zetten, implementeer [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Wijs een van beide controllers toe met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

De volgende controller gebruikt [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--), die stabiel blijft gedurende de levensduur van het shape, en een herhaalbare teller voor de tekst‑spans. Hierdoor zijn de gegenereerde ID’s geschikt voor post‑processing van een ongewijzigde presentatie.

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

In een [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) roep je [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) aan met een [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/)‑waarde om een JavaScript‑eventhandler toe te voegen aan een geëxporteerd shape. Wijs de controller toe met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) en definieer de JavaScript‑functie op de pagina of in het SVG‑document dat het resultaat host.

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

De host‑pagina kan de JavaScript‑functie definiëren die door de handler wordt aangeroepen. Het toewijzen van ID’s en eventhandlers maakt slide‑viewers, toegankelijkheidsverbeteringen en andere interactieve SVG‑werkstromen mogelijk.

## **FAQ**

**Wanneer moet ik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) gebruiken in plaats van [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

Gebruik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt moet worden omgezet naar grafische afbeeldingen.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden afbeeldingsgebieden, en kies voor gekoppelde lettertype‑bestanden wanneer de doelomgeving ze kan leveren. Test het resultaat omdat een lagere afbeeldingsresolutie, lagere JPEG‑kwaliteit en gevectoriseerde tekst elk verschillende kwaliteit‑ en grootte‑afwegingen hebben.

**Kan ik geëxporteerde SVG‑elementen na export aanpassen?**

Ja. Wijs ID’s toe via een formatting‑controller en selecteer vervolgens de overeenkomende SVG‑elementen in uw post‑processing‑tool of browserscript.