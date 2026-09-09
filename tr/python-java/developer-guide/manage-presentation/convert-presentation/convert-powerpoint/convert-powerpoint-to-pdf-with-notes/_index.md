---
title: Python'da Notlarla PowerPoint Sunumlarını PDF'ye Dönüştür
linktitle: Notlarla PowerPoint PDF'ye Dönüştür
type: docs
weight: 50
url: /tr/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint PDF'ye
- sunumu PDF'ye
- PPT PDF'ye
- PPTX PDF'ye
- sunumu PDF olarak kaydet
- PPT'yi PDF'ye dışa aktar
- PPTX'i PDF'ye dışa aktar
- konuşmacı notları
- notlu PDF
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PPT ve PPTX sunumlarını konuşmacı notlarıyla PDF'ye dönüştürün. Not yerleşimini yapılandırın ve uzun notları koruyun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarını konuşmacı notlarıyla PDF'ye dönüştürmeyi açıklar. Her slaydın altına not ekleyebilir ve uzun notların ek sayfalara devam etmesine izin verebilirsiniz. Diğer PDF dışa aktarma ayarları için [Convert PowerPoint to PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/) sayfasına bakın.

## **PowerPoint'i Notlarla PDF'ye Dönüştür**

[save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemini, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir PPT veya PPTX sunumunu PDF'ye dışa aktarmak için kullanın. Konuşmacı notlarını eklemek için bir [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/) nesnesi oluşturun ve not yerleşimini [setNotesPosition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) yöntemiyle yapılandırın. Bu yerleşimi [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/) içinde [setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) kullanarak atayın.

İlgili örnek `sample.pptx` dosyasını yükler ve slaytların altına konuşmacı notları ekleyerek `output.pdf` olarak dışa aktarır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Konuşmacı notlarını işlemek için PDF seçeneklerini yapılandır.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Konuşmacı notlarıyla sunumu PDF'ye kaydet.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Not" %}}
Ayrıca [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/tr/conversion) aracını da deneyebilirsiniz.
{{% /alert %}}

## **SSS**

**Uzun konuşmacı notlarının kesilmesini nasıl önleyebilirim?**

[NotesPositions.BottomFull](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notespositions/#BottomFull) kullanın, yukarıdaki örnekteki gibi. Bu ayar, gerektiğinde ek sayfalar kullanarak tam notları gösterir.

**Her slaytı ve notlarını tek bir sayfada tutabilir miyim?**

[NotesPositions.BottomTruncated](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notespositions/#BottomTruncated) kullanın. Bu ayar notları bir sayfaya sınırlar, bu nedenle sığmayan notlar kırpılabilir.

**Konuşmacı notları olmadan slaytları nasıl dışa aktarabilirim?**

Not yerleşim yapılandırmasını atlayın ve [Convert PowerPoint to PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/) sayfasında açıklanan standart PDF dışa aktarmayı kullanın.