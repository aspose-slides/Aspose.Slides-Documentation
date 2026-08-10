---
title: PHP'de Sunum Slaytlarını SVG Görüntüsü Olarak Oluşturma
linktitle: Slaytı SVG'ye
type: docs
weight: 50
url: /tr/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint'ten SVG'ye
- sunumdan SVG'ye
- slayttan SVG'ye
- PPT'den SVG'ye
- PPTX'den SVG'ye
- SVG dışa aktarma seçenekleri
- etkileşimli SVG
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "PowerPoint slaytlarını PHP'de SVG görüntüsü olarak dışa aktarın ve yazı tiplerini, metni, resimleri, ID'leri ve olayları Aspose.Slides ile kontrol edin."
---
## **Genel Bakış**

SVG, web yayıncılığı, slayt görüntüleyicileri, erişilebilirlik iş akışları ve otomatik sonrası işleme için iyi çalışan ölçeklenebilir bir XML tabanlı görüntü formatıdır. Aspose.Slides, her slaytı ayrı bir SVG dosyasına dışa aktarır ve metin, yazı tipleri, resimler ve SVG öğelerinin nasıl yazılacağını kontrol etmenizi sağlar.

Dışa aktarılan SVG'nin kompakt, tarayıcılar arasında öngörülebilir veya etkileşimli kullanım için hazır olması gerektiğinde [SVGOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgoptions/) kullanın.

## **Bir Slaytı SVG Olarak Dışa Aktar**

Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) oluşturun, bir slayt seçin ve [Slide.writeAsSvg](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#writeAsSvg) ile bir akıma yazın. Aşağıdaki örnek, bir sunumdaki her slaytı ayrı bir SVG dosyası olarak dışa aktarır.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Dosya adı, döngü indeksinin yerine [Slide.getSlideNumber](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getSlideNumber) kullanır. Bir slayt görüntüleyicisinin veya web sayfasının yalnızca belirli bir şekle ihtiyaç duyduğu durumlarda [Shape.writeAsSvg](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#writeAsSvg) ile tek bir şekli de dışa aktarabilirsiniz.

## **SVG Çıktısını Yapılandırma**

[SVGOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgoptions/) SVG oluşturmayı kontrol eder. Metin çerçeveleri için, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgoptions/#setUseFrameSize) metin çerçevesini oluşturma alanına dahil eder ve [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgoptions/#setUseFrameRotation) çerçeve dönüşünün uygulanıp uygulanmayacağını belirler. Metnin ligatürsüz oluşturulması gerektiğinde [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) değerini `true` olarak ayarlayın.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Metin ve Yazı Tiplerini Kontrol Etme**

### **Tüm Metni Vektörleştir**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgoptions/#setVectorizeText) değerini `true` olarak ayarlayarak tüm slayt metnini vektör grafik olarak yazın. Bu, yazı tipi bağımlılıklarını ortadan kaldırır ve görsel sonucu tarayıcılar arasında daha tutarlı hale getirir, ancak metin artık SVG metni olarak seçilemez veya aranamaz.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **Harici Yazı Tiplerinin Nasıl İşleneceğini Seçin**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgoptions/#setExternalFontsHandling), harici olarak yüklenen yazı tipleri için bir [SvgExternalFontsHandling](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgexternalfontshandling/) değeri kullanır. Ayrı yazı tipi dosyalarına referans vermek için `AddLinksToFontFiles`, yazı tipi verisini SVG'ye dahil etmek için `Embed` ve harici yazı tipleri kullanan metni yalnızca grafik olarak oluşturmak için `Vectorize` seçeneklerini seçin. Yazı tiplerini gömmeden önce lisanslamayı doğrulayın.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Gömülü Görüntü Boyutunu Azaltma**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgoptions/#setPicturesCompression) kullanarak gömülü resimlerin çözünürlüğünü azaltın, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) ile kırpılmış kaynak alanlarını atlayın ve JPEG kodlama kalitesini kontrol etmek için [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgoptions/#setJpegQuality) ayarlayın. Bu ayarlar, görüntü doğruluğu veya saklanan görüntü verisi pahasına dosya boyutunu küçültür.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Şekillere ve Metne Kararlı ID'ler Atama**

[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgoptions/#setShapeFormattingController) için bir biçimlendirme geri araması sağlayarak her SVG şekli için [SvgShape.setId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgshape/#setId) belirleyin. Geri arama, metin `tspan` öğeleri üzerinde de [SvgTSpan.setId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgtspan/#setId) değerlerini ayarlayabilir.

PhpJavaBridge, akış modunda çalışırken `writeAsSvg` den bir PHP geri aramasını çağıramaz. Biçimlendirme mantığını küçük bir Java yardımcı sınıfına koyun, derleyin ve ortaya çıkan JAR dosyasını köprü sınıf yoluna ekleyin. Yardımcı, şeklin ömrü boyunca kararlı olan ve metin span'ları için tekrarlanabilir bir sayaç sağlayan [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getOfficeInteropShapeId) kullanabilir. Yardımcı kodu görmek için [Java implementation of `StableSvgIdController`](/slides/tr/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) adresine bakın.

Derlenmiş `com.example.slides.StableSvgIdController` sınıfını köprü sınıf yoluna ekledikten sonra, PHP üzerinden örnekleyin ve `SVGOptions`'a atayın:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **SVG Olay İşleyicileri Ekleme**

Bir biçimlendirme geri aramasında, dışa aktarılan bir şekle JavaScript olay işleyicisi eklemek için bir [SvgEvent](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgevent/) değeriyle [SvgShape.setEventHandler](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgshape/#setEventHandler) çağırın. Geri aramayı [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgoptions/#setShapeFormattingController) ile atayın ve sonucu barındıran sayfa veya SVG belgesinde JavaScript fonksiyonunu tanımlayın.

Kararlı ID'ler gibi, PhpJavaBridge akış modunu kullandığında geri aramayı bir Java yardımcı sınıfında uygulayın. [Java implementation of `SvgEventController`](/slides/tr/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) `ActionButton` adlı bir şekle bir ID ve bir `OnClick` işleyicisi atar. Bu yardımcıyı derleyin, köprü sınıf yoluna `com.example.slides.SvgEventController` olarak ekleyin ve aşağıdaki gibi PHP üzerinden kullanın:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

Barındırma sayfası, işleyici tarafından referans verilen JavaScript fonksiyonunu tanımlayabilir. ID'lerin ve olay işleyicilerin atanması slayt görüntüleyicileri, erişilebilirlik iyileştirmeleri ve diğer etkileşimli SVG iş akışlarını etkinleştirir.

## **SSS**

**[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgoptions/#setVectorizeText) yerine [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgexternalfontshandling/) ne zaman kullanmalıyım?**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgoptions/#setVectorizeText) tüm metnin yazı tiplerinden bağımsız olması gerektiğinde kullanın. [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgexternalfontshandling/) yalnızca harici yazı tipleri kullanan metnin grafiklere dönüştürülmesi gerektiğinde kullanın.

**Bir SVG'yi daha küçük yapmak için en iyi yol nedir?**

Öncelikle gömülü resimleri sıkıştırın, kırpılmış görüntü alanlarını silin ve hedef ortam bunları sunabiliyorsa bağlı font dosyalarını seçin. Sonucu test edin; çünkü daha düşük görüntü çözünürlüğü, daha düşük JPEG kalitesi ve vektörleştirilmiş metin farklı kalite ve boyut dengelerine sahiptir.

**Dışa aktarılan SVG öğelerini dışa aktarım sonrası değiştirebilir miyim?**

Evet. Biçimlendirme geri aramasıyla ID'leri atayın, ardından eşleşen SVG öğelerini ardından işleme aracınızda veya tarayıcı betiğinizde seçin.