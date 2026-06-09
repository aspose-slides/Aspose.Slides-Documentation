---
title: C++'ta PowerPoint Yazı Tiplerini Özelleştir
linktitle: Özel Yazı Tipi
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
description: "Aspose.Slides for C++ ile PowerPoint slaytlarındaki yazı tiplerini özelleştirerek sunumlarınızın her cihazda net ve tutarlı olmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides, işletim sistemine kurulum yapmadan sunumlarda özel yazı tiplerini kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belge düzeyinde yazı tipi kaynakları aracılığıyla belirli bir sunuma yazı tipleri sağlayabilir veya dış yazı tiplerini doğrudan ikili veriden yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum renderlendiğinde veya dışa aktarıldığında, örneğin PDF, görüntüler ve diğer desteklenen formatlara, kullanılır. Bu, sunum çıktısının farklı ortamlar arasında tutarlı kalmasına yardımcı olur. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerinin nasıl inceleneceğini ve dış yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğinin nasıl temizleneceğini açıklar.

Özel yazı tiplerini renderleme için kaydetmek, yazı tiplerini bir PPTX dosyasına gömmekten ayrı bir işlemdir. Bir yazı tipinin sunumun içinde depolanması gerekiyorsa, yazı tipi gömme özelliklerini açıkça kullanın.

{{% alert color="primary" %}} 
Aspose Slides, bu yazı tiplerini [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/loadexternalfonts/) kullanarak yüklemenize olanak tanır:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Bakınız [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) yazı tipleri. Bakınız [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Özel Yazı Tiplerini Yükleme**

Aspose.Slides, bir sunumda kullanılan yazı tiplerini sistemde kurmadan yüklemenize olanak tanır. Bu, PDF, görüntüler ve diğer desteklenen formatlar gibi dışa aktarım çıktısını etkiler; böylece ortaya çıkan belgeler ortamlar arasında tutarlı görünür. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı dosyalarını içeren bir veya daha fazla klasör belirtin.
2. Bu klasörlerden yazı tiplerini yüklemek için statik [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/loadexternalfonts/) yöntemini çağırın.
3. Sunumu yükleyin ve render/çıkartın.
4. Yazı tipi önbelleğini temizlemek için [FontsLoader.clearCache](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/clearcache/) yöntemini çağırın.

Aşağıdaki kod örneği, yazı tipi yükleme sürecini göstermektedir:

```cpp
// Özel yazı tipi dosyalarını içeren klasörleri tanımlayın.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Özel yazı tiplerini belirli klasörlerden yükleyin.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Yüklenen yazı tiplerini kullanarak sunumu renderleyin/ dışa aktarın (örn. PDF, görüntüler veya diğer formatlar).
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// İş tamamlandıktan sonra yazı tipi önbelleğini temizleyin.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/loadexternalfonts/) ek klasörleri yazı tipi arama yollarına ekler, ancak yazı tipi başlatma sırasını değiştirmez.
Yazı tipleri şu sırayla başlatılır:

1. İşletim sisteminin varsayılan yazı tipi yolu.
1. [FontsLoader](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/) üzerinden yüklenen yollar.
{{%/alert %}}

## **Özel Yazı Tipi Klasörlerini Al**

Aspose.Slides, yazı tipi klasörlerini bulmanızı sağlayan [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/getfontfolders/) sağlar. Bu yöntem, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini döndürür.

Bu C++ kodu, [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/getfontfolders/) yönteminin nasıl kullanılacağını gösterir:

``` cpp
// Bu satır, yazı tipi dosyaları için kontrol edilen klasörleri çıktılar.
// Bunlar, LoadExternalFonts yöntemiyle eklenen ve sistem yazı tipi klasörleridir.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Sunumla Kullanılan Özel Yazı Tiplerini Belirtme**

Aspose.Slides, sunumla birlikte kullanılacak dış yazı tiplerini belirtmenizi sağlayan [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) özelliğini sunar.

Bu C++ kodu, [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) özelliğinin nasıl kullanılacağını gösterir:

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    // sunum üzerinde çalışın
    // CustomFont1, CustomFont2 ile birlikte assets\fonts ve global\fonts klasörlerinden ve alt klasörlerinden gelen yazı tipleri de sunumda kullanılabilir.
}
```

## **Yazı Tiplerini Dışarıdan Yönetme**

Aspose.Slides, dış yazı tiplerini bayt dizisine yüklemenizi sağlayan [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/loadexternalfont/) yöntemini sunar.

Bu C++ kodu, bayt dizisi yazı tipi yükleme sürecini göstermektedir:

```cpp
// Belge dizininin yolu
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

**Özel yazı tipleri tüm formatlara (PDF, PNG, SVG, HTML) dışa aktarmayı etkiler mi?**

Evet. Bağlı yazı tipleri, renderleyici tarafından tüm dışa aktarım formatlarında kullanılır.

**Özel yazı tipleri sonuç PPTX dosyasına otomatik olarak gömülür mü?**

Hayır. Bir yazı tipini renderleme için kaydetmek, PPTX dosyasına gömmekle aynı değildir. Yazı tipinin sunum dosyasının içinde taşınması gerekiyorsa, açıkça [gömme özelliklerini](/slides/tr/cpp/embedded-font/) kullanmalısınız.

**Bir özel yazı tipinde belirli glifler eksik olduğunda geri dönüş davranışını kontrol edebilir miyim?**

Evet. İstenen glif eksik olduğunda hangi yazı tipinin kullanılacağını tam olarak tanımlamak için [yazı tipi ikamesi](/slides/tr/cpp/font-substitution/), [değiştirme kuralları](/slides/tr/cpp/font-replacement/) ve [geri dönüş setleri](/slides/tr/cpp/fallback-font/) yapılandırın.

**Yazı tiplerini Linux/Docker konteynerlerinde sistem genelinde kurmadan kullanabilir miyim?**

Evet. Kendi yazı tipi klasörlerinize işaret edebilir veya yazı tiplerini bayt dizilerinden yükleyebilirsiniz. Bu, konteyner imajındaki sistem yazı tipi dizinlerine bağımlılığı ortadan kaldırır.

**Lisanslama konusunda ne? Herhangi bir özel yazı tipini kısıtlama olmadan gömebilir miyim?**

Yazı tipi lisansına uyumluluktan siz sorumludur. Şartlar değişiklik gösterir; bazı lisanslar gömme veya ticari kullanımı yasaklayabilir. Çıktıları dağıtmadan önce her zaman yazı tipinin son kullanıcı lisans sözleşmesini (EULA) inceleyin.