---
title: "C++'ta PowerPoint Yazı Tiplerini Özelleştirme"
linktitle: "Özel Yazı Tipi"
type: docs
weight: 20
url: /tr/cpp/custom-font/
keywords:
- "yazı tipi"
- "özel yazı tipi"
- "harici yazı tipi"
- "yazı tipi yükle"
- "yazı tiplerini yönet"
- "yazı tipi klasörü"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ ile PowerPoint slaytlarındaki yazı tiplerini özelleştirerek sunumlarınızı her cihazda net ve tutarlı tutun."
---
## **Genel Bakış**

Aspose.Slides, özel yazı tiplerini işletim sistemine kurmadan sunumlarda kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belge seviyesindeki yazı tipi kaynakları aracılığıyla belirli bir sunum için yazı tipleri sağlayabilir veya dış yazı tiplerini doğrudan ikili veri olarak yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum **render** edildiğinde veya PDF, görseller ve diğer desteklenen biçimlere dışa aktarıldığında kullanılır. Bu, farklı ortamlar arasında sunum çıktısının tutarlı kalmasını sağlar. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerini nasıl inceleyeceğinizi ve dış yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğini nasıl temizleyeceğinizi açıklar.

Render için özel yazı tiplerini kaydetmek, bir PPTX dosyasına yazı tiplerini gömmekten ayrı bir işlemdir. Bir yazı tipinin sunum içinde saklanması gerekiyorsa, gömme özelliklerini açıkça kullanın.

Bir sunum teması, bireysel yazı sistemleri için farklı yazı tipi ailelerine başvurabilir. Bu eşlemeler yalnızca yazı tipi adlarını depolar; yazı tipi dosyalarını kurmaz veya yüklemez. Eşlemeleri yönetmek için [Script-Specific Theme Fonts](/slides/tr/cpp/script-specific-font-mappings/) sayfasına bakın ve aşağıdaki yükleme seçeneklerini kullanarak başvurulan yazı tiplerini tutarlı render için kullanılabilir hâle getirin.

{{% alert color="info" title="Note" %}}
Aspose Slides, bu yazı tiplerini şu yöntemle yüklemenize izin verir: [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Bakınız: [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) yazı tipleri. Bakınız: [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Özel Yazı Tiplerini Yükleme**

Aspose.Slides, bir sunumda kullanılan yazı tiplerini sistemde kurmadan yüklemenize olanak tanır. Bu, PDF, görseller ve diğer desteklenen formatlar gibi dışa aktarma çıktısını etkiler; böylece oluşturulan belgeler ortamlar arasında tutarlı görünür. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı tipi dosyalarını içeren bir veya daha fazla klasör belirtin.
2. Bu klasörlerden yazı tiplerini yüklemek için statik [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/loadexternalfonts/) yöntemini çağırın.
3. Sunumu yükleyin ve render/ dışa aktarın.
4. Yazı tipi önbelleğini temizlemek için [FontsLoader.clearCache](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/clearcache/) yöntemini çağırın.

Aşağıdaki kod örneği yazı tipi yükleme sürecini gösterir:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Özel yazı tipi dosyalarını içeren klasörleri tanımlayın.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Belirtilen klasörlerden özel yazı tiplerini yükleyin.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Yüklenen yazı tiplerini kullanarak sunumu render/ dışa aktarın (ör. PDF, görseller veya diğer biçimler).
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// İş tamamlandıktan sonra yazı tipi önbelleğini temizleyin.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/loadexternalfonts/) ek klasörleri yazı tipi arama yollarına ekler, ancak yazı tipi başlatma sırasını değiştirmez.  
Yazı tipleri aşağıdaki sırayla başlatılır:

1. İşletim sisteminin varsayılan yazı tipi yolu.  
1. [FontsLoader](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.
{{%/alert %}}

## **Özel Yazı Tipi Klasörlerini Al**

Aspose.Slides, [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/getfontfolders/) metodunu sağlayarak yazı tipi klasörlerini bulmanıza olanak tanır. Bu metod, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini döndürür.

Bu C++ kodu, [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/getfontfolders/) metodunun nasıl kullanılacağını gösterir:

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Bu satır, yazı tipi dosyaları için kontrol edilen klasörleri çıktılar.
// Bunlar, LoadExternalFonts yöntemiyle eklenen klasörler ve sistem yazı tipi klasörleridir.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Sunumla Kullanılan Özel Yazı Tiplerini Belirtme**

Aspose.Slides, sunumla birlikte kullanılacak dış yazı tiplerini belirtmek için [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) özelliğini sunar.

Bu C++ kodu, [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) özelliğinin nasıl kullanılacağını gösterir:

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    // sunumla çalış
    // CustomFont1, CustomFont2 ve assets\fonts & global\fonts klasörleri ile alt klasörlerindeki yazı tipleri sunumda kullanılabilir
}
```

## **Yazı Tiplerini Dışarıdan Yönetme**

Aspose.Slides, dış yazı tiplerini bir bayt dizisine yüklemenize izin veren [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/loadexternalfont/) metodunu sağlar.

Bu C++ kodu, bayt dizisi üzerinden yazı tipi yükleme sürecini gösterir:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// Belgeler dizininin yolu
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **SSS**

### Özel yazı tipleri tüm formatlarda (PDF, PNG, SVG, HTML) dışa aktarımı etkiler mi?

Evet. Bağlantılı yazı tipleri, tüm dışa aktarım formatlarında oluşturucu tarafından kullanılır.

### Özel yazı tipleri sonuç PPTX dosyasına otomatik olarak gömülür mü?

Hayır. Bir yazı tipinin oluşturma için kaydedilmesi, PPTX dosyasına gömülmesiyle aynı şey değildir. Yazı tipinin sunum dosyasının içinde bulunmasını istiyorsanız, açıkça [gömme özelliklerini](/slides/tr/cpp/embedded-font/) kullanmalısınız.

### Özel bir yazı tipi belirli glifleri içermediğinde geri dönüş davranışını kontrol edebilir miyim?

Evet. İstenen glif eksik olduğunda hangi yazı tipinin kullanılacağını kesin olarak tanımlamak için [font substitution](/slides/tr/cpp/font-substitution/), [replacement rules](/slides/tr/cpp/font-replacement/) ve [fallback sets](/slides/tr/cpp/fallback-font/) yapılandırabilirsiniz.

### Linux/Docker konteynerlerinde yazı tiplerini sistem genelinde kurmadan kullanabilir miyim?

Evet. Kendi yazı tipi klasörlerinizi işaretleyebilir veya yazı tiplerini bayt dizilerinden yükleyebilirsiniz. Bu, konteyner imajındaki sistem yazı tipi dizinlerine olan bağımlılığı ortadan kaldırır.

### Lisanslama hakkında—herhangi bir özel yazı tipini kısıtlama olmadan gömebilir miyim?

Yazı tipi lisans uyumluluğu sizin sorumluluğunuzdadır. Şartlar değişiklik gösterir; bazı lisanslar gömme veya ticari kullanımı yasaklayabilir. Çıktıları dağıtmadan önce her zaman yazı tipinin EULA’sını inceleyin.