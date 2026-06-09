---
title: PowerPoint Sunumlarını C++'ta Word Belgelerine Dönüştürme
linktitle: PowerPoint'tan Word'e
type: docs
weight: 110
url: /tr/cpp/convert-powerpoint-to-word/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'tan Word'e
- sunumu Word'e
- slaytı Word'e
- PPT'yi Word'e
- PPTX'i Word'e
- PowerPoint'tan DOCX'e
- sunumu DOCX'e
- slaytı DOCX'e
- PPT'yi DOCX'e
- PPTX'i DOCX'e
- PowerPoint'tan DOC'a
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
description: Aspose.Slides kullanarak, PowerPoint PPT ve PPTX slaytlarını C++'ta düzenlenebilir Word belgelerine, kesin düzen, görseller ve biçimlendirme korunarak dönüştürün.
---
## **Giriş**

Bir sunumdan (PPT veya PPTX) metin içeriği veya bilgi kullanmayı yeni şekillerde planlıyorsanız, sunumu Word'e (DOC veya DOCX) dönüştürmekten fayda sağlayabilirsiniz.

* Microsoft PowerPoint ile karşılaştırıldığında, Microsoft Word uygulaması içerik için daha fazla araç ve işlevselliğe sahiptir.
* Word'deki düzenleme işlevlerinin yanı sıra, geliştirilmiş işbirliği, yazdırma ve paylaşım özelliklerinden de faydalanabilirsiniz.

{{% alert color="primary" %}} 

Kaydıraklardaki metin içeriğiyle çalışmaktan neler elde edebileceğinizi görmek için [**Sunumu Word'e Çeviren Çevrimiçi Dönüştürücü**](https://products.aspose.app/slides/tr/conversion/ppt-to-word) denemek isteyebilirsiniz.

{{% /alert %}} 

## **Aspose.Slides ve Aspose.Words**

Bir PowerPoint dosyasını (PPTX veya PPT) Word (DOCX veya DOC) formatına dönüştürmek için hem [Aspose.Slides for C++](https://products.aspose.com/slides/tr/cpp/) hem de [Aspose.Words for C++](https://products.aspose.com/words/cpp/) gerekir.

Bağımsız bir API olarak, C++ için [Aspose.Slides](https://products.aspose.app/slides) sunumlardan metin çıkarmanıza izin veren işlevler sunar.

[Aspose.Words](https://docs.aspose.com/words/cpp/) gelişmiş bir belge işleme API'sıdır ve uygulamaların Microsoft Word kullanmadan dosyalar oluşturmasına, değiştirmesine, dönüştürmesine, görüntülemesine, yazdırmasına ve belgeyle ilgili diğer görevleri yerine getirmesine olanak tanır.

## **PowerPoint Sunumunu Word Belgesine Dönüştürme**

PowerPoint'i Word'e dönüştürmek için bu kod parçacığını kullanın:

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // slayt görüntüsü oluşturur ve ekler
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // slayt metinlerini ekler
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
```

## **SSS**

**PowerPoint ve OpenDocument sunumlarını Word belgelerine dönüştürmek için hangi bileşenler kurulmalıdır?**

Projenize yalnızca [Aspose.Slides for C++](https://releases.aspose.com/slides/tr/cpp/) ve [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) ilgili paketlerini eklemeniz yeterlidir. Her iki kütüphane de bağımsız API'lar olarak çalışır ve Microsoft Office'in kurulu olmasına gerek yoktur.

**Tüm PowerPoint ve OpenDocument sunum formatları destekleniyor mu?**

Aspose.Slides [tüm sunum formatlarını destekler](/slides/tr/cpp/supported-file-formats/), bunlar arasında PPT, PPTX, ODP ve diğer yaygın dosya türleri bulunmaktadır. Bu, çeşitli Microsoft PowerPoint sürümlerinde oluşturulmuş sunumlarla çalışabileceğiniz anlamına gelir.