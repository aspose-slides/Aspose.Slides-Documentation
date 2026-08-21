---
title: Android에서 저코드 프레젠테이션 작업
linktitle: 저코드 API
type: docs
weight: 50
url: /ko/androidjava/low-code-presentation-operations/
keywords:
- 저코드 프레젠테이션 API
- 프레젠테이션 변환
- 프레젠테이션 병합
- 슬라이드 순회
- 도형 순회
- 텍스트 순회
- 도형 수집
- 프레젠테이션 압축
- 사용되지 않는 마스터 슬라이드 제거
- 사용되지 않는 레이아웃 슬라이드 제거
- 내장 폰트 압축
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Android에서 Aspose.Slides 저코드 API를 사용하여 프레젠테이션을 변환 및 병합하고, 콘텐츠를 순회하며, 도형을 수집하고, 프레젠테이션 크기를 줄입니다."
---
## **개요**

The [com.aspose.slides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/) package provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| 헬퍼 | 사용 용도 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/convert/) | 프레젠테이션을 직접 파일-대-파일 호출로 다른 형식으로 변환합니다. |
| [Merger](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/merger/) | 동일한 형식의 전체 프레젠테이션 파일을 결합합니다. |
| [ForEach](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/) | 각 슬라이드, 도형, 단락 또는 텍스트 부분에 대해 작업을 실행합니다. |
| [Collect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/collect/) | 전체 프레젠테이션에서 도형을 가져와 반복 처리나 분석에 활용합니다. |
| [Compress](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/) | 사용되지 않는 마스터와 레이아웃을 제거하고 포함된 글꼴 데이터를 감소시킵니다. |

## **프레젠테이션 변환**

Use [Convert.autoByExtension](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/androidjava/convert-presentation/) for format-specific workflows and options.

## **프레젠테이션 병합**

Use [Merger.process](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) to combine complete presentation files with one call. The input presentations must have the same file format.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/androidjava/merge-presentation/) for those scenarios.

## **프레젠테이션 요소 반복 처리**

The [ForEach](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.slide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), and [ForEach.portion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) to inspect the corresponding elements:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **도형 수집**

Use [Collect.shapes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Use [ForEach.shape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **프레젠테이션 콘텐츠 압축**

The [Compress](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) removes layout slides that no normal slide references.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) removes master slides that are no longer used.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) removes unused characters from embedded fonts.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/androidjava/slide-master/) and [Embedded Font](/androidjava/embedded-font/).

## **FAQ**

**언제 전체 객체 모델 대신 로우코드 API를 사용해야 하나요?**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**Merger가 서로 다른 파일 형식의 프레젠테이션을 병합할 수 있나요?**

No. [Merger.process](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) requires input presentations in the same format. Convert the input files to a common format first, for example with [Convert.autoByExtension](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), and then merge the converted files.

**ForEach가 마스터, 레이아웃, 그리고 노트 슬라이드를 처리하나요?**

[ForEach.slide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) iterates through normal presentation slides. Presentation-wide [ForEach.shape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), and [ForEach.portion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) operations include normal, master, and layout slides by default. Use their overloads with `includeNotes` set to `true` to include notes slides.

**ForEach.shape와 Collect.shapes의 차이점은 무엇인가요?**

Use [ForEach.shape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) to process each shape immediately through a callback. Use [Collect.shapes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) when you need an iterable result that can be retained, filtered, counted, or traversed multiple times.

**Compress는 항상 프레젠테이션 파일을 더 작게 만들나요?**

Not necessarily. The result depends on whether the presentation contains unused layouts, unused masters, or embedded fonts with unused characters. If none of those are present, the corresponding [Compress](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/) operations may not reduce the file size.

**ForEach 또는 Compress가 만든 변경 사항이 자동으로 저장되나요?**

No. These helpers operate on the loaded [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) object in memory. After changing elements in a [ForEach](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/) callback or running [Compress](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/), call [Presentation.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) to write the result.

## **관련 기사**

- [프레젠테이션 변환](/androidjava/convert-presentation/)
- [프레젠테이션 병합](/androidjava/merge-presentation/)
- [슬라이드 마스터](/androidjava/slide-master/)
- [텍스트 박스 관리](/androidjava/manage-textbox/)
- [임베디드 폰트](/androidjava/embedded-font/)