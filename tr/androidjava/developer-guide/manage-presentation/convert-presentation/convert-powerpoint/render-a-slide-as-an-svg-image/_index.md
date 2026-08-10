---
title: Android'de Sunum Slaytlarını SVG Görüntüleri Olarak Oluştur
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
- SVG dışa aktarım seçenekleri
- etkileşimli SVG
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Android'de PowerPoint slaytlarını SVG görüntüleri olarak dışa aktarın ve Aspose.Slides ile yazı tiplerini, metni, görüntüleri, kimlikleri ve olayları kontrol edin."
---
## **Genel Bakış**

SVG, web yayıncılığı, slayt izleyicileri, erişilebilirlik iş akışları ve otomatik son işleme için iyi çalışan ölçeklenebilir bir XML tabanlı görüntü formatıdır. Aspose.Slides for Android via Java, her slaytı ayrı bir SVG dosyasına dışa aktarır ve metin, yazı tipleri, resimler ve SVG öğelerinin nasıl yazılacağını kontrol etmenizi sağlar.

Dışa aktarılan SVG'nin kompakt, tarayıcılar arasında öngörülebilir veya etkileşimli kullanım için hazır olması gerektiğinde [SVGOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgoptions/) kullanın.

## **Bir Slaytı SVG Olarak Dışa Aktarma**

Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) oluşturun, bir slaytı seçin ve onu bir akışa [ISlide.writeAsSvg](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) ile yazın. Aşağıdaki örnek, bir sunumdaki her slaytı ayrı bir SVG dosyası olarak dışa aktarır.

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

Dosya adı, döngü indeksi yerine [ISlide.getSlideNumber](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#getSlideNumber--) kullanır. Bir slayt görüntüleyicisinin veya web sayfasının yalnızca o şekli gerektirdiği durumlarda, [IShape.writeAsSvg](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) ile bireysel bir şekil de dışa aktarabilirsiniz.

## **SVG Çıktısını Yapılandırma**

[SVGOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgoptions/) SVG renderlemesini kontrol eder. Metin çerçeveleri için, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) metin çerçevesini renderleme alanına dahil eder ve [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) çerçeve döndürmesinin uygulanıp uygulanmayacağını belirler. Metnin ligatürsüz renderlenmesi gerektiğinde [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) değerini `true` olarak ayarlayın.

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

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) değerini `true` olarak ayarlayın, böylece tüm slayt metni vektör grafiği olarak yazılır. Bu, yazı tipi bağımlılıklarını ortadan kaldırır ve görsel sonucu tarayıcılar arasında daha tutarlı hâle getirir, ancak metin artık SVG metni olarak seçilebilir veya aranabilir olmaz.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) harici olarak yüklenen yazı tipleri için bir [SvgExternalFontsHandling](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgexternalfontshandling/) değeri kullanır. Ayrı yazı tipi dosyalarına referans vermek için [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgexternalfontshandling/), yazı tipi verilerini SVG'ye dahil etmek için [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgexternalfontshandling/) veya harici yazı tipleri kullanan metni yalnızca grafik olarak renderlemek için [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgexternalfontshandling/) seçin. Yazı tiplerini gömmeden önce lisanslamayı doğrulayın.

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

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) ile gömülü resimlerin çözünürlüğünü azaltın, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) ile kırpılmış kaynak bölgelerini atlayın ve [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) ile JPEG kodlama kalitesini kontrol edin. Bu ayarlar, dosya boyutunu görüntü doğruluğu veya tutulan görüntü verisi maliyeti karşılığında azaltır.

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

Her SVG şekli için [ISvgShape.setId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) ayarlamak üzere [ISvgShapeFormattingController](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) kullanın. Metin `tspan` öğelerine de [ISvgTSpan.setId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) değerleri atamak için [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/) uygulayın. Bu denetleyicilerden birini [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) ile atayın.

Aşağıdaki denetleyici, şeklin ömrü boyunca kararlı olan ve metin span'ları için tekrar edilebilir bir sayaç sağlayan [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) değerini kullanır. Bu, oluşturulan kimliklerin değişmemiş bir sunumun son işlemelerinde kullanılmasını sağlar.

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

[ISvgShapeFormattingController](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) içinde, dışa aktarılan bir şekle JavaScript olay işleyicisi eklemek için bir [SvgEvent](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgevent/) değeriyle [ISvgShape.setEventHandler](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) çağırın. Denetleyiciyi [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) ile atayın ve sonucu barındıran sayfa veya SVG belgesinde JavaScript işlevini tanımlayın.

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

Ana sayfa, işleyici tarafından referans verilen JavaScript işlevini tanımlayabilir. Kimliklerin ve olay işleyicilerin atanması, slayt izleyicileri, erişilebilirlik artırımları ve diğer etkileşimli SVG iş akışlarını mümkün kılar.

## **SSS**

**[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) yerine [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgexternalfontshandling/) ne zaman kullanılmalı?**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) tüm metnin yazı tiplerinden bağımsız olması gerektiğinde kullanın. [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgexternalfontshandling/) yalnızca harici yazı tipleri kullanan metnin grafiklere dönüştürülmesi gerektiğinde kullanın.

**Bir SVG'yi daha küçük yapmak için en iyi yöntem nedir?**

Başlangıç olarak gömülü resimleri sıkıştırın, kırpılmış görüntü bölgelerini silin ve hedef ortam bunları sunabiliyorsa bağlanmış yazı tipi dosyalarını seçin. Sonucu test edin; çünkü daha düşük görüntü çözünürlüğü, daha düşük JPEG kalitesi ve vektörleştirilmiş metin farklı kalite ve boyut dengelerine sahiptir.

**Dışa aktarılan SVG öğelerini dışa aktarımdan sonra değiştirebilir miyim?**

Evet. Bir biçimlendirme denetleyicisi aracılığıyla kimlikler atayın, ardından eşleşen SVG öğelerini post‑işleme aracınızda veya tarayıcı betiğinizde seçin.