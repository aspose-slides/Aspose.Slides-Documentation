---
title: PHP'de Sunum Mürekkep Nesnelerini Yönetme
linktitle: Mürekkebi Yönet
type: docs
weight: 95
url: /tr/php-java/manage-ink/
keywords:
- mürekkep
- mürekkep nesnesi
- mürekkep izi
- mürekkebi yönet
- mürekkep çiz
- çizim
- mürekkep dışa aktarımı
- mürekkep işleme
- mürekkebi gizle
- InkOptions
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "PowerPoint mürekkep nesnelerini yönetin, izleri ve fırça özelliklerini düzenleyin ve PDF, HTML, SVG, TIFF ve görüntü ihracı sırasında mürekkep görünümünü Aspose.Slides for PHP via Java ile kontrol edin."
---
## **Giriş**

PowerPoint, serbest çizgiler çizmenizi sağlayan bir mürekkep özelliği sunar. Mürekkep, diğer nesneleri vurgulamak, bağlantı ve süreçleri göstermek ve bir slayttaki belirli öğelere dikkat çekmek için kullanılabilir.

Aspose.Slides, mürekkep nesneleriyle çalışmak için gereken türleri sağlar. Örneğin, [Ink](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ink/) sınıfı bir slayttaki mürekkep nesnesini temsil eder.

## **Düzenli Nesneler ve Mürekkep Nesneleri Arasındaki Farklar**

PowerPoint bir slayttaki nesneler genellikle [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) nesneleriyle temsil edilir. En basit biçimde bir şekil, nesnenin kendisinin (çerçevesinin) alanını tanımlayan ve konteyner boyutu, şekil ve arka plan gibi özellikleri içeren bir kapsayıcıdır. Daha fazla bilgi için [Shape Layout Format](https://docs.aspose.com/slides/tr/php-java/shape-manipulations/#access-layout-formats-for-shape) bölümüne bakın.

Bununla birlikte, PowerPoint bir mürekkep nesnesiyle karşılaştığında, nesne çerçevesinin (kapsayıcının) tüm özelliklerini boyutu haricinde görmezden gelir. Kapsayıcı alanının boyutu, standart [Shape.getWidth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getWidth) ve [Shape.getHeight](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getHeight) metodlarıyla belirlenir:

![ink_powerpoint1](ink_powerpoint1.png)

## **Mürekkep İzleri**

Bir mürekkep izi, bir kalemin dijital mürekkep yazarken izlediği yörüngeyi kaydetmek için kullanılan temel bir öğedir. Bir iz, bağlantılı noktalar dizisini saklar.

Kodlamanın en basit biçimi, her örnek noktanın X ve Y koordinatlarını belirtir. Tüm bağlantılı noktalar çizildiğinde aşağıdaki gibi bir görüntü oluşur:

![ink_powerpoint2](ink_powerpoint2.png)

## **Çizim İçin Fırça Özellikleri**

Bir fırça, bir mürekkep izinin noktalarını birleştiren çizgileri çizmek için kullanılır. Fırçanın kendi rengi ve boyutu vardır; bunlar [InkBrush.getColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/inkbrush/#getColor) ve [InkBrush.getSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/inkbrush/#getSize) metodlarıyla temsil edilir.

### **Mürekkep Fırçası Rengini Ayarlama**

Bu PHP kodu, bir mürekkep fırçasının renginin nasıl ayarlanacağını gösterir:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **Mürekkep Fırçası Boyutunu Ayarlama**

Bu PHP kodu, bir mürekkep fırçasının boyutunun nasıl ayarlanacağını gösterir:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

Genel olarak, bir fırçanın genişliği ve yüksekliği eşleşmez, bu yüzden PowerPoint fırça boyutunu göstermez (ilgili veri bölümü gri renktedir). Fırça genişliği ve yüksekliği eşleştiğinde, PowerPoint boyutu şu şekilde gösterir:

![ink_powerpoint3](ink_powerpoint3.png)

Açıklık kazanması için, mürekkep nesnesinin yüksekliğini artırıp önemli boyutları gözden geçirelim:

![ink_powerpoint4](ink_powerpoint4.png)

Kapsayıcı (çerçeve), fırçaların boyutunu dikkate almaz—her zaman çizgi kalınlığının sıfır olduğunu varsayar (önceki görsele bakın).

Bu nedenle, tüm mürekkep nesnesinin görünen alanını belirlemek için izlerinin fırça boyutu hesaba katılmalıdır. Burada, hedef nesne (el yazısı metin izi) kapsayıcının (çerçevenin) boyutuna ölçeklendirilmiştir. Kapsayıcının boyutu değiştiğinde fırça boyutu sabit kalır ve tersine de aynı şey geçerlidir.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint, metin nesneleri için benzer bir davranış sergiler:

![ink_powerpoint6](ink_powerpoint6.png)

## **Dışa Aktarım ve İşleme Sırasında Mürekkep Görünümünü Kontrol Etme**

Aspose.Slides, mürekkep nesnelerinin dışa aktarılan veya işlenen çıktıda nasıl görüneceğini kontrol etmek için [InkOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/inkoptions/) sınıfını sunar. Özelliklerini kullanarak mürekkebi tamamen gizleyebilir veya mürekkep fırça maske işlemlerinin nasıl yorumlandığını değiştirebilirsiniz.

Mürekkep seçenekleri, çeşitli çıktı türleri için dışa aktarma veya işleme seçenekleri aracılığıyla kullanılabilir:

| Çıktı | Mürekkep seçenekleri özelliği |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slayt resmi | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/renderingoptions/#getInkOptions) |

Aşağıdaki [InkOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/inkoptions/) metodları aynı iki ayarı sunar:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/tr/php-java/aspose.slides/inkoptions/#getHideInk) mürekkep nesnelerinin çıktıya dahil edilip edilmediğini belirler. Varsayılan değeri `false`tır.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) bir maske işleminin, bir mürekkep fırçası işlenirken opaklık olarak yorumlanıp yorumlanmayacağını belirler. Varsayılan değeri `true`dır; bunun yerine ROP işlemini kullanmak için `false` ile [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) çağırın.

### **PDF Çıktısında Mürekkep Nesnelerini Gizleme**

Varsayılan olarak, mürekkep nesneleri dışa aktarım sırasında görünür kalır. El yazısı açıklamalar veya diğer mürekkep içerikleri olmadan temiz bir çıktı oluşturmak için [InkOptions.setHideInk](https://reference.aspose.com/slides/tr/php-java/aspose.slides/inkoptions/#setHideInk) metodunu `true` değeriyle çağırın.

Aşağıdaki PHP örneği, tüm mürekkep nesnelerini gizleyerek bir sunumu PDF olarak dışa aktarır:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Slaytı Görüntü Olarak İşlerken Mürekkep Nesnelerini Gizleme**

Slaytları bitmap görüntüler olarak işlerken mürekkep nesnelerini gizlemek için [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/renderingoptions/#getInkOptions) yapılandırın ve işleme seçeneklerini [Slide.getImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getImage) metoduna aktarın.

Aşağıdaki PHP örneği, ilk slaytı mürekkep nesneleri olmadan bir PNG görüntüsü olarak işler:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **Mürekkep Maske İşlemesini Kontrol Etme**

[InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) ayarı, mürekkep fırçaları işlenirken maske işlemlerinin nasıl yorumlanacağını kontrol eder. Varsayılan değer `true` olup opaklık kullanır. Bunun yerine ROP işlemini kullanmak için `false` ile [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) çağırın.

Aşağıdaki PHP örneği, bir slaytı SVG olarak dışa aktarır ve mürekkep maske işlemleri için ROP tabanlı işleme kullanır:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Aynı ayar, bir sunumu dışa aktarırken veya bir slaytı TIFF olarak işlerken [TiffOptions.getInkOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/#getInkOptions) aracılığıyla da uygulanabilir.

### **Mürekkebi Gizleme veya Korumayı Seçme**

İncelemeler olmadan dağıtım için anotasyonlu bir sunumun temiz bir sürümüne ihtiyacınız olduğunda, dışa aktarım sırasında [InkOptions.setHideInk](https://reference.aspose.com/slides/tr/php-java/aspose.slides/inkoptions/#setHideInk) metodunu `true` ile çağırın.

Mürekkep açıklamaları, el notları, vurgulamalar veya çizimler gibi hedef içeriğin bir parçası olduğunda, [InkOptions.getHideInk](https://reference.aspose.com/slides/tr/php-java/aspose.slides/inkoptions/#getHideInk) varsayılan `false` değerinde bırakın. Bu, uygulamaların aynı sunumdan kaynak mürekkep nesnelerini değiştirmeden ayrı inceleme ve final çıktıları üretmesine olanak tanır.

## **SSS**

**Mevcut bir mürekkep çizgisinin rengini veya boyutunu değiştirebilir miyim?**

Evet. [Ink.getTraces](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ink/#getTraces) ile izleri alın, ardından [InkTrace.getBrush](https://reference.aspose.com/slides/tr/php-java/aspose.slides/inktrace/#getBrush) metodunu değiştirin. Rengi değiştirmek için [InkBrush.setColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/inkbrush/#setColor), boyutu değiştirmek için ise [InkBrush.setSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/inkbrush/#setSize) metodunu kullanın.

**Mürekkebi gizlemek kaynak sunumu değiştirir mi?**

Hayır. [InkOptions.setHideInk](https://reference.aspose.com/slides/tr/php-java/aspose.slides/inkoptions/#setHideInk) yalnızca işlenen veya dışa aktarılan sonucu etkiler; kaynak sunumdaki mürekkep nesnelerini kaldırmaz veya değiştirmez.

**Hangi dışa aktarım formatları mürekkep seçeneklerini destekler?**

Yukarıda gösterilen ilgili dışa aktarma veya işleme seçenekleri aracılığıyla PDF, HTML, SVG, TIFF ve bitmap slayt görüntüleri için mürekkep seçeneklerini yapılandırabilirsiniz.

**Daha fazla okuma**

* Şekiller hakkında genel bilgi için [PowerPoint Shapes](https://docs.aspose.com/slides/tr/php-java/powerpoint-shapes/) bölümüne bakın.
* Etkili değerler hakkında daha fazla bilgi için [Shape Effective Properties](https://docs.aspose.com/slides/tr/php-java/shape-effective-properties/#get-effective-font-height-value) bölümünü inceleyin.
* PDF dışa aktarımı hakkında ayrıntılar için [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/tr/php-java/convert-powerpoint-to-pdf/) sayfasını okuyun.
* HTML dışa aktarımı hakkında ayrıntılar için [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/tr/php-java/convert-powerpoint-to-html/) sayfasına göz atın.
* SVG dışa aktarımı hakkında ayrıntılar için [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/tr/php-java/render-a-slide-as-an-svg-image/) bölümünü inceleyin.
* TIFF dışa aktarımı hakkında ayrıntılar için [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/tr/php-java/convert-powerpoint-to-tiff/) bölümüne bakın.
* Slaytı görsele dönüştürme hakkında ayrıntılar için [Convert Presentation Slides to Images](https://docs.aspose.com/slides/tr/php-java/convert-slide/) sayfasını ziyaret edin.