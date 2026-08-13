---
title: Notlu PowerPoint Sunumlarını C++ ile PDF'ye Dönüştür
linktitle: PowerPoint'ten Notlu PDF'ye
type: docs
weight: 50
url: /tr/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint PDF'ye
- sunum PDF'ye
- slayt PDF'ye
- PPT PDF'ye
- PPTX PDF'ye
- sunumu PDF olarak kaydet
- PPT'yi PDF olarak kaydet
- PPTX'i PDF olarak kaydet
- PPT'yi PDF'ye aktar
- PPTX'i PDF'ye aktar
- konuşmacı notları
- notlu PDF
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PPT ve PPTX formatlarını notlu PDF'ye dönüştürün. Profesyonel sunumlar için düzenleri ve konuşmacı notlarını koruyun."
---
## **Genel Bakış**

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla birlikte PDF formatına nasıl dönüştüreceğinizi öğreneceksiniz. Bu kılavuz gerekli adımları kapsar ve bu görevi verimli bir şekilde gerçekleştirmenize yardımcı olacak kod örnekleri sunar. Makalenin sonunda şunları yapabilecek duruma geleceksiniz:

- PowerPoint slaytlarını konuşmacı notlarını koruyarak PDF belgelere dönüştüren dönüşüm sürecini uygulamak.
- Çıktı PDF'yi özelleştirerek konuşmacı notlarının gereksinimlerinize göre dahil edilmesini ve biçimlendirilmesini sağlamak.

## **Konuşmacı Notlarıyla PowerPoint'i PDF'ye Dönüştür**

`Save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfında PPT veya PPTX sunumlarını konuşmacı notlarıyla birlikte PDF'ye dönüştürmek için kullanılabilir. Aspose.Slides ile yalnızca sunumu yükler, konuşmacı notlarını eklemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notescommentslayoutingoptions/) sınıfını kullanarak düzen seçeneklerini yapılandırır ve ardından dosyayı PDF olarak kaydedersiniz. Aşağıdaki kod parçacığı, örnek bir sunumu Notlar Slayt görünümünde PDF'ye nasıl dönüştüreceğinizi gösterir.

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

// Konuşmacı notlarını işlemek için PDF seçeneklerini yapılandır.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Konuşmacı notlarını slaytın altında işleyin.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Sunumu konuşmacı notlarıyla PDF'ye kaydet.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Aspose [Çevrimiçi PowerPoint'ten PDF'ye Dönüştürücü](https://products.aspose.app/slides/tr/conversion) aracını kontrol etmek isteyebilirsiniz. 
{{% /alert %}}