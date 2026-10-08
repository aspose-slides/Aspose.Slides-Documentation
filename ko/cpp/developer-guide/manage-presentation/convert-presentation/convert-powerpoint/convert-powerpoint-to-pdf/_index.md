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
description: "Aspose.Slides를 사용하여 C++에서 PowerPoint PPT/PPTX를 고품질이며 검색 가능한 PDF로 변환합니다. 빠른 코드 예제와 고급 변환 옵션을 제공합니다."
---
## **개요**

C++에서 PowerPoint 프레젠테이션(PPT, PPTX, ODP 등)을 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 다양한 장치 간 호환성 및 프레젠테이션의 레이아웃과 서식을 보존하는 것이 포함됩니다. 이 가이드는 프레젠테이션을 PDF 문서로 변환하고, 이미지 품질을 제어하는 다양한 옵션을 사용하며, 숨겨진 슬라이드를 포함하고, PDF 파일에 비밀번호를 설정하고, 폰트 치환을 감지하고, 변환할 특정 슬라이드를 선택하며, 출력 문서에 규정 준수 표준을 적용하는 방법을 보여줍니다.

## **PowerPoint to PDF 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다:

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 인수로 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 클래스에 전달한 다음, [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 메서드를 사용하여 프레젠테이션을 PDF로 저장합니다. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 메서드를 제공합니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++는 API 정보와 버전 번호를 출력 문서에 삽입합니다. 예를 들어, 프레젠테이션을 PDF로 변환할 때 Aspose.Slides는 Application 필드에 "*Aspose.Slides*"를, PDF Producer 필드에 "*Aspose.Slides v XX.XX*" 형태의 값을 채웁니다. **참고** 이 정보는 Aspose.Slides에 의해 출력 문서에서 변경하거나 제거할 수 없습니다.
{{% /alert %}}

Aspose.Slides는 다음과 같이 변환할 수 있습니다:

* 전체 프레젠테이션을 PDF로 변환
* 프레젠테이션의 특정 슬라이드를 PDF로 변환

Aspose.Slides는 프레젠테이션을 PDF로 내보내며, 결과 PDF가 원본 프레젠테이션과 매우 가깝게 일치하도록 합니다. 변환 시 요소와 속성이 정확하게 렌더링됩니다. 포함 항목:

* 이미지
* 텍스트 상자 및 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리 기호
* 표

## **PowerPoint를 PDF로 변환**

표준 PowerPoint‑to‑PDF 변환 프로세스는 기본 옵션을 사용합니다. 이 경우 Aspose.Slides는 최적의 설정과 최대 품질 수준을 사용하여 제공된 프레젠테이션을 PDF로 변환하려고 합니다.

다음 예제는 프레젠테이션을 로드하고 기본 내보내기 설정을 사용하여 모든 보이는 슬라이드를 PDF로 저장합니다.

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
Aspose는 무료 온라인 [**PowerPoint to PDF 변환기**](https://products.aspose.app/slides/conversion/ppt-to-pdf)를 제공하여 프레젠테이션‑to‑PDF 변환 프로세스를 보여줍니다. 이 변환기로 테스트를 실행하여 여기서 설명한 절차를 실시간으로 확인할 수 있습니다.
{{% /alert %}}

## **옵션을 사용한 PowerPoint를 PDF로 변환**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 클래스 아래의 사용자 지정 옵션(속성)을 제공하여 결과 PDF를 사용자 지정하고, 비밀번호로 PDF를 잠그며, 변환 프로세스 진행 방식을 지정할 수 있습니다.

### **사용자 지정 옵션을 사용한 PowerPoint를 PDF로 변환**

사용자 지정 변환 옵션을 사용하면 래스터 이미지에 대한 선호 품질 설정을 정의하고, 메타파일 처리 방식을 지정하고, 텍스트에 대한 압축 수준을 설정하고, 이미지에 대한 DPI를 구성하는 등 다양한 작업을 수행할 수 있습니다.

다음 예제는 JPEG 품질을 90으로, 이미지 해상도를 300 DPI로, 메타파일을 PNG로 저장하고, Flate 텍스트 압축을 적용하여 PDF 1.5로 프레젠테이션을 내보냅니다.

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

### **PDF 첨부 파일로 OLE 파일 보존**

프레젠테이션에 포함된 Excel 워크북이 있는 경우 PDF 수신자가 워크북 데이터를 접근하고 슬라이드를 볼 수 있기를 원할 수 있습니다. `true`와 함께 [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/)를 호출하면 포함된 OLE 파일을 결과 PDF의 첨부 파일로 보존합니다.

기본값은 `false`이며, OLE 객체의 미리보기 이미지 또는 아이콘은 PDF 페이지에 렌더링되지만 첨부 파일 자체는 포함되지 않습니다. 옵션을 `true`로 설정하면 파일 데이터가 추가로 포함됩니다. 미리보기는 시각적 표현으로 남고, 첨부 파일을 통해 수신자는 파일을 별도로 열거나 저장할 수 있습니다. OLE 객체가 PDF 페이지에서 인터랙티브한 Excel 워크시트가 되는 것은 아닙니다.

다음 예제는 이미 Excel 워크북이 포함된 프레젠테이션을 로드하고 워크북을 첨부 파일로 포함하여 PDF로 내보냅니다.

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

1. Adobe Acrobat Reader와 같이 파일 첨부를 지원하는 뷰어에서 내보낸 PDF를 엽니다.
2. 뷰어의 **첨부 파일** 패널을 열고 포함된 워크북을 찾습니다.
3. 첨부 파일을 저장하고 Excel에서 열어 데이터를 확인하거나, 뷰어가 허용하는 경우 직접 엽니다. PDF 페이지의 미리보기와 첨부 파일은 별개입니다.

{{% alert color="info" title="Note" %}}
PDF/A 표준은 첨부 파일에 제한을 둡니다. PDF/A‑1은 첨부 파일을 금지하고, PDF/A‑2는 PDF/A 첨부 파일만 허용하며, PDF/A‑3은 Excel 워크북을 포함한 기타 파일 형식을 허용합니다. 이는 표준 자체의 요구 사항이며 Aspose.Slides에 특화된 제한이 아닙니다. 이 예제는 기본 PDF 규정 준수 설정을 사용하며 PDF/A 내보내기를 보여주지는 않습니다.
{{% /alert %}}

### **숨겨진 슬라이드 포함하여 PowerPoint를 PDF로 변환**

프레젠테이션에 숨겨진 슬라이드가 있는 경우 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 클래스의 [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 메서드를 사용하여 숨겨진 슬라이드를 결과 PDF의 페이지에 포함시킬 수 있습니다.

다음 예제는 숨겨진 슬라이드를 포함하여 프레젠테이션을 PDF로 내보냅니다.

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

### **비밀번호가 설정된 PDF로 PowerPoint 변환**

다음 예제는 열 때 비밀번호 `password`가 필요한 PDF로 프레젠테이션을 내보냅니다. 접근 권한은 인쇄를 허용하며, 고품질 인쇄도 포함됩니다.

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

### **폰트 치환 감지**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 클래스 아래의 [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) 메서드를 제공하여 프레젠테이션‑to‑PDF 변환 과정에서 폰트 치환을 감지할 수 있게 합니다.

다음 예제는 프레젠테이션을 PDF로 내보내고 콘솔에 폰트 치환 경고를 출력합니다. 사용 불가능한 폰트가 대체될 때만 경고가 출력됩니다.

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
폰트 치환에 대한 자세한 내용은 [폰트 치환](/slides/ko/cpp/font-substitution/) 문서를 참조하십시오.
{{% /alert %}} 

### **전용 굵은 글꼴이 없는 경우 처리**

프레젠테이션은 해당 폰트에 전용 굵은 글꼴이 없더라도 텍스트에 굵게 서식을 적용할 수 있습니다. 이 경우 인공 굵게 적용을 통해 일반 글리프를 인위적으로 두껍게 표시합니다. PDF에서 해당 텍스트가 너무 무겁게 보이거나 의도와 다르게 표시될 경우, `true`와 함께 [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/)를 호출해 보십시오. 이 옵션은 PDF 내보내기 시 영향을 받는 텍스트를 비트맵으로 렌더링하여 특정 폰트에 대한 표시 품질을 개선할 수 있습니다. 기본값은 `false`입니다.

샘플 프레젠테이션에는 두 개의 텍스트 상자가 포함되어 있습니다. 하나는 일반 텍스트이고, 다른 하나는 전용 굵은 글꼴이 없는 동일 폰트에 굵게 서식이 적용된 텍스트입니다. 다음 예제는 프레젠테이션을 로드하고 전용 굵은 글꼴이 없는 경우 텍스트 스타일을 래스터화하도록 설정한 뒤 PDF로 내보냅니다.

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

다음 미리보기는 옵션이 비활성화된 출력과 활성화된 출력을 보여줍니다. 이 예제에서는 옵션이 비활성화된 경우 굵은 텍스트의 획이 더 두껍게 표시됩니다. 옵션을 활성화하면 굵은 텍스트의 획이 더 가벼워지고, 일반 텍스트는 변경되지 않습니다. 결과를 비교한 후 프레젠테이션에 적합한 설정을 선택하십시오.

| 옵션 비활성화 (`false`, 기본값) | 옵션 활성화 (`true`) |
|---|---|
| ![지원되지 않는 굵은 글꼴 스타일 래스터화 비활성화된 PDF](unsupported-bold-disabled.png) | ![지원되지 않는 굵은 글꼴 스타일 래스터화 활성화된 PDF](unsupported-bold-enabled.png) |

이 예제에서 옵션을 활성화하면 굵은 텍스트만 비트맵으로 변환됩니다. 비트맵 텍스트는 OCR 없이 선택, 복사 또는 검색할 수 없으며 800% 확대 시 가장자리가 더 부드럽게 보입니다. 일반 텍스트는 검색 가능 상태를 유지합니다. 옵션을 비활성화하면 두 문자열 모두 텍스트 형태로 유지됩니다.

이 옵션은 폰트에 전용 굵은 글꼴이 없는 경우 굵게 서식이 적용된 텍스트를 래스터화합니다. [폰트 치환](/slides/ko/cpp/font-substitution/)은 원본 폰트를 사용할 수 없을 때 다른 폰트를 선택합니다.

## **PowerPoint에서 선택한 슬라이드만 PDF로 변환**

다음 예제는 프레젠테이션에서 슬라이드 1과 3을 선택하여 PDF로 내보냅니다. 배열에 포함된 슬라이드 번호는 1부터 시작하며, 입력 프레젠테이션에 최소 세 개의 슬라이드가 있어야 합니다.

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

다음 예제는 프레젠테이션의 첫 번째 슬라이드를 새 프레젠테이션으로 복사하고 슬라이드 크기를 612 × 792 포인트(8.5 × 11 인치)로 설정합니다. 슬라이드 내용을 맞춰 스케일링하고 단일 슬라이드를 PDF로 내보냅니다.

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

## **노트 슬라이드 보기에서 PowerPoint를 PDF로 변환**

다음 예제는 프레젠테이션을 PDF로 내보내면서 각 슬라이드의 발표자 노트를 슬라이드 아래에 배치합니다. 결과를 확인하려면 발표자 노트가 포함된 프레젠테이션을 사용하십시오.

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

Aspose.Slides는 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 을 준수하는 변환 절차를 사용할 수 있게 합니다. 다음 규정 준수 표준 중 원하는 것을 선택하여 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, 그리고 **PDF/UA**.

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
Aspose.Slides는 PDF 변환 작업을 지원하므로 PDF 파일을 다양한 일반 형식으로 변환할 수 있습니다. [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), [PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) 변환을 수행할 수 있습니다. 또한 특수 형식에 대한 변환도 지원합니다: [PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), [PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) 변환이 가능합니다.
{{% /alert %}}

> **참고:** PDF/UA로 내보낼 때 Aspose.Slides는 SmartArt, 차트, 수식과 같은 복합 그래픽을 단일 그림으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며, 아티팩트로 표시될 수 있습니다; 대체 텍스트는 전체 그림에만 제공됩니다.

## **자주 묻는 질문**

**여러 PowerPoint 파일을 한 번에 PDF로 변환할 수 있나요?**

예, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 PDF로 일괄 변환하는 기능을 지원합니다. 파일을 순회하면서 프로그램matically 변환 프로세스를 적용할 수 있습니다.

**변환된 PDF에 비밀번호를 설정할 수 있나요?**

예. 변환 과정 중 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 클래스를 사용하여 비밀번호를 설정하고 접근 권한을 정의할 수 있습니다.

**PDF에 숨겨진 슬라이드를 포함하려면 어떻게 해야 하나요?**

[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 클래스의 [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 메서드를 사용하여 결과 PDF에 숨겨진 슬라이드를 포함시킬 수 있습니다.

**Aspose.Slides가 PDF에서 높은 이미지 품질을 유지할 수 있나요?**

예. [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 클래스의 [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) 및 [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) 메서드를 사용하여 PDF에 고품질 이미지를 보장할 수 있습니다.

**Aspose.Slides가 PDF/A 규정 준수 표준을 지원하나요?**

예. Aspose.Slides는 PDF/A1a, PDF/A1b, PDF/UA 등 다양한 표준을 준수하는 PDF를 내보낼 수 있어 문서가 접근성 및 보존 요구 사항을 충족하도록 합니다.

## **추가 자료**

- [Aspose.Slides for C++ Documentation](/slides/ko/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)