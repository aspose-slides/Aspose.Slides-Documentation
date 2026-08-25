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
- 임베디드 글꼴 압축
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PHP에서 Aspose.Slides 로우코드 API를 사용하여 프레젠테이션을 변환 및 병합하고, 콘텐츠를 반복하며, 도형을 수집하고, 프레젠테이션 크기를 줄입니다."
---
## **개요**

The [aspose.slides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/ko/php-java/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ko/php-java/aspose.slides/convert/) | 프레젠테이션을 직접 파일 간 호출로 다른 형식으로 변환 |
| [Merger](https://reference.aspose.com/slides/ko/php-java/aspose.slides/merger/) | 같은 형식의 전체 프레젠테이션 파일을 결합 |
| [ForEach_](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/) | 각 슬라이드, 도형, 단락, 텍스트 부분에 대해 콜백 실행 |
| [Collect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/collect/) | 전체 프레젠테이션에서 도형을 가져와 반복 처리 또는 분석에 사용 |
| [Compress](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/) | 사용되지 않는 마스터와 레이아웃을 제거하고 포함된 글꼴 데이터를 축소 |

## **프레젠테이션 변환**

Use [Convert::autoByExtension](https://reference.aspose.com/slides/ko/php-java/aspose.slides/convert/#autoByExtension) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/ko/php-java/aspose.slides/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/slides/ko/php-java/convert-presentation/) for format-specific workflows and options.

## **프레젠테이션 병합**

Use [Merger::process](https://reference.aspose.com/slides/ko/php-java/aspose.slides/merger/#process) to combine complete presentation files with one call. The input presentations must have the same file format.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/ko/php-java/merge-presentation/) for those scenarios.

## **프레젠테이션 요소 반복**

The [ForEach_](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach_::slide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#paragraph), and [ForEach_::portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#portion) to inspect the corresponding elements:

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

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **도형 수집**

Use [Collect::shapes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/collect/#shapes) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

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

Use [ForEach_::shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#shape) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **프레젠테이션 콘텐츠 압축**

The [Compress](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) removes layout slides that no normal slide references.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/#removeUnusedMasterSlides) removes master slides that are no longer used.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/#compressEmbeddedFonts) removes unused characters from embedded fonts.

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

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/ko/php-java/slide-master/) and [Embedded Font](/slides/ko/php-java/embedded-font/).

## **FAQ**

**언제 로우코드 API를 전체 객체 모델 대신 사용해야 합니까?**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**Merger가 서로 다른 파일 형식의 프레젠테이션을 결합할 수 있나요?**

No. [Merger::process](https://reference.aspose.com/slides/ko/php-java/aspose.slides/merger/#process) requires input presentations in the same format. Convert the input files to a common format first, for example with [Convert::autoByExtension](https://reference.aspose.com/slides/ko/php-java/aspose.slides/convert/#autoByExtension), and then merge the converted files.

**ForEach_가 마스터, 레이아웃 및 노트 슬라이드를 처리합니까?**

[ForEach_::slide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#slide) iterates through normal presentation slides. Presentation-wide [ForEach_::shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#paragraph), and [ForEach_::portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#portion) operations include normal, master, and layout slides by default. Use their overloads with `includeNotes` set to `true` to include notes slides.

**ForEach_::shape와 Collect::shapes의 차이점은 무엇인가요?**

Use [ForEach_::shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_/#shape) to process each shape immediately through a callback. Use [Collect::shapes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/collect/#shapes) when you need an iterable result that can be retained, filtered, counted, or traversed multiple times.

**Compress는 항상 프레젠테이션 파일을 더 작게 만들까요?**

Not necessarily. The result depends on whether the presentation contains unused layouts, unused masters, or embedded fonts with unused characters. If none of those are present, the corresponding [Compress](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/) operations may not reduce the file size.

**ForEach_ 또는 Compress가 수행한 변경 사항이 자동으로 저장되나요?**

No. These helpers operate on the loaded [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) object in memory. After changing elements in a [ForEach_](https://reference.aspose.com/slides/ko/php-java/aspose.slides/foreach_) callback or running [Compress](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/), call [Presentation::save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#save) to write the result.

## **관련 문서**

- [프레젠테이션 변환](/slides/ko/php-java/convert-presentation/)
- [프레젠테이션 병합](/slides/ko/php-java/merge-presentation/)
- [슬라이드 마스터](/slides/ko/php-java/slide-master/)
- [텍스트 상자 관리](/slides/ko/php-java/manage-textbox/)
- [임베디드 글꼴](/slides/ko/php-java/embedded-font/)