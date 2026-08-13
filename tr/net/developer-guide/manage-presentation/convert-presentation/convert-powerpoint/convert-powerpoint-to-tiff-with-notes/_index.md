---
title: .NET'te Notlu PowerPoint Sunumlarını TIFF'e Dönüştür
linktitle: Notlu PowerPoint'ten TIFF'e
type: docs
weight: 100
url: /tr/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
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
- notlu PowerPoint
- notlu sunum
- notlu slayt
- notlu PPT
- notlu PPTX
- notlu TIFF
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint sunumlarını notlarla TIFF'e dönüştürün. Konuşmacı notlarıyla slaytları verimli bir şekilde nasıl dışa aktaracağınızı öğrenin."
---
## **Giriş**

Aspose.Slides for .NET, notlar ile birlikte PowerPoint ve OpenDocument sunumlarını (PPT, PPTX ve ODP) TIFF formatına dönüştürmek için basit bir çözüm sunar. Bu format, yüksek kaliteli görüntü depolama, baskı ve belge arşivleme için yaygın olarak kullanılır. Aspose.Slides ile yalnızca konuşmacı notlarıyla tüm sunumları dışa aktarmakla kalmaz, aynı zamanda Not Slaytı görünümünde slayt küçük resimleri de oluşturabilirsiniz. Dönüştürme işlemi basit ve etkilidir; `Save` yöntemi kullanılarak [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı, notları ve düzeni koruyarak tüm sunumu bir dizi TIFF görüntüsüne dönüştürür.

## **Sunumu Notlarla TIFF’e Dönüştürme**

Aspose.Slides for .NET kullanarak bir PowerPoint veya OpenDocument sunumunu notlarla birlikte TIFF’e kaydetmek aşağıdaki adımları içerir:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfını örnekleyin: PowerPoint veya OpenDocument dosyasını yükleyin.
1. Çıktı düzeni seçeneklerini yapılandırın: Notların ve yorumların nasıl görüntüleneceğini belirlemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/notescommentslayoutingoptions/) sınıfını kullanın.
1. Sunumu TIFF olarak kaydedin: Yapılandırılmış seçenekleri [Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/methods/save/index) yöntemine geçirin.

Diyelim ki aşağıdaki slaytı içeren bir "speaker_notes.pptx" dosyamız var:

![Konuşmacı notlarıyla sunum slaytı](slide_with_notes.png)

Aşağıdaki kod snippet’i, [SlidesLayoutOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) özelliğini kullanarak Not Slaytı görünümünde sunumu bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Bir sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Notlarla TIFF seçeneklerini yapılandırın.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Notları slaytın altında göster.
        }
    };

    // Sunumu konuşmacı notlarıyla birlikte TIFF olarak kaydedin.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Sonuç:

![Konuşmacı notlarıyla TIFF görüntüsü](TIFF_with_notes.png)

{{% alert title="İpucu" color="info" %}}

Aspose [Ücretsiz PowerPoint'ten Afiş Dönüştürücü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) sitesine göz atın.

{{% /alert %}}

## **SSS**

### Oluşan TIFF içinde not alanının konumunu kontrol edebilir miyim?

Evet. Notların konumunu belirlemek için [notes layout settings](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) üzerinden `None`, `BottomTruncated` veya `BottomFull` gibi seçenekleri kullanabilirsiniz; bu seçenekler sırasıyla notları gizler, tek bir sayfaya sığdırır veya ek sayfalara akmasına izin verir.

### Görünür kalite kaybı olmadan not içeren bir TIFF dosyasının boyutunu nasıl küçültebilirim?

[Efficient compression](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/compressiontype/) (ör. `LZW` veya `RLE`) seçin, makul bir DPI değeri ayarlayın ve kabul edilebiliyorsa daha düşük bir [pixel format](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/pixelformat/) (ör. monokrom için 8 bpp veya 1 bpp) kullanın. [Image dimensions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/imagesize/) biraz küçültülmesi de okunabilirliği belirgin etkilemeden yardımcı olabilir.

### Notlardaki yazı tipi, sistemde orijinal yazı tipleri eksikse sonucu etkiler mi?

Evet. Eksik yazı tipleri [substitution](/slides/tr/net/font-selection-sequence/) tetikleyerek metin ölçüleri ve görünümünü değiştirebilir. Bunun önüne geçmek için gerekli yazı tiplerini [supply the required fonts](/slides/tr/net/custom-font/) sağlayın veya varsayılan bir [fallback font](/slides/tr/net/fallback-font/) ayarlayarak istenen tipografinin kullanılmasını garantileyin.