---
title: .NET에서 프레젠테이션의 그리기 안내선 관리
linktitle: 그리기 안내선
type: docs
weight: 85
url: /ko/net/drawing-guides/
keywords:
- 그리기 안내선
- 수평 안내선
- 수직 안내선
- 정렬 안내선
- 슬라이드 보기
- 마스터 슬라이드
- 레이아웃 슬라이드
- 노트 마스터
- 유인물 마스터
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션에서 수평 및 수직 그리기 안내선을 추가하고, 접근하며, 제거합니다."
---
## **개요**

그리기 안내선은 조정 가능한 가로 및 세로 선으로, PowerPoint에서 프레젠테이션을 편집할 때 사용자가 도형을 일관되게 정렬하도록 돕습니다. 특히 응용 프로그램이 프레젠테이션을 생성하고 나중에 수동으로 다듬을 때 유용합니다. 응용 프로그램은 저자가 콘텐츠를 추가하거나 이동할 때 따라야 할 동일한 정렬 도구를 저장할 수 있습니다.

그리기 안내선은 편집 보조 도구이며 슬라이드 콘텐츠가 아닙니다. 슬라이드 쇼나 렌더링된 출력에 표시되지 않습니다. Aspose.Slides for .NET은 이를 [IDrawingGuidesCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/idrawingguidescollection/) 인터페이스를 통해 노출합니다. 안내선은 [IDrawingGuide](https://reference.aspose.com/slides/ko/net/aspose.slides/idrawingguide/) 로 표현되며 방향, 위치 및 색상을 가집니다.

위치는 해당 슬라이드 또는 마스터의 왼쪽 위 모서리에서 포인트 단위로 측정됩니다. 세로 안내선은 가로 좌표를 사용하며 일반적으로 0에서 슬라이드 너비 사이입니다. 가로 안내선은 세로 좌표를 사용하며 일반적으로 0에서 슬라이드 높이 사이입니다.

## **슬라이드 보기에서 안내선 추가**

일반 슬라이드를 편집하는 동안 표시되는 안내선을 관리하려면 [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/ko/net/aspose.slides/icommonslideviewproperties/drawingguides/)를 사용합니다. [Orientation](https://reference.aspose.com/slides/ko/net/aspose.slides/orientation/) 값과 포인트 단위 위치를 사용하여 [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/ko/net/aspose.slides/idrawingguidescollection/add/)를 호출합니다.

다음 예제는 슬라이드 중앙 오른쪽에 세로 안내선 하나와 아래쪽에 가로 안내선 하나를 추가합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **그리기 안내선 액세스**

기존 안내선에 접근하려면 [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/ko/net/aspose.slides/idrawingguidescollection/count/) 속성과 인덱서를 사용합니다. [IDrawingGuide.Orientation](https://reference.aspose.com/slides/ko/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/ko/net/aspose.slides/idrawingguide/position/), [IDrawingGuide.Color](https://reference.aspose.com/slides/ko/net/aspose.slides/idrawingguide/color/) 속성은 읽거나 변경할 수 있습니다.

다음 예제는 위에서 만든 프레젠테이션의 슬라이드 보기 안내선을 읽습니다:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **마스터 및 레이아웃 슬라이드에 안내선 추가**

슬라이드 마스터와 각 레이아웃 슬라이드마다 자체 그리기 안내선 컬렉션을 가질 수 있습니다. 마스터 슬라이드에는 [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslide/drawingguides/)를 사용하고 레이아웃 슬라이드에는 [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/drawingguides/)를 사용합니다.

다음 예제는 첫 번째 마스터 슬라이드에 세로 안내선을, 첫 번째 레이아웃 슬라이드에 가로 안내선을 추가합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **노트 및 유인물 마스터에 안내선 추가**

노트 마스터와 유인물 마스터도 그리기 안내선을 지원합니다. 해당 컬렉션에 접근하려면 [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/ko/net/aspose.slides/imasternotesslide/drawingguides/)와 [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterhandoutslide/drawingguides/)를 사용합니다. 프레젠테이션에 이러한 마스터가 포함되지 않은 경우, [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) 또는 [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/)가 기본 마스터를 생성하고 반환합니다.

다음 예제는 노트 마스터에 가로 안내선을, 유인물 마스터에 세로 안내선을 추가합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **그리기 안내선 제거**

[IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/ko/net/aspose.slides/idrawingguidescollection/clear/)를 호출하여 특정 컬렉션의 모든 안내선을 제거합니다. 하나의 컬렉션을 비워도 다른 범위에 저장된 안내선에는 영향을 주지 않습니다.

다음 예제는 누락된 마스터를 생성하지 않고 슬라이드 보기 안내선과 슬라이드 마스터, 레이아웃 슬라이드, 노트 마스터 및 유인물 마스터의 모든 안내선을 삭제합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **FAQ**

**그리기 안내선이 슬라이드 쇼나 내보낸 이미지에 표시됩니까?**

아니오. 그리기 안내선은 편집을 위한 정렬 보조 도구이며 프레젠테이션 콘텐츠로 렌더링되지 않습니다.

**그리기 안내선을 개별 일반 슬라이드에 직접 추가할 수 있습니까?**

일반 슬라이드 편집 안내선은 프레젠테이션의 슬라이드 보기 속성에 저장됩니다. 슬라이드 마스터, 레이아웃 슬라이드, 노트 마스터 및 유인물 마스터에 대한 별도 안내선 컬렉션이 제공됩니다.

**안내선 위치에 사용되는 단위는 무엇입니까?**

위치는 포인트 단위이며, 72포인트는 1인치에 해당합니다. 세로 위치는 왼쪽 가장자리에서 측정하고, 가로 위치는 위쪽 가장자리에서 측정합니다.

**그리기 안내선을 제거하면 도형이 삭제되거나 슬라이드 콘텐츠가 변경됩니까?**

아니오. `Clear` 메서드는 선택된 컬렉션의 안내선만 삭제합니다. 도형 및 기타 슬라이드 콘텐츠는 변경되지 않은 그대로 유지됩니다.