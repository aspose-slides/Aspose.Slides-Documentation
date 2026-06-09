---
title: PowerPoint Sunumlarını Android'de Notlarla TIFF'ye Dönüştür
linktitle: PowerPoint'ten Notlu TIFF'ye
type: docs
weight: 100
url: /tr/androidjava/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten TIFF'ye
- sunumdan TIFF'ye
- slayttan TIFF'ye
- PPT'den TIFF'ye
- PPTX'den TIFF'ye
- PPT'yi TIFF olarak kaydet
- PPTX'yi TIFF olarak kaydet
- PPT'yi TIFF'ye dışa aktar
- PPTX'yi TIFF'ye dışa aktar
- Notlu PowerPoint
- Notlu sunum
- Notlu slayt
- Notlu PPT
- Notlu PPTX
- Notlu TIFF
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint sunumlarını notlarla birlikte TIFF'ye dönüştürün. Konuşmacı notlarıyla slaytları verimli bir şekilde dışa aktarmayı öğrenin."
---
## **Giriş**

Aspose.Slides for Android via Java, not not... PowerPoint ve OpenDocument sunumlarını (PPT, PPTX ve ODP) notlarla birlikte TIFF formatına dönüştürmek için basit bir çözüm sunar. Bu format, yüksek kaliteli görüntü depolama, baskı ve belge arşivleme için yaygın olarak kullanılır. Aspose.Slides ile yalnızca konuşmacı notlarıyla birlikte tüm sunumları dışa aktarmakla kalmaz, aynı zamanda Not Slaytı görünümünde slayt küçük resimleri de oluşturabilirsiniz. Dönüştürme süreci basit ve etkilidir; `save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının tüm sunumu bir dizi TIFF görüntüsüne dönüştürürken notları ve düzeni korur.

## **Bir Sunumu Notlarla TIFF’ye Dönüştürme**

PowerPoint veya OpenDocument bir sunumu notlarla birlikte TIFF’ye kaydetmek, Aspose.Slides for Android via Java ile aşağıdaki adımları içerir:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun: PowerPoint veya OpenDocument dosyasını yükleyin.  
2. Çıktı düzen seçeneklerini yapılandırın: Notların ve yorumların nasıl görüntüleneceğini belirtmek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notescommentslayoutingoptions/) sınıfını kullanın.  
3. Sunumu TIFF olarak kaydedin: Yapılandırılmış seçenekleri [save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yöntemine iletin.

Diyelim ki aşağıdaki slaytı içeren bir **speaker_notes.pptx** dosyamız var:

![Konuşmacı notlarıyla sunum slaytı](slide_with_notes.png)

Aşağıdaki kod parçacığı, [setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) yöntemi kullanılarak sunumu Not Slaytı görünümünde bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir.

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekle.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Notları slaytın altında göster.

    // Not yerleşimi ile TIFF seçeneklerini yapılandır.
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

![Konuşmacı notlarıyla TIFF görüntüsü](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) 'ı inceleyin.
{{% /alert %}}

## **FAQ**

**Son elde edilen TIFF'de not alanının konumunu kontrol edebilir miyim?**

Evet. Notların nasıl yerleştirileceğini seçmek için [notes layout settings](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) kullanın; `None`, `BottomTruncated` veya `BottomFull` gibi seçeneklerden birini seçebilirsiniz. Bu seçenekler sırasıyla notları gizler, tek bir sayfaya sığdırır veya ek sayfalara akmasına izin verir.

**Notlarla TIFF dosyasının boyutunu kalite kaybı olmadan nasıl küçültebilirim?**

Verimli bir sıkıştırma türü ([efficient compression](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-)) seçin (ör. `LZW` veya `RLE`), makul bir DPI ayarlayın ve kabul edilebiliyorsa daha düşük bir [pixel format](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (ör. 8 bpp veya monokrom için 1 bpp) kullanın. Görüntü [boyutlarını](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) hafifçe küçültmek de okunabilirliği belirgin olarak etkilemeden dosya boyutunu azaltabilir.

**Sistemde orijinal yazı tipleri eksikse, notlardaki yazı tipi sonuca etkiler mi?**

Evet. Eksik yazı tipleri [substitution](/slides/tr/androidjava/font-selection-sequence/) tetikler ve bu da metin ölçülerini ve görünümünü değiştirebilir. Bunu önlemek için gerekli yazı tiplerini [supply the required fonts](/slides/tr/androidjava/custom-font/) sağlayın veya varsayılan bir [fallback font](/slides/tr/androidjava/fallback-font/) ayarlayın; böylece istenen tipografiler kullanılabilir.