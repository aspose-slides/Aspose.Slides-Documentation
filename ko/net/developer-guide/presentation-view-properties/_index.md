---
title: .NET에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/net/presentation-view-properties/
keywords:
- 보기 속성
- 일반 보기
- 개요 내용
- 개요 아이콘
- 세로 스플리터 스냅
- 단일 보기
- 바 상태
- 차원 크기
- 자동 조정
- 기본 확대/축소
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션에서 일반 보기 레이아웃, 슬라이드 및 노트 확대/축소, 격자 간격 및 주석 표시 여부를 구성합니다."
---
## **소개**

PowerPoint의 일반 보기에서 슬라이드는 썸네일 또는 개요용 사이드 창과 아래의 노트 창 사이에 표시됩니다. Aspose.Slides for .NET은 [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/)를 통해 프레젠테이션에 저장된 편집 기본 설정을 노출합니다. 여기에는 창 레이아웃, 확대/축소 수준, 격자 간격 및 주석 표시 여부가 포함됩니다.

## **INormalViewProperties에 대해**

[NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/)를 사용하여 [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/) 인터페이스에 액세스합니다. [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/)는 개요에서 슬라이드 제목 옆에 아이콘을 표시할지 여부를 제어합니다. [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/)는 사용자가 사이드 창을 좁힐 때 창이 최소화 상태에 스냅하도록 합니다. [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/)는 전체 창에서 하나의 창만 표시하도록 하는 기본 설정을 나타냅니다.

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/)는 사이드 창과 슬라이드 사이의 구분자를 제어합니다. [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/)는 노트 창 위의 구분자를 제어합니다. 두 속성 모두 `Minimized`, `Maximized`, 또는 `Restored` 값의 [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/)을 허용합니다.

## **INormalViewProperties 복원에 대해**

구분자가 복원될 때, [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/)은 사이드 창의 저장된 크기를 제공하고, [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/)은 상단 슬라이드 영역의 저장된 크기를 제공합니다. 두 속성 모두 [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/)를 노출합니다. 해당 인터페이스의 [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) 속성은 0에서 100 사이의 백분율을 허용하며, [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/)는 창 크기가 조정될 때 편집기가 크기를 자동으로 조정할지 여부를 제어합니다.

이 예제는 기존 프레젠테이션을 업데이트합니다. 가로 구분자를 복원하고, [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/)을 자동 조정이 활성화된 상태에서 80%로 설정하며, 세로 구분자를 최대화합니다. 또한 개요 보기에서 [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/)를 활성화합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **기본 확대/축소 값 설정**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/)와 [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/)는 편집기용 독립적인 확대/축소 설정을 저장합니다. 이러한 설정은 슬라이드 크기, 슬라이드 쇼 재생 또는 이미지 내보내기 해상도에 영향을 주지 않습니다.

이 예제는 기존 프레젠테이션을 열고 [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/)을 활성화하여 슬라이드가 편집 창에 맞도록 합니다. 노트 페이지의 경우 자동 스케일링을 비활성화하고 [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/)을 고정된 80% 확대/축소로 설정합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **격자 간격 설정**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/)은 프레젠테이션 전체에서 편집 격자선 사이의 거리를 설정합니다. 인치는 72 포인트이므로 양의 포인트 값을 사용합니다. 이 예제는 기존 프레젠테이션의 현재 간격을 출력하고, 간격을 18 포인트(¼인치)로 설정하여 ¼인치 격자를 저장합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

격자는 고정된 간격으로 반복됩니다. [Drawing guides](/slides/ko/net/drawing-guides/)는 개별 수평 또는 수직 위치를 표시합니다. 두 기능 모두 편집 보조 도구이며 해당 기능을 표시하는 편집기에서만 나타납니다. 슬라이드 쇼와 PDF, 이미지, SVG로의 내보내기에서는 표시되지 않습니다.

## **프레젠테이션 열 때 주석 표시 또는 숨기기**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/)은 호환 편집기가 프레젠테이션을 열 때 사용할 기본 설정을 저장합니다. 주석이 있는 기존 프레젠테이션의 경우, 이 예제는 현재 설정을 출력하고 주석이 숨겨진 사본을 저장합니다. 또한 [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/)를 [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/)로 설정하여 사본이 슬라이드 보기로 열리도록 합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

주석을 숨겨도 텍스트, 작성자, 위치, 답글 및 상태는 보존됩니다. 주석 자체를 변경하려면 [Presentation Comments](/slides/ko/net/presentation-comments/)를 참조하십시오. 내보내기 설정은 PDF, HTML, 이미지, 노트 또는 유인물에 주석을 표시할지 여부를 제어합니다.

## **FAQ**

**프레젠테이션을 다시 열었을 때 격자가 숨겨지는 이유는 무엇인가요?**

프레젠테이션은 격자 간격을 저장합니다. 격자를 보려면 편집기에서 격자 표시를 활성화하십시오.

**가이드를 삭제해도 격자 간격이 변경되나요?**

아니요. 가이드를 추가, 이동 또는 삭제해도 격자 간격은 변하지 않습니다.

**프레젠테이션의 서로 다른 섹션에 서로 다른 보기 설정을 적용할 수 있나요?**

아니요. [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/)는 전체 프레젠테이션에 적용됩니다.

**다른 사용자별로 다른 보기 설정을 저장할 수 있나요?**

파일은 모든 사용자에 대해 하나의 보기 속성 세트만 저장합니다. 편집기는 사용자의 로컬 기본 설정을 적용할 수도 있습니다.

**템플릿에 보기 설정을 저장할 수 있나요?**

예. 템플릿에서 만든 프레젠테이션은 저장된 보기 설정을 상속합니다.