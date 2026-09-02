---
title: C++'ta Sunum Yerelleştirmesini Otomatikleştir
linktitle: Sunum Yerelleştirmesi
type: docs
weight: 100
url: /tr/cpp/presentation-localization/
keywords:
- dil değiştir
- imla kontrolü
- imla kontrolünü devre dışı bırak
- düzeltme dili
- dil kimliği
- çok dilli metin
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides ile C++'ta PowerPoint ve OpenDocument sunum metinleri için proofing dillerini ayarlayın; varsayılanlar ve çok dilli paragraflar dahil."
---
## **Genel Bakış**

Aspose.Slides for C++ size, bireysel metin bölümleri için proofing üst verilerini yapılandırmanıza olanak tanır. Proofing dilini belirlemek için [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/set_languageid/), imla denetimini izin vermek veya engellemek için [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseportionformat/set_spellcheck/) ve daha geniş kanıtlamama durumunu kontrol etmek için [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseportionformat/set_proofdisabled/) kullanın. Bu ayarlar bölüm seviyesinde uygulandığı için bir paragraf birden çok dil ve farklı proofing kuralları içerebilir.

Bu makale, belirli bir metne dil atamayı, yeni metin için varsayılan dili [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) ile ayarlamayı, çok dilli paragraflar oluşturmayı, `SpellCheck` ile `ProofDisabled` arasında seçim yapmayı ve [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/joinportionswithsameformatting/) kullanırken hedef ayarların korunmasını açıklar. Bu özellikler, sunum uygulamaları için üst veri depolar; metni çevirmez, sözlük tabanlı imla denetimi yapmaz veya hatalı yazılmış kelimeleri döndürmez.

## **Metin İçin Proofing Dilini Ayarlama**

Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) oluşturun veya yükleyin, gerekli metin bölümüne [IPortion::get_PortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/get_portionformat/) aracılığıyla erişin ve dil tanımlayıcısını atayın. Aşağıdaki örnek bir şekil oluşturur, British English’i proofing dili olarak ayarlar ve sonucu [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) ile kaydeder:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Set the proofing language for this text.");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LanguageId(u"en-GB");

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Yeni Metin İçin Varsayılan Dili Ayarlama**

[ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) kullanarak Aspose.Slides’in yeni oluşturulan metne atayacağı proofing dilini belirtebilirsiniz. Bu ayar, bir sunumdaki çoğu ya da tüm yeni metnin aynı dili kullanması durumunda yararlıdır. Zaten açık bir dil tanımlaması olan metnin dil üst verisini değiştirmez.

Aşağıdaki örnek, yeni metnin Almanca proofing kurallarını kullandığı bir sunum oluşturur:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"de-DE");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Willkommen zur Präsentation");

presentation->Save(u"default_text_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Tek Bir Paragrafta Birden Çok Dil Kullanma**

[IParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/) bir metin bölümü koleksiyonu içerir. Her dil için ayrı bir [Portion](https://reference.aspose.com/slides/tr/cpp/aspose.slides/portion/) oluşturun ve `LanguageId` özelliğini bağımsız olarak ayarlayın.

Bu örnek, İngilizce ve Fransızca bölümler içeren bir paragraf oluşturur:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto englishPortion = System::MakeObject<Portion>(u"Welcome");
englishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Bireysel Bölümler İçin İmla Denetimini Etkinleştirme veya Kapatma**

[IPortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportionformat/) , [IBasePortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/) tarafından tanımlanan ortak metin özelliklerini devralır. Bir bölümün formatına [IPortion::get_PortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/get_portionformat/) aracılığıyla erişin ve [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseportionformat/set_spellcheck/) çağırarak bir sunum uygulamasının o bölüm için imla denetimi yapıp yapmayacağını kontrol edin. Varsayılan değer `false`’tır: `true` imla denetimini etkinleştirir, `false` ise engeller.

Bu ayar bireysel metin bölümlerine uygulanır. Aynı paragraftaki farklı bölümler bu nedenle farklı değerler kullanabilir. [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseportionformat/set_languageid/) ve `SpellCheck` birbirini tamamlayan amaçlara hizmet eder: `LanguageId` proofing dilini belirler, `SpellCheck` ise o bölüm için imla denetiminin izin verilip verilmediğini belirler.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseportionformat/set_proofdisabled/) ayrıca proofing’i kontrol eder, ancak daha geniş “kanıtlanmasın” durumunu bir [NullableBool](https://reference.aspose.com/slides/tr/cpp/aspose.slides/nullablebool/) olarak temsil eder. `SpellCheck` yalnızca imla denetimi için doğrudan bir Boolean anahtarına ihtiyacınız olduğunda kullanın. `ProofDisabled` ise sunumun no‑proof üst verisini, özellikle `NullableBool::NotDefined` durumunu korumak veya açıkça kontrol etmek istediğinizde kullanın. Her iki özelliği de ayarlarsanız, değerlerin tutarlı olmasına dikkat edin; `SpellCheck = true` ile `ProofDisabled = NullableBool::True` kombinasyonunu yapmayın.

Bu özellikler, PowerPoint ve diğer sunum uygulamaları tarafından kullanılan proofing üst verisini yapılandırır. Aspose.Slides bu verileri sözlük tabanlı imla denetimi yapmak veya hatalı kelimelerin listesini döndürmek için kullanmaz.

Aşağıdaki tam örnek bir giriş sunumu oluşturur, yükler, aynı paragraftaki iki bölüme farklı imla denetim ayarları ve proofing dilleri atar, sonucu kaydeder, yeniden açar ve saklanan değerleri doğrular:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputFile = u"spell_check_input.pptx";
const System::String outputFile = u"spell_check_settings.pptx";

{
    auto sourcePresentation = System::MakeObject<Presentation>();
    auto sourceSlide = sourcePresentation->get_Slide(0);
    auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
    auto sourceParagraph = sourceShape->get_TextFrame()->get_Paragraph(0);
    sourceParagraph->get_Portions()->Clear();

    auto sourceEnglishPortion = System::MakeObject<Portion>(u"Check this text. ");
    sourceEnglishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    sourceParagraph->get_Portions()->Add(sourceEnglishPortion);

    auto sourceFrenchPortion = System::MakeObject<Portion>(u"Ignorer ce code : ZX-81.");
    sourceFrenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    sourceParagraph->get_Portions()->Add(sourceFrenchPortion);

    sourcePresentation->Save(inputFile, SaveFormat::Pptx);
    sourcePresentation->Dispose();
}

{
    auto presentation = System::MakeObject<Presentation>(inputFile);
    auto firstShape = presentation->get_Slide(0)->get_Shape(0);
    auto shape = System::ExplicitCast<IAutoShape>(firstShape);
    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

    auto checkedPortion = paragraph->get_Portion(0);
    checkedPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    checkedPortion->get_PortionFormat()->set_SpellCheck(true);

    auto suppressedPortion = paragraph->get_Portion(1);
    suppressedPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    suppressedPortion->get_PortionFormat()->set_SpellCheck(false);

    presentation->Save(outputFile, SaveFormat::Pptx);
    presentation->Dispose();
}

auto reopenedPresentation = System::MakeObject<Presentation>(outputFile);
auto reopenedFirstShape = reopenedPresentation->get_Slide(0)->get_Shape(0);
auto reopenedShape = System::ExplicitCast<IAutoShape>(reopenedFirstShape);
auto storedParagraph = reopenedShape->get_TextFrame()->get_Paragraph(0);

bool portionsStored = storedParagraph->get_Portions()->get_Count() == 2;
if (portionsStored)
{
    auto firstStoredPortion = storedParagraph->get_Portion(0);
    auto secondStoredPortion = storedParagraph->get_Portion(1);

    bool firstPortionStored = firstStoredPortion->get_PortionFormat()->get_LanguageId() == u"en-US" && 
        firstStoredPortion->get_PortionFormat()->get_SpellCheck();

    bool secondPortionStored = secondStoredPortion->get_PortionFormat()->get_LanguageId() == u"fr-FR" && 
        !secondStoredPortion->get_PortionFormat()->get_SpellCheck();

    if (firstPortionStored && secondPortionStored)
    {
        System::Console::WriteLine(u"The proofing settings were stored correctly.");
    }
    else
    {
        System::Console::WriteLine(u"The proofing settings could not be verified.");
    }
}
else
{
    System::Console::WriteLine(u"The proofing settings could not be verified.");
}

reopenedPresentation->Dispose();
```

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/joinportionswithsameformatting/) aynı biçimlendirmeye sahip yan yana bölümleri birleştirir. Yalnızca `SpellCheck` farkı, bu bölümlerin ayrı kalmasını sağlamaz; birleştirildikten sonra oluşan bölüm, ilk bölümün `SpellCheck` değerini korur. Bölümlerin farklı imla denetim ayarlarına ihtiyacı varsa, bu ayarları atamadan önce `JoinPortionsWithSameFormatting` çağırın ya da oluşan bölüm sınırlarını inceleyip ayarları sonradan yeniden uygulayın. `LanguageId` değerleri farklı olan bölümler, proofing‑dili biçimlendirmeleri farklı olduğu için ayrı kalır.

## **SSS**

**Bir dil kimliği metni çevirir mi?**

Hayır. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/set_languageid/) imla ve dil bilgisi denetimi için proofing üst verisi depolar; metin içeriğini değiştirmez. Metni ayrı olarak çevirin ve ardından her çevrilmiş bölüm için uygun dil tanımlayıcısını ayarlayın.

**Proofing dili yazı tiplerini, hecelemeyi veya satır kaydırmayı kontrol eder mi?**

Hayır. Dil tanımlayıcısı sadece proofing içindir. Metin işleme ve yerleşim esas olarak mevcut [fonts](/slides/tr/cpp/powerpoint-fonts/), yazı sistemi ve metin‑çerçeve ayarlarına bağlıdır. Güvenilir bir görünüm için gerekli yazı tiplerini sağlayın, [font substitution](/slides/tr/cpp/font-substitution/) ayarlayın veya sunumda [embed fonts](/slides/tr/cpp/embedded-font/) kullanın.

**Bir paragraf birden fazla proofing dili kullanabilir mi?**

Evet. Her dili ayrı bir bölümde atayın; çok dilli paragraf örneğinde gösterildiği gibi.

**`DefaultTextLanguage` mı yoksa `LanguageId` mi kullanmalıyım?**

Yeni oluşturulan metin için bir varsayılan istiyorsanız [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) kullanın. Belirli bir bölümün açık bir proofing dili gerektirdiği veya bir paragrafta birden fazla dil bulunduğu durumlarda ise [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/set_languageid/) kullanın.