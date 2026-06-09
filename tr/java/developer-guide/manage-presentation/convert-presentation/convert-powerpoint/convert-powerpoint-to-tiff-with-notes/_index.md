---
title: Java'da Notlarla PowerPoint Sunumlarını TIFF'e Dönüştürme
linktitle: PowerPoint'ten Notlarla TIFF'e
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
description: "Aspose.Slides for Java kullanarak PowerPoint sunumlarını notlarla TIFF'e dönüştürün. Konuşmacı notlarıyla slaytları verimli bir şekilde dışa aktarmayı öğrenin."
---
## **Giriş**

Aspose.Slides for Java, PowerPoint ve OpenDocument sunumlarını (PPT, PPTX ve ODP) notlarla birlikte TIFF formatına dönüştürmek için basit bir çözüm sunar. Bu format yüksek kaliteli görüntü depolama, baskı ve belge arşivleme amacıyla yaygın olarak kullanılır. Aspose.Slides ile sadece tüm sunumları konuşmacı notlarıyla dışa aktarmakla kalmaz, aynı zamanda Not Slaytı görünümünde slayt küçük resimlerini de oluşturabilirsiniz. Dönüştürme süreci basit ve etkilidir; `save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı kullanılarak tüm sunumu notları ve düzeni koruyan bir dizi TIFF görüntüsüne dönüştürür.

## **Bir Sunumu Notlarla TIFF'e Dönüştürme**

Aspose.Slides for Java kullanarak bir PowerPoint veya OpenDocument sunumunu notlarla birlikte TIFF'e kaydetmek aşağıdaki adımları içerir:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfını örnekleyin: bir PowerPoint veya OpenDocument dosyasını yükleyin.  
1. Çıktı düzeni seçeneklerini yapılandırın: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/notescommentslayoutingoptions/) sınıfını kullanarak notların ve yorumların nasıl görüntüleneceğini belirleyin.  
1. Sunumu TIFF olarak kaydedin: yapılandırılmış seçenekleri [save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yöntemine geçirin.

Diyelim ki aşağıdaki slaytı içeren bir "speaker_notes.pptx" dosyamız var:

![The presentation slide with speaker notes](slide_with_notes.png)

Aşağıdaki kod örneği, [setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) yöntemini kullanarak Not Slaytı görünümünde sunumu bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir.

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Notları slayın altında göster.

    // Not düzeni ile TIFF seçeneklerini yapılandır.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Sunumu konuşmacı notlarıyla TIFF olarak kaydet.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Aspose [Ücretsiz PowerPoint'ten Poster Dönüştürücü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) sitesine göz atın.

{{% /alert %}}

## **SSS**

**Çıktı TIFF'te not alanının konumunu kontrol edebilir miyim?**

Evet. [notes layout settings](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) kullanarak `None`, `BottomTruncated` veya `BottomFull` gibi seçenekler arasından seçim yapabilirsiniz; bu seçenekler sırasıyla notları gizler, tek bir sayfaya sığdırır veya ek sayfalara akmasına izin verir.

**Notlarla bir TIFF dosyasının boyutunu, görünür kalite kaybı olmadan nasıl küçültebilirim?**

[efficient compression](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) (ör. `LZW` veya `RLE`) seçin, makul bir DPI ayarlayın ve kabul edilebiliyorsa daha düşük bir [pixel format](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (ör. 8 bpp veya monokrom için 1 bpp) kullanın. [image dimensions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) değerlerini hafifçe azaltmak da okunabilirliği belirgin bir şekilde etkilemeden faydalı olabilir.

**Orijinal yazı tipleri sistemde eksik olduğunda notların yazı tipi sonucu etkiler mi?**

Evet. Eksik yazı tipleri [substitution](/slides/tr/java/font-selection-sequence/) tetikler ve bu da metin metriklerini ve görünümünü değiştirebilir. Bunu önlemek için [gerekli yazı tiplerini sağlayın](/slides/tr/java/custom-font/) veya varsayılan bir [fallback font](/slides/tr/java/fallback-font/) ayarlayın ki istenen tipografiler kullanılsın.