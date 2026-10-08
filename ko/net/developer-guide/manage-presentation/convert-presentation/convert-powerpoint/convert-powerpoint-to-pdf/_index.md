---
title: "PPT 및 PPTX를 .NET에서 PDF로 변환 [고급 기능 포함]"
linktitle: "PowerPoint를 PDF로"
type: docs
weight: 40
url: /ko/net/convert-powerpoint-to-pdf/
keywords:
- "PowerPoint 변환"
- "프레젠테이션 변환"
- "PowerPoint를 PDF로"
- "프레젠테이션을 PDF로"
- "PPT를 PDF로"
- "PPT를 PDF로 변환"
- "PPTX를 PDF로"
- "PPTX를 PDF로 변환"
- "PowerPoint를 PDF로 저장"
- "PPT를 PDF로 저장"
- "PPTX를 PDF로 저장"
- "PPT를 PDF로 내보내기"
- "PPTX를 PDF로 내보내기"
- "첨부 파일"
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides를 사용하여 .NET에서 PowerPoint PPT/PPTX를 고품질의 검색 가능한 PDF로 변환합니다. 빠른 C# 코드 예제와 고급 변환 옵션을 제공합니다."
---
## **개요**

C#에서 PowerPoint 프레젠테이션(PPT, PPTX, ODP 등)을 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 여러 기기 간 호환성 및 프레젠테이션의 레이아웃과 서식을 유지하는 것이 포함됩니다. 이 가이드는 프레젠테이션을 PDF 문서로 변환하는 방법, 이미지 품질을 제어하는 다양한 옵션 사용, 숨김 슬라이드 포함, PDF 파일에 비밀번호 보호, 글꼴 대체 감지, 특정 슬라이드 선택 변환, 그리고 출력 문서에 규정 준수 표준을 적용하는 방법을 보여줍니다.

## **PowerPoint to PDF 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다:

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 인수로 [프레젠테이션](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 클래스에 전달한 다음 [저장](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 메서드를 사용하여 PDF로 저장합니다. [프레젠테이션](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 [저장](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 메서드를 제공합니다.

{{% alert color="info" title="Note" %}}

Aspose.Slides for .NET은 API 정보와 버전 번호를 출력 문서에 삽입합니다. 예를 들어 프레젠테이션을 PDF로 변환할 때 Aspose.Slides는 Application 필드에 "*Aspose.Slides*"를, PDF Producer 필드에 "*Aspose.Slides v XX.XX*" 형태의 값을 채웁니다. **Note** 이 정보는 출력 문서에서 변경하거나 제거하도록 Aspose.Slides에 지시할 수 없습니다.

{{% /alert %}}

Aspose.Slides를 사용하면 다음을 변환할 수 있습니다:

* 전체 프레젠테이션을 PDF로 변환
* 프레젠테이션의 특정 슬라이드를 PDF로 변환

Aspose.Slides는 프레젠테이션을 PDF로 내보내며, 결과 PDF가 원본 프레젠테이션과 거의 일치하도록 합니다. 변환 시 요소와 속성이 정확하게 렌더링됩니다. 포함 항목은 다음과 같습니다:

* 이미지
* 텍스트 상자 및 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리표
* 표

## **PowerPoint를 PDF로 변환**

표준 PowerPoint‑to‑PDF 변환 프로세스는 기본 옵션을 사용합니다. 이 경우 Aspose.Slides는 최적의 설정과 최대 품질 수준으로 제공된 프레젠테이션을 PDF로 변환하려고 시도합니다.

다음 예제는 프레젠테이션을 로드하고 기본 내보내기 설정을 사용하여 모든 보이는 슬라이드를 PDF로 저장합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}

Aspose는 무료 온라인 [**PowerPoint to PDF 변환기**](https://products.aspose.app/slides/conversion/ppt-to-pdf)를 제공하며, 이 도구는 프레젠테이션‑to‑PDF 변환 과정을 시연합니다. 여기에서 변환기를 사용해 실시간으로 절차를 테스트할 수 있습니다.

{{% /alert %}}

## **옵션을 사용한 PowerPoint to PDF 변환**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 클래스 아래에 있는 속성을 통해 결과 PDF를 사용자 지정하고, PDF에 비밀번호를 설정하거나 변환 프로세스 진행 방식을 지정할 수 있는 사용자 지정 옵션을 제공합니다.

### **사용자 지정 옵션을 사용한 PowerPoint to PDF 변환**

사용자 지정 변환 옵션을 사용하면 래스터 이미지의 품질 설정, 메타파일 처리 방식, 텍스트 압축 수준, 이미지 DPI 등을 정의할 수 있습니다.

다음 예제는 JPEG 품질을 90으로, 이미지 해상도를 300 DPI로, 메타파일을 PNG로 저장하고, Flate 텍스트 압축을 적용하여 PDF 1.5로 프레젠테이션을 내보냅니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **임베드된 OLE 파일을 PDF 첨부 파일로 보존**

프레젠테이션에 임베드된 Excel 워크북이 포함된 경우, PDF 수신자가 슬라이드와 함께 워크북 데이터를 액세스하도록 할 수 있습니다. [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/)를 `true` 로 설정하면 임베드된 OLE 파일이 결과 PDF에 첨부 파일로 보존됩니다.

기본값은 `false`이며, 이 경우 OLE 객체의 미리 보기 이미지 또는 아이콘이 PDF 페이지에 렌더링되지만 임베드된 파일은 첨부 파일로 포함되지 않습니다. 옵션을 `true` 로 설정하면 파일 데이터가 추가로 포함됩니다. 미리 보기는 시각적 표시만 남으며, 첨부 파일을 통해 수신자는 별도로 파일을 열거나 저장할 수 있습니다. OLE 객체가 PDF 페이지에서 대화형 Excel 워크시트가 되지는 않습니다.

다음 예제는 이미 임베드된 Excel 워크북을 포함하는 프레젠테이션을 로드하고 워크북을 첨부 파일로 포함하여 PDF로 내보냅니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

결과를 확인하려면:

1. 파일 첨부 기능을 지원하는 뷰어(예: Adobe Acrobat Reader)에서 내보낸 PDF를 엽니다.
2. 뷰어의 **첨부 파일** 패널을 열고 임베드된 워크북을 찾습니다.
3. 첨부 파일을 저장하고 Excel에서 열어 데이터를 확인하거나, 뷰어가 허용하는 경우 바로 엽니다. PDF 페이지의 미리 보기와 첨부 파일은 별개입니다.

{{% alert color="info" title="Note" %}}

PDF/A 표준은 첨부 파일에 제한을 둡니다: PDF/A‑1은 임베드된 파일을 금지하고, PDF/A‑2는 PDF/A 첨부 파일만 허용하며, PDF/A‑3은 Excel 워크북을 포함한 기타 파일 유형을 허용합니다. 이는 표준의 요구사항이며 Aspose.Slides 고유의 제한이 아닙니다. 이 예제는 기본 PDF 규정 준수 설정을 사용하며 PDF/A 내보내기를 보여주지는 않습니다.

{{% /alert %}}

### **숨김 슬라이드를 포함한 PowerPoint to PDF 변환**

프레젠테이션에 숨김 슬라이드가 포함된 경우, [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 클래스의 [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) 속성을 사용하여 숨김 슬라이드를 결과 PDF의 페이지로 포함할 수 있습니다.

다음 예제는 숨김 슬라이드를 포함하여 프레젠테이션을 PDF로 내보냅니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **비밀번호 보호된 PDF로 PowerPoint 변환**

다음 예제는 열 때 `password` 비밀번호가 필요한 PDF로 프레젠테이션을 내보냅니다. 접근 권한은 인쇄를 허용하며, 고품질 인쇄도 포함합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **글꼴 대체 감지**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 클래스 아래에 있는 [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) 속성을 제공하여 프레젠테이션‑to‑PDF 변환 과정에서 글꼴 대체를 감지할 수 있습니다.

다음 예제는 프레젠테이션을 PDF로 내보내고 콘솔에 글꼴 대체 경고를 출력합니다. 사용 불가능한 글꼴이 대체될 때만 경고가 출력됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}

글꼴 대체에 대한 자세한 내용은 [Font Substitution](/slides/ko/net/font-substitution/) 문서를 참조하십시오.

{{% /alert %}} 

### **전용 굵은 글꼴이 없는 경우 처리**

프레젠테이션은 글꼴에 전용 굵은 글꼴이 없더라도 굵게 서식을 적용할 수 있습니다. 이 경우 합성 굵게가 적용되어 일반 글리프가 인위적으로 두꺼워집니다. PDF에서 해당 텍스트가 너무 두껍게 보이거나 의도와 다르게 표시되는 경우, [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/)를 `true` 로 설정해 보십시오. 이 옵션은 PDF 내보내기 중 영향을 받는 텍스트를 비트맵으로 렌더링하여 특정 글꼴에서 외관을 개선할 수 있습니다. 기본값은 `false`입니다.

샘플 프레젠테이션에는 일반 텍스트 상자와 같은 글꼴에 굵게 서식만 적용된 텍스트 상자가 있습니다(전용 굵은 글꼴이 없음). 다음 예제는 프레젠테이션을 로드하고 전용 굵은 글꼴이 없는 경우 래스터화를 활성화한 뒤 PDF로 내보냅니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

아래 예시는 옵션이 비활성화된 출력과 활성화된 출력을 보여줍니다. 이 예제에서는 옵션이 비활성화된 경우 굵은 텍스트가 더 두꺼운 획을 갖습니다. 옵션을 활성화하면 굵은 텍스트의 획이 더 가벼워지고, 일반 텍스트는 변하지 않습니다. 프레젠테이션에 적용할 설정을 선택하기 전에 결과를 비교하십시오.

| 옵션 비활성화 (`false`, 기본값) | 옵션 활성화 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

이 예제에서 옵션을 활성화하면 굵은 텍스트만 비트맵으로 변환됩니다: OCR 없이 텍스트로 선택, 복사 또는 검색할 수 없으며, 800% 확대 시 가장자리가 더 부드럽게 보입니다. 일반 텍스트는 검색이 가능합니다. 옵션을 비활성화하면 두 문자열 모두 텍스트 상태를 유지합니다.

이 옵션은 전용 굵은 글꼴이 없는 경우 굵게 서식된 텍스트를 래스터화합니다. [Font substitution](/slides/ko/net/font-substitution/)은 원본 글꼴을 사용할 수 없을 때 다른 글꼴을 선택합니다.

## **선택한 슬라이드를 PDF로 변환**

다음 예제는 프레젠테이션에서 슬라이드 1과 3을 선택하여 PDF로 내보냅니다. 이 배열의 슬라이드 번호는 1부터 시작하며, 입력 프레젠테이션에 최소 세 개의 슬라이드가 있어야 합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **맞춤 슬라이드 크기로 PowerPoint를 PDF로 변환**

다음 예제는 프레젠테이션의 첫 번째 슬라이드를 새 프레젠테이션에 복사하고 슬라이드 크기를 612 × 792 포인트(8.5 × 11 인치)로 설정합니다. 슬라이드 내용을 맞추어 확대하고 단일 슬라이드를 PDF로 내보냅니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **노트 슬라이드 보기에서 PowerPoint를 PDF로 변환**

다음 예제는 프레젠테이션을 PDF로 내보내며, 각 슬라이드 아래에 발표자 노트를 배치합니다. 결과를 보려면 발표자 노트가 포함된 프레젠테이션을 사용하십시오.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **PDF에 대한 접근성 및 규정 준수 표준**

Aspose.Slides는 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 를 준수하는 변환 절차를 사용할 수 있게 해줍니다. 다음 규정 준수 표준 중 하나를 사용하여 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, **PDF/UA**.

다음 C# 코드는 다양한 규정 준수 표준에 따라 여러 PDF를 생성하는 PowerPoint‑to‑PDF 변환 프로세스를 시연합니다:

```csharp
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

{{% alert color="info" title="Note" %}}

Aspose.Slides는 PDF 변환 작업을 지원하며, PDF 파일을 다양한 인기 형식으로 변환할 수 있습니다. [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) 변환을 수행할 수 있습니다. 또한 [PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) 등 특수 형식으로의 변환도 지원됩니다.

{{% /alert %}}

> **Note:** PDF/UA로 내보낼 때 Aspose.Slides는 스마트아트, 차트, 수식과 같은 복잡한 그래픽을 단일 그림으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며 아티팩트로 표시될 수 있습니다; 대체 텍스트는 전체 그림에 대해서만 제공됩니다.

## **FAQ**

**여러 PowerPoint 파일을 일괄적으로 PDF로 변환할 수 있나요?**

예, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 PDF로 배치 변환하는 기능을 지원합니다. 파일을 순회하면서 프로그래밍 방식으로 변환 프로세스를 적용할 수 있습니다.

**변환된 PDF에 비밀번호를 설정할 수 있나요?**

예. 변환 과정에서 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 클래스를 사용해 비밀번호를 설정하고 접근 권한을 정의할 수 있습니다.

**PDF에 숨김 슬라이드를 포함하려면 어떻게 해야 하나요?**

[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 클래스의 [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) 속성을 `true` 로 설정하면 결과 PDF에 숨김 슬라이드가 포함됩니다.

**Aspose.Slides가 PDF에서 높은 이미지 품질을 유지할 수 있나요?**

예. [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) 및 [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/)과 같은 속성을 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 클래스에 설정하여 PDF의 이미지 품질을 높게 유지할 수 있습니다.

**Aspose.Slides가 PDF/A 규정 준수 표준을 지원하나요?**

예. Aspose.Slides는 PDF/A1a, PDF/A1b, PDF/UA 등 다양한 표준을 준수하는 PDF 내보내기를 지원하여 문서가 접근성과 보관 요구 사항을 충족하도록 합니다.

## **추가 자료**

- [Aspose.Slides for .NET Documentation](/slides/ko/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)