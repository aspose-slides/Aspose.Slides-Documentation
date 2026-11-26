---
title: .NET에서 프레젠테이션의 ActiveX 컨트롤 관리
linktitle: ActiveX
type: docs
weight: 80
url: /ko/net/activex/
keywords:
- ActiveX
- ActiveX 컨트롤
- ActiveX 관리
- ActiveX 추가
- ActiveX 수정
- 미디어 플레이어
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션에서 ActiveX 텍스트 상자와 버튼을 편집하고, 컨트롤 미리보기를 업데이트하며, Windows Media Player 컨트롤을 재사용합니다."
---
## **소개**

ActiveX 컨트롤은 텍스트 상자, 명령 단추 및 미디어 플레이어와 같은 대화형 요소를 PowerPoint 슬라이드에 제공합니다. Aspose.Slides for .NET은 슬라이드의 컨트롤을 [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/)를 통해 노출합니다. 이 컬렉션을 사용하여 컨트롤을 편집하고, 슬라이드에서 이동시키며, 제거할 수 있습니다.

## **ActiveX 컨트롤 및 저장된 속성 목록**

익숙하지 않은 템플릿을 검사하려면 템플릿을 읽기 모드로 열고 각 슬라이드의 컨트롤을 반복합니다. 예제는 슬라이드 번호, 컨트롤 이름, [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/), 및 [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties)의 각 키-값 쌍을 보고합니다. 컨트롤을 활성화하거나 이벤트·매크로를 호출하거나 값을 변경하거나 파일을 저장하지 않고 프레젠테이션을 읽습니다.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
}
```

`ActiveX.pptm`에서 선택된 출력은 텍스트 상자와 명령 단추를 보여줍니다.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

빈 속성 컬렉션은 `[]` 로 표시됩니다. 이진 저장소를 사용하는 컨트롤의 경우 `Properties`가 `null`을 반환할 수 있으며, 이는 `Properties unavailable` 로 표시됩니다. 이름만 필요하면 null 확인 후 [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/)를 사용하십시오. 보고서는 프레젠테이션에서 사용할 수 있는 속성을 나열합니다. 컨트롤은 런타임에 추가 속성을 지원할 수 있습니다.

## **ActiveX 컨트롤 수정**

예제는 첫 번째 슬라이드에 `TextBox1`이라는 텍스트 상자와 `CommandButton1`이라는 명령 단추가 포함된 매크로 사용 프레젠테이션을 예상합니다. 텍스트 상자 값과 단추 캡션을 변경하려면 [컨트롤 속성 컬렉션](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/)을 사용합니다. 각 컨트롤은 활성화 전에 PowerPoint이 표시할 수 있는 정적 미리보기를 갖습니다. 업데이트된 텍스트와 모양을 보여주는 PNG를 각 컨트롤에 제공하십시오. 예제는 이러한 이미지를 [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/)을 통해 할당합니다.

예제는 첫 번째 슬라이드의 모든 컨트롤을 [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/)을 변경하여 100포인트 아래로 이동시킵니다. 편집된 프레젠테이션을 PPTM 형식으로 저장한 후, [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/)을 사용하여 해당 슬라이드에서 모든 ActiveX 컨트롤을 제거한 두 번째 복사본을 저장합니다.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```

## **ActiveX 미디어 플레이어 컨트롤 추가**

구성된 Windows Media Player 컨트롤을 재사용하려면 첫 번째 슬라이드에 `WindowsMediaPlayer1`이라는 플레이어가 포함된 템플릿으로 시작합니다. [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/)은 전체 슬라이드를 새 프레젠테이션으로 복사합니다. 예제는 플레이어의 `URL`을 [속성 컬렉션](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/)에 설정하고 복제된 슬라이드를 출력의 유일한 슬라이드로 저장합니다. 비디오는 외부에 남아 있으므로 재생 중에 플레이어가 접근할 수 있는 경로를 선택하십시오.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```

## **자주 묻는 질문**

**Aspose.Slides가 ActiveX 컨트롤을 실행하지 않고 보존할 수 있나요?**

예. Aspose.Slides는 컨트롤을 활성화하지 않고도 해당 속성과 위치를 포함하여 읽고 저장할 수 있습니다.

**ActiveX 컨트롤은 OLE 객체와 어떻게 다릅니까?**

ActiveX 컨트롤은 사용자가 텍스트를 입력하거나 버튼을 클릭하는 등 슬라이드와 상호 작용할 수 있게 합니다. [OLE object](/slides/ko/net/manage-ole/)는 슬라이드가 Excel 워크시트와 같은 다른 응용 프로그램에서 관리되는 콘텐츠를 포함하거나 연결하도록 합니다.

**Aspose.Slides로 프레젠테이션을 저장한 후에도 ActiveX 이벤트가 VBA 매크로를 트리거합니까?**

프레젠테이션을 PPTM과 같은 매크로 사용 형식으로 저장하면 VBA 프로젝트가 유지됩니다. Windows용 PowerPoint는 보안 설정에서 ActiveX 컨트롤과 매크로 모두를 허용할 경우 기존 이벤트 처리기를 실행할 수 있습니다.