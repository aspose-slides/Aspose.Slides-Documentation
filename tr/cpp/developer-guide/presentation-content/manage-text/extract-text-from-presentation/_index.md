---
title: C++ ile Sunumlardan Gelişmiş Metin Çıkarma
linktitle: Metni Çıkar
type: docs
weight: 90
url: /tr/cpp/extract-text-from-presentation/
keywords:
- "metin çıkarma"
- "slayttan metin çıkarma"
- "sunumdan metin çıkarma"
- "PowerPoint'tan metin çıkarma"
- "OpenDocument'ten metin çıkarma"
- "PPT'den metin çıkarma"
- "PPTX'ten metin çıkarma"
- "ODP'den metin çıkarma"
- "metin getirme"
- "slayttan metin getirme"
- "sunumdan metin getirme"
- "PowerPoint'tan metin getirme"
- "OpenDocument'ten metin getirme"
- "PPT'den metin getirme"
- "PPTX'ten metin getirme"
- "ODP'den metin getirme"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument sunumlardan hızlıca metin çıkarın. Zaman tasarrufu için basit, adım adım rehberimizi izleyin."
---
## **Genel Bakış**

Sunumlardan metin çıkarmak, slayt içeriğiyle çalışan geliştiriciler için yaygın ancak önemli bir görevdir. Microsoft PowerPoint dosyaları PPT veya PPTX formatında ya da OpenDocument sunumları (ODP) ile çalışıyor olun, metinsel verilere erişmek ve bunları almak analiz, otomasyon, indeksleme veya içerik taşıma amaçları için kritik olabilir.

Bu makale, Aspose.Slides for C++ kullanarak PPT, PPTX ve ODP dahil çeşitli sunum formatlarından metni verimli bir şekilde nasıl çıkaracağınızı kapsamlı bir rehber sunar. Sunum öğeleri üzerinden sistematik olarak nasıl yineleme yaparak ihtiyacınız olan metin içeriğini doğru bir şekilde alabileceğinizi öğreneceksiniz.

## **Bir Slayttan Metin Çıkarma**

Aspose.Slides for C++ , [Aspose.Slides.Util](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/) ad alanını sağlar; bu ad alanda [SlideUtil](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/slideutil/) sınıfı bulunur. Bu sınıf, bir sunum veya slayttan tüm metni çıkarmak için birkaç aşırı yüklenmiş statik yöntem sunar. Bir sunumdaki slayttan metin çıkarmak için [GetAllTextBoxes](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/slideutil/getalltextboxes/) yöntemini kullanın. Bu yöntem, parametre olarak [IBaseSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslide/) türünde bir nesne alır. Çalıştırıldığında, yöntem tüm slaytı metin için tarar ve metin biçimlendirmesini koruyan [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) türünde nesneler dizisi döndürür.

Aşağıdaki kod parçacığı, sunumun ilk slaydındaki tüm metni çıkarır:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Bir Sunumdan Metin Çıkarma**

Sunumun tamamındaki metni taramak için [SlideUtil](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/slideutil/) sınıfı tarafından sunulan [GetAllTextFrames](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/slideutil/getalltextframes/) statik yöntemini kullanın. Bu yöntem iki parametre alır:

1. İlk parametre, metnin çıkarılacağı bir PowerPoint veya OpenDocument sunumunu temsil eden bir [IPresentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/) nesnesidir.
1. İkinci parametre, sunumdan metin taranırken ana slaytların (master slides) dahil edilip edilmeyeceğini belirten bir `Boolean` değeridir.

Yöntem, metin biçimlendirme bilgilerini içeren [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) türünde nesneler dizisi döndürür. Aşağıdaki kod, ana slaytlar dahil olmak üzere bir sunumdan metin ve biçimlendirme ayrıntılarını tarar.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Kategorize Edilmiş ve Hızlı Metin Çıkarma**

[PresentationFactory](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentationfactory/) sınıfı da sunumlardan tüm metni çıkarmak için yöntemler sunar:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textextractionarrangingmode/) enum argümanı, metin çıkarma sonucunun düzenleme modunu gösterir ve aşağıdaki değerlerden biri olarak ayarlanabilir:
- `Unarranged` - Slayttaki konumuna bakılmaksızın ham metin.
- `Arranged` - Metin, slayttaki aynı sırada düzenlenir.

Hızın kritik olduğu durumlarda düzenlenmemiş (unarranged) mod kullanılabilir; bu mod, düzenlenmiş (arranged) moddan daha hızlıdır.

[IPresentationText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationtext/) sunumdan çıkarılan ham metni temsil eder. `get_SlidesText()` yöntemi, [ISlideText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidetext/) türünde nesneler dizisi döndürür. Her nesne, ilgili slaydın metnini temsil eder. [ISlideText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidetext/) türündeki nesnenin aşağıdaki yöntemleri vardır:
- `get_Text()` - Slayt şekilleri içindeki metin.
- `get_MasterText()` - Bu slaytla ilişkili ana slayd (master slide) şekilleri içindeki metin.
- `get_LayoutText()` - Bu slaytla ilişkili düzen slaydının (layout slide) şekilleri içindeki metin.
- `get_NotesText()` - Bu slaytla ilişkili not slaydının şekilleri içindeki metin.
- `get_CommentsText()` - Bu slaytla ilişkili yorumlardaki metin.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **SSS**

**Aspose.Slides büyük sunumları metin çıkarma sırasında ne kadar hızlı işler?**

Aspose.Slides yüksek performans için optimize edilmiştir ve hatta [büyük sunumları](/slides/tr/cpp/open-presentation/) işleyebilir; bu da gerçek zamanlı veya toplu işleme senaryoları için uygundur.

**Aspose.Slides sunumlardaki tablolar ve grafiklerden metin çıkarabilir mi?**

Evet. Aspose.Slides, tablolar ve grafikle ilgili nesneler dahil birçok slayt öğesinden metin çıkarabilir; böylece yaygın sunum yapılarındaki metin içeriğine erişebilir ve analiz edebilirsiniz.

**Sunumlardan metin çıkarmak için özel bir Aspose.Slides lisansına ihtiyacım var mı?**

Aspose.Slides'in ücretsiz deneme sürümünü kullanarak metin çıkarabilirsiniz, ancak bu sürümün [belirli kısıtlamaları](/slides/tr/cpp/licensing/) vardır; örneğin sadece sınırlı sayıda slaytı işleyebilir. Sınırsız kullanım ve daha büyük sunumları işleyebilmek için tam bir lisans satın almanız önerilir.