---
title: Prezentáció szövegének formázása C++-ban
linktitle: Szövegformázás
type: docs
weight: 50
url: /hu/cpp/text-formatting/
keywords:
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszóság
- karakterköz
- betűtípus tulajdonságok
- betűtípus család
- szöveg forgatás
- forgatási szög
- szövegkeret
- sortávolság
- automatikus illeszkedés tulajdonság
- szövegkeret rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for C++ használatával. Testreszabhatja a betűtípusokat, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet szöveget formázni PowerPoint és OpenDocument prezentációkban az Aspose.Slides for C++ segítségével. Tárgyalja a háttérszíneket, átlátszóságot, karakterközöket, betűtípus‑tulajdonságokat, forgatást, bekezdés‑közöket, automatikus illeszkedés viselkedését, szöveg‑rögzítést, tabulátor‑pozíciókat és a nyelvi beállításokat.

Az alábbi példákban egy “sample.pptx” nevű fájlt fogunk használni, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

A szöveg keresése és cseréje a literális vagy reguláris‑kifejezéssel egyező részekhez lásd a [Szöveg keresése és cseréje](/slides/hu/cpp/search-and-replace-text/).

## **Szöveg háttérszín beállítása**

Használja az [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) hogy beállítsa a bekezdés alapértelmezett kiemelési színét, vagy használja az [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) egyedi szövegrészekhez.

Az alábbi kódrészlet bemutatja, hogyan lehet beállítani a háttérszínt a **teljes bekezdés** számára:

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

// Állítsa be a kiemelés színét a teljes bekezdéshez.
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan lehet beállítani a háttérszínt **félkövér betűtípussal rendelkező szövegrészek** számára:

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
        // Állítsa be a kiemelés színét a szövegrészhez.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A szürke szövegrészek](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használja az [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_alignment/) hogy beállítsa a bekezdés igazítását egy szövegdobozon belül. Az érték lehet középre igazított, balra igazított, jobbra igazított, sorkizárt stb.

Az alábbi kódrészlet bemutatja, hogyan lehet a bekezdést **középre** igazítani:

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

// Állítsa be a bekezdés igazítását középre.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az igazított bekezdés](aligned_paragraph.png)

## **Szöveg átlátszatlanságának beállítása**

Az átlátszatlanságot a szín alfa komponensével lehet szabályozni, amelyet a [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/get_fillformat/) segítségével állítanak be. Az alábbi példákban az `alpha = 50` egy ARGB alfa‑csatorna érték a 0‑255 skálán, nem százalékos átlátszóság.

Az alábbi kódrészlet azt mutatja, hogyan lehet átlátszatlanságot alkalmazni a **teljes bekezdés**‑re:

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

// Állítsa be a szöveg kitöltőszínét átlátszó színre.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az átlátszó bekezdés](transparent_paragraph.png)

Az alábbi kódrészlet azt mutatja, hogyan lehet átlátszatlanságot alkalmazni **félkövér betűtípussal rendelkező szövegrészek**‑re:

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
        // Állítsa be a szövegrész átlátszóságát.
        portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
        auto baseColor = System::Drawing::Color::get_Black();
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
        portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az átlátszó szövegrészek](transparent_text_portions.png)

## **Karakterköz beállítása szöveghez**

Használja az [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_spacing/) hogy növelje vagy csökkentse a karakterek közti távolságot egy szövegdobozban.

Az alábbi C++ kódrészlet bemutatja, hogyan lehet növelni a karakterközt a **teljes bekezdés**‑ben:

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

// Megjegyzés: Negatív értékek használata a karakterköz szorításhoz.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // Növelje a karakterközt.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan lehet növelni a karakterközt **félkövér betűtípussal rendelkező szövegrészek**‑ben:

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
        // Megjegyzés: Negatív értékek használata a karakterköz szorításhoz.
        portionFormat->set_Spacing(3.0f); // Növelje a karakterközt.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Néhány esetben az Aspose.Slides által renderelt szöveg valamivel szorosabbnak tűnhet, mint a PowerPointban megjelenő ugyanaz a szöveg. Ez azért történhet, mert a PowerPoint bizonyos betűtípusok esetén figyelmen kívül hagyhatja a kerning adatokat, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt, és a PowerPoint beállításaiban a kerning engedélyezett.

Az ilyen esetekben, hogy a renderelt kimenet közelebb legyen a PowerPointhoz, letilthatja a kerninget a érintett betűtípust használó szövegrészeknél. Használja az [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) hogy egy a tényleges betűméretnél lényegesen nagyobb értéket állítson be:

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

## **Szöveg betűtípus‑tulajdonságainak kezelése**

A betűtípus‑tulajdonságok a bekezdés szintjén állíthatók be a [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) vagy egyedi részeknél a [IPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportionformat/) segítségével.

Az alábbi kód beállítja a betűtípust és a szövegstílust a teljes bekezdéshez: alkalmazza a betűméretet, félkövér, dőlt, pontozott aláhúzást, valamint a Times New Roman betűtípust minden részre a bekezdésben.

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

// Állítsa be a betűtípus tulajdonságait a bekezdéshez.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
auto font = System::MakeObject<FontData>(u"Times New Roman");
defaultPortionFormat->set_LatinFont(font);

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A betűtípus‑tulajdonságok a bekezdéshez](font_properties_for_paragraph.png)

Az alábbi kódrészlet hasonló tulajdonságokat alkalmaz **félkövér betűtípussal rendelkező szövegrészek**‑re:

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
        // Állítsa be a betűtípus tulajdonságait a szövegrészhez.
        portionFormat->set_FontHeight(13.0f);
        portionFormat->set_FontItalic(NullableBool::True);
        portionFormat->set_FontUnderline(TextUnderlineType::Dotted);
        portionFormat->set_LatinFont(font);
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A betűtípus‑tulajdonságok a szövegrészekhez](font_properties_for_text_portions.png)

## **Szöveg forgatás beállítása**

Használja az [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_textverticaltype/) hogy előre definiált szövegorientációt állítson be egy alakzaton belül.

Az alábbi kódrészlet a szövegorientációt a alakzatban a [TextVerticalType::Vertical270](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textverticaltype/) értékre állítja, amely **90 fokkal óramutatóval ellentétesen** forgatja a szöveget:

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

Az eredmény:

![A szöveg forgatása](text_rotation.png)

## **Egyedi forgatás beállítása szövegkeretekhez**

Használja az [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_rotationangle/) hogy egyedi forgatási szöget állítson be egy [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) számára.

Az alábbi kódrészlet a szövegkeretet 3 fokkal az óramutató járásával megegyező irányban forgatja az alakzatban:

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

Az eredmény:

![Az egyedi szöveg forgatás](custom_text_rotation.png)

## **Bekezdés sortávolság beállítása**

Aspose.Slides a [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_spaceafter/), a [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_spacebefore/) és a [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_spacewithin/) metódusokat biztosítja a bekezdés távolságának szabályozásához. Ezek a metódusok a következőképpen használhatók:

* Pozitív értékkel a sortávolságot a sor magasságának százalékában adhatja meg.
* Negatív értékkel a sortávolságot pontban adhatja meg.

Az alábbi kódrészlet bemutatja, hogyan lehet megadni a sortávolságot a bekezdésen belül:

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

Az eredmény:

![A sortávolság a bekezdésen belül](line_spacing.png)

## **Automatikus illeszkedés típus beállítása szövegkeretekhez**

Az [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_autofittype/) meghatározza, hogyan viselkedik a szöveg, ha meghaladja a tároló határait. Ezzel vezérelheti, hogy a szöveg zsugorodjon, túlfusson vagy automatikusan átméretezze az alakzatot.

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

A sorok számlálásához automatikus tördelés után és a szöveg vagy alakzat szélességének változásának megtekintéséhez lásd a [Count Rendered Lines](/slides/hu/cpp/manage-paragraph/) oldalt. A sorok száma önmagában nem jelzi, hogy a szöveg túlfut-e a tárolón.

## **Szövegkeretek rögzítésének beállítása**

Az [ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_anchoringtype/) meghatározza, hogyan helyezkedik el a szöveg függőlegesen egy alakzatban, például a tetején, közepén vagy alján.

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

## **Szöveg tabuláció beállítása**

Használja az [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) és az [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/get_tabs/) metódusokat a tabulátorpozíciók beállításához egy bekezdésben.

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

Az eredmény:

![A bekezdés tabulátorai](paragraph_tabs.png)

## **Lektoráló nyelv beállítása**

Az Aspose.Slides a [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_languageid/) segítségével lehetővé teszi a lektoráló nyelv beállítását egy szövegrészhez. A lektoráló nyelv határozza meg, hogy melyik nyelvet használja a helyesírás- és nyelvtan-ellenőrzés a PowerPointban.

Az alábbi kódrészlet bemutatja, hogyan lehet beállítani a lektoráló nyelvet egy szövegrészhez:

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

// Állítsa be a lektoráló nyelv azonosítóját.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Alapértelmezett nyelv beállítása**

Használja az [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) metódust a szöveg alapértelmezett nyelvének meghatározásához a bemutató betöltése vagy létrehozása során.

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

// Új téglalap alakzat hozzáadása szöveggel.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Ellenőrizze az első szövegrész nyelvét.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás prezentáció szintjén történő alkalmazásához használja a [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_defaulttextstyle/) metódust.

Az alábbi kódrészlet azt mutatja, hogyan állíthat be alapértelmezett félkövér betűtípust 14 pt mérettel minden dián az új prezentációban.

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

// Szerezze meg a legfelső szintű bekezdésformátumot.
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

## **Szöveg kinyerése az Összes nagybetű hatással**

A PowerPointban az **All Caps** (összes nagybetű) betűhatás alkalmazása miatt a szöveg nagybetűként jelenik meg a dián, még ha eredetileg kisbetűkkel lett beírva is. Amikor az Aspose.Slides segítségével lekéri ezt a szövegrészt, a könyvtár pontosan úgy adja vissza a szöveget, ahogy beírták. A megjelenített szöveghez való illesztéshez ellenőrizze a [TextCapType] értéket, és alakítsa a visszakapott karakterláncot nagybetűvé, ha az érték [TextCapType::All].

Tegyük fel, hogy a sample2.pptx fájl első diáján a következő szövegdoboz van.

![Az All Caps hatás](all_caps_effect.png)

Az alábbi kódrészlet bemutatja, hogyan lehet kinyerni a szöveget, amikor az **All Caps** hatás alkalmazva van:

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

## **GYIK**

**Hogyan módosítható a szöveg egy táblázatban egy dián?**

Ahhoz, hogy szöveget módosítson egy táblázatban egy dián, használja a [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/). Iteráljon a cellákon, és minden cellát frissítsen a [ICell::get_TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icell/get_textframe/) segítségével, valamint a bekezdés formázását a [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/get_paragraphformat/) segítségével.

**Hogyan alkalmazhatók színátmenetes színek a szövegre egy PowerPoint diában?**

A szövegre színátmenetes szín alkalmazásához használja a [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/get_fillformat/). Állítsa a [IFillFormat::set_FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifillformat/set_filltype/) értékét a [FillType::Gradient](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékre, és konfigurálja a színátmeneti állomásokat, irányt és átlátszóságot.