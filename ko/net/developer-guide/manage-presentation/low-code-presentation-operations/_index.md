---
title: Low-Code 프레젠테이션 작업(.NET)
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
description: "Aspose.Slides Low-Code API를 .NET에서 사용하여 프레젠테이션을 변환 및 병합하고, 콘텐츠를 순회하며, 도형을 수집하고, 프레젠테이션 크기를 줄입니다."
---
## **개요**

The [Aspose.Slides.LowCode](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/) 네임스페이스는 일반적인 프레젠테이션 작업을 위한 정적 헬퍼 클래스를 제공합니다. 이 헬퍼들은 자주 사용되는 객체‑모델 워크플로를 집중된 메서드로 래핑하여 파일을 변환하거나 병합하고, 프레젠테이션 요소를 처리하고, 도형을 수집하며, 사용되지 않는 콘텐츠를 더 적은 코드로 제거할 수 있게 합니다.

Low‑code 헬퍼는 작업이 전체 파일 또는 프레젠테이션에 적용되고 기본 워크플로가 요구 사항과 일치할 때 가장 유용합니다. 개별 슬라이드, 마스터, 레이아웃, 도형, 내보내기 설정 또는 프레젠테이션 요소 간 관계에 대해 세밀한 제어가 필요하면 전체 [Aspose.Slides object model](https://reference.aspose.com/slides/ko/net/aspose.slides/)을 사용하십시오.

다음 표는 사용 가능한 헬퍼를 요약합니다:

| Helper | 사용 용도 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/convert/) | 파일‑to‑파일 호출로 프레젠테이션을 다른 형식으로 변환 |
| [Merger](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/merger/) | 동일 형식의 전체 프레젠테이션 파일을 결합 |
| [ForEach](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/) | 각 슬라이드, 도형, 단락 또는 텍스트 부분에 대한 작업 실행 |
| [Collect](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/collect/) | 전체 프레젠테이션에서 도형을 검색하여 반복 처리 또는 분석에 사용 |
| [Compress](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/) | 사용되지 않는 마스터 및 레이아웃을 제거하고 포함된 글꼴 데이터를 축소 |

## **프레젠테이션 변환**

출력 파일 확장자만으로 내보내기 형식을 선택할 수 있을 때는 [Convert.AutoByExtension](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/convert/autobyextension/)을 사용하십시오. 이 메서드는 원본 프레젠테이션을 열고, 출력 경로에서 필요한 형식을 결정한 뒤 결과를 기록합니다.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/convert/) 클래스는 PDF, SVG, JPEG, PNG, TIFF 출력용 전용 메서드도 제공합니다. 내보내기 전에 프레젠테이션을 검사하거나 수정하거나 선택한 헬퍼가 노출하지 않는 내보내기 옵션을 구성해야 하는 경우 전체 객체 모델을 사용하십시오. 형식별 워크플로와 옵션은 [Convert Presentation](/net/convert-presentation/)을 참조하십시오.

## **프레젠테이션 병합**

[Merger.Process](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/merger/process/)를 사용하면 한 번의 호출로 전체 프레젠테이션 파일을 결합할 수 있습니다. 입력 프레젠테이션은 동일한 파일 형식이어야 합니다.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

이 헬퍼는 모든 슬라이드를 개별 선택이나 매핑 없이 하나의 결과에 추가해야 할 때 적합합니다. 선택된 슬라이드를 병합하거나 대상 마스터·레이아웃을 적용하거나 섹션을 명시적으로 보존하거나 서로 다른 슬라이드 크기를 조정해야 하는 경우 전체 객체 모델을 사용하십시오. 해당 시나리오는 [Merge Presentations](/net/merge-presentation/)를 참조하십시오.

## **프레젠테이션 요소 순회**

[ForEach](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/) 클래스는 요청된 프레젠테이션 요소 유형마다 콜백을 호출합니다. 중첩된 컬렉션 루프를 피하고 프레젠테이션 전체에 대한 검사 또는 서식 변경에 편리합니다.

다음 예제는 [ForEach.Slide](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/paragraph/), [ForEach.Portion](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/portion/)을 사용해 해당 요소를 검사합니다:

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

기본적으로 프레젠테이션 전체 도형 및 텍스트 순회에는 일반 슬라이드, 마스터 슬라이드, 레이아웃 슬라이드가 포함됩니다. `includeNotes` 매개변수가 있는 오버로드를 사용하면 노트 슬라이드도 처리할 수 있습니다. 순회 순서, 조기 종료, 콜백 호출 전 필터링, 상세한 부모‑자식 제어가 중요한 경우 직접 컬렉션 루프를 사용하십시오.

## **도형 수집**

각 도형에 대한 콜백 대신 프레젠테이션 전체 도형 컬렉션이 필요한 경우 [Collect.Shapes](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/collect/shapes/)을 사용하십시오. 동일한 집합을 여러 번 필터링, 계산 또는 처리하려는 경우에 유용합니다.

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

각 도형을 즉시 처리할 수 있고 수집된 결과를 유지할 필요가 없을 때는 [ForEach.Shape](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/shape/)를 대신 사용하십시오.

## **프레젠테이션 콘텐츠 압축**

[Compress](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/) 클래스는 사용되지 않는 구조 요소를 제거하고 포함된 글꼴 데이터를 축소할 수 있습니다:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 사용되지 않는 레이아웃 슬라이드(일반 슬라이드에서 참조되지 않는)를 제거합니다.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) 사용되지 않는 마스터 슬라이드를 제거합니다.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/compressembeddedfonts/) 포함된 글꼴에서 사용되지 않는 문자들을 제거합니다.

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

레이아웃을 정리한 후에 마스터를 정리하십시오. 레이아웃 정리 후에 참조가 사라진 마스터도 함께 제거될 수 있습니다. 원본 마스터·레이아웃·전체 포함 글꼴 데이터가 나중에 필요할可能성이 있다면 최적화된 프레젠테이션을 새 파일로 저장하십시오. 자세한 내용은 [Slide Master](/net/slide-master/)와 [Embedded Font](/net/embedded-font/)를 참고하십시오.

## **자주 묻는 질문**

**When should I use the low-code API instead of the full object model?**  
표준 작업이 전체 파일 또는 프레젠테이션에 적용되고 개별 요소에 대한 상세 제어가 필요하지 않을 때 Low‑code 헬퍼를 사용하십시오. 특정 슬라이드를 선택하거나 마스터·레이아웃 관계를 제어하거나 중간 상태를 검사하거나 헬퍼가 제공하지 않는 동작을 구성해야 할 경우 전체 객체 모델을 사용하십시오.

**Can Merger combine presentations in different file formats?**  
아니요. [Merger.Process](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/merger/process/)는 입력 프레젠테이션이 동일한 형식일 때만 작동합니다. 먼저 [Convert.AutoByExtension](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/convert/autobyextension/) 등으로 파일을 공통 형식으로 변환한 뒤 병합하십시오.

**Does ForEach process master, layout, and notes slides?**  
[ForEach.Slide](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/slide/)은 일반 프레젠테이션 슬라이드만 순회합니다. 프레젠테이션 전체에 대한 [ForEach.Shape](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/paragraph/), [ForEach.Portion](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/portion/) 작업은 기본적으로 일반, 마스터, 레이아웃 슬라이드를 포함합니다. `includeNotes`를 `true`로 설정한 오버로드를 사용하면 노트 슬라이드도 포함됩니다.

**What is the difference between ForEach.Shape and Collect.Shapes?**  
각 도형을 콜백으로 즉시 처리하려면 [ForEach.Shape](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/shape/)를 사용하십시오. 도형 컬렉션을 보관하거나 여러 번 필터링·계산·순회해야 할 경우에는 [Collect.Shapes](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/collect/shapes/)를 사용하십시오.

**Does Compress always make the presentation file smaller?**  
항상 그렇지는 않습니다. 프레젠테이션에 사용되지 않는 레이아웃·마스터·글꼴(사용되지 않는 문자 포함)이 존재할 때만 해당 [Compress](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/) 작업이 파일 크기를 줄일 수 있습니다. 해당 요소가 없으면 파일 크기가 변하지 않을 수 있습니다.

**Are changes made by ForEach or Compress saved automatically?**  
아니요. 이러한 헬퍼는 메모리 내의 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 객체에만 영향을 미칩니다. [ForEach](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/foreach/) 콜백이나 [Compress](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/) 실행 후에는 [Presentation.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/)을 호출해 결과를 파일에 기록해야 합니다.

## **관련 문서**

- [Convert Presentation](/net/convert-presentation/)
- [Merge Presentations](/net/merge-presentation/)
- [Slide Master](/net/slide-master/)
- [Manage Text Box](/net/manage-textbox/)
- [Embedded Font](/net/embedded-font/)