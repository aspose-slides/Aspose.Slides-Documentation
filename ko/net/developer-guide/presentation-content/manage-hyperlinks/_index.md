---
title: .NET에서 프레젠테이션 하이퍼링크 관리
linktitle: 하이퍼링크 관리
type: docs
weight: 20
url: /ko/net/manage-hyperlinks/
keywords:
- URL 추가
- 하이퍼링크 추가
- 하이퍼링크 만들기
- 하이퍼링크 서식 지정
- 하이퍼링크 제거
- 하이퍼링크 업데이트
- 텍스트 하이퍼링크
- 슬라이드 하이퍼링크
- 도형 하이퍼링크
- 이미지 하이퍼링크
- 비디오 하이퍼링크
- 가변 하이퍼링크
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 C# 예제로 PowerPoint 및 OpenDocument 프레젠테이션에서 하이퍼링크를 추가, 서식 지정, 업데이트 및 제거합니다."
---
## **소개**

하이퍼링크는 프레젠테이션 콘텐츠를 웹사이트나 프레젠테이션 내부의 위치와 연결합니다. PowerPoint에서 하이퍼링크는 일반적으로 두 가지 목적을 제공합니다:

* 텍스트, 도형 또는 미디어 프레임에서 웹사이트를 엽니다.
* 목차처럼 다른 슬라이드로 이동합니다.

Aspose.Slides for .NET을 사용하면 이러한 링크를 추가하고, 모양과 소리를 제어하며, 속성을 업데이트하고, 제거할 수 있습니다. 아래 예제에서는 개별 요소에 대한 하이퍼링크 작업 방법과 프레젠테이션, 슬라이드, 텍스트 프레임 수준에서 하이퍼링크에 접근하는 방법을 보여줍니다.

{{% alert color="info" title="참고" %}}
무료 온라인 Aspose PowerPoint 편집기([free online Aspose PowerPoint editor](https://products.aspose.app/slides/editor))로도 프레젠테이션을 편집할 수 있습니다.
{{% /alert %}}

## **URL 하이퍼링크 추가**

텍스트, 도형 또는 미디어 프레임에 웹사이트 URL을 할당할 수 있습니다. 하이퍼링크를 할당하는 요소에 따라 클릭 가능한 영역이 결정됩니다: 텍스트 부분은 선택된 텍스트에만 링크가 적용되고, 도형이나 프레임은 슬라이드 객체 전체에 링크가 적용됩니다.

프레젠테이션에 상대 하이퍼링크가 포함된 경우, 문서 수준 기본값을 읽고, 변경하고, 지우려면 [Manage the Hyperlink Base](/slides/ko/net/presentation-properties/#manage-the-hyperlink-base)를 참고하세요.

### **텍스트에 URL 하이퍼링크 추가**

텍스트를 웹사이트에 연결하려면, 아래와 같이 텍스트 부분의 [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) 속성에 [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/)을 할당합니다. 해당 텍스트 부분만 클릭 가능해집니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **도형 및 미디어 프레임에 URL 하이퍼링크 추가**

사각형의 [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) 속성에 URL을 할당하면 전체 영역이 클릭 가능해집니다. [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/)은 사용자가 사각형 위에 마우스를 올렸을 때 대상에 대한 힌트를 제공합니다. 동일한 속성은 그림, 오디오, 비디오 프레임에도 적용됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **하이퍼링크를 사용하여 목차 만들기**

내부 하이퍼링크를 사용하면 독자가 목차에서 특정 슬라이드로 이동할 수 있습니다. 다음 예제는 [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/)을 사용해 첫 번째 슬라이드의 “Page 2” 텍스트를 두 번째 슬라이드에 연결합니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **하이퍼링크 서식 지정**

링크된 텍스트 색상을 변경하고, 사용자가 링크를 활성화할 때 소리를 재생하거나 정지시키며, 마우스를 올렸을 때 표시되는 툴팁을 설정할 수 있습니다.

### **색상**

[IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/)의 [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) 속성은 하이퍼링크가 프레젠테이션의 기본 하이퍼링크 색상을 사용할지 텍스트 부분의 포맷팅을 사용할지를 결정합니다. 사용자 지정 텍스트 색상을 적용하려면 [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/)을 선택하고 부분의 채우기 색을 설정합니다. 이 기능은 PowerPoint 2019에서 도입되었으며, 이전 버전에서는 적용되지 않습니다.

이 예제에서는 첫 번째 링크에 [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/)를 설정해 텍스트가 빨간색으로 표시되게 합니다. 두 번째 링크는 프레젠테이션의 기본 하이퍼링크 색상을 유지합니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```

### **소리**

하이퍼링크는 활성화될 때 소리를 재생하거나 이미 재생 중인 소리를 정지시킬 수 있습니다. 다음 속성을 사용해 동작을 구성합니다:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/)은 하이퍼링크와 연결된 오디오를 지정합니다.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/)은 하이퍼링크를 활성화할 때 이전 소리를 정지시킬지 여부를 제어합니다.

#### **하이퍼링크 소리 추가**

첫 번째 슬라이드의 버튼은 [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/)을 사용해 사용자가 클릭하여 진행할 때 WAV 파일의 오디오를 재생합니다. 두 번째 슬라이드의 별도 버튼은 [StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/)을 사용해 재생을 중지하고 사용자를 해당 슬라이드에 머무르게 합니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **하이퍼링크 소리 추출**

다음 예제는 앞에서 만든 프레젠테이션을 열고, 첫 번째 도형의 하이퍼링크 오디오를 [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/)과 [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/)를 통해 메모리로 읽어옵니다.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **툴팁 및 상호 작용 설정**

텍스트나 도형에 하이퍼링크를 할당한 후 다음 [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) 속성을 업데이트할 수 있습니다:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/)은 뷰어가 링크에 대한 힌트로 표시할 텍스트를 설정합니다.
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/)은 적용 가능한 경우 상위 HTML 프레임셋 내 대상 프레임을 지정합니다.
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/)는 링크를 활성화했을 때 목적지가 조회된 하이퍼링크 목록에 추가되는지 여부를 제어합니다.
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/)은 클릭 시 하이퍼링크가 강조 표시되는지 여부를 제어합니다.

## **프레젠테이션에서 하이퍼링크 제거**

[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)을 사용해 텍스트-부분 링크를 포함한 하이퍼링크 컨테이너를 수집한 다음 변경합니다. 다음 예제는 첫 번째 슬라이드에서 두 가지 활성화 유형을 모두 제거합니다. 하나만 제거하려면 [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) 또는 [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)만 호출하면 됩니다; 클릭 동작을 제거해도 마우스 오버 동작은 남아 있습니다.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

조건 없이 모두 제거하려면 [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)가 선택된 범위에서 두 활성화 유형을 한 번에 삭제합니다. 마스터, 레이아웃, 노트 범위까지 선택적으로 정리하려면 [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)를 참고하세요.

### **SmartArt 텍스트 교체 전 하이퍼링크 지우기**

기존 SmartArt 노드에서 단락을 교체할 때, 텍스트 부분을 지우면 이전 하이퍼링크가 남아 있을 수 있습니다. [ISmartArtNode.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/textframe/)을 통해 단락을 가져온 뒤, 해당 노드 모양의 텍스트 프레임에서 [HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/)를 사용해 [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)를 호출합니다. 이렇게 하면 해당 프레임에 포함된 모든 하이퍼링크가 삭제됩니다.

예제에서는 첫 번째 슬라이드의 세 번째 도형이 SmartArt 그래픽이라고 가정하고, 네 번째 노드의 첫 번째 단락을 교체합니다. 이 프레젠테이션에서 해당 노드의 첫 번째 도형이 그 단락을 표시합니다.

두 부분을 추가한 뒤 예제는 [GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/)를 통해 실제 포맷을 읽습니다. 실제 [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/iportionformateffectivedata/hyperlinkclick/) 속성은 첫 번째 부분에 새로운 하이퍼링크를, 두 번째 부분에는 `null`을 반환합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("SmartArtHyperlink.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt)slide.Shapes[2];
var node = smartArt.AllNodes[3];
var paragraph = node.TextFrame.Paragraphs[0];

node.Shapes[0].TextFrame.HyperlinkQueries.RemoveAllHyperlinks();
paragraph.Portions.Clear();

var link = new Portion("New reference");
link.PortionFormat.HyperlinkClick = new Hyperlink("https://example.com/new");
paragraph.Portions.Add(link);
var text = new Portion(" (updated)");
paragraph.Portions.Add(text);

Console.WriteLine(link.PortionFormat.GetEffective().HyperlinkClick.ExternalUrl); // https://example.com/new
Console.WriteLine(text.PortionFormat.GetEffective().HyperlinkClick?.ToString() ?? "null"); // null
```

## **전체 하이퍼링크 인벤토리 구축**

프레젠테이션을 배포하기 전에 인터랙티브 액션과 웹 링크를 모두 조사하십시오. [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)는 URL 문자열 목록이 아니라 [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/) 객체를 반환합니다. 각 컨테이너의 [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/)과 [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/)를 모두 검사하십시오. 두 액션은 독립적이며, 동일 컨테이너가 두 동작을 모두 제공할 수 있으므로 완전한 보고서에는 컨테이너당 최대 두 행이 필요합니다.

도형 수준 하이퍼링크만 스캔하면 텍스트 부분에 연결된 링크를 놓칠 수 있습니다. 적절한 범위를 쿼리하고 반환된 컨테이너를 보관하면 나중에 액션을 업데이트하거나 제거할 수 있습니다.

### **프레젠테이션, 슬라이드 및 텍스트 프레임 범위 쿼리**

[IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) 인터페이스는 [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/), 그리고 [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/)를 통해 사용할 수 있습니다. 각 범위는 동일한 쿼리를 지원합니다:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/)은 클릭 액션이 있는 컨테이너를 반환합니다.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/)은 마우스 오버 액션이 있는 컨테이너를 반환합니다.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)은 하나 또는 두 액션을 가진 컨테이너를 반환합니다.

이 예제는 도형과 그 텍스트에 클릭 및 마우스 오버 액션을, 별도 버튼에 매크로 액션을 할당합니다. 그런 다음 [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)가 반환한 컨테이너 수를 각 활성화 유형별 카운트와 비교합니다. 텍스트 프레임 쿼리는 텍스트에만 있는 링크를 셉니다. 포함된 도형 자체 액션은 슬라이드 및 프레젠테이션 쿼리에 나타납니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

이 예제에서는 프레젠테이션과 슬라이드 쿼리 각각이 클릭 컨테이너 3개, 마우스 오버 컨테이너 2개, 전체 액션 컨테이너 3개를 보고합니다. 텍스트 프레임 쿼리는 각 카테고리마다 1개씩 보고합니다.

### **동작 및 대상 분류**

[IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/)을 사용해 동작을 해석한 뒤 대상을 해석하십시오. [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) 값은 단순 웹 탐색을 넘어서는 다양한 동작을 포함합니다:

| 값 | 감사 의미 |
| --- | --- |
| `Hyperlink` | 외부 하이퍼링크; URL 및 스킴을 검사합니다. |
| `JumpSpecificSlide` | 특정 슬라이드로 내부 이동. |
| `JumpFirstSlide` | `JumpPreviousSlide` | `JumpNextSlide` | `JumpLastSlide` | `JumpLastViewedSlide` | 기본 슬라이드 쇼 내비게이션, 슬라이드 쇼 컨텍스트에서 해석됩니다. |
| `JumpEndShow` | `StartCustomSlideShow` | 현재 쇼를 종료하거나 사용자 정의 쇼를 시작합니다. |
| `StartMacro` | 매크로 실행. |
| `StartProgram` | 프로그램 실행. |
| `OpenFile` | `OpenPresentation` | 파일 또는 다른 프레젠테이션을 엽니다; 웹 URL과 별도로 검토합니다. |
| `StartStopMedia` | 미디어 재생 시작 또는 정지. |
| `NoAction` | `Unknown` | 네비게이션 동작이 없거나 인식되지 않은 동작으로 검토가 필요합니다. |

외부 목적지는 [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/)에서, 내부 특정 목적지는 [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/)에서 읽어옵니다. 내부 동작 및 기본 슬라이드 쇼 명령은 외부 URL이 없을 수 있으며, 빈 URL가 컨테이너에 동작이 없다는 의미는 아닙니다. 정규화된 URL와 다를 경우 [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/)을 보존하고, 가능한 경우 [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/)을 포함하십시오.

### **하이퍼링크 보고, 정리 및 검증**

이 .NET 6+ 예제는 앞서 소개한 프레젠테이션을 열어 동작당 하나의 JSON 레코드를 작성합니다. 일반 슬라이드, 마스터, 레이아웃, 노트와 함께 노트 및 핸드아웃 마스터도 포함해 [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)를 사용해 컨테이너를 수집합니다. 참조 동등성을 이용해 각 컨테이너를 한 번만 카운트하고, 아래 정책을 적용한 뒤 저장된 프레젠테이션을 다시 열어 클릭 및 마우스 오버 동작을 확인합니다.

보고서는 1부터 시작하는 슬라이드 인덱스와 가능한 경우 [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/)를 기록합니다. [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/)은 지원되는 컨테이너에 대해 소유 슬라이드를 제공합니다. 마스터, 레이아웃, 노트는 일반 슬라이드 인덱스가 없으며 범위로 식별됩니다. 도형 컨테이너와 텍스트-부분 포맷팅 컨테이너는 별도로 라벨링되며, 다른 컨테이너 유형은 런타임 타입 이름을 유지합니다. 각 컨테이너는 보고서 내 로컬 ID를 부여받아 두 동작을 연관시킬 수 있습니다.

이 제한적인 정책은 절대 HTTPS URL과 유효한 내부 슬라이드 대상만 허용합니다. 매크로, 프로그램, 파일 동작, 기타 슬라이드 쇼 동작, 알 수 없는 동작 및 기타 URL 스킴은 거부합니다. 이러한 거부는 정책 결정일 뿐 Aspose.Slides 안전성 판단이 아닙니다. HTTPS만으로 신뢰가 보장되지 않으며, 호스트 허용 목록 및 기타 검증을 추가해야 합니다. 원본과 정규화된 외부 URL 모두 검증됩니다. 예제는 링크를 따라가거나 동작을 실행하지 않고 메타데이터만 감사합니다.

수정이 필요할 경우, 컨테이너의 [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/)는 [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/), [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)를 지원합니다. 여기서는 금지된 외부 클릭 링크를 고정된 HTTPS 랜딩 페이지로 교체하고, 다른 금지된 클릭 및 마우스 오버 동작은 독립적으로 제거합니다. `replaceExternalClicks`를 `false`로 설정하면 모든 정책 위반을 제거합니다. 배포 전에 애플리케이션이 소유한 교체 페이지를 선택하세요.

보고서의 내보내기 플래그는 보수적인 PDF 검토 정책을 사용합니다: 마우스 오버 동작 및 외부 링크가 아닌 모든 동작을 잠재적으로 지원되지 않음으로 표시합니다. 이는 검토 힌트이며, 플래그가 없는 링크가 내보내기에서 유지된다는 보장은 아닙니다. 지원되는 [PDF](/slides/ko/net/convert-powerpoint-to-pdf/) 및 [HTML](/slides/ko/net/convert-powerpoint-to-html/) 내보내기는 동작, 옵션 및 뷰어에 따라 하이퍼링크를 보존할 수 있습니다. 래스터 [images](/slides/ko/net/convert-powerpoint-to-png/)와 [video](/slides/ko/net/convert-powerpoint-to-video/)는 인터랙티브 하이퍼링크를 보존할 수 없으며, 이러한 출력에 대해 감사할 때는 모든 동작을 플래그하십시오.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

위에서 만든 입력으로 보고서는 다섯 개의 동작 행을 포함합니다. 파일 마우스 오버 링크와 매크로 클릭이 제거되고, HTTPS 링크와 내부 슬라이드 탐색은 유지됩니다. 검증은 금지된 동작이 없음을 출력합니다. 금지된 외부 클릭 URL을 포함한 입력은 교체 분기를 실행합니다. 허용된 클릭과 금지된 마우스 오버가 있는 컨테이너는 클릭 동작을 유지합니다.

이 선택적 정리는 정책에 따라 [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)이 수행하는 전체 제거와 다릅니다. 여기서 검증은 하이퍼링크 동작만 확인하며, VBA 프로젝트, OLE 객체 등 다른 활성 콘텐츠를 제거하지 않고, 내보낸 PDF 또는 HTML 파일을 검증하지도 않습니다.

## **FAQ**

**섹션 또는 해당 섹션의 첫 슬라이드에 어떻게 연결합니까?**

PowerPoint의 섹션은 슬라이드를 그룹화하지만, 내부 하이퍼링크는 개별 슬라이드를 대상으로 합니다. 섹션으로 이동하려면 해당 섹션의 첫 슬라이드에 링크를 걸어야 합니다.

**마스터 슬라이드 요소에 하이퍼링크를 붙여 모든 슬라이드에서 동작하도록 할 수 있나요?**

예. 마스터 슬라이드와 레이아웃 요소는 하이퍼링크를 지원합니다. 이러한 요소에 대한 링크는 해당 마스터 또는 레이아웃을 사용하는 슬라이드 쇼 동안 사용할 수 있습니다.

**PDF, HTML, 이미지 또는 비디오로 내보낼 때 하이퍼링크가 유지되나요?**

지원되는 PDF와 HTML 내보내기는 동작에 따라 하이퍼링크를 보존할 수 있습니다. 래스터 이미지와 비디오는 인터랙티브 하이퍼링크를 보존할 수 없습니다. 자세한 내용은 [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) 섹션을 확인하십시오.