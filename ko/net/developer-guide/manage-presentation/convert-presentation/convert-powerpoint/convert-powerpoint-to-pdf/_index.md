---
title: .NET에서 PPT 및 PPTX를 PDF로 변환 [고급 기능 포함]
linktitle: PowerPoint를 PDF로
type: docs
weight: 40
url: /ko/net/convert-powerpoint-to-pdf/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides를 사용하여 .NET에서 PowerPoint PPT/PPTX를 고품질의 검색 가능한 PDF로 변환합니다. 빠른 C# 코드 예제와 고급 변환 옵션을 제공합니다."
---
## **개요**

C#에서 PowerPoint 프레젠테이션(PPT, PPTX, ODP 등)을 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 다양한 장치 간 호환성 및 프레젠테이션의 레이아웃과 서식을 보존하는 것이 포함됩니다. 이 가이드는 프레젠테이션을 PDF 문서로 변환하는 방법, 이미지 품질을 제어하는 다양한 옵션 사용, 숨겨진 슬라이드 포함, PDF 파일에 비밀번호 보호, 글꼴 대체 감지, 변환할 특정 슬라이드 선택, 출력 문서에 규격 적용 방법을 보여줍니다.

## **PowerPoint를 PDF로 변환**

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인수로 전달한 다음 [Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/) 메서드를 사용하여 PDF로 저장합니다. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 [Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/) 메서드를 제공합니다.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for .NET은 출력 문서에 API 정보와 버전 번호를 삽입합니다. 예를 들어 프레젠테이션을 PDF로 변환할 때 Aspose.Slides는 Application 필드에 "*Aspose.Slides*"를, PDF Producer 필드에 "*Aspose.Slides v XX.XX*" 형식의 값을 채웁니다. **Note** 이 정보는 Aspose.Slides가 출력 문서에서 변경하거나 제거하도록 할 수 없습니다.
{{% /alert %}}

Aspose.Slides를 사용하면 다음을 변환할 수 있습니다:

* 전체 프레젠테이션을 PDF로
* 프레젠테이션의 특정 슬라이드를 PDF로

Aspose.Slides는 프레젠테이션을 PDF로 내보내어 결과 PDF가 원본 프레젠테이션과 가깝게 일치하도록 합니다. 변환 시 요소와 속성이 정확하게 렌더링됩니다, 포함 항목:

* 이미지
* 텍스트 상자 및 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리표
* 표

## **PowerPoint를 PDF로 변환**

표준 PowerPoint에서 PDF로 변환하는 과정은 기본 옵션을 사용합니다. 이 경우 Aspose.Slides는 최적 설정과 최대 품질 수준을 사용하여 제공된 프레젠테이션을 PDF로 변환하려고 시도합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using var presentation = new Presentation("PowerPoint.ppt");

// 프레젠테이션을 PDF로 저장합니다.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 
Aspose는 프레젠테이션을 PDF로 변환하는 과정을 보여주는 무료 온라인 [**PowerPoint to PDF converter**](https://products.aspose.app/slides/ko/conversion/ppt-to-pdf)를 제공합니다. 여기에서 설명한 절차를 실제로 구현하려면 이 변환기로 테스트를 실행할 수 있습니다.
{{% /alert %}}

## **옵션을 사용한 PowerPoint를 PDF로 변환**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/) 클래스 아래의 속성인 사용자 지정 옵션을 제공하여 결과 PDF를 사용자화하고, 비밀번호로 PDF를 잠그며, 변환 프로세스 진행 방식을 지정할 수 있습니다.

### **사용자 지정 옵션을 사용한 PowerPoint를 PDF로 변환**

사용자 지정 변환 옵션을 사용하면 래스터 이미지에 대한 원하는 품질 설정을 정의하고, 메타파일 처리 방식을 지정하며, 텍스트 압축 수준을 설정하고, 이미지 DPI를 구성하는 등 다양한 설정을 할 수 있습니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PdfOptions 클래스를 인스턴스화합니다.
var pdfOptions = new PdfOptions
{
    // JPG 이미지의 품질을 설정합니다.
    JpegQuality = 90,

    // 이미지의 DPI를 설정합니다.
    SufficientResolution = 300,

    // 메타파일에 대한 동작을 설정합니다.
    SaveMetafilesAsPng = true,

    // 텍스트 콘텐츠에 대한 압축 수준을 설정합니다.
    TextCompression = PdfTextCompression.Flate,

    // PDF 규격 모드를 정의합니다.
    Compliance = PdfCompliance.Pdf15
};

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using var presentation = new Presentation("PowerPoint.pptx");

// 프레젠테이션을 PDF 문서로 저장합니다.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **숨겨진 슬라이드를 포함한 PowerPoint를 PDF로 변환**

프레젠테이션에 숨겨진 슬라이드가 포함되어 있는 경우, [PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/) 클래스의 [ShowHiddenSlides](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/showhiddenslides/) 속성을 사용하여 숨겨진 슬라이드를 결과 PDF의 페이지로 포함할 수 있습니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using var presentation = new Presentation("PowerPoint.pptx");

// PdfOptions 클래스를 인스턴스화합니다.
var pdfOptions = new PdfOptions();

// 숨겨진 슬라이드를 추가합니다.
pdfOptions.ShowHiddenSlides = true;

// 프레젠테이션을 PDF로 저장합니다.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **비밀번호 보호 PDF로 PowerPoint 변환**

다음 C# 코드는 [PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/) 클래스의 보호 매개변수를 사용하여 PowerPoint 프레젠테이션을 비밀번호 보호 PDF로 변환하는 방법을 보여줍니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using var presentation = new Presentation("PowerPoint.pptx");

// PdfOptions 클래스를 인스턴스화합니다.
var pdfOptions = new PdfOptions();

// PDF 비밀번호와 접근 권한을 설정합니다.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// 프레젠테이션을 PDF로 저장합니다.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **글꼴 대체 감지**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/) 클래스 아래에 [WarningCallback](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveoptions/warningcallback/) 속성을 제공하여 프레젠테이션을 PDF로 변환하는 동안 글꼴 대체를 감지할 수 있게 합니다.

다음 C# 코드는 글꼴 대체를 감지하는 방법을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

public static void Main()
{
    // PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다. 
    using var presentation = new Presentation("sample.pptx");

    // PDF 옵션에 경고 콜백을 설정합니다.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // 프레젠테이션을 PDF로 저장합니다.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// 경고 콜백 구현.
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="info"  %}} 
렌더링 과정에서 글꼴 대체에 대한 콜백을 받는 방법에 대한 자세한 내용은 [Getting Warning Callbacks for Fonts Substitution](/slides/ko/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)을 참조하십시오. 글꼴 대체에 대한 자세한 내용은 [Font Substitution](/slides/ko/net/font-substitution/) 문서를 확인하십시오.
{{% /alert %}} 

## **PowerPoint에서 선택한 슬라이드만 PDF로 변환**

다음 C# 코드는 PowerPoint 프레젠테이션에서 특정 슬라이드만 선택하여 PDF로 변환하는 방법을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using var presentation = new Presentation("PowerPoint.pptx");

// 슬라이드 번호 배열을 설정합니다.
int[] slides = { 1, 3 };

// 프레젠테이션을 PDF로 저장합니다.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **사용자 지정 슬라이드 크기로 PowerPoint를 PDF로 변환**

다음 C# 코드는 지정된 슬라이드 크기로 PowerPoint 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);

// Save the resized presentation as a PDF.
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **노트 슬라이드 보기로 PowerPoint를 PDF로 변환**

다음 C# 코드는 노트를 포함한 PDF로 PowerPoint 프레젠테이션을 변환하는 방법을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint 프레젠테이션을 로드합니다.
using var presentation = new Presentation("NotesFile.pptx");

// 노트 레이아웃으로 PDF 옵션을 구성합니다.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// 노트가 포함된 PDF로 프레젠테이션을 저장합니다.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **PDF 접근성 및 규정 준수 표준**

Aspose.Slides를 사용하면 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 을 준수하는 변환 절차를 사용할 수 있습니다. 다음 규격 중 하나를 사용하여 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, **PDF/UA**.

다음 C# 코드는 서로 다른 규정 준수 표준에 따라 여러 PDF를 생성하는 PowerPoint에서 PDF로의 변환 과정을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert title="Note" color="warning" %}} 
Aspose.Slides는 PDF 변환 작업을 지원하여 PDF 파일을 일반적인 파일 형식으로 변환할 수 있습니다. [PDF to HTML](https://products.aspose.com/slides/ko/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/ko/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/ko/net/conversion/pdf-to-jpg/), [PDF to PNG](https://products.aspose.com/slides/ko/net/conversion/pdf-to-png/) 변환을 수행할 수 있습니다. 또한 특수 형식인 [PDF to SVG](https://products.aspose.com/slides/ko/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/ko/net/conversion/pdf-to-tiff/), [PDF to XML](https://products.aspose.com/slides/ko/net/conversion/pdf-to-xml/) 변환도 지원됩니다.
{{% /alert %}}

> **Note:** PDF/UA로 내보낼 때, Aspose.Slides는 SmartArt, 차트, 수식과 같은 복합 그래픽을 단일 피규어로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며 아티팩트로 표시될 수 있으며, 대체 텍스트는 전체 피규어에만 제공됩니다.

## **FAQ**

### 여러 PowerPoint 파일을 한 번에 PDF로 변환할 수 있나요?

예, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 PDF로 일괄 변환하는 기능을 지원합니다. 파일을 순회하면서 프로그래밍 방식으로 변환 프로세스를 적용할 수 있습니다.

### 변환된 PDF에 비밀번호를 설정할 수 있나요?

네, 가능합니다. 변환 과정에서 비밀번호를 설정하고 접근 권한을 정의하려면 [PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/) 클래스를 사용합니다.

### PDF에 숨겨진 슬라이드를 포함하려면 어떻게 해야 하나요?

`ShowHiddenSlides` 속성을 [PdfOptions] 클래스에서 `true` 로 설정하면 결과 PDF에 숨겨진 슬라이드가 포함됩니다.

### Aspose.Slides가 PDF에서 높은 이미지 품질을 유지할 수 있나요?

예, `JpegQuality` 및 `SufficientResolution` 과 같은 속성을 [PdfOptions] 클래스에서 설정하여 PDF 내 이미지 품질을 높게 유지할 수 있습니다.

### Aspose.Slides가 PDF/A 규격을 지원하나요?

예, Aspose.Slides는 PDF/A1a, PDF/A1b, PDF/UA 등 다양한 규격을 준수하는 PDF를 내보낼 수 있어 문서가 접근성 및 보존 요구 사항을 충족하도록 합니다.

## **추가 리소스**

- [Aspose.Slides for .NET 문서](/slides/ko/net/)
- [Aspose.Slides for .NET API 참조](https://reference.aspose.com/slides/ko/net/)
- [Aspose 무료 온라인 변환기](https://products.aspose.app/slides/ko/conversion)