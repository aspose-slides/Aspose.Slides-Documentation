---
title: .NET에서 Low-Code 프레젠테이션 작업
linktitle: Low-Code API
type: docs
weight: 50
url: /ko/net/low-code-presentation-operations/
keywords:
- Low-Code 프레젠테이션 API
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
description: ".NET에서 Aspose.Slides Low-Code API를 사용하여 프레젠테이션을 변환 및 병합하고, 콘텐츠를 순회하며, 도형을 수집하고, 프레젠테이션 크기를 줄일 수 있습니다."
---
## **개요**

The [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/net/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| 헬퍼 | 사용 목적 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | 프레젠테이션을 다른 형식으로 직접 파일 간 호출하여 변환합니다. |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | 동일한 형식의 전체 프레젠테이션 파일을 결합합니다. |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | 각 슬라이드, 도형, 단락, 텍스트 부분에 대해 작업을 실행합니다. |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | 전체 프레젠테이션에서 도형을 가져와 반복 처리 또는 분석에 사용합니다. |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | 사용되지 않는 마스터/레이아웃을 제거하고, 포함된 글꼴 데이터를 줄이며, 그림을 압축합니다. |

## **프레젠테이션 변환**

Use [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [프레젠테이션 변환](/slides/ko/net/convert-presentation/) for format-specific workflows and options.

## **프레젠테이션 병합**

Use [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) to combine complete presentation files with one call. The input presentations must have the same file format.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/ko/net/merge-presentation/) for those scenarios.

## **프레젠테이션 요소 반복**

The [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/), and [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) to inspect the corresponding elements:

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

Use [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

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

Use [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **프레젠테이션 콘텐츠 압축**

The [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) removes layout slides that no normal slide references.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) removes master slides that are no longer used.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) removes unused characters from embedded fonts.

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

### **전체 프레젠테이션 압축**

Aspose.Slides for .NET 26.11 adds [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/). It combines removal of unused layout/master slides, subsetting of embedded fonts to used characters, and picture compression at 150 DPI. Use the individual operations above when you need to control which changes are applied.

Install [Aspose.Slides for .NET](/slides/ko/net/installation/) 26.11 or later and provide `input.pptx`. Save to a separate file: removed layouts, font characters and cropped picture pixels may be needed for later editing.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **선택한 해상도로 이미지 압축**

Use [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) to process eligible pictures without also removing layouts or subsetting fonts. This example uses 96 DPI; select another [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) value for your output needs.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

Both helpers use the following picture-processing scope:

| 내용 | 처리 |
| --- | --- |
| 일반, 마스터 및 레이아웃 슬라이드의 래스터 이미지와 도형 이미지 채우기(그룹화된 도형 포함) | 압축 대상. |
| 이미 요청된 해상도 이하인 이미지 | 업스케일되지 않음. 잘린 영역은 여전히 제거될 수 있음. |
| 잘린 이미지 영역 | 숨겨진 픽셀은 영구히 제거되고 잘림 오프셋이 재설정됩니다. |
| 슬라이드 배경 및 표 셀 채우기 | 이 헬퍼에서 처리되지 않습니다. |
| 차트/SmartArt 내부, GIF 및 SVG, EMF, WMF와 같은 벡터 형식 | 문서화된 이미지 압축 범위에 포함되지 않음. |

In 26.11, [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) avoids resolution-based downsampling of an uncropped picture, but **does not preserve cropped pixels**. A cropped picture can still be rewritten with its hidden areas removed. Neither helper exposes a preserve-crop option. For individual control, see the [이미지별 압축 예제](/slides/ko/net/examples/optimization-batch/compression/).

Compare the output's appearance and file size before replacing the original. Savings depend on the source pictures, their displayed size and unused content; compression does not guarantee a smaller file. See [Embedded Fonts](/slides/ko/net/embedded-font/) for the implications of font subsetting.

## **FAQ**

**언제 전체 객체 모델 대신 Low-code API를 사용해야 하나요?**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**Merger가 다른 파일 형식의 프레젠테이션을 결합할 수 있나요?**

No. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) requires input presentations in the same format. Convert the input files to a common format first, for example with [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), and then merge the converted files.

**ForEach가 마스터, 레이아웃 및 노트 슬라이드를 처리하나요?**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) iterates through normal presentation slides. Presentation-wide [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/), and [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) operations include normal, master, and layout slides by default. Use their overloads with `includeNotes` set to `true` to include notes slides.

**ForEach.Shape와 Collect.Shapes의 차이점은 무엇인가요?**

Use [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) to process each shape immediately through a callback. Use [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) when you need an enumerable result that can be retained, filtered, counted, or traversed multiple times.

**Compress가 항상 프레젠테이션 파일을 작게 만들까요?**

Not necessarily. Savings depend on unused layouts/masters, embedded fonts with unused characters, and pictures that benefit from compression. The [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) helpers may leave the size unchanged or produce a larger file for some inputs. Compare both size and rendered quality, and keep the original.

**ForEach 또는 Compress에 의해 만든 변경 사항이 자동으로 저장되나요?**

No. These helpers operate on the loaded [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) object in memory. After changing elements in a [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) callback or running [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/), call [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) to write the result.

## **Related Articles**

- [프레젠테이션 변환](/slides/ko/net/convert-presentation/)
- [프레젠테이션 병합](/slides/ko/net/merge-presentation/)
- [슬라이드 마스터](/slides/ko/net/slide-master/)
- [텍스트 상자 관리](/slides/ko/net/manage-textbox/)
- [포함된 글꼴](/slides/ko/net/embedded-font/)