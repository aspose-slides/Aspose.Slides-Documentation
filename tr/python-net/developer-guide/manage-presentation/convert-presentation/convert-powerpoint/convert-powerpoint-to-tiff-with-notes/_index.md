---
title: Python'da Notlarla PowerPoint Sunumlarını TIFF'ye Dönüştürme
linktitle: Notlarla PowerPoint'ten TIFF
type: docs
weight: 100
url: /tr/python-net/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint dönüştürme
- sunum dönüştürme
- slayt dönüştürme
- PPT dönüştürme
- PPTX dönüştürme
- PowerPoint'ten TIFF'ye
- sunumdan TIFF'ye
- slayttan TIFF'ye
- PPT'den TIFF'ye
- PPTX'ten TIFF'ye
- Notlu PowerPoint
- Notlu sunum
- Notlu slayt
- Notlu PPT
- Notlu PPTX
- Notlu TIFF
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint sunumlarını notlarla TIFF'ye dönüştürün. Konuşmacı notlarıyla slaytları verimli bir şekilde dışa aktarmayı öğrenin."
---
## **Giriş**

Aspose.Slides for Python via .NET, not notetli PowerPoint ve OpenDocument sunumlarını (PPT, PPTX ve ODP) TIFF formatına dönüştürmek için basit bir çözüm sunar. Bu format, yüksek kaliteli görüntü depolama, baskı ve belge arşivleme için yaygın olarak kullanılır. Aspose.Slides ile yalnızca tüm sunumları konuşmacı notlarıyla dışa aktarmakla kalmaz, aynı zamanda Not Slayt görünümünde slayt küçük resimlerini de oluşturabilirsiniz. Dönüştürme işlemi basit ve etkilidir; tüm sunumu notlar ve düzeni koruyarak bir dizi TIFF görüntüsüne dönüştürmek için [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının `save` metodunu kullanır.

## **Sunumu Notlarla TIFF'ye Dönüştürme**

PowerPoint veya OpenDocument sunumunu notlarla TIFF'ye kaydetmek, Aspose.Slides for Python via .NET kullanarak aşağıdaki adımları içerir:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun: bir PowerPoint veya OpenDocument dosyasını yükleyin.
2. Çıktı düzeni seçeneklerini yapılandırın: notların ve yorumların nasıl görüntüleneceğini belirlemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/notescommentslayoutingoptions/) sınıfını kullanın.
3. Sunumu TIFF olarak kaydedin: yapılandırılmış seçenekleri [save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions) metoduna iletin.

Örneğin, aşağıdaki slaytı içeren "speaker_notes.pptx" dosyamız olduğunu varsayalım:

![Konuşmacı notlarıyla sunum slaytı](slide_with_notes.png)

Aşağıdaki kod parçacığı, [slides_layout_options](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) özelliğini kullanarak sunumu Not Slayt görünümünde bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir.

```py
# Sunum dosyasını temsil eden Presentation sınıfını oluştur.
with slides.Presentation("speaker_notes.pptx") as presentation:
    
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL  # Notları slaytın altında görüntüle.
    
    # Not düzeni ile TIFF seçeneklerini yapılandır.
    tiff_options = slides.export.TiffOptions()
    tiff_options.dpi_x = 300
    tiff_options.dpi_y = 300
    tiff_options.slides_layout_options = notes_options
    
    # Sunumu konuşmacı notlarıyla TIFF olarak kaydet.
    presentation.save("TIFF_with_notes.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

Sonuç:

![Konuşmacı notlarıyla TIFF görüntüsü](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose [Ücretsiz PowerPoint Poster Dönüştürücü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **SSS**

**Sonuç TIFF'inde not alanının konumunu kontrol edebilir miyim?**

Evet. Notların düzen ayarlarını kullanarak `NONE`, `BOTTOM_TRUNCATED` veya `BOTTOM_FULL` gibi seçeneklerden birini seçebilirsiniz; bunlar sırasıyla notları gizler, bir sayfaya sığdırır veya ek sayfalara akmasına izin verir.

**Notlarla bir TIFF dosyasının boyutunu görüntü kalitesinde belirgin bir kayıp olmadan nasıl azaltabilirim?**

Verimli bir sıkıştırma (ör. `LZW` veya `RLE`) seçin, makul bir DPI belirleyin ve kabul edilebilirse daha düşük bir [pixel format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/pixel_format/) (monokrom için 8 bpp veya 1 bpp gibi) kullanın. [image dimensions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/image_size/) (görsel boyutlarını) hafifçe azaltmak da okunabilirliği belirgin şekilde etkilemeden yardımcı olabilir.

**Sistemde orijinal yazı tipleri bulunmadığında notlardaki yazı tipi sonuçları etkiler mi?**

Evet. Eksik yazı tipleri [substitution](/slides/tr/python-net/font-selection-sequence/) (yerine koyma) tetikler ve bu metin ölçüleri ile görünümünü değiştirebilir. Bunu önlemek için [gerekli yazı tiplerini sağlayın](/slides/tr/python-net/custom-font/) veya varsayılan bir [fallback font](/slides/tr/python-net/fallback-font/) ayarlayın, böylece istenen fontlar kullanılır.