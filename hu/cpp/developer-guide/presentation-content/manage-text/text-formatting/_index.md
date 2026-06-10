---
title: Prezentáció szövegének formázása C++-ban
linktitle: Szövegformázás
type: docs
weight: 50
url: /hu/cpp/text-formatting/
keywords:
- szöveg kiemelése
- reguláris kifejezés
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszóság
- karakterköz
- betűtulajdonságok
- betűtípus család
- szöveg forgatás
- forgatási szög
- szövegdoboz
- sorköz
- automatikus illesztés beállítás
- szövegdoboz rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Formázza és stilizálja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for C++ használatával. Testreszabhatja a betűtípusokat, színeket, igazítást és egyéb beállításokat."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet formázni a szöveget PowerPoint és OpenDocument bemutatókban az Aspose.Slides for C++ használatával. Kitér a kiemelésre, háttérszínekre, átlátszóságra, karakterközökre, betűtulajdonságokra, forgatásra, bekezdésközökre, automatikus illesztésre, szöveg rögzítésére, tabulátorok beállítására és nyelvi beállításokra.

Az alábbi példákban a "sample.pptx" nevű fájlt használjuk, amely egyetlen szövegdobozt tartalmaz az első dián a következő szöveggel:

![Minta szöveg](sample_text.png)

## **Szöveg kiemelése**

Használja a [ITextFrame.HighlightText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/highlighttext/) metódust, amikor egy szövegkeretben egy adott mintának megfelelő szöveget kell kiemelni. A metódus egy kiemelő színt alkalmaz a megfelelő szövegrészletekre, és használható a [ITextSearchOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextsearchoptions/) segítségével a keresés módjának szabályozására, például csak teljes szavak egyezésére.

Az alábbi kódrészlet kiemeli a **"try"** karakterek minden előfordulását, majd csak a teljes **"to"** szót emeli ki.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// Szerezze meg az első alakzatot az első diáról.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Emelje ki a "try" szót az alakzatban.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// Emelje ki a "to" szót az alakzatban.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A kiemelt szöveg](highlighted_text.png)

## **Szöveg kiemelése reguláris kifejezésekkel**

A [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/highlightregex/) metódus kiemeli a reguláris kifejezés által talált szövegösszeeséseket. C++‑ban ez az API a [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) felületén érhető el.

Az alábbi kódrészlet kiemeli az összes olyan szót, amely **hét vagy több karaktert** tartalmaz:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Highlight all words with seven or more characters.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A reguláris kifejezéssel kiemelt szöveg](highlighted_text_using_regex.png)

## **Szöveg háttérszín beállítása**

Használja a [IParagraphFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat`‑t a bekezdés alapértelmezett kiemelő színének beállításához, vagy használja a [IPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportionformat/)`.HighlightColor`‑t az egyedi szövegrészekhez.

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín a **teljes bekezdésre**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Állítsa be a kiemelés színét a teljes bekezdésre.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín a **félkövér betűtípussal rendelkező szövegrészek** számára:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Állítsa be a szövegrész kiemelés színét.
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A szürke szövegrészek](gray_text_portions.png)

## **Szövegbekezdések igazítása**

Használja a [IParagraphFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/)`.Alignment`‑t a bekezdés igazításának beállításához egy szövegkereten belül. Az érték lehet középre, balra, jobbra, sorkizárt stb.

Az alábbi kódrészlet bemutatja, hogyan igazítható a bekezdés a **középre**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Állítsa be a bekezdés igazítását középre.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az igazított bekezdés](aligned_paragraph.png)

## **Szöveg átlátszóság beállítása**

A szöveg átlátszóságát az [IPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportionformat/)`.FillFormat`‑hez rendelt szín alfa komponensével szabályozzák. Az alábbi példákban az `alpha = 50` egy ARGB alfa-csatorna érték a 0‑255 skálán, nem átlátszósági százalék.

Az alábbi kódrészlet bemutatja, hogyan alkalmazható átlátszóság a **teljes bekezdésre**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Set the fill color of the text to transparent color.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az átlátszó bekezdés](transparent_paragraph.png)

A következő kódrészlet bemutatja, hogyan alkalmazható átlátszóság a **félkövér betűtípussal rendelkező szövegrészek** számára:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Állítsa be a szövegrész átlátszóságát.
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az átlátszó szövegrészek](transparent_text_portions.png)

## **Karakterköz beállítása szöveghez**

Használja a [IBasePortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/)`.Spacing`‑t a karakterek közötti távolság növeléséhez vagy csökkentéséhez egy szövegdobozban.

Az alábbi C++ kód mutatja, hogyan növelhető a karakterköz a **teljes bekezdésben**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Megjegyzés: A karakterköz szorításához használjon negatív értékeket.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A bekezdés karakterköze](character_spacing_in_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan növelhető a karakterköz a **félkövér betűtípussal rendelkező szövegrészek** esetén:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Megjegyzés: A karakterköz szorításához használjon negatív értékeket.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A szövegrészek karakterköze](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg valamivel szorosabbnak tűnhet, mint a PowerPointban megjelenített ugyanaz a szöveg. Ez azért fordulhat elő, mert a PowerPoint bizonyos betűtípusoknál figyelmen kívül hagyhatja a kerning adatokat, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint beállításaiban a kerning engedélyezve van.

Az ilyen esetekben a renderelt kimenet PowerPointnak megfelelőbbé tételéhez letilthatja a kerninget az érintett betűtípust használó szövegrészeknél. Állítsa be az [IPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize` értékét lényegesen nagyobbra, mint a tényleges betűméret:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
System::String targetFont = u"Roboto";
auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = paragraphs->idx_get(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = portions->idx_get(portionIndex);
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

Ez a beállítás megakadályozza, hogy a kerning alkalmazásra kerüljön a megfelelő szövegrészekre, és segíthet az Aspose.Slides renderelését a PowerPoint vizuális kimenetéhez igazítani azoknál a betűtípusoknál, amelyeket ez a PowerPoint‑specifikus viselkedés érint.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók bekezdési szinten a [IParagraphFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat`‑en keresztül, vagy egyes részeknél a [IPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportionformat/)`.

Az alábbi kód beállítja a betűtípust és a szöveg stílusát a teljes bekezdésre: alkalmazza a betűméretet, félkövér, dőlt, pontozott aláhúzást, valamint a Times New Roman betűtípust a bekezdés minden részére.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Állítsa be a bekezdés betűtulajdonságait.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A bekezdés betűtulajdonságai](font_properties_for_paragraph.png)

Az alábbi kódrészlet hasonló tulajdonságokat alkalmaz a **félkövér betűtípussal rendelkező szövegrészek** számára:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Állítsa be a betűtulajdonságokat a szövegrészhez.
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A szövegrészek betűtulajdonságai](font_properties_for_text_portions.png)

## **Szöveg forgatásának beállítása**

Használja az [ITextFrameFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/)`.TextVerticalType`‑t előre definiált szövegorientáció beállításához egy alakzatban.

Az alábbi kódrészlet a szövegorientációt `Vertical270`‑re állítja az alakzatban, ami **90 fokos balra forgatást** jelent:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A szöveg forgatása](text_rotation.png)

## **Egyedi forgatás beállítása szövegdobozokhoz**

Használja az [ITextFrameFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/)`.RotationAngle`‑t egyéni forgatási szög beállításához egy [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) .

Az alábbi kódrészlet 3 fokkal forgatja el a szövegdobozt az alakzaton belül óramutató járásával megegyező irányban:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az egyedi szövegforgatás](custom_text_rotation.png)

## **Bekezdések sorközének beállítása**

Az Aspose.Slides biztosítja a [IParagraphFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`, `IParagraphFormat.SpaceBefore` és `IParagraphFormat.SpaceWithin` tulajdonságokat a bekezdésköz szabályozásához. Ezeket a tulajdonságokat a következőképpen használják:

* Pozitív érték használata a sorköz megadása a sormagasság százalékában.
* Negatív érték használata a sorköz megadása pontban.

Az alábbi kódrészlet bemutatja, hogyan adható meg a sorköz a bekezdésen belül:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A bekezdésen belüli sorköz](line_spacing.png)

## **Automatikus illesztés típusának beállítása szövegdobozokhoz**

Az [ITextFrameFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/)`.AutofitType` meghatározza, hogyan viselkedik a szöveg, ha meghaladja a tárolója határait. Használja a szöveg zsugorodásának, túlfutásának vagy az alakzat automatikus méretezésének szabályozására.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Szövegdobozok rögzítésének beállítása**

Az [ITextFrameFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/)`.AnchoringType` meghatározza, hogyan helyezkedik el a szöveg függőlegesen egy alakzatban, például a tetején, közepén vagy alján.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Szöveg tabulációjának beállítása**

Használja az [IParagraphFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize` és `IParagraphFormat.Tabs` beállításokat a bekezdés tabulátorállásainak konfigurálásához.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A bekezdés tabulátorai](paragraph_tabs.png)

## **Helyesírási nyelv beállítása**

Az Aspose.Slides a [IPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportionformat/)`.LanguageId`‑t biztosítja, amely lehetővé teszi a szövegrész helyesírási nyelvének beállítását. A helyesírási nyelv határozza meg a PowerPointban a helyesírási és nyelvtani ellenőrzés nyelvét.

Az alábbi kódrészlet bemutatja, hogyan állítható be a helyesírási nyelv egy szövegrészhez:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
textPortion->get_PortionFormat()->set_ComplexScriptFont(font);
textPortion->get_PortionFormat()->set_EastAsianFont(font);
textPortion->get_PortionFormat()->set_LatinFont(font);

// Állítsa be a helyesírási nyelv azonosítóját.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Alapértelmezett nyelv beállítása**

Használja a [ILoadOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage`‑t a prezentáció betöltése vagy létrehozása során létrehozott szöveg alapértelmezett nyelvének meghatározásához.

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Adjunk hozzá egy új négyszög alakzatot szöveggel.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Ellenőrizze az első rész nyelvét.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás prezentációszinten történő alkalmazásához használja a [IPresentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle`‑t.

Az alábbi kódrészlet bemutatja, hogyan állítható be egy alapértelmezett félkövér betűtípus 14 pt mérettel az új prezentáció minden diáján lévő összes szöveghez.

```cpp
auto presentation = System::MakeObject<Presentation>();

// Szerezze be a legfelső szintű bekezdésformátumot.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Szöveg kinyerése nagybetűs hatással**

A PowerPointban az **All Caps** betűhatás alkalmazása a szöveget nagybetűsen jeleníti meg a dián, még akkor is, ha eredetileg kisbetűvel írták. Amikor ilyen szövegrészt kér le az Aspose.Slides, a könyvtár pontosan úgy adja vissza a szöveget, ahogy beírták. A megjelenített szövegnek megfelelően ellenőrizze a [TextCapType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textcaptype/) értékét, és alakítsa a visszakapott karakterláncot nagybetűssé, ha az érték `All`.

Tegyük fel, hogy a sample2.pptx első diáján a következő szövegdoboz található:

![A nagybetűs hatás](all_caps_effect.png)

Az alábbi kódrészlet bemutatja, hogyan nyerhető ki a szöveg a **All Caps** hatással:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

System::Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```

Kimenet:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **GYIK**

**Hogyan lehet módosítani a szöveget egy táblázatban a dián?**

A dián lévő táblázat szövegének módosításához használja az [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/). Iteráljon a cellákon, és frissítse minden cellát az [ICell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icell/)`.TextFrame` segítségével, illetve a bekezdésformázást az [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/)`.ParagraphFormat` segítségével.

**Hogyan alkalmazzunk színátmenetet a szövegre egy PowerPoint dián?**

A szövegre színátmenet alkalmazásához használja a [IPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportionformat/)`.FillFormat`‑t. Állítsa be a [IFillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifillformat/)`.FillType` értékét a [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/)`.Gradient`‑ra, és konfigurálja a színátmenet állomásait, irányát és átlátszóságát.