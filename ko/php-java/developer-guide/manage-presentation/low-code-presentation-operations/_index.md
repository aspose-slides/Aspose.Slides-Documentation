---
title: PHP에서 로우코드 프레젠테이션 작업
linktitle: 로우코드 API
type: docs
weight: 50
url: /ko/php-java/low-code-presentation-operations/
keywords:
- 로우코드 프레젠테이션 API
- 프레젠테이션 변환
- 프레젠테이션 병합
- 슬라이드 반복
- 도형 반복
- 텍스트 반복
- 도형 수집
- 프레젠테이션 압축
- 사용되지 않는 마스터 슬라이드 제거
- 사용되지 않는 레이아웃 슬라이드 제거
- 내장 폰트 압축
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PHP에서 Aspose.Slides 로우코드 API를 사용하여 프레젠테이션을 변환 및 병합하고, 콘텐츠를 반복하며, 도형을 수집하고, 프레젠테이션 크기를 줄입니다."
---
## **개요**

[aspose.slides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/) 네임스페이스는 일반 프레젠테이션 작업을 위한 정적 헬퍼 클래스를 제공합니다. 이러한 헬퍼는 자주 사용되는 객체 모델 워크플로를 집중된 메서드로 래핑하여 파일을 변환하거나 병합하고, 프레젠테이션 요소를 처리하고, 도형을 수집하며, 사용되지 않는 콘텐츠를 더 적은 코드로 제거할 수 있습니다.

작업이 전체 파일이나 프레젠테이션에 적용되고 기본 워크플로가 요구 사항에 맞을 때 로우코드 헬퍼가 가장 유용합니다. 개별 슬라이드, 마스터, 레이아웃, 도형, 내보내기 설정 또는 프레젠테이션 요소 간 관계에 대한 세밀한 제어가 필요하면 전체 [Aspose.Slides object model](https://reference.aspose.com/slides/ko/php-java/aspose.slides/)을 사용하십시오.

다음 표는 사용 가능한 헬퍼를 요약합니다:

| 헬퍼 | 용도 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ko/php-java/aspose.slides/convert/) | 직접 파일 간 호출로 프레젠테이션을 다른 형식으로 변환 |
| [Merger](https://reference.aspose.com/slides/ko/php-java/aspose.slides/merger/) | 동일 형식의 전체 프레젠테이션 파일을 결합 |
| [ForEach_](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/) | 각 슬라이드, 도형, 단락 또는 텍스트 부분에 대해 콜백 실행 |
| [Collect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/collect/) | 전체 프레젠테이션에서 도형을 가져와 반복 처리 또는 분석 |
| [Compress](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/) | 사용되지 않는 마스터와 레이아웃을 제거하고 내장 폰트 데이터를 축소 |

## **프레젠테이션 변환**

출력 파일 확장자가 내보내기 형식을 선택하기에 충분할 때 [Convert::autoByExtension](https://reference.aspose.com/slides/ko/php-java/aspose.slides/convert/#autoByExtension) 을 사용하십시오. 이 메서드는 원본 프레젠테이션을 열고, 출력 경로에서 필요한 형식을 결정한 뒤 결과를 기록합니다.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/ko/php-java/aspose.slides/convert/) 클래스는 PDF, SVG, JPEG, PNG 및 TIFF 출력에 대한 전용 메서드도 제공합니다. 내보내기 전에 프레젠테이션을 검사하거나 수정해야 하거나 선택한 헬퍼가 노출하지 않는 내보내기 옵션을 구성해야 할 경우 전체 객체 모델을 사용하십시오. 형식별 워크플로와 옵션은 [Convert Presentation](/php-java/convert-presentation/) 를 참조하십시오.

## **프레젠테이션 병합**

[Merger::process](https://reference.aspose.com/slides/ko/php-java/aspose.slides/merger/#process) 를 사용하면 한 번의 호출로 전체 프레젠테이션 파일을 결합할 수 있습니다. 입력 프레젠테이션은 동일한 파일 형식이어야 합니다.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

모든 슬라이드를 하나의 결과에 순차적으로 추가하고 개별 선택이나 매핑이 필요 없을 때 이 헬퍼가 적합합니다. 선택된 슬라이드만 병합하거나 대상 마스터·레이아웃을 적용하고, 섹션을 명시적으로 보존하거나 슬라이드 크기가 다른 경우 전체 객체 모델을 사용하십시오. 이러한 시나리오는 [Merge Presentations](/php-java/merge-presentation/) 에서 확인할 수 있습니다.

## **프레젠테이션 요소 반복**

[ForEach_](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/) 클래스는 요청된 유형의 프레젠테이션 요소마다 콜백을 호출합니다. 중첩된 컬렉션 루프를 피하면서 프레젠테이션 전체 검사나 서식 변경에 편리합니다.

다음 예제는 [ForEach_::slide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#paragraph), [ForEach_::portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#portion) 을 사용해 해당 요소들을 검사합니다:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

기본적으로 프레젠테이션 전체 도형 및 텍스트 순회에는 일반 슬라이드, 마스터 슬라이드 및 레이아웃 슬라이드가 포함됩니다. `includeNotes` 매개변수가 있는 오버로드를 사용하면 노트 슬라이드도 처리할 수 있습니다. 순회 순서, 조기 종료, 콜백 호출 전 필터링, 또는 상세한 부모‑자식 제어가 중요한 경우 직접 컬렉션 루프를 사용하십시오.

## **도형 수집**

프레젠테이션 전체에서 모든 도형의 컬렉션이 필요하고 각 도형에 대한 콜백이 필요하지 않을 때는 [Collect::shapes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/collect/#shapes) 를 사용하십시오. 동일한 집합을 여러 번 필터링하거나, 카운트하거나, 처리할 경우 유용합니다.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

각 도형을 즉시 처리하고 수집된 결과를 유지할 필요가 없을 경우에는 [ForEach_::shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#shape) 을 대신 사용하십시오.

## **프레젠테이션 내용 압축**

[Compress](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/) 클래스는 사용되지 않는 구조 요소를 제거하고 내장 폰트 데이터를 축소할 수 있습니다:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) 은 정상 슬라이드가 참조하지 않는 레이아웃 슬라이드를 제거합니다.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/#removeUnusedMasterSlides) 은 더 이상 사용되지 않는 마스터 슬라이드를 제거합니다.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/#compressEmbeddedFonts) 은 내장 폰트에서 사용되지 않는 문자를 제거합니다.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

먼저 사용되지 않는 레이아웃을 제거하고 그 다음에 사용되지 않는 마스터를 제거하십시오. 레이아웃 정리 후에 참조가 끊긴 마스터도 함께 제거됩니다. 원본 마스터·레이아웃·전체 내장 폰트 데이터를 나중에 필요할 수 있다면 최적화된 프레젠테이션을 새 파일에 저장하십시오. 자세한 내용은 [Slide Master](/php-java/slide-master/) 및 [Embedded Font](/php-java/embedded-font/) 를 참고하십시오.

## **FAQ**

**저코드 API를 전체 객체 모델 대신 언제 사용해야 하나요?**  
표준 작업이 전체 파일이나 프레젠테이션에 적용되고 개별 요소에 대한 세부 제어가 필요하지 않을 때 로우코드 헬퍼를 사용하십시오. 특정 슬라이드를 선택하거나 마스터·레이아웃 관계를 제어하고, 중간 상태를 검사하거나 헬퍼가 노출하지 않는 동작을 구성해야 할 경우 전체 객체 모델을 사용하십시오.

**Merger가 서로 다른 파일 형식의 프레젠테이션을 결합할 수 있나요?**  
아니요. [Merger::process](https://reference.aspose.com/slides/ko/php-java/aspose.slides/merger/#process) 은 입력 프레젠테이션이 동일한 형식이어야 합니다. 먼저 [Convert::autoByExtension](https://reference.aspose.com/slides/ko/php-java/aspose.slides/convert/#autoByExtension) 와 같은 방법으로 입력 파일을 공통 형식으로 변환한 뒤 결합하십시오.

**ForEach_가 마스터, 레이아웃 및 노트 슬라이드를 처리합니까?**  
[ForEach_::slide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#slide) 은 일반 프레젠테이션 슬라이드만 순회합니다. 프레젠테이션 전체에 적용되는 [ForEach_::shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#paragraph), [ForEach_::portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#portion) 작업은 기본적으로 일반, 마스터 및 레이아웃 슬라이드를 포함합니다. 노트 슬라이드를 포함하려면 `includeNotes` 매개변수를 `true` 로 설정한 오버로드를 사용하십시오.

**ForEach_::shape와 Collect::shapes의 차이점은 무엇인가요?**  
각 도형을 즉시 콜백으로 처리하려면 [ForEach_::shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#shape) 를 사용하십시오. 도형 컬렉션을 보관하고 나중에 필터링·카운트·다중 순회하려면 [Collect::shapes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/collect/#shapes) 를 사용하십시오.

**Compress는 항상 프레젠테이션 파일 크기를 줄이나요?**  
必ずしも 그렇지는 않습니다. 프레젠테이션에 사용되지 않는 레이아웃·마스터·내장 폰트의 사용되지 않는 문자 등이 존재하는 경우에만 해당 [Compress](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/) 작업이 파일 크기를 감소시킬 수 있습니다.

**ForEach_ 또는 Compress가 수행한 변경 사항이 자동으로 저장되나요?**  
아니요. 이러한 헬퍼는 메모리상의 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 객체에 대해 작동합니다. [ForEach_](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_) 콜백이나 [Compress](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/) 를 실행한 후에는 [Presentation::save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#save) 을 호출해 결과를 파일에 기록해야 합니다.

## **관련 문서**

- [Convert Presentation](/php-java/convert-presentation/)
- [Merge Presentations](/php-java/merge-presentation/)
- [Slide Master](/php-java/slide-master/)
- [Manage Text Box](/php-java/manage-textbox/)
- [Embedded Font](/php-java/embedded-font/)