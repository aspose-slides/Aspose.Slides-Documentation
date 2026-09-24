---
title: Formatowanie tekstu prezentacji w C++
linktitle: Formatowanie tekstu
type: docs
weight: 50
url: /pl/cpp/text-formatting/
keywords:
- wyrównanie akapitu
- styl tekstu
- tło tekstu
- przezroczystość tekstu
- odstępy między znakami
- właściwości czcionki
- rodzina czcionek
- obrót tekstu
- kąt obrotu
- ramka tekstowa
- odstęp między wierszami
- właściwość autofit
- kotwica ramki tekstowej
- tabulacja tekstu
- domyślny język
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Formatuj i stylizuj tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for C++. Dostosuj czcionki, kolory, wyrównanie i wiele więcej."
---
## **Przegląd**

Ten artykuł pokazuje, jak formatować tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for C++. Obejmuje kolory tła, przezroczystość, odstępy między znakami, właściwości czcionki, obrót, odstępy akapitu, zachowanie autofit, kotwiczenie tekstu, tabulatory oraz ustawienia językowe.

W poniższych przykładach użyjemy pliku o nazwie „sample.pptx”, który zawiera pojedyncze pole tekstowe na pierwszym slajdzie z następującym tekstem:

![Sample text](sample_text.png)

Aby znaleźć i podświetlić dosłowny tekst lub dopasowania wyrażeń regularnych, zobacz [Search and Replace Text](/slides/pl/cpp/search-and-replace-text/).

## **Ustaw kolor tła tekstu**

Użyj [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) aby ustawić domyślny kolor podświetlenia dla akapitu lub [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) dla pojedynczych fragmentów tekstu.

Poniższy przykład kodu pokazuje, jak ustawić kolor tła dla **całego akapitu**:

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

// Ustaw kolor podświetlenia dla całego akapitu.
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The gray paragraph](gray_paragraph.png)

Poniższy przykład kodu demonstruje, jak ustawić kolor tła dla **fragmentów tekstu z pogrubioną czcionką**:

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
        // Ustaw kolor podświetlenia dla fragmentu tekstu.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The gray text portions](gray_text_portions.png)

## **Wyrównaj akapity tekstu**

Użyj [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_alignment/) aby ustawić wyrównanie akapitu w ramce tekstowej. Wartość może być wyśrodkowana, wyrównana do lewej, do prawej, justowana itp.

Poniższy przykład kodu pokazuje, jak wyrównać akapit do **środka**:

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

// Ustaw wyrównanie akapitu na środku.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The aligned paragraph](aligned_paragraph.png)

## **Ustaw przezroczystość tekstu**

Przezroczystość tekstu jest kontrolowana przez składnik alfa koloru przypisanego przy użyciu [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseportionformat/get_fillformat/). W poniższych przykładach `alpha = 50` to wartość kanału alfa ARGB w skali 0‑255, a nie procent przezroczystości.

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **całego akapitu**:

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

// Ustaw kolor wypełnienia tekstu na kolor przezroczysty.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The transparent paragraph](transparent_paragraph.png)

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **fragmentów tekstu z pogrubioną czcionką**:

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
        // Ustaw przezroczystość fragmentu tekstu.
        portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
        auto baseColor = System::Drawing::Color::get_Black();
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
        portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The transparent text portions](transparent_text_portions.png)

## **Ustaw odstępy między znakami w tekście**

Użyj [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseportionformat/set_spacing/) aby zwiększyć lub zmniejszyć odstępy między znakami w polu tekstowym.

Poniższy kod C++ pokazuje, jak zwiększyć odstępy znaków w **całym akapicie**:

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

// Uwaga: użyj wartości ujemnych, aby skompresować odstępy między znakami.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // Zwiększ odstępy między znakami.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Poniższy przykład kodu pokazuje, jak zwiększyć odstępy znaków w **fragmentach tekstu z pogrubioną czcionką**:

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
        // Uwaga: użyj wartości ujemnych, aby skompresować odstępy między znakami.
        portionFormat->set_Spacing(3.0f); // Zwiększ odstępy między znakami.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Wyłącz kerning dla konkretnych czcionek**

W niektórych przypadkach tekst renderowany przez Aspose.Slides może wyglądać nieco ciasniej niż ten sam tekst wyświetlany w PowerPoint. Może się tak stać, ponieważ PowerPoint może ignorować dane kerningu dla niektórych czcionek, nawet gdy czcionka zawiera prawidłowe informacje o kerningu i kerning jest włączony w ustawieniach PowerPoint.

Aby w takich sytuacjach uzyskać wynik bardziej zbliżony do PowerPoint, możesz wyłączyć kerning dla fragmentów tekstu używających danej czcionki. Użyj [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) aby ustawić wartość znacznie większą niż rzeczywisty rozmiar czcionki:

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

To ustawienie zapobiega stosowaniu kerningu do pasujących fragmentów tekstu i może pomóc zbliżyć renderowanie Aspose.Slides do wizualnego wyniku PowerPoint dla czcionek dotkniętych tym specyficznym zachowaniem PowerPoint.

## **Zarządzaj właściwościami czcionki tekstu**

Właściwości czcionki można ustawiać na poziomie akapitu przy użyciu [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) lub na poziomie poszczególnych fragmentów przy użyciu [IPortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportionformat/).

Poniższy kod ustawia czcionkę i styl tekstu dla całego akapitu: stosuje rozmiar czcionki, pogrubienie, kursywę, znak podkreślenia kropkowany oraz czcionkę Times New Roman we wszystkich fragmentach akapitu.

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

// Ustaw właściwości czcionki dla akapitu.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
auto font = System::MakeObject<FontData>(u"Times New Roman");
defaultPortionFormat->set_LatinFont(font);

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The font properties for the paragraph](font_properties_for_paragraph.png)

Poniższy przykład kodu stosuje podobne właściwości do **fragmentów tekstu z pogrubioną czcionką**:

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
        // Ustaw właściwości czcionki dla fragmentu tekstu.
        portionFormat->set_FontHeight(13.0f);
        portionFormat->set_FontItalic(NullableBool::True);
        portionFormat->set_FontUnderline(TextUnderlineType::Dotted);
        portionFormat->set_LatinFont(font);
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Ustaw obrót tekstu**

Użyj [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframeformat/set_textverticaltype/) aby ustawić wstępnie zdefiniowaną orientację tekstu w kształcie.

Poniższy przykład kodu ustawia orientację tekstu w kształcie na [TextVerticalType::Vertical270](https://reference.aspose.com/slides/pl/cpp/aspose.slides/textverticaltype/), co obraca tekst **o 90 stopni przeciwnie do ruchu wskazówek zegara**:

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

Wynik:

![The text rotation](text_rotation.png)

## **Ustaw własny obrót ramki tekstowej**

Użyj [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframeformat/set_rotationangle/) aby ustawić własny kąt obrotu dla [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/).

Poniższy przykład kodu obraca ramkę tekstową o 3 stopnie zgodnie z ruchem wskazówek zegara w obrębie kształtu:

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

Wynik:

![The custom text rotation](custom_text_rotation.png)

## **Ustaw odstępy między wierszami w akapitach**

Aspose.Slides udostępnia [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_spaceafter/), [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_spacebefore/) oraz [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_spacewithin/) do kontrolowania odstępów akapitu. Metody te stosuje się w następujący sposób:

* Użyj wartości dodatniej, aby określić odstęp jako procent wysokości wiersza.
* Użyj wartości ujemnej, aby określić odstęp w punktach.

Poniższy przykład kodu pokazuje, jak określić odstęp między wierszami w akapicie:

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

Wynik:

![The line spacing within the paragraph](line_spacing.png)

## **Ustaw typ autofitu dla ramek tekstowych**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframeformat/set_autofittype/) określa, jak tekst zachowuje się, gdy przekracza granice swojego kontenera. Użyj go, aby kontrolować, czy tekst ma się zmniejszać, wypływać poza obszar, czy automatycznie zmieniać rozmiar kształtu.

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

Aby policzyć wiersze po automatycznym zawijaniu i zobaczyć, jak zmienia się szerokość tekstu lub kształtu, zobacz [Count Rendered Lines](/slides/pl/cpp/manage-paragraph/). Same liczby wierszy nie wskazują, czy tekst wypływa poza kontener.

## **Ustaw kotwicę ramek tekstowych**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframeformat/set_anchoringtype/) definiuje, jak tekst jest pozycjonowany pionowo wewnątrz kształtu, np. u góry, w środku lub na dole.

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

## **Ustaw tabulacje tekstu**

Użyj [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) oraz [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/get_tabs/) aby skonfigurować tabulatory w akapicie.

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

Wynik:

![The paragraph tabs](paragraph_tabs.png)

## **Ustaw język korekty**

Aspose.Slides udostępnia [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseportionformat/set_languageid/), który umożliwia ustawienie języka korekty dla fragmentu tekstu. Język korekty określa, w jakim języku będą przeprowadzane sprawdzanie pisowni i gramatyki w PowerPoint.

Poniższy przykład kodu pokazuje, jak ustawić język korekty dla fragmentu tekstu:

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

// Set the Id of a proofing language.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ustaw domyślny język**

Użyj [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) aby zdefiniować domyślny język dla tekstu tworzonego podczas ładowania lub tworzenia prezentacji.

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

// Dodaj nowy kształt prostokątny z tekstem.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Sprawdź język pierwszego fragmentu.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **Ustaw domyślny styl tekstu**

Aby zastosować domyślne formatowanie tekstu na poziomie prezentacji, użyj [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_defaulttextstyle/).

Poniższy przykład kodu pokazuje, jak ustawić domyślną pogrubioną czcionkę o rozmiarze 14 pt dla całego tekstu we wszystkich slajdach nowej prezentacji.

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

// Pobierz format akapitu najwyższego poziomu.
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

## **Wyodrębnij tekst z efektem wielkich liter**

W PowerPoint stosowanie efektu **All Caps** powoduje, że tekst wyświetlany jest wielkimi literami, nawet jeśli został wpisany małymi. Gdy pobierasz taki fragment tekstu przy użyciu Aspose.Slides, biblioteka zwraca dokładnie wprowadzony tekst. Aby uzyskać wyświetlany tekst, sprawdź [TextCapType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/textcaptype/) i przekształć zwrócony ciąg na wielkie litery, gdy wartość to [TextCapType::All](https://reference.aspose.com/slides/pl/cpp/aspose.slides/textcaptype/).

Załóżmy, że mamy następujące pole tekstowe na pierwszym slajdzie pliku sample2.pptx.

![The All Caps effect](all_caps_effect.png)

Poniższy przykład kodu pokazuje, jak wyodrębnić tekst z zastosowanym efektem **All Caps**:

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

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Jak zmodyfikować tekst w tabeli na slajdzie?**

Aby zmodyfikować tekst w tabeli na slajdzie, użyj [ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/). Przeglądaj komórki i aktualizuj każdą komórkę przez [ICell::get_TextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icell/get_textframe/) oraz formatowanie akapitu przez [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraph/get_paragraphformat/).

**Jak zastosować gradientowy kolor do tekstu w slajdzie PowerPoint?**

Aby zastosować gradientowy kolor do tekstu, użyj [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseportionformat/get_fillformat/). Ustaw [IFillFormat::set_FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifillformat/set_filltype/) na [FillType::Gradient](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) i skonfiguruj przystanki gradientu, kierunek oraz przezroczystość.