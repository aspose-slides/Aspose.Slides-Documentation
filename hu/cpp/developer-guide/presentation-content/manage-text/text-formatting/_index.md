---
title: "Prezentáció szövegének formázása C++-ban"
linktitle: "Szövegformázás"
type: docs
weight: 50
url: /hu/cpp/text-formatting/
keywords:
- "bekezdés igazítása"
- "szövegstílus"
- "szöveg háttér"
- "szöveg átlátszóság"
- "karakterköz"
- "betűtulajdonságok"
- "betűcsalád"
- "szöveg forgatás"
- "forgatási szög"
- "szövegkeret"
- "sorköz"
- "automatikus illeszkedés tulajdonság"
- "szövegkeret rögzítése"
- "szöveg tabuláció"
- "alapértelmezett nyelv"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "C++"
- "Aspose.Slides"
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for C++ használatával. Testreszabhatja a betűtípusokat, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázható a szöveg a PowerPoint és az OpenDocument prezentációkban az Aspose.Slides for C++ használatával. Tárgyalja a háttérszíneket, átlátszóságot, karakterközöket, betűtulajdonságokat, forgatást, bekezdésközöket, automatikus illeszkedés viselkedését, szöveg rögzítését, tabulátorpozíciókat és nyelvi beállításokat.

Kivéve, ha máshogy szerepel, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dián az első alakzata egy szövegdoboz, és az első bekezdése az alább látható szöveget tartalmazza. A dia- és alakzatszámok nullával kezdődnek. Azokat a példákat, amelyek felső karaktereket választanak, hatékony formázással, beleértve az örökölt félkövér formázást használják:

![Minta szöveg](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés egyezéseinek megtalálásához és kiemeléséhez lásd a [Keresés és szövegcsere](/slides/hu/cpp/search-and-replace-text/).

## **Szöveg háttérszín beállítása**

Használd az [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) metódust egy bekezdés alapértelmezett kiemelési színének beállításához, vagy az [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) metódust az egyedi szöverrészekhez.

Az alábbi példa világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyes részekre vonatkozó kifejezett kiemelési színek felülírják ezt az alapértelmezést:

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

// Állítsa be a kiemelési színt az egész bekezdésre.
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódpélda bemutatja, hogyan állítható be a háttérszín **félkövér betűtípusú szöverrészek** számára:

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
        // Állítsa be a kiemelési színt a szövegrészhez.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A szürke szöverrészek](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használd az [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_alignment/) metódust a bekezdés igazításának beállításához egy szövegkeretben. Az érték lehet középre igazított, balra igazított, jobbra igazított, sorkizárt stb.

Az alábbi kódpélda megmutatja, hogyan igazítható a bekezdés a **középre**:

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

## **Szöveg átlátszóság beállítása**

A szöveg átlátszósága a szín alfa komponensén keresztül szabályozható, amelyet az [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/get_fillformat/) ad meg. Az alábbi példákban az `alpha = 50` egy ARGB alfa csatorna érték a 0‑255 skálán, nem pedig átlátszósági százalék.

Az alábbi kódpélda megmutatja, hogyan alkalmazzunk átlátszóságot a **teljes bekezdés**-re:

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

// Állítsa be a szöveg kitöltő színét átlátszó színre.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az átlátszó bekezdés](transparent_paragraph.png)

A következő kódpélda bemutatja, hogyan alkalmazzunk átlátszóságot **félkövér betűtípusú szöverrészek**-re:

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

![Az átlátszó szöverrészek](transparent_text_portions.png)

## **Karakterköz beállítása a szöveghez**

Használd az [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_spacing/) metódust a karakterek közötti távolság növelésére vagy csökkentésére egy szövegdobozban. A példák 3 pont távolságot adnak hozzá; a negatív értékek összehúzzák a szöveget.

Az alábbi C++ kód megmutatja, hogyan növelhető a karakterköz a **teljes bekezdés**-ben:

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

// Megjegyzés: Negatív értékek használata a karakterköz összenyomásához.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // Karakterköz növelése.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódpélda bemutatja, hogyan növelhető a karakterköz **félkövér betűtípusú szöverrészek** esetén:

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
        // Megjegyzés: Negatív értékek használata a karakterköz összenyomásához.
        portionFormat->set_Spacing(3.0f); // Karakterköz növelése.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A karakterköz a szöverrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Néhány esetben az Aspose.Slides által megjelenített szöveg kissé szorosabb lehet, mint a PowerPoint-ban megjelenített azonos szöveg. Ez azért fordulhat elő, mert a PowerPoint bizonyos betűtípusoknál figyelmen kívül hagyhatja a kerning adatokat, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt, és a kerning engedélyezve van a PowerPoint beállításaiban.

Az ilyen esetekben a renderelt kimenet PowerPoint-hoz közelié tételéhez letilthatod a kerninget a hatott betűtípust használó szöverrészeknél. Használd az [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) metódust egy, a tényleges betűméretnél nagyobb érték beállításához. Ez a példa a "presentation.pptx" fájlt igényli, amelynek az első diáján az első alakzata egy szövegdoboz. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűtípusokat, és 100 pont küszöböt állít be a Roboto-t használó részekre. Ez letiltja a kerninget a 100 pontnál kisebb betűmérettel rendelkező egyező részeknél:

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

A küszöb alatti egyező szöveg esetén ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelésének a PowerPoint vizuális kimenetéhez igazításában azoknál a betűtípusoknál, amelyeket ez a PowerPoint-specifikus viselkedés érint.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten az [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) segítségével, vagy egyedi részeknél az [IPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportionformat/) segítségével.

Az alábbi példa beállítja az első bekezdés alapértelmezett betűtípusát 12 pontos Times New Roman-ra, félkövér, dőlt és pontozott aláhúzással. Az egyes részekre vonatkozó kifejezett formázás felülírja ezeket az alapértelmezéseket:

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

// Állítsa be a betűtulajdonságokat a bekezdéshez.
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

![A bekezdés betűtulajdonságai](font_properties_for_paragraph.png)

Az alábbi példa 13 pontos Times New Roman-t, dőlt formázást és pontozott aláhúzást alkalmaz azokra a részekre, amelyek hatékony formázása félkövér:

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
        // Állítsa be a betűtulajdonságokat a szövegrészhez.
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

![A szöverrészek betűtulajdonságai](font_properties_for_text_portions.png)

## **Szöveg forgatás beállítása**

Használd az [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_textverticaltype/) metódust egy előre definiált szövegtájolás beállításához egy alakzaton belül.

Az alábbi kódpélda a szöveg tájolását a alakzaton a [TextVerticalType::Vertical270](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textverticaltype/) értékre állítja, amely **90 fokkal óramutató járásával ellentétesen** forgatja a szöveget:

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

## **Egyéni forgatás beállítása szövegkeretekhez**

Használd az [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_rotationangle/) metódust egyéni forgatási szög beállításához egy [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) számára.

Az alábbi kódpélda a szövegkeretet 3 fokkal óramutató járásával megegyező irányban forgatja az alakzaton belül:

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

![Az egyéni szöveg forgatás](custom_text_rotation.png)

## **Bekezdések sortávolságának beállítása**

Az Aspose.Slides a [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_spaceafter/), [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_spacebefore/) és [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_spacewithin/) metódusokkal szabályozza a bekezdésközöket. Ezeket a metódusokat a következőképpen használják:

* Pozitív értéket használj a sortávolság a sormagasság százalékaként történő megadásához.
* Negatív értéket használj a sortávolság pontban történő megadásához.

Az alábbi példa a első bekezdésen belüli távolságot a sormagasság 200%-ára (dupla sortávolság) állítja:

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

## **Sortörés szabályainak vezérlése**

A bekezdés sortörési szabályai szűk szövegtömbökben és Olat és kelet-ázsiai szöveget keverő prezentációkban hasznosak. A következő metódusok az [IParagraphFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/) részei, így egész bekezdésre vonatkoznak:

- [IParagraphFormat::set_LatinLineBreak](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_latinlinebreak/) szabályozza a latin sortörés szabályait. Vegyes szöveg esetén a módosítása megváltoztathatja az egymás melletti kelet-ázsiai szöveg és írásjel tördelésének helyét.
- [IParagraphFormat::set_EastAsianLineBreak](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_eastasianlinebreak/) szabályozza a kelet-ázsiai sortörés szabályait, beleértve a sor elején és végén lévő karakterekre vonatkozó korlátozásokat.

Ezek a szabályok nem helyettesítik az [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_wraptext/) metódust. A tördelés során befolyásolják az elrendezést; nem illesztenek sortörés karaktert. Egy explicit sortörés új sort hoz létre a bekezdésen belül a rendelkezésre álló szélességtől függetlenül.

Az alábbi önálló példa egy szűk szövegtömböt hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörési szabályt explicit módon beállítja, és elmenti a "line_breaking.pptx" fájlt. A szabályok kipróbálásához változtasd meg az értéket, amelyet a setternek adsz, miközben a másik beállítást változatlanul hagyod. A példa 24 pontos Arial és SimSun betűtípusokat használ, 160 pontos keretszélességgel és nulla vízszintes szövegkeret margóval. Az [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_autofittype/) metódus a [TextAutofitType::None](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textautofittype/) értékkel van meghívva, hogy a szövegméret és a keret méretei rögzítve maradjanak:

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

## **Függőleges írásjelek vezérlése**

[IParagraphFormat::set_HangingPunctuation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_hangingpunctuation/) lehetővé teszi, hogy az elegendő írásjelek a szövegsor jobb szélén túlnyúljanak, ahelyett, hogy a következő sorban helyezkednének el. Az egész bekezdésre vonatkozik, és különbözik a függőleges behúzástól.

Az alábbi önálló példa bekapcsolja a függőleges írásjeleket egy 100 pontos széles szövegkeretben, és elmenti a "hanging_punctuation.pptx" fájlt. 24 pontos Arial betűtípussal és nulla vízszintes szövegkeret margóval a befejező pont a "sentence" után marad, és túlnyúlik a szöveg jobb szélén. A [NullableBool::False](https://reference.aspose.com/slides/hu/cpp/aspose.slides/nullablebool/) átadása a setternek összehasonlításként: ezekkel a beállításokkal a pont külön sorba kerül. A tördelés engedélyezve van, az automatikus illeszkedés le van tiltva, hogy a rendelkezésre álló szélesség rögzített maradjon.

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

Nem minden írásjel függőlegesen jeleníthető meg. A látható eredmény a betűtípustól és az elrendezéstől függ: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus illeszkedés beállításainak módosítása eltüntetheti a látható különbséget.

## **Automatikus illeszkedés típusának beállítása szövegkeretekhez**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_autofittype/) meghatározza, hogyan viselkedik a szöveg, ha meghaladja a tároló határait. Használd ezt annak szabályozására, hogy a szöveg zsugorodjon, túlcímkézzen vagy automatikusan átméretezze az alakzatot. Az alábbi példa úgy konfigurálja az alakzatot, hogy átméretezze magát a szöveghez, és elmenti az eredményt a "autofit_type.pptx" fájlba.

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

A sorok számolásához automatikus tördelés után és annak megtekintéséhez, hogy a szöveg vagy az alakzat szélessége hogyan változtatja az eredményt, lásd a [Renderelt sorok számlálása](/slides/hu/cpp/manage-paragraph/). A sorok száma önmagában nem mutatja, hogy a szöveg túlnyúlik-e a tárolóban.

## **Szövegkeretek rögzítésének beállítása**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_anchoringtype/) meghatározza, hogyan helyezkedik el a szöveg függőlegesen egy alakzaton belül, például a tetején, közepén vagy alján. Az alábbi példa a szöveget az első alakzat alján rögzíti, és elmenti az eredményt a "text_anchor.pptx" fájlba.

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

Használd az [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) és az [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/get_tabs/) metódusokat a bekezdés tabulátorállásainak konfigurálásához. Az alábbi példa az alapértelmezett tabulátor lépést 100 pontra állítja, és egy balra igazított tabulátort ad hozzá 30 pontnál. Ezek a beállítások a tabulátor karaktert tartalmazó szövegeket érintik.

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

## **Ellenőrző nyelv beállítása**

Az Aspose.Slides biztosítja az [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_languageid/) metódust, amely lehetővé teszi a szövegrész ellenőrző nyelvének beállítását. Az ellenőrző nyelv határozza meg a PowerPointban a helyesírás- és nyelvtani ellenőrzéshez használt nyelvet.

Az alábbi példa a "presentation.pptx" fájlt igényli, amelynek az első diáján első alakzata egy szövegdoboz, és legalább egy bekezdést tartalmaz. A első bekezdés tartalmát "1。"‑re cseréli, a betűtípust SimSun‑ra állítja, és a Simplified Chinese (egyszerűsített kínai) ellenőrző nyelvet (`zh-CN`) rendeli hozzá. Az eredményt a "proofing_language.pptx" fájlba menti:

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

// Állítsa be a helyesírási nyelvet egyszerűsített kínaira.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1。");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Alapértelmezett nyelv beállítása**

Használd a [LoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_defaulttextlanguage/) metódust az alapértelmezett nyelv meghatározásához a prezentáció betöltése vagy létrehozása közben létrehozott szövegekhez. Az alábbi példa egy prezentációt hoz létre, amelynek az alapértelmezett szövegnyelv az amerikai angol, hozzáad egy szövegdobozt, és kiírja az `en-US` értéket az első szövegrészhez.

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

## **Alapértelmezett szövegstílus beállítása**

Alapértelmezett szövegformázás alkalmazásához a prezentáció szintjén használd az [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_defaulttextstyle/) metódust.

Az alábbi példa 14 pontos félkövér betűtípust állít be alapértelmezettként a felső szintű bekezdésekhez egy új prezentációban, és elmenti a "default_text_style.pptx" fájlba. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak nem felülírja egy specifikusabb formázás.

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

// Szerezze meg a felső szintű bekezdésformátumot.
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

## **Szöveg kinyerése nagybetűs hatással**

PowerPointban az **All Caps** (nagybetűs) betűhatás alkalmazása azt eredményezi, hogy a szöveg a dián nagybetűkkel jelenik meg, még akkor is, ha eredetileg kisbetűkkel lett beírva. Amikor egy ilyen szövegrészt az Aspose.Slides használatával kérsz le, a könyvtár a pontosan beírt szöveget adja vissza. A megjelenített szöveghez való illeszkedéshez ellenőrizd a [TextCapType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textcaptype/) értékét, és konvertáld a visszaadott karakterláncot nagybetűssé, ha az érték [TextCapType::All](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textcaptype/).

Ez a példa a "sample2.pptx" fájlt igényli, amelynek az első diáján első alakzata egy szövegdoboz. Az első bekezdés első része tartalmazza a "Hello, Aspose!" szöveget All Caps hatással, ahogy az alább látható.

![All Caps hatás](all_caps_effect.png)

Az alábbi kódpélda megmutatja, hogyan nyerhető ki a szöveg **All Caps** hatással:

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

Kimenet:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hogyan módosíthatom a szöveget egy dián lévő táblázatban?**

A dián lévő táblázat szövegének módosításához használd a [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) példányt. Iterálj a cellákon, és frissítsd az egyes cellákat az [ICell::get_TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icell/get_textframe/) segítségével, a bekezdés formázását pedig az [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/get_paragraphformat/) segítségével.

**Hogyan alkalmazhatok színátmenetet a szövegre egy PowerPoint dián?**

A szövegre színátmenet alkalmazásához használd az [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/get_fillformat/) metódust. Állítsd az [IFillFormat::set_FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifillformat/set_filltype/) értékét a [FillType::Gradient](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) típusra, és állítsd be a gradient állomásokat, az irányt és az átlátszóságot.