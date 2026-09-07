---
title: PowerPoint Sunumlarını Notlarla Python'da TIFF'e Dönüştürme
linktitle: PowerPoint'ten Notlu TIFF
type: docs
weight: 100
url: /tr/python-java/convert-powerpoint-to-tiff-with-notes/
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
- notlu PowerPoint
- notlu sunum
- notlu slayt
- notlu PPT
- notlu PPTX
- notlu TIFF
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarını notlarla TIFF'e dönüştürün. Konuşmacı notlarıyla slaytları verimli bir şekilde dışa aktarmayı öğrenin."
---
## **Giriş**

Aspose.Slides for Python via Java, notlarıyla birlikte PowerPoint ve OpenDocument sunumlarını (PPT, PPTX ve ODP) TIFF biçimine dönüştürmek için basit bir çözüm sunar. Bu biçim, yüksek kalitede görüntü depolama, baskı ve belge arşivleme için yaygın olarak kullanılır. Slaytları ve konuşmacı notlarını tek bir çok sayfalı TIFF dosyasına dışa aktarmak için [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının [save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu kullanın.

## **Notlarla Bir Sunumu TIFF'e Dönüştürme**

Aspose.Slides for Python via Java kullanarak bir PowerPoint veya OpenDocument sunumunu notlarla birlikte TIFF'e kaydetmek aşağıdaki adımları içerir:

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun: PowerPoint veya OpenDocument dosyasını yükleyin.
1. Çıktı düzeni seçeneklerini yapılandırın: Notların ve yorumların nasıl görüntüleneceğini belirlemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/) sınıfını kullanın.
1. Sunumu TIFF olarak kaydedin: Yapılandırılmış seçenekleri [save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metoduna aktarın.

Diyelim ki aşağıdaki slaytı içeren bir "speaker_notes.pptx" dosyamız var:

![Konuşmacı notlarıyla sunum slaytı](slide_with_notes.png)

Aşağıdaki kod parçacığı, [setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) metodunu kullanarak sunumu Notlar Slayt görünümünde bir TIFF görüntüsüne nasıl dönüştüreceğini gösterir.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # Her slaytın altında tam konuşmacı notlarını göster.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # TIFF çözünürlüğünü ve not düzenini yapılandır.
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # Sunumu konuşmacı notlarıyla TIFF olarak kaydet.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Sonuç:

![Konuşmacı notlarıyla TIFF görüntüsü](TIFF_with_notes.png)

{{% alert title="İpucu" color="success" %}}
Aspose'un [Ücretsiz PowerPoint Poster Dönüştürücüsü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) incelenebilir.
{{% /alert %}}

## **FAQ**

**Çıktı TIFF'indeki notlar alanının konumunu kontrol edebilir miyim?**

Evet. Notları tek sayfaya sığdırmak ve gerekirse kesmek için [setNotesPosition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) metodunu [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notespositions/#BottomTruncated) ile, gerektiğinde ek sayfalar kullanarak tüm notları göstermek için ise [NotesPositions.BottomFull](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notespositions/#BottomFull) ile yapılandırın. Notlarsız slaytları dışa aktarmak için, [Convert PowerPoint to TIFF](/slides/tr/python-java/convert-powerpoint-to-tiff/) bölümünde gösterildiği gibi not düzeni yapılandırmasını atlayın.

**Notlu bir TIFF dosyasının boyutunu görüntü kalitesini kaybetmeden nasıl küçültebilirim?**

[setCompressionType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffoptions/#setCompressionType) yöntemiyle [LZW compression](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffcompressiontypes/#LZW) gibi kayıpsız sıkıştırma kullanın. Çözünürlüğü veya renk derinliğini düşürmek dosya boyutunu daha da azaltabilir, ancak görüntü kalitesini ve notların okunabilirliğini etkileyebilir. Daha fazla seçenek için [TIFF export settings](/slides/tr/python-java/convert-powerpoint-to-tiff/) bölümüne bakın.

**Orijinal fontlar sistemde eksik olduğunda notlardaki yazı tipi sonucu etkiler mi?**

Evet. Eksik fontlar [font substitution](/slides/tr/python-java/font-selection-sequence/) tetikleyerek metin ölçüleri ve görünümünü değiştirebilir. İstenen fontları [Supply the required fonts](/slides/tr/python-java/custom-font/) ekleyerek planlanan yazı tiplerini koruyabilirsiniz.