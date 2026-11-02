---
title: PHP에서 프레젠테이션 하이퍼링크 관리
linktitle: 하이퍼링크 관리
type: docs
weight: 20
url: /ko/php-java/manage-hyperlinks/
keywords:
- URL 추가
- 하이퍼링크 추가
- 하이퍼링크 생성
- 하이퍼링크 서식 지정
- 하이퍼링크 제거
- 하이퍼링크 업데이트
- 텍스트 하이퍼링크
- 슬라이드 하이퍼링크
- 도형 하이퍼링크
- 이미지 하이퍼링크
- 비디오 하이퍼링크
- 가변 하이퍼링크
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PHP 예제로 PowerPoint 및 OpenDocument 프레젠테이션에서 하이퍼링크를 추가, 서식 지정, 업데이트 및 제거합니다."
---
## **소개**

하이퍼링크는 프레젠테이션 콘텐츠를 웹사이트나 프레젠테이션 내 위치에 연결합니다. PowerPoint에서 하이퍼링크는 일반적으로 두 가지 용도로 사용됩니다:

* 텍스트, 도형 또는 미디어 프레임에서 웹사이트를 엽니다.
* 예를 들어 목차에서 다른 슬라이드로 이동합니다.

Aspose.Slides for PHP via Java는 이러한 링크를 추가하고, 모양과 사운드를 제어하고, 속성을 업데이트하며, 제거할 수 있게 해줍니다. 아래 예제는 개별 요소에서 하이퍼링크를 작업하는 방법과 프레젠테이션, 슬라이드, 텍스트 프레임 수준에서 하이퍼링크에 접근하는 방법을 보여줍니다. PHP/Java Bridge와 Aspose.Slides PHP 래퍼가 초기화되어 있다고 가정합니다. PHP 참조 페이지 링크가 없는 API 멤버는 기본 Java API를 가리킵니다.

{{% alert color="info" title="Note" %}}
무료 온라인 [Aspose PowerPoint 편집기](https://products.aspose.app/slides/editor)로 프레젠테이션을 편집할 수도 있습니다.
{{% /alert %}} 

## **URL 하이퍼링크 추가**

텍스트, 도형 또는 미디어 프레임에 웹사이트 URL을 할당할 수 있습니다. 하이퍼링크를 할당하는 요소에 따라 클릭 가능한 영역이 결정됩니다. 텍스트 부분에 할당하면 선택한 텍스트만 클릭 가능하고, 도형이나 프레임에 할당하면 슬라이드 개체 전체가 클릭 가능하게 됩니다.

프레젠테이션에 상대 하이퍼링크가 포함된 경우, 문서 수준 기본값을 읽고, 변경하고, 지우려면 [하이퍼링크 기본값 관리](/slides/ko/php-java/presentation-properties/#manage-the-hyperlink-base)를 참조하십시오.

### **텍스트에 URL 하이퍼링크 추가**

텍스트를 웹사이트에 연결하려면 텍스트 부분의 [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) 메서드에 [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/)을 전달합니다. 아래와 같이 하면 해당 텍스트 부분만 클릭 가능해집니다.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **도형 및 미디어 프레임에 URL 하이퍼링크 추가**

도형이나 프레임을 클릭 가능하게 만들려면 해당 객체의 [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/) 메서드를 호출합니다. 하이퍼링크는 텍스트 부분이 아니라 객체 자체에 속합니다.

그림, 오디오, 비디오 프레임에도 동일한 접근 방식을 적용합니다. 프레임에 하이퍼링크를 할당하고 필요하면 [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/)을 호출합니다.

아래 예제는 사각형을 클릭 가능하게 만듭니다:

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **목차 만들기에 하이퍼링크 사용**

내부 하이퍼링크를 사용하면 독자가 목차에서 특정 슬라이드로 이동할 수 있습니다. 아래 예제는 첫 슬라이드의 “Page 2” 텍스트를 두 번째 슬라이드에 연결하기 위해 [setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/)을 사용합니다.

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **하이퍼링크 서식 지정**

### **색상**

[Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/)의 [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) 메서드는 하이퍼링크가 프레젠테이션의 하이퍼링크 색상을 사용할지 텍스트 부분의 서식을 사용할지를 결정합니다. 사용자 지정 텍스트 색상을 적용하려면 [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/)을 선택하고 부분의 채우기 색을 설정합니다. 이 기능은 PowerPoint 2019에서 도입되었으며, 이전 버전에서는 적용되지 않습니다.

아래 예제는 같은 슬라이드에 두 개의 텍스트 하이퍼링크를 추가합니다. 첫 번째는 빨간색 텍스트 채우기를 사용하고, 두 번째는 기본 하이퍼링크 색상을 유지합니다.

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **소리**

하이퍼링크를 활성화하면 소리를 재생하거나 이미 재생 중인 소리를 중지시킬 수 있습니다. 다음 메서드를 사용해 동작을 구성합니다:

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) – 하이퍼링크와 연결된 오디오를 지정합니다.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) – 하이퍼링크를 활성화할 때 이전 소리를 중지할지 여부를 제어합니다.

#### **하이퍼링크 소리 추가**

아래 예제는 `sampleaudio.wav` 파일을 로드하고 첫 슬라이드의 버튼에 연결합니다. 버튼을 클릭하면 소리가 재생되고 다음 슬라이드로 이동합니다. 동일 슬라이드의 두 번째 도형은 클릭 시 이전 소리를 중지하고 탐색 동작을 수행하지 않습니다.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **하이퍼링크 소리 추출**

아래 예제는 앞서 만든 프레젠테이션을 열고 첫 번째 도형의 하이퍼링크 오디오를 [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/)과 [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/)을 통해 메모리로 읽어옵니다.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **툴팁 및 인터랙션 설정**

텍스트나 도형에 하이퍼링크를 할당한 후 다음 [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) 메서드를 호출할 수 있습니다:

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) – 사용자가 링크에 대한 힌트로 표시할 텍스트를 설정합니다.
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) – 해당되는 경우 상위 HTML 프레임셋 내의 대상 프레임을 지정합니다.
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) – 링크를 활성화했을 때 대상이 조회된 하이퍼링크 목록에 추가될지 여부를 제어합니다.
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) – 클릭 시 하이퍼링크가 강조 표시될지 여부를 제어합니다.

## **프레젠테이션에서 하이퍼링크 제거**

[getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)를 사용해 텍스트 부분 링크를 포함한 하이퍼링크 컨테이너를 수집한 후 변경합니다. 아래 예제는 첫 슬라이드에서 두 가지 활성화 유형을 모두 제거합니다. 하나만 제거하려면 [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) 또는 [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/)만 호출하면 됩니다. 클릭 동작을 제거해도 마우스오버 동작은 남습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

조건 없이 모두 제거하려면 [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)를 사용해 선택된 범위에서 두 활성화 유형을 한 번에 제거합니다. 마스터, 레이아웃, 노트 등을 포함한 선택적 정리를 원하면 [하이퍼링크 보고, 정리 및 검증](#report-sanitize-and-verify-hyperlinks)을 참고하십시오.

## **전체 하이퍼링크 인벤토리 구축**

프레젠테이션을 배포하기 전에 인터랙티브 동작과 웹 링크를 모두 조사하십시오. [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)는 URL 문자열 목록이 아니라 [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) 객체를 반환합니다. 각 컨테이너에 대해 [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--)와 [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--)를 검사하십시오. 두 메서드는 독립적이며, 같은 컨테이너가 두 동작을 모두 가질 수 있으므로 완전한 보고서에는 컨테이너당 최대 두 행이 필요합니다.

도형 수준 하이퍼링크만 스캔하면 텍스트 부분에 붙은 링크를 놓칠 수 있습니다. 적절한 범위에 대해 쿼리하고 반환된 컨테이너를 보관해 나중에 동작을 업데이트하거나 제거할 수 있도록 하십시오.

### **프레젠테이션, 슬라이드 및 텍스트 프레임 범위 쿼리**

[HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) 클래스는 [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) 및 [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/)를 통해 사용할 수 있습니다. 각 범위는 동일한 쿼리를 지원합니다:

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) – 클릭 동작이 있는 컨테이너를 반환합니다.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) – 마우스오버 동작이 있는 컨테이너를 반환합니다.
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) – 어느 한쪽이든 동작이 있는 컨테이너를 반환합니다.

아래 예제는 외부 클릭 링크, 파일 마우스오버 링크, 내부 슬라이드 이동, 텍스트 마우스오버 링크, 매크로 동작을 포함한 `hyperlink-audit-input.pptx`를 생성합니다. 이 예제는 어떤 동작도 실행하지 않습니다. 세 가지 쿼리는 모든 범위에서 동일하게 작동하며, 반환값은 컨테이너 수를 의미합니다. 텍스트 프레임 범위는 포함된 도형 자체의 링크를 제외합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

이 예제에서는 프레젠테이션 및 슬라이드 쿼리가 각각 클릭 컨테이너 3개, 마우스오버 컨테이너 2개, 총 3개의 컨테이너를 보고합니다. 텍스트 프레임 쿼리는 각 카테고리당 1개의 컨테이너를 보고합니다.

### **동작 및 대상 분류**

[Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/)을 사용해 동작을 해석한 뒤 목적지를 해석하십시오. [HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) 값은 웹 탐색을 넘어 다양한 동작을 포함합니다:

| 값 | 감사 시 의미 |
| --- | --- |
| `Hyperlink` | 외부 하이퍼링크; URL 및 스키마를 확인합니다. |
| `JumpSpecificSlide` | 특정 슬라이드로 내부 이동. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 슬라이드 쇼 내 내장 네비게이션, 슬라이드 쇼 컨텍스트에서 해석됩니다. |
| `JumpEndShow`, `StartCustomSlideShow` | 현재 쇼를 종료하거나 사용자 정의 쇼를 시작합니다. |
| `StartMacro` | 매크로 실행. |
| `StartProgram` | 프로그램 실행. |
| `OpenFile`, `OpenPresentation` | 파일 또는 다른 프레젠테이션을 엽니다; 웹 URL과 별도로 검토합니다. |
| `StartStopMedia` | 미디어 재생을 시작하거나 중지합니다. |
| `NoAction`, `Unknown` | 탐색 동작이 없거나 인식되지 않은 동작이며 검토가 필요합니다. |

외부 목적지는 [getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/)으로, 특정 내부 목적지는 [getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/)으로 읽어옵니다. 내부 동작 및 내장 명령은 외부 URL이 없을 수 있으며, 빈 URL가 컨테이너에 동작이 없음을 의미하지는 않습니다. 정규화된 URL과 차이가 있는 경우 [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) 값을 보존하고, 사용 가능한 경우 [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/)에서 반환된 툴팁도 포함하십시오.

### **하이퍼링크 보고, 정리 및 검증**

아래 PHP 예제는 기존 프레젠테이션을 읽고(`hyperlink-audit-input.pptx`), `hyperlink-audit.json`을 쓰고, 정책을 적용한 뒤 `hyperlink-sanitized.pptx`를 저장하고, 다시 열어 두 활성화 유형을 확인합니다. 변경 전 컨테이너를 수집하고 동일 컨테이너를 두 번 처리하지 않도록 참조 동일성을 사용합니다. 프레젠테이션 쿼리는 일반 슬라이드만 포함하고, 전체 패키지 인벤토리를 위해 마스터, 레이아웃, 노트 및 해당 마스터도 명시적으로 쿼리합니다.

보고서는 1부터 시작하는 슬라이드 인덱스와 가능한 경우 [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--)를 기록합니다. 지원되는 컨테이너에 대해 [ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--)이 소유 슬라이드를 제공합니다. 마스터, 레이아웃, 노트는 일반 슬라이드 인덱스가 없으며 범위별로 식별됩니다. 도형 컨테이너와 텍스트 부분 서식 컨테이너는 별도로 라벨링되며, 기타 컨테이너는 런타임 타입 이름을 유지합니다. 각 컨테이너는 두 동작을 연계할 수 있도록 보고서 로컬 ID를 갖습니다. 보고서는 PHP 열거형에 정의된 정수 상수로 동작 유형을 저장합니다.

이 정책은 절대 HTTPS URL과 유효한 내부 슬라이드 대상만 허용합니다. 매크로, 프로그램, 파일 동작, 기타 슬라이드 쇼 동작, 알 수 없는 동작 및 기타 URL 스키마는 거부됩니다. 이러한 거부는 정책 결정이며 Aspose.Slides 안전성 판단이 아닙니다. HTTPS만으로는 신뢰를 보장하지 않으므로 호스트 허용 목록 및 추가 검증을 적용하십시오. 원본 및 정규화된 외부 URL 모두를 검사합니다. 예제는 링크를 따라가거나 동작을 실행하지 않고 메타데이터만 감사합니다.

수정하려면 컨테이너의 [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--)를 사용해 [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/), [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/)를 적용합니다. 여기서는 금지된 외부 클릭 링크를 고정된 HTTPS 랜딩 페이지로 교체하고, 기타 금지된 클릭 및 마우스오버 동작은 독립적으로 제거합니다. `$replaceExternalClicks`를 `false`로 설정하면 모든 정책 위반을 제거합니다. 배포 전 애플리케이션 자체 교체 페이지를 선택하십시오.

보고서의 내보내기 플래그는 보수적인 PDF 검토 정책을 사용합니다: 마우스오버 동작 및 외부 링크가 아닌 동작이나 특정 슬라이드 점프를 잠재적으로 지원되지 않는 것으로 표시합니다. 이는 검토 힌트이며, 플래그가 없는 링크가 내보내기에서 유지된다는 보장은 아닙니다. 지원되는 [PDF](/slides/ko/php-java/convert-powerpoint-to-pdf/) 및 [HTML](/slides/ko/php-java/convert-powerpoint-to-html/) 내보내기는 동작, 옵션 및 뷰어에 따라 하이퍼링크를 보존할 수 있습니다. 래스터 [이미지](/slides/ko/php-java/convert-powerpoint-to-png/)와 [비디오](/slides/ko/php-java/convert-powerpoint-to-video/)는 인터랙티브 하이퍼링크를 보존할 수 없으므로, 해당 출력에 대해 감사할 때 모든 동작에 플래그를 지정하십시오.

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

위에서 만든 입력을 사용하면 보고서에 다섯 개의 동작 행이 포함됩니다. 파일 마우스오버 링크와 매크로 클릭은 제거되고, HTTPS 링크와 내부 슬라이드 이동은 남습니다. 검증 결과는 금지된 동작이 0임을 출력합니다. 금지된 외부 클릭 URL을 포함한 입력은 교체 분기를 실행합니다. 허용된 클릭과 금지된 마우스오버가 모두 있는 컨테이너는 클릭 동작을 유지합니다.

이 선택적 정리는 정책에 따라 금지된 동작만 제거하며, [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)처럼 범위 전체에서 모든 활성화 유형을 무조건 제거하지 않습니다. 여기서 검증은 하이퍼링크 동작만 확인하며, 삽입된 VBA 프로젝트, OLE 개체 또는 기타 활성 콘텐츠를 제거하지 않고, 내보낸 PDF 또는 HTML 파일을 검증하지도 않습니다.

## **FAQ**

**섹션 또는 해당 섹션의 첫 슬라이드에 어떻게 링크합니까?**

PowerPoint 섹션은 슬라이드를 그룹화하지만 내부 하이퍼링크는 개별 슬라이드를 대상으로 합니다. 섹션으로 이동하려면 해당 섹션의 첫 슬라이드에 링크하십시오.

**마스터 슬라이드 요소에 하이퍼링크를 연결해 모든 슬라이드에서 작동하도록 할 수 있나요?**

예. 마스터 슬라이드와 레이아웃 요소는 하이퍼링크를 지원합니다. 이러한 요소의 링크는 해당 마스터나 레이아웃을 사용하는 슬라이드 쇼 중에 사용할 수 있습니다.

**PDF, HTML, 이미지 또는 비디오로 내보낼 때 하이퍼링크가 유지됩니까?**

지원되는 PDF와 HTML 내보내기는 하이퍼링크를 보존할 수 있지만, 래스터 이미지와 비디오는 보존할 수 없습니다. 자세한 내용은 [하이퍼링크 보고, 정리 및 검증](#report-sanitize-and-verify-hyperlinks) 항목의 내보내기 고려 사항을 확인하십시오.