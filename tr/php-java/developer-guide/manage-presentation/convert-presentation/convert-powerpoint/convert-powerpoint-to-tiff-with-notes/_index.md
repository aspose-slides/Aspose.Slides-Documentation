---
title: PowerPoint Sunumlarını Notlarla TIFF'e PHP'de Dönüştürme
linktitle: PowerPoint'ten Notlarla TIFF
type: docs
weight: 100
url: /tr/php-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten TIFF'e
- sunumu TIFF'e
- slaytı TIFF'e
- PPT'den TIFF'e
- PPTX'ten TIFF'e
- PPT'yi TIFF olarak kaydet
- PPTX'i TIFF olarak kaydet
- PPT'yi TIFF'e dışa aktar
- PPTX'i TIFF'e dışa aktar
- Notlu PowerPoint
- Notlu sunum
- Notlu slayt
- Notlu PPT
- Notlu PPTX
- Notlu TIFF
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint sunumlarını notlarla TIFF'e dönüştürün. Konuşmacı notlarıyla slaytları verimli bir şekilde dışa aktarmayı öğrenin."
---
## **Giriş**

Aspose.Slides for PHP via Java, notlu PowerPoint ve OpenDocument sunumlarını (PPT, PPTX ve ODP) TIFF formatına dönüştürmek için basit bir çözüm sağlar. Bu format, yüksek kaliteli görüntü depolama, baskı ve belge arşivleme için yaygın olarak kullanılır. Aspose.Slides ile sadece konuşmacı notlarıyla birlikte tüm sunumları dışa aktarmak değil, aynı zamanda Not Slaytı görünümünde slayt küçük resimleri de oluşturabilirsiniz. Dönüştürme işlemi basit ve etkilidir; [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının `save` yöntemi kullanılarak, notlar ve düzen korunarak tüm sunum bir dizi TIFF görüntüsüne dönüştürülür.

## **Bir Sunumu Notlarla TIFF'e Dönüştürme**

Aspose.Slides for PHP via Java kullanarak bir PowerPoint veya OpenDocument sunumunu notlarla birlikte TIFF olarak kaydetmek aşağıdaki adımları içerir:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun: PowerPoint veya OpenDocument dosyasını yükleyin.  
2. Çıktı düzen seçeneklerini yapılandırın: Notların ve yorumların nasıl görüntüleneceğini belirlemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notescommentslayoutingoptions/) sınıfını kullanın.  
3. Sunumu TIFF olarak kaydedin: Yapılandırılmış seçenekleri [save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) yöntemine geçirin.

Diyelim ki aşağıdaki slaytı içeren bir "speaker_notes.pptx" dosyamız var:

![Sunum slaytı ve konuşmacı notları](slide_with_notes.png)

Aşağıdaki kod parçacığı, [setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) yöntemi kullanılarak Not Slaytı görünümünde sunumu TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir.

```php
// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturun.
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // Slaytın altında notları göster.

    // Not düzeniyle TIFF seçeneklerini yapılandırın.
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Sunumu konuşmacı notlarıyla TIFF olarak kaydedin.
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Konuşmacı notlarıyla TIFF görüntüsü](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose'un [Ücretsiz PowerPoint'ten Poster Dönüştürücü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) hizmetine göz atın.
{{% /alert %}}

## **SSS**

**Sonuç TIFF'inde not alanının konumunu kontrol edebilir miyim?**

Evet. Notların konumunu seçmek için [notes layout settings](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) kullanın; `None`, `BottomTruncated` veya `BottomFull` gibi seçenekler, notları gizleme, tek sayfaya sığdırma veya ek sayfalara akmasına izin verme gibi davranışları belirler.

**Notlarla bir TIFF dosyasının boyutunu, görünür kalite kaybı olmadan nasıl azaltabilirim?**

[efficient compression](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/setcompressiontype/) (ör. `LZW` veya `RLE`) seçin, makul bir DPI ayarlayın ve kabul edilebilir ise daha düşük bir [pixel format](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/setpixelformat/) (ör. monokrom için 8 bpp veya 1 bpp) kullanın. Ayrıca [image dimensions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/setimagesize/) değerini hafifçe küçültmek, okunabilirliği belirgin şekilde etkilemeden dosya boyutunu azaltabilir.

**Sistemde orijinal fontlar eksikse, notlardaki font sonuçları etkiler mi?**

Evet. Eksik fontlar, [substitution](/slides/tr/php-java/font-selection-sequence/) tetikler ve metin ölçüleri ile görünüm değişebilir. Bunu önlemek için [gerekli fontları sağlayın](/slides/tr/php-java/custom-font/) veya varsayılan bir [fallback font](/slides/tr/php-java/fallback-font/) ayarlayın; böylece istenen yazı tipleri kullanılabilir.