---
title: C++에서 PPT 및 PPTX를 PDF로 변환 [고급 기능 포함]
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
- 첨부 파일
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 PowerPoint PPT/PPTX를 고품질의 검색 가능한 PDF로 변환합니다. 빠른 코드 예제와 고급 변환 옵션을 제공합니다."
---
## **개요**

PowerPoint 프레젠테이션(PPT, PPTX, ODP 등)을 C++에서 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 다양한 장치 간 호환성 및 프레젠테이션의 레이아웃과 서식을 유지하는 것이 포함됩니다. 이 가이드는 프레젠테이션을 PDF 문서로 변환하는 방법, 이미지 품질을 제어하는 옵션 사용, 숨겨진 슬라이드 포함, PDF 파일에 비밀번호 보호, 글꼴 대체 감지, 특정 슬라이드 선택 변환, 및 출력 문서에 규정 준수 표준 적용을 보여줍니다.

## **PowerPoint to PDF 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다:

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 클래스에 인수로 전달한 다음 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 메서드를 사용해 PDF로 저장합니다. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 메서드를 제공합니다.

{{% alert color="info" title="Note" %}}

Aspose.Slides for C++는 API 정보와 버전 번호를 출력 문서에 삽입합니다. 예를 들어 프레젠테이션을 PDF로 변환할 때 Aspose.Slides는 Application 필드에 "*Aspose.Slides*"를, PDF Producer 필드에 "*Aspose.Slides v XX.XX*" 형식의 값을 채웁니다. **참고** 이 정보를 출력 문서에서 변경하거나 제거하도록 Aspose.Slides에 지시할 수 없습니다.

{{% /alert %}}

Aspose.Slides는 다음을 변환할 수 있습니다:

* 전체 프레젠테이션을 PDF로
* 프레젠테이션의 특정 슬라이드를 PDF로

Aspose.Slides는 프레젠테이션을 PDF로 내보릴 때 원본 프레젠테이션과 거의 일치하도록 합니다. 변환 시 다음 요소와 속성이 정확하게 렌더링됩니다:

* 이미지
* 텍스트 상자 및 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리표
* 표

## **PowerPoint를 PDF로 변환**

표준 PowerPoint‑to‑PDF 변환 프로세스는 기본 옵션을 사용합니다. 이 경우 Aspose.Slides는 최적의 설정을 사용해 최대 품질 수준으로 제공된 프레젠테이션을 PDF로 변환하려고 시도합니다.

다음 예제는 프레젠테이션을 로드하고 기본 내보내기 설정을 사용해 모든 보이는 슬라이드를 PDF로 저장합니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Aspose는 무료 온라인 [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf)를 제공하며, 여기서 프레젠테이션‑to‑PDF 변환 프로세스를 시연합니다. 이 변환기를 사용해 여기에서 설명된 절차를 실시간으로 테스트해 볼 수 있습니다.

{{% /alert %}}

## **옵션을 사용하여 PowerPoint를 PDF로 변환**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 클래스 아래에 있는 사용자 정의 옵션(속성)을 제공하여 결과 PDF를 사용자 정의하거나, 비밀번호로 PDF를 잠그거나, 변환 프로세스 진행 방식을 지정할 수 있습니다.

### **사용자 정의 옵션으로 PowerPoint를 PDF로 변환**

사용자 정의 변환 옵션을 사용하면 래스터 이미지에 대한 선호 품질 설정, 메타파일 처리 방식, 텍스트 압축 수준, 이미지 DPI 등을 정의할 수 있습니다.

다음 예제는 프레젠테이션을 PDF 1.5로 내보내고 JPEG 품질을 90, 이미지 해상도를 300 DPI, 메타파일을 PNG로 저장하고 Flate 텍스트 압축을 적용합니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **이미지 압축 자동 선택**

프레젠테이션에 사진이나 스크린샷이 많이 포함된 경우, 내보낸 PDF 크기를 줄이면 이메일 전송이나 다운로드가 쉬워집니다. PDF 내보낼 때 각 이미지에 가장 적합한 압축 알고리즘을 자동으로 선택하려면 `true`와 함께 [PdfOptions::set_BestImagesCompressionRatio](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_bestimagescompressionratio/)를 호출합니다.

다음 예제는 기존 프레젠테이션을 로드하고 자동 이미지 압축 선택을 활성화한 뒤 PDF 문서로 저장합니다. 다른 모든 PDF 내보내기 설정은 기본값을 유지합니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_BestImagesCompressionRatio(true);

auto presentation = MakeObject<Presentation>(u"image-heavy.pptx");
presentation->Save(u"image-heavy.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

이 옵션은 각 이미지에 대해 압축 알고리즘을 선택합니다. [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/)를 사용해 JPEG 품질을 낮추면 JPEG 이미지 품질이 감소하고, [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/)로 해상도를 낮추면 이미지가 더 낮은 해상도로 다운샘플링되어 세부 사항이 줄어듭니다. 자동 압축 선택을 활성화한다고 해서 이 설정 중 어느 하나도 자동으로 낮아지지는 않습니다.

이미지 압축 알고리즘을 선택하면 추가 처리 시간과 메모리가 필요합니다. 크기 감소는 프레젠테이션의 이미지 및 내보내기 설정에 따라 달라지며, 모든 프레젠테이션에 대해 고정된 감소량이 보장되는 것은 아닙니다.

### **임베드된 OLE 파일을 PDF 첨부 파일로 보존**

프레젠테이션에 임베드된 Excel 워크북이 포함된 경우, PDF 수신자가 슬라이드와 함께 워크북 데이터를 액세스할 수 있도록 할 수 있습니다. `true`와 함께 [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/)를 호출하면 임베드된 OLE 파일을 결과 PDF의 첨부 파일로 보존합니다.

기본값은 `false`이며, 이 경우 OLE 객체의 미리보기 이미지 또는 아이콘만 PDF 페이지에 렌더링되고 임베드된 파일은 첨부 파일로 포함되지 않습니다. 옵션을 `true`로 설정하면 파일 데이터도 추가로 포함됩니다. 미리보기는 시각적 표현으로 남고, 첨부 파일은 수신자가 별도로 열거나 저장할 수 있도록 합니다. OLE 객체가 PDF 페이지에서 인터랙티브한 Excel 워크시트로 변환되지는 않습니다.

다음 예제는 이미 임베드된 Excel 워크북을 포함하고 있는 프레젠테이션을 로드하고 워크북을 첨부 파일로 포함하여 PDF로 내보냅니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

결과를 확인하려면:

1. 파일 첨부 기능을 지원하는 뷰어(예: Adobe Acrobat Reader)에서 내보낸 PDF를 엽니다.
2. 뷰어의 **Attachments** 패널을 열고 임베드된 워크북을 찾습니다.
3. 첨부 파일을 저장하고 Excel에서 열어 데이터를 검사하거나, 뷰어가 허용한다면 직접 엽니다. PDF 페이지의 미리보기는 첨부 파일과 별개입니다.

{{% alert color="info" title="Note" %}}

PDF/A 표준은 첨부 파일에 제한을 둡니다. PDF/A‑1은 임베드된 파일을 금지하고, PDF/A‑2는 PDF/A 첨부 파일만 허용하며, PDF/A‑3은 Excel 워크북을 포함한 기타 파일 유형을 허용합니다. 이는 표준 자체의 요구 사항이며 Aspose.Slides에만 적용되는 제한이 아닙니다. 이 예제는 기본 PDF 규정 준수 설정을 사용하며 PDF/A 내보내기를 시연하지 않습니다.

{{% /alert %}}

### **숨겨진 슬라이드를 포함하여 PowerPoint를 PDF로 변환**

프레젠테이션에 숨겨진 슬라이드가 포함된 경우, [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 클래스의 [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 메서드를 사용해 숨겨진 슬라이드를 결과 PDF의 페이지로 포함할 수 있습니다.

다음 예제는 숨겨진 슬라이드를 포함해 프레젠테이션을 PDF로 내보냅니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **비밀번호로 보호된 PDF로 PowerPoint 변환**

다음 예제는 `password`라는 비밀번호로 열어야 하는 PDF로 프레젠테이션을 내보냅니다. 접근 권한은 인쇄, 고품질 인쇄를 허용합니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **글꼴 대체 감지**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 클래스 아래의 [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) 메서드를 제공하여 프레젠테이션‑to‑PDF 변환 중 발생하는 글꼴 대체를 감지할 수 있습니다.

다음 예제는 프레젠테이션을 PDF로 내보내고 글꼴 대체 경고를 콘솔에 출력합니다. 사용 가능한 글꼴이 없을 때만 경고가 출력됩니다.

```cpp
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

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

글꼴 대체에 대한 자세한 내용은 [Font Substitution](/slides/ko/cpp/font-substitution/) 문서를 참조하십시오.

{{% /alert %}} 

### **전용 Bold 글꼴이 없는 경우 처리**

프레젠테이션은 해당 글꼴에 전용 Bold 체가 없더라도 텍스트에 굵게 서식을 적용할 수 있습니다. 이 경우 텍스트는 인공적으로 두껍게 표시됩니다. PDF에서 해당 텍스트가 너무 무겁게 보이거나 의도와 다르게 보일 경우, `true`와 함께 [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/)를 호출해 보십시오. 이 옵션은 PDF 내보내기 시 해당 텍스트를 비트맵으로 렌더링하여 특정 글꼴에 대한 외관을 개선할 수 있습니다. 기본값은 `false`입니다.

샘플 프레젠테이션에는 일반 텍스트 상자와 전용 Bold 체가 없는 동일한 글꼴에 굵게 서식이 적용된 텍스트 상자가 포함되어 있습니다. 다음 예제는 프레젠테이션을 로드하고 전용 Bold가 없는 글꼴 스타일의 래스터화를 활성화한 뒤 PDF로 내보냅니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_RasterizeUnsupportedFontStyles(true);

auto presentation = MakeObject<Presentation>(u"unsupported-bold.pptx");
presentation->Save(u"rasterized.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

다음 미리보기는 옵션이 비활성화된 출력과 활성화된 출력을 보여줍니다. 이 예제에서 옵션이 비활성화된 경우 굵은 텍스트의 획이 더 두껍게 표시됩니다. 옵션을 활성화하면 굵은 텍스트의 획이 더 얇아지고, 일반 텍스트는 변함이 없습니다. 프레젠테이션에 적용할 설정을 선택하기 전에 결과를 비교하십시오.

| 옵션 비활성화 (`false`, 기본값) | 옵션 활성화 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

이 예제에서 옵션을 활성화하면 굵은 텍스트만 비트맵으로 변환됩니다. 비트맵 텍스트는 OCR 없이 선택, 복사 또는 검색할 수 없으며, 800 % 확대 시 가장자리가 더 부드럽게 보입니다. 일반 텍스트는 그대로 검색 가능하게 유지됩니다. 옵션을 비활성화하면 두 문자열 모두 텍스트 형태로 남습니다.

이 옵션은 전용 Bold 체가 없는 경우 굵게 서식된 텍스트를 래스터화합니다. [Font substitution](/slides/ko/cpp/font-substitution/)은 원본 글꼴이 없을 때 다른 글꼴을 선택합니다.

## **프레젠테이션에서 선택된 슬라이드만 PDF로 변환**

다음 예제는 프레젠테이션에서 슬라이드 1과 3을 선택해 PDF로 내보냅니다. 배열의 슬라이드 번호는 1부터 시작하며, 입력 프레젠테이션에는 최소 세 개의 슬라이드가 포함되어 있어야 합니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **맞춤 슬라이드 크기로 PowerPoint를 PDF로 변환**

다음 예제는 프레젠테이션의 첫 슬라이드를 새 프레젠테이션으로 복사하고 슬라이드 크기를 612 × 792 포인트(8.5 × 11 인치)로 설정합니다. 슬라이드 콘텐츠를 맞추어 크기를 조정하고 단일 슬라이드를 PDF로 내보냅니다.

```cpp
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

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **노트 슬라이드 보기로 PowerPoint를 PDF에 변환**

다음 예제는 프레젠테이션을 PDF로 내보내며 각 슬라이드 아래에 발표자 노트를 배치합니다. 결과를 확인하려면 발표자 노트가 포함된 프레젠테이션을 사용하십시오.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **PDF에 대한 접근성 및 규정 준수 표준**

Aspose.Slides는 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 를 준수하는 변환 절차를 사용할 수 있도록 합니다. 다음 규정 준수 표준 중 하나를 사용해 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, **PDF/UA**.

다음 C++ 코드는 다양한 규정 준수 표준에 따라 여러 PDF를 생성하는 PowerPoint‑to‑PDF 변환 프로세스를 보여줍니다:

```cpp
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

{{% alert color="info" title="Note" %}}

Aspose.Slides는 PDF 변환 작업을 지원하며, PDF 파일을 다양한 형식으로 변환할 수 있습니다. [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), [PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) 변환이 가능합니다. 또한 [PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), [PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) 등 특수 형식으로의 변환도 지원합니다.

{{% /alert %}}

> **참고:** PDF/UA로 내보낼 때 Aspose.Slides는 SmartArt, 차트, 수식과 같은 복합 그래픽을 단일 도형으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며 아티팩트로 표시될 수 있습니다; 대체 텍스트는 전체 도형에만 제공됩니다.

## **FAQ**

**여러 PowerPoint 파일을 한 번에 PDF로 변환할 수 있나요?**

예, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 일괄적으로 PDF로 변환하는 배치 변환을 지원합니다. 파일을 반복하면서 프로그래밍 방식으로 변환 프로세스를 적용할 수 있습니다.

**변환된 PDF에 비밀번호를 설정할 수 있나요?**

예. 변환 과정에서 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 클래스를 사용해 비밀번호를 설정하고 접근 권한을 정의할 수 있습니다.

**PDF에 숨겨진 슬라이드를 포함하려면 어떻게 해야 하나요?**

[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 클래스의 [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 메서드를 사용해 결과 PDF에 숨겨진 슬라이드를 포함시킬 수 있습니다.

**Aspose.Slides가 PDF에서 높은 이미지 품질을 유지할 수 있나요?**

예. [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 클래스의 [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) 및 [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) 메서드를 사용해 PDF 내 이미지 품질을 고품질로 유지할 수 있습니다.

**Aspose.Slides가 PDF/A 규정 준수 표준을 지원하나요?**

예. Aspose.Slides는 PDF/A1a, PDF/A1b, PDF/UA 등 다양한 규정 준수 표준에 맞는 PDF를 내보낼 수 있어 문서가 접근성 및 보존 요구 사항을 충족하도록 합니다.

## **추가 리소스**

- [Aspose.Slides for C++ Documentation](/slides/ko/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)