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
- gömülü yazı tipi kaldır
- gömülü yazı tipini sıkıştır
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument sunumlarına TrueType yazı tiplerini gömerek, tüm platformlarda doğru render edilmesini sağlayın."
---
## **Giriş**

**Embedded fonts in PowerPoint** PowerPoint'taki gömülü yazı tipleri, sunumunuzun herhangi bir sistem veya cihazda açıldığında istenen görünümünü korumasına yardımcı olur. Bu, markalaşma veya yaratıcı amaçlar için özel, üçüncü taraf veya standart dışı yazı tipleri kullanıldığında özellikle önemlidir. Gömülü yazı tipleri olmadığında, metin başka bir yazı tipine değiştirilebilir, düzen bozulabilir ve karakterler okunamayan semboller veya dikdörtgenler şeklinde görünebilir; bu da tasarımın bütünlüğünü zedeler.

Aspose.Slides for C++ gömülü yazı tiplerini programlı olarak yönetmek için güçlü bir dizi API sağlar. Sunum dosyalarınızda gömülü yazı tiplerini incelemek, eklemek veya kaldırmak için [FontsManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/) ve [FontData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontdata/) sınıflarını kullanabilirsiniz. Ayrıca, [Compress](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/) sınıfı, kaliteyi veya görünümü etkilemeden yazı tipi verisini sıkıştırarak dosya boyutunu optimize etmenizi sağlar.

Bu araçlar, yazı tipi gömmesi üzerinde tam kontrol sağlar; böylece gerektiğinde dosya boyutunu küçültürken platformlar arasında tutarlı tipografiyi korumanıza yardımcı olur.

## **Bir Sunumdan Gömülü Yazı Tiplerini Al**

Aspose.Slides for C++ FontsManager sınıfı üzerinden `GetEmbeddedFonts` yöntemini sunar; bu yöntem, bir PowerPoint sunumunda gömülü olan yazı tiplerinin listesini almanızı sağlar. Bu, yazı tipi kullanımını denetlemek, marka yönergelerine uyumu sağlamak veya dosyayı paylaşmadan önce gerekli tüm yazı tiplerinin doğru şekilde dahil edildiğini doğrulamak için yararlı olabilir.

Aşağıdaki C++ kodu, bir sunum dosyasından gömülü yazı tiplerini nasıl alacağınızı gösterir:

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Tüm gömülü yazı tiplerini alın.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Gömülü yazı tiplerinin adlarını yazdırın.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Bir Sunuma Gömülü Yazı Tipi Ekle**

Aspose.Slides for C++ AddEmbeddedFont yöntemiyle bir PowerPoint sunumuna yazı tipleri gömmeyi sağlar; bu yöntem iki aşırı yükleme (overload) ile esnek kullanım sunar. [EmbedFontCharacters](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/embedfontcharacters/) enumarasyonunu kullanarak gömülen yazı tipi karakter sayısını kontrol edebilirsiniz — örneğin yalnızca kullanılan karakterleri ya da tüm yazı tipi kümesini gömmeyi seçebilirsiniz. Bu özellik, sunumu paylaşım veya dağıtım için hazırlarken özellikle faydalıdır; özel veya standart dışı yazı tiplerinin, ilgili yazı tipleri yüklü olmasa bile tüm sistemlerde doğru görünmesini sağlar.

Aşağıdaki C++ kodu, bir sunumda kullanılan tüm yazı tiplerini kontrol eder ve hâlihazırda gömülü olmayanları gömer:

```cpp
// Bir sunum dosyasını yükleyin.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Yazı tipinin zaten gömülü olup olmadığını kontrol edin.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Yazı tipini sunuma gömün.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Sunumu diske kaydedin.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Bir Sunumdan Gömülü Yazı Tiplerini Kaldır**

Aspose.Slides for C++ FontsManager sınıfı üzerinden `RemoveEmbeddedFont` yöntemini sunar; bu yöntem bir PowerPoint sunumunda gömülü belirli bir yazı tipini kaldırmanıza olanak tanır. Bu, gömülü yazı tipleri artık kullanılmadığında veya gereksiz olduğunda dosya boyutunu azaltmaya yardımcı olabilir. Kullanılmayan yazı tiplerini kaldırmak aynı zamanda performansı iyileştirir ve sunumunuzun yalnızca gerekli kaynakları içermesini sağlar.

Aşağıdaki C++ kodu, bir sunumdan gömülü bir yazı tipini nasıl kaldıracağınızı gösterir:

```cpp
auto fontName = u"Calibri";

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Tüm gömülü yazı tiplerini alın.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Gömülü yazı tipini kaldırın.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Gömülü Yazı Tiplerini Sıkıştır**

Aspose.Slides for C++ [Compress](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/) sınıfı aracılığıyla `CompressEmbeddedFonts` yöntemini sunar; bu yöntem gömülü yazı tipi verisini optimize ederek bir sunumun toplam dosya boyutunu azaltmanıza olanak tanır. Sunumunuz büyük veya birden çok yazı tipi içerdiğinde ve dosyayı paylaşım, depolama veya çevrimiçi kullanım için hafif tutmak istediğinizde — içeriğin görsel bütünlüğünü bozmadan — özellikle kullanışlıdır.

Aşağıdaki C++ kodu, bir PowerPoint sunumunda gömülü yazı tiplerini nasıl sıkıştıracağınızı gösterir:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SSS**

**Gömülü olmasına rağmen bir yazı tipinin yine de render sırasında değiştirileceğini nasıl anlayabilirim?**  
[yerine koyma bilgisi](/slides/tr/cpp/font-substitution/) ve [yedekleme/yerine koyma kuralları](/slides/tr/cpp/fallback-font/) incelenerek font yöneticisinde kontrol edilebilir: yazı tipi mevcut değilse veya kısıtlıysa bir yedekleme kullanılacaktır.

**Arial/Calibri gibi “sistem” yazı tiplerini gömmek mantıklı mı?**  
Genellikle hayır—bu yazı tipleri neredeyse her zaman mevcuttur. Ancak “ince” ortamların (Docker, önceden yüklü font olmayan bir Linux sunucusu) tam taşınabilirliğini sağlamak için sistem yazı tiplerini gömmek, beklenmedik değişiklik riskini ortadan kaldırabilir.