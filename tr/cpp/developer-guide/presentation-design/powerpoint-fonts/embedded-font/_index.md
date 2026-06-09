---
title: C++ Kullanarak Sunumlarda Yazı Tiplerini Gömme
linktitle: Yazı Tipi Gömme
type: docs
weight: 40
url: /tr/cpp/embedded-font/
keywords:
- yazı tipi ekle
- yazı tipi gömme
- yazı tipi gömme
- gömülü yazı tipini al
- gömülü yazı tipi ekle
- gömülü yazı tipini kaldır
- gömülü yazı tipini sıkıştır
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument sunumlarında TrueType yazı tiplerini gömerek, tüm platformlarda doğru render almayı sağlayın."
---
## **Giriş**

**PowerPoint’te gömülü yazı tipleri**, sunumunuzun herhangi bir sistem veya cihazda açıldığında planlanan görünümünü korumasını sağlar. Bu, marka kimliği veya yaratıcı amaçlar için özel, üçüncü‑taraf veya standart dışı yazı tipleri kullanıldığında özellikle önemlidir. Gömülü yazı tipleri olmadan, metin başka bir yazı tipiyle değiştirilebilir, düzen bozulabilir ve karakterler okunamaz semboller ya da dikdörtgenler şeklinde görünebilir; bu da tasarımın bütünlüğünü zedeler.

Aspose.Slides for C++, gömülü yazı tiplerini program aracılığıyla yönetmek için güçlü API’ler sunar. Sunum dosyalarınızda gömülü yazı tiplerini incelemek, eklemek veya kaldırmak için [FontsManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/) ve [FontData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontdata/) sınıflarını kullanabilirsiniz. Ayrıca, kaliteyi veya görünümü etkilemeden yazı tipi verisini sıkıştırarak dosya boyutunu optimize etmenizi sağlayan [Compress](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/) sınıfı da mevcuttur.

Bu araçlar, font gömme üzerinde tam kontrol sağlayarak platformlar arasında tutarlı tipografi sürdürmenize ve gerektiğinde dosya boyutunu azaltmanıza yardımcı olur.

## **Bir Sunumdan Gömülü Yazı Tiplerini Almak**

Aspose.Slides for C++ `GetEmbeddedFonts` yöntemini, bir PowerPoint sunumunda gömülü olan yazı tiplerinin listesini almanızı sağlayan [FontsManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/) sınıfı aracılığıyla sunar. Bu, yazı tipi kullanımını denetlemek, marka yönergelerine uyumu sağlamak veya dosyayı paylaşmadan önce gerekli tüm yazı tiplerinin doğru bir şekilde dahil edildiğini doğrulamak için faydalı olabilir.

Aşağıdaki C++ kodu, bir sunum dosyasından gömülü yazı tiplerini nasıl alacağınızı gösterir:

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Get all embedded fonts.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Print names of the embedded fonts.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Bir Sunuma Gömülü Yazı Tipi Eklemek**

Aspose.Slides for C++ [AddEmbeddedFont](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/addembeddedfont/) yöntemini kullanarak bir PowerPoint sunumuna yazı tipi gömebilirsiniz; bu yöntem iki aşırı yüklemesiyle esnek bir kullanım sunar. [EmbedFontCharacters](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/embedfontcharacters/) enum’ı sayesinde gömülen karakter miktarını kontrol edebilirsiniz — örneğin yalnızca kullanılan karakterleri ya da tüm yazı tipi setini gömebilirsiniz. Bu özellik, sunumu paylaşım veya dağıtım için hazırlarken, özel veya standart dışı yazı tiplerinin tüm sistemlerde doğru görünmesini sağlamak için özellikle yararlıdır; bu sistemlerde ilgili yazı tipleri yüklü olmayabilir.

Aşağıdaki C++ kodu, bir sunumda kullanılan tüm yazı tiplerini kontrol eder ve hâlâ gömülmemiş olanları gömer:

```cpp
// Bir sunum dosyasını yükle.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Yazı tipinin zaten gömülü olup olmadığını kontrol et.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Yazı tipini sunuma göm.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Sunumu diske kaydet.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Bir Sunumdan Gömülü Yazı Tipi Kaldırmak**

Aspose.Slides for C++ `RemoveEmbeddedFont` yöntemini, bir PowerPoint sunumunda gömülü belirli bir yazı tipini kaldırmanızı sağlayan [FontsManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/) sınıfı aracılığıyla sunar. Bu, gömülü yazı tipleri artık kullanılmadığında veya gerekmediğinde toplam dosya boyutunu azaltmaya yardımcı olur. Kullanılmayan yazı tiplerini kaldırmak ayrıca performansı iyileştirir ve sunumunuzun yalnızca gerekli kaynakları içermesini sağlar.

Aşağıdaki C++ kodu, bir sunumdan gömülü bir yazı tipinin nasıl kaldırılacağını gösterir:

```cpp
auto fontName = u"Calibri";

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Tüm gömülü yazı tiplerini al.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Gömülü yazı tipini kaldır.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Gömülü Yazı Tiplerini Sıkıştırmak**

Aspose.Slides for C++ `CompressEmbeddedFonts` yöntemini, gömülü yazı tipi verisini optimize ederek bir sunumun toplam dosya boyutunu azaltmanızı sağlayan [Compress](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/) sınıfı aracılığıyla sunar. Bu, sunumunuzda büyük veya birden çok yazı tipi bulunduğunda ve dosyayı paylaşım, depolama veya çevrimiçi kullanım için hafif tutmak istediğinizde özellikle faydalıdır — içerik görsel bütünlüğünden ödün vermeden.

Aşağıdaki C++ kodu, bir PowerPoint sunumunda gömülü yazı tiplerini nasıl sıkıştıracağınızı gösterir:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SSS**

**Gömülmüş bir yazı tipi, render sırasında hâlâ değiştirilecek mi, nasıl anlayabilirim?**

Yazı tipi yöneticisindeki [substitution information](/slides/tr/cpp/font-substitution/) ve [fallback/substitution rules](/slides/tr/cpp/fallback-font/) bölümlerine bakın; eğer yazı tipi kullanılamaz ya da kısıtlıysa bir yedek kullanılacaktır.

**Arial/Calibri gibi “sistem” yazı tiplerini gömmek mantıklı mı?**

Genellikle hayır — bu yazı tipleri hemen her yerde bulunur. Ancak “ince” ortamlarda (Docker, önceden yüklü yazı tipi olmayan bir Linux sunucusu) tam taşınabilirlik için sistem yazı tiplerini gömmek beklenmedik değişiklik riskini ortadan kaldırabilir.