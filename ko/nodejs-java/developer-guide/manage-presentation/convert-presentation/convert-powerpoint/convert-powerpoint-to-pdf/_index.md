---
title: JavaScript에서 PPT 및 PPTX를 PDF로 변환 [고급 기능 포함]
linktitle: PowerPoint를 PDF로
type: docs
weight: 40
url: /ko/nodejs-java/convert-powerpoint-to-pdf/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 PowerPoint PPT/PPTX를 고품질이며 검색 가능한 PDF로 변환합니다. 빠른 코드 예제와 고급 변환 옵션을 제공합니다."
---
## **개요**

JavaScript에서 PowerPoint 및 OpenDocument 프레젠테이션(PPT, PPTX, ODP 등)을 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 다양한 장치 간 호환성 및 프레젠테이션의 레이아웃과 서식을 보존하는 것이 포함됩니다. 이 가이드에서는 프레젠테이션을 PDF 문서로 변환하는 방법, 이미지 품질을 제어하는 다양한 옵션 사용, 숨김 슬라이드 포함, PDF 파일에 비밀번호 보호, 글꼴 대체 감지, 특정 슬라이드 선택 변환, 및 출력 문서에 규정 준수 표준 적용 방법을 보여줍니다.

## **PowerPoint를 PDF로 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다:

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 매개변수로 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 클래스에 전달한 다음 [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) 메서드를 사용하여 프레젠테이션을 PDF로 저장합니다. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) 메서드를 노출합니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java는 API 정보와 버전 번호를 출력 문서에 삽입합니다. 예를 들어, 프레젠테이션을 PDF로 변환할 때 Aspose.Slides는 Application 필드에 "*Aspose.Slides*"를, PDF Producer 필드에 "*Aspose.Slides v XX.XX*" 형태의 값을 채웁니다. **Note** 이 정보는 출력 문서에서 변경하거나 제거하도록 Aspose.Slides에 지시할 수 없습니다.
{{% /alert %}}

Aspose.Slides를 사용하면 다음을 변환할 수 있습니다:

* 전체 프레젠테이션을 PDF로
* 프레젠테이션의 특정 슬라이드를 PDF로

Aspose.Slides는 프레젠테이션을 PDF로 내보내어 결과 PDF가 원본 프레젠테이션과 매우 유사하도록 보장합니다. 변환 시 정확하게 렌더링되는 요소와 속성은 다음과 같습니다:

* 이미지
* 텍스트 상자 및 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리표
* 표

## **PowerPoint를 PDF로 변환**

표준 PowerPoint-to-PDF 변환 프로세스는 기본 옵션을 사용합니다. 이 경우 Aspose.Slides는 최적의 설정과 최대 품질 수준을 사용하여 제공된 프레젠테이션을 PDF로 변환하려고 시도합니다.

다음 예제는 프레젠테이션을 로드하고 기본 내보내기 설정을 사용하여 모든 표시 슬라이드를 PDF로 저장합니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose는 프레젠테이션을 PDF로 변환하는 과정을 보여주는 무료 온라인 [**PowerPoint PDF 변환기**](https://products.aspose.app/slides/conversion/ppt-to-pdf)를 제공합니다. 여기서 설명된 절차를 실시간으로 테스트하려면 이 변환기를 사용할 수 있습니다.
{{% /alert %}}

## **PowerPoint를 PDF로 옵션과 함께 변환**

Aspose.Slides는 결과 PDF를 사용자 지정하고, PDF에 비밀번호를 설정하거나, 변환 프로세스 진행 방식을 지정할 수 있는 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 클래스 아래의 사용자 지정 옵션—속성을 제공합니다.

### **PowerPoint를 PDF로 사용자 지정 옵션과 함께 변환**

사용자 지정 변환 옵션을 사용하면 래스터 이미지에 대한 선호 품질 설정을 정의하고, 메타파일 처리 방식을 지정하고, 텍스트 압축 수준을 설정하며, 이미지 DPI를 구성하는 등 다양한 작업을 수행할 수 있습니다.

다음 예제는 JPEG 품질을 90으로, 이미지 해상도를 300 DPI로, 메타파일을 PNG로 저장하고, Flate 텍스트 압축을 적용하여 PDF 1.5로 프레젠테이션을 내보냅니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **임베드된 OLE 파일을 PDF 첨부 파일로 보존**

프레젠테이션에 임베드된 Excel 워크북이 포함되어 있는 경우 PDF 수신자가 워크북 데이터를 접근하고 슬라이드를 볼 수 있기를 원할 수 있습니다. 결과 PDF에 임베드된 OLE 파일을 첨부 파일로 보존하려면 `true`와 함께 [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)를 호출하십시오.

기본값은 `false`이며, OLE 객체의 미리보기 이미지 또는 아이콘은 PDF 페이지에 렌더링되지만 임베드된 파일은 첨부 파일로 포함되지 않습니다. 옵션을 `true`로 설정하면 파일 데이터가 추가로 포함됩니다. 미리보기는 시각적 표현으로 남으며, 첨부 파일을 통해 수신자는 임베드된 파일을 별도로 열거나 저장할 수 있습니다. OLE 객체는 PDF 페이지에서 인터랙티브한 Excel 워크시트가 되지 않습니다.

다음 예제는 이미 임베드된 Excel 워크북을 포함하고 있는 프레젠테이션을 로드하고 워크북이 첨부된 상태로 PDF로 내보냅니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

결과를 확인하려면:

1. Adobe Acrobat Reader와 같이 파일 첨부를 지원하는 뷰어에서 내보낸 PDF를 엽니다.
2. 뷰어의 **Attachments** 패널을 열고 임베드된 워크북을 찾습니다.
3. 첨부 파일을 저장하고 Excel에서 열어 데이터를 확인하거나, 뷰어가 허용하면 직접 엽니다. PDF 페이지의 미리보기는 첨부 파일과 별개입니다.

{{% alert color="info" title="Note" %}}
PDF/A 표준은 첨부 파일에 제한을 두고 있습니다: PDF/A-1은 임베드된 파일을 금지하고, PDF/A-2는 PDF/A 첨부 파일만 허용하며, PDF/A-3는 Excel 워크북을 포함한 기타 파일 유형을 허용합니다. 이는 표준의 요구 사항이며 Aspose.Slides에만 해당되는 제한이 아닙니다. 이 예제는 기본 PDF 규정 준수 설정을 사용하며 PDF/A 내보내기를 시연하지 않습니다.
{{% /alert %}}

### **숨김 슬라이드가 포함된 PowerPoint를 PDF로 변환**

프레젠테이션에 숨김 슬라이드가 포함된 경우, [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 클래스의 [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) 메서드를 사용하여 숨김 슬라이드를 결과 PDF의 페이지로 포함할 수 있습니다.

다음 예제는 숨김 슬라이드를 포함하여 프레젠테이션을 PDF로 내보냅니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **비밀번호로 보호된 PDF로 PowerPoint 변환**

다음 예제는 열려면 `password` 비밀번호가 필요한 PDF로 프레젠테이션을 내보냅니다. 접근 권한은 인쇄를 허용하며, 고품질 인쇄도 포함됩니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **글꼴 대체 감지**

Aspose.Slides는 프레젠테이션을 PDF로 변환하는 과정에서 글꼴 대체를 감지할 수 있도록 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 클래스 아래의 [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) 메서드를 제공합니다.

다음 예제는 프레젠테이션을 PDF로 내보내고 콘솔에 글꼴 대체 경고를 출력합니다. 경고는 사용 불가능한 글꼴이 내보내기 중에 대체될 때만 표시됩니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
글꼴 대체에 대한 자세한 내용은 [글꼴 대체](/slides/ko/nodejs-java/font-substitution/) 문서를 참조하십시오.
{{% /alert %}} 

### **전용 굵은 글꼴이 없는 글꼴 처리**

프레젠테이션은 글꼴에 전용 굵은 형태가 없더라도 텍스트에 굵게 서식을 적용할 수 있습니다. 이 경우 합성 굵게 처리(synthetic bolding)를 통해 일반 글리프를 인위적으로 두껍게 하여 굵게 표시됩니다. 해당 텍스트가 PDF에서 너무 무겁게 보이거나 의도와 다르게 보이면 [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)를 `true`와 함께 호출해 보십시오. 이 옵션은 영향을 받는 텍스트를 PDF 내보내기 시 비트맵으로 렌더링하여 특정 글꼴의 외관을 개선할 수 있습니다. 기본값은 `false`입니다.

샘플 프레젠테이션에는 두 개의 텍스트 상자가 포함되어 있습니다: 하나는 일반 텍스트이고, 다른 하나는 동일한 글꼴에 굵게 서식이 적용되어 있지만 전용 굵은 형태가 없습니다. 다음 예제는 프레젠테이션을 로드하고, 지원되지 않는 글꼴 스타일의 래스터화를 활성화한 뒤 PDF로 내보냅니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

다음 미리보기는 옵션이 비활성화된 출력과 활성화된 출력을 보여줍니다. 이 예에서 옵션이 비활성화될 경우 굵은 텍스트의 획이 더 두껍게 나타납니다. 옵션을 활성화하면 획이 더 가벼워지고, 일반 텍스트는 변하지 않습니다. 설정을 선택하기 전에 결과를 비교하십시오.

| 옵션 비활성화 (`false`, 기본값) | 옵션 활성화 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

이 예에서 옵션을 활성화하면 굵은 텍스트만 비트맵으로 변환됩니다: OCR 없이 텍스트로 선택, 복사, 검색이 불가능하고, 800% 확대 시 가장자리가 부드럽게 보입니다. 일반 텍스트는 검색 가능 상태를 유지합니다. 옵션이 비활성화된 경우 두 문자열 모두 텍스트로 유지됩니다.

이 옵션은 글꼴에 전용 굵은 형태가 없을 때 굵게 서식이 적용된 텍스트를 래스터화합니다. [글꼴 대체](/slides/ko/nodejs-java/font-substitution/)는 원본 글꼴을 사용할 수 없을 때 다른 글꼴을 선택합니다.

## **PowerPoint에서 선택된 슬라이드를 PDF로 변환**

다음 예제는 프레젠테이션에서 슬라이드 1과 3을 PDF로 내보냅니다. 이 배열의 슬라이드 번호는 1부터 시작하며, 입력 프레젠테이션에는 최소 세 개의 슬라이드가 있어야 합니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **PowerPoint를 사용자 지정 슬라이드 크기로 PDF 변환**

다음 예제는 프레젠테이션에서 첫 번째 슬라이드를 612 × 792 포인트(8.5 × 11 인치) 슬라이드 크기의 새 프레젠테이션으로 복사합니다. 슬라이드 콘텐츠를 맞게 스케일링하고 단일 슬라이드를 PDF로 내보냅니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // 새 프레젠테이션이 생성될 때 포함된 빈 슬라이드를 제거합니다.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **노트 슬라이드 보기에서 PowerPoint를 PDF로 변환**

다음 예제는 프레젠테이션을 PDF로 내보내며 각 슬라이드의 발표자 노트를 슬라이드 아래에 배치합니다. 결과를 보려면 발표자 노트가 포함된 프레젠테이션을 사용하십시오.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF에 대한 접근성 및 규정 준수 표준**

Aspose.Slides는 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html)를 준수하는 변환 절차를 사용할 수 있게 합니다. 다음 규정 준수 표준 중 하나를 사용하여 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, 및 **PDF/UA**.

다음 코드는 다양한 규정 준수 표준에 따라 여러 PDF를 생성하는 PowerPoint-to-PDF 변환 프로세스를 보여줍니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides는 PDF 변환 작업을 지원하여 PDF 파일을 일반적인 파일 형식으로 변환할 수 있습니다. [PDF를 HTML로](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF를 JPG로](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), 및 [PDF를 PNG로](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) 변환을 수행할 수 있습니다. 특수 형식으로의 다른 PDF 변환 작업—[PDF를 SVG로](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF를 TIFF로](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)—도 지원됩니다.
{{% /alert %}}

> **Note:** PDF/UA로 내보낼 때 Aspose.Slides는 SmartArt, 차트 및 수식과 같은 복합 그래픽을 단일 도형으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며 아티팩트로 표시될 수 있습니다; 대체 텍스트는 전체 도형에만 제공됩니다.

## **FAQ**

**여러 PowerPoint 파일을 한 번에 PDF로 변환할 수 있나요?**  
네, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 PDF로 일괄 변환하는 것을 지원합니다. 파일을 순회하면서 프로그래밍 방식으로 변환 프로세스를 적용할 수 있습니다.

**변환된 PDF에 비밀번호를 설정할 수 있나요?**  
네. 변환 과정에서 비밀번호를 설정하고 접근 권한을 정의하려면 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 클래스를 사용하십시오.

**PDF에 숨김 슬라이드를 포함하려면 어떻게 해야 하나요?**  
[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 클래스에서 `true`와 함께 [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/)를 호출하면 결과 PDF에 숨김 슬라이드가 포함됩니다.

**Aspose.Slides가 PDF에서 높은 이미지 품질을 유지할 수 있나요?**  
네, PDF에서 고품질 이미지를 보장하기 위해 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 클래스의 [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) 및 [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/)와 같은 메서드를 사용하여 이미지 품질을 제어할 수 있습니다.

**Aspose.Slides가 PDF/A 규정 준수 표준을 지원하나요?**  
네, Aspose.Slides는 [다양한 표준](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/)을 준수하는 PDF를 내보낼 수 있으며, 여기에는 PDF/A1a, PDF/A1b 및 PDF/UA가 포함되어 있어 문서가 접근성 및 보관 요건을 충족하도록 합니다.

## **Additional Resources**

- [Aspose.Slides for Node.js via Java 문서](/slides/ko/nodejs-java/)
- [Aspose.Slides for Node.js via Java API 레퍼런스](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose 무료 온라인 변환기](https://products.aspose.app/slides/conversion)