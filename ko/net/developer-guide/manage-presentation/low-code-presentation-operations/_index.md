---
title: .NET에서 로우코드 프레젠테이션 작업
linktitle: 로우코드 API
type: docs
weight: 50
url: /ko/net/low-code-presentation-operations/
keywords:
  - 로우코드 프레젠테이션 API
  - 프레젠테이션 변환
  - 프레젠테이션 병합
  - 슬라이드 순회
  - 도형 순회
  - 텍스트 순회
  - 도형 수집
  - 프레젠테이션 압축
  - 사용되지 않는 마스터 슬라이드 제거
  - 사용되지 않는 레이아웃 슬라이드 제거
  - 내장 글꼴 압축
  - PowerPoint
  - OpenDocument
  - 프레젠테이션
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides 로우코드 API를 .NET에서 사용하여 프레젠테이션을 변환·병합하고, 내용을 순회하며, 도형을 수집하고, 프레젠테이션 크기를 줄일 수 있습니다."
---
## **개요**

The [Aspose.Slides.LowCode](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/ko/net/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| 헬퍼 | 사용 용도 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/convert/) | 프레젠테이션을 직접 파일 대 파일 호출로 다른 형식으로 변환합니다. |
| [Merger](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/merger/) | 동일 형식의 전체 프레젠테이션 파일을 결합합니다. |
| [ForEach](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/) | 각 슬라이드, 도형, 단락 또는 텍스트 구간에 대한 동작을 실행합니다. |
| [Collect](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/collect/) | 전체 프레젠테이션에서 도형을 검색하여 반복 처리 또는 분석에 사용합니다. |
| [Compress](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/) | 사용되지 않는 마스터와 레이아웃을 제거하고 포함된 글꼴 데이터를 축소합니다. |

## **프레젠테이션 변환**

Use [Convert.AutoByExtension](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/convert/autobyextension/) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/slides/ko/net/convert-presentation/) for format-specific workflows and options.

## **프레젠테이션 병합**

Use [Merger.Process](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/merger/process/) to combine complete presentation files with one call. The input presentations must have the same file format.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/ko/net/merge-presentation/) for those scenarios.

## **프레젠테이션 요소 반복**

The [ForEach](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.Slide](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/paragraph/), and [ForEach.Portion](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/portion/) to inspect the corresponding elements:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **도형 수집**

Use [Collect.Shapes](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/collect/shapes/) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

Use [ForEach.Shape](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/shape/) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **프레젠테이션 콘텐츠 압축**

The [Compress](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) removes layout slides that no normal slide references.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) removes master slides that are no longer used.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/compressembeddedfonts/) removes unused characters from embedded fonts.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/ko/net/slide-master/) and [Embedded Font](/slides/ko/net/embedded-font/).

## **FAQ**

**전체 객체 모델 대신 로우코드 API를 언제 사용해야 합니까?**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**Merger가 서로 다른 파일 형식의 프레젠테이션을 결합할 수 있습니까?**

No. [Merger.Process](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/merger/process/) requires input presentations in the same format. Convert the input files to a common format first, for example with [Convert.AutoByExtension](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/convert/autobyextension/), and then merge the converted files.

**ForEach가 마스터, 레이아웃 및 노트 슬라이드를 처리합니까?**

[ForEach.Slide](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/slide/) iterates through normal presentation slides. Presentation-wide [ForEach.Shape](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/paragraph/), and [ForEach.Portion](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/portion/) operations include normal, master, and layout slides by default. Use their overloads with `includeNotes` set to `true` to include notes slides.

**ForEach.Shape와 Collect.Shapes의 차이점은 무엇입니까?**

Use [ForEach.Shape](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/shape/) to process each shape immediately through a callback. Use [Collect.Shapes](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/collect/shapes/) when you need an enumerable result that can be retained, filtered, counted, or traversed multiple times.

**Compress는 항상 프레젠테이션 파일을 작게 만들까요?**

Not necessarily. The result depends on whether the presentation contains unused layouts, unused masters, or embedded fonts with unused characters. If none of those are present, the corresponding [Compress](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/) operations may not reduce the file size.

**ForEach나 Compress에 의해 변경된 내용이 자동으로 저장되나요?**

No. These helpers operate on the loaded [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) object in memory. After changing elements in a [ForEach](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/) callback or running [Compress](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/), call [Presentation.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/) to write the result.

## **관련 문서**

- [프레젠테이션 변환](/slides/ko/net/convert-presentation/)
- [프레젠테이션 병합](/slides/ko/net/merge-presentation/)
- [슬라이드 마스터](/slides/ko/net/slide-master/)
- [텍스트 상자 관리](/slides/ko/net/manage-textbox/)
- [포함된 글꼴](/slides/ko/net/embedded-font/)