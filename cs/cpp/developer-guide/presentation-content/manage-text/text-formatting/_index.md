---
title: Formátování textu prezentace v C++
linktitle: Formátování textu
type: docs
weight: 50
url: /cs/cpp/text-formatting/
keywords:
- zarovnání odstavce
- styl textu
- pozadí textu
- průhlednost textu
- mezera mezi znaky
- vlastnosti písma
- rodina písma
- rotace textu
- úhel rotace
- textový rámec
- řádkování
- vlastnost automatického přizpůsobení
- ukotvení textového rámce
- tabulace textu
- výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Formátujte a stylizujte text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro C++. Přizpůsobte písma, barvy, zarovnání a další."
---
## **Přehled**

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro C++. Pokrývá barvy pozadí, průhlednost, mezeru mezi znaky, vlastnosti písma, otáčení, mezery odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

V níže uvedených příkladech použijeme soubor nazvaný "sample.pptx", který obsahuje jediný textový rámeček na první snímku s následujícím textem:

![Sample text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárních výrazů viz [Search and Replace Text](/slides/cs/cpp/search-and-replace-text/).

## **Nastavení barvy pozadí textu**

Použijte [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) k nastavení výchozí barvy zvýraznění pro odstavec nebo použijte [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) pro jednotlivé části textu.

Následující ukázka kódu ukazuje, jak nastavit barvu pozadí pro **celý odstavec**:

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

// Nastavte barvu zvýraznění pro celý odstavec.
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![The gray paragraph](gray_paragraph.png)

Níže uvedená ukázka kódu demonstruje, jak nastavit barvu pozadí pro **části textu s tučným písmem**:

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
        // Nastavte barvu zvýraznění pro textovou část.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![The gray text portions](gray_text_portions.png)

## **Zarovnání odstavců textu**

Použijte [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_alignment/) k nastavení zarovnání odstavce v textovém rámci. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, do bloku a podobně.

Následující ukázka kódu ukazuje, jak zarovnat odstavec do **středu**:

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

// Nastavte zarovnání odstavce na střed.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![The aligned paragraph](aligned_paragraph.png)

## **Nastavení průhlednosti textu**

Průhlednost textu je řízena alfa komponentou barvy přiřazené pomocí [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseportionformat/get_fillformat/). V níže uvedených příkladech je `alpha = 50` hodnota kanálu ARGB v rozsahu 0‑255, nikoli procento průhlednosti.

Níže uvedená ukázka kódu ukazuje, jak použít průhlednost na **celý odstavec**:

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

// Nastavte barvu výplně textu na průhlednou barvu.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![The transparent paragraph](transparent_paragraph.png)

Následující ukázka kódu ukazuje, jak použít průhlednost na **části textu s tučným písmem**:

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
        // Nastavte průhlednost textové části.
        portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
        auto baseColor = System::Drawing::Color::get_Black();
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
        portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![The transparent text portions](transparent_text_portions.png)

## **Nastavení mezery mezi znaky pro text**

Použijte [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseportionformat/set_spacing/) k rozšíření nebo zmenšení mezery mezi znaky v textovém rámečku.

Následující C++ kód ukazuje, jak rozšířit mezeru mezi znaky v **celém odstavci**:

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

// Poznámka: Použijte záporné hodnoty ke zmenšení mezery mezi znaky.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // Rozšiřte mezeru mezi znaky.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Níže uvedená ukázka kódu ukazuje, jak rozšířit mezeru mezi znaky v **částech textu s tučným písmem**:

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
        // Poznámka: Použijte záporné hodnoty ke zmenšení mezery mezi znaky.
        portionFormat->set_Spacing(3.0f); // Rozšiřte mezeru mezi znaky.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Zakázání kerningu pro konkrétní písma**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určitá písma, i když písmo obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby byl výstup vykreslený blíže PowerPointu, můžete v takových případech zakázat kerning pro části textu, které používají postižené písmo. Použijte [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) k nastavení hodnoty podstatně větší než skutečná velikost písma:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IFontData.h>
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
        auto latinFont = portionFormat->get_LatinFont();
        auto eastAsianFont = portionFormat->get_EastAsianFont();
        auto complexScriptFont = portionFormat->get_ComplexScriptFont();

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

Toto nastavení zabraňuje aplikaci kerningu na odpovídající části textu a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu pro písma, na která se tato specifická chování PowerPointu vztahují.

## **Správa vlastností písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) nebo na jednotlivých částech pomocí [IPortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportionformat/).

Následující kód nastavuje písmo a styl textu pro celý odstavec: aplikuje velikost písma, tučnost, kurzívu, tečkované podtržení a písmo Times New Roman na všechny části odstavce.

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

// Nastavte vlastnosti písma pro odstavec.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
auto font = System::MakeObject<FontData>(u"Times New Roman");
defaultPortionFormat->set_LatinFont(font);

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![The font properties for the paragraph](font_properties_for_paragraph.png)

Níže uvedená ukázka kódu aplikuje podobné vlastnosti na **části textu s tučným písmem**:

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
            // Nastavte vlastnosti písma pro textovou část.
            portionFormat->set_FontHeight(13.0f);
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontUnderline(TextUnderlineType::Dotted);
            portionFormat->set_LatinFont(font);
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Nastavení rotace textu**

Použijte [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/set_textverticaltype/) k nastavení předdefinované orientace textu uvnitř tvaru.

Následující ukázka kódu nastavuje orientaci textu v tvaru na [TextVerticalType::Vertical270](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textverticaltype/), což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

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

Výsledek:

![The text rotation](text_rotation.png)

## **Nastavení vlastní rotace pro textové rámce**

Použijte [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/set_rotationangle/) k nastavení vlastního úhlu rotace pro [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/).

Níže uvedená ukázka kódu otáčí textový rámec o 3 stupně po směru hodinových ručiček uvnitř tvaru:

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

Výsledek:

![The custom text rotation](custom_text_rotation.png)

## **Nastavení řádkování odstavců**

Aspose.Slides poskytuje [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_spaceafter/), [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_spacebefore/) a [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_spacewithin/) k řízení mezery odstavců. Tyto metody se používají následovně:

* Použijte kladnou hodnotu pro určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu pro určení řádkování v bodech.

Následující ukázka kódu ukazuje, jak zadat řádkování v odstavci:

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

Výsledek:

![The line spacing within the paragraph](line_spacing.png)

## **Nastavení typu automatického přizpůsobení pro textové rámce**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/set_autofittype/) určuje, jak se text chová, když překročí hranice svého kontejneru. Použijte jej k řízení, zda se text zmenší, přesáhne nebo automaticky přizpůsobí velikost tvaru.

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

Pro spočítání řádků po automatickém zalomení a zjištění, jak se mění šířka textu nebo tvaru, viz [Count Rendered Lines](/slides/cs/cpp/manage-paragraph/). Počet řádků sám o sobě neukazuje, zda text přesahuje svůj kontejner.

## **Nastavení ukotvení textových rámců**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/set_anchoringtype/) definuje, jak je text vertikálně umístěn uvnitř tvaru, například nahoře, uprostřed nebo dole.

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

## **Nastavení tabulátorů textu**

Použijte [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) a [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/get_tabs/) k nakonfigurování tabulátorů v odstavci.

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

Výsledek:

![The paragraph tabs](paragraph_tabs.png)

## **Nastavení jazyka kontroly pravopisu**

Aspose.Slides poskytuje [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseportionformat/set_languageid/), který umožňuje nastavit jazyk kontroly pravopisu pro část textu. Jazyk kontroly pravopisu určuje jazyk používaný pro pravopisné a gramatické kontroly v PowerPointu.

Následující ukázka kódu ukazuje, jak nastavit jazyk kontroly pravopisu pro část textu:

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

// Nastavte Id jazyka kontroly pravopisu.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nastavení výchozího jazyka**

Použijte [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) k definování výchozího jazyka pro text vytvořený při načítání nebo vytváření prezentace.

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

// Add a new rectangle shape with text.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Check the first portion language.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **Nastavení výchozího stylu textu**

Pro aplikaci výchozího formátování textu na úrovni prezentace použijte [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_defaulttextstyle/).

Následující ukázka kódu ukazuje, jak nastavit výchozí tučné písmo o velikosti 14 pt pro celý text napříč snímky v nové prezentaci.

```cpp
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

// Získejte formát odstavce nejvyšší úrovně.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    auto defaultPortionFormat = paragraphFormat->get_DefaultPortionFormat();
    defaultPortionFormat->set_FontHeight(14.0f);
    defaultPortionFormat->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Extrahování textu s efektem Všechna velká písmena**

V PowerPointu aplikace efektu **All Caps** (všechna velká písmena) způsobí, že se text na snímku zobrazí velkými písmeny, i když byl původně zadán malými. Když takovou část textu získáte pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro sladění se zobrazeným textem zkontrolujte [TextCapType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textcaptype/) a převést vrácený řetězec na velká písmena, když je hodnota [TextCapType::All](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textcaptype/).

Předpokládejme, že máme následující textový rámeček na první snímku souboru sample2.pptx.

![The All Caps effect](all_caps_effect.png)

Níže uvedená ukázka kódu ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

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

Výstup:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Často kladené otázky**

**Jak upravit text v tabulce na snímku?**

Pro úpravu textu v tabulce na snímku použijte [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/). Procházejte buňky a aktualizujte každou buňku pomocí [ICell::get_TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icell/get_textframe/) a formátování odstavců pomocí [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/get_paragraphformat/).

**Jak aplikovat gradientní barvu na text v PowerPoint snímku?**

Pro aplikaci gradientní barvy na text použijte [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseportionformat/get_fillformat/). Nastavte [IFillFormat::set_FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifillformat/set_filltype/) na [FillType::Gradient](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) a nakonfigurujte gradientní zastávky, směr a průhlednost.