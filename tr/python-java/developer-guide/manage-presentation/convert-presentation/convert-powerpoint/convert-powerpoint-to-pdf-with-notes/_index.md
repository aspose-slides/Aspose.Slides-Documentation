---
title: Notlu PowerPoint Sunumlarını Python ile PDF'ye Dönüştür
linktitle: PowerPoint PDF'ye Notlarla
type: docs
weight: 50
url: /tr/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten PDF'ye
- sunumdan PDF'ye
- PPT'den PDF'ye
- PPTX'ten PDF'ye
- sunumu PDF olarak kaydet
- PPT'yi PDF'ye dışa aktar
- PPTX'i PDF'ye dışa aktar
- konuşmacı notları
- notlu PDF
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PPT ve PPTX sunumlarını konuşmacı notlarıyla PDF'ye dönüştür. Not yerleşimini yapılandırın ve uzun notları koruyun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarını konuşmacı notlarıyla PDF'ye nasıl dönüştüreceğinizi açıklar. Her slaytın altına not ekleyebilir ve uzun notların ek sayfalara devam etmesine izin verebilirsiniz. Diğer PDF dışa aktarma ayarları için [Convert PowerPoint to PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/) sayfasına bakın.

Dışa aktarmadan önce not sayfası boyutlarını ve yönünü ayarlamak için [Notes Page Size](/slides/tr/python-java/notes-size/) sayfasına bakın.

## **PowerPoint'i Notlarla PDF'e Dönüştür**

PDF'ye bir PPT veya PPTX sunumunu dışa aktarmak için [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının [save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu kullanın. Konuşmacı notlarını eklemek için bir [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/) nesnesi oluşturun ve not yerleştirmesini onun [setNotesPosition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) yöntemiyle yapılandırın. Bu düzeni, [setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) kullanarak [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/) üzerine atayın.

Aşağıdaki örnek `sample.pptx` dosyasını yükler ve konuşmacı notları slaytların altında olacak şekilde `output.pdf` olarak dışa aktarır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Konuşmacı notalarını render etmek için PDF seçeneklerini yapılandır.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Sunumu konuşmacı notalarıyla PDF olarak kaydet.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Ayrıca [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/tr/conversion) aracını da deneyebilirsiniz.
{{% /alert %}}

## **SSS**

**Uzun konuşmacı notlarının kesilmesini nasıl önleyebilirim?**

Yukarıdaki örnekte olduğu gibi [NotesPositions.BottomFull](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notespositions/#BottomFull) kullanın. Bu ayar, gerektiğinde ek sayfalar kullanarak notların tamamını gösterir.

**Her slaytı ve notlarını tek bir sayfada tutabilir miyim?**

[NotesPositions.BottomTruncated](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notespositions/#BottomTruncated) kullanın. Bu ayar notları bir sayfaya sınırlar, bu yüzden sığmayan notlar kesilebilir.

**Konuşmacı notları olmadan slaytları nasıl dışa aktarırım?**

Not düzeni yapılandırmasını atlayın ve [Convert PowerPoint to PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/) sayfasında açıklanan standart PDF dışa aktarımını kullanın.