---
title: C++에서 PPT 및 PPTX를 PDF로 변환 (고급 기능 포함)
linktitle: PowerPoint를 PDF로
type: docs
weight: 40
url: /ko/cpp/convert-powerpoint-to-pdf/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- PowerPoint를 PDF로
- 프레젠테이션을 PDF로
- PPT를 PDF로
- PPT를 PDF로 변환
- PPTX를 PDF로
- PPTX를 PDF로 변환
- PowerPoint를 PDF로 저장
- PPT를 PDF로 저장
- PPTX를 PDF로 저장
- PPT를 PDF로 내보내기
- PPTX를 PDF로 내보내기
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 PowerPoint PPT/PPTX를 고품질의 검색 가능한 PDF로 변환하고, 빠른 코드 예제와 고급 변환 옵션을 제공합니다."
---
## **개요**

PowerPoint 프레젠테이션(PPT, PPTX, ODP 등)을 C++에서 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 다양한 장치 간 호환성 및 프레젠테이션의 레이아웃과 서식을 유지하는 것이 포함됩니다. 이 가이드는 프레젠테이션을 PDF 문서로 변환하는 방법, 이미지 품질을 제어하는 다양한 옵션 사용, 숨겨진 슬라이드 포함, PDF 파일에 암호 보호, 글꼴 대체 감지, 변환할 특정 슬라이드 선택, 출력 문서에 규정 준수 표준 적용 방법을 보여줍니다.

## **PowerPoint를 PDF로 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다:

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인수로 전달한 다음 `Save` 메서드를 사용하여 PDF로 저장합니다. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 `Save` 메서드를 제공합니다.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++는 API 정보와 버전 번호를 출력 문서에 삽입합니다. 예를 들어 프레젠테이션을 PDF로 변환할 때 Aspose.Slides는 Application 필드에 "*Aspose.Slides*"를, PDF Producer 필드에 "*Aspose.Slides v XX.XX*" 형식의 값을 채웁니다. **참고**: 이 정보를 출력 문서에서 변경하거나 제거하도록 Aspose.Slides에 지시할 수 없습니다.

{{% /alert %}}

Aspose.Slides는 다음과 같은 변환을 지원합니다:

* 전체 프레젠테이션을 PDF로 변환
* 프레젠테이션의 특정 슬라이드를 PDF로 변환

Aspose.Slides는 프레젠테이션을 PDF로 내보내며, 결과 PDF가 원본 프레젠테이션과 매우 유사하게 매칭되도록 합니다. 변환 과정에서 다음 요소와 속성이 정확하게 렌더링됩니다:

* 이미지
* 텍스트 상자 및 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리표
* 표

## **PowerPoint를 PDF로 변환**

표준 PowerPoint‑to‑PDF 변환 프로세스는 기본 옵션을 사용합니다. 이 경우 Aspose.Slides는 최적의 설정과 최고 품질 수준으로 제공된 프레젠테이션을 PDF로 변환하려고 시도합니다.

다음 C++ 코드는 프레젠테이션(PPT, PPTX, ODP 등)을 PDF로 변환하는 방법을 보여줍니다:

```c++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// 프레젠테이션을 PDF로 저장합니다.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="info"  %}} 

Aspose는 무료 온라인 **PowerPoint to PDF 변환기**[https://products.aspose.app/slides/ko/conversion/ppt-to-pdf]를 제공하여 프레젠테이션‑to‑PDF 변환 과정을 시연합니다. 이 변환기를 사용하여 여기서 설명한 절차를 실시간으로 테스트할 수 있습니다.

{{% /alert %}}

## **옵션을 사용한 PowerPoint를 PDF로 변환**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/) 클래스 아래의 사용자 정의 옵션(속성)을 제공하여 결과 PDF를 맞춤 설정하거나, PDF에 암호를 설정하거나, 변환 프로세스 진행 방식을 지정할 수 있습니다.

### **맞춤 옵션을 사용한 PowerPoint를 PDF로 변환**

맞춤 변환 옵션을 사용하면 래스터 이미지에 대한 선호 품질 설정을 정의하고, 메타파일 처리 방법을 지정하고, 텍스트 압축 수준을 설정하고, 이미지 DPI를 구성하는 등 다양한 옵션을 지정할 수 있습니다.

아래 코드 예제는 여러 맞춤 옵션을 사용하여 PowerPoint 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다.

```c++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// PdfOptions 클래스를 인스턴스화합니다.
auto pdfOptions = MakeObject<PdfOptions>();

// JPG 이미지 품질을 설정합니다.
pdfOptions->set_JpegQuality(90);

// 이미지 DPI를 설정합니다.
pdfOptions->set_SufficientResolution(300);

// 메타파일 저장 동작을 설정합니다.
pdfOptions->set_SaveMetafilesAsPng(true);

// 텍스트 콘텐츠에 대한 압축 수준을 설정합니다.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// PDF 규정 준수 모드를 정의합니다.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 프레젠테이션을 PDF 문서로 저장합니다.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **숨겨진 슬라이드 포함하여 PowerPoint를 PDF로 변환**

프레젠테이션에 숨겨진 슬라이드가 포함된 경우 [PdfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/) 클래스의 [set_ShowHiddenSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 메서드를 사용하여 숨겨진 슬라이드를 결과 PDF의 페이지로 포함시킬 수 있습니다.

다음 C++ 코드는 숨겨진 슬라이드를 포함하여 PowerPoint 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptions 클래스를 인스턴스화합니다.
auto pdfOptions = MakeObject<PdfOptions>();

// 숨겨진 슬라이드를 추가합니다.
pdfOptions->set_ShowHiddenSlides(true);

// 프레젠테이션을 PDF로 저장합니다.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **암호로 보호된 PDF로 PowerPoint 변환**

다음 C++ 코드는 [PdfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/) 클래스의 보호 매개변수를 사용하여 PowerPoint 프레젠테이션을 암호 보호된 PDF로 변환하는 방법을 시연합니다:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptions 클래스를 인스턴스화합니다.
auto pdfOptions = MakeObject<PdfOptions>();

// PDF 비밀번호와 접근 권한을 설정합니다.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// 프레젠테이션을 PDF로 저장합니다.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **글꼴 대체 감지**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/) 클래스 아래의 [set_WarningCallback](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveoptions/set_warningcallback/) 메서드를 제공하여 프레젠테이션‑to‑PDF 변환 과정 중 글꼴 대체를 감지할 수 있게 합니다.

다음 C++ 코드는 글꼴 대체를 감지하는 방법을 보여줍니다:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

// 경고 콜백 구현.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss &&
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // PDF 옵션에 경고 콜백을 설정합니다.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // 프레젠테이션을 PDF로 저장합니다.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);

    presentation->Dispose();

    return 0;
}
```

{{%  alert color="info"  %}} 

렌더링 과정 중 글꼴 대체에 대한 콜백을 받는 방법에 대한 자세한 내용은 [Getting Warning Callbacks for Fonts Substitution](/slides/ko/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)를 참고하십시오.

글꼴 대체에 대한 자세한 내용은 [Font Substitution](/slides/ko/cpp/font-substitution/) 문서를 참조하십시오.

{{% /alert %}} 

## **PowerPoint에서 선택한 슬라이드만 PDF로 변환**

다음 C++ 코드는 PowerPoint 프레젠테이션에서 특정 슬라이드만 선택하여 PDF로 변환하는 방법을 보여줍니다:

```C++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 슬라이드 번호 배열을 설정합니다.
auto slides = MakeArray<int32_t>({ 1, 3 });

// 프레젠테이션을 PDF로 저장합니다.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **맞춤 슬라이드 크기로 PowerPoint를 PDF로 변환**

다음 C++ 코드는 지정된 슬라이드 크기로 PowerPoint 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다:

```C++
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// 조정된 슬라이드 크기로 새 프레젠테이션을 생성합니다.
auto resizedPresentation = MakeObject<Presentation>();

// 사용자 정의 슬라이드 크기를 설정합니다.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// 원본 프레젠테이션에서 첫 번째 슬라이드를 복제합니다.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// 노트가 포함된 PDF로 크기 조정된 프레젠테이션을 저장합니다.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **노트 슬라이드 보기로 PowerPoint를 PDF로 변환**

다음 C++ 코드는 노트를 포함한 PDF로 PowerPoint 프레젠테이션을 변환하는 방법을 보여줍니다:

```C++
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// 노트 레이아웃으로 PDF 옵션을 구성합니다.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// 프레젠테이션을 노트가 포함된 PDF로 저장합니다.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **PDF에 대한 접근성 및 규정 준수 표준**

Aspose.Slides는 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 를 준수하는 변환 절차를 사용할 수 있도록 지원합니다. 다음 규정 준수 표준 중 하나를 사용하여 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, **PDF/UA**.

다음 C++ 코드는 다양한 규정 준수 표준에 따라 여러 PDF를 생성하는 PowerPoint‑to‑PDF 변환 프로세스를 시연합니다:

```C++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides는 PDF 변환 작업을 지원하며 PDF 파일을 다양한 인기 형식으로 변환할 수 있습니다. [PDF to HTML](https://products.aspose.com/slides/ko/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/ko/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/ko/cpp/conversion/pdf-to-jpg/), [PDF to PNG](https://products.aspose.com/slides/ko/cpp/conversion/pdf-to-png/) 변환을 수행할 수 있습니다. 또한 [PDF to SVG](https://products.aspose.com/slides/ko/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/ko/cpp/conversion/pdf-to-tiff/), [PDF to XML](https://products.aspose.com/slides/ko/cpp/conversion/pdf-to-xml/)과 같은 특수 형식으로의 변환도 지원합니다.

{{% /alert %}}

> **참고:** PDF/UA 로 내보낼 때 Aspose.Slides는 SmartArt, 차트, 수식과 같은 복합 그래픽을 단일 도형으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며 아티팩트로 표시될 수 있으며, 대체 텍스트는 전체 도형에만 제공됩니다.

## **FAQ**

### 여러 PowerPoint 파일을 한 번에 PDF로 변환할 수 있나요?

예, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 한 번에 PDF로 일괄 변환하는 기능을 지원합니다. 파일을 순회하며 프로그래밍 방식으로 변환 프로세스를 적용할 수 있습니다.

### 변환된 PDF에 암호를 설정할 수 있나요?

물론입니다. 변환 과정에서 [PdfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/) 클래스를 사용해 비밀번호를 설정하고 접근 권한을 정의할 수 있습니다.

### PDF에 숨겨진 슬라이드를 포함하려면 어떻게 해야 하나요?

[PdfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/) 클래스의 `set_ShowHiddenSlides` 메서드를 사용하여 숨겨진 슬라이드를 결과 PDF에 포함시킬 수 있습니다.

### Aspose.Slides가 PDF에서 높은 이미지 품질을 유지할 수 있나요?

예, `set_JpegQuality` 및 `set_SufficientResolution`과 같은 메서드를 사용해 [PdfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/) 클래스에서 이미지 품질을 제어하여 PDF에 고품질 이미지를 보장할 수 있습니다.

### Aspose.Slides가 PDF/A 규정 준수 표준을 지원하나요?

예, Aspose.Slides는 PDF/A1a, PDF/A1b, PDF/UA 등 다양한 규정 준수 표준을 만족하는 PDF를 내보낼 수 있어 문서가 접근성 및 보존 요구 사항을 충족하도록 합니다.

## **추가 리소스**

- [Aspose.Slides for C++ Documentation](/slides/ko/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/ko/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/ko/conversion)