---
title: PowerPoint Slaytlarını PHP'de PNG'ye Dönüştür
linktitle: PowerPoint'ten PNG'ye
type: docs
weight: 30
url: /tr/php-java/convert-powerpoint-to-png/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten PNG'ye
- sunumu PNG'ye
- slaytı PNG'ye
- PPT'yi PNG'ye
- PPTX'i PNG'ye
- PPT'yi PNG olarak kaydet
- PPTX'i PNG olarak kaydet
- PPT'yi PNG'ye dışa aktar
- PPTX'i PNG'ye dışa aktar
- PHP
- Aspose.Slides
description: "PowerPoint sunumlarını yüksek kaliteli PNG görüntülerine, Java üzerinden PHP için Aspose.Slides ile hızlı bir şekilde dönüştürerek kesin ve otomatik sonuçlar elde edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for PHP via Java kullanarak sunum slaytlarını PNG görüntülerine nasıl dönüştüreceğinizi açıklar. PPT, PPTX ve ODP gibi biçimlerde sunumları yükleyebilir, her slaytı renderleyebilir ve ayrı bir PNG görüntüsü olarak kaydedebilirsiniz.

Aşağıdaki örnekler, varsayılan ölçekte renderleme, ölçeği artırma, çıktı boyutlarını piksel olarak belirtme ve bir gradient renderleme stilini seçme işlemlerini gösterir.

## **PowerPoint'i PNG'ye Dönüştür**

Bir sunumu, [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfını kullanarak yükleyin ve slaytlarına [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) koleksiyonu aracılığıyla erişin. Örnek, her slaytı parametre olmadan [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) ile renderleyerek bir küçük resim oluşturur. Ardından, her renderlenmiş slaytı PNG görüntüsü olarak kaydetmek için [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) metodunu [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) ile çağırır.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Parametresiz [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) aşırı yüklemesi 0,2 ölçekle renderler. Örneğin, 720 × 540 puan ölçüsündeki bir slayt 144 × 108 piksel bir küçük resim üretir. Çıktı boyutlarını kontrol etmek için, aşağıda gösterildiği gibi ölçek faktörleriyle veya açık bir görüntü boyutuyla aşırı yüklemeleri kullanın.
{{% /alert %}}

## **PowerPoint'i Özel Boyutlarla PNG'ye Dönüştür**

Renderlenen boyutları kontrol etmek için yatar ve dikey ölçek faktörlerini [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) metoduna geçirin. Bu örnekte her iki faktör de 2'dir, bu yüzden 720 Г— 540 puan ölçüsündeki bir slayt 1440 Г— 1080 piksel bir görüntü üretir. Eşit ölçek faktörleri slaytın en‑boy oranını korur. Her görüntü, [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) ile PNG formatında kaydedilir.
```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **PowerPoint'i Özel Boyutta PNG'ye Dönüştür**

Piksel cinsinden çıktı boyutlarını belirtmek için ölçek faktörleri yerine bir boyut değerini [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) metoduna geçirin. Bu örnek, her slaytı 960 Г— 720 piksel olarak renderler ve sonucu [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) ile kaydeder. Görüntünün gerilmesini önlemek için slaytın en‑boy oranına uygun boyutları seçin.
```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Bir Gradient Renderleme Stili Seçin**

Bir slayt gradient dolgular içeriyorsa ve dışa aktarılan PNG'deki geçişler PowerPoint'te gördüklerinizden daha açık ya da farklı görünüyorsa, [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) sınıfının devraldığı [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) metodunu kullanarak gradientlerin nasıl renderleneceğini seçebilirsiniz.

[gradient-styles.pptx](gradient-styles.pptx) dosyasını indirin ve uygulamanın çalışma dizinine koyun. İlk slaytı, üstte camgöbeğinden turuncuya ve altta maviden sarıya iki lineer gradient içerir. Her gradient iki durak noktasına sahiptir: %0 ve %100.

Aşağıdaki örnek bu sunumu yükler ve aynı ilk slaytı her iki modda da [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) ile renderler.
```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Aşağıdaki görüntüler aynı slayttan çıkan çıktıyı, her görüntüde iki gradient ile gösterir:

| Default | PowerPointUI |
| --- | --- |
| ![Varsayılan ile renderlenen camgöbeği‑turuncu ve mavi‑sarı gradientler](gradient-Default.png) | ![PowerPointUI ile renderlenen aynı gradientler](gradient-PowerPointUI.png) |

Bu örnekte, `Default` daha açık ara renkler üretirken, `PowerPointUI` daha koyu ara renkler üretir. Fark, gradient içindeki renkler ve durak noktasına bağlıdır.

`Default` stilini, standart Aspose.Slides çıktısı ihtiyaçlarınıza uygun olduğunda seçin. PowerPoint'teki görünümle eşleşme önceliğinizse `PowerPointUI` stilini deneyin. Her iki çıktıyı da beklediğiniz sonuçla karşılaştırın; hiçbir mod tüm durumlar için evrensel olarak tercih edilemez.

## **SSS**

**Bir grafik veya resim gibi belirli bir şekli, tüm slayt yerine nasıl dışa aktarabilirim?**

Aspose.Slides, [tek tek şekiller için küçük resimler oluşturmayı](/slides/tr/php-java/create-shape-thumbnails/) destekler; böylece bir şekli PNG görüntüsü olarak renderleyebilirsiniz.

**Sunucuda paralel dönüşüm destekleniyor mu?**

Evet. Her iş parçacığı veya süreç için ayrı bir sunum örneği kullanın; [tek bir örneği iş parçacıkları arasında paylaşmayın](/slides/tr/php-java/multithreading/).

**PNG olarak dışa aktarırken değerlendirme sınırlamaları nelerdir?**

Değerlendirme modu, çıktı görüntülerine bir filigran ekler ve lisans uygulanana kadar [diğer kısıtlamaları](/slides/tr/php-java/licensing/) uygular.