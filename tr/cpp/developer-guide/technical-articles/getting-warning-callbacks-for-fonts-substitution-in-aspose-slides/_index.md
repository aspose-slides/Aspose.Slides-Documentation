---
title: Yazı Tipi Yerine Koyma İçin Uyarı Geri Aramalarını Alın
type: docs
weight: 70
url: /tr/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- uyarı geri araması
- yazı tipi yerine koyma
- renderleme süreci
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde yazı tipi yerine koyma için uyarı geri aramalarını almayı öğrenin ve PowerPoint ve OpenDocument sunumlarını doğru bir şekilde görüntüleyin."
---
## **Giriş**

Aspose.Slides for C++ size, bir zorunlu yazı tipi oyun sırasında makinede mevcut olmadığında yazı tipi yerine koyma için uyarı geri aramaları almanızı sağlar. Bu geri aramalar, eksik veya erişilemeyen yazı tipleriyle ilgili sorunları teşhis etmeye yardımcı olur.

## **Uyarı Geri Aramalarını Etkinleştirme**

Aspose.Slides for C++ sunum slaytlarını oluştururken uyarı geri aramaları almanız için basit API'ler sunar. Uyarı geri aramalarını yapılandırmak için aşağıdaki adımları izleyin:

1. Uyarıları işlemek için [IWarningCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides.warnings/iwarningcallback/) arayüzünü uygulayan özel bir geri arama sınıfı oluşturun.
2. [RenderingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/htmloptions/) ve diğer seçenek sınıflarını kullanarak uyarı geri aramasını ayarlayın.
3. Hedef makinede mevcut olmayan bir yazı tipi kullanan bir sunumu yükleyin.
4. Etkisini görmek için bir slayt küçük resmi oluşturun ya da sunumu dışa aktarın.

**Özel Uyarı Geri Arama Sınıfı:**

```cpp
#include <Warnings/IWarningCallback.h>

class FontWarningHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontWarningHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss)
    {
        Console::WriteLine(warning->get_Description());
    }

    return ReturnAction::Continue;
}

// Örnek çıktı:
//
// Yazı tipi XYZ'den {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol} olarak değiştirilecektir
```

**Bir Slayt Küçük Resmi Oluşturma:**

```cpp
// Slayt oluşturma sırasında yazı tipi ile ilgili uyarıları ele almak için bir uyarı geri araması ayarlayın.
auto options = MakeObject<RenderingOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Sunumu belirtilen dosya yolundan yükleyin.
auto presentation = MakeObject<Presentation>(u"sample.pptx");
    
// Sunumdaki her slayt için bir küçük resim oluşturun.
for(auto&& slide : presentation->get_Slides())
{
    // Belirtilen oluşturma seçeneklerini kullanarak slayt küçük resmi alın.
    auto image = slide->GetImage(options);
    // ...

    image->Dispose();
}

presentation->Dispose();
```

**PDF Biçimine Dışa Aktarma:**

```cpp
// PDF dışa aktarımı sırasında yazı tipi ile ilgili uyarıları ele almak için bir uyarı geri araması ayarlayın.
auto options = MakeObject<PdfOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Sunumu belirtilen dosya yolundan yükleyin.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Sunumu PDF olarak dışa aktarın.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Pdf, options);
// ...

stream->Dispose();
presentation->Dispose();
```

**HTML Biçimine Dışa Aktarma:**

```cpp
// HTML dışa aktarımı sırasında yazı tipi ile ilgili uyarıları ele almak için bir uyarı geri araması ayarlayın.
auto options = MakeObject<HtmlOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Sunumu belirtilen dosya yolundan yükleyin.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Sunumu HTML formatında dışa aktarın.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Html, options);
// ...

stream->Dispose();
presentation->Dispose();
```