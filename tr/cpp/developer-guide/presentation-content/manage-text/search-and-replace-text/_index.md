---
title: C++ ile PowerPoint Sunumlarında Metin Arama ve Değiştirme
linktitle: Metin Arama ve Değiştirme
type: docs
weight: 55
url: /tr/cpp/search-and-replace-text/
keywords:
- metin arama
- metin vurgulama
- metin değiştirme
- düzenli ifade
- sonuç geri çağırması
- metin çerçevesi
- denetim raporu
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "PowerPoint sunumlarında metin arama, vurgulama ve değiştirme işlemini Aspose.Slides for C++ ile gerçekleştirirken her eşleşmeyi toplar."
---
## **Genel Bakış**

Aspose.Slides for C++ bireysel bir metin çerçevesinde veya tüm sunumda metin arayabilir, vurgulayabilir ve değiştirebilir. Her işlem, her eşleşme için bir sonuç geri çağırması aracılığıyla uygulamayı bilgilendirebilir. Bu sayede bir sunumu güncellerken eşleşen metin, bağlamı, konumu, metin çerçevesi ve slayt numarasını içeren bir denetim izi oluşturmak mümkün olur.

Bu yetenekler, inceleme, sansürleme, terminoloji denetimleri, şablon temizliği ve otomatik raporlama iş akışları için yararlıdır.

Aşağıdaki ilk örneklerde, ilk slaytta aşağıdaki metni içeren tek bir metin kutusu bulunan “sample.pptx” adlı bir dosya kullanıyoruz:

![Sample text](sample_text.png)

## **Arama Kapsamını Seçin**

Bir işlemi tek bir metin çerçevesiyle sınırlamak için [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) üzerindeki yöntemleri kullanın. Sunumdaki tüm uygulanabilir metni işlemek için [IPresentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/) üzerindeki yöntemleri kullanın.

| İşlem | Tek metin çerçevesi | Tüm sunum |
|---|---|---|
| Literal metni vurgula | [ITextFrame::HighlightText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/highlighttext/) |
| Düzenli ifade eşleşmelerini vurgula | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/highlightregex/) |
| Literal metni değiştir | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/replacetext/) |
| Düzenli ifade eşleşmelerini değiştir | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Metin Eşleştirmeyi Yapılandırın**

Literal‑metin işlemleri için eşleşmeyi kontrol etmek amacıyla [ITextSearchOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextsearchoptions/) kullanın:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) eşleşmeleri yalnızca tam kelimelerle sınırlar.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) karakter duyarlılığının gerekliyip gerekmediğini kontrol eder.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextsearchoptions/set_includenotes/) slayt notlarını sunum‑düzeyindeki arama, değiştirme ve vurgulama işlemlerine dahil eder.

Düzenli ifade işlemleri bir `System::Text::RegularExpressions::Regex` kullanır; bu nedenle büyük/küçük harf duyarlılığı ve kelime sınırları gibi kurallar ifadenin kendisi ve seçenekleriyle tanımlanır.

## **Bir Metin Çerçevesinin Sahibini Belirleme**

Genel metin işleme iş akışları, arama, değiştirme, doğrulama veya dışa aktarma sırasında sıklıkla bir [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) alır. Metin çerçevesinin hangi sunum nesnesine ait olduğunu belirlemek için [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/get_parentshape/) ve [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/get_parentcell/) kullanın.

Beklenen değerler sahibine bağlıdır:

| Metin çerçevesi sahibi | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| Bir AutoShape veya başka bir metin içeren şekil | Sahip olan [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) | `nullptr` |
| Bir tablo hücresi | `nullptr` | Sahip olan [ICell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icell/) |

Her iki yöntem de yalnızca okuma amaçlı gezinme sağlar. Çağrılmaları metin çerçevesini taşımaz veya sahibini değiştirmez. Genel kod, iki değeri de `nullptr` için kontrol etmeli ve hiçbir sahibin mevcut olmama olasılığını ele almalıdır.

Aşağıdaki örnek, bir sunumdaki metin çerçevelerini yinelemek için [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/slideutil/getalltextframes/) kullanır. Şekiller için şekil adını, C++ çalışma zamanı tipini ve içerdiği slaytı raporlar. Tablo hücreleri için ise sıfır‑tabanlı sütun ve satır koordinatları ile içerdiği slaytı raporlar.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using Aspose::Slides::Presentation;
using Aspose::Slides::Util::SlideUtil;
using System::AsCast;
using System::Console;
using System::MakeObject;
using System::String;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto textFrames = SlideUtil::GetAllTextFrames(presentation, false);

for (const auto& textFrame : textFrames)
{
    auto ownerShape = textFrame->get_ParentShape();
    if (ownerShape != nullptr)
    {
        auto shapeName = String::IsNullOrEmpty(ownerShape->get_Name()) ? u"(unnamed)" : ownerShape->get_Name();
        auto shapeType = ownerShape->GetType().get_Name();
        auto baseSlide = ownerShape->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Shape: {0}; type: {1}; {2}", shapeName, shapeType, slideLabel);
        continue;
    }

    auto ownerCell = textFrame->get_ParentCell();
    if (ownerCell != nullptr)
    {
        auto baseSlide = ownerCell->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Table cell: column {0}, row {1}; {2}", ownerCell->get_FirstColumnIndex(), ownerCell->get_FirstRowIndex(), slideLabel);
        continue;
    }

    Console::WriteLine(u"The text frame owner is not available as a shape or table cell.");
}
```

SmartArt içeriği için, [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) içindeki şekilleri yineleyin ve her bir [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/ismartartshape/get_textframe/) öğesine erişin. Metin çerçevesi, [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/get_parentshape/) aracılığıyla ilişkili şekline izlenebilir, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/get_parentcell/) ise `nullptr` döndürür. Bu yüzden örnekteki şekil dalı, SmartArt düğümlerinden gelen metni de işler.

## **Eşleşme Bilgilerini Geri Çağırma ile Topla**

Her eşleşme için bir bildirim almak üzere [IFindResultCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifindresultcallback/) uygulayın. Bu arayüzün [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifindresultcallback/foundresult/) yöntemi ilgili metin çerçevesi, kaynak metin, eşleşen metin ve eşleşme konumunu sağlar.

Geri çağırma doğrudan bir slayt numarası almaz. Aşağıdaki uygulama, bunu [ISlideComponent::get_Slide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecomponent/get_slide/) üzerinden türetir ve ayrıca [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/inotesslide/get_parentslide/) aracılığıyla slayt notlarında bulunan metni işleyebilir. Null‑olan bir slayt numarası, aynı sonuç modelinin diğer slayt türleriyle ilişkili metni temsil etmesini sağlar.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
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
        auto parentShape = textFrame->get_ParentShape();
        auto parentCell = textFrame->get_ParentCell();
        SharedPtr<IBaseSlide> baseSlide;

        if (parentShape != nullptr)
        {
            baseSlide = parentShape->get_Slide();
        }
        else if (parentCell != nullptr)
        {
            baseSlide = parentCell->get_Slide();
        }
        else
        {
            baseSlide = textFrame->get_Slide();
        }

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

Değiştirme işlemleri için, `FoundText` orijinal eşleşen metni içerdiğinden, geri çağırma tam olarak hangi terimlerin değiştirildiğini kaydedebilir.

## **Metni Vurgula**

Literal‑metin eşleşmelerini bir metin çerçevesinde vurgulamak için [ITextFrame::HighlightText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/highlighttext/) yöntemini kullanın. Aramayı kontrol etmek için [ITextSearchOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextsearchoptions/) ve eşleşme ayrıntılarını toplamak için bir geri çağırma geçirin.

Aşağıdaki kod örneği, **"try"** karakterlerinin tüm oluşumlarını vurgular ve ardından yalnızca tam kelime **"to"** yu vurgular. Her iki arama da aynı geri çağırmaya eşleşmelerini raporlar.

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

// İlk slayttan ilk şekli al.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Metin çerçevesinde "try" ifadesinin her oluşumunu vurgula.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Yalnızca tam kelime "to" yu vurgula.
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

![The highlighted text](highlighted_text.png)

## **Düzenli İfadeler Kullanarak Metni Vurgula**

[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/highlightregex/) yöntemi, bir düzenli ifadeyle bulunan metin eşleşmelerini bir metin çerçevesinde vurgular.

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

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Sunum Genelinde Metni Vurgula**

Tüm uygulanabilir metin çerçevelerinde arama yapmak için [IPresentation::HighlightText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/highlighttext/) ve [IPresentation::HighlightRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/highlightregex/) kullanın. Aşağıdaki örnek, bir literal terimi ve tüm e‑posta adreslerini vurgular; iki arama için ayrı sonuç koleksiyonları tutar.

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

Literal metin için [ITextFrame::ReplaceText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/replacetext/), desen‑tabanlı değiştirme için ise [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/replaceregex/) kullanın. Bu yöntemler, eşleşen metni mevcut metin çerçevesi içinde günceller; böylece çevreleyen kısmın biçimlendirmesi korunur ve çerçeve bir düz dizeyle yeniden oluşturulmaz.

Aşağıdaki örnek bir yazım varyantını standartlaştırır ve ardından sürüm etiketlerini değiştirir. Aynı geri çağırma, her iki işlemde eşleşen orijinal terimleri kaydeder.

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

Bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, çıktıyı inceleyerek hangi biçimin değiştirme metnine uygulanacağını doğrulayın.

## **Sunum Genelinde Metni Değiştir**

[IPresentation::ReplaceText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/replacetext/) ve [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/replaceregex/) kullanarak aynı işlemleri tüm sunuma uygulayın. Bu, şablon temizliği, terminoloji güncellemeleri ve sansürleme için yararlıdır.

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

## **Raporlama İçin Eşleşmeleri Gruplama**

Her sonuç slayt numarasını ve metin çerçevesini sakladığından, uygulamalar denetim, raporlama veya inceleme iş akışları için eşleşmeleri gruplayabilir. Aşağıdaki örnek, toplanan sonuçları önce slayta, sonra metin çerçevesine göre gruplayarak gösterir:

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

**Yalnızca bir metin kutusunda, tüm sunumu aramadan nasıl arama yapabilirim?**

Şeklin metin çerçevesini alın ve o çerçevede [ITextFrame::HighlightText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/replacetext/) veya [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/replaceregex/) metodlarını çağırın. Sunum‑düzeyindeki yöntemler ise tüm uygulanabilir metin çerçevelerini işler.

**Tam kelimeleri doğru büyük/küçük harf duyarlılığıyla nasıl eşleştirebilirim?**

[ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) ve [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) metodlarını `true` olarak çağırın ve seçenekleri literal‑metin vurgulama veya değiştirme yöntemiyle birlikte geçirin. Düzenli ifadeler için, kelime sınırlarını ve duyarlılığı ifadenin kendisinde tanımlayın.

**Arama ve değiştirme slayt notlarındaki metni de içerebilir mi?**

Evet. Sunum‑düzeyinde literal‑metin işlemi kullanırken [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextsearchoptions/set_includenotes/) metodunu `true` olarak ayarlayın. Yukarıdaki geri çağırma uygulaması, bir not slaydındaki eşleşmeyi ebeveyn slayt numarasına geri eşler.

**Sunumu ikinci kez taramadan bir rapor nasıl oluşturabilirim?**

Vurgulama veya değiştirme işlemi sırasında bir [IFindResultCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifindresultcallback/) uygulamasını geçirin. Geri çağırma, işlem çalışırken her eşleşmeyi alır; böylece uygulama kaynak metni, eşleşen metni, konumu, metin çerçevesini ve türetilen slayt numarasını daha sonra grup‑lama veya dışa aktarma için saklayabilir.

**Metni değiştirmek biçimlendirmesini korur mu?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/replacetext/) ve [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/replaceregex/) eşleşen metni mevcut metin çerçevesi içinde değiştirir ve çevredeki kısmın biçimlendirmesini korur. Bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, değiştirme işleminin istenen stili kullandığından emin olmak için sonucu inceleyin.