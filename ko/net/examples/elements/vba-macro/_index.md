---
title: VBA 매크로
type: docs
weight: 150
url: /ko/net/examples/elements/vba-macro/
keywords:
- VBA 매크로
- VBA 매크로 추가
- VBA 매크로 액세스
- VBA 매크로 제거
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 프레젠테이션을 자동화합니다: PPT, PPTX 및 ODP에서 VBA 매크로를 생성, 실행, 가져오고 보호하는 명확한 C# 예제."
---
이 문서에서는 **Aspose.Slides for .NET**을 사용하여 VBA 매크로를 추가하고, 액세스하고, 제거하는 방법을 보여줍니다.

## **VBA 매크로 추가**

VBA 프로젝트와 간단한 매크로 모듈을 포함하는 프레젠테이션을 생성합니다.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **VBA 매크로 액세스**

VBA 프로젝트에서 첫 번째 모듈을 가져옵니다.

```csharp
static void AccessVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    var firstModule = presentation.VbaProject.Modules[0];
}
```

## **VBA 매크로 제거**

VBA 프로젝트에서 모듈을 삭제합니다.

```csharp
static void RemoveVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    presentation.VbaProject.Modules.Remove(module);
}
```