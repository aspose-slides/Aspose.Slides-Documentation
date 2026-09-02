---
title: "C++'ta PPT'yi PPTX'e Dönüştür"
linktitle: "PPT'den PPTX'e"
type: docs
weight: 20
url: /tr/cpp/convert-ppt-to-pptx/
keywords:
- "PowerPoint dönüştür"
- "sunum dönüştür"
- "slayt dönüştür"
- "PPT dönüştür"
- "PPT'den PPTX'e"
- "PPT'yi PPTX olarak kaydet"
- "PPT'yi PPTX'e dışa aktar"
- "PowerPoint"
- "sunum"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides ile C++'ta eski PPT dosyalarını PPTX'e dönüştürün. Tek dosya ve toplu dönüşüm, hata yönetimi ve doğruluk notları için C++ örneklerini içerir."
---
## **Genel Bakış**

PPT, eski ikili PowerPoint formatıdır, PPTX ise daha yeni Open XML formatıdır. Aspose.Slides for C++ bir PPT dosyasını yükleyebilir ve Microsoft PowerPoint olmadan PPTX olarak kaydedebilir. Bu makale, tek bir dosyayı veya bir dosya dizinini nasıl dönüştüreceğinizi gösterir ve dönüşüm sonrası neyin doğrulanması gerektiğini açıklar.

## **PPT Dosyasını PPTX'e Dönüştürmek**

Kaynak dosyayı [Presentation] sınıfı ile yükleyin, ardından [Presentation::Save] metodunu [SaveFormat::Pptx] argümanı ile çağırın. Artık ihtiyaç duyulmadığında sunumu yokederek kaynaklarını serbest bırakın.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Dosya uzantısı tek başına çıktı biçimini seçmez; bunu [SaveFormat::Pptx] argümanı belirler. Orijinal PPT dosyasını korumanız gerekiyorsa giriş ve çıkış yollarını farklı tutun.

## **Birden Çok PPT Dosyasını Dönüştürmek**

Aşağıdaki örnek, bir dizindeki tüm `.ppt` dosyalarını dönüştürür. Her dosya bağımsız işlenir, bu yüzden bir dönüşüm hatası diğerlerini durdurmaz.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

Üretim ortamları için tam istisna kaydını tutun, mevcut bir çıktı dosyasının üzerine yazılıp yazılamayacağına karar verin ve başarısız dosya adlarını yeniden deneme veya inceleme kuyruğuna yazın. Bozuk dosyalar, gerekli şifre olmadan açılan şifre korumalı dosyalar, erişilemeyen yollar ve desteklenmeyen içerikler dönüşümün başarısız olmasına neden olabilir. Şifreli dosyaları yüklemek için [Şifre Koruması İle Sunumlar](/slides/tr/cpp/password-protected-presentation/) sayfasına bakın.

## **Doğruluk ve Eski Özellikler**

Dönüştürme genellikle slaytları, masterları, yerleşimleri, metni, şekilleri, görüntüleri, tabloları ve grafikleri korur. Ancak PPT ve PPTX her özelliği tam olarak aynı şekilde temsil etmez. Kütüphane tarafından desteklenmeyen veya PPTX karşılığı bulunmayan eski bir özellik normalleştirilebilir, atlanabilir veya farklı gösterilebilir.

Dönüştürülmüş dosyayı animasyonlar, geçişler, gömülü veya bağlantılı OLE nesneleri, ActiveX denetimleri, gömülü medya, nadir bulunan yazı tipleri veya VBA makroları içerdiğinde kontrol edin. Düz bir PPTX dosyası makro‑etkin bir format değildir; VBA'nın mevcut kalması gerektiğinde uygun makro‑etkin bir iş akışı kullanın. Ayrıca, dönüştürülmüş sunumun açılacağı veya işleneceği ortamda gerekli yazı tiplerinin ve dış kaynakların bulunduğunu doğrulayın.

Önemli belgeler için, oluşturulan PPTX'i programatik olarak yeniden açın ve temel slayt sayısını ve içeriğini inceleyin, ardından görünümünü ve slayt gösterisi davranışını hedef görüntüleyicide karşılaştırın. Başarılı bir [Presentation::Save] çağrısını, her eski özelliğin tam bir PPTX temsiline sahip olduğunun kanıtı olarak değerlendirmeyin.

## **PPTX Ne Zaman Kullanılır**

Sunum, mevcut PowerPoint sürümlerinde düzenlenecek, Open XML paketleriyle çalışan sistemlerle paylaşılacak veya eski ikili PPT'ye göre incelemesi ve kurtarılması daha kolay bir formatta saklanacaksa PPTX kullanın. Dönüştürülmüş sunum doğruluk kontrollerinizden geçene kadar orijinal PPT'yi arşiv veya geri dönüş kopyası olarak tutun.

PDF, HTML, görüntüler, XPS veya başka bir çıktı türüne ihtiyacınız varsa, tüm hedeflerin düzenlenebilir PowerPoint özelliklerini koruyacağını varsaymak yerine [Sunumları Çoklu Formata Dönüştürme](/slides/tr/cpp/convert-presentation/) sayfasındaki format‑özel yönergeleri kullanın.

## **Çevrimiçi Dönüştürücü**

Ara sıra bir dosya veya hızlı bir karşılaştırma için [online PPT to PPTX converter](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) adresini kullanabilirsiniz. Tekrarlanabilir dönüşümler, toplu işleme veya uygulama‑seviyesi hata yönetimi için C++ API'sini kullanın.

## **İlgili Makaleler**

- [C++'ta Sunumları Kaydet](/slides/tr/cpp/save-presentation/)
- [Desteklenen Dosya Formatları](/slides/tr/cpp/supported-file-formats/)
- [C++'ta Sunumları Aç](/slides/tr/cpp/open-presentation/)

## **SSS**

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürebilir miyim?**

Evet. Aspose.Slides for C++ sunum dosyalarını Microsoft PowerPoint gerektirmeden yükleyip kaydedebilir.

**PPT'den PPTX'e dönüşüm tüm içeriği tam olarak korur mu?**

Ortak sunum içeriğini korur, ancak her eski veya desteklenmeyen özellik için tam doğruluk garanti edilmez. Oluşturulan dosyayı makrolar, OLE veya ActiveX nesneleri, medya, özel animasyonlar veya nadir yazı tipleri içerdiğinde inceleyin.

**Şifre korumalı bir PPT dosyasını dönüştürebilir miyim?**

Evet, dosyayı yüklerken doğru şifreyi sağlarsanız. Şifre eksik veya yanlış ise yükleme işlemi başarısız olur.

**Dönüşüm sonrası PPT dosyasını silmeli miyim?**

Orijinali, PPTX'i sizin için önemli olan görüntüleyiciler ve iş akışlarıyla doğrulayana kadar tutun. Bu, bir eski özelliğin farklı dönüşmesi durumunda geri dönüş kopyası sağlar.