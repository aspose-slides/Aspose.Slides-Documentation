---
title: .NET에서 PPT를 PPTX로 변환
linktitle: PPT를 PPTX로
type: docs
weight: 20
url: /ko/net/convert-ppt-to-pptx/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPT를 PPTX로
- PPT를 PPTX로 저장
- PPT를 PPTX로 내보내기
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides를 사용하여 .NET에서 레거시 PPT 파일을 PPTX로 변환합니다. 단일 파일 및 배치 변환, 오류 처리, 정밀도에 관한 C# 예제가 포함되어 있습니다."
---
## **개요**

PPT는 레거시 바이너리 PowerPoint 형식이며, PPTX는 최신 Open XML 형식입니다. Aspose.Slides for .NET은 Microsoft PowerPoint 없이 PPT 파일을 로드하고 PPTX로 저장할 수 있습니다. 이 문서에서는 파일 하나 또는 디렉터리의 파일들을 변환하는 방법과 변환 후 확인해야 할 사항을 설명합니다.

## **PPT 파일을 PPTX로 변환**

소스 파일을 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스로 로드한 다음, [IPresentation.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/save/) 메서드를 [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveformat/) 인수와 함께 호출합니다. `using` 선언은 스코프가 끝날 때 프레젠테이션을 해제하고 리소스를 반환합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// 레거시 PPT 프레젠테이션을 로드합니다.
using var presentation = new Presentation("presentation.ppt");

// 프레젠테이션을 PPTX 형식으로 저장합니다.
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

파일 확장자는 자체적으로 출력 형식을 선택하지 않으며, [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveformat/) 인수가 선택합니다. 원본 PPT 파일을 보존해야 한다면 입력 경로와 출력 경로를 다르게 지정하십시오.

## **여러 PPT 파일 변환**

다음 예제는 하나의 디렉터리에 있는 모든 `.ppt` 파일을 변환합니다. 각 파일은 독립적으로 처리되므로 하나의 변환이 실패해도 나머지 배치가 중단되지 않습니다.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

프로덕션 환경에서는 전체 예외를 기록하고, 기존 출력 파일을 덮어쓸지 여부를 결정하며, 실패한 파일명을 재시도 또는 검토 큐에 기록하십시오. 손상된 파일, 비밀번호가 필요한 파일을 비밀번호 없이 열려는 경우, 접근할 수 없는 경로, 지원되지 않는 콘텐츠 등은 모두 변환 실패의 원인이 될 수 있습니다. 암호화된 파일 로드 방법은 [Password‑Protected Presentations](/slides/ko/net/password-protected-presentation/)를 참고하십시오.

## **정밀도 및 레거시 기능**

변환은 일반적으로 슬라이드, 마스터, 레이아웃, 텍스트, 도형, 이미지, 표 및 차트를 보존합니다. 그러나 PPT와 PPTX는 모든 기능을 동일하게 표현하지 않으며, PPTX에 해당하지 않거나 라이브러리에서 지원하지 않는 레거시 기능은 정규화되거나 누락되거나 다르게 표시될 수 있습니다.

변환된 파일에 애니메이션, 전환, 임베드 또는 연결된 OLE 개체, ActiveX 컨트롤, 임베드 미디어, 흔하지 않은 글꼴 또는 VBA 매크로가 포함된 경우 반드시 확인하십시오. 일반 PPTX 파일은 매크로를 지원하지 않으므로 VBA가 필요할 경우 매크로 지원 워크플로를 사용해야 합니다. 또한 변환된 프레젠테이션이 열리거나 렌더링되는 환경에 필요한 글꼴 및 외부 리소스가 존재하는지도 검증하십시오.

중요 문서의 경우, 생성된 PPTX를 프로그래밍 방식으로 다시 열어 주요 슬라이드 수와 내용을 검사하고, 의도한 뷰어에서 외관 및 슬라이드쇼 동작을 비교하십시오. 성공적인 [IPresentation.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/save/) 호출이 모든 레거시 기능이 정확히 PPTX로 매핑되었다는 증거가 되지 않도록 주의하십시오.

## **PPTX를 사용해야 할 때**

프레젠테이션을 최신 PowerPoint 버전에서 편집하거나 Open XML 패키지를 사용하는 시스템과 교환하거나, 레거시 바이너리 PPT보다 검사 및 복구가 쉬운 형식으로 보관하려는 경우 PPTX를 사용하십시오. 변환된 프레젠테이션이 정밀도 검증을 통과할 때까지 원본 PPT를 보관하거나 롤백 복사본으로 유지하십시오.

PDF, HTML, 이미지, XPS 혹은 다른 출력 형식이 필요하다면, [Convert Presentations to Multiple Formats](/slides/ko/net/convert-presentation/)에 있는 형식별 가이드를 참고하고 모든 대상이 편집 가능한 PowerPoint 기능을 보존한다는 가정은 하지 마십시오.

## **온라인 변환기**

가끔 파일을 변환하거나 빠르게 비교하고 싶을 때는 [온라인 PPT to PPTX 변환기](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx) 를 사용할 수 있습니다. 반복 변환, 배치 처리 또는 애플리케이션 수준 오류 처리가 필요한 경우 .NET API를 사용하십시오.

## **관련 문서**

- [PPT와 PPTX](/slides/ko/net/ppt-vs-pptx/)
- [.NET에서 프레젠테이션 저장](/slides/ko/net/save-presentation/)
- [지원 파일 형식](/slides/ko/net/supported-file-formats/)
- [.NET에서 프레젠테이션 열기](/slides/ko/net/open-presentation/)

## **FAQ**

**Microsoft PowerPoint가 설치되지 않은 상태에서 PPT를 PPTX로 변환할 수 있나요?**

예. Aspose.Slides for .NET은 Microsoft PowerPoint 없이도 프레젠테이션 파일을 로드하고 저장할 수 있습니다.

**PPT‑to‑PPTX 변환이 모든 콘텐츠를 정확히 보존하나요?**

일반적인 프레젠테이션 콘텐츠는 보존하지만, 모든 레거시 또는 지원되지 않는 기능에 대해 정확한 정밀도가 보장되지는 않습니다. 매크로, OLE 또는 ActiveX 개체, 미디어, 특수 애니메이션 또는 흔하지 않은 글꼴이 포함된 경우 변환된 파일을 검토하십시오.

**암호가 보호된 PPT 파일을 변환할 수 있나요?**

예. 파일을 로드할 때 올바른 비밀번호를 제공하면 변환이 가능합니다. 비밀번호가 없거나 올바르지 않으면 로드 작업이 실패합니다.

**변환 후 PPT 파일을 삭제해야 하나요?**

원본 PPT 파일은 변환된 PPTX가 필요 뷰어와 워크플로에서 검증될 때까지 보관하십시오. 이렇게 하면 레거시 기능이 다르게 변환될 경우 롤백 복사본으로 사용할 수 있습니다.