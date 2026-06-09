---
title: Python'da Notlarla Sunumları PDF'ye Dönüştür
linktitle: Sunumu Notlarla PDF'ye
type: docs
weight: 50
url: /tr/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint dönüştür
- OpenDocument dönüştür
- sunum dönüştür
- PPT dönüştür
- PPTX dönüştür
- ODP dönüştür
- PowerPoint'tan PDF'ye
- OpenDocument'tan PDF'ye
- sunum PDF'ye
- PPT'den PDF'ye
- PPTX'ten PDF'ye
- ODP'den PDF'ye
- konuşmacı notları
- notlu PDF
- Python
- Aspose.Slides
description: "Aspose.Slides for Python kullanarak PPT, PPTX ve ODP formatlarını notlarla PDF'ye dönüştürün. Profesyonel sunumlar için yerleşimleri ve konuşmacı notlarını koruyun."
---
## **Genel Bakış**

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla PDF formatına nasıl dönüştüreceğinizi öğreneceksiniz. Bu kılavuz gerekli adımları kapsar ve bu görevi verimli bir şekilde tamamlamanıza yardımcı olacak kod örnekleri sağlar. Makalenin sonunda aşağıdakileri yapabileceksiniz:

- PowerPoint slaytlarını konuşmacı notlarını koruyarak PDF belgelerine dönüştürme sürecini uygulayın.
- Çıktı PDF'yi, konuşmacı notlarının dahil edilmesini ve gereksinimlerinize göre biçimlendirilmesini sağlayacak şekilde özelleştirin.

## **Konuşmacı Notlarıyla PowerPoint'i PDF'ye Dönüştür**

`save` yöntemi, [Sunum](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfında PPT veya PPTX sunumunu konuşmacı notlarıyla PDF'ye dönüştürmek için kullanılabilir. Aspose.Slides ile sunumu yükler, konuşmacı notlarını dahil etmek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/notescommentslayoutingoptions/) sınıfını kullanarak yerleşim seçeneklerini yapılandırır ve ardından dosyayı PDF olarak kaydedersiniz. Aşağıdaki kod parçacığı, örnek bir sunumu Not Slaytı görünümünde PDF'ye nasıl dönüştüreceğinizi gösterir.

```py
with slides.Presentation("sample.pptx") as presentation:

    # Konuşmacı notlarını işlemek için PDF seçeneklerini yapılandır.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Sunumu konuşmacı notlarıyla PDF olarak kaydet.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="primary" %}} 
Aspose [Çevrimiçi PowerPoint PDF Dönüştürücü](https://products.aspose.app/slides/tr/conversion) aracını incelemek isteyebilirsiniz. 
{{% /alert %}}