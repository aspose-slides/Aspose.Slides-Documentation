---
title: "PowerPoint Sunumlarını Notlarla Python'da PDF'e Dönüştür"
linktitle: "PowerPoint'ten Notlu PDF"
type: docs
weight: 50
url: /tr/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- "PowerPoint dönüştür"
- "sunumu dönüştür"
- "PPT dönüştür"
- "PPTX dönüştür"
- "PowerPoint'ten PDF'e"
- "sunumu PDF'e"
- "PPT'den PDF'e"
- "PPTX'ten PDF'e"
- "sunumu PDF olarak kaydet"
- "PPT'yi PDF'e dışa aktar"
- "PPTX'i PDF'e dışa aktar"
- "konuşmacı notları"
- "notlu PDF"
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PPT ve PPTX sunumlarını konuşmacı notlarıyla PDF'e dönüştürün. Not yerleşimini yapılandırın ve uzun notları koruyun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarını konuşmacı notlarıyla PDF'e nasıl dönüştüreceğinizi açıklar. Her slaytın altına not ekleyebilir ve uzun notların ek sayfalara devam etmesini sağlayabilirsiniz. Diğer PDF dışa aktarma ayarları için [PowerPoint'i PDF'e Dönüştür](/slides/tr/python-java/convert-powerpoint-to-pdf/) bölümüne bakın.

## **Konuşmacı Notlarıyla PowerPoint'i PDF'e Dönüştürme**

[Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının [save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemini kullanarak bir PPT veya PPTX sunumunu PDF olarak dışa aktarın. Konuşmacı notlarını eklemek için bir [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/) nesnesi oluşturup onun [setNotesPosition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) metodunu yapılandırın. Bu yerleşimi, [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/) sınıfına [setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) yöntemiyle atayın.

Aşağıdaki örnek, `sample.pptx` dosyasını yükler ve slaytların altına konuşmacı notları ekleyerek `output.pdf` olarak dışa aktarır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Konuşmacı notlarını render etmek için PDF seçeneklerini yapılandır.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Sunumu konuşmacı notlarıyla PDF olarak kaydet.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Not" %}}
Ayrıca [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/tr/conversion) aracını deneyebilirsiniz.
{{% /alert %}}

## **SSS**

**Uzun konuşmacı notlarının kesilmesini nasıl önleyebilirim?**

Yukarıdaki örnekte olduğu gibi [NotesPositions.BottomFull](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notespositions/#BottomFull) kullanın. Bu ayar, gerektiğinde ek sayfalar kullanarak tam notların gösterilmesini sağlar.

**Her slaytı ve notlarını tek bir sayfada tutabilir miyim?**

[NotesPositions.BottomTruncated](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notespositions/#BottomTruncated) kullanın. Bu ayar notları bir sayfaya sınırlayarak sığmayan notların kesilmesine yol açar.

**Konuşmacı notları olmadan slaytları nasıl dışa aktarırım?**

Not yerleşim yapılandırmasını atlayıp, [PowerPoint'i PDF'e Dönüştür](/slides/tr/python-java/convert-powerpoint-to-pdf/) bölümünde açıklanan standart PDF dışa aktarma yöntemini kullanın.