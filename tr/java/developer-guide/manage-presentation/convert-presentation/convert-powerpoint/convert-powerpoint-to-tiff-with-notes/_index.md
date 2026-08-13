---
title: Java'da Notlu PowerPoint Sunumlarını TIFF'e Dönüştürme
linktitle: Notlu PowerPoint'ten TIFF'e
type: docs
weight: 100
url: /tr/java/convert-powerpoint-to-tiff-with-notes/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak notlu PowerPoint sunumlarını TIFF'e dönüştürün. Konuşmacı notlarıyla slaytları verimli bir şekilde dışa aktarmayı öğrenin."
---
## **Giriş**

Aspose.Slides for Java, notlarla birlikte PowerPoint ve OpenDocument sunumlarını (PPT, PPTX ve ODP) TIFF formatına dönüştürmek için basit bir çözüm sunar. Bu format, yüksek kaliteli görüntü depolama, baskı ve belge arşivleme için yaygın olarak kullanılır. Aspose.Slides ile yalnızca konuşmacı notlarıyla birlikte tüm sunumları dışa aktarmakla kalmaz, aynı zamanda Not Slayt görünümünde slayt küçük resimleri de oluşturabilirsiniz. Dönüştürme işlemi basit ve verimlidir; tüm sunumu notları ve düzeni koruyarak bir dizi TIFF görüntüsüne dönüştürmek için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının `save` yöntemini kullanır.

## **Sunumu Notlarla TIFF'e Dönüştürme**

PowerPoint veya OpenDocument sunumunu notlarla birlikte TIFF'e kaydetmek için Aspose.Slides for Java aşağıdaki adımları içerir:

1. Presentation sınıfının bir örneğini oluşturun: Bir PowerPoint veya OpenDocument dosyasını yükleyin.
1. Çıktı düzen seçeneklerini yapılandırın: Notların ve yorumların nasıl görüntüleneceğini belirlemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/notescommentslayoutingoptions/) sınıfını kullanın.
1. Sunumu TIFF olarak kaydedin: Yapılandırılmış seçenekleri [save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yöntemine geçirin.

Diyelim ki aşağıdaki slayta sahip bir "speaker_notes.pptx" dosyamız var:

![Konuşmacı notlarıyla sunum slaytı](slide_with_notes.png)

Aşağıdaki kod snippet'i, sunumu Not Slayt görünümünde TIFF görüntüsüne dönüştürmek için [setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) yönteminin nasıl kullanılacağını gösterir.

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Notları slaytın altında gösterir.

    // Not düzeniyle TIFF seçeneklerini yapılandır.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Sunumu konuşmacı notlarıyla TIFF olarak kaydeder.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Konuşmacı notlarıyla TIFF görüntüsü](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Aspose [Ücretsiz PowerPoint'den Poster Dönüştürücüsü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) inceleyin.
{{% /alert %}}

## **SSS**

### Oluşan TIFF'teki not alanının konumunu kontrol edebilir miyim?

Evet. Notların konumunu seçmek için [notes layout settings](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) içinde `None`, `BottomTruncated` veya `BottomFull` gibi seçenekleri kullanabilirsiniz; bu seçenekler sırasıyla notları gizler, tek bir sayfaya sığdırır veya ek sayfalara akmasına izin verir.

### Notlarla bir TIFF dosyasının boyutunu, kalite kaybı olmadan nasıl azaltabilirim?

Bir [verimli sıkıştırma](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) (ör. `LZW` veya `RLE`) seçin, makul bir DPI ayarlayın ve kabul edilebilirse daha düşük bir [piksel biçimi](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (ör. monokrom için 8 bpp veya 1 bpp) kullanın. [görüntü boyutları](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) değerlerini biraz azaltmak da okunabilirliği belirgin şekilde etkilemeden yardımcı olabilir.

### Sisteminizde orijinal fontlar eksikse, notlardaki font sonuçları etkiler mi?

Evet. Eksik fontlar [substitution](/slides/tr/java/font-selection-sequence/) tetikler ve bu, metin ölçümlerini ve görünümünü değiştirebilir. Bunu önlemek için [gereken fontları sağlayın](/slides/tr/java/custom-font/) veya varsayılan bir [fallback font](/slides/tr/java/fallback-font/) ayarlayarak istenen tipografilerin kullanılmasını sağlayabilirsiniz.