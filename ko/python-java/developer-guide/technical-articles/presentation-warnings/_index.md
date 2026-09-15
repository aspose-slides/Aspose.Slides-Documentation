---
title: Java를 통해 Python에서 프레젠테이션 경고 처리
type: docs
weight: 90
url: /ko/python-java/presentation-warnings/
aliases:
- /python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Python
- Java
- Aspose.Slides
description: "Java를 통해 Python용 Aspose.Slides를 사용하여 프레젠테이션을 로드, 렌더링, 변환 및 저장하는 동안 경고를 수집, 분류 및 처리하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides는 프레젠테이션을 로드, 렌더링, 변환 또는 저장하는 동안 복구 가능한 문제를 보고할 수 있습니다. 예를 들어 손상된 원본 레코드, 보존할 수 없는 콘텐츠, 글꼴 대체, 대상 형식의 제한 등이 있습니다. 경고 콜백을 사용하면 애플리케이션이 이러한 조건을 기록하고 현재 작업을 계속 진행할지 여부를 결정할 수 있습니다.

`jpype.JProxy`를 통해 `IWarningCallback` 인터페이스를 구현하고 `IWarningInfo`에서 제공되는 `getWarningType` 및 `getDescription` 값을 검사합니다. 경고를 수용하려면 [ReturnAction.Continue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/returnaction/#Continue) 을, 작업을 중단하려면 [ReturnAction.Abort](https://reference.aspose.com/slides/ko/python-java/aspose.slides/returnaction/#Abort) 을 반환합니다.

프레젠테이션을 열 때 발생하는 경고는 [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setWarningCallback) 을 사용합니다. 렌더링 및 내보내기 옵션 클래스는 [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveoptions/#setWarningCallback) 을 상속하며, 슬라이드 렌더링, 변환 및 저장 과정에서 발생하는 경고를 수신합니다. 경고 자체가 애플리케이션 작업을 식별하지 않으므로, 결합된 보고서를 작성할 때 각 콜백 인스턴스를 작업 단계와 연결하십시오.

## **경고 및 예외**

경고는 콜백이 `ReturnAction.Continue` 를 반환하면 Aspose.Slides가 복구할 수 있는 상태를 설명합니다. 예외는 요청된 작업을 정상적으로 완료할 수 없음을 의미하며, 예외는 경고로 변환되지 않으며 경고 정책으로 처리할 수 없습니다.

`ReturnAction.Abort` 를 반환하면 경고 디스패처가 예외를 발생시켜 현재 작업을 종료하도록 요청합니다. 발생하는 공개 예외는 작업 및 프레젠테이션 형식에 따라 다릅니다. 예를 들어 로드 시에는 [PptxReadException](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pptxreadexception/) 또는 [PptReadException](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pptreadexception/) 이 발생할 수 있고, 저장 또는 내보내기 시에는 [PptxException](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pptxexception/) 가 발생할 수 있습니다. 작업 경계에서 예외를 처리하고 경고 보고서를 사용하여 애플리케이션 정책이 종료를 유발했는지 판단하십시오. 콜백은 `ReturnAction.Abort` 를 반환하기 전에 경고를 기록하므로 이유가 애플리케이션에 전달됩니다.

## **경고 카테고리**

[WarningType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/warningtype/) 클래스는 다음 카테고리에 대한 정수 상수를 제공합니다.

| 경고 유형 | 의미 | 일반 정책 |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ko/python-java/aspose.slides/warningtype/#SourceFileCorruption) | 원본 프레젠테이션에 손상이 포함되어 있어 원래 형식으로 저장된 문서를 사용할 수 없게 될 수 있습니다. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/ko/python-java/aspose.slides/warningtype/#DataLoss) | 로드 또는 저장 후 텍스트, 차트, 이미지 등 일부 데이터가 누락될 수 있습니다. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ko/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | 프레젠테이션에서 중요한 서식이 손실될 수 있습니다. | 엄격한 검증 모드에서는 Abort, 그렇지 않으면 기록하고 Continue. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ko/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | 제한적인 서식 차이가 발생할 수 있습니다. | 진단용으로 기록하고 Continue. |
| [CompatibilityIssue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/warningtype/#CompatibilityIssue) | 결과가 일부 애플리케이션이나 이전 버전에서 열리거나 정상 동작하지 않을 수 있습니다. | 호환성이 필수되지 않는 한 로그를 남기고 Continue. |
| [UnexpectedContent](https://reference.aspose.com/slides/ko/python-java/aspose.slides/warningtype/#UnexpectedContent) | 원본에 지원되지 않거나 인식되지 않은 콘텐츠가 포함되어 있으며 그 영향이 아직 알려지지 않았습니다. | 기록하고 Continue하거나, 엄격한 정책에서는 오류로 처리. |

카테고리는 정책 결정을 주도해야 합니다. 진단을 위해 `getDescription` 에서 반환된 값을 저장하지만, 메시지 텍스트는 경고 시나리오와 제품 버전에 따라 달라질 수 있으므로 애플리케이션 로직에서는 텍스트에 의존하지 마십시오.

## **경고 수집 및 분류**

다음 예제는 전체 처리 파이프라인에 대해 하나의 애플리케이션 수준 보고서를 사용합니다. 별도의 콜백 인스턴스가 로드, 렌더링, PDF 변환 및 PPTX 저장 단계의 경고에 라벨을 붙입니다. 정책은 소스 손상 또는 데이터 손실 시 Abort하고, 주요 서식 손실 시 선택적으로 Abort하며, 다른 경고는 Continue합니다.

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

`WarningPolicy` 를 구성할 때 주요 서식 차이가 허용되는 경우 `abort_on_major_formatting_loss` 에 `False` 를 전달하십시오. 호환성 문제, 소규모 서식 손실, 예상치 못한 콘텐츠는 작업이 계속되더라도 보고서에 유지됩니다. 이러한 카테고리 중 하나를 거부해야 하는 경우 `WarningPolicy.get_action` 을 확장하십시오.

## **일반적인 경고 시나리오**

경고는 워크플로우의 다양한 단계에서 나타날 수 있습니다.

- **디지털 서명:** 서명된 프레젠테이션을 로드하는 동안 서명이 처리 과정에서 손실될 수 있다는 경고가 발생할 수 있습니다. Aspose.Slides는 이 `DataLoss` 상황을 `IPresentationSignedWarningInfo` 로 보고합니다. 로드 단계 콜백을 사용해 파일을 거부하거나 보고된 손실을 명시적으로 수용할 수 있습니다.
- **글꼴 대체:** 슬라이드가 렌더링되거나 내보내질 때 사용할 수 없는 글꼴을 다른 글꼴로 교체할 수 있습니다. 글꼴 대체 경고는 `DataLoss` 로 보고되므로, 위의 엄격한 정책에서는 애플리케이션이 시각적으로 허용 가능하더라도 Abort합니다. 런타임에 사용할 수 없는 글꼴이 포함된 입력 프레젠테이션을 사용해 이 동작을 확인하십시오. 경고 설명에 대체 내용이 표시되므로 필요한 글꼴을 설치하거나 [글꼴 대체 규칙](/slides/ko/python-java/font-substitution/) 을 구성한 뒤 다시 시도하십시오.
- **지원되지 않거나 예상치 못한 콘텐츠:** 로더가 인식하지 못하는 프레젠테이션 레코드나 기능을 마주할 수 있습니다. 이러한 경고는 `UnexpectedContent` 로 표시되거나, 데이터나 서식이 영향을 받는 경우 더 심각한 카테고리를 사용할 수 있습니다.
- **형식 호환성:** 다른 프레젠테이션 형식으로 저장할 때 기능이 누락되거나 일부 애플리케이션에서 동작이 달라질 수 있습니다. 예를 들어, 수평 가이드 8개 이상 또는 수직 가이드 8개 이상을 포함한 프레젠테이션을 레거시 PPT 로 저장하면 `CompatibilityIssue` 가 보고됩니다. 저장 단계 콜백은 손실을 기록하고 Continue하거나, 모든 가이드를 보존해야 한다면 거부할 수 있습니다.
- **로드 동작:** 로드 옵션 및 레거시 동작도 경고를 발생시킬 수 있습니다. 예를 들어, `IObsoletePresLockingBehaviorWarningInfo` 은 구식 프레젠테이션 잠금 동작 사용을 `CompatibilityIssue` 로 식별합니다.

경고는 소스 문서, 대상 형식, 작업 및 Aspose.Slides 버전에 따라 달라집니다. 모든 파일이 경고를 발생한다거나 하나의 시나리오가 항상 단일 카테고리에 매핑된다고 가정하지 마십시오.

## **중단된 작업 안전하게 처리하기**

콜백이 `ReturnAction.Abort` 를 반환하면 로드에 실패한 객체를 사용하지 말고, 렌더링 또는 저장 결과가 완전하다고 가정하지 마십시오. 작업은 출력 파일을 생성한 뒤 아직 완료되지 않은 상태에서 종료될 수 있습니다.

검증된 결과를 `validated-output.pptx` 와 같이 별도 경로에 저장하십시오. 기존 프레젠테이션을 교체하려면 작업이 성공적으로 종료되고, 경고 보고서가 애플리케이션 정책을 만족하며, 출력 파일을 열어 확인한 뒤에만 교체하십시오. 이렇게 하면 부분적이거나 거부된 결과가 유효한 소스 파일을 덮어쓰는 상황을 방지할 수 있습니다.

빈 경고 보고서는 모든 소스 기능이 보존되었다는 보장이 아닙니다. 애플리케이션에서 요구하는 추가 콘텐츠 및 시각적 검사를 적용하십시오. 또한 [프레젠테이션 열기](/slides/ko/python-java/open-presentation/) 와 [프레젠테이션 저장](/slides/ko/python-java/save-presentation/) 도 참고하십시오.

## **FAQ**

**경고 콜백이 Aspose.Slides 모든 오류를 처리할 수 있습니까?**

아닙니다. 콜백은 경고로 보고되는 복구 가능한 상태만 처리합니다. 콜백과 무관하게 발생하는 예외는 로드, 렌더링, 변환 또는 저장 호출을 둘러싼 애플리케이션 코드에서 직접 처리해야 합니다.

**`ReturnAction.Continue` 를 반환하면 동일한 출력이 보장됩니까?**

아닙니다. 이는 처리를 계속하도록 허용할 뿐이며, 보고된 상태로 인해 데이터, 서식 또는 호환성 차이가 발생할 수 있으므로 수집된 경고 유형 및 설명을 검토해야 합니다.

**애플리케이션이 어떤 작업에서 경고가 발생했는지 식별하려면 어떻게 해야 합니까?**

각 작업마다 콜백 인스턴스를 생성하고, `getWarningType` 와 `getDescription` 이 반환한 값과 함께 애플리케이션에서 정의한 단계 정보를 저장하십시오. 예제에 나와 있는 방법을 참고하십시오.