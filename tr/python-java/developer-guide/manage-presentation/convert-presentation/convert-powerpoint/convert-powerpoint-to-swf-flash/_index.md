---
title: Python üzerinden Java ile PowerPoint Sunumlarını SWF Flash'e Dönüştür
linktitle: PowerPoint'ten SWF'ye
type: docs
weight: 80
url: /tr/python-java/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten SWF'ye
- sunumdan SWF'ye
- slayttan SWF'ye
- PPT'den SWF'ye
- PPTX'ten SWF'ye
- PowerPoint'ten Flash'a
- sunumdan Flash'a
- slayttan Flash'a
- PPT'den Flash'a
- PPTX'ten Flash'a
- PPT'yi SWF olarak kaydet
- PPTX'i SWF olarak kaydet
- PPT'yi SWF'ye aktar
- PPTX'i SWF'ye aktar
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides ile Python üzerinden Java kullanarak PowerPoint sunumlarını SWF Flash'a dönüştürün. Görüntüleyiciyi, notları, gizli slaytları, sıkıştırmayı ve fontları yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, Microsoft PowerPoint olmadan PowerPoint sunumlarını SWF formatına dönüştürmenizi sağlar. Sunumu dışa aktarmak için [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) ve görüntü ayarlarını, görüntü kalitesini ve notlar ya da yorumların düzenini yapılandırmak için [SwfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/swfoptions/) kullanın.

## **Sunumları Flash'e Dönüştür**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) ile yükleyin, [SwfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/swfoptions/) yapılandırın ve [SaveFormat.Swf](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Swf) kullanarak kaydedin.

Aşağıdaki örnek `presentation.pptx` dosyasını `presentation.swf` olarak dışa aktarır. Gömülü görüntüleyiciyi [setViewerIncluded](https://reference.aspose.com/slides/tr/python-java/aspose.slides/swfoptions/#setViewerIncluded) ile devre dışı bırakır ve slaytların altına konuşmacı notlarını eklemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/) kullanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

Örneği çalıştırmadan önce, [install Aspose.Slides for Python via Java](/slides/tr/python-java/installation/) işlemini yapın ve `presentation.pptx` dosyasını çalışma dizinine koyun. JVM, her Python işlemi başına bir kez başlatılır.

Örnek, [setNotesPosition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) aracılığıyla [NotesPositions.BottomFull](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notespositions/#BottomFull) uygular ve düzeni [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions) aracılığıyla iletir. Yorumları da dahil etmek için dışa aktarmadan önce [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) yapılandırın.

## **SSS**

**SWF'de gizli slaytları dahil edebilir miyim?**

Evet. [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) metodunu `True` ile çağırın. Varsayılan olarak gizli slaytlar dışa aktarılmaz.

**Sıkıştırmayı ve son SWF boyutunu nasıl kontrol edebilirim?**

[SwfOptions.setCompressed](https://reference.aspose.com/slides/tr/python-java/aspose.slides/swfoptions/#setCompressed) kullanarak sıkıştırmayı etkinleştirebilir veya devre dışı bırakabilirsiniz ve JPEG görüntü kalitesini ayarlamak için [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/tr/python-java/aspose.slides/swfoptions/#setJpegQuality) kullanın. Daha düşük JPEG kalitesi, görüntü doğruluğu pahasına dosya boyutunu azaltabilir.

**Gömülü görüntüleyici ne için kullanılır ve ne zaman devre dışı bırakılmalıdır?**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/tr/python-java/aspose.slides/swfoptions/#setViewerIncluded), oluşturulan SWF'nin görüntüleyici içerip içermeyeceğini kontrol eder. Yukarıdaki örnekte olduğu gibi, gömülü görüntüleyici olmadan dışa aktarılan slaytlara ihtiyacınız olduğunda `False` geçirin.

**Dışa aktarma makinesinde kaynak font eksikse ne olur?**

[setDefaultRegularFont](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) kullanarak varsayılan bir normal font belirtebilirsiniz; bu ayar [SwfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/swfoptions/) tarafından devralınır. Dışa aktarma sürecinde mevcut bir font seçin; font ikamesi metin görünümünü ve düzenini değiştirebilir.