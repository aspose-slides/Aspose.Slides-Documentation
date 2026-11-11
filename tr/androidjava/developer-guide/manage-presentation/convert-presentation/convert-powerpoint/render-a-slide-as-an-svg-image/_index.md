---
title: Android'de Sunum Slaytlarını SVG Görüntüleri Olarak İşleyin
linktitle: Slaytı SVG'ye
type: docs
weight: 50
url: /tr/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint'ten SVG'ye
- sunumdan SVG'ye
- slayttan SVG'ye
- PPT'den SVG'ye
- PPTX'ten SVG'ye
- SVG dışa aktarma seçenekleri
- etkileşimli SVG
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Android'de PowerPoint slaytlarını SVG görüntüleri olarak dışa aktarın ve Aspose.Slides ile yazı tiplerini, metni, görüntüleri, kimlikleri ve olayları kontrol edin."
---
## **Genel Bakış**

SVG, web yayıncılığı, slayt görüntüleyicileri, erişilebilirlik iş akışları ve otomatik sonrası işleme için iyi çalışan ölçeklenebilir bir XML tabanlı görüntü formatıdır. Aspose.Slides for Android via Java, her slaytı ayrı bir SVG dosyasına aktarır ve metin, yazı tipleri, resimler ve SVG öğelerinin nasıl yazılacağını kontrol etmenizi sağlar.

Use [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) when the exported SVG must be compact, predictable across browsers, or ready for interactive use.

## **Bir Slaytı SVG Olarak Dışa Aktarın**

Create a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), select a slide, and write it to a stream with [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). The following example exports every slide in a presentation as a separate SVG file.

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

The filename uses [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) rather than the loop index. You can also export an individual shape with [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) when a slide viewer or web page needs only that shape.

## **SVG Çıktısını Yapılandırma**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) controls SVG rendering. For text frames, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) includes the text frame in the rendering area, and [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) determines whether the frame rotation is applied. Set [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) to `true` when text must be rendered without ligatures.

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

## **Ok Başlarında Çizgi Ucu Kırpmasını Kontrol Etme**

SVG 1.1'de, bir çizginin ok başının altındaki durma noktasını belirten bir işaretçi içi ayarı yoktur. Varsayılan olarak, Aspose.Slides dışa aktarılan çizgiyi, çizginin darbesinin işaretçi üzerinden dışarı çıkmaması için kısaltır. Call [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) with `true` to draw the stroke all the way to the line's original endpoint. This setting affects only the SVG output. The line keeps its position and length on the slide.

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

The example draws triangle and diamond arrowheads on lines 2 and 10 points wide. It exports the same slide twice, changing only the cropping option.

![Kırpma etkin olduğunda keskin uçlu, kırpma devre dışı bırakıldığında düz uçlu büyütülmüş 10 puanlık üçgen](line-end-cropping.png)

In the other lines from the example, the protruding stroke is less visible on the 2-point triangle. The filled diamond covers the end of the stroke at both widths.

## **Metin ve Yazı Tiplerini Kontrol Etme**

When exporting slides to SVG, you can control whether text remains as text or is converted to vector graphics, and how external fonts are included or referenced. The following options help you balance visual consistency, text selection, and font dependencies in the exported SVG.

### **Tüm Metni Vektörleştir**

Set [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) to `true` to write all slide text as vector graphics. This eliminates font dependencies and makes the visual result more consistent across browsers, but the text is no longer selectable or searchable as SVG text.

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

### **Harici Yazı Tiplerinin Nasıl İşleneceğini Seçin**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) uses a [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) value for fonts that are loaded externally. Choose [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) to reference separate font files, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) to include font data in the SVG, or [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) to render only text that uses external fonts as graphics. Verify font licensing before embedding fonts.

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

## **Gömülü Görüntü Boyutunu Azaltma**

Use [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) to reduce the resolution of embedded pictures, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) to omit cropped source areas, and [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) to control JPEG encoding quality. These settings reduce file size at the cost of image fidelity or retained image data.

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

## **Metafile Rasterizasyon Çözünürlüğünü Kontrol Etme**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) sets the lower resolution limit for rasterizing metafiles during SVG export. Use it to balance detail and file size when an EMF or WMF image is rasterized. It does not define a global DPI for the SVG or force every object on the slide to become a raster image.

Download [metafile-rasterization.pptx](metafile-rasterization.pptx), which contains an EMF image with closely spaced diagonal lines. The following example exports its first slide at three rasterization resolutions through [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). All other export settings remain identical so that the results can be compared.

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

In the output, the EMF became one embedded PNG in each SVG. The following measurements are for the supplied presentation; they are not a general formula for converting DPI to pixel dimensions.

| Metafile rasterizasyon DPI | Gömülü PNG boyutları | SVG dosya boyutu (bayt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

The comparison below shows the same area of the embedded raster at the same enlarged display size. The diagonal lines show visible pixelation at 72 DPI and smoother edges at higher resolutions, while the SVG file grows. Increasing the value does not necessarily improve every detail or change every exported image.

![72, 150 ve 300 DPI'de büyütülmüş çapraz çizgi detayı](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) controls image resolution reduction and can mask the effect of changing the metafile rasterization resolution. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) controls JPEG encoding quality, not metafile rasterization resolution.

## **Şekillere ve Metne Kararlı Kimlikler Atama**

Use [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) to set [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) for each SVG shape. To set [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) values on text `tspan` elements as well, implement [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Assign either controller with [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

The following controller uses [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--), which is stable for the lifetime of the shape, and a repeatable counter for its text spans. This makes the generated IDs suitable for post-processing an unchanged presentation.

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

## **SVG Olay İşleyicileri Ekleme**

In an [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/), call [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) with a [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/) value to add a JavaScript event handler to an exported shape. Assign the controller with [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) and define the JavaScript function in the page or SVG document that hosts the result.

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

The host page can define the JavaScript function referenced by the handler. Assigning IDs and event handlers enables slide viewers, accessibility enhancements, and other interactive SVG workflows.

## **FAQ**

**Ne zaman [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) yerine [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) kullanmalıyım?**

Use [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) when all text must be independent of fonts. Use [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) when only text that uses external fonts should be converted to graphics.

**Bir SVG'yi daha küçük yapmak için en iyi yol nedir?**

Start by compressing embedded pictures, deleting cropped image areas, and choosing linked font files when the target environment can serve them. Test the result because lower image resolution, lower JPEG quality, and vectorized text each have different quality and size tradeoffs.

**Dışa aktarılan SVG öğelerini dışa aktarımdan sonra değiştirebilir miyim?**

Yes. Assign IDs through a formatting controller, then select the matching SVG elements in your post-processing tool or browser script.