---
title: ".NET에서 PPT 및 PPTX를 PDF로 변환 [고급 기능 포함]"
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
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides를 사용하여 .NET에서 PowerPoint PPT/PPTX를 고품질이며 검색 가능한 PDF로 변환하고, 빠른 C# 코드 예제와 고급 변환 옵션을 제공합니다."
---
## **개요**

C#에서 PowerPoint 프레젠테이션(PPT, PPTX, ODP 등)을 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 다양한 장치 간 호환성 및 프레젠테이션 레이아웃과 서식을 유지하는 것이 포함됩니다. 이 가이드는 프레젠테이션을 PDF 문서로 변환하고, 이미지 품질을 제어하는 옵션을 사용하고, 숨겨진 슬라이드를 포함하고, PDF 파일에 비밀번호를 설정하고, 글꼴 대체를 감지하고, 특정 슬라이드를 선택하여 변환하고, 출력 문서에 준수 표준을 적용하는 방법을 보여줍니다.

## **PowerPoint to PDF 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다.

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 클래스에 인수로 전달한 다음 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 메서드를 사용하여 PDF로 저장합니다. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 메서드를 제공합니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET은 출력 문서에 API 정보와 버전 번호를 삽입합니다. 예를 들어 프레젠테이션을 PDF로 변환할 때 Aspose.Slides는 Application 필드에 "*Aspose.Slides*"를, PDF Producer 필드에 "*Aspose.Slides v XX.XX*" 형식의 값을 채웁니다. **주의** 이 정보를 출력 문서에서 변경하거나 제거하도록 Aspose.Slides에 지시할 수 없습니다.
{{% /alert %}}

Aspose.Slides를 사용하면 다음을 변환할 수 있습니다.

* 전체 프레젠테이션을 PDF로
* 프레젠테이션의 특정 슬라이드를 PDF로

Aspose.Slides는 프레젠테이션을 PDF로 내보낼 때 원본 프레젠테이션과 거의 동일하게 PDF를 생성합니다. 변환 과정에서 요소와 속성이 정확하게 렌더링되며, 포함되는 항목은 다음과 같습니다.

* 이미지
* 텍스트 상자 및 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리표
* 표

## **PowerPoint를 PDF로 변환**

표준 PowerPoint‑to‑PDF 변환 프로세스는 기본 옵션을 사용합니다. 이 경우 Aspose.Slides는 가능한 최적의 설정으로 최대 품질 수준에서 제공된 프레젠테이션을 PDF로 변환하려고 시도합니다.

다음 예제는 프레젠테이션을 로드하고 기본 내보내기 설정을 사용하여 모든 표시 가능한 슬라이드를 PDF로 저장합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose는 프레젠테이션‑to‑PDF 변환 프로세스를 보여주는 무료 온라인 [**PowerPoint PDF 변환기**](https://products.aspose.app/slides/conversion/ppt-to-pdf)를 제공합니다. 여기서 설명한 절차를 실제로 테스트하려면 이 변환기를 사용해 보십시오.
{{% /alert %}}

## **PowerPoint를 PDF로 옵션과 함께 변환**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 클래스 아래에 있는 사용자 지정 옵션(속성)을 제공하여 결과 PDF를 맞춤 설정하고, PDF에 비밀번호를 설정하거나, 변환 프로세스가 진행되는 방식을 지정할 수 있습니다.

### **PowerPoint를 PDF로 사용자 지정 옵션과 함께 변환**

사용자 지정 변환 옵션을 사용하면 래스터 이미지에 대한 선호 품질 설정을 정의하고, 메타파일 처리 방식을 지정하고, 텍스트 압축 수준을 설정하고, 이미지에 대한 DPI를 구성하는 등 다양한 옵션을 지정할 수 있습니다.

다음 예제는 JPEG 품질을 90으로, 이미지 해상도를 300 DPI로, 메타파일을 PNG로 저장하고, Flate 텍스트 압축을 적용한 PDF 1.5로 프레젠테이션을 내보냅니다.

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

### **임베디드 OLE 파일을 PDF 첨부 파일로 보존**

프레젠테이션에 임베디드 Excel 워크북이 포함된 경우 PDF 수신자가 워크북 데이터를 액세스하고 슬라이드를 볼 수 있도록 할 수 있습니다. [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/)를 `true`로 설정하면 결과 PDF에 임베디드 OLE 파일이 첨부 파일로 보존됩니다.

기본값은 `false`이며, OLE 개체의 미리보기 이미지 또는 아이콘은 PDF 페이지에 렌더링되지만 임베디드 파일은 첨부 파일로 포함되지 않습니다. 옵션을 `true`로 설정하면 파일 데이터도 추가로 포함됩니다. 미리보기는 시각적 표현으로 남고, 첨부 파일을 통해 수신자는 별도로 파일을 열거나 저장할 수 있습니다. OLE 개체가 PDF 페이지에서 인터랙티브한 Excel 워크시트가 되지는 않습니다.

다음 예제는 이미 임베디드 Excel 워크북을 포함하고 있는 프레젠테이션을 로드하고 워크북이 첨부된 상태로 PDF로 내보냅니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

결과를 확인하려면:

1. 파일 첨부 기능을 지원하는 뷰어(예: Adobe Acrobat Reader)에서 내보낸 PDF를 엽니다.
2. 뷰어의 **Attachments** 패널을 열고 임베디드 워크북을 찾습니다.
3. 첨부 파일을 저장하고 Excel에서 열어 데이터를 확인하거나, 뷰어가 허용하면 직접 엽니다. PDF 페이지의 미리보기는 첨부 파일과 별개입니다.

{{% alert color="info" title="Note" %}}
PDF/A 표준은 첨부 파일에 제한을 둡니다. PDF/A‑1은 임베디드 파일을 금지하고, PDF/A‑2는 PDF/A 첨부 파일만 허용하며, PDF/A‑3은 Excel 워크북을 포함한 기타 파일 유형을 허용합니다. 이는 표준 자체의 요구 사항이며 Aspose.Slides에 특화된 제한이 아닙니다. 이 예제는 기본 PDF 준수 설정을 사용하며 PDF/A 내보내기를 보여주지는 않습니다.
{{% /alert %}}

### **숨겨진 슬라이드를 포함한 PowerPoint를 PDF로 변환**

프레젠테이션에 숨겨진 슬라이드가 포함된 경우 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 클래스의 [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) 속성을 사용하여 숨겨진 슬라이드를 결과 PDF의 페이지로 포함할 수 있습니다.

다음 예제는 숨겨진 슬라이드를 포함하여 프레젠테이션을 PDF로 내보냅니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **비밀번호로 보호된 PDF로 PowerPoint 변환**

다음 예제는 열 때 `password` 비밀번호가 필요한 PDF로 프레젠테이션을 내보냅니다. 접근 권한은 인쇄를 허용하며 고품질 인쇄도 가능합니다.

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

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 클래스 아래에 있는 [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) 속성을 제공하여 프레젠테이션‑to‑PDF 변환 과정에서 글꼴 대체를 감지할 수 있게 합니다.

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
글꼴 대체에 대한 자세한 내용은 [폰트 대체](/slides/ko/net/font-substitution/) 문서를 참조하십시오.
{{% /alert %}} 

## **PowerPoint에서 선택된 슬라이드만 PDF로 변환**

다음 예제는 프레젠테이션에서 슬라이드 1과 3을 선택하여 PDF로 내보냅니다. 이 배열의 슬라이드 번호는 1부터 시작하며, 입력 프레젠테이션에는 최소 세 개의 슬라이드가 있어야 합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **사용자 지정 슬라이드 크기로 PowerPoint를 PDF로 변환**

다음 예제는 프레젠테이션의 첫 번째 슬라이드를 새 프레젠테이션으로 복사하고 슬라이드 크기를 612 × 792 포인트(8.5 × 11 인치)로 설정합니다. 슬라이드 내용은 자동으로 맞춰지고 단일 슬라이드가 PDF로 내보내집니다.

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

다음 예제는 프레젠테이션을 PDF로 내보내면서 각 슬라이드 아래에 발표자 노트를 배치합니다. 결과를 확인하려면 발표자 노트가 포함된 프레젠테이션을 사용하십시오.

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

## **PDF 접근성 및 준수 표준**

Aspose.Slides는 [웹 콘텐츠 접근성 지침 (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 을 준수하는 변환 절차를 사용할 수 있도록 지원합니다. 다음과 같은 준수 표준을 사용하여 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, **PDF/UA**.

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
Aspose.Slides는 PDF 변환 작업을 지원하여 PDF 파일을 일반적인 파일 형식으로 변환할 수 있습니다. 다음과 같은 변환을 수행할 수 있습니다: [PDF를 HTML로](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF를 이미지로](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF를 JPG로](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), [PDF를 PNG로](https://products.aspose.com/slides/net/conversion/pdf-to-png/) 변환. 또한 [PDF를 SVG로](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF를 TIFF로](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), [PDF를 XML로](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)와 같은 특수 형식으로의 변환도 지원합니다.
{{% /alert %}}

> **참고:** PDF/UA로 내보낼 때 Aspose.Slides는 SmartArt, 차트, 수식과 같은 복잡한 그래픽을 단일 도형으로 처리합니다. 개별 경로 요소는 별도의 콘텐츠로 보존되지 않으며 아티팩트로 표시될 수 있으며, 대체 텍스트는 전체 도형에만 제공됩니다.

## **자주 묻는 질문**

**여러 PowerPoint 파일을 한 번에 PDF로 변환할 수 있나요?**

네, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 PDF로 일괄 변환하는 기능을 지원합니다. 파일을 순회하면서 프로그래밍 방식으로 변환 프로세스를 적용하면 됩니다.

**변환된 PDF에 비밀번호를 설정할 수 있나요?**

네. 변환 과정에서 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 클래스를 사용하여 비밀번호와 접근 권한을 설정할 수 있습니다.

**PDF에 숨겨진 슬라이드를 포함하려면 어떻게 해야 하나요?**

[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 클래스의 [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) 속성을 `true`로 설정하면 결과 PDF에 숨겨진 슬라이드가 포함됩니다.

**Aspose.Slides가 PDF에서 높은 이미지 품질을 유지할 수 있나요?**

네, [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 클래스의 [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) 및 [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/)과 같은 속성을 설정하여 PDF에 고품질 이미지를 확보할 수 있습니다.

**Aspose.Slides가 PDF/A 준수 표준을 지원하나요?**

네, Aspose.Slides는 PDF/A1a, PDF/A1b, PDF/UA 등 다양한 표준에 맞는 PDF를 내보낼 수 있어 문서가 접근성 및 보존 요구 사항을 충족하도록 할 수 있습니다.

## **추가 리소스**

- [Aspose.Slides for .NET 문서](/slides/ko/net/)
- [Aspose.Slides for .NET API 레퍼런스](https://reference.aspose.com/slides/net/)
- [Aspose 무료 온라인 변환기](https://products.aspose.app/slides/conversion)