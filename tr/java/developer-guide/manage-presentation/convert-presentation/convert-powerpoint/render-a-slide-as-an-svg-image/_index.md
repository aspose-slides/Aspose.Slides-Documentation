---
title: Java'da Sunum Slaytlarını SVG Görüntülerine Dönüştür
linktitle: Slaytı SVG'ye
type: docs
weight: 50
url: /tr/java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint'ten SVG'ye
- sunumu SVG'ye
- slaytı SVG'ye
- PPT'yi SVG'ye
- PPTX'i SVG'ye
- SVG dışa aktarım seçenekleri
- etkileşimli SVG
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Java'da PowerPoint slaytlarını SVG görüntüleri olarak dışa aktarın ve Aspose.Slides ile yazı tiplerini, metni, resimleri, kimlikleri ve olayları kontrol edin."
---
## **Genel Bakış**

SVG, web yayıncılığı, slayt görüntüleyicileri, erişilebilirlik iş akışları ve otomatik sonrası işleme için iyi çalışan ölçeklenebilir bir XML tabanlı görüntü formatıdır. Aspose.Slides, her slaytı ayrı bir SVG dosyasına dışa aktarır ve metin, yazı tipleri, resimler ve SVG öğelerinin nasıl yazılacağını kontrol etmenizi sağlar.

İhraç edilen SVG'nin kompakt, tarayıcılar arasında öngörülebilir veya etkileşimli kullanım için hazır olması gerektiğinde [SVGOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgoptions/) kullanın.

## **Bir Slaytı SVG Olarak Dışa Aktarma**

[Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) oluşturun, bir slaytı seçin ve [ISlide.writeAsSvg](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) ile bir akıma yazın. Aşağıdaki örnek, bir sunumdaki her slaytı ayrı bir SVG dosyası olarak dışa aktarır.

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

Dosya adı, döngü dizini yerine [ISlide.getSlideNumber](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#getSlideNumber--) kullanır. Bir slayt görüntüleyicisi veya web sayfasının yalnızca o şekle ihtiyacı olduğunda [IShape.writeAsSvg](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) ile tek bir şekli de dışa aktarabilirsiniz.

## **SVG Çıktısını Yapılandırma**

[SVGOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgoptions/) SVG renderlemesini kontrol eder. Metin çerçeveleri için, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) metin çerçevesini renderleme alanına dahil eder ve [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) çerçeve dönüşünün uygulanıp uygulanmayacağını belirler. Metnin ligatürsüz renderlenmesi gerektiğinde [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) değerini `true` olarak ayarlayın.

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

## **Metin ve Yazı Tiplerini Kontrol Etme**

### **Tüm Metni Vektörleştir**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) değerini `true` olarak ayarlayarak tüm slayt metnini vektörel grafik olarak yazın. Bu, yazı tipi bağımlılıklarını ortadan kaldırır ve görsel sonucu tarayıcılar arasında daha tutarlı hale getirir, ancak metin artık SVG metni olarak seçilebilir veya aranabilir değildir.

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

### **Harici Yazı Tiplerinin Nasıl Ele Alınacağını Seçin**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) harici olarak yüklenen yazı tipleri için bir [SvgExternalFontsHandling](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgexternalfontshandling/) değeri kullanır. Ayrı yazı tipi dosyalarına referans vermek için `AddLinksToFontFiles`, yazı tipi verisini SVG'ye dahil etmek için `Embed` veya harici yazı tiplerini kullanan metni grafik olarak renderlemek için `Vectorize` seçeneğini tercih edin. Yazı tiplerini gömmeden önce lisanslamayı doğrulayın.

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

Gömülü resimlerin çözünürlüğünü azaltmak için [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-), kırpılmış kaynak alanlarını atlamak için [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-), ve JPEG kodlama kalitesini kontrol etmek için [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) kullanın. Bu ayarlar, dosya boyutunu azaltır ancak görüntü doğruluğu veya tutulan görüntü verisi pahasına olur.

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

## **Şekillere ve Metne Kararlı Kimlikler Atama**

Her SVG şekli için [ISvgShape.setId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) ayarlamak amacıyla [ISvgShapeFormattingController](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgshapeformattingcontroller/) kullanın. Metin `tspan` öğeleri için de [ISvgTSpan.setId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) değerlerini ayarlamak isterseniz [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgshapeandtextformattingcontroller/) uygulayın. Bu denetleyicilerden birini [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) ile atayın.

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

[ISvgShapeFormattingController](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgshapeformattingcontroller/) içinde, dışa aktarılan bir şekle JavaScript olay işleyicisi eklemek için [ISvgShape.setEventHandler](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) metodunu bir [SvgEvent](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgevent/) değeriyle çağırın. Denetleyiciyi [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) ile atayın ve JavaScript fonksiyonunu sonucu barındıran sayfada veya SVG belgesinde tanımlayın.

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

Barındırıcı sayfa, işleyici tarafından başvurulan JavaScript fonksiyonunu tanımlayabilir. Kimliklerin ve olay işleyicilerin atanması, slayt görüntüleyicileri, erişilebilirlik iyileştirmeleri ve diğer etkileşimli SVG iş akışlarını mümkün kılar.

## **SSS**

**[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) yerine [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgexternalfontshandling/) ne zaman kullanılmalı?**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) tüm metnin yazı tiplerinden bağımsız olması gerektiğinde kullanın. Yalnızca harici yazı tiplerini kullanan metnin grafiklere dönüştürülmesi gerektiğinde ise [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgexternalfontshandling/) kullanın.

**Bir SVG'yi daha küçük yapmak için en iyi yol nedir?**

İlk olarak gömülü resimleri sıkıştırın, kırpılmış görüntü alanlarını silin ve hedef ortam bu dosyaları sunabiliyorsa bağlanmış yazı tipi dosyalarını seçin. Sonucu test edin; çünkü düşük görüntü çözünürlüğü, düşük JPEG kalitesi ve vektörleştirilmiş metin farklı kalite ve boyut dengelerine sahiptir.

**Dışa aktarılan SVG öğelerini dışa aktardıktan sonra değiştirebilir miyim?**

Evet. Bir biçimlendirme denetleyicisi aracılığıyla kimlikler atayın, ardından eşleşen SVG öğelerini sonrası işleme aracınızda veya tarayıcı betiğinizde seçin.