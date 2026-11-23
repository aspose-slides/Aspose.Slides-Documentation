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
- betűtulajdonságok
- betűcsalád
- szöveg forgatás
- forgatási szög
- szövegkeret
- sortávolság
- automatikus illesztés tulajdonság
- szövegkeret rögzítés
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Formázza és stílusolja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for C++ segítségével. Testreszabhatja a betűket, színeket, igazítást és még sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for C++ használatával. Kitér a háttérszínekre, átlátszóságra, karakterközre, betűtulajdonságokra, forgatásra, bekezdésközökre, automatikus illesztés viselkedésére, szöveg rögzítésére, tabulátorállásokra és nyelvi beállításokra.

Kivéve, ha másként van megadva, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dia első alakzata egy szövegmező, és az első bekezdése tartalmazza az alább látható szöveget. Mind a dia, mind az alakzat indexei nullánál kezdődnek. A félkövér részeket kiválasztó példák hatékony formázást használnak, beleértve az örökölt félkövér formázást:

![Minta szöveg](sample_text.png)

Az adott szöveg vagy reguláris kifejezés szerinti találatok megtalálásához és kiemeléséhez tekintse meg a [Szöveg keresése és cseréje](/slides/hu/cpp/search-and-replace-text/) oldalt.

## **Szöveg háttérszínének beállítása**

A [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) segítségével állítható be a bekezdés alapértelmezett kiemelési színe, vagy az [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) egyedi szövegrészekhez.

Az alábbi példa világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyes részeken megadott kiemelési színek felülírják ezt az alapértelmezést:

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

// Állítsa be a kiemelési színt az egész bekezdéshez.
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűvel rendelkező szövegrészek** esetén:

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

![A szürke szövegrészek](gray_text_portions.png)

## **Bekezdések igazítása**

Az [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) segítségével állítható be a bekezdés igazítása a szövegkereten belül. Az érték lehet középre igazított, balra igazított, jobbra igazított, sorkizárt, stb.

Az alábbi kódrészlet bemutatja, hogyan igazítható a bekezdés **középre**:

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

## **Betűk igazítása egy soron belül**

Az [IParagraphFormat::set_FontAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_fontalignment/) segítségével függőlegesen igazíthatók a különböző betűméretű szövegrészek egy soron belül. Ez a beállítás az egész bekezdésre érvényes, és szabályozza az egyes sorokban történő igazítást.

Az alábbi önálló példa négy címkézett szövegmezőt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pontban, különböző betűigazítással. Arial betűtípust használ, letiltja az automatikus illesztést és a sortörést, és a szövegkereteket elég nagyra állítja egyetlen sorhoz.

```cpp
#include <DOM/FontAlignment.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

FontAlignment alignments[] = { FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom };
String labels[] = { u"Baseline", u"Top", u"Center", u"Bottom" };
float fontSizes[] = { 18.0f, 36.0f, 54.0f };
auto font = MakeObject<FontData>(u"Arial");

for (auto i = 0; i < 4; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 20 + i * 130, 660, 120);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);
    textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
    textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::False);

    auto label = textFrame->get_Paragraph(0);
    label->set_Text(labels[i]);
    label->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    auto labelFormat = label->get_ParagraphFormat()->get_DefaultPortionFormat();
    labelFormat->set_FontHeight(14);
    labelFormat->set_LatinFont(font);
    labelFormat->get_FillFormat()->set_FillType(FillType::Solid);
    labelFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->set_FontAlignment(alignments[i]);
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    auto portionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    portionFormat->set_LatinFont(font);
    portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
    portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    for (auto fontSize : fontSizes)
    {
        auto portion = MakeObject<Portion>(u"Ag ");
        portion->get_PortionFormat()->set_FontHeight(fontSize);
        paragraph->get_Portions()->Add(portion);
    }

    textFrame->get_Paragraphs()->Add(paragraph);
}

presentation->Save(u"font_alignment.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Összehasonlítás az alapvonal, felső, középső és alsó betűigazításról kevert betűméretekkel](font_alignment.png)

A betűigazítás a betűmetrikákon alapul, ezért az egyes betűk látható szélei nem feltétlenül esnek pontosan egy vonalra. A példa tartalmaz egy nagybetűt és egy lejjebb nyúló karaktert, hogy mutassa a különbséget az alapvonal és az alsó igazítás között. A betűtípus rendelkezésre állása, a használt karakterek és a betűméretek különbsége befolyásolja az eredményt. A keret méretei, margók, sortávolság, sortörés és automatikus illesztés szintén hatással vannak a megjelenésre; az összehasonlításkor ugyanazokat a betűtípusokat és beállításokat használja.

Ez a beállítás különbözik az [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/)‑tól, amely a vízszintes bekezdésigazítást szabályozza, valamint az [ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/)‑tól, amely a szövegtömb függőleges helyzetét határozza meg az alakzaton belül. A [IBasePortionFormat::set_Escapement](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_escapement/)‑tel végzett felső- és alsó indexelés a részleteket az alapvonalhoz képest eltolja, a bekezdés sorainak betűigazítását nem módosítva.

## **Szöveg átlátszóságának beállítása**

Az átlátszóság a [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/) által visszaadott szín alfa‑komponensén keresztül szabályozható. Az alábbi példákban az `alpha = 50` egy 0–255 skálájú ARGB alfa‑csatorna‑érték, nem átlátszósági százalék.

Az alábbi kódrészlet bemutatja, hogyan alkalmazzunk átlátszóságot a **teljes bekezdésre**:

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

Az alábbi kódrészlet bemutatja, hogyan alkalmazzunk átlátszóságot **félkövér betűvel rendelkező szövegrészek** esetén:

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

## **Karakterköz beállítása a szövegben**

A [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_spacing/) segítségével növelhető vagy szűkíthető a karakterek közötti távolság egy szövegmezőben. A példák 3 pont távolságot adnak hozzá; negatív értékek szűkítik a szöveget.

Az alábbi C++ kód azt mutatja, hogyan növelhető a karakterköz a **teljes bekezdésben**:

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

// Megjegyzés: Negatív értékekkel lehet a karakterközöt összenyomni.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // Bővíti a karakterközt.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan növelhető a karakterköz **félkövér betűvel rendelkező szövegrészek** esetén:

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
        // Megjegyzés: Negatív értékekkel lehet a karakterközöt összenyomni.
        portionFormat->set_Spacing(3.0f); // Bővíti a karakterközt.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által megjelenített szöveg kissé szorosabbnak tűnhet, mint a PowerPoint‑ban ugyanaz a szöveg. Ennek oka lehet, hogy a PowerPoint bizonyos betűtípusok esetén figyelmen kívül hagyja a kerning adatokat, még ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint beállításában a kerning engedélyezve is van.

Az ilyen esetekben a renderelt eredmény PowerPoint‑hoz hasonlóbbá tételéhez letilthatja a kerninget azoknál a szövegrészeknél, amelyek az érintett betűtípust használják. A [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) segítségével állíthat be egy értéket, amely nagyobb, mint a tényleges betűméret. Ez a példa a „presentation.pptx” fájlt igényli, amelyen az első dia első alakzata egy szövegmező. A hatékony betűneveket, beleértve az örökölt betűket, ellenőrzi, és 100 pontos küszöböt állít be azoknál a részeknél, amelyek a Roboto‑t használják. Ez letiltja a kerninget a 100 pont alatti betűmérettel rendelkező egyező részeknél:

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

A küszöb alatti egyező szövegek esetén ez a beállítás meggátolja a kerninget, és segíthet az Aspose.Slides renderelésének összhangban tartásában a PowerPoint vizuális kimenetével azon betűtípusoknál, amelyeket ez a PowerPoint‑specifikus viselkedés befolyásol.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten a [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) segítségével, vagy egyedi részeknél az [IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/) használatával.

Az alábbi példa a első bekezdés alapértelmezett betűtípusát 12 pontos Times New Roman‑ra állítja be félkövér, dőlt és pontozott aláhúzással. Az egyedi részeken megadott formázás felülírja ezeket az alapértelmezéseket:

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

Az alábbi példa 13 pontos Times New Roman‑t, dőlt formázást és pontozott aláhúzást alkalmaz azon részekre, amelyek hatékony formázása félkövér:

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

![A szövegrészek betűtulajdonságai](font_properties_for_text_portions.png)

## **Szövegmagasság normalizálásának vezérlése**

Használja a [IBasePortionFormat::set_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_normaliseheight/) metódust sablon tipográfia újraalkotásához vagy a karaktermagasságok közti különbségek vizsgálatához. PowerPoint‑ban a normalizálás engedélyezése függőlegesen nyújtja vagy összenyomja az egyes karaktereket, hogy egységes látható magasságot biztosítson a szövegrészben. Ez nem garantál egyenlő szövegmagasságot különböző betűtípusok között.

Az értéket a [NullableBool::True or False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/)‑ra állítva lehet kifejezetten engedélyezni vagy letiltani a normalizálást. A `NullableBool::NotDefined` azt jelenti, hogy a helyi beállítás nincs meghatározva, így a részörökli azt például a bekezdés [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/)‑ból. Ez nem jelenti a `False`‑t. A [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) és a [IBasePortionFormatEffectiveData::get_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformateffectivedata/get_normaliseheight/) segítségével lekérhető a feloldott logikai érték.

Az alábbi önálló példa **Arial** betűtípust igényel. Két szövegtömböt hoz létre, amelyek ugyanazokat a nagybetűket, kisbetűket, lejjebb nyúló karaktereket és ékezetes karaktereket 54 pontban tartalmazzák. Mindkét bekezdés alapértelmezésben engedélyezi a normalizálást. A felső rész kifejezetten letiltja, a alsó rész pedig örökli a beállítást. A keretek méretei, margói és bekezdésközei azonosak, a sortörés és az automatikus illesztés le van tiltva a konzisztens összehasonlítás érdekében. A példa kiírja a `False: False` és a `NotDefined: True` értékeket, majd elmenti a „text_height_normalization.pptx” fájlt.

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

NullableBool settings[] = { NullableBool::False, NullableBool::NotDefined };

for (auto i = 0; i < 2; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 60 + i * 200, 660, 150);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->set_Text(u"Hxgjpq ÅÉ 0123");
    textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
    textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::False);
    textFrame->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);
    textFrame->get_TextFrameFormat()->set_MarginTop(0);
    textFrame->get_TextFrameFormat()->set_MarginLeft(0);

    auto paragraph = textFrame->get_Paragraph(0);
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    paragraph->get_ParagraphFormat()->set_SpaceBefore(0);
    paragraph->get_ParagraphFormat()->set_SpaceAfter(0);
    paragraph->get_ParagraphFormat()->set_SpaceWithin(100);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_NormaliseHeight(NullableBool::True);

    auto portion = paragraph->get_Portion(0);
    auto font = MakeObject<FontData>(u"Arial");
    portion->get_PortionFormat()->set_LatinFont(font);
    portion->get_PortionFormat()->set_FontHeight(54);
    portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    portion->get_PortionFormat()->set_NormaliseHeight(settings[i]);

    Console::WriteLine(u"{0}: {1}", settings[i], portion->get_PortionFormat()->GetEffective()->get_NormaliseHeight());
}

presentation->Save(u"text_height_normalization.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az alábbi összehasonlítás a mentett prezentációból lett exportálva. A felső sorban a normalizálás le van tiltva (`False`); az alsó sor örökli az engedélyezett beállítást (`NotDefined` → `True`). Az eredmény reprodukálásához telepítve kell legyen az Arial.

![Arial 54‑pontos szöveg normalizálás nélkül felül, normalizálással alul](text_height_normalization.png)

A normalizálás a karaktermagasságot változtatja anélkül, hogy a [IBasePortionFormat::get_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fontheight/) értékét módosítaná, amely a betűméretet pontban adja meg. A bekezdés [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/) szabályozza a sortávolságot, míg a szövegkeret [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) határozza meg, hogy a szöveg vagy a tároló hogyan alkalmazkodik. Ezek a beállítások különböző célokat szolgálnak, és függetlenül befolyásolhatják a teljes elrendezést. A bekezdésformázásról és öröklődésről további információért tekintse meg a [Bekezdések kezelése](/slides/hu/cpp/manage-paragraph/) oldalt.

## **Áthúzás alkalmazása és eltávolítása**

Az [IBasePortionFormat::set_StrikethroughType](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_strikethroughtype/) használatával egy szövegrészen megjeleníthetők javítások, törölt kifejezések vagy korábbi árak a szöveg törlése nélkül. Állítsa be a [TextStrikethroughType::Single or Double](https://reference.aspose.com/slides/cpp/aspose.slides/textstrikethroughtype/) értékek egyikére, hogy egy vagy két vonal jelenjen meg a szöveg felett.

Az áthúzás eltávolításához állítsa a `TextStrikethroughType::None` értéket. Ez kifejezetten letiltja a hatást, még akkor is, ha a környező formázás áthúzást tartalmaz. Ezzel szemben a `TextStrikethroughType::NotDefined` azt jelenti, hogy a helyi beállítás nincs meghatározva, így a rész örökölheti a formázást, például a bekezdéstől. Az nem garantálja, hogy az áthúzás eltávolításra kerül. A [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) segítségével olvasható a végső formázás, beleértve az örökölt értékeket is.

Az alábbi önálló példa három árösszehasonlítást hoz létre. Minden bekezdés külön részeket tartalmaz a címke, a korábbi ár és az aktuális ár számára, így csak a korábbi ár érintett. Az első sor áthúzást alkalmaz, majd eltávolít; a többi sor egyszeres és dupla áthúzást tart meg. Ennek a tulajdonságnak a módosítása megőrzi a szöveget és egyéb formázását, beleértve a félkövér korábbi árat is.

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextStrikethroughType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

String labels[] = { u"None: ", u"Single: ", u"Double: " };

for (auto label : labels)
{
    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    paragraph->get_ParagraphFormat()->set_SpaceAfter(20);

    auto format = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    format->set_FontHeight(28);
    auto font = MakeObject<FontData>(u"Arial");
    format->set_LatinFont(font);
    format->get_FillFormat()->set_FillType(FillType::Solid);
    format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    auto labelPortion = MakeObject<Portion>(label);
    paragraph->get_Portions()->Add(labelPortion);

    auto previousPrice = MakeObject<Portion>(u"$100");
    previousPrice->get_PortionFormat()->set_FontBold(NullableBool::True);
    paragraph->get_Portions()->Add(previousPrice);
    auto currentPrice = MakeObject<Portion>(u" → $80");
    paragraph->get_Portions()->Add(currentPrice);

    textFrame->get_Paragraphs()->Add(paragraph);
}

// Alkalmazza az áthúzást, majd kifejezetten eltávolítja az első korábbi árból.
auto firstPriceFormat = textFrame->get_Paragraph(0)->get_Portion(1)->get_PortionFormat();
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::Single);
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::None);

textFrame->get_Paragraph(1)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Single);
textFrame->get_Paragraph(2)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Double);

presentation->Save(u"strikethrough.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény felülről lefelé: nincs áthúzás, egyszeres áthúzás és dupla áthúzás.

![Korábbi árak áthúzás nélkül, egyszeres áthúzással és dupla áthúzással](strikethrough.png)


## **Szöveg forgatásának beállítása**

Az [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_textverticaltype/) segítségével előre definiált szövegorientáció állítható be egy alakzaton belül.

Az alábbi kódrészlet a szövegorientációt a [TextVerticalType::Vertical270](https://reference.aspose.com/slides/cpp/aspose.slides/textverticaltype/) értékre állítja, amely **90 fokkal óramutatóval ellentétesen** forgatja a szöveget:

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

## **Számjegyek egymás mellé helyezése függőleges japán szövegben**

Egy kétjegyű szám függőleges japán címke esetén a számjegyeket egyetlen szövegrészben kell elhelyezni, majd a [IBasePortionFormat::set_Kumimoji](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_kumimoji/) metódust hívni. A példa a [TextVerticalType::EastAsianVertical](https://reference.aspose.com/slides/cpp/aspose.slides/textverticaltype/) értéket és 40 pontos MS Gothic‑ot használ mindkét címkehez. A numerikus részhez átadott [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) érték eltérő.

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto addLabel = [&slide](float x, NullableBool kumimoji)
{
    auto label = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, 48, 120, 420);
    label->get_FillFormat()->set_FillType(FillType::NoFill);
    label->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto frame = label->AddTextFrame(u"");
    frame->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::EastAsianVertical);

    auto paragraph = frame->get_Paragraph(0);
    auto format = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    auto font = MakeObject<FontData>(u"MS Gothic");
    format->set_LatinFont(font);
    format->set_EastAsianFont(font);
    format->set_FontHeight(40);
    format->get_FillFormat()->set_FillType(FillType::Solid);
    format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    auto digits = MakeObject<Portion>(u"12");
    digits->get_PortionFormat()->set_Kumimoji(kumimoji);

    auto portions = paragraph->get_Portions();
    portions->Clear();
    portions->Add(MakeObject<Portion>(u"令和"));
    portions->Add(digits);
    portions->Add(MakeObject<Portion>(u"年"));
};

addLabel(120, NullableBool::True);
addLabel(360, NullableBool::False);

presentation->Save(u"vertical_date.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

PowerPoint‑ban a bal oldali címke (`True`) függőlegesen állítja a számjegyeket, a két számjegy egymás mellett jelenik a 和 és 年 karakterek között. A jobb oldali címke (`False`) esetén a dupla 90 fokos óramutatóval megfelelő elforgatású. A környező japán karakterek mindkét címkén álló helyzetben maradnak.

![PowerPoint összehasonlítás a függőleges dátumcímkékről, bal oldalon álló számjegyekkel és jobb oldalon fordított számjegyekkel.](vertical_date.png)

## **Egyéni forgatás beállítása szövegkeretekhez**

Az [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) használatával egyedi forgatási szöget adhat meg egy [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) számára.

Az alábbi példa 3 fokkal óramutatóval azonos irányban forgatja el a szövegkeretet az alakzaton belül:

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

![Az egyéni szöveg forgatása](custom_text_rotation.png)

## **Bekezdések sortávolságának beállítása**

Az Aspose.Slides a [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spaceafter/), [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacebefore/) és [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/) metódusokkal szabályozza a bekezdésközöket. Ezeket a következőképpen használja:

* Pozitív értékkel a sortávolság a sormagasság százalékában adható meg.
* Negatív értékkel a sortávolság pontban adható meg.

Az alábbi példa a bekezdésen belüli sortávolságot a sormagasság 200 %-ára (kétszeres sorköz) állítja:

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

## **Sorok tördelésének vezérlése**

A bekezdés sorok tördelésének szabályai szűk szövegblokkokban és olyan prezentációkban hasznosak, ahol latin és kelet-ázsiai szöveg keveredik. Az alábbi módszerek az [IParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/) részei, ezért egy teljes bekezdésre vonatkoznak:

* A [IParagraphFormat::set_LatinLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_latinlinebreak/) szabályozza a latin szöveg tördelését. Vegyes szöveg esetén ennek módosítása megváltoztathatja a szomszédos kelet-ázsiai szöveg és írásjelek tördelésének helyét is.
* A [IParagraphFormat::set_EastAsianLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_eastasianlinebreak/) szabályozza a kelet-ázsiai szöveg tördelését, beleértve a sor elején és végén lévő karakterek korlátozását.

E szabályok nem helyettesítik az [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) metódust, amely a szövegkereten belüli automatikus sortörést engedélyezi. A fenti szabályok befolyásolják a layoutot, amikor a sortörés megtörténik; nem illesztenek be sorvége karaktert. Egy explicit sortörés új sort hoz létre a bekezdésen belül, függetlenül a rendelkezésre álló szélességtől.

Az alábbi önálló példa egy keskeny szövegblokkot hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sorbontási szabályt explicit módon beállítja, majd a „line_breaking.pptx” fájlt menti. A szabályok teszteléséhez módosítsa a setternek átadott értéket, miközben a többi beállítást változatlanul hagyja. A példa 24 pontos Arial‑t és SimSun‑t használ 160 pont széles kerettel és nulla vízszintes szövegkeret‑margóval. Az [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) a [TextAutofitType::None](https://reference.aspose.com/slides/cpp/aspose.slides/textautofittype/) értékre van állítva, hogy a betűméret és a keret méretei rögzítve legyenek.

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

## **Függőleges írásjelek használata**

Az [IParagraphFormat::set_HangingPunctuation](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_hangingpunctuation/) lehetővé teszi, hogy az adott írásjelek a sor jobb szélén túlnyúljanak ahelyett, hogy a következő sorba kerülnek. Ez a beállítás a teljes bekezdésre vonatkozik, és különbözik a függőleges behúzástól.

Az alábbi önálló példa engedélyezi a függőleges írásjeleket egy 100 pont széles szövegkeretben, majd a „hanging_punctuation.pptx” fájlt menti. 24 pontos Arial és nulla vízszintes szövegkeret‑margó használatával a végső pont a „sentence” szó után marad, és a sor jobb szélén túl nyúlik. A [NullableBool::False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) átadásával összehasonlítható, hogy ebben az esetben a pont külön sorba kerül. A sortörés engedélyezett, az automatikus illesztés le van tiltva, hogy a rendelkezésre álló szélesség rögzítve legyen.

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

Nem minden írásjel függetlenen függőleges. A fentebb leírt [betű- és elrendezési feltételek](#control-line-breaking) szintén érvényesek erre az összehasonlításra: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus illesztés módosítása eltüntetheti a látható különbséget.

## **Automatikus illesztés típusának beállítása szövegkeretekhez**

Az [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) meghatározza, hogyan viselkedjen a szöveg, ha meghaladja a tároló határait. Használja azt, hogy szabályozza, a szöveg zsugorodjon, túlcsorduljon vagy a forma automatikusan méreteződjön. Az alábbi példa úgy konfigurálja a formát, hogy a szöveghez igazodva méretezze a formát, majd a „autofit_type.pptx” fájlt menti.

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

Az automatikus sortörés utáni sorok számolásához és a szöveg vagy a forma szélesség változásának megtekintéséhez tekintse meg a [Renderelt sorok számlálása](/slides/hu/cpp/manage-paragraph/) oldalt. A sorok száma önmagában nem mutatja, hogy a szöveg túlcsordul-e a tárolóból.

## **Szövegkeretek rögzítésének beállítása**

Az [ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/) meghatározza, hogyan helyezkedik el függőlegesen a szöveg egy alakzaton belül, például a tetején, közepén vagy alján. Az alábbi példa a szöveget az első alakzat aljához rögzíti, majd a „text_anchor.pptx” fájlt menti.

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

## **Szöveg tabulációjának beállítása**

Használja a [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) és a [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_tabs/) metódusokat a bekezdés tabulátorállásainak konfigurálásához. Az alábbi példa az alapértelmezett tabulátort 100 pontra állítja, és egy balra igazított tabulátort ad hozzá 30 pontnál. Ezek a beállítások a tabulátor‑karaktereket tartalmazó szövegre hatnak.

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

## **Helyesírási nyelv beállítása**

Az Aspose.Slides a [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) segítségével lehetővé teszi a szövegrészek helyesírási nyelvének beállítását. A helyesírási nyelv meghatározza, hogy a PowerPoint milyen nyelven ellenőrizze a helyesírást és a nyelvtant.

Az alábbi példa a „presentation.pptx” fájlt igényli, amelyen az első dia első alakzata egy szövegmező és legalább egy bekezdés van. Az első bekezdés tartalmát „1。”‑re cseréli, a betűtípust SimSun‑ra állítja, és a Kínai (egyszerű) helyesírási nyelvet (`zh-CN`) rendeli hozzá. A „proofing_language.pptx” fájlt menti:

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

// Állítsa be a helyesírási nyelvet egyszerű kínai nyelvre.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1。");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Nyelvi metaadat másolása**

Többnyelvű szöveg sablonból történő másolásakor mindkét nyelvi azonosítót meg kell őrizni a [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) és a [IBasePortionFormat::set_AlternativeLanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_alternativelanguageid/) használatával. Az alábbi önálló példa egy forrásrészt hoz létre, amelynek elsődleges nyelve az amerikai angol, alternatív nyelve a francia, majd a szöveget és az azonosítókat egy új prezentáció egy részébe másolja.

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

auto source = System::MakeObject<Portion>(u"Hello! Bonjour!");
source->get_PortionFormat()->set_LanguageId(u"en-US");
source->get_PortionFormat()->set_AlternativeLanguageId(u"fr-FR");

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto destination = System::MakeObject<Portion>();
destination->set_Text(source->get_Text());
destination->get_PortionFormat()->set_LanguageId(source->get_PortionFormat()->get_LanguageId());
// Ha a forrásnak nincs alternatív nyelve, egy null karakterlánc törli a cél értékét.
destination->get_PortionFormat()->set_AlternativeLanguageId(source->get_PortionFormat()->get_AlternativeLanguageId());
paragraph->get_Portions()->Add(destination);

presentation->Save(u"copied_language_metadata.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ha forrást akar anélkül, hogy alternatív nyelv lenne, hagyja ki a `u"fr-FR"` hozzárendelését. Az alternatív azonosító ilyenkor null‑string, és ugyanaz a másolási parancs megőrzi a hiányát anélkül, hogy alapértelmezett értéket vezetne be, még ha a célhelyen korábban már be van állítva alternatív nyelv.

Ezek az azonosítók nyelvi metaadatai. Megőrzésük nem határozza meg, hogy a PowerPoint melyik szótárat használja a helyesírás vagy nyelvtani ellenőrzéshez.

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_defaulttextlanguage/) metódust az alapértelmezett nyelv meghatározásához a prezentáció betöltése vagy létrehozása során. Az alábbi példa egy prezentációt hoz létre, amelynek alapértelmezett szövegnyelve az amerikai angol, egy szövegmezőt ad hozzá, majd az első szövegrésznek kiírja az `en-US` értéket.

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

Az alapértelmezett szövegformázás alkalmazásához a prezentáció szintjén használja az [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_defaulttextstyle/) metódust.

Az alábbi példa 14 pontos félkövér betűtípust állít be az új prezentáció felső szintű bekezdéseihez, majd a „default_text_style.pptx” fájlt menti. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak egy specifikusabb formázás nincs előnyben.

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

// Lekéri a legfelső szintű bekezdésformátumot.
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

## **Nagybetűs effektussal ellátott szöveg kinyerése**

PowerPoint‑ban a **All Caps** betűtípus‑effektus alkalmazása azt eredményezi, hogy a szöveg a dián nagybetűvel jelenik meg, még akkor is, ha eredetileg kisbetűvel lett beírva. Amikor ilyen szövegrészt kér le az Aspose.Slides, a könyvtár pontosan úgy adja vissza a szöveget, ahogyan azt beírták. A megjelenített szöveghez való igazításhoz ellenőrizze a [TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) értékét, és ha az [TextCapType::All](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) értékre van állítva, konvertálja a visszakapott karakterláncot nagybetűssé.

Ez a példa a „sample2.pptx” fájlt igényli, amelyen az első dia első alakzata egy szövegmező, és az első bekezdés első része a „Hello, Aspose!” szöveget tartalmazza, amelyen az All Caps effektus alkalmazva van, ahogyan az alább látható.

![Az All Caps effektus](all_caps_effect.png)

Az alábbi kódrészlet bemutatja, hogyan nyerhető ki a **All Caps** effektussal ellátott szöveg:

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

## **GYIK**

**Hogyan módosíthatom a táblázat szövegét egy dián?**

A táblázat szövegének módosításához a dián használja az [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) interfészt. Iteráljon a cellákon, és frissítse az egyes cellákat a [ICell::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) és a [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/) segítségével.

**Hogyan alkalmazhatok fokozatos színátmenetet a szövegre egy PowerPoint dián?**

A szövegre való fokozatos színátmenet alkalmazásához használja az [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/) metódust. Állítsa az [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) értékét a [FillType::Gradient](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) típusra, és konfigurálja a gradient‑állomásokat, irányt és átlátszóságot.

Kapcsolódó funkció: [Formázza a szöveget a diákon](/slides/hu/features/text-formatting/).