---
title: C++ ile PowerPoint Fontlarını Özelleştir
linktitle: Özel Font
type: docs
weight: 20
url: /tr/cpp/custom-font/
keywords:
- yazı tipi
- özel yazı tipi
- harici yazı tipi
- yazı tipi yükle
- yazı tiplerini yönet
- yazı tipi klasörü
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint slaytlarındaki yazı tiplerini özelleştirerek sunumlarınızı her cihazda net ve tutarlı tutun."
---
## **Overview**

Aspose.Slides, özel fontları işletim sistemine kurmadan sunumlarda kullanmanıza olanak tanır. Fontları özel klasörlerden yükleyebilir, belge düzeyindeki font kaynakları aracılığıyla belirli bir sunuma font sağlayabilir veya dış fontları doğrudan ikili veri olarak yükleyebilirsiniz.

Yüklenen fontlar, bir sunum render edildiğinde veya PDF, görüntüler ve diğer desteklenen formatlara dışa aktarıldığında kullanılır. Bu, sunum çıktısının farklı ortamlar arasında tutarlı kalmasına yardımcı olur. Makale ayrıca Aspose.Slides tarafından kullanılan font klasörlerini nasıl inceleyeceğinizi ve dış fontlarla çalıştıktan sonra font önbelleğini nasıl temizleyeceğinizi açıklar.

Render için özel fontları kaydetmek, fontları bir PPTX dosyasına gömmekten ayrı bir işlemdir. Eğer bir fontun sunum içinde saklanması gerekiyorsa, font gömme özelliklerini açıkça kullanın.

{{% alert color="info" %}} 
Aspose Slides, bu fontları [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/loadexternalfonts/) kullanarak yüklemenize olanak tanır:

* TrueType (.ttf) ve TrueType Collection (.ttc) fontları. Bakınız [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) fontları. Bakınız [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Özel Fontları Yükleme**

Aspose.Slides, bir sunumda kullanılan fontları sistemde kurmadan yüklemenize olanak tanır. Bu, PDF, görüntüler ve diğer desteklenen formatlar gibi dışa aktarma çıktısını etkiler; böylece ortaya çıkan belgeler ortamlar arasında tutarlı görünür. Fontlar özel dizinlerden yüklenir.

1. Font dosyalarını içeren bir veya daha fazla klasör belirtin.
2. Bu klasörlerden fontları yüklemek için statik [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/loadexternalfonts/) yöntemini çağırın.
3. Sunumu yükleyin ve render/dışa aktarın.
4. Font önbelleğini temizlemek için [FontsLoader.clearCache](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/clearcache/) yöntemini çağırın.

Aşağıdaki kod örneği font yükleme sürecini göstermektedir:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Özel font dosyalarını içeren klasörleri tanımlayın.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Belirtilen klasörlerden özel fontları yükleyin.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Yüklenen fontları kullanarak sunumu render/dışa aktarın (örn. PDF, görüntüler veya diğer formatlar).
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// İş bittiğinde font önbelleğini temizleyin.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/loadexternalfonts/) font arama yollarına ek klasörler ekler, ancak font başlatma sırasını değiştirmez.
Fontlar aşağıdaki sırayla başlatılır:

1. Varsayılan işletim sistemi font yolu.
1. [FontsLoader](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/) ile yüklenen yollar.

{{%/alert %}}

## **Özel Font Klasörlerini Al**

Aspose.Slides, font klasörlerini bulmanızı sağlayan [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/getfontfolders/) metodunu sunar. Bu yöntem, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem font klasörlerini döndürür.

Bu C++ kodu, [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/getfontfolders/) yönteminin nasıl kullanılacağını gösterir:

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Bu satır, font dosyaları için kontrol edilen klasörleri çıktı olarak verir.
// Bunlar, LoadExternalFonts yöntemiyle eklenen klasörler ve sistem font klasörleridir.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Bir Sunumla Kullanılan Özel Fontları Belirleme**

Aspose.Slides, sunumla birlikte kullanılacak dış fontları belirlemenizi sağlayan [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) özelliğini sunar.

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
    //sunumla çalış
    //CustomFont1, CustomFont2 ve assets\fonts & global\fonts klasörleri ve alt klasörlerinden gelen fontlar sunum için kullanılabilir
}
```

## **Fontları Dışarıdan Yönetme**

Aspose.Slides, dış fontları bir bayt dizisine yüklemenizi sağlayan [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/loadexternalfont/) yöntemini sunar.

Bu C++ kodu, bayt dizisi font yükleme sürecini göstermektedir:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// Belgeler dizinine giden yol
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

### Özel fontlar tüm formatlara (PDF, PNG, SVG, HTML) dışa aktarmayı etkiler mi?

Evet. Bağlı fontlar, render tarafından tüm dışa aktarma formatlarında kullanılır.

### Özel fontlar otomatik olarak oluşturulan PPTX dosyasına gömülür mü?

Hayır. Bir fontu render için kaydetmek, onu bir PPTX dosyasına gömmekle aynı şey değildir. Fontun sunum dosyası içinde bulunmasını istiyorsanız, açıkça [gömme özelliklerini](/slides/tr/cpp/embedded-font/) kullanmalısınız.

### Özelleştirilmiş bir font belirli glifleri içermediğinde geri dönüş (fallback) davranışını kontrol edebilir miyim?

Evet. İstenen glif bulunmadığında hangi fontun kullanılacağını kesin olarak tanımlamak için [font ikamesi](/slides/tr/cpp/font-substitution/), [değiştirme kuralları](/slides/tr/cpp/font-replacement/) ve [geri dönüş setleri](/slides/tr/cpp/fallback-font/) yapılandırabilirsiniz.

### Fontları Linux/Docker konteynerlerinde sistem genelinde kurmadan kullanabilir miyim?

Evet. Kendi font klasörlerinize işaret edebilir veya fontları bayt dizilerinden yükleyebilirsiniz. Bu, konteyner imajında sistem font dizinlerine olan bağımlılığı ortadan kaldırır.

### Lisanslama konusunda—herhangi bir özel fontu kısıtlama olmadan gömebilir miyim?

Font lisans uyumluluğundan siz sorumlusunuz. Şartlar değişiklik gösterebilir; bazı lisanslar gömmeyi veya ticari kullanımı yasaklar. Çıktıları dağıtmadan önce her zaman fontun EULA'sını gözden geçirin.