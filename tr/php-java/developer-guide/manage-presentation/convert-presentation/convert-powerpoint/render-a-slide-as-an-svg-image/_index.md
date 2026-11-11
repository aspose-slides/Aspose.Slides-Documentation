---
title: PHP'de Sunum Slaytlarını SVG Görüntüleri Olarak Oluşturun
linktitle: Slayttan SVG'ye
type: docs
weight: 50
url: /tr/php-java/render-a-slide-as-an-svg-image/
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
- PHP
- Aspose.Slides
description: "PowerPoint slaytlarını PHP'de SVG görüntüleri olarak dışa aktarın ve Aspose.Slides ile yazı tiplerini, metni, görüntüleri, kimlikleri ve olayları kontrol edin."
---
## **Genel Bakış**

SVG, web yayıncılığı, slayt görüntüleyicileri, erişilebilirlik iş akışları ve otomatik son işlem için iyi çalışan ölçeklenebilir bir XML tabanlı görüntü formatıdır. Aspose.Slides, her slaytı ayrı bir SVG dosyasına dışa aktarır ve metin, yazı tipleri, resimler ve SVG öğelerinin nasıl yazılacağını kontrol etmenizi sağlar.

Dışa aktarılan SVG'nin kompakt, tarayıcılar arasında öngörülebilir veya etkileşimli kullanım için hazır olması gerektiğinde [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) kullanın.

## **Slaytı SVG Olarak Dışa Aktarma**

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) oluşturun, bir slayt seçin ve [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg) ile bir akıma yazın. Aşağıdaki örnek, bir sunumdaki her slaytı ayrı bir SVG dosyası olarak dışa aktarır.

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

Dosya adı, döngü indeksi yerine [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) kullanır. Bir slayt görüntüleyicisinin veya web sayfasının yalnızca o şekle ihtiyacı olduğunda [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) ile tek bir şekli de dışa aktarabilirsiniz.

## **SVG Çıktısını Yapılandırma**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) SVG oluşturmayı denetler. Metin çerçeveleri için [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) metin çerçevesini oluşturma alanına dahil eder ve [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) çerçeve dönüşünün uygulanıp uygulanmayacağını belirler. Metin, ligatürler olmadan oluşturulmalıysa [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) `true` olarak ayarlayın.

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

## **Ok Uçlarında Çizgi Ucu Kırpmasını Kontrol Et**

SVG 1.1, bir çizginin ok ucunun altında nerede durması gerektiğini belirten bir işaret içi ayarı içermez. Varsayılan olarak, Aspose.Slides dışa aktarılan çizgiyi, darbesinin işaretin içine çıkmaması için kısaltır. Çizgiyi orijinal bitiş noktasına kadar çizmeye `true` ile [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) çağırın. Bu ayar yalnızca SVG çıktısını etkiler. Çizgi slayttaki konumunu ve uzunluğunu korur.

Örnek, 2 ve 10 puan genişliğinde çizgilere üçgen ve elmas ok uçları çizer. Aynı slaytı yalnızca kırpma seçeneğini değiştirerek iki kez dışa aktarır.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

Karşılaştırma, 10 puanlık çizgideki üçgen ok ucunu gösterir. Kırpma etkinleştirildiğinde uç keskindir. Kırpma devre dışı bırakıldığında, darbe işaretin eğimli kenarlarından dışarı çıkar ve düz bir uç bırakır.

![Kırpma etkin olduğunda keskin bir uca sahip, kırpma devre dışı bırakıldığında düz bir uca sahip, büyütülmüş 10 puanlık üçgen](line-end-cropping.png)

Diğer örnek çizgilerde, dışarı çıkan darbe 2 puanlık üçgende daha az görülür. Dolu elmas, her iki genişlikte de darbenin sonunu kapatır.

## **Metin ve Yazı Tiplerini Kontrol Et**

Slaytları SVG olarak dışa aktarırken, metnin metin olarak kalıp kalmayacağını veya vektör grafiğe dönüştürüleceğini ve harici yazı tiplerinin nasıl dahil edilip referans verileceğini kontrol edebilirsiniz. Aşağıdaki seçenekler, dışa aktarılan SVG'de görsel tutarlılık, metin seçimi ve yazı tipi bağımlılıkları arasında denge kurmanıza yardımcı olur.

### **Tüm Metni Vektörleştir**

[TVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) `true` olarak ayarlandığında tüm slayt metni vektör grafik olarak yazılır. Bu, yazı tipi bağımlılıklarını ortadan kaldırır ve görsel sonucu tarayıcılar arasında daha tutarlı hâle getirir, ancak metin artık SVG metni olarak seçilemez veya aranamaz.

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

### **Harici Yazı Tiplerinin Nasıl İşleneceğini Seç**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) harici olarak yüklü yazı tipleri için bir [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) değeri kullanır. `AddLinksToFontFiles` seçilirse ayrı font dosyalarına referans verilir, `Embed` seçilirse font verisi SVG içine eklenir, `Vectorize` seçilirse harici yazı tipleri kullanan metin yalnızca grafik olarak oluşturulur. Fontları gömmeden önce lisans koşullarını doğrulayın.

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

## **Gömülü Görüntü Boyutunu Azalt**

[Görsellerin çözünürlüğünü düşürmek için [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression)], [kırpılmış kaynak alanlarını atlamak için [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas)], ve JPEG kodlama kalitesini kontrol etmek için [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) kullanın. Bu ayarlar, görüntü doğruluğu ya da tutulan görüntü verileri pahasına dosya boyutunu azaltır.

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

## **Metafile Rasterizasyon Çözünürlüğünü Kontrol Et**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) SVG dışa aktarımı sırasında metafile’ların rasterleştirilmesi için alt çözünürlük sınırını ayarlar. EMF veya WMF bir görüntü rasterleştirildiğinde ayrıntı ve dosya boyutu arasında denge kurmak için kullanın. Bu, SVG için global bir DPI tanımlamaz ya da slayttaki her nesnenin raster görüntüye dönüşmesini zorlamaz.

[metafile-rasterization.pptx](metafile-rasterization.pptx) dosyasını indirin; bu dosya, yakın aralıklı diyagonal çizgileri olan bir EMF görüntüsü içerir. Aşağıdaki örnek, ilk slaytı [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/) aracılığıyla üç rasterleştirme çözünürlüğünde dışa aktarır. Diğer tüm dışa aktarma ayarları aynı tutulur, böylece sonuçlar karşılaştırılabilir.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

Çıktıda, EMF her SVG içinde gömülü bir PNG’ye dönüşür. Aşağıdaki ölçümler sağlanan sunum içindir; DPI’yı piksel boyutuna dönüştürmek için genel bir formül değildir.

| Metafile rasterizasyon DPI | Gömülü PNG boyutları | SVG dosya boyutu (bayt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Aşağıdaki karşılaştırma, aynı genişletilmiş görüntü boyutunda gömülü rasterin aynı alanını gösterir. Diyagonal çizgiler 72 DPI’da belirgin pikselleşme, daha yüksek çözünürlüklerde daha yumuşak kenarlar gösterir; bu arada SVG dosyası büyür. Değeri artırmak mutlaka her detayı iyileştirmez veya her dışa aktarılan görüntüyü değiştirmez.

![72, 150 ve 300 DPI’da büyütülmüş diyagonal çizgi detayı](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) görüntü çözünürlüğü azaltmayı denetler ve metafile rasterleştirme çözünürlüğündeki değişikliğin etkisini maskeleyebilir. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) JPEG kodlama kalitesini denetler, metafile rasterleştirme çözünürlüğünü değil.

## **Şekillere ve Metne Kararlı Kimlikler Ata**

[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) aracılığıyla bir biçimlendirme geri çağrısı sağlayarak her SVG şekli için [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) ayarlayın. Geri çağrı, metin `tspan` öğelerine [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) değerleri de atayabilir.

PhpJavaBridge, `writeAsSvg` akış modunda çalıştığında bir PHP geri çağrısını çalıştıramaz. Biçimlendirme mantığını küçük bir Java yardımcı sınıfına koyun, derleyin ve oluşan JAR dosyasını köprü sınıf yoluna ekleyin. Yardımcı, şeklin yaşam süresi boyunca kararlı olan [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId) ve metin span’ları için tekrarlanabilir bir sayıcıyı kullanabilir. Yardımcı kodu için [Java implementation of `StableSvgIdController`](/slides/tr/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) bölümüne bakın.

Derlenmiş `com.example.slides.StableSvgIdController` sınıfını köprü sınıf yoluna ekledikten sonra, PHP’den örnekleyin ve `SVGOptions`a atayın:

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

## **SVG Olay İşleyicileri Ekle**

Bir biçimlendirme geri çağrısında, bir [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) değeriyle [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) çağırarak dışa aktarılan bir şekle JavaScript olay işleyicisi ekleyin. Geri çağırıyı [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) ile atayın ve sonucu barındıran sayfa ya da SVG belgesinde JavaScript fonksiyonunu tanımlayın.

Kararlı kimliklerde olduğu gibi, PhpJavaBridge akış modunda çalışırken geri çağırıyı bir Java yardımcı sınıfında uygulayın. [Java implementation of `SvgEventController`](/slides/tr/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) bir `ActionButton` adlı şekle bir kimlik ve bir `OnClick` işleyicisi atar. Bu yardımcıyı derleyin, köprü sınıf yoluna `com.example.slides.SvgEventController` olarak ekleyin ve PHP’den aşağıdaki gibi kullanın:

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

Ana sayfa, işleyiciye referans veren JavaScript fonksiyonunu tanımlayabilir. Kimliklerin ve olay işleyicilerin atanması, slayt görüntüleyicileri, erişilebilirlik iyileştirmeleri ve diğer etkileşimli SVG iş akışları için olanak tanır.

## **SSS**

**[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) yerine [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) ne zaman kullanılmalı?**

Tüm metnin yazı tiplerinden bağımsız olması gerektiğinde [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) kullanın. Yalnızca harici yazı tipleri kullanan metnin grafik olarak dönüştürülmesi gerektiğinde [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) kullanın.

**Bir SVG'yi daha küçük yapmak için en iyi yol nedir?**

İlk olarak gömülü resimleri sıkıştırın, kırpılmış görüntü alanlarını silin ve hedef ortam bunları sunabiliyorsa bağlanan font dosyalarını seçin. Sonucu test edin; çünkü düşük görüntü çözünürlüğü, düşük JPEG kalitesi ve vektörleştirilmiş metin her biri farklı kalite‑boyut dengeleri sunar.

**Dışa aktarılan SVG öğelerini dışa aktarımdan sonra değiştirebilir miyim?**

Evet. Bir biçimlendirme geri çağrısı aracılığıyla kimlikler atayın, ardından post‑işleme aracınızda veya tarayıcı betiğinizde eşleşen SVG öğelerini seçin.