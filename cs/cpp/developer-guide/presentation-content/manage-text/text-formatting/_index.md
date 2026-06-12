---
title: Formátování textu prezentace v C++
linktitle: Formátování textu
type: docs
weight: 50
url: /cs/cpp/text-formatting/
keywords:
- zvýraznění textu
- regulární výraz
- zarovnání odstavce
- styl textu
- pozadí textu
- průhlednost textu
- mezera mezi znaky
- vlastnosti fontu
- rodina fontů
- rotace textu
- úhel rotace
- textový rám
- řádkování
- vlastnost automatického přizpůsobení
- ukotvení textového rámu
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

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro C++. Pokrývá zvýrazňování, barvy pozadí, průhlednost, mezery mezi znaky, vlastnosti fontu, rotaci, mezery odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

V příkladech níže použijeme soubor s názvem „sample.pptx“, který obsahuje jedinou textovou oblast na první snímku s následujícím textem:

![Ukázkový text](sample_text.png)

## **Zvýraznění textu**

Použijte metodu [ITextFrame.HighlightText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/highlighttext/) když potřebujete zvýraznit text, který odpovídá konkrétnímu vzorku v textovém rámci. Metoda aplikuje barvu zvýraznění na odpovídající úseky textu a lze ji použít s [ITextSearchOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextsearchoptions/) k řízení provádění vyhledávání, například pro shodu pouze celých slov.

Ukázkový kód níže zvýrazní všechny výskyty znaků **"try"** a poté zvýrazní pouze celé slovo **"to"**.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// Získejte první tvar z prvního snímku.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Zvýrazněte slovo "try" v tvaru.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// Zvýrazněte slovo "to" v tvaru.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Zvýrazněný text](highlighted_text.png)

## **Zvýraznění textu pomocí regulárních výrazů**

Metoda [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/highlightregex/) zvýrazňuje shody textu nalezené regulárním výrazem. V C++ je toto API k dispozici na [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/).

Ukázkový kód níže zvýrazní všechna slova, která obsahují **sedm nebo více znaků**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Highlight all words with seven or more characters.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Zvýrazněný text pomocí regulárního výrazu](highlighted_text_using_regex.png)

## **Nastavení barvy pozadí textu**

Použijte [IParagraphFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` k nastavení výchozí barvy zvýraznění pro odstavec nebo použijte [IPortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportionformat/)`.HighlightColor` pro jednotlivé části textu.

Následující ukázkový kód ukazuje, jak nastavit barvu pozadí pro **celý odstavec**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Nastavte barvu zvýraznění pro celý odstavec.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Šedý odstavec](gray_paragraph.png)

Ukázkový kód níže demonstruje, jak nastavit barvu pozadí pro **části textu s tučným písmem**:

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
        // Nastavte barvu zvýraznění pro část textu.
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Šedé části textu](gray_text_portions.png)

## **Zarovnání odstavců textu**

Použijte [IParagraphFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/)`.Alignment` k nastavení zarovnání odstavce v textovém rámci. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, do bloku atd.

Následující ukázkový kód ukazuje, jak zarovnat odstavec do **středu**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Nastavte zarovnání odstavce na střed.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Zarovnaný odstavec](aligned_paragraph.png)

## **Nastavení průhlednosti textu**

Průhlednost textu je řízena pomocí alfa komponenty barvy přiřazené k [IPortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportionformat/)`.FillFormat`. V níže uvedených příkladech je `alpha = 50` hodnota ARGB alfa kanálu v rozsahu 0‑255, nikoli procento průhlednosti.

Ukázkový kód níže ukazuje, jak použít průhlednost na **celý odstavec**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Nastavte výplňovou barvu textu na průhlednou barvu.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Průhledný odstavec](transparent_paragraph.png)

Následující ukázkový kód ukazuje, jak použít průhlednost na **části textu s tučným písmem**:

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
        // Nastavte průhlednost části textu.
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Průhledné části textu](transparent_text_portions.png)

## **Nastavení mezery mezi znaky pro text**

Použijte [IBasePortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseportionformat/)`.Spacing` pro rozšíření nebo zúžení mezery mezi znaky v textovém poli.

Následující C++ kód ukazuje, jak rozšířit mezeru mezi znaky v **celém odstavci**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Poznámka: Použijte záporné hodnoty pro zmenšení mezery mezi znaky.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Mezera mezi znaky v odstavci](character_spacing_in_paragraph.png)

Ukázkový kód níže ukazuje, jak rozšířit mezeru mezi znaky v **částech textu s tučným písmem**:

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
        // Poznámka: Použijte záporné hodnoty pro zmenšení mezery mezi znaky.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Mezera mezi znaky v částech textu](character_spacing_in_text_portions.png)

### **Zakázání kerningu pro konkrétní písma**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určitá písma, i když písmo obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby byl výstup při takových případech bližší PowerPointu, můžete zakázat kerning pro části textu, které používají dotčené písmo. Nastavte [IPortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize` na hodnotu výrazně větší než skutečná velikost písma:

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

Toto nastavení zabraňuje aplikaci kerningu na odpovídající části textu a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu pro písma, která jsou touto specifickou chováním PowerPointu postižena.

## **Správa vlastností fontu textu**

Vlastnosti fontu lze nastavit na úrovni odstavce pomocí [IParagraphFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` nebo na jednotlivých částech pomocí [IPortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportionformat/)`.

Následující kód nastavuje font a styl textu pro celý odstavec: aplikuje velikost písma, tučný, kurzíva, tečkované podtržení a font Times New Roman na všechny části v odstavci.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Nastavte vlastnosti fontu pro odstavec.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Vlastnosti fontu pro odstavec](font_properties_for_paragraph.png)

Ukázkový kód níže aplikuje podobné vlastnosti na **části textu s tučným písmem**:

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
        // Nastavte vlastnosti fontu pro část textu.
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Vlastnosti fontu pro části textu](font_properties_for_text_portions.png)

## **Nastavení rotace textu**

Použijte [ITextFrameFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/)`.TextVerticalType` k nastavení předdefinované orientace textu uvnitř tvaru.

Následující ukázkový kód nastavuje orientaci textu v tvaru na `Vertical270`, což otočí text **o 90 stupňů proti směru hodinových ručiček**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Rotace textu](text_rotation.png)

## **Nastavení vlastní rotace pro textové rámy**

Použijte [ITextFrameFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/)`.RotationAngle` k nastavení vlastního úhlu rotace pro [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/).

Ukázkový kód níže otočí textový rám o 3 stupně po směru hodinových ručiček uvnitř tvaru:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Vlastní rotace textu](custom_text_rotation.png)

## **Nastavení řádkování odstavců**

Aspose.Slides poskytuje [IParagraphFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`, `IParagraphFormat.SpaceBefore` a `IParagraphFormat.SpaceWithin` pro řízení mezery odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu pro určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu pro určení řádkování v bodech.

Následující ukázkový kód ukazuje, jak specifikovat řádkování v odstavci:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Řádkování v odstavci](line_spacing.png)

## **Nastavení typu automatického přizpůsobení pro textové rámy**

[ITextFrameFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/)`.AutofitType` určuje, jak se text chová, když překročí hranice svého kontejneru. Použijte jej k řízení, zda se text zmenšuje, přetéká nebo automaticky mění velikost tvaru.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nastavení ukotvení textových rámů**

[ITextFrameFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/)`.AnchoringType` určuje, jak je text vertikálně umístěn uvnitř tvaru, např. nahoře, uprostřed nebo dole.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nastavení tabulace textu**

Použijte [IParagraphFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize` a `IParagraphFormat.Tabs` k nastavení tabulátorů v odstavci.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Tabulátory odstavce](paragraph_tabs.png)

## **Nastavení pravopisného jazyka**

Aspose.Slides poskytuje [IPortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportionformat/)`.LanguageId`, který umožňuje nastavit pravopisný jazyk pro část textu. Pravopisný jazyk určuje jazyk použitého pro kontrolu pravopisu a gramatiky v PowerPointu.

Následující ukázkový kód ukazuje, jak nastavit pravopisný jazyk pro část textu:

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

// Nastavte Id pravopisného jazyka.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nastavení výchozího jazyka**

Použijte [ILoadOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage` k definování výchozího jazyka pro text vytvářený při načítání nebo tvorbě prezentace.

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Přidejte nový obdélníkový tvar s textem.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Zkontrolujte jazyk první části textu.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **Nastavení výchozího stylu textu**

Pro použití výchozího formátování textu na úrovni prezentace použijte [IPresentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle`.

Následující ukázkový kód ukazuje, jak nastavit výchozí tučný font o velikosti 14 pt pro celý text napříč snímky v nové prezentaci.

```cpp
auto presentation = System::MakeObject<Presentation>();

// Získejte formát odstavce nejvyšší úrovně.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Extrahování textu s efektem Všech Velkých Písmen**

V PowerPointu aplikování efektu **All Caps** (všechna velká písmena) způsobí, že se text na snímku zobrazí velkými písmeny, i když byl původně zadán malými. Když takovou část textu načtete pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro shodu se zobrazeným textem zkontrolujte [TextCapType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textcaptype/) a převěďte vrácený řetězec na velká písmena, pokud je hodnota `All`.

Řekněme, že máme následující textové pole na prvním snímku souboru sample2.pptx.

![Efekt Všech Velkých Písmen](all_caps_effect.png)

Ukázkový kód níže ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

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

Výstup:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Často kladené otázky**

**Jak upravit text v tabulce na snímku?**

Pro úpravu textu v tabulce na snímku použijte [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/). Procházejte buňky a aktualizujte každou buňku pomocí [ICell](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icell/)`.TextFrame` a formátování odstavců pomocí [IParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/)`.ParagraphFormat`.

**Jak aplikovat gradientní barvu na text v PowerPoint snímku?**

Pro aplikaci gradientní barvy na text použijte [IPortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportionformat/)`.FillFormat`. Nastavte [IFillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifillformat/)`.FillType` na [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/)`.Gradient` a nakonfigurujte gradientové zastavení, směr a průhlednost.