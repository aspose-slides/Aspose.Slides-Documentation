---
title: "C++'da PowerPoint Sunumlarını Markdown'a Dönüştür"
linktitle: "PowerPoint'tan Markdown'a"
type: docs
weight: 140
url: /tr/cpp/convert-powerpoint-to-markdown/
keywords:
- "PowerPoint dönüştür"
- "sunumu dönüştür"
- "slaytı dönüştür"
- "PPT dönüştür"
- "PPTX dönüştür"
- "PowerPoint'tan MD'ye"
- "sunumdan MD'ye"
- "slayttan MD'ye"
- "PPT'den MD'ye"
- "PPTX'den MD'ye"
- "PowerPoint'i Markdown olarak kaydet"
- "sunumu Markdown olarak kaydet"
- "slaytı Markdown olarak kaydet"
- "PPT'yi MD olarak kaydet"
- "PPTX'i MD olarak kaydet"
- "PPT'yi MD'ye dışa aktar"
- "PPTX'i MD'ye dışa aktar"
- "Markdown görüntü dışa aktarımı"
- "CDN görüntü bağlantıları"
- "PowerPoint"
- "sunum"
- "Markdown"
- "C++"
- "Aspose.Slides"
description: "C++'da PPT ve PPTX sunumlarını Markdown'a dönüştürün ve dışa aktarılan bitmap, metafile ve SVG görüntülerinin nerede kaydedileceğini ve referans verileceğini kontrol edin."
---
## **Genel Bakış**

Aspose.Slides for C++ PPT ve PPTX sunumlarını dokümantasyon, statik site, içerik aktarımı ve sürüm kontrolü iş akışları için Markdown’a dönüştürebilir. Bir Markdown çeşidi seçebilir, slayt içeriğinin nasıl işleneceğini kontrol edebilir ve dışa aktarılan görsellerin nerede depolanacağını ve oluşturulan Markdown’ın bunlara nasıl referans vereceğini belirleyebilirsiniz.

Varsayılan olarak, Markdown dışa aktarma sadece metin çıktısı üretir. Görsel içeriği dışa aktarmak için [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) yöntemini [MarkdownExportType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/markdownexporttype/) enum’tan `Sequential` veya `Visual` değerine ayarlayın. `Sequential` slayt öğelerini ayrı ayrı ve sıralı olarak render ederken, `Visual` gruplandırılmış öğeleri birlikte tutarak görsel ilişkilerini korur. `TextOnly` değeri görsel kaynakları üretmez; bu modda görsel‑kaydetme olayları tetiklenmez.

## **Sunumu Markdown’a Dönüştür**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı ile yükleyin ve ardından `Md` değerini [SaveFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveformat/) enum’undan kullanarak [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) yöntemini çağırın.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Bir Markdown Çeşidi Seçin**

[MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) yöntemi, çıktıda kullanılacak Markdown spesifikasyonunu kontrol eder. [Flavor](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/flavor/) enum’u CommonMark, GitHub Flavored Markdown ve diğer desteklenen varyantları içerir.

Aşağıdaki örnek bir sunumu CommonMark olarak dışa aktarır:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **Varsayılan Yerel Kaydetme Davranışıyla Görselleri Dışa Aktar**

[MarkdownSaveOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/markdownsaveoptions/) sınıfı, yerel olarak kaydedilen görselleri yapılandırmak için iki yöntem sunar:

- [set_BasePath](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) Markdown belgesinin ve kaynaklarının temel dizinini belirtir.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) görsel alt dizinini belirtir. Varsayılan değeri `Images`dır.

Aşağıdaki örnek görsel içeriği render eder, görselleri `output/assets` klasörüne yazar ve Markdown belgesinde göreli görsel referansları oluşturur:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Bu davranış, özel görsel‑kaydetme işleyicisi `false` döndürdüğünde yedek olarak da kullanılır.

## **Görsel Kaydetmeyi ve Markdown Bağlantılarını Özelleştir**

Markdown dışa aktarımı sırasında üretilen SVG dışı bitmap ve metafile kaynakları için `MarkdownSaveOptions::ImageSaving` olayını kullanın. Bu olayın [MarkdownImageSavingHandler](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) temsilcisi, [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) nesnesini, onun [ImageFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imageformat/) bilgisini ve oluşturulan Markdown bağlantısını `System::String&` parametresi olarak alır. Görseli verilen formatta kaydedin veya yükleyin ve `link` değişkenini Markdown çıktısında görünmesi gereken referansla değiştirin.

SVG formatında üretilen kaynaklar ayrı olarak işlenir. `MarkdownSaveOptions::SvgImageSaving` olayına abone olun; bu olayın [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) temsilcisi bir [ISvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/) nesnesi ve `System::String& link` parametresini alır. SVG’nin `ImageFormat` argümanı yoktur; bunun yerine [ISvgImage::get_SvgData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/get_svgdata/) yöntemiyle XML verisini yazın veya yükleyin. Dışa aktarım modu ve görsel gruplama durumuna bağlı olarak, kaynak sunumdaki bir SVG rasterleştirilebilir veya diğer içeriklerle birleştirilebilir; ortaya çıkan non‑SVG kaynak daha sonra `ImageSaving`e iletilir. Her dışa aktarılan görsel kaynağın özel işleme ihtiyacı varsa her iki olaya da abone olun.

İşleyicinin dönüş değeri, görselin kim tarafından işlendiğini belirler:

- İşleyici görseli kaydetti, yükledi, dönüştürdü vb. ve geçerli bir değer atadıysa `true` döndürün. Aspose.Slides bu değeri Markdown belgesine yazar ve varsayılan yerel kaydetmeyi gerçekleştirmez.
- Aspose.Slides’in görseli yerel olarak kaydetmesini ve bağlantıyı [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) ve [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) ayarlarına göre oluşturmasını istiyorsanız `false` döndürün.

{{% alert color="warning" title="Önemli" %}}

`true` döndüren bir işleyici, görselin sorumluluğunu alır. Geçerli ve boş olmayan bir bağlantı atanmadan `true` dönerse dışa aktarım `InvalidOperationException` hatasıyla başarısız olur.

{{% /alert %}}

### **Görselleri Bir CDN Köken Diziniyle Kaydedin ve Harici URL’ler Kullanın**

Aşağıdaki örnek, `cdn-origin/presentations/quarterly-report` dizinini bağlanmış veya eşitlenmiş bir CDN kökeni olarak kabul eder. Her işleyici oluşturulan dosya adını alır, görseli bu özel dizine kaydeder ve yerel referansı genel bir CDN URL’siyle değiştirir. Örnek kendisi ağ üzerinden bir yükleme yapmaz: URL, dizin CDN kökeni olarak bağlandığında veya dosyalar CDN’ye yayımlandığında geçerli olur. Nesne depolama için dosya‑sistemi yazma işlemini depolama SDK’sının yükleme operasyonu ile değiştirin ve yalnızca yükleme başarılı olduğunda `link` atayın.

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Bitmap işleyicisi, 128 × 128 pikselden küçük görseller için kasıtlı olarak `false` döndürür; böylece Aspose.Slides bu görselleri varsayılan davranışla `output/fallback-images` dizinine kaydeder. Daha büyük bitmap ve metafile kaynakları ile SVG kaynakları özel kod tarafından işlenir. Örneğin, `fallback-images/image1.png` gibi bir yerel referans `https://cdn.example.com/presentations/quarterly-report/image1.png` haline gelir. İşleyiciler dosya sistemi yollarını yalnızca dosya yazma sırasında kullanır; Markdown’da yazılan bağlantılar ileri eğik çizgi (`/`) ve URL‑kodlu dosya adları içerir. Göreli bağlantılar oluştururken aynı kuralı uygulayın: platform‑özel klasör ayırıcı yerine `/` kullanın.

## **SSS**

**Bir işlemci hem raster görselleri hem de SVG görselleri işleyebilir mi?**

Hayır. Üretilen bitmap ve metafile kaynakları için `MarkdownSaveOptions::ImageSaving` ve SVG olarak üretilen kaynaklar için `MarkdownSaveOptions::SvgImageSaving` kullanın. İlkincisi bir [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) nesnesi ve bir [ImageFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imageformat/) sağlar; ikincisi ise SVG verisi [ISvgImage::get_SvgData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/get_svgdata/) ile okunabilen bir [ISvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/) nesnesi sağlar. Dışa aktarım sırasında rasterleştirilen bir kaynak SVG ise `ImageSaving` tarafından işlenir.

**Bir görsel‑kaydetme işleyicisi `false` döndürdüğünde ne olur?**

Aspose.Slides varsayılan yerel‑kaydetme davranışını kullanır. Görsel konumu ve oluşturulan referans, [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) ve [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) ayarlarıyla kontrol edilir.

**Bir işleyici görseli yerel kaydetmeden bir URL sağlayabilir mi?**

Evet. İşleyici görseli nesne depolamaya yükleyebilir veya başka bir hizmete aktarabilir, elde edilen URL’yi `link`e atayabilir ve `true` dönebilir. İşleyicinin işlemi tamamen kendisi tamamlamalıdır; `true` döndürmek varsayılan yerel kaydetmeyi engeller.

**Markdown dışa aktarma, bir işleyiciden `InvalidOperationException` hatası verirse neden?**

Bu istisna, işleyici `true` döndürüp geçerli bir bağlantı sağlamadığında ortaya çıkar. `true` döndürmeden önce Markdown’a yazılması gereken göreli yol ya da harici URL’yi `link`e atayın.

**Görsel bağlantılar hangi yol ayırıcıyı kullanmalı?**

Markdown bağlantıları ve URL’lerde ileri eğik çizgi (`/`) kullanın. Dosya‑sistemi yolları için yalnızca `Path::Combine` kullanın, ardından Markdown referansını ayrı olarak oluşturun veya normalleştirin.

**Markdown dışa aktarımı sırasında hiperlinkler korunur mu?**

Evet. Metin [hyperlinks](/slides/tr/cpp/manage-hyperlinks/) standart Markdown linkleri olarak korunur. Slayt [transitions](/slides/tr/cpp/slide-transition/) ve [animations](/slides/tr/cpp/powerpoint-animation/) dönüştürülmez.

**Sunumlar paralel olarak Markdown’a dönüştürülebilir mi?**

Farklı sunum dosyalarını paralel olarak işleyebilirsiniz, ancak aynı [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneğini birden fazla iş parçacığı arasında paylaşmayın. [multithreading guidelines](/slides/tr/cpp/multithreading/) yönergelerini izleyin ve her dosya için ayrı bir örnek kullanın.