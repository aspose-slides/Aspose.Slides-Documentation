---
title: PowerPoint Yazı Tiplerini C++'ta Özelleştirin
linktitle: Özel Yazı Tipi
type: docs
weight: 20
url: /tr/cpp/custom-font/
keywords:
- yazı tipi
- özel yazı tipi
- harici yazı tipi
- yazı tipi yükleme
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

Aspose.Slides, özel yazı tiplerini işletim sistemine kurmadan sunumlarda kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belge düzeyindeki yazı tipi kaynakları aracılığıyla belirli bir sunum için yazı tipleri sağlayabilir veya harici yazı tiplerini doğrudan ikili veriden yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum render edildiğinde veya PDF, resimler ve diğer desteklenen biçimlere dışa aktarıldığında kullanılır. Bu, sunum çıktısının farklı ortamlar arasında tutarlı kalmasını sağlar. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerini nasıl inceleyeceğinizi ve harici yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğini nasıl temizleyeceğinizi açıklar.

Özel yazı tiplerini render için kaydetmek, bir PPTX dosyasına gömmekten ayrı bir işlemdir. Bir yazı tipinin doğrudan sunum içinde saklanması gerekiyorsa, yazı tipi gömme özelliklerini açıkça kullanın.

{{% alert color="primary" %}} 
Aspose Slides, bu yazı tiplerini [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/loadexternalfonts/) kullanarak yüklemenize olanak tanır:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Ayrıntılar için [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) yazı tipleri. Ayrıntılar için [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Özel Yazı Tiplerini Yükleme**

Aspose.Slides, bir sunumda kullanılan yazı tiplerini sistemde kurmadan yüklemenize imkan verir. Bu, PDF, resimler ve diğer desteklenen biçimler gibi dışa aktarma çıktısını etkileyerek ortaya çıkan belgelerin ortamlar arasında tutarlı görünmesini sağlar. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı tipi dosyalarını içeren bir veya daha fazla klasör belirtin.
2. Bu klasörlerden yazı tiplerini yüklemek için statik [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/loadexternalfonts/) metodunu çağırın.
3. Sunumu yükleyin ve render/dışa aktarın.
4. Yazı tipi önbelleğini temizlemek için [FontsLoader.clearCache](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/clearcache/) metodunu çağırın.

Aşağıdaki kod örneği, yazı tipi yükleme sürecini göstermektedir:

```cpp
// Özel yazı tipi dosyalarını içeren klasörleri tanımlayın.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Belirtilen klasörlerden özel yazı tiplerini yükleyin.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Yüklenen yazı tiplerini kullanarak sunumu render/dışa aktarın (ör. PDF, resimler veya diğer biçimlere).
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// İş bittiğinde yazı tipi önbelleğini temizleyin.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/loadexternalfonts/) ek klasörleri yazı tipi arama yollarına ekler, ancak yazı tipi başlatma sırasını değiştirmez.
Yazı tipleri şu sırayla başlatılır:

1. Varsayılan işletim sistemi yazı tipi yolu.
2. [FontsLoader](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.
{{%/alert %}}

## **Özel Yazı Tipi Klasörlerini Al**

Aspose.Slides, yazı tipi klasörlerini bulmanıza olanak tanıyan [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/getfontfolders/) sağlar. Bu yöntem, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini döndürür.

Bu C++ kodu, [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/getfontfolders/) yöntemini nasıl kullanacağınızı gösterir:

``` cpp
// Bu satır, yazı tipi dosyaları için kontrol edilen klasörleri çıktılar.
// Bunlar, LoadExternalFonts yöntemiyle eklenen klasörler ve sistem yazı tipi klasörleridir.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Sunumla Kullanılan Özel Yazı Tiplerini Belirtme**

Aspose.Slides, sunumla birlikte kullanılacak harici yazı tiplerini belirtmenizi sağlayan [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) özelliğini sunar.

Bu C++ kodu, [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) özelliğini nasıl kullanacağınızı gösterir:

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //sunum ile çalış
    //CustomFont1, CustomFont2 ve assets\fonts ile global\fonts klasörleri ve alt klasörlerindeki yazı tipleri sunumda kullanılabilir
}
```

## **Yazı Tiplerini Dışarıdan Yönetme**

Aspose.Slides, harici yazı tiplerini bir bayt dizisine yüklemenizi sağlayan [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/loadexternalfont/) metodunu sunar.

Bu C++ kodu, bayt dizisi yazı tipi yükleme sürecini göstermektedir:

```cpp
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

**Özel yazı tipleri tüm biçimlere (PDF, PNG, SVG, HTML) dışa aktarmayı etkiler mi?**

Evet. Bağlı yazı tipleri, tüm dışa aktarma biçimlerinde render tarafından kullanılır.

**Özel yazı tipleri sonuç PPTX dosyasına otomatik olarak gömülür mü?**

Hayır. Bir yazı tipini render için kaydetmek, bir PPTX dosyasına gömmekle aynı şey değildir. Yazı tipinin sunum dosyasında taşınması gerekiyorsa, açıkça [gömme özelliklerini](/slides/tr/cpp/embedded-font/) kullanmalısınız.

**Bir özel yazı tipi belirli karakterleri içermediğinde geri dönüş (fallback) davranışını kontrol edebilir miyim?**

Evet. [Yazı tipi ikamesi](/slides/tr/cpp/font-substitution/), [değiştirme kuralları](/slides/tr/cpp/font-replacement/) ve [geri dönüş setleri](/slides/tr/cpp/fallback-font/) yapılandırarak, istenen karakter eksik olduğunda hangi yazı tipinin kullanılacağını kesin olarak tanımlayabilirsiniz.

**Yazı tiplerini Linux/Docker konteynerlerinde sistem genelinde kurmadan kullanabilir miyim?**

Evet. Kendi yazı tipi klasörlerinize işaret edebilir veya yazı tiplerini bayt dizilerinden yükleyebilirsiniz. Bu, konteyner imajındaki sistem yazı tipi dizinlerine olan tüm bağımlılığı ortadan kaldırır.

**Lisanslama hakkında ne söyleyebilirsiniz—herhangi bir özel yazı tipini sınırlama olmadan gömebilir miyim?**

Yazı tipi lisanslama uyumluluğu sizin sorumluluğunuzdadır. Şartlar farklılık gösterir; bazı lisanslar gömme ya da ticari kullanımı yasaklar. Çıktıları dağıtmadan önce her zaman yazı tipinin son kullanıcı lisans anlaşmasını (EULA) inceleyin.