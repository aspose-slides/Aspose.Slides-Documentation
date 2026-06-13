---
title: 섹션
type: docs
weight: 90
url: /ko/net/examples/elements/section/
keywords:
- 섹션
- 슬라이드 섹션
- 섹션 추가
- 섹션 액세스
- 섹션 제거
- 섹션 이름 바꾸기
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 슬라이드 섹션을 관리합니다: PPT, PPTX 및 ODP에 대한 C# 예제를 사용하여 슬라이드를 생성, 이름 바꾸기, 순서 변경 및 그룹화합니다."
---
Aspose.Slides for .NET를 사용하여 프레젠테이션 섹션을 프로그래밍 방식으로 추가, 액세스, 제거 및 이름 바꾸기 예제.

## **섹션 추가**

특정 슬라이드에서 시작하는 섹션을 생성합니다.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 섹션 시작을 표시하는 슬라이드를 지정합니다.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **섹션 액세스**

프레젠테이션에서 섹션 정보를 읽습니다.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // 인덱스로 섹션에 액세스합니다.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **섹션 제거**

이전에 추가된 섹션을 삭제합니다.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // 첫 번째 섹션을 제거합니다.
    presentation.Sections.RemoveSection(section);
}
```

## **섹션 이름 바꾸기**

기존 섹션의 이름을 변경합니다.

```csharp
static void RenameSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("Old Name", slide);

    var section = presentation.Sections[0];
    section.Name = "New Name";
}
```