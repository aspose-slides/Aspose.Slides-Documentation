---
title: PHP에서 프레젠테이션 텍스트 서식 지정
linktitle: 텍스트 서식 지정
type: docs
weight: 50
url: /ko/php-java/text-formatting/
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
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트를 형식화하고 스타일을 지정합니다. 글꼴, 색상, 정렬 등을 사용자 지정할 수 있습니다."
---
## **개요**

이 문서에서는 Aspose.Slides for PHP via Java을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트를 서식 지정하는 방법을 보여줍니다. 강조 표시, 배경 색상, 투명도, 문자 간격, 글꼴 속성, 회전, 단락 간격, 자동 맞춤 동작, 텍스트 고정, 탭 정지 및 언어 설정을 다룹니다.

아래 예제에서는 첫 번째 슬라이드에 단일 텍스트 상자가 포함된 "sample.pptx" 파일을 사용합니다.

![Sample text](sample_text.png)

## **텍스트 강조**

특정 샘플과 일치하는 텍스트를 강조해야 할 때 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)`::highlightText` 메서드를 사용합니다. 이 메서드는 일치하는 텍스트 조각에 강조 색을 적용하며, 전체 단어만 일치하도록 하려면 [TextHighlightingOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/texthighlightingoptions/)와 함께 사용할 수 있습니다.

다음 코드 예제는 문자 **"try"**의 모든 발생을 강조한 후, 전체 단어 **"to"**만 강조합니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    // 첫 번째 슬라이드에서 첫 번째 도형을 가져옵니다.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lightBlue = new Java("java.awt.Color", 173, 216, 230);
    $violet = new Java("java.awt.Color", 238, 130, 238);

    // 도형에서 "try" 단어를 강조합니다.
    $shape->getTextFrame()->highlightText("try", $lightBlue);

    $searchOptions = new TextHighlightingOptions();
    $searchOptions->setWholeWordsOnly(true);

    // 도형에서 "to" 단어를 강조합니다.
    $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![The highlighted text](highlighted_text.png)

## **정규식을 사용한 텍스트 강조**

[TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)`::highlightRegex` 메서드는 정규식으로 찾은 텍스트 일치를 강조합니다.

다음 코드 예제는 **길이가 7자 이상인** 모든 단어를 강조합니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // 길이가 7자 이상인 모든 단어를 강조합니다.
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **텍스트 배경 색상 설정**

단락의 기본 강조 색을 설정하려면 [ParagraphFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/)'s 기본 PortionFormat을 사용하고, 개별 텍스트 Portion에 대해서는 [PortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portionformat/)을 사용합니다.

다음 코드 예제는 **전체 단락**의 배경 색을 설정하는 방법을 보여줍니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 전체 단락에 대한 강조 색상을 설정합니다.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![The gray paragraph](gray_paragraph.png)

다음 코드 예제는 **굵은 글꼴을 가진 텍스트 Portion**에 배경 색을 설정하는 방법을 보여줍니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 텍스트 Portion에 대한 강조 색상을 설정합니다.
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![The gray text portions](gray_text_portions.png)

## **텍스트 단락 정렬**

[ParagraphFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/)`::setAlignment` 메서드를 사용하여 텍스트 상자 내 단락 정렬을 설정합니다. 값으로는 가운데, 왼쪽 정렬, 오른쪽 정렬, 양쪽 맞춤 등을 지정할 수 있습니다.

다음 코드 예제는 단락을 **가운데** 정렬하는 방법을 보여줍니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 단락의 정렬을 가운데로 설정합니다.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![The aligned paragraph](aligned_paragraph.png)

## **텍스트 투명도 설정**

텍스트 투명도는 [PortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portionformat/)'s fill format에 지정된 색상의 알파 구성 요소를 통해 제어됩니다. 아래 예제에서 `alpha = 50` 은 0‑255 범위의 ARGB 알파값이며, 투명도 백분율이 아닙니다.

다음 코드 예제는 **전체 단락**에 투명도를 적용하는 방법을 보여줍니다.

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // 텍스트의 채우기 색상을 투명 색으로 설정합니다.
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![The transparent paragraph](transparent_paragraph.png)

다음 코드 예제는 **굵은 글꼴을 가진 텍스트 Portion**에 투명도를 적용하는 방법을 보여줍니다.

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 텍스트 Portion의 투명도를 설정합니다.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![The transparent text portions](transparent_text_portions.png)

## **텍스트 문자 간격 설정**

[BasePortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/)`::setSpacing` 메서드를 사용하면 텍스트 상자 내 문자 간격을 확대하거나 축소할 수 있습니다.

다음 PHP 코드는 **전체 단락**의 문자 간격을 확대하는 방법을 보여줍니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 참고: 문자 간격을 압축하려면 음수 값을 사용합니다.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // 문자 간격을 확대합니다.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

다음 코드 예제는 **굵은 글꼴을 가진 텍스트 Portion**의 문자 간격을 확대하는 방법을 보여줍니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 참고: 문자 간격을 압축하려면 음수 값을 사용합니다.
            $portion->getPortionFormat()->setSpacing(3); // 문자 간격을 확대합니다.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **특정 글꼴에 대한 커닝 비활성화**

일부 경우 Aspose.Slides에서 렌더링된 텍스트가 PowerPoint에서 표시되는 텍스트보다 약간 더 촘촘해 보일 수 있습니다. 이는 PowerPoint가 특정 글꼴에 대해 커닝 데이터를 무시하기 때문이며, 글꼴에 유효한 커닝 정보가 있어도 설정에서 커닝이 활성화되어 있어도 발생합니다.

이러한 경우 렌더링 결과를 PowerPoint와 가깝게 만들려면 해당 글꼴을 사용하는 텍스트 Portion에 대해 커닝을 비활성화할 수 있습니다. [BasePortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/)`::setKerningMinimalSize` 메서드를 실제 글꼴 크기보다 크게 설정합니다.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

이 설정은 일치하는 텍스트 Portion에 커닝 적용을 방지하고, PowerPoint 특유의 동작에 영향을 받는 글꼴에 대해 Aspose.Slides 렌더링을 PowerPoint 시각 출력과 맞추는 데 도움이 됩니다.

## **텍스트 글꼴 속성 관리**

글꼴 속성은 [ParagraphFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/)'s 기본 PortionFormat을 통해 단락 수준에서 설정하거나, 개별 Portion에 대해 [PortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portionformat/)을 통해 설정할 수 있습니다.

다음 코드는 전체 단락에 대해 글꼴 크기, 굵게, 기울임꼴, 점선 밑줄 및 Times New Roman 글꼴을 적용합니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // 단락에 대한 글꼴 속성을 설정합니다.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont(new FontData("Times New Roman"));

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![The font properties for the paragraph](font_properties_for_paragraph.png)

다음 코드 예제는 **굵은 글꼴을 가진 텍스트 Portion**에 유사한 속성을 적용합니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 텍스트 Portion에 대한 글꼴 속성을 설정합니다.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont(new FontData("Times New Roman"));
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![The font properties for text portions](font_properties_for_text_portions.png)

## **텍스트 회전 설정**

[TextFrameFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/)`::setTextVerticalType` 메서드를 사용하여 도형 내 미리 정의된 텍스트 방향을 설정합니다.

다음 코드 예제는 텍스트 방향을 `Vertical270`으로 설정하여 텍스트를 **시계 반대 방향으로 90도** 회전시킵니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![The text rotation](text_rotation.png)

## **텍스트 상자에 대한 사용자 정의 회전 설정**

[TextFrameFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/)`::setRotationAngle` 메서드를 사용하여 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)에 대한 사용자 정의 회전 각도를 지정합니다.

다음 코드 예제는 도형 내 텍스트 프레임을 시계 방향으로 3도 회전시킵니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![The custom text rotation](custom_text_rotation.png)

## **단락의 줄 간격 설정**

Aspose.Slides는 [ParagraphFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`, `ParagraphFormat::setSpaceBefore` 및 `ParagraphFormat::setSpaceWithin` 메서드를 제공하여 단락 간격을 제어합니다. 사용 방법은 다음과 같습니다.

* 양수 값을 사용하면 줄 높이의 백분율로 줄 간격을 지정합니다.
* 음수 값을 사용하면 포인트 단위의 줄 간격을 지정합니다.

다음 코드 예제는 단락 내 줄 간격을 지정하는 방법을 보여줍니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![The line spacing within the paragraph](line_spacing.png)

## **텍스트 상자에 대한 자동 맞춤 유형 설정**

[TextFrameFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/)`::setAutofitType` 메서드는 텍스트가 컨테이너 경계를 초과할 때의 동작을 결정합니다. 텍스트가 축소, 넘침, 또는 도형이 자동으로 크기 조정되는지를 제어합니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **텍스트 상자 고정점 설정**

[TextFrameFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/)`::setAnchoringType` 메서드는 텍스트가 도형 내부에서 수직으로 어디에 배치될지를 정의합니다(예: 위쪽, 가운데, 아래쪽).

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **텍스트 탭 설정**

[ParagraphFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize` 메서드와 해당 탭 컬렉션을 사용하여 단락의 탭 정지를 구성합니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![The paragraph tabs](paragraph_tabs.png)

## **교정 언어 설정**

Aspose.Slides는 [BasePortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/)`::setLanguageId` 메서드를 제공하여 텍스트 Portion의 교정 언어를 설정할 수 있게 합니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사를 수행할 언어를 결정합니다.

다음 코드 예제는 텍스트 Portion에 교정 언어를 설정하는 방법을 보여줍니다.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // 교정 언어의 ID를 설정합니다.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **기본 언어 설정**

[LoadOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage` 메서드를 사용하여 프레젠테이션을 로드하거나 생성할 때 텍스트의 기본 언어를 정의합니다.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 텍스트가 있는 새로운 사각형 도형을 추가합니다.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // 첫 번째 Portion의 언어를 확인합니다.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **기본 텍스트 스타일 설정**

프레젠테이션 수준에서 기본 텍스트 서식을 적용하려면 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/)'s 기본 텍스트 스타일을 사용합니다.

다음 코드 예제는 새 프레젠테이션의 모든 슬라이드에 대해 14pt 크기의 굵은 기본 글꼴을 설정하는 방법을 보여줍니다.

```php
$presentation = new Presentation();
try {
    // 최상위 레벨 단락 형식을 가져옵니다.
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **All‑Caps 효과가 적용된 텍스트 추출**

PowerPoint에서 **All Caps** 글꼴 효과를 적용하면 원래 소문자로 입력된 텍스트라도 슬라이드에 대문자로 표시됩니다. Aspose.Slides를 사용해 해당 텍스트 Portion을 가져오면 라이브러리는 입력된 그대로의 텍스트를 반환합니다. 표시된 텍스트와 일치시키려면 [TextCapType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textcaptype/)을 확인하고 값이 `All`인 경우 반환된 문자열을 대문자로 변환합니다.

다음은 sample2.pptx 파일 첫 번째 슬라이드에 있는 텍스트 상자를 예시로 든 것입니다.

![The All Caps effect](all_caps_effect.png)

다음 코드 예제는 **All Caps** 효과가 적용된 텍스트를 추출하는 방법을 보여줍니다.

```php
$presentation = new Presentation("sample2.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($textPortion->getText());
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

출력:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**슬라이드의 표에서 텍스트를 어떻게 수정합니까?**

슬라이드의 표 텍스트를 수정하려면 [Table](https://reference.aspose.com/slides/ko/php-java/aspose.slides/table/)를 사용합니다. 셀을 순회하며 각 셀의 [Cell](https://reference.aspose.com/slides/ko/php-java/aspose.slides/cell/) 텍스트 프레임과 [Paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/)의 단락 형식을 통해 텍스트를 업데이트합니다.

**PowerPoint 슬라이드의 텍스트에 그라데이션 색상을 어떻게 적용합니까?**

그라데이션 색상을 적용하려면 [PortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portionformat/)'s fill format을 사용합니다. [FillFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/)'s fill type을 [FillType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/filltype/) `Gradient`로 설정하고 그라데이션 정지점, 방향 및 투명도를 구성합니다.