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
description: "Aspose.Slides를 사용하여 C++에서 PowerPoint PPT/PPTX를 고품질이며 검색 가능한 PDF로 변환하고, 빠른 코드 예제와 고급 변환 옵션을 제공합니다."
---
## **개요**

C++에서 PowerPoint 프레젠테이션(PPT, PPTX, ODP 등)을 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 다양한 장치 간 호환성 및 프레젠테이션의 레이아웃과 서식을 보존하는 것이 포함됩니다. 이 가이드는 프레젠테이션을 PDF 문서로 변환하는 방법, 이미지 품질을 제어하는 다양한 옵션 사용, 숨긴 슬라이드 포함, PDF 파일에 비밀번호 설정, 글꼴 대체 감지, 특정 슬라이드 선택 변환, 그리고 출력 문서에 준수 표준을 적용하는 방법을 보여줍니다.

## **PowerPoint to PDF 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다:

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 인수로 전달하여 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 생성한 다음 `Save` 메서드를 사용해 PDF로 저장합니다. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 `Save` 메서드를 제공합니다.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++는 API 정보와 버전 번호를 출력 문서에 삽입합니다. 예를 들어 프레젠테이션을 PDF로 변환할 때 Aspose.Slides는 Application 필드에 "*Aspose.Slides*"를, PDF Producer 필드에 "*Aspose.Slides v XX.XX*" 형식의 값을 채웁니다. **Note** 이 정보는 출력 문서에서 변경하거나 제거하도록 Aspose.Slides에 지시할 수 없습니다.

{{% /alert %}}

Aspose.Slides를 사용하면 다음과 같이 변환할 수 있습니다:

* 전체 프레젠테이션을 PDF로
* 프레젠테이션의 특정 슬라이드를 PDF로

Aspose.Slides는 프레젠테이션을 PDF로 내보내며, 결과 PDF가 원본 프레젠테이션과 거의 동일하게 매치되도록 합니다. 변환 시 다음 요소와 속성이 정확하게 렌더링됩니다:

* 이미지
* 텍스트 상자 및 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리표
* 표

## **PowerPoint를 PDF로 변환**

표준 PowerPoint‑to‑PDF 변환 프로세스는 기본 옵션을 사용합니다. 이 경우 Aspose.Slides는 최적의 설정과 최대 품질 레벨을 사용하여 제공된 프레젠테이션을 PDF로 변환하려고 시도합니다.

다음 C++ 코드가 PPT, PPTX, ODP 등 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다:

```c++
// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Save the presentation as a PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose는 무료 온라인 [**PowerPoint to PDF 변환기**](https://products.aspose.app/slides/ko/conversion/ppt-to-pdf)를 제공하여 프레젠테이션‑to‑PDF 변환 프로세스를 시연합니다. 여기에서 변환기를 사용해 본문에서 설명한 절차를 실제로 테스트해 볼 수 있습니다.

{{% /alert %}}

## **옵션을 사용한 PowerPoint를 PDF로 변환**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/) 클래스 아래의 사용자 지정 옵션(속성)을 제공하여 결과 PDF를 맞춤 설정하거나 비밀번호로 잠그거나 변환 프로세스 진행 방식을 지정할 수 있습니다.

### **맞춤 옵션을 사용한 PowerPoint를 PDF로 변환**

맞춤 변환 옵션을 사용하면 래스터 이미지에 대한 선호 품질 설정, 메타파일 처리 방법, 텍스트 압축 수준, 이미지 DPI 등을 정의할 수 있습니다.

아래 코드 예제는 여러 맞춤 옵션을 적용해 PowerPoint 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다.

```c++
// PdfOptions 클래스를 인스턴스화합니다.
auto pdfOptions = MakeObject<PdfOptions>();

// JPG 이미지의 품질을 설정합니다.
pdfOptions->set_JpegQuality(90);

// 이미지의 DPI를 설정합니다.
pdfOptions->set_SufficientResolution(300);

// 메타파일의 동작을 설정합니다.
pdfOptions->set_SaveMetafilesAsPng(true);

// 텍스트 콘텐츠에 대한 압축 수준을 설정합니다.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// PDF 준수 모드를 정의합니다.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 프레젠테이션을 PDF 문서로 저장합니다.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **숨겨진 슬라이드를 포함한 PowerPoint를 PDF로 변환**

프레젠테이션에 숨긴 슬라이드가 포함되어 있는 경우, [PdfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/) 클래스의 [set_ShowHiddenSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 메서드를 사용해 숨긴 슬라이드를 결과 PDF의 페이지로 포함시킬 수 있습니다.

다음 C++ 코드는 숨긴 슬라이드를 포함해 PowerPoint 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다:

```c++
// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptions 클래스를 인스턴스화합니다.
auto pdfOptions = MakeObject<PdfOptions>();

// 숨긴 슬라이드를 추가합니다.
pdfOptions->set_ShowHiddenSlides(true);

// 프레젠테이션을 PDF로 저장합니다.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **비밀번호로 보호된 PDF로 PowerPoint 변환**

이 С++ 코드는 [PdfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/) 클래스의 보호 매개변수를 사용해 PowerPoint 프레젠테이션을 비밀번호로 보호된 PDF로 변환하는 방법을 시연합니다:

```c++
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

### **폰트 대체 감지**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/) 클래스 아래에 있는 [set_WarningCallback](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveoptions/set_warningcallback/) 메서드를 제공하여 프레젠테이션‑to‑PDF 변환 과정에서 글꼴 대체를 감지할 수 있습니다.

다음 C++ 코드는 글꼴 대체를 감지하는 방법을 보여줍니다:

```c++
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

{{%  alert color="primary"  %}} 

렌더링 과정에서 글꼴 대체에 대한 콜백을 받는 방법에 대한 자세한 내용은 [Getting Warning Callbacks for Fonts Substitution](/slides/ko/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)을 참고하십시오.

글꼴 대체에 대한 자세한 내용은 [Font Substitution](/slides/ko/cpp/font-substitution/) 문서를 확인하십시오.

{{% /alert %}} 

## **PowerPoint에서 선택된 슬라이드만 PDF로 변환**

다음 C++ 코드는 PowerPoint 프레젠테이션에서 특정 슬라이드만 선택해 PDF로 변환하는 방법을 보여줍니다:

```C++
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
auto slideWidth = 612;
auto slideHeight = 792;

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// 조정된 슬라이드 크기로 새로운 프레젠테이션을 생성합니다.
auto resizedPresentation = MakeObject<Presentation>();

// 사용자 정의 슬라이드 크기를 설정합니다.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// 원본 프레젠테이션에서 첫 번째 슬라이드를 복제합니다.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// 조정된 프레젠테이션을 노트가 포함된 PDF로 저장합니다.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **노트 슬라이드 보기에서 PowerPoint를 PDF로 변환**

다음 C++ 코드는 노트를 포함한 PDF를 생성하도록 PowerPoint 프레젠테이션을 변환하는 방법을 보여줍니다:

```C++
// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Configure the PDF options with Notes Layout.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to a PDF with notes.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **PDF에 대한 접근성 및 준수 표준**

Aspose.Slides는 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 를 준수하는 변환 절차를 사용할 수 있도록 지원합니다. 다음 준수 표준 중 하나를 사용해 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, **PDF/UA**.

다음 C++ 코드는 다양한 준수 표준에 따라 여러 개의 PDF를 생성하는 PowerPoint‑to‑PDF 변환 프로세스를 보여줍니다:

```C++
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

Aspose.Slides는 PDF 변환 작업을 지원하며, PDF 파일을 다양한 일반 형식으로 변환할 수 있습니다. [PDF to HTML](https://products.aspose.com/slides/ko/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/ko/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/ko/cpp/conversion/pdf-to-jpg/), [PDF to PNG](https://products.aspose.com/slides/ko/cpp/conversion/pdf-to-png/) 변환을 수행할 수 있습니다. 또한 [PDF to SVG](https://products.aspose.com/slides/ko/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/ko/cpp/conversion/pdf-to-tiff/), [PDF to XML](https://products.aspose.com/slides/ko/cpp/conversion/pdf-to-xml/)과 같은 특수 형식으로의 변환도 지원됩니다.

{{% /alert %}}

> **Note:** PDF/UA로 내보낼 때 Aspose.Slides는 SmartArt, 차트, 수식과 같은 복잡한 그래픽을 단일 도형으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며 아티팩트로 표시될 수 있으며, 대체 텍스트는 전체 도형에만 제공됩니다.

## **FAQ**

**여러 PowerPoint 파일을 한 번에 대량으로 PDF로 변환할 수 있나요?**

예, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 PDF로 일괄 변환하는 기능을 지원합니다. 파일을 순회하면서 프로그래밍 방식으로 변환 프로세스를 적용할 수 있습니다.

**변환된 PDF에 비밀번호를 설정할 수 있나요?**

물론 가능합니다. 변환 과정에서 [PdfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/) 클래스를 사용해 비밀번호와 접근 권한을 지정하십시오.

**PDF에 숨겨진 슬라이드를 포함하려면 어떻게 해야 하나요?**

[PdfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/) 클래스의 `set_ShowHiddenSlides` 메서드를 사용해 숨겨진 슬라이드를 결과 PDF에 포함시킬 수 있습니다.

**Aspose.Slides가 PDF에서 높은 이미지 품질을 유지하도록 할 수 있나요?**

예, [PdfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/) 클래스의 `set_JpegQuality`와 `set_SufficientResolution` 같은 메서드를 사용해 이미지 품질을 고품질로 유지하도록 제어할 수 있습니다.

**Aspose.Slides가 PDF/A 준수 표준을 지원하나요?**

예, Aspose.Slides는 PDF/A1a, PDF/A1b, PDF/UA와 같은 다양한 표준을 준수하는 PDF를 내보낼 수 있어 문서가 접근성 및 보관 요구 사항을 만족하도록 합니다.

## **Additional Resources**

- [Aspose.Slides for C++ Documentation](/slides/ko/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/ko/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/ko/conversion)