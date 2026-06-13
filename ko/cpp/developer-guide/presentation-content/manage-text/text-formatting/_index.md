---
title: C++에서 프레젠테이션 텍스트 형식 지정
linktitle: 텍스트 서식
type: docs
weight: 50
url: /ko/cpp/text-formatting/
keywords:
- 텍스트 강조
- 정규식
- 단락 정렬
- 텍스트 스타일
- 텍스트 배경
- 텍스트 투명도
- 문자 간격
- 글꼴 속성
- 글꼴 패밀리
- 텍스트 회전
- 회전 각도
- 텍스트 프레임
- 줄 간격
- 자동 맞춤 속성
- 텍스트 프레임 고정점
- 텍스트 탭
- 기본 언어
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트를 형식화하고 스타일을 지정합니다. 글꼴, 색상, 정렬 등을 사용자 지정합니다."
---
## **개요**

이 문서는 Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 서식 지정하는 방법을 보여줍니다. 강조 표시, 배경 색, 투명도, 문자 간격, 글꼴 속성, 회전, 단락 간격, 자동 맞춤 동작, 텍스트 고정, 탭 정지 및 언어 설정을 다룹니다.

아래 예제에서는 첫 번째 슬라이드에 단일 텍스트 상자가 포함된 "sample.pptx" 파일을 사용합니다.

![샘플 텍스트](sample_text.png)

## **텍스트 강조**

특정 샘플에 일치하는 텍스트를 강조해야 할 때 [ITextFrame.HighlightText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/highlighttext/) 메서드를 사용합니다. 이 메서드는 일치하는 텍스트 조각에 강조 색을 적용하며, 전체 단어만 일치하도록 검색 방식을 제어하려면 [ITextSearchOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextsearchoptions/)와 함께 사용할 수 있습니다.

다음 코드 예제는 **"try"** 문자를 모두 강조한 다음 전체 단어 **"to"**만 강조합니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// 첫 번째 슬라이드에서 첫 번째 도형을 가져옵니다.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// 도형에서 "try" 단어를 강조합니다.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// 도형에서 "to" 단어를 강조합니다.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![강조된 텍스트](highlighted_text.png)

## **정규식으로 텍스트 강조**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/highlightregex/) 메서드는 정규식으로 찾은 텍스트 일치를 강조합니다. C++에서는 이 API가 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/)에 노출됩니다.

다음 코드 예제는 **7자 이상**인 모든 단어를 강조합니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Highlight all words with seven or more characters.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![정규식으로 강조된 텍스트](highlighted_text_using_regex.png)

## **텍스트 배경 색 설정**

문단의 기본 강조 색을 설정하려면 [IParagraphFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat`을 사용하고, 개별 텍스트 부분에 대해서는 [IPortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportionformat/)`.HighlightColor`를 사용합니다.

다음 코드 예제는 **전체 문단**의 배경 색을 설정하는 방법을 보여줍니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Set the highlight color for the entire paragraph.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![회색 문단](gray_paragraph.png)

다음 코드 예제는 **굵은 글꼴 텍스트 부분**의 배경 색을 설정하는 방법을 보여줍니다.

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
        // 텍스트 부분에 강조 색을 설정합니다.
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![회색 텍스트 부분](gray_text_portions.png)

## **텍스트 단락 정렬**

텍스트 프레임 내에서 단락 정렬을 설정하려면 [IParagraphFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/)`.Alignment`를 사용합니다. 값은 중앙, 왼쪽, 오른쪽, 양쪽 맞춤 등으로 지정할 수 있습니다.

다음 코드 예제는 단락을 **중앙**에 정렬하는 방법을 보여줍니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// 단락 정렬을 가운데로 설정합니다.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![정렬된 단락](aligned_paragraph.png)

## **텍스트 투명도 설정**

텍스트 투명도는 [IPortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportionformat/)`.FillFormat`.의 색상 알파 구성 요소를 통해 제어합니다. 아래 예제에서 `alpha = 50`은 0-255 스케일의 ARGB 알파 채널 값이며, 투명도 백분율이 아닙니다.

다음 코드 예제는 **전체 문단**에 투명도를 적용하는 방법을 보여줍니다.

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// 텍스트의 채우기 색을 투명 색으로 설정합니다.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![투명한 문단](transparent_paragraph.png)

다음 코드 예제는 **굵은 글꼴 텍스트 부분**에 투명도를 적용하는 방법을 보여줍니다.

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
        // 텍스트 부분의 투명도를 설정합니다.
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![투명한 텍스트 부분](transparent_text_portions.png)

## **텍스트 문자 간격 설정**

텍스트 상자에서 문자 간격을 늘리거나 줄이려면 [IBasePortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseportionformat/)`.Spacing`을 사용합니다.

다음 C++ 코드는 **전체 문단**의 문자 간격을 확장하는 방법을 보여줍니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// 참고: 문자 간격을 압축하려면 음수 값을 사용합니다.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![문단의 문자 간격](character_spacing_in_paragraph.png)

다음 코드 예제는 **굵은 글꼴 텍스트 부분**의 문자 간격을 확장하는 방법을 보여줍니다.

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
        // 참고: 문자 간격을 압축하려면 음수 값을 사용합니다.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![텍스트 부분의 문자 간격](character_spacing_in_text_portions.png)

### **특정 글꼴에 대한 커닝 비활성화**

일부 경우 Aspose.Slides가 렌더링한 텍스트가 PowerPoint에서 표시되는 텍스트보다 약간 더 촘촘하게 보일 수 있습니다. 이는 PowerPoint가 특정 글꼴에 대한 커닝 데이터를 무시하기 때문이며, 해당 글꼴이 유효한 커닝 정보를 포함하고 PowerPoint 설정에서 커닝이 활성화되어 있어도 발생할 수 있습니다.

이러한 경우 렌더링 결과를 PowerPoint와 더 가깝게 만들려면 영향을 받는 글꼴을 사용하는 텍스트 부분에 대해 커닝을 비활성화할 수 있습니다. [IPortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize`를 실제 글꼴 크기보다 훨씬 크게 설정합니다.

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

이 설정은 일치하는 텍스트 부분에 커닝이 적용되지 않도록 방지하며, 해당 PowerPoint 전용 동작에 영향을 받는 글꼴에 대해 Aspose.Slides 렌더링을 PowerPoint 시각 출력과 맞추는 데 도움이 될 수 있습니다.

## **텍스트 글꼴 속성 관리**

글꼴 속성은 [IParagraphFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat`을 통해 단락 수준에서 설정하거나, [IPortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportionformat/)`.`를 통해 개별 부분에 설정할 수 있습니다.

다음 코드는 전체 문단에 대한 글꼴 및 텍스트 스타일을 설정합니다. 여기서는 글꼴 크기, 굵게, 기울임꼴, 점선 밑줄 및 Times New Roman 글꼴을 모든 부분에 적용합니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// 단락에 대한 글꼴 속성을 설정합니다.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![문단의 글꼴 속성](font_properties_for_paragraph.png)

다음 코드 예제는 **굵은 글꼴 텍스트 부분**에 유사한 속성을 적용합니다.

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
        // 텍스트 부분에 대한 글꼴 속성을 설정합니다.
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![텍스트 부분의 글꼴 속성](font_properties_for_text_portions.png)

## **텍스트 회전 설정**

[ITextFrameFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframeformat/)`.TextVerticalType`을 사용하면 도형 내에서 미리 정의된 텍스트 방향을 설정할 수 있습니다.

다음 코드 예제는 도형 내 텍스트 방향을 `Vertical270`으로 설정하여 텍스트를 **시계 반대 방향으로 90도** 회전시킵니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![텍스트 회전](text_rotation.png)

## **텍스트 프레임에 대한 사용자 지정 회전 설정**

[ITextFrameFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframeformat/)`.RotationAngle`을 사용하면 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/)에 대한 사용자 지정 회전 각도를 설정할 수 있습니다.

다음 코드 예제는 도형 내 텍스트 프레임을 시계 방향으로 3도 회전시킵니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![사용자 지정 텍스트 회전](custom_text_rotation.png)

## **단락 줄 간격 설정**

Aspose.Slides는 [IParagraphFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`, `IParagraphFormat.SpaceBefore` 및 `IParagraphFormat.SpaceWithin`을 제공하여 단락 간격을 제어합니다. 이 속성들은 다음과 같이 사용됩니다:

* 양수 값을 사용하면 줄 간격을 줄 높이의 백분율로 지정합니다.
* 음수 값을 사용하면 줄 간격을 포인트 단위로 지정합니다.

다음 코드 예제는 단락 내 줄 간격을 지정하는 방법을 보여줍니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![단락 내 줄 간격](line_spacing.png)

## **텍스트 프레임 자동 맞춤 유형 설정**

[ITextFrameFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframeformat/)`.AutofitType`은 텍스트가 컨테이너 경계를 초과할 때 동작 방식을 결정합니다. 텍스트가 축소, 넘침, 또는 도형이 자동으로 크기 조정되는지를 제어할 수 있습니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **텍스트 프레임 고정점 설정**

[ITextFrameFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframeformat/)`.AnchoringType`은 텍스트가 도형 내부에서 수직으로 위치하는 방식을 정의합니다(예: 상단, 가운데, 하단).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **텍스트 탭 설정**

[IParagraphFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize`와 `IParagraphFormat.Tabs`를 사용하여 단락 내 탭 정지를 구성합니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![단락 탭](paragraph_tabs.png)

## **맞춤법 검사 언어 설정**

Aspose.Slides는 [IPortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportionformat/)`.LanguageId`를 제공하여 텍스트 부분에 대한 맞춤법 검사 언어를 설정할 수 있습니다. 맞춤법 검사 언어는 PowerPoint에서 철자 및 문법 검사를 수행할 때 사용되는 언어를 결정합니다.

다음 코드 예제는 텍스트 부분에 맞춤법 검사 언어를 설정하는 방법을 보여줍니다.

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

// 맞춤법 검사 언어의 Id를 설정합니다.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **기본 언어 설정**

[ILoadOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage`를 사용하면 프레젠테이션을 로드하거나 생성하면서 만든 텍스트의 기본 언어를 정의할 수 있습니다.

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Add a new rectangle shape with text.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Check the first portion language.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **기본 텍스트 스타일 설정**

프레젠테이션 수준에서 기본 텍스트 서식을 적용하려면 [IPresentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle`를 사용합니다.

다음 코드 예제는 새 프레젠테이션의 모든 슬라이드에 대해 14pt 크기의 굵은 기본 글꼴을 설정하는 방법을 보여줍니다.

```cpp
auto presentation = System::MakeObject<Presentation>();

// 최상위 수준 단락 형식을 가져옵니다.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **All-Caps 효과가 적용된 텍스트 추출**

PowerPoint에서 **All Caps** 글꼴 효과를 적용하면 슬라이드에 표시될 때 텍스트가 대문자로 보이지만, 원본 텍스트는 소문자로 입력될 수 있습니다. Aspose.Slides로 해당 텍스트 부분을 검색하면 라이브러리는 입력된 그대로 반환합니다. 표시된 텍스트와 일치시키려면 [TextCapType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/textcaptype/)을 확인하고 값이 `All`일 때 반환된 문자열을 대문자로 변환합니다.

예를 들어 sample2.pptx 파일의 첫 번째 슬라이드에 다음 텍스트 상자가 있다고 가정합니다.

![All Caps 효과](all_caps_effect.png)

다음 코드 예제는 **All Caps** 효과가 적용된 텍스트를 추출하는 방법을 보여줍니다.

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

출력:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**슬라이드의 표에서 텍스트를 어떻게 수정합니까?**

표의 텍스트를 수정하려면 [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/)를 사용합니다. 셀을 순회하면서 각 셀을 [ICell](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icell/)`.TextFrame` 및 [IParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/)`.ParagraphFormat`을 통해 단락 서식을 업데이트합니다.

**PowerPoint 슬라이드에서 텍스트에 그라디언트 색을 어떻게 적용합니까?**

그라디언트 색을 적용하려면 [IPortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportionformat/)`.FillFormat`를 사용합니다. [IFillFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifillformat/)`.FillType`을 [FillType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/filltype/)`.Gradient`으로 설정하고 그라디언트 정지점, 방향 및 투명도를 구성합니다.