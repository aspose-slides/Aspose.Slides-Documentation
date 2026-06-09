---
title: Notlarla PowerPoint Sunumlarını C++ ile TIFF'e Dönüştürme
linktitle: Notlarla PowerPoint'ten TIFF'e
type: docs
weight: 100
url: /tr/cpp/convert-powerpoint-to-tiff-with-notes/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint sunumlarını notlarla TIFF'e dönüştürün. Konuşmacı notlarıyla slaytları verimli bir şekilde dışa aktarmayı öğrenin."
---
## **Giriş**

Aspose.Slides for C++ sunum notlarıyla PowerPoint ve OpenDocument sunumlarını (PPT, PPTX ve ODP) TIFF formatına dönüştürmek için basit bir çözüm sunar. Bu format, yüksek kaliteli görüntü depolama, baskı ve belge arşivleme için yaygın olarak kullanılır. Aspose.Slides ile yalnızca sunum notlarıyla bütün sunumları dışa aktarmakla kalmaz, aynı zamanda Not Slaytı görünümünde slayt küçük resimlerini de oluşturabilirsiniz. Dönüştürme işlemi basit ve etkilidir; `Save` yöntemi [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının tüm sunumu notları ve düzeni koruyarak bir dizi TIFF görüntüsüne dönüştürmek için kullanılır.

## **Sunumu Notlarla TIFF'e Dönüştürme**

Aspose.Slides for C++ kullanarak bir PowerPoint veya OpenDocument sunumunu notlarla birlikte TIFF'e kaydetmek aşağıdaki adımları içerir:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun: PowerPoint veya OpenDocument dosyasını yükleyin.  
1. Çıkış düzeni seçeneklerini yapılandırın: Notların ve yorumların nasıl gösterileceğini belirlemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notescommentslayoutingoptions/) sınıfını kullanın.  
1. Sunumu TIFF olarak kaydedin: Yapılandırılmış seçenekleri [Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) yöntemine iletin.

Diyelim ki aşağıdaki slayta sahip bir **speaker_notes.pptx** dosyamız var:

![Sunum slaytı ve konuşmacı notları](slide_with_notes.png)

Aşağıdaki kod örneği, [set_SlidesLayoutOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) yöntemini kullanarak sunumu Not Slaytı görünümünde bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir.

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Notları slaytın altında göster.

// Not yerleşimiyle TIFF seçeneklerini yapılandırın.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Sunumu konuşmacı notlarıyla TIFF olarak kaydedin.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Sonuç:

![TIFF görüntüsü ve konuşmacı notları](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose'un [Ücretsiz PowerPoint'ten Poster Dönüştürücü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) hizmetine göz atın.
{{% /alert %}}

## **SSS**

**Son TIFF'teki not bölgesinin konumunu kontrol edebilir miyim?**

Evet. Notların konumunu seçmek için [notes layout settings](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) kullanın; `None`, `BottomTruncated` veya `BottomFull` gibi seçenekler notları gizlemeyi, tek bir sayfaya sığdırmayı veya ek sayfalara akmasını sağlar.

**Notlarla birlikte bir TIFF dosyasının boyutunu kalite kaybı olmadan nasıl küçültebilirim?**

Verimli bir sıkıştırma türü seçin ([efficient compression](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_compressiontype/); ör. `LZW` veya `RLE`), makul bir DPI ayarlayın ve kabul edilebilirse daha düşük bir [pixel format](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (ör. 8 bpp veya monokrom için 1 bpp) kullanın. Görüntü boyutlarını biraz küçültmek ([image dimensions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_imagesize/)) da okunabilirliği belirgin şekilde etkilemeden yardımcı olabilir.

**Orijinal yazı tipleri sistemde eksikse, notlardaki yazı tipi sonuca etkiler mi?**

Evet. Eksik yazı tipleri [substitution](/slides/tr/cpp/font-selection-sequence/) tetikleyerek metin ölçümlerini ve görünümünü değiştirebilir. Bunu önlemek için gerekli yazı tiplerini [supply the required fonts](/slides/tr/cpp/custom-font/) sağlayın veya varsayılan bir [fallback font](/slides/tr/cpp/fallback-font/) ayarlayarak istenen tipografi kullanılmasını sağlayın.