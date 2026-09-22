---
title: C++ içinde Orijinal Sunum Biçimini Belirle
linktitle: Kaynak Biçim
type: docs
weight: 35
url: /tr/cpp/detect-presentation-source-format/
keywords:
- kaynak biçim
- sunum biçimini algıla
- PowerPoint
- OpenDocument
- sunum
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak C++'ta yüklü bir sunumun orijinal biçimini okuyun, algılama API'lerini karşılaştırın ve dosyalar, akışlar ve eski biçimlerle çalışın."
---
## **Genel Bakış**

Bir sunumu yükledikten sonra, orijinal biçimini belirlemek için [Presentation::get_SourceFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_sourceformat/) metodunu çağırın. Bu yöntem [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_sourceformat/) üzerinden de kullanılabilir. Mevcut örneğin yüklendiği biçime bağlı olarak sonraki işlem gerektiğinde bunu kullanın.

Kaynak biçim, çıktı dosyası için seçilen [SaveFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveformat/) biçiminden farklıdır. Başka bir biçime kaydetmek, mevcut örneğin kaynak biçimini değiştirmez.

## **Bir Dosyanın Kaynak Biçimini Okuma**

Bu örnek, mevcut bir `sample.pptx` dosyası gerektirir. Dosyayı yükler ve dosya adını değil, [Presentation::get_SourceFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_sourceformat/) kullanarak bir uygulama işleme politikasını seçer. Diğer biçimleri denemek için giriş yolunu değiştirin. Örnek, seçilen politikayı yazdırır; mesajları uygulama mantığınızla değiştirin.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **Desteklenen Değerleri Tanıma**

[SourceFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/sourceformat/) enumarasyonu aşağıdaki sunum biçimlerini ayırır. Aşağıdaki uzantılar geleneksel uzantılardır, orijinal dosya adının yeniden oluşturulması değildir.

| SourceFormat değeri | Uzantı | Biçim |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 sunumu |
| `Pptx` | `.pptx` | Office Open XML sunumu |
| `Pptm` | `.pptm` | Makro etkin Office Open XML sunumu |
| `Pps` | `.pps` | PowerPoint 97–2003 slayt gösterisi |
| `Ppsx` | `.ppsx` | Office Open XML slayt gösterisi |
| `Ppsm` | `.ppsm` | Makro etkin Office Open XML slayt gösterisi |
| `Pot` | `.pot` | PowerPoint 97–2003 şablonu |
| `Potx` | `.potx` | Office Open XML şablonu |
| `Potm` | `.potm` | Makro etkin Office Open XML şablonu |
| `Odp` | `.odp` | OpenDocument sunumu |
| `Otp` | `.otp` | OpenDocument sunum şablonu |
| `Fodp` | `.fodp` | Düz XML ODF sunumu |
| `Xml` | `.xml` | PowerPoint XML sunumu |

## **Akışın Kaynak Biçimini Okuma**

Bu örnek, mevcut bir `sample.pps` dosyası gerektirir. Baytlarını bir bellek akışına okuyarak, veritabanı değeri veya yüklenmiş bayt dizisi gibi dosya adı olmayan girdi modellemesi yapılır. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) yapıcı yalnızca akışı alır.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT, PPS ve POT aynı temel ikili formatı kullanır. Dosya yolu ile yüklerken, uzantı slayt gösterisi veya şablonu ayırt etmeye yardımcı olabilir. Dosya adı olmadan, eski PPS ve POT içeriği `SourceFormat::Ppt` olarak raporlanabilir; yukarıdaki PPS örneği `Ppt` rapor eder.

Uygulamanız ayrımı korumak zorundaysa, orijinal dosya adını veya alt tip meta verilerini ayrı olarak tutun. Uzantı bu eski alt tipler için faydalı bir ipucu olsa da, rastgele sunum içeriğini tanımlamanın tek temeli olmamalıdır.

## **Yüklemeden Önce ve Sonra Algılamayı Karşılaştırma**

Dosyayı tam sunum nesne modeline yüklemeden önce incelemeniz gerektiğinde [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentationfactory/getpresentationinfo/) ve [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/get_loadformat/) kullanın. Örnek mevcut olduğunda ise [Presentation::get_SourceFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_sourceformat/) kullanın.

Bu örnek `sample.pptx` gerektirir ve her iki kontrol için de `Pptx` yazdırır. Gerçek ortamda işleme aşamanıza uygun API'yi seçin; zaten yüklü bir sunumun kaynak biçimini elde etmek için ikinci bir incelemeye gerek yoktur.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

Sonuçlar farklı enumarasyon tiplerine sahiptir: [LoadFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadformat/) ve [SourceFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/sourceformat/). Sayısal değerlerini dönüştürerek karşılaştırmayın ve her biçimin aynı algılama sonuçlarına sahip olduğunu varsaymayın. PowerPoint XML, yüklemeden önce `LoadFormat::Unknown`, yüklendikten sonra ise `SourceFormat::Xml` olarak raporlanabilir.

## **Kaynak ve Çıktı Biçimlerini Ayrı Tutun**

Bu örnek `sample.pptx` gerektirir ve `converted.odp` yazar. Orijinal örnek kaydedilmeden önce ve sonra `Pptx` yazdırır. Yalnızca ODP çıktısından yüklü yeni örnek `Odp` rapor eder.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

`MakeObject<Presentation>()` ile sıfırdan oluşturulan bir sunum `SourceFormat::Pptx` rapor eder. Giriş dosyası yoktur: bu, yeni oluşturulan bir örnek için varsayılan değerdir, bir PPTX dosyasının yüklendiğinin kanıtı değildir. Bu ayrım önemliyse, uygulamanızın örneği oluşturup oluşturmadığını ayrı olarak izleyin.

## **Bir Kaynak Biçimini Uzantıya Haritalama**

Aşağıdaki örnek `sample.pptx` gerektirir. Giriş dosya adını ayrıştırmadan, mevcut desteklenen her [SourceFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/sourceformat/) değerini geleneksel bir uzantıya eşler. Yedek, tanınmayan bir değere sessizce uzantı atamaktan kaçınır.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

Bu eşleme bir dosyayı dönüştürmez veya akış yüklemesi sırasında kaybolan eski PPS/POT alt tipini geri getirmez. Gerçek kaydetme için bir [SaveFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveformat/) açıkça seçin veya [Sunumları Orijinal Biçiminde Kaydet](/slides/tr/cpp/save-presentation/#save-presentations-in-their-original-format) bölümündeki dönüşümü kullanın.

## **Kaydedip Yeniden Açarak Biçimleri Doğrulama**

Bu bağımsız örnek bir sunum oluşturur ve çalışma dizininde üç dosya yazar, aynı isimli dosyaları üzerine yazar. Her çıktıyı hem yol üzerinden hem de bellek akışı aracılığıyla yeniden açar. PPTX ve ODP için her iki yol da kaydedilen biçimi rapor eder. PPS için, yol üzerinden yükleme `Pps` rapor ederken, dosya adı olmadan aynı baytları yükleme `Ppt` rapor eder.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

Aşağıdaki tablo, eşleşen uzantılara sahip sunumlar için kaynak‑biçim tanımlamasını özetler:

| Kaydedilen biçim | Dosya yolundan SourceFormat | İsimsiz akıştan SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Dosya yoluyla aynı |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Dosya yoluyla aynı |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Dosya yoluyla aynı |
| ODP, OTP | `Odp`, `Otp` respectively | Dosya yoluyla aynı |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Eski PPS/POT içeriği, isimlendirilmemiş akışlar için `Ppt` olarak normalleştirilir. Tablo, biçim tanımlamasını açıklar; dönüşüm sırasında her bir sunum özelliğinin korunmasını açıklamaz.

## **SSS**

**PPTX'ten yüklenen bir sunumu ODP olarak kaydetmek, kaynak biçimini değiştirir mi?**

Hayır. Mevcut örnek hâlâ `Pptx` rapor eder. Kaydedilen ODP dosyasından yüklenen bir örnek `Odp` rapor eder.

**Bir akış her zaman eski bir sunumu, slayt gösterisini ve şablonu ayırt edebilir mi?**

Hayır. PPT, PPS ve POT aynı ikili formatı paylaşır. Bu ayrım gerektiğinde dosya adını veya alt tip meta verilerini ayrı tutun.

**Sunum zaten yüklüyse hangi API'yi kullanmalıyım?**

[Presentation::get_SourceFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_sourceformat/) metodunu okuyun. Yüklemeden önce inceleme için [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentationfactory/getpresentationinfo/) kullanın.