---
title: ActiveX
type: docs
weight: 200
url: /ko/net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX 추가
- ActiveX 액세스
- ActiveX 제거
- ActiveX 속성
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ActiveX 예제를 확인하세요: 명확한 C# 코드를 사용하여 PPT 및 PPTX 프레젠테이션에서 ActiveX 객체를 삽입, 구성 및 제어합니다."
---
이 문서에서는 **Aspose.Slides for .NET**을 사용하여 프레젠테이션에 ActiveX 컨트롤을 추가, 액세스, 제거 및 구성하는 방법을 보여줍니다.

## **ActiveX 컨트롤 추가**

새 ActiveX 컨트롤을 삽입하고 선택적으로 해당 속성을 설정합니다.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 새 ActiveX 컨트롤을 추가합니다.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // 필요에 따라 일부 속성을 설정합니다.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **ActiveX 컨트롤 액세스**

슬라이드에 있는 첫 번째 ActiveX 컨트롤의 정보를 읽어옵니다.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // 첫 번째 ActiveX 컨트롤에 접근합니다.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **ActiveX 컨트롤 제거**

슬라이드에서 기존 ActiveX 컨트롤을 삭제합니다.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // 첫 번째 ActiveX 컨트롤을 제거합니다.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **ActiveX 속성 설정**

컨트롤을 추가하고 여러 ActiveX 속성을 구성합니다.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // CommandButton을 추가하고 속성을 구성합니다.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```