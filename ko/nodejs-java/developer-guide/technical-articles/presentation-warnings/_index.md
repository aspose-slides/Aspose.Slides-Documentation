---
title: Node.js에서 프레젠테이션 경고 처리
type: docs
weight: 90
url: /ko/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- JavaScript
- Node.js
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 프레젠테이션을 로드, 렌더링, 변환 및 저장할 때 경고를 수집, 분류 및 처리하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides는 프레젠테이션을 로드, 렌더링, 변환 또는 저장하는 동안 복구 가능한 문제를 보고할 수 있습니다. 예시로는 손상된 소스 레코드, 보존할 수 없는 콘텐츠, 글꼴 대체, 대상 형식의 제한 등이 있습니다. 경고 콜백을 사용하면 애플리케이션이 이러한 상황을 기록하고 현재 작업을 계속할 수 있는지 여부를 결정할 수 있습니다.

JavaScript에서 `java.newProxy`를 사용해 Java 인터페이스 [IWarningCallback](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iwarningcallback/)를 구현하고, [IWarningInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iwarninginfo/)를 통해 제공되는 [getWarningType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iwarninginfo/#getWarningType--) 및 [getDescription](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iwarninginfo/#getDescription--) 값을 검사합니다. 경고를 수용하려면 [ReturnAction.Continue](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/returnaction/#Continue)를 반환하고, 작업을 중단하려면 [ReturnAction.Abort](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/returnaction/#Abort)를 반환합니다.

프레젠테이션을 열 때 발생하는 경고는 [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setWarningCallback)를 사용합니다. 렌더링 및 내보내기 옵션 클래스는 [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveoptions/#setWarningCallback)를 상속하며, 이는 슬라이드 렌더링, 변환 및 저장 시 발생하는 경고를 받습니다. 경고 자체만으로는 어떤 애플리케이션 작업인지 식별되지 않으므로, 결합된 보고서를 만들 때 각 콜백 인스턴스를 작업 단계와 연결하십시오.

## **경고 및 예외**

경고는 콜백이 `ReturnAction.Continue`를 반환하면 Aspose.Slides가 복구할 수 있는 상황을 설명합니다. 예외는 요청된 작업을 정상적으로 완료할 수 없음을 의미하며, 예외는 경고로 변환되지 않고 경고 정책으로 처리할 수 없습니다.

`ReturnAction.Abort`를 반환하면 경고 디스패처가 예외를 발생시켜 현재 작업을 종료하도록 요청합니다. 공개 예외는 작업 및 프레젠테이션 형식에 따라 달라집니다. 예를 들어 로드 시에는 [PptxReadException](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptxreadexception/) 또는 [PptReadException](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptreadexception/)가 발생할 수 있고, 저장 또는 내보내기 시에는 [PptxException](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptxexception/)가 발생할 수 있습니다. 작업 경계에서 Java 브릿지를 통해 오류를 잡고, 경고 보고서를 사용해 애플리케이션 정책이 종료를 초래했는지 확인하십시오. 콜백은 `ReturnAction.Abort`를 반환하기 전에 경고를 기록하므로, 이유가 애플리케이션에 남아 있습니다.

## **경고 범주**

[WarningType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/warningtype/) 클래스는 다음 범주에 대한 정수 상수를 제공합니다.

| 경고 유형 | 의미 | 일반 정책 |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | 원본 프레젠테이션에 손상이 있어 원래 형식으로 저장된 문서를 사용할 수 없게 될 수 있습니다. | 중단. |
| [DataLoss](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/warningtype/#DataLoss) | 로드 또는 저장 후 텍스트, 차트, 이미지 등 일부 데이터가 누락될 수 있습니다. | 중단. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | 프레젠테이션이 중요한 서식을 잃을 수 있습니다. | 엄격한 검증 모드에서는 중단; 그렇지 않으면 기록하고 계속. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | 제한된 서식 차이가 발생할 수 있습니다. | 진단을 위해 기록하고 계속. |
| [CompatibilityIssue](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | 결과물이 일부 애플리케이션이나 이전 버전에서 열리지 않거나 올바르게 동작하지 않을 수 있습니다. | 호환성이 필수적이지 않다면 로그에 남기고 계속. |
| [UnexpectedContent](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | 원본에 지원되지 않거나 인식되지 않은 콘텐츠가 포함되어 있어 영향이 아직 알려지지 않았습니다. | 기록하고 계속하거나, 엄격한 정책에서는 오류로 처리. |

카테고리는 정책 결정을 주도해야 합니다. 진단을 위해 [getDescription](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iwarninginfo/#getDescription--)이 반환하는 값을 저장하되, 경고 시나리오와 제품 버전에 따라 메시지 텍스트가 달라질 수 있으므로 애플리케이션 로직에서는 해당 문구에 의존하지 마십시오.

## **경고 수집 및 분류**

다음 JavaScript 예제는 전체 처리 파이프라인에 대해 하나의 애플리케이션 수준 보고서를 사용합니다. 별도의 콜백 인스턴스가 로드, 렌더링, PDF 변환 및 PPTX 저장 단계의 경고에 레이블을 붙입니다. 정책은 소스 손상 또는 데이터 손실 시 중단하고, 필요에 따라 주요 서식 손실 시에도 중단하며, 기타 경고는 계속 진행합니다.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

`WarningPolicy`를 구성할 때 주요 서식 차이가 허용될 경우 `abortOnMajorFormattingLoss`에 `false`를 전달하십시오. 호환성 문제, 마이너 서식 손실 및 예상치 못한 콘텐츠는 작업이 계속되더라도 보고서에 남습니다. 이러한 범주 중 하나라도 애플리케이션에서 거부해야 한다면 `WarningPolicy.getAction`을 확장하십시오.

## **일반적인 경고 시나리오**

경고는 워크플로우의 다양한 단계에서 나타날 수 있습니다:

- **디지털 서명:** 서명된 프레젠테이션을 로드할 때 서명이 처리 중 손실된다는 경고가 발생할 수 있습니다. Aspose.Slides는 이 `DataLoss` 상황을 [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationsignedwarninginfo/)를 통해 보고합니다. 로드 단계 콜백을 사용해 파일을 거부하거나 보고된 손실을 명시적으로 수용할 수 있습니다.
- **글꼴 대체:** 슬라이드가 렌더링되거나 내보내질 때 사용 가능한 글꼴이 없으면 대체됩니다. 글꼴 대체 경고는 `DataLoss`로 보고되므로, 위의 엄격한 정책은 애플리케이션이 시각적으로 허용한다 하더라도 중단합니다. 런타임에 없는 글꼴로 된 텍스트가 포함된 입력 프레젠테이션을 사용해 동작을 확인하십시오. 경고 설명에 대체 내용이 표시되므로 필요한 글꼴을 구성하거나 [글꼴 대체 규칙](/slides/ko/nodejs-java/font-substitution/)을 설정한 뒤 다시 시도하십시오.
- **지원되지 않거나 예상치 못한 콘텐츠:** 로더가 인식하지 못하는 프레젠테이션 레코드나 기능을 만나면 경고가 발생합니다. 이러한 경우 `UnexpectedContent` 또는 데이터·서식에 영향을 미치는 경우 더 심각한 범주가 사용될 수 있습니다.
- **형식 호환성:** 다른 프레젠테이션 형식으로 저장하면 일부 기능이 누락되거나 결과물이 특정 애플리케이션에서 다르게 동작할 수 있습니다. 예를 들어, 8개 이상의 가로 또는 세로 그리기 가이드를 포함한 프레젠테이션을 레거시 PPT로 저장하면 `CompatibilityIssue`가 보고됩니다. 저장 단계 콜백을 사용해 손실을 기록하고 계속하거나, 모든 가이드를 보존해야 한다면 거부할 수 있습니다.
- **로드 동작:** 로드 옵션 및 레거시 동작도 경고를 발생시킬 수 있습니다. 예를 들어, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/)는 오래된 프레젠테이션 잠금 동작 사용을 `CompatibilityIssue`로 식별합니다.

경고는 소스 문서, 대상 형식, 작업 및 Aspose.Slides 버전에 따라 달라집니다. 모든 파일이 경고를 발생시키거나 시나리오가 하나의 범주에만 매핑된다고 가정하지 마십시오.

## **중단된 작업을 안전하게 처리**

콜백이 `ReturnAction.Abort`를 반환하면 로드에 실패한 객체를 사용하지 말고, 렌더링이나 저장 결과가 완전하다고 가정하지 마십시오. 작업은 출력 파일을 생성한 뒤 아직 완전하지 않은 상태에서 종료될 수 있습니다.

검증된 결과를 `validated-output.pptx`와 같은 별도 경로에 저장하십시오. 기존 프레젠테이션을 교체하는 것은 작업이 성공적으로 끝나고, 경고 보고서가 애플리케이션 정책을 만족하며, 출력 파일을 열어 확인할 수 있는 경우에만 수행하십시오. 이렇게 하면 부분적이거나 거부된 결과가 유효한 소스 파일을 덮어쓰는 것을 방지할 수 있습니다.

빈 경고 보고서는 모든 소스 기능이 보존되었다는 보장이 아닙니다. 애플리케이션에서 요구하는 추가 콘텐츠 및 시각적 검사를 적용하십시오. 또한 [프레젠테이션 열기](/slides/ko/nodejs-java/open-presentation/)와 [프레젠테이션 저장](/slides/ko/nodejs-java/save-presentation/)을 참고하십시오.

## **FAQ**

**경고 콜백이 Aspose.Slides 모든 오류를 처리할 수 있나요?**

아니요. 콜백은 경고로 보고되는 복구 가능한 상황만 처리합니다. 콜백과 별개로 발생하는 예외는 로드, 렌더링, 변환 또는 저장 호출을 둘러싼 애플리케이션 코드에서 처리해야 합니다.

**`ReturnAction.Continue`를 반환하면 동일한 출력이 보장되나요?**

아니요. 이는 처리를 계속 허용할 뿐이며, 보고된 상황에 따라 데이터, 서식 또는 호환성 차이가 발생할 수 있으므로 수집된 경고 유형과 설명을 검토해야 합니다.

**애플리케이션이 어떤 작업에서 발생한 경고인지 식별하려면?**

예제와 같이 각 작업에 대한 콜백 인스턴스를 만들고, [getWarningType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iwarninginfo/#getWarningType--)과 [getDescription](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iwarninginfo/#getDescription--)이 반환하는 값과 함께 애플리케이션이 정의한 단계 정보를 저장하십시오.