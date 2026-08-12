---
title: PowerPoint Sunumlarında C++ ile Metin Arama ve Değiştirme
linktitle: Metin Arama ve Değiştirme
type: docs
weight: 55
url: /tr/cpp/search-and-replace-text/
keywords:
- metin ara
- metin vurgula
- metin değiştir
- düzenli ifade
- sonuç geri çağrısı
- metin çerçevesi
- denetim raporu
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "PowerPoint sunumlarında metin arayın, vurgulayın ve değiştirin; tüm eşleşmeleri Aspose.Slides for C++ ile toplayın."
---
## **Genel Bakış**

Aspose.Slides for C++ bir metin çerçevesinde veya tüm sunum boyunca metin arayabilir, vurgulayabilir ve değiştirebilir. Her işlem, sonuç geri çağrısı aracılığıyla her eşleşme hakkında bir uygulamayı da bilgilendirebilir. Bu, bir sunumu güncellerken eşleşen metni, bağlamını, konumunu, metin çerçevesini ve slayt numarasını içeren bir denetim izini aynı anda oluşturmayı mümkün kılar.

Bu yetenekler, inceleme, redacte etme, terminoloji kontrolleri, şablon temizliği ve otomatik raporlama iş akışları için faydalıdır.

Aşağıdaki ilk örneklerde, ilk slaytta aşağıdaki metni içeren tek bir metin kutusu bulunan **sample.pptx** adlı bir dosya kullanıyoruz:

![Örnek metin](sample_text.png)

## **Arama Kapsamını Seçin**

[ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) üzerindeki yöntemleri bir işlemi tek bir metin çerçevesiyle sınırlamak için kullanın. [IPresentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/) üzerindeki yöntemleri sunumdaki tüm uygulanabilir metni işlemek için kullanın.

| İşlem | Tek metin çerçevesi | Tüm sunum |
|---|---|---|
| Doğrudan metni vurgula | [ITextFrame::HighlightText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/highlighttext/) |
| Düzenli ifade eşleşmelerini vurgula | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/highlightregex/) |
| Doğrudan metni değiştir | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/replacetext/) |
| Düzenli ifade eşleşmelerini değiştir | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Metin Eşleştirmeyi Yapılandırın**

Doğrudan metin işlemleri için eşleştirmeyi kontrol etmek amacıyla [ITextSearchOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextsearchoptions/) kullanın:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) tam kelimelerle eşleşmeleri sınırlamak için kullanılır.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) karakter büyük/küçük harf duyarlılığını kontrol eder.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextsearchoptions/set_includenotes/) sunum düzeyinde arama, değiştirme ve vurgulama işlemlerine slayt notlarını dahil eder.

Düzenli ifade işlemleri bir `System::Text::RegularExpressions::Regex` kullanır; bu nedenle büyük/küçük harf duyarlılığı ve kelime sınırları gibi eşleşme kuralları ifadenin kendisi ve seçenekleriyle belirlenir.

## **Geri Çağrı ile Eşleşme Bilgilerini Toplayın**

[IFindResultCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifindresultcallback/) uygulayarak her eşleşme için bir bildirim alabilirsiniz. Its [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifindresultcallback/foundresult/) metodu ilgili metin çerçevesini, kaynak metni, eşleşen metni ve eşleşme konumunu sağlar.

Geri çağrı doğrudan bir slayt numarası almaz. Aşağıdaki uygulama bunu [ISlideComponent::get_Slide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecomponent/get_slide/) üzerinden türetir ve [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/inotesslide/get_parentslide/) aracılığıyla slayt notlarında bulunan metni de işler. Null olabilen bir slayt numarası, aynı sonuç modelinin diğer slayt türleriyle ilişkili metni temsil etmesine izin verir.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using System::AsCast;
using System::MakeObject;
using System::Nullable;
using System::SharedPtr;
using System::String;
using System::Collections::Generic::List;

class TextMatch : public System::Object
{
public:
    TextMatch(SharedPtr<ITextFrame> textFrame, String sourceText, String foundText,
        int32_t textPosition, Nullable<int32_t> slideNumber)
        : TextFrame(textFrame), SourceText(sourceText), FoundText(foundText),
          TextPosition(textPosition), SlideNumber(slideNumber)
    {
    }

    SharedPtr<ITextFrame> TextFrame;
    String SourceText;
    String FoundText;
    int32_t TextPosition;
    Nullable<int32_t> SlideNumber;
};

class TextSearchCallback : public IFindResultCallback
{
public:
    TextSearchCallback()
        : Results(MakeObject<List<SharedPtr<TextMatch>>>())
    {
    }

    void FoundResult(SharedPtr<ITextFrame> textFrame, String sourceText,
        String foundText, int32_t textPosition) override
    {
        auto slideNumber = GetSlideNumber(textFrame);
        auto result = MakeObject<TextMatch>(textFrame, sourceText, foundText,
            textPosition, slideNumber);

        Results->Add(result);
    }

    SharedPtr<List<SharedPtr<TextMatch>>> Results;

private:
    static Nullable<int32_t> GetSlideNumber(SharedPtr<ITextFrame> textFrame)
    {
        SharedPtr<IBaseSlide> baseSlide = textFrame->get_Slide();
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            return slide->get_SlideNumber();
        }

        auto notesSlide = AsCast<INotesSlide>(baseSlide);
        if (notesSlide != nullptr)
        {
            auto parentSlide = notesSlide->get_ParentSlide();
            return parentSlide->get_SlideNumber();
        }

        return nullptr;
    }
};
```

Değiştirme işlemleri için `FoundText` özgün eşleşen metni içerir; bu sayede geri çağrı tam olarak hangi terimlerin değiştirildiğini kaydedebilir.

## **Metni Vurgula**

Bir metin çerçevesindeki doğrudan metin eşleşmelerini vurgulamak için [ITextFrame::HighlightText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/highlighttext/) yöntemini kullanın. Aramayı kontrol etmek için [ITextSearchOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextsearchoptions/) ve eşleşme ayrıntılarını toplamak için bir geri çağrı iletin.

Aşağıdaki kod örneği, **"try"** karakterlerinin tüm görünümlerini vurgular ve ardından yalnızca tam **"to"** kelimesini vurgular. Her iki arama da eşleşmelerini aynı geri çağrıya raporlar.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Get the first shape from the first slide.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Highlight every occurrence of "try" in the text frame.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Highlight only the complete word "to".
shape->get_TextFrame()->HighlightText(
    u"to", System::Drawing::Color::get_Violet(), wholeWordSearchOptions, callback);

for (auto&& result : callback->Results)
{
    auto slideLabel = result->SlideNumber.get_HasValue()
        ? System::String::Format(u"{0}", result->SlideNumber.get_Value())
        : u"Other";

    System::Console::WriteLine(u"Found '{0}' at position {1} on slide {2}.",
        result->FoundText, result->TextPosition, slideLabel);
}

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Vurgulanan metin](highlighted_text.png)

## **Düzenli İfadeler Kullanarak Metni Vurgula**

[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/highlightregex/) yöntemi, bir metin çerçevesinde düzenli ifade ile bulunan metin eşleşmelerini vurgular.

Aşağıdaki kod, yedi veya daha fazla karakter içeren tüm kelimeleri vurgular ve her eşleşmeyi toplar:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto regex = MakeObject<Regex>(u"\\b[^\\s]{7,}\\b");

shape->get_TextFrame()->HighlightRegex(
    regex, System::Drawing::Color::get_Yellow(), callback);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Düzenli ifade kullanılarak vurgulanan metin](highlighted_text_using_regex.png)

## **Sunum Genelinde Metni Vurgula**

[IPresentation::HighlightText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/highlighttext/) ve [IPresentation::HighlightRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/highlightregex/) yöntemlerini kullanarak bir sunumdaki tüm uygulanabilir metin çerçevelerini arayın. Aşağıdaki örnek, doğrudan bir terimi ve tüm e-posta adreslerini vurgular ve iki arama için ayrı sonuç koleksiyonları tutar.

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto termCallback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

presentation->HighlightText(
    u"confidential", System::Drawing::Color::get_Orange(), searchOptions, termCallback);

auto emailCallback = MakeObject<TextSearchCallback>();
auto emailRegex = MakeObject<Regex>(
    u"\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", RegexOptions::IgnoreCase);

presentation->HighlightRegex(
    emailRegex, System::Drawing::Color::get_Yellow(), emailCallback);

presentation->Save(u"highlighted_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Bir Metin Çerçevesinde Metni Değiştir**

Doğrudan metin için [ITextFrame::ReplaceText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/replacetext/), kalıba dayalı değiştirme için ise [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/replaceregex/) kullanın. Bu yöntemler, mevcut metin çerçevesindeki eşleşen metni günceller; böylece çerçeveyi düz bir dizeden yeniden oluşturmak yerine çevresindeki kısmın biçimlendirmesini korur.

Aşağıdaki örnek, bir yazım varyantını standartlaştırır ve ardından sürüm etiketlerini değiştirir. Aynı geri çağrı, her iki işlem tarafından eşleşen orijinal terimleri kaydeder.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

shape->get_TextFrame()->ReplaceText(u"colour", u"color", searchOptions, callback);

auto versionRegex = MakeObject<Regex>(
    u"\\bv\\d+(?:\\.\\d+)*\\b", RegexOptions::IgnoreCase);
shape->get_TextFrame()->ReplaceRegex(versionRegex, u"current version", callback);

presentation->Save(u"updated_text_frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, çıkışı inceleyerek hangi biçimlendirmenin değiştirme metnine uygulanması gerektiğini doğrulayın.

## **Sunum Genelinde Metni Değiştir**

[IPresentation::ReplaceText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/replacetext/) ve [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/replaceregex/) kullanarak aynı işlemleri sunum genelinde uygulayın. Bu, şablon temizliği, terminoloji güncellemeleri ve redacte işlemleri için faydalıdır.

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);

presentation->ReplaceText(u"Contoso", u"Example Corp", searchOptions, callback);

auto accountNumberRegex = MakeObject<Regex>(u"\\bACCT-\\d{6}\\b");
presentation->ReplaceRegex(accountNumberRegex, u"ACCT-REDACTED", callback);

presentation->Save(u"updated_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Raporlama İçin Eşleşmeleri Gruplandırma**

Her sonuç slayt numarası ve metin çerçevesini depoladığından, uygulamalar eşleşmeleri denetim, raporlama veya inceleme iş akışları için gruplayabilir. Aşağıdaki örnek, toplanan sonuçları önce slayta, sonra metin çerçevesine göre gruplar:

```cpp
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <system/string.h>
#include <map>
#include <vector>

std::map<int32_t, std::map<Aspose::Slides::ITextFrame*,
    std::vector<System::SharedPtr<TextMatch>>>> matchesBySlide;

for (auto&& result : callback->Results)
{
    int32_t slideKey = result->SlideNumber.get_HasValue()
        ? result->SlideNumber.get_Value()
        : 0;
    auto textFrameKey = result->TextFrame.get();

    matchesBySlide[slideKey][textFrameKey].push_back(result);
}

for (const auto& slideGroup : matchesBySlide)
{
    auto slideLabel = slideGroup.first == 0
        ? System::String(u"Other")
        : System::String::Format(u"{0}", slideGroup.first);
    System::Console::WriteLine(u"Slide: {0}", slideLabel);

    for (const auto& textFrameGroup : slideGroup.second)
    {
        auto textFrameText = textFrameGroup.first->get_Text();
        System::Console::WriteLine(u"  Text frame: {0}", textFrameText);

        for (const auto& result : textFrameGroup.second)
        {
            System::Console::WriteLine(
                u"    '{0}' at position {1}; context: '{2}'",
                result->FoundText, result->TextPosition, result->SourceText);
        }
    }
}
```

## **SSS**

**Tüm sunumu değil sadece bir metin kutusunda nasıl arama yapabilirim?**

Şeklin metin çerçevesini alın ve bu çerçeve üzerinde [ITextFrame::HighlightText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/replacetext/) veya [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/replaceregex/) yöntemlerini çağırın. Sunum düzeyindeki yöntemler ise tüm uygulanabilir metin çerçevelerini işler.

**Tam kelimeleri doğru büyük/küçük harfle nasıl eşleştirebilirim?**

[ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) ve [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) yöntemlerini `true` olarak çağırın ve seçenekleri doğrudan metin vurgulama veya değiştirme yöntemine aktarın. Düzenli ifadeler için, kelime sınırlarını ve büyük/küçük harf duyarlılığını `System::Text::RegularExpressions::Regex` içinde tanımlayın.

**Arama ve değiştirme slayt notlarındaki metni de içerebilir mi?**

Evet. Sunum düzeyinde doğrudan metin işlemi kullanırken [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextsearchoptions/set_includenotes/) yöntemini `true` olarak çağırın. Yukarıdaki geri çağrı uygulaması, bir not slaydındaki eşleşmeyi üst slayt numarasına eşler.

**Sunumu ikinci kez taramadan bir rapor nasıl oluşturabilirim?**

[IFindResultCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifindresultcallback/) bir uygulamasını vurgulama veya değiştirme işlemine aktarın. Geri çağrı, işlem çalışırken her eşleşmeyi alır; böylece uygulama kaynak metni, eşleşen metni, konumu, metin çerçevesini ve türetilen slayt numarasını daha sonra gruplama veya dışa aktarma için saklayabilir.

**Metni değiştirmek biçimlendirmesini korur mu?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/replacetext/) ve [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/replaceregex/) mevcut metin çerçevesindeki eşleşen metni değiştirir ve çevresindeki kısmın biçimlendirmesini korur. Eğer bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, sonuçları inceleyerek değiştirilen metnin istenen stili kullandığından emin olun.