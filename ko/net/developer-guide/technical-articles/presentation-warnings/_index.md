---
title: .NET에서 프레젠테이션 경고 처리
type: docs
weight: 120
url: /ko/net/presentation-warnings/
aliases:
- /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 경고 콜백
- 경고 정책
- 데이터 손실
- 소스 손상
- 호환성 문제
- 글꼴 대체
- 디지털 서명
- 프레젠테이션 로드
- 프레젠테이션 렌더링
- 프레젠테이션 변환
- 프레젠테이션 저장
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 프레젠테이션을 로드, 렌더링, 변환 및 저장하는 동안 경고를 수집하고 분류하며 처리하는 방법을 배우세요."
---
## **개요**

Aspose.Slides는 프레젠테이션을 로드, 렌더링, 변환 또는 저장하는 동안 복구 가능한 문제를 보고할 수 있습니다. 예시로는 손상된 원본 레코드, 보존할 수 없는 콘텐츠, 글꼴 대체 및 대상 형식의 제한 등이 있습니다. 경고 콜백을 사용하면 애플리케이션이 이러한 상황을 기록하고 현재 작업을 계속 진행할지 여부를 결정할 수 있습니다.

[IWarningCallback](https://reference.aspose.com/slides/ko/net/aspose.slides.warnings/iwarningcallback/) 인터페이스를 구현하고 [IWarningInfo](https://reference.aspose.com/slides/ko/net/aspose.slides.warnings/iwarninginfo/)를 통해 제공되는 [WarningType](https://reference.aspose.com/slides/ko/net/aspose.slides.warnings/iwarninginfo/warningtype/) 및 [Description](https://reference.aspose.com/slides/ko/net/aspose.slides.warnings/iwarninginfo/description/) 속성을 확인합니다. 경고를 수락하려면 [ReturnAction.Continue](https://reference.aspose.com/slides/ko/net/aspose.slides.warnings/returnaction/)을 반환하고, 작업을 중단하려면 `ReturnAction.Abort`를 반환합니다.

프레젠테이션을 여는 동안 발생하는 경고는 [LoadOptions.WarningCallback](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/warningcallback/)을 사용합니다. 렌더링 및 내보내기 옵션 클래스는 [SaveOptions.WarningCallback](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveoptions/warningcallback/)을 상속하며, 슬라이드 렌더링, 변환 및 저장 시 경고를 수신합니다. 경고 자체만으로는 애플리케이션 작업을 식별할 수 없으므로, 결합된 보고서를 작성할 때 각 콜백 인스턴스를 작업 단계와 연결하십시오.

## **경고 및 예외**

경고는 콜백이 `ReturnAction.Continue`를 반환하면 Aspose.Slides가 복구할 수 있는 상황을 설명합니다. 예외는 요청된 작업을 정상적으로 완료할 수 없음을 의미하며, 예외는 경고로 변환되지 않고 경고 정책으로 처리할 수 없습니다.

`ReturnAction.Abort`를 반환하면 경고 디스패처가 예외를 발생시켜 현재 작업을 종료하도록 요청합니다. 공개 예외는 작업 및 프레젠테이션 형식에 따라 달라집니다. 예를 들어, 로드 중에는 [PptxReadException](https://reference.aspose.com/slides/ko/net/aspose.slides/pptxreadexception/) 또는 [PptReadException](https://reference.aspose.com/slides/ko/net/aspose.slides/pptreadexception/)가 발생할 수 있고, 저장 또는 내보내기 중에는 [PptxException](https://reference.aspose.com/slides/ko/net/aspose.slides/pptxexception/)가 발생할 수 있습니다. 작업 경계에서 예외를 처리하고 경고 보고서를 사용하여 애플리케이션 정책이 종료를 초래했는지 판단하십시오. 콜백은 `ReturnAction.Abort`를 반환하기 전에 경고를 기록하므로 이유가 애플리케이션에 남아 있습니다.

## **경고 카테고리**

[WarningType](https://reference.aspose.com/slides/ko/net/aspose.slides.warnings/warningtype/) 열거형은 다음 카테고리를 제공합니다.

| 경고 유형 | 의미 | 일반적인 정책 |
| --- | --- | --- |
| `SourceFileCorruption` | 원본 프레젠테이션에 손상이 있어 원래 형식으로 저장된 문서를 사용할 수 없게 될 수 있습니다. | Abort. |
| `DataLoss` | 로드 또는 저장 후 텍스트, 차트, 이미지 등 일부 데이터가 누락될 수 있습니다. | Abort. |
| `MajorFormattingLoss` | 프레젠테이션에서 중요한 서식이 손실될 수 있습니다. | Strict 검증 모드에서는 Abort; 그 외 경우에는 기록하고 계속 진행. |
| `MinorFormattingLoss` | 제한된 서식 차이가 발생할 수 있습니다. | 진단을 위해 기록하고 계속 진행. |
| `CompatibilityIssue` | 결과가 일부 애플리케이션이나 이전 버전에서 열리지 않거나 올바르게 동작하지 않을 수 있습니다. | 호환성이 필수적이지 않다면 로그에 남기고 계속 진행. |
| `UnexpectedContent` | 원본에 지원되지 않거나 인식되지 않는 콘텐츠가 포함되어 그 영향을 알 수 없습니다. | 기록하고 계속 진행하거나, 엄격한 정책에서는 오류로 처리. |

카테고리는 정책 결정을 주도해야 합니다. 진단을 위해 `Description`을 저장하되, 경고 시나리오와 제품 버전에 따라 메시지 텍스트가 달라질 수 있으므로 애플리케이션 로직에서는 해당 문구에 의존하지 마십시오.

## **경고 수집 및 분류**

다음 예제는 전체 처리 파이프라인에 대한 애플리케이션 수준 보고서를 사용합니다. 별도의 콜백 인스턴스가 로드, 렌더링, PDF 변환 및 PPTX 저장 단계의 경고에 레이블을 지정합니다. 정책은 소스 손상 또는 데이터 손실 시 중단하고, 주요 서식 손실 시 선택적으로 중단하며, 기타 경고는 계속 진행합니다.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

주요 서식 차이가 허용되는 경우 `abortOnMajorFormattingLoss`를 `false`로 설정합니다. 호환성 문제, 소규모 서식 손실 및 예상치 못한 콘텐츠는 작업이 계속되더라도 보고서에 남습니다. 필요에 따라 `WarningPolicy.GetAction`을 확장하여 해당 카테고리를 거부하도록 구현하십시오.

## **일반적인 경고 시나리오**

경고는 워크플로우의 다양한 단계에서 나타날 수 있습니다:

- **디지털 서명:** 서명된 프레젠테이션을 로드할 때 서명이 처리 중에 손실된다는 경고가 발생할 수 있습니다. Aspose.Slides는 이 `DataLoss` 상황을 [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ko/net/aspose.slides.warnings/ipresentationsignedwarninginfo/)를 통해 보고합니다. 로드 단계 콜백을 사용해 파일을 거부하거나 보고된 손실을 명시적으로 수락할 수 있습니다.
- **글꼴 대체:** 슬라이드가 렌더링되거나 내보내질 때 사용할 수 없는 글꼴이 대체될 수 있습니다. 글꼴 대체 경고는 `DataLoss`로 보고되므로, 위의 엄격한 정책에서는 애플리케이션이 시각적으로 허용 가능하더라도 중단됩니다. 런타임에 없는 글꼴이 사용된 입력 프레젠테이션을 사용해 이 동작을 확인하십시오. 경고 설명에 대체 내용이 표시되므로 필요한 글꼴을 구성하거나 [폰트 대체 규칙](/slides/ko/net/font-substitution/)을 설정한 후 다시 시도하십시오.
- **지원되지 않거나 예상치 못한 콘텐츠:** 로더가 인식하지 못하는 프레젠테이션 레코드나 기능을 만나면 경고가 발생합니다. 이러한 경우 `UnexpectedContent` 또는 데이터·서식이 영향을 받는 경우 더 심각한 카테고리가 사용될 수 있습니다.
- **형식 호환성:** 다른 프레젠테이션 형식으로 저장하면 기능이 누락되거나 일부 애플리케이션에서 동작이 달라질 수 있습니다. 예를 들어, 레거시 PPT로 저장할 때 수평 가이드 8개 이상 또는 수직 가이드 8개 이상이 있는 경우 `CompatibilityIssue`가 보고됩니다. 저장 단계 콜백은 손실을 기록하고 계속 진행하거나, 모든 가이드를 보존해야 한다면 거부할 수 있습니다.
- **로드 동작:** 로드 옵션 및 레거시 동작도 경고를 발생시킬 수 있습니다. 예를 들어, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ko/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/)는 오래된 프레젠테이션 잠금 동작 사용을 `CompatibilityIssue`로 식별합니다.

경고는 소스 문서, 대상 형식, 작업 및 Aspose.Slides 버전에 따라 달라집니다. 모든 파일이 경고를 발생시키거나 시나리오가 하나의 카테고리만에 해당한다고 가정하지 마십시오.

## **중단된 작업을 안전하게 처리**

콜백이 `ReturnAction.Abort`를 반환하면 로드에 실패한 객체를 사용하지 말고, 렌더링이나 저장 결과가 완전하다고 가정하지 마십시오. 작업은 출력 파일을 생성한 뒤에도 완료되기 전에 종료될 수 있습니다.

검증된 결과를 `validated-output.pptx`와 같은 별도 경로에 저장하십시오. 기존 프레젠테이션을 교체하는 작업은 전체 작업이 성공적으로 끝나고 경고 보고서가 정책을 만족하며 출력 파일을 열어 확인한 경우에만 수행하십시오. 이렇게 하면 부분적으로 생성되었거나 거부된 결과가 유효한 소스 파일을 덮어쓰는 일을 방지할 수 있습니다.

빈 경고 보고서는 모든 소스 기능이 보존되었다는 보장이 아닙니다. 애플리케이션에 필요한 추가 콘텐츠 및 시각 검사를 적용하십시오. 또한 [프레젠테이션 열기](/slides/ko/net/open-presentation/) 및 [프레젠테이션 저장](/slides/ko/net/save-presentation/)을 참고하십시오.

## **FAQ**

**경고 콜백으로 모든 Aspose.Slides 오류를 처리할 수 있나요?**

아니요. 복구 가능한 상황을 경고로 보고할 때만 처리합니다. 콜백과 무관하게 발생하는 예외는 로드, 렌더링, 변환 또는 저장 호출을 둘러싼 애플리케이션 코드에서 처리해야 합니다.

**`ReturnAction.Continue`를 반환하면 동일한 출력이 보장되나요?**

아니요. 처리만 계속될 수 있게 할 뿐입니다. 보고된 상황에 따라 데이터·서식·호환성 차이가 발생할 수 있으므로 수집된 경고 유형 및 설명을 검토하십시오.

**애플리케이션이 경고를 발생시킨 작업을 어떻게 식별하나요?**

각 작업에 대해 콜백 인스턴스를 만들고 `WarningType` 및 `Description`과 함께 애플리케이션 정의 단계 정보를 저장하면 됩니다. 예제에 표시된 대로 구현하십시오.