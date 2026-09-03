---
title: C++에서 프레젠테이션 경고 처리
type: docs
weight: 70
url: /ko/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 프레젠테이션을 로드, 렌더링, 변환 및 저장하는 동안 경고를 수집하고, 분류하며, 조치를 취하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides는 프레젠테이션을 로드, 렌더링, 변환 또는 저장하는 동안 복구 가능한 문제를 보고할 수 있습니다. 예를 들어 손상된 원본 레코드, 보존할 수 없는 콘텐츠, 글꼴 대체, 대상 형식의 제한 등이 있습니다. 경고 콜백을 사용하면 애플리케이션이 이러한 상황을 기록하고 현재 작업을 계속 진행할지 여부를 결정할 수 있습니다.

[IWarningCallback](https://reference.aspose.com/slides/ko/cpp/aspose.slides.warnings/iwarningcallback/) 인터페이스를 구현하고 [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) 및 [IWarningInfo::get_Description](https://reference.aspose.com/slides/ko/cpp/aspose.slides.warnings/iwarninginfo/get_description/) 메서드를 통해 제공되는 [IWarningInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides.warnings/iwarninginfo/)를 검사합니다. 경고를 수락하려면 [ReturnAction::Continue](https://reference.aspose.com/slides/ko/cpp/aspose.slides.warnings/returnaction/)를, 작업을 중단하려면 `ReturnAction::Abort`를 반환합니다.

프레젠테이션을 열 때 발생하는 경고는 [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_warningcallback/)를 사용합니다. 렌더링 및 내보내기 옵션 클래스는 [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveoptions/set_warningcallback/)를 상속하며, 슬라이드 렌더링, 변환 및 저장 시 발생하는 경고를 받습니다. 경고 자체는 어떤 애플리케이션 작업인지 식별하지 않으므로, 결합된 보고서를 작성할 때 각 콜백 인스턴스를 작업 단계와 연결하십시오.

## **경고와 예외**

경고는 콜백이 `ReturnAction::Continue`를 반환하면 Aspose.Slides가 복구할 수 있는 상황을 설명합니다. 예외는 요청된 작업을 정상적으로 완료할 수 없음을 의미하며, 예외는 경고로 변환되지 않으며 경고 정책으로 처리할 수 없습니다.

`ReturnAction::Abort`를 반환하면 경고 디스패처에 현재 작업을 예외를 발생시켜 종료하도록 요청합니다. 공개 예외는 작업 및 프레젠테이션 형식에 따라 다릅니다. 예를 들어, 로드 시에는 [PptxReadException](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pptxreadexception/) 또는 [PptReadException](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pptreadexception/)가 나타날 수 있고, 저장 또는 내보내기 시에는 [PptxException](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pptxexception/)가 나타날 수 있습니다. 작업 경계에서 예외를 처리하고 경고 보고서를 사용해 애플리케이션 정책이 종료를 초래했는지 확인하십시오. 콜백은 `ReturnAction::Abort`를 반환하기 전에 경고를 기록하므로 원인이 애플리케이션에 남아 있습니다.

## **경고 유형**

[WarningType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.warnings/warningtype/) 열거형은 다음 범주를 제공합니다.

| 경고 유형 | 의미 | 일반적인 정책 |
| --- | --- | --- |
| `SourceFileCorruption` | 원본 프레젠테이션에 손상이 포함되어 있어 원본 형식으로 저장된 문서를 사용할 수 없게 될 수 있습니다. | 중단. |
| `DataLoss` | 로드하거나 저장한 후 텍스트, 차트, 이미지 또는 기타 데이터가 누락될 수 있습니다. | 중단. |
| `MajorFormattingLoss` | 프레젠테이션에서 중요한 서식이 손실될 수 있습니다. | 엄격한 검증 모드에서는 중단; 그렇지 않으면 기록하고 계속 진행. |
| `MinorFormattingLoss` | 제한된 서식 차이가 발생할 수 있습니다. | 진단을 위해 기록하고 계속 진행. |
| `CompatibilityIssue` | 결과가 일부 애플리케이션이나 이전 버전에서 열리거나 정상 동작하지 않을 수 있습니다. | 호환성이 필수적이지 않다면 로그를 남기고 계속 진행. |
| `UnexpectedContent` | 원본에 지원되지 않거나 인식되지 않은 내용이 포함되어 있어 그 영향이 아직 알려지지 않았을 수 있습니다. | 기록하고 계속 진행하거나, 엄격한 정책에서는 오류로 처리. |

범주는 정책 결정을 주도해야 합니다. 진단을 위해 경고 설명을 저장하되, 메시지 텍스트는 경고 시나리오와 제품 버전에 따라 달라질 수 있으므로 애플리케이션 로직에서는 의존하지 마십시오.

## **경고 수집 및 분류**

다음 예제는 전체 처리 파이프라인에 대한 하나의 애플리케이션 수준 보고서를 사용합니다. 별도의 콜백 인스턴스가 로드, 렌더링, PDF 변환 및 PPTX 저장 시 발생한 경고에 라벨을 붙입니다. 정책은 소스 손상 또는 데이터 손실 시 중단하고, 필요에 따라 주요 서식 손실 시에도 중단하며, 기타 경고는 계속 진행합니다.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

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
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

주요 서식 차이가 허용될 경우 `abortOnMajorFormattingLoss`를 `false`로 설정하십시오. 호환성 문제, 경미한 서식 손실 및 예상치 못한 콘텐츠는 작업이 계속되더라도 보고서에 그대로 유지됩니다. 애플리케이션이 해당 카테고리를 모두 거부해야 할 경우 `WarningPolicy::GetAction`을 확장하십시오.

## **일반적인 경고 시나리오**

경고는 워크플로의 다양한 단계에서 나타날 수 있습니다.

- **디지털 서명:** 서명된 프레젠테이션을 로드할 때 처리 중 서명이 손실될 것이라는 경고가 발생할 수 있습니다. Aspose.Slides는 이 `DataLoss` 상태를 [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/)를 통해 보고합니다. 로드 단계 콜백을 사용해 파일을 거부하거나 보고된 손실을 명시적으로 수락할 수 있습니다.
- **글꼴 대체:** 사용 불가능한 글꼴이 슬라이드 렌더링 또는 내보내기 중 교체될 수 있습니다. 글꼴 대체 경고는 `DataLoss`로 보고되므로, 위의 엄격한 정책에서는 애플리케이션이 시각적으로 허용 가능하다고 판단해도 중단됩니다. 런타임에 사용할 수 없는 글꼴이 포함된 입력 프레젠테이션을 사용해 이 동작을 확인하십시오. 경고 설명에 대체된 글꼴이 표시됩니다; 필요한 글꼴을 구성하거나 [폰트 대체 규칙](/slides/ko/cpp/font-substitution/)을 설정한 뒤 재시도하십시오.
- **지원되지 않거나 예상치 못한 콘텐츠:** 로더가 인식하지 못하는 프레젠테이션 레코드나 기능을 만나면 경고가 발생할 수 있습니다. 이러한 경고는 `UnexpectedContent`이거나 데이터·서식에 영향을 미치는 경우 더 심각한 범주가 될 수도 있습니다.
- **형식 호환성:** 다른 프레젠테이션 형식으로 저장하면 기능이 누락되거나 일부 애플리케이션에서 동작이 달라질 수 있습니다. 예를 들어, 레거시 PPT에 가로·세로 그리기 가이드가 8개 초과로 포함된 프레젠테이션을 저장하면 `CompatibilityIssue`가 보고됩니다. 저장 단계 콜백은 손실을 기록하고 계속 진행하거나, 모든 가이드를 보존해야 할 경우 거부할 수 있습니다.
- **로드 동작:** 로드 옵션 및 레거시 동작도 경고를 만들 수 있습니다. 예를 들어, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/)는 구식 프레젠테이션 잠금 동작 사용을 `CompatibilityIssue`로 식별합니다.

경고는 소스 문서, 대상 형식, 작업 및 Aspose.Slides 버전에 따라 달라집니다. 모든 파일이 경고를 발생시키거나 특정 시나리오가 언제나 하나의 카테고리에만 매핑된다고 가정하지 마십시오.

## **중단된 작업을 안전하게 처리하기**

콜백이 `ReturnAction::Abort`를 반환하면 로드에 실패한 객체를 사용하거나 렌더링·저장 결과가 완전하다고 가정하지 마십시오. 작업은 출력 파일을 생성한 뒤 아직 완료되지 않은 상태에서 종료될 수 있습니다.

검증된 결과를 `validated-output.pptx`와 같은 별도 경로에 저장하십시오. 기존 프레젠테이션을 교체하는 작업은 다음 조건을 모두 만족할 때만 수행합니다: 작업이 성공적으로 마무리되고, 경고 보고서가 애플리케이션 정책을 충족하며, 출력 파일을 열어 확인할 수 있는 경우. 이렇게 하면 부분적으로 생성되었거나 거부된 결과가 유효한 소스 파일을 덮어쓰는 상황을 방지할 수 있습니다.

빈 경고 보고서는 모든 소스 기능이 보존되었다는 보장이 아닙니다. 애플리케이션이 요구하는 추가 콘텐츠 및 시각적 검사를 적용하십시오. 또한 [프레젠테이션 열기](/slides/ko/cpp/open-presentation/) 및 [프레젠테이션 저장](/slides/ko/cpp/save-presentation/)을 참조하십시오.

## **FAQ**

**경고 콜백으로 Aspose.Slides의 모든 오류를 처리할 수 있나요?**

아니요. 콜백은 경고로 보고되는 복구 가능한 상황만 처리합니다. 콜백과 무관하게 발생하는 예외는 로드·렌더링·변환·저장 호출을 둘러싼 애플리케이션 코드에서 처리해야 합니다.

**`ReturnAction::Continue`를 반환하면 동일한 출력이 보장되나요?**

아니요. 이는 처리 진행을 허용할 뿐입니다. 보고된 상황이 여전히 데이터, 서식 또는 호환성 차이를 초래할 수 있으므로 수집된 경고 유형과 설명을 검토해야 합니다.

**애플리케이션이 어떤 작업에서 경고가 발생했는지 식별하려면 어떻게 해야 하나요?**

각 작업마다 콜백 인스턴스를 만들고, 경고 유형·설명과 함께 애플리케이션 정의 단계 정보를 저장하면 됩니다. 예제에서와 같이 구현하십시오.