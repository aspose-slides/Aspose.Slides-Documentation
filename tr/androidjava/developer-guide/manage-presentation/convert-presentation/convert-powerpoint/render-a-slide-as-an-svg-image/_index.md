---
title: Android'de Sunum Slaytlarını SVG Görselleri Olarak İşleyin
linktitle: Slaytı SVG'ye
type: docs
weight: 50
url: /tr/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint'ten SVG'ye
- sunumdan SVG'ye
- slayttan SVG'ye
- PPT'den SVG'ye
- PPTX'den SVG'ye
- SVG dışa aktarım seçenekleri
- etkileşimli SVG
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Android'de PowerPoint slaytlarını SVG görselleri olarak dışa aktarın ve Aspose.Slides ile yazı tiplerini, metni, görselleri, kimlikleri ve olayları kontrol edin."
---
## **Genel Bakış**

SVG, web yayını, slayt görüntüleyicileri, erişilebilirlik iş akışları ve otomatik sonrası işleme için iyi çalışan ölçeklenebilir bir XML tabanlı görsel biçimidir. Aspose.Slides for Android via Java, her slaytı ayrı bir SVG dosyasına aktarır ve metin, yazı tipleri, resimler ve SVG öğelerinin nasıl yazılacağını kontrol etmenizi sağlar.

İhrac edilen SVG'nin kompakt, tarayıcılar arasında öngörülebilir veya etkileşimli kullanım için hazır olması gerektiğinde [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) kullanın.

## **Bir Slaytı SVG Olarak Dışa Aktarma**

Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) oluşturun, bir slaytı seçin ve slaytı bir akıma [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) ile yazın. Aşağıdaki örnek, bir sunumdaki tüm slaytları ayrı bir SVG dosyası olarak dışa aktarır.

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

Dosya adı, döngü indeksinin yerine [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) kullanır. Bir slayt görüntüleyicisinin veya web sayfasının yalnızca o şekle ihtiyacı olduğunda, [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) ile tek bir şekli de dışa aktarabilirsiniz.

## **SVG Çıktısını Yapılandırma**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) SVG renderlemesini kontrol eder. Metin çerçeveleri için, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) metin çerçevesini renderleme alanına dahil eder ve [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) çerçeve dönüşünün uygulanıp uygulanmayacağını belirler. Metin bağlaçları olmadan render edilmesi gerektiğinde [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) değerini `true` olarak ayarlayın.

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

Slaytları SVG olarak dışa aktarırken, metnin metin olarak kalıp kalmayacağını veya vektör grafiklerine dönüştürülüp dönüştürülmeyeceğini ve harici yazı tiplerinin nasıl dahil edileceğini veya referans verileceğini kontrol edebilirsiniz. Aşağıdaki seçenekler, dışa aktarılan SVG'de görsel tutarlılık, metin seçimi ve yazı tipi bağımlılıklarını dengelemenize yardımcı olur.

### **Tüm Metni Vektörleştir**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) değerini `true` olarak ayarlayın; bu şekilde tüm slayt metni vektör grafik olarak yazılır. Bu, yazı tipi bağımlılıklarını ortadan kaldırır ve görsel sonucu tarayıcılar arasında daha tutarlı hâle getirir, ancak metin artık SVG metni olarak seçilemez veya aranamaz.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) harici olarak yüklenen yazı tipleri için bir [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) değeri kullanır. Ayrı yazı tipi dosyalarına referans vermek için [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/), SVG içinde yazı tipi verisini dahil etmek için [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/), veya harici yazı tipleri kullanan metni grafik olarak renderlemek için [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) seçeneğini seçin. Yazı tiplerini gömmeden önce lisanslarını doğrulayın.

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

## **Gömülü Resim Boyutunu Azaltma**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) kullanarak gömülü resimlerin çözünürlüğünü düşürün, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) ile kırpılmış kaynak alanlarını atlayın ve [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) ile JPEG kodlama kalitesini kontrol edin. Bu ayarlar, dosya boyutunu görüntü doğruluğu ya da tutulan resim verisi pahasına azaltır.

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

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) SVG dışa aktarımı sırasında metafile'ların rasterleştirilmesi için alt çözünürlük limitini belirler. Bir EMF veya WMF görüntüsü rasterleştirildiğinde ayrıntı ile dosya boyutunu dengelemek için kullanın. Bu, SVG için global bir DPI tanımlamaz ya da slayttaki her nesnenin raster görüntü haline gelmesini zorlamaz.

[metafile-rasterization.pptx](metafile-rasterization.pptx) dosyasını indirin; içinde yakından aralıklı çapraz çizgili bir EMF görüntüsü bulunur. Aşağıdaki örnek, [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) aracılığıyla ilk slaytını üç rasterleştirme çözünürlüğünde dışa aktarır. Diğer tüm dışa aktarım ayarları aynı kalır, böylece sonuçlar karşılaştırılabilir.

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

Çıktıda, EMF her SVG'de tek bir gömülü PNG'ye dönüşmüştür. Aşağıdaki ölçümler sağlanan sunum içindir; DPI'yı piksel boyutlarına dönüştürmek için genel bir formül değildir.

| Metafile rasterizasyon DPI | Gömülü PNG boyutları | SVG dosya boyutu (bayt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Aşağıdaki karşılaştırma, gömülü rasterin aynı bölgesini aynı büyütülmüş ekranda gösterir. Çapraz çizgiler, 72 DPI'da görülebilir pikselleşmeyi ve daha yüksek çözünürlüklerde daha düzgün kenarları gösterirken, SVG dosyası büyür. Değeri artırmak, her detayı iyileştirmez ya da her dışa aktarılan görüntüyü değiştirmez.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) görüntü çözünürlüğü azaltmayı kontrol eder ve metafile rasterizasyon çözünürlüğündeki değişimin etkisini maskeleyebilir. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) JPEG kodlama kalitesini kontrol eder, metafile rasterizasyon çözünürlüğünü değil.

## **Şekillere ve Metne Kararlı Kimlikler Atama**

Her SVG şekli için [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) ayarlamak üzere [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) kullanın. Metin `tspan` öğeleri için de [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) değerlerini ayarlamak istiyorsanız, [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/) uygulayın. Bu denetleyicilerden birini [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) ile atayın.

Aşağıdaki denetleyici, şeklin ömrü boyunca kararlı olan ve metin parçaları için tekrarlanabilir bir sayaç sağlayan [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) kullanır. Bu, oluşturulan kimliklerin değişmemiş bir sunumun sonrası işlenmesi için uygun olmasını sağlar.

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

[ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) içinde, dışa aktarılan bir şekle JavaScript olay işleyicisi eklemek için bir [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/) değeriyle [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) çağırın. Denetleyiciyi [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) ile atayın ve sonucu barındıran sayfada ya da SVG belgesinde JavaScript fonksiyonunu tanımlayın.

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

Barındırıcı sayfa, işleyici tarafından referans edilen JavaScript fonksiyonunu tanımlayabilir. Kimliklerin ve olay işleyicilerin atanması, slayt görüntüleyicileri, erişilebilirlik iyileştirmeleri ve diğer etkileşimli SVG iş akışlarını etkinleştirir.

## **SSS**

**[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) yerine [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) ne zaman kullanılmalı?**

Tüm metnin yazı tiplerinden bağımsız olması gerektiğinde [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) kullanın. Yalnızca harici yazı tipleri kullanan metnin grafiklere dönüştürülmesi gerektiğinde [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) kullanın.

**Bir SVG'yi küçültmenin en iyi yolu nedir?**

İlk olarak gömülü resimleri sıkıştırın, kırpılmış resim alanlarını silin ve hedef ortam dosyaları sunabiliyorsa bağlantılı yazı tipi dosyalarını seçin. Sonucu test edin; çünkü daha düşük resim çözünürlüğü, daha düşük JPEG kalitesi ve vektörleştirilmiş metin, her biri farklı kalite ve boyut dengelerine sahiptir.

**Dışa aktarılan SVG öğelerini dışa aktarımdan sonra değiştirebilir miyim?**

Evet. Bir formatlama denetleyicisi aracılığıyla kimlikleri atayın, ardından bunlara uygun SVG öğelerini sonrası işleme aracınızda veya tarayıcı betiğinizde seçin.