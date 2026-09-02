---
title: Android에서 PowerPoint 프레젠테이션 텍스트 검색 및 교체
linktitle: 텍스트 검색 및 교체
type: docs
weight: 55
url: /ko/androidjava/search-and-replace-text/
keywords:
- 텍스트 검색
- 텍스트 강조
- 텍스트 교체
- 정규식
- 결과 콜백
- 텍스트 프레임
- 감사 보고서
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Java를 통해 Android용 Aspose.Slides로 PowerPoint 프레젠테이션의 텍스트를 검색, 강조 및 교체하면서 모든 일치를 수집합니다."
---
## **개요**

Aspose.Slides for Android via Java은 개별 텍스트 프레임 또는 전체 프레젠테이션에서 텍스트를 검색, 강조 및 교체할 수 있습니다. 각 작업은 결과 콜백을 통해 일치하는 모든 항목에 대해 애플리케이션에 알릴 수 있습니다. 이를 통해 프레젠테이션을 업데이트하면서 일치한 텍스트, 해당 컨텍스트, 위치, 텍스트 프레임 및 슬라이드 번호를 포함하는 감사 추적을 동시에 생성할 수 있습니다.

이러한 기능은 검토, 민감 정보 삭제, 용어 검사, 템플릿 정리 및 자동 보고 워크플로에 유용합니다.

아래 첫 번째 예제에서는 첫 번째 슬라이드에 단일 텍스트 상자가 포함된 "sample.pptx" 파일을 사용합니다. 해당 텍스트 상자에는 다음 텍스트가 들어 있습니다:

![샘플 텍스트](sample_text.png)

## **검색 범위 선택**

하나의 텍스트 프레임에 작업을 제한하려면 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/)의 메서드를 사용하세요. 프레젠테이션의 모든 적용 가능한 텍스트를 처리하려면 [IPresentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/)의 메서드를 사용하세요.

| 작업 | 단일 텍스트 프레임 | 전체 프레젠테이션 |
|---|---|---|
| 리터럴 텍스트 강조 | [ITextFrame.highlightText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 정규식 일치 강조 | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| 리터럴 텍스트 교체 | [ITextFrame.replaceText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 정규식 일치 교체 | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **텍스트 매칭 구성**

리터럴 텍스트 작업에서는 일치를 제어하기 위해 [TextSearchOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textsearchoptions/)를 사용합니다:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-)는 일치를 전체 단어로만 제한합니다.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-)는 문자 대소문자 일치를 제어합니다.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-)는 슬라이드 노트를 포함합니다.

정규식 작업은 Java `Pattern`을 사용하므로, 대소문자 구분 및 단어 경계와 같은 매칭 규칙은 표현식 및 해당 플래그에 의해 정의됩니다.

## **콜백을 사용한 일치 정보 수집**

[IFindResultCallback](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifindresultcallback/)을 구현하여 모든 일치에 대한 알림을 받습니다. 해당 [IFindResultCallback.foundResult](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) 메서드는 관련 텍스트 프레임, 원본 텍스트, 일치된 텍스트 및 일치 위치를 제공합니다.

콜백은 슬라이드 번호를 직접 받지 못합니다. 아래 구현은 부모 슬라이드에서 번호를 유도하고 슬라이드 노트에 있는 텍스트도 처리합니다. nullable `Integer`를 사용하면 동일한 결과 모델이 다른 슬라이드 유형과 연결된 텍스트를 나타낼 수 있습니다.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

final class TextMatch {
    private final ITextFrame textFrame;
    private final String sourceText;
    private final String foundText;
    private final int textPosition;
    private final Integer slideNumber;

    TextMatch(ITextFrame textFrame, String sourceText, String foundText, int textPosition, Integer slideNumber) {
        this.textFrame = textFrame;
        this.sourceText = sourceText;
        this.foundText = foundText;
        this.textPosition = textPosition;
        this.slideNumber = slideNumber;
    }

    ITextFrame getTextFrame() {
        return textFrame;
    }

    String getSourceText() {
        return sourceText;
    }

    String getFoundText() {
        return foundText;
    }

    int getTextPosition() {
        return textPosition;
    }

    Integer getSlideNumber() {
        return slideNumber;
    }
}

final class TextSearchCallback implements IFindResultCallback {
    private final List<TextMatch> results = new ArrayList<TextMatch>();

    List<TextMatch> getResults() {
        return results;
    }

    @Override
    public void foundResult(ITextFrame textFrame, String sourceText, String foundText, int textPosition) {
        Integer slideNumber = getSlideNumber(textFrame);
        TextMatch result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);
        results.add(result);
    }

    private static Integer getSlideNumber(ITextFrame textFrame) {
        if (!(textFrame instanceof TextFrame)) {
            return null;
        }

        IBaseSlide parentSlide = ((TextFrame) textFrame).getSlide();

        if (parentSlide instanceof ISlide) {
            return ((ISlide) parentSlide).getSlideNumber();
        }

        if (parentSlide instanceof INotesSlide) {
            return ((INotesSlide) parentSlide).getParentSlide().getSlideNumber();
        }

        return null;
    }
}
```

교체 작업의 경우 `foundText`에 원본 일치 텍스트가 포함되므로 콜백에서 정확히 어떤 용어가 교체되었는지 기록할 수 있습니다.

## **텍스트 강조**

[ITextFrame.highlightText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 메서드를 사용하여 텍스트 프레임에서 리터럴 텍스트 일치를 강조합니다. 검색을 제어하기 위해 [TextSearchOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textsearchoptions/)를 전달하고 일치 세부 정보를 수집하기 위해 콜백을 전달합니다.

아래 코드 예제에서는 문자 **"try"**의 모든 발생을 강조한 다음 전체 단어 **"to"**만 강조합니다. 두 검색 모두 동일한 콜백에 일치를 보고합니다.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    int substringHighlightColor = Color.rgb(173, 216, 230);

    // 텍스트 프레임에서 "try"가 나타나는 모든 위치를 강조합니다.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // 전체 단어 "to"만 강조합니다.
    shape.getTextFrame().highlightText("to", wholeWordHighlightColor, wholeWordSearchOptions, callback);

    for (TextMatch result : callback.getResults()) {
        System.out.println("Found '" + result.getFoundText() + "' at position " +
                result.getTextPosition() + " on slide " + result.getSlideNumber() + ".");
    }

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![강조된 텍스트](highlighted_text.png)

## **정규식을 사용한 텍스트 강조**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) 메서드는 텍스트 프레임에서 정규식으로 찾은 텍스트 일치를 강조합니다.

다음 코드는 7자 이상인 모든 단어를 강조하고 각 일치를 수집합니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    Pattern regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![정규식을 사용한 강조된 텍스트](highlighted_text_using_regex.png)

## **프레젠테이션 전체 텍스트 강조**

[IPresentation.highlightText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)와 [IPresentation.highlightRegex](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-)를 사용하여 프레젠테이션의 모든 적용 가능한 텍스트 프레임을 검색합니다. 다음 예제는 리터럴 용어와 모든 이메일 주소를 강조하면서 두 검색에 대한 별도의 결과 컬렉션을 유지합니다.

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    int termHighlightColor = Color.rgb(255, 165, 0);
    presentation.highlightText("confidential", termHighlightColor, searchOptions, termCallback);

    TextSearchCallback emailCallback = new TextSearchCallback();
    Pattern emailRegex = Pattern.compile(
            "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
            Pattern.CASE_INSENSITIVE);

    presentation.highlightRegex(emailRegex, Color.YELLOW, emailCallback);
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **텍스트 프레임에서 텍스트 교체**

리터럴 텍스트 교체에는 [ITextFrame.replaceText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)를, 패턴 기반 교체에는 [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)를 사용합니다. 이러한 메서드는 기존 텍스트 프레임 내의 일치 텍스트를 업데이트하며, 전체 문자열에서 텍스트 프레임을 재구성하는 대신 주변 부분 서식을 유지합니다.

다음 예제는 철자 변형을 표준화한 뒤 버전 라벨을 교체합니다. 동일한 콜백이 두 작업에서 일치한 원본 용어를 기록합니다.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText("colour", "color", searchOptions, callback);

    Pattern versionRegex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", callback);

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

일치가 서로 다른 서식의 부분에 걸쳐 있는 경우, 교체 텍스트에 적용할 서식을 확인하기 위해 출력물을 검토하십시오.

## **프레젠테이션 전체 텍스트 교체**

[IPresentation.replaceText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)와 [IPresentation.replaceRegex](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)를 사용하여 프레젠테이션 전체에 동일한 작업을 적용합니다. 이는 템플릿 정리, 용어 업데이트 및 민감 정보 삭제에 유용합니다.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText("Contoso", "Example Corp", searchOptions, callback);

    Pattern accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **보고를 위한 일치 그룹화**

각 결과가 슬라이드 번호와 텍스트 프레임을 저장하므로 애플리케이션은 감사, 보고 또는 검토 워크플로를 위해 일치를 그룹화할 수 있습니다. 다음 예제는 수집된 결과를 먼저 슬라이드별로, 그 다음 텍스트 프레임별로 그룹화합니다:

```java
import com.aspose.slides.ITextFrame;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

Map<Integer, Map<ITextFrame, List<TextMatch>>> matchesBySlide =
        new LinkedHashMap<Integer, Map<ITextFrame, List<TextMatch>>>();

for (TextMatch result : callback.getResults()) {
    Integer slideNumber = result.getSlideNumber();
    Map<ITextFrame, List<TextMatch>> matchesByTextFrame = matchesBySlide.get(slideNumber);

    if (matchesByTextFrame == null) {
        matchesByTextFrame = new LinkedHashMap<ITextFrame, List<TextMatch>>();
        matchesBySlide.put(slideNumber, matchesByTextFrame);
    }

    ITextFrame textFrame = result.getTextFrame();
    List<TextMatch> textFrameMatches = matchesByTextFrame.get(textFrame);

    if (textFrameMatches == null) {
        textFrameMatches = new java.util.ArrayList<TextMatch>();
        matchesByTextFrame.put(textFrame, textFrameMatches);
    }

    textFrameMatches.add(result);
}

for (Map.Entry<Integer, Map<ITextFrame, List<TextMatch>>> slideEntry : matchesBySlide.entrySet()) {
    String slideLabel = slideEntry.getKey() == null ? "Other" : slideEntry.getKey().toString();
    System.out.println("Slide: " + slideLabel);

    for (Map.Entry<ITextFrame, List<TextMatch>> textFrameEntry : slideEntry.getValue().entrySet()) {
        System.out.println("  Text frame: " + textFrameEntry.getKey().getText());

        for (TextMatch result : textFrameEntry.getValue()) {
            System.out.println("    '" + result.getFoundText() + "' at position " +
                    result.getTextPosition() + "; context: '" + result.getSourceText() + "'");
        }
    }
}
```

## **FAQ**

**전체 프레젠테이션이 아니라 하나의 텍스트 상자만 검색하려면 어떻게 해야 하나요?**

쉐이프의 텍스트 프레임을 가져와 해당 텍스트 프레임에 대해 [ITextFrame.highlightText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), 또는 [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)를 호출합니다. 프레젠테이션 수준 메서드는 모든 적용 가능한 텍스트 프레임을 처리합니다.

**정확한 대소문자를 사용하여 전체 단어와 일치시키려면 어떻게 해야 하나요?**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-)와 [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-)를 `true`로 설정하고 옵션을 리터럴 텍스트 강조 또는 교체 메서드에 전달합니다. 정규식의 경우 Java `Pattern` 자체에서 단어 경계와 대소문자 구분을 정의합니다.

**검색 및 교체에 슬라이드 노트의 텍스트도 포함될 수 있나요?**

예. 프레젠테이션 수준 리터럴 텍스트 작업을 사용할 때 [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-)를 `true`로 설정합니다. 위에 표시된 콜백 구현은 노트 슬라이드의 일치를 부모 슬라이드 번호로 매핑합니다.

**프레젠테이션을 두 번 스캔하지 않고 보고서를 생성하려면 어떻게 해야 하나요?**

[IFindResultCallback](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifindresultcallback/) 구현을 강조 또는 교체 작업에 전달합니다. 콜백은 작업 실행 중에 모든 일치를 받으므로 애플리케이션은 원본 텍스트, 일치 텍스트, 위치, 텍스트 프레임 및 파생된 슬라이드 번호를 저장하여 나중에 그룹화하거나 내보낼 수 있습니다.

**텍스트 교체 시 서식이 유지되나요?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)와 [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)는 기존 텍스트 프레임 내의 일치 텍스트를 수정하고 주변 부분 서식을 유지합니다. 일치가 서로 다른 서식의 부분에 걸쳐 있는 경우, 교체가 원하는 스타일을 사용하도록 결과를 검사하십시오.