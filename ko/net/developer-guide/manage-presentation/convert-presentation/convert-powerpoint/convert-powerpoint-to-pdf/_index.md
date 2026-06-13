---
title: PPT 및 PPTX를 .NET에서 PDF로 변환 (고급 기능 포함)
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
description: ".NET에서 Aspose.Slides를 사용하여 PowerPoint PPT/PPTX를 고품질의 검색 가능한 PDF로 변환하고, 빠른 C# 코드 예제와 고급 변환 옵션을 제공합니다."
---
## **개요**

C#에서 PowerPoint 프레젠테이션(PPT, PPTX, ODP 등)을 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 다양한 장치 간 호환성 및 프레젠테이션의 레이아웃과 서식을 유지하는 것이 포함됩니다. 이 가이드에서는 프레젠테이션을 PDF 문서로 변환하는 방법, 이미지 품질을 제어하는 다양한 옵션 사용, 숨겨진 슬라이드 포함, PDF 파일에 비밀번호 보호, 글꼴 대체 감지, 변환할 특정 슬라이드 선택, 출력 문서에 준수 표준 적용 방법을 보여줍니다.

## **PowerPoint to PDF 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다:

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스에 인수로 전달한 후 [Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/) 메서드를 사용하여 프레젠테이션을 PDF로 저장합니다. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 [Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/) 메서드를 제공합니다.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET은 출력 문서에 API 정보와 버전 번호를 삽입합니다. 예를 들어 프레젠테이션을 PDF로 변환할 때 Aspose.Slides는 Application 필드에 "*Aspose.Slides*"를, PDF Producer 필드에 "*Aspose.Slides v XX.XX*" 형식의 값을 채웁니다. **Note** Aspose.Slides에 이 정보를 변경하거나 제거하도록 지시할 수 없습니다.

{{% /alert %}}

Aspose.Slides를 사용하면 다음을 변환할 수 있습니다:

* 전체 프레젠테이션을 PDF로 변환
* 프레젠테이션의 특정 슬라이드를 PDF로 변환

Aspose.Slides는 프레젠테이션을 PDF로 내보내면서 원본 프레젠테이션과 거의 동일한 결과물을 보장합니다. 변환 중에 다음과 같은 요소와 속성이 정확하게 렌더링됩니다:

* 이미지
* 텍스트 상자 및 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리 기호
* 표

## **PowerPoint를 PDF로 변환**

표준 PowerPoint‑to‑PDF 변환 프로세스는 기본 옵션을 사용합니다. 이 경우 Aspose.Slides는 최적의 설정으로 최대 품질 수준에서 제공된 프레젠테이션을 PDF로 변환하려고 시도합니다.

```c#
// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using var presentation = new Presentation("PowerPoint.ppt");

// 프레젠테이션을 PDF로 저장합니다.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose는 프레젠테이션을 PDF로 변환하는 과정을 보여주는 무료 온라인 [**PowerPoint PDF 변환기**](https://products.aspose.app/slides/ko/conversion/ppt-to-pdf)를 제공합니다. 여기에서 설명한 절차를 실시간으로 구현하려면 이 변환기로 테스트를 실행할 수 있습니다.

{{% /alert %}}

## **옵션을 사용하여 PowerPoint를 PDF로 변환**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/) 클래스 아래의 속성을 통해 결과 PDF를 사용자 지정하고, PDF에 비밀번호를 설정하거나, 변환 프로세스 진행 방식을 지정할 수 있는 사용자 정의 옵션을 제공합니다.

### **사용자 지정 옵션을 사용하여 PowerPoint를 PDF로 변환**

사용자 지정 변환 옵션을 사용하면 래스터 이미지에 대한 선호 품질 설정을 정의하고, 메타파일 처리 방식을 지정하고, 텍스트 압축 수준을 설정하고, 이미지 DPI를 구성하는 등 다양한 옵션을 지정할 수 있습니다.

```c#
// PdfOptions 클래스를 인스턴스화합니다.
var pdfOptions = new PdfOptions
{
    // JPG 이미지 품질을 설정합니다.
    JpegQuality = 90,

    // 이미지 DPI를 설정합니다.
    SufficientResolution = 300,

    // 메타파일 처리 방식을 설정합니다.
    SaveMetafilesAsPng = true,

    // 텍스트 콘텐츠의 압축 수준을 설정합니다.
    TextCompression = PdfTextCompression.Flate,

    // PDF 준수 모드를 정의합니다.
    Compliance = PdfCompliance.Pdf15
};

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using var presentation = new Presentation("PowerPoint.pptx");

// 프레젠테이션을 PDF 문서로 저장합니다.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **숨겨진 슬라이드가 있는 PowerPoint를 PDF로 변환**

프레젠테이션에 숨겨진 슬라이드가 포함된 경우 [PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/) 클래스의 [ShowHiddenSlides](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/showhiddenslides/) 속성을 사용하여 숨겨진 슬라이드를 결과 PDF의 페이지로 포함시킬 수 있습니다.

```c#
// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using var presentation = new Presentation("PowerPoint.pptx");

// PdfOptions 클래스를 인스턴스화합니다.
var pdfOptions = new PdfOptions();

// 숨겨진 슬라이드를 추가합니다.
pdfOptions.ShowHiddenSlides = true;

// 프레젠테이션을 PDF로 저장합니다.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **비밀번호가 보호된 PDF로 PowerPoint 변환**

이 C# 코드는 [PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/) 클래스의 보호 매개변수를 사용하여 PowerPoint 프레젠테이션을 비밀번호 보호 PDF로 변환하는 방법을 보여줍니다:

```c#
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

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/) 클래스 아래의 [WarningCallback](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveoptions/warningcallback/) 속성을 제공하여 프레젠테이션‑to‑PDF 변환 과정에서 글꼴 대체를 감지할 수 있게 합니다.

```c#
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

// 경고 콜백의 구현.
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

{{%  alert color="primary"  %}} 

렌더링 과정에서 글꼴 대체에 대한 콜백을 받는 방법에 대한 자세한 내용은 [글꼴 대체에 대한 경고 콜백 받기](/slides/ko/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)를 참조하십시오.

글꼴 대체에 대한 자세한 내용은 [글꼴 대체](/slides/ko/net/font-substitution/) 문서를 확인하십시오.

{{% /alert %}} 

## **PowerPoint에서 선택된 슬라이드만 PDF로 변환**

이 C# 코드는 PowerPoint 프레젠테이션에서 특정 슬라이드만 선택하여 PDF로 변환하는 방법을 보여줍니다:

```c#
// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using var presentation = new Presentation("PowerPoint.pptx");

// 슬라이드 번호 배열을 설정합니다.
int[] slides = { 1, 3 };

// 프레젠테이션을 PDF로 저장합니다.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **사용자 지정 슬라이드 크기로 PowerPoint를 PDF로 변환**

이 C# 코드는 지정된 슬라이드 크기로 PowerPoint 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다:

```c#
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

// Save the resized presentation to a PDF with notes.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```

## **노트 슬라이드 보기로 PowerPoint를 PDF로 변환**

이 C# 코드는 노트를 포함한 PDF로 PowerPoint 프레젠테이션을 변환하는 방법을 보여줍니다:

```c#
// PowerPoint 프레젠테이션을 로드합니다.
using var presentation = new Presentation("NotesFile.pptx");

// Configure the PDF options with Notes Layout.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Save the presentation to a PDF with notes.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **PDF 접근성 및 준수 표준**

Aspose.Slides는 [웹 콘텐츠 접근성 지침 (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 을 준수하는 변환 절차를 사용할 수 있게 합니다. 다음과 같은 준수 표준 중 하나를 사용하여 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, **PDF/UA**.

이 C# 코드는 다양한 준수 표준에 따라 여러 PDF를 생성하는 PowerPoint‑to‑PDF 변환 프로세스를 보여줍니다:

```c#
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

Aspose.Slides는 PDF 변환 작업을 지원하여 PDF 파일을 인기 있는 파일 형식으로 변환할 수 있습니다. 다음과 같은 변환을 수행할 수 있습니다: [PDF를 HTML로](https://products.aspose.com/slides/ko/net/conversion/pdf-to-html/), [PDF를 이미지로](https://products.aspose.com/slides/ko/net/conversion/pdf-to-image/), [PDF를 JPG로](https://products.aspose.com/slides/ko/net/conversion/pdf-to-jpg/), 그리고 [PDF를 PNG로](https://products.aspose.com/slides/ko/net/conversion/pdf-to-png/) 변환. 또한 특수 형식으로의 변환도 지원됩니다—[PDF를 SVG로](https://products.aspose.com/slides/ko/net/conversion/pdf-to-svg/), [PDF를 TIFF로](https://products.aspose.com/slides/ko/net/conversion/pdf-to-tiff/), [PDF를 XML로](https://products.aspose.com/slides/ko/net/conversion/pdf-to-xml/) 변환도 가능합니다.

{{% /alert %}}

> **Note:** PDF/UA로 내보낼 때 Aspose.Slides는 SmartArt, 차트 및 수식과 같은 복잡한 그래픽을 단일 그림으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며 아티팩트로 표시될 수 있으며, 대체 텍스트는 전체 그림에 대해서만 제공됩니다.

## **FAQ**

**여러 PowerPoint 파일을 한 번에 PDF로 변환할 수 있나요?**

네, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 PDF로 일괄 변환하는 기능을 지원합니다. 파일을 반복하여 프로그래밍 방식으로 변환 프로세스를 적용할 수 있습니다.

**변환된 PDF에 비밀번호를 설정할 수 있나요?**

물론입니다. 변환 과정에서 [PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/) 클래스를 사용하여 비밀번호를 설정하고 접근 권한을 정의할 수 있습니다.

**PDF에 숨겨진 슬라이드를 포함하려면 어떻게 해야 하나요?**

[PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/) 클래스의 `ShowHiddenSlides` 속성을 `true` 로 설정하면 결과 PDF에 숨겨진 슬라이드가 포함됩니다.

**Aspose.Slides가 PDF에서 높은 이미지 품질을 유지할 수 있나요?**

예, [PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/) 클래스의 `JpegQuality` 및 `SufficientResolution` 등 속성을 설정하여 PDF의 이미지 품질을 고품질로 유지할 수 있습니다.

**Aspose.Slides가 PDF/A 준수 표준을 지원하나요?**

네, Aspose.Slides는 PDF/A1a, PDF/A1b 및 PDF/UA 등 다양한 준수 표준에 맞는 PDF를 내보낼 수 있어 문서가 접근성 및 보관 요구 사항을 충족하도록 합니다.

## **추가 리소스**

- [Aspose.Slides for .NET 문서](/slides/ko/net/)
- [Aspose.Slides for .NET API 레퍼런스](https://reference.aspose.com/slides/ko/net/)
- [Aspose 무료 온라인 변환기](https://products.aspose.app/slides/ko/conversion)