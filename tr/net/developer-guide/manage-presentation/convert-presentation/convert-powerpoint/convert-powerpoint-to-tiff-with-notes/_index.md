---
title: Notlarla PowerPoint Sunumlarını .NET'te TIFF'e Dönüştürme
linktitle: PowerPoint'ten Notlarla TIFF'e
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
- sunumu TIFF'e
- slaytı TIFF'e
- PPT'den TIFF'e
- PPTX'den TIFF'e
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint sunumlarını notlarla TIFF'e dönüştürün. Slaytları konuşmacı notlarıyla verimli bir şekilde dışa aktarmayı öğrenin."
---
## **Giriş**

Aspose.Slides for .NET, notlu PowerPoint ve OpenDocument sunumlarını (PPT, PPTX ve ODP) TIFF formatına dönüştürmek için basit bir çözüm sunar. Bu format, yüksek kaliteli görüntü depolama, baskı ve belge arşivleme için yaygın olarak kullanılır. Aspose.Slides ile yalnızca tamamen notlu sunumları dışa aktarmakla kalmaz, aynı zamanda Not Slaytı görünümünde slayt küçük resimleri de oluşturabilirsiniz. Dönüştürme işlemi, tüm sunumu notları ve düzeni koruyarak bir dizi TIFF görüntüsüne dönüştüren `Save` metodunu kullanan [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı sayesinde basit ve etkilidir.

## **Sunumu Notlarla TIFF'e Dönüştürme**

PowerPoint veya OpenDocument bir sunumu notlarla TIFF olarak kaydetmek Aspose.Slides for .NET ile aşağıdaki adımları içerir:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının örneğini oluşturun: PowerPoint veya OpenDocument dosyasını yükleyin.  
2. Çıktı düzeni seçeneklerini yapılandırın: Notların ve yorumların nasıl görüntüleneceğini belirtmek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/notescommentslayoutingoptions/) sınıfını kullanın.  
3. Sunumu TIFF olarak kaydedin: Yapılandırılmış seçenekleri [Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/methods/save/index) metoduna geçirin.

Diyelim ki aşağıdaki slaytı içeren bir "speaker_notes.pptx" dosyamız var:

![Sunum slaytı notlarla](slide_with_notes.png)

```c#
// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Not düzeniyle TIFF seçeneklerini yapılandır.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Notları slaytın altında göster.
        }
    };

    // Sunumu konuşmacı notlarıyla TIFF olarak kaydet.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Sonuç:

![Notlu TIFF görüntüsü](TIFF_with_notes.png)

{{% alert title="İpucu" color="primary" %}}
Aspose'in [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) hizmetine bir göz atın.
{{% /alert %}}

## **SSS**

**Not alanının sonuç TIFF içindeki konumunu kontrol edebilir miyim?**

Evet. Notların konumunu seçmek için [notes layout settings](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) üzerinden `None`, `BottomTruncated` veya `BottomFull` gibi seçenekleri kullanabilirsiniz; bu seçenekler sırasıyla notları gizler, tek bir sayfaya sığdırır veya ek sayfalara akmasına izin verir.

**Görünür kalite kaybı olmadan notlu bir TIFF dosyasının boyutunu nasıl küçültebilirim?**

[Efficient compression](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/compressiontype/) (ör. `LZW` veya `RLE`), makul bir DPI değeri ve kabul edilebilir ise daha düşük bir [pixel format](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/pixelformat/) (ör. monokrom için 8 bpp veya 1 bpp) seçin. Ayrıca [image dimensions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/imagesize/) değerini hafifçe azaltmak, okunabilirliği belirgin şekilde etkilemeden boyutu düşürmeye yardımcı olabilir.

**Orijinal fontlar sistemde eksik olduğunda notlardaki font sonuçları etkiler mi?**

Evet. Eksik fontlar [substitution](/slides/tr/net/font-selection-sequence/) işlemini tetikleyerek metin ölçüleri ve görünümünü değiştirebilir. Bunu önlemek için gerekli fontları [supply the required fonts](/slides/tr/net/custom-font/) sağlayın veya varsayılan bir [fallback font](/slides/tr/net/fallback-font/) ayarlayarak istenen tipografların kullanılmasını garanti edin.