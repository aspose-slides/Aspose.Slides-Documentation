---
title: .NET에서 노트 페이지 크기 및 방향 변경
linktitle: 노트 페이지 크기
type: docs
weight: 10
url: /ko/net/notes-size/
keywords:
- 노트 페이지 크기
- 노트 방향
- 가로 노트
- 세로 노트
- 유인물 크기
- PowerPoint
- 프레젠테이션
- PPT
- PPTX
- C#
- Aspose.Slides
description: Aspose.Slides for .NET에서 노트 페이지 크기를 읽고 변경하며, 방향을 전환하고, 저장된 크기를 확인하고, 노트 또는 유인물을 PDF와 이미지로 내보냅니다.
---
## **개요**

프레젠테이션의 노트 페이지 설정에 접근하려면 [Presentation.NotesSize](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/notessize/)를 사용하십시오. 이 메서드는 [INotesSize](https://reference.aspose.com/slides/ko/net/aspose.slides/inotessize/) 객체를 반환하며, 해당 객체의 [Size](https://reference.aspose.com/slides/ko/net/aspose.slides/inotessize/size/) 속성은 쓰기 가능합니다. 설정 객체 자체는 읽기 전용이지만, size 속성에 새로운 차원을 할당할 수 있습니다.

너비와 높이는 **포인트** 단위로 지정되며, 1인치당 72포인트입니다. 예를 들어, 900 × 600 포인트는 12.5 × 8⅓ 인치에 해당합니다. 이러한 설정은 개별 슬라이드의 노트가 아니라 프레젠테이션 전체에 적용됩니다.

| 설정 | 목적 |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/notessize/) | 노트 페이지 차원을 제어하고 유인물 내보내기에 사용되는 페이지 차원을 제어합니다. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/slidesize/) | [ISlideSize](https://reference.aspose.com/slides/ko/net/aspose.slides/islidesize/)를 통해 정규 프레젠테이션 슬라이드 차원을 제어합니다. |

두 설정 중 하나를 변경해도 다른 설정이 자동으로 변경되지 않습니다. 노트 페이지 방향을 변경해도 정규 슬라이드가 회전하지 않습니다. 정규 슬라이드 크기를 조정하려면 [Slide Size](/slides/ko/net/slide-size/)를 참조하십시오.

아래 예제들은 기존 `sample.pptx` 파일을 사용합니다. 내보내기 예제의 경우, 발표자 노트가 포함된 슬라이드가 최소 하나 있는 프레젠테이션을 사용하십시오. 각 예제는 독립적으로 실행할 수 있습니다.

## **노트 페이지 크기 및 방향 읽기**

너비와 높이를 읽어 비교하여 방향을 결정합니다: 페이지가 더 넓으면 가로형, 더 높으면 세로형, 차원이 동일하면 정사각형 페이지입니다. 이 예제는 표준 용지 크기를 가정하지 않고 실제 포인트 단위 크기를 출력합니다.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **용지 크기를 변경하지 않고 가로형으로 전환**

Orientation만 변경하려면 기존 너비와 높이를 서로 교환하면 됩니다. 이렇게 하면 사용자 정의 용지 크기를 포함한 양쪽 길이가 보존됩니다. 아래 조건은 이미 가로형인 페이지가 세로형으로 전환되는 것을 방지하고 정사각형 페이지는 변경되지 않도록 합니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

세로형 방향의 경우 `size.Width > size.Height`일 때 동일한 할당을 사용하십시오. 용지 크기도 변경하려는 경우가 아니라면 A4 또는 Letter 크기로 대체하지 마십시오.

## **사용자 정의 노트 페이지 크기 설정 및 검증**

두 차원을 함께 할당한 뒤 [Presentation.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/)를 사용하여 프레젠테이션을 저장합니다. 이 예제는 900 × 600 포인트 가로형 페이지를 설정하고 PPTX 형식으로 저장한 후, 저장된 파일을 다시 열어 지속된 값을 확인합니다. 비교 시 부동소수점 값에 대해 0.01 포인트 허용 오차를 적용합니다; 이는 모든 파일 형식에 대한 정밀성을 보장하지는 않습니다.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

예상 결과는 `900 x 600 points` 와 `Size preserved: True` 입니다. 새로 연 프레젠테이션을 검사하면 메모리 내 설정만이 아니라 저장된 파일을 검증합니다.

## **노트 및 유인물 내보내기**

페이지 차원은 노트 또는 유인물 레이아웃에 사용할 수 있는 영역을 정의합니다. 이 차원만으로 해당 레이아웃이 활성화되는 것은 아니며, 내보내기 옵션도 설정해야 합니다. 정규 슬라이드 내보내기는 슬라이드 차원을 계속 사용합니다.

### **노트를 PDF 및 PNG로 내보내기**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/notescommentslayoutingoptions/)를 [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/slideslayoutoptions/)에 할당하여 PDF에 노트를 포함합니다. 이 예제는 또한 [Slide.GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/getimage/)와 [RenderingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/renderingoptions/)를 사용해 노트가 포함된 첫 번째 슬라이드를 PNG로 렌더링합니다.

[BottomTruncated](https://reference.aspose.com/slides/ko/net/aspose.slides.export/notespositions/) 모드는 노트를 한 페이지에 유지하며, 페이지에 맞지 않는 노트는 잘릴 수 있습니다. PDF는 900 × 600 포인트 페이지를 사용합니다. 아래에서 사용한 1 × 1 이미지 스케일에서는 PNG가 900 × 600 픽셀이 됩니다. 포인트는 페이지 기하학을 나타내고, 픽셀은 렌더링 스케일에 따라 결정되는 래스터 출력의 크기를 나타냅니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

긴 노트가 있는 PDF 내보내기의 경우, [BottomFull](https://reference.aspose.com/slides/ko/net/aspose.slides.export/notespositions/)은 필요에 따라 추가 페이지를 허용합니다. 위의 단일 슬라이드 이미지 호출은 이를 지원하지 않으므로 해당 모드를 사용하지 마십시오. 크기 조정 후에는 잘린 노트와 기존 notes-master 객체의 배치를 확인하십시오; 페이지 차원만 변경한다고 모든 콘텐츠가 맞는 보장은 없습니다. 노트 내보내기에 대한 자세한 내용은 [Convert PowerPoint to PDF with Notes](/slides/ko/net/convert-powerpoint-to-pdf-with-notes/)를 참조하십시오.

### **유인물을 PDF로 내보내기**

[HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/handoutlayoutingoptions/)를 사용하여 한 페이지에 여러 슬라이드 썸네일을 배치합니다. 다음 예제는 900 × 600 포인트 페이지를 설정하고 [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ko/net/aspose.slides.export/handouttype/)를 사용해 페이지당 최대 네 개의 슬라이드를 배치합니다. 가로 프리셋은 슬라이드 순서를 제어하고, 페이지 방향은 너비와 높이에서 파생됩니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

페이지 크기를 변경하면 소스 슬라이드 차원을 바꾸지 않고 유인물 그리드에 사용할 수 있는 영역이 바뀝니다. 유인물 이미지를 만들 때는 개별 슬라이드 이미지 메서드 대신 유인물 레이아웃과 함께 [Presentation.GetImages](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/getimages/)를 사용하십시오. Aspose.Slides에서는 프레젠테이션 수준 유인물 렌더링이 노트 페이지 차원을 사용하지만, 개별 슬라이드 이미지 호출은 유인물 페이지를 생성하지 않습니다. 레이아웃 옵션에 대해서는 [Handout Mode](/slides/ko/net/convert-powerpoint-in-handout-mode/)를 확인하십시오.

## **뷰어, 내보내기 및 인쇄 시 페이지 크기**

저장된 프레젠테이션 크기, 내보낸 페이지 크기 및 인쇄된 용지 크기를 별도로 관리하십시오:

- **Presentation viewers:** 뷰어는 자체 레이아웃 규칙을 사용해 노트를 표시하거나 인쇄할 수 있습니다. 다른 애플리케이션이 파일을 저장한 경우 다시 열어 차원을 확인하십시오; 해당 애플리케이션의 형식 변환이 차원을 정규화할 수 있습니다.
- **Export formats:** 위의 노트 및 유인물 PDF 예제는 구성된 페이지 차원을 사용합니다. 래스터 이미지는 정수 픽셀 차원과 렌더링 스케일을 사용하므로, 소수점 포인트값은 이미지 출력 시 반올림될 수 있습니다. 정규 슬라이드 내보내기는 노트 페이지 크기를 적용하지 않습니다.
- **Printer drivers:** 용지 선택, 자동 회전 및 페이지 맞춤 설정은 프레젠테이션이나 PDF에 저장된 차원을 변경하지 않고 실제 출력에 영향을 줄 수 있습니다. 특정 용지 크기에 맞추려면 프린터 설정을 일치시키고 인쇄 미리보기를 확인하십시오.

## **FAQ**

**한 슬라이드에만 노트 크기를 설정할 수 있나요?**

노트 페이지 크기는 프레젠테이션 수준 설정입니다. 개별 슬라이드는 서로 다른 노트 내용을 가질 수 있지만, 이 속성은 각 슬라이드마다 별도의 페이지 크기를 제공하지 않습니다.

**노트 방향을 변경했는데 슬라이드가 바뀌지 않은 이유가 무엇인가요?**

노트 페이지와 정규 슬라이드는 독립적인 차원을 가지고 있습니다. 슬라이드 자체의 크기를 조정하려면 정규 슬라이드 크기 설정을 사용하십시오.

**저장하거나 인쇄한 결과가 다른 크기로 나오는 이유는 무엇인가요?**

먼저 저장된 프레젠테이션을 다시 열어 노트 차원을 비교하십시오. 차원이 변경되었다면 다른 애플리케이션에서 파일을 저장하거나 변환하면서 페이지 설정이 바뀌었을 수 있습니다. 변경되지 않았다면 내보내기 레이아웃, 이미지 스케일, 뷰어 설정 및 프린터 용지 선택을 확인하십시오.