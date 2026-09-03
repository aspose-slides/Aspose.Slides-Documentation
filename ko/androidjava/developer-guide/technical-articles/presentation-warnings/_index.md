---
title: Android에서 프레젠테이션 경고 처리
type: docs
weight: 90
url: /ko/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 Java를 통해 사용하면서 프레젠테이션을 로드, 렌더링, 변환 및 저장할 때 발생하는 경고를 수집, 분류 및 처리하는 방법을 배우세요."
---
## **개요**

Aspose.Slides는 프레젠테이션을 로드, 렌더링, 변환 또는 저장하는 동안 복구 가능한 문제를 보고할 수 있습니다. 예로는 손상된 원본 레코드, 보존할 수 없는 콘텐츠, 글꼴 대체, 대상 형식의 제한 등이 있습니다. 경고 콜백을 사용하면 애플리케이션이 이러한 조건을 기록하고 현재 작업을 계속할 수 있는지 결정할 수 있습니다.

[IWarningCallback](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iwarningcallback/) 인터페이스를 구현하고 [IWarningInfo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iwarninginfo/)를 통해 제공되는 [getWarningType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) 및 [getDescription](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) 값을 검사하십시오. 경고를 수락하려면 [ReturnAction.Continue](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/returnaction/#Continue)을, 작업을 중단하려면 [ReturnAction.Abort](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/returnaction/#Abort)을 반환하십시오.

프레젠테이션을 열 때 발생하는 경고에는 [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)를 사용합니다. 렌더링 및 내보내기 옵션 클래스는 [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)를 상속하며, 슬라이드 렌더링, 변환 및 저장 과정에서 발생하는 경고를 수신합니다. 경고 자체는 애플리케이션 작업을 식별하지 않으므로, 결합 보고서를 작성할 때 각 콜백 인스턴스를 작업 단계와 연결하십시오.

## **경고와 예외**

경고는 콜백이 `ReturnAction.Continue`를 반환하면 Aspose.Slides가 복구할 수 있는 조건을 설명합니다. 예외는 요청된 작업을 정상적으로 완료할 수 없음을 의미하며, 예외는 경고로 변환되지 않으며 경고 정책으로 처리할 수 없습니다.

`ReturnAction.Abort`를 반환하면 경고 디스패처가 예외를 발생시켜 현재 작업을 종료하도록 요청합니다. 공개 예외는 작업 및 프레젠테이션 형식에 따라 달라집니다. 예를 들어 로드 시에는 [PptxReadException](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pptxreadexception/) 또는 [PptReadException](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pptreadexception/)가 발생할 수 있고, 저장 또는 내보내기 시에는 [PptxException](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pptxexception/)가 발생할 수 있습니다. 작업 경계에서 예외를 처리하고 경고 보고서를 사용해 애플리케이션 정책이 종료를 일으켰는지 확인하십시오. 콜백은 `ReturnAction.Abort`를 반환하기 전에 경고를 기록하므로 이유가 애플리케이션에 남아 있습니다.

## **경고 범주**

[WarningType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/warningtype/) 클래스는 다음 범주에 대한 정수 상수를 제공합니다.

| 경고 유형 | 의미 | 일반적인 정책 |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | 원본 프레젠테이션에 손상이 포함되어 있어 원래 형식으로 저장된 문서를 사용할 수 없게 될 수 있습니다. | 중단 |
| [DataLoss](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/warningtype/#DataLoss) | 로드 또는 저장 후 텍스트, 차트, 이미지 또는 기타 데이터가 누락될 수 있습니다. | 중단 |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | 프레젠테이션이 중요한 서식을 잃을 수 있습니다. | 엄격한 검증 모드에서는 중단, 그렇지 않으면 기록하고 계속 |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | 제한된 서식 차이가 발생할 수 있습니다. | 진단을 위해 기록하고 계속 |
| [CompatibilityIssue](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | 결과가 일부 애플리케이션이나 이전 버전에서 열리지 않거나 올바르게 동작하지 않을 수 있습니다. | 호환성이 필수적이지 않은 한 기록하고 계속 |
| [UnexpectedContent](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | 원본에 지원되지 않거나 인식되지 않은 콘텐츠가 포함되어 있어 그 영향이 아직 알려지지 않을 수 있습니다. | 기록하고 계속하거나, 엄격한 정책에서는 오류로 처리 |

범주는 정책 결정을 이끌어야 합니다. 진단을 위해서는 [getDescription](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iwarninginfo/#getDescription--)이 반환하는 값을 저장하지만, 메시지 텍스트는 경고 시나리오와 제품 버전마다 달라질 수 있으므로 애플리케이션 로직에 의존하지 마십시오.

## **경고 수집 및 분류**

다음 예제는 전체 처리 파이프라인에 대해 하나의 애플리케이션 수준 보고서를 사용합니다. 별도의 콜백 인스턴스가 로드, 렌더링, PDF 변환 및 PPTX 저장 단계에서 발생한 경고에 라벨을 붙입니다. 정책은 소스 손상이나 데이터 손실 시 중단하고, 필요에 따라 주요 서식 손실 시에도 중단하며, 기타 경고는 계속합니다.

`input.pptx`를 쓰기 가능한 애플리케이션 디렉터리에 배치하고 해당 디렉터리를 `PresentationWarningExample.run`에 전달하십시오. 예제는 출력 파일을 동일한 디렉터리에 저장합니다. Android 사용자 인터페이스가 응답성을 유지하도록 프레젠테이션 처리를 백그라운드 스레드에서 실행하십시오.

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

`WarningPolicy`를 구성할 때 주요 서식 차이가 허용 가능한 경우 `abortOnMajorFormattingLoss`에 `false`를 전달하십시오. 호환성 문제, 소량 서식 손실 및 예상치 못한 콘텐츠는 작업이 계속되더라도 보고서에 남습니다. 이러한 범주 중 어느 하나라도 애플리케이션이 거부해야 하는 경우 `WarningPolicy.getAction`을 확장하십시오.

## **일반적인 경고 시나리오**

경고는 작업 흐름의 다양한 단계에서 나타날 수 있습니다:

- **디지털 서명:** 서명된 프레젠테이션을 로드할 때 처리 중 서명이 손실될 것이라는 경고가 발생할 수 있습니다. Aspose.Slides는 이 `DataLoss` 조건을 [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/)를 통해 보고합니다. 로드 단계 콜백을 사용하면 파일을 거부하거나 보고된 손실을 명시적으로 수락할 수 있습니다.
- **글꼴 대체:** 사용 불가능한 글꼴이 슬라이드 렌더링 또는 내보내기 중에 교체될 수 있습니다. 글꼴 대체 경고는 `DataLoss`로 보고되므로, 위의 엄격한 정책에서는 애플리케이션이 시각적으로 허용 가능하다고 판단하더라도 중단됩니다. 런타임에 사용할 수 없는 글꼴이 포함된 입력 프레젠테이션을 사용해 이 동작을 확인하십시오. 경고 설명에 대체 글꼴이 명시됩니다; 필요한 글꼴을 구성하거나 [font substitution rules](/slides/ko/androidjava/font-substitution/)를 설정한 후 다시 시도하십시오.
- **지원되지 않거나 예상치 못한 콘텐츠:** 로더가 인식하지 못하는 프레젠테이션 레코드나 기능을 만나면 경고가 발생할 수 있습니다. 이러한 경우 `UnexpectedContent` 또는 데이터·서식에 영향을 미치는 경우 더 심각한 범주가 사용될 수 있습니다.
- **형식 호환성:** 다른 프레젠테이션 형식으로 저장하면 기능이 누락되거나 일부 애플리케이션에서 동작이 달라질 수 있습니다. 예를 들어, 수평 또는 수직 그리기 가이드가 8개를 초과하는 프레젠테이션을 레거시 PPT로 저장하면 `CompatibilityIssue`가 보고됩니다. 저장 단계 콜백은 손실을 기록하고 계속하거나, 모든 가이드를 유지해야 하는 경우 거부할 수 있습니다.
- **로드 동작:** 로드 옵션 및 레거시 동작도 경고를 생성할 수 있습니다. 예를 들어, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/)는 폐기된 프레젠테이션 잠금 동작 사용을 `CompatibilityIssue`로 식별합니다.

경고는 소스 문서, 대상 형식, 작업 및 Aspose.Slides 버전에 따라 달라집니다. 모든 파일이 경고를 발생시키거나 시나리오가 하나의 범주에만 매핑된다고 가정하지 마십시오.

## **중단된 작업 안전하게 처리하기**

콜백이 `ReturnAction.Abort`를 반환하면 로드에 실패한 객체를 사용하지 말고, 렌더링 또는 저장 결과가 완전하다고 가정하지 마십시오. 작업은 출력 파일을 생성했지만 완전히 끝내기 전에 종료될 수 있습니다.

검증된 결과를 `validated-output.pptx`와 같은 별도 경로에 저장하십시오. 기존 프레젠테이션은 작업이 성공적으로 완료되고, 경고 보고서가 애플리케이션 정책을 만족하며, 출력 파일을 열고 확인할 수 있을 때만 교체하십시오. 이렇게 하면 부분적이거나 거부된 결과로 유효한 소스 파일을 덮어쓰는 일을 방지할 수 있습니다.

빈 경고 보고서는 모든 소스 기능이 보존되었다는 보장이 아닙니다. 애플리케이션에서 필요로 하는 추가 콘텐츠 및 시각적 검사를 수행하십시오. 또한 [Open Presentations](/slides/ko/androidjava/open-presentation/)와 [Save Presentations](/slides/ko/androidjava/save-presentation/)를 참고하십시오.

## **FAQ**

**경고 콜백이 Aspose.Slides 모든 오류를 처리할 수 있나요?**

아니요. 복구 가능한 경고로 보고되는 조건만 처리합니다. 콜백과 무관하게 발생하는 예외는 로드, 렌더링, 변환 또는 저장 호출을 둘러싼 애플리케이션 코드에서 처리해야 합니다.

**`ReturnAction.Continue`를 반환하면 동일한 출력이 보장되나요?**

아니요. 처리를 계속할 수 있게 할 뿐이며, 보고된 조건으로 인해 데이터, 서식 또는 호환성 차이가 발생할 수 있으므로 수집된 경고 유형과 설명을 검토해야 합니다.

**애플리케이션이 어떤 작업에서 경고가 발생했는지 식별하려면 어떻게 해야 하나요?**

예제와 같이 각 작업마다 콜백 인스턴스를 만들고, 해당 인스턴스와 함께 [getWarningType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) 및 [getDescription](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iwarninginfo/#getDescription--)이 반환한 값을 저장하십시오.