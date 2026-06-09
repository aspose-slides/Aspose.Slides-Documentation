---
title: PowerPoint Sunumlarını Notlarla PDF'ye Dönüştür (C++)
linktitle: PowerPoint'ten Notlarla PDF
type: docs
weight: 50
url: /tr/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten PDF'ye
- sunumu PDF'ye
- slaytı PDF'ye
- PPT'den PDF'ye
- PPTX'den PDF'ye
- sunumu PDF olarak kaydet
- PPT'yi PDF olarak kaydet
- PPTX'i PDF olarak kaydet
- PPT'yi PDF'ye dışa aktar
- PPTX'i PDF'ye dışa aktar
- konuşmacı notları
- notlu PDF
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PPT ve PPTX formatlarını notlarla PDF'ye dönüştürün. Profesyonel sunumlar için düzenleri ve konuşmacı notlarını koruyun."
---
## **Genel Bakış**

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla PDF formatına nasıl dönüştüreceğinizi öğreneceksiniz. Bu kılavuz gerekli adımları kapsar ve bu görevi etkin bir şekilde tamamlamanıza yardımcı olacak kod örnekleri sunar. Makalenin sonunda şunları yapabilecek duruma geleceksiniz:

- Konuşmacı notlarını koruyarak PowerPoint slaytlarını PDF belgelerine dönüştürme sürecini uygulamak.
- Konuşmacı notlarının dahil edildiğinden ve gereksinimlerinize göre biçimlendirildiğinden emin olmak için çıktı PDF'yi özelleştirmek.

## **Notlarla PowerPoint'i PDF'ye Dönüştür**

`Save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfında, PPT veya PPTX sunumunu konuşmacı notlarıyla PDF'ye dönüştürmek için kullanılabilir. Aspose.Slides ile sadece sunumu yüklersiniz, konuşmacı notlarını eklemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notescommentslayoutingoptions/) sınıfını kullanarak düzen seçeneklerini yapılandırırsınız ve ardından dosyayı PDF olarak kaydedersiniz. Aşağıdaki kod parçacığı, örnek bir sunumu Notlu Slayt görünümünde PDF'ye nasıl dönüştüreceğinizi gösterir.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Konuşmacı notlarını renderlemek için PDF seçeneklerini yapılandır.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Konuşmacı notlarını slaytın altına renderle.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Sunumu konuşmacı notlarıyla PDF'ye kaydet.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="primary" %}} 
Aspose [Online PowerPoint to PDF Dönüştürücü](https://products.aspose.app/slides/tr/conversion)'nü kontrol etmek isteyebilirsiniz. 
{{% /alert %}}