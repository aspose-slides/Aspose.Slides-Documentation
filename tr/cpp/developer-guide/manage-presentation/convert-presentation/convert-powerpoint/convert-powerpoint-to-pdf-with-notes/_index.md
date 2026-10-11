---
title: PowerPoint Sunumlarını Notlarla PDF'e Dönüştürme C++
linktitle: Notlarla PowerPoint'ten PDF'e
type: docs
weight: 50
url: /tr/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten PDF'e
- sunumdan PDF'e
- slayttan PDF'e
- PPT'den PDF'e
- PPTX'ten PDF'e
- sunumu PDF olarak kaydet
- PPT'yi PDF olarak kaydet
- PPTX'i PDF olarak kaydet
- PPT'yi PDF'e dışa aktar
- PPTX'i PDF'e dışa aktar
- konuşmacı notları
- notlu PDF
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PPT ve PPTX formatlarını notlarla PDF'e dönüştürün. Profesyonel sunumlar için düzenleri ve konuşmacı notlarını koruyun."
---
## **Genel Bakış**

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla PDF formatına nasıl dönüştüreceğinizi öğreneceksiniz. Bu kılavuz gerekli adımları kapsar ve bu görevi verimli bir şekilde gerçekleştirmenize yardımcı olacak kod örnekleri sunar. Makalenin sonunda şu yeteneklere sahip olacaksınız:

- Konuşmacı notlarını koruyarak PowerPoint slaytlarını PDF belgelerine dönüştürme sürecini uygulamak.
- Çıktı PDF'sini, konuşmacı notlarının dahil edildiğinden ve gereksinimlerinize göre biçimlendirildiğinden emin olacak şekilde özelleştirmek.

Dışa aktarmadan önce not sayfası boyutlarını ve yönünü ayarlamak için [Notes Page Size](/slides/tr/cpp/notes-size/) adresine bakın.

## **PowerPoint'i Notlarla PDF'e Dönüştür**

`Save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfında bir PPT veya PPTX sunumunu konuşmacı notlarıyla PDF'e dönüştürmek için kullanılabilir. Aspose.Slides ile yalnızca sunumu yükler, konuşmacı notlarını eklemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notescommentslayoutingoptions/) sınıfını kullanarak düzen seçeneklerini yapılandırır ve ardından dosyayı PDF olarak kaydedersiniz. Aşağıdaki kod parçacığı, örnek bir sunumun Not Slaytı görünümünde PDF'e nasıl dönüştürüleceğini gösterir.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Configure PDF options for rendering speaker notes.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Konuşmacı notlarını slaytın altında görüntüle.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/tr/conversion) adresine göz atmak isteyebilirsiniz.
{{% /alert %}}