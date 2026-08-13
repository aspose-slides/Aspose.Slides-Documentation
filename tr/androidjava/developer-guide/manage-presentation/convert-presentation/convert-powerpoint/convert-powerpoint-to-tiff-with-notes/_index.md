---
title: PowerPoint Sunumlarını Android'de Notlarla TIFF'e Dönüştür
linktitle: PowerPoint'ten Notlarla TIFF'e
type: docs
weight: 100
url: /tr/androidjava/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten TIFF'e
- sunumdan TIFF'e
- slayttan TIFF'e
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint sunumlarını notlarla TIFF'e dönüştürün. Konuşmacı notlarıyla slaytları verimli bir şekilde dışa aktarmayı öğrenin."
---
## **Giriş**

Aspose.Slides for Android via Java, PowerPoint ve OpenDocument sunumlarını (PPT, PPTX ve ODP) notlarla birlikte TIFF formatına dönüştürmek için basit bir çözüm sunar. Bu format, yüksek kaliteli görüntü depolama, baskı ve belge arşivleme için yaygın olarak kullanılır. Aspose.Slides ile yalnızca tüm sunumları konuşmacı notlarıyla dışa aktarmakla kalmaz, aynı zamanda Notlar Slaytı görünümünde slayt küçük resimleri de oluşturabilirsiniz. Dönüştürme işlemi basit ve etkilidir; `save` yöntemiyle [Sunum](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfını kullanarak tüm sunumu notları ve yerleşimi koruyarak bir dizi TIFF görüntüsüne dönüştürür.

## **Sunumu Notlarla TIFF'e Dönüştürme**

PowerPoint veya OpenDocument bir sunumu notlarla birlikte TIFF formatına kaydetmek, Aspose.Slides for Android via Java kullanarak aşağıdaki adımları içerir:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfını örnekleyin: Bir PowerPoint veya OpenDocument dosyasını yükleyin.
1. Çıktı yerleşim seçeneklerini yapılandırın: Notların ve yorumların nasıl görüntüleneceğini belirlemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notescommentslayoutingoptions/) sınıfını kullanın.
1. Sunumu TIFF olarak kaydedin: Yapılandırılmış seçenekleri [save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yöntemine geçirin.

Diyelim ki aşağıdaki slaytı içeren bir "speaker_notes.pptx" dosyamız var:

![Sunum slaytı konuşmacı notlarıyla](slide_with_notes.png)

Aşağıdaki kod parçacığı, [setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) yöntemini kullanarak sunumu Notlar Slaytı görünümünde bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir.

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Notları slaytın altında göster.

    // Not yerleşimiyle TIFF seçeneklerini yapılandır.
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

{{% alert title="Tip" color="info" %}}
Aspose [Ücretsiz PowerPoint'ten Poster Dönüştürücü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) adresine göz atın.
{{% /alert %}}

## **SSS**

### Not alanının konumunu sonuç TIFF içinde kontrol edebilir miyim?

Evet. Not yerleşim ayarlarını ([notes layout settings](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)) kullanarak `None`, `BottomTruncated` veya `BottomFull` gibi seçeneklerden birini seçebilirsiniz; bu seçenekler sırasıyla notları gizler, tek sayfaya sığdırır veya ek sayfalara akmasına izin verir.

### Notlarla birlikte bir TIFF dosyasının boyutunu görünür kalite kaybı olmadan nasıl azaltabilirim?

[Verimli sıkıştırma](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (ör. `LZW` veya `RLE`) seçin, makul bir DPI ayarlayın ve kabul edilebilirse daha düşük bir [piksel formatı](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (ör. 8 bpp veya monokrom için 1 bpp) kullanın. [Görüntü boyutlarını](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) hafifçe azaltmak da okunurluğa dikkate değer bir zarar vermeden yardımcı olabilir.

### Orijinal yazı tipleri sistemde bulunamadığında notlardaki yazı tipi sonuca etkiler mi?

Evet. Eksik yazı tipleri [yerine koyma](/slides/tr/androidjava/font-selection-sequence/) yolunu tetikler ve bu da metin ölçümleri ve görünümünü değiştirebilir. Bunu önlemek için gerekli yazı tiplerini [sağlayın](/slides/tr/androidjava/custom-font/) veya varsayılan bir [yedek yazı tipi](/slides/tr/androidjava/fallback-font/) ayarlayın, böylece amaçlanan tipografiler kullanılır.