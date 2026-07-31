---
title: C++ ile Sunumlardan Gelişmiş Metin Çıkarma
linktitle: Metin Çıkarma
type: docs
weight: 90
url: /tr/cpp/extract-text-from-presentation/
aliases:
  - /cpp/sunumdan-metni-cikarmak/
keywords:
- metin çıkarma
- slayttan metin çıkarma
- sunumdan metin çıkarma
- PowerPoint'tan metin çıkarma
- OpenDocument'ten metin çıkarma
- PPT'den metin çıkarma
- PPTX'ten metin çıkarma
- ODP'den metin çıkarma
- metin getirme
- slayttan metin getirme
- sunumdan metin getirme
- PowerPoint'tan metin getirme
- OpenDocument'ten metin getirme
- PPT'den metin getirme
- PPTX'ten metin getirme
- ODP'den metin getirme
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument sunumlardan hızlı bir şekilde metin çıkarın. Zaman kazanmak için basit, adım adım rehberimizi izleyin."
---
## **Genel Bakış**

Sunumlardan metin çıkarmak, slayt içeriğiyle çalışan geliştiriciler için yaygın ancak hayati bir görevdir. Microsoft PowerPoint dosyaları PPT veya PPTX formatında olsun, ya da OpenDocument sunumları (ODP) olsun, metinsel verilere erişmek ve bunları almak, analiz, otomasyon, indeksleme veya içerik taşıma amaçları için kritik olabilir.

Bu makale, Aspose.Slides for C++ kullanarak PPT, PPTX ve ODP dahil çeşitli sunum formatlarından metni verimli bir şekilde nasıl çıkaracağınızı kapsamlı bir şekilde anlatır. Sunum öğeleri üzerinde sistematik olarak dolaşarak ihtiyacınız olan metin içeriğini doğru şekilde nasıl alacağınızı öğreneceksiniz.

## **Bir Slayttan Metin Çıkarma**

Aspose.Slides for C++ **[Aspose.Slides.Util](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/)** ad alanını sağlar; bu ad alanı **[SlideUtil](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/slideutil/)** sınıfını içerir. Bu sınıf, bir sunum veya slayttan tüm metni çıkarmak için birkaç aşırı yüklü statik yöntem sunar. Bir sunumdaki bir slayttan metin çıkarmak için **[GetAllTextBoxes](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/slideutil/getalltextboxes/)** yöntemini kullanın. Bu yöntem, parametre olarak **[IBaseSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslide/)** tipinde bir nesne alır. Çalıştırıldığında, yöntem slaytı tamamen tarar, metni bulur ve **[ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/)** tipinde nesneler dizisi döndürür; böylece metin biçimlendirmesi korunur.

Aşağıdaki kod parçacığı, sunumun ilk slaytındaki tüm metni çıkarır:

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

Tüm sunumdaki metni taramak için **[SlideUtil](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/slideutil/)** sınıfı tarafından sunulan **[GetAllTextFrames](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/slideutil/getalltextframes/)** statik yöntemini kullanın. Bu yöntem iki parametre alır:

1. İlk olarak, metnin çıkarılacağı PowerPoint veya OpenDocument sunumunu temsil eden bir **[IPresentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/)** nesnesi.
2. İkinci olarak, sunumdan metin taranırken ana slaytların (master slides) dahil edilip edilmeyeceğini belirten bir `Boolean` değer.

Yöntem, metin biçimlendirme bilgilerini içeren **[ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/)** tipinde nesneler dizisi döndürür. Aşağıdaki kod, bir sunumdan, ana slaytlar da dahil olmak üzere, metin ve biçimlendirme ayrıntılarını tarar.

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

## **Kategorize ve Hızlı Metin Çıkarma**

**[PresentationFactory](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentationfactory/)** sınıfı da sunumlardan tüm metni çıkarmak için yöntemler sağlar:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

**[TextExtractionArrangingMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textextractionarrangingmode/)** enum argümanı, metin çıkarma sonucunun düzenlenme biçimini belirtir ve aşağıdaki değerlere ayarlanabilir:
- `Unarranged` - Slayttaki konumuna bakılmaksızın ham metin.
- `Arranged` - Metin, slayttaki aynı sırayla düzenlenir.

Hızın kritik olduğu durumlarda `Unarranged` modu kullanılabilir; bu mod, `Arranged` modundan daha hızlıdır.

**[IPresentationText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationtext/)**, sunumdan çıkarılan ham metni temsil eder. `get_SlidesText()` yöntemi, **[ISlideText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidetext/)** tipinde nesneler dizisi döndürür. Her nesne, ilgili slayttaki metni temsil eder. **[ISlideText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidetext/)** tipindeki nesnenin aşağıdaki yöntemleri vardır:

- `get_Text()` - Slayt şekillerindeki metin.
- `get_MasterText()` - Bu slaytla ilişkili ana slayt şekillerindeki metin.
- `get_LayoutText()` - Bu slaytla ilişkili düzen (layout) slayt şekillerindeki metin.
- `get_NotesText()` - Bu slaytla ilişkili not slaytı şekillerindeki metin.
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

Aspose.Slides yüksek performans için optimize edilmiştir ve **[büyük sunumları](/slides/tr/cpp/open-presentation/)** bile işleyebilir; bu da gerçek zamanlı ya da toplu işleme senaryoları için uygundur.

**Aspose.Slides sunumlardaki tablolar ve grafiklerden metin çıkarabilir mi?**

Evet. Aspose.Slides, tablolar ve grafikle ilgili nesneler dahil birçok slayt öğesinden metin çıkarabilir; böylece yaygın sunum yapıları içindeki metin içeriğine erişebilir ve analiz edebilirsiniz.

**Sunumlardan metin çıkarmak için özel bir Aspose.Slides lisansına ihtiyacım var mı?**

Metni, Aspose.Slides'in ücretsiz deneme sürümüyle çıkarabilirsiniz; ancak bu sürüm **[bazı sınırlamalara](/slides/tr/cpp/licensing/)** sahiptir, örneğin yalnızca sınırlı sayıda slaytı işleyebilir. Sınırsız kullanım ve daha büyük sunumları işleyebilmek için tam lisans satın almanız önerilir.