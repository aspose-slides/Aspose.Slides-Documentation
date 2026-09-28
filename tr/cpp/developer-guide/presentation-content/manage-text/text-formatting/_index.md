---
title: C++ ile Sunum Metnini Biçimlendirme
linktitle: Metin Biçimlendirme
type: docs
weight: 50
url: /tr/cpp/text-formatting/
keywords:
- paragraf hizalama
- metin stili
- metin arka planı
- metin şeffaflığı
- karakter aralığı
- yazı tipi özellikleri
- yazı tipi ailesi
- metin döndürmesi
- döndürme açısı
- metin çerçevesi
- satır aralığı
- otomatik sığdırma özelliği
- metin çerçevesi tutturması
- metin sekleme
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarında Aspose.Slides for C++ kullanarak metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin tutturma, sek durakları ve dil ayarlarını kapsar.

Aksi belirtilmedikçe, örneklerde [sample.pptx](sample.pptx) kullanılır. İlk slaydındaki ilk şekil bir metin kutusudur ve ilk paragrafı aşağıda gösterilen metni içerir. Slayt ve şekil indeksleri sıfır‑tabanlıdır. Kalın bölümleri seçen örnekler, kalıtılmış kalın biçimlendirmeyi de içeren geçerli biçimlendirmeyi kullanır:

![Örnek metin](sample_text.png)

Gerçek metin veya düzenli ifade eşleşmelerini bulmak ve vurgulamak için [Search and Replace Text](/slides/tr/cpp/search-and-replace-text/) bölümüne bakın.

## **Metin Arka Plan Rengini Ayarlama**

Bir paragraf için varsayılan vurgu rengini ayarlamak için [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) kullanın veya tek tek metin bölümleri için [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) kullanın.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgu ayarlar. Tek tek bölümlerdeki açık vurgu renkleri bu varsayılanın üzerine yazılır:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
auto highlightColor = System::Drawing::Color::get_LightGray();

// Paragrafın tamamı için vurgulama rengini ayarla.
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipiyle** **metin bölümlerinin** arka plan renginin nasıl ayarlanacağını gösterir:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto highlightColor = System::Drawing::Color::get_LightGray();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Metin bölümünün vurgulama rengini ayarla.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Gri metin bölümleri](gray_text_portions.png)

## **Metin Paragraflarını Hizalama**

Bir metin çerçevesi içinde paragraf hizalamasını ayarlamak için [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_alignment/) kullanın. Değerler ortalanmış, sola hizalı, sağa hizalı, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamayı gösterir:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextAlignment.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
// Paragrafın hizalamasını ortaya ayarla.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Metnin Şeffaflığını Ayarlama**

Metin şeffaflığı, [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/get_fillformat/) üzerinden atanan rengin alfa bileşeniyle kontrol edilir. Aşağıdaki örneklerde `alpha = 50`, 0‑255 ölçeğinde bir ARGB alfa kanalı değeridir, yüzde şeffaflık değil.

Aşağıdaki kod örneği **tüm paragraf** için şeffaflık uygulamayı gösterir:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Metnin doldurma rengini şeffaf renk olarak ayarla.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipiyle** **metin bölümlerine** şeffaflık uygulamayı gösterir:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Metin bölümünün şeffaflığını ayarla.
        portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
        auto baseColor = System::Drawing::Color::get_Black();
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
        portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Şeffaf metin bölümleri](transparent_text_portions.png)

## **Metin İçin Karakter Aralığını Ayarlama**

Bir metin kutusundaki karakterler arasındaki aralığı genişletmek veya daraltmak için [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/set_spacing/) kullanın. Örneklerde 3 puan aralık eklenir; negatif değerler metni sıkıştırır.

Aşağıdaki C++ kodu **tüm paragrafta** karakter aralığını genişletmeyi gösterir:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // Karakter aralığını genişlet.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Paragraftaki karakter aralığı](character_spacing_in_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipiyle** **metin bölümlerinde** karakter aralığını genişletmeyi gösterir:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
        portionFormat->set_Spacing(3.0f); // Karakter aralığını genişlet.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Metin bölümlerindeki karakter aralığı](character_spacing_in_text_portions.png)

### **Belirli Yazı Tipleri İçin Kerning’i Devre Dışı Bırakma**

Bazı durumlarda Aspose.Slides ile işlenen metin, PowerPoint’te aynı metinden biraz daha sık görünebilir. Bu, PowerPoint’in belirli yazı tipleri için kerning verisini yok saymasından kaynaklanabilir, hatta yazı tipi geçerli kerning bilgilerine sahip olsa ve PowerPoint ayarlarında kerning açıksa bile.

Bu durumlarda, etkilenen yazı tipini kullanan metin bölümleri için kerning’i devre dışı bırakarak çıktıyı PowerPoint’e daha yakın hâle getirebilirsiniz. [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) ile gerçek yazı tipi boyutundan daha büyük bir değer ayarlayın. Bu örnek, ilk slaydın ilk şekli olarak bir metin kutusuna sahip “presentation.pptx” dosyasını gerektirir. Etkili yazı tipi adlarını, kalıtılmış yazı tipleri dahil, kontrol eder ve Roboto kullanan bölümler için 100 puan eşik değeri ayarlar. Bu, 100 puandan küçük yazı tipi boyutuna sahip eşleşen bölümler için kerning’i devre dışı bırakır:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IFontData.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
System::String targetFont = u"Roboto";
auto textFrame = autoShape->get_TextFrame();
auto paragraphs = textFrame->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        auto portionFormat = portion->get_PortionFormat();
        auto textFormat = portionFormat->GetEffective();
        auto latinFont = textFormat->get_LatinFont();
        auto eastAsianFont = textFormat->get_EastAsianFont();
        auto complexScriptFont = textFormat->get_ComplexScriptFont();

        bool isLatinFont = latinFont != nullptr && latinFont->get_FontName() == targetFont;
        bool isEastAsianFont = eastAsianFont != nullptr && eastAsianFont->get_FontName() == targetFont;
        bool isComplexScriptFont = complexScriptFont != nullptr && complexScriptFont->get_FontName() == targetFont;

        if (isLatinFont || isEastAsianFont || isComplexScriptFont)
        {
            portionFormat->set_KerningMinimalSize(100.0f);
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Eşiğin altındaki eşleşen metin için bu ayar kerning’i önler ve Aspose.Slides’ın render çıktısını, bu PowerPoint‑özgü davranıştan etkilenen yazı tipleri için PowerPoint’in görsel çıktısına yaklaştırabilir.

## **Metin Yazı Tipi Özelliklerini Yönetme**

Yazı tipi özellikleri, [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) aracılığıyla paragraf düzeyinde veya tek tek bölümler için [IPortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportionformat/) aracılığıyla ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan yazı tipini 12 puan Times New Roman, kalın, italik ve noktalı alt çizgi olarak ayarlar. Tek tek bölümlerdeki açık biçimlendirme bu varsayılanların üzerine yazılır:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Paragraf için yazı tipi özelliklerini ayarla.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
auto font = System::MakeObject<FontData>(u"Times New Roman");
defaultPortionFormat->set_LatinFont(font);

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Paragrafın yazı tipi özellikleri](font_properties_for_paragraph.png)

Aşağıdaki örnek, etkili biçimlendirmesi kalın olan bölümlere 13 puan Times New Roman, italik ve noktalı alt çizgi uygular:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto font = System::MakeObject<FontData>(u"Times New Roman");

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Metin bölümü için yazı tipi özelliklerini ayarla.
        portionFormat->set_FontHeight(13.0f);
        portionFormat->set_FontItalic(NullableBool::True);
        portionFormat->set_FontUnderline(TextUnderlineType::Dotted);
        portionFormat->set_LatinFont(font);
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Metin bölümlerinin yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Döndürme**

Bir şekil içinde önceden tanımlı bir metin yönelimini ayarlamak için [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/set_textverticaltype/) kullanın.

Aşağıdaki kod örneği, şekildeki metin yönelimini [TextVerticalType::Vertical270](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Metin döndürme](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Döndürme Ayarlama**

[ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/set_rotationangle/) kullanarak bir [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) için özel bir döndürme açısı ayarlayın.

Aşağıdaki kod örneği, şekil içinde metin çerçevesini saat yönünde 3 derece döndürür:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Özel metin döndürme](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarlama**

Aspose.Slides, paragraf aralığını kontrol etmek için [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_spaceafter/), [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_spacebefore/) ve [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_spacewithin/) sağlar. Bu yöntemler şu şekilde kullanılır:

* Satır aralığını, satır yüksekliğinin yüzdesi olarak belirtmek için pozitif bir değer kullanın.
* Satır aralığını puan olarak belirtmek için negatif bir değer kullanın.

Aşağıdaki örnek, ilk paragraftaki aralığı satır yüksekliğinin %200’ü (çift satır aralığı) olarak ayarlar:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Paragraftaki satır aralığı](line_spacing.png)

## **Satır Kesme Kontrolü**

Paragraf satır kesme kuralları, dar metin blokları ve Latin ile Doğu Asya metninin karıştığı sunumlar için faydalıdır. Aşağıdaki yöntemler [IParagraphFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/) altındadır ve bir bütün paragraf için geçerlidir:

- [IParagraphFormat::set_LatinLineBreak](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_latinlinebreak/) Latin satır kesme kurallarını kontrol eder. Karışık metinde değiştirildiğinde, yan yana gelen Doğu Asya metni ve noktalama işaretlerinin nerede dolandığını da etkileyebilir.
- [IParagraphFormat::set_EastAsianLineBreak](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_eastasianlinebreak/) Doğu Asya satır kesme kurallarını kontrol eder; satır başı ve sonundaki karakter kısıtlamalarını içerir.

Bu kurallar, bir metin çerçevesi içinde otomatik sarma sağlayan [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/set_wraptext/) işlevinin yerini almaz. Sarma gerçekleştiğinde yerleşimi etkiler; satır sonu karakteri eklemezler. Açık bir satır sonu, mevcut genişlikten bağımsız olarak paragrafta yeni bir satır başlatır.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. Her iki satır kesme kuralını da açıkça ayarlar ve “line_breaking.pptx” olarak kaydeder. Kurallardan birini denemek için, diğer ayarları sabit tutarken setter’a verilen değeri değiştirin. Örnek 24 puan Arial ve SimSun, 160 puan çerçeve genişliği ve sıfır yatay metin‑çerçeve kenar boşluğu kullanır. [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/set_autofittype/) [TextAutofitType::None](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textautofittype/) ile çağrılır; böylece metin boyutu ve çerçeve boyutları sabit kalır:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 160.0f, 300.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
textFrame->get_TextFrameFormat()->set_MarginLeft(0);
textFrame->get_TextFrameFormat()->set_MarginRight(0);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->set_Text(u"中文排版测试，PowerPoint 中文演示。");

auto format = paragraph->get_ParagraphFormat();
format->set_Alignment(TextAlignment::Left);
auto portionFormat = format->get_DefaultPortionFormat();
portionFormat->set_FontHeight(24.0f);
auto latinFont = System::MakeObject<FontData>(u"Arial");
portionFormat->set_LatinFont(latinFont);
auto eastAsianFont = System::MakeObject<FontData>(u"SimSun");
portionFormat->set_EastAsianFont(eastAsianFont);
portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
format->set_LatinLineBreak(NullableBool::False);
format->set_EastAsianLineBreak(NullableBool::True);

presentation->Save(u"line_breaking.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Sarkan Noktalama İşaretini Kontrol Etme**

[IParagraphFormat::set_HangingPunctuation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_hangingpunctuation/) uygun noktalama işaretlerinin, bir sonraki satırı doldurmak yerine metin satırının sağ kenarının ötesine uzanmasını sağlar. Tüm paragrafı etkiler ve sarkan girintiyle aynı şey değildir.

Aşağıdaki bağımsız örnek, 100 puan genişliğinde bir metin çerçevesinde sarkan noktalama işaretini etkinleştirir ve “hanging_punctuation.pptx” dosyasına kaydeder. 24 puan Arial ve sıfır yatay kenar boşluğu ile son nokta “sentence” kelimesinden sonra kalır ve sağ kenarın ötesine uzanır. Karşılaştırma için setter’a [NullableBool::False](https://reference.aspose.com/slides/tr/cpp/aspose.slides/nullablebool/) gönderin: bu ayarlarla nokta ayrı bir satırda yer alır. Sarma açıktır ve otomatik sığdırma devre dışıdır, böylece kullanılabilir genişlik sabit kalır:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 200.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
textFrame->get_TextFrameFormat()->set_MarginLeft(0);
textFrame->get_TextFrameFormat()->set_MarginRight(0);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->set_Text(u"Simple text, next sentence.");

auto format = paragraph->get_ParagraphFormat();
format->set_Alignment(TextAlignment::Left);
auto portionFormat = format->get_DefaultPortionFormat();
portionFormat->set_FontHeight(24.0f);
auto latinFont = System::MakeObject<FontData>(u"Arial");
portionFormat->set_LatinFont(latinFont);
portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
format->set_HangingPunctuation(NullableBool::True);

presentation->Save(u"hanging_punctuation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Her noktalama işareti sarkamaz. Görünür sonuç, yazı tipine ve yerleşime bağlıdır; yazı tipini, kullanılabilir genişliği, kenar boşluklarını veya otomatik sığdırma ayarlarını değiştirmek farkı ortadan kaldırabilir.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarlama**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/set_autofittype/) metin, kapsayıcısının sınırlarını aştığında nasıl davranacağını belirler. Metnin küçülmesi, taşması veya şeklin otomatik olarak yeniden boyutlandırılması gibi davranışları kontrol etmek için bu ayarı kullanın. Aşağıdaki örnek, şekli metnine göre yeniden boyutlandıracak şekilde yapılandırır ve son sonucu “autofit_type.pptx” olarak kaydeder:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Otomatik sarma sonrası satırları saymak ve metin ya da şekil genişliğinin sonucu nasıl etkilediğini görmek için [Count Rendered Lines](/slides/tr/cpp/manage-paragraph/) bölümüne bakın. Satır sayısı yalnızca metnin kapsayıcısını aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Tutulmasını Ayarlama**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/set_anchoringtype/) bir şekil içinde metnin dikey konumunu tanımlar; örneğin üst, orta veya alt. Aşağıdaki örnek, metni ilk şeklin alt kısmına tutturur ve sonucu “text_anchor.pptx” olarak kaydeder:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAnchorType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Metin Seklemeyi Ayarlama**

Paragrafta sek duraklarını yapılandırmak için [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) ve [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/get_tabs/) kullanın. Aşağıdaki örnek, varsayılan sek aralığını 100 puan olarak ayarlar ve 30 puanda sola hizalı bir sek durak ekler. Bu ayarlar sek karakteri içeren metni etkiler:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITabCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TabAlignment.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Paragraf sekleri](paragraph_tabs.png)

## **Düzeltme Dilini Ayarlama**

Aspose.Slides, bir metin bölümü için düzeltme dilini ayarlamanıza izin veren [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/set_languageid/) sağlar. Düzeltme dili, PowerPoint’te imla ve dilbilgisi denetimlerinde kullanılan dili belirler.

Aşağıdaki örnek, ilk slaydın ilk şekli olarak bir metin kutusuna sahip “presentation.pptx” dosyasını gerektirir ve en az bir paragraf içerir. İlk paragrafın içeriğini “1。” olarak değiştirir, SimSun’u yazı tipi olarak ayarlar ve Basitleştirilmiş Çince düzeltme dilini (`zh-CN`) atar. Sonucu “proofing_language.pptx” olarak kaydeder:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
auto portionFormat = textPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

// Düzeltme dilini Basitleştirilmiş Çince olarak ayarla.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1。");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Varsayılan Dili Ayarlama**

Yükleme veya yeni bir sunum oluşturma sırasında oluşturulan metin için varsayılan dili tanımlamak için [LoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_defaulttextlanguage/) kullanın. Aşağıdaki örnek, varsayılan metin dili olarak ABD İngilizcesi ile bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümünün dilini `en-US` olarak yazdırır:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Yeni bir dikdörtgen şekil ekle ve metin ayarla.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// İlk bölüm dilini kontrol et.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **Varsayılan Metin Stili Ayarlama**

Sunum düzeyinde varsayılan metin biçimlendirmesi uygulamak için [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_defaulttextstyle/) kullanın.

Aşağıdaki örnek, yeni bir sunumdaki üst‑seviye paragraflar için varsayılan olarak 14 puan kalın bir yazı tipini ayarlar ve “default_text_style.pptx” olarak kaydeder. Metin, daha spesifik bir biçimlendirme tarafından geçersiz kılınmadıkça bu varsayılanları miras alabilir.

```cpp
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ITextStyle> 
#include <DOM/NullableBool.h>
#include <DOM/Presentation> 
#include <Export/SaveFormat.h>

using namespace Aspose::Slide 
```

## **BÜYÜK HARF (All‑Caps) Etkisiyle Metin Çıkarma**

PowerPoint’te **All Caps** (BÜYÜK HARF) yazı tipi etkisini uygulamak, metni slaytta büyük harflerle gösterir, ancak aslında küçük harfle girilmiştir. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni tam olarak girildiği gibi döndürür. Görüntülenen metinle eşleşmesi için [TextCapType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textcaptype/) kontrol edin ve değer [TextCapType::All](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textcaptype/) olduğunda döndürülen dizeyi büyük harfe çevirin.

Bu örnek, ilk slaydın ilk şekli olarak bir metin kutusuna sahip “sample2.pptx” dosyasını gerektirir. İlk paragrafın ilk bölümü, aşağıda gösterildiği gibi All Caps etkisi uygulanmış “Hello, Aspose!” içerir.

![All Caps etkisi](all_caps_effect.png)

Aşağıdaki kod örneği, **All Caps** etkisi uygulanmış metni çıkarmayı gösterir:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextCapType.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

auto originalText = textPortion->get_Text();
System::Console::WriteLine(u"Original text: " + originalText);

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto uppercaseText = originalText.ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + uppercaseText);
}

presentation->Dispose();
```

Çıktı:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **SSS**

**Bir slayttaki bir tabloda metni nasıl değiştiririm?**

Bir slayttaki bir tabloda metni değiştirmek için [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) kullanın. Hücreler üzerinde döngü kurarak her bir hücreyi [ICell::get_TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icell/get_textframe/) ve paragraf biçimlemesini [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/get_paragraphformat/) aracılığıyla güncelleyin.

**PowerPoint slaytındaki metne nasıl bir degrade (gradient) renk uygularım?**

Metne degrade renk uygulamak için [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/get_fillformat/) kullanın. [IFillFormat::set_FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifillformat/set_filltype/) değerini [FillType::Gradient](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.