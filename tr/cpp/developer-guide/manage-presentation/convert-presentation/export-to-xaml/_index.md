---
title: C++ ile Sunumları XAML’e Dışa Aktarma
linktitle: Sunumu XAML’e
type: docs
weight: 30
url: /tr/cpp/export-to-xaml/
keywords:
- PowerPoint'i dışa aktar
- OpenDocument'i dışa aktar
- sunumu dışa aktar
- PowerPoint'i dönüştür
- OpenDocument'i dönüştür
- sunumu dönüştür
- PowerPoint'ten XAML'e
- OpenDocument'ten XAML'e
- sunumdan XAML'e
- PPT'den XAML'e
- PPTX'den XAML'e
- ODP'den XAML'e
- PPT'yi XAML olarak kaydet
- PPTX'i XAML olarak kaydet
- ODP'yi XAML olarak kaydet
- PPT'yi XAML'e dışa aktar
- PPTX'i XAML'e dışa aktar
- ODP'yi XAML'e dışa aktar
- C++
- Aspose.Slides
description: Aspose.Slides kullanarak C++ içinde PowerPoint ve OpenDocument slaytlarını XAML’e dönüştürün - hızlı, Office gerekmeden, düzeninizi koruyan bir çözüm.
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını XAML olarak dışa aktarmayı açıklar. XAML’e kısa bir giriş içerir, varsayılan ayarlarla bir sunumun XAML’e nasıl kaydedileceğini gösterir ve gizli slaytların dışa aktarılması dahil olmak üzere [XamlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export.xaml/xamloptions/) üzerinden dışa aktarma özelleştirmelerini gösterir. Makale ayrıca yedek yazı tipleri, XAML yığını uyumluluğu ve gizli slayt dışa aktarım davranışıyla ilgili yaygın sorulara yanıt verir.

## **XAML Hakkında**

XAML, WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) ve Xamarin.Forms gibi çerçevelerde kullanıcı arabirimlerini tanımlamak için kullanılan XML tabanlı bir işaretleme dilidir.

XAML dosyalarıyla görsel bir tasarımcıda çalışabilir veya işaretlemeyi doğrudan yazıp düzenleyebilirsiniz.

## **Varsayılan Seçeneklerle Sunumları XAML’e Dışa Aktarma**

Aşağıdaki C++ örneği, bir sunumun varsayılan ayarlarla XAML’e nasıl dışa aktarılacağını gösterir:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

Varsayılan olarak, dışa aktarılan slaytlar sürecin geçerli çalışma dizinindeki `pres` alt klasörüne kaydedilir; bu dizin [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/tr/cpp/system.io/directory/getcurrentdirectory/) tarafından döndürülür. Klasör otomatik olarak oluşturulur ve gereken görseller de oraya kaydedilir.

Çıktı klasörü adı, uzantısı olmadan kaynak dosya adından alınır. `pres.pptx` için çıktı dosyaları `pres/Slide_1.xaml`, `pres/Slide_2.xaml` şeklinde adlandırılır. Giriş sunumuna mutlak bir yol gönderseniz bile, çıktı klasörü geçerli çalışma dizinine göre oluşturulur, giriş dosyasının yanına değil.

## **Özel Seçeneklerle Sunumları XAML’e Dışa Aktarma**

Aspose.Slides’in bir sunumu XAML’e nasıl dışa aktaracağını kontrol etmek için [IXamlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export.xaml/ixamloptions/) arayüzünü kullanın.

Çıktıyı özel bir konuma kaydetmek için [IXamlOutputSaver](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export.xaml/ixamloutputsaver/) uygulayın ve örneğinizi [XamlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export.xaml/xamloptions/) sınıfının [set_OutputSaver](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) metoduna aktarın.

Gizli slaytları XAML çıktısına dahil etmek için aşağıdaki C++ örneğinde gösterildiği gibi [set_ExportHiddenSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) metoduna `true` gönderin:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **Oluşturulan Tüm XAML Artefaktlarını Yakalama**

Bir XAML dışa aktarımı, dışa aktarılan her slayt için bir XAML belgesi ve ayrı görseller ile destekleyici kaynaklar üretebilir. Bu artefaktları varsayılan dosya‑sistemi kaydedicisi yerine almak için özel bir [IXamlOutputSaver](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export.xaml/ixamloutputsaver/) sağlayın ve [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) metodunu kullanın. Dışa aktarmayı, XAML seçeneklerini kabul eden XAML‑özel [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) aşırı yüklemesiyle başlatın.

### **Geri Çağırma Yaşam Döngüsünü Anlama**

Dışa aktarıcı, oluşturulan her artefakt için [IXamlOutputSaver::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) metodunu ayrı ayrı çağırır:

- `path` artefaktı tanımlar ve göreli dizinler içerebilir. XAML, kaynakları göreli yollarla referanslayabileceği için bu bilgiyi koruyun.
- `data` artefaktın baytlarını içerir. Görseller ve diğer ikili kaynaklar metin olarak çözülmemelidir.
- Kaydedici, veriyi geri döndürmeden önce saklamaktan veya kalıcı hale getirmekten sorumludur. Örneklerde her bayt dizisi uygulamaya ait belleğe kopyalanır.
- Sunum kaydetme işlemi döndüğünde ve tüm geri çağırmalar başarılı bir şekilde tamamlandığında dışa aktarımı başarılı sayın. Depolama hatalarını yok saymayın veya gözlemlenmemiş arka plan yazımlarını başlatmayın. Kalıcılaştırma daha sonra gerçekleşirse, genel başarı yalnızca bu adım da başarılı olduğunda bildirilmelidir.

[set_ExportHiddenSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) aynı zamanda özel bir kaydediciye de uygulanır. Varsayılan ayar `false` olduğundan gizli‑slayt XAML belgeleri dışarıda bırakılır. `true` ayarı, gizli slaytları ve bunların dışa aktarımı için gereken tüm kaynakları dahil eder. Kaynak sayısı sunuma bağlıdır; slayt başına bir geri çağırma veya sabit bir sıralama varsaymayın.

### **Belleğe Aktar ve Artefaktları İncele**

Bu tam örnek `pres.pptx` dosyasını yükler, her artefakti bir [Dictionary<String,ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/tr/cpp/system.collections.generic/dictionary/) içinde toplar ve adını, tipini ve bayt sayısını yazdırır. Sağlanan adlar eksiksiz korunur. Aynı ada sahip bir artefakt toplama sırasında hataya neden olur, sessizce üzerine yazılmaz.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // Yalnızca XAML'i çöz, ve yalnızca metinsel denetim gerektiğinde.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

Uygulamanızdan `InMemoryXamlExample::Run` metodunu çağırın. Uzantı kontrolleri inceleme için faydalıdır; tanınmayan kaynak tipleri dahil tüm artefaktları koruyun. Baytları depolarken veya aktarırken değiştirmeyin. Yalnızca XAML metin işleme gerektiğinde UTF‑8 kodlamasıyla [Encoding::GetString](https://reference.aspose.com/slides/tr/cpp/system.text/encoding/getstring/) kullanın.

### **Toplanan Artefaktları ZIP Arşivine Paketleme**

Bu bağımsız örnek dışa aktarımı toplar, adlarını doğrular ve orijinal baytları bir ZIP arşivine yazar. Benzersiz bir arşiv adı aynı anda çalışan dışa aktarma işlerindeki çakışmaları önler. ZIP girdileri ileri eğik çizgi (`/`) kullanır ve göreli dizinleri korur. Normalleştirme sonrası çakışan veya güvensiz adlar, paketleme aşamasında tamamen reddedilir.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // Kaydet, ZIP dizinini sonlandırır; başarı raporlanmadan önce dosyayı kapat.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

Uygulamanızdan `ZipXamlExample::Run` metodunu çağırın. Örnek, C++ çalışma zamanındaki `Aspose::Zip::ZipFile` sınıfını kullanarak yerel bir arşiv yazar; dışa aktarıcı kendisi gevşek XAML veya görsel dosyaları yazmaz. Uzaktan depolama için, arşiv‑yazma aşamasını toplanan bayt dizilerinin yüklenmesiyle değiştirin. Bir dışa aktarma‑iş kimliği ile tam göreli artefakt adını blob anahtarı olarak kullanın veya iş kimliği, göreli ad ve ikili veriyi bir veritabanı satırında saklayın. Tüm yüklemeler tamamlanıp veritabanı işlemi onaylandıktan sonra işi yayınlayın. Kalıcılaştırma başarısız olursa kısmi çıktıyı temizleyin.

Büyük sunumlar için, özel bir kaydedici her artefakti doğrudan uygulama depolamasına yazdırarak tüm dışa aktarmayı uygulama belleğinde tutma ihtiyacını ortadan kaldırabilir. Dışa aktarıcı yine de tüm artefaktları bellekte toplar, ardından kaydediciye iletir. Her geri çağırmayı dışa aktarıcının bakış açısından senkron tutun: baytlar hedef tarafından kabul edilene kadar dönmeyin ve hataların çağırıcıya ulaşmasına izin verin.

### **Kaynak Adlarını Koruma ve Referansları Doğrulama**

- Hedef gerektiriyorsa yol ayırıcılarını normalleştirin, ancak göreli dizinleri koruyun. Her üretilen adın benzersiz olduğunu ve kaynak referanslarının geçerli kalacağını garanti edemiyorsanız, yalnızca [Path::GetFileName](https://reference.aspose.com/slides/tr/cpp/system.io/path/getfilename/) kullanmayın.
- Hedef‑özel ad doğrulaması uygulayın. Gevşek dosyalar yazılırken kök yolları ve geçiş bölümlerini reddedin, hedefi [Path::GetFullPath](https://reference.aspose.com/slides/tr/cpp/system.io/path/getfullpath/) ile çözümleyin ve hedefin, istenen dışa aktarma dizini içinde (dizin ayırıcısı dahil) kalıp kalmadığını kontrol edin. Sembolik bağlar yönlendirmeye izin vermeyen uygulama‑kontrollü bir dizin kullanın.
- Her dışa aktarma işi için ayrı bir kaydedici ve depolama ad alanı kullanın. Ayraç normalleştirmesinden sonra ve hedefin büyük/küçük harf duyarlılığı kurallarına göre çakışmaları tespit edin.
- Yayınlamadan önce, her XAML belgesini XML olarak ayrıştırın ve `Source` ya da `ImageSource` gibi dosya‑tabanlı kaynak referanslarını inceleyin. Göreli URI’yı belgeyi içeren XAML artefaktının dizinine göre çözümlendirin, elde edilen depolama adını normalleştirin ve ilgili sözlük anahtarının, ZIP girdisinin ya da depolanmış nesnenin mevcut olduğunu doğrulayın. Harici URI’ları ve XAML işaretleme ifadelerini göreli dosya adlarından ayrı tutun.

Örneğin, `pres/Slide_1.xaml` dosyası `images/image1.png` dosyasına referans veriyorsa, depolanan kaynak `pres/images/image1.png` olarak bulunmalıdır. Yalnızca `image1.png` saklamak ilişkiyi bozar. Nesne depolamada, iş ön eki altındaki aynı dizin yapısını koruyun ve bu kaynak URL’lerini XAML tüketicisinin erişebileceği şekilde sunun. ZIP’i tekrar açarak giriş adlarını ve kaynak baytlarını doğrulayın ve hedef XAML ortamında örnek slaytları yükleyerek görsellerin doğru çözüldüğünden emin olun.

## **SSS**

**Orijinal yazı tipi makinada mevcut değilse öngörülebilir yazı tiplerini nasıl sağlarız?**

[XamlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export.xaml/xamloptions/) içinde yer alan [set_DefaultRegularFont](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) metodunu kullanın — eksik olduğunda dışa aktarma sırasında yedek bir yazı tipi olarak kullanılır. Bu, oluşturulan XAML’in yedek yazı tipine başvuracağını veya hedef makinede yazı tipinin mevcut olacağını garantilemez. XAML’in referans ettiği yazı tiplerinin, görüntülenecek ortamda bulunmasını sağlayın.

**Dışa aktarılan XAML sadece WPF için mi tasarlandı, diğer XAML yığınlarında da kullanılabilir mi?**

Aspose.Slides, genel API’si üzerinden WPF XAML’i dışa aktarır. UWP ve Xamarin.Forms gibi diğer XAML yığınlarıyla uyumluluk garanti edilmez. Oluşturulan işaretlemeyi hedef ortamınızda test edin.

**Gizli slaytlar destekleniyor mu ve varsayılan olarak dışa aktarılmalarını nasıl engellerim?**

Varsayılan olarak gizli slaytlar dahil edilmez. Bu davranışı [set_ExportHiddenSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) metodunu kullanarak kontrol edebilirsiniz — ihtiyaç duymadığınız sürece devre dışı bırakılmış bırakın.