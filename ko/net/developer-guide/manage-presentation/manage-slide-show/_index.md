---
title: .NET에서 슬라이드 쇼 관리
linktitle: 슬라이드 쇼
type: docs
weight: 90
url: /ko/net/manage-slide-show/
keywords:
- 쇼 유형
- 발표자에 의해 제시
- 개인별 탐색
- 키오스크에서 탐색
- 쇼 옵션
- 지속적 루프
- 내레이션 없이 쇼
- 애니메이션 없이 쇼
- 펜 색상
- 슬라이드 표시
- 맞춤 쇼
- 슬라이드 전진
- 수동으로
- 타이밍 사용
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 슬라이드 쇼를 관리하는 방법을 학습하십시오. PPT, PPTX 및 ODP 형식 전반에 걸쳐 슬라이드 전환, 타이밍 및 기타 기능을 손쉽게 제어할 수 있습니다."
---
## **소개**

Microsoft PowerPoint에서 **슬라이드 쇼** 설정은 전문적인 프레젠테이션을 준비하고 전달하기 위한 핵심 도구입니다. 이 섹션에서 가장 중요한 기능 중 하나는 **Set Up Show**이며, 이를 통해 프레젠테이션을 특정 상황과 청중에 맞게 맞춤 설정하여 유연성과 편의성을 보장할 수 있습니다. 이 기능을 사용하면 쇼 유형(예: 발표자가 진행, 개인이 탐색, 키오스크에서 탐색)을 선택하고, 루핑을 켜거나 끌 수 있으며, 표시할 특정 슬라이드를 선택하고, 타이밍을 사용할 수 있습니다. 이러한 준비 단계는 프레젠테이션을 보다 효과적이고 전문적으로 만들기 위해 필수적입니다.

`SlideShowSettings`은 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 속성으로, 유형은 [SlideShowSettings](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/slideshowsettings/)이며 PowerPoint 프레젠테이션의 슬라이드 쇼 설정을 관리할 수 있게 해줍니다. 이 기사에서는 이 속성을 사용하여 슬라이드 쇼 설정의 다양한 측면을 구성하고 제어하는 방법을 살펴봅니다. 

## **쇼 유형 선택**

`SlideShowSettings.SlideShowType`은 슬라이드 쇼의 유형을 정의하며, 다음 클래스 중 하나의 인스턴스가 될 수 있습니다: [PresentedBySpeaker](https://reference.aspose.com/slides/ko/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/ko/net/aspose.slides/browsedbyindividual/), 또는 [BrowsedAtKiosk](https://reference.aspose.com/slides/ko/net/aspose.slides/browsedatkiosk/). 이 속성을 사용하면 자동 키오스크나 수동 프레젠테이션 등 다양한 사용 시나리오에 맞게 프레젠테이션을 조정할 수 있습니다.

아래 코드 예제는 새 프레젠테이션을 만들고 스크롤바를 표시하지 않은 상태에서 쇼 유형을 "Browsed by an individual"으로 설정합니다.

```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **쇼 옵션 활성화**

`SlideShowSettings.Loop`은 슬라이드 쇼를 수동으로 중지할 때까지 루프로 반복할지를 결정합니다. 이는 지속적으로 실행돼야 하는 자동 프레젠테이션에 유용합니다. `SlideShowSettings.ShowNarration`은 슬라이드 쇼 중에 음성 내레이션을 재생할지를 결정합니다. 이는 청중에게 음성 안내가 포함된 자동 프레젠테이션에 유용합니다. `SlideShowSettings.ShowAnimation`은 슬라이드 개체에 추가된 애니메이션을 재생할지를 결정합니다. 이는 프레젠테이션의 전체 시각 효과를 제공하는 데 유용합니다.

다음 코드 예제는 새 프레젠테이션을 만들고 슬라이드 쇼를 루프로 설정합니다.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **표시할 슬라이드 선택**

`SlideShowSettings.Slides` 속성을 사용하면 프레젠테이션 중에 표시할 슬라이드 범위를 선택할 수 있습니다. 전체 슬라이드가 아니라 프레젠테이션의 일부만 표시해야 할 때 유용합니다. 다음 코드 예제는 새 프레젠테이션을 만들고 슬라이드 범위를 `2`부터 `9`까지 표시하도록 설정합니다.

```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **슬라이드 자동 전환 사용**

`SlideShowSettings.UseTimings` 속성을 통해 각 슬라이드에 대한 사전 정의된 타이밍 사용을 활성화하거나 비활성화할 수 있습니다. 이는 미리 정의된 표시 기간으로 슬라이드를 자동으로 전환하는 데 유용합니다. 아래 코드 예제는 새 프레젠테이션을 만들고 타이밍 사용을 비활성화합니다.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **미디어 컨트롤 표시**

`SlideShowSettings.ShowMediaControls` 속성은 멀티미디어 콘텐츠(예: 비디오 또는 오디오)가 재생될 때 슬라이드 쇼 중에 재생, 일시 정지, 정지와 같은 미디어 컨트롤을 표시할지를 결정합니다. 프레젠테이션 중에 발표자가 미디어 재생을 제어할 수 있도록 할 때 유용합니다.

다음 코드 예제는 새 프레젠테이션을 만들고 미디어 컨트롤을 표시하도록 활성화합니다.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **FAQ**

**프레젠테이션을 저장하면 바로 슬라이드 쇼 모드로 열리게 할 수 있나요?**

예. 파일을 PPSX 또는 PPSM 형식으로 저장하면 PowerPoint에서 열었을 때 바로 슬라이드 쇼 모드로 실행됩니다. Aspose.Slides에서는 [during export](/slides/ko/net/save-presentation/) 해당 저장 형식을 선택합니다.

**프레젠테이션 파일에서 삭제하지 않고 개별 슬라이드를 쇼에서 제외할 수 있나요?**

예. 슬라이드를 [Hidden](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/hidden/)으로 표시하면 됩니다. 숨겨진 슬라이드는 프레젠테이션에 남아 있지만 슬라이드 쇼 중에는 표시되지 않습니다.

**Aspose.Slides가 슬라이드 쇼를 재생하거나 화면에서 실시간 프레젠테이션을 제어할 수 있나요?**

아니요. Aspose.Slides는 프레젠테이션 파일을 편집, 분석 및 변환하는 역할을 하며, 실제 재생은 PowerPoint와 같은 뷰어 애플리케이션에서 처리됩니다.