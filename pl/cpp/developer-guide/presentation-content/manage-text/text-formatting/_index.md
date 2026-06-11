---
title: "Formatowanie tekstu prezentacji w C++"
linktitle: "Formatowanie tekstu"
type: docs
weight: 50
url: /pl/cpp/text-formatting/
keywords:
- podświetlanie tekstu
- wyrażenie regularne
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
- właściwość autofitu
- kotwiczenie ramki tekstowej
- tabulacja tekstu
- domyślny język
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Formatowanie i stylizacja tekstu w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++. Dostosuj czcionki, kolory, wyrównanie i inne."
---
## **Przegląd**

Ten artykuł pokazuje, jak formatować tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++. Omówiono w nim podświetlanie, kolory tła, przezroczystość, odstępy między znakami, właściwości czcionek, obrót, odstępy między akapitami, zachowanie autofit, kotwiczenie tekstu, tabulatory i ustawienia języka.

W poniższych przykładach użyjemy pliku o nazwie „sample.pptx”, który zawiera jedną ramkę tekstową na pierwszym slajdzie z następującym tekstem:

![Sample text](sample_text.png)

## **Podświetlanie tekstu**

Użyj metody [ITextFrame.HighlightText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/highlighttext/) wtedy, gdy potrzebujesz podświetlić tekst pasujący do określonego wzorca w ramce tekstowej. Metoda nakłada kolor podświetlenia na dopasowane fragmenty tekstu i może być używana wraz z [ITextSearchOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextsearchoptions/), aby kontrolować sposób wyszukiwania, na przykład aby dopasować tylko całe słowa.

Poniższy przykład kodu podświetla wszystkie wystąpienia znaków **„try”**, a następnie podświetla tylko pełne słowo **„to”**.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// Pobierz pierwszą figurę z pierwszego slajdu.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Podświetl słowo "try" w figurze.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// Podświetl słowo "to" w figurze.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The highlighted text](highlighted_text.png)

## **Podświetlanie tekstu przy użyciu wyrażeń regularnych**

Metoda [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/highlightregex/) podświetla dopasowania tekstu znalezione przez wyrażenie regularne. W C++ API to udostępniono w [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/).

Poniższy przykład kodu podświetla wszystkie słowa zawierające **siedem lub więcej znaków**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Highlight all words with seven or more characters.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Ustawianie koloru tła tekstu**

Użyj `DefaultPortionFormat` z [IParagraphFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/) aby ustawić domyślny kolor podświetlenia dla akapitu lub użyj `HighlightColor` z [IPortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportionformat/) dla poszczególnych fragmentów tekstu.

Poniższy przykład kodu pokazuje, jak ustawić kolor tła dla **całego akapitu**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Ustaw kolor podświetlenia dla całego akapitu.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The gray paragraph](gray_paragraph.png)

Poniższy przykład kodu demonstruje, jak ustawić kolor tła dla **fragmentów tekstu z pogrubioną czcionką**:

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
            // Ustaw kolor podświetlenia dla fragmentu tekstu.
            portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The gray text portions](gray_text_portions.png)

## **Wyrównywanie akapitów tekstowych**

Użyj `Alignment` z [IParagraphFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/) aby ustawić wyrównanie akapitu wewnątrz ramki tekstowej. Wartość może być wyśrodkowana, wyrównana do lewej, do prawej, justowana itp.

Poniższy przykład kodu pokazuje, jak wyrównać akapit do **środka**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Ustaw wyrównanie akapitu na środku.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The aligned paragraph](aligned_paragraph.png)

## **Ustawianie przezroczystości tekstu**

Przezroczystość tekstu jest kontrolowana przez składnik alfa koloru przypisanego do `FillFormat` z [IPortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportionformat/). W poniższych przykładach `alpha = 50` oznacza wartość kanału alfa ARGB w skali 0‑255, a nie procent przezroczystości.

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **całego akapitu**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Ustaw kolor wypełnienia tekstu na kolor przezroczysty.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The transparent paragraph](transparent_paragraph.png)

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **fragmentów tekstu z pogrubioną czcionką**:

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
        // Ustaw przezroczystość fragmentu tekstu.
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The transparent text portions](transparent_text_portions.png)

## **Ustawianie odstępu między znakami w tekście**

Użyj `Spacing` z [IBasePortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseportionformat/) aby zwiększyć lub zmniejszyć odstęp między znakami w ramce tekstowej.

Poniższy kod C++ pokazuje, jak zwiększyć odstęp między znakami w **całym akapicie**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Uwaga: użyj wartości ujemnych, aby zmniejszyć odstęp między znakami.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Poniższy przykład kodu pokazuje, jak zwiększyć odstęp między znakami w **fragmentach tekstu z pogrubioną czcionką**:

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
        // Uwaga: użyj wartości ujemnych, aby zmniejszyć odstęp między znakami.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Wyłączanie kerningu dla konkretnych czcionek**

W niektórych przypadkach tekst renderowany przez Aspose.Slides może wyglądać nieco ściślej niż ten sam tekst wyświetlany w PowerPoint. Może się tak zdarzyć, ponieważ PowerPoint może ignorować dane kerningu dla niektórych czcionek, nawet gdy czcionka zawiera prawidłowe informacje o kerningu i kerning jest włączony w ustawieniach PowerPoint.

Aby w takich sytuacjach uzyskać wynik bardziej zbliżony do PowerPoint, możesz wyłączyć kerning dla fragmentów tekstu używających danej czcionki. Ustaw `KerningMinimalSize` z [IPortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportionformat/) na wartość znacznie większą niż rzeczywisty rozmiar czcionki:

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

Ustawienie to zapobiega stosowaniu kerningu do pasujących fragmentów tekstu i może pomóc w dopasowaniu renderowania Aspose.Slides do wizualnego wyniku PowerPoint dla czcionek dotkniętych tym specyficznym zachowaniem PowerPoint.

## **Zarządzanie właściwościami czcionki tekstu**

Właściwości czcionki można ustawiać na poziomie akapitu poprzez `DefaultPortionFormat` z [IParagraphFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/) lub na poziomie poszczególnych fragmentów poprzez [IPortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportionformat/).

Poniższy kod ustawia czcionkę i styl tekstu dla całego akapitu: stosuje rozmiar czcionki, pogrubienie, kursywę, kropkowaną podkreślenie oraz czcionkę Times New Roman do wszystkich fragmentów w akapicie.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Ustaw właściwości czcionki dla akapitu.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The font properties for the paragraph](font_properties_for_paragraph.png)

Poniższy przykład kodu stosuje podobne właściwości do **fragmentów tekstu z pogrubioną czcionką**:

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
        // Ustaw właściwości czcionki dla fragmentu tekstu.
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Ustawianie obrotu tekstu**

Użyj `TextVerticalType` z [ITextFrameFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframeformat/) aby ustawić predefiniowaną orientację tekstu wewnątrz kształtu.

Poniższy przykład kodu ustawia orientację tekstu w kształcie na `Vertical270`, co obraca tekst **o 90 stopni przeciwnie do ruchu wskazówek zegara**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The text rotation](text_rotation.png)

## **Ustawianie własnego obrotu ramki tekstowej**

Użyj `RotationAngle` z [ITextFrameFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframeformat/) aby ustawić niestandardowy kąt obrotu dla [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/).

Poniższy przykład kodu obraca ramkę tekstową o 3 stopnie zgodnie z ruchem wskazówek zegara w kształcie:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The custom text rotation](custom_text_rotation.png)

## **Ustawianie odstępu między wierszami w akapitach**

Aspose.Slides udostępnia `SpaceAfter`, `SpaceBefore` oraz `SpaceWithin` z [IParagraphFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/) do kontrolowania odstępów między akapitami. Właściwości te stosuje się w następujący sposób:

* Użyj wartości dodatniej, aby określić odstęp jako procent wysokości wiersza.
* Użyj wartości ujemnej, aby określić odstęp w punktach.

Poniższy przykład kodu pokazuje, jak określić odstęp między wierszami w akapicie:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The line spacing within the paragraph](line_spacing.png)

## **Ustawianie typu autofitu dla ramek tekstowych**

`AutofitType` z [ITextFrameFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframeformat/) określa, jak tekst zachowuje się, gdy przekracza granice swojego kontenera. Użyj go, aby kontrolować, czy tekst ma się zmniejszać, przepływać poza obszar czy automatycznie zmieniać rozmiar kształtu.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ustawianie kotwiczenia ramek tekstowych**

`AnchoringType` z [ITextFrameFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframeformat/) definiuje, jak tekst jest pozycjonowany pionowo wewnątrz kształtu, np. u góry, w środku lub na dole.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ustawianie tabulacji tekstu**

Użyj `DefaultTabSize` i `Tabs` z [IParagraphFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/) aby skonfigurować tabulatory w akapicie.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The paragraph tabs](paragraph_tabs.png)

## **Ustawianie języka korekty**

Aspose.Slides udostępnia `LanguageId` z [IPortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportionformat/), który pozwala ustawić język korekty dla fragmentu tekstu. Język korekty określa, w jakim języku mają być przeprowadzane sprawdzanie pisowni i gramatyki w PowerPoint.

Poniższy przykład kodu pokazuje, jak ustawić język korekty dla fragmentu tekstu:

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

// Ustaw Id języka korekty.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ustawianie domyślnego języka**

Użyj `DefaultTextLanguage` z [ILoadOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iloadoptions/) aby zdefiniować domyślny język dla tekstu tworzonego podczas ładowania lub tworzenia prezentacji.

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Dodaj nowy prostokątny kształt z tekstem.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Sprawdź język pierwszego fragmentu.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **Ustawianie domyślnego stylu tekstu**

Aby zastosować domyślne formatowanie tekstu na poziomie prezentacji, użyj `DefaultTextStyle` z [IPresentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/).

Poniższy przykład kodu pokazuje, jak ustawić domyślną pogrubioną czcionkę o rozmiarze 14 pt dla całego tekstu we wszystkich slajdach nowej prezentacji.

```cpp
auto presentation = System::MakeObject<Presentation>();

// Pobierz format akapitu najwyższego poziomu.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Wyodrębnianie tekstu z efektem wielkich liter**

W PowerPoint stosowanie efektu **All Caps** powoduje, że tekst jest wyświetlany wielkimi literami na slajdzie, nawet jeśli został wpisany małymi literami. Gdy pobierasz taki fragment tekstu przy użyciu Aspose.Slides, biblioteka zwraca tekst dokładnie tak, jak został wprowadzony. Aby dopasować go do wyświetlanego tekstu, sprawdź [TextCapType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/textcaptype/) i przekształć zwrócony łańcuch na wielkie litery, gdy wartość to `All`.

Załóżmy, że mamy następującą ramkę tekstową na pierwszym slajdzie pliku sample2.pptx.

![The All Caps effect](all_caps_effect.png)

Poniższy przykład kodu pokazuje, jak wyodrębnić tekst z zastosowanym efektem **All Caps**:

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

Wyjście:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Jak zmodyfikować tekst w tabeli na slajdzie?**

Aby zmodyfikować tekst w tabeli na slajdzie, użyj [ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/). Iteruj przez komórki i aktualizuj każdą komórkę przez `TextFrame` z [ICell](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icell/) oraz formatowanie akapitu przez `ParagraphFormat` z [IParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraph/).

**Jak zastosować gradientowe wypełnienie tekstu w slajdzie PowerPoint?**

Aby zastosować gradientowy kolor do tekstu, użyj `FillFormat` z [IPortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportionformat/). Ustaw `FillType` z [IFillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifillformat/) na `Gradient` i skonfiguruj przystanki gradientu, kierunek oraz przezroczystość.