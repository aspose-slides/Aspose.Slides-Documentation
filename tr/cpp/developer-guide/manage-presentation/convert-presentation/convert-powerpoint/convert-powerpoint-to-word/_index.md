---
title: C++ ile PowerPoint Sunumlarını Word Belgelerine Dönüştürme
linktitle: PowerPoint'ten Word'e
type: docs
weight: 110
url: /tr/cpp/convert-powerpoint-to-word/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten Word'e
- sunumu Word'e
- slaytı Word'e
- PPT'yi Word'e
- PPTX'i Word'e
- PowerPoint'ten DOCX'e
- sunumu DOCX'e
- slaytı DOCX'e
- PPT'yi DOCX'e
- PPTX'i DOCX'e
- PowerPoint'ten DOC'a
- sunumu DOC'a
- slaytı DOC'a
- PPT'yi DOC'a
- PPTX'i DOC'a
- PPT'yi DOCX olarak kaydet
- PPTX'i DOCX olarak kaydet
- PPT'yi DOCX'e aktar
- PPTX'i DOCX'e aktar
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++ içinde PowerPoint PPT ve PPTX slaytlarını düzenlenebilir Word belgelerine, kesin düzen, görseller ve biçimlendirme korunarak dönüştürün."
---
## **Giriş**

Sunum (PPT veya PPTX) içindeki metinsel içeriği veya bilgiyi yeni şekillerde kullanmayı planlıyorsanız, sunumu Word (DOC veya DOCX) formatına dönüştürmek size fayda sağlayabilir. 

* Microsoft PowerPoint'e kıyasla, Microsoft Word uygulaması içerik için daha fazla araç ve işlevselliğe sahiptir. 
* Word'deki düzenleme işlevlerinin yanı sıra, geliştirilmiş işbirliği, baskı ve paylaşım özelliklerinden de yararlanabilirsiniz. 

{{% alert color="info" %}} 

Kaydıraklardaki metinsel içerikle çalışarak neler kazanabileceğinizi görmek için [**Sunumu Word'e Çevrimiçi Dönüştürücü**](https://products.aspose.app/slides/tr/conversion/ppt-to-word) deneyebilirsiniz. 

{{% /alert %}} 

## **Aspose.Slides ve Aspose.Words**

PowerPoint dosyasını (PPTX veya PPT) Word (DOCX veya DOC) formatına dönüştürmek için hem [Aspose.Slides for C++](https://products.aspose.com/slides/tr/cpp/) hem de [Aspose.Words for C++](https://products.aspose.com/words/cpp/) gerekir. 

Bağımsız bir API olarak, C++ için [Aspose.Slides](https://products.aspose.app/slides) sunumlardan metin çıkarmanıza olanak tanıyan işlevler sunar. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) gelişmiş bir belge işleme API'sidir ve uygulamaların Microsoft Word kullanmadan dosyaları oluşturmasını, değiştirmesini, dönüştürmesini, render etmesini, yazdırmasını ve belgelerle ilgili diğer görevleri yerine getirmesini sağlar. 

## **PowerPoint Sunumunu Word Belgesine Dönüştürme**

PowerPoint'i Word'e dönüştürmek için bu kod snippet'ini kullanın: 

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // slayt görüntüsünü bayt dizisi akışı olarak oluşturur
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // slaytın metinlerini ekler
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}

doc->Save(u"output.docx");
presentation->Dispose();
```

## **FAQ**

### PowerPoint ve OpenDocument sunumlarını Word belgelerine dönüştürmek için hangi bileşenlerin kurulması gerekir?

Projenize sadece [Aspose.Slides for C++](https://releases.aspose.com/slides/tr/cpp/) ve [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) ilgili paketlerini eklemeniz yeterlidir. Her iki kütüphane de bağımsız API'lar olarak çalışır ve Microsoft Office'in kurulmuş olmasına gerek yoktur.

### Tüm PowerPoint ve OpenDocument sunum formatları destekleniyor mu?

Aspose.Slides [tüm sunum formatlarını destekler](/slides/tr/cpp/supported-file-formats/), PPT, PPTX, ODP ve diğer yaygın dosya türleri dahil. Bu, Microsoft PowerPoint'in çeşitli sürümlerinde oluşturulmuş sunumlarla çalışabileceğiniz anlamına gelir.