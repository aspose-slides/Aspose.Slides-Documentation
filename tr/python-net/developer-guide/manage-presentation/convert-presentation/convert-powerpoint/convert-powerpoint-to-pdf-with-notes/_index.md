---
title: Python ile Notlu PDF'e Sunum Dönüştürme
linktitle: Sunumdan Notlu PDF'e
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
- PowerPoint'tan PDF'e
- OpenDocument'tan PDF'e
- sunumdan PDF'e
- PPT'den PDF'e
- PPTX'ten PDF'e
- ODP'den PDF'e
- konuşmacı notları
- notlu PDF
- Python
- Aspose.Slides
description: "Aspose.Slides for Python kullanarak PPT, PPTX ve ODP formatlarını notlu PDF'e dönüştürün. Profesyonel sunumlar için düzenleri ve konuşmacı notlarını koruyun."
---
## **Genel Bakış**

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla PDF formatına dönüştürmeyi öğreneceksiniz. Bu kılavuz gerekli adımları kapsar ve bu görevi verimli bir şekilde gerçekleştirmenize yardımcı olacak kod örnekleri sunar. Makalenin sonunda, aşağıdakileri yapabileceksiniz:

- Konuşmacı notlarını koruyarak PowerPoint slaytlarını PDF belgelerine dönüştürme sürecini uygulayın.
- Çıktı PDF'yi, konuşmacı notlarının dahil edildiği ve gereksinimlerinize göre biçimlendirildiği şekilde özelleştirin.

Not sayfası boyutu ve yönünü dışa aktarmadan önce ayarlamak için, [Not Sayfası Boyutu](/slides/tr/python-net/notes-size/) bölümüne bakın.

## **PowerPoint'i Notlu PDF'e Dönüştürme**

`save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfında, bir PPT veya PPTX sunumunu konuşmacı notlarıyla PDF'e dönüştürmek için kullanılabilir. Aspose.Slides ile sunumu sadece yükleyip, [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/notescommentslayoutingoptions/) sınıfını kullanarak konuşmacı notlarını dahil edecek şekilde düzenleme seçeneklerini yapılandırır ve ardından dosyayı PDF olarak kaydedersiniz. Aşağıdaki kod parçacığı, örnek bir sunumu Not Slaytı görünümünde PDF'e nasıl dönüştüreceğinizi gösterir.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # Konuşmacı notlarını oluşturmak için PDF seçeneklerini yapılandır.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Sunumu konuşmacı notlarıyla PDF olarak kaydet.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Note" %}}
Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/tr/conversion) adresini inceleyebilirsiniz.
{{% /alert %}}