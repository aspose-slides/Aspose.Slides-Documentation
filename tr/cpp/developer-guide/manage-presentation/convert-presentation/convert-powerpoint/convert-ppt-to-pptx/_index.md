---
title: "C++'ta PPT'yi PPTX'e Dönüştür"
linktitle: "PPT'den PPTX'e"
type: docs
weight: 20
url: /tr/cpp/convert-ppt-to-pptx/
keywords:
- "PowerPoint dönüştür"
- "sunumu dönüştür"
- "slaytı dönüştür"
- "PPT dönüştür"
- "PPT'den PPTX'e"
- "PPT'yi PPTX olarak kaydet"
- "PPT'yi PPTX'e dışa aktar"
- "PowerPoint"
- "sunum"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides ile C++'ta eski PPT dosyalarını PPTX'e dönüştürün. Tek dosya ve toplu dönüşüm, hata yönetimi ve doğruluk notları için C++ örnekleri içerir."
---
## **Genel Bakış**

PPT, eski ikili PowerPoint formatıdır, PPTX ise daha yeni Open XML formatıdır. Aspose.Slides for C++ Microsoft PowerPoint olmadan bir PPT dosyasını yükleyebilir ve PPTX olarak kaydedebilir. Bu makale, tek bir dosyayı veya bir dosya dizinini nasıl dönüştüreceğinizi gösterir ve dönüşüm sonrası neyin doğrulanması gerektiğini açıklar.

## **Bir PPT Dosyasını PPTX'e Dönüştür**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı ile yükleyin, ardından [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) yöntemini [SaveFormat::Pptx](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveformat/) ile çağırın. Artık gerekli olmadığında sunumu serbest bırakın ve kaynaklarını serbest bırakın.

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

Dosya uzantısı tek başına çıktı formatını seçmez; bunu [SaveFormat::Pptx](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveformat/) argümanı yapar. Orijinal PPT dosyasını korumanız gerekiyorsa giriş ve çıkış yollarını farklı tutun.

## **Birden Çok PPT Dosyasını Dönüştür**

Aşağıdaki örnek, bir dizindeki tüm `.ppt` dosyalarını dönüştürür. Her dosya bağımsız olarak işlenir, bu yüzden bir dönüşüm hatası diğerlerini durdurmaz.

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

Üretim ortamları için, tam istisna kaydını tutun, mevcut bir çıktı dosyasının üzerine yazılıp yazılamayacağını belirleyin ve başarısız dosya adlarını yeniden deneme veya inceleme kuyruğuna yazın. Bozuk dosyalar, gerekli şifre olmadan açılan şifre korumalı dosyalar, erişilemeyen yollar ve desteklenmeyen içeriklerin hepsi dönüşümün başarısız olmasına neden olabilir. Şifreli dosyaları yüklemek için [Password-Protected Presentations](/cpp/password-protected-presentation/) sayfasına bakın.

## **Doğruluk ve Eski Özellikler**

Dönüştürme genellikle slaytları, master'ları, yerleşimleri, metni, şekilleri, görselleri, tabloları ve grafikleri korur. Ancak, PPT ve PPTX her özelliği tam olarak aynı şekilde temsil etmez. Kitaplık tarafından desteklenmeyen veya PPTX eşdeğeri bulunmayan eski bir özellik, normalleştirilebilir, atlanabilir veya farklı görüntülenebilir.

Dönüştürülmüş dosyayı, animasyonlar, geçişler, gömülü veya bağlantılı OLE nesneleri, ActiveX denetimleri, gömülü medya, nadir yazı tipleri veya VBA makroları içerdiğinde kontrol edin. Düz bir PPTX dosyası makro etkin bir format değildir, bu nedenle VBA'nın mevcut kalması gerektiğinde uygun makro‑etkin bir iş akışı kullanın. Ayrıca, gerekli yazı tiplerinin ve dış kaynakların, dönüştürülmüş sunumun açılacağı veya render edileceği ortamda mevcut olduğunu doğrulayın.

Önemli belgeler için, üretilen PPTX dosyasını programlı olarak yeniden açın ve temel slayt sayısı ile içeriği inceleyin, ardından görünümünü ve slayt gösterisi davranışını hedeflenen görüntüleyicide karşılaştırın. Başarılı bir [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) çağrısını, her eski özelliğin tam bir PPTX temsiline sahip olduğunun kanıtı olarak değerlendirmeyin.

## **Ne Zaman PPTX Kullanılır**

Sunum, güncel PowerPoint sürümlerinde düzenlenecek, Open XML paketleriyle çalışan sistemlerle değiş tokuş yapılacak veya eski ikili PPT'ye göre incelemesi ve geri kazanılması daha kolay bir formatta saklanacaksa PPTX kullanın. Dönüştürülmüş sunum doğruluk kontrollerinizi geçene kadar orijinal PPT'yi arşiv veya geri dönüş kopyası olarak tutun.

PDF, HTML, görseller, XPS veya başka bir çıktı türüne ihtiyacınız varsa, tüm hedeflerin düzenlenebilir PowerPoint özelliklerini koruduğunu varsaymak yerine [Convert Presentations to Multiple Formats](/cpp/convert-presentation/) sayfasındaki format‑özel yönergeleri kullanın.

## **Çevrimiçi Dönüştürücü**

Ara sıra bir dosya veya hızlı bir karşılaştırma için [online PPT to PPTX converter](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) adresini kullanabilirsiniz. Tekrarlanabilir dönüşümler, toplu işleme veya uygulama düzeyinde hata yönetimi için C++ API'sini kullanın.

## **İlgili Makaleler**

- [C++'ta Sunumları Kaydet](/cpp/save-presentation/)
- [Desteklenen Dosya Formatları](/cpp/supported-file-formats/)
- [C++'ta Sunumları Aç](/cpp/open-presentation/)

## **SSS**

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürebilir miyim?**

Evet. Aspose.Slides for C++ Microsoft PowerPoint gerektirmeden sunum dosyalarını yükler ve kaydeder.

**PPT'den PPTX'e dönüşüm tüm içeriği tam olarak korur mu?**

Ortak sunum içeriğini korur, ancak her eski ya da desteklenmeyen özellik için tam doğruluk garanti edilmez. Oluşturulan dosyayı, makrolar, OLE veya ActiveX nesneleri, medya, özel animasyonlar veya nadir yazı tipleri içerdiğinde gözden geçirin.

**Şifre korumalı bir PPT dosyasını dönüştürebilir miyim?**

Evet, dosyayı yüklerken doğru şifreyi sağlarsanız. Eksik veya hatalı şifre, yükleme işleminin başarısız olmasına neden olur.

**Dönüşümden sonra PPT dosyasını silmeli miyim?**

Orijinali, PPTX'i sizin için önemli olan görüntüleyiciler ve iş akışlarıyla doğrulayana kadar tutun. Bu, eski bir özelliğin farklı dönüştürülmesi durumunda geri dönüş kopyası sağlar.