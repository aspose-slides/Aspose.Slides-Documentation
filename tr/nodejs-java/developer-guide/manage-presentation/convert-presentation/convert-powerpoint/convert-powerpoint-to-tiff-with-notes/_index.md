---
title: JavaScript'te Notlarla PowerPoint Sunumlarını TIFF'e Dönüştürme
linktitle: Notlarla PowerPoint'ten TIFF
type: docs
weight: 100
url: /tr/nodejs-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten TIFF'e
- sunumu TIFF'e
- slaytı TIFF'e
- PPT'yi TIFF'e
- PPTX'i TIFF'e
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak JavaScript'te notlarla PowerPoint sunumlarını TIFF'e dönüştürün. Konuşmacı notlarıyla slaytları verimli bir şekilde dışa aktarmayı öğrenin."
---
## **Giriş**

Aspose.Slides for Node.js via Java, PowerPoint ve OpenDocument sunumlarını (PPT, PPTX ve ODP) notlarıyla birlikte TIFF formatına dönüştürmek için basit bir çözüm sunar. Bu format, yüksek kaliteli görüntü depolama, baskı ve belge arşivleme için yaygın olarak kullanılır. Aspose.Slides ile yalnızca tüm sunumları konuşmacı notlarıyla dışa aktarmakla kalmaz, aynı zamanda Not Slaytı görünümünde slayt küçük resimlerini de oluşturabilirsiniz. Dönüştürme işlemi basit ve verimlidir; `save` metodunu [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının kullanarak tüm sunumu notları ve düzeni koruyan bir dizi TIFF görüntüsüne dönüştürür.

## **Sunumu Notlarla TIFF'e Dönüştürme**

PowerPoint veya OpenDocument sunumunu notlarla birlikte TIFF olarak kaydetmek, Aspose.Slides for Node.js via Java kullanarak şu adımları içerir:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfını örnekleyin: Bir PowerPoint veya OpenDocument dosyasını yükleyin.
2. Çıktı düzen seçeneklerini yapılandırın: Notların ve yorumların nasıl görüntüleneceğini belirlemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notescommentslayoutingoptions/) sınıfını kullanın.
3. Sunumu TIFF olarak kaydedin: Yapılandırılmış seçenekleri [save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) metoduna geçirin.

Örneğin aşağıdaki slaytı içeren bir "speaker_notes.pptx" dosyamız olduğunu varsayalım:

![Konuşmacı notlarıyla sunum slaytı](slide_with_notes.png)

Aşağıdaki kod parçacığı, [setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) metodunu kullanarak sunumu Not Slaytı görünümünde bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir.

```js
// Bir sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // Notları slaydın altında göster.

    // Not düzeniyle TIFF seçeneklerini yapılandırın.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Sunumu konuşmacı notlarıyla TIFF olarak kaydedin.
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Konuşmacı notlarıyla TIFF görüntüsü](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose [Ücretsiz PowerPoint'ten Poster Dönüştürücü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) ürününe göz atın.
{{% /alert %}}

## **SSS**

**Sonuç TIFF'inde not alanının konumunu kontrol edebilir miyim?**

Evet. Not düzen ayarlarını [notes layout settings](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) kullanarak `None`, `BottomTruncated` veya `BottomFull` gibi seçeneklerden birini seçebilirsiniz; bu seçenekler sırasıyla notları gizler, tek bir sayfaya sığdırır veya ek sayfalara akmasına izin verir.

**Notlarla bir TIFF dosyasının boyutunu görünür kalite kaybı olmadan nasıl azaltabilirim?**

Bir [verimli sıkıştırma](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/) (örneğin `LZW` veya `RLE`) seçin, uygun bir DPI ayarlayın ve kabul edilebilir ise daha düşük bir [piksel formatı](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/setpixelformat/) (monokrom için 8 bpp veya 1 bpp gibi) kullanın. [Görüntü boyutlarını](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/setimagesize/) hafifçe azaltmak da okunabilirliği belirgin şekilde etkilemeden yardımcı olabilir.

**Sistemde orijinal yazı tipleri eksik olduğunda notlardaki yazı tipi sonucu etkiler mi?**

Evet. Eksik yazı tipleri [yerine koyma](/slides/tr/nodejs-java/font-selection-sequence/) işlemini tetikler ve bu da metin ölçümlerini ve görünümünü değiştirebilir. Bunu önlemek için gereken yazı tiplerini [sağlayın](/slides/tr/nodejs-java/custom-font/) veya varsayılan bir [yedek yazı tipi](/slides/tr/nodejs-java/fallback-font/) belirleyin; böylece hedeflenen tipografiler kullanılır.