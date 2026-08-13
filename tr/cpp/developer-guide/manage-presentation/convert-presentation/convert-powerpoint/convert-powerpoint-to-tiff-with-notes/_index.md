---
title: PowerPoint Sunumlarını Notlarla TIFF'e C++ ile Dönüştürme
linktitle: PowerPoint'ten Notlarla TIFF'e
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
description: "Aspose.Slides for C++ kullanarak PowerPoint sunumlarını notlarla birlikte TIFF'e dönüştürün. Konuşmacı notlarıyla slaytları verimli bir şekilde dışa aktarmayı öğrenin."
---
## **Giriş**

Aspose.Slides for C++ PowerPoint ve OpenDocument sunumlarını (PPT, PPTX ve ODP) notlarla birlikte TIFF formatına dönüştürmek için basit bir çözüm sunar. Bu format yüksek kaliteli görüntü depolama, yazdırma ve belge arşivleme için yaygın olarak kullanılır. Aspose.Slides ile yalnızca konuşmacı notları içeren tüm sunumları dışa aktarmakla kalmaz, aynı zamanda Not Slaytı görünümünde slayt küçük resimleri de oluşturabilirsiniz. Dönüştürme süreci basit ve etkilidir; tüm sunumu notları ve düzeni koruyarak bir dizi TIFF görüntüsüne dönüştürmek için [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının `Save` metodunu kullanır.

## **Sunumu Notlarla TIFF'e Dönüştürme**

PowerPoint veya OpenDocument sunumunu notlarla birlikte TIFF formatına kaydetmek için Aspose.Slides for C++ aşağıdaki adımları içerir:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun: PowerPoint veya OpenDocument dosyasını yükleyin.
2. Çıktı düzen seçeneklerini yapılandırın: Notların ve yorumların nasıl gösterileceğini belirlemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notescommentslayoutingoptions/) sınıfını kullanın.
3. Sunumu TIFF olarak kaydedin: Yapılandırılmış seçenekleri [Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) metoduna iletin.

Diyelim ki aşağıdaki slaytı içeren bir "speaker_notes.pptx" dosyamız var:

![Konuşmacı notları içeren sunum slaytı](slide_with_notes.png)

Aşağıdaki kod parçacığı, [set_SlidesLayoutOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) metodunu kullanarak sunumu Not Slaytı görünümünde bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Sunum dosyasını temsil eden Presentation sınıfını örnekle.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Notları slaytın altında göster.

// Configure the TIFF options with Notes layouting.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to TIFF with the speaker notes.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Sonuç:

![Konuşmacı notları içeren TIFF görüntüsü](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Aspose [Ücretsiz PowerPoint'ten Poster Dönüştürücü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) ürününe göz atın.
{{% /alert %}}

## **SSS**

### Oluşturulan TIFF içinde not alanının konumunu kontrol edebilir miyim?

Evet. Notların düzen ayarlarını ([notes layout settings](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/)) kullanarak `None`, `BottomTruncated` veya `BottomFull` gibi seçeneklerden birini seçebilirsiniz; bu seçenekler sırasıyla notları gizler, tek bir sayfaya sığdırır veya ek sayfalara akmasına izin verir.

### Notlarla bir TIFF dosyasının boyutunu kalite kaybı olmadan nasıl azaltabilirim?

Verimli bir sıkıştırma ([efficient compression](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)) seçin (ör. `LZW` veya `RLE`), makul bir DPI ayarlayın ve kabul edilebilir ise daha düşük bir [pixel format](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (ör. monokrom için 8 bpp veya 1 bpp) kullanın. [image dimensions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_imagesize/) biraz azaltmak da okunabilirliği belirgin şekilde etkilemeden yardımcı olabilir.

### Notlardaki yazı tipi, sistemde orijinal yazı tipleri eksikse sonucu etkiler mi?

Evet. Eksik yazı tipleri [substitution](/slides/tr/cpp/font-selection-sequence/) tetikler ve bu da metin ölçümlerini ve görünümünü değiştirebilir. Bunu önlemek için [gerekli yazı tiplerini sağlayın](/slides/tr/cpp/custom-font/) veya varsayılan bir [fallback font](/slides/tr/cpp/fallback-font/) belirleyerek istenen yazı tiplerinin kullanılmasını sağlayın.